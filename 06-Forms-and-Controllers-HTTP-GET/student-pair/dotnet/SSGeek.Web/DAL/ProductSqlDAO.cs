using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAO : IProductDAO
    {             

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        
    }

}
