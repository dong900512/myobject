using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
using NewInfoWeb.Appcode;
namespace NewInfoWeb.manage.Manager_llHD
{
    public partial class LPDHList : System.Web.UI.Page
    {

        protected int count = 0;

        protected string cod = DNTRequest.RequstString("topid");
        protected string ctitile = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {

                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        Product model = db.Product.Where(s => s.Id.Equals(tmpid) && s.Extent3.Equals("1")).FirstOrDefault();
                        if (model != null)
                        {
                            //string strsql = "update Article set status=1 where Type=" + model.ID;
                            //db.ExecuteStoreCommand(strsql);
                            //db.ArticleType.DeleteObject(model);.
                            db.Product.DeleteObject(model);
                            db.SaveChanges();
                        }
                    }
                    if (!string.IsNullOrEmpty(Request["upd"]) && WebUtil.IsDigit(Request["upd"]))
                    {
                        int tmpid = Convert.ToInt32(Request["upd"]);
                        Product model = db.Product.Where(s => s.Id.Equals(tmpid) && s.Extent3.Equals("1")).FirstOrDefault();
                        if (model != null)
                        {
                            model.Status = 1;
                            db.SaveChanges();
                        }
                    }
                }
                BindRepeater(cod);
            }
            if (!string.IsNullOrEmpty(cod))
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    var tmodel = db.Forms.Where(s => s.Source.Equals(cod) && s.Type.Equals(8)).FirstOrDefault();
                    if (tmodel != null)
                    {
                        ctitile = tmodel.Name;
                    }
                }
            }
        }

        private void BindRepeater(string cod)
        {
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                    page = int.Parse(Request["page"] + "");
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<Product> carlist = db.Product.Where(s => s.Extent3.Equals("1") && s.Desction.Equals(cod)).OrderBy(o => o.AddTime);
                if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.RealName.Contains(txtKeywords.Text));
                }
                var dblist = carlist.ToPagedList(page, AspNetPager1.PageSize);
                AspNetPager1.RecordCount = dblist.TotalItemCount;
                ltlCount.Text = "<b>" + dblist.TotalItemCount + "</b>";
                if (!this.IsPostBack)
                {
                    if (Request["page"] + "" != "")
                    {
                        int temp = int.Parse(Request["page"] + "");
                        AspNetPager1.CurrentPageIndex = temp;
                    }
                }
                WebUtil.CtrlToList<Product>(rptLoop, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater(cod);
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRepeater(cod);
        }
    }
}