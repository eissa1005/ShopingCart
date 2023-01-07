using ShopingCart.Domain.Core.Models;
using System.Linq.Expressions;

namespace ShopingCart.Domain.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public BaseSpecification(Expression<Func<T, bool>> criteial) 
        {
            Criteial = criteial;
        }
        public Expression<Func<T, bool>> Criteial { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        public Expression<Func<T, object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDesceinding { get; set; }

        public Expression<Func<T, object>> GroupBy { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public bool InPageingEnable { get; set; } = false;

        public virtual void Appling(Expression<Func<T,object>> inculdes )
        {
            Includes.Add(inculdes);
        }
        public virtual void ApplingIncludeString(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        public virtual void ApplyOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }
        public virtual void ApplyOrderByDecending(Expression<Func<T, object>> orderByExpression)
        {
            OrderByDesceinding = orderByExpression;
        }
        public virtual void ApplyGroupBy(Expression<Func<T, object>> orderByExpression)
        {
            GroupBy = orderByExpression;
        }

    }
}
