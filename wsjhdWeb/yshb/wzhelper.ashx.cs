using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WX.Utils;
using System.Web.Configuration;
using WXEF;
using Senparc.Weixin.MP.TenPayLibV3;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using NewInfoWeb.Appcode;
using System.Threading;

namespace NewInfoWeb.yshb
{
    /// <summary>
    /// wzhelper 的摘要说明
    /// </summary>
    public class wzhelper : IHttpHandler
    {
        protected HttpContext _context;
        public void ProcessRequest(HttpContext context)
        {
            _context = context;
            context.Response.ContentType = "text/plain";
            var type = _context.Request.Form["type"];
            switch (type)
            {
                case "fhb":
                    FhbInfo();
                    break;
                case "czcjnum":
                    CzNum();
                    break;
                case "upjfinfo":
                    UpWzStats();
                    break;
            }
        }
        private void UpWzStats()
        {
            try
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var topid = _context.Request.Form["topid"];
                    var tm1 = DateTime.Now.Date;
                    var tm2 = DateTime.Now.Date.AddDays(1);
                    var tmodel = db.Oders.Where(s => s.Soucre.Equals(topid) && s.Extent1.Equals("65") && s.AddTime > tm1 && s.AddTime < tm2).OrderBy(s => s.AddTime).FirstOrDefault();
                    if (tmodel != null)
                    {
                        if (tmodel.Status.Equals(1))
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "4", result = "0", count = 2 });
                            _context.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            tmodel.Status = 1;
                            db.SaveChanges();
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "4", result = "0", count = 1 });
                            _context.Response.Write(jsonstrlist);
                        }
                    }
                    else
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "4", result = "0", count = 2 });
                        _context.Response.Write(jsonstrlist);
                    }
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "4", result = "0", count = 0 });
                _context.Response.Write(jsonstrlist);
            }
        }
        private void CzNum()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                try
                {
                    //var strsql = "";
                    var strsql = new StringBuilder();
                    strsql.Append("update effect set Orders=60  where Status=1 ");
                    strsql.Append("update effect set Orders=50  where Status=2 ");
                    strsql.Append("update effect set Orders=30  where Status=3 ");
                    strsql.Append("update effect set Orders=25  where Status=4 ");
                    strsql.Append("update effect set Orders=20  where Status=5 ");
                    strsql.Append("update effect set Orders=15  where Status=6 ");
                    strsql.Append("update effect set Orders=9  where Status=7 ");
                    strsql.Append("update effect set Orders=5  where Status=8 ");
                    db.ExecuteStoreCommand(strsql.ToString());
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "", result = "", count = 1 });
                    _context.Response.Write(jsonstrlist);
                }
                catch (Exception ext)
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ext.Message, result = "", count = 0 });
                    _context.Response.Write(jsonstrlist);
                }
            }
        }
        private void FhbInfo()
        {
            //string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 4 });
            //_context.Response.Write(jsonstrlist);
            //return;
            try
            {
                var stopid = _context.Request.Form["tid"];
                var sjd = _context.Request.Form["sjd"];
                var uname = _context.Request.Form["nickname"];
                var picurl = _context.Request.Form["picurl"];
                var cursjd = _context.Request.Form["cursjd"];
                var starttime = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime8"]);
                var endtime = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime8"]);
                //using (WXDBEntities db = new WXDBEntities())
                //{
                //    var curtotalnum = db.Oders.Where(s => s.Extent1.Equals("65") && s.AddUser.Equals(cursjd) && s.AddTime > starttime && s.AddTime < endtime).Select(s => s.Totals).Sum();
                //    int ti = Convert.ToInt32(curtotalnum);
                //    //if (Convert.ToInt32(curtotalnum) >= Convert.ToInt32(totalnum))
                //    //{
                //    //    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 4 });
                //    //    _context.Response.Write(jsonstrlist);
                //    //}
                //}
                //
                //cursjd.Equals("2") && DateTime.Now.Hour >= 14 && span < end
                DateTime now = DateTime.Now;
                TimeSpan span = now.TimeOfDay;
                TimeSpan end = new TimeSpan(15, 0, 0);
                TimeSpan end1 = new TimeSpan(12, 0, 0);
                if (cursjd.Equals("1") && DateTime.Now.Hour >= 11 && span < end1)
                {
                    if (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) < Convert.ToDateTime(starttime))
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "活动还未开始！", result = null, count = 2 });
                        _context.Response.Write(jsonstrlist);
                    }
                    else if (DateTime.Now > Convert.ToDateTime(endtime).AddDays(1))
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "活动已结束，敬请期待下次派发！", result = null, count = 2 });
                        _context.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        string str = _context.Request.UserHostAddress;
                        if (string.IsNullOrEmpty(_context.Request.UserAgent) || (!_context.Request.UserAgent.Contains("MicroMessenger") && !_context.Request.UserAgent.Contains("Windows Phone")))
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "非法访问", result = null, count = 2 });
                            _context.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            using (WXDBEntities db = new WXDBEntities())
                            {
                                string hb = GetSZ();
                                var tm1 = DateTime.Now.Date;
                                var tm2 = DateTime.Now.Date.AddDays(1);
                                var curmodel = db.Oders.Where(s => s.Soucre.Equals(stopid) && s.Extent1.Equals("65") && s.AddTime > tm1 && s.AddTime < tm2).OrderBy(s => s.AddTime).FirstOrDefault();
                                var trcount = db.Oders.Where(s => s.Soucre.Equals(stopid) && s.Extent1.Equals("65") && s.AddTime > tm1 && s.AddTime < tm2).Count();
                                var totalnum = Convert.ToInt32(WebConfigurationManager.AppSettings["totalHB8"]);
                                if (trcount >= 2)
                                {
                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "你的红包已领完,请明天继续！", result = null, count = 4 });
                                    _context.Response.Write(jsonstrlist);
                                }
                                else
                                {
                                    if (curmodel != null)
                                    {
                                        if (curmodel.Status.Equals(1))
                                        {
                                            var td = DateTime.Now.Date;
                                            var td1 = DateTime.Now.Date.AddDays(1);
                                            var curtotalnum = db.Oders.Where(s => s.Extent1.Equals("65") && s.AddUser.Equals(cursjd) && s.AddTime > td && s.AddTime < td1).Select(s => s.Totals).Sum();
                                            if (Convert.ToInt32(curtotalnum) >= totalnum)
                                            {
                                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 4 });
                                                _context.Response.Write(jsonstrlist);
                                            }
                                            else
                                            {
                                                if ((Convert.ToInt32(curtotalnum) + Convert.ToInt32(hb)) > totalnum)
                                                {
                                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 5 });
                                                    _context.Response.Write(jsonstrlist);
                                                }
                                                else
                                                {
                                                    string[] tmpinfo = SendHB(stopid, sjd, hb, cursjd).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                                    if (tmpinfo[0].Equals("1"))
                                                    {
                                                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = tmpinfo[2], result = null, count = 200 });
                                                        _context.Response.Write(jsonstrlist);
                                                    }
                                                    else
                                                    {
                                                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包领取失败！", result = null, count = 300 });
                                                        _context.Response.Write(jsonstrlist);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "你已经领取过红包了，不能重复领取！", result = null, count = 3 });
                                            _context.Response.Write(jsonstrlist);
                                        }
                                    }
                                    else
                                    {
                                        var td = DateTime.Now.Date;
                                        var td1 = DateTime.Now.Date.AddDays(1);
                                        var curtotalnum = db.Oders.Where(s => s.Extent1.Equals("65") && s.AddUser.Equals(cursjd) && s.AddTime > td && s.AddTime < td1).Select(s => s.Totals).Sum();
                                        if (Convert.ToInt32(curtotalnum) >= totalnum)
                                        {
                                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 4 });
                                            _context.Response.Write(jsonstrlist);
                                        }
                                        else
                                        {
                                            if ((Convert.ToInt32(curtotalnum) + Convert.ToInt32(hb)) > totalnum)
                                            {
                                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包已领完。", result = null, count = 5 });
                                                _context.Response.Write(jsonstrlist);
                                            }
                                            else
                                            {
                                                string[] tmpinfo = SendHB(stopid, sjd, hb, cursjd).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                                if (tmpinfo[0].Equals("1"))
                                                {
                                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = tmpinfo[2], result = null, count = 200 });
                                                    _context.Response.Write(jsonstrlist);
                                                }
                                                else
                                                {
                                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "红包领取失败！", result = null, count = 600 });
                                                    _context.Response.Write(jsonstrlist);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "请从正规渠道访问1！", result = null, count = 2 });
                    _context.Response.Write(jsonstrlist);
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = null, count = 0 });
                _context.Response.Write(jsonstrlist);
            }
        }
        private string GetSZ()
        {
            double mindouble = Convert.ToDouble(WebConfigurationManager.AppSettings["minhb8"]);
            double maxdouble = Convert.ToDouble(WebConfigurationManager.AppSettings["maxhb8"]);
            Thread.Sleep(1);
            long tick = DateTime.Now.Ticks;//一个以0.1纳秒为单位的时间戳，18位
            int seed = int.Parse(tick.ToString().Substring(9));
            //double.Format("{0:#.00}",
            Random rd = new Random(seed);
            //return string.Format("{0:#.00}",
            return Convert.ToDouble((rd.NextDouble() * (maxdouble - mindouble) + mindouble).ToString("f2")) * 100 + "";
        }
        private string SendHB(string opid, string stid, string hb, string cursjd)
        {
            var str = string.Empty;
            DateTime now = DateTime.Now;
            TimeSpan span = now.TimeOfDay;
            TimeSpan end = new TimeSpan(15, 0, 0);
            TimeSpan end1 = new TimeSpan(12, 0, 0);
            //cursjd.Equals("1") || 
            //cursjd.Equals("1") && DateTime.Now.Hour >= 11 && span < end1
            //cursjd.Equals("2") && DateTime.Now.Hour >= 14 && span < end
            if (cursjd.Equals("1") && DateTime.Now.Hour >= 11 && span < end1)
            {
                #region 设置参数信息
                try
                {
                    string mchbillno = DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(28);
                    string nonceStr = TenPayV3Util.GetNoncestr();
                    RequestHandler packageReqHandler = new RequestHandler(null);

                    //设置package订单参数
                    packageReqHandler.SetParameter("nonce_str", nonceStr);              //随机字符串
                    packageReqHandler.SetParameter("wxappid", WebConfigurationManager.AppSettings["wxappid8"]);		  //公众账号ID
                    packageReqHandler.SetParameter("mch_id", WebConfigurationManager.AppSettings["WeixinPay_PartnerId8"]);		  //商户号
                    packageReqHandler.SetParameter("mch_billno", mchbillno);                 //填入商家订单号
                    packageReqHandler.SetParameter("send_name", WebConfigurationManager.AppSettings["sendname8"]);                 //红包发送者名称
                    packageReqHandler.SetParameter("re_openid", opid);                 //接受收红包的用户的openId
                    packageReqHandler.SetParameter("total_amount", hb);                //付款金额，单位分
                    packageReqHandler.SetParameter("total_num", "1");               //红包发放总人数
                    packageReqHandler.SetParameter("wishing", WebConfigurationManager.AppSettings["hbzf8"]);               //红包祝福语
                    packageReqHandler.SetParameter("client_ip", _context.Request.UserHostAddress);               //调用接口的机器Ip地址
                    packageReqHandler.SetParameter("act_name", WebConfigurationManager.AppSettings["hbname8"]);   //活动名称
                    packageReqHandler.SetParameter("remark", WebConfigurationManager.AppSettings["hbDesc8"]);   //备注信息
                    string sign = packageReqHandler.CreateMd5Sign("key", WebConfigurationManager.AppSettings["WeixinPay_Key8"]);
                    packageReqHandler.SetParameter("sign", sign);	                    //签名
                    //发红包需要post的数据
                    string data = packageReqHandler.ParseXML();
                    //发红包接口地址
                    string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";
                    //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
                    string cert = WebConfigurationManager.AppSettings["zswz8"];
                    //私钥（在安装证书时设置）
                    string password = WebConfigurationManager.AppSettings["WeixinPay_PartnerId8"];
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    //调用证书
                    X509Certificate2 cer = new X509Certificate2(cert, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                #endregion
                    #region 发起post请求

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

                    WxZFData tdata = new WxZFData();
                    tdata.FromXml(responseContent);
                    string return_code = tdata.GetValue("return_code").ToString();//状态码
                    string return_msg = tdata.GetValue("return_msg").ToString();//状态码


                    string result_code = tdata.GetValue("result_code").ToString().ToUpper();
                    if ("SUCCESS".Equals(return_code))
                    {
                        //using (WXDBEntities db = new WXDBEntities())
                        //{
                        //    OperateLoginfo mt = new OperateLoginfo()
                        //    {
                        //        Title = "五洲国际红包",
                        //        Descs = "进入",
                        //        AddTime = DateTime.Now,
                        //        UpdateTime = DateTime.Now,
                        //        Status = 0,
                        //        Orders = 0,
                        //        Extent1 = return_msg,
                        //        Extent2 = result_code,
                        //        LogType = 0
                        //    };
                        //    db.OperateLoginfo.AddObject(mt);
                        //    db.SaveChanges();
                        //}

                        if ("SUCCESS".Equals(result_code))
                        {
                            //红包发送成功！
                            using (WXDBEntities db = new WXDBEntities())
                            {
                                //OperateLoginfo mt = new OperateLoginfo()
                                //{
                                //    Title = "五洲国际红包",
                                //    Descs = stid,
                                //    AddTime = DateTime.Now,
                                //    UpdateTime = DateTime.Now,
                                //    Status = 0,
                                //    Orders = 0,
                                //    Extent1 = "",
                                //    Extent2 = cursjd,
                                //    LogType = 0
                                //};
                                //db.OperateLoginfo.AddObject(mt);
                                //db.SaveChanges();
                                var model = new Oders()
                                {
                                    OrderId = mchbillno,
                                    Title = "五洲红包",
                                    Number = 1,
                                    Mobile = "",
                                    Soucre = opid,
                                    Remark = "345",
                                    AddTime = DateTime.Now,
                                    UpdateTime = DateTime.Now,
                                    OrderStatus = 0,
                                    Status = 0,
                                    Orders = 0,
                                    Extent1 = stid,
                                    Extent2 = "789",
                                    AddUser = cursjd,
                                    UpdateUser = "admin",
                                    CheckTime = DateTime.Now,
                                    CheckoutTime = DateTime.Now,
                                    Totals = Convert.ToInt32(hb)
                                };
                                db.Oders.AddObject(model);
                                db.SaveChanges();
                            }
                            //加入数据库操作
                            str = "1|发送红包成功|" + hb;
                        }
                        else
                        {
                            string err_code = tdata.GetValue("err_code").ToString();
                            string err_code_des = tdata.GetValue("err_code_des").ToString();
                            using (WXDBEntities db = new WXDBEntities())
                            {
                                OperateLoginfo mt = new OperateLoginfo()
                                {
                                    Title = "五洲国际红包",
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
                                Title = "五洲国际红包",
                                Descs = return_msg,
                                AddTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                Status = 0,
                                Orders = 0,
                                Extent1 = "",
                                Extent2 = "",
                                LogType = 2
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
                            Title = "五洲国际红包",
                            Descs = ex.Message,
                            AddTime = DateTime.Now,
                            UpdateTime = DateTime.Now,
                            Status = 0,
                            Orders = 0,
                            Extent1 = hb,
                            Extent2 = "",
                            LogType = 6
                        };
                        db.OperateLoginfo.AddObject(mt);
                        db.SaveChanges();
                    }
                    return "4|获取失败！";
                }
            }
            else
            {
                str = "2|发送红包失败！";
                return str;
            }
                    #endregion
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }
        private static Random rnd = new Random();
        /// <summary>
        /// 获取抽奖结果
        /// </summary>
        /// <param name="prob">各物品的抽中概率</param>
        /// <returns>返回抽中的物品所在数组的位置</returns>
        private static int GetlottNum()
        {
            float[] prob = new float[8];
            prob[0] = float.Parse("1");
            prob[1] = float.Parse("1");
            prob[2] = float.Parse("1");
            prob[3] = float.Parse("1");
            prob[4] = float.Parse("1");
            prob[5] = float.Parse("1");
            prob[6] = float.Parse("0.9");
            prob[7] = float.Parse("0.8");
            int result = 0;
            int n = (int)(prob.Sum() * 1000);           //计算概率总和，放大1000倍
            Random r = rnd;
            System.Threading.Thread.Sleep(1);
            float x = (float)r.Next(0, n) / 1000;       //随机生成0~概率总和的数字
            for (int i = 0; i < prob.Count(); i++)
            {
                float pre = prob.Take(i).Sum();         //区间下界
                float next = prob.Take(i + 1).Sum();    //区间上界
                if (x >= pre && x < next)               //如果在该区间范围内，就返回结果退出循环
                {
                    result = i;
                    break;
                }
            }
            return result;
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