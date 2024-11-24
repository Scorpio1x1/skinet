using System;
using System.IO.Pipelines;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    protected BaseSpecification() : this(null) {}
    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy {get; private set;}

    public Expression<Func<T, object>>? OrderByDescending  {get; private set;}

    public bool IsDistinc {get; private set;}

    protected void addOrderBy(Expression<Func<T, object>> orderByExpression) {
        OrderBy = orderByExpression;
    }

    protected void addOrderByDescending(Expression<Func<T, object>> orderByDescExpression) {
        OrderByDescending = orderByDescExpression;
    }

    protected void ApplyDistinct() {
        IsDistinc = true;
    }
}

public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria) : BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
    protected BaseSpecification() : this(null!) {}
    public Expression<Func<T, TResult>>? Select {get; private set;}

    protected void AddSelect(Expression<Func<T, TResult>> selectExpression) {
        Select = selectExpression;
    }
}