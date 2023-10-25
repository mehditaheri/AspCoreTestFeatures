using Microsoft.AspNetCore.Mvc;
using AspCoreTestFeatures.Services;

namespace AspCoreTestFeatures.Pages.Components.Users
{
    public class UsersViewComponent : ViewComponent
    {
        private IUserService _userService;

        public UsersViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }
    }
}
