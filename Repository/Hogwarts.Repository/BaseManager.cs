using Hogwarts.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Hogwarts.Repository.SqlServer
{
    /// <summary>
    /// 公共增删改查方法实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseManager<T> where T : class, new()
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T AddEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges() > 0;

        }

        public bool EditEntity(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambdaExpression)
        {
            return _dbContext.Set<T>().Where(whereLambdaExpression);
        }
        public IQueryable<T> GetAllEntities()
        {
            return _dbContext.Set<T>();
        }
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambdaExpression, Expression<Func<T, S>> orderByLambdaExpression, bool isAsc)
        {
            var tem = _dbContext.Set<T>().Where(whereLambdaExpression);
            totalCount = tem.Count();
            if (isAsc)
            {
                tem = tem.OrderBy(orderByLambdaExpression).Skip(pageIndex).Take(pageSize);
            }else
            {
                tem = tem.OrderByDescending(orderByLambdaExpression).Skip(pageIndex).Take(pageSize);
            }
            return tem;
        }
    }
}
