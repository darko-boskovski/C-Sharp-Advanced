using E_Shop.Domain.Core.Entities;
using E_Shop.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Domain.Core.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        int Price { get; set; }
        Brand Brand { get; set; }
    }
}
