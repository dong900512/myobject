using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dos.ORM;
using Dos.Model;
using Dos.Common;
using WX.Utils;
using System.Web.Configuration;
using Senparc.Weixin;
using System.Data;
namespace NewInfoWeb.ChinaTele
{
    public partial class index : System.Web.UI.Page
    {
        protected string tmpstr = string.Empty;
        protected string tmpcode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tmpstr = Dos.Common.CookieHelper.Get("curDxTel");
                tmpcode = Dos.Common.CookieHelper.Get("curDxTcode");
                if (string.IsNullOrEmpty(tmpstr) || string.IsNullOrEmpty(tmpcode))
                {
                    //jsHint.toUrl("index.aspx");
                }
                else
                {
                    jsHint.toUrl("main.aspx");
                }
            }
        }
    }
}