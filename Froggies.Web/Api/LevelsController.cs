using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace Froggies.Web.Api
{
    [Route("api/levels")]
    public class LevelsController : Controller
    {
        [Route("ids")]
        public IActionResult GetLevelIds()
        {
            var currentDir = Directory.GetCurrentDirectory();

            var levelsPath = Path.Join(currentDir, "Assets/Levels/");

            var fileNames = Directory.GetFiles(levelsPath);

            var levelIds = fileNames.Select(f =>
            {
                var fname = f.Split('/').Last();
                return fname.Split('.').First();
            });

            return this.Ok(levelIds);
        }
    }
}
