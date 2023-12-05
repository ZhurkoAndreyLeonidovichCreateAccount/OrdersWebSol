using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }

        IProviderRepository Provider { get; }

        IOrderItemRepository OrderItem { get; }
    }
}

