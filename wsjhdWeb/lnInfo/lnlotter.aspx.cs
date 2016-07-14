using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dos.Model;
using Dos.ORM;
using Dos.Common;
using System.Web.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP;
using WX.Utils;
using Senparc.Weixin;

namespace NewInfoWeb.lnInfo
{
    public partial class lnlotter1 : System.Web.UI.Page
    {
        protected string tnum = "0";
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isx = "0";
        protected string tmpstr = string.Empty;
        protected string ispic = "0";
        protected string strstart = "-1";
        protected string jpinfo = "";
        protected string isname = "0";
        protected string isexit = "0";
        protected string jpcode = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.UserAgent) || (!Request.UserAgent.Contains("MicroMessenger") && !Request.UserAgent.Contains("Windows Phone")))
                {
                    jsHint.toUrl("/index.html");
                }
                else
                {
                    tmpstr = Dos.Common.CookieHelper.Get("curlnLotAre");
                    if (string.IsNullOrEmpty(tmpstr))
                    {
                        //不存在
                        //code = "890";
                        code = Request.QueryString["code"];
                        if (string.IsNullOrEmpty(code))
                        {
                            GetCode();
                        }
                        else
                        {
                            wxopid = GetOpid(code);
                            // wxopid = "o-VTojracv-qDK3toYJR0mIAVltctsnddddssdd";
                            //ctname = "互动点赞";
                            //ctimgurl = "http://wx.qlogo.cn/mmopen/MvRAYAnmInk1nmbAeTtzO9mnw8QJbarxVeVicMKlOiaZfaF1I43MID2oUia6RicibBvTVfHJZcnWNgPq1FtkBuQ4sbGecA6zukloa/0";
                            tmpstr = Common.CryptHelper.DESEncrypt.Encrypt(wxopid, WebConfigurationManager.AppSettings["PassWordKey"]);
                            Dos.Common.CookieHelper.Set("curlnLotAre", tmpstr, 12600);
                        }
                    }
                    else
                    {
                        //存在
                        wxopid = Common.CryptHelper.DESEncrypt.Decrypt(tmpstr, WebConfigurationManager.AppSettings["PassWordKey"]);
                        //Dos.Common.CookieHelper.Set("curLNTid", wxopid, 12600);
                    }
                    try
                    {
                        if (string.IsNullOrEmpty(wxopid))
                        {
                            jsHint.toUrl("lnlotter.aspx");
                        }
                        else
                        {
                            DateTime t1 = DateTime.Now;
                            DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime18"]);
                            DateTime t3 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime18"]);
                            if (DateTime.Compare(t1, t2) > 0 && DateTime.Compare(t1, t3) < 0)
                            {
                                ispic = "1";
                                var model = DbSession.Default.From<Forms>().Where(s => s.Source.Equals(wxopid) && s.Status.Equals(1) && s.Type.Equals(95)).ToFirstDefault();
                                if (model.Id > 0)
                                {
                                    if (!string.IsNullOrEmpty(model.Name))
                                    {
                                        isname = "1";
                                    }
                                    isexit = "1";
                                    jpinfo = model.Extend;
                                    jpcode = model.Remark;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        jsHint.toUrl("/index.html");
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
                //var userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                if (result.errcode != ReturnCode.请求成功)
                {
                    //Response.Redirect("/zpzs/zptinfo.aspx");
                    jsHint.toUrl("lnlotter.aspx");
                }
                else
                {
                    opid = result.openid;
                }
            }
            catch (Exception ex)
            {
                jsHint.toUrl("lnlotter.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            //此页面引导用户点击授权
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid"], "http://wsjhb.tencenthouse.com/lnInfo/lnlotter.aspx", "JeffreySu", OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}