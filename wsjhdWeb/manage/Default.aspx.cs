using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewInfoWeb.manage
{
    public partial class Default : System.Web.UI.Page
    {
        protected string curdata = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            curdata = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd");
        }
    }
}