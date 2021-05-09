﻿using MyCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyCv.Repositories
{
    public class GenericRepository<T> where T : class, new()

    {
        DbCVEntities db = new DbCVEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public void TGet(int id)
        {
            db.Set<T>().Find(id);
            db.SaveChanges();
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

    }
}