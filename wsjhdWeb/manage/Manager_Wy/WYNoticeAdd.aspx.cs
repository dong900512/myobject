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
namespace NewInfoWeb.manage.Manager_Wy
{
    public partial class WYNoticeAdd : ManageBasePage
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
                string reqStrUrl = "WYNoticeList.aspx";
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
                var model = db.Article.Where(s => s.AritcleID.Equals(p)).FirstOrDefault();
                if (model != null)
                {
                    txttitle.Text = model.Title;
                    txtcontent.Value = model.Contents;
                    txtOrders.Text = model.Orders.ToString();
                    txtStart.Text = model.AddTime.ToString("yyyy-MM-dd");
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
                jsHint.Back("请输入标题信息！");
                return;
            }
            if (string.IsNullOrEmpty(txtOrders.Text.Trim()))
            {
                jsHint.Back("请输入排序号！");
                return;
            }
            if (!WebUtil.IsDigit(txtOrders.Text.Trim()))
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
                var addobj = new Article();
                if (aid != -1)
                {
                    addobj = db.Article.Where(s => s.AritcleID == aid).FirstOrDefault();
                    if (addobj != null)
                    {

                    }
                    else
                    {
                        addobj = new Article();
                    }
                }
                //var tmpmodel = db.Article.Where(s => s.Title == txttitle.Text && s.Type.Equals(24)).Where(s => s.AritcleID != aid).FirstOrDefault();
                //if (tmpmodel != null)
                //{
                //    jsHint.Back("该标题已存在，请重新输入标题信息");
                //    return;
                //}
                addobj.Title = txttitle.Text;
                addobj.Orders = string.IsNullOrEmpty(txtOrders.Text) ? 0 : int.Parse(txtOrders.Text);
                addobj.Contents = txtcontent.Value; ;
                addobj.Description = "";
                addobj.Status = 0;
                ///关键字
                addobj.Extend1 = "";
                addobj.Type = 26;
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
                if (aid != -1)
                {
                    var addobj1 = db.Article.Where(s => s.AritcleID == aid).FirstOrDefault();
                    if (addobj1 != null)
                    {
                    }
                    else
                    {
                        db.Article.AddObject(addobj);
                    }
                }
                db.SaveChanges();
                jsHint.toUrl("信息" + addobj.Title + "操作成功!", "WYNoticeList.aspx");
            }
        }
    }
}