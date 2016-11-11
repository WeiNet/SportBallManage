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

public partial class re_zdcx : BasePage
{
    #region 全局变数
    ReportDB objReportDB = new ReportDB();
    KFB_HYGLDB objHygl = new KFB_HYGLDB();
    AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request["zdid"] != null)
        {
            string strmes = "";
            string strreid = this.Request["zdid"].ToString();
            if (!strreid.Equals("ContentPlaceHolder11_btqd"))
            {
                try
                {
                    string[] strid = strreid.Split('-');

                    //賽事ID
                    string strgameid = strid[0].ToString().Replace("bt", "");
                    //下注ID
                    string strxzid = strid[1].ToString();
                    //類型
                    string strtype = strid[2].ToString();

                    if (strtype.Equals("0"))
                    {
                        strmes = "還原";
                    }
                    else
                    {
                        strmes = "刪除";
                    }

                    ArrayList arrsql = new ArrayList();
                    ArrayList arrpa = new ArrayList();
                    decimal dkyed = 0;
                    //刪除賽事
                    objReportDB.GGdel(strgameid, Convert.ToInt32(strtype), arrsql, arrpa);

                    //重新計算過關可贏金額
                    DataSet ds = objReportDB.GGData(strxzid);
                    decimal dxzje = 0;
                    decimal dpl = 1;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dxzje = Convert.ToDecimal(ds.Tables[0].Rows[0]["n_xzje"].ToString());
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dpl = dpl * (1 + Convert.ToDecimal(ds.Tables[0].Rows[0]["n_pl"].ToString()));
                        }
                    }
                    dkyed = dxzje * dpl;
                    //囘寫數據庫
                    objReportDB.UPGGData(strxzid, dkyed, arrsql, arrpa);

                    //事務開始
                    objReportDB.GGTran(arrsql, arrpa);

                    ShowMsg( strmes + "成功！");
                }
                catch (Exception ex)
                {
                    this.WriteLog("用户名=" + mUserID+ex.ToString());
                    ShowMsg( strmes + "失敗！");
                }
            }
        }

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
    protected void bthy_Click(object sender, EventArgs e)
    {
        Button bthf = ((Button)sender);
        int index = ((System.Web.UI.WebControls.GridViewRow)(bthf.Parent.Parent)).RowIndex;
        string strid = ((Label)this.JXGrid1.Rows[index].Cells[0].FindControl("lbn_xzdh")).Text;
       KFB_PTZD mo_PTZD = new KFB_PTZD(); 
        mo_PTZD.N_XZDH = strid;
        mo_PTZD.N_DEL = 0;
        mo_PTZD.N_DELYY = "";
        mo_PTZD.N_XGJL = "R;re_zdcx;" + mUserID + ";" + GetIp() + ";" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        if (this.objReportDB.IsGZ(strid, "1"))
        {
            if (objReportDB.CheckBet(strid, "4"))
            {
                if (this.rdon_gz.SelectedValue.Equals("1"))
                    objReportDB.delO(mo_PTZD);
                else
                    objReportDB.del(mo_PTZD);
                objReportDB.ModifyRecord(strid, "4");
            }
            else
            {
               this.ShowMsg("已过账注单不能恢复，如需恢复请cs创建注单号");
                return;
            }
        }
        else
        {
            if (this.rdon_gz.SelectedValue.Equals("1"))
                objReportDB.delO(mo_PTZD);
            else
                objReportDB.del(mo_PTZD);
        }
        string strgg = ((Label)this.JXGrid1.Rows[index].Cells[0].FindControl("lbn_gsty")).Text;
        if (strgg.Equals("3") || strgg.Equals("7"))
        {
            string strxzje = this.JXGrid1.Rows[index].Cells[4].Text;
            string strhydh = this.JXGrid1.Rows[index].Cells[2].Text;
            objReportDB.HuiFuHYYE(strhydh, -decimal.Parse(strxzje) / 10000);
            if (this.rdon_gz.SelectedValue.Equals("1"))
                objReportDB.updatejsO(strid, 0);
            else
                objReportDB.updatejs(strid, 0);
        }
        SetGrid();
    }

    protected void btdel_Click(object sender, EventArgs e)
    {
        Button btgb = ((Button)sender);
        int index = ((System.Web.UI.WebControls.GridViewRow)(btgb.Parent.Parent)).RowIndex;
        string strid = ((Label)this.JXGrid1.Rows[index].Cells[0].FindControl("lbn_xzdh")).Text;
       KFB_PTZD mo_PTZD = new KFB_PTZD(); 
        mo_PTZD.N_XZDH = strid;
        mo_PTZD.N_DEL = 1;
        mo_PTZD.N_DELYY = this.delyy.Value;
        mo_PTZD.N_XGJL = "D;re_zdcx;" + mUserID + ";" + GetIp() + ";" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        mo_PTZD.N_HYJG = 0;
        if (objReportDB.IsGZ(strid, "1"))
        {
            //if (o_PTZD.CheckBet(strid, "0") || o_PTZD.CheckBet(strid, "3"))
            if (objReportDB.CheckBet(strid, "0"))
            {
                if (this.rdon_gz.SelectedValue.Equals("1"))
                    objReportDB.delO(mo_PTZD);
                else
                    objReportDB.del(mo_PTZD);

                objReportDB.ModifyRecord(strid, "0");
                //o_PTZD.ModifyRecord(strid, "3");
            }
            else
            {
                this.ShowMsg( "已过账注单不能删除，如需删除请cs创建注单号");
                return;
            }
        }
        else
        {
            if (this.rdon_gz.SelectedValue.Equals("1"))
                objReportDB.delO(mo_PTZD);
            else
                objReportDB.del(mo_PTZD);
        }


        //if (o_PTZD.IsGZ(strid, "1") && (o_PTZD.CheckBet(strid, "0") || o_PTZD.CheckBet(strid, "2")))
        //{
        //    if (this.rdon_gz.SelectedValue.Equals("1"))
        //        o_PTZD.delO(mo_PTZD);
        //    else
        //        o_PTZD.del(mo_PTZD);

        //    o_PTZD.ModifyRecord(strid);
        //}
        //else
        //{


        //    ShowPageMesg("00000", "已过账注单不能删除，如需删除请cs创建注单号");
        //    return;
        //}
        string strgg = ((Label)this.JXGrid1.Rows[index].Cells[0].FindControl("lbn_gsty")).Text;
        if (strgg.Equals("3") || strgg.Equals("7"))
        {
            string strxzje = this.JXGrid1.Rows[index].Cells[4].Text;
            string strhydh = this.JXGrid1.Rows[index].Cells[2].Text;
            string strhyjg = this.JXGrid1.Rows[index].Cells[5].Text;
            if (strhyjg.Equals(""))
                strhyjg = "0";
            if (!this.objReportDB.getGGCOL(strid, "n_js").Equals("1"))//未計算
            {

                objReportDB.HuiFuHYYE(strhydh, decimal.Parse(strxzje) / 10000);
            }
            else
            {

                objReportDB.HuiFuHYYE(strhydh, -decimal.Parse(strhyjg) / 10000);
            }
        }
        SetGrid();
    }
    #endregion

    #region gridview事件
    protected void JXGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            for (int i = 5; i < 10; i++)
            {
                if (e.Row.Cells[i].Text.IndexOf('-') > -1)
                {
                    e.Row.Cells[i].ForeColor = Color.Red;
                }
                else
                {
                    e.Row.Cells[i].ForeColor = Color.Green;
                }
            }
        }
      
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
            //strwf = Comm.ChType(strwf) + (strgglp.Equals("") ? "" : ("<br><span class='ENG_BLUE'>" + strgglp + "</span>"));
            strwf = Comm.GetPlayName(strwf, strgsty) + (strgglp.Equals("") ? "" : ("<br><span class='ENG_BLUE'>" + strgglp + "</span>"));

            //注單内容
            string strnr = "";
            DataSet ds = this.objReportDB.GetZDNR(strdh);


            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows.Count == 1)
                {
                    strnr = ds.Tables[0].Rows[0]["n_xznr"].ToString() + strdelyy;
                    strwf = Comm.Ch234Type(strwf, strnr);
                }
                else
                {
                    strnr = " <table width='100%'  border='0' cellpadding='0' cellspacing='0' > ";
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        //每個賽事的刪除
                        string strggdel = ds.Tables[0].Rows[j]["n_del"].ToString();
                        //是否刪除
                        string strbttext = "";
                        string strsfsc = "";
                        string strtype = "";
                        if (strggdel.Equals("1"))
                        {
                            strbttext = "還原";
                            strsfsc = "<SPAN  class='pk'>已刪除</span>" + ds.Tables[0].Rows[j]["n_delyy"].ToString();
                            strtype = "0";
                        }
                        else
                        {
                            strbttext = "刪除";
                            strsfsc = " ";
                            strtype = "1";
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

                        if (j < ds.Tables[0].Rows.Count - 1)
                        {
                            strnr = strnr + " <tr> <td width='10'  style='border-top-style: none; border-bottom-color: ; border-right-style: none; border-left-style: none'  > " + Convert.ToString(j + 1) + "</td> <td   style='border-top-style: none; border-bottom-color: ; border-right-style: none; border-left-style: none'  >" + ds.Tables[0].Rows[j]["n_xznr"].ToString() + "      輸贏：" + strps + "  " + strsfsc + " </td> ";
                            strnr = strnr + " <td  width='10%' bgcolor='#FFFFFF' align='center'  style='border-top-style: none; border-bottom-color: ; border-right-style: none; border-left-style: none' > <input id='bt" + ds.Tables[0].Rows[j]["n_id"].ToString() + "-" + strdh + "-" + strtype + "' type='button' value='" + strbttext + "' style='display:none' onclick='GGUP(this)' /> </td>";
                            strnr = strnr + " </tr>";
                        }
                        else
                        {
                            strnr = strnr + " <tr> <td width='10'  style='border-style: none;'> " + Convert.ToString(j + 1) + "</td> <td  style='border-style: none;' >" + ds.Tables[0].Rows[j]["n_xznr"].ToString() + "      輸贏：" + strps + "  " + strsfsc + " </td> ";
                            strnr = strnr + " <td  width='10%' bgcolor='#FFFFFF' align='center' style='border-style: none;' > <input id='bt" + ds.Tables[0].Rows[j]["n_id"].ToString() + "-" + strdh + "-" + strtype + "' type='button' value='" + strbttext + "' style='display:none' onclick='GGUP(this)' /> </td>";
                            strnr = strnr + " </tr>";
                        }

                    }
                    strnr = strnr + " </table > ";
                }
            }
            e.Row.Cells[1].Text = strwf + "<br/>" + strdh + "<br/>[" + strip + "]";
            e.Row.Cells[3].Text = string.Format(strnr, "", "");//Modify By Jean替换注单内容的"{0},{1}"为空
            //modify by amanda 2011-08-04  小博退傭欄位顯示退傭實際金額
            e.Row.Cells[7].Text = ((Convert.ToDecimal(e.Row.Cells[7].Text.ToString()) * Convert.ToDecimal(e.Row.Cells[4].Text.ToString())) / 10000).ToString("0.0");
            string strsyjg = e.Row.Cells[6].Text;
            string strhyjg = e.Row.Cells[8].Text;
            string strgsjg = e.Row.Cells[9].Text;
            if (!strsyjg.Equals("") && !strsyjg.Equals("&nbsp;"))
            {
                e.Row.Cells[6].Text = Convert.ToString(Math.Round(Convert.ToDecimal(strsyjg), 2));
            }
            if (!strhyjg.Equals("") && !strhyjg.Equals("&nbsp;"))
            {
                e.Row.Cells[8].Text = Convert.ToString(Math.Round(Convert.ToDecimal(strhyjg), 2));
            }
            if (!strgsjg.Equals("") && !strgsjg.Equals("&nbsp;"))
            {
                e.Row.Cells[9].Text = Convert.ToString(Math.Round(Convert.ToDecimal(strgsjg), 2));
            }


            Button btdel = new Button();
            btdel.Text = "刪除";
            btdel.ID = "btdel";
            btdel.Attributes.Add("onclick", "return confirmsreason()");
            btdel.Attributes.Add("class", "button");
            btdel.Click += new EventHandler(btdel_Click);
            e.Row.Cells[9].Controls.Add(btdel);

            Button bthy = new Button();
            bthy.Attributes.Add("class", "button");
            bthy.Text = "還原";
            bthy.ID = "bthy";
            bthy.Click += new EventHandler(bthy_Click);
            e.Row.Cells[9].Controls.Add(bthy);

            if (strdel.Equals("1"))
            {
                btdel.Visible = false;
                bthy.Visible = true;
            }
            else
            {
                btdel.Visible = true;
                bthy.Visible = false;
            }
        }
    }
    #endregion

    #region 自定义事件
    private void SetGrid()
    {
        this.txtbh.Text = this.txtbh.Text.ToUpper().Trim();
        DataSet ds = new DataSet(); 
        string strbh = this.drtj.SelectedValue.Equals("0") ? "0" : Comm.Trim(this.txtbh.Text.Trim());
        if (this.drlx.SelectedValue.Equals("0"))
        {
            if (ms_GROUP_LEVEL.Equals("2"))
            {
                ds = this.objReportDB.ZDCX(this.drwf.SelectedValue + "0", this.drzwrq.SelectedValue.Replace("-", "/"), this.drzd.SelectedValue, this.drtj.SelectedValue, strbh, "1", this.rdon_gz.SelectedValue.ToString(), this.drpCount.SelectedValue);
                //  ds = o_PTZD.ZDCX(this.drlx.SelectedValue, "2008/07/30", this.drzd.SelectedValue, this.drtj.SelectedValue, this.txtbh.Text);
            }
            else
            {
                ds = this.objReportDB.ZDCX(this.drwf.SelectedValue, this.drzwrq.SelectedValue.Replace("-", "/"), this.drzd.SelectedValue, this.drtj.SelectedValue, strbh, "1", this.rdon_gz.SelectedValue.ToString(), this.drpCount.SelectedValue);
            }
        }
        else if (this.drlx.SelectedValue.Equals("1"))
        {
            ds = this.objReportDB.ZDCX(this.drwf.SelectedValue, this.drzwrq.SelectedValue.Replace("-", "/"), this.drzd.SelectedValue, this.drtj.SelectedValue, strbh, "2", this.rdon_gz.SelectedValue.ToString(), this.drpCount.SelectedValue);
        }
        else
        {
            ds = this.objReportDB.ZDCX(this.drwf.SelectedValue, this.drzwrq.SelectedValue.Replace("-", "/"), this.drzd.SelectedValue, this.drtj.SelectedValue, strbh, "3", this.rdon_gz.SelectedValue.ToString(), this.drpCount.SelectedValue);
        }
        this.JXGrid1.DataSource = ds;
        this.JXGrid1.DataBind();
        this.Panel1.Visible = true;
    }

    private void SetData()
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
        DateTime dtNow = Comm.GetZWRQ();
        DateTime dt = dtNow.AddDays(5);
        for (int i = 0; i < 20; i++)
        {
            ListItem item = new ListItem();
            item.Value = dt.ToString("yyyy/MM/dd");
            item.Text = dt.ToString("MM") + "/" + dt.ToString("dd") + " " + Comm.CaculateWeekDay(dt.Year, dt.Month, dt.Day);
            this.drzwrq.Items.Add(item);
            dt = dt.AddDays(-1);
        }
        this.drzwrq.SelectedValue = dtNow.ToString("yyyy/MM/dd");
        this.btqd.Attributes.Add("onclick", "GGUP(this);");
    }
    #endregion 
}
