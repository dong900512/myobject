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
namespace NewInfoWeb.manage.Manager_LiveInfo
{
    public partial class LiveInfoBMList : ManageBasePage
    {
        protected int count = 0;
        public int aid = DNTRequest.RequstInt("tid");
        protected string str = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        Forms model = db.Forms.Where(s => s.Id == tmpid).FirstOrDefault();
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
                var tmodel = db.Article.Where(s => s.AritcleID.Equals(aid)).FirstOrDefault();
                str = tmodel.Title;
                IQueryable<Forms> carlist = db.Forms.Where(s => s.Status.Equals(0) && s.Type.Equals(0) && s.FormType.Equals(aid)).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);

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
                WebUtil.CtrlToList<Forms>(rptLoop, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }
    }
}