
using CRNproduct.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct.Infrastructure
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
