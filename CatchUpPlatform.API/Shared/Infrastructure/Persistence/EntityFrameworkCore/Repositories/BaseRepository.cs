using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using CatchUpPlatform.API.Shared.Domain.Repositories;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class BaseRepository<T>(AppDbContext dbContext) : IBaseRepository<T> where T: class
{
    protected readonly AppDbContext Context = dbContext;
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task<T?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().FindAsync([id], cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return;
    }

    public void Update(T entity)
    {
        Context.Update(entity);
    }

    public void Remove(int id)
    {
        Context.Remove(Context.Set<T>().Find(id));
    }

    public Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return null;
    }
}