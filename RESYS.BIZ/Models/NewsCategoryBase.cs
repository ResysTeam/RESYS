using idocNet.Client.Core.Data;
using idocNet.Client.Core.Data.Entities;
using idocNet.Client.Core.Data.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESYS.BIZ.Models
{
    public class NewsCategoryBase : EntityBase
    {
        [DataColum]
        public int NewsCategoryId { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public string NewsCategoryTitle { get; set; }

        private NewsCategoryBase _parent;
        public NewsCategoryBase Parent
        {
            get
            {
                return _parent ?? (_parent = new NewsCategoryBase()
                {
                    NewsCategoryId = ParentId
                });
            }
            set { _parent = value; }
        }

        public List<NewsCategoryBase> Children { get; set; }

        public int HLevel
        {
            get;
            set;
        }

        public string HlevelTitle
        {
            get
            {
                if (HLevel > 0)
                {
                    var l = "";
                    for (var i = 1; i <= HLevel; ++i)
                    {
                        l += "|--";
                    }
                    return string.Format("{0}{1}", l, NewsCategoryTitle);

                }

                return NewsCategoryTitle;
            }
        }
    }
}
