using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AddressVC : ViewComponent
	{
		private readonly IAddressService _addressService;

		public _AddressVC(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _addressService.GetListAll();

			return View(values);
		}
	}
}
