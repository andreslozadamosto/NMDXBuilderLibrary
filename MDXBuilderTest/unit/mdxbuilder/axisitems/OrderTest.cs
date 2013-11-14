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
    [Category("MDXBuilderLibrary.axisitems.Order")]
    public class OrderTest
    {
        #region Tests

        [Test]
        public void InitializationShouldbeEmpty()
        {
            Order Item = new Order(null);

            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
        }

        [Test]
        public void InitializationWihtAxisItemByParam()
        {
            Order Item = new Order(MDXTextUtil.GetMoqMDXAxisItem());

            Assert.Throws(Is.TypeOf<MDXException>()
                            .And.Message.EqualTo(MDXTextUtil.GetMessageErrorBaseNotInit(Item)),
                            () => Item.Build());
        }

        [Test]
        public void InitializationWihtAxisItemByParamAndComparator()
        {
            Order Item = new Order(MDXTextUtil.GetMoqMDXAxisItem());
            Item.OrderComparator = MDXTextUtil.GetDummySalesMeasure();

            Assert.AreEqual("ORDER (" + MDXTextUtil.GetDummyMember() + ", " + MDXTextUtil.GetDummySalesMeasure() + ")", Item.Build());
        }

        [Test]
        public void InitializationWihtAxisItemByParamAndComparatorAndDescType()
        {
            Order Item = new Order(MDXTextUtil.GetMoqMDXAxisItem());
            Item.OrderComparator = MDXTextUtil.GetDummySalesMeasure();
            Item.TypeOrder = Order.OrderType.DESC;
            string expect = "ORDER (" + 
                MDXTextUtil.GetDummyMember() + ", " + 
                MDXTextUtil.GetDummySalesMeasure() + ", " + 
                Order.OrderType.DESC.ToString() + ")";
            Assert.AreEqual(expect, Item.Build());
        }
        #endregion
    }
}
