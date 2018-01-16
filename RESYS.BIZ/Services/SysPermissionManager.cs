using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using  RESYS.BIZ.Models;
using  RESYS.BIZ.Persistance;

namespace  RESYS.BIZ.Services
{
	public class SysPermissionManager: DataManagerBase<SysPermission>
	{
		public SysPermissionManager(IDataProvider<SysPermission> provider)
			: base(provider)
		{
		}


		ISysPermissionProvider SysPermissionProvider
		{
			get
			{
				return (ISysPermissionProvider)Provider;
			}
		}


		

		public List<SysPermission> GetAll()
		{
			int total=0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<SysPermission> list)
		{
			SysPermissionProvider.Import(list, false);
		}


		public List<SysPermission> GetByGroup(SysGroup group)
		{
			return SysPermissionProvider.GetByGroup(group);
		}

		public List<SysPermission> GetByUser(SysUser user)
		{
			return SysPermissionProvider.GetByUser(user);
		}


	}
}
