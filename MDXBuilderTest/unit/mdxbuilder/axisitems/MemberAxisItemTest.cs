using System;
using MDXBuilderLibrary.mdx.axisitems;
using NUnit.Framework;

namespace MDXBuilderTest.unit.mdxbuilder.axisitems
{
    [TestFixture]
    [Category("MDXBuilderLibrary")]
    [Category("MDXBuilderLibrary.axisitems.MemberAxisItem")]
    public class MemberAxisItemTest
    {
        [Test]
        public void InitializationShoulBeEmpty()
        {
            MemberAxisItem item = new MemberAxisItem();

            Assert.AreEqual(item.Build(), "");
        }

        [Test]
        public void InitializationWithMemberByParam()
        {
            MemberAxisItem item = new MemberAxisItem("[Country].Members");

            Assert.AreEqual("[Country].Members", item.Build());
        }

        [Test]
        public void InitializationWithMemberByProperty()
        {
            MemberAxisItem item = new MemberAxisItem();
            item.Member = "[Country].Members";

            Assert.AreEqual("[Country].Members", item.Build());
        }
    }
}
