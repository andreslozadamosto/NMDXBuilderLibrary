using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx.axisitems
{
    /// <summary>
    /// Clase para agregar MDX directamente
    /// </summary>
    public class StringAxisItem : AbstractAxisItem
    {
        private string Txt;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="txt"></param>
        public StringAxisItem(string txt)
        {
            this.Txt = txt;
        }

        public override string Build()
        {
            return this.Txt;
        }
    }
}
