using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.View.Model
{
    /// <summary>
    /// 用户登陆数据实体
    /// </summary>
    public class UserLoginViewModel
    {
        /// <summary>
        /// 用户名/账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerificationCode { get; set; }
    }
}
