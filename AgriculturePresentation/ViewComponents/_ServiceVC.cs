using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _ServiceVC : ViewComponent
	{
		private readonly IServiceService _serviceService;

		public _ServiceVC(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _serviceService.GetListAll();

			return View(values);
		}
	}
}
