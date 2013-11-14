using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;
using MDXBuilderLibrary.mdx.axisitems;

namespace MDXBuilderLibrary.mdx.with
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms145487.aspx"/>
    public class Set :IMDXWithItem
    {
        private IMDXAxisItem _Set;
        private string _Name;


        public Set(string Name, IMDXAxisItem Set)
        {
            this._Set = Set;
            this._Name = Name;
        }

        public string Build()
        {
            if (this._Set != null)
            {
                string txt = this._Set.Build();
                string retTxt = "SET " + this._Name + " AS ";
                if (this._Set is SetAxisItem)
                {
                    retTxt = txt;
                }
                else 
                {
                    retTxt = "'" + txt + "'";
                }

                return retTxt;
            }
            return "";
        }
    }
}
