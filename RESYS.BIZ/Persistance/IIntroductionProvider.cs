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
    public interface IIntroductionProvider : IDataProvider<Introduction>
    {
        void Add(Introduction model, string culture);
        List<Introduction> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Introduction> GetAllActive(string culture);
        List<Introduction> GetTop(int topcount, string culture);
        Introduction GetByShortName(string shortname, string culture);
    }
}
