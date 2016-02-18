using System;
using System.Web.Mvc;

namespace AdventureWorks.Web.HomePage
{
    public class HomePageController : Controller
    {
        [Route("")]
        [Route("~/homepage")]
        public ActionResult HomePage()
        {
            return View(new HomePageViewModel());
        }

        [Route("About")]
        public ActionResult AboutPage()
        {
            return View(new AboutPageViewModel());
        }

        [Route("StoreFront")]
        [Route("StoreFront2")]
        [Route("something")]
        public ActionResult HomePageDie()
        {
            throw new InvalidOperationException("storefront!");
        }
    }
}