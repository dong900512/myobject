using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP;
using Dos.ORM;
using Dos.Model;
using Dos.Common;
using WX.Utils;
using System.Web.Configuration;
using Senparc.Weixin;
using System.Data;
namespace NewInfoWeb.lnInfo
{
    public partial class lnychindex : System.Web.UI.Page
    {
        protected string tnum = "0";
        protected string code = string.Empty;
        protected string wxopid = string.Empty;
        protected string isx = "0";
        protected string tmpstr = string.Empty;
        protected string ctname = string.Empty;
        protected string ctimgurl = string.Empty;
        protected string stopNum = "0";
        protected string stotal = "0";
        protected string startNum = "0";
        protected string tid = "0";
        protected string strstart = "-1";
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
                    tmpstr = Dos.Common.CookieHelper.Get("curlnQPAes1");
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
                            //wxopid = "o-VTojracv-qDK3toYJR0mIAVltctsndssd";
                            //ctname = "互动点赞";
                            //ctimgurl = "http://wx.qlogo.cn/mmopen/MvRAYAnmInk1nmbAeTtzO9mnw8QJbarxVeVicMKlOiaZfaF1I43MID2oUia6RicibBvTVfHJZcnWNgPq1FtkBuQ4sbGecA6zukloa/0";
                            tmpstr = Common.CryptHelper.DESEncrypt.Encrypt(wxopid, WebConfigurationManager.AppSettings["PassWordKey"]);
                            Dos.Common.CookieHelper.Set("curlnQPAes1", tmpstr, 12600);
                            //Dos.Common.CookieHelper.Set("curXYTid", wxopid, 12600);
                            Dos.Common.CookieHelper.Set("curlnQPName", ctname, 12600);
                            Dos.Common.CookieHelper.Set("curlnQPImgUrl", ctimgurl, 12600);
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
                            jsHint.toUrl("lnychindex.aspx");
                        }
                        else
                        {
                            tnum = DbSession.Default.From<HdPic>().Where(s => s.Extend2.Equals("110")).Count() + "";
                            if (!tnum.Equals("0"))
                            {
                                stopNum = DbSession.Default.FromSql("select row from (select row_number() over (order by orders desc,updatetime asc) row,extend1 from hdpic where Extend2='110') newtable where extend1=@extend1").AddInParameter("@extend1", DbType.String, wxopid).ToScalar() + "";
                            }
                            //SqlSection str = new SqlSection();
                            var model =
                                DbSession.Default.From<Dos.Model.HdPic>()
                                .Where(s => s.Extend1.Equals(wxopid) && s.Extend2.Equals("110")).ToFirstDefault();
                            if (model.Id > 0)
                            {
                                var tmodel = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(wxopid) && s.extend1.Equals("111")).ToFirstDefault();
                                if (tmodel.Id > 0)
                                {
                                    strstart = tmodel.extend2;
                                }
                                tid = model.Id + "";
                                isx = "1";
                                stotal = model.Orders + "";
                                startNum = model.Status + "";
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
                var userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                if (result.errcode != ReturnCode.请求成功)
                {
                    //Response.Redirect("/zpzs/zptinfo.aspx");
                    jsHint.toUrl("lnychindex.aspx");
                }
                else
                {
                    opid = result.openid;
                    ctname = userInfo.nickname;
                    ctimgurl = userInfo.headimgurl;
                }
            }
            catch (Exception ex)
            {
                jsHint.toUrl("lnychindex.aspx");
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode()
        {
            //此页面引导用户点击授权
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid"], "http://wsjhb.tencenthouse.com/lnInfo/lnychindex.aspx", "JeffreySu", OAuthScope.snsapi_userinfo);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}