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

public partial class re_zdxg : BasePage
{
    #region 全局变数
    ReportDB objReportDB = new ReportDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetData();
            this.Panel1.Visible = false;
        }
        SetGrid();
    }


    #endregion

    #region 按钮事件
    protected void btqd_Click(object sender, EventArgs e)
    {

    }

    protected void btqbxg_Click(object sender, EventArgs e)
    {
        KFB_PTZD mo_PTZD = new KFB_PTZD(); 
        string[] strupdate = this.hidupdate.Value.Split(';');
        this.objReportDB.XGZDZWRQ(strupdate[0], strupdate[1], strupdate[2], strupdate[3], "");
       this.ShowMsg("修改成功!");
        SetGrid();
    }
    protected void btxg_Click(object sender, EventArgs e)
    {
        Button btxg = ((Button)sender);
        int index = ((System.Web.UI.WebControls.GridViewRow)(btxg.Parent.Parent)).RowIndex;
        string strid = ((Label)this.JXGrid1.Rows[index].Cells[0].FindControl("lbn_xzdh")).Text;
        KFB_PTZD mo_PTZD = new KFB_PTZD();
        this.objReportDB.XGZDZWRQ("", "", "", "", strid);
        this.ShowMsg("修改成功!");
        SetGrid();
    }
    #endregion

    #region gridview事件
    protected void JXGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strdh = ((Label)e.Row.FindControl("lbn_xzdh")).Text;
            string strip = ((Label)e.Row.FindControl("lbn_hyip")).Text;
            string strdel = ((Label)e.Row.FindControl("lbn_del")).Text;
            string strwf = ((Label)e.Row.FindControl("lbn_xzwf")).Text;
            string strgsty = ((Label)e.Row.FindControl("lbn_gsty")).Text;
            string strgglp = ((Label)e.Row.FindControl("lbn_gglp")).Text;
            string strdelyy = "";
            if (strdel.Equals("1"))
                strdelyy = ((Label)e.Row.FindControl("lbn_delyy")).Text;
            // this.JXGrid1.Rows[i].Cells[3].Text = strnr;
            strwf = Comm.ChType(strwf) + (strgglp.Equals("") ? "" : ("<br><span class='ENG_BLUE'>" + strgglp + "</span>"));

            //注單内容
            string strnr = "";
            string strzdzwrq = "";
            string strbszwrq = "";
            DataSet ds = this.objReportDB.GetZDXGNR(strdh);


            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows.Count == 1)
                {
                    strnr = ds.Tables[0].Rows[0]["n_xznr"].ToString() + strdelyy;
                    strzdzwrq = "<span class='RED_BET'>" + ds.Tables[0].Rows[0]["n_zwrq"].ToString() + "</span>";
                    strbszwrq = "<span class='RED_BET'>" + ds.Tables[0].Rows[0]["n_zwdate"].ToString() + "</span>";
                    strwf = Comm.Ch234Type(strwf, strnr);
                }
                else
                {
                    strnr = " <table width='100%'  border='0' cellpadding='0' cellspacing='0' > ";
                    strzdzwrq = " <table width='100%'  border='0' cellpadding='0' cellspacing='0' > ";
                    strbszwrq = " <table width='100%'  border='0' cellpadding='0' cellspacing='0' > ";
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        //每個賽事的刪除
                        string strggdel = ds.Tables[0].Rows[j]["n_del"].ToString();
                        //是否刪除
                        string strsfsc = "";
                        if (strggdel.Equals("1"))
                        {
                            strsfsc = "<SPAN  class='pk'>已刪除</span>" + ds.Tables[0].Rows[j]["n_delyy"].ToString();
                        }
                        else
                        {
                            strsfsc = " ";
                        }

                        string strps = "";
                        if (!ds.Tables[0].Rows[j]["n_dlswcz"].ToString().Equals(""))
                        {
                            if (Convert.ToDecimal(ds.Tables[0].Rows[j]["n_dlswcz"].ToString()) >= 0)
                            {
                                strps = "<span CLASS='Green' >" + ds.Tables[0].Rows[j]["n_dlswcz"].ToString() + "</span>";
                            }
                            else
                            {
                                strps = "<span CLASS='RED_FENSHU' >" + ds.Tables[0].Rows[j]["n_dlswcz"].ToString() + "</span>";
                            }
                        }
                        string sfxd1 = "<span style='font-size:13px'>&nbsp;</span><br>";
                        string sfxd2 = "<span style='font-size:13px'>&nbsp;</span><br><span style='font-size:13px'>&nbsp;</span><br>";
                        if (ds.Tables[0].Rows[j]["n_zwrq"].ToString() != ds.Tables[0].Rows[j]["n_zwdate"].ToString())
                        {
                            sfxd1 = sfxd1 + "<span class='RED_BET'>";
                            sfxd2 = "</span>" + sfxd2;
                        }
                        if (j < ds.Tables[0].Rows.Count - 1)
                        {
                            strnr = strnr + " <tr> <td width='10'  style='border-top-style: none; border-bottom-color: ; border-right-style: none; border-left-style: none'  > " + Convert.ToString(j + 1) + "</td> <td   style='border-top-style: none; border-bottom-color: ; border-right-style: none; border-left-style: none'  >" + ds.Tables[0].Rows[j]["n_xznr"].ToString() + "      輸贏：" + strps + "  " + strsfsc + " </td> ";
                            strnr = strnr + " </tr>";
                            strzdzwrq = strzdzwrq + "<tr><td style='border-top-color:white; border-bottom-color:;border-right-color:white;border-left-color:white'> " + sfxd1 + ds.Tables[0].Rows[j]["n_zwrq"].ToString() + sfxd2 + "</td></tr>";
                            strbszwrq = strbszwrq + "<tr><td style='border-top-color:white; border-bottom-color:;border-right-color:white;border-left-color:white'> " + sfxd1 + ds.Tables[0].Rows[j]["n_zwdate"].ToString() + sfxd2 + "</td></tr>";
                        }
                        else
                        {
                            strnr = strnr + " <tr> <td width='10'  style='border-style: none;'> " + Convert.ToString(j + 1) + "</td> <td  style='border-style: none;' >" + ds.Tables[0].Rows[j]["n_xznr"].ToString() + "      輸贏：" + strps + "  " + strsfsc + " </td> ";
                            strnr = strnr + " </tr>";
                            strzdzwrq = strzdzwrq + "<tr> <td style='border-style: none;' > " + sfxd1 + ds.Tables[0].Rows[j]["n_zwrq"].ToString() + sfxd2 + "</td></tr>";
                            strbszwrq = strbszwrq + "<tr> <td style='border-style: none;' > " + sfxd1 + ds.Tables[0].Rows[j]["n_zwdate"].ToString() + sfxd2 + "</td></tr>";
                        }

                    }
                    strnr = strnr + " </table > ";
                    strzdzwrq = strzdzwrq + " </table > ";
                    strbszwrq = strbszwrq + " </table > ";
                }
            }
            e.Row.Cells[1].Text = strwf + "<br/>" + strdh + "<br/>[" + strip + "]";
            e.Row.Cells[3].Text = strnr;
            e.Row.Cells[4].Text = strzdzwrq;
            e.Row.Cells[5].Text = strbszwrq;
            Button btxg = new Button();
            btxg.Text = "修改";
            btxg.ID = "btxg";
            btxg.Attributes.Add("onclick", "return xiugaiconfirms()");
            btxg.Attributes.Add("class", "button");
            btxg.Click += new EventHandler(btxg_Click);
           e.Row.Cells[7].Controls.Add(btxg);

        }

        if (this.JXGrid1.Rows.Count.Equals(0))
            this.btqbxg.Enabled = false;
        else
            this.btqbxg.Enabled = true;
    }
  
    #endregion

    #region 自定义事件
    public void SetData()
    {
        if (ms_GROUP_LEVEL.Equals("2"))
        {
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(1);
            this.drwf.Items.RemoveAt(4);
            this.tr_xzfs.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        DateTime dt = Comm.GetZWRQ();
        for (int i = 0; i < 10; i++)
        {
            ListItem item = new ListItem();
            item.Value = dt.ToString("yyyy/MM/dd");
            item.Text = dt.ToString("MM") + "/" + dt.ToString("dd") + " " + Comm.CaculateWeekDay(dt.Year, dt.Month, dt.Day);
            this.drzwrq.Items.Add(item);
            dt = dt.AddDays(-1);
        }
        this.btqd.Attributes.Add("onclick", "GGUPXG(this);");
    }

    public void SetGrid()
    {
        DataSet ds = new DataSet();
        if (ms_GROUP_LEVEL.Equals("2"))
        {
            ds = objReportDB.ZDXGCX(this.drwf.SelectedValue + "0", this.drzwrq.SelectedValue.Replace("-", "/"), this.drzd.SelectedValue, this.drlx.SelectedValue);
            this.hidupdate.Value = this.drwf.SelectedValue + "0;" + this.drzwrq.SelectedValue.Replace("-", "/") + ";" + this.drzd.SelectedValue + ";" + this.drlx.SelectedValue;
        }
        else
        {
            ds = objReportDB.ZDXGCX(this.drwf.SelectedValue, this.drzwrq.SelectedValue.Replace("-", "/"), this.drzd.SelectedValue, this.drlx.SelectedValue);
            this.hidupdate.Value = this.drwf.SelectedValue + ";" + this.drzwrq.SelectedValue.Replace("-", "/") + ";" + this.drzd.SelectedValue + ";" + this.drlx.SelectedValue;
        }

        this.JXGrid1.DataSource = ds;
        this.JXGrid1.DataBind();
        this.Panel1.Visible = true;
    }
  
    #endregion

   
}
