using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TheNameFlewAway.Models;
using TheNameFlewAway.ResponseModel;

namespace TheNameFlewAway.Controllers
{
    /// <summary>
    /// 文件操作相关API
    /// </summary>
    public class FileController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();
        //资源路径
        private string resourcePath = ConfigurationManager.AppSettings["ResourcePath"];

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns>上传成功返回true，上传失败返回false</returns>
        [HttpPost]
        public async Task<FileUploadResponse.FileUpload> FileUpload()
        {
            bool operate = false;
            string fileName = null;
            DateTime date = DateTime.Now.AddYears(-21);
            //判断是否为正确的文件的格式multipart/form-data
            if (!Request.Content.IsMimeMultipartContent())
            {
                return new FileUploadResponse.FileUpload()
                { fileName = fileName, uploadTime = date.ToString(), operate = operate };
            }
            //设置文件上传的文件夹目录
            string rootPath = AppDomain.CurrentDomain.BaseDirectory + resourcePath;

            //创建multipart/form-data文件流提供者
            var provider = new MultipartFileStreamProvider(rootPath);
            //等待异步读取multipart/form-data文件信息
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (MultipartFileData item in provider.FileData)
            {
                try
                {
                    //剪切的文件名
                    string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                    var str = name.Split('.');
                    Console.WriteLine(str);
                    if (str.Length >= 2)
                    {
                        date = DateTime.Now;
                        fileName = date.ToFileTimeUtc() + "." + str[str.Length - 1];
                        //将文件转为(移动)正确的文件
                        File.Move(item.LocalFileName, Path.Combine(rootPath, fileName));
                        //File.Delete(item.LocalFileName);
                        Console.WriteLine(Path.Combine(rootPath, fileName));
                        operate = true;
                    }
                    else
                    {
                        operate = false;
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return new FileUploadResponse.FileUpload()
            { fileName = fileName, uploadTime = date.ToString(), operate = operate };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
