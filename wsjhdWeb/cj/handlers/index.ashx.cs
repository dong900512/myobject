using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WX.Utils;
using System.Web.Script.Serialization;
namespace TencentHouse.Admin.payment.sdqcl_cj.handlers
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<object> alist = new List<object>();

            FileStream fs = new FileStream(context.Server.MapPath(@"/cj/images/data2.txt"), FileMode.Open);
            StreamReader m_streamReader = new StreamReader(fs);
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string Line = m_streamReader.ReadLine();
            int i = 0;
            while (Line != null && Line != "")
            {
                alist.Add(new
                {
                    st = Line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[1] + Line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[2].Replace(Line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[2].Substring(3, 4), "****") + "|" + Line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[1] + Line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[2]
                });
                Line = m_streamReader.ReadLine();
            }
            string jsonStr = JsonSerialize(alist);
            m_streamReader.Close();
            m_streamReader.Dispose();
            fs.Close();
            fs.Dispose();
            context.Response.Write(jsonStr);
        }
        public string JsonSerialize(object obj)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(obj);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}