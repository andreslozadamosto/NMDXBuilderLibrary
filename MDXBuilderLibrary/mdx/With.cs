using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx
{
    class With
    {
        private IList<IMDXWithItem> WithList;

        public With()
        {
            this.WithList = new List<IMDXWithItem>();
        }

        public void AddItem(IMDXWithItem Item)
        {
            this.WithList.Add(Item);
        }

        public int Count()
        {
            return this.WithList.Count;
        }

        public string Build()
        {
            if (this.WithList != null && this.WithList.Count > 0)
            {
                string retText = "";
                retText += this.WithList[0].Build();
                for (int i = 1; i < this.WithList.Count; i++)
                {
                    retText += Environment.NewLine + this.WithList[i].Build();
                }
                return "WITH " + Environment.NewLine + retText;
            }
            return "";
        }
    }
}
