using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
    public class IntroductionManager : DataManagerBase<Introduction>
    {
        public IntroductionManager()
            : base()
        { }

        public IntroductionManager(IDataProvider<Introduction> provider)
            : base(provider)
        {
        }

        private IIntroductionProvider IntroductionProvider
        {
            get { return (IIntroductionProvider)Provider; }
        }

        public void Add(Introduction model, string culture)
        {
            IntroductionProvider.Add(model, culture);
        }

        public List<Introduction> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return IntroductionProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<Introduction> GetAllActive(string culture)
        {
            return IntroductionProvider.GetAllActive(culture);
        }

        public List<Introduction> GetTop(int topcount, string culture)
        {
            return IntroductionProvider.GetTop(topcount, culture);
        }

        public Introduction GetByShortName(string shortname, string culture)
        {
            return IntroductionProvider.GetByShortName(shortname, culture);
        }

    }
}
