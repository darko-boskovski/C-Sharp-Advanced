using System;
using System.Collections.Generic;
using System.Text;
using static E_Shop.Domain.Core.Entities.User;

namespace E_Shop.Domain.Core.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        string City { get; set; }

        public void ProcessPayment(string payment);
        public void ShippingOrder(string shipping, Address addess );
    }
}
