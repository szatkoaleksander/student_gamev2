using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace student_game.backend.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string LoggedInUser => User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}