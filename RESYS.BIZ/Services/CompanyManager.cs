using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class CompanyManager : DataManagerBase<Company>
    {
        public CompanyManager()
            : base()
        { }

        public CompanyManager(IDataProvider<Company> provider)
            : base(provider)
        {
        }

        private ICompanyProvider CompanyProvider
        {
            get { return (ICompanyProvider)Provider; }
        }

        public void Add(Company model, string culture)
        {
            CompanyProvider.Add(model, culture);
        }

        public List<Company> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return CompanyProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<Company> GetAllActive(string culture)
        {
            return CompanyProvider.GetAllActive(culture);
        }
        public Company GetByShortName(Company dummy)
        {
            return CompanyProvider.GetByShortName(dummy);
        }

        public List<Company> GetTop(int topcount, string culture)
        {
            return CompanyProvider.GetTop(topcount, culture);
        }
        public List<Company> GetByCateId(int companycateid, string culture)
        {
            return CompanyProvider.GetByCateId(companycateid, culture);
        }

    }
}
