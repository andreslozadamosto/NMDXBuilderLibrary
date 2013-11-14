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
    [Category("MDXBuilderLibrary.axisitems.CountTest")]
    public class CountTest
    {
        #region Tests

        [Test]
        public void InitWithNull()
        {
            Count Item = new Count(null);

            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
        }

        [Test]
        public void InitWithBaseItem()
        {
            Count Item = new Count(MDXTextUtil.GetMoqMDXAxisItem());

            Assert.AreEqual("Count (" + MDXTextUtil.GetDummyMember() + ")", Item.Build());
        }

        [Test]
        public void InitWithbaseItemAndOptionBySetter()
        {
            Count Item = new Count(MDXTextUtil.GetMoqMDXAxisItem());
            Item.Options = Count.Key.EXCLUDEEMPTY;

            Assert.AreEqual("Count (" + MDXTextUtil.GetDummyMember() + ", " + Count.Key.EXCLUDEEMPTY.ToString() + ")", Item.Build());
        }

        #endregion
    }
}
