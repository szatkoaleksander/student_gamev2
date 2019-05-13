using System.Collections.Generic;
using System.Threading.Tasks;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public interface IDungeonService
    {
         Task<IEnumerable<Dungeon>> FindAllAsync();
    }
}