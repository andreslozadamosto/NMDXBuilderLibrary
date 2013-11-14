using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx;

namespace MDXBuilderLibrary.mdx.customs.sap
{
    public class SAPMDXBuilder : MDXBuilder
    {
        private List<ISAPMDXVariable> SapVariables;

        public SAPMDXBuilder()
        {
            this.SapVariables = new List<ISAPMDXVariable>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        public void AddVariable(ISAPMDXVariable variable)
        {
            if ( variable != null )
                this.SapVariables.Add(variable);
        }

        public override string Build()
        {
            string ret = base.Build();

            if (ret != "" && this.SapVariables.Count > 0)
            {
                ret += " SAP VARIABLES";
                for (int i = 0; i < this.SapVariables.Count; i++)
                {
                    ret += " " + this.SapVariables[i].Build();
                }
            }

            return ret;
        }
    }
}
