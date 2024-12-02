using Flightly.Helpers.Interfaces;
using System.Linq.Expressions;

namespace Flightly.Helpers
{
    public class Helpers: IHelpers
    {
        public Helpers()
        {
        }

        public IQueryable<T> ApplySorting<T>(
            IQueryable<T> query,
            string? sortBy,
            bool isDescending)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);

            var methodName = isDescending ? "OrderByDescending" : "OrderBy";
            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda })!;
        }
    }
}
