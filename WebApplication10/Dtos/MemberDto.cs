using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Dtos
{
    public class MemberDto
    {
        public int MemId { get; set; }
        public string MemName { get; set; }
        public string MemEmail { get; set; }
        public string MemAddress { get; set; }
    }
}