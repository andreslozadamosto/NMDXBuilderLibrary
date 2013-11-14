using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDXBuilderLibrary.mdx.interfaces
{
    public interface IMDXAxis
    {
        /// <summary>
        /// Documentacion por aca
        /// </summary>
        /// <returns>El texto generado</returns>
        string Build();

        /// <summary>
        /// 
        /// </summary>
        IMDXAxisItem AxisItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string AxisType { get; set; }
    }
}
