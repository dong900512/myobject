using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs.User;
using Senparc.Weixin.MP.CommonAPIs;
using Webdiyer.WebControls.Mvc;
using System.Data.SqlClient;
using Dos.Common;
using Dos.ORM;
using System.Data;
using Dos.Model;
namespace NewInfoWeb.ChinaTele
{
    /// <summary>
    /// helper 的摘要说明
    /// </summary>
    public class helper : IHttpHandler
    {

        protected HttpContext _ct;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _ct = context;
            var type = _ct.Request.Form["type"];
            switch (type)
            {
                case "isexit":
                    YzmIsexit();
                    break;
                case "bcArea":
                    BcAreaInfo();
                    break;
                case "tjwj":
                    WJdc();
                    break;
                case "tjjy":
                    JYInfo();
                    break;
            }
        }

        private void JYInfo()
        {

            try
            {
                var tname = _ct.Request.Form["tname"];
                var tmsg = _ct.Request.Form["tmsg"];

                var model = new Forms();
                model.Attach();
                model.Title = "";
                model.FormType = 0;
                model.Name = tname;
                model.Number = 0;
                model.Mobile = "";
                model.Age = 0;
                model.Source = tmsg;
                model.Income = "";
                model.Remark = "";
                model.AddTime = DateTime.Now;
                model.Status = 0;
                model.Orders = 0;
                model.UpdateTime = DateTime.Now;
                model.Extend = "";
                model.Extend2 = "";
                model.Type = 21;
                model.JFCount = 0;
                int t = DbSession.Default.Insert<Forms>(model);
                _ct.Response.Write("{\"ist\":\"" + 1 + "\"}");
            }
            catch (Exception ex)
            {

                _ct.Response.Write("{\"ismsgs\":\"" + ex.Message + "\",\"ist\":\"" + 0 + "\"}");
            }
        }

        private void WJdc()
        {
            try
            {
                var tname = _ct.Request.Form["tname"];
                var tmsg = _ct.Request.Form["tcod"];
                var tmodel = DbSession.Default.From<Forms>().Where(s => s.Name.Equals(tname)).ToFirstDefault();
                if (tmodel.Id > 0)
                {
                    _ct.Response.Write("{\"ist\":\"" + 1 + "\"}");
                }
                else
                {
                    var model = new Forms();
                    model.Attach();
                    model.Title = "";
                    model.FormType = 0;
                    model.Name = tname;
                    model.Number = 0;
                    model.Mobile = "";
                    model.Age = 0;
                    model.Source = tmsg;
                    model.Income = "";
                    model.Remark = "";
                    model.AddTime = DateTime.Now;
                    model.Status = 0;
                    model.Orders = 0;
                    model.UpdateTime = DateTime.Now;
                    model.Extend = "";
                    model.Extend2 = "";
                    model.Type = 20;
                    model.JFCount = 0;
                    int t = DbSession.Default.Insert<Forms>(model);
                    _ct.Response.Write("{\"ist\":\"" + 1 + "\"}");
                }
            }
            catch (Exception ex)
            {

                _ct.Response.Write("{\"ismsgs\":\"" + ex.Message + "\",\"ist\":\"" + 0 + "\"}");
            }
        }
        /// <summary>
        /// 保存cookie信息
        /// </summary>
        private void BcAreaInfo()
        {
            var tname = _ct.Request.Form["tname"];
            var tcode = _ct.Request.Form["tcode"];
            try
            {
                var tinfo = CookieHelper.Get("curDxTel");
                if (string.IsNullOrEmpty(tinfo))
                {
                    CookieHelper.Set("curDxTel", tname, 129600);
                    CookieHelper.Set("curDxTcode", tcode, 129600);
                }
                _ct.Response.Write("{\"ist\":\"" + 1 + "\"}");
            }
            catch (Exception ex)
            {
                _ct.Response.Write("{\"ismsgs\":\"" + ex.Message + "\",\"ist\":\"" + 0 + "\"}");

            }
        }
        /// <summary>
        /// 判断验证码是否存在
        /// </summary>
        private void YzmIsexit()
        {
            var tyzm = _ct.Request.Form["tyzm"];
            try
            {
                if (string.IsNullOrEmpty(tyzm))
                {
                    _ct.Response.Write("{\"ismsgs\":\"请填写数据信息\",\"ist\":\"" + 1 + "\"}");
                }
                else
                {
                    var tmodel = DbSession.Default.From<BannerInfo>().Where(s => s.Name.Equals(tyzm)).ToFirstDefault();
                    if (tmodel.Id > 0)
                    {
                        _ct.Response.Write("{\"ismsgs\":\"数据存在\",\"ist\":\"" + 2 + "\",\"name\":\"" + tmodel.EName + "\",\"gs\":\"" + tmodel.PicUrl + "\"}");
                    }
                    else
                    {
                        _ct.Response.Write("{\"ismsgs\":\"请输入正确的信息\",\"ist\":\"" + 3 + "\"}");
                    }
                }
            }
            catch (Exception ex)
            {
                _ct.Response.Write("{\"ismsgs\":\"" + ex.Message + "\",\"ist\":\"" + 0 + "\"}");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}