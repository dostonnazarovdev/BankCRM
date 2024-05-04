using BankCRM.Data.IRepositories;
using BankCRM.Data.Repositories;
using BankCRM.Domain.Entities;

namespace BankCRM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();
           /* var user = userRepository.Create(new User()
            {
                Id = 3,
                FirstName = "gggg",
                LastName = "sssdddd",
                Email = "aa@gmail.com",
                Password = "3321ali$sS",
                CreatedDate = DateTime.Now

            });*/
            //bool user =  userRepository.Delete(2);
            //var user = userRepository.GetById(2);
            var users = userRepository.GetAll();
            foreach (var item in users)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.FirstName);
                Console.WriteLine(item.LastName);
                Console.WriteLine(item.Email);
                Console.WriteLine(item.Password);
                Console.WriteLine(item.CreatedDate);
            }


        }
    }
}
