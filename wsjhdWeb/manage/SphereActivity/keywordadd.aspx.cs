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
    public partial class keywordadd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Activity)this.Master).txtTitle = "关键词信息添加";
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
                //var tmp = db.WXKewWords.Where(s => s.Type == 1).FirstOrDefault();
                //if (tmp != null)
                //{
                //    tmp.Description = txtcontent.Value;
                //}
                //else
                //{
                var tmp = new WXKewWords();
                var m1 = db.WXKewWords.Where(s => s.Title.Equals(txtKeword.Text.Trim())).FirstOrDefault();
                if (m1 != null)
                {
                    jsHint.Back("已存在该关键词信息,请重新输入关键词！");
                    return;
                }
                tmp.Title = txtKeword.Text.Trim();
                tmp.Status = 0;
                tmp.Orders = 0;
                tmp.AddTime = DateTime.Now;
                tmp.UpdateTime = DateTime.Now;
                tmp.Type = 1;
                tmp.Description = txtcontent.Value;
                db.WXKewWords.AddObject(tmp);
                //}
                try
                {
                    db.SaveChanges();
                    jsHint.toUrl("关键词信息添加成功!", "keyword.aspx");
                }
                catch (Exception et)
                {
                    jsHint.Alert("错误信息" + et.Message);
                }
            }
        }
    }
}