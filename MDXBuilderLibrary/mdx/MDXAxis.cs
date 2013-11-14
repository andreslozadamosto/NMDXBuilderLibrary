using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx
{
    /// <summary>
    /// 
    /// </summary>
    public class MDXAxis : IMDXAxis
    {
        #region Constants
        /// <summary>
        /// 
        /// </summary>
        public const string ROW_AXIS = "ROWS";
        /// <summary>
        /// 
        /// </summary>
        public const string COLUMN_AXIS = "COLUMNS";
        /// <summary>
        /// 
        /// </summary>
        public const string SLICE_AXIS = "SLICE";
        #endregion //Constants

        #region Constructors
        /// <summary>
        /// Consutructor
        /// </summary>
        public MDXAxis()
        {
        }

        /// <summary>
        /// Consutructor
        /// </summary>
        /// <param name="type">Axis type (ROW, COLUMN, SLICE, etc)</param>
        public MDXAxis(string type)
        {
            this.AxisType = type;
        }
        #endregion //Constructors

        #region PublicAPI
        public string Build()
        {
 	        return (this.AxisItem != null) ? this.AxisItem.Build() + " ON " + this.AxisType : "";
        }

        public IMDXAxisItem AxisItem { get; set;}

        public string AxisType { get; set; }
        #endregion //PublicAPI
    }
}
