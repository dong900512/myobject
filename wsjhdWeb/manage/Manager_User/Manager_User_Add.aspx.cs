using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using NewInfoWeb.Appcode;
using Dos.ORM;

namespace NewInfoWeb.manage.Manager_User
{
    public partial class Manager_User_Add : ManageBasePage
    {

        public int UserId = DNTRequest.RequstInt("UserId");
        public string change = DNTRequest.RequstString("change");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  角色权限初始化
                Manager_GroupsData();

                if (Request.QueryString["change"] == "edit" && UserId != -1)
                {
                    txt_change.Value = "edit";
                    ShowInfo(this.UserId);
                }
                string reqStrUrl = "Manager_User_List.aspx";
                if (Request.UrlReferrer != null)
                {
                    reqStrUrl = Request.UrlReferrer.ToString();
                }
                btn_Back.Attributes.Add("onclick", "window.location.href='" + reqStrUrl + "';return false;");
            }

        }
        void ShowInfo(int _id)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var xmodel = db.SysAccount.Where(s => s.Status.Equals(0) && s.AccountID.Equals(_id)).FirstOrDefault();
                if (xmodel != null)
                {
                    drpGroups.SelectedValue = xmodel.SyType.ToString();
                    txt_UserName.Text = xmodel.LoginName;
                    //txt_Password.Text = xmodel.Password;
                    txt_Password.Attributes.Add("value", "******");

                    //txt_TwoPassword.Text = xmodel.Password;
                    txt_TwoPassword.Attributes.Add("value", "******");

                    txt_RealName.Text = xmodel.RealName;
                    txt_Email.Text = xmodel.Email;
                    txt_Mobile.Text = xmodel.Mobile;
                }
            }
        }
        void Manager_GroupsData()
        {
            WebUtil.DrpToListEx<Dos.Model.Manager_Groups>(drpGroups,
                DbSession.Default.From<Dos.Model.Manager_Groups>().Where(s => s.Status == 0).OrderBy(s => s.AddTime).ToList(), "Name", "Id","请选择权限信息");
        }
        //确认按钮事件
        protected void btn_click_Click(object sender, EventArgs e)
        {
            string oldPassWord = "";
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = new WXEF.SysAccount();
                if (this.UserId > 0)
                {
                    model = db.SysAccount.Where(s => s.AccountID.Equals(this.UserId) && s.Status.Equals(0)).FirstOrDefault();
                    oldPassWord = model.Password;
                }
                else
                {
                    //新增
                    //model.UpdateTime = DateTime.Now;
                    model.LastLoginTime = DateTime.Now;
                }
                if (string.IsNullOrEmpty(txt_Password.Text) || (txt_Password.Text.Trim().Equals("******")))
                {
                    model.Password = oldPassWord;
                }
                else
                {
                    model.Password = Utils.MD5(txt_Password.Text.Trim());
                }
                model.LoginName = txt_UserName.Text;
                model.Mobile = txt_Mobile.Text;
                model.Email = txt_Email.Text;
                model.SyType = int.Parse(drpGroups.SelectedValue);
                model.RealName = txt_RealName.Text;
                model.LoginNums = 0;
                model.Status = 0;
                model.Phone = "";
                //model.AddTime = DateTime.Now;
                //model.AddUser = "";
                //model.UpdateUser = "";
                if (Request.QueryString["change"] == "edit" && this.UserId != -1)
                {
                    try
                    {
                        db.SaveChanges();
                        jsHint.toUrl("用户信息编辑成功！", "Manager_User_List.aspx");
                        //日志保存操作
                        string Details = "修改用户信息：" + model.LoginName;
                        string type = "修改";
                        string typeName = "用户管理";
                        Logger.Default.Info("修改稿用户信息成功", Details);

                    }
                    catch (Exception ex1)
                    {
                        string Details = "出错！！！方法：" + ex1.TargetSite + ",异常消息：" + ex1.Message + ",出错的应用程序或对象名称：" + ex1.Source;
                        string type = "修改";
                        string typeName = "用户管理";
                        Logger.Default.Error("修改稿用户信息成功", Details);
                        jsHint.Alert("用户信息编辑失败，原因：" + ex1.Message);
                    }
                }
                else
                {
                    try
                    {
                        var tmptyid = int.Parse(drpGroups.SelectedValue);
                        var tname = txt_UserName.Text.Trim();
                        var model1 = db.SysAccount.Where(s => s.Status.Equals(0) && s.SyType.Equals(tmptyid) && s.LoginName.Equals(tname)).FirstOrDefault();
                        if (model1 != null)
                        {
                            Logger.Default.Fatal("该权限下已存在登陆名，请重新填写！");
                            jsHint.Back("该权限下已存在登陆名，请重新填写！");
                            return;
                        }
                        else
                        {
                            db.SysAccount.AddObject(model);
                            db.SaveChanges();
                            jsHint.toUrl("用户信息添加成功！", "Manager_User_List.aspx");
                            Logger.Default.Info("新增用户信息", model.LoginName);
                        }

                    }
                    catch (Exception ex)
                    {
                        jsHint.Alert("用户信息添加失败，原因：" + ex.Message);
                        string Details = "出错！！！方法：" + ex.TargetSite + ",异常消息：" + ex.Message + ",出错的应用程序或对象名称：" + ex.Source;
                        string type = "新增";
                        string typeName = "用户管理";
                        Logger.Default.Info("新增用户失败", model.LoginName);
                    }
                }
            }
        }
    }
}