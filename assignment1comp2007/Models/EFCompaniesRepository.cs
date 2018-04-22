using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assignment1comp2007.Models
{
    public class EFCompaniesRepository : IMockCompaniesRepository
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public IQueryable<Company> Companies {get {return db.Companies;} }

        public void Delete(Company company)
        {
            throw new NotImplementedException();
        }

        public Company Save(Company company)
        {
            throw new NotImplementedException();
        }
    }
}