using OrdersWeb.DAL.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace OrdersWeb.DAL.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllOrderItemsAsync(bool trackChanges);

        Task<List<SelectListItem>> GetAllDistinctUnitsAsync();

        Task<List<SelectListItem>> GetAllDistinctNamesAsync();

        Task DeleteOrderItemAsync(OrderItem orderItem);
    }
}
