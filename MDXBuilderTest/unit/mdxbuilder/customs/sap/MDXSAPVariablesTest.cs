using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MDXBuilderLibrary.mdx.customs.sap;
using Moq;

namespace MDXBuilderTest.unit.mdxbuilder.customs.sap
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.customs.sap.MDXSAPVariables")]
    public class MDXSAPVariablesTest
    {
        #region Tests

        [Test]
        public void MDXSAPVariablesTest_InitializationShuldbeEmpty()
        {
            MDXSAPVariable SapVariable = new MDXSAPVariable();

            Assert.AreEqual(SapVariable.Build(), "");
        }

        [Test]
        public void MDXSAPVariablesTest_WithValuesByParam()
        {
            MDXSAPVariable SapVariable = new MDXSAPVariable("Country", true, MDXSAPVariable.COMP_EQ, "AR");

            Assert.AreEqual(SapVariable.Build(), "Country INCLUDE = AR");
        }

        #endregion
    }
}
