using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace SaifRepository
{
    public class CatalogueRepository
    {
        public List<ProductCatalogue> GetProductCatalogues()
        {
            var dbContext = new SaifDatabaseEntities();
            var result = dbContext.ProductCatalogues.Select(x => x).ToList();
            return result;
        }
    }
}
