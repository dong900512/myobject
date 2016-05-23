using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WX.Utils;
using WXEF;

using System.Linq;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// writexml 的摘要说明
/// </summary>
public class writexml
{
    public writexml()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 修改xml
    /// </summary>
    /// <param name="year">年份值</param>
    /// <param name="month">月份值</param>
    /// <param name="day">天数值</param>
    /// <param name="price">价格</param>
    public void UpdataXml(string year, string month, string day, int price)
    {
        string xmlpath = globalVariables.Auctionxmlpath + "auction.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlpath);

        XmlNode root = doc.SelectSingleNode("data");
        XmlNodeList children = root.ChildNodes;
        int count = root.ChildNodes.Count;

        //月循环
        int i = 0;
        for (i = 0; i < children.Count; i++)
        {
            XmlElement ele = (XmlElement)children[i];

            //找到了月的节点
            if (ele.GetAttribute("value") == month)
            {
                int qu1 = Convert.ToInt32(ele.GetAttribute("qujian1"));
                int qu2 = Convert.ToInt32(ele.GetAttribute("qujian2"));
                int qu3 = Convert.ToInt32(ele.GetAttribute("qujian3"));
                int qu4 = Convert.ToInt32(ele.GetAttribute("qujian4"));

                XmlNodeList daylist = ele.ChildNodes;
                int j = 0;
                for (j = 0; j < daylist.Count; j++)
                {
                    XmlElement xeday = (XmlElement)daylist[j];

                    //找到了日节点
                    if (xeday.GetAttribute("value") == day)
                    {
                        if (price >= qu1 && price <= qu2)
                        {
                            int num = Convert.ToInt32(xeday.GetAttribute("qujian1")) + 1;
                            xeday.SetAttribute("qujian1", num.ToString());

                            int sum = Convert.ToInt32(xeday.GetAttribute("sum1")) + price;
                            xeday.SetAttribute("sum1", sum.ToString());

                            string avg = Math.Round(((double)sum / num), 2).ToString();
                            xeday.SetAttribute("average1", avg);
                        }
                        else if (price >= qu3 && price <= qu4)
                        {
                            int num = Convert.ToInt32(xeday.GetAttribute("qujian2")) + 1;
                            xeday.SetAttribute("qujian2", num.ToString());

                            int sum = Convert.ToInt32(xeday.GetAttribute("sum2")) + price;
                            xeday.SetAttribute("sum2", sum.ToString());

                            string avg = Math.Round(((double)sum / num), 2).ToString();
                            xeday.SetAttribute("average2", avg);
                        }
                        break;
                    }
                }
                break;
            }
        }

        //没有找到合适的月节点
        if (i == count)
        {
            AddMonth(year, month, day, price);
            UpdateDay(year, month, day, price);
        }
        else
            doc.Save(xmlpath);
    }

    public string GetQuJian(string year, string month)
    {
        string qujian = "";
        string qupath = globalVariables.Auctionxmlpath + "interval.xml";
        XmlDocument xmldoc = new XmlDocument();

        xmldoc.Load(qupath);
        XmlNode quroot = xmldoc.SelectSingleNode("AuctionIntervals");
        XmlNodeList qulist = quroot.ChildNodes;

        int qui = 0;
        for (qui = 0; qui < qulist.Count; qui++)
        {
            XmlElement ele = (XmlElement)qulist[qui];
            string temp = ele.GetAttribute("month");
            if (temp.Equals(year + "-" + month))
            {
                qujian = qujian + ele.GetAttribute("setion1") + ",";
                qujian = qujian + ele.GetAttribute("setion2") + ",";
                qujian = qujian + ele.GetAttribute("setion3") + ",";
                qujian = qujian + ele.GetAttribute("setion4") + ",";

                break;
            }
        }
        return qujian;
    }

