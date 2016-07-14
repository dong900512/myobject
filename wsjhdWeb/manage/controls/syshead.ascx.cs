using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;

namespace NewInfoWeb.manage.controls
{
    public partial class syshead : System.Web.UI.UserControl
    {
        private int trnum;
        public int trNum
        {
            set { trnum = value; }
            get { return trnum; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.trNum == 1)
                    this.trProcessRecord.Visible = true;
                else
                    this.trProcessRecord.Visible = false;

                txtCreateTime.Attributes.Add("onfocus", "setday(this)");
                txtCreateTime.Attributes.Add("style", "cursor:hand");
                using (WXDBEntities db = new WXDBEntities())
                {
                    WebUtil.DrpToListEx<SysAccount>(drpParentid, db.SysAccount.OrderByDescending(o => o.AccountID).ToList(), "LoginName", "AccountID");
                }
            }
        }


        /// <summary>
        /// 处理多级联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpParentid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 处理搜索操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSerachProcessRecord_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/manage/SysMaintenance/ProcessRecord.aspx?xAccountID=" + this.drpParentid.SelectedValue + "&xOpTime=" + this.txtCreateTime.Text.Trim());
        }
    }
}