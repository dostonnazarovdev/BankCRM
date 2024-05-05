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
        private IUserRepository userRepository = new UserRepository();

        public UserService()
        {
            var users  = userRepository.GetAll().ToList();
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
            var user = userRepository.GetAll().FirstOrDefault(x=>x.Email.ToLower()==dto.Email.ToLower());
            if (user != null)
            {
                return new Response()
                {
                    StatusCode = 409,
                    Message = "User is already exist!",
                    IsAvailable=false,
                    User = user
                };
            }
            User person = new User()
            {
                Id = _id,
                FirstName= dto.FirstName,
                LastName= dto.LastName,
                Email = dto.Email,
                Password= dto.Password,
                CreatedDate= DateTime.Now,
                UserType= dto.UserType
            };
      
            userRepository.Create(person);

            return new Response()
            {
                StatusCode = 200,
                Message = "Success",
                IsAvailable=true,
                User = person
            };
        }

        public Response Delete(int id)
        {
          var user = userRepository.GetById(id);
            if (user == null)
            {
                return new Response()
                {
                    StatusCode = 404,
                    Message = "User is not found!"
                };
            }
            return new Response()
            {
                StatusCode = 200,
                Message = "Success",
                IsAvailable=true,
                User = null
            };
        }

        public ListResponse GetAll()
        {
           var users = userRepository.GetAll().ToList();
            return new ListResponse()
            {
                StatusCode=200,
                Message="Success",
                Users=users
            };
        }

        public Response GetById(int id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
            {
                return new Response()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    IsAvailable = false,
                    User = null
                };
            }
            
                return new Response()
                {
                    StatusCode = 200,
                    Message = "Success",
                    IsAvailable = true,
                    User = user
                };

        }

        public Response Update(int id, UserDto dto)
        {
            var user = userRepository.GetById(id);
            if(user == null)
            {
                return new Response()
                {
                    StatusCode = 404,
                    Message = "User is not found!",
                    IsAvailable = false,
                    User = null
                };
            }

            var person = new User()
            {
                Id = id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserType = dto.UserType,
                CreatedDate=DateTime.Now
            };
            
            userRepository.Create(person);

            return new Response()
            {
                StatusCode = 200,
                Message = "Success",
                IsAvailable = true,
                User = person
            };
        }
    }
}
