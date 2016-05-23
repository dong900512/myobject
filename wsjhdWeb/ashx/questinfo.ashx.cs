using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXEF;
using WX.Utils;

namespace NewInfoWeb.ashx
{
    /// <summary>
    /// questinfo 的摘要说明
    /// </summary>
    public class questinfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.Cache.SetNoStore();
            //context.Response.Clear();
            var type = context.Request.QueryString["type"];
            //当前用户openid
            //var wxopenid = context.Request.QueryString["useropenid"];
            //var currtitle = context.Request.QueryString["EffectTitle"];
            //context.Response.Write("Hello World");
            switch (type)
            {
                case "addques":
                    AddQues(context);
                    break;
            }
        }
        //新增留言
        public void AddQues(HttpContext context)
        {
            string opid = context.Request.Params["tmpopid"];
            string uname = context.Request.Params["tmpuname"];
            string cot = context.Request.Params["tmpcont"];
            try
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var qumod = new ZxFw();
                    qumod.wxopenid = opid;
                    qumod.Extend1 = uname;
                    qumod.status = 0;
                    qumod.orders = 0;
                    qumod.qucont = Utils.EncodeHtml(cot);
                    qumod.anscont = "";
                    qumod.addtime = DateTime.Now;
                    qumod.updatetime = DateTime.Now;
                    qumod.extend2 = "";
                    qumod.extend3 = "";
                    db.ZxFw.AddObject(qumod);
                    db.SaveChanges();
                    context.Response.Write("1");
                    return;
                }
            }
            catch (Exception)
            {
                context.Response.Write("0");
                return;
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