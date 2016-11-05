using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaifRepository
{
    public class ProductRepository
    {
        SaifDatabaseEntities dbContext = new SaifDatabaseEntities();

        public List<Product> GetProducts()
        {
            var result = dbContext.Products.Select(x => x);
            var sortlist = result.OrderBy(x => x.SortOrder).ToList();
            return sortlist;
        }
    }
}
