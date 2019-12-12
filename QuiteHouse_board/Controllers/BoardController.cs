using QuiteHouse_board.Models.Logic;
using Microsoft.AspNetCore.Mvc;
using QuiteHouse_board.Model.Context;
using System.Linq;

namespace QuiteHouse_board.Controllers
{
    public class BoardController : Controller
    {
        private static string domain;

        [Route("/{boardDomain}")]
        public IActionResult Index(string boardDomain)
        {
            domain = boardDomain;
            Boards board = BoardActions.LoadBoard(boardDomain);
            board.Threads = board.Threads.OrderByDescending(x => x.lastBump).ToList();
            ViewBag.Board = board;
            return View();
        }

        public IActionResult CreateThread(string message, int boardId, string image = null)
        {
            BoardActions.CreateThread(message, boardId, image);
            return RedirectToAction("Index", new { boardDomain = domain});
        }

        [HttpPost]
        public IActionResult ReplyToThread(string message, int threadId, string image = null)
        {
            BoardActions.ReplyToThread(message, threadId, image);
            return RedirectToAction("Index", new { boardDomain = domain });
        }
    }
}