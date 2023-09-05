using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IContactService _contactService;

		public DefaultController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

		[HttpPost]
		public IActionResult SendMessage(Contact contact)
		{
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.Insert(contact);

			return RedirectToAction("Index", "Default");
		}

        public PartialViewResult ScriptVC()
        {
            return PartialView();
        }
	}
}
