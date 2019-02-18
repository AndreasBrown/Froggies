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

		[Route("test/{test}")]
		public IActionResult Test(string test)
		{
			return this.Content(test);
		}
	}
}
