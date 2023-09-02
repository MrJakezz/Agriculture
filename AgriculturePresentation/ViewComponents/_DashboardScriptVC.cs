using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardScriptVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
