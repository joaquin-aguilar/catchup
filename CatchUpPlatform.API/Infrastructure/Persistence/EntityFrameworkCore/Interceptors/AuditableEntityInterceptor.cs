using CatchUpPlatform.API.Shared.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CatchUpPlatform.API.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;

public sealed class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private static void ApplyAuditTimeStamps(DbContext context)
    {
        if (context is null) return;
        var now = DateTimeOffset.UtcNow;
        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State is EntityState.Added or EntityState.Modified) entry.Entity.UpdatedAt = now;
            if (entry.State is EntityState.Added) 
                entry.Entity.CreatedAt ??= now;
        }
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> results)
    {
        ApplyAuditTimeStamps(eventData.Context);
        return base.SavingChanges(eventData, results);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> results,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditTimeStamps(eventData.Context);
        return base.SavingChangesAsync(eventData, results, cancellationToken);
    }
}