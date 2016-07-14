using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HPSF;
namespace NewInfoWeb.manage.jjrmantenance
{
    public partial class RegistInfo : ManageBasePage
    {
        protected int count = 0;
        protected string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                name = loginname;
                if (!string.IsNullOrEmpty(Request.Params["isid"]))
                {

                }
                // 处理删除操作
                if (!string.IsNullOrEmpty(Request.QueryString["del"]) && WebUtil.IsDigit(Request.QueryString["del"]))
                {
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        int tmpid = int.Parse(Request.QueryString["del"]);

                        var model = db.RegisterInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            db.RegisterInfo.DeleteObject(model);
                            db.SaveChanges();
                        }
                        jsHint.toUrl("删除成功！", "RegistInfo.aspx");
                        //MaintenanceService.Instance.DeleteAccountById(int.Parse(Request.QueryString["del"]));
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
                IQueryable<RegisterInfo> carlist = db.RegisterInfo.Where(s => s.Status != 4).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);

                if (!string.IsNullOrEmpty(txtname.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.Name.Contains(txtname.Text));
                }
                if (!string.IsNullOrEmpty(txtphone.Text.Trim()))
                {
                    carlist = carlist.Where(s => s.Phone.Contains(txtphone.Text));
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
                AspNetPager1.CurrentPageIndex = 0;
                WebUtil.CtrlToList<RegisterInfo>(rptnews, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }
        protected string GetCount(object obj)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                int tmprid = Convert.ToInt32(obj);
                return db.RecommendInfo.Where(s => s.RgeisterInfo == tmprid).Count().ToString();
            }
        }
        protected string GetSFInfo(object obj)
        {
            return Utils.GetSFInfo(obj.ToString());
        }
        protected void btnCallInfo_Click(object sender, EventArgs e)
        {
            BindRepeater();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<RegisterInfo> carlist = db.RegisterInfo.Where(s => s.Status != 4).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);
                if (carlist.Count() > 0)
                {

                    string filename = "注册人.xls";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
                    Response.Clear();

                    InitializeWorkbook();
                    GenerateData();
                    GetExcelStream().WriteTo(Response.OutputStream);
                    Response.End();

                }
                else
                {
                    jsHint.Alert("暂无数据导出！");
                }
            }
        }
        HSSFWorkbook hssfworkbook;

        MemoryStream GetExcelStream()
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }

        void GenerateData()
        {
            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            //sheet1.CreateRow(0).CreateCell(0).IsPartOfArrayFormulaGroup = true;
            IRow row2 = sheet1.CreateRow(0);
            ICell cell = row2.CreateCell(0);
            cell.SetCellValue("注册人信息");
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeight = 20 * 20;
            style.SetFont(font);
            cell.CellStyle = style;
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
            IRow row1 = sheet1.CreateRow(1);
            row1.CreateCell(0).SetCellValue("注册人");
            row1.CreateCell(1).SetCellValue("手机号码");
            row1.CreateCell(2).SetCellValue("所得佣金");
            row1.CreateCell(3).SetCellValue("已结算佣金");
            row1.CreateCell(4).SetCellValue("身份类别");
            row1.CreateCell(5).SetCellValue("公司名称");
            row1.CreateCell(6).SetCellValue("推荐人数");
            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<RegisterInfo> carlist = db.RegisterInfo.Where(s => s.Status != 4).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);
                int x = 2;
                foreach (var item in carlist)
                {
                    IRow row = sheet1.CreateRow(x);
                    row.CreateCell(0).SetCellValue(item.Name);
                    row.CreateCell(1).SetCellValue(item.Phone);
                    row.CreateCell(2).SetCellValue(item.BeforeMoney);
                    row.CreateCell(3).SetCellValue(item.MoneyOld);
                    row.CreateCell(4).SetCellValue(GetSFInfo(item.ZwInfo));
                    row.CreateCell(5).SetCellValue(item.CompanyName);
                    row.CreateCell(6).SetCellValue(GetCount(item.Id));
                    x++;
                }
                //int x = 1;
                //for (int i = 1; i <= 400; i++)
                //{
                //    IRow row = sheet1.CreateRow(i);
                //    for (int j = 0; j < 20; j++)
                //    {
                //        row.CreateCell(j).SetCellValue(x++);
                //    }
                //}
            }
        }

        void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();

            ////create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;
        }
        /// <summary>
        /// 导入数据到SQL中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}