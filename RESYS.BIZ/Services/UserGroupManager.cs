using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using  RESYS.BIZ.Models;
using  RESYS.BIZ.Persistance;

namespace  RESYS.BIZ.Services
{
	public class SysGroupManager: DataManagerBase<SysGroup>
	{
		public SysGroupManager(IDataProvider<SysGroup> provider)
			: base(provider)
		{
		}


		ISysGroupProvider SysGroupProvider
		{
			get
			{
				return (ISysGroupProvider)Provider;
			}
		}


		

		public List<SysGroup> GetAll()
		{
			int total=0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<SysGroup> list)
		{
			SysGroupProvider.Import(list, false);
		}


		public override SysGroup Get(SysGroup dummy)
		{
			var data= base.Get(dummy);

			if (data != null)
			{
				data.Permissions = ServiceFactory.SysPermissionManager.GetByGroup(data);
			}

			return data;
		}


		public override void Add(SysGroup o)
		{
			base.Add(o);

			foreach (var p in o.Permissions)
			{
				ServiceFactory.GroupPermissionManager.Add(new GroupPermission()
				{
					GroupCode=o.Code,
					PermissionCode=p.Code
				});
				
			}
			
		}

		public void Update(SysGroup group)
		{
			
			base.Update(group, group);


			ServiceFactory.GroupPermissionManager.DeleteByGroup(group);
			foreach (var p in group.Permissions)
			{
				ServiceFactory.GroupPermissionManager.Add(new GroupPermission()
				{
					GroupCode = group.Code,
					PermissionCode = p.Code
				});

			}

		}
	}
}
