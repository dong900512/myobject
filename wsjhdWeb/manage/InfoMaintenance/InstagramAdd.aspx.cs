using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using System.IO;

namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class InstagramAdd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "楼盘实景添加";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            if (string.IsNullOrEmpty(txttitle.Text.Trim()))
            {
                jsHint.Back("请输入分享人名称信息！");
                return;
            }

            var model = new Instagram();
            model.lat1 = "";// lat2 + "";
            model.lng1 = "";// lng2 + "";
            model.UserName = txttitle.Text;
            model.Status = 0;
            model.UpdateTime = DateTime.Now;
            model.AddTime = DateTime.Now;
            model.Orders = 0;

            if (upPic.HasFile)
            {
                string _imgpath = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();
                upPic.PostedFile.SaveAs(System.Configuration.ConfigurationManager.AppSettings["picWallPath"].ToString() + _imgpath);
                model.PicUrl = _imgpath;
            }
            else
            {
                jsHint.Back("请上传楼盘实景图片信息！");
                return;

            }
            using (WXDBEntities db = new WXDBEntities())
            {
                db.Instagram.AddObject(model);
                db.SaveChanges();
                jsHint.toUrl("图片增加成功!", "InstagramList.aspx");
            }
        }
    }
}