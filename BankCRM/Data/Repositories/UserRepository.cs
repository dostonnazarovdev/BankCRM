using BankCRM.Data.IRepositories;
using BankCRM.Domain.Configurations;
using BankCRM.Domain.Entities;
using BankCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRM.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        string path = DatabasePath.Path;
        public User Create(User user)
        {
            string person = $"{user.Id}|{user.FirstName}|{user.LastName}|{user.Email}|{user.Password}|{user.CreatedDate} |{user.UserType}\n";
            File.AppendAllText(path, person);
            return user;
        }

        public bool Delete(int id)
        {
            bool isAvailabe = false;
            var users = GetAll();
            File.WriteAllText(path, "");
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    isAvailabe = true;
                    continue;
                }
                Create(user);
            }
            return isAvailabe;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> list = new List<User>();
            string[] users = File.ReadAllLines(path);
            foreach (string item in users)
            {
                try
                {

                string[] arr = item.Split('|');
                User person = new User();
                person.Id = Convert.ToInt32(arr[0]);
                person.FirstName = arr[1];
                person.LastName = arr[2];
                person.Email = arr[3];
                person.Password = arr[4];
                person.CreatedDate = DateTime.Parse(arr[5]);
                    // person.UserType = (Domain.Enums.UserType)Enum.Parse(typeof(User), arr[6]);

                    if (int.Parse(arr[6]) == 0)
                    {
                        person.UserType = UserType.Male;  
                    }
                    else if (int.Parse(arr[6]) == 1)
                    {
                        person.UserType = UserType.Famele;
                    }
                list.Add(person);
                }catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return list;
        }

        public User GetById(int id)
        {
            var users = GetAll();
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public User Update(User user)
        {
            var users = GetAll();
            File.WriteAllText(path, "");
            User modifiedUser = null;
            foreach (var item in users)
            {
                if (item.Id == user.Id)
                {
                    item.Id = user.Id;
                    item.FirstName = user.FirstName;
                    item.LastName = user.LastName;
                    item.Email = user.Email;
                    item.Password = user.Password;
                    item.CreatedDate = user.CreatedDate;
                    modifiedUser = item;
                }
                Create(item);
            }
            return modifiedUser;
        }
    }
}
