using System;
using MDXBuilderLibrary.mdx.interfaces;
using MDXBuilderLibrary.mdx;
using Moq;
using NUnit.Framework;

namespace MDXBuilderTest.unit.mdxbuilder
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.MDXAxis")]
    public class MDXAxisTest
    {
        [Test]
        public void InitalizationEmpty()
        {
            MDXAxis axis = new MDXAxis();

            Assert.AreEqual(axis.Build(), "");
        }

        [Test]
        public void InitializationWhitRowAxisByConstructParam()
        {
            MDXAxis axis = new MDXAxis(MDXAxis.ROW_AXIS);

            Assert.AreEqual(axis.AxisType, MDXAxis.ROW_AXIS);
        }

        [Test]
        public void InitializationWhitRowAxisByProperty()
        {
            MDXAxis axis = new MDXAxis();
            axis.AxisType = MDXAxis.ROW_AXIS;

            Assert.AreEqual(axis.AxisType, MDXAxis.ROW_AXIS);
        }

        [Test]
        public void InitializationWhitColumnAxisByConstructParam()
        {
            MDXAxis axis = new MDXAxis(MDXAxis.COLUMN_AXIS);

            Assert.AreEqual(axis.AxisType, MDXAxis.COLUMN_AXIS);
        }

        [Test]
        public void InitializationWhitColumnAxisByProperty()
        {
            MDXAxis axis = new MDXAxis();
            axis.AxisType = MDXAxis.COLUMN_AXIS;

            Assert.AreEqual(axis.AxisType, MDXAxis.COLUMN_AXIS);
        }

        [Test]
        public void InitializationWhitSliceAxisByConstructParam()
        {
            MDXAxis axis = new MDXAxis(MDXAxis.SLICE_AXIS);

            Assert.AreEqual(axis.AxisType, MDXAxis.SLICE_AXIS);
        }

        [Test]
        public void InitializationWhitSliceAxisByProperty()
        {
            MDXAxis axis = new MDXAxis();
            axis.AxisType = MDXAxis.SLICE_AXIS;

            Assert.AreEqual(axis.AxisType, MDXAxis.SLICE_AXIS);
        }

        [Test]
        public void AxisWithOneAxisItemAndRowType()
        {
            MDXAxis axis = new MDXAxis(MDXAxis.ROW_AXIS);
            var mock = new Mock<IMDXAxisItem>();
            mock.Setup(item => item.Build()).Returns("[Country].Members");

            axis.AxisItem = mock.Object;

            Assert.AreEqual(axis.Build(), "[Country].Members ON ROWS");
        }
    }
}
