using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MDXBuilderLibrary.mdx.axisitems;
using MDXBuilderLibrary.mdx.Errors;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.axisitems.NonEmpty")]
    public class NonEmptyTest
    {
        #region Tests

        [Test]
        public void InitializationNull()
        {
            NonEmpty AxisItem = new NonEmpty(null);
            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(AxisItem)),
                            () => AxisItem.Build());
        }

        [Test]
        public void InitializationOk()
        {
            NonEmpty AxisItem = new NonEmpty(MDXTextUtil.GetMoqMDXAxisItem());

            Assert.AreEqual("NON EMPTY { " + MDXTextUtil.GetDummyMember() + " }", AxisItem.Build());
        }

        #endregion
    }
}
