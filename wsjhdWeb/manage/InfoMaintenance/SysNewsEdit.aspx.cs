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
    public partial class SysNewsEdit : ManageBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SysNewsmaster)this.Master).txtTitle = "新闻信息编辑";
            if (!this.IsPostBack)
            {
                InitCtrls();
                BindData(Convert.ToInt32(Request.Params["id"]));
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

        /// <summary>
        /// 绑定数据信息
        /// </summary>
        /// <param name="tmpid"></param>
        public void BindData(int tmpid)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = db.Article.Where(s => s.AritcleID == tmpid).FirstOrDefault();
                if (model != null)
                {

                    drptype.SelectedValue = model.Type.ToString();
                    txttitle.Text = model.Title;
                    txtkeyword.Text = model.Extend1;
                    txtsummary.Text = model.Description;
                    txtcontent.Value = model.Contents;
                    txtorders.Text = model.Orders.ToString();
                    rdisshow.SelectedValue = model.Status.ToString();
                    txtStart.Text = model.AddTime.ToString("yyyy-MM-dd");
                    if (!string.IsNullOrEmpty(model.Cover))
                    {
                        hyp.Text = "查看封面信息";
                        hyp.NavigateUrl = globalVariables.NewsImgServer + model.Cover;

                    }
                }
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
            using (WXDBEntities db = new WXDBEntities())
            {
                int tmpid = Convert.ToInt32(Request.Params["Id"]);
                var addobj = db.Article.Where(s => s.AritcleID == tmpid).FirstOrDefault();
                var tmpmodel = db.Article.Where(s => s.Title == txttitle.Text).Where(s => s.AritcleID != tmpid).FirstOrDefault();
                if (tmpmodel != null)
                {
                    jsHint.Back("请重新输入标题信息");
                    return;
                }
                addobj.Title = txttitle.Text;
                addobj.Orders = string.IsNullOrEmpty(txtorders.Text) ? 0 : int.Parse(txtorders.Text);
                addobj.Contents = txtcontent.Value; ;
                addobj.Description = txtsummary.Text;
                addobj.Status = rdisshow.SelectedValue == "0" ? 0 : 1;
                ///关键字
                addobj.Extend1 = txtkeyword.Text;
                addobj.Type = Convert.ToInt32(drptype.SelectedValue);
                addobj.UpdateTime = DateTime.Now;
                if (string.IsNullOrEmpty(txtStart.Text))
                {
                    addobj.AddTime = DateTime.Now;
                }
                else
                {
                    addobj.AddTime = Convert.ToDateTime(txtStart.Text);
                }

                //修改人
                addobj.Extend2 = loginname;

                if (upPic.HasFile)
                {
                    string _imgpath = Guid.NewGuid().ToString() + Path.GetExtension(upPic.FileName).ToLower();
                    upPic.PostedFile.SaveAs(globalVariables.NewsImgPath + _imgpath);
                    addobj.Cover = _imgpath;
                }
                db.SaveChanges();
                jsHint.toUrl("信息" + addobj.Title + "修改成功!", "SysNewsList.aspx");
            }
        }
    }

}