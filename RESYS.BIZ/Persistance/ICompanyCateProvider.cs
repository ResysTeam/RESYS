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
    public interface ICompanyCateProvider : IDataProvider<CompanyCate>
    {
        void Add(CompanyCate model, string culture);
        List<CompanyCate> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<CompanyCate> GetAllActive(string culture);
        List<CompanyCate> GetTop(int topcount, string culture);
        List<CompanyCate> GetTopHot(int topcount, string culture);
        List<CompanyCate> GetHot( string culture);
    }
}
