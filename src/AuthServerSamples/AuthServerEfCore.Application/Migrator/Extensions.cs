using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.Application.Migrator
{
    /// <summary>
    /// Extension methods for migrations
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds or updates entity by predicate
        /// </summary>
        public static async Task AddOrUpdateAsync<TEntity>(this DbContext context, TEntity entity, Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var dbSet = context.Set<TEntity>();

            var existingEntity = await dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);

            if (existingEntity == null)
            {
                dbSet.Add(entity);
                return;
            }

            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var keyFieldInfo = entityType.FindPrimaryKey().Properties.First().FieldInfo;

            var keyValue = keyFieldInfo.GetValue(existingEntity);
            keyFieldInfo.SetValue(entity, keyValue);
            dbSet.Update(entity);
        }
    }
}