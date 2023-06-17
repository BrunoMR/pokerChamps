using System.Linq.Expressions;
using Poker.Domain.Entities.Base;

namespace Poker.Domain.Extensions;

public static class EntityExtensions
{
    private static List<string> JournalProperties = new() { "CreatedAt", "UpdatedAt" };

    public static Expression<Func<T, bool>> CreateFilterPredicate<T>(this Entity obj,
        bool exceptJournalProperties = false)
    {
        var properties = typeof(T).GetProperties();
        var parameter = Expression.Parameter(typeof(T), "x");
        var conditions = new List<Expression>();

        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(obj);

            if (!JournalProperties.Contains(property.Name))
            {
                // Add null or empty check based on property type
                if (propertyValue != null &&
                    (!string.IsNullOrEmpty(propertyValue.ToString()) || property.PropertyType.IsValueType))
                {
                    var propertyAccess = Expression.Property(parameter, property);
                    var condition = Expression.Equal(propertyAccess, Expression.Constant(propertyValue));
                    // var condition = Expression.NotEqual(propertyAccess, Expression.Constant(null));
                    conditions.Add(condition);
                }
            }
        }

        var body = conditions.Count > 0 ? conditions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}