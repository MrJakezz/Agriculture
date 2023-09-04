using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewVC : ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly IServiceService _serviceService;
        private readonly IContactService _contactService;

        public _DashboardOverviewVC(ITeamService teamService, IServiceService serviceService, IContactService contactService)
        {
            _teamService = teamService;
            _serviceService = serviceService;
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var statistics = new StatisticsViewModel()
            {
                TeamCount = Convert.ToString(_teamService.GetTeamCount()),
                ServiceCount = Convert.ToString(_serviceService.GetServiceCount()),
                MessageCount = Convert.ToString(_contactService.GetMessageCount())
            };

            return View(statistics);
        }
    }
}
