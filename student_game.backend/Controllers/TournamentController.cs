using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_game.backend.Services;
using student_game.backend.ViewModels;

namespace student_game.backend.Controllers
{
    [Route("api/[controller]")]
    public class TournamentController : BaseController
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpPost]
        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> BattleWithBot([FromBody]BattleViewModel battleViewModel)
        {
            var result = await _tournamentService.BattleWithBot(battleViewModel.Dungeon, battleViewModel.Enemy, LoggedInUser);

            return Json(result);
        }
    }
}