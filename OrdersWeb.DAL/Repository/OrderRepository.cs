using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrdersWeb.DAL.Data;
using OrdersWeb.DAL.Entity;
using OrdersWeb.DAL.Interfaces;




namespace OrdersWeb.DAL.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Order>> GetAllOrdersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Include(o=>o.Provider).Include(o=>o.Items).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId, bool trackChanges)
        {
            return await FindByCondition(o => o.Id == orderId, trackChanges).Include(o=>o.Items).Include(o=>o.Provider).FirstOrDefaultAsync();
        }
        public async Task CreateOrderAsync(Order order)
        {
             await CreateAsync(order);
        }

        public async Task DeleteOrderAsync(Order order)
        {
           await DeleteAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await UpdateAsync(order);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<List<SelectListItem>> GetAllDistinctNumbersAsync()
        {
            return await FindAll(false).Select(x => new SelectListItem { Text = x.Number, Value = x.Number }).Distinct().ToListAsync();
        }

        public bool CheckUniqueProviderIdandNumber(string number, int providerId)
        {
            return context.Orders.Any(x => x.Number == number && x.ProviderId == providerId);
        }

        //public async Task<List<Order>> GetAllOrdersFilterAsync(FilterView filter ,bool trackChanges)
        //{
        //            return await FindAll(trackChanges)
        //    .Include(o => o.Provider)
        //    .Include(o => o.Items)
        //    .Where(o => o.Date >= filter.StartDate && o.Date <= filter.EndDate
        //                && o.Items.Any(i => filter.ItemNames.Contains(i.Name)))
        //    .ToListAsync();
        //}
    }
}
