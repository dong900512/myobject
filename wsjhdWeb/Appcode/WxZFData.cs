using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace NewInfoWeb.Appcode
{
    public class WxZFData
    {
        public void SetValue(string key, object value)
        {
            m_values[key] = value;
        }
        /**
       * 根据字段名获取某个字段的值
       * @param key 字段名
        * @return key对应的字段值
       */
        public object GetValue(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            return o;
        }
        /**
        * 判断某个字段是否已设置
        * @param key 字段名
        * @return 若字段key已被设置，则返回true，否则返回false
        */
        public bool IsSet(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            if (null != o)
                return true;
            else
                return false;
        }
        private SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();

        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new Exception("将空的xml串转换为WxPayData不合法!");
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                m_values[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中
            }
            return m_values;
        }
    }
}