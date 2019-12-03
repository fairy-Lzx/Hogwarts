using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Core
{
    public class JsonData
    {
        public JsonData(int code, int count, string msg, List<object> data)
        {
            Data = new List<object>();
            Code = code;
            Count = count;
            Msg = msg;
            Data = data;
        }
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回数据数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回的实际数据
        /// </summary>
        public List<object> Data { get; set; }
    }
}
