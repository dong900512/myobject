using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using System.IO;
using WXEF;

namespace NewInfoWeb.manage.SphereActivity
{
    public partial class ActivityEdit : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Activity)this.Master).txtTitle = "活动信息编辑";

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
                var model = db.Activity.Where(s => s.ID == tmpid).FirstOrDefault();
                if (model != null)
                {
                    //drpActityType.SelectedValue = model.Type.ToString();
                    txttitle.Text = model.Title;
                    txtStart.Text = model.StartTime.ToString("yyyy-MM-dd");
                    txtEnd.Text = model.EndTime.ToString("yyyy-MM-dd");
                    txtsummary.Text = model.Description;
                    txtcontent.Value = model.Contents;
                    if (!string.IsNullOrEmpty(model.Conver))
                    {
                        hyp.Text = "查看封面信息";
                        hyp.NavigateUrl = globalVariables.NewsImgServer + model.Conver;

                    }
                    txtorders.Text = model.Orders.ToString();
                    rdisshow.SelectedValue = model.Status.ToString();
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
            using (WXDBEntities db = new WXDBEntities())
            {
                int tmpid = Convert.ToInt32(Request.Params["id"]);
                var addobj = db.Activity.Where(s => s.ID == tmpid).FirstOrDefault();
                if (addobj != null)
                {


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
                    try
                    {
                        db.SaveChanges();
                        jsHint.toUrl("活动信息" + addobj.Title + "修改成功!", "ActivityList.aspx");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

        }
    }

}