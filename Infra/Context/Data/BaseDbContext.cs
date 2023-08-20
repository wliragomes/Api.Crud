﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context.Data
{
    public class BaseDbContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options)
            : base(options)
        { }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConvertPropertyValuesToUpperCase();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ConvertPropertyValuesToUpperCase();
            return base.SaveChanges();
        }

        private void ConvertPropertyValuesToUpperCase()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);

            foreach (var entity in entities)
            {
                var properties = entity.GetType().GetProperties()
                    .Where(p => p.PropertyType == typeof(string) && p.CanWrite);

                foreach (var property in properties)
                {
                    var value = (string)property.GetValue(entity)!;
                    if (!string.IsNullOrEmpty(value))
                    {
                        property.SetValue(entity, value.ToUpper());
                    }
                }
            }
        }
    }
}
