using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using medjoin.Commons;
using medjoin.Data.Repo;
using medjoin.Dto;
using medjoin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace medjoin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private IConfiguration _configuration { get; }

        public UsersController(IUserRepo repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        public ActionResult<IEnumerable<User>> GetCredentials()
        {
            var credentials = _repo.GetUsers();
            return Ok(credentials);
        }

        [AllowAnonymous]
        [HttpGet("doctors")]
        public ActionResult<IEnumerable<UserDoctorReadDto>> GetDoctors()
        {
            var doctors = _repo.GetDoctors();
            return Ok(doctors);
        }

        [HttpPost("data")]
        public ActionResult<User> GetUser(UserLogin credential)
        {
            Console.WriteLine("-------------------------------------- " + credential);
            var user = _repo.GetUserByEmailAndPassword(credential.Email, EncryptedDecryted.ConvertToEncrypt(credential.Password));
            Console.WriteLine("-------------------------------------- " + user);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, User user)
        {
            var userTemp = _repo.GetUserById(id);
            if (userTemp == null)
            {
                return NotFound();
            }
            _repo.UpdateUser(userTemp, user);
            return Ok(userTemp);
        }

        [HttpPut("{id}/profile")]
        public ActionResult<User> UpdateUser(int id, ImageProfile profile)
        {
            var userTemp = _repo.GetUserById(id);
            if (userTemp == null)
            {
                return NotFound();
            }
            _repo.UpdateUserProfile(userTemp, profile.ImgProfile);
            return Ok(userTemp);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateCredential(User credential)
        {
            var newUser = credential;
            newUser.Password = EncryptedDecryted.ConvertToEncrypt(newUser.Password);
            _repo.CreateUser(newUser);
            var user = _repo.GetUserByEmailAndPassword(credential.Email, newUser.Password);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login(UserLogin userLogin)
        {
            var user = _repo.GetUserByEmailAndPassword(userLogin.Email, EncryptedDecryted.ConvertToEncrypt(userLogin.Password));

            if (user != null)
            {
                return Ok(new { token = GenerarTokenJWT(user) });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("upload/profile"), DisableRequestSizeLimitAttribute]
        public IActionResult UploadProfile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Profiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileNameArray = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"').Split("@");
                    var fileNameToDelete = fileNameArray[0];
                    var fileName = fileNameArray[1];

                    Console.WriteLine("FilenameCreated " + fileName);
                    Console.WriteLine("fileNameToDelete " + fileNameToDelete);
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    try
                    {
                        // Check if file exists with its full path    
                        if (System.IO.File.Exists(Path.Combine(pathToSave, fileNameToDelete)))
                        {
                            // If file found, delete it    
                            System.IO.File.Delete(Path.Combine(pathToSave, fileNameToDelete));
                        
                        }
                        else Console.WriteLine("File not found");
                    }
                    catch (IOException ioExp)
                    {
                        Console.WriteLine(ioExp.Message);
                    }
                    // System.Threading.Thread.Sleep(10000);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {                        
                        file.CopyTo(stream);
                    }

                    return Ok(new { fileName });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("upload"), DisableRequestSizeLimitAttribute]
        [AllowAnonymous]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                Console.WriteLine("file", file);
                var folderName = Path.Combine("Resources", "Files");
                Console.WriteLine("folderName", folderName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                
                
                Console.WriteLine("pathToSave", pathToSave);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private string GenerarTokenJWT(User usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:ClaveSecreta"))
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.FirstName),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            // CREAMOS EL PAYLOAD //
            // var date = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            // var date = DateTime.Now;
            var date = DateTime.UtcNow;

            var _Payload = new JwtPayload(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: _Claims,
                    notBefore: date,
                    // Exipra a la 24 horas.
                    expires: date.AddHours(8)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}