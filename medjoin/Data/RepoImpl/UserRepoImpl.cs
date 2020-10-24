using medjoin.Data.Repo;
using medjoin.Dto;
using medjoin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class UserRepoImpl : IUserRepo
    {
        public Context _context { get; }

        public UserRepoImpl(Context context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }

        public IEnumerable<UserDoctorReadDto> GetDoctors()
        {
            var doctors = _context.Users.Where(d => d.IsDoctor).Select(d => new UserDoctorReadDto
            {
                Id = d.Id,
                Email = d.Email,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Country = d.Country,
                ImgProfile = d.ImgProfile,
                State = d.State,
                City = d.City,
                Ext = d.Ext,
                Phone = d.Phone,
                Date = d.Date,
                Gender = d.Gender,
                Height = d.Height,
                Weight = d.Weight,
                Aboutyou = d.Aboutyou,
                Address = d.Address,
                IsDoctor = d.IsDoctor,
                Rol = d.Rol,
                MedicalDetail = _context.MedicalDetails.FirstOrDefault(m => m.UserId == d.Id)

            }).ToList();

            return doctors;
            // return _context.Users.Where(d => d.IsDoctor).Include(d => d.me).ToList();
        }

        public void UpdateUser(User user, User userUpdated)
        {
            user.Aboutyou = userUpdated.Aboutyou;
            user.Address = userUpdated.Address;
            user.City = userUpdated.City;
            user.Country = userUpdated.Country;
            user.Date = userUpdated.Date;
            user.Email = userUpdated.Email;
            user.Ext = userUpdated.Ext;
            user.FirstName = userUpdated.FirstName;
            user.Gender = userUpdated.Gender;
            user.Height = userUpdated.Height;
            user.LastName = userUpdated.LastName;
            user.Phone = userUpdated.Phone;
            user.State = userUpdated.State;
            user.Weight = userUpdated.Weight;
            _context.SaveChanges();

        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUserProfile(User user, string imgProfile)
        {
            user.ImgProfile = imgProfile;
            _context.SaveChanges();
        }
    }
}
