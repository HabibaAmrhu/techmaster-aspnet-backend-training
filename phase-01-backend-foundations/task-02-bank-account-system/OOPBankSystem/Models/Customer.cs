using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequiredAttribute = ServiceStack.DataAnnotations.RequiredAttribute;

namespace OOPBankSystem.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
