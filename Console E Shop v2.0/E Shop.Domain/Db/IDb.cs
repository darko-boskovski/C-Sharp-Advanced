using E_Shop.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TryBeingFit.Domain.Db
{
    public interface IDb<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void RemoveById(int id);
        void Update(T entity);

        List<G> Insert<G>(List<G> list) where G : Bicycle;

    }
}
