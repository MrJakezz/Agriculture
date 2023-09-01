using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _MapVC : ViewComponent
	{
		private readonly IAddressService _addressService;

		public _MapVC(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()
		{
			var value = _addressService.SelectMapInfo();

			ViewBag.MapInfo = value;

			return View();
		}
	}
}
