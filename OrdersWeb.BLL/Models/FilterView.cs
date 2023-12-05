using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OrdersWeb.BLL.Models
{
    public class FilterView
    {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Today.AddMonths(-1);

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Today;

        public List<SelectListItem> ProvidersNameSelect { get; set; }

        public List<SelectListItem> OrderNumbersSelect { get; set; }

        public List<SelectListItem> ItemNamesSelect { get; set; }

        public List<SelectListItem> OrderItemUnitsListSelect { get; set; }

        public List<string> ProvidersName { get; set; }

        public List<string> OrderNumbers { get; set; }

        public List<string> ItemNames { get; set; }

        public List<string> OrderItemUnitsList { get; set; }


    }
}
