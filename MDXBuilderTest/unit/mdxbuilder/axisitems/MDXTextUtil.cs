using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    public class MDXTextUtil
    {
        #region DummyData
        static public string GetDummyMember()
        {
            return MDXTextUtil.GetCountryDummyMember();
        }
        static public string GetRegionDummyMembers()
        {
            return "[Region].Members";
        }
        static public string getCountryDummyMembers()
        {
            return "[Country].Members";
        }
        static public string GetDepartamentsDummyMembers()
        {
            return "[Departaments].Members";
        }
        static public string GetCountryDummyMember()
        {
            return "[Country].[AR]";
        }
        static public string GetDummySalesMeasure()
        {
            return "[Measures].[Sales]";
        }
        static public string GetDummySalesPointMembers()
        {
            return "[SellPoints].Members";
        }
        #endregion

        static public IMDXAxisItem GetMoqMDXAxisItem(string txt = "")
        {
            var Mock = new Mock<IMDXAxisItem>();
            Mock.Setup(item => item.Build()).Returns(((txt == "") ? MDXTextUtil.GetDummyMember() : txt));

            return Mock.Object;
        }

        static public string GetMessageErrorBaseNotInit(object item)
        {
            return item.GetType().ToString() + " no initilize base item";
        }
    }
}
