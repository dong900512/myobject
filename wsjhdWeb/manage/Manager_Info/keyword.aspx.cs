using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.Manager_Info
{
    public partial class keyword : System.Web.UI.Page
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
                        WXKewWords model = db.WXKewWords.Where(s => s.Id == tmpid && s.Type != 0).FirstOrDefault();
                        if (model != null)
                        {
                            db.WXKewWords.DeleteObject(model);
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
                IQueryable<WXKewWords> carlist = db.WXKewWords.Where(s => s.Status.Equals(0) && s.Type != 0).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);

                if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.Kewords.ToLower().Contains(txtKeywords.Text.ToLower()));
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
                WebUtil.CtrlToList<WXKewWords>(rptLoop, dblist);
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