using System.Data.Entity;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingAPI.Core.Models;

namespace ShoppingAPI.Persistence
{
    public class ShoppingApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }

        public ShoppingApiDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ShoppingApiDbContext Create()
        {
            return new ShoppingApiDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}