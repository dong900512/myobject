using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System.Web.Configuration;
using Senparc.Weixin;
using WX.Utils;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs.User;
namespace NewInfoWeb.yqh
{
    public partial class hdhsinfo : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isexit = "0";
        protected string wxnickname = string.Empty;
        protected string wxpicurl = string.Empty;
        protected string curtid = "";
        protected string iswxh = "";
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
                        wxopid = GetOpid(code);
                        //wxopid = "1ox6aVwHK4GSsKHzWzLA7_d-6_THA1";
                        //HttpCookie cookie = Request.Cookies["HSGGWebDomain"];
                        //if (cookie == null)
                        //{
                        //    cookie = new HttpCookie("HSGGWebDomain");
                        //}
                        //cookie.Values.Set("useropid", wxopid);
                        ////cookie.Expires = DateTime.Now.AddDays(-1);
                        //cookie.Secure = false;
                        //HttpContext.Current.Response.SetCookie(cookie);
                        //HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR");
                        //wxnickname = "444";
                        //wxpicurl = "http://wx.qlogo.cn/mmopen/PiajxSqBRaEJbKGdHKTbA3POS9tddx7fpDFarw5a2ffxka41e7g5icHE0Vvot3eXMbcFvoo2Jy4FicpenSQIsUTSA/0";
                        using (WXDBEntities db = new WXDBEntities())
                        {
                            var model = db.Forms.Where(s => s.Source.Equals(wxopid) && s.Type == 8).FirstOrDefault();
                            if (model != null)
                            {
                                isexit = "1";
                                curtid = model.Id + "";
                            }
                        }
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
                var tpuser = UserApi.Info(WXhelper.Instance.CurrenToken(), result.openid);
                try
                {
                    iswxh = tpuser.subscribe + "";
                }
                catch (Exception)
                {

                    jsHint.toUrl("hdhsinfo.aspx");
                }

                if (result.errcode != ReturnCode.请求成功)
                {
                    //Response.Redirect("/zpzs/zptinfo.aspx");
                    jsHint.toUrl("hdhsinfo.aspx");
                }
                else
                {
                    opid = result.openid;
                    HttpCookie cookie = Request.Cookies["HSGGWebDomain"];
                    if (cookie == null)
                    {
                        cookie = new HttpCookie("HSGGWebDomain");
                    }
                    cookie.Values.Set("useropid", opid);
                    cookie.Values.Set("iswxh", iswxh);
                    //cookie.Expires = DateTime.Now.AddDays(-1);
                    cookie.Secure = false;
                    HttpContext.Current.Response.SetCookie(cookie);
                    HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR");
                }
            }
            catch (Exception)
            {
                jsHint.toUrl("hdhsinfo.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            //此页面引导用户点击授权
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid"], "http://wsjhb.tencenthouse.com/yqh/hdhsinfo.aspx", "JeffreySu", OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}