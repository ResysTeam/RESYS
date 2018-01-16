using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idocNet.Client.Core.Data;
using idocNet.Client.Core.Utils;
using  RESYS.BIZ.Models;
using  RESYS.BIZ.Persistance;

namespace  RESYS.BIZ.Services
{
	public class SysUserManager : DataManagerBase<SysUser>
	{
		public SysUserManager(IDataProvider<SysUser> provider)
			: base(provider)
		{
		}


		ISysUserProvider SysUserProvider
		{
			get
			{
				return (ISysUserProvider)Provider;
			}
		}




		public List<SysUser> GetAll()
		{
			int total = 0;
			return Provider.GetAll(0, 0, ref total);
		}

		public void Import(List<SysUser> list)
		{
			SysUserProvider.Import(list, false);
		}


		public override void Add(SysUser o)
		{

			o.PasswordSalt = EncryptUtils.GenerateSalt();
			o.Password = EncryptUtils.EncryptPassword(o.Password, o.PasswordSalt);

			base.Add(o);


			if (o.Groups != null)
			{
				foreach (var g in o.Groups)
				{
					ServiceFactory.SysUserInGroupManager.Add(new SysUserInGroup()
					{
						Username=o.Username,
						GroupCode= g.Code
					});
				}
			}


		}

		public  void Update(SysUser o, bool changePassword)
		{


			if (changePassword)
			{
				o.PasswordSalt = EncryptUtils.GenerateSalt();
				o.Password = EncryptUtils.EncryptPassword(o.Password, o.PasswordSalt);
			}

			base.Update(o, o);

			ServiceFactory.SysUserInGroupManager.DeleteByUser(o);

			if (o.Groups != null)
			{
				foreach (var g in o.Groups)
				{
					ServiceFactory.SysUserInGroupManager.Add(new SysUserInGroup()
					{
						Username = o.Username,
						GroupCode = g.Code
					});
				}
			}

		}

		public override SysUser Get(SysUser dummy)
		{
			var user = base.Get(dummy);


			if (user != null)
			{
				var list = ServiceFactory.SysUserInGroupManager.GetByUser(user);

				user.Groups = list.Select(i => i.Group).ToList();
				user.Permissions = ServiceFactory.SysPermissionManager.GetByUser(user);
			}

			return user;
		}

		public SysUser Login(string username, string password)
		{
			var user = Get(new SysUser() { Username = username });


			if (user != null)
			{
				string ePass = EncryptUtils.EncryptPassword(password, user.PasswordSalt);


				if (!ePass.Equals(user.Password))
				{
					user = null;
				}
			}


			return user;
		}


		public void Update(SysUser model)
		{
			base.Update(model, model);

			ServiceFactory.SysUserInGroupManager.DeleteByUser(model);
			foreach (var p in model.Groups)
			{
				ServiceFactory.SysUserInGroupManager.Add(new SysUserInGroup()
				{
					Username=model.Username,
					GroupCode=p.Code
				});

			}


		}

	
	}
}
