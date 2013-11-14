using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDXBuilderLibrary.mdx.axisitems;
using MDXBuilderLibrary.mdx.interfaces;
using NUnit.Framework;
using Moq;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.axisitems.Set")]
    public class SetAxisItemTest
    {
        #region Tests

        [Test]
        public void InitializationWithNullItemByConstruct()
        {
            SetAxisItem SetItems = new SetAxisItem(null);
            Assert.AreEqual(SetItems.Build(), "{ }");
        }

        [Test]
        public void InitializationWithItemByConstruct()
        {
            var mock = new Mock<IMDXAxisItem>();
            mock.Setup(item => item.Build()).Returns("[Country].[AR]");

            SetAxisItem SetItems = new SetAxisItem(mock.Object);

            Assert.AreEqual(SetItems.Build(), "{ [Country].[AR] }");
        }

        [Test]
        public void InitializationWithItemByConstructAndOneItemByFunction()
        {
            var mock = new Mock<IMDXAxisItem>();
            mock.Setup(item => item.Build()).Returns("[Country].[AR]");

            SetAxisItem SetItems = new SetAxisItem(mock.Object);

            mock = new Mock<IMDXAxisItem>();
            mock.Setup(item => item.Build()).Returns("[Region].[America]");
            SetItems.AddAxisItem(mock.Object);

            Assert.AreEqual(SetItems.Build(), "{ [Country].[AR], [Region].[America] }");
        }

        #endregion
    }
}
