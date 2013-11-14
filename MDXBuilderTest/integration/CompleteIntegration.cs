using System;
using MDXBuilderLibrary.mdx;
using MDXBuilderLibrary.mdx.axisitems;
using NUnit.Framework;

namespace MDXBuilderTest.integration
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.integration.MDXBuilder")]
    public class CompleteIntegration
    {
        [Test]
        public void CompleteTest()
        {
            string compResult = "SELECT ";
            compResult += "NON EMPTY { CrossJoin ([COUNTRY].Members, [CITY].Members) } ON ROWS, ";
            compResult += "NON EMPTY { { [Measures].[ventas], [Measures].[stock] } } ON COLUMNS ";
            compResult += "FROM Ventas";
            
            //builder
            MDXBuilder Builder = new MDXBuilder();
            Builder.CubeName = "Ventas";

            //ROW Axis
            MDXAxis RowAxis = new MDXAxis(MDXAxis.ROW_AXIS);
            CrossJoin CrossJoin = new CrossJoin(new MemberAxisItem("[COUNTRY].Members"));
            CrossJoin.AddCrossJointTo(new MemberAxisItem("[CITY].Members"));
            RowAxis.AxisItem = new NonEmpty(CrossJoin);

            //Column Axis
            MDXAxis ColumnAxis = new MDXAxis(MDXAxis.COLUMN_AXIS);
            SetAxisItem setList = new SetAxisItem(new MemberAxisItem("[Measures].[ventas]"));
            setList.AddAxisItem(new MemberAxisItem("[Measures].[stock]"));
            ColumnAxis.AxisItem = new NonEmpty(setList);

            //Add Axis to Builder
            Builder.AddAxis(RowAxis);
            Builder.AddAxis(ColumnAxis);

            Assert.AreEqual(compResult, Builder.Build());
        }
    }
}
