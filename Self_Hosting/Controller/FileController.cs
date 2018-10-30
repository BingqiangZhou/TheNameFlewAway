using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Self_Hosting.Controller
{
    public class FileController :ApiController
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>上传成功返回true，上传失败返回false</returns>
        [HttpPost]
        public async Task<Dictionary<string, object>> UploadFile(int id)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            bool operate = false;
            //判断是否为正确的文件的格式multipart/form-data
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            //设置文件上传的文件夹目录
            string rootPath = AppDomain.CurrentDomain.BaseDirectory+ "upload";
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

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
                    //Console.WriteLine(item.LocalFileName);
                    //将文件转为(移动)正确的文件
                    File.Move(item.LocalFileName, Path.Combine(rootPath, name));
                    //File.Delete(item.LocalFileName);
                    operate = true;
                    //Console.WriteLine(Path.Combine(rootPath, name));
                    //Console.WriteLine(item.LocalFileName);
                    //string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                    //string newFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(name);
                    //File.Move(item.LocalFileName, Path.Combine(rootPath, newFileName));
                    //Request.RequestUri.PathAndQury为需要去掉域名的后面地址
                    //如上述请求为http://localhost:80824/api/upload/post，这就为api/upload/post
                    //Request.RequestUri.AbsoluteUri则为http://localhost:8084/api/upload/post
                    //Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                    //string fileRelativePath = rootPath + "\\" + item.LocalFileName;
                    //Uri fileFullPath = new Uri(baseuri, fileRelativePath);
                    //savedFilePath.Add(fileFullPath.ToString());
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
                results.Add("operate", operate);
            }
            return results;
        }
    }
}
