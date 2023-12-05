using Microsoft.EntityFrameworkCore;
using OrdersWeb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().HasData(
                new Provider { Id = 1, Name = "Фурнитур - ВУ" },
                new Provider { Id = 2, Name = "Тория Стиль" },
                new Provider { Id = 3, Name = "Сладкая идея" },
                new Provider { Id = 4, Name = "АВС" }
        );
            modelBuilder.Entity<Order>().HasIndex(o => new { o.Number, o.ProviderId }).IsUnique();
        }
    }
}
