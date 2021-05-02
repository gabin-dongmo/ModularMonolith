﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Product.Domain;

namespace ModularMonolith.Product.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Domain.Product product)
        {
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Domain.Product> Get(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
