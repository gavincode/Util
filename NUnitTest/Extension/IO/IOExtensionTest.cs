// ****************************************
// FileName:IOExtensionTest.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/17 17:57:04
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using System.Reflection;
using System.IO;

namespace NUnitTest.Extension.IO
{
    /// <summary>
    /// IOExtension扩展方法测试类
    /// </summary>
    [TestFixture]
    public class IOExtensionTest
    {
        [Test]
        public void ExsitsEx()
        {
            String file = Assembly.GetExecutingAssembly().Location;
            String path = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;

            var abc = "a".CombineEx("b").CombineEx("c");

            Assert.AreEqual("a\\b\\c", abc);
            Assert.IsTrue(file.ExistsEx());
            Assert.IsTrue(path.ExistsEx());
        }
    }
}
