#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Enterprise Edition/Microsoft.Common
// File:  ConfigFileHandler.cs 
// Date: 2014/07/14 0:40
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
namespace EnterpriseSolutionBIDesktop
{
    using System;
    using System.IO;
    using System.Xml;

    public sealed class ConfigFileHandler
    {
        private XmlDocument _configDocument;
        private string _configFilePath;
        //private RijndaelCryptionHelper _rijndaelCryption;
        private string _rootPath;

        public ConfigFileHandler()
        {
            this._configFilePath = string.Empty;
            this._rootPath = string.Empty;
            //this._rijndaelCryption = Shared.GetCryptionHelper();
        }

        public ConfigFileHandler(string filename, string rootPath)
        {
            this._configFilePath = string.Empty;
            this._rootPath = string.Empty;
            //this._rijndaelCryption = Shared.GetCryptionHelper();
            this._rootPath = rootPath;
            this.Load(filename);
        }

        public string GetEncryptValue(string key)
        {
            return this.GetValue(key, true);
        }

        public bool GetEncrpytBoolValue(string key, bool? defaultValue = new bool?())
        {
            bool flag = !defaultValue.HasValue;
            bool flag2 = false;
            string str = this.GetValue(key, true);
            if (!string.IsNullOrWhiteSpace(str))
            {
                return Convert.ToBoolean(str);
            }
            if (defaultValue.HasValue)
            {
                flag2 = defaultValue.Value;
            }
            return flag2;
        }

        public string GetEncryptValue(string key, string defaultValue = null)
        {
            bool flag = defaultValue == null;
            string str = string.Empty;
            string str2 = this.GetValue(key, true);
            if (!string.IsNullOrWhiteSpace(str2))
            {
                return str2;
            }
            if (defaultValue != null)
            {
                str = defaultValue;
            }
            return str;
        }

        public string GetValue(string key)
        {
            return this.GetValue(key, false);
        }

        public string GetValue(string key,string defaultValue)
        {
            string result=this.GetValue(key, false);
            return string.IsNullOrEmpty(result) ? defaultValue : result;
        }

        private string GetValue(string key, bool encrypted)
        {
            if (this._configDocument == null)
            {
                throw new AppException("Config file is not loaded");
            }
            string xpath = string.Format("{0}/setting[@name='{1}']", this._rootPath, key);
            XmlNodeList list = this._configDocument.SelectNodes(xpath);
            if (list.Count == 0)
            {
                throw new AppException(string.Format("Key [{0}] not found", key));
            }
            System.Xml.XmlNode node = list[0];
            foreach (System.Xml.XmlNode node2 in node.ChildNodes)
            {
                if (node2.Name == "value")
                {
                    if (encrypted)
                    {
                      //  return this._rijndaelCryption.DecryptString(node2.InnerText);
                    }
                    return node2.InnerText;
                }
            }
            return string.Empty;
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new AppException(string.Format("System file not found: {0}", filename));
            }
            this._configFilePath = filename;
            this._configDocument = new XmlDocument();
            this._configDocument.PreserveWhitespace = true;
            this._configDocument.Load(this._configFilePath);
        }

        public void Save()
        {
            if (this._configDocument == null)
            {
                throw new AppException("Config file is not loaded");
            }
            this._configDocument.Save(this._configFilePath);
        }

        public void SetEncryptValue(string key, string value)
        {
            this.SetValue(key, value, true);
        }

        public void SetValue(string key, string value)
        {
            this.SetValue(key, value, false);
        }

        private void SetValue(string key, string value, bool encrypted)
        {
            if (this._configDocument == null)
            {
                throw new AppException("Config file is not loaded");
            }
            string xpath = string.Format("{0}/setting[@name='{1}']", this._rootPath, key);
            XmlNodeList list = this._configDocument.SelectNodes(xpath);
            if (list.Count == 0)
            {
                throw new AppException(string.Format("Key [{0}] not found", key));
            }
            System.Xml.XmlNode node = list[0];
            foreach (System.Xml.XmlNode node2 in node.ChildNodes)
            {
                if (node2.Name == "value")
                {
                    if (encrypted)
                    {
                       // node2.InnerText = this._rijndaelCryption.EncryptString(value);
                    }
                    else
                    {
                        node2.InnerText = value;
                    }
                    break;
                }
            }
        }

        public int GetIntValue(string key, int? defaultValue = new int?())
        {
            bool flag = !defaultValue.HasValue;
            int num = 0;
            string str = this.GetValue(key, false);
            if (!string.IsNullOrWhiteSpace(str))
            {
                return Convert.ToInt32(str);
            }
            if (defaultValue.HasValue)
            {
                num = defaultValue.Value;
            }
            return num;
        }

        public bool GetBoolValue(string key, bool? defaultValue = new bool?())
        {
            bool flag = !defaultValue.HasValue;
            bool flag2 = false;
            string str = this.GetValue(key, false);
            if (!string.IsNullOrWhiteSpace(str))
            {
                return Convert.ToBoolean(str);
            }
            if (defaultValue.HasValue)
            {
                flag2 = defaultValue.Value;
            }
            return flag2;
        }
    }
}

