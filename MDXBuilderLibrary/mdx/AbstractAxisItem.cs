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
    public abstract class AbstractAxisItem  : IMDXAxisItem
    {

        abstract public string Build();
    }
}
