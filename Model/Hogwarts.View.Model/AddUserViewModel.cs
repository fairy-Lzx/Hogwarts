using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.View.Model
{
    public class AddUserViewModel
    {
        /// <summary>
        /// 用户昵称
        /// </summary>
        //public string NickName { get; set; }
        /// <summary>
        /// 用户名(账号)
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户角色ID
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 用户角色、等级
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        //public string Email { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 用户状态，是否正在使用
        /// </summary>
        public bool IsInUsing { get; set; }
        /// <summary>
        /// 用户创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 用户简介、描述
        /// </summary>
        public string UserDescription { get; set; }
    }
}
