using System.Collections.Generic;

namespace AdventureWorks.Web.HomePage
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            Links.Add(new LinksViewModel() { URL = "~/about", Name = "About Us!" });
            Links.Add(new LinksViewModel() { URL = "~/storefront", Name = "The Store Front" });
        }

        public List<LinksViewModel> Links { get; } = new List<LinksViewModel>();

        public class LinksViewModel
        {
            public string URL { get; internal set; }
            public string Name { get; internal set; }
        }
    }
}