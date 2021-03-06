﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            db.Companies.Remove(company);
            db.SaveChanges();
        }

        public Company Save(Company company)
        {
            if(company.BrandId != null)
            {
                db.Entry(company).State = EntityState.Modified;
            }
            else
            {
                db.Companies.Add(company);
            }

            db.SaveChanges();
            return company;

        }
    }
}