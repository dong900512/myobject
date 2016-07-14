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
namespace NewInfoWeb.manage.Manager_llHD
{
    public partial class ProductAdd : ManageBasePage
    {
        public int aid = DNTRequest.RequstInt("tid");
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
                string reqStrUrl = "ProductList.aspx";
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
                var model = db.Product.Where(s => s.Id.Equals(p)).FirstOrDefault();
                if (model != null)
                {
                    txttitle.Text = model.RealName;
                    txtdhjf.Text = model.Extent1;
                    txtckj.Text = model.Extent2;
                    txtnums.Text = model.Nums + "";

                    txtStart.Text = model.AddTime.ToString("yyyy-MM-dd");
                    if (!string.IsNullOrEmpty(model.PicUrl))
                    {
                        hyp.Text = "查看封面信息";
                        curimg = globalVariables.NewsImgServer + model.PicUrl;
                        hyp.NavigateUrl = globalVariables.NewsImgServer + model.PicUrl;
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
                jsHint.Back("请输入名称信息！");
                return;
            }

            using (WXDBEntities db = new WXDBEntities())
            {
                var addobj = new Product();
                if (aid != -1)
                {
                    addobj = db.Product.Where(s => s.Id.Equals(aid)).FirstOrDefault();
                    if (addobj != null)
                    {
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 210, 160);
                        if (str.Equals("没有选择上传图片") || str.Equals("图片格式不正确") || str.Equals("没有选择图片"))
                        {

                        }
                        else
                        {
                            addobj.PicUrl = str;
                        }

                    }
                    else
                    {
                        addobj = new Product();
                        string str = WebUtil.UpLoadImage(upfile, "/Files/NewsImg/", Guid.NewGuid().ToString().ToLower(), 291, 221);
                        if (str.Equals("没有选择上传图片") || str.Equals("图片格式不正确") || str.Equals("没有选择图片"))
                        {
                            jsHint.Back("请选择封面后进行操作!");
                            return;
                        }
                        else
                        {
                            addobj.PicUrl = str;
                        }
                    }
                }
                var tmpmodel = db.Product.Where(s => s.RealName.Equals
                (txttitle.Text)).Where(s => s.Id != aid).FirstOrDefault();
                if (tmpmodel != null)
                {
                    jsHint.Back("该礼品已存在，请重新输入信息");
                    return;
                }
                addobj.RealName = txttitle.Text;
                addobj.Extent1 = txtdhjf.Text;
                addobj.Extent2 = txtckj.Text;
                addobj.Extent3 = "0";
                addobj.Nums = Convert.ToInt32(txtnums.Text);
                if (string.IsNullOrEmpty(txtStart.Text))
                {
                    addobj.AddTime = DateTime.Now;
                }
                else
                {
                    addobj.AddTime = Convert.ToDateTime(txtStart.Text);
                }

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

                if (string.IsNullOrEmpty(hyp.Text))
                {
                    db.Product.AddObject(addobj);
                }
                db.SaveChanges();
                jsHint.toUrl("礼品信息" + addobj.RealName + "操作成功!", "ProductList.aspx");
            }
        }
    }
}