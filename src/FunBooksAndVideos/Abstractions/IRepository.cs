namespace FunBooksAndVideos.Abstractions;

internal interface IRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> GetById(Guid id);
    
    Task Save(TEntity entity);
}