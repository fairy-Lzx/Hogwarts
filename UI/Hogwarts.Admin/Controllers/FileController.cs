using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hogwarts.Admin.Controllers
{
    [Authorize]
    public class FileController:Controller
    {
        private readonly IHostingEnvironment _hostEnv;
        public FileController(IHostingEnvironment env)
        {
            _hostEnv = env;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            var imgFile = Request.Form.Files[0];
            if(imgFile!=null&&!string.IsNullOrEmpty(imgFile.FileName))
            {
                var filename = imgFile.FileName.Trim();
                var extname = System.IO.Path.GetExtension(filename);
                var fileSize = imgFile.Length;
                if((fileSize/1024/1024)>1)
                {
                    return Json(new { code = 1, msg = "只允许上传小于 1MB 的图片." });
                }
                var saveFilename= DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(1000, 9999) + extname;
                var path = _hostEnv.WebRootPath;
                string dir = DateTime.Now.ToString("yyyyMMdd");
                string finaldir = path + Path.DirectorySeparatorChar + "file" + Path.DirectorySeparatorChar + "upload" + Path.DirectorySeparatorChar + "images" + Path.DirectorySeparatorChar + dir;
                if (!Directory.Exists(finaldir))
                {
                    Directory.CreateDirectory(finaldir);
                }
                var completeFilename = finaldir+Path.DirectorySeparatorChar+saveFilename;
                using(FileStream fs=System.IO.File.Create(completeFilename))
                {
                    await imgFile.CopyToAsync(fs);
                    fs.Flush();
                }
                return Json(new { code = 0, msg = "上传成功",
                    //data = new { src ="http://" + Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + Request.HttpContext.Connection.LocalPort + $" /file/upload/images/{dir}/{saveFilename}" }  });
                    //data = new { src = "https"+"://www.pnhs.xyz"+$"/file/upload/images/{dir}/{saveFilename}" } });
                    //data = new { src = "http://94.191.83.150:5000" + $"/file/upload/images/{dir}/{saveFilename}" } });
                    data = new { src = $"/file/upload/images/{dir}/{saveFilename}" } });
                    
                }
            return Json(new { code = 1, msg = "失败", data = new { } });
        }
    }
}
