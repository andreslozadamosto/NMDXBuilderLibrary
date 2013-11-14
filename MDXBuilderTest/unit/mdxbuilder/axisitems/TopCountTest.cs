using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MDXBuilderLibrary.mdx.axisitems;
using MDXBuilderLibrary.mdx.Errors;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.axisitems.TopCount")]
    public class TopCountTest
    {
         [Test]
         public void InitWithNull()
         {
             TopCount Item = new TopCount(null);

             Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
         }

         [Test]
         public void InitWithAxisItemAndDataOK()
         {
             TopCount Item = new TopCount(MDXTextUtil.GetMoqMDXAxisItem());
             Item.Comparator = MDXTextUtil.GetDummySalesMeasure();
             Item.Count = 5;

             Assert.AreEqual("TOPCOUNT (" + MDXTextUtil.GetDummyMember() + ", 5, " + MDXTextUtil.GetDummySalesMeasure() + ")", Item.Build());
         }
    }
}
