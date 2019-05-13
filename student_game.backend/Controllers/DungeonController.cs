using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_game.backend.Services;

namespace student_game.backend.Controllers
{
    [Route("api/[controller]")]
    public class DungeonController : BaseController
    {
        private readonly IDungeonService _dungeonService;
        
        public DungeonController(IDungeonService dungeonService)
        {
            _dungeonService = dungeonService;
        }

        [HttpGet]
        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> GetDungeon()
        {
            var result = await _dungeonService.FindAllAsync();

            return Json(result);
        }
    }
}