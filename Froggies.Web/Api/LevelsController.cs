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
        public int[] GetLevelIds()
        {
            return this.Context.Levels.Select(x => x.Id).ToArray();
        }


    }
}
