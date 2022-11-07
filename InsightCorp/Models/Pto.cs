using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsightCorp.Models
{
    public class Pto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ManagerId { get; set; }
        public DateTime RequestedDayOff { get; set; }
        public bool? IsApproved { get; set; }
    }
}