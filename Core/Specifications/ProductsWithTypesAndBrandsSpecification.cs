using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInlcude(x => x.ProductType);
            AddInlcude(x => x.ProductBrand);

        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x =>x.Id ==id)
        {
            AddInlcude(x => x.ProductType);
            AddInlcude(x => x.ProductBrand);
        }
    }
}