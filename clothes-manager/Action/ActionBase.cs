using Contracts;
using Entities;
using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace clothes_manager.Method
{
    public class ActionBase<T> : IActionBase<T> where T : class
    {
        protected ApplicationContext ApplicationContext { get; set; }
        public ActionBase(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public IQueryable<T> FindAll() => ApplicationContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            ApplicationContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => ApplicationContext.Set<T>().Add(entity);

        public void Update(T entity) => ApplicationContext.Set<T>().Update(entity);

        public void Delete(T entity) => ApplicationContext.Set<T>().Remove(entity);
    }
}
