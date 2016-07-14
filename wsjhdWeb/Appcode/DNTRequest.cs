using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewInfoWeb.Appcode
{
    public class DNTRequest
    {

        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// 获取Request 反回字符串
        /// </summary>
        /// <param name="sParam"></param>
        /// <returns></returns>
        public static string RequstString(string sParam)
        {

            return (HttpContext.Current.Request[sParam] == null || HttpContext.Current.Request[sParam] == "undefined" ? string.Empty : HttpContext.Current.Request[sParam].ToString().Trim());

        }
        /// <summary>
        /// 获取Request 反回数字
        /// </summary>
        /// <param name="sParam"></param>
        /// <returns></returns>
        public static int RequstInt(string sParam)
        {

            return (HttpContext.Current.Request[sParam] == null || HttpContext.Current.Request[sParam] == "undefined" ? 0 : ConvertToTrimInt(HttpContext.Current.Request[sParam].Trim()));

        }
        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string ConvertToTrimString<T>(T source)
        {
            string result = source.ToString();

            if (!String.IsNullOrEmpty(result))
            {
                result = result.Trim();
            }
            return result;
        }
        /// <summary>
        /// 转换成数字
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sParam"></param>
        /// <returns></returns>
        private static int ConvertToTrimInt<T>(T sParam)
        {
            int iValue;

            string sValue = ConvertToTrimString(sParam);

            int.TryParse(sValue, out iValue);

            return iValue;

        }
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        public static string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;

        }


        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }


        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }



        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }


        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }



        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }


        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }


        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }


        public static string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            else
            {
                return GetQueryString(strName);
            }
        }
    }
}