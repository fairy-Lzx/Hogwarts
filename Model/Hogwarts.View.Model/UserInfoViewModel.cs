using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.View.Model
{
    public class UserInfoViewModel
    {
        public int UsersId { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserSex { get; set; }
        public bool UserStatus { get; set; }
        public string UserGrade { get; set; }
        public string UserEndTime { get; set; }
        public string EnglishName { get; set; }
        public string UserDesc { get; set; }
        public string CourseName { get; set; }
        /// <summary>
        /// 家庭地址/省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 家庭地址/市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 家庭地址/区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 真实名字
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string UserFaceImgUrl { get; set; }
    }
}
