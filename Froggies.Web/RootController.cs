using Microsoft.AspNetCore.Mvc;

namespace Froggies.Web
{
    public class RootController : Controller
    {
        public IActionResult Root()
        {
            return this.View("~/wwwroot/index.html");
        }
    }
}
