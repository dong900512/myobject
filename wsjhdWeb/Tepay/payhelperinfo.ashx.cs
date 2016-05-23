using System;
using System.Web;
using WXEF;
using WX.Utils;
using System.IO;
using System.Collections.Generic;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.TenPayLibV3;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;
using WXEF;
using System.Collections.Generic;
using System.Linq;
using Util;
using WX.Utils;
using System.Xml.Linq;
using System.Web.Configuration;
namespace NewInfoWeb.Tepay
{
    /// <summary>
    /// payhelperinfo 的摘要说明
    /// </summary>
    public class payhelperinfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var type = context.Request.Params["type"];
            switch (type)
            {
                case "AddInfo":
                    AddRoomInfo(context);
                    break;
                case "GetNum":
                    GetNumInfo(context);
                    break;
                default:
                    break;
            }
        }
        protected void GetNumInfo(HttpContext context)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var phone = "18616203362";
                string strsql = "select sum(Number) from oders where mobile=" + phone + " and OrderStatus=1";
                var tmodel = db.Oders.Where(s => s.Mobile.Equals(phone) && s.OrderStatus.Equals(1)).FirstOrDefault();
                if (tmodel != null)
                {
                    int total = db.Oders.Where(s => s.Mobile.Equals(phone) && s.OrderStatus.Equals(1)).Sum(s => s.Number);
                    context.Response.Write(total);
                }
                else
                {
                    context.Response.Write(0);
                }


            }
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="context"></param>
        protected void AddRoomInfo(HttpContext context)
        {
            var uname = WebConfigurationManager.AppSettings["zcname"];//名称

            string appId = WebConfigurationManager.AppSettings["WeixinPay_AppId"].ToString();
            var totalprrc = context.Request.Params["total"];
            var unnum = Convert.ToInt32(context.Request.Params["tnum"]);
            if (context.Request.Cookies["ZCWebDomain"] == null || string.IsNullOrEmpty(context.Request.Cookies["ZCWebDomain"]["useropid"]))
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "用户数据不正确！", result = null, count = 2 });
                context.Response.Write(jsonstrlist);
            }
            else
            {
                var tmpopenid = context.Request.Cookies["ZCWebDomain"]["useropid"];
                var phone = context.Request.Params["phone"];
                var name = context.Request.Params["name"];
                string timeStamp = "";
                string nonceStr = "";
                string packageValue = "";
                string paySign = "";
                string tmpOrderId = string.Empty;
                using (WXDBEntities db = new WXDBEntities())
                {
                    int tmptotals = Convert.ToInt32(Convert.ToDouble(totalprrc) * 100);//总价格

                    var tmodel = db.Oders.Where(s => s.Mobile.Equals(phone) && s.OrderStatus.Equals(1)).FirstOrDefault();
                    var tmotol = 0;
                    if (tmodel != null)
                    {
                        if (tmodel.Extent1.Equals(name))
                        {
                            var ttinfo = db.Oders.Where(s => s.Mobile.Equals(phone) && s.OrderStatus.Equals(1)).FirstOrDefault();
                            if (ttinfo != null)
                            {
                                tmotol = db.Oders.Where(s => s.Mobile.Equals(phone) && s.OrderStatus.Equals(1)).Sum(s => s.Number);
                            }
                            if ((unnum + tmotol) > 20)
                            {
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "你购买的众筹份数已超额，请重新选择数量", result = null, count = 3 });
                                context.Response.Write(jsonstrlist);
                            }
                            else
                            {
                                //追加购买
                                try
                                {
                                    Oders order = new Oders()
                                    {
                                        Title = uname,
                                        OrderId = WebConn.TenPayInfo.PartnerId + DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(4),
                                        Number = unnum,
                                        Mobile = phone,
                                        Soucre = "12",//房间单价格
                                        Remark = WebConfigurationManager.AppSettings["zcname"],//所选房间
                                        AddTime = DateTime.Now,
                                        UpdateTime = DateTime.Now,
                                        OrderStatus = 0,
                                        Status = 0,
                                        Orders = 0,
                                        Extent1 = name,
                                        Extent2 = "",
                                        AddUser = tmpopenid,//订单人
                                        UpdateUser = "",
                                        CheckTime = DateTime.Now,
                                        CheckoutTime = DateTime.Now,
                                        Totals = tmptotals
                                    };
                                    db.Oders.AddObject(order);
                                    db.SaveChanges();
                                    //设置输出参数
                                    //创建支付应答对象
                                    RequestHandler packageReqHandler = new RequestHandler(context);
                                    //初始化
                                    packageReqHandler.Init();
                                    packageReqHandler.SetKey(WebConfigurationManager.AppSettings["WeixinPay_Key"]);

                                    timeStamp = TenPayV3Util.GetTimestamp();
                                    nonceStr = TenPayV3Util.GetNoncestr().ToLower();

                                    //设置package订单参数
                                    packageReqHandler.SetParameter("appid", appId);		            //公众账号ID
                                    packageReqHandler.SetParameter("mch_id", WebConfigurationManager.AppSettings["WeixinPay_PartnerId"]);		    //商户号
                                    packageReqHandler.SetParameter("nonce_str", nonceStr);          //随机字符串
                                    packageReqHandler.SetParameter("body", order.Remark);           //商品描述
                                    packageReqHandler.SetParameter("out_trade_no", order.OrderId);		//商家订单号
                                    packageReqHandler.SetParameter("total_fee", order.Totals.ToString());			    //商品金额,以分为单位(money * 100).ToString()
                                    packageReqHandler.SetParameter("spbill_create_ip", context.Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
                                    packageReqHandler.SetParameter("notify_url", WebConfigurationManager.AppSettings["WeixinPay_TenpayNotify"]);		    //通知的URL
                                    packageReqHandler.SetParameter("trade_type", "JSAPI");	                    //交易类型
                                    packageReqHandler.SetParameter("openid", order.AddUser);//用户Openid
                                    //获取package包
                                    string sign = packageReqHandler.CreateMd5Sign("key", WebConfigurationManager.AppSettings["WeixinPay_Key"]);
                                    packageReqHandler.SetParameter("sign", sign);	                    //sign签名

                                    string data = packageReqHandler.ParseXML();
                                    var result = TenPayV3.Unifiedorder(data);
                                    var res = XDocument.Parse(result);
                                    string prepayId = res.Element("xml").Element("prepay_id").Value;
                                    packageValue = string.Format("prepay_id={0}", prepayId);
                                    //设置支付参数
                                    RequestHandler paySignReqHandler = new RequestHandler(context);
                                    paySignReqHandler.SetParameter("appId", appId);
                                    paySignReqHandler.SetParameter("timeStamp", timeStamp);
                                    paySignReqHandler.SetParameter("nonceStr", nonceStr);
                                    paySignReqHandler.SetParameter("package", string.Format("prepay_id={0}", prepayId));
                                    paySignReqHandler.SetParameter("signType", "MD5");
                                    paySign = paySignReqHandler.CreateMd5Sign("key", WebConfigurationManager.AppSettings["WeixinPay_Key"]);//

                                    List<object> listDesc = new List<object>();
                                    listDesc.Add(new
                                    {
                                        appId = appId,
                                        timeStamp = timeStamp,
                                        nonceStr = nonceStr,
                                        package = packageValue,
                                        paySign = paySign,
                                        orderid = order.OrderId
                                    });
                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                                    context.Response.Write(jsonstrlist);
                                }
                                catch (Exception ex)
                                {
                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = "", count = 0 });
                                    context.Response.Write(jsonstrlist);
                                }
                            }
                        }
                        else
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "用户数据不匹配，不能进行购买！", result = null, count = 3 });
                            context.Response.Write(jsonstrlist);
                        }
                    }
                    else
                    {
                        //新的购买

                        try
                        {
                            Oders order = new Oders()
                            {
                                Title = uname,
                                OrderId = WebConn.TenPayInfo.PartnerId + DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(4),
                                Number = unnum,
                                Mobile = phone,
                                Soucre = "12",//房间单价格
                                Remark = WebConfigurationManager.AppSettings["zcname"],//所选房间
                                AddTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                OrderStatus = 0,
                                Status = 0,
                                Orders = 0,
                                Extent1 = name,
                                Extent2 = "",
                                AddUser = tmpopenid,//订单人
                                UpdateUser = "",
                                CheckTime = DateTime.Now,
                                CheckoutTime = DateTime.Now,
                                Totals = tmptotals
                            };
                            db.Oders.AddObject(order);
                            db.SaveChanges();
                            //设置输出参数
                            //创建支付应答对象
                            RequestHandler packageReqHandler = new RequestHandler(context);
                            //初始化
                            packageReqHandler.Init();
                            packageReqHandler.SetKey(WebConfigurationManager.AppSettings["WeixinPay_Key"]);

                            timeStamp = TenPayV3Util.GetTimestamp();
                            nonceStr = TenPayV3Util.GetNoncestr().ToLower();

                            //设置package订单参数
                            packageReqHandler.SetParameter("appid", appId);//公众账号ID		            
                            packageReqHandler.SetParameter("mch_id", WebConfigurationManager.AppSettings["WeixinPay_PartnerId"]);		    //商户号
                            packageReqHandler.SetParameter("nonce_str", nonceStr);          //随机字符串
                            packageReqHandler.SetParameter("body", order.Remark);           //商品描述
                            packageReqHandler.SetParameter("out_trade_no", order.OrderId);		//商家订单号
                            packageReqHandler.SetParameter("total_fee", order.Totals.ToString());			    //商品金额,以分为单位(money * 100).ToString()
                            packageReqHandler.SetParameter("spbill_create_ip", context.Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
                            packageReqHandler.SetParameter("notify_url", WebConfigurationManager.AppSettings["WeixinPay_TenpayNotify"]);		    //通知的URL
                            packageReqHandler.SetParameter("trade_type", "JSAPI");	                    //交易类型
                            packageReqHandler.SetParameter("openid", order.AddUser);//用户Openid
                            //获取package包
                            string sign = packageReqHandler.CreateMd5Sign("key", WebConfigurationManager.AppSettings["WeixinPay_Key"]);
                            packageReqHandler.SetParameter("sign", sign);	                    //sign签名

                            string data = packageReqHandler.ParseXML();
                            var result = TenPayV3.Unifiedorder(data);
                            var res = XDocument.Parse(result);
                            string prepayId = res.Element("xml").Element("prepay_id").Value;
                            packageValue = string.Format("prepay_id={0}", prepayId);
                            //设置支付参数
                            RequestHandler paySignReqHandler = new RequestHandler(context);
                            paySignReqHandler.SetParameter("appId", appId);
                            paySignReqHandler.SetParameter("timeStamp", timeStamp);
                            paySignReqHandler.SetParameter("nonceStr", nonceStr);
                            paySignReqHandler.SetParameter("package", string.Format("prepay_id={0}", prepayId));
                            paySignReqHandler.SetParameter("signType", "MD5");
                            paySign = paySignReqHandler.CreateMd5Sign("key", WebConfigurationManager.AppSettings["WeixinPay_Key"]);//

                            List<object> listDesc = new List<object>();
                            listDesc.Add(new
                            {
                                appId = appId,
                                timeStamp = timeStamp,
                                nonceStr = nonceStr,
                                package = packageValue,
                                paySign = paySign,
                                orderid = order.OrderId
                            });
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = listDesc, count = listDesc.Count });
                            context.Response.Write(jsonstrlist);
                        }
                        catch (Exception ex)
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = ex.Message, count = 0 });
                            context.Response.Write(jsonstrlist);
                        }
                    }

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