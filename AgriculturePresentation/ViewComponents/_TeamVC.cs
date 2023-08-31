using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _TeamVC : ViewComponent
	{
		private readonly ITeamService _teamService;

		public _TeamVC(ITeamService teamService)
		{
			_teamService = teamService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _teamService.GetListAll();

			return View(values);
		}
	}
}
