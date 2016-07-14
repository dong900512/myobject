using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;
using NewInfoWeb.Appcode;
using System.IO;
namespace NewInfoWeb.manage.Manager_LiveInfo
{
    public partial class ActivityBannerAdd : ManageBasePage
    {
        public int aid = DNTRequest.RequstInt("id");
        public string change = DNTRequest.RequstString("change");
        protected string curimg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["change"] == "edit" && aid != -1)
                {
                    ShowInfo(this.aid);
                }
                string reqStrUrl = "ActivityBannerList.aspx";
                if (Request.UrlReferrer != null)
                {
                    reqStrUrl = Request.UrlReferrer.ToString();
                }
                btn_Back.Attributes.Add("onclick", "window.location.href='" + reqStrUrl + "';return false;");

            }

        }
        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="p"></param>
        private void ShowInfo(int p)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model = db.AResource.Where(s => s.RId.Equals(p)).FirstOrDefault();
                if (model != null)
                {
                    txttitle.Text = model.Title;

                    txtOrders.Text = model.ArticleID.ToString();
                    if (!string.IsNullOrEmpty(model.Creation))
                    {
                        hyp.Text = "查看封面信息";
                        curimg = globalVariables.NewsImgServer + model.Creation;
                        hyp.NavigateUrl = globalVariables.NewsImgServer + model.Creation;
                        slt.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_click_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txttitle.Text.Trim()))
            {
                jsHint.Back("请输入图片名称信息！");
                return;
            }

            if (!WebUtil.IsDigit(txtOrders.Text.Trim()))
            {
                jsHint.Back("排序号请输入数字！");
                return;
            }

            using (WXDBEntities db = new WXDBEntities())
            {
                var addobj = new AResource();
                if (aid != -1)
                {
                    addobj = db.AResource.Where(s => s.RId == aid).FirstOrDefault();
                    if (addobj != null)
                    {
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 640, 300);
                        if (str.Equals("没有选择上传图片") || str.Equals("图片格式不正确") || str.Equals("没有选择图片"))
                        {

                        }
                        else
                        {
                            addobj.Creation = str;
                        }

                    }
                    else
                    {
                        addobj = new AResource();
                        addobj.AddTime = DateTime.Now;
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 640, 300);
                        if (str.Equals("没有选择上传图片") || str.Equals("图片格式不正确") || str.Equals("没有选择图片"))
                        {
                            jsHint.Back("请选择封面后进行操作!");
                            return;
                        }
                        else
                        {
                            addobj.Creation = str;
                        }
                    }
                }

                addobj.Title = txttitle.Text;
                addobj.ArticleID = string.IsNullOrEmpty(txtOrders.Text) ? 0 : int.Parse(txtOrders.Text);
                addobj.Contents = "";
                addobj.Description = "";

                ///类别
                addobj.Extend = "0";
                addobj.AddTime = DateTime.Now;
                addobj.UpdateTime = DateTime.Now;
                addobj.Extend1 = "";
                if (string.IsNullOrEmpty(hyp.Text))
                {
                    db.AResource.AddObject(addobj);
                }
                db.SaveChanges();
                jsHint.toUrl("信息" + addobj.Title + "操作成功!", "ActivityBannerList.aspx");
            }
        }
    }
}