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
    public partial class HdPostList : System.Web.UI.Page
    {
        protected int count = 0;
        protected int tid = DNTRequest.RequstInt("tid");
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
                        Posts model = db.Posts.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            //string strsql = "update Article set status=1 where Type=" + model.ID;
                            //db.ExecuteStoreCommand(strsql);
                            //db.ArticleType.DeleteObject(model);.
                            var tm = db.Forms.Where(s => s.Id.Equals(tid) && s.Type.Equals(2)).FirstOrDefault();
                            if (tm != null)
                            {
                                tm.Status = tm.Status - 1;
                            }
                            db.Posts.DeleteObject(model);
                            db.SaveChanges();
                        }
                    }

                }
                BindRepeater(tid + "");
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                var tm = db.Forms.Where(s => s.Id.Equals(tid) && s.Type.Equals(2)).FirstOrDefault();
                if (tm != null)
                {
                    ctitile = tm.Title;
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
                IQueryable<Posts> carlist = db.Posts.Where(s => s.Extend1.Equals("0") && s.Extend.Equals(tid)).OrderBy(o => o.Orders).ThenByDescending(o => o.AddTime);


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
                WebUtil.CtrlToList<Posts>(rptLoop, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater(tid + "");
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRepeater(tid + "");
        }
    }
}