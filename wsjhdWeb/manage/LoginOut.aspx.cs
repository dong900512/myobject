using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewInfoWeb.Appcode;
using System.Web.Configuration;
namespace NewInfoWeb.manage
{
    public partial class LoginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CookieHelper.Delete(WebConfigurationManager.AppSettings["ManageDomain"]);
                Response.Redirect("admin_login.aspx");
            }
        }
    }
}