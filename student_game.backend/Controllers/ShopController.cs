using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_game.backend.Services;
using student_game.backend.ViewModels;

namespace student_game.backend.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : BaseController
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var result = await _shopService.FindAllAsync();

            return Json(result);
        }

        [HttpPost]
        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> Buy([FromBody]BuyProductViewModel command)
        {
            await _shopService.BuyProductAsync(command.ProductId, LoggedInUser);

            return Ok();
        }
    }
}