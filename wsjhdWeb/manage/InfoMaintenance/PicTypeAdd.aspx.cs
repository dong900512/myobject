using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;

namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class PicTypeAdd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "图片类别添加";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            using (WXDBEntities db = new WXDBEntities())
            {
                PicType model = new PicType();
                model.Title = txttitle.Text;
                model.Description = txtDesc.Text;
                model.Orders = Convert.ToInt32(txtorders.Text);
                model.AddTime = DateTime.Now;
                model.Status = 0;
                model.UpdateTime = DateTime.Now;
                model.Extend = loginname;
                model.Extend1 = loginname;
                try
                {
                    db.PicType.AddObject(model);
                    db.SaveChanges();
                    jsHint.toUrl("信息" + model.Title + "增加成功!", "PicTypeList.aspx");
                }
                catch (Exception ex)
                {
                    jsHint.Alert(ex.Message);
                }
            }
        }
    }
}