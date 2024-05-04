using BankCRM.Data.IRepositories;
using BankCRM.Data.Repositories;
using BankCRM.Domain.Entities;
using BankCRM.Service.DTOs;
using BankCRM.Service.Helpers;
using BankCRM.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRM.Service.Services
{
    public class UserService : IUserService
    {
        private int _id;
        private IUserRepository _userRepository = new UserRepository();

        public UserService()
        {
            var users  = _userRepository.GetAll().ToList();
            if (users.Count == 0)
            {
                _id = 1;
            }else
            {
                var user = users[users.Count - 1];
                _id = user.Id++;
            }
        }
        public Response Create(UserDto dto)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x=>x.Email.ToLower()==dto.Email.ToLower());
            if (user != null)
            {
                return new Response()
                {
                    StatusCode = 409,
                    Message = "User is already exist!",
                    User = user
                };
            }
            User person = new User();
            person.Id = _id;
            person.Email = dto.Email;
            person.FirstName = dto.FirstName;
            person.LastName = dto.LastName;
            person.Password = dto.Password;
            person.CreatedDate=DateTime.Now;
            person.UserType=dto.UserType;
            _userRepository.Create(person);

            return new Response()
            {
                StatusCode = 200,
                Message = "Success",
                User = person
            };
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ListResponse GetAll()
        {
            throw new NotImplementedException();
        }

        public Response GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response Update(int id, UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
