using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WX.Utils;
using WXEF;

namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class PageEdit : ManageBasePage
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

            ((maintenancemaster)this.Master).txtTitle = "页面信息列表";
            btnBack.Attributes.Add("onclick", "window.location.href='" + Server.UrlDecode(Request.QueryString["refer"]) + "';return false;");
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void InitCtrls(int Id)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                PageItem xPageItem = db.PageItem.Where(p => p.ItemID == Id).FirstOrDefault();

                WebUtil.DrpToListEx<ModuleItem>(drpModule, db.ModuleItem.ToList(), "ModuleName", "ModuleID");

                drpModule.SelectedValue = xPageItem.ModuleID.ToString();
                txtPageName.Text = xPageItem.PageName;
                txtUrl.Text = xPageItem.Url;
                IsDisplay.Checked = xPageItem.IsDisplay;
            }
        }

        /// <summary>
        /// 修改保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                int id = int.Parse(Request.QueryString["id"]);
                PageItem xPageItem = db.PageItem.Where(p => p.ItemID == id).FirstOrDefault();

                xPageItem.PageName = txtPageName.Text;
                xPageItem.Url = txtUrl.Text;
                xPageItem.IsDisplay = IsDisplay.Checked;

                if (upPic.HasFile)
                {
                    if (!string.IsNullOrEmpty(xPageItem.PicUrl) && File.Exists(globalVariables.SysDirString + xPageItem.PicUrl))
                        File.Delete(globalVariables.SysDirString + xPageItem.PicUrl);

                    string _img = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();
                    upPic.PostedFile.SaveAs(globalVariables.SysDirString + _img);

                    xPageItem.PicUrl = _img;
                }

                db.SaveChanges();
            }
            jsHint.toUrl("页面信息" + txtPageName.Text + "修改成功!", refer.Value);
        }
    }
}