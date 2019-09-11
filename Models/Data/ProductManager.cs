using Microsoft.AspNetCore.Http;
using PicknPayAspNetCoreWebApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PicknPayAspNetCoreWebApi.Models.Data
{
    public class ProductManager : IDataRepository<Product>
    {
        readonly ProductContext _productContext;

        public ProductManager(ProductContext context)
        {
            _productContext = context;
        }

        public void Add(Product entity)
        {
           
            _productContext.Products.Add(entity);
            _productContext.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _productContext.Products.Remove(entity);
            _productContext.SaveChanges();
        }

        public Product Get(long id)
        {
            return _productContext.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productContext.Products.ToList();
        }

        public void Update(Product dbEntity, Product entity)
        {
            dbEntity.ProductName = entity.ProductName;
            dbEntity.ProductCategory = entity.ProductCategory;
            dbEntity.ProductBrand = entity.ProductBrand;
            dbEntity.ProductPrice = entity.ProductPrice;
            dbEntity.ProductPreviousPrice = entity.ProductPreviousPrice;
            dbEntity.ProductBarcode = entity.ProductBarcode;
            dbEntity.ProductMass = entity.ProductMass;
            dbEntity.CartItemCount = entity.CartItemCount;

            _productContext.SaveChanges();
        }
    }
}
