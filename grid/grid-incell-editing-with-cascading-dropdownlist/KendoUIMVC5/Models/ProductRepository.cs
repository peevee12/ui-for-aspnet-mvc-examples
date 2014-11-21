﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIMVC5.Models
{
    public static class ProductRepository
    {
        public static IEnumerable<Product> Products
        {
            get
            {
                IEnumerable<Product> result = (IEnumerable<Product>)HttpContext.Current.Session["Products"];

                if (result == null)
                {
                    HttpContext.Current.Session["Products"] = result = GenerateProducts();
                }

                return result;
            }
        }

        public static IEnumerable<Product> GetProductsByVendor(int vendorId)
        {
            return Products.Where(p => p.VendorId == vendorId);
        }

        private static IEnumerable<Product> GenerateProducts()
        {
            var list = new List<Product>();
            var idx = 1;

            for (var i = 1; i <= 10; i++)
            {
                list.Add(new Product
                {
                    ProductId = idx,
                    ProductName = "Product" + idx,
                    VendorId = i
                });

                idx += 1;

                list.Add(new Product
                {
                    ProductId = idx,
                    ProductName = "Product" + idx,
                    VendorId = i
                });
            }

            return list;
        }
    }
}