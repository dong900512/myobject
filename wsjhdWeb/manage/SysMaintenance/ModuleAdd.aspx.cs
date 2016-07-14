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
    public partial class ModuleAdd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((maintenancemaster)this.Master).txtTitle = "模块信息增加";
            btnBack.Attributes.Add("onclick", "window.location.href='ModuleList.aspx';return false;");
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                ModuleItem xModuleItem = new ModuleItem();

                xModuleItem.ModuleName = txtModuleName.Text;
                xModuleItem.DefaultUrl = txtDefaultUrl.Text;

                if (upPicPath.HasFile)
                {
                    // 开始保存文件信息("~/UploadedImages/");
                    string _img = Guid.NewGuid().ToString() + Path.GetExtension(upPicPath.FileName).ToLower();
                    //upPicPath.PostedFile.SaveAs(MapPath("~/Manage/UploadFiles/Sys/" + _img));
                    upPicPath.PostedFile.SaveAs(globalVariables.SysDirString + _img);

                    xModuleItem.Picpath = _img;
                }

                db.ModuleItem.AddObject(xModuleItem);
                db.SaveChanges();
            }
            if (string.IsNullOrEmpty(Request.QueryString["type"]))
                jsHint.toUrl("模块信息" + txtModuleName.Text + "增加成功!", "ModuleList.aspx");
            else
                jsHint.toUrl("模块信息" + txtModuleName.Text + "增加成功!", Request.UrlReferrer.OriginalString);
        }
    }
}