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
    public partial class PicTypeEdit : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "图片类别添加";
            if (!IsPostBack)
            {
                InitCtrls(Convert.ToInt32(Request.Params["id"]));
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="tmpid"></param>
        protected void InitCtrls(int tmpid)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = db.PicType.Where(s => s.Id == tmpid).FirstOrDefault();
                if (model != null)
                {
                    txttitle.Text = model.Title;
                    txtDesc.Text = model.Description;
                    txtorders.Text = model.Orders.ToString();
                }
            }
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            using (WXDBEntities db = new WXDBEntities())
            {
                int tmpid = Convert.ToInt32(Request.Params["id"]);
                var model = db.PicType.Where(s => s.Id == tmpid).FirstOrDefault();
                model.Title = txttitle.Text;
                model.Description = txtDesc.Text;
                model.Orders = Convert.ToInt32(txtorders.Text);
                model.UpdateTime = DateTime.Now;
                model.Extend1 = loginname;
                try
                {
                    db.SaveChanges();
                    jsHint.toUrl("信息" + model.Title + "修改成功!", "PicTypeList.aspx");
                }
                catch (Exception ex)
                {
                    jsHint.Alert(ex.Message);
                }
            }
        }
    }
}