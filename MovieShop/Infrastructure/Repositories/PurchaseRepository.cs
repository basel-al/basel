using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository: EfRepository<Purchase>, IPurchaseRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Purchase>>  GetByUserId(int userId)
        {
            var purchases = await _dbContext.Purchases.Where(x => x.UserId == userId).ToListAsync();
            return purchases;
        }

    }
}
