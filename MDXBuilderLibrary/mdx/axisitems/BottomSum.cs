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
    public class BottomSum : AbstractAxisItem
    {
        private IMDXAxisItem _Set;
        private int _Percent = 0;
        private MemberAxisItem _Meaure;

        public BottomSum(IMDXAxisItem Set, int Percent, MemberAxisItem Measure)
        {
            this._Meaure = Measure;
            this._Percent = Percent;
            this._Set = Set;
        }

        public override string Build()
        {
            if (this._Meaure != null && this._Percent > 0 && this._Set != null)
            {
                return "BottomSum(" +
                    this._Set.Build() +
                    ", " + this._Percent +
                    ", " + this._Meaure.Build() +
                    ")";
            }
            return "";
        }
    }
}
