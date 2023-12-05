using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrdersWeb.DAL.Data;
using OrdersWeb.DAL.Entity;
using OrdersWeb.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        ApplicationDbContext _context;
        public ProviderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetAllDistinctNamesAsync()
        {
            
            return await FindAll(false).Select(p => new SelectListItem { Text = p.Name, Value = p.Name }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetAllDistinctNamesWithValueIdAsync()
        {

            return await FindAll(false).Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToListAsync();
        }

        public async Task<List<Provider>> GetAllProviderAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();

        }
    }
}
