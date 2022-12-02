using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsightCorp.Models
{
    public class UserViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<Payroll> Payrolls { get; set; }
    }
}