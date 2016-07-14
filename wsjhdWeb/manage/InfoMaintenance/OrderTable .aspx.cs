﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class OrderTable : ManageBasePage
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SysNewsmaster)this.Master).txtTitle = "看房预约信息的管理";
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
                IQueryable<Forms> carlist = db.Forms.OrderBy(o => o.Orders).ThenByDescending(o => o.AddTime).Where(s => s.Type == 0);
                if (!string.IsNullOrEmpty(txtStart.Value.Trim()) && !string.IsNullOrEmpty(txtEnd.Value.Trim()))
                {
                    DateTime strtime = Convert.ToDateTime(txtStart.Value);
                    DateTime endtime = Convert.ToDateTime(txtEnd.Value);
                    carlist = carlist.Where(s => s.AddTime >= strtime && s.AddTime <= endtime);
                }

                else if (!string.IsNullOrEmpty(txtStart.Value.Trim()))
                {
                    DateTime strtime = Convert.ToDateTime(txtStart.Value);
                    carlist = carlist.Where(s => s.AddTime >= strtime);
                }
                else if (!string.IsNullOrEmpty(txtEnd.Value.Trim()))
                {
                    DateTime endtime = Convert.ToDateTime(txtEnd.Value);
                    carlist = carlist.Where(s => s.AddTime <= endtime);
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
                WebUtil.CtrlToList<Forms>(rptnews, dblist);
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