    /// <summary>
    /// 添加月节点
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="price"></param>
    public void AddMonth(string year, string month, string day, int price)
    {
        string[] qulist = GetQuJian(year, month).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string qu1 = qulist[0];
        string qu2 = qulist[1];
        string qu3 = qulist[2];
        string qu4 = qulist[3];

        string xmlpath = globalVariables.Auctionxmlpath + "auction.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlpath);

        XmlNode root = doc.SelectSingleNode("data");

        XmlElement ele = doc.CreateElement("month");
        ele.SetAttribute("value", month);
        ele.SetAttribute("qujian1", qu1);
        ele.SetAttribute("qujian2", qu2);
        ele.SetAttribute("qujian3", qu3);
        ele.SetAttribute("qujian4", qu4);

        DateTime time = Convert.ToDateTime(year + "-" + month + "-1");
        for (int m = 1; m < 32; m++)
        {
            XmlElement ele_day = doc.CreateElement("day");
            ele_day.SetAttribute("value", m.ToString());
            ele_day.SetAttribute("qujian1", "0");
            ele_day.SetAttribute("average1", "0");
            ele_day.SetAttribute("sum1", "0");
            ele_day.SetAttribute("qujian2", "0");
            ele_day.SetAttribute("average2", "0");
            ele_day.SetAttribute("sum2", "0");

            ele.AppendChild((XmlNode)ele_day);

            DateTime objtime = time.AddDays(m);
            if (objtime.Month > Convert.ToInt32(month))
            {
                break;
            }
        }

        root.AppendChild((XmlNode)ele);

        doc.Save(xmlpath);
    }

    public void UpdateDay(string year, string month, string day, int price)
    {
        string[] qulist = GetQuJian(year, month).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int qu1 = Convert.ToInt32(qulist[0]);
        int qu2 = Convert.ToInt32(qulist[1]);
        int qu3 = Convert.ToInt32(qulist[2]);
        int qu4 = Convert.ToInt32(qulist[3]);

        string xmlpath = globalVariables.Auctionxmlpath + "auction.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlpath);

        XmlNode root = doc.SelectSingleNode("data");
        for (int i = 0; i < root.ChildNodes.Count; i++)
        {
            XmlElement ele = (XmlElement)root.ChildNodes[i];
            //得到月份节点
            if (ele.GetAttribute("value") == month)
            {
                XmlNodeList daylist = ele.ChildNodes;

                int j = 0;
                for (j = 0; j < daylist.Count; j++)
                {
                    XmlElement ele_day = (XmlElement)daylist[j];
                    //获取日节点
                    if (ele_day.GetAttribute("value") == day)
                    {
                        if (price >= qu1 && price <= qu2)
                        {
                            int num = Convert.ToInt32(ele_day.GetAttribute("qujian1")) + 1;
                            ele_day.SetAttribute("qujian1", num.ToString());

                            int sum = Convert.ToInt32(ele_day.GetAttribute("sum1")) + price;
                            ele_day.SetAttribute("sum1", sum.ToString());

                            string avg = Math.Round(((double)sum / num), 2).ToString();
                            ele_day.SetAttribute("average1", avg);
                        }
                        else if (price >= qu3 && price <= qu4)
                        {
                            int num = Convert.ToInt32(ele_day.GetAttribute("qujian2")) + 1;
                            ele_day.SetAttribute("qujian2", num.ToString());

                            int sum = Convert.ToInt32(ele_day.GetAttribute("sum2")) + price;
                            ele_day.SetAttribute("sum2", sum.ToString());

                            string avg = Math.Round(((double)sum / num), 2).ToString();
                            ele_day.SetAttribute("average2", avg);
                        }
                        break;
                    }
                }
                break;
            }
        }
        doc.Save(xmlpath);
    }

    /// <summary>
    /// 把数据库中所有经过审核的信息写入xml
    /// </summary>
    //public void WriteUserInfosToXML()
    //{
    //    string xmlpath = globalVariables.Auctionxmlpath + "roll.xml";
    //    XmlDocument xmldoc = new XmlDocument();
    //    xmldoc.Load(xmlpath);

    //    XmlNode root = xmldoc.SelectSingleNode("data");
    //    root.RemoveAll();

    //    for (int i = 1; i < 13; i++)
    //    {
    //        IList<OrderCarForm> formlist = CommonServices.Instance.GetTBySample<OrderCarForm>(new Order[] { Order.Asc("ID") }, new ICriterion[] { Expression.In("IdNumber",this.GetCurrentUsers(DateTime.Now.Year,i)), Expression.Eq("ToFlash", (byte)1) });
    //        if (formlist.Count > 0)
    //        {
    //            //月
    //            XmlElement ele = xmldoc.CreateElement("month");
    //            ele.SetAttribute("value", i.ToString());

