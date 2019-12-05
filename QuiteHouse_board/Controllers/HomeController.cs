using Microsoft.AspNetCore.Mvc;
using QuiteHouse_board.Model.Context;
using QuiteHouse_board.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace QuiteHouse_board.Controllers
{
    public class HomeController : Controller
    {
        public List<Boards> Boards { get; set; }
        public List<Threads> Threads { get; set; }

        public HomeController()
        {
            
        }
        public IActionResult Index()
        {
            LoadBoard();
            ViewBag.Boards = Boards;
            ViewBag.Threads = Threads;
            return View();
        }

        private void LoadBoard()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Boards = db.Boards.ToList();
                Threads = db.Threads.ToList();

                foreach (Threads t in Threads)
                {
                    t.MainPost = db.Posts.Where(x => x.Id == t.MainPostId).First();
                    t.Posts = db.Posts.Where(x => x.ThreadId == t.Id).ToList();
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ReplyToThread(string message, int threadId/*, string image = null*/)
        {
            if (message == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            using (ApplicationContext db = new ApplicationContext())
            {
                Posts post = new Posts()
                {
                    Message = message,
                    ThreadId = threadId,
                    Author = "Аноним",
                    //Image = image
                };
                db.Posts.Add(post);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateThread(string message, int boardId, string image = null)
        {
            if (message == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            using (ApplicationContext db = new ApplicationContext())
            {
                Threads thread = new Threads()
                {
                    BoardId = boardId,
                    MainPost = new Posts()
                    {
                        Author = "Аноним",
                        Image = image,
                        Message = message
                    }
                };

                db.Add(thread);       
                
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
