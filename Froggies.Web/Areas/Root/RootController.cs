using Microsoft.AspNetCore.Mvc;

namespace Froggies.Web.Areas.Root
{
	[Area("Root")]
	[Route("")]
	public class RootController : Controller
    {
        public IActionResult Root()
        {
			return this.View();
        }
    }
}