namespace dal.interfaces
{
    using System;
    using System.Threading.Tasks;
    public interface IRepository : IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity, string createdBy)
        where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Delete<TEntity>(object id) where TEntity : class, IEntity;

        void Save();

        Task SaveAsync();
    }
}