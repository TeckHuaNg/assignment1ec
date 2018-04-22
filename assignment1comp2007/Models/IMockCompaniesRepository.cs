using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1comp2007.Models
{
    public interface IMockCompaniesRepository
    {
        IQueryable<Company> Companies {get;}

        Company Save(Company company);
        void Delete(Company company);
    }
}
