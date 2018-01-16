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
    public interface IDevelopMonthProvider : IDataProvider<DevelopMonth>
    {
        void Add(DevelopMonth model, string culture);
        List<DevelopMonth> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<DevelopMonth> GetAllActive(string culture);
        List<DevelopMonth> GetTop(int topcount, string culture);
        List<DevelopMonth> GetByYear(int developyearid, string culture);
        List<DevelopMonth> GetByYearActive(int developyearid, string culture);
    }
}
