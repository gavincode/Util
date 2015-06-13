// ****************************************
// FileName:LogTest.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/17 11:20:10
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Util.Log;

namespace NUnitTest
{
    /// <summary>
    /// Util.Log测试类
    /// </summary>
    [TestFixture]
    public class LogTest
    {
        [TestCase("D:\\")]
        public void SetLogPath(String path)
        {
            LogUtil.SetLogPath(path);

            Assert.AreEqual(path, LogUtil.GetLogPath());
        }

        [TestCase(null)]
        [TestCase("仅供测试")]
        public void WritLog(String message)
        {
            LogUtil.SetLogPath(Environment.CurrentDirectory);

            LogUtil.Write(message, LogType.Debug);

            Assert.AreEqual(LogUtil.LastMessage, message);
        }
    }
}
