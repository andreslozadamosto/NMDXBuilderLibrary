using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx.axisitems
{
    public class SetAxisItem : AbstractAxisItem
    {
        private List<IMDXAxisItem> MemberList;

        /// <summary>
        /// 
        /// </summary>
        public void AddMember()
        {
        }

        /// <summary>
        /// Consutructor with out params
        /// </summary>
        public SetAxisItem(IMDXAxisItem AxisItem)
        {
            MemberList = new List<IMDXAxisItem>();
            if (AxisItem != null)
            {
                MemberList.Add(AxisItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AxisItem"></param>
        public void AddAxisItem(IMDXAxisItem AxisItem)
        {
            if (AxisItem == null) return;
            this.MemberList.Add(AxisItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AxisItemList"></param>
        public void AddAxisItemList(List<IMDXAxisItem> AxisItemList)
        {
            this.MemberList.AddRange(AxisItemList);
        }

        /* ********************************************* */
        public override string Build()
        {
            string ret = "{ }";

            if (this.MemberList != null && this.MemberList.Count > 0)
            {
                ret = "{ " + this.MemberList[0].Build();

                for (int i = 1; i < this.MemberList.Count; i++)
                {
                    ret += ", " + this.MemberList[i].Build();
                }

                ret += " }";
            }

            return ret;
        }
    }
}
