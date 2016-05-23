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

namespace NewInfoWeb.yshb
{
    public partial class ydhb : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isexit = "0";
        protected string iscj = "0";
        protected int ids = 0;
        protected string jpnum = "0";
        protected string wxnickname = string.Empty;
        protected string wxpicurl = string.Empty;
        protected string curcj = "0";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //code = "345";
                code = Request.QueryString["code"];
                if (string.IsNullOrEmpty(code))
                {
                    GetCode();
                }
                else
                {
                    //获取opid
                    //wxopid = "or0aAs_FI1HkTXouZM4UMG098obk";
                    wxopid = GetOpid(code);
                    if (string.IsNullOrEmpty(Request.UserAgent) || (!Request.UserAgent.Contains("MicroMessenger") && !Request.UserAgent.Contains("Windows Phone")))
                    {
                        jsHint.toUrl("ydhb.aspx");
                    }
                    else
                    {
                        DateTime t1 = DateTime.Now;
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime6"]);
                        DateTime t3 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime6"]);
                        if (DateTime.Compare(t1, t2) > 0 && DateTime.Compare(t1, t3) < 0)
                        {
                            isexit = "1";
                            DateTime now = DateTime.Now;
                            TimeSpan span = now.TimeOfDay;
                            var tmsg = WebConfigurationManager.AppSettings["sjd6"].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in tmsg)
                            {
                                ids++;
                                var tmpinfo = item.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                                TimeSpan begin = new TimeSpan(Convert.ToInt32(tmpinfo[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0]), Convert.ToInt32(tmpinfo[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]), 0);
                                TimeSpan end = new TimeSpan(Convert.ToInt32(tmpinfo[1].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0]), Convert.ToInt32(tmpinfo[1].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]), 0);
                                if ((span >= begin) && (span <= end))
                                {
                                    iscj = "1";
                                    break;
                                }
                            }
                            if (iscj.Equals("1"))
                            {
                                using (WXDBEntities db = new WXDBEntities())
                                {
                                    string ti = ids + "";
                                    var order = db.Oders.Where(s => s.Soucre.Equals(wxopid) && s.Extent1.Equals("61") && s.AddUser.Equals(ti)).FirstOrDefault();
                                    if (order != null)
                                    {
                                        curcj = "1";
                                    }
                                }
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
                var result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["wxappid6"], WebConfigurationManager.AppSettings["wxsecret6"], cd);
                var userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                //var tpuser = UserApi.Info(WXhelper.Instance.CurenTokenByApddidAndAppSec(WebConfigurationManager.AppSettings["wxappid3"], WebConfigurationManager.AppSettings["wxsecret3"]), result.openid);
                if (result.errcode != ReturnCode.请求成功)
                {

                    //Response.Redirect("/zpzs/zptinfo.aspx");
                    jsHint.toUrl("ydhb.aspx");
                }
                else
                {
                    wxnickname = HttpUtility.UrlEncode(userInfo.nickname);
                    wxpicurl = userInfo.headimgurl;
                    opid = result.openid;
                }
            }
            catch (Exception ex)
            {
                jsHint.toUrl("ydhb.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid6"], "http://wsjhb.tencenthouse.com/yshb/ydhb.aspx", "JeffreySu", OAuthScope.snsapi_userinfo);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}