﻿using BuyMore.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyMore.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
