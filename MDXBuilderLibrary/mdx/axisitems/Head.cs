using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;
using MDXBuilderLibrary.mdx.Errors;

namespace MDXBuilderLibrary.mdx.axisitems
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms144859.aspx"/>
    public class Head : AbstractAxisItem
    {
        private IMDXAxisItem BaseAxisItem;

        private uint _count = 0;
        /// <summary>
        /// Number of items to get from Head
        /// </summary>
        /// <value>0</value>
        public uint Count { 
            get 
            {
                return this._count;
            }
            set 
            {
                this._count = value;
            } 
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="AxisItem"></param>
        public Head(IMDXAxisItem AxisItem)
        {
            this.BaseAxisItem = AxisItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <see cref="MDXBuilderLibrary.mdx.interfaces.IMDXAxisItem"/>
        public override string Build()
        {
            if (this.BaseAxisItem == null || this.Count == 0)
            {
                throw MDXException.WhenBaseNotInit(this);
            }

            return "HEAD (" + this.BaseAxisItem.Build() + ", " + this.Count.ToString() + ")";
        }
    }
}
