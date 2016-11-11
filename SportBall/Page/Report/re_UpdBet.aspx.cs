#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class re_UpdBet : BasePage
{
    #region 全局变数
    ReportDB objReportDB = new ReportDB(); 
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtkjsj.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            this.txtjssj.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.txtkjsj.Attributes.Add("onblur", "return fn_CheckDate(this);");
            this.txtjssj.Attributes.Add("onblur", "return fn_CheckDate(this);");
        }
       
    }


    #endregion

   

    #region 按钮事件
    protected void btcx_Click(object sender, EventArgs e)
    {
        try
        {
          Query();
        }
        catch (Exception ex)
        {
            this.ShowMsg("查询失败，请洽管理员！");
        }
    }
    #endregion

   

    #region gridview事件
   
    #endregion

    #region 自定义事件
    private void Query()
    {
       
        DataSet ds = new DataSet();

        ds = this.objReportDB.GetAbnormalBet(this.txtkjsj.Text.Replace('-', '/'), this.txtjssj.Text.Replace('-', '/'));
        if (ds.Tables[0].Rows.Count > 0)
        {
          
            this.JXGrid1.DataSource = ds;
            this.JXGrid1.DataBind();
        }
        else
        {
           
            this.JXGrid1.DataSource = null;
            this.JXGrid1.DataBind();
            ShowMsg("查无资料");
        }
    }
    #endregion
}
