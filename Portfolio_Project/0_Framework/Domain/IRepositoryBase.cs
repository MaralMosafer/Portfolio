﻿using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepositoryBase<Model> where Model : class
    {
        Model GetBy(long id);
        List<Model> GetList();
        void CreateAndSave(Model entity);
        void SaveChanges();
        bool CheckDataExists();
        bool Exists(Expression<Func<Model, bool>> predicate);
    }
}