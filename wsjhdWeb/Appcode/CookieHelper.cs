using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewInfoWeb.Appcode
{
    public enum TimeUnit
    {
        Minute, Hour, Day, Month, Year
    }
    public class CookieHelper
    {
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="n">cookie名</param>
        /// <param name="d">保存日期</param>
        /// <param name="l">需要保存的列表的值</param>
        public static void WriteIn(string n, int d, Dictionary<string, string> l)
        {
            HttpCookie cookie = new HttpCookie(n);
            //if (cookie == null)
            //{
            //    cookie = new HttpCookie(n);
            //}
            //new HttpCookie(n);//初使化并设置Cookie的名称
            DateTime dt = DateTime.Now;
            cookie.Expires = DateTime.Now.AddMinutes(30);
            foreach (var item in l)
            {
                cookie.Values.Add(item.Key, item.Value);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
            HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR");

        }
        /// <summary>
        /// 判断cookie 是否为空
        /// </summary>
        /// <param name="n">cookie名</param>
        public static bool ISNull(string n)
        {
            return HttpContext.Current.Request.Cookies[n] != null ? true : false;
        }
        /// <summary>
        /// 判断是否存在值或者值为空
        /// </summary>
        /// <param name="n"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool ISNullCurVal(string n, string v)
        {
            return (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[n][v])) ? true : false;
        }
        /// <summary>
        /// 单个读出
        /// </summary>
        /// <param name="n">cookie名</param>
        /// <param name="v">第X个值</param>
        /// <returns></returns>
        public static string Read(string n, string v)
        {
            return HttpContext.Current.Request.Cookies[n][v];
        }
        /// 修改
        /// </summary>
        /// <param name="n">cookie名</param>
        /// <param name="c">需要修改的索引</param>
        /// <param name="v">需要修改的值</param>
        public static void ReWrite(string n, string c, string v)
        {
            //获取客户端的Cookie对象
            HttpCookie cok = HttpContext.Current.Request.Cookies[n];

            if (cok != null)
            {
                //修改Cookie的两种方法
                //如果userid不存在，修改则无意义
                cok.Values[c] = v;
                //cok.Values.Set("userid", "alter-value");
                HttpContext.Current.Response.AppendCookie(cok);
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="n">cookie名</param>
        /// <param name="c">索引</param>
        /// <param name="v">值</param>
        public static void Add(string n, string c, string v)
        {
            //获取客户端的Cookie对象
            HttpCookie cok = HttpContext.Current.Request.Cookies[n];

            if (cok != null)
            {
                //往Cookie里加入新的内容
                cok.Values.Set(c, v);
                HttpContext.Current.Response.AppendCookie(cok);
            }
        }
        /// <summary>
        /// 去除
        /// </summary>
        /// <param name="n">cookie名</param>
        /// <param name="c">索引</param>
        public static void Remove(string n, string c)
        {
            HttpCookie cok = HttpContext.Current.Request.Cookies[n];
            if (cok != null)
            {
                cok.Values.Remove(c);//移除
                HttpContext.Current.Response.AppendCookie(cok);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="n">cookie名</param>
        public static void Delete(string n)
        {
            HttpCookie cok = HttpContext.Current.Request.Cookies[n];
            if (cok != null)
            {
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
                HttpContext.Current.Response.AppendCookie(cok);
            }
        }
    }
}