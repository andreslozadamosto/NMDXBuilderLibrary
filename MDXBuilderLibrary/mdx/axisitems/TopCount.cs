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
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms144792.aspx"/>
    public class TopCount : AbstractAxisItem
    {
        private IMDXAxisItem BaseAxisItem;

        private uint _count = 0;
        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        public string Comparator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="AxisItem"></param>
        public TopCount(IMDXAxisItem AxisItem)
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
            return "TOPCOUNT (" + this.BaseAxisItem.Build() + ", " + this.Count.ToString() + ((this.Comparator != "") ? ", " + this.Comparator : "") + ")";
        }
    }
}
