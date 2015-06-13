// ****************************************
// FileName:LogUtil.cs
// Description:日志助手类
// Tables:Nothing
// Author:Gavin
// Create Date:2015-3-17 11:42:06
// Revision History:
// ****************************************

using System;
using System.IO;
using System.Collections.Generic;

namespace Util.Log
{
    /// <summary>
    /// 日志助手类
    /// </summary>
    public static class LogUtil
    {
        //定义锁变量
        private static readonly Object lockObj = new Object();

        //分隔符
        const String SPLITER = "\r\n------------------------------------------------------------\r\n";

        //定义日志文件存放的路径
        private static String LogPath { get; set; }

        //上一次成功写入的信息
        public static String LastMessage { get; private set; }

        /// <summary>
        /// 获取日志文件存放的路径
        /// </summary>
        /// <returns>日志文件存放的路径</returns>
        public static String GetLogPath()
        {
            return LogPath;
        }

        /// <summary>
        /// 设置日志文件存放的路径
        /// </summary>
        /// <param name="logPath">日志文件存放的路径</param>
        public static void SetLogPath(String logPath)
        {
            LogPath = logPath;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="logType">日志类型</param>
        /// <param name="ifIncludeHour">是否包含小时</param>
        public static void Write(String msg, LogType logType, Boolean ifIncludeHour = true)
        {
            if (String.IsNullOrEmpty(LogPath))
                throw new ArgumentNullException("LogPath", "Please set the logPath First.");

            String backupMsg = msg;
            DateTime dtNow = DateTime.Now;

            //构造文件路径和文件名
            String filePath = String.Format("{0}\\{1}\\{2}", LogPath, dtNow.Year, dtNow.Month);
            String fileName;
            if (ifIncludeHour)
            {
                fileName = String.Format("{0}-{1}.{2}.{3}", dtNow.ToStringEx(true), dtNow.Hour, Enum.GetName(typeof(LogType), logType), "txt");
            }
            else
            {
                fileName = String.Format("{0}.{1}.{2}", dtNow.ToStringEx(true), Enum.GetName(typeof(LogType), logType), "txt");
            }

            //独占方式，因为文件只能由一个进程写入
            try
            {
                lock (lockObj)
                {
                    msg = "[{0}] {1}{2}".FormatEx(dtNow.ToStringEx(), msg, SPLITER);

                    //Create Directory if Not Exist
                    filePath.CreateDirectoryEx();

                    File.AppendAllText("{0}\\{1}".FormatEx(filePath, fileName), msg);

                    LastMessage = backupMsg;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}