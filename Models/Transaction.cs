using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string SourceAccNumber { get; set; }
        public string Operation { get; set; }
        public decimal Amount { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
