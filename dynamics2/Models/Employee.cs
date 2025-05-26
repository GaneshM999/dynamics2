using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dynamics2.Models
{
    public class Employee
    {
        [Key]
        public int EId { get; set; }
        [Required(ErrorMessage ="Enter the Name")]
        public string EName { get; set; }
        [Required(ErrorMessage = "Enter the Salary")]
        public decimal ESalary { get; set; }
        [Required(ErrorMessage = "Select Department")]
        public int DId { get; set; }

        public virtual Department Department { get; set; }

    }
}