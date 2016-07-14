using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dos.Model;
using Dos.ORM;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.Manager_Groups
{
    public partial class Manager_Groups_List : ManageBasePage
    {
        public int TotalCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                {

                    int tmpid = Convert.ToInt32(Request["del"]);
                    var model = DbSession.Default.From<Dos.Model.Manager_Groups>().Where(s => s.Id.Equals(tmpid)).ToFirstDefault();
                    if (model.Id > 0)
                    {
                        model.Attach();
                        model.Status = 1;
                        int ts = DbSession.Default.Update<Dos.Model.Manager_Groups>(model);
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
            FromSection<Dos.Model.Manager_Groups> fromsection = DbSession.Default.From<Dos.Model.Manager_Groups>()
           .Where(s => s.Status.Equals(0))
           .OrderBy(s => s.AddTime).OrderByDescending(s => s.Id);

            //List<object> listDesc = new List<object>();
            //var  carlist = DbSession.Default.fr.Manager_Groups.Where(s => s.Status.Equals(0)).OrderBy(o => o.AddTime).ThenByDescending(o => o.Id);

            if (!string.IsNullOrEmpty(txtKeywords.Text.Trim()))
            {
                fromsection = fromsection.Where(s => s.Name.Contains(txtKeywords.Text));
            }
            //carlist.ToPagedList(page, AspNetPager1.PageSize);
            AspNetPager1.RecordCount = fromsection.Count();
            ltlCount.Text = "<b>" + fromsection.Count() + "</b>";
            var dblist = fromsection.Page(AspNetPager1.PageSize, page).ToList();
            if (!this.IsPostBack)
            {
                if (Request["page"] + "" != "")
                {
                    int temp = int.Parse(Request["page"] + "");
                    AspNetPager1.CurrentPageIndex = temp;
                }
            }
            WebUtil.CtrlToList<Dos.Model.Manager_Groups>(rptLoop, dblist);

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AuthItem">权限项</param>
        /// <param name="authID">权限ID</param>
        /// <param name="name">角色名称</param>
        /// <param name="Mark">说明</param>
        /// <returns></returns>
        public string EditUrl(string AuthItem, string authID, string name, string Mark, object xmno)
        {
            return "Manager_Groups_Add.aspx?AuthItem=" + AuthItem + "&AuthID=" + authID + "&Name=" + name + "&Mark=" + Mark + "&xmno=" + xmno;
        }
    }
}