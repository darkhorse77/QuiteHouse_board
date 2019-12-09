using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuiteHouse_board.Model.Context;
using QuiteHouse_board.Models.Logic;

namespace QuiteHouse_board.Controllers
{
    public class ThreadController : Controller
    {
        private static int threadMPId;

        [Route("/res/{threadMainPostId}")]
        public IActionResult Index(int threadMainPostId)
        {
            threadMPId = threadMainPostId;
            ViewBag.Thread = Actions.LoadThread(threadMainPostId);
            return View();
        }

        [HttpPost]
        public IActionResult ReplyToThread(string message, int threadId, string image = null)
        {
            Actions.ReplyToThread(message, threadId, image);
            return RedirectToAction("Index", new { threadMainPostId = threadMPId });
        }
    }
}