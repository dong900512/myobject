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
namespace NewInfoWeb.yshb
{
    /// <summary>
    /// helper 的摘要说明
    /// </summary>
    public class helper : IHttpHandler, IRequiresSessionState
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
            }
        }
        private void FhbInfo()
        {
            try
            {
                var stopid = _context.Request.Form["tid"];
                var sjd = _context.Request.Form["sjd"];
                var starttime = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime5"]);
                var endtime = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime5"]);
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

                            //判断红包数量
                            var jpmodel = db.PicType.Where(s => s.Orders > 0 && s.Extend.Equals("1")).FirstOrDefault();
                            if (jpmodel != null)
                            {
                                var hbnum = db.Oders.Where(s => s.Extent1.Equals(sjd)).Count();
                                if (hbnum >= 39)
                                {
                                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "当前红包已领完，请明天继续", result = null, count = 1 });
                                    _context.Response.Write(jsonstrlist);
                                }
                                else
                                {
                                    var tmodel = db.Oders.Where(s => s.Soucre.Equals(stopid) && s.Extent1.Equals(sjd)).FirstOrDefault();
                                    if (tmodel != null)
                                    {
                                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "你已经领取过红包了，不能重复领取！", result = null, count = 3 });
                                        _context.Response.Write(jsonstrlist);
                                    }
                                    else
                                    {
                                        string hb = string.Empty;
                                        int ti = Get() + 1;
                                        var model1 = db.PicType.Where(s => s.Status.Equals(ti) && s.Orders > 0 && s.Extend.Equals("1")).FirstOrDefault();

                                        if (model1 != null)
                                        {
                                            model1.Orders = model1.Orders - 1;
                                            hb = Convert.ToInt32(model1.Title) * 100 + "";
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            jpmodel.Orders = jpmodel.Orders - 1;
                                            hb = Convert.ToInt32(jpmodel.Title) * 100 + "";
                                            db.SaveChanges();
                                        }
                                        string[] tmpinfo = SendHB(stopid, sjd, hb).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
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
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "当前红包已领完，请明天继续", result = null, count = 1 });
                                _context.Response.Write(jsonstrlist);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = null, count = 0 });
                _context.Response.Write(jsonstrlist);
            }
        }

        private string SendHB(string opid, string stid, string hb)
        {
            #region 设置参数信息

            string mchbillno = DateTime.Now.ToString("HHmmss") + TenPayV3Util.BuildRandomStr(28);
            string nonceStr = TenPayV3Util.GetNoncestr();
            RequestHandler packageReqHandler = new RequestHandler(null);

            //设置package订单参数
            packageReqHandler.SetParameter("nonce_str", nonceStr);              //随机字符串
            packageReqHandler.SetParameter("wxappid", WebConfigurationManager.AppSettings["wxappid5"]);		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", WebConfigurationManager.AppSettings["WeixinPay_PartnerId5"]);		  //商户号
            packageReqHandler.SetParameter("mch_billno", mchbillno);                 //填入商家订单号
            packageReqHandler.SetParameter("send_name", WebConfigurationManager.AppSettings["sendname5"]);                 //红包发送者名称
            packageReqHandler.SetParameter("re_openid", opid);                 //接受收红包的用户的openId
            packageReqHandler.SetParameter("total_amount", hb);                //付款金额，单位分
            packageReqHandler.SetParameter("total_num", "1");               //红包发放总人数
            packageReqHandler.SetParameter("wishing", WebConfigurationManager.AppSettings["hbzf5"]);               //红包祝福语
            packageReqHandler.SetParameter("client_ip", _context.Request.UserHostAddress);               //调用接口的机器Ip地址
            packageReqHandler.SetParameter("act_name", WebConfigurationManager.AppSettings["hbname5"]);   //活动名称
            packageReqHandler.SetParameter("remark", WebConfigurationManager.AppSettings["hbDesc5"]);   //备注信息
            string sign = packageReqHandler.CreateMd5Sign("key", WebConfigurationManager.AppSettings["WeixinPay_Key5"]);
            packageReqHandler.SetParameter("sign", sign);	                    //签名
            //发红包需要post的数据
            string data = packageReqHandler.ParseXML();
            //发红包接口地址
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";
            //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
            string cert = WebConfigurationManager.AppSettings["zswz5"];
            //私钥（在安装证书时设置）
            string password = WebConfigurationManager.AppSettings["WeixinPay_PartnerId5"];
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

                WxZFData tdata = new WxZFData();
                tdata.FromXml(responseContent);
                string return_code = tdata.GetValue("return_code").ToString();//状态码
                string return_msg = tdata.GetValue("return_msg").ToString();//状态码

                var str = string.Empty;
                if ("SUCCESS".Equals(return_code))
                {
                    string result_code = tdata.GetValue("result_code").ToString();
                    if ("SUCCESS".Equals(result_code))
                    {
                        //红包发送成功！
                        using (WXDBEntities db = new WXDBEntities())
                        {
                            var model = new Oders()
                            {
                                Title = WebConfigurationManager.AppSettings["hbDesc5"],
                                OrderId = "1233445",
                                Number = 1,
                                Mobile = "",
                                Soucre = opid,
                                Remark = "",
                                AddTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                UpdateUser = "admin",
                                OrderStatus = 0,
                                Status = 0,
                                Orders = 0,
                                Extent1 = stid,
                                Extent2 = "",
                                AddUser = "",
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
                                Title = "燕山一號红包",
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
                            Title = "燕山一號红包",
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
                        Title = "燕山一號红包",
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
        private static int Get()
        {
            float[] prob = new float[6];
            prob[0] = float.Parse("1.5");
            prob[1] = float.Parse("1");
            prob[2] = float.Parse("1");
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