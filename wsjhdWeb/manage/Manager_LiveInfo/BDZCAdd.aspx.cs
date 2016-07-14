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
    public partial class BDZCAdd : ManageBasePage
    {
        public int aid = DNTRequest.RequstInt("id");
        public int typid = DNTRequest.RequstInt("typid") == 0 ? 5 : DNTRequest.RequstInt("typid");
        protected string stTitle = string.Empty;
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
                WebConn.ManageInfoType sex = (WebConn.ManageInfoType)typid;
                switch (sex)
                {
                    case WebConn.ManageInfoType.自驾车租赁:
                        stTitle = WebConn.ManageInfoType.自驾车租赁.ToString();
                        break;
                    case WebConn.ManageInfoType.万宁站租车服务:
                        stTitle = WebConn.ManageInfoType.万宁站租车服务.ToString();
                        break;
                    case WebConn.ManageInfoType.自行车租赁:
                        stTitle = WebConn.ManageInfoType.自行车租赁.ToString();
                        break;
                }
                string reqStrUrl = "BDZCList.aspx?tid=" + typid;
                hidTyp.Value = typid + "";
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
                var model = db.Article.Where(s => s.AritcleID.Equals(p)).FirstOrDefault();
                if (model != null)
                {
                    txttitle.Text = model.Title;
                    txtkeyword.Text = model.Extend1;
                    txtsummary.Text = model.Description;
                    hid1.Value = "1";
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
                var tmpmodel = db.Article.Where(s => s.Title == txttitle.Text && s.Type.Equals(typid)).Where(s => s.AritcleID != aid).FirstOrDefault();
                if (tmpmodel != null)
                {
                    jsHint.Back("该标题已存在，请重新输入标题信息");
                    return;
                }
                addobj.Title = txttitle.Text;
                addobj.Orders = string.IsNullOrEmpty(txtOrders.Text) ? 0 : int.Parse(txtOrders.Text);
                addobj.Contents = "";
                addobj.Description = txtsummary.Text;
                addobj.Status = 0;
                ///关键字
                addobj.Extend1 = txtkeyword.Text;
                addobj.Type = Convert.ToInt32(hidTyp.Value);
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
                if (hid1.Value == "0")
                {
                    db.Article.AddObject(addobj);
                }
                db.SaveChanges();
                jsHint.toUrl("信息" + addobj.Title + "操作成功!", "BDZCList.aspx?tid=" + hidTyp.Value);
            }
        }
    }
}