using System;
using MDXBuilderLibrary.mdx;
using MDXBuilderLibrary.mdx.interfaces;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace MDXBuilderTest.unit.mdxbuilder
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.MDXBuilder")]
    public class MDXBuilderTest
    {
        [Test]
        public void InitializationShouldEmpty()
        {
            string Template = "SELECT {MDX_AXIS} FROM {CUBE_NAME}";
            MDXBuilder builder = new MDXBuilder();

            Assert.AreEqual(builder.Build(), Template);
            Assert.AreEqual(builder.AxisCount, 0);
        }

        [Test]
        public void InitializationWithOneAxis()
        {
            MDXBuilder builder = new MDXBuilder();
            var mock = new Mock<IMDXAxis>();
            builder.AddAxis(mock.Object);

            Assert.AreEqual(builder.AxisCount, 1);
        }

        [Test]
        public void InitializationWithTwoAxis()
        {
            MDXBuilder builder = new MDXBuilder();
            var mock = new Mock<IMDXAxis>();
            builder.AddAxis(mock.Object);
            mock = new Mock<IMDXAxis>();
            builder.AddAxis(mock.Object);

            Assert.AreEqual(builder.AxisCount, 2);
        }

        [Test]
        public void InitializationWithCubeName()
        {
            MDXBuilder builder = new MDXBuilder();
            builder.CubeName = "[Accounts]";

            Assert.AreEqual(builder.Build(), "SELECT {MDX_AXIS} FROM [Accounts]");
        }
    }
}
