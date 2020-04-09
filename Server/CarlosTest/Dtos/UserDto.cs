using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosTest.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
    }
}