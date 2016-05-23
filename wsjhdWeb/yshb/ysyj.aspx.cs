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
    public partial class ysyj : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isexit = "0";
        protected string iscj = "0";
        protected int ids = 0;
        protected string jpnum = "0";
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
                        jsHint.toUrl("ysyj.aspx");
                    }
                    else
                    {
                        DateTime t1 = DateTime.Now;
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime5"]);
                        DateTime t3 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime5"]);
                        if (DateTime.Compare(t1, t2) > 0 && DateTime.Compare(t1, t3) < 0)
                        {
                            isexit = "1";
                            DateTime now = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                            var tmsg = WebConfigurationManager.AppSettings["sjd5"].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in tmsg)
                            {
                                ids++;
                                DateTime cur = Convert.ToDateTime(item);
                                if (DateTime.Compare(now, cur) == 0)
                                {
                                    iscj = "1";
                                    break;
                                }
                            }
                            if (iscj.Equals("1"))
                            {
                                using (WXDBEntities db = new WXDBEntities())
                                {
                                    var model = db.PicType.Where(s => s.Orders > 0 && s.Extend.Equals("1")).FirstOrDefault();
                                    if (model != null)
                                    {
                                        jpnum = "1";
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
                var result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["wxappid5"], WebConfigurationManager.AppSettings["wxsecret5"], cd);
                //var userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                //var tpuser = UserApi.Info(WXhelper.Instance.CurenTokenByApddidAndAppSec(WebConfigurationManager.AppSettings["wxappid3"], WebConfigurationManager.AppSettings["wxsecret3"]), result.openid);
                if (result.errcode != ReturnCode.请求成功)
                {

                    //Response.Redirect("/zpzs/zptinfo.aspx");
                    jsHint.toUrl("ysyj.aspx");
                }
                else
                {
                    opid = result.openid;
                }
            }
            catch (Exception ex)
            {
                jsHint.toUrl("ysyj.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid5"], "http://wsjhb.tencenthouse.com/yshb/ysyj.aspx", "JeffreySu", OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}