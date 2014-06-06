using DirectoryBrowser.Utilities;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
 
namespace DirectoryBrowser.Controllers
{
    public class HomeController : Controller
    {
      
        List<ListItem> files = new List<ListItem>();
        DataTable dt = new DataTable();

        public ActionResult Index(string keywords)
        {
            string pathString = WebConfigurationManager.AppSettings["directorypath"];
            var filePaths = Directory.EnumerateFiles(@pathString, "*"+keywords+"*", SearchOption.AllDirectories);
 
            List<File> fileCollection = new List<File>();
            
            foreach (string filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                var file = new File(fileInfo.Name, fileInfo.FullName, fileInfo.CreationTime);              

                fileCollection.Add(file); 
            }
            
            return View(fileCollection);
        }

        public FilePathResult Download(string file)
        {
            string pathString = WebConfigurationManager.AppSettings["directorypath"];
            string fullPath = pathString + file;
            FileInfo fileInfo = new FileInfo(fullPath);
            string contentType = ContentTypeUtility.GetMimeTypeFromFilename(fileInfo.Name);

            var result = new FilePathResult(fileInfo.FullName, contentType)
            { 
                FileDownloadName = fileInfo.Name
            };

            return result; 
            
        }

        public ActionResult Comments()
        {
            return View(files);
        }

        public ActionResult AddComment()
        {
            return View();
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

    public static class ContentTypeHelper
    {
        /// <summary>
        /// Gets the MIME type corresponding to the extension of the specified file name.
        /// </summary>
        /// <param name="fileName">The file name to determine the MIME type for.</param>
        /// <returns>The MIME type corresponding to the extension of the specified file name, if found; otherwise, null.</returns>
        public static string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            if (String.IsNullOrWhiteSpace(extension))
            {
                return null;
            }

            var registryKey = Registry.ClassesRoot.OpenSubKey(extension);

            if (registryKey == null)
            {
                return null;
            }

            var value = registryKey.GetValue("Content Type") as string;

            return String.IsNullOrWhiteSpace(value) ? null : value;
        }
    }
}
