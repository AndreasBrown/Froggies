using Microsoft.AspNetCore.Mvc;

namespace Froggies.Web.Areas.Root.Components.Field
{
	public class Field : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return this.View();
		}

	}
}
