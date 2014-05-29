//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace DirectoryBrowser.Controllers
//{
//    public class DirectoryController : Controller
//    {
//        //
//        // GET: /Directory/
//        private static IList<Comment> comments = new List<Comment>
//        {  
//            new Comment { Text = "hi there", Id = Guid.NewGuid() },
//            new Comment { Text = "hello", Id = Guid.NewGuid() }
//        };

//        public ActionResult Index()
//        {
//            ViewData["a1"] = "hi there";
//            ViewBag.Foo = "something";

//            return View(new Foo { Name = "Foo1", Quantity = 123 });
//        }

//        public ActionResult Comments()
//        {
//            return View(comments);
//        }

//        public ActionResult AddComment()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult AddComment(CommentInput input)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(input);
//            }

//            comments.Add(new Comment { Text = input.Text, Id = Guid.NewGuid() });

//            return RedirectToAction("Comments");
//        }

//        [HttpPost]
//        public ActionResult Delete(Guid id)
//        {
//            comments.Remove(comments.SingleOrDefault(o => o.Id == id));

//            return RedirectToAction("Comments");
//        }

//    }

//    public class Foo
//    {
//        public string Name { get; set; }

//        public int Quantity { get; set; }
//    }

//    public class Comment
//    {
//        public Guid Id { get; set; }
//        public string Text { get; set; }
//    }

//    public class CommentInput
//    {
//        [Required]
//        public string Text { get; set; }
//    }
//}

//    }
//}
