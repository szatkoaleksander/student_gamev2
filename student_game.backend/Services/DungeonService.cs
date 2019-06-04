using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student_game.backend.Database;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public class DungeonService : IDungeonService
    {        
        private readonly AppDbContext _appDbContext;

        public DungeonService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Dungeon>> FindAllAsync()
        {
 _appDbContext.Database.EnsureCreated();
 await _appDbContext.SaveChangesAsync();

            return await _appDbContext.Dungeons.Include(x => x.Enemy).ToListAsync();
        }
    }
}