using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXEF;
using WX.Utils;
namespace NewInfoWeb.yshb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (WXDBEntities db = new WXDBEntities())
            {
                var model1 = db.Forms.Where(s => s.Source.Equals("o8Auot6V2F15E57zCCbkEmQT7IVQ") && s.Type.Equals(18)).OrderByDescending(s => s.AddTime).FirstOrDefault();
                if (model1 != null)
                {
                    //判断今天是否抽奖
                    if ((DateTime.Now.Date - model1.AddTime.Date).TotalDays > 0)
                    {
                        jsHint.Alert("123");
                    }
                    else
                    {
                        jsHint.Alert("456");
                    }
                }
            }
        }
    }
}