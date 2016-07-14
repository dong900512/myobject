using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewInfoWeb.manage.InfoMaintenance
{
    public partial class SysNewsmaster : System.Web.UI.MasterPage
    {
        public string txtTitle
        {
            set { ltlTitle.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}