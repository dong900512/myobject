using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXEF;
using WX.Utils;
using System.IO;
using System.Web.SessionState;

namespace NewInfoWeb.ashx
{
    /// <summary>
    /// newsInfo 的摘要说明
    /// </summary>
    public class newsInfo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.Cache.SetNoStore();
            //context.Response.Clear();
            var type = context.Request.QueryString["type"];
            //当前用户openid
            var wxopenid = context.Request.QueryString["useropenid"];
            var currtitle = context.Request.QueryString["EffectTitle"];
            switch (type)
            {
                case "impressType":
                    AddEffect(wxopenid, currtitle, context);
                    break;
                case "imgpicleft":
                    GetPicwal(context);
                    break;
                case "imgpicright":
                    GetPicwalright(context);
                    break;
                case "newsleft":
                    GetNewsLeft(context);
                    break;
                case "newsright":
                    GetNewsRight(context);
                    break;
                case "jindu":
                    GetJinDu(context);
                    break;
                case "jinduinfo":
                    GetJinduInfo(context);
                    break;
                case "hdinfo":
                    GetHDInfo(context);
                    break;
                case "hqNewsInfo":
                    GetNewsInfo(context);
                    break;
                case "qd":
                    Addqd(context);
                    break;
                case "jft":
                    GetJft(context);
                    break;
                case "isqd":
                    IsQd(context);
                    break;
                case "jixq":
                    jfxq(context);
                    break;
                case "AddKFinfo":
                    AddKFinfo(context);
                    break;
            }
        }
        /// <summary>
        /// 预约看房信息
        /// </summary>
        /// <param name="context"></param>
        protected void AddKFinfo(HttpContext context)
        {
            try
            {
                var name = context.Request.Params["tname"];
                var phone = context.Request.Params["tphone"];
                var sex = context.Request.Params["sex"];
                var year = context.Request.Params["year"];
                var mon = context.Request.Params["mon"];
                var dd = context.Request.Params["day"];
                var yxfx = context.Request.Params["fx"];
                var hztj = context.Request.Params["tj"];
                var lfqy = context.Request.Params["qy"];
                using (WXDBEntities db = new WXDBEntities())
                {
                    Forms model = new Forms();
                    model.Name = name;
                    model.Number = 0;
                    model.Mobile = phone;
                    model.Age = 0;
                    model.Source = hztj;
                    model.Income = yxfx;
                    model.AddTime = Convert.ToDateTime(year + "-" + mon + "-" + dd);
                    model.UpdateTime = DateTime.Now;
                    model.Status = 0;
                    model.Orders = 0;
                    model.Extend = lfqy;
                    model.Extend2 = sex;
                    model.JFCount = 0;
                    //看房预约
                    model.Type = 15;
                    model.Title = year + "年" + mon + "月" + dd + "日";
                    db.Forms.AddObject(model);
                    db.SaveChanges();
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = null, count = 1 });
                    context.Response.Write(jsonstrlist);
                }
            }
            catch (Exception)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = null, count = 0 });
                context.Response.Write(jsonstrlist);
            }
        }
        protected void jfxq(HttpContext context)
        {
            int page = 0;
            int pagesize = 20;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;

            var tmpopid = context.Request.Params["tmpid"];
            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;
                var newslit = db.UserPoinLog.Where(s => s.WxOpenid == tmpopid).OrderBy(s => s.Orders).ThenByDescending(s => s.AddTime).Skip(skipsize).Take(pagesize).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            time = item.AddTime.ToString("yyyy-MM-dd"),
                            dec = item.PointCode == 1 ? "注册会员" : (item.PointCode == 2 ? "已签到" : (item.PointCode == 3 ? "抽奖消费积分" : (item.PointCode == 6 ? "抽奖赠送积分" : (item.PointCode == 4 ? "连续签到送积分" : (item.PointCode == 7 ? "兑换优惠券消费" : "消费积分"))))),
                            jf = (item.PointCode == 3 || item.PointCode == 7) ? item.Extent1 : "+" + item.Extent1
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }
        protected void IsQd(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpid"];
            using (WXDBEntities db = new WXDBEntities())
            {
                UserPoinLog tmodel = db.UserPoinLog.Where(s => s.WxOpenid == tmpopid && s.PointCode == 2).OrderByDescending(s => s.AddTime).FirstOrDefault();
                if (tmodel != null)
                {

                    if (tmodel.AddTime.Date == DateTime.Now.Date)
                    {
                        context.Response.Write("{\"flag\":\"0\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"flag\":\"002\"}");
                    }
                }
                else
                {
                    context.Response.Write("{\"flag\":\"002\"}");
                }
            }
        }

        protected void GetJft(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpid"];
            using (WXDBEntities db = new WXDBEntities())
            {
                try
                {
                    var count = db.Forms.Where(s => s.Source == tmpopid && s.Type == 6).FirstOrDefault();
                    if (count != null)
                    {
                        context.Response.Write("{\"flag\":\"" + count.JFCount + "\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"flag\":\"" + 0 + "\"}");
                    }

                }
                catch (Exception)
                {

                    context.Response.Write("{\"flag\":\"0\"}");
                }

            }
        }
        protected string GetJFAdd(string Level)
        {
            if (Level.Equals(WebConn.MembersLevel.PT.ToString()))
            {
                return "1";
            }
            else if (Level.Equals(WebConn.MembersLevel.YK.ToString()))
            {
                return "1.5";
            }
            else if (Level.Equals(WebConn.MembersLevel.JK.ToString()))
            {
                return "2";
            }
            else if (Level.Equals(WebConn.MembersLevel.BJ.ToString()))
            {
                return "3";
            }
            else
            {
                return "0";
            }

        }
        protected void Addqd(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpid"];
            using (WXDBEntities db = new WXDBEntities())
            {
                UserPoinLog tmodel = db.UserPoinLog.Where(s => s.WxOpenid == tmpopid && s.PointCode == 2).OrderByDescending(s => s.AddTime).FirstOrDefault();
                try
                {
                    //lotterUserInfo lt = db.lotterUserInfo.Where(s => s.OpenId == tmpopid).FirstOrDefault();
                    Forms formodel = db.Forms.Where(s => s.Type == 6).Where(s => s.Source == tmpopid).FirstOrDefault();

                    if (tmodel != null)
                    {
                        if (tmodel.AddTime.Date == DateTime.Now.Date)
                        {
                            context.Response.Write("{\"flag\":\"002\"}");
                        }
                        else
                        {
                            if (formodel != null)
                            {
                                UserPoinLog ml = new UserPoinLog()
                                {
                                    UserPointDesc = "签到送积分",
                                    WxOpenid = tmpopid,
                                    WxNickName = "",
                                    PointCode = 2,//签到送积分
                                    AddTime = DateTime.Now,
                                    Updatetime = DateTime.Now,
                                    Status = 0,
                                    Orders = 0,
                                    Extent1 = GetJFAdd(formodel.Extend2),
                                    Extent2 = "",
                                    Extent3 = ""
                                };
                                Signtable sl = db.Signtable.Where(s => s.wxopenid == tmpopid).FirstOrDefault();
                                if (sl != null)
                                {
                                    if (DateTime.Now.AddDays(-1).Date == sl.PrevLoginDate.Date)
                                    {
                                        sl.LCount = sl.LCount + 1;
                                    }
                                    else
                                    {
                                        sl.LCount = 1;
                                    }
                                    formodel.JFCount += Convert.ToDouble(GetJFAdd(formodel.Extend2));
                                    db.UserPoinLog.AddObject(ml);
                                    db.SaveChanges();
                                    if (sl.LCount >= 7)
                                    {
                                        sl.LCount = 1;

                                        UserPoinLog ml2 = new UserPoinLog()
                                        {
                                            UserPointDesc = "连续签到送积分",
                                            WxOpenid = tmpopid,
                                            WxNickName = "",
                                            PointCode = 4,//连续签到送积分
                                            AddTime = DateTime.Now,
                                            Updatetime = DateTime.Now,
                                            Status = 0,
                                            Orders = 0,
                                            Extent1 = "10",
                                            Extent2 = "",
                                            Extent3 = ""
                                        };
                                        formodel.JFCount += 10;
                                        db.UserPoinLog.AddObject(ml2);
                                    }
                                }
                                else
                                {
                                    sl = new Signtable()
                                    {
                                        wxopenid = tmpopid,
                                        LCount = 1,
                                        PrevLoginDate = DateTime.Now,
                                        AddTime = DateTime.Now,
                                        Extent1 = "",
                                        Extent2 = ""
                                    };
                                    db.Signtable.AddObject(sl);
                                }
                                db.SaveChanges();
                            }
                            else
                            {
                                formodel = new Forms();
                                formodel.Name = "";
                                formodel.Number = 0;
                                formodel.Mobile = "";
                                formodel.Age = 0;
                                formodel.Source = tmpopid;
                                formodel.Income = "";
                                formodel.AddTime = DateTime.Now;
                                formodel.UpdateTime = DateTime.Now;
                                formodel.Remark = "";
                                formodel.Status = 0;
                                formodel.Orders = 0;
                                formodel.FormType = 0;
                                formodel.Extend = "";
                                formodel.Extend2 = WebConn.MembersLevel.PT.ToString();
                                //会员信息
                                formodel.Type = 6;
                                formodel.Title = "";
                                formodel.JFCount = 0;
                                UserPoinLog ml = new UserPoinLog()
                                {
                                    UserPointDesc = "签到送积分",
                                    WxOpenid = tmpopid,
                                    WxNickName = "",
                                    PointCode = 2,//签到送积分
                                    AddTime = DateTime.Now,
                                    Updatetime = DateTime.Now,
                                    Status = 0,
                                    Orders = 0,
                                    Extent1 = "1",
                                    Extent2 = "",
                                    Extent3 = ""
                                };
                                Signtable sl = db.Signtable.Where(s => s.wxopenid == tmpopid).FirstOrDefault();
                                if (DateTime.Now.AddDays(-1).Date == sl.PrevLoginDate.Date)
                                {
                                    sl.LCount = sl.LCount + 1;
                                }
                                else
                                {
                                    sl.LCount = 1;
                                }
                                db.Forms.AddObject(formodel);
                                db.UserPoinLog.AddObject(ml);
                                db.SaveChanges();
                            }
                            context.Response.Write("{\"flag\":\"001\"}");
                        }
                    }
                    else
                    {
                        if (formodel != null)
                        {
                            UserPoinLog ml = new UserPoinLog()
                            {
                                UserPointDesc = "签到送积分",
                                WxOpenid = tmpopid,
                                WxNickName = "",
                                PointCode = 2,//签到送积分
                                AddTime = DateTime.Now,
                                Updatetime = DateTime.Now,
                                Status = 0,
                                Orders = 0,
                                Extent1 = GetJFAdd(formodel.Extend2),
                                Extent2 = "",
                                Extent3 = ""
                            };
                            formodel.JFCount += Convert.ToDouble(GetJFAdd(formodel.Extend2));
                            Signtable sl = new Signtable()
                            {
                                wxopenid = tmpopid,
                                LCount = 1,
                                PrevLoginDate = DateTime.Now,
                                AddTime = DateTime.Now,
                                Extent1 = "",
                                Extent2 = ""
                            };
                            db.Signtable.AddObject(sl);
                            db.UserPoinLog.AddObject(ml);
                            db.SaveChanges();
                        }
                        else
                        {
                            formodel = new Forms();
                            formodel.Name = "";
                            formodel.Number = 0;
                            formodel.Mobile = "";
                            formodel.Age = 0;
                            formodel.Source = tmpopid;
                            formodel.Income = "";
                            formodel.AddTime = DateTime.Now;
                            formodel.UpdateTime = DateTime.Now;
                            formodel.Remark = "";
                            formodel.Status = 0;
                            formodel.Orders = 0;
                            formodel.FormType = 0;
                            formodel.Extend = "";
                            formodel.Extend2 = WebConn.MembersLevel.PT.ToString();
                            //会员信息
                            formodel.Type = 6;
                            formodel.Title = "";
                            formodel.JFCount = 1;
                            UserPoinLog ml = new UserPoinLog()
                            {
                                UserPointDesc = "签到送积分",
                                WxOpenid = tmpopid,
                                WxNickName = "",
                                PointCode = 2,//签到送积分
                                AddTime = DateTime.Now,
                                Updatetime = DateTime.Now,
                                Status = 0,
                                Orders = 0,
                                Extent1 = "1",
                                Extent2 = "",
                                Extent3 = ""
                            };
                            Signtable sl = new Signtable()
                            {
                                wxopenid = tmpopid,
                                LCount = 1,
                                PrevLoginDate = DateTime.Now,
                                AddTime = DateTime.Now,
                                Extent1 = "",
                                Extent2 = ""
                            };
                            db.Signtable.AddObject(sl);
                            db.Forms.AddObject(formodel);
                            db.UserPoinLog.AddObject(ml);
                            db.SaveChanges();
                        }
                        context.Response.Write("{\"flag\":\"001\"}");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        protected void GetNewsInfo(HttpContext context)
        {
            int page = 0;
            int type = 0;
            int pagesize = 3;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;
            int.TryParse(context.Request.Params["tmptype"], out type);
            int.TryParse(context.Request.Params["pagesize"], out pagesize);
            var status = Convert.ToInt32(context.Request.Params["status"]);
            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;
                var newslit = db.Article.Where(s => s.Type == type && s.Status == status).OrderBy(s => s.Orders).ThenByDescending(s => s.UpdateTime).Skip(skipsize).Take(pagesize).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            id = item.AritcleID,
                            title = item.Title,
                            addtime = item.AddTime.ToString("yyyy.MM.dd"),
                            cont = item.Description.Length > 50 ? item.Contents.Substring(0, 50) +"...": item.Description 
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }

        protected void GetHDInfo(HttpContext context)
        {
            int page = 0;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;
            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * 8;
                var newslit = db.Activity.Where(s => s.Type == 0).OrderBy(s => s.Orders).ThenByDescending(s => s.UpdateTime).Skip(skipsize).Take(8).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            id = item.ID,
                            title = item.Title,
                            desc = item.Description,
                            time = item.StartTime.ToString("yyyy.MM.dd") + "-" + item.EndTime.ToString("yyyy.MM.dd"),
                            status = item.Status
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }
        protected void GetJinduInfo(HttpContext context)
        {

            int page = 0;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;
            using (WXDBEntities db = new WXDBEntities())
            {
                //var list = new List<Instagram>();
                int skipsize = page * 6;
                var newslit = db.TuInfo.Where(s => s.extend3 == "2").Where(s => s.status == 0).OrderBy(s => s.orders).ThenByDescending(s => s.updatetime).Skip(skipsize).Take(6).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            title = item.name,
                            addtime = item.addtime.ToString("yyyy年MM月dd日"),
                            cont = item.extend2,
                            pic = item.varurl,
                            id = item.Id
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }

        }
        protected void GetJinDu(HttpContext context)
        {

            int page = 0;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;
            using (WXDBEntities db = new WXDBEntities())
            {
                //var list = new List<Instagram>();
                int skipsize = page * 2;
                var newslit = db.TuInfo.Where(s => s.status == 0 && s.extend3 == "2").OrderBy(s => s.orders).ThenByDescending(s => s.addtime).Skip(skipsize).Take(2).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            title = item.name,
                            name = item.varurl
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }
        //左侧文章
        protected void GetNewsLeft(HttpContext context)
        {
            int page = 0;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;
            using (WXDBEntities db = new WXDBEntities())
            {
                //var list = new List<Instagram>();
                int skipsize = page * 3;
                var newslit = db.Article.Where(s => s.Type == 2).Where(s => s.Status == 0).OrderBy(s => s.Orders).ThenByDescending(s => s.UpdateTime).Skip(skipsize).Take(3).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            title = item.Title,
                            addtime = item.AddTime.ToString("yyyy年MM月dd日"),
                            cont = item.Contents
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }
        //右侧文章
        protected void GetNewsRight(HttpContext context)
        {
            int page = 0;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;
            using (WXDBEntities db = new WXDBEntities())
            {
                //var list = new List<Instagram>();
                int skipsize = page * 3;
                var newslit = db.Article.Where(s => s.Type == 2).Where(s => s.Status == 1).OrderBy(s => s.Orders).ThenByDescending(s => s.UpdateTime).Skip(skipsize).Take(3).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            title = item.Title,
                            addtime = item.AddTime.ToString("yyyy年MM月dd日"),
                            cont = item.Contents
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }
        //左侧图片信息
        public void GetPicwal(HttpContext context)
        {
            int page = 0;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page <= 1)
                page = 1;
            using (WXDBEntities db = new WXDBEntities())
            {
                var list = new List<Instagram>();
                int skipsize = page * 6;
                list = db.Instagram.Where(s => s.Id % 2 == 0).OrderByDescending(s => s.AddTime).Skip(skipsize).Take(6).ToList();

                List<object> listDesc = new List<object>();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        listDesc.Add(new
                        {
                            name = item.UserName,
                            picurl = item.PicUrl,
                            addtime = item.AddTime.ToString("yyyy-MM-dd")
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }
        //右侧图片信息 
        public void GetPicwalright(HttpContext context)
        {

            int page = 0;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page <= 1)
                page = 1;
            using (WXDBEntities db = new WXDBEntities())
            {
                var list = new List<Instagram>();
                int skipsize = page * 6;
                list = db.Instagram.Where(s => s.Id % 2 == 1).OrderByDescending(s => s.AddTime).Skip(skipsize).Take(6).ToList();

                List<object> listDesc = new List<object>();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        listDesc.Add(new
                        {
                            name = item.UserName,
                            picurl = item.PicUrl,
                            addtime = item.AddTime.ToString("yyyy-MM-dd")
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    context.Response.Write(jsonstrlist);
                }
            }
        }
        public void AddEffect(string openid, string currtitle, HttpContext context)
        {
            try
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var model = new Effect();
                    model.Title = currtitle;
                    model.Openid = openid;
                    model.AddTime = DateTime.Now;
                    model.UpdateTime = DateTime.Now;
                    model.Status = 0;
                    model.Orders = 0;

                    db.Effect.AddObject(model);
                    db.SaveChanges();
                    context.Response.Write("{\"ismsgs\":\"1\"}");
                }
            }
            catch (Exception ext)
            {
                context.Response.Write("{\"ismsgs\":\"0\"}");
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