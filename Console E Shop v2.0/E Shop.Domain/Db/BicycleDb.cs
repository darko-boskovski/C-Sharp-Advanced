using E_Shop.Domain.Core.Entities;
using E_Shop.Domain.Core.Enums;
using SEDC.TryBeingFit.Domain.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Shop.Domain.Db
{
    public class BicycleDb<T> : IDb<T> where T : BaseEntity
    {

        public int IdCount { get; set; }

        private List<T> _db;

        public BicycleDb()
        {
            _db = new List<T>();
    
        }
        public List<T> GetAll()
        {
            return _db;
        }

        public T GetById(int id)
        {
            return _db.SingleOrDefault(x => x.Id == id);
        }


        public List<G> Insert<G>(List<G> list) where G : Bicycle
        {
            return list;
        }



        public void RemoveById(int id)
        {
            T item = _db.SingleOrDefault(x => x.Id == id);
            if (item != null) _db.Remove(item);
        }

        public void Update(T entity)
        {
            T item = _db.SingleOrDefault(x => x.Id == entity.Id);
            item = entity;
        }
      
    }
}
