using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.Manager_llHD
{
    public partial class TagList : System.Web.UI.Page
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {

                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        Article model = db.Article.Where(s => s.AritcleID == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            model.Status = 2;
                            //string strsql = "update Article set status=1 where Type=" + model.ID;
                            //db.ExecuteStoreCommand(strsql);
                            //db.ArticleType.DeleteObject(model);
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
                IQueryable<Article> carlist = db.Article.Where(s => (!s.Status.Equals(2)) && s.Type.Equals(24)).OrderBy(o => o.Orders).ThenByDescending(o => o.AritcleID);

                if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.Title.Contains(txtKeywords.Text));
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
                WebUtil.CtrlToList<Article>(rptLoop, dblist);
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