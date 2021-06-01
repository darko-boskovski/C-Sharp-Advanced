using System;
using System.Collections.Generic;
using System.Text;
using static E_Shop.Domain.Core.Entities.User;

namespace E_Shop.Domain.Core.Interfaces
{
    public interface IShipping
    {
        string Name { get; set; }
        void ShipOrder(string shippingCompany,Address address);
    }
}
