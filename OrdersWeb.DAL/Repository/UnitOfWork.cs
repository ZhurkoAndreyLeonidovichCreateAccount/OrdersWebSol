using OrdersWeb.DAL.Data;
using OrdersWeb.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private  ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Order = new OrderRepository(_context);
            Provider = new ProviderRepository(_context);
            OrderItem = new OrderItemRepository(_context);
        }

        public IOrderRepository Order {  get; private set; }

        public IProviderRepository Provider { get; private set; }

        public IOrderItemRepository OrderItem { get; private set; }
    }
}
