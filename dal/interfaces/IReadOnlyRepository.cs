namespace dal.interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IReadOnlyRepository
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null, // Where clause. Pass in lambda expression
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, // Order by function. pass in lambda
            string includeProperties = null)
            where TEntity : class, IEntity;

        Task<TEntity> GetByIdAsync<TEntity>(object id)
        where TEntity : class, IEntity;
    }
}