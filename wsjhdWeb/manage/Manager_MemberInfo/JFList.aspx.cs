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
namespace NewInfoWeb.manage.Manager_MemberInfo
{
    public partial class JFList : System.Web.UI.Page
    {
        protected int count = 0;
        protected string topid = DNTRequest.RequstString("topid");
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

                        UserPoinLog model = db.UserPoinLog.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            var tm = db.Forms.Where(s => s.Source.Equals(topid) && s.Type.Equals(8)).FirstOrDefault();
                            if (tm != null)
                            {
                                //tm.JFCount = tm.JFCount - Convert.ToDecimal(model.Extent1);
                               // tm.Status = tm.Status - 1;
                            }
                            db.UserPoinLog.DeleteObject(model);
                            db.SaveChanges();
                        }
                    }

                }
                BindRepeater(topid);
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                var tm = db.Forms.Where(s => s.Source.Equals(topid) && s.Type.Equals(8)).FirstOrDefault();
                if (tm != null)
                {
                    ctitile = tm.Name;
                }
            }

        }

        private void BindRepeater(string tid)
        {
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                    page = int.Parse(Request["page"] + "");
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<UserPoinLog> carlist = db.UserPoinLog.Where(s => s.WxOpenid.Equals(topid)).OrderByDescending(s => s.AddTime);
                if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.UserPointDesc.Contains(txtKeywords.Text));
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
                WebUtil.CtrlToList<UserPoinLog>(rptLoop, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater(topid);
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRepeater(topid);
        }
    }
}