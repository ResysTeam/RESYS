using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
	public class HtmlItemFieldManager: DataManagerBase<HtmlItemField>
	{
		public HtmlItemFieldManager(IDataProvider<HtmlItemField> provider)
			: base(provider)
		{
		}


		IHtmlItemFieldProvider HtmlItemFieldProvider
		{
			get
			{
				return (IHtmlItemFieldProvider)Provider;
			}
		}


		

		public List<HtmlItemField> GetAll()
		{
			int total=0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<HtmlItemField> list)
		{
			HtmlItemFieldProvider.Import(list, false);
		}



		public List<HtmlItemField> GetByItem(HtmlItem item)
		{
			return HtmlItemFieldProvider.GetByItem(item);

		}

		public override void Update(HtmlItemField @new, HtmlItemField old)
		{
			Remove(old);
			Add(@new);
		}
	}
}
