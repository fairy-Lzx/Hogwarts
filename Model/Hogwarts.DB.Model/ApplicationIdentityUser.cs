using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.DB.Model
{
    public class ApplicationIdentityUser:IdentityUser
    {
        public int Tid { get; set; }
        public Teacher Teacher { get; set; }
    }
}
