using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HomeWork_22.Controllers
{
    public class UsersController : Controller
    {
        public ViewResult Index() =>
            View(new Dictionary<string, object> { ["Placeholder"] = "Placeholder" });
    }
}
