using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx;
using MDXBuilderLibrary.mdx.interfaces;
using MDXBuilderLibrary.mdx.Errors;

namespace MDXBuilderLibrary.mdx.axisitems
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms145988.aspx"/>
    public class NonEmpty : AbstractAxisItem
    {
        private IMDXAxisItem BaseAxisItem;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="AxisItem"></param>
        public NonEmpty(IMDXAxisItem AxisItem)
        {
            this.BaseAxisItem = AxisItem;
        }


        public override string Build()
        {
            if (this.BaseAxisItem == null)
            {
                throw MDXException.WhenBaseNotInit(this);
            }

            return "NON EMPTY { " + this.BaseAxisItem.Build() + " }";
        }
    }
}
