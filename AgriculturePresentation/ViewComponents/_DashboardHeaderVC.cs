using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardHeaderVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
