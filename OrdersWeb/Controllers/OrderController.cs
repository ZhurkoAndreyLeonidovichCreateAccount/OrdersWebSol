using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrdersWeb.BLL.Interfaces;
using OrdersWeb.BLL.Models;
using OrdersWeb.DAL.Entity;
using OrdersWeb.DAL.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrdersWeb.API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _context;
       
        private readonly IServiceOrder _service;

        public OrderController(IUnitOfWork context, IMapper mapper, IServiceOrder service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var filterView = await _service.GetFilterViewAsync(null);
            ViewBag.Filter = filterView;
            var ordersView = await _service.GetAllOrderViewAsync();
            return View(ordersView);
        }

        [HttpPost]
        public async Task<IActionResult> Index(FilterView filter)
        {
            var ordersView = await _service.MakeFiltrationAsync(filter);
            var filterView = await _service.GetFilterViewAsync(filter);
            ViewBag.Filter = filterView;
            return View(ordersView);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var order = await _context.Order.GetOrderByIdAsync(id, false);
            return View(order);
        }

        //Создать - flag 0
        //Создать Orderitem - flag 1
        //Редактировать - flag 2      
        public async Task<IActionResult> Create(CreateViewOrder create, int flag, int id, int index = -1)
        {
            CreateViewOrder createOrderView = await  _service.CreateAsync(create, flag, id, index);
                                       
            return View(createOrderView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinal(CreateViewOrder create)
        {

            var errors = _service.CheckErrorCreateFinal(create);
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }

            if (!ModelState.IsValid)
            {              
                create.ProvidersNameList = await _context.Provider.GetAllDistinctNamesWithValueIdAsync();

                return View("Create", create);
            }
                      
            await _service.CreateOrUpdateAsync(create);

            return create.Id == 0 ? RedirectToAction(nameof(Index)) : RedirectToAction(nameof(Detail), new { Id = create.Id });
            
        }

       

        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var order = await _context.Order.GetOrderByIdAsync(id,false);
            return View(order);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Order.GetOrderByIdAsync(id, false);
            await _context.Order.DeleteOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }

       

    }
}


