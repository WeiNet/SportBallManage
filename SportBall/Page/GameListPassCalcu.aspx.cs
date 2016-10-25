#region History
///程式代號：      GameListPassCalcu
///程式名稱：      GameListPassCalcu
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class GameListPassCalcu :BasePage
{
    #region 全局变量
    GameListPassCalcuDB objGameList = new GameListPassCalcuDB();
    #endregion
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime dt = Comm.GetZWRQ();
            for (int i = 0; i < 10; i++)
            {
                ListItem item = new ListItem();
                item.Value = dt.ToString("yyyy/MM/dd");
                item.Text = dt.ToString("MM") + "/" + dt.ToString("dd") + " " + Comm.CaculateWeekDay(dt.Year, dt.Month, dt.Day);
                this.drpDate.Items.Add(item);
                dt = dt.AddDays(-1);
            }

            if (Request["bt"] != null)
            {
                this.lbtt.Text = Comm.ChType(Request["bt"].ToString());
                this.ViewState["bt"] = Request["bt"].ToString();
            }
            SetGrid();
        }
    }

   
    #endregion

    #region 按钮事件
    protected void btcx_Click(object sender, EventArgs e)
    {
        SetGrid();
    }

    protected void btjs_Click(object sender, EventArgs e)
    {
        string strrq = drpDate.SelectedValue;
        //Comm.GGJS(strrq, this.ViewState["ball"].ToString());
        objGameList.BallPassCount(strrq, this.ViewState["bt"].ToString());
        SetGrid();
    }
    protected void drpDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGrid();
    }
    #endregion
    #region grid事件
    protected void JXGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].ColumnSpan = 3;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Text = this.lbxzje.Text;
            e.Row.Cells[4].Text = this.lbkyje.Text;
            e.Row.Cells[5].Text = this.lbsyjg.Text;

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strnr = "";
            string strdel = "";
            string n_xzwf = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_xzwf").ToString());
            string n_xzdh = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_xzdh").ToString()); 
            Label lbn_xzdh = (Label)e.Row.FindControl("lbn_xzdh");
            if (lbn_xzdh!=null) {
                lbn_xzdh.Text = Comm.ChType(n_xzwf) + "<br>" + n_xzdh;
            }
            if (DataBinder.Eval(e.Row.DataItem, "N_DEL").ToString().Equals("1"))
                strdel = "<font color='red'>已删除</font>";
            string strXZNR = ((Label)(e.Row.FindControl("lbn_xznr"))).Text;
            strnr = " <table  border='0' cellpadding='0' cellspacing='0' class='font_12_b' width='100%'> ";
            string[] strsplit = strXZNR.Split('#');
            for (int j = 0; j < strsplit.Length - 1; j++)
            {
                if (j < strsplit.Length - 2)
                    strnr = strnr + " <tr> <td width='10' bgcolor='#FFFFFF' style='border-top-color: white; border-bottom-color: ; border-right-color: white; border-left-color: white' > " + Convert.ToString(j + 1) + "</td> <td bgcolor='#FFFFFF' style='border-top-color: white; border-bottom-color: ; border-right-color: white; border-left-color: white' >" + strsplit[j].ToString() + strdel + " </td> </tr> ";
                else
                    strnr = strnr + " <tr> <td width='10' bgcolor='#FFFFFF' style='border-color: white;'> " + Convert.ToString(j + 1) + "</td> <td bgcolor='#FFFFFF' style='border-color: white;'>" + strsplit[j].ToString() + strdel + " </td> </tr> ";
            }
            strnr = strnr + " </table > ";

            e.Row.Cells[2].Text = string.Format(strnr, "", "");
        }
      
    }
    #endregion
    #region 自定义事件
    private void SetGrid()
    {
       
        DataSet ds = new DataSet();
        string strrq = "";
        strrq = drpDate.SelectedValue;
        ds = objGameList.GetGG(Convert.ToDateTime(strrq), this.ViewState["bt"].ToString());

        decimal d_xzje = 0;
        decimal d_kyje = 0;
        decimal d_syjg = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            d_xzje = d_xzje + decimal.Parse(ds.Tables[0].Rows[i]["n_xzje"].ToString().Equals("") ? "0" : ds.Tables[0].Rows[i]["n_xzje"].ToString());
            d_kyje = d_kyje + decimal.Parse(ds.Tables[0].Rows[i]["n_kyje"].ToString().Equals("") ? "0" : ds.Tables[0].Rows[i]["n_kyje"].ToString());
            d_syjg = d_syjg + decimal.Parse(ds.Tables[0].Rows[i]["n_syjg"].ToString().Equals("") ? "0" : ds.Tables[0].Rows[i]["n_syjg"].ToString());
        }
        this.lbxzje.Text = d_xzje.ToString();
        this.lbkyje.Text = d_kyje.ToString("F01");
        this.lbsyjg.Text = d_syjg.ToString("F01");
        this.trhj.Visible = false;
        if (ds.Tables[0].Rows.Count.Equals(0))
        {
            this.trno.Visible = true;
        }
        else
        {
            this.trno.Visible = false;
        }

        this.JXGrid1.DataSource = ds;
        this.JXGrid1.DataBind();
    }
    #endregion

  

  
 
    }
