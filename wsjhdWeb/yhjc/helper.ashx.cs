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
using WX.Utils;
using Dos.Model;

namespace NewInfoWeb.yhjc
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
                case "addBmInfo":
                    AddBmInfo();
                    break;
                case "getXMlist":
                    GetXMList();
                    break;
                case "AddJCInfo":
                    AddJCInfo();
                    break;
                case "getQSJG":
                    GetQSJG();
                    break;
                case "getmyJC":
                    GetMyJc();
                    break;
                case "yhPgList":
                    GetYHlist();
                    break;
                case "UpdateInfo":
                    UpdQSInfo();
                    break;
                case "yhOtherZan":
                    YHOtherInfo();
                    break;
            }
        }
        //助威效果
        private void YHOtherInfo()
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
                        DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime16"]);
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
                                        var tmpdel = DbSession.Default.From<Dos.Model.HdPicHit>().Where(s => s.wxopenid.Equals(tmpopenid) && s.extend1.Equals("116") && s.hdpicid.Equals(tmphid) && s.addtime > t1 && s.addtime < tm2).ToFirstDefault();
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
                                            model.extend1 = "116";
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
                                                nums1 = tmodel.Orders + 5;
                                                tmodel.Orders = tmodel.Orders + 5;
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

        private void UpdQSInfo()
        {
            try
            {
                try
                {
                    var tinfo = _ct.Request.Form["tinfo"];
                    if (string.IsNullOrEmpty(tinfo))
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "没有竞猜值", result = "", count = 0 });
                        _ct.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        var tlist = tinfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        string tsd = _ct.Request.UrlReferrer.Host;
                        var std1 = _ct.Request.UserHostAddress;
                        foreach (var item in tlist)
                        {
                            var tdetal = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            var txmid = Convert.ToInt32(tdetal[1]);
                            var str = 0;
                            ProcSection proc = DbSession.Default.FromProc("p_UpdateQSJg")
                                .AddInParameter("cid", DbType.Int32, txmid)
                                .AddInParameter("jg", DbType.String, tdetal[2])
                                .AddInParameter("jf", DbType.Int32, Convert.ToInt32(WebConfigurationManager.AppSettings["curjf"]))
                                .AddOutParameter("return", DbType.Int32);
                            int tid = proc.ExecuteNonQuery();
                            Dictionary<string, object> returnValue = proc.GetReturnValues();
                            foreach (KeyValuePair<string, object> kv in returnValue)
                            {
                                object creturn = kv.Value;
                            }
                        }
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "数据更新成功", result = "", count = 1 });
                        _ct.Response.Write(jsonstrlist);
                    }
                }
                catch (Exception ex)
                {
                    string st = ex.Message;
                }
                finally
                {
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = "", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
        }

        private void GetYHlist()
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
              .Where(s => s.Extend2.Equals("115"))
              .OrderBy(HdPic._.Orders.Desc, HdPic._.UpdateTime.Asc);
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

        private void GetMyJc()
        {
            var topid1 = Common.CryptHelper.DESEncrypt.Decrypt(Dos.Common.CookieHelper.Get("curYHJCAes1"), WebConfigurationManager.AppSettings["PassWordKey"]);
            FromSection<HdPicHit> fromsection = DbSession.Default.From<HdPicHit>()
             .Where(s => s.wxopenid.Equals(topid1) && s.extend1.Equals("115")).OrderBy(HdPicHit._.addtime.Desc);
            var list = fromsection.Page(30, 1).ToList();
            List<object> listDesc = new List<object>();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    listDesc.Add(new
                    {
                        id = item.Id,
                        sjd = item.extend2,
                        jc = item.name,
                        sy = item.status
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

        private void GetQSJG()
        {
            FromSection<Activity> fromsection = DbSession.Default.From<Activity>()
             .Where(s => s.Status.Equals(2) && s.Type.Equals(10)).OrderBy(Activity._.UpdateTime.Desc);
            var list = fromsection.Page(30, 1).ToList();
            List<object> listDesc = new List<object>();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    listDesc.Add(new
                    {
                        id = item.ID,
                        sjd = item.Title,
                        gj = item.Entitle,
                        img = item.Conver,
                        sb = item.Extend
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
        /// 添加竞猜信息
        /// </summary>
        private void AddJCInfo()
        {
            try
            {
                var da1 = Convert.ToDateTime("09:00");
                var da2 = Convert.ToDateTime("21:00");
                var curdat = DateTime.Now;
                if (curdat > da1 && curdat < da2)
                {
                    var topid1 = Common.CryptHelper.DESEncrypt.Decrypt(Dos.Common.CookieHelper.Get("curYHJCAes1"), WebConfigurationManager.AppSettings["PassWordKey"]);
                    var tinfo = _ct.Request.Form["tinfo"];
                    if (string.IsNullOrEmpty(tinfo))
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "没有竞猜值", result = "", count = 0 });
                        _ct.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        var tlist = tinfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        string tsd = _ct.Request.UrlReferrer.Host;
                        var std1 = _ct.Request.UserHostAddress;
                        foreach (var item in tlist)
                        {
                            var tdetal = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            var txmid = Convert.ToInt32(tdetal[1]);
                            HdPicHit model = DbSession.Default.From<HdPicHit>().Where(s => s.wxopenid.Equals(topid1) && s.extend1.Equals("115") && s.hdpicid.Equals(txmid)).ToFirstDefault();
                            if (model.Id > 0)
                            {
                            }
                            else
                            {
                                model = new HdPicHit();
                                model.Attach();
                                model.addtime = DateTime.Now;
                                model.updatetime = DateTime.Now;
                                model.extend1 = "115";
                                model.extend2 = tdetal[0];
                                model.orders = 0;
                                model.status = 0;//2 竞猜错误 1竞猜成功
                                model.wxopenid = topid1;
                                model.name = tdetal[2];
                                model.hdpicid = txmid;
                                int returnValue = DbSession.Default.Insert<HdPicHit>(model);
                            }
                        }
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "竞猜成功", result = "", count = 2 });
                        _ct.Response.Write(jsonstrlist);
                    }
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "当前时间不允许竞猜", result = "", count = 3 });
                    _ct.Response.Write(jsonstrlist);
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = "", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }

        }

        private void GetXMList()
        {
            FromSection<Activity> fromsection = DbSession.Default.From<Activity>()
              .Where(s => s.Status.Equals(0) && s.Type.Equals(10));
            var list = fromsection.Page(10, 1).ToList();
            List<object> listDesc = new List<object>();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    listDesc.Add(new
                    {
                        id = item.ID,
                        sjd = item.Title,
                        gj = item.Entitle,
                        img = item.Conver,
                        sb = item.Extend
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

        private void AddBmInfo()
        {
            try
            {
                var topid1 = Common.CryptHelper.DESEncrypt.Decrypt(Dos.Common.CookieHelper.Get("curYHJCAes1"), WebConfigurationManager.AppSettings["PassWordKey"]);
                var tname = _ct.Request.Form["tname"];
                var tphone = _ct.Request.Form["tphone"];
                var tpicurl = Dos.Common.CookieHelper.Get("curYHJCImgUrl");
                var tpnickname = Dos.Common.CookieHelper.Get("curYHJCName");
                var tmodel = DbSession.Default.From<Dos.Model.HdPic>().Where(s => s.Extend2.Equals("115") && s.Extend1.Equals(topid1)).ToFirstDefault();
                if (tmodel.Id > 0)
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "不能重复提交数据", result = null, count = 1 });
                    _ct.Response.Write(jsonstrlist);
                }
                else
                {
                    var tmo = DbSession.Default.From<Dos.Model.HdPic>().Where(t => t.Extend4.Equals(tphone) && t.Extend2.Equals("115")).ToFirstDefault();
                    if (tmo.Id > 0)
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "该手机号码已存在,请重新输入", result = null, count = 3 });
                        _ct.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        var tid = DbSession.Default.From<Dos.Model.HdPic>().Where(s => s.Extend2.Equals("115")).Count();
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
                            Extend2 = "115",
                            Extend3 = tname,
                            Extend4 = tphone
                        };
                        int ti = DbSession.Default.Insert<Dos.Model.HdPic>(tmodel);
                        var stopnum = DbSession.Default.FromSql("select row from (select row_number() over (order by orders desc,updatetime asc) row,extend1 from hdpic where Extend2='115') newtable where extend1=@extend1").AddInParameter("@extend1", DbType.String, topid1).ToScalar() + "";
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}