using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDXBuilderLibrary.mdx.Errors
{
    public class MDXException : Exception
    {

        #region Constructor
        public MDXException() : base()
        {
        }

        public MDXException(string message) : base(message)
        {
            
        }
        public MDXException(string message, Exception innerException) : base(message, innerException)
        {
        }
        #endregion


        static public MDXException WhenBaseNotInit(object clazz)
        {
            return new MDXException(clazz.GetType().ToString() + " no initilize base item");
        }
        
    }
}
