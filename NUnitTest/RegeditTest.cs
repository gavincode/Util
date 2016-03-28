//***********************************************************************************
// 文件名称：RegeditTest.cs
// 功能描述：
// 数据表：
// 作者：Gavin
// 日期：2016/3/28 14:12:12
// 修改记录：
//***********************************************************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Util.Regedit;

namespace NUnitTest
{
    /// <summary>
    /// 注册表读取测试类
    /// </summary>
    [TestFixture]
    internal class RegeditTest
    {
        [Test]
        public void Read()
        {
            //AppSetting
            RegeditHelper.SetRegistryValue(RegistryRootEnum.LocalMachine, "SOFTWARE\\TEST", "Name", "gavin");

            //ConnectionString
            Assert.AreEqual(RegeditHelper.GetRegistryValue(RegistryRootEnum.LocalMachine, "SOFTWARE\\TEST", "Name"), "gavin");
        }
    }
}
