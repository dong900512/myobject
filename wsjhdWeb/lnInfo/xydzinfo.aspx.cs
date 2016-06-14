using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP;
using System.Web.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WX.Utils;
using Senparc.Weixin;
using Dos.Common;
using Dos.ORM;
using Dos.Model;
namespace NewInfoWeb.lnInfo
{
    public partial class xydzinfo : System.Web.UI.Page
    {
        protected string stnickname = string.Empty;
        protected string tpid = "0";
        protected string wxopid = string.Empty;
        protected string wxnickname = string.Empty;
        protected string wximgurl = string.Empty;
        protected string code = string.Empty;
        protected string curtid = string.Empty;
        protected string curXYDZAre = string.Empty;
        protected string curXYDZAreTid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.UserAgent) || (!Request.UserAgent.Contains("MicroMessenger") && !Request.UserAgent.Contains("Windows Phone")))
            {
                jsHint.toUrl("/index.html");
            }
            else
            {
                tpid = Request.Params["tid"];
                code = Request.QueryString["code"];
                if (string.IsNullOrEmpty(code))
                {
                    GetCode(tpid);
                }
                else
                {
                    //获取opid
                    //wxopid = "7981";
                    //curtid = "689";
                    wxopid = GetOpid(code);
                    curXYDZAre = Common.CryptHelper.DESEncrypt.Encrypt(wxopid, WebConfigurationManager.AppSettings["PassWordKey"]);
                    curXYDZAreTid = Common.CryptHelper.DESEncrypt.Encrypt(wxopid, WebConfigurationManager.AppSettings["PassWordKey1"]);
                    try
                    {
                        int tmpid = Convert.ToInt32(curtid);
                        var model = DbSession.Default.From<HdPic>().
                            Where(s => s.Id.Equals(tmpid)).ToFirstDefault();
                        if (model.Id > 0)
                        {
                            if (model.Extend1.Equals(wxopid))
                            {
                                jsHint.toUrl("xyindex.aspx");
                            }
                            else
                            {
                                stnickname = model.Name;
                            }
                        }
                        //using (WXDBEntities db = new WXDBEntities())
                        //{
                        //    var model = db.HdPic.Where(s => s.Id.Equals(tmpid)).FirstOrDefault();
                        //    if (model != null)
                        //    {
                        //        nickname = model.Name;
                        //        ords = model.Orders + "";
                        //        if (model.Extend1.Equals(wxopid))
                        //        {
                        //            jsHint.toUrl("xyindex.aspx");
                        //        }
                        //    }
                        //}
                    }
                    catch (Exception ex)
                    {
                        jsHint.toUrl("xyindex.aspx");
                    }
                }
            }
        }
        protected string GetOpid(string cd)
        {
            string opid = string.Empty;
            curtid = Request.Params["state"];
            try
            {
                var result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["wxappid"], WebConfigurationManager.AppSettings["wxsecret"], cd);

                if (result.errcode != ReturnCode.请求成功)
                {
                    jsHint.toUrl("xydzinfo.aspx?tid=" + curtid);
                }
                else
                {
                    opid = result.openid;
                }
            }
            catch (Exception)
            {
                jsHint.toUrl("xydzinfo.aspx?tid=" + curtid);
            }
            return opid;
        }
        /// <summary>
        /// 获取code
        /// </summary>
        protected void GetCode(string tid)
        {
            //此页面引导用户点击授权
            string strurl = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["wxappid"], "http://wsjhb.tencenthouse.com/lnInfo/xydzinfo.aspx", tid, OAuthScope.snsapi_base);
            Response.Redirect(strurl);
            Response.End();
        }
    }
}