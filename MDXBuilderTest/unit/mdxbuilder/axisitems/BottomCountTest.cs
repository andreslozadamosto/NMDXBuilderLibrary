using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using MDXBuilderLibrary.mdx.axisitems;
using MDXBuilderLibrary.mdx.Errors;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.axisitems.BottomCount")]
    public class BottomCountTest
    {
        #region Tests

        [Test]
        public void InitWithNull()
        {
            BottomCount Item = new BottomCount(null);
            
            Assert.Throws( Is.TypeOf<MDXException>()
                            .And.Message.EqualTo( MDXTextUtil.GetMessageErrorBaseNotInit(Item) ),
                            () => Item.Build());
        }

        [Test]
        public void InitWithBaseItemAndWithoutCount()
        {
            BottomCount Item = new BottomCount(MDXTextUtil.GetMoqMDXAxisItem());

            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
        }

        [Test]
        public void InitWithBaseItemAndCountByConstructor()
        {
            BottomCount Item = new BottomCount(MDXTextUtil.GetMoqMDXAxisItem(), 10);

            Assert.AreEqual("BottomCount (" + MDXTextUtil.GetDummyMember() + ", 10)", Item.Build());
        }

        [Test]
        public void InitWithBaseItemAndCountBySetter()
        {
            BottomCount Item = new BottomCount(MDXTextUtil.GetMoqMDXAxisItem(), 10);
            Item.Count = 5;

            Assert.AreEqual("BottomCount (" + MDXTextUtil.GetDummyMember() + ", 5)", Item.Build());
        }

        [Test]
        public void InitWithBaseItemAndCountAndMeasure()
        {
            BottomCount Item = new BottomCount(MDXTextUtil.GetMoqMDXAxisItem(), 10, "[Measures].[Sales]");

            Assert.AreEqual("BottomCount (" + MDXTextUtil.GetDummyMember() + ", 10, [Measures].[Sales])", Item.Build());
        }

        #endregion
    }
}
