using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;

namespace NewInfoWeb.manage.SphereActivity
{
    public partial class znkf : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Activity)this.Master).txtTitle = "智能客服信息";

            if (!this.IsPostBack)
            {
                InitCtrls();
            }
        }

        private void InitCtrls()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var tmp = db.WXKewWords.Where(s => s.Type == 0).FirstOrDefault();
                if (tmp != null)
                {
                    txtcontent.Value = tmp.Description;
                }
            }
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtcontent.Value.Trim()))
            {
                jsHint.Back("请输入智能客服信息！");
                return;
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                var tmp = db.WXKewWords.Where(s => s.Type == 0).FirstOrDefault();
                if (tmp != null)
                {
                    tmp.Description = txtcontent.Value;
                }
                else
                {
                    tmp = new WXKewWords();
                    tmp.Status = 0;
                    tmp.Orders = 0;
                    tmp.AddTime = DateTime.Now;
                    tmp.UpdateTime = DateTime.Now;
                    tmp.Type = 0;
                    tmp.Description = txtcontent.Value;
                    db.WXKewWords.AddObject(tmp);
                }
                try
                {
                    db.SaveChanges();
                    jsHint.Alert("智能客服信息编辑成功!");
                }
                catch (Exception et)
                {
                    jsHint.Alert("错误信息" + et.Message);
                }
            }
        }
    }
}