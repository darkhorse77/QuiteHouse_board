using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuiteHouse_board.Model.Context;
using QuiteHouse_board.Models;

namespace QuiteHouse_board.Controllers
{
    public class ThreadController : Controller
    {
        Threads thread = new Threads();
       
        [Route("/res/{threadId}")]
        public IActionResult Index(int threadId)
        {
            LoadThread(threadId);
            ViewBag.Thread = thread;
            return View();
        }

        public void LoadThread(int threadId)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                thread = db.Threads.Where(x => x.MainPostId == threadId).FirstOrDefault();
                thread.MainPost = db.Posts.Where(x => x.Id == thread.MainPostId).FirstOrDefault();
                thread.Posts = db.Posts.Where(x => x.ThreadId == thread.Id).ToList();                
            }
        }
    }
}