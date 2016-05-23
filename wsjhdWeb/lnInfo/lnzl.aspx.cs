using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using System.Web.Configuration;
using Senparc.Weixin;
using WXEF;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP;
using Dos.ORM;
using Dos.Common;
namespace NewInfoWeb.lnInfo
{
    public partial class lnzl : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isx = "0";
        protected string tmpstr = string.Empty;
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
                    tmpstr = Dos.Common.CookieHelper.Get("curLNAes");
                    if (string.IsNullOrEmpty(tmpstr))
                    {
                        //不存在
                        code = Request.QueryString["code"];
                        if (string.IsNullOrEmpty(code))
                        {
                            GetCode();
                        }
                        else
                        {
                            wxopid = GetOpid(code);
                            tmpstr = Common.CryptHelper.DESEncrypt.Encrypt(wxopid, WebConfigurationManager.AppSettings["PassWordKey"]);
                            Dos.Common.CookieHelper.Set("curLNAes", tmpstr, 12600);
                            Dos.Common.CookieHelper.Set("curLNTid", wxopid, 12600);
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
                            jsHint.toUrl("lnzl.aspx");
                        }
                        else
                        {
                            var model =
                                DbSession.Default.From<Dos.Model.HdPic>()
                                .Where(s => s.Extend1.Equals(wxopid) && s.Extend2.Equals("108")).ToFirstDefault();
                            if (model.Id > 0)
                            {
                                isx = "1";
                            }
                        }
                    }
                    catch (Exception)
                    {
                        jsHint.toUrl("/index.html");
                    }
                }
                #region 备注信息
                //code = "789";
                //code = Request.QueryString["code"];
                //if (string.IsNullOrEmpty(code))
                //{
                //    GetCode();
                //}
                //else
                //{
                //    //获取opid
                //    //wxnickname = HttpUtility.UrlEncode("o-VTojracv-qDK3toYJR0mIAVltc");
                //    //wximgurl = "http://wx.qlogo.cn/mmopen/MvRAYAnmInk1nmbAeTtzO9mnw8QJbarxVeVicMKlOiaZfaF1I43MID2oUia6RicibBvTVfHJZcnWNgPq1FtkBuQ4sbGecA6zukloa/0";
                //    ////
                //    if (string.IsNullOrEmpty(Request.UserAgent) || (!Request.UserAgent.Contains("MicroMessenger") && !Request.UserAgent.Contains("Windows Phone")))
                //    {
                //        jsHint.toUrl("/index.html");
                //    }
                //    else
                //    {
                //        //  wxopid = "1d1o-VTojracv-qDK3toYJR0mIAVddltc22323";
                //        wxopid = GetOpid(code);
                //        encode = Common.CryptHelper.DESEncrypt.Encrypt(wxopid, WebConfigurationManager.AppSettings["PassWordKey"]);
                //        using (WXDBEntities db = new WXDBEntities())
                //        {
                //            if (!string.IsNullOrEmpty(wxopid))
                //            {
                //                var model = db.HdPic.Where(s => s.Extend2.Equals("108") && s.Extend1.Equals(wxopid)).FirstOrDefault();
                //                if (model != null)
                //                {
                //                    isx = "1";
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion
            }
        }
        protected string GetOpid(string cd)
        {
            string opid = string.Empty;
            try
            {
                var result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["wxappid1"], WebConfigurationManager.AppSettings["wxsecret1"], cd);
                // var userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                if (result.errcode != ReturnCode.请求成功)
                {
                    //Response.Redirect("/zpzs/zptinfo.aspx");
                    jsHint.toUrl("lnzl.aspx");
                }
                else
                {
                    opid = result.openid;
                }
            }
            catch (Exception ex)
            {
                jsHint.toUrl("lnzl.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            //此页面引导用户点击授权
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid1"], "http://wsjhb.tencenthouse.com/lnInfo/lnzl.aspx", "JeffreySu", OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}