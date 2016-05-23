using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using WXEF;
using WX.Utils;
using System.IO;
using System.Web.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using System.Diagnostics;
using System.Drawing;
using Senparc.Weixin.MP.CommonAPIs;

namespace NewInfoWeb.zshmsg
{
    /// <summary>
    /// nbzshelper 的摘要说明
    /// </summary>
    public class nbzshelper : IHttpHandler
    {
        protected HttpContext _ct;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _ct = context;
            var type = _ct.Request.Form["type"];
            switch (type)
            {
                case "AddImg":
                    AddImgInfo();
                    break;
                case "AddAudio":
                    SaveCurInfo();
                    break;
                case "AddYJ":
                    YjInfo();
                    break;
                case "GetCurInfo":
                    GetOneInfo();
                    break;
                case "getjpph":
                    GetListInfo();
                    break;
            }
        }
        /// <summary>
        /// 获取单个信息
        /// </summary>
        protected void GetOneInfo()
        {
            var tid = _ct.Request.Form["tid"];
            int curtid = 0;
            int.TryParse(tid, out curtid);
            try
            {
                if (curtid > 0)
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        var model = db.lotterUserInfo.Where(s => s.Id.Equals(curtid)).FirstOrDefault();
                        if (model != null)
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = model.LotterSN, result = model.lotDesc, count = 1 });
                            _ct.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "fail", result = "", count = 0 });
                            _ct.Response.Write(jsonstrlist);
                        }
                    }
                }
                else
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "fail", result = "", count = 0 });
                    _ct.Response.Write(jsonstrlist);
                }

            }
            catch (Exception)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "fail", result = "", count = 0 });
                _ct.Response.Write(jsonstrlist);
            }
        }
        /// <summary>
        /// 获取奖品信息
        /// </summary>
        protected void GetListInfo()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var list = new List<lotterUserInfo>();
                list = db.lotterUserInfo.Where(s => s.Type.Equals(15) && s.PriceNumber != 0).ToList();
                List<object> listDesc = new List<object>();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        listDesc.Add(new
                        {
                            id = item.Id,
                            name = item.NickName.Substring(0, 1) + "***",
                            phone = item.Extend1.Substring(0, 3) + "****" + item.Extend1.Substring(7),
                            ords = item.PriceName
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
        /// <summary>
        /// 执行转换
        /// </summary>
        /// <param name="exe">exe命令地址</param>
        /// <param name="sourcePath">源路径</param>
        /// <param name="targetPath">目标路径</param>
        /// <param name="output"></param>
        protected void ExcuteProcess(string exe, string sourcePath, string targetPath, DataReceivedEventHandler output)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = exe;
                p.StartInfo.Arguments = "-y -i " + sourcePath + " -ar 44100 -ab 128k " + targetPath;
                p.StartInfo.UseShellExecute = false;    //输出信息重定向
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += output;
                p.ErrorDataReceived += output;
                p.Exited += delegate
                {
                    if (File.Exists(sourcePath))
                    {
                        File.Delete(sourcePath);
                    }
                };
                p.Start();                    //启动线程
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();            //等待进程结束
            }
        }
        /// <summary>
        /// 新增语音数据
        /// </summary>
        /// <param name="context"></param>
        protected void SaveCurInfo()
        {
            var mediald = _ct.Request.Params["serverId"];
            var wxopid = _ct.Request.Params["tmpid"];
            using (MemoryStream ms = new MemoryStream())
            {
                MediaApi.Get(AccessTokenContainer.TryGetToken(WebConfigurationManager.AppSettings["wxappid"], WebConfigurationManager.AppSettings["wxsecret"]), mediald, ms);
                //保存到文件
                var ditick = DateTime.Now.Ticks;
                var targetname = string.Format("mp3_{0}.mp3", ditick);
                var fileName = string.Format(WebConfigurationManager.AppSettings["mp3url"] + "mp3_{0}.amr", ditick);
                var targetpaht = string.Format(WebConfigurationManager.AppSettings["mp3url"] + "mp3_{0}.mp3", ditick);
                try
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        ms.Position = 0;
                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;
                        while ((bytesRead = ms.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            fs.Write(buffer, 0, bytesRead);
                        }
                        fs.Flush();
                    }
                    ExcuteProcess(WebConfigurationManager.AppSettings["ffexepath"], fileName, targetpaht, (s, e) => Console.WriteLine(e.Data));
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        var tmodel = db.lotterUserInfo.Where(s => s.Type.Equals(15) && s.OpenId.Equals(wxopid)).FirstOrDefault();
                        if (tmodel != null)
                        {
                            tmodel.lotDesc = targetname;
                            db.SaveChanges();
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = tmodel.Id + "", count = 1 });
                            _ct.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "faile", result = "暂无数据", count = 2 });
                            _ct.Response.Write(jsonstrlist);
                        }
                    }
                }
                catch (Exception e)
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "faile", result = e.Message, count = 0 });
                    _ct.Response.Write(jsonstrlist);
                }
            }
        }
        /// <summary>
        /// 新增图片
        /// </summary>
        protected void AddImgInfo()
        {
            try
            {
                string filename = System.Guid.NewGuid().ToString().Replace("-", "");
                string imgData = _ct.Request.Form["img"];
                string imgType = "";
                string tid = _ct.Request.Form["tid"];
                string stopid = _ct.Request.Form["stopid"];
                int fid = 0;
                int.TryParse(tid, out fid);
                if (fid == 0)
                {
                    string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "faile", result = "", count = 0 });
                    _ct.Response.Write(jsonstrlist);
                }
                else
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        var model1 = db.lotterUserInfo.Where(s => s.OpenId.Equals(stopid) && s.Type.Equals(15)).FirstOrDefault();
                        if (model1 != null)
                        {
                            if (imgData != "")
                            {
                                imgType = imgData.IndexOf("image/jpeg") != -1 ? "jpg" : "png";
                                MemoryStream stream = new MemoryStream(Convert.FromBase64String(imgData.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "")));
                                Bitmap img = new Bitmap(stream);
                                img.Save(_ct.Server.MapPath(@"/zshmsg/images/" + filename + "." + imgType));
                            }
                            //图片
                            model1.LotterSN = filename + "." + imgType;
                            db.SaveChanges();
                            string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = filename + "." + imgType, count = 2 });
                            _ct.Response.Write(jsonstrlist);
                        }
                        else
                        {
                            if (imgData != "")
                            {
                                imgType = imgData.IndexOf("image/jpeg") != -1 ? "jpg" : "png";
                                MemoryStream stream = new MemoryStream(Convert.FromBase64String(imgData.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "")));
                                Bitmap img = new Bitmap(stream);
                                img.Save(_ct.Server.MapPath(@"/zshmsg/images/" + filename + "." + imgType));

                                model1 = new lotterUserInfo()
                                {
                                    NickName = "",
                                    OpenId = stopid,
                                    StartTime = DateTime.Now,
                                    LotterNumber = 0,
                                    AddTime = DateTime.Now,
                                    Updatetime = DateTime.Now,
                                    LotterSN = filename + "." + imgType,
                                    PriceName = "",
                                    PriceNumber = 0,
                                    Extend1 = "",
                                    Extend2 = "",
                                    Extend3 = "",
                                    Status = 0,
                                    Orders = 0,
                                    Type = 15,
                                    lotDesc = ""
                                };
                                db.lotterUserInfo.AddObject(model1);
                                db.SaveChanges();
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "succ", result = filename + "." + imgType, count = 2 });
                                _ct.Response.Write(jsonstrlist);
                            }
                            else
                            {
                                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "faile", result = "", count = 3 });
                                _ct.Response.Write(jsonstrlist);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "faile", result = "", count = 3 });
                _ct.Response.Write(jsonstrlist);
            }
        }

        /// <summary>
        /// 添加中奖信息
        /// </summary>
        protected void YjInfo()
        {
            string jsonstrlist = string.Empty;
            string tname = _ct.Request.Form["tname"];
            string tphone = _ct.Request.Form["tphone"];
            string tadress = _ct.Request.Form["tadress"];
            string stropid = _ct.Request.Form["tinfoid"];
            try
            {
                DateTime t1 = DateTime.Now;
                DateTime t2 = Convert.ToDateTime(WebConfigurationManager.AppSettings["starttime10"]);
                DateTime t3 = Convert.ToDateTime(WebConfigurationManager.AppSettings["endtime10"]);
                DateTime t4 = DateTime.Now.Date;
                DateTime t5 = t4.AddDays(1);
                if (DateTime.Compare(t1, t2) > 0 && DateTime.Compare(t1, t3) < 0)
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        var countnum = db.lotterUserInfo.Where(s => s.Type.Equals(15)).Count();
                        var mod1 = db.lotterUserInfo.Where(s => s.Type.Equals(15) && s.OpenId.Equals(stropid)).FirstOrDefault();
                        if (mod1 != null)
                        {
                            if (!string.IsNullOrEmpty(mod1.NickName))
                            {
                                //已抽奖
                                jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = mod1.PriceNumber + "", result = mod1.PriceName, count = 3 });
                            }
                            else
                            {
                                var str = lotterid().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                mod1.NickName = tname;
                                mod1.Updatetime = DateTime.Now;
                                mod1.PriceName = str[1];
                                mod1.PriceNumber = Convert.ToInt32(str[0]);
                                mod1.Extend1 = tphone;
                                mod1.Extend2 = tadress;
                                mod1.Extend3 = ((countnum + 1) + "").PadLeft(5, '0');
                                //db.lotterUserInfo.AddObject(mod1);
                                db.SaveChanges();
                                jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = mod1.PriceNumber + "", result = mod1.PriceName, count = 3 });
                            }
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
                jsonstrlist = JsonHelper.GetJsonString(new jsonResult { code = "error", result = ex.Message, count = 0 });
            }
            _ct.Response.Write(jsonstrlist);
        }

        private string lotterid()
        {
            string str = string.Empty;
            string jp = string.Empty;
            int ti = GetLotter();
            if (ti == 0)
            {
                jp = "谢谢参与";
            }
            else
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    //判断奖品数量
                    var jpmodel = db.Effect.Where(s => s.Orders > 0 && s.Openid.Equals("7")).FirstOrDefault();
                    if (jpmodel != null)
                    {
                        string hb = string.Empty;
                        var model1 = db.Effect.Where(s => s.Status.Equals(ti) && s.Orders > 0 && s.Openid.Equals("7")).FirstOrDefault();
                        if (model1 != null)
                        {
                            model1.Orders = model1.Orders - 1;
                            hb = model1.Title;
                            jp = model1.Title;
                            db.SaveChanges();
                        }
                        else
                        {
                            //jp = jpmodel.Title;
                            //jpmodel.Orders = jpmodel.Orders - 1;
                         
                            //ti = jpmodel.Status;
                            //db.SaveChanges();
                            jp = "谢谢参与";
                            ti = 0;
                        }
                    }
                    else
                    {
                        jp = "谢谢参与";
                        ti = 0;
                    }
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
            float[] prob = new float[5];
            prob[0] = float.Parse("6");
            prob[1] = float.Parse("1");
            prob[2] = float.Parse("3");
            prob[3] = float.Parse("2");
            prob[4] = float.Parse("2");
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