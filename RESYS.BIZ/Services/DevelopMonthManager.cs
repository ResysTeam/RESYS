using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class DevelopMonthManager : DataManagerBase<DevelopMonth>
    {
        public DevelopMonthManager()
            : base()
        { }

        public DevelopMonthManager(IDataProvider<DevelopMonth> provider)
            : base(provider)
        {
        }

        private IDevelopMonthProvider DevelopMonthProvider
        {
            get { return (IDevelopMonthProvider)Provider; }
        }

        public void Add(DevelopMonth model, string culture)
        {
            DevelopMonthProvider.Add(model, culture);
        }

        public List<DevelopMonth> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return DevelopMonthProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<DevelopMonth> GetAllActive(string culture)
        {
            return DevelopMonthProvider.GetAllActive(culture);
        }

        public List<DevelopMonth> GetTop(int topcount, string culture)
        {
            return DevelopMonthProvider.GetTop(topcount, culture);
        }

        public List<DevelopMonth> GetByYear(int developyearid, string culture)
        {
            return DevelopMonthProvider.GetByYear(developyearid, culture);
        }

        public List<DevelopMonth> GetByYearActive(int developyearid, string culture)
        {
            return DevelopMonthProvider.GetByYearActive(developyearid, culture);
        }

    }
}
