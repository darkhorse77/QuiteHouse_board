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
            ViewBag.Board = Actions.LoadBoard(boardDomain);
            return View();
        }

        public IActionResult CreateThread(string message, int boardId, string image = null)
        {
            Actions.CreateThread(message, boardId, image);
            return RedirectToAction("Index", new { boardDomain = domain});
        }

        [HttpPost]
        public IActionResult ReplyToThread(string message, int threadId, string image = null)
        {
            Actions.ReplyToThread(message, threadId, image);
            return RedirectToAction("Index", new { boardDomain = domain });
        }
    }
}