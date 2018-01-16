using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace RESYS.BIZ.Models
{
    public class News : EntityBase
    {
        [DataColum]
        public int NewsId { get; set; }

        [DataColum]
        public int NewsCategoryId { get; set; }

        [DataColum]
        public string NewsCategoryShortName { get; set; }

        [DataColum]
        public string NewsCategoryTitle { get; set; }

        [DataColum]
        public string NewsTitle { get; set; }

        [DataColum]
        public string NewsShortName { get; set; }

        [DataColum]
        public int CompanyId { get; set; }

        [DataColum]
        public string CompanyName { get; set; }

        [DataColum]
        public string CompanyShortName { get; set; }

        [DataColum]
        public string NewsBody { get; set; }

        [DataColum]
        public string NewsDescription { get; set; }

        [DataColum]
        public string NewsKeyword { get; set; }

        [DataColum]
        public string NewsImage { get; set; }
        
        [DataColum]
        public DateTime NewsPublishDate { get; set; }

        [DataColum]
        public bool IsHotNews { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public int Count { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }     

        public List<NewsImage> ListNewsImage
        {
            get;
            set;
        }

    }

    public class NewsCategory : NewsCategoryBase
    {
        public NewsCategory()
            : base()
        {
        }
        public NewsCategory(int id)
            : this()
        {

            this.NewsCategoryId = id;
        }
        public NewsCategory(string name)
            : this()
        {

            this.NewsCategoryTitle = name;
        }
        [DataColum]
        public string NewsCategoryShortName { get; set; }

        [DataColum]
        public string NewsCategorySummary { get; set; }

        [DataColum]
        public string NewsCategoryDescription { get; set; }

        [DataColum]
        public string NewsCategoryKeyword { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string Culture { get; set; }

        public List<News> ListNews { get; set; }

    }
}
