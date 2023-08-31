using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AnnouncementVC : ViewComponent
	{
		private readonly IAnnouncementService _announcementService;

		public _AnnouncementVC(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _announcementService.GetListAll();

			return View(values);
		}
	}
}
