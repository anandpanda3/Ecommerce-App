using Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParms parms)
            : base(x => 
            (string.IsNullOrEmpty(parms.Search) || x.Name.ToLower().Contains(parms.Search))
            &&(!parms.TypeId.HasValue || x.ProductTypeId == parms.TypeId)
            && (!parms.BrandId.HasValue || x.ProductBrandId == parms.BrandId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            ApplyPaging(parms.PageSize * (parms.PageIndex - 1), parms.PageSize);
            
            if (!string.IsNullOrEmpty(parms.Sort))
            {
                switch(parms.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
