using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;

namespace RESYS.BIZ.Persistance
{
	interface IImportableDataProvider<T> : IDataProvider<T>
		where T : idocNet.Client.Core.Data.Entities.EntityBase
	{
		void Import(List<T> list, bool deleteExist);
	}
}
