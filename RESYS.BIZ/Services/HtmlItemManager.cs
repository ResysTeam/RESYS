using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
	public class HtmlItemManager : DataManagerBase<HtmlItem>
	{
		public HtmlItemManager(IDataProvider<HtmlItem> provider)
			: base(provider)
		{
		}


		IHtmlItemProvider HtmlItemProvider
		{
			get
			{
				return (IHtmlItemProvider)Provider;
			}
		}




		public List<HtmlItem> GetAll()
		{
			int total = 0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<HtmlItem> list)
		{
			HtmlItemProvider.Import(list, false);
		}



		public override HtmlItem Get(HtmlItem dummy)
		{
			var item = base.Get(dummy);
			if (item != null)
			{
				item.ItemFields = ServiceFactory.HtmlItemFieldManager.GetByItem(item);
			}
			return item;

		}

		public void Update(HtmlItem htmlItem)
		{
			throw new NotImplementedException();
		}
	}
}
