using System;
using MDXBuilderLibrary.mdx;
using MDXBuilderLibrary.mdx.axisitems;
using MDXBuilderLibrary.mdx.customs.sap;
using NUnit.Framework;
using MDXBuilderLibrary.mdx.interfaces;

namespace MDXBuilderTest.integration
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.integration.SAPMDXBuilder")]
    public class CompleteSapIntegration
    {
        [Test]
        public void CompleteTest()
        {
            string compResult = "SELECT ";
            compResult += "NON EMPTY { CrossJoin ([COUNTRY].Members, [CITY].Members) } ON ROWS, ";
            compResult += "NON EMPTY { { [Measures].[ventas], [Measures].[stock] } } ON COLUMNS ";
            compResult += "FROM Ventas ";
            compResult += "SAP VARIABLES ";
            compResult += "Country INCLUDE = AR ";
            compResult += "Country INCLUDE = CR";

            //builder
            SAPMDXBuilder Builder = new SAPMDXBuilder();
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

            //Add SAP Variables
            Builder.AddVariable(new MDXSAPVariable("Country", true, MDXSAPVariable.COMP_EQ, "AR"));
            Builder.AddVariable(new MDXSAPVariable("Country", true, MDXSAPVariable.COMP_EQ, "CR"));

            Assert.AreEqual(Builder.Build(), compResult);
        }
    }
}
