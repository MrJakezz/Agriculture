using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Windows.Markup;

namespace AgriculturePresentation.ViewComponents
{
	public class _GalleryVC : ViewComponent
	{
		private readonly IImageService _imageService;

		public _GalleryVC(IImageService imageService)
		{
			_imageService = imageService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _imageService.GetListAll();

			return View(values);
		}
	}
}
