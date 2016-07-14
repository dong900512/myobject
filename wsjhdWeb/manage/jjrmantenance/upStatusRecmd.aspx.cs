using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Utils;
using WXEF;

namespace NewInfoWeb.manage.jjrmantenance
{
    public partial class upStatusRecmd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (WXDBEntities db = new WXDBEntities())
                {
                    int tmpid = Convert.ToInt32(Request.Params["rcid"]);
                    var model = db.RecommendInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                    if (model != null)
                    {
                        ltlName.Text = model.Name;
                        ltlhx.Text = model.loupanInfo;
                        if (model.Status == 5)
                        {
                            drpStatus.Enabled = false;
                            drpPI.Enabled = false;
                        }
                        drpStatus.SelectedValue = model.Status.ToString();
                        drpPI.SelectedValue = string.IsNullOrEmpty(model.Extent2) ? "0" : model.Extent2;
                    }
                }
            }
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                int tmpid = Convert.ToInt32(Request.Params["rcid"]);
                var model = db.RecommendInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                int tmpRgid = Convert.ToInt32(Request.Params["rgid"]);
                if (model != null)
                {
                    if (model.Status != 5)
                    {
                        var rginfo = db.RegisterInfo.Where(s => s.Id == tmpRgid).FirstOrDefault();
                        if (rginfo != null)
                        {
                            var stri = Utils.GetPricInfo(model.loupanInfo);
                            var status = drpStatus.SelectedValue;
                            if (status.Equals("5"))
                            {
                                var pi = drpPI.SelectedValue;
                                if (pi.Equals("1"))
                                {
                                    if (string.IsNullOrEmpty(rginfo.BeforeMoney))
                                    {
                                        rginfo.BeforeMoney = Convert.ToInt32(stri) + 2000 + "";
                                    }
                                    else
                                    {
                                        rginfo.BeforeMoney = Convert.ToInt32(rginfo.BeforeMoney) + Convert.ToInt32(stri) + 2000 + "";
                                    }
                                    //全款

                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(rginfo.BeforeMoney))
                                    {
                                        rginfo.BeforeMoney = stri;
                                    }
                                    else
                                    {
                                        rginfo.BeforeMoney = Convert.ToInt32(rginfo.BeforeMoney) + Convert.ToInt32(stri) + "";
                                    }

                                }
                                model.Status = Convert.ToInt32(drpStatus.SelectedValue);
                                db.SaveChanges();
                                var logmodel = new InfoLogo()
                                {
                                    Title = "",
                                    Remark = "结算佣金" + rginfo.BeforeMoney,
                                    Status = 0,
                                    Orders = 0,
                                    AddTime = DateTime.Now,
                                    UpdateTime = DateTime.Now,
                                    RgId = tmpRgid,
                                    Extent1 = rginfo.BeforeMoney,
                                    Extent2 = model.Name,
                                    Extent3 = "",
                                    RecId = model.Id
                                };
                                db.InfoLogo.AddObject(logmodel);
                                db.SaveChanges();
                            }
                            else
                            {
                                model.Status = Convert.ToInt32(drpStatus.SelectedValue);
                                db.SaveChanges();
                            }
                        }
                    }

                    jsHint.toUrl("客户状态修改成功", "RegRecomdInfo.aspx?rgid=" + Request.Params["rgid"]);
                }
            }
        }
    }
}