    //            foreach (OrderCarForm order in formlist)
    //            {
    //                int price = 100;
    //                DateTime dt = GetCurrentTime(DateTime.Now.Year, i, order,ref price);
    //                //信息
    //                XmlElement dayele = xmldoc.CreateElement("msg");
    //                dayele.SetAttribute("num", order.Phone);
    //                dayele.SetAttribute("jbj",price.ToString());

    //                ele.AppendChild(dayele);
    //            }

    //            root.AppendChild(ele);
    //        }
    //    }

    //    xmldoc.Save(xmlpath);
    //}

    /// <summary>
    /// 重新更新auction.xml
    /// </summary>
    //public void WriteAuctionXml()
    //{
    //    string xmlpath = globalVariables.Auctionxmlpath + "auction.xml";
    //    XmlDocument doc = new XmlDocument();
    //    doc.Load(xmlpath);

    //    XmlNode root = doc.SelectSingleNode("data");
    //    root.RemoveAll();

    //    doc.Save(xmlpath);

    //    for (int i = 1; i < 13; i++)
    //    {
    //        IList<OrderCarForm> formlist = CommonServices.Instance.GetTBySample<OrderCarForm>(new Order[] { Order.Asc("ID") }, new ICriterion[] { Expression.In("IdNumber", this.GetCurrentUsers(DateTime.Now.Year, i)), Expression.Eq("ToFlash", (byte)1) });
    //        if (formlist.Count > 0)
    //        {
    //            foreach (OrderCarForm order in formlist)
    //            {
    //                int price=100;
    //                DateTime dt = GetCurrentTime(DateTime.Now.Year, i, order, ref price);
    //                if (!string.IsNullOrEmpty(order.Blowprice) && WebUtil.IsDigit(order.Blowprice))
    //                {
    //                    if (i == DateTime.Now.Month)
    //                    {
    //                        DateTime ordercardate = Convert.ToDateTime(order.OrderCarDate);
    //                        UpdataXml(ordercardate.Year.ToString(), ordercardate.Month.ToString(), ordercardate.Day.ToString(), price);
    //                    }
    //                    else
    //                    {
    //                        UpdataXml(dt.Year.ToString(), dt.Month.ToString(), dt.Day.ToString(), price);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// 获取某年某月的消费记录
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    //private List<string> GetCurrentUsers(int year,int month)
    //{
    //    string sql = "SELECT [ID],[IdNumber],[SecKillDate],[SecType],[SecResult],[BlowPrice] FROM [BuickHuamu].[dbo].[MiaoShaHistory] where [SecType]='0' and  [SecKillDate]>='";
    //    sql += year.ToString();
    //    sql += "-";
    //    sql += month.ToString();
    //    sql += "-1'";
    //    sql += " and [SecKillDate]<='";
    //    sql += year.ToString();
    //    sql += "-";
    //    sql += month.ToString();
    //    sql += "-"+DateTime.DaysInMonth(year,month).ToString()+"'";
    //    DataTable dt = SqlHelper.Query(sql).Tables[0];
    //    List<string> result = new List<string>();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        result.Add(dr["IdNumber"].ToString());
    //    }

    //    return result;
    //}

    /// <summary>
    /// 获取当前用户的月、最低中标价
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="order"></param>
    /// <param name="price"></param>
    /// <returns></returns>
    //private DateTime GetCurrentTime(int year,int month,OrderCarForm order, ref int price)
    //{
    //    try
    //    {
    //        string sql = "SELECT [ID],[IdNumber],[SecKillDate],[SecType],[SecResult],[BlowPrice] FROM [BuickHuamu].[dbo].[MiaoShaHistory] where ";
    //        sql += "[IdNumber]='" + order.IdNumber;
    //        sql+="' and [SecKillDate]>='";
    //        sql += year.ToString();
    //        sql += "-";
    //        sql += month.ToString();
    //        sql += "-1'";
    //        sql += " and [SecKillDate]<='";
    //        sql += year.ToString();
    //        sql += "-";
    //        sql += month.ToString();
    //        sql += "-" + DateTime.DaysInMonth(year, month).ToString() + "'";
    //        DataTable dt = SqlHelper.Query(sql).Tables[0];
    //        price = int.Parse(dt.Rows[0]["BlowPrice"].ToString());
    //        DateTime result = Convert.ToDateTime(dt.Rows[0]["SecKillDate"].ToString());
    //        return result;
    //    }
    //    catch
    //    {
    //        return DateTime.Now;
    //    }
    //}
}
