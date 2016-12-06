#region Histroy
///程式代號：      GameDetail
///程式名稱：      GameDetail
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class GameDetail : BasePage
{
    #region 全局变量
    private string ms_TYPE = "";
    private int mi_TYPE = -1;
    BaseBallDB objBaseBallDB = new BaseBallDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["bt"] != null)
        {
            ms_TYPE = Request.QueryString["bt"];
            switch (Request.QueryString["bt"])
            {
                case "b_bk":
                    this.lblball.Text = "籃球";
                    mi_TYPE = 1;
                    break;
                case "b_bj":
                    this.lblball.Text = "棒球";
                    mi_TYPE = 2;
                    break;
                case "b_bq":
                    this.lblball.Text = "冰球";
                    mi_TYPE = 13;
                    break;
                case "b_by":
                    this.lblball.Text = "网球";
                    mi_TYPE = 3;
                    break;
                case "b_zq":
                    this.lblball.Text = "足球";
                    mi_TYPE = 4;
                    break;
                case "b_bf":
                    this.lblball.Text = "美足";
                    mi_TYPE = 5;
                    break;
                case "b_cq":
                    this.lblball.Text = "彩球";
                    mi_TYPE = 14;
                    break;
                case "b_bb":
                    this.lblball.Text = "排球";
                    mi_TYPE = 6;
                    break;
                case "b_zs":
                    this.lblball.Text = "指數";
                    mi_TYPE = 7;
                    break;
            }
        }
        if (!IsPostBack)
        {

            this.lblDW.Text = objBaseBallDB.GetDW(Request.QueryString["id"]);
            switch (Request["pt"])
            {
                case "l_rf":
                    this.lblWF.Text = "讓分注單";
                    break;
                case "l_dx":
                    this.lblWF.Text = "大小注單";
                    break;
                case "l_dy":
                    this.lblWF.Text = "獨贏注單";
                    break;
                case "l_hj":
                    this.lblWF.Text = "和局注單";
                    break;
                case "l_sy":
                    this.lblWF.Text = "一輸二贏注單";
                    break;
                case "l_ds":
                    this.lblWF.Text = "單雙注單";
                    break;
                case "l_bd":
                    this.lblWF.Text = "波膽注單";
                    break;
                case "l_rqs":
                    this.lblWF.Text = "入球數注單";
                    break;
                case "l_bqc":
                    this.lblWF.Text = "半全場注單";
                    break;
                case "l_zdrf":
                    this.lblWF.Text = "滾球讓分注單";
                    break;
                case "l_zddx":
                    this.lblWF.Text = "滾球大小注單";
                    break;
                case "l_zddy":
                    this.lblWF.Text = "滾球独赢注單";
                    break;
                case "l_zdhj":
                    this.lblWF.Text = "滾球和局注單";
                    break;
                default:
                    this.lblWF.Text = "全部注單";
                    break;
            }
            Query("Detail");
        }

    }
    #endregion

    #region 按钮事件
    protected void lbtnDetail_Click(object sender, EventArgs e)
    {
        Query("Detail");
    }

    protected void lbtnStat_Click(object sender, EventArgs e)
    {
        Query("Stat");
    }

    protected void lbtnCount_Click(object sender, EventArgs e)
    {
        Query("Count");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Query(this.hidType.Value);
    }

    protected void drpBill_SelectedIndexChanged(object sender, EventArgs e)
    {
        Query(this.hidType.Value);
    }

    protected void drpPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Query("Detail");
    }

    #endregion

    #region gridview 事件
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string delyy = this.delyy.Value;

            //o_KFB_PTZD_BLL.DeleteBill(((Label)this.grvDetail.Rows[e.RowIndex].FindControl("lbln_xzdh")).Text, this.drpBill.SelectedValue.Equals("3") ? 0 : 1);
            string strDel = ((Label)this.grvDetail.Rows[e.RowIndex].FindControl("lbln_del")).Text;
            string xgjl = (strDel.Equals("0") ? "D;" : "R;") + "billdetail;" + this.mUserID + ";" + GetIp() + ";" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int iDel = strDel.Equals("0") ? 1 : 0;
            if (iDel.Equals(0))
            {
                delyy = "";
            }
            int i = this.objBaseBallDB.DeleteBill(((Label)this.grvDetail.Rows[e.RowIndex].FindControl("lbln_xzdh")).Text, iDel, delyy, xgjl);
            int j = this.objBaseBallDB.DeleteBillHis(((Label)this.grvDetail.Rows[e.RowIndex].FindControl("lbln_xzdh")).Text, iDel, delyy, xgjl); 
                Query("Detail"); 

        }
        catch (Exception ex)
        {
            this.ShowMsg("删除失败");
            this.WriteLog(ex.ToString());
        }
    }
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            string strDel = ((Label)e.Row.FindControl("lbln_del")).Text;
            string strWxzd = ((Label)e.Row.FindControl("lbln_wxdj")).Text;
            string strdbzd = ((Label)e.Row.FindControl("lbln_dbzd")).Text;
            ((Label)e.Row.FindControl("lblBetContent")).Text = string.Format(((Label)e.Row.FindControl("lblBetContent")).Text, "", "");

            LinkButton lb = e.Row.Cells[10].Controls[0] as LinkButton;
            //if (drpBill.SelectedValue.Equals("3"))
            if (strDel.Equals("1"))
            {
                lb.Text = "恢復";
                e.Row.BackColor = Color.LightGray;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), e.Row.RowIndex.ToString() + "tishi", "huifutishi('" + e.Row.Cells[10].ClientID + "');", true);
            }
            else
            {
                if (!strWxzd.Equals("1") || strdbzd.Equals("1"))
                    e.Row.BackColor = Color.Pink;
                lb.Text = "刪除";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), e.Row.RowIndex.ToString() + "tishi", "deletetishireason('" + e.Row.Cells[10].ClientID + "');", true);
            }
            e.Row.Cells[2].Text = e.Row.Cells[2].Text + "<br />(" + objBaseBallDB.GetHyName(e.Row.Cells[2].Text) + ")";
            if (e.Row.Cells[6].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[6].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[6].ForeColor = Color.Green;
            }
            if (e.Row.Cells[8].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[8].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[8].ForeColor = Color.Green;
            }
            if (e.Row.Cells[9].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[9].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[9].ForeColor = Color.Green;
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_xzwf").ToString().IndexOf("l_bd") > -1)
            {
                ((Label)e.Row.FindControl("lbln_xzwf")).Text = "波膽注單";
            }
            else if (DataBinder.Eval(e.Row.DataItem, "n_xzwf").ToString().IndexOf("l_rqs") > -1)
            {
                ((Label)e.Row.FindControl("lbln_xzwf")).Text = "入球數注單";
            }
            else if (DataBinder.Eval(e.Row.DataItem, "n_xzwf").ToString().IndexOf("l_bqc") > -1)
            {
                ((Label)e.Row.FindControl("lbln_xzwf")).Text = "半全場注單";
            }
        }

    }
    protected void grvStat_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            string str = DataBinder.Eval(e.Row.DataItem, "dw").ToString();
            string[] a_Str = str.Split('@');
            if (a_Str.Length == 3)
            {
                e.Row.Cells[0].Text = a_Str[1];
                e.Row.Cells[1].Text = a_Str[0];
                e.Row.Cells[2].Text = a_Str[2];
            }
            else
            {
                e.Row.Cells[2].Text = str;
            }
            if (e.Row.Cells[6].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[6].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[6].ForeColor = Color.Green;
            }
            if (e.Row.Cells[8].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[8].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[8].ForeColor = Color.Green;
            }
            if (e.Row.Cells[9].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[9].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[9].ForeColor = Color.Green;
            }
        }

    }
    protected void grvCount_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            string str = DataBinder.Eval(e.Row.DataItem, "dw").ToString();
            string[] a_Str = str.Split('@');
            if (a_Str.Length == 3)
            {
                e.Row.Cells[0].Text = a_Str[1];
                e.Row.Cells[1].Text = a_Str[0];
                e.Row.Cells[2].Text = a_Str[2];
            }
            else
            {
                e.Row.Cells[2].Text = str;
            }
            if (e.Row.Cells[5].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[5].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[5].ForeColor = Color.Green;
            }
            if (e.Row.Cells[7].Text.IndexOf('-') > -1)
            {
                e.Row.Cells[7].ForeColor = Color.Red;
            }
            else
            {
                e.Row.Cells[7].ForeColor = Color.Green;
            }
        }

    }
    #endregion

    #region 自定义事件
    private void Query(string s_aType)
    {
        this.grvCount.Visible = false;
        this.grvDetail.Visible = false;
        this.grvStat.Visible = false;
        GamesDB objGamesDB = new GamesDB();

        this.hidType.Value = s_aType;
        switch (s_aType)
        {
            case "Detail":
                this.grvDetail.Visible = true;
                this.drpPage.Visible = true;
                this.grvDetail.PageSize = Convert.ToInt32(this.drpPage.SelectedValue);
                if (this.drpBill.SelectedValue.Equals("3"))
                {
                    ((System.Web.UI.WebControls.CommandField)(grvDetail.Columns[10])).DeleteText = "恢復";
                    grvDetail.Columns[10].HeaderText = "恢復";
                }
                else if (!this.drpBill.SelectedValue.Equals("0"))
                {
                    ((System.Web.UI.WebControls.CommandField)(grvDetail.Columns[10])).DeleteText = "刪除";
                    grvDetail.Columns[10].HeaderText = "刪除";
                }
                else
                {
                    grvDetail.Columns[10].HeaderText = "操作";
                }
                this.grvDetail.DataSource = objGamesDB.GetBillDetail(Request["id"], Request["ti"], Request["pt"], this.drpBill.SelectedValue, Request["pi"]);
                this.grvDetail.DataBind();
                break;
            case "Stat":
                this.grvStat.Visible = true;
                this.drpPage.Visible = false;
                this.grvStat.AllowPaging = false;
                this.grvStat.DataSource = objGamesDB.GetBillStat(Request["id"], Request["ti"], Request["pt"], this.drpBill.SelectedValue, Request["pi"]);
                //this.grvStat.DataSource = o_KFB_BASEBALL_BLL.GetBillStat(Request.QueryString["N_ID"], Request.QueryString["VH"] == null ? "-1" : Request.QueryString["VH"], Request.QueryString["Ball"], Request.QueryString["WF"] == null ? "l_all" : "(" + Request.QueryString["WF"].ToString() + ")", Request.QueryString["PK"] == null ? "LR" : Request.QueryString["PK"], this.drpBill.SelectedValue, "(" + Request.QueryString["Type"].ToString() + ")", Request.QueryString["Status"]);
                this.grvStat.DataBind();
                break;
            case "Count":
                this.grvCount.Visible = true;
                this.drpPage.Visible = false;
                this.grvStat.AllowPaging = false;
                this.grvCount.DataSource = objGamesDB.GetBillCount(Request["id"], Request["ti"], Request["pt"], this.drpBill.SelectedValue, Request["pi"]);
                //this.grvCount.DataSource = o_KFB_BASEBALL_BLL.GetBillCount(Request.QueryString["N_ID"], Request.QueryString["VH"] == null ? "-1" : Request.QueryString["VH"], Request.QueryString["Ball"], Request.QueryString["WF"] == null ? "l_all" : "(" + Request.QueryString["WF"].ToString() + ")", Request.QueryString["PK"] == null ? "LR" : Request.QueryString["PK"], this.drpBill.SelectedValue, "(" + Request.QueryString["Type"].ToString() + ")");
                this.grvCount.DataBind();
                break;
        }
    }
    #endregion

   
  

   


}
