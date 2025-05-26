using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dynamics2.Models
{
    public class Department
    {
        [Key]
        public int DId { get; set; }
        [Required(ErrorMessage ="Enter The Name")]
        public string DName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}