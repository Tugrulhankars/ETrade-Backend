
using Core.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //ÇIPLAK CLASS KALMASIN 
    //veritabanı nesnesidir category
    public class Category:IEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
