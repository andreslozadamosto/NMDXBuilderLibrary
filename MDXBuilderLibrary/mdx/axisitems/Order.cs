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
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms145587.aspx"/>
    public class Order : AbstractAxisItem 
    {
        public enum OrderType { NONE, ASC, DESC, BASC, BDESC };
        /// <summary>
        /// 
        /// </summary>
        public string OrderComparator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OrderType TypeOrder;

        private IMDXAxisItem BaseAxisItem;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="AxisItem"></param>
        public Order(IMDXAxisItem AxisItem)
        {
            this.BaseAxisItem = AxisItem;
        }

        public override string Build()
        {
            if (this.BaseAxisItem == null || this.OrderComparator == null || this.OrderComparator == "")
            {
                throw MDXException.WhenBaseNotInit(this);
            }
            return "ORDER (" + this.BaseAxisItem.Build() + ", " + this.OrderComparator + this.GetOrderType() + ")";
        }

        private string GetOrderType()
        {
            string Txt = Enum.GetName(typeof(OrderType), this.TypeOrder);
            if (Txt != "" && Txt != "NONE")
            {
                return ", " + Txt;
            }

            return "";
        }
    }
}
