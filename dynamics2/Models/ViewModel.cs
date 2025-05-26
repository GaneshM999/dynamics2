using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dynamics2.Models
{
    public class ViewModel
    {
       public Employee Employee { get; set; }

        public IEnumerable<SelectListItem>Department { get; set; }
    }
}