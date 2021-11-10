using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models.Users
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string FullName => $"{Name} {Family}";
        public ICollection<Transaction> Transactions { get; set; }
    }
}
