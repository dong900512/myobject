using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXEF;
using WX.Utils;

namespace NewInfoWeb.cj.handlers
{
    /// <summary>
    /// helper 的摘要说明
    /// </summary>
    public class helper : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var type = context.Request.Form["type"];
            switch (type)
            {
                case "t1":
                    GetOInfo(context);
                    break;
                case "t2":
                    GetTInfo(context);
                    break;
                case "t3":
                    GetThInfo(context);
                    break;
                case "rze":
                    QKInfo(context);
                    break;
                default:
                    break;
            }
        }
        private void QKInfo(HttpContext context)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                try
                {
                    var strsql = "update effect set status=0";
                    db.ExecuteStoreCommand(strsql);
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = "", count = 1 });
                    context.Response.Write(jsonstrlist);
                }
                catch (Exception)
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }

            }
        }
        private void GetOInfo(HttpContext context)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var list = db.Effect.Where(s => s.Openid.Equals("0") && s.Status.Equals(0)).FirstOrDefault();
                if (list != null)
                {
                    list.Status = 1;
                    db.SaveChanges();//list.Title +
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = list.Decsription, result = "", count = 1 });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }


            }
        }
        private void GetTInfo(HttpContext context)
        {

            using (WXDBEntities db = new WXDBEntities())
            {
                var list = db.Effect.Where(s => s.Openid.Equals("1") && s.Status.Equals(0)).FirstOrDefault();
                if (list != null)
                {
                    list.Status = 1;
                    db.SaveChanges();
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = list.Decsription, result = "", count = 1 });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }

            }
        }
        private void GetThInfo(HttpContext context)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var list = db.Effect.Where(s => s.Openid.Equals("2") && s.Status.Equals(0)).FirstOrDefault();
                if (list != null)
                {
                    list.Status = 1;
                    db.SaveChanges();
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = list.Decsription, result = "", count = 1 });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }

            }
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