using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewInfoWeb
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime now = DateTime.Now;
            //TimeSpan span = now.TimeOfDay;
            // TimeSpan end = new TimeSpan(15,0,0);
            // Response.Write(DateTime.Now.Hour >= 14&&span <= end);
            DateTime t1 = DateTime.Now.Date;
            DateTime tm2 = DateTime.Now.AddDays(1).Date;
            DateTime t2 = Convert.ToDateTime("2016-05-09");
            DateTime t3 = t2.AddDays(1);
        }
    }
}
