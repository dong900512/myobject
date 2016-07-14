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
    public partial class QrCodeInfo : ManageBasePage
    {
        protected int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SysNewsmaster)this.Master).txtTitle = "关注来源信息的管理";
                using (WXDBEntities db = new WXDBEntities())
                {

                    if (!string.IsNullOrEmpty(Request["del"]) && WebUtil.IsDigit(Request["del"]))
                    {
                        int tmpid = Convert.ToInt32(Request["del"]);
                        WXEF.QrCodeInfo model = db.QrCodeInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            db.QrCodeInfo.DeleteObject(model);
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
                IQueryable<WXEF.QrCodeInfo> carlist = db.QrCodeInfo.OrderBy(o => o.Orders).ThenByDescending(o => o.AddTime);
                if (drpList.SelectedValue != "-1")
                {
                    var tmeVal = drpList.SelectedValue;
                    carlist = carlist.Where(s => s.QrCodeReslut.Contains(tmeVal));
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
                WebUtil.CtrlToList<WXEF.QrCodeInfo>(rptnews, dblist);
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

        protected string GetSourceInfo(object obj)
        {
            string tmpobj = string.Empty;
            try
            {
                tmpobj = obj.ToString().Replace("qrscene_", "");
            }
            catch (Exception)
            {

                tmpobj = "1";
            }
            string tmpreturn = string.Empty;
            switch (tmpobj)
            {
                case "1":
                    tmpreturn = "默认";
                    break;
                case "2":
                    tmpreturn = "电视";
                    break;
                case "3":
                    tmpreturn = "网路";
                    break;
                case "4":
                    tmpreturn = "报纸";
                    break;
                case "5":
                    tmpreturn = "楼书";
                    break;
                default:
                    tmpreturn = "默认";
                    break;
            }
            return tmpreturn;
        }

        public enum SourceEnum
        {
            默认 = 1,
            电视 = 2,
            网路 = 3,
            报纸 = 4,
            楼书 = 5
        }
    }
}