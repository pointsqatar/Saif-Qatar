using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaifRepository
{
    public class EventsRepository
    {
        SaifDatabaseEntities dbContext = new SaifDatabaseEntities();

        public List<Event> GetEvents()
        {
            var result = dbContext.Events.Select(x => x);
            return result.ToList();
        }
    }
}
