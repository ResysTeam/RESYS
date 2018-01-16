using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
  public class CompanyCateManager : DataManagerBase<CompanyCate>
    {
        public CompanyCateManager()
            : base()
        { }

        public CompanyCateManager(IDataProvider<CompanyCate> provider)
            : base(provider)
        {
        }

        private ICompanyCateProvider CompanyCateProvider
        {
            get { return (ICompanyCateProvider)Provider; }
        }
       
        public void Add(CompanyCate model, string culture)
        {
            CompanyCateProvider.Add(model, culture);
        }
        
        public List<CompanyCate> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return CompanyCateProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
       
        public List<CompanyCate> GetAllActive(string culture)
        {
            return CompanyCateProvider.GetAllActive(culture);
        }

        public List<CompanyCate> GetTop(int topcount, string culture)
        {
            return CompanyCateProvider.GetTop(topcount, culture);
        }
        public List<CompanyCate> GetTopHot(int topcount, string culture)
        {
            return CompanyCateProvider.GetTopHot(topcount, culture);
        }
        public List<CompanyCate> GetHot(string culture)
        {
            return CompanyCateProvider.GetHot(culture);
        }
      
    }
}
