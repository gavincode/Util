// ****************************************
// FileName:ServiceTest.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/17 18:14:22
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Util.Service;

namespace NUnitTest
{
    /// <summary>
    /// ServiceUtil测试类
    /// </summary>
    [TestFixture]
    public class ServiceTest
    {
        String ServiceExe, ServiceName;

        [SetUp]
        public void Init()
        {
            ServiceExe = AppDomain.CurrentDomain.BaseDirectory + "\\ServiceTest.exe";

            ServiceName = ServiceUtil.GetServiceName(ServiceExe);

            Assert.IsNotNull(ServiceName);
        }

        [Test]
        public void Install()
        {
            ServiceUtil.Install(ServiceExe);
        }
        [Test]
        public void Start()
        {
            ServiceUtil.Start(ServiceExe);
        }
        [Test]
        public void Stop()
        {
            ServiceUtil.Stop(ServiceExe);
        }
        [Test]
        public void UnInstall()
        {
            ServiceUtil.UnInstall(ServiceExe);
        }
    }
}