using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaifRepository
{
    public class DownloadRepository
    {
        public List<Certificate> GetCertificate()
        {
            var dbContext = new SaifDatabaseEntities();
            var result = dbContext.Certificates.Select(x => x).ToList();
            return result;
        }

        public CompanyProfile GetCompanyProfile()
        {
            var dbContext = new SaifDatabaseEntities();
            var result = dbContext.CompanyProfiles.Select(x => x).SingleOrDefault();
            return result;
        }
    }
}
