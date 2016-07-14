using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WX.Utils;
using System.IO;
using WXEF;
using System.Web.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs.User;
using Senparc.Weixin.MP.CommonAPIs;
using Webdiyer.WebControls.Mvc;
using System.Data.SqlClient;
using Dos.ORM;

namespace NewInfoWeb.zpzs
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
                case "makeImg":
                    AddHdPicInof();
                    break;
                case "getlist":
                    GetImgList();
                    break;
                case "HDZan":
                    SetZan1(context);
                    break;
                case "GetList1":
                    GetListPM();
                    break;
                case "HDZan1":
                    SetZan2(context);
                    break;
                case "getlist2":
                    Getlist2();
                    break;
                case "getlist3":
                    Getlist3();
                    break;
                default:
                    break;
            }
        }

        private void Getlist3()
        {
            int page = 0;
            int pagesize = 8;
            int.TryParse(_ct.Request.Form["tmppage"], out page);
            if (page < 1)
                page = 0;
            int.TryParse(_ct.Request.Form["pagesize"], out pagesize);

            //using (WXDBEntities db = new WXDBEntities())
            //{
            //int skipsize = page * pagesize;
            int tmpage = page + 1;
            FromSection<Dos.Model.HdPic> fromsection = DbSession.Default.From<Dos.Model.HdPic>()
                .Where(s => s.Extend2.Equals("113"))
                .OrderByDescending(s => s.Orders);
            var list1 = fromsection.Page(pagesize, tmpage).ToList();
            //int count = fromsection.Count();

            //fromsection.Page(pager.PageSize, pager.CurrentPageIndex).ToList();
            //var list1 = DbSession.Default.From<Dos.Model.HdPic>()

            //    .OrderBy(Dos.Model.HdPic._.Orders.Desc)
            //  //.OrderBy(Dos.Model.HdPic._.UpdateTime.Asc)

            //  .Page(pagesize, tmpage)
            //  .ToList();
            //IQueryable<HdPic> list = db.HdPic.OrderByDescending(s => s.Orders).ThenBy(s => s.UpdateTime).Where(s => s.Status == 0 && s.Extend2.Equals("107"));
            //var dblist = list.ToPagedList(tmpage, pagesize);
            //..
            //list = .Skip(skipsize).Take(pagesize).ToList();
            //int count = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).Count();
            List<object> listDesc = new List<object>();
            if (list1.Count > 0)
            {
                foreach (var item in list1)
                {
                    listDesc.Add(new
                    {
                        id = item.Id,
                        name = item.Name,
                        nums = item.Orders,
                        imgurl = item.PicUrl,
                        ntnum = item.Extend4
                    });
                }
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = list1.Count });
                _ct.Response.Write(jsonstrlist);
            }
            else
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
            //}
        }

        protected void Getlist2()
        {
            int page = 0;
            int pagesize = 8;
            int.TryParse(_ct.Request.Form["tmppage"], out page);
            if (page < 1)
                page = 0;
            int.TryParse(_ct.Request.Form["pagesize"], out pagesize);

            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;

                int tmpage = page + 1;
                //var list = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).OrderBy(s => s.AddTime).Skip(skipsize).Take(pagesize).ToList();
                FromSection<Dos.Model.HdPic> fromsection = DbSession.Default.From<Dos.Model.HdPic>()
                    .Where(s => s.Extend2.Equals("113"));
                var list = fromsection.Page(pagesize, tmpage).ToList();
                //IQueryable<HdPic> list = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).OrderBy(s => s.AddTime);
                //var dblist = list.ToPagedList(tmpage, pagesize);
                //.OrderByDescending(s => s.Orders).
                //list = .Skip(skipsize).Take(pagesize).ToList();
                //int count = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).Count();
                List<object> listDesc = new List<object>();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        listDesc.Add(new
                        {
                            id = item.Id,
                            name = item.Name,
                            nums = item.Orders,
                            imgurl = item.PicUrl,
                            ntnum = item.Extend4
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = list.Count });
                    _ct.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    _ct.Response.Write(jsonstrlist);
                }
            }
        }
        private void SetZan2(HttpContext context)
        {
            #region 新的方法
            try
            {
                int tmphid = 0;
                int.TryParse(_ct.Request.Form["tmpid"], out tmphid);
                //string topid = _ct.Request.Form["tmpres"];
                string topid = Dos.Common.CookieHelper.Get("curYLAes");
                if (string.IsNullOrEmpty(topid))
                {
                    context.Response.Write("{\"ismsgs\":\"不存在topid\",\"ist\":\"" + 4 + "\"}");
                }
                else
                {
                    var tmpopenid = Common.CryptHelper.DESEncrypt.Decrypt(topid, WebConfigurationManager.AppSettings["PassWordKey"]);
                    var tmpopid2 = Common.CryptHelper.DESEncrypt.Encrypt(Dos.Common.CookieHelper.Get("curYLTid"), WebConfigurationManager.AppSettings["PassWordKey"]);
                    if (tmpopid2.Equals(topid))
                    {
                        int nums1 = 0;
                        int ist = 0;
                        DateTime t1 = DateTime.Now.Date;
                        DateTime tm2 = DateTime.Now.AddDays(1).Date;
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime20"]);
                        DateTime t3 = t2.AddDays(1);
                        var userInfo = UserApi.Info(AccessTokenContainer.TryGetToken(WebConfigurationManager.AppSettings["wxappid1"], WebConfigurationManager.AppSettings["wxsecret1"]), tmpopenid);
                        if (_ct.Request.UrlReferrer.Host.Equals("wsjhb.tencenthouse.com"))
                        {
                            if (string.IsNullOrEmpty(_ct.Request.UserAgent) || (!_ct.Request.UserAgent.Contains("MicroMessenger") && !_ct.Request.UserAgent.Contains("Windows Phone")))
                            {
                                _ct.Response.Write("{\"ismsgs\":\"请从微信端访问\",\"ist\":\"" + 6 + "\"}");
                            }
                            else
                            {
                                if (DateTime.Compare(t1, t2) < 0)
                                {
                                    var ctcount = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(tmpopenid) && s.addtime > t1 && s.addtime < tm2 && s.extend1.Equals("113")).Count();
                                    if (ctcount >= 3)
                                    {
                                        _ct.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 2 + "\"}");
                                    }
                                    else
                                    {
                                        var tmpdel = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(tmpopenid) && s.hdpicid.Equals(tmphid) && s.addtime > t1 && s.addtime < tm2).ToFirstDefault();
                                        if (tmpdel.Id > 0)
                                        {
                                            _ct.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 5 + "\"}");
                                        }
                                        else
                                        {
                                            string tsd = _ct.Request.UrlReferrer.Host;
                                            var std1 = _ct.Request.UserHostAddress;
                                            Dos.Model.HdPicHit model = new Dos.Model.HdPicHit();
                                            model.Attach();
                                            model.addtime = DateTime.Now;
                                            model.updatetime = DateTime.Now;
                                            model.extend1 = "113";
                                            model.extend2 = tsd;
                                            model.orders = 0;
                                            model.status = 0;
                                            model.wxopenid = tmpopenid;
                                            model.name = std1;
                                            model.hdpicid = tmphid;
                                            int returnValue = DbSession.Default.Insert<Dos.Model.HdPicHit>(model);
                                            Dos.Model.HdPic tmodel = DbSession.Default.From<Dos.Model.HdPic>().Where(s => s.Id.Equals(tmphid) && s.Extend2.Equals("113")).ToFirstDefault();
                                            if (tmodel.Id > 0)
                                            {
                                                tmodel.Attach();
                                                nums1 = tmodel.Orders + 1;
                                                tmodel.Orders = tmodel.Orders + 1;
                                                tmodel.UpdateTime = DateTime.Now;
                                                int returnvalue = DbSession.Default.Update<Dos.Model.HdPic>(tmodel);
                                            }
                                            ist = 1;
                                            _ct.Response.Write("{\"ismsgs\":\"" + nums1 + "\",\"ist\":\"" + 1 + "\"}");
                                        }
                                    }
                                }
                                else
                                {
                                    _ct.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 3 + "\"}");
                                }
                            }
                        }
                        else
                        {
                            _ct.Response.Write("{\"ismsgs\":\"请从正规域名访问\",\"ist\":\"" + 6 + "\"}");
                        }

                    }
                    else
                    {
                        context.Response.Write("{\"ismsgs\":\"数据不正确\",\"ist\":\"" + 4 + "\"}");
                    }
                }
            }
            catch (Exception ex)
            {
                _ct.Response.Write("{\"ismsgs\":\"出错了\",\"ist\":\"" + 4 + "\"}");
            }
            #endregion
        }
        private void GetListPM()
        {
            int page = 0;
            int pagesize = 8;
            int.TryParse(_ct.Request.Form["tmppage"], out page);
            if (page < 1)
                page = 0;
            int.TryParse(_ct.Request.Form["pagesize"], out pagesize);

            //using (WXDBEntities db = new WXDBEntities())
            //{
            //int skipsize = page * pagesize;
            int tmpage = page + 1;
            FromSection<Dos.Model.HdPic> fromsection = DbSession.Default.From<Dos.Model.HdPic>()
                .Where(s => s.Extend2.Equals("107"))
                .OrderBy(Dos.Model.HdPic._.Orders.Desc);
            var list1 = fromsection.Page(pagesize, tmpage).ToList();
            //int count = fromsection.Count();

            //fromsection.Page(pager.PageSize, pager.CurrentPageIndex).ToList();
            //var list1 = DbSession.Default.From<Dos.Model.HdPic>()

            //    .OrderBy(Dos.Model.HdPic._.Orders.Desc)
            //  //.OrderBy(Dos.Model.HdPic._.UpdateTime.Asc)

            //  .Page(pagesize, tmpage)
            //  .ToList();
            //IQueryable<HdPic> list = db.HdPic.OrderByDescending(s => s.Orders).ThenBy(s => s.UpdateTime).Where(s => s.Status == 0 && s.Extend2.Equals("107"));
            //var dblist = list.ToPagedList(tmpage, pagesize);
            //..
            //list = .Skip(skipsize).Take(pagesize).ToList();
            //int count = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).Count();
            List<object> listDesc = new List<object>();
            if (list1.Count > 0)
            {
                foreach (var item in list1)
                {
                    listDesc.Add(new
                    {
                        id = item.Id,
                        name = item.Name,
                        nums = item.Orders,
                        imgurl = item.PicUrl,
                        ntnum = item.Extend4
                    });
                }
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = list1.Count });
                _ct.Response.Write(jsonstrlist);
            }
            else
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
            //}
        }
        private void SetZan1(HttpContext context)
        {

            #region 新的方法
            try
            {
                int tmphid = 0;
                int.TryParse(_ct.Request.Form["tmpid"], out tmphid);
                //string topid = _ct.Request.Form["tmpres"];
                string topid = Dos.Common.CookieHelper.Get("curYSAes");
                if (string.IsNullOrEmpty(topid))
                {
                    context.Response.Write("{\"ismsgs\":\"不存在topid\",\"ist\":\"" + 4 + "\"}");
                }
                else
                {
                    var tmpopenid = Common.CryptHelper.DESEncrypt.Decrypt(topid, WebConfigurationManager.AppSettings["PassWordKey"]);
                    var tmpopid2 = Common.CryptHelper.DESEncrypt.Encrypt(Dos.Common.CookieHelper.Get("curYSTid"), WebConfigurationManager.AppSettings["PassWordKey"]);
                    if (tmpopid2.Equals(topid))
                    {
                        int nums1 = 0;
                        int ist = 0;
                        DateTime t1 = DateTime.Now.Date;
                        DateTime tm2 = DateTime.Now.AddDays(1).Date;
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime11"]);
                        DateTime t3 = t2.AddDays(1);
                        var userInfo = UserApi.Info(AccessTokenContainer.TryGetToken(WebConfigurationManager.AppSettings["wxappid1"], WebConfigurationManager.AppSettings["wxsecret1"]), tmpopenid);
                        if (_ct.Request.UrlReferrer.Host.Equals("wsjhb.tencenthouse.com"))
                        {
                            if (string.IsNullOrEmpty(_ct.Request.UserAgent) || (!_ct.Request.UserAgent.Contains("MicroMessenger") && !_ct.Request.UserAgent.Contains("Windows Phone")))
                            {
                                _ct.Response.Write("{\"ismsgs\":\"请从微信端访问\",\"ist\":\"" + 6 + "\"}");
                            }
                            else
                            {
                                if (DateTime.Compare(t1, t2) < 0)
                                {
                                    var ctcount = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(tmpopenid) && s.addtime > t1 && s.addtime < tm2 && s.extend1.Equals("107")).Count();
                                    if (ctcount >= 3)
                                    {
                                        _ct.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 2 + "\"}");
                                    }
                                    else
                                    {
                                        var tmpdel = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(tmpopenid) && s.hdpicid.Equals(tmphid) && s.addtime > t1 && s.addtime < tm2).ToFirstDefault();
                                        if (tmpdel.Id > 0)
                                        {
                                            _ct.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 5 + "\"}");
                                        }
                                        else
                                        {
                                            string tsd = _ct.Request.UrlReferrer.Host;
                                            var std1 = _ct.Request.UserHostAddress;
                                            Dos.Model.HdPicHit model = new Dos.Model.HdPicHit();
                                            model.Attach();
                                            model.addtime = DateTime.Now;
                                            model.updatetime = DateTime.Now;
                                            model.extend1 = "107";
                                            model.extend2 = tsd;
                                            model.orders = 0;
                                            model.status = 0;
                                            model.wxopenid = tmpopenid;
                                            model.name = std1;
                                            model.hdpicid = tmphid;
                                            int returnValue = DbSession.Default.Insert<Dos.Model.HdPicHit>(model);
                                            Dos.Model.HdPic tmodel = DbSession.Default.From<Dos.Model.HdPic>().Where(s => s.Id.Equals(tmphid)).ToFirstDefault();
                                            if (tmodel.Id > 0)
                                            {
                                                tmodel.Attach();
                                                nums1 = tmodel.Orders + 1;
                                                tmodel.Orders = tmodel.Orders + 1;
                                                tmodel.UpdateTime = DateTime.Now;
                                                int returnvalue = DbSession.Default.Update<Dos.Model.HdPic>(tmodel);
                                            }
                                            ist = 1;
                                            _ct.Response.Write("{\"ismsgs\":\"" + nums1 + "\",\"ist\":\"" + 1 + "\"}");
                                        }
                                    }
                                }
                                else
                                {
                                    _ct.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 3 + "\"}");
                                }
                            }
                        }
                        else
                        {
                            _ct.Response.Write("{\"ismsgs\":\"请从正规域名访问\",\"ist\":\"" + 6 + "\"}");
                        }

                    }
                    else
                    {
                        context.Response.Write("{\"ismsgs\":\"数据不正确\",\"ist\":\"" + 4 + "\"}");
                    }
                }
            }
            catch (Exception ex)
            {
                _ct.Response.Write("{\"ismsgs\":\"出错了\",\"ist\":\"" + 4 + "\"}");
            }
            #endregion
        }
        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="context"></param>
        protected void GetImgList()
        {
            int page = 0;
            int pagesize = 8;
            int.TryParse(_ct.Request.Form["tmppage"], out page);
            if (page < 1)
                page = 0;
            int.TryParse(_ct.Request.Form["pagesize"], out pagesize);

            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;

                int tmpage = page + 1;
                //var list = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).OrderBy(s => s.AddTime).Skip(skipsize).Take(pagesize).ToList();
                FromSection<Dos.Model.HdPic> fromsection = DbSession.Default.From<Dos.Model.HdPic>()
                    .Where(s => s.Extend2.Equals("107"));
                var list = fromsection.Page(pagesize, tmpage).ToList();
                //IQueryable<HdPic> list = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).OrderBy(s => s.AddTime);
                //var dblist = list.ToPagedList(tmpage, pagesize);
                //.OrderByDescending(s => s.Orders).
                //list = .Skip(skipsize).Take(pagesize).ToList();
                //int count = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("107")).Count();
                List<object> listDesc = new List<object>();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        listDesc.Add(new
                        {
                            id = item.Id,
                            name = item.Name,
                            nums = item.Orders,
                            imgurl = item.PicUrl,
                            ntnum = item.Extend4
                        });
                    }
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = list.Count });
                    _ct.Response.Write(jsonstrlist);
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "", count = 0 });
                    _ct.Response.Write(jsonstrlist);
                }
            }
        }
        private void AddHdPicInof()
        {
            var name = _ct.Request.Form["tname"];
            var phone = _ct.Request.Form["tphone"];
            var opid = _ct.Request.Form["tmpid"];
            var tmimg = _ct.Request.Form["img"];
            try
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    if (string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(name) && string.IsNullOrEmpty(phone) && string.IsNullOrWhiteSpace(phone))
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "faill", result = null, count = 0 });
                        _ct.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[1]+[3,4,5,6,7,8]+\d{9}"))
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "faill", result = null, count = 0 });
                            _ct.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            var model = db.HdPic.Where(s => s.Extend1.Equals(opid) && s.Extend2.Equals("107")).FirstOrDefault();
                            if (model != null)
                            {
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = null, count = 1 });
                                _ct.Response.Write(jsonstrlist);
                            }
                            else
                            {
                                string picame = Guid.NewGuid().ToString("N") + DateTime.Now.ToString("yyyyMMddHHssmm");
                                FileStream fs = File.Create(WebConfigurationManager.AppSettings["yspic"].ToString() + picame + ".jpg");
                                byte[] bytes = Convert.FromBase64String(tmimg.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", ""));
                                fs.Write(bytes, 0, bytes.Length);
                                fs.Close();
                                var tid = db.HdPic.Where(s => s.Extend2.Equals("107")).Count();
                                model = new HdPic()
                                {
                                    Name = name,
                                    PicUrl = picame + ".jpg",
                                    Status = 0,
                                    Orders = 0,
                                    AddTime = DateTime.Now,
                                    UpdateTime = DateTime.Now,
                                    Extend1 = opid,
                                    Extend2 = "107",
                                    Extend3 = phone,
                                    Extend4 = (tid + 1) + ""
                                };
                                db.HdPic.AddObject(model);
                                db.SaveChanges();
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = null, count = 2 });
                                _ct.Response.Write(jsonstrlist);
                            }
                        }
                    }
                }
            }
            catch (Exception et)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = et.Message, result = null, count = 0 });
                _ct.Response.Write(jsonstrlist);
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