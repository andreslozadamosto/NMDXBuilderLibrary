using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDXBuilderLibrary.mdx.customs.sap
{
    public interface ISAPMDXVariable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string Build();

        /// <summary>
        /// 
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Comparator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool Include { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Variable { get; set; }
    }
}
