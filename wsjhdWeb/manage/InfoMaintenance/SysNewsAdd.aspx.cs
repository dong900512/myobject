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
    public partial class SysNewsAdd : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "新闻信息添加";
            if (!this.IsPostBack)
            {
                InitCtrls();
            }
        }

        private void InitCtrls()
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                WebUtil.DrpToListEx<ArticleType>(drptype,
                        db.ArticleType.Where(s => s.Status == 0).OrderBy(s => s.ID).ToList(), "TypeName", "ID");//(
            }

        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (drptype.SelectedValue == "-1")
            {
                jsHint.Back("请选择信息类别！");
                return;
            }
            if (string.IsNullOrEmpty(txttitle.Text.Trim()))
            {
                jsHint.Back("请输入标题信息！");
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
            Article addobj = new Article();
            addobj.Title = txttitle.Text;
            addobj.Extend = loginname;
            addobj.Orders = string.IsNullOrEmpty(txtorders.Text) ? 0 : int.Parse(txtorders.Text);
            addobj.Contents = txtcontent.Value; ;
            addobj.Description = txtsummary.Text.Trim();
            addobj.Extend1 = txtkeyword.Text.Trim();
            if (string.IsNullOrEmpty(txtStart.Text))
            {
                addobj.AddTime = DateTime.Now;
            }
            else
            {
                addobj.AddTime = Convert.ToDateTime(txtStart.Text);
            }
            addobj.Status = rdisshow.SelectedValue == "0" ? 0 : 1;
            addobj.Type = Convert.ToInt32(drptype.SelectedValue);

            addobj.UpdateTime = DateTime.Now;
            addobj.Extend2 = loginname;
            if (upPic.HasFile)
            {
                string _imgpath = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();
                upPic.PostedFile.SaveAs(globalVariables.NewsImgPath + _imgpath);
                addobj.Cover = _imgpath;
            }
            else
            {
                jsHint.Back("请上传封面图片信息！");
                return;
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                db.Article.AddObject(addobj);
                db.SaveChanges();
                jsHint.toUrl("信息" + addobj.Title + "增加成功!", "SysNewsList.aspx");
            }
        }
    }
}