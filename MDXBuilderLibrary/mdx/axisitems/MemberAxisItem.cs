using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx.axisitems
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberAxisItem :  AbstractAxisItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Member { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public MemberAxisItem()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="AxisItem"></param>
        public MemberAxisItem(IMDXAxisItem AxisItem)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m"></param>
        public MemberAxisItem(string m)
        {
            this.Member = m;
        }

        public override string Build()
        {
            return (this.Member != null) ? this.Member : "";
        }
    }
}
