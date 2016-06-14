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
using Dos.Common;
using Dos.ORM;
using System.Data;

namespace NewInfoWeb.lnInfo
{
    /// <summary>
    /// Operation 的摘要说明
    /// </summary>
    public class Operation : IHttpHandler
    {
        protected HttpContext _ct;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _ct = context;
            var type = _ct.Request.Form["type"];
            switch (type)
            {
                case "AddMX":
                    AddMXInfo();
                    break;
                case "getlist":
                    GetImgList();
                    break;
                case "HDZan":
                    SetZan(context);
                    break;
                case "AddXYInfo":
                    AddXYInfo();
                    break;
                case "HDXYZJZan":
                    XYZJDz();
                    break;
                case "XYPgList":
                    XYPGList();
                    break;
                case "HDXYOtherZan":
                    XYOtherDZ();
                    break;
            }
        }

        /// <summary>
        /// 别人点赞操作
        /// </summary>
        private void XYOtherDZ()
        {
            try
            {
                int tmphid = 0;
                int.TryParse(_ct.Request.Form["tmpid"], out tmphid);
                //string topid = _ct.Request.Form["tmpres"];
                string topid = _ct.Request.Form["curXYDZAre"];
                if (string.IsNullOrEmpty(topid))
                {
                    _ct.Response.Write("{\"ismsgs\":\"不存在数据\",\"ist\":\"" + 2 + "\"}");
                }
                else
                {
                    var tmpopenid = Common.CryptHelper.DESEncrypt.Decrypt(topid, WebConfigurationManager.AppSettings["PassWordKey"]);
                    var topid2 = Common.CryptHelper.DESEncrypt.Decrypt(_ct.Request.Form["curXYDZAreTid"], WebConfigurationManager.AppSettings["PassWordKey1"]);
                    if (topid2.Equals(tmpopenid))
                    {
                        int nums1 = 0;
                        int ist = 0;
                        DateTime t1 = DateTime.Now.Date;
                        DateTime tm2 = DateTime.Now.AddDays(1).Date;
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime14"]);
                        DateTime t3 = t2.AddDays(1);

                        //var userInfo = UserApi.Info(AccessTokenContainer.TryGetToken(WebConfigurationManager.AppSettings["wxappid1"], WebConfigurationManager.AppSettings["wxsecret1"]), tmpopenid);
                        if (_ct.Request.UrlReferrer.Host.Equals("wsjhb.tencenthouse.com"))
                        {
                            if (string.IsNullOrEmpty(_ct.Request.UserAgent) || (!_ct.Request.UserAgent.Contains("MicroMessenger") && !_ct.Request.UserAgent.Contains("Windows Phone")))
                            {
                                _ct.Response.Write("{\"ismsgs\":\"请通过微信端访问\",\"ist\":\"" + 2 + "\"}");
                            }
                            else
                            {
                                if (DateTime.Compare(t1, t2) < 0)
                                {
                                    if (tmphid > 0)
                                    {
                                        var tmpdel = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(tmpopenid) && s.extend1.Equals("109") && s.hdpicid.Equals(tmphid) && s.addtime > t1 && s.addtime < tm2).ToFirstDefault();
                                        if (tmpdel.Id > 0)
                                        {
                                            _ct.Response.Write("{\"ismsgs\":\"已存在数据\",\"ist\":\"" + 5 + "\"}");
                                        }
                                        else
                                        {
                                            string tsd = _ct.Request.UrlReferrer.Host;
                                            var std1 = _ct.Request.UserHostAddress;
                                            Dos.Model.HdPicHit model = new Dos.Model.HdPicHit();
                                            model.Attach();
                                            model.addtime = DateTime.Now;
                                            model.updatetime = DateTime.Now;
                                            model.extend1 = "109";
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
                                            //string nts = "编号:" + tmodel.Extend4 + " 票数：" + nums1;
                                            _ct.Response.Write("{\"ismsgs\":\"" + nums1 + "\",\"ist\":\"" + 1 + "\"}");
                                        }
                                    }
                                    else
                                    {
                                        _ct.Response.Write("{\"ismsgs\":\"操作的数据不存在\",\"ist\":\"" + 0 + "\"}");
                                    }
                                }
                                else
                                {
                                    _ct.Response.Write("{\"ismsgs\":\"活动时间已过\",\"ist\":\"" + 3 + "\"}");
                                }
                            }
                        }
                        else
                        {
                            _ct.Response.Write("{\"ismsgs\":\"请通过正规域名访问\",\"ist\":\"" + 2 + "\"}");
                        }
                    }
                    else
                    {
                        _ct.Response.Write("{\"ismsgs\":\"数据不一致\",\"ist\":\"" + 2 + "\"}");
                    }
                }
            }
            catch (Exception)
            {
                _ct.Response.Write("{\"ismsgs\":\"数据出错\",\"ist\":\"" + 4 + "\"}");
            }
        }

        /// <summary>
        /// 得到列表信息
        /// </summary>
        private void XYPGList()
        {
            int page = 0;
            int pagesize = 15;
            int.TryParse(_ct.Request.Form["tmppage"], out page);
            if (page < 1)
                page = 0;
            int.TryParse(_ct.Request.Form["pagesize"], out pagesize);
            int skipsize = page * pagesize;
            int tmpage = page + 1;
            FromSection<Dos.Model.HdPic> fromsection = DbSession.Default.From<Dos.Model.HdPic>()
              .Where(s => s.Extend2.Equals("109"))
              .OrderBy(Dos.Model.HdPic._.Orders.Desc, Dos.Model.HdPic._.UpdateTime.Asc);
            var list = fromsection.Page(pagesize, tmpage).ToList();
            List<object> listDesc = new List<object>();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    listDesc.Add(new
                    {
                        id = item.Id,
                        img = item.PicUrl,
                        nickname = item.Name,
                        nums = item.Orders
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

        /// <summary>
        /// 自己挤满7颗珠子
        /// </summary>
        private void XYZJDz()
        {
            try
            {
                var topid1 = Common.CryptHelper.DESEncrypt.Decrypt(Dos.Common.CookieHelper.Get("curXYAes"), WebConfigurationManager.AppSettings["PassWordKey"]);
                int tmphid = 0;
                int.TryParse(_ct.Request.Form["tmpid"], out tmphid);
                if (string.IsNullOrEmpty(topid1))
                {
                    _ct.Response.Write("{\"ismsgs\":\"不存在数据\",\"ist\":\"" + 2 + "\"}");
                }
                else
                {
                    var tmodel = DbSession.Default.From<Dos.Model.HdPic>().Where(s => s.Id.Equals(tmphid)).ToFirstDefault();
                    if (tmodel.Id > 0)
                    {
                        if (tmodel.Status >= 7)
                        {
                            _ct.Response.Write("{\"ismsgs\":\" 基础星星已集满\",\"ist\":\"" + 3 + "\"}");
                        }
                        else
                        {
                            tmodel.Attach();
                            tmodel.Status = tmodel.Status + 1;
                            tmodel.Orders = tmodel.Orders + 1;
                            int returnvalue = DbSession.Default.Update<Dos.Model.HdPic>(tmodel);
                            var stopnum = DbSession.Default.FromSql("select row from (select row_number() over (order by orders desc,updatetime asc) row,extend1 from hdpic where Extend2='109') newtable where extend1=@extend1").AddInParameter("@extend1", DbType.String, topid1).ToScalar() + "";
                            _ct.Response.Write("{\"ismsgs\":\"" + stopnum + "\",\"ist\":\"" + 4 + "\",\"nums\":\"" + tmodel.Orders + "\"}");
                        }
                    }
                    else
                    {
                        _ct.Response.Write("{\"ismsgs\":\" 不存在数据\",\"ist\":\"" + 1 + "\"}");
                    }
                }
            }
            catch (Exception ex)
            {
                _ct.Response.Write("{\"ismsgs\":\"" + ex.Message + "\",\"ist\":\"" + 0 + "\"}");
            }
        }

        /// <summary>
        /// 新增数据信息
        /// </summary>
        private void AddXYInfo()
        {
            try
            {
                var topid1 = Common.CryptHelper.DESEncrypt.Decrypt(Dos.Common.CookieHelper.Get("curXYAes"), WebConfigurationManager.AppSettings["PassWordKey"]);
                var tname = _ct.Request.Form["tname"];
                var tphone = _ct.Request.Form["tphone"];
                var tpicurl = Dos.Common.CookieHelper.Get("curXYImgUrl");
                var tpnickname = Dos.Common.CookieHelper.Get("curXYName");
                var tmodel = DbSession.Default.From<Dos.Model.HdPic>().Where(s => s.Extend2.Equals("109") && s.Extend1.Equals(topid1)).ToFirstDefault();
                if (tmodel.Id > 0)
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "不能重复提交数据", result = null, count = 1 });
                    _ct.Response.Write(jsonstrlist);
                }
                else
                {
                    var tmo = DbSession.Default.From<Dos.Model.HdPic>().Where(t => t.Extend4.Equals(tphone) && t.Extend2.Equals("109")).ToFirstDefault();
                    if (tmo.Id > 0)
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "该手机号码已存在,请重新输入", result = null, count = 3 });
                        _ct.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        var tid = DbSession.Default.From<Dos.Model.HdPic>().Where(s => s.Extend2.Equals("109")).Count();
                        //tmodel.AttachAll()
                        tmodel = new Dos.Model.HdPic()
                        {
                            Name = tpnickname,
                            PicUrl = tpicurl,
                            Status = 0,
                            Orders = 0,
                            AddTime = DateTime.Now,
                            UpdateTime = DateTime.Now,
                            Extend1 = topid1,
                            Extend2 = "109",
                            Extend3 = tname,
                            Extend4 = tphone
                        };
                        int ti = DbSession.Default.Insert<Dos.Model.HdPic>(tmodel);

                        var stopnum = DbSession.Default.FromSql("select row from (select row_number() over (order by orders desc,updatetime asc) row,extend1 from hdpic where Extend2='109') newtable where extend1=@extend1").AddInParameter("@extend1", DbType.String, topid1).ToScalar() + "";
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ti + "", result = stopnum, count = 2 });
                        _ct.Response.Write(jsonstrlist);
                    }
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = null, count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
        }

        private void SetZan(HttpContext context)
        {
            try
            {
                int tmphid = 0;
                int.TryParse(_ct.Request.Form["tmpid"], out tmphid);
                //string topid = _ct.Request.Form["tmpres"];
                string topid = Dos.Common.CookieHelper.Get("curLNAes");
                if (string.IsNullOrEmpty(topid))
                {
                    _ct.Response.Write("{\"ismsgs\":\"不存在数据\",\"ist\":\"" + 2 + "\"}");
                }
                else
                {
                    var tmpopenid = Common.CryptHelper.DESEncrypt.Decrypt(topid, WebConfigurationManager.AppSettings["PassWordKey"]);
                    var topid2 = Common.CryptHelper.DESEncrypt.Encrypt(Dos.Common.CookieHelper.Get("curLNTid"), WebConfigurationManager.AppSettings["PassWordKey"]);
                    if (topid2.Equals(topid))
                    {
                        int nums1 = 0;
                        int ist = 0;
                        DateTime t1 = DateTime.Now.Date;
                        DateTime tm2 = DateTime.Now.AddDays(1).Date;
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime12"]);
                        DateTime t3 = t2.AddDays(1);

                        //var userInfo = UserApi.Info(AccessTokenContainer.TryGetToken(WebConfigurationManager.AppSettings["wxappid1"], WebConfigurationManager.AppSettings["wxsecret1"]), tmpopenid);
                        if (_ct.Request.UrlReferrer.Host.Equals("wsjhb.tencenthouse.com"))
                        {
                            if (string.IsNullOrEmpty(_ct.Request.UserAgent) || (!_ct.Request.UserAgent.Contains("MicroMessenger") && !_ct.Request.UserAgent.Contains("Windows Phone")))
                            {
                                _ct.Response.Write("{\"ismsgs\":\"请通过微信端访问\",\"ist\":\"" + 2 + "\"}");
                            }
                            else
                            {
                                if (DateTime.Compare(t1, t2) < 0)
                                {
                                    if (tmphid > 0)
                                    {
                                        var tmpdel = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(tmpopenid) && s.extend1.Equals("108") && s.hdpicid.Equals(tmphid) && s.addtime > t1 && s.addtime < tm2).ToFirstDefault();
                                        if (tmpdel.Id > 0)
                                        {
                                            context.Response.Write("{\"ismsgs\":\"已存在数据\",\"ist\":\"" + 5 + "\"}");
                                        }
                                        else
                                        {

                                            string tsd = _ct.Request.UrlReferrer.Host;
                                            var std1 = _ct.Request.UserHostAddress;
                                            Dos.Model.HdPicHit model = new Dos.Model.HdPicHit();
                                            model.Attach();
                                            model.addtime = DateTime.Now;
                                            model.updatetime = DateTime.Now;
                                            model.extend1 = "108";
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
                                            //string nts = "编号:" + tmodel.Extend4 + " 票数：" + nums1;
                                            _ct.Response.Write("{\"ismsgs\":\"" + nums1 + "\",\"ist\":\"" + 1 + "\"}");
                                        }
                                    }
                                    else
                                    {
                                        _ct.Response.Write("{\"ismsgs\":\"操作的数据不存在\",\"ist\":\"" + 0 + "\"}");
                                    }
                                }
                                else
                                {
                                    _ct.Response.Write("{\"ismsgs\":\"活动时间已过\",\"ist\":\"" + 3 + "\"}");
                                }
                            }
                        }
                        else
                        {
                            _ct.Response.Write("{\"ismsgs\":\"请通过正规域名访问\",\"ist\":\"" + 2 + "\"}");
                        }
                    }
                    else
                    {
                        _ct.Response.Write("{\"ismsgs\":\"数据不一致\",\"ist\":\"" + 2 + "\"}");
                    }

                }
            }
            catch (Exception)
            {
                _ct.Response.Write("{\"ismsgs\":\"数据出错\",\"ist\":\"" + 4 + "\"}");
            }
        }
        //private void SetZan(HttpContext context)
        //{
        //    try
        //    {
        //        int tmphid = 0;
        //        int.TryParse(context.Request.Form["tmpid"], out tmphid);
        //        string topid = context.Request.Form["tmpopenid"];

        //        var tmpopenid = Common.CryptHelper.DESEncrypt.Decrypt(topid, WebConfigurationManager.AppSettings["PassWordKey"]);
        //        int nums1 = 0;
        //        int ist = 0;
        //        DateTime t1 = DateTime.Now.Date;
        //        DateTime tm2 = DateTime.Now.AddDays(1).Date;
        //        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime12"]);
        //        DateTime t3 = t2.AddDays(1);

        //        var userInfo = UserApi.Info(AccessTokenContainer.TryGetToken(WebConfigurationManager.AppSettings["wxappid1"], WebConfigurationManager.AppSettings["wxsecret1"]), tmpopenid);
        //        if (string.IsNullOrEmpty(_ct.Request.UserAgent) || (!_ct.Request.UserAgent.Contains("MicroMessenger") && !_ct.Request.UserAgent.Contains("Windows Phone")))
        //        {
        //            context.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 2 + "\"}");
        //        }
        //        else
        //        {

        //            if (DateTime.Compare(t1, t2) < 0)
        //            {
        //                if (tmphid > 0)
        //                {
        //                    int idnum = 0;
        //                    using (WXDBEntities db = new WXDBEntities())
        //                    {
        //                        //var ctcount = db.HdPicHit.Where(s => s.wxopenid.Equals(tmpopenid) && s.addtime > t1 && s.addtime < tm2).Count();
        //                        //if (ctcount >= 3)
        //                        //{
        //                        //    context.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 2 + "\"}");
        //                        //}
        //                        //else
        //                        //{
        //                        //var tmpdel = db.HdPicHit.Where(s => s.wxopenid.Equals(tmpopenid) && s.hdpicid.Equals(tmphid) && s.addtime > t1 && s.addtime < tm2).FirstOrDefault();
        //                        var tmpdel = db.HdPicHit.Where(s => s.wxopenid.Equals(tmpopenid) && s.extend1.Equals("108")).FirstOrDefault();
        //                        if (tmpdel != null)
        //                        {
        //                            context.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 5 + "\"}");
        //                        }
        //                        else
        //                        {
        //                            HdPicHit model = new HdPicHit();
        //                            model.addtime = DateTime.Now;
        //                            model.updatetime = DateTime.Now;
        //                            model.extend1 = "108";
        //                            model.extend2 = "";
        //                            model.orders = 0;
        //                            model.status = 0;
        //                            model.wxopenid = tmpopenid;
        //                            model.name = "";
        //                            model.hdpicid = tmphid;
        //                            db.HdPicHit.AddObject(model);
        //                            db.SaveChanges();
        //                            HdPic tmodel = db.HdPic.Where(s => s.Id == tmphid).FirstOrDefault();
        //                            if (tmodel != null)
        //                            {
        //                                nums1 = tmodel.Orders + 1;
        //                                SqlParameter[] para = new SqlParameter[] {
        //                                    new SqlParameter("@Id",tmodel.Id),
        //                                    new SqlParameter("@Orders",tmodel.Orders+1),
        //                                    new SqlParameter("@UpdateTime",DateTime.Now)
        //                                    };
        //                                var ct = db.ExecuteStoreCommand(" update HdPic set Orders=@Orders, UpdateTime=@UpdateTime  where Id=@Id", para);
        //                            }
        //                            else
        //                            {
        //                                nums1 = 0;
        //                            }
        //                            ist = 1;
        //                            context.Response.Write("{\"ismsgs\":\"" + nums1 + "\",\"ist\":\"" + 1 + "\"}");
        //                            //}
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    context.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 0 + "\"}");
        //                }
        //            }
        //            else
        //            {
        //                context.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 3 + "\"}");
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        context.Response.Write("{\"ismsgs\":\"0\",\"ist\":\"" + 4 + "\"}");
        //    }
        //}
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
                //var list = new List<HdPic>();
                //////.OrderByDescending(s => s.Orders).
                //list = db.HdPic.Where(s => s.Status == 0 && s.Extend2.Equals("108")).OrderByDescending(s => s.Orders).ThenBy(s => s.UpdateTime).Skip(skipsize).Take(pagesize).ToList();
                FromSection<Dos.Model.HdPic> fromsection = DbSession.Default.From<Dos.Model.HdPic>()
                  .Where(s => s.Extend2.Equals("108"))
                  .OrderBy(Dos.Model.HdPic._.Orders.Desc, Dos.Model.HdPic._.UpdateTime.Asc);
                var list = fromsection.Page(pagesize, tmpage).ToList();
                //DbSession.Default.FromSql("select row from (select row_number() over (order by orders desc,updatetime asc) row,extend1 from hdpic where Extend2='108') newtable where extend1=@extend1").AddInParameter("@extend1", DbType.String, "321").ToScalar();
                //SqlSection str = new SqlSection();
                //str.(DbSession)
                //IQueryable<HdPic> list = db.HdPic.OrderByDescending(s => s.Orders).ThenBy(s => s.UpdateTime).Where(s => s.Extend2.Equals("108"));
                //var dblist = list.ToPagedList(tmpage, pagesize);

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
                            tcont = item.PicUrl
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
        private void AddMXInfo()
        {
            try
            {
                var topid1 = _ct.Request.Form["tpid"];
                var tname = _ct.Request.Form["tname"];
                var tphone = _ct.Request.Form["tphone"];
                var tcont = _ct.Request.Form["tcont"];
                //var topid2 = Common.CryptHelper.DESEncrypt.Encrypt(Dos.Common.CookieHelper.Get("curLNTid"), WebConfigurationManager.AppSettings["PassWordKey"]);
                var topid = Common.CryptHelper.DESEncrypt.Decrypt(topid1, WebConfigurationManager.AppSettings["PassWordKey"]);
                //if (topid2.Equals(topid1))
                //{
                using (WXDBEntities db = new WXDBEntities())
                {
                    var tmodel = db.HdPic.Where(s => s.Extend2.Equals("108") && s.Extend1.Equals(topid)).FirstOrDefault();
                    if (tmodel != null)
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "不能重复提交数据", result = null, count = 1 });
                        _ct.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        var tmo = db.HdPic.Where(t => t.Extend3.Equals(tphone)).FirstOrDefault();
                        if (tmo != null)
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "该手机号码已存在,请重新输入", result = null, count = 3 });
                            _ct.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            var tid = db.HdPic.Where(s => s.Extend2.Equals("108")).Count();
                            tmodel = new HdPic()
                            {
                                Name = tname,
                                PicUrl = tcont,
                                Status = 0,
                                Orders = 0,
                                AddTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                Extend1 = topid,
                                Extend2 = "108",
                                Extend3 = tphone,
                                Extend4 = (tid + 1) + ""
                            };
                            db.HdPic.AddObject(tmodel);
                            db.SaveChanges();
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = tmodel.Id + "", result = null, count = 2 });
                            _ct.Response.Write(jsonstrlist);
                        }
                    }
                }
                //}
                //else
                //{
                //    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "请从正规渠道访问", result = null, count = 0 });
                //    _ct.Response.Write(jsonstrlist);
                //}
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = null, count = 0 });
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