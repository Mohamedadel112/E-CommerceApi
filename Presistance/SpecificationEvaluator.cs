using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T>inputQuery, Specification<T> specification)where T : class
        {

            var query = inputQuery;

            if (specification.Criteria is not null) query = query.Where(specification.Criteria);
            
            query = specification.IncludeExpression.Aggregate(query, (current,include)=>current.Include(include));

            if(specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDesc is not null)
            {
                query=query.OrderByDescending(specification.OrderByDesc);
            }

            if (specification.Ispagient)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

                return query;
        }
    }
}
