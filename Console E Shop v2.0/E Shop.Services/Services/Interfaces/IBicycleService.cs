using E_Shop.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Services.Services.Interfaces
{
    public interface IBicycleService<T> where T : Bicycle
    {
        List<Bicycle> GetAllProducts();
    }
}
