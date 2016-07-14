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
    public partial class RegistJSInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (WXDBEntities db = new WXDBEntities())
                {
                    if (!string.IsNullOrEmpty(Request.Params["isid"]))
                    {
                        var tmpid = Convert.ToInt32(Request.Params["isid"]);
                        var model = db.RegisterInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                        if (model != null)
                        {
                            ltlName.Text = model.Name;
                            ltlPhone.Text = model.Phone;
                            ltlCName.Text = model.Extent1;
                            ltlBankName.Text = model.BankName;
                            ltltCarId.Text = model.BankCard;
                            ltlyj.Text = model.BeforeMoney;
                        }
                    }
                }
            }
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ltlCName.Text))
            {
                jsHint.Back("请联系客户绑定银行卡信息有进行操作!");
                return;
            }
            using (WXDBEntities db = new WXDBEntities())
            {
                var tmpid = Convert.ToInt32(Request.Params["isid"]);
                var model = db.RegisterInfo.Where(s => s.Id == tmpid).FirstOrDefault();
                if (drpyj.SelectedValue == "0")
                {
                    jsHint.Back("若确认佣金支付成功,请选择是");
                    return;
                }
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.BeforeMoney))
                    {
                        if (string.IsNullOrEmpty(model.MoneyOld))
                        {
                            model.MoneyOld = Convert.ToInt32(model.BeforeMoney) + "";
                        }
                        else
                        {
                            model.MoneyOld = Convert.ToInt32(model.MoneyOld) + Convert.ToInt32(model.BeforeMoney) + "";
                        }
                        model.BeforeMoney = "";
                        db.SaveChanges();
                        db.ExecuteStoreCommand("update InfoLogo set Status={0} where RgId={1}", 3, tmpid);
                        jsHint.toUrl("佣金支付成功", "RegistInfo.aspx?page=" + Request.Params["page"]);
                    }
                    else
                    {
                        jsHint.toUrl("佣金已经支付成功", "RegistInfo.aspx?page=" + Request.Params["page"]);
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            jsHint.toUrl("RegistInfo.aspx?page=" + Request.Params["page"]);
        }
    }
}