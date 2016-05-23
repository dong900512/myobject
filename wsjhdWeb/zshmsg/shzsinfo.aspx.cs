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

namespace NewInfoWeb.zshmsg
{
    public partial class shzsinfo : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isexit = "0";
        protected string isks = "0";
        protected int ids = 0;
        protected string tnum = "0";
        protected string tnam = "";
        protected string iscurcj = "0";
        protected string lotNum = "0";
        protected string curtid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // code = "345";
                code = Request.QueryString["code"];
                if (string.IsNullOrEmpty(code))
                {
                    GetCode();
                }
                else
                {
                    //获取opidd
                    //wxopid = "or0ddaAs_FI1HkddouZxdddddM4UMG098obk1";
                    if (string.IsNullOrEmpty(Request.UserAgent) || (!Request.UserAgent.Contains("MicroMessenger") && !Request.UserAgent.Contains("Windows Phone")))
                    {
                        jsHint.toUrl("/index.html");
                    }
                    else
                    {
                        wxopid = GetOpid(code);
                        DateTime t1 = DateTime.Now;
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime10"]);
                        DateTime t3 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime10"]);
                        if (DateTime.Compare(t1, t2) > 0 && DateTime.Compare(t1, t3) < 0)
                        {
                            isks = "1";
                            using (WXDBEntities db = new WXDBEntities())
                            {
                                var model = db.lotterUserInfo.Where(s => s.OpenId.Equals(wxopid) && s.Type.Equals(14)).OrderByDescending(s => s.AddTime).FirstOrDefault();
                                if (model != null)
                                {
                                    isexit = "1";
                                    if (!string.IsNullOrEmpty(model.NickName))
                                    {
                                        curtid = model.Id + "";
                                        iscurcj = "1";
                                        lotNum = model.PriceNumber + "";
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
                var result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["wxappid"], WebConfigurationManager.AppSettings["wxsecret"], cd);

                if (result.errcode != ReturnCode.请求成功)
                {
                    jsHint.toUrl("shzsinfo.aspx");
                }
                else
                {
                    opid = result.openid;
                }
            }
            catch (Exception ex)
            {
                jsHint.toUrl("shzsinfo.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid"], "http://wsjhb.tencenthouse.com/zshmsg/shzsinfo.aspx", "JeffreySu", OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}