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
    /// <see cref="http://msdn.microsoft.com/es-es/library/ms144823.aspx"/>
    /// <example>
    /// BottomCount item = new Count(new StringAxisItem("[DIMENSION].[ITEM]"));
    /// try 
    /// {
    ///     string query = item.Build(); //Count ([DIMENSION].[ITEM])
    /// }
    /// catch (MDXException e)
    /// {
    ///     //Do something
    /// }
    /// </example>
    public class Count : AbstractAxisItem
    {
        private IMDXAxisItem BaseItem;

        /// <summary>
        /// Enum with both options that you can use
        /// </summary>
        public enum Key
        {
            /// <summary>
            /// Without options
            /// </summary>
            NONE,
            /// <summary>
            /// 
            /// </summary>
            EXCLUDEEMPTY,
            /// <summary>
            /// 
            /// </summary>
            INCLUDEEMPTY
        };

        /// <summary>
        /// Options, one of Count.Key property
        /// </summary>
        /// <value>Count.Key.NONE</value>
        public Count.Key Options = Count.Key.NONE;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Item"></param>
        public Count(IMDXAxisItem Item)
        {
            this.BaseItem = Item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <see cref="MDXBuilderLibrary.mdx.interfaces.IMDXAxisItem"/>
        public override string Build()
        {
            if (this.BaseItem == null)
            {
                throw MDXException.WhenBaseNotInit(this);
            }

            return "Count (" +
                this.BaseItem.Build() +
                ((this.Options != Count.Key.NONE) ? ", " + this.Options.ToString() : "") +
                ")";
        }
    }
}