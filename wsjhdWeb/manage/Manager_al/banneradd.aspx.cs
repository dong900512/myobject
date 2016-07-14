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
namespace NewInfoWeb.manage.Manager_al
{
    public partial class banneradd : System.Web.UI.Page
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
                string reqStrUrl = "bannerlist.aspx";
                //if (Request.UrlReferrer != null)
                //{
                //    reqStrUrl = Request.UrlReferrer.ToString();
                //}
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
                var model = db.Forms.Where(s => s.Id.Equals(p)).FirstOrDefault();
                if (model != null)
                {
                    txttitle.Text = model.Title;
                    txttzinfo.Text = model.Source;
                    txtOrders.Text = model.Orders.ToString();
                    if (!string.IsNullOrEmpty(model.Income))
                    {
                        hyp.Text = "查看封面信息";
                        curimg = globalVariables.NewsImgServer + model.Income;
                        hyp.NavigateUrl = globalVariables.NewsImgServer + model.Income;
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
                jsHint.Back("请填写标题信息！");
                return;
            }
            if (string.IsNullOrEmpty(txttzinfo.Text.Trim()))
            {
                jsHint.Back("请填写跳转链接信息");
                return;
            }
            if (!WebUtil.IsDigit(txtOrders.Text.Trim()))
            {
                jsHint.Back("排序号请输入数字！");
                return;
            }

            using (WXDBEntities db = new WXDBEntities())
            {
                var addobj = new Forms();
                if (aid != -1)
                {
                    addobj = db.Forms.Where(s => s.Id == aid).FirstOrDefault();
                    if (addobj != null)
                    {
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 640, 300);
                        if (str.Equals("0"))
                        {

                        }
                        else
                        {
                            addobj.Income = str;
                        }

                    }
                    else
                    {
                        addobj = new Forms();
                        addobj.AddTime = DateTime.Now;
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 640, 300);
                        if (str.Equals("0"))
                        {
                            jsHint.Back("请上传图片后进行操作!");
                            return;
                        }
                        else
                        {
                            addobj.Income = str;
                        }
                    }
                }
                addobj.Title = txttitle.Text;
                addobj.Orders = string.IsNullOrEmpty(txtOrders.Text) ? 0 : int.Parse(txtOrders.Text);
                addobj.FormType = 0;
                addobj.Source = txttzinfo.Text.Trim();
                addobj.Name = "";
                addobj.Mobile = "";
                addobj.Remark = "";
                addobj.AddTime = DateTime.Now;
                addobj.Status = 0;
                addobj.UpdateTime = DateTime.Now;
                addobj.Extend = "";
                addobj.Extend2 = "";
                addobj.Type = 22;
                addobj.JFCount = 0;
                ///类别

                if (string.IsNullOrEmpty(hyp.Text))
                {
                    db.Forms.AddObject(addobj);
                }
                db.SaveChanges();
                jsHint.toUrl("活动banner" + addobj.Title + "操作成功!", "bannerlist.aspx");
            }
        }
    }
}