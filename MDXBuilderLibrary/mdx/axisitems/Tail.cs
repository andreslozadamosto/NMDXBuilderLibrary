using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx.axisitems
{
    class Tail : AbstractAxisItem
    {
        private IMDXAxisItem BaseAxisItem;
        /// <summary>
        /// Cantidad
        /// </summary>
        public int Count = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Item"></param>
        public Tail(IMDXAxisItem Item, int Count = 0)
        {
            this.BaseAxisItem = Item;
        }

        public override string Build()
        {
            return "TAIL (" + this.BaseAxisItem.Build() + ", " + this.Count + ")";
        }
    }
}
