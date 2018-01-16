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
    public interface IDevelopYearProvider : IDataProvider<DevelopYear>
    {
        void Add(DevelopYear model, string culture);
        List<DevelopYear> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<DevelopYear> GetAllActive(string culture);
        List<DevelopYear> GetTop(int topcount, string culture);
    }
}
