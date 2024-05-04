using BankCRM.Service.DTOs;
using BankCRM.Service.Helpers;

namespace BankCRM.Service.Interface
{
    public interface IUserService
    {
        public Response Create(UserDto dto);
        public Response Update(int id,UserDto dto);
        public Response Delete(int id);
        public Response GetById(int id);
        public ListResponse GetAll();

    }
}
