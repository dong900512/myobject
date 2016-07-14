using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;

namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class marketInfo : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "销售咨询信息";
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var model = db.MarketInfo.FirstOrDefault();
                    if (model != null)
                    {
                        txtMarkInfo.Text = model.Contents.Replace("<br/>", "\r\n");
                    }
                }
            }
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            if (string.IsNullOrEmpty(txtMarkInfo.Text.Trim()))
            {
                jsHint.Back("请输入销售咨询信息！");
                return;
            }
            using (WXDBEntities db = new WXDBEntities())
            {

                var model = db.MarketInfo.FirstOrDefault();
                if (model != null)
                {
                    model.Contents = txtMarkInfo.Text.Replace("\r\n", "<br/>");
                    model.UpdateTime = DateTime.Now;
                    model.UpdateUser = loginname;
                    model.UpdateUserId = UserId;
                }
                else
                {
                    model = new MarketInfo();
                    model.Contents = txtMarkInfo.Text.Replace("\r\n", "<br/>");
                    model.Description = "";
                    model.Status = 0;
                    model.Orders = 0;
                    model.AddTime = DateTime.Now;
                    model.UpdateTime = DateTime.Now;
                    model.UpdateUser = loginname;
                    model.UpdateUserId = UserId;
                    db.MarketInfo.AddObject(model);
                }
                db.SaveChanges();
                jsHint.toUrl("信息修改成功!", "marketInfo.aspx");
            }
        }
    }
}