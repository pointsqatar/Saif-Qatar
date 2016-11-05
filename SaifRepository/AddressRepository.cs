using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaifRepository
{
    public class AddressRepository
    {
        SaifDatabaseEntities dbcontext = new SaifDatabaseEntities();
        public List<Address> GetAddress()
        {
            var result = dbcontext.Addresses.Select(x => x);
            return result.ToList();
        }
        public List<Contact> GetTelephoneNumber()
        {
            var query = dbcontext.Contacts.Select(x => x);
            return query.ToList();
        }
    }
}
