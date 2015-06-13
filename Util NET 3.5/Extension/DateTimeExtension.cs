// ****************************************
// FileName:DateTimeEx.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/5 16:14:21
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// DateTime扩展类
    /// </summary>
    public static class DateTimeEx
    {
        /// <summary>
        /// 将目标日期转换为'yyyy-MM-dd HH:mm:ss' 或 'yyyy-MM-dd' 格式的字符串
        /// </summary>
        /// <param name="src">源日期</param>
        /// <param name="dateOnly">true:转换为'yyyy-MM-dd'; 默认'yyyy-MM-dd HH:mm:ss'</param>
        /// <returns>格式化字符串</returns>
        public static String ToStringEx(this DateTime src, Boolean dateOnly = false)
        {
            return dateOnly ? src.ToString("yyyy-MM-dd") : src.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}