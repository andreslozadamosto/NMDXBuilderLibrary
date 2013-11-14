using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx.axisitems
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms145628.aspx"/>
    public class Covariance: AbstractAxisItem
    {
        private IMDXAxisItem _Set;
        private MemberAxisItem _MeasureX;
        private MemberAxisItem _MeasureY;

        public Covariance(IMDXAxisItem Set, MemberAxisItem MeasureY, MemberAxisItem MeasureX = null)
        {
            this._Set = Set;
            this._MeasureX = MeasureX;
            this._MeasureY = MeasureY;
        }

        public override string Build()
        {
            if (this._Set != null && this._MeasureY != null)
            {
                return "Covariance(" +
                    this._Set.Build() +
                    ", " + this._MeasureY.Build() +
                    ((this._MeasureX != null) ? ", " + this._MeasureX.Build() : "") +
                    ")";
            }
            return "";
        }
    }
}
