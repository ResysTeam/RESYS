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
	interface IGroupPermissionProvider : IImportableDataProvider<GroupPermission>
	{
		void DeleteByGroup(SysGroup group);
	}
}
