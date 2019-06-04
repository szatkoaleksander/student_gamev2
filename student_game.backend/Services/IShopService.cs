using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public interface IShopService
    {
        Task<IEnumerable<Product>> FindAllAsync();
        Task BuyProductAsync(Guid productId, string userId); 
    }
}