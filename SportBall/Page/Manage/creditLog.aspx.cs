#region History
///程式代號：      cxhy
///程式名稱：      cxhy
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class creditLog : BasePage
{
    #region 全局变数 
    ZZBGDB objZZBGDB = new ZZBGDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtkjsj.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txtjssj.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

    }
    #endregion

   

    #region 按钮事件
    protected void btcx_Click(object sender, EventArgs e)
    {
        
        DataSet ds = this.objZZBGDB.GetCreditLogList(this.txtUserId.Text, this.txtkjsj.Text, this.txtjssj.Text, this.txtBillId.Text, this.drpType1.SelectedValue);
        this.grvCreditLog.DataSource = ds;
        this.grvCreditLog.DataBind();
    }
    #endregion

   

    #region gridview事件
   

    protected void grvCreditLog_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[1].Text)
            {
                case "0":
                    e.Row.Cells[1].Text = "下注";
                    break;
                case "1":
                    e.Row.Cells[1].Text = "状态删单";
                    break;
                case "2":
                    e.Row.Cells[1].Text = "计算";
                    break;
                case "3":
                    e.Row.Cells[1].Text = "重新计算";
                    break;
                case "4":
                    e.Row.Cells[1].Text = "转账";
                    break;
                case "5":
                    e.Row.Cells[1].Text = "恢复删单";
                    break;
                case "6":
                    e.Row.Cells[1].Text = "彻底删单";
                    break;
                case "7":
                    e.Row.Cells[1].Text = "过账";
                    break;
                case "8":
                    e.Row.Cells[1].Text = "恢复比赛";
                    break;
            }
            e.Row.Cells[5].Text = Convert.ToString(Convert.ToDecimal(e.Row.Cells[4].Text) - Convert.ToDecimal(e.Row.Cells[3].Text));
        }
    }
   
    #endregion

    #region 自定义事件
   
    #endregion

 
}
