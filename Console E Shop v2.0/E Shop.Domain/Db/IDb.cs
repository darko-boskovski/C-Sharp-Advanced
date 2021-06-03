using E_Shop.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Domain.Db
{
    public interface IDb<T> where T : BaseEntity
    {

        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void RemoveById(int id);
        void Update(T entity);
        void DeleteId();

    }
}
