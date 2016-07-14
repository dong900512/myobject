using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using System.IO;
using WXEF;

namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class ModuleEdit : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["id"]) || !WebUtil.IsDigit(Request.QueryString["id"]))
                {
                    jsHint.Back(" 参数不合法！");
                    return;
                }

                InitCtrls(int.Parse(Request.QueryString["id"]));

                refer.Value = Server.UrlDecode(Request.QueryString["refer"]);
            }

            ((maintenancemaster)this.Master).txtTitle = "模块信息修改";
            btnBack.Attributes.Add("onclick", "window.location.href='" + Server.UrlDecode(Request.QueryString["refer"]) + "';return false;");
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void InitCtrls(int Id)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                ModuleItem xModuleItem = db.ModuleItem.Where(m => m.ModuleID == Id).FirstOrDefault();

                txtModuleName.Text = xModuleItem.ModuleName;
                txtDefaultUrl.Text = xModuleItem.DefaultUrl;
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]); using (WXDBEntities db = new WXDBEntities())
            {
                ModuleItem xModuleItem = db.ModuleItem.Where(m => m.ModuleID == id).FirstOrDefault();

                xModuleItem.ModuleName = txtModuleName.Text;
                xModuleItem.DefaultUrl = txtDefaultUrl.Text;

                if (upPicPath.HasFile)
                {
                    if (!string.IsNullOrEmpty(xModuleItem.Picpath) && File.Exists(globalVariables.SysDirString + xModuleItem.Picpath))
                        File.Delete(globalVariables.SysDirString + xModuleItem.Picpath);

                    // 开始保存文件信息("~/UploadedImages/");
                    string _img = Guid.NewGuid().ToString() + Path.GetExtension(upPicPath.FileName).ToLower();
                    //upPicPath.PostedFile.SaveAs(MapPath("~/Manage/UploadFiles/Sys/" + _img));
                    upPicPath.PostedFile.SaveAs(globalVariables.SysDirString + _img);

                    xModuleItem.Picpath = _img;
                }

                db.SaveChanges();
            }
            if (string.IsNullOrEmpty(refer.Value))
                jsHint.toUrl("模块信息" + txtModuleName.Text + "修改成功!", "ModuleList.aspx");
            else
                jsHint.toUrl("模块信息" + txtModuleName.Text + "修改成功!", refer.Value);
        }
    }
}