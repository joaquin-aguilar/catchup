namespace CatchUpPlatform.API.Shared.Domain.Repositories;

public interface IBaseRepository<T>
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task <T?> FindByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Remove(int id);
    Task <IEnumerable<T>> ListAsync(CancellationToken cancellationToken = default);
}