using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using RESYS.BIZ.Models;
using RESYS.BIZ.Persistance;

namespace RESYS.BIZ.Services
{
	public class GroupPermissionManager: DataManagerBase<GroupPermission>
	{
		public GroupPermissionManager(IDataProvider<GroupPermission> provider)
			: base(provider)
		{
		}


		IGroupPermissionProvider GroupPermissionProvider
		{
			get
			{
				return (IGroupPermissionProvider)Provider;
			}
		}


		

		public List<GroupPermission> GetAll()
		{
			int total=0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<GroupPermission> list)
		{
			GroupPermissionProvider.Import(list, false);
		}

		public void DeleteByGroup(SysGroup group)
		{
			this.GroupPermissionProvider.DeleteByGroup(group);
		}

	}
}
