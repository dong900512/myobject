using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXEF;
using WX.Utils;
using System.Web.Configuration;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Text;
using System.IO;
using NewInfoWeb.Appcode;
using System.Threading;
namespace NewInfoWeb.yqh
{
    /// <summary>
    /// helper3 的摘要说明
    /// </summary>
    public class helper3 : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var type = context.Request.Params["type"];
            switch (type)
            {
                case "AddInfo":
                    AddWSJInfo(context);
                    break;
            }
        }

        private void AddWSJInfo(HttpContext context)
        {
            try
            {
                var tname = context.Request.Params["tname"];
                var tphone = context.Request.Params["tphone"];
                var starttime = WebConfigurationManager.AppSettings["starttime3"];
                var endtime = WebConfigurationManager.AppSettings["endtime3"];
                if (context.Request.Cookies["LXKJWebDomain"] == null || string.IsNullOrEmpty(context.Request.Cookies["LXKJWebDomain"]["iswxh"]))
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "非法访问", result = null, count = 2 });
                    context.Response.Write(jsonstrlist);
                }
                else
                {
                    if (string.IsNullOrEmpty(tname) || string.IsNullOrEmpty(tphone))
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "用户信息不正确！", result = null, count = 1 });
                        context.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        if (context.Request.Cookies["LXKJWebDomain"] == null || string.IsNullOrEmpty(context.Request.Cookies["LXKJWebDomain"]["useropid"]))
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "用户数据不正确！", result = null, count = 2 });
                            context.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            if (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) < Convert.ToDateTime(starttime))
                            {
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "活动还未开始！", result = null, count = 2 });
                                context.Response.Write(jsonstrlist);
                                return;
                            }
                            if (DateTime.Now > Convert.ToDateTime(endtime).AddDays(1))
                            {
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "活动已结束，敬请期待下次派发！", result = null, count = 2 });
                                context.Response.Write(jsonstrlist);
                                return;
                            }
                            string str = context.Request.UserHostAddress;


                            using (WXDBEntities db = new WXDBEntities())
                            {
                                var nums = db.Forms.Where(s => s.Extend.Equals(str)).Count();
                                //if (nums >= 3)
                                //{
                                //    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "非法访问", result = null, count = 2 });
                                //    context.Response.Write(jsonstrlist);
                                //    return;
                                //}
                                var modelt = db.Forms.Where(s => s.Name.Equals(tname) && s.Type.Equals(10)).FirstOrDefault();
                                if (string.IsNullOrEmpty(context.Request.UserAgent) || (!context.Request.UserAgent.Contains("MicroMessenger") && !context.Request.UserAgent.Contains("Windows Phone")))
                                {
                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "非法访问", result = null, count = 2 });
                                    context.Response.Write(jsonstrlist);
                                    return;
                                }
                                else if (modelt != null)
                                {
                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "非法访问", result = null, count = 2 });
                                    context.Response.Write(jsonstrlist);
                                    return;
                                }
                                else
                                {
                                    var tmpopid = context.Request.Cookies["LXKJWebDomain"]["useropid"];
                                    var model = db.Forms.Where(s => s.Source.Equals(tmpopid) && s.Type.Equals(10)).FirstOrDefault();
                                    var model1 = db.Forms.Where(s => s.Type.Equals(10) && s.Mobile.Equals(tphone)).FirstOrDefault();
                                    string tmpphone = WebConfigurationManager.AppSettings["phonelist"];
                                    if (model != null || model1 != null)
                                    {
                                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "你已经领取过红包了，不能重复领取！", result = null, count = 3 });
                                        context.Response.Write(jsonstrlist);
                                    }
                                    else
                                    {

                                        string hb = string.Empty;
                                        if (tmpopid.Equals("ox6aVwHK4GSsKHzWzLA7_d-6_THA"))
                                        {
                                            hb = WebConfigurationManager.AppSettings["hbje"];
                                        }
                                        else if (tmpphone.Contains(tphone))
                                        {
                                            hb = "100";
                                        }
                                        else
                                        {
                                            hb = GetSZ();
                                        }

                                        var total = db.Forms.Where(s => s.Type.Equals(10)).Select(s => s.JFCount).Sum();
                                        var totalnum = Convert.ToDouble(WebConfigurationManager.AppSettings["totalHB3"]);
                                        if (total >= totalnum)
                                        {
                                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 4 });
                                            context.Response.Write(jsonstrlist);
                                        }
                                        else
                                        {
                                            if (total + Convert.ToDouble(hb) > totalnum)
                                            {
                                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 5 });
                                                context.Response.Write(jsonstrlist);
                                            }
                                            else
                                            {
                                                string[] tmpinfo = SendHB(context, tmpopid, tname, tphone, hb).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                                if (tmpinfo[0].Equals("1"))
                                                {
                                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包领取成功！", result = null, count = 200 });
                                                    context.Response.Write(jsonstrlist);
                                                }
                                                else
                                                {
                                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包领取失败！", result = null, count = 300 });
                                                    context.Response.Write(jsonstrlist);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = null, count = 0 });
                context.Response.Write(jsonstrlist);

            }
        }
        private string SendHB(HttpContext context, string opid, string name, string phone, string hb)
        {
            #region 设置参数信息

            string mchbillno = DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(28);

            string nonceStr = TenPayV3Util.GetNoncestr();
            RequestHandler packageReqHandler = new RequestHandler(null);

            //设置package订单参数
            packageReqHandler.SetParameter("nonce_str", nonceStr);              //随机字符串
            packageReqHandler.SetParameter("wxappid", WebConfigurationManager.AppSettings["wxappid1"]);		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", WebConfigurationManager.AppSettings["WeixinPay_PartnerId1"]);		  //商户号
            packageReqHandler.SetParameter("mch_billno", mchbillno);                 //填入商家订单号
            packageReqHandler.SetParameter("send_name", WebConfigurationManager.AppSettings["sendname3"]);                 //红包发送者名称
            packageReqHandler.SetParameter("re_openid", opid);                 //接受收红包的用户的openId
            packageReqHandler.SetParameter("total_amount", hb);                //付款金额，单位分
            packageReqHandler.SetParameter("total_num", "1");               //红包发放总人数
            packageReqHandler.SetParameter("wishing", WebConfigurationManager.AppSettings["hbzf3"]);               //红包祝福语
            packageReqHandler.SetParameter("client_ip", context.Request.UserHostAddress);               //调用接口的机器Ip地址
            packageReqHandler.SetParameter("act_name", WebConfigurationManager.AppSettings["hbname3"]);   //活动名称
            packageReqHandler.SetParameter("remark", WebConfigurationManager.AppSettings["hbDesc3"]);   //备注信息
            string sign = packageReqHandler.CreateMd5Sign("key", WebConfigurationManager.AppSettings["WeixinPay_Key1"]);
            packageReqHandler.SetParameter("sign", sign);	                    //签名

            //最新的官方文档中将以下三个字段去除了
            //packageReqHandler.SetParameter("nick_name", "提供方名称");                 //提供方名称
            //packageReqHandler.SetParameter("max_value", "100");                //最大红包金额，单位分
            //packageReqHandler.SetParameter("min_value", "100");                //最小红包金额，单位分


            //发红包需要post的数据
            string data = packageReqHandler.ParseXML();

            //发红包接口地址
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";
            //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
            string cert = WebConfigurationManager.AppSettings["zswz3"];
            //私钥（在安装证书时设置）
            string password = WebConfigurationManager.AppSettings["WeixinPay_PartnerId1"];
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            //调用证书
            X509Certificate2 cer = new X509Certificate2(cert, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
            #endregion
            #region 发起post请求
            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                webrequest.ClientCertificates.Add(cer);
                webrequest.Method = "post";

                byte[] postdatabyte = Encoding.UTF8.GetBytes(data);
                webrequest.ContentLength = postdatabyte.Length;
                Stream stream;
                stream = webrequest.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();

                HttpWebResponse httpWebResponse = (HttpWebResponse)webrequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();
                //using (WXDBEntities db = new WXDBEntities())
                //{
                //    OperateLoginfo mt = new OperateLoginfo()
                //    {
                //        Title = name,
                //        Descs = "返回成功",
                //        AddTime = DateTime.Now,
                //        UpdateTime = DateTime.Now,
                //        Status = 0,
                //        Orders = 0,
                //        Extent1 = "",
                //        Extent2 = "",
                //        LogType = 1
                //    };
                //    db.OperateLoginfo.AddObject(mt);
                //    db.SaveChanges();
                //}
                WxZFData tdata = new WxZFData();
                tdata.FromXml(responseContent);
                string return_code = tdata.GetValue("return_code").ToString();//状态码
                string return_msg = tdata.GetValue("return_msg").ToString();//状态码
                //using (WXDBEntities db = new WXDBEntities())
                //{
                //    OperateLoginfo mt = new OperateLoginfo()
                //    {
                //        Title = name,
                //        Descs = "返回值:" + return_code,
                //        AddTime = DateTime.Now,
                //        UpdateTime = DateTime.Now,
                //        Status = 0,
                //        Orders = 0,
                //        Extent1 = "",
                //        Extent2 = "",
                //        LogType = 1
                //    };
                //    db.OperateLoginfo.AddObject(mt);
                //    db.SaveChanges();
                //}
                var str = string.Empty;
                if ("SUCCESS".Equals(return_code))
                {
                    //string zfsign = tdata.GetValue("sign").ToString();
                    string result_code = tdata.GetValue("result_code").ToString();

                    //using (WXDBEntities db = new WXDBEntities())
                    //{
                    //    //+ "|" + err_code + "|" + err_code_des
                    //    OperateLoginfo mt = new OperateLoginfo()
                    //    {
                    //        Title = name,
                    //        Descs = "返回值:" + result_code,
                    //        AddTime = DateTime.Now,
                    //        UpdateTime = DateTime.Now,
                    //        Status = 0,
                    //        Orders = 0,
                    //        Extent1 = "",
                    //        Extent2 = "",
                    //        LogType = 1
                    //    };
                    //    db.OperateLoginfo.AddObject(mt);
                    //    db.SaveChanges();
                    //}
                    if ("SUCCESS".Equals(result_code))
                    {
                        //红包发送成功！
                        using (WXDBEntities db = new WXDBEntities())
                        {
                            var model = new Forms()
                            {
                                Title = WebConfigurationManager.AppSettings["hbDesc3"],
                                FormType = 0,
                                Name = name,
                                Number = 1,
                                Mobile = phone,
                                Age = 0,
                                Source = opid,
                                Income = "",
                                Remark = "",
                                AddTime = DateTime.Now,
                                Status = 0,
                                Orders = 0,
                                UpdateTime = DateTime.Now,
                                Extend = context.Request.UserHostAddress,
                                Extend2 = "",
                                Type = 10,
                                JFCount = Convert.ToDouble(hb)
                            };
                            db.Forms.AddObject(model);
                            db.SaveChanges();
                        }
                        //加入数据库操作
                        str = "1|发送红包成功";
                    }
                    else
                    {
                        string err_code = tdata.GetValue("err_code").ToString();
                        string err_code_des = tdata.GetValue("err_code_des").ToString();
                        using (WXDBEntities db = new WXDBEntities())
                        {
                            OperateLoginfo mt = new OperateLoginfo()
                            {
                                Title = name,
                                Descs = err_code,
                                AddTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                Status = 0,
                                Orders = 0,
                                Extent1 = "",
                                Extent2 = err_code_des,
                                LogType = 1
                            };
                            db.OperateLoginfo.AddObject(mt);
                            db.SaveChanges();
                        }
                        //红包发送失败
                        str = "2|发送红包失败！";
                    }
                }
                else
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        OperateLoginfo mt = new OperateLoginfo()
                        {
                            Title = name,
                            Descs = return_msg,
                            AddTime = DateTime.Now,
                            UpdateTime = DateTime.Now,
                            Status = 0,
                            Orders = 0,
                            Extent1 = "",
                            Extent2 = "",
                            LogType = 1
                        };
                        db.OperateLoginfo.AddObject(mt);
                        db.SaveChanges();
                    }
                    str = "3|发送红包失败";
                }
                return str;
            }
            catch (Exception ex)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    OperateLoginfo mt = new OperateLoginfo()
                    {
                        Title = name,
                        Descs = ex.Message,
                        AddTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        Status = 0,
                        Orders = 0,
                        Extent1 = "",
                        Extent2 = "",
                        LogType = 5
                    };
                    db.OperateLoginfo.AddObject(mt);
                    db.SaveChanges();
                }
                return "4|获取失败！";
            }
            #endregion
        }

        private string GetSZ()
        {
            double mindouble = Convert.ToDouble(WebConfigurationManager.AppSettings["minhb"]);
            double maxdouble = Convert.ToDouble(WebConfigurationManager.AppSettings["maxhb"]);
            Thread.Sleep(1);
            long tick = DateTime.Now.Ticks;//一个以0.1纳秒为单位的时间戳，18位
            int seed = int.Parse(tick.ToString().Substring(9));
            //double.Format("{0:#.00}",
            Random rd = new Random(seed);
            //return string.Format("{0:#.00}",
            return Convert.ToDouble((rd.NextDouble() * (maxdouble - mindouble) + mindouble).ToString("f2")) * 100 + "";
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
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