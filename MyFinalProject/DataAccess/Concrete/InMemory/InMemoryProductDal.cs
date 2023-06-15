using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;

        public InMemoryProductDal()
        {
            _products= new List<Product> { 
            new Product{CategoryId=1,ProductId=1,ProductName="bardak",UnitsInStock=15,UnitPrice=15},
            new Product{CategoryId=2,ProductId=1,ProductName="kamera",UnitsInStock=3,UnitPrice=500},
            new Product{CategoryId=3,ProductId=2,ProductName="telefon",UnitsInStock=15,UnitPrice=15},
            new Product{CategoryId=4,ProductId=2,ProductName="klavye",UnitsInStock=65,UnitPrice=150},
            new Product{CategoryId=5,ProductId=2,ProductName="fare",UnitsInStock=1,UnitPrice=85}
            };
        }

        public void Add(Product product)
        {
            
           _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Add(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; 
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllCategory(int categoryId)
        {
          return _products.Where(p => p.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id' sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }

}
