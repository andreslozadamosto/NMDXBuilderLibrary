using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx.axisitems
{
    /// <summary>
    /// Class for AVG function
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms146067.aspx"/>
    public class AVG : AbstractAxisItem
    {
        private IMDXAxisItem _Item;
        private MemberAxisItem _Measure;

        #region Constructors
        public AVG(IMDXAxisItem Item, MemberAxisItem Measure = null)
        {
            this._Item = Item;
            this._Measure = Measure;
        }
        #endregion //Constructors

        #region API
        public IMDXAxisItem Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }

        public MemberAxisItem Measure
        {
            get { return this._Measure; }
            set { this._Measure = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <see cref="MDXBuilderLibrary.mdx.interfaces.IMDXAxisItem"/>
        public override string Build()
        {
            string parentItem = (this._Item != null) ? this._Item.Build() : "";
            if (parentItem != null)
            {
                return "AVG (" + parentItem + ((this._Measure != null) ? " ," + this._Measure.Build() : "") + ")";
            }
            return "";
        }

        #endregion //API
    }
}
