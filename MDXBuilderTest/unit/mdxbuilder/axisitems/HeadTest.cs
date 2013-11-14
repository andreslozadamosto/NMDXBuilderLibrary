using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MDXBuilderLibrary.mdx.axisitems;
using MDXBuilderLibrary.mdx.interfaces;
using MDXBuilderLibrary.mdx.Errors;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.axisitems.Head")]
    public class HeadTest
    {
        #region Tests

        [Test]
        public void InitializationWithNull()
        {
            Head Item = new Head(null);

            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
        }

        [Test]
        public void InitializationWihtIMDXAxisItem()
        {
            Head Item = new Head(MDXTextUtil.GetMoqMDXAxisItem());

            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
        }


        [Test]
        public void InitializationWihtIMDXAxisItemAndCountOfHead()
        {
            Head Item = new Head(MDXTextUtil.GetMoqMDXAxisItem());
            Item.Count = 5;

            Assert.AreEqual("HEAD (" + MDXTextUtil.GetDummyMember() + ", 5)", Item.Build());
        }

        #endregion
    }
}
