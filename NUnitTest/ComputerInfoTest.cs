// ****************************************
// FileName:ComputerInfo.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/5/22 11:39:16
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Util.Computer;

namespace NUnitTest
{
    [TestFixture]
    internal class ComputerInfoTest
    {
        [Test]
        public void Test()
        {
            Console.WriteLine("ComputerName" + ComputerInfo.Instance.ComputerName);
            Console.WriteLine("LoginUserName" + ComputerInfo.Instance.LoginUserName);
            Console.WriteLine("SystemType" + ComputerInfo.Instance.SystemType);
            Console.WriteLine("IpAddress" + ComputerInfo.Instance.IpAddress);
            Console.WriteLine("TotalPhysicalMemory" + ComputerInfo.Instance.TotalPhysicalMemory);
            Console.WriteLine("CpuID" + ComputerInfo.Instance.CpuID);
            Console.WriteLine("DiskID" + ComputerInfo.Instance.DiskID);
            Console.WriteLine("MacAddress" + ComputerInfo.Instance.MacAddress);
        }
    }
}
