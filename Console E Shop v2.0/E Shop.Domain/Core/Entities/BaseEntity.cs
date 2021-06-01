using E_Shop.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Domain.Core.Entities
{
    
        public abstract class BaseEntity : IBaseEntity
        {
            public int Id { get; set; }
            public abstract void Print();
        }
    
}

