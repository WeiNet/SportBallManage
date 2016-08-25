using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportBall.Styles
{
    public partial class NewMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null) {
                this.username.Text = Session["UserID"].ToString();
            }
      
        }
    }
}