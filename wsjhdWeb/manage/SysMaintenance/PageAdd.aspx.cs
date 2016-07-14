using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using System.IO;

namespace NewInfoWeb.manage.SysMaintenance
{
    public partial class PageAdd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((maintenancemaster)this.Master).txtTitle = "页面信息增加";

            if (!Page.IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    WebUtil.DrpToListEx<ModuleItem>(drpModule, db.ModuleItem.ToList(), "ModuleName", "ModuleID");
                }
                if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
                    drpModule.SelectedValue = Request.QueryString["mid"];

                if (!string.IsNullOrEmpty(Request.QueryString["refer"]))
                {
                    refer.Value = Request.QueryString["refer"];
                    btnBack.Attributes.Add("onclick", "window.location.href='" + Server.UrlDecode(refer.Value) + "';return false;");
                }
                else
                    btnBack.Attributes.Add("onclick", "window.location.href='modulelist.aspx';return false;");
            }
        }

        /// <summary>
        /// 页面信息保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                int mid = int.Parse(drpModule.SelectedValue);
                if (mid > 0)
                {
                    PageItem xPageItem = new PageItem();
                    xPageItem.ModuleID = mid;
                    xPageItem.PageName = txtPageName.Text;
                    xPageItem.Url = txtUrl.Text;
                    xPageItem.IsDisplay = IsDisplay.Checked;

                    if (upPic.HasFile)
                    {
                        string _img = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();

                        upPic.PostedFile.SaveAs(globalVariables.SysDirString + _img);
                        xPageItem.PicUrl = _img;
                    }

                    db.PageItem.AddObject(xPageItem);
                    db.SaveChanges();

                    if (!string.IsNullOrEmpty(refer.Value))
                        jsHint.toUrl("页面信息" + txtPageName.Text + "增加成功!", refer.Value);
                    else if (string.IsNullOrEmpty(Request.QueryString["type"]))
                        jsHint.toUrl("页面信息" + txtPageName.Text + "增加成功!", "PageList.aspx");
                    else
                        jsHint.toUrl("页面信息" + txtPageName.Text + "增加成功!", Request.UrlReferrer.OriginalString);
                }
                else
                {
                    jsHint.toUrl("请选择模块信息", refer.Value);
                }
            }
        }
    }
}