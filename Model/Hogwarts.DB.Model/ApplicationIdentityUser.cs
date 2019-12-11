using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.DB.Model
{
    public class ApplicationIdentityUser:IdentityUser
    {
        public int TId { get; set; }
        public string RoleName { get; set; }
        public string UserFaceImgUrl { get; set; }
        public string UserDescription { get; set; }
        public Teacher Teacher { get; set; }
    }
}
