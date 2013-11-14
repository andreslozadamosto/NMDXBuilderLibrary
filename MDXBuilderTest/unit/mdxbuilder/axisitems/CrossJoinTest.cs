using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MDXBuilderLibrary.mdx.interfaces;
using MDXBuilderLibrary.mdx.axisitems;
using MDXBuilderLibrary.mdx.Errors;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.axisitems.CrossJoin")]
    public class CrossJoinTest
    {
       #region Tests
        [Test]
        public void InitWithNull()
        {
            CrossJoin Item = new CrossJoin(null);

            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());

            Item = new CrossJoin(MDXTextUtil.GetMoqMDXAxisItem());
            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
        }

        [Test]
        public void CompleteTest()
        {
            CrossJoin Item = new CrossJoin(MDXTextUtil.GetMoqMDXAxisItem(MDXTextUtil.getCountryDummyMembers()));
            Item.AddCrossJointTo(MDXTextUtil.GetMoqMDXAxisItem(MDXTextUtil.GetDummySalesPointMembers()));
            string expected = "CrossJoin (" + 
                MDXTextUtil.getCountryDummyMembers() + ", " + 
                MDXTextUtil.GetDummySalesPointMembers() + ")";
            Assert.AreEqual(expected, Item.Build());
        }

        [Test]
        public void CompleteTestWith3CrossJoin()
        {
            CrossJoin Item = new CrossJoin(MDXTextUtil.GetMoqMDXAxisItem(MDXTextUtil.GetRegionDummyMembers()));
            Item.AddCrossJointTo(MDXTextUtil.GetMoqMDXAxisItem(MDXTextUtil.getCountryDummyMembers()));
            Item.AddCrossJointTo(MDXTextUtil.GetMoqMDXAxisItem(MDXTextUtil.GetDummySalesPointMembers()));
            string expected = "CrossJoin (" + 
                MDXTextUtil.GetRegionDummyMembers() + ", " + 
                MDXTextUtil.getCountryDummyMembers() + ", " + 
                MDXTextUtil.GetDummySalesPointMembers() + ")";
            Assert.AreEqual(expected, Item.Build());
        }
        #endregion
    }
}
