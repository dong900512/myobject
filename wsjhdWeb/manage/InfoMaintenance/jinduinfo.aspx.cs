using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class jinduinfo : ManageBasePage
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SysNewsmaster)this.Master).txtTitle = "进度图片管理";
                using (WXDBEntities db = new WXDBEntities())
                {

                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {

                        int tmpid = Convert.ToInt32(Request["del"]);
                        TuInfo model = db.TuInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            db.TuInfo.DeleteObject(model);
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
                IQueryable<TuInfo> carlist = db.TuInfo.Where(s => s.status == 0 && s.extend3 == "2").OrderBy(s => s.orders).ThenByDescending(s => s.addtime);
                //if (drpType.SelectedValue != "-1")
                //{
                //    int tmptype = Convert.ToInt32(drpType.SelectedValue);
                //    carlist = carlist.Where(s => s.Type == tmptype);
                //}
                //if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                //{
                //    carlist = carlist.Where(s => s.Title.Contains(txtSearch.Text));
                //}
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
                WebUtil.CtrlToList<TuInfo>(rptnews, dblist);
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
            jsHint.toUrl("jinduAddinfo.aspx");
        }
    }
}