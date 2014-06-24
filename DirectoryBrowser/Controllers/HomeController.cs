using DirectoryBrowser.Utilities;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
 
namespace DirectoryBrowser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string keywords)
        {
            string pathString = WebConfigurationManager.AppSettings["directorypath"];

            List<File> fileCollection = new List<File>();

            if (!String.IsNullOrEmpty(keywords))
            {
                var filePaths = Directory.EnumerateFiles(@pathString, "*" + keywords + "*", SearchOption.AllDirectories);

                foreach (string filePath in filePaths)
                {
                    FileInfo fileInfo = new FileInfo(filePath);

                    var file = new File(fileInfo.Name, HttpUtility.UrlEncode(fileInfo.FullName), fileInfo.CreationTime);

                    fileCollection.Add(file);
                }
            }

            return View(fileCollection);
        }

        public FilePathResult Download(string file)
        {
            string pathString = WebConfigurationManager.AppSettings["directorypath"];
            string fullPath = file;
            HttpUtility.UrlDecode(fullPath);
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
        public DateTime CreationTime { get; set; }

        public string Path 
        {
            get
            {
                return FilePath.Replace(WebConfigurationManager.AppSettings["directorypath"], "");
            }
        }

        public File(string name, string filePath, DateTime creationTime)
        {
            Name = name;
            FilePath = filePath;
            CreationTime = creationTime;
        }
    }
}
