using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXEF;
using WX.Utils;

namespace NewInfoWeb.ashx
{
    /// <summary>
    /// yhqdh 的摘要说明
    /// </summary>
    public class yhqdh : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var type = context.Request.Params["type"];
            switch (type)
            {
                case "AddYhq":
                    AddYhQinfo(context);
                    break;
                case "YHQList":
                    GetYHQList(context);
                    break;
                case "cjinfo":
                    CJinfo(context);
                    break;
                case "CYInfo":
                    GetCYList(context);
                    break;
                case "AddCY":
                    AddCyInfo(context);
                    break;
                case "RoomInfo":
                    GetRoomInfo(context);
                    break;
                default:
                    break;
            }
        }
        protected void GetRoomInfo(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpopid"];
            int page = 0;
            int pagesize = 20;

            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;

            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;
                var newslit = db.Oders.Where(s => s.OrderStatus == 1 && s.AddUser == tmpopid).OrderBy(s => s.Orders).ThenByDescending(s => s.AddTime).Skip(skipsize).Take(pagesize).ToList();//房间预定信息
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            title = item.Remark,
                            num = item.Number,
                            startime = item.Extent1,
                            endtime = item.Extent2
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
        /// <summary>
        /// 添加餐饮预定信息
        /// </summary>
        /// <param name="context"></param>
        protected void AddCyInfo(HttpContext context)
        {
            var tmpopid = context.Request.Params["sourcid"];
            var tmptitle = context.Request.Params["title"];
            var tmpremark = context.Request.Params["Remak"];
            var tmpname = context.Request.Params["name"];
            var tmpphone = context.Request.Params["phone"];
            var tmpnums = context.Request.Params["nums"];
            var remark = context.Request.Params["remark"];
            using (WXDBEntities db = new WXDBEntities())
            {
                var models = new Forms()
                {
                    Name = tmpname,
                    Number = Convert.ToInt32(tmpnums),
                    Mobile = tmpphone,
                    Age = 0,
                    Source = tmpopid,
                    Income = "",
                    AddTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    Remark = tmpremark,
                    Status = 0,
                    Orders = 0,
                    FormType = 0,
                    Extend = "",
                    Extend2 = remark,
                    //餐饮预定信息
                    Type = 8,
                    Title = tmptitle,
                    JFCount = 1
                };
                try
                {
                    db.Forms.AddObject(models);
                    db.SaveChanges();
                    context.Response.Write("{\"msg\":\"1\",\"desc\":\"您的预定信息提交成功!\"}");
                    return;
                }
                catch (Exception)
                {
                    context.Response.Write("{\"msg\":\"2\",\"desc\":\"网络错误,预定信息失败!请重新提交！\"}");
                    return;
                }
            }
        }
        /// <summary>
        /// 得到餐饮预定信息
        /// </summary>
        /// <param name="context"></param>
        protected void GetCYList(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpopid"];
            int page = 0;
            int pagesize = 20;

            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;

            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;
                var newslit = db.Forms.Where(s => s.Source == tmpopid && s.Type == 8).OrderBy(s => s.Orders).ThenByDescending(s => s.AddTime).Skip(skipsize).Take(pagesize).ToList();//餐饮预定信息
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            time = item.Remark,
                            dec = item.Title,
                            isuse = item.Number
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
        protected void CJinfo(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpopid"];
            int page = 0;
            int pagesize = 20;
            var lotterids = System.Configuration.ConfigurationManager.AppSettings["lottry1"].ToString();
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;

            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;
                var newslit = db.lotterUserInfo.Where(s => s.OpenId == tmpopid & s.Type == 1).OrderBy(s => s.Orders).ThenByDescending(s => s.AddTime).Skip(skipsize).Take(pagesize).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            time = item.AddTime.ToString("yyyy-MM-dd"),
                            dec = lotterids.Contains(item.PriceNumber.ToString()) ? item.PriceName : "未中奖",
                            isuse = item.Extend3 == "0" ? "未使用" : "已使用",
                            snu = lotterids.Contains(item.PriceNumber.ToString()) ? item.LotterSN : "",

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
        protected void GetYHQList(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpopid"];
            int page = 0;
            int pagesize = 20;
            int.TryParse(context.Request.Params["tmppage"], out page);
            if (page < 1)
                page = 0;

            using (WXDBEntities db = new WXDBEntities())
            {
                int skipsize = page * pagesize;
                var newslit = db.lotterUserInfo.Where(s => s.OpenId == tmpopid && s.Type == 0).OrderBy(s => s.Orders).ThenByDescending(s => s.AddTime).Skip(skipsize).Take(pagesize).ToList();
                List<object> listDesc = new List<object>();
                if (newslit.Count > 0)
                {
                    foreach (var item in newslit)
                    {
                        listDesc.Add(new
                        {
                            time = item.AddTime.ToString("yyyy-MM-dd"),
                            dec = item.lotDesc,
                            isuse = item.Extend3 == "0" ? "未使用" : "已使用",
                            snu = item.LotterSN
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
        protected void AddYhQinfo(HttpContext context)
        {
            var tmpopid = context.Request.Params["tmpopid"];
            var tmpqtype = context.Request.Params["qtype"];
            using (WXDBEntities db = new WXDBEntities())
            {
                var forms = db.Forms.Where(s => s.Type == 6 && s.Source == tmpopid).FirstOrDefault();
                if (forms != null)
                {
                    double xfi = 0f;
                    string desc = string.Empty;
                    switch (tmpqtype)
                    {
                        case "YY":
                            xfi = 210;
                            desc = "游泳优惠券";
                            break;
                        case "MN":
                            xfi = 300;
                            desc = "迷你吧台优惠券";
                            break;
                        case "XWC":
                            xfi = 408;
                            desc = "下午茶优惠券";
                            break;
                    }
                    if ((forms.JFCount - xfi) > 0)
                    {
                        var lotter = new lotterUserInfo();
                        lotter.AddTime = DateTime.Now;
                        lotter.Type = 0;//积分兑换优惠券
                        lotter.OpenId = tmpopid;
                        lotter.lotDesc = desc;
                        lotter.StartTime = DateTime.Now;
                        lotter.LotterNumber = 0;
                        lotter.Updatetime = DateTime.Now;
                        lotter.LotterSN = "yh" + DateTime.Now.ToString("HHmmss") + Senparc.Weixin.MP.TenPayLib.TenPayUtil.BuildRandomStr(4) + "q";
                        lotter.PriceName = "";
                        lotter.PriceNumber = 0;
                        lotter.Extend1 = "";
                        lotter.Extend2 = "";
                        lotter.Status = 0;
                        lotter.Orders = 0;
                        lotter.Extend3 = "0";//是否使用
                        db.lotterUserInfo.AddObject(lotter);
                        UserPoinLog ml = new UserPoinLog()
                        {
                            UserPointDesc = "兑换优惠券消费",
                            WxOpenid = tmpopid,
                            WxNickName = "",
                            PointCode = 7,//兑换优惠券消费
                            AddTime = DateTime.Now,
                            Updatetime = DateTime.Now,
                            Status = 0,
                            Orders = 0,
                            Extent1 = "-" + xfi.ToString(),
                            Extent2 = "",
                            Extent3 = ""
                        };
                        forms.JFCount = forms.JFCount - xfi;
                        db.UserPoinLog.AddObject(ml);
                        db.SaveChanges();
                        //计入lotteruserinfo中
                        context.Response.Write("{\"flag\":\"2\",\"desc\":\"兑换成功,优惠券信息请在我的优惠券中查询！\"}");
                        return;
                    }
                    else
                    {
                        context.Response.Write("{\"flag\":\"1\",\"desc\":\"您当前的积分不足以兑换！\"}");
                        return;
                    }
                }
                else
                {
                    context.Response.Write("{\"flag\":\"0\",\"desc\":\"请注册会员信息或者消费后进行兑换！\"}");
                    return;
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