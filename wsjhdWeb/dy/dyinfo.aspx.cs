using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System.Web.Configuration;
using Senparc.Weixin;
using WX.Utils;
using Senparc.Weixin.MP;
using WXEF;
using Senparc.Weixin.MP.AdvancedAPIs.User;
namespace NewInfoWeb.dy
{
    public partial class dyinfo : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isexit = "0";
        protected string wxnickname = string.Empty;
        protected string wxpicurl = string.Empty;
        protected string curtid = "";
        protected string ispic = "0";
        protected string tmpid = "0";
        protected string imgurl = "";
        protected string zpnum = "";
        protected string isgz = "0";
        protected bool ist1 = false;
        protected void Page_Load(object sender, EventArgs e)
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
                    wxopid = GetOpid(code);
                    if (string.IsNullOrEmpty(Request.UserAgent) || (!Request.UserAgent.Contains("MicroMessenger") && !Request.UserAgent.Contains("Windows Phone")))
                    {
                        jsHint.toUrl("dyinfo.aspx");
                    }
                    //wxopid = "or0aAs_FI1HkTXouZM4UMG098obk";
                }
            }
        }
        protected string GetOpid(string cd)
        {
            string opid = string.Empty;
            try
            {
                var result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["wxappid"], WebConfigurationManager.AppSettings["wxsecret"], cd);
                //var userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                //var tpuser = UserApi.Info(WXhelper.Instance.CurenTokenByApddidAndAppSec(WebConfigurationManager.AppSettings["wxappid3"], WebConfigurationManager.AppSettings["wxsecret3"]), result.openid);
                if (result.errcode != ReturnCode.请求成功)
                {
                    //Response.Redirect("/zpzs/zptinfo.aspx");
                    jsHint.toUrl("dyinfo.aspx");
                }
                else
                {
                    opid = result.openid;
                    //HttpCookie cookie = Request.Cookies["xdTPinfo"];
                    //if (cookie == null)
                    //{
                    //    cookie = new HttpCookie("xdTPinfo");
                    //}
                    //isgz = tpuser.subscribe + "";
                    //cookie.Values.Set("isgz", tpuser.subscribe + "");
                    //cookie.Values.Set("useropid", opid);
                    ////cookie.Expires = DateTime.Now.AddDays(-1);
                    //cookie.Secure = false;
                    //HttpContext.Current.Response.SetCookie(cookie);
                    //HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR");
                    //wxnickname = HttpUtility.UrlEncode(userInfo.nickname);
                    //wxpicurl = userInfo.headimgurl;
                }

            }
            catch (Exception ex)
            {
                jsHint.toUrl("dyinfo.aspx");
                //jsHint.Alert(ex.Message);
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            //此页面引导用户点击授权
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid"], "http://wsjhb.tencenthouse.com/dy/dyinfo.aspx", "JeffreySu", OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}