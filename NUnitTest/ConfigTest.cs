// ****************************************
// FileName:ConfigTest.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/17 14:15:05
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Util.Config;

namespace NUnitTest
{
    /// <summary>
    /// 配置文件读取测试类
    /// </summary>
    [TestFixture]
    public class ConfigTest
    {
        [Test]
        public void Read()
        {
            //AppSetting
            Assert.AreEqual(ConfigUtil.GetAppSetting("BBB"), "ASFQWFASDFSF");

            //ConnectionString
            Assert.AreEqual(ConfigUtil.GetConnectionString("AAA"), "alkhdfqwkhnroifjai");
        }
    }
}
