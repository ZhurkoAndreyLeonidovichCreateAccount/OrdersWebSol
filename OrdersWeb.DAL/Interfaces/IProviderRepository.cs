using Microsoft.AspNetCore.Mvc.Rendering;
using OrdersWeb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Interfaces
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetAllProviderAsync(bool trackChanges);

        Task<List<SelectListItem>> GetAllDistinctNamesAsync();

        Task<List<SelectListItem>> GetAllDistinctNamesWithValueIdAsync();
    }
}
