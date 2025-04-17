using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Specification<T>where T : class
    {
        public Expression<Func<T,bool>>? Criteria { get; }
        public List<Expression<Func<T, object>>> IncludeExpression { get; } = new();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDesc { get; private set; }


        protected Specification(Expression<Func<T, bool>>? criteria)
        {
            this.Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<T, object>> expression)
        {
            IncludeExpression.Add(expression);
        }
        protected void SetOrder(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;   
        }
        protected void SetOrderdesc(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }


    }
}
