using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class SysNewsList : ManageBasePage
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SysNewsmaster)this.Master).txtTitle = "新闻信息的管理";
                using (WXDBEntities db = new WXDBEntities())
                {
                    WebUtil.DrpToListEx<ArticleType>(drpType,
                      db.ArticleType.Where(s => s.Status == 0).OrderBy(s => s.ID).ToList(), "TypeName", "ID");
                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {

                        int tmpid = Convert.ToInt32(Request["del"]);
                        Article model = db.Article.Where(s => s.AritcleID == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            db.Article.DeleteObject(model);
                            db.SaveChanges();
                        }
                    }
                }
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                    page = int.Parse(Request["page"] + "");
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<Article> carlist = db.Article.OrderBy(o => o.Orders).ThenByDescending(o => o.AritcleID);
                if (drpType.SelectedValue != "-1")
                {
                    int tmptype = Convert.ToInt32(drpType.SelectedValue);
                    carlist = carlist.Where(s => s.Type == tmptype);
                }
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.Title.Contains(txtSearch.Text));
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
                WebUtil.CtrlToList<Article>(rptnews, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRepeater();
        }
    }

}