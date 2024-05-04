using BankCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRM.Service.Helpers
{
    public class ListResponse
    {
        public int StatusCode {  get; set; }
        public string Message { get; set; }
        public List<User> Users { get; set; }
    }
}
