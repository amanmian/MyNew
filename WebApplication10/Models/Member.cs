using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Member
    {
        [Key]
        public int MemId { get; set; }
        public string MemName { get; set; }
        public string MemEmail { get; set; }
        public string MemAddress { get; set; }
    }
}