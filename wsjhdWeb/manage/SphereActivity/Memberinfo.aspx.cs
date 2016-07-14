using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using System.Collections.Generic;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.SphereActivity
{
    public partial class Memberinfo : ManageBasePage
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Activity)this.Master).txtTitle = " 会员信息管理";
                using (WXDBEntities db = new WXDBEntities())
                {

                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        Forms model = db.Forms.Where(s => s.Id == tmpid).Where(s => s.FormType == 1).FirstOrDefault();
                        if (model != null)
                        {
                            db.Forms.DeleteObject(model);
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
                //圈层活动报名
                IQueryable<Forms> carlist = db.Forms.OrderBy(o => o.Orders).ThenByDescending(o => o.AddTime).Where(s => s.Type == 6);

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
                WebUtil.CtrlToList<Forms>(rptnews, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }
  
    }
}