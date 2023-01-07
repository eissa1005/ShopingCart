using Microsoft.EntityFrameworkCore;
using ShopingCart.Domain.Core.Models;
using ShopingCart.Domain.Core.Specifications;

namespace ShopingCart.Infrastructure.Repositories
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if(specification.Criteial is not null)
            {
                query = query.Where(specification.Criteial);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            if(specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            else if(specification.OrderByDesceinding is not null)
            {
                query = query.OrderByDescending(specification.OrderByDesceinding);
            }
            if(specification.GroupBy is not null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            return query;
        }

    }
}
