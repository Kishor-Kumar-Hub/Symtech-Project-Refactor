using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Accounts
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public double? Amount { get; set; }

    }
       
}