using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using System.IO;
using WXEF;

namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class jinduEditinfo : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "进度图片编辑";

            if (!this.IsPostBack)
            {
                InitCtrls(Convert.ToInt32(Request.Params["ID"]));
            }
        }
        /// <summary>
        ///  绑定信息
        /// </summary>
        private void InitCtrls(int tmpid)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = db.TuInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                if (model != null)
                {
                    //drpActityType.SelectedValue = model.Type.ToString();
                    txttitle.Text = model.name;
                    txtsummary.Text = model.extend2;
                    if (!string.IsNullOrEmpty(model.varurl))
                    {
                        hyp.Text = "查看进度图信息";
                        hyp.NavigateUrl = globalVariables.NewsImgServer + model.varurl;

                    }
                }
            }
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            if (string.IsNullOrEmpty(txttitle.Text.Trim()))
            {
                jsHint.Back("请输入进度名称信息！");
                return;
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                int tmpid = Convert.ToInt32(Request.Params["id"]);
                var model = db.TuInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                model.name = txttitle.Text.Trim();// lat2 + "";
                model.extend2 = txtsummary.Text.Trim();
                model.updatetime = DateTime.Now;

                if (upPic.HasFile)
                {
                    string _imgpath = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();
                    upPic.PostedFile.SaveAs(globalVariables.NewsImgPath + _imgpath);
                    model.varurl = _imgpath;
                }


                //db.TuInfo.AddObject(model);
                db.SaveChanges();
                jsHint.toUrl("进度图信息编辑成功!", "jinduinfo.aspx");
            }
        }
    }
}