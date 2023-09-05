using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserEditViewModel userEditViewModel = new UserEditViewModel();

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            userEditViewModel.Mail = values.Email;
            userEditViewModel.PhoneNumber = values.PhoneNumber;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            if (userEditViewModel.Password == userEditViewModel.ConfirmPassword) {

                values.Email = userEditViewModel.Mail;
                values.PhoneNumber = userEditViewModel.PhoneNumber;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEditViewModel.Password);

                var result = await _userManager.UpdateAsync(values);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View();
        }
    }
}
