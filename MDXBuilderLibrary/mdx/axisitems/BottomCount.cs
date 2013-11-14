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
    /// <see cref="http://msdn.microsoft.com/es-es/library/ms144864.aspx"/>
    /// <example>
    /// BottomCount item = new BottomCount(new StringAxisItem("[DIMENSION].[ITEM]"), 10);
    /// try 
    /// {
    ///     string query = item.Build(); //BottomCount ([DIMENSION].[ITEM], 10)
    /// }
    /// catch (MDXException e)
    /// {
    ///     //Do something
    /// }
    /// </example>
    public class BottomCount : AbstractAxisItem
    {
        private IMDXAxisItem BaseItem;
        /// <summary>
        /// Number of items that you want to get
        /// </summary>
        public uint Count = 0;

        /// <summary>
        /// Expresion to evaluate (needs to be a number)
        /// </summary>
        public string Measure;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Item"></param>
        public BottomCount(IMDXAxisItem Item, uint Count = 0, string Measure = "")
        {
            this.BaseItem = Item;
            this.Count = Count;
            this.Measure = Measure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <see cref="MDXBuilderLibrary.mdx.interfaces.IMDXAxisItem"/>
        public override string Build()
        {
            if (this.BaseItem == null || this.Count == 0)
            {
                throw MDXException.WhenBaseNotInit(this);
            }

            string Txt = this.BaseItem.Build();
            
            return "BottomCount (" +
                Txt + ", " +
                this.Count +
                ((this.Measure != "") ? ", " + this.Measure : "") +
                ")";
        }
    }
}
