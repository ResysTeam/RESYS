using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
	public class PotentialCustomerManager: DataManagerBase<PotentialCustomer>
	{
		public PotentialCustomerManager(IDataProvider<PotentialCustomer> provider)
			: base(provider)
		{
		}


		IPotentialCustomerProvider PotentialCustomerProvider
		{
			get
			{
				return (IPotentialCustomerProvider)Provider;
			}
		}


		

		public List<PotentialCustomer> GetAll()
		{
			int total=0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<PotentialCustomer> list)
		{
			PotentialCustomerProvider.Import(list, false);
		}


	}
}
