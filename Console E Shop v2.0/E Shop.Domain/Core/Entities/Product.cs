using E_Shop.Domain.Core.Enums;
using E_Shop.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace E_Shop.Domain.Core.Entities
{
    public abstract class Product : BaseEntity, IProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Brand Brand { get; set; }


        public abstract override void Print();
        
                  
    }
}
