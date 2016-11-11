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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class cxhy : BasePage
{
    #region 全局变数
    KFB_HYGLDB objKFB_HYGLDB = new KFB_HYGLDB();

    #endregion
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region 按钮事件
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        this.txtHYZH.Value = this.txtHYZH.Value.ToUpper();

        this.grvQuery.DataSource = objKFB_HYGLDB.GetList(this.txtHYZH.Value);
        this.grvQuery.DataBind();
        if (this.grvQuery.Rows.Count == 0)
        {
            this.ShowMsg("查無符合的資料");

        }
        else
        {
            this.hidHYZH.Value = this.txtHYZH.Value;
        }
    }
    #endregion

    #region gridview事件
    protected void grvQuery_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[7].Text = "台幣";
            if (e.Row.Cells[8].Text.Equals("1"))
            {
                e.Row.Cells[8].Text = "是";
            }
            else
            {
                e.Row.Cells[8].Text = "否";
            }
        }
    }

    protected void grvQuery_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("HuiShou"))
            {
                Hashtable o_Ht = new Hashtable();

                KFB_HYGL m_HY = objKFB_HYGLDB.GetModel(this.hidHYZH.Value);
                decimal dKyed = decimal.Parse(m_HY.N_KYED.ToString());
                objKFB_HYGLDB.FanHuiDLYE(this.hidHYZH.Value, dKyed, o_Ht);
                objKFB_HYGLDB.HuiShouHYYE(this.hidHYZH.Value, o_Ht);
                objKFB_HYGLDB.SetTran(o_Ht);
               this.ShowMsg( "餘額回收成功");
            }
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
           this.ShowMsg("餘額回收失敗");
        }

    }
    #endregion

    #region 自定义事件
    #endregion
}
