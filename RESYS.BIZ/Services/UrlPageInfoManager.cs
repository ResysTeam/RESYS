using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
	public class UrlPageInfoManager: DataManagerBase<UrlPageInfo>
	{
		public UrlPageInfoManager(IDataProvider<UrlPageInfo> provider)
			: base(provider)
		{
		}


		IUrlPageInfoProvider UrlPageInfoProvider
		{
			get
			{
				return (IUrlPageInfoProvider)Provider;
			}
		}


		

		public List<UrlPageInfo> GetAll()
		{
			int total=0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<UrlPageInfo> list)
		{
			UrlPageInfoProvider.Import(list, false);
		}


	}
}
