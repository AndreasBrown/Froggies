using Microsoft.AspNetCore.Mvc;

namespace Froggies.Web.Areas.Login
{
	[Area("Auth")]
	[Route("auth")]
	public class AuthController : Controller
	{
		public IActionResult Root()
		{
			return this.View();
		}

		[Route("register")]
		public IActionResult Register()
		{
			return this.View();
		}
	}
}
