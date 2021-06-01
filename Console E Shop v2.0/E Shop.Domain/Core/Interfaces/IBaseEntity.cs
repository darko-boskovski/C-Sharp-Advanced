using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Domain.Core.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        void Print();
    }
}
