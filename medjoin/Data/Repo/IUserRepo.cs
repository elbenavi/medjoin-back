using medjoin.Dto;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        User GetUserByEmailAndPassword(string user, string password);
        IEnumerable<UserDoctorReadDto> GetDoctors();
        void UpdateUser(User user, User userUpdated);
        void UpdateUserProfile(User user, string imgProfile);
        User GetUserById(int id);
    }
}
