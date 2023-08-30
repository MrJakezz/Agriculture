using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AboutVC : ViewComponent	
	{
		private readonly IAboutService _aboutService;

		public _AboutVC(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _aboutService.GetListAll();

			return View(values);
		}
	}
}
