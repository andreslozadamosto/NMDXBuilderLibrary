using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderLibrary.mdx
{
    /// <summary>
    /// This class create a MDX string
    /// </summary>
    public class MDXBuilder
    {
        private string _BaseTemplate = "SELECT {MDX_AXIS} FROM {CUBE_NAME}";
        private string _WhereTemplate = "WHERE {WHERE_DATA}";
        private string _Where = "";
        private With _With;
        private string _Template;

        /// <summary>
        /// MDX Query Tamplate
        /// </summary>
        protected string BaseTemplate
        {
            get { return this._BaseTemplate; }
        }

        public string Template
        {
            get { return (!String.IsNullOrEmpty(this._Template)) ? this._Template : this.BaseTemplate; }
            set { this._Template = value; }
        }

        protected List<IMDXAxis> AxisList;

        /// <summary>
        /// Number of Axis 
        /// </summary>
        public int AxisCount
        {
            get { return (AxisList != null) ? AxisList.Count : 0; }
        }

        /// <summary>
        /// The name of the Cube of the Query
        /// </summary>
        public string CubeName { get; set; } 

        /// <summary>
        /// Constructor
        /// </summary>
        public MDXBuilder ()
        {
            this.AxisList = new List<IMDXAxis>();
            this._With = new With();
        }

        /// <summary>
        /// Generate a MDX query
        /// </summary>
        /// <returns></returns>
        virtual public string Build()
        {
            string result = this.Template;//this.BaseTemplate;
            if (this.CubeName != null && this.CubeName != "")
            {
                result = result.Replace("{CUBE_NAME}", this.CubeName);//this.BaseTemplate.Replace("{CUBE_NAME}", this.CubeName);
            }

            if (this.AxisCount > 0)
            {
                string Txt = "";
                Txt = this.AxisList[0].Build();
                for (int i = 1; i < this.AxisCount; i++)
                {
                    Txt += ", " + this.AxisList[i].Build();
                }

                result = result.Replace("{MDX_AXIS}", Txt);
            }
            if (this._Where != "")
            {
                string template = this._WhereTemplate;
                template = template.Replace("{WHERE_DATA}", this._Where);
                result += " " + template;
            }

            if (this._With != null && this._With.Count() > 0)
            {

                result = this._With.Build() + Environment.NewLine + result;
            }

            return result;
        }

        public void AddWithItem(IMDXWithItem Item)
        {
            this._With.AddItem(Item);
        }

        /// <summary>
        /// Adds a new axis to MDX Query
        /// </summary>
        /// <param name="axis"></param>
        public void AddAxis(IMDXAxis axis)
        {
            if (axis != null)
            {
                this.AxisList.Add(axis);
            }
        }

        public void AddWhere(string value)
        {
            this._Where = value;
        }

        ~MDXBuilder()
        {
            if (AxisList.Count > 0)
            {
                for (int i = 0; i < AxisList.Count; i++)
                {

                }
                AxisList.Clear();
            }
        }

    }
}
