using Microsoft.AspNetCore.Mvc;

namespace Froggies.Web.Areas.Root.Components.Game
{
	public class Game : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return this.View();
		}
	}
}
