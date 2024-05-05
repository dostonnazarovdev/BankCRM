using BankCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRM.Service.Helpers
{
    public class Response
    {
       public int StatusCode {  get; set; }
        public string Message { get; set; }
        public bool IsAvailable {  get; set; }
        public User User { get; set; }
    }
}
