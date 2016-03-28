//***********************************************************************************
// 文件名称：RegeditHelper.cs
// 功能描述：注册表读写帮助类
// 数据表：
// 作者：Gavin
// 日期：2016/3/28 11:27:58
// 修改记录：
//***********************************************************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Util.Regedit
{
    /// <summary>
    /// 注册表读写帮助类
    /// </summary>
    public class RegeditHelper
    {
        /// <summary>
        /// 读取指定名称的注册表的值
        /// </summary>
        /// <param name="root">注册表根目录</param>
        /// <param name="subkey">子路径(如: 'SOFTWARE\\Micosoft')</param>
        /// <param name="name">注册项名称</param>
        /// <returns>指定注册表项的值, 不存在则返回""</returns>
        public static string GetRegistryValue(RegistryRootEnum rootEnum, string subkey, string name)
        {
            string registData = "";
            RegistryKey myKey = GetRegistryRoot(rootEnum).OpenSubKey(subkey, true);
            if (myKey != null)
            {
                registData = myKey.GetValue(name).ToString();
            }

            return registData;
        }

        /// <summary>
        /// 向注册表中写数据
        /// </summary>
        /// <param name="root">注册表根目录</param>
        /// <param name="subkey">子路径(如: 'SOFTWARE\\Micosoft')</param>
        /// <param name="name">注册项名称</param>
        /// <param name="value">设定值</param>
        public static void SetRegistryValue(RegistryRootEnum rootEnum, string subkey, string name, string value)
        {
            RegistryKey aimdir = GetRegistryRoot(rootEnum).CreateSubKey(subkey);
            aimdir.SetValue(name, value);
        }

        /// <summary>
        /// 删除注册表中指定的注册表项
        /// </summary>
        /// <param name="root">注册表根目录</param>
        /// <param name="subkey">子路径(如: 'SOFTWARE\\Micosoft')</param>
        /// <param name="name">注册项名称</param>
        public static void DeleteRegist(RegistryRootEnum rootEnum, string subkey, string name)
        {
            string[] subkeyNames;
            RegistryKey myKey = GetRegistryRoot(rootEnum).OpenSubKey(subkey, true);
            subkeyNames = myKey.GetSubKeyNames();
            foreach (string aimKey in subkeyNames)
            {
                if (aimKey == name)
                    myKey.DeleteSubKeyTree(name);
            }
        }

        /// <summary>
        /// 判断指定注册表项是否存在
        /// </summary>
        /// <param name="root">注册表根目录</param>
        /// <param name="subkey">子路径(如: 'SOFTWARE\\Micosoft')</param>
        /// <param name="name">注册项名称</param>
        /// <returns>指定注册表项是否存在</returns>
        public static bool IsRegistryExist(RegistryRootEnum rootEnum, string subkey, string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            RegistryKey myKey = GetRegistryRoot(rootEnum).OpenSubKey(subkey, true);
            subkeyNames = myKey.GetSubKeyNames();
            foreach (string keyName in subkeyNames)
            {
                if (keyName == name)
                {
                    _exit = true;
                    break;
                }
            }

            return _exit;
        }

        /// <summary>
        /// 获取枚举对应注册键对象
        /// </summary>
        /// <param name="rootEnum">RegistryRootEnum</param>
        /// <returns>对应注册键对象</returns>
        private static RegistryKey GetRegistryRoot(RegistryRootEnum rootEnum)
        {
            switch (rootEnum)
            {
                case RegistryRootEnum.Users:
                    return Registry.Users;

                case RegistryRootEnum.CurrentUser:
                    return Registry.CurrentUser;

                case RegistryRootEnum.ClassesRoot:
                    return Registry.ClassesRoot;

                case RegistryRootEnum.LocalMachine:
                    return Registry.LocalMachine;

                default:
                    return Registry.Users;
            }
        }
    }

    /// <summary>
    /// 注册表更目录枚举
    /// </summary>
    public enum RegistryRootEnum
    {
        Users,

        CurrentUser,

        ClassesRoot,

        LocalMachine,
    }
}
