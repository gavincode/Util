// ****************************************
// FileName:CodeTimer.cs
// Description:代码运行时间测试类
// Tables:
// Author:Gavin
// Create Date:2015/3/26 11:29:11
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace Util.Code
{
    /// <summary>
    /// 代码运行时间测试类
    /// </summary>
    public static class CodeTimer
    {
        /// <summary>
        /// 初始化(预热)
        /// </summary>
        public static void Initialize()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Time("", 1, () => { });
        }

        /// <summary>
        /// 时间计算
        /// </summary>
        /// <param name="name">测试名</param>
        /// <param name="iteration">迭代次数</param>
        /// <param name="action">执行的方法</param>
        public static void Time(String name, Int32 iteration, Action action)
        {
            if (String.IsNullOrEmpty(name)) return;

            // 1.
            ConsoleColor currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(name);

            // 2.
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Int32[] gcCounts = new Int32[GC.MaxGeneration + 1];
            for (Int32 i = 0; i <= GC.MaxGeneration; i++)
            {
                gcCounts[i] = GC.CollectionCount(i);
            }

            // 3.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            UInt64 cycleCount = GetCycleCount();
            for (Int32 i = 0; i < iteration; i++) action();
            UInt64 cpuCycles = GetCycleCount() - cycleCount;
            watch.Stop();

            // 4.
            Console.ForegroundColor = currentForeColor;
            Console.WriteLine("\tTime Elapsed:\t" + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine("\tCPU Cycles:\t" + cpuCycles);

            // 5.
            for (Int32 i = 0; i <= GC.MaxGeneration; i++)
            {
                Int32 count = GC.CollectionCount(i) - gcCounts[i];
                Console.WriteLine("\tGen " + i + ": \t\t" + count);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 获取当前线程运行周期
        /// </summary>
        /// <returns></returns>
        private static UInt64 GetCycleCount()
        {
            UInt64 cycleCount = 0;
            QueryThreadCycleTime(GetCurrentThread(), ref cycleCount);
            return cycleCount;
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool QueryThreadCycleTime(IntPtr threadHandle, ref UInt64 cycleTime);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentThread();
    }
}