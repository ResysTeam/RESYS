using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESYS.BIZ.Services
{
	public class ServiceFactory
	{

		static Hashtable services = new Hashtable();
        static ServiceFactory()
        {
            services.Add(typeof(SysPermissionManager), new SysPermissionManager(new RESYS.BIZ.Persistance.SqlServer.SysPermissionProvider()));
            services.Add(typeof(GroupPermissionManager), new GroupPermissionManager(new RESYS.BIZ.Persistance.SqlServer.GroupPermissionProvider()));
            services.Add(typeof(SysUserManager), new SysUserManager(new RESYS.BIZ.Persistance.SqlServer.SysUserProvider()));
            services.Add(typeof(SysGroupManager), new SysGroupManager(new RESYS.BIZ.Persistance.SqlServer.SysGroupProvider()));
            services.Add(typeof(SysUserInGroupManager), new SysUserInGroupManager(new RESYS.BIZ.Persistance.SqlServer.SysUserInGroupProvider()));
            services.Add(typeof(SlideBannerManager), new SlideBannerManager(new RESYS.BIZ.Persistance.SqlServer.SlideBanneProvider()));
            services.Add(typeof(UrlPageInfoManager), new UrlPageInfoManager(new RESYS.BIZ.Persistance.SqlServer.UrlPageInfoProvider()));
            services.Add(typeof(ImageManager), new ImageManager(new RESYS.BIZ.Persistance.SqlServer.ImageProvider()));
            services.Add(typeof(VideoManager), new VideoManager(new RESYS.BIZ.Persistance.SqlServer.VideoProvider()));
            services.Add(typeof(LibraryManager), new LibraryManager(new RESYS.BIZ.Persistance.SqlServer.LibraryProvider()));
            services.Add(typeof(AlbumManager), new AlbumManager(new RESYS.BIZ.Persistance.SqlServer.AlbumProvider()));
            services.Add(typeof(CompanyCateManager), new CompanyCateManager(new RESYS.BIZ.Persistance.SqlServer.CompanyCateProvider()));
            services.Add(typeof(CompanyManager), new CompanyManager(new RESYS.BIZ.Persistance.SqlServer.CompanyProvider()));
            services.Add(typeof(IntroductionManager), new IntroductionManager(new RESYS.BIZ.Persistance.SqlServer.IntroductionProvider()));
            services.Add(typeof(DevelopMonthManager), new DevelopMonthManager(new RESYS.BIZ.Persistance.SqlServer.DevelopMonthProvider()));
            services.Add(typeof(DevelopYearManager), new DevelopYearManager(new RESYS.BIZ.Persistance.SqlServer.DevelopYearProvider()));
            services.Add(typeof(NewsCategoryManager), new NewsCategoryManager(new RESYS.BIZ.Persistance.SqlServer.NewsCategoryProvider()));
            services.Add(typeof(NewsManager), new NewsManager(new RESYS.BIZ.Persistance.SqlServer.NewsProvider()));
            services.Add(typeof(NewsImageManager), new NewsImageManager(new RESYS.BIZ.Persistance.SqlServer.NewsImageProvider()));
            services.Add(typeof(AlbumImageManager), new AlbumImageManager(new RESYS.BIZ.Persistance.SqlServer.AlbumImageProvider()));
            services.Add(typeof(HtmlItemManager), new HtmlItemManager(new RESYS.BIZ.Persistance.SqlServer.HtmlItemProvider()));

            services.Add(typeof(HtmlItemFieldManager), new HtmlItemFieldManager(new RESYS.BIZ.Persistance.SqlServer.HtmlItemFieldProvider()));
            
            services.Add(typeof(PotentialCustomerManager), new PotentialCustomerManager(new RESYS.BIZ.Persistance.SqlServer.PotentialCustomerProvider()));
        }
			


		public static PotentialCustomerManager PotentialCustomerManager
		{
			get
			{
				return (PotentialCustomerManager)services[typeof(PotentialCustomerManager)];
			}
			set
			{
				services[typeof(PotentialCustomerManager)] = value;
			}
		}


		public static HtmlItemFieldManager HtmlItemFieldManager
		{
			get
			{
				return (HtmlItemFieldManager)services[typeof(HtmlItemFieldManager)];
			}
			set
			{
				services[typeof(HtmlItemFieldManager)] = value;
			}
		}




		public static HtmlItemManager HtmlItemManager
		{
			get
			{
				return (HtmlItemManager)services[typeof(HtmlItemManager)];
			}
			set
			{
				services[typeof(HtmlItemManager)] = value;
			}
		}

		
		public static UrlPageInfoManager UrlPageInfoManager
		{
			get
			{
				return (UrlPageInfoManager)services[typeof(UrlPageInfoManager)];
			}
			set
			{
				services[typeof(UrlPageInfoManager)] = value;
			}
		}

        public static ImageManager ImageManager
        {
            get
            {
                return (ImageManager)services[typeof(ImageManager)];
            }
            set
            {
                services[typeof(ImageManager)] = value;
            }
        }

        public static VideoManager VideoManager
        {
            get
            {
                return (VideoManager)services[typeof(VideoManager)];
            }
            set
            {
                services[typeof(VideoManager)] = value;
            }
        }

        public static LibraryManager LibraryManager
        {
            get
            {
                return (LibraryManager)services[typeof(LibraryManager)];
            }
            set
            {
                services[typeof(LibraryManager)] = value;
            }
        }
        public static AlbumManager AlbumManager
        {
            get
            {
                return (AlbumManager)services[typeof(AlbumManager)];
            }
            set
            {
                services[typeof(AlbumManager)] = value;
            }
        }
        public static AlbumImageManager AlbumImageManager
        {
            get
            {
                return (AlbumImageManager)services[typeof(AlbumImageManager)];
            }
            set
            {
                services[typeof(AlbumImageManager)] = value;
            }
        }
        public static SlideBannerManager SlideBannerManager
        {
            get
            {
                return (SlideBannerManager)services[typeof(SlideBannerManager)];
            }
            set
            {
                services[typeof(SlideBannerManager)] = value;
            }
        }

        public static CompanyCateManager CompanyCateManager
        {
            get
            {
                return (CompanyCateManager)services[typeof(CompanyCateManager)];
            }
            set
            {
                services[typeof(CompanyCateManager)] = value;
            }
        }

        public static CompanyManager CompanyManager
        {
            get
            {
                return (CompanyManager)services[typeof(CompanyManager)];
            }
            set
            {
                services[typeof(CompanyManager)] = value;
            }
        }

        public static IntroductionManager IntroductionManager
        {
            get
            {
                return (IntroductionManager)services[typeof(IntroductionManager)];
            }
            set
            {
                services[typeof(IntroductionManager)] = value;
            }
        }

        public static DevelopMonthManager DevelopMonthManager
        {
            get
            {
                return (DevelopMonthManager)services[typeof(DevelopMonthManager)];
            }
            set
            {
                services[typeof(DevelopMonthManager)] = value;
            }
        }

        public static DevelopYearManager DevelopYearManager
        {
            get
            {
                return (DevelopYearManager)services[typeof(DevelopYearManager)];
            }
            set
            {
                services[typeof(DevelopYearManager)] = value;
            }
        }

        public static NewsCategoryManager NewsCategoryManager
        {
            get
            {
                return (NewsCategoryManager)services[typeof(NewsCategoryManager)];
            }
            set
            {
                services[typeof(NewsCategoryManager)] = value;
            }
        }

        public static NewsManager NewsManager
        {
            get
            {
                return (NewsManager)services[typeof(NewsManager)];
            }
            set
            {
                services[typeof(NewsManager)] = value;
            }
        }

        public static NewsImageManager NewsImageManager
        {
            get
            {
                return (NewsImageManager)services[typeof(NewsImageManager)];
            }
            set
            {
                services[typeof(NewsImageManager)] = value;
            }
        }
		public static SysUserInGroupManager SysUserInGroupManager
		{
			get
			{
				return (SysUserInGroupManager)services[typeof(SysUserInGroupManager)];
			}
			set
			{
				services[typeof(SysUserInGroupManager)] = value;
			}
		}

		public static SysGroupManager SysGroupManager
		{
			get
			{
				return (SysGroupManager)services[typeof(SysGroupManager)];
			}
			set
			{
				services[typeof(SysGroupManager)] = value;
			}
		}


		public static SysUserManager SysUserManager
		{
			get
			{
				return (SysUserManager)services[typeof(SysUserManager)];
			}
			set
			{
				services[typeof(SysUserManager)] = value;
			}
		}


		public static SysPermissionManager SysPermissionManager
		{
			get
			{
				return (SysPermissionManager)services[typeof(SysPermissionManager)];
			}
			set
			{
				services[typeof(SysPermissionManager)] = value;
			}
		}


		public static GroupPermissionManager GroupPermissionManager
		{
			get
			{
				return (GroupPermissionManager)services[typeof(GroupPermissionManager)];
			}
			set
			{
				services[typeof(GroupPermissionManager)] = value;
			}
		}







		public static T GetService<T>()
		{
			foreach (var service in services.Values)
			{
				if (service is T)
				{
					return (T)service;
				}
			}
			return default(T);
		}

	}

}
