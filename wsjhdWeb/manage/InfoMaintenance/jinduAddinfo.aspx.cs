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
    public partial class jinduAddinfo : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "进度图片添加";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            if (string.IsNullOrEmpty(txttitle.Text.Trim()))
            {
                jsHint.Back("请输入进度名称信息！");
                return;
            }
            var model = new TuInfo();
            model.name = txttitle.Text.Trim();// lat2 + "";
            model.status = 0;
            model.orders = 0;
            model.addtime = DateTime.Now;
            model.updatetime = DateTime.Now;
            model.extend1 = "";
            model.extend2 = txtsummary.Text.Trim();
            model.extend3 = "2";

            if (upPic.HasFile)
            {
                string _imgpath = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();
                upPic.PostedFile.SaveAs(globalVariables.NewsImgPath + _imgpath);
                model.varurl = _imgpath;
            }

            else
            {
                jsHint.Back("请上传进度图片信息！");
                return;

            }
            using (WXDBEntities db = new WXDBEntities())
            {
                db.TuInfo.AddObject(model);
                db.SaveChanges();
                jsHint.toUrl("图片增加成功!", "jinduinfo.aspx");
            }
        }
    }
}