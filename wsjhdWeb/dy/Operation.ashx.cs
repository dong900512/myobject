using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXEF;
using WX.Utils;

namespace NewInfoWeb.dy
{
    /// <summary>
    /// Operation 的摘要说明
    /// </summary>
    public class Operation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var type = context.Request.Form["type"];
            switch (type)
            {
                case "dz":
                    DZInfo(context);
                    break;
                case "gtlist":
                    GetList(context);
                    break;
            }
        }
        protected void GetList(HttpContext context)
        {
            try
            {

                if (string.IsNullOrEmpty(context.Request.Form["tmpinfo"]))
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "非法访问", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        var list = db.HdPic.Where(s => s.Extend2.Equals("56")).OrderBy(s => s.AddTime).ThenBy(s => s.AddTime);
                        List<object> listDesc = new List<object>();
                        foreach (var item in list)
                        {
                            listDesc.Add(new
                            {
                                id = item.Id,
                                name = item.Name,
                                pic = item.PicUrl,
                                addtime = item.AddTime.ToString("MM月dd日 HH:mm"),
                                orders = item.Orders
                            });
                        }
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                        context.Response.Write(jsonstrlist);
                    }
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = "", count = 0 });
                context.Response.Write(jsonstrlist);
            }
        }
        protected void DZInfo(HttpContext context)
        {
            int tmphid = 0;
            int.TryParse(context.Request.Form["tmpid"], out tmphid);
            string texid = context.Request.Form["tmpext1"];
            int nums1 = 0;
            int ist = 0;
            if (string.IsNullOrEmpty(context.Request.UserAgent) || (!context.Request.UserAgent.Contains("MicroMessenger") && !context.Request.UserAgent.Contains("Windows Phone")))
            //
            {
                context.Response.Write("{\"ismsgs\":\"" + 0 + "\",\"ist\":\"" + 3 + "\"}");
            }
            else
            {
                string tmpopenid = context.Request.Form["tmpopenid"];
                try
                {
                    //UserInfoJson info = UserApi.Info(AccessTokenContainer.TryGetToken(WebConfigurationManager.AppSettings["wxappid1"], WebConfigurationManager.AppSettings["wxsecret1"]), tmpopenid);
                    DateTime t1 = DateTime.Now;
                    DateTime t2 = Convert.ToDateTime("2015-12-28");
                    DateTime t3 = DateTime.Now.Date;
                    DateTime t4 = DateTime.Now.Date.AddDays(1);
                    if (DateTime.Compare(t1, t2) < 0)
                    {
                        if (tmphid > 0)
                        {
                            int idnum = 0;
                            using (WXDBEntities db = new WXDBEntities())
                            {
                                var cont = db.HdPicHit.Where(s => s.wxopenid.Equals(tmpopenid) && s.extend1.Equals(texid) && s.addtime > t3 && s.addtime < t4).Count();
                                if (cont >= 1)
                                {
                                    context.Response.Write("{\"ismsgs\":\"" + 0 + "\",\"ist\":\"" + 0 + "\"}");
                                }
                                else
                                {
                                    if (false)
                                    {

                                    }
                                    else
                                    {
                                        HdPicHit model = new HdPicHit();
                                        model.addtime = DateTime.Now;
                                        model.updatetime = DateTime.Now;
                                        model.extend1 = texid;
                                        model.extend2 = "";
                                        model.orders = 0;
                                        model.status = 0;
                                        model.wxopenid = tmpopenid;
                                        model.name = "";
                                        model.hdpicid = tmphid;
                                        db.HdPicHit.AddObject(model);
                                        HdPic tmodel = db.HdPic.Where(s => s.Id == tmphid).FirstOrDefault();
                                        if (tmodel != null)
                                        {
                                            tmodel.Orders = tmodel.Orders + 1;
                                        }
                                        db.SaveChanges();
                                        nums1 = tmodel.Orders;
                                        ist = 1;
                                    }
                                    idnum = db.HdPicHit.Where(s => s.hdpicid == tmphid && s.extend1.Equals(texid)).Count();
                                    context.Response.Write("{\"ismsgs\":\"" + nums1 + "\",\"ist\":\"" + ist + "\"}");
                                }
                            }
                        }
                        else
                        {
                            context.Response.Write("{\"ismsgs\":\"" + 0 + "\",\"ist\":\"" + 1 + "\"}");
                        }

                    }
                    else
                    {
                        context.Response.Write("{\"ismsgs\":\"" + 0 + "\",\"ist\":\"" + 4 + "\"}");
                    }

                }
                catch (Exception ex)
                {
                    context.Response.Write("{\"ismsgs\":\"" + ex.Message + "\",\"ist\":\"" + 5 + "\"}");
                }
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