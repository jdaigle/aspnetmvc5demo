using System.Web.Mvc;

namespace AdventureWorks.Web.StoreFront
{
    [RoutePrefix("StoreFront")]
    public class StoreFrontController : Controller
    {
        [Route("help")]
        public ActionResult HomePage()
        {
            return View(new ShoppingBagViewModel());
        }
    }
}