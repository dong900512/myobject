using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using WXEF;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using WX.Utils;
using Webdiyer.WebControls.Mvc;
namespace NewInfoWeb.manage.jjrmantenance
{
    public partial class RegRecomdInfo : System.Web.UI.Page
    {
        protected int count = 0;
        protected string rgid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["rgid"]))
                {
                    rgid = Request.Params["rgid"];
                    using (WXDBEntities db = new WXDBEntities())
                    {
                        var tmpid = Convert.ToInt32(Request.Params["rgid"]);
                        var model = db.RegisterInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            ltlServer.Text = model.Name;
                            BindRepeater(tmpid);
                        }
                    }
                }
            }
        }
        private void BindRepeater(int pid)
        {
            int page = AspNetPager1.CurrentPageIndex;
            if (!this.IsPostBack)
            {
                if (Request["page1"] + "" != "")
                    page = int.Parse(Request["page1"] + "");
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                IQueryable<RecommendInfo> carlist = db.RecommendInfo.Where(s => s.RgeisterInfo == pid).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);

                var dblist = carlist.ToPagedList(page, AspNetPager1.PageSize);
                AspNetPager1.RecordCount = dblist.TotalItemCount;
                ltlCount.Text = "<b>" + dblist.TotalItemCount + "</b>";

                if (!this.IsPostBack)
                {
                    if (Request["page1"] + "" != "")
                    {
                        int temp = int.Parse(Request["page1"] + "");
                        AspNetPager1.CurrentPageIndex = temp;
                    }
                }
                //AspNetPager1.CurrentPageIndex = 0;
                WebUtil.CtrlToList<RecommendInfo>(rptnews, dblist);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRepeater(Convert.ToInt32(Request.Params["rgid"]));
        }

        protected void btnCallInfo_Click(object sender, EventArgs e)
        {
            jsHint.toUrl("RegistInfo.aspx?page=" + Request.Params["page"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var tmpid = Convert.ToInt32(Request.Params["rgid"]);
                IQueryable<RecommendInfo> carlist = db.RecommendInfo.Where(s => s.RgeisterInfo == tmpid).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);
                if (carlist.Count() > 0)
                {
                    string filename = ltlServer.Text + "推荐的客户.xls";
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
                    jsHint.Alert("暂无数据导出");
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
            cell.SetCellValue(ltlServer.Text + "推荐的客户");
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeight = 20 * 20;
            style.SetFont(font);
            cell.CellStyle = style;
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
            IRow row1 = sheet1.CreateRow(1);
            row1.CreateCell(0).SetCellValue("姓名");
            row1.CreateCell(1).SetCellValue("手机号码");
            row1.CreateCell(2).SetCellValue("状态");
            row1.CreateCell(3).SetCellValue("户型面积");
            row1.CreateCell(4).SetCellValue("备注信息");

            using (WXDBEntities db = new WXDBEntities())
            {
                var tmpid = Convert.ToInt32(Request.Params["rgid"]);
                IQueryable<RecommendInfo> carlist = db.RecommendInfo.Where(s => s.RgeisterInfo == tmpid).OrderBy(o => o.Orders).ThenByDescending(o => o.Id);
                if (carlist.Count() > 0)
                {
                    int x = 2;
                    foreach (var item in carlist)
                    {
                        IRow row = sheet1.CreateRow(x);
                        row.CreateCell(0).SetCellValue(item.Name);
                        row.CreateCell(1).SetCellValue(item.Phone);
                        row.CreateCell(2).SetCellValue(WX.Utils.Utils.GetStatus(Convert.ToInt32(item.Status)));
                        row.CreateCell(3).SetCellValue(item.loupanInfo);
                        row.CreateCell(4).SetCellValue(item.Extent1);
                        x++;
                    }
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
    }
}