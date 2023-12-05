using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrdersWeb.BLL.Interfaces;
using OrdersWeb.BLL.Models;
using OrdersWeb.DAL.Entity;
using OrdersWeb.DAL.Interfaces;

namespace OrdersWeb.BLL.Services
{
    public class ServiceOrder: IServiceOrder
    {
        private readonly IUnitOfWork _context;

        private readonly IMapper _mapper;

        public ServiceOrder(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public async Task<FilterView> GetFilterViewAsync(FilterView? filterView = null)
        {
            if(filterView == null) filterView = new FilterView();

            filterView.ProvidersNameSelect = await _context.Provider.GetAllDistinctNamesAsync();
            filterView.ItemNamesSelect = await _context.OrderItem.GetAllDistinctNamesAsync();
            filterView.OrderItemUnitsListSelect = await _context.OrderItem.GetAllDistinctUnitsAsync();
            filterView.OrderNumbersSelect = await _context.Order.GetAllDistinctNumbersAsync();
            return filterView;
        }

        public async Task<List<OrderView>> GetAllOrderViewAsync()
        {
            var orders = await _context.Order.GetAllOrdersAsync(false);

            var ordersView = _mapper.Map<List<OrderView>>(orders);

            return ordersView.OrderBy(o=>o.Date).ToList();
        }

       
        public async Task<List<OrderView>> MakeFiltrationAsync(FilterView filter)
        {
            var orders = await _context.Order.GetAllOrdersAsync(false);

            var ordersIEnum = orders.Where(o => o.Date >= filter.StartDate && o.Date <= filter.EndDate);
            if (filter.ProvidersName != null && filter.ProvidersName.Any())
            {
                ordersIEnum = ordersIEnum.Where(o => filter.ProvidersName.ToList().Contains(o.Provider.Name));
            }

            if (filter.OrderNumbers != null && filter.OrderNumbers.Any())
            {
                ordersIEnum = ordersIEnum.Where(o => filter.OrderNumbers.Contains(o.Number));
            }

            if (filter.ItemNames != null && filter.ItemNames.Any())
            {
                ordersIEnum = ordersIEnum.Where(o => o.Items.Any(i => filter.ItemNames.Contains(i.Name)));
            }
            orders = ordersIEnum.ToList();

            var ordersView = _mapper.Map<List<OrderView>>(orders);
            return ordersView;

        }


        public async Task<CreateViewOrder> CreateAsync(CreateViewOrder create, int flag, int id, int index)
        {
            CreateViewOrder createOrderView = create;

            if (index != -1)
            {
                if(createOrderView.Items[index].Id != 0)
                {
                    await _context.OrderItem.DeleteOrderItemAsync(createOrderView.Items[index]);
                }
                createOrderView.Items.RemoveAt(index);
            }
            else if (flag == 0)
            {

                createOrderView = new CreateViewOrder
                {

                    Items = new List<OrderItem> { new OrderItem() }

                };
            }
            else if (flag == 1)
            {
                createOrderView = create;
                createOrderView.Items.Add(new OrderItem());
            }

            else if (flag == 2)
            {
                var order = await _context.Order.GetOrderByIdAsync(id, false);

                createOrderView = _mapper.Map<CreateViewOrder>(order);

            }

            createOrderView.ProvidersNameList = await _context.Provider.GetAllDistinctNamesWithValueIdAsync();

            return createOrderView;
        }


        

        public Dictionary<string, string> CheckErrorCreateFinal(CreateViewOrder create)
        {
            var error = new Dictionary<string, string>();
           
                if (create.Id == 0 && _context.Order.CheckUniqueProviderIdandNumber(create.Number, create.ProviderId))
                {
                    error.Add(string.Empty, "The combination of Number and ProviderId must be unique.");
                }              
            
            for (int i = 0; i < create.Items.Count(); i++)
            {
                if (create.Items[0].Name == create.Number)
                {
                    error.Add($"Items[{i}].Name", "item name can not be equal order Number ");
                }
            }

            return error;
        }

        public async Task CreateOrUpdateAsync(CreateViewOrder create)
        {
            var order = _mapper.Map<Order>(create);
           
            if (order.Id == 0)
            {
                await _context.Order.CreateOrderAsync(order);
            }

            else 
            {
                await _context.Order.UpdateOrderAsync(order);
            } 
            
        }

    }
}
