using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Hogwarts.Core
{
    public static class JsonHelper
    {
        public static JsonResult StandardJsonResult(int code, int count, string msg, List<object> data)
        {
            return new JsonResult(new JsonData(code, count, msg, data));
        }
    }
}
