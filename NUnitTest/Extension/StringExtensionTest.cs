// ****************************************
// FileName:StringExtensionTest.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/17 17:31:41
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitTest.Extension
{
    /// <summary>
    /// String扩展方法测试类
    /// </summary>
    [TestFixture]
    public class StringExtensionTest
    {
        [Test]
        public void IsNullOrEmptyTest()
        {
            String src = null;
            Assert.IsTrue(src.IsNullOrEmpty() == String.IsNullOrEmpty(src));

            src = "";
            Assert.IsTrue(src.IsNullOrEmpty() == String.IsNullOrEmpty(src));

            src = "abc";
            Assert.IsTrue(src.IsNullOrEmpty() == String.IsNullOrEmpty(src));
        }

        [TestCase("aa", "bb")]
        public void FormatTest(params Object[] args)
        {
            String src = "{0}-{1}";

            Assert.IsTrue(src.FormatEx(args) == String.Format(src, args));
        }

        [Test]
        public void EqualsTest()
        {
            Assert.IsTrue("aa".EqualsEx("aa"));
            Assert.IsTrue("Aa".EqualsEx("aa"));
            Assert.IsTrue(!"Aa".EqualsEx("aa", StringComparison.Ordinal));
        }
    }
}
