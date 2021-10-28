using ContactManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Manager
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "No Name specified")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name is to short or long")]
        public string Name { get; set; }
        [Column("Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "No Salary specified")]
        [Range(1, 99999, ErrorMessage = "Incorrect Salary")]
        public decimal Salary { get; set; }
    }
}
