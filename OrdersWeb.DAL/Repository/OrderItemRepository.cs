using Microsoft.EntityFrameworkCore;
using OrdersWeb.DAL.Data;
using OrdersWeb.DAL.Entity;
using OrdersWeb.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrdersWeb.DAL.Repository
{
    public class OrderItemRepository:Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetAllDistinctNamesAsync()
        {
            return await FindAll(false).Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).Distinct().ToListAsync();
        }

        public async Task<List<SelectListItem>> GetAllDistinctUnitsAsync()
        {
            return await FindAll(false).Select(x => new SelectListItem { Text = x.Unit, Value = x.Unit }).Distinct().ToListAsync();
        }

        public async Task DeleteOrderItemAsync(OrderItem orderItem)
        {
            await DeleteAsync(orderItem);
        }


    }
}
