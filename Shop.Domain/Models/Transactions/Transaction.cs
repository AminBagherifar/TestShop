using Shop.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
    public class Transaction:BaseEntity
    {
        public int UserId { get; set; }
        public DateTime SatrtDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Sum { get; set; }
        public decimal Total { get; set; }
        public bool IsFinaly { get; set; }

        //Relations
        public User User { get; set; }
    }
}
