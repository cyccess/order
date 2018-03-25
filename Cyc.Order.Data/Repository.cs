using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cyc.Order.Data
{
    public class Repository
    {
        private readonly OrderDbContext context;

        /// <summary>
        /// 每次new会重新创建一个 DBContext 实例
        /// </summary>
        public Repository()
        {
            //this.context = new OrderDbContext();
        }

        public OrderDbContext DbContext
        {
            get
            {
                return context;
            }
        }

        public T Find<T>(int id) where T : class, new()
        {
            return context.Set<T>().Find(id);
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> func) where T : class, new()
        {
            return context.Set<T>().FirstOrDefault(func);
        }

        public T SingleOrDefault<T>(Expression<Func<T, bool>> func) where T : class, new()
        {
            return context.Set<T>().SingleOrDefault(func);
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> func) where T : class, new()
        {
            return context.Set<T>().Where(func);
        }

        public void Add<T>(T model) where T : class, new()
        {
            context.Set<T>().Add(model);
        }

        public void Update<T>(T model) where T : class, new()
        {
            context.Update<T>(model);
        }

        public void Delete<T>(T model) where T : class, new()
        {
            context.Set<T>().Remove(model);
        }

        public void Delete<T>(Expression<Func<T, bool>> func) where T : class, new()
        {
            var list = context.Set<T>().Where(func).ToList();
            foreach (var item in list)
            {
                context.Set<T>().Remove(item);
            }
        }

        public void Delete<T>(int id) where T : class, new()
        {
            var obj = Find<T>(id);
            if (obj != null)
            {
                Delete(obj);
                //return 1;
            }
            //return 0;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public IQueryable<T> Entities<T>() where T : class, new()
        {
            return context.Set<T>().AsQueryable();
        }

    }
}
