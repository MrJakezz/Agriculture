using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardNavbarVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
