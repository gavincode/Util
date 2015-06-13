// ****************************************
// FileName:StringEx.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/5 15:25:30
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// String扩展类
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 判断当前字符串是否为null或空字符串
        /// </summary>
        /// <param name="src">源字符串</param>
        /// <returns>是true;否则false</returns>
        public static Boolean IsNullOrEmpty(this String src)
        {
            return String.IsNullOrEmpty(src);
        }

        /// <summary>
        /// 将参数填充到当前字符串的占位符中
        /// </summary>
        /// <param name="src">源格式字符串</param>
        /// <param name="args">需要填充的参数</param>
        /// <returns>填充后的字符串</returns>
        public static String FormatEx(this String src, params Object[] args)
        {
            return String.Format(src, args);
        }

        /// <summary>
        /// 当前字符串是否等于目标字符串
        /// </summary>
        /// <param name="src">源字符串</param>
        /// <param name="target">比较目标字符串</param>
        /// <param name="comparison">StringComparison默认为OrdinalIgnoreCase</param>
        /// <returns>相等true;否则false</returns>
        public static Boolean EqualsEx(this String src, String target, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return String.Equals(src, target, comparison);
        }
    }
}