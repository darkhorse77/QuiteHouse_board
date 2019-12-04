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
            LoadBoard();
        }
        public IActionResult Index()
        {
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
    }
}
