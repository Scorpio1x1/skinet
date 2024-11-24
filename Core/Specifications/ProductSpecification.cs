using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(string? brand, string? type, string? sort) : base(x => 
        (string.IsNullOrWhiteSpace(brand) || x.Brand == brand) && 
        (string.IsNullOrWhiteSpace(type) || x.Type == type)
    )
    {
        switch (sort)
        {
            case "priceAsc":
                addOrderBy(x => x.Price);
                break;
            case "priceDesc":
                addOrderByDescending(x => x.Price);
                break;
            default:
                addOrderBy(x => x.Name);
                break;
        }
    }
}
