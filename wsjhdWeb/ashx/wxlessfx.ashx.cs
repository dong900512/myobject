using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WX.Utils;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.CommonAPIs;
using System.Web.Configuration;

namespace NewInfoWeb.ashx
{
    /// <summary>
    /// wxlessfx 的摘要说明
    /// </summary>
    public class wxlessfx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            var type = context.Request.Params["getsign"];
            switch (type)
            {
                case "WXSign":
                    GetSingInfo(context);
                    break;
                default:
                    break;
            }
        }
        private void GetSingInfo(HttpContext context)
        {
            try
            {
                var list = new List<object>();
                var appid = WebConfigurationManager.AppSettings["wxappid"].ToString();
                var appsecret = WebConfigurationManager.AppSettings["wxsecret"].ToString();
                var timeStamp = JSSDKHelper.GetTimestamp();
                var nonceStr = JSSDKHelper.GetNoncestr();
                var url = context.Request.Params["urlinfo"];
                if (!JsApiTicketContainer.CheckRegistered(appid))
                {
                    JsApiTicketContainer.Register(appid, appsecret);
                }
                string jsapiticket = JsApiTicketContainer.GetTicket(appid);
                JSSDKHelper cd = new JSSDKHelper();
                var signature = cd.GetSignature(jsapiticket, nonceStr, timeStamp, url);
                list.Add(new { appid1 = appid, timeStamp1 = timeStamp, nonceStr1 = nonceStr, signature1 = signature });

                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = list, count = list.Count });
                context.Response.Write(jsonstrlist);
            }
            catch (Exception)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = "", count = 0 });
                context.Response.Write(jsonstrlist);
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