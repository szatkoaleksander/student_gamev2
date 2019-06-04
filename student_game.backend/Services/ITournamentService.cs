using System.Threading.Tasks;

namespace student_game.backend.Services
{
    public interface ITournamentService
    {
        Task<int> BattleWithBot(int dungeon, int enemy, string userId);
    }
}