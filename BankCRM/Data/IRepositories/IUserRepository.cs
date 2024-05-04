using BankCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRM.Data.IRepositories
{
    public interface IUserRepository
    {
        public User Create(User user);
        public User Update(User user);
        public bool Delete(int id);
        public User GetById(int id);
        public IEnumerable<User> GetAll();
    }
}
