using Core;
using Core.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    //DTO => Data Transformation Object
    //IEntity vermedik çünkü bu bir veri tabanı tablosu veya nesnesi değil

    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public short UnitsInStock { get; set; }

    }
}
