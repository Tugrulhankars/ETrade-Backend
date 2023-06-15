
using Core.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //veritabanı nesnesidir customer
    public class Customer:IEntity
    {
        public string CustomerId { get; set; }

        public string ContactName { get; set; }

        public string CompannyName { get; set; }

        public string City { get; set; }
    }
}
