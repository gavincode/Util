// ****************************************
// FileName:ConfigUtil.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/5 15:48:58
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace Util.Config
{
    /// <summary>
    /// 配置文件工具类
    /// </summary>
    public class ConfigUtil
    {
        ///<summary>
        ///依据连接串名字connectionName返回数据连接字符串
        ///</summary>
        ///<param name="connectionName">连接名称</param>
        ///<returns>数据连接字符串</returns>
        public static String GetConnectionString(String connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        ///<summary>
        ///更新连接字符串 (*.exe.config)
        ///</summary>
        ///<param name="newName">连接字符串名称</param>
        ///<param name="newConString">连接字符串内容</param>
        ///<param name="newProviderName">数据提供程序名称</param>
        public static void UpdateConnectionStringsConfig(String newName, String newConString, String newProviderName)
        {
            //记录该连接串是否已经存在
            Boolean isModified = ConfigurationManager.ConnectionStrings[newName] != null;

            //新建一个连接字符串实例
            ConnectionStringSettings mySettings = new ConnectionStringSettings(newName, newConString, newProviderName);

            // 打开可执行的配置文件*.exe.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 如果连接串已存在，首先删除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }

            // 将新的连接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);

            // 保存对配置文件所作的更改
            config.Save(ConfigurationSaveMode.Modified);

            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        ///<summary>
        ///返回web.config或＊.exe.config文件中appSettings配置节的value项
        ///</summary>
        ///<param name="keyName">keyName</param>
        ///<exception cref="不存在时会抛出Exception异常">不存在时会抛出异常</exception>
        ///<returns>keyName对应的value值</returns>
        public static String GetAppSetting(String keyName)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(keyName))
            {
                throw new Exception("keyName = {0} 的配置项不存在!".FormatEx(keyName));
            }

            return ConfigurationManager.AppSettings[keyName];
        }

        ///<summary>
        ///在＊.exe.config文件中appSettings配置节更新或增加一对键、值对
        ///</summary>
        ///<param name="newKey">新的key</param>
        ///<param name="newValue">新的value</param>
        public static void UpdateAppSetting(String newKey, String newValue)
        {
            //Check if the key exists
            Boolean isModified = false;
            foreach (String key in ConfigurationManager.AppSettings)
            {
                if (String.Equals(key, newKey, StringComparison.Ordinal))
                {
                    isModified = true;
                }
            }

            // Open App.Config of executable
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // You need to remove the old settings object before you can replace it
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }

            // Add an Application Setting.
            config.AppSettings.Settings.Add(newKey, newValue);

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}