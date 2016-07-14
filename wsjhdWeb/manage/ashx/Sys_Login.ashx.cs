using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WX.Utils;
using NewInfoWeb.Appcode;
using WXEF;
using System.Web.Configuration;
using Dos.ORM;

namespace NewInfoWeb.manage
{
    /// <summary>
    /// Sys_Login 的摘要说明
    /// </summary>
    public class Sys_Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var type = context.Request.Params["RqtAction"];
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "login":
                        SysLogin(context);
                        break;
                    case "sysQX":
                        SysQxManage(context);
                        break;

                }
            }

        }

        /// <summary>
        /// 修改权限问题
        /// </summary>
        /// <param name="context"></param>
        private void SysQxManage(HttpContext context)
        {
            string retMsg = "";
            string Id = context.Request["Id"];
            string DutyName = context.Request["DutyName"];
            string AuthItem = context.Request["AuthItem"];
            string FunctionItem = context.Request["FunctionItem"];
            string Mark = context.Request["Mark"];
            string XMNo = context.Request["XMNo"];
            try
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    string LoginName = CookieHelper.Read(WebConfigurationManager.AppSettings["ManageDomain"], "loginname");
                    if (Id == "")
                    {   //添加
                        var model = new Dos.Model.Manager_Groups();
                        model.Role = AuthItem;
                        model.AddTime = DateTime.Now;
                        model.AddUser = LoginName;
                        model.Name = DutyName;
                        model.Remark = Mark;
                        model.UpdateTime = DateTime.Now;
                        model.UpdateUser = LoginName;
                        model.Extend1 = XMNo;
                        model.Status = 0;
                        try
                        {
                            int t1 = DbSession.Default.Insert<Dos.Model.Manager_Groups>(model);
                            //db.Manager_Groups.AddObject(model);
                            //db.SaveChanges();
                            string Details = "Manager_Groups  ID为：" + model.Id + ",角色名称为：" + model.Name;
                            string type = "添加";
                            string typeName = "角色管理";
                            Logger.Default.Info("角色添加", Details);
                        }
                        catch (Exception ex)
                        {
                            retMsg = "Error";
                            string Details = "出错！！！方法：" + ex.TargetSite + ",异常消息：" + ex.Message + ",出错的应用程序或对象名称：" + ex.Source;
                            string type = "添加";
                            string typeName = "角色管理";
                            Logger.Default.Error("角色添加", Details);
                        }
                    }
                    else
                    {
                        //修改
                        var tmpid = Convert.ToInt32(Id);
                        var model1 = DbSession.Default.From<Dos.Model.Manager_Groups>().Where(s => s.Id.Equals(tmpid) && s.Status.Equals(0)).ToFirstDefault();
                        if (model1.Id > 0)
                        {
                            model1.Attach();
                            model1.Role = AuthItem;
                            model1.Name = DutyName;
                            model1.Remark = Mark;
                            model1.UpdateTime = DateTime.Now;
                            model1.UpdateUser = LoginName;
                            model1.Extend1 = XMNo;
                            try
                            {
                                int t2 = DbSession.Default.Update<Dos.Model.Manager_Groups>(model1);
                                string Details = "Manager_Groups  ID为：" + Id + ",角色名称为：" + model1.Name;
                                string type = "修改";
                                string typeName = "角色管理";
                                Logger.Default.Error("角色修改", Details);
                            }
                            catch (Exception ex)
                            {
                                retMsg = "Error";
                                string Details = "出错！！！方法：" + ex.TargetSite + ",异常消息：" + ex.Message + ",出错的应用程序或对象名称：" + ex.Source;
                                string type = "修改";
                                string typeName = "角色管理";
                                Logger.Default.Error("修改出错", Details);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Default.Error("修改出错", ex.Message);
            }
            context.Response.Write(retMsg);
            context.Response.End();
        }

        /// <summary>
        /// 登陆信息
        /// </summary>
        /// <param name="context"></param>
        private void SysLogin(HttpContext context)
        {
            string LoginName = context.Request["LoginName"];
            string LoginPassword = context.Request["LoginPassword"];
            string SecretCode = context.Request["SecretCode"];
            string retMsg = string.Empty;

            try
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var tmpma = Utils.MD5(LoginPassword);
                    var tmodel = db.SysAccount.Where(s => s.LoginName.Equals(LoginName) && s.Status.Equals(0) && s.Password.Equals(tmpma)).FirstOrDefault();
                    if (tmodel != null)
                    {
                        var tqx = DbSession.Default.From<Dos.Model.Manager_Groups>().Where(s => s.Id.Equals(tmodel.SyType) && s.Status.Equals(0)).ToFirstDefault();

                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("loginname", LoginName);
                        dic.Add("userid", tmodel.AccountID + "");
                        dic.Add("DutyId", tmodel.SyType + "");
                        if (tqx.Id > 0)
                        {
                            dic.Add("CityNo", tqx.Remark);
                            dic.Add("ProjectNo", tqx.Extend1);
                        }
                        //dic.Add("","");
                        CookieHelper.WriteIn(WebConfigurationManager.AppSettings["ManageDomain"], 30, dic);
                        tmodel.LastLoginTime = DateTime.Now;
                        tmodel.LoginNums += 1;
                        db.SaveChanges();
                        retMsg = "success";
                        context.Response.Write(retMsg);
                    }
                    else
                    {
                        retMsg = "Error";
                        context.Response.Write(retMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                retMsg = "Error";
                context.Response.Write(retMsg);
                Logger.Default.Error("获取用户信息出错", ex);
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