using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaifRepository
{
    public class GallaryReprository
    {
        SaifDatabaseEntities dbContext = new SaifDatabaseEntities();
        public List<Gallery> GetGalleryImages()
        {
            var query = (dbContext.Galleries.Where(x => (bool)x.IsActive).Select(x => x)).ToList();
            return query;
        }
    }
}
