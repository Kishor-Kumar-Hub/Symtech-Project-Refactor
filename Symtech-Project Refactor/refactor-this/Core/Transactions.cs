using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }

        public double? Amount { get; set; }

        public DateTime Date { get; set; }
       
        public Guid AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Accounts Accounts { get; set; }
    }
}