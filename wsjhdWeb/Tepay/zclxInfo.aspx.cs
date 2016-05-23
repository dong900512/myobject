using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP;
using System.Web.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin;
using WX.Utils;
namespace NewInfoWeb.Tepay
{
    public partial class zclxInfo : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.UserAgent) || (!Request.UserAgent.Contains("MicroMessenger") && !Request.UserAgent.Contains("Windows Phone")))
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "非法访问", result = null, count = 2 });
                jsHint.toUrl("/index.html");
            }
            else
            {


                if (!IsPostBack)
                {
                    code = Request.QueryString["code"];
                    //code = "345";
                    if (string.IsNullOrEmpty(code))
                    {
                        GetCode();
                    }
                    else
                    {
                        //获取opid
                        //wxopid = "8890";
                        wxopid = GetOpid(code);
                    }
                }
            }
        }
        protected string GetOpid(string cd)
        {
            string opid = string.Empty;
            try
            {
                var result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["wxappid"], WebConfigurationManager.AppSettings["wxsecret"], cd);

                if (result.errcode != ReturnCode.请求成功)
                {
                    jsHint.toUrl("zclxInfo.aspx");
                }
                else
                {
                    opid = result.openid;
                    HttpCookie cookie = Request.Cookies["ZCWebDomain"];
                    if (cookie == null)
                    {
                        cookie = new HttpCookie("ZCWebDomain");
                    }
                    cookie.Values.Set("useropid", opid);
                    //cookie.Expires = DateTime.Now.AddDays(-1);
                    cookie.Secure = false;
                    HttpContext.Current.Response.SetCookie(cookie);
                    HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR");
                }
            }
            catch (Exception)
            {
                jsHint.toUrl("zclxInfo.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            //此页面引导用户点击授权
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid"], "http://wsjhb.tencenthouse.com/Tepay/zclxInfo.aspx", "JeffreySu", OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}