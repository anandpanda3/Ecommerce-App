﻿using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData 
                        = File.ReadAllText(@"../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var item in brands)
                    {
                        ProductBrand brand = new ProductBrand
                        {
                            Name = item.Name
                        };
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData
                        = File.ReadAllText(@"../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        ProductType type = new ProductType
                        {
                            Name = item.Name
                        };
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData
                        = File.ReadAllText(@"../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        Product product = new Product
                        {
                            Name = item.Name,
                            Price = item.Price,
                            PictureUrl = item.PictureUrl,
                            ProductBrandId = item.ProductBrandId,
                            ProductTypeId = item.ProductTypeId,
                            Description = item.Description
                        };
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
