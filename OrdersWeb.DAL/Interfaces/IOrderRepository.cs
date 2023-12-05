using Microsoft.AspNetCore.Mvc.Rendering;
using OrdersWeb.DAL.Entity;


namespace OrdersWeb.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync(bool trackChanges);

        Task<Order> GetOrderByIdAsync(int orderId, bool trackChanges);

        Task CreateOrderAsync(Order order);

        Task DeleteOrderAsync(Order order);

        Task UpdateOrderAsync(Order order);
        Task<List<SelectListItem>> GetAllDistinctNumbersAsync();

        bool CheckUniqueProviderIdandNumber(string number, int providerId);


    }
}
