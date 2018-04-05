namespace dal
{
    using System;
    using System.Threading.Tasks;
    using dal.interfaces;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TContext> : ReadOnlyRepository<TContext>, IRepository where TContext : DbContext
    {
        public Repository(TContext context) : base(context) {}
        public void Save()
        {
            _context.SaveChanges();
        }
        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        void IRepository.Create<TEntity>(TEntity entity, string createdBy)
        {
            entity.CreatedBy = createdBy;
            _context.Set<TEntity>().Add(entity);
        }
        void IRepository.Delete<TEntity>(object id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var dbSet = _context.Set<TEntity>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        void IRepository.Update<TEntity>(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}