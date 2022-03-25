using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        [Required]
        [RegularExpression("^[A-Z][A-Z a-z]{2,}$")]
        public string Name { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public long Salary { get; set; }
        [Required]
        public DateTime? Startdate { get; set; }

        public String Notes { get; set; }
    }
}
