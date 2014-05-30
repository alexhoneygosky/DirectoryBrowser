using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
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
            var filePaths = new ArrayList(Directory.GetFiles(@"..\\Test", keywords+"*", SearchOption.AllDirectories));
 
            List<FileInfo> fileCollection = new List<FileInfo>();
            
            foreach (string filePath in filePaths)
            {
                FileInfo file = new FileInfo(filePath);
                fileCollection.Add(file); 
            }

            return View(fileCollection);
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
        public string Path { get; set; }
    }

    public class Foo
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }

    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }

    public class CommentInput
    {
        [Required]
        public string Text { get; set; }
    }
}
