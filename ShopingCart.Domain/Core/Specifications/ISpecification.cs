
using ShopingCart.Domain.Core.Models;
using System.Linq.Expressions;

namespace ShopingCart.Domain.Core.Specifications
{
    public interface ISpecification<T> where T : IBaseEntity
    {
        Expression<Func<T, bool>> Criteial { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesceinding { get; }
        Expression<Func<T, object>> GroupBy { get; }

        int Skip { get; }
        int Take { get; }
        bool InPageingEnable { get; }



    }
}
