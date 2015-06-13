// ****************************************
// FileName:IOEx.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/6 9:45:58
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace System.IO
{
    /// <summary>
    /// System.IO扩展类
    /// </summary>
    public static class IOExtension
    {
        /// <summary>
        /// 当前路径字符串对应的文件/文件夹是否存在
        /// </summary>
        /// <param name="src">源字符串</param>
        /// <returns>存在true;否则false</returns>
        public static Boolean ExistsEx(this String src)
        {
            return File.Exists(src) || Directory.Exists(src);
        }

        /// <summary>
        /// 创建路径, 如果不存在
        /// </summary>
        /// <param name="src">源字符串</param>
        public static void CreateDirectoryEx(this String src)
        {
            if (!Directory.Exists(src))
            {
                Directory.CreateDirectory(src);
            }
        }

        /// <summary>
        /// 创建文件, 如果不存在
        /// </summary>
        /// <param name="src">源字符串</param>
        public static void CreateFileEx(this String src)
        {
            if (!File.Exists(src))
            {
                File.Create(src).Close();
            }
        }

        /// <summary>
        /// 合并字符串
        /// </summary>
        /// <param name="src">源字符串</param>
        /// <param name="target">合并目标字符串</param>
        /// <param name="seprarator">分隔符</param>
        /// <returns>合并字符串</returns>
        public static String CombineEx(this String src, String target, String seprarator = "\\")
        {
            return String.Concat(src, seprarator, target);
        }
    }
}
