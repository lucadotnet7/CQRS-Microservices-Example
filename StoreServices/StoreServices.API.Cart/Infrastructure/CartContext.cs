using Microsoft.EntityFrameworkCore;
using StoreServices.API.Cart.Models;

namespace StoreServices.API.Cart.Infrastructure
{
    public class CartContext : DbContext
    {
        public DbSet<CartSession> CartSessions { get; set; }
        public DbSet<CartSessionDetail> CartSessionDetails { get; set; }

        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {
        }
    }
}