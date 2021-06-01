using E_Shop.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Domain.Core.Interfaces
{
    public interface IBicycle
    {
         Size Size { get; set; }
         TypeOfBike Type { get; set; }
    }
}
