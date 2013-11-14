using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDXBuilderLibrary.mdx.customs.sap
{
    public class MDXSAPVariable : ISAPMDXVariable
    {
        public const string COMP_EQ = "=";
        public const string COMP_NO_EQ = "<>";
        public const string COMP_LT = "<";
        public const string COMP_GT = ">";

        /// <summary>
        /// Constructor
        /// </summary>
        public MDXSAPVariable()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Var"></param>
        /// <param name="Inc"></param>
        /// <param name="Comp"></param>
        /// <param name="Val"></param>
        public MDXSAPVariable(string Var, bool Inc, string Comp, string Val)
        {
            this.Variable = Var;
            this.Include = Inc;
            this.Comparator = Comp;
            this.Value = Val;
        }

        public string Build()
        {
            if (this.Variable != null && this.Variable != "" )
            {
                if (this.Comparator != null && this.Comparator != "")
                {
                    if (this.Value != null && this.Value != "")
                    {
                        return this.Variable + " " + this.ComparatorString + " " + this.Comparator + " " + this.Value;
                    }
                }
            }
            
            return "";
        }

        public string Value { get; set; }

        public string Comparator { get; set; }

        public bool Include { get; set; }

        public string Variable { get; set; }

        protected string ComparatorString 
        {
            get {
                return (this.Include) ? "INCLUDING" : "EXCLUDE";
            }
        }
    }
}
