using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using  RESYS.BIZ.Models;
using  RESYS.BIZ.Persistance;

namespace  RESYS.BIZ.Services
{
	public class SysUserInGroupManager: DataManagerBase<SysUserInGroup>
	{
		public SysUserInGroupManager(IDataProvider<SysUserInGroup> provider)
			: base(provider)
		{
		}


		ISysUserInGroupProvider SysUserInGroupProvider
		{
			get
			{
				return (ISysUserInGroupProvider)Provider;
			}
		}


		

		public List<SysUserInGroup> GetAll()
		{
			int total=0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<SysUserInGroup> list)
		{
			SysUserInGroupProvider.Import(list, false);
		}


		public List<SysUserInGroup> GetByUser(SysUser user)
		{
			return SysUserInGroupProvider.GetByUser(user);
		}

		public void DeleteByUser(SysUser user)
		{
			SysUserInGroupProvider.DeleteByUser(user);
		}


	}
}
