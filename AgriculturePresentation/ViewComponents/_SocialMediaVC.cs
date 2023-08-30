using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _SocialMediaVC : ViewComponent
	{
		private readonly ISocialMediaService _socialMediaService;

		public _SocialMediaVC(ISocialMediaService socialMediaService)
		{
			_socialMediaService = socialMediaService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _socialMediaService.GetListAll();

			return View(values);
		}
	}
}
