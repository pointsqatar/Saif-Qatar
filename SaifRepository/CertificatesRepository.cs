using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace SaifRepository
{
    public class CertificatesRepository
    {
         SaifDatabaseEntities dbContext = new SaifDatabaseEntities();

        public List<Certificate> GetCertificates()
        {
            var result = dbContext.Certificates.Select(x => x).ToList();
            return result;
        }
    }
}
