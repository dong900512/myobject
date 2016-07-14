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
    public partial class keywordedit : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Activity)this.Master).txtTitle = "关键词信息编辑";
            if (!this.IsPostBack)
            {
                InitCtrls();
            }
        }
        private void InitCtrls()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var tmpid = Convert.ToInt32(Request.Params["id"]);
                var tmp = db.WXKewWords.Where(s => s.Id == tmpid).FirstOrDefault();
                if (tmp != null)
                {
                    txtKeword.Text = tmp.Title;
                    txtcontent.Value = tmp.Description;
                }
            }
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            //if (drpActityType.SelectedValue == "-1")
            //{
            //    jsHint.Back("请选择活动信息类别！");
            //    return;
            //}
            if (string.IsNullOrEmpty(txtKeword.Text.Trim()))
            {
                jsHint.Back("请输入关键词！");
                return;
            }
            if (string.IsNullOrEmpty(txtcontent.Value.Trim()))
            {
                jsHint.Back("请输入关键词信息！");
                return;
            }
            using (WXDBEntities db = new WXDBEntities())
            {

                var tmpid = Convert.ToInt32(Request.Params["id"]);
                var m1 = db.WXKewWords.Where(s => s.Title.Equals(txtKeword.Text.Trim())).Where(s => s.Id != tmpid).FirstOrDefault();
                if (m1 != null)
                {
                    jsHint.Back("已存在该关键词信息,请重新输入关键词！");
                    return;
                }
                var tmp = db.WXKewWords.Where(s => s.Id == tmpid).FirstOrDefault();
                if (tmp != null)
                {
                    tmp.Title = txtKeword.Text.Trim();
                    tmp.Description = txtcontent.Value;
                    tmp.UpdateTime = DateTime.Now;
                }
                else
                {
                    tmp = new WXKewWords();
                    tmp.Title = txtKeword.Text.Trim();
                    tmp.Status = 0;
                    tmp.Orders = 0;
                    tmp.AddTime = DateTime.Now;
                    tmp.UpdateTime = DateTime.Now;
                    tmp.Type = 1;
                    tmp.Description = txtcontent.Value;
                    db.WXKewWords.AddObject(tmp);
                }
                try
                {
                    db.SaveChanges();
                    jsHint.toUrl("关键词信息编辑成功!", "keyword.aspx");
                }
                catch (Exception et)
                {
                    jsHint.Alert("错误信息" + et.Message);
                }
            }
        }
    }
}