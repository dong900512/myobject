using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXEF;
using WX.Utils;

using System.IO;
using System.Web.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using System.Diagnostics;
using System.Drawing;
using System.Text;
namespace NewInfoWeb.lnInfo
{
    /// <summary>
    /// lnlotter 的摘要说明
    /// </summary>
    public class lnlotter : IHttpHandler
    {

        protected HttpContext _ct;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _ct = context;
            var type = _ct.Request.Form["type"];
            switch (type)
            {
                case "cj":
                    CJInfo();
                    break;
                case "tjinfo":
                    UpTjInfo();
                    break;
            }
        }

        private void UpTjInfo()
        {
            try
            {
                string stropid = Common.CryptHelper.DESEncrypt.Decrypt(Dos.Common.CookieHelper.Get("curlnLotAre"), WebConfigurationManager.AppSettings["PassWordKey"]);
                string tname = _ct.Request.Form["tname"];
                string tphone = _ct.Request.Form["tphone"];
                using (WXDBEntities db = new WXDBEntities())
                {
                    var mod1 = db.Forms.Where(s => s.Source.Equals(stropid) && s.Type.Equals(95)).FirstOrDefault();
                    if (mod1 != null)
                    {
                        mod1.Name = tname; mod1.Mobile = tphone;
                        db.SaveChanges();
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "提交成功！", result = "用户信息出错", count = 1 });
                        _ct.Response.Write(jsonstrlist);
                    }
                    else
                    {
                        string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "不存在用户信息", result = "用户信息出错", count = 2 });
                        _ct.Response.Write(jsonstrlist);
                    }
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = ex.Message, result = "用户信息出错", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
        }

        private void CJInfo()
        {
            string jsonstrlist = string.Empty;

            try
            {
                string stropid = Common.CryptHelper.DESEncrypt.Decrypt(Dos.Common.CookieHelper.Get("curlnLotAre"), WebConfigurationManager.AppSettings["PassWordKey"]);
                DateTime t1 = DateTime.Now;
                DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime18"]);
                DateTime t3 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime18"]);
                DateTime t4 = DateTime.Now.Date;
                DateTime t5 = t4.AddDays(1);
                if (DateTime.Compare(t1, t2) > 0 && DateTime.Compare(t1, t3) < 0)
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        var countnum = db.Forms.Where(s => s.Status.Equals(1) && s.Type.Equals(95)).Count();
                        var mod1 = db.Forms.Where(s => s.Source.Equals(stropid) && s.Type.Equals(95)).FirstOrDefault();
                        if (mod1 != null)
                        {
                            object om = new { jp = mod1.Extend, jpid = Convert.ToInt32(mod1.Income) - 1 };
                            jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = mod1.Remark, result = om, count = 3 });
                        }
                        else
                        {
                            var str = lotterid().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            var models = new Forms()
                            {
                                Title = "龙湖抽奖",
                                FormType = 0,
                                Name = "",
                                Number = 0,
                                Mobile = "",
                                Age = 0,
                                Source = stropid,
                                Income = str[0],
                                Remark = ((countnum + 1) + "").PadLeft(5, '0'),
                                AddTime = DateTime.Now,
                                Status = 1,
                                Orders = 0,
                                UpdateTime = DateTime.Now,
                                Extend = str[1],
                                Extend2 = "",
                                Type = 95,
                                JFCount = 0
                            };
                            db.Forms.AddObject(models);
                            db.SaveChanges();
                            object om = new { jp = models.Extend, jpid =Convert.ToInt32(str[0])-1 };
                            jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = models.Remark, result = om, count = 3 });
                        }
                    }
                }
                else
                {
                    jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "活动时间未开始OR已经结束", count = 1 });
                }
            }
            catch (Exception ex)
            {
                jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = "活动信息出错", count = 0 });
            }
            _ct.Response.Write(jsonstrlist);
        }

        private string lotterid()
        {
            string str = string.Empty;
            string jp = string.Empty;
            int ti = GetLotter() + 1;
            using (WXDBEntities db = new WXDBEntities())
            {
                //判断红包数量
                var jpmodel = db.Effect.Where(s => s.Orders > 0 && s.Openid.Equals("9")).FirstOrDefault();
                if (jpmodel != null)
                {
                    string hb = string.Empty;
                    var model1 = db.Effect.Where(s => s.Status.Equals(ti) && s.Orders > 0 && s.Openid.Equals("9")).FirstOrDefault();
                    if (model1 != null)
                    {
                        model1.Orders = model1.Orders - 1;
                        hb = model1.Title;
                        jp = model1.Title;
                        db.SaveChanges();
                    }
                    else
                    {
                        jp = "纸巾盒";
                        ti = 1;
                    }
                }
                else
                {
                    jp = "纸巾盒";
                    ti = 1;
                }
            }

            return ti + "|" + jp;
        }
        private static Random rnd = new Random();
        /// <summary>
        /// 获取抽奖结果
        /// </summary>
        /// <param name="prob">各物品的抽中概率</param>
        /// <returns>返回抽中的物品所在数组的位置</returns>
        private static int GetLotter()
        {
            float[] prob = new float[6];
            prob[0] = float.Parse("5");
            prob[1] = float.Parse("2");
            prob[2] = float.Parse("1");
            prob[3] = float.Parse("0.7");
            prob[4] = float.Parse("0.5");
            prob[5] = float.Parse("0.3");
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