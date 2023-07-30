using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParms parms)
            : base(x =>
            (string.IsNullOrEmpty(parms.Search) || x.Name.ToLower().Contains(parms.Search))
            && (!parms.TypeId.HasValue || x.ProductTypeId == parms.TypeId)
            && (!parms.BrandId.HasValue || x.ProductBrandId == parms.BrandId))
        {

        }
    }
}
