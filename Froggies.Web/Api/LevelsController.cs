using Froggies.Web.DB;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Froggies.Web.Api
{
    [Route("api/levels")]
    public class LevelsController : Controller
    {
        private DataContext Context { get; }

        public LevelsController(DataContext context)
        {
            this.Context = context;
        }

        [Route("ids")]
        public IActionResult GetLevelIds()
        {
            return this.Ok(this.Context.Levels.Select(x => x.Id).ToArray());
        }

        [Route("{id:int}")]
        public IActionResult LoadLevel(int id)
        {
            var lvl = this.Context.Levels.FirstOrDefault(x => x.Id == id);

            if (lvl == null)
                return this.BadRequest("Level not found.");

            return this.Ok(lvl.CellsJson);
        }
    }
}
