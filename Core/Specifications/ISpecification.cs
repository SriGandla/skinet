using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
         Expression<Func<T,bool>> Criteria {get;}//where clause
         List<Expression<Func<T,object>>> Inlcudes {get;}
    }
}