using DirectoryBrowser.Utilities;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web.Http.Cors;
 
namespace DirectoryBrowser.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials=true)]
    public class HomeController : Controller
    {
        public ActionResult Index(string keywords)
        {
            string pathString = WebConfigurationManager.AppSettings["directorypath"];

            List<File> fileCollection = new List<File>();

            if (String.IsNullOrEmpty(keywords))
            {

                JavaScriptSerializer JS = new JavaScriptSerializer();
                JS.Serialize(fileCollection);

<<<<<<< HEAD
                return Json(fileCollection, JsonRequestBehavior.AllowGet);
            }

            var filePaths = Directory.EnumerateFiles(@pathString, "*" + keywords + "*", SearchOption.AllDirectories);
=======
                    var file = new File(fileInfo.Name, fileInfo.FullName, fileInfo.CreationTime);
>>>>>>> upstream/master

            foreach (string filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                var file = new File(fileInfo.Name, HttpUtility.UrlEncode(fileInfo.FullName), fileInfo.CreationTime.ToString());
                fileCollection.Add(file);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            js.Serialize(fileCollection);

            return Json(fileCollection, JsonRequestBehavior.AllowGet);
        }

        public FilePathResult Download(string file)
        {
            var decodedFile = HttpUtility.UrlDecode(file).TrimStart(new char[]{ '\\' });
            string fullPath = Path.Combine(WebConfigurationManager.AppSettings["directorypath"], decodedFile);
            FileInfo fileInfo = new FileInfo(fullPath);
            string contentType = ContentTypeUtility.GetMimeTypeFromFilename(fileInfo.Name);

            var result = new FilePathResult(fileInfo.FullName, contentType)
            { 
                FileDownloadName = fileInfo.Name
            };

            return result; 
            
        }
    }

    public class SearchCriteria
    {
        public string Keywords { get; set; }
    }

    public class File
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string CreationTime { get; set; }

<<<<<<< HEAD
        //public string Path 
        //{
        //    get
        //    {
        //        return FilePath.Replace(WebConfigurationManager.AppSettings["directorypath"], "");
        //    }
        //}
=======
        public string Path 
        {
            get
            {
                return HttpUtility.UrlEncode(FilePath.Replace(WebConfigurationManager.AppSettings["directorypath"], ""));
            }
        }
>>>>>>> upstream/master

        public File(string name, string filePath, string creationTime)
        {
            Name = name;
            FilePath = filePath;
            CreationTime = creationTime;
        }
    }
}
