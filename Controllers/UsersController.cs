using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace HomeWork_22.Controllers
{
    public class UsersController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View(GetData(nameof(Index)));
        }

        [Authorize(Roles = "Users")]
        public IActionResult OtherAction()
        {
            return View("Index", GetData(nameof(OtherAction)));
        }

        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object>
            {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In Users Role"] = HttpContext.User.IsInRole("Users")
            };
    }
}
