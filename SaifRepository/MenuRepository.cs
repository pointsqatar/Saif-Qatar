using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaifRepository
{
    public class MenuRepository
    {
        SaifDatabaseEntities dbContext = new SaifDatabaseEntities();

        public List<Menu> GetMenus()
        {
            var result = dbContext.Menus.Select(x => x);
            return result.ToList();
        }

        public List<HomeCarousel> GetCarousel()
        {
            var query = dbContext.HomeCarousels.Select(x => x).ToList();
            return query;
        }

    }
}
