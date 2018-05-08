using ForumForGeeksForLess.BL.interfaceDTO;
using System.Web.Mvc;
using System.Web.UI;

namespace ForumForGeeksForLess.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBL forumService;
        public HomeController(IRepositoryBL serv)
        {
            forumService = serv;
        }

        [OutputCache(Duration = 10, Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                forumService.SetVisirer(User.Identity.Name);
             return View(forumService.GetAllSectionAndSub());
        }

        protected override void Dispose(bool disposing)
        {
            forumService.Dispose();
            base.Dispose(disposing);
        }

    }
}