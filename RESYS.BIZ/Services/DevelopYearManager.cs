using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class DevelopYearManager : DataManagerBase<DevelopYear>
    {
        public DevelopYearManager()
            : base()
        { }

        public DevelopYearManager(IDataProvider<DevelopYear> provider)
            : base(provider)
        {
        }

        private IDevelopYearProvider DevelopYearProvider
        {
            get { return (IDevelopYearProvider)Provider; }
        }

        public void Add(DevelopYear model, string culture)
        {
            DevelopYearProvider.Add(model, culture);
        }

        public List<DevelopYear> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return DevelopYearProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<DevelopYear> GetAllActive(string culture)
        {
            return DevelopYearProvider.GetAllActive(culture);
        }

        public List<DevelopYear> GetTop(int topcount, string culture)
        {
            return DevelopYearProvider.GetTop(topcount, culture);
        }

    }
}
