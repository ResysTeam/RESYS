using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;
using RESYS.BIZ.Models;

namespace RESYS.BIZ.Persistance
{
    public interface ICompanyProvider : IDataProvider<Company>
    {
        void Add(Company model, string culture);
        List<Company> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Company> GetAllActive(string culture);
        List<Company> GetTop(int topcount, string culture);
        List<Company> GetByCateId(int companycateid, string culture);
        Company GetByShortName(Company dummy);
    }
}
