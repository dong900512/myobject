using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;
using WXEF;
using System.Text;

namespace NewInfoWeb.Tepay
{
    public partial class payNotifyUrl : System.Web.UI.Page
    {
        //private Hashtable Parameters;
        private Hashtable XmlMap;
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info("回调函数", "进入");
            WxPayData infos = GetNotifyData();
            string out_trade_no = infos.GetValue("out_trade_no").ToString();
            //财付通订单号
            string transaction_id = infos.GetValue("transaction_id").ToString();
            //金额,以分为单位
            string total_fee = infos.GetValue("total_fee").ToString();
            ////如果有使用折扣券，discount有值，total_fee+discount=原请求的total_fee
            //string discount = resHandler.GetParameter("discount");
            //支付结果
            string trade_state = infos.GetValue("result_code").ToString();
            string stropid = infos.GetValue("openid").ToString();//openid
            //string total_fee = XmlMap["total_fee"].ToString();//总价格
            //即时到账
            Log.Info("回调函数", trade_state);
            if ("SUCCESS".Equals(trade_state))
            {
                Log.Info("回调函数", "成功");
                //------------------------------
                //处理业务开始
                //------------------------------
                using (WXDBEntities db = new WXDBEntities())
                {
                    string tmpordids = out_trade_no;
                    Oders order = db.Oders.Where(s => s.OrderId == tmpordids && s.OrderStatus != 1).FirstOrDefault();
                    if (order != null)
                    {
                        order.OrderStatus = 1;//支付成功
                        order.UpdateTime = DateTime.Now;
                        OperateLoginfo model = new OperateLoginfo()
                        {
                            Title = "支付成功",
                            Descs = "",
                            AddTime = DateTime.Now,
                            UpdateTime = DateTime.Now,
                            Status = 0,
                            Orders = 0,
                            Extent1 = "",
                            Extent2 = "",
                            LogType = 1 //支付日志
                        };
                        db.OperateLoginfo.AddObject(model);
                        db.SaveChanges();
                    }
                    else
                    {
                        Log.Info("回调函数", "不存在数据");
                    }
                }
                //处理数据库逻辑
                //注意交易单不要重复处理
                //注意判断返回金额
                //------------------------------
                //处理业务完毕
                //------------------------------
                //给财付通系统发送成功信息，财付通系统收到此结果后不再进行后续通知
                Response.Write("success 后台通知成功");
            }
            else
            {
                Log.Info("回调函数", "失败");
                using (WXDBEntities db = new WXDBEntities())
                {
                    OperateLoginfo model = new OperateLoginfo()
                    {
                        Title = "支付失败",
                        Descs = out_trade_no,
                        AddTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        Status = 0,
                        Orders = 0,
                        Extent1 = "",
                        Extent2 = "",
                        LogType = 2 //支付日志
                    };
                    db.OperateLoginfo.AddObject(model);
                    db.SaveChanges();
                }
                Response.Write("支付失败");
            }
            //回复服务器处理成功
            Response.Write("success");
        }
        public WxPayData GetNotifyData()
        {
            Log.Info("获取数据测试", "回调函数");
            //接收从微信后台POST过来的数据
            System.IO.Stream s = Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            Log.Info(this.GetType().ToString(), "Receive data from WeChat : " + builder.ToString());

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                Log.Error(this.GetType().ToString(), "Sign check error : " + res.ToXml());
                Response.Write(res.ToXml());
                Response.End();
            }
            Log.Info(this.GetType().ToString(), "Check sign success");
            return data;
        }
    }
}