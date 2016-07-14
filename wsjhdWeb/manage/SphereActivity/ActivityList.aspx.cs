using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.SphereActivity
{
    public partial class ActivityList : ManageBasePage
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Activity)this.Master).txtTitle = "活动信息管理";
                using (WXDBEntities db = new WXDBEntities())
                {
                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        WXEF.Activity model = db.Activity.Where(s => s.ID == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            db.Activity.DeleteObject(model);
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
                IQueryable<WXEF.Activity> carlist = db.Activity.OrderBy(o => o.Orders).ThenByDescending(o => o.ID);
                if (drpActityType.SelectedValue != "-1")
                {
                    int tmptype = Convert.ToInt32(drpActityType.SelectedValue);
                    carlist = carlist.Where(s => s.Type == tmptype);
                }
                if (drpisshow.SelectedValue != "-1")
                {
                    int tmpStatus = Convert.ToInt32(drpisshow.SelectedValue);
                    carlist = carlist.Where(s => s.Status == tmpStatus);
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
                WebUtil.CtrlToList<WXEF.Activity>(rptnews, dblist);
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