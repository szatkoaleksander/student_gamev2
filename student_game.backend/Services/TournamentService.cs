using System;
using System.Linq;
using System.Threading.Tasks;
using student_game.backend.Database;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserService _userService;

        public TournamentService(AppDbContext appDbContext, IUserService userService)
        {
            _appDbContext = appDbContext;
            _userService = userService;
        }
        public async Task<int> BattleWithBot(int dungeon, int enemy, string userId)
        {
            var user = _appDbContext.Users.SingleOrDefault(x => x.Id == userId);
            var en = new Enemy();
            en.Attack += dungeon * enemy * 10;
            en.Defense += dungeon * enemy * 5;

            var result = FightWith(user, en);

            if(result == 1)
            {
                user.Exp += 100;
                user.Money += 100;

                await _userService.LevelUpAsync(user, 1);
                await _userService.UpdateAsync(user);

                return result;
            }
            else if(result == 0)
            {
                return result;
            }
            else 
                throw new Exception("Tournament error");
        }

        private int FightWith(AppUser user, Enemy en)
        {
            Random rnd = new Random();

            while(true)
            {
                var defenseUser = rnd.Next(0, (int)user.Defense / 2);
                var defenseEnemy = rnd.Next(0, (int)en.Defense / 2);

                var userAttack = user.Attack - (defenseEnemy / 2);
                var enemyAttack = en.Attack - (defenseUser / 2);

                if(userAttack >= enemyAttack)
                {
                    double probability = (enemyAttack / userAttack) * 100;

                    if(probability >= 80)
                    {
                        return 1;
                    }
                    else if(probability < 80 && probability >=50)
                    {
                        var lucky = rnd.Next(0, 2);

                        if(lucky == 2)
                            return 0;
                        else return 1;
                    }
                    else if(probability < 50 && probability >=20)
                    {
                        var lucky = rnd.Next(0, 4);

                        if(lucky == 3)
                            return 1;
                        else return 0;
                    }
                    else if(probability < 20)
                    {
                        return 0;
                    }
                }
                else if(userAttack < enemyAttack)
                {
                    double probability = (userAttack / enemyAttack) * 100;

                    if(probability >= 80)
                    {
                        return 0;
                    }
                    else if(probability < 80 && probability >=50)
                    {
                        var lucky = rnd.Next(0, 3);

                        if(lucky == 3)
                            return 1;
                        else return 0;
                    }
                    else if(probability < 50 && probability >=20)
                    {
                        var lucky = rnd.Next(0, 4);

                        if(lucky == 3)
                            return 1;
                        else return 0;
                    }
                    else if(probability < 20)
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }
    }
}