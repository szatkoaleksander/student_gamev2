using Microsoft.AspNetCore.Identity;

namespace student_game.backend.Models
{
    public class AppUser : IdentityUser
    {
        public int Hp { get; set; } = 100;
        public decimal Money { get; set; } = 1500;
        public int Exp { get; set; } = 0;
        public int Lvl { get; set; } = 0;
        public double Attack { get; set; } = 10;
        public double Defense { get; set; } = 10;
    }
}