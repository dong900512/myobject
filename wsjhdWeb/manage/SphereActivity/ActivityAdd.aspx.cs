using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using System.IO;

namespace NewInfoWeb.manage.SphereActivity
{
    public partial class ActivityAdd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Activity)this.Master).txtTitle = "活动信息添加";

            if (!this.IsPostBack)
            {
                InitCtrls();
            }
        }

        private void InitCtrls()
        {


        }


        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            //if (drpActityType.SelectedValue == "-1")
            //{
            //    jsHint.Back("请选择活动信息类别！");
            //    return;
            //}
            if (string.IsNullOrEmpty(txttitle.Text.Trim()))
            {
                jsHint.Back("请输入活动标题！");
                return;
            }
            if (string.IsNullOrEmpty(txtorders.Text.Trim()))
            {
                jsHint.Back("请输入排序号！");
                return;
            }
            if (!WebUtil.IsDigit(txtorders.Text.Trim()))
            {
                jsHint.Back("排序号请输入数字！");
                return;
            }
            if (string.IsNullOrEmpty(txtcontent.Value))
            {
                jsHint.Back("请输入内容信息！");
                return;
            }
            WXEF.Activity addobj = new WXEF.Activity();
            addobj.Title = txttitle.Text;
            addobj.Entitle = "";
            addobj.Author = loginname;
            addobj.UpdateAuthor = loginname;

            addobj.Orders = string.IsNullOrEmpty(txtorders.Text) ? 0 : int.Parse(txtorders.Text);
            addobj.Contents = txtcontent.Value; ;
            addobj.Description = txtsummary.Text.Trim();
            addobj.StartTime = Convert.ToDateTime(txtStart.Text.Trim());
            addobj.EndTime = Convert.ToDateTime(txtEnd.Text.Trim());
            addobj.AddTime = DateTime.Now;
            addobj.Status = rdisshow.SelectedValue == "0" ? 0 : 1;
            addobj.Type = 0;// Convert.ToInt32(drpActityType.SelectedValue);
            addobj.UpdateTime = DateTime.Now;

            if (upPic.HasFile)
            {
                string _imgpath = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();
                upPic.PostedFile.SaveAs(globalVariables.NewsImgPath + _imgpath);
                addobj.Conver = _imgpath;
            }
            else
            {
                addobj.Conver = "";
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                db.Activity.AddObject(addobj);
                db.SaveChanges();
                jsHint.toUrl("活动信息" + addobj.Title + "增加成功!", "ActivityList.aspx");
            }
        }
    }
}