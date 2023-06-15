using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        //ben burda Liste döndürmek istiyorum ama aynı zamanda mesaj ve işlem sonucunuda dönürmek istiyorum
        IDataResult<List<Product>> GetAll();

        IDataResult<List<Product>>  GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min,decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int productId);

        //bu void içerisinde bir data yok bu nedenle IResult dedim sadece
        IResult Add(Product product);

        IResult AddTransactionalTest(Product product);
    }
}
