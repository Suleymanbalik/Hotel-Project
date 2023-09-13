using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }

        // This Part For Header of _AdminLayout
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        // This Part For PreLoader of _AdminLayout
        public PartialViewResult PreLoaderPartial()
        {
            return PartialView();
        }

        // This Part For NavHeader of _AdminLayout
        public PartialViewResult NavHeaderPartial()
        {
            return PartialView();
        }

        // This Part For Keader of _AdminLayout

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        // This Part For SideBar of _AdminLayout
        public PartialViewResult SideBarPartial()
        {
            return PartialView();
        }

        // This Part For Footer of _AdminLayout
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
    }
}
