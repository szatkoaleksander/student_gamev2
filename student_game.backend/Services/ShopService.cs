using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student_game.backend.Database;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public class ShopService : IShopService
    {
        private readonly AppDbContext _appDbContext;

        public ShopService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Product>> FindAllAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task BuyProductAsync(Guid productId, string userId)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
            var product = await _appDbContext.Products.SingleOrDefaultAsync(x => x.Id == productId);

            if(user == null)
            {
                throw new Exception("null user shopservice");
            }
            if(product == null)
            {
                throw new Exception("null product shopservice");
            }
            if(user.Money < product.Price)
            {
                throw new Exception("not enought money");
            }

            user.Money -= product.Price;

            var aup = new AppUserProduct();
            aup.AppUser = user;
            aup.AppUserId = user.Id;
            aup.Product = product;
            aup.ProductId = product.Id;

            user.AppUserProduct.Add(aup);
            product.AppUserProduct.Add(aup);

            _appDbContext.Users.Update(user);
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();
        }
    }
}