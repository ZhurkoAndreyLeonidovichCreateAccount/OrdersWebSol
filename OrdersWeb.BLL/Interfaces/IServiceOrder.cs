using OrdersWeb.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.BLL.Interfaces
{
    public interface IServiceOrder
    {
         Task<FilterView> GetFilterViewAsync(FilterView? filterView);
         Task<List<OrderView>> GetAllOrderViewAsync();
        Task<List<OrderView>> MakeFiltrationAsync(FilterView filter);
        Task<CreateViewOrder> CreateAsync(CreateViewOrder create, int flag, int id, int index = -1);
        Dictionary<string, string> CheckErrorCreateFinal(CreateViewOrder create);
        Task CreateOrUpdateAsync(CreateViewOrder create);
    }
}
