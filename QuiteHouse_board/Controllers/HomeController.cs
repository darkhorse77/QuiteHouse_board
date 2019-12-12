using QuiteHouse_board.Models.Logic;
using Microsoft.AspNetCore.Mvc;

namespace QuiteHouse_board.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.BoardsList = BoardActions.LoadBoardsList();
            return View();
        }
    }
}