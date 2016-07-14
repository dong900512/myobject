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
    public partial class PicShowList : ManageBasePage
    {
        protected int tmpPicTypeid = 0;
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SysNewsmaster)this.Master).txtTitle = "图片类型信息的管理";
                using (WXDBEntities db = new WXDBEntities())
                {
                    if (!string.IsNullOrEmpty(Request["delt"]) && WebUtil.IsDigit(Request["delt"]))
                    {
                        int tmpid = Convert.ToInt32(Request["delt"]);
                        PicShow model = db.PicShow.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            db.PicShow.DeleteObject(model);
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
                tmpPicTypeid = Convert.ToInt32(Request.Params["del"]);
                IQueryable<PicShow> carlist = db.PicShow.OrderBy(o => o.Orders).ThenByDescending(o => o.Id).Where(s => s.Status == 0).Where(s => s.Type == tmpPicTypeid);
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
                WebUtil.CtrlToList<PicShow>(rptnews, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    jsHint.toUrl("PicShowAdd.aspx?pictypeid=" + Request.Params["del"]);
        //}
    }
}