using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
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
            var filePaths = new ArrayList(Directory.GetFiles(@pathString, "*"+keywords+"*", SearchOption.AllDirectories));
 
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

        //[HttpPost]
        //public ActionResult AddComment(CommentInput input)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(input);
        //    }

        //    files.Add(new Comment { Text = input.Text, Id = Guid.NewGuid() });

        //    return RedirectToAction("Comments");
        //}

        //[HttpPost]
        //public ActionResult Delete(Guid id)
        //{
        //    comments.Remove(comments.SingleOrDefault(o => o.Id == id));

        //    return RedirectToAction("Comments");
        //}

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
