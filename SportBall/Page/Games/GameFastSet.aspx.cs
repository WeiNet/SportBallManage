#region
///程式代號：      GameFastSet
///程式名稱：      GameFastSet
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion


public partial class GameFastSet : BasePage
{
    #region 全局变量
    BaseBallDB objBase = new BaseBallDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["N_ID"] != null)
            {

                KFB_BASEBALL o_KFB_BASEBALL = objBase.GetModel(Convert.ToInt32(Request.QueryString["N_ID"].ToString()));
                if (o_KFB_BASEBALL.N_LX.Equals("b_zq"))
                {
                    this.drpFS.Items.RemoveAt(1);
                    for (int i = 0; i < 20; i++)
                        this.drpFS.Items.RemoveAt(11);
                }
                string s_aDWA = objBase.GetBallName(o_KFB_BASEBALL.N_VISIT.Value);
                string s_aDWB = String.Empty;
                if (o_KFB_BASEBALL.N_HOME.HasValue)
                    s_aDWB = objBase.GetBallName(o_KFB_BASEBALL.N_HOME.Value);
                switch (Request.QueryString["PK"].ToString().ToUpper())
                {
                    case "RF":
                        this.btnOpen.Value = o_KFB_BASEBALL.N_RF_OPEN.Value.Equals(1) ? "關閉中" : "開放中";
                        this.hidOpen.Value = o_KFB_BASEBALL.N_RF_OPEN.ToString();
                        this.btnLOpen.Value = o_KFB_BASEBALL.N_RF_LOCK_V.Value.Equals(1) ? "關" : "開";
                        this.hidLOpen.Value = o_KFB_BASEBALL.N_RF_LOCK_V.ToString();
                        this.btnROpen.Value = o_KFB_BASEBALL.N_RF_LOCK_H.Value.Equals(1) ? "關" : "開";
                        this.hidROpen.Value = o_KFB_BASEBALL.N_RF_LOCK_H.ToString();
                        this.drpFS.Value = o_KFB_BASEBALL.N_RFFS.ToString();
                        this.drpLB.Value = o_KFB_BASEBALL.N_RFLX.ToString();
                        this.txtPL.Value = o_KFB_BASEBALL.N_RFBL.ToString();
                        this.chkLet.Checked = o_KFB_BASEBALL.N_LET.Value.Equals(1) ? true : false;
                        this.chkLet.Value = o_KFB_BASEBALL.N_LET.ToString();
                        this.lblLXName.Text = "讓分";
                        this.lblLDW.Text = s_aDWA + "賠率";
                        this.lblRDW.Text = s_aDWB + "賠率";
                        this.txtPLTT.Value = Convert.ToString(o_KFB_BASEBALL.N_LRFPL + o_KFB_BASEBALL.N_RRFPL);
                        this.txtLPL.Value = o_KFB_BASEBALL.N_LRFPL.ToString();
                        this.txtRPL.Value = o_KFB_BASEBALL.N_RRFPL.ToString();
                        this.txtFS.Visible = false;
                        break;
                    case "DX":
                        this.btnOpen.Value = o_KFB_BASEBALL.N_DX_OPEN.Value.Equals(1) ? "關閉中" : "開放中";
                        this.hidOpen.Value = o_KFB_BASEBALL.N_DX_OPEN.ToString();
                        this.btnLOpen.Value = o_KFB_BASEBALL.N_DX_LOCK_V.Value.Equals(1) ? "關" : "開";
                        this.hidLOpen.Value = o_KFB_BASEBALL.N_DX_LOCK_V.ToString();
                        this.btnROpen.Value = o_KFB_BASEBALL.N_DX_LOCK_H.Value.Equals(1) ? "關" : "開";
                        this.hidROpen.Value = o_KFB_BASEBALL.N_DX_LOCK_H.ToString();
                        this.txtFS.Text = o_KFB_BASEBALL.N_DXFS.ToString();
                        this.drpLB.Value = o_KFB_BASEBALL.N_DXLX.ToString();
                        this.txtPL.Value = o_KFB_BASEBALL.N_DXBL.ToString();
                        this.trRF.Visible = false;
                        this.lblLXName.Text = "大小";
                        this.lblLDW.Text = "大賠率";
                        this.lblRDW.Text = "小賠率";
                        this.txtPLTT.Value = Convert.ToString(o_KFB_BASEBALL.N_DXDPL + o_KFB_BASEBALL.N_DXXPL);
                        this.txtLPL.Value = o_KFB_BASEBALL.N_DXDPL.ToString();
                        this.txtRPL.Value = o_KFB_BASEBALL.N_DXXPL.ToString();
                        this.drpFS.Visible = false;
                        break;
                    case "DY":
                        if (o_KFB_BASEBALL.N_LX.Equals("b_zq"))
                        {
                            this.sphj.InnerText = "◎和局賠率：";
                            this.chkLock.Visible = false;
                            this.txtPLTT.Value = o_KFB_BASEBALL.N_HJPL.ToString();
                            this.txtPLTT.Attributes.Remove("readonly");
                            this.txtPLTT.Attributes.Remove("onblur");
                            this.txtLPL.Attributes.Remove("onblur");
                            this.txtRPL.Attributes.Remove("onblur");
                            this.btnOpen.Value = o_KFB_BASEBALL.N_DY_OPEN.Value.Equals(1) ? "關閉中" : "開放中";
                            this.hidOpen.Value = o_KFB_BASEBALL.N_DY_OPEN.ToString();
                            this.btnLOpen.Value = o_KFB_BASEBALL.N_DY_LOCK_V.Value.Equals(1) ? "關" : "開";
                            this.hidLOpen.Value = o_KFB_BASEBALL.N_DY_LOCK_V.ToString();
                            this.btnROpen.Value = o_KFB_BASEBALL.N_DY_LOCK_H.Value.Equals(1) ? "關" : "開";
                            this.hidROpen.Value = o_KFB_BASEBALL.N_DY_LOCK_H.ToString();
                            this.trLX.Visible = false;
                            this.trRF.Visible = false;
                            this.lblLXName.Text = "獨贏";
                            this.lblLDW.Text = s_aDWA + "賠率";
                            this.lblRDW.Text = s_aDWB + "賠率";
                            //this.txtPLTT.Value = Convert.ToString(o_KFB_BASEBALL.N_LDYPL + o_KFB_BASEBALL.N_RDYPL);
                            this.txtLPL.Value = o_KFB_BASEBALL.N_LDYPL.ToString();
                            this.txtRPL.Value = o_KFB_BASEBALL.N_RDYPL.ToString();
                        }
                        else
                        {
                            this.btnOpen.Value = o_KFB_BASEBALL.N_DY_OPEN.Value.Equals(1) ? "關閉中" : "開放中";
                            this.hidOpen.Value = o_KFB_BASEBALL.N_DY_OPEN.ToString();
                            this.btnLOpen.Value = o_KFB_BASEBALL.N_DY_LOCK_V.Value.Equals(1) ? "關" : "開";
                            this.hidLOpen.Value = o_KFB_BASEBALL.N_DY_LOCK_V.ToString();
                            this.btnROpen.Value = o_KFB_BASEBALL.N_DY_LOCK_H.Value.Equals(1) ? "關" : "開";
                            this.hidROpen.Value = o_KFB_BASEBALL.N_DY_LOCK_H.ToString();
                            this.trLX.Visible = false;
                            this.trRF.Visible = false;
                            this.lblLXName.Text = "獨贏";
                            this.lblLDW.Text = s_aDWA + "賠率";
                            this.lblRDW.Text = s_aDWB + "賠率";
                            this.txtPLTT.Value = Convert.ToString(o_KFB_BASEBALL.N_LDYPL + o_KFB_BASEBALL.N_RDYPL);
                            this.txtLPL.Value = o_KFB_BASEBALL.N_LDYPL.ToString();
                            this.txtRPL.Value = o_KFB_BASEBALL.N_RDYPL.ToString();
                        }
                        break;
                    case "SY":
                        this.btnOpen.Value = o_KFB_BASEBALL.N_SY_OPEN.Value.Equals(1) ? "關閉中" : "開放中";
                        this.hidOpen.Value = o_KFB_BASEBALL.N_SY_OPEN.ToString();
                        this.btnLOpen.Value = o_KFB_BASEBALL.N_SY_LOCK_V.Value.Equals(1) ? "關" : "開";
                        this.hidLOpen.Value = o_KFB_BASEBALL.N_SY_LOCK_V.ToString();
                        this.btnROpen.Value = o_KFB_BASEBALL.N_SY_LOCK_H.Value.Equals(1) ? "關" : "開";
                        this.hidROpen.Value = o_KFB_BASEBALL.N_SY_LOCK_H.ToString();
                        this.trLX.Visible = false;
                        this.trRF.Visible = false;
                        this.lblLXName.Text = "一輸二贏";
                        this.lblLDW.Text = s_aDWA + "賠率";
                        this.lblRDW.Text = s_aDWB + "賠率";
                        this.txtPLTT.Value = Convert.ToString(o_KFB_BASEBALL.N_LSYPL + o_KFB_BASEBALL.N_RSYPL);
                        this.txtLPL.Value = o_KFB_BASEBALL.N_LSYPL.ToString();
                        this.txtRPL.Value = o_KFB_BASEBALL.N_RSYPL.ToString();
                        break;
                    case "DS":
                        this.btnOpen.Value = o_KFB_BASEBALL.N_DS_OPEN.Value.Equals(1) ? "關閉中" : "開放中";
                        this.hidOpen.Value = o_KFB_BASEBALL.N_DS_OPEN.ToString();
                        this.btnLOpen.Value = o_KFB_BASEBALL.N_DS_LOCK_V.Value.Equals(1) ? "關" : "開";
                        this.hidLOpen.Value = o_KFB_BASEBALL.N_DS_LOCK_V.ToString();
                        this.btnROpen.Value = o_KFB_BASEBALL.N_DS_LOCK_H.Value.Equals(1) ? "關" : "開";
                        this.hidROpen.Value = o_KFB_BASEBALL.N_DS_LOCK_H.ToString();
                        this.trLX.Visible = false;
                        this.trRF.Visible = false;
                        this.lblLXName.Text = "單雙";
                        this.lblLDW.Text = "單賠率";
                        this.lblRDW.Text = "雙賠率";
                        this.txtPLTT.Value = Convert.ToString(o_KFB_BASEBALL.N_DSDPL + o_KFB_BASEBALL.N_DSSPL);
                        this.txtLPL.Value = o_KFB_BASEBALL.N_DSDPL.ToString();
                        this.txtRPL.Value = o_KFB_BASEBALL.N_DSSPL.ToString();
                        break;
                }
                this.lblDWName.Text = "[ " + s_aDWA + "  " + s_aDWB + " ] - " + GeCB(o_KFB_BASEBALL.N_CBXH.Value) + " - " + this.lblLXName.Text;
                this.lblDWName.Text = this.lblDWName.Text.Trim();
            }
        }

    }
    #endregion

    #region 按钮事件
    protected void btnModify_Click(object sender, EventArgs e)
    {
        Hashtable o_HtStart = new Hashtable();
        
        KFB_BASEBALL o_KFB_BASEBALL = this.objBase.GetModel(Convert.ToInt32(Request.QueryString["N_ID"].ToString()));

        switch (Request.QueryString["PK"].ToString().ToUpper())
        {
            case "RF":
                o_KFB_BASEBALL.N_RF_OPEN = this.hidOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_RF_LOCK_V = this.hidLOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_RF_LOCK_H = this.hidROpen.Value.Equals("1") ? 1 : 0;

                o_KFB_BASEBALL.N_RFFS = Convert.ToDecimal(this.drpFS.Value);
                o_KFB_BASEBALL.N_RFLX = Convert.ToInt32(this.drpLB.Value);
                o_KFB_BASEBALL.N_RFBL = Convert.ToInt32(this.txtPL.Value);

                o_KFB_BASEBALL.N_LET = this.chkLet.Checked ? 1 : 0;

                decimal? temp = 0;
                if ((this.chkLet.Value.Equals("0") && this.chkLet.Checked) || (this.chkLet.Value.Equals("1") && !this.chkLet.Checked))
                {
                    temp = o_KFB_BASEBALL.N_LDYPL;
                    o_KFB_BASEBALL.N_LDYPL = o_KFB_BASEBALL.N_RDYPL;
                    o_KFB_BASEBALL.N_RDYPL = temp;

                    temp = o_KFB_BASEBALL.N_LSYPL;
                    o_KFB_BASEBALL.N_LSYPL = o_KFB_BASEBALL.N_RSYPL;
                    o_KFB_BASEBALL.N_RSYPL = temp;
                }
                o_KFB_BASEBALL.N_LRFPL = Convert.ToDecimal(this.txtLPL.Value);
                o_KFB_BASEBALL.N_RRFPL = Convert.ToDecimal(this.txtRPL.Value);
                break;
            case "DX":
                o_KFB_BASEBALL.N_DX_OPEN = this.hidOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_DX_LOCK_V = this.hidLOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_DX_LOCK_H = this.hidROpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_DXFS = Convert.ToDecimal(this.txtFS.Text);
                o_KFB_BASEBALL.N_DXLX = Convert.ToInt32(this.drpLB.Value);
                o_KFB_BASEBALL.N_DXBL = Convert.ToInt32(this.txtPL.Value);

                o_KFB_BASEBALL.N_DXDPL = Convert.ToDecimal(this.txtLPL.Value);
                o_KFB_BASEBALL.N_DXXPL = Convert.ToDecimal(this.txtRPL.Value);
                break;
            case "DY":
                if (o_KFB_BASEBALL.N_LX.Equals("b_zq"))
                {
                    o_KFB_BASEBALL.N_HJPL = Convert.ToDecimal(this.txtPLTT.Value);
                }
                o_KFB_BASEBALL.N_DY_OPEN = this.hidOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_DY_LOCK_V = this.hidLOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_DY_LOCK_H = this.hidROpen.Value.Equals("1") ? 1 : 0;

                o_KFB_BASEBALL.N_LDYPL = Convert.ToDecimal(this.txtLPL.Value);
                o_KFB_BASEBALL.N_RDYPL = Convert.ToDecimal(this.txtRPL.Value);
                break;
            case "SY":
                o_KFB_BASEBALL.N_SY_OPEN = this.hidOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_SY_LOCK_V = this.hidLOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_SY_LOCK_H = this.hidROpen.Value.Equals("1") ? 1 : 0;

                o_KFB_BASEBALL.N_LSYPL = Convert.ToDecimal(this.txtLPL.Value);
                o_KFB_BASEBALL.N_RSYPL = Convert.ToDecimal(this.txtRPL.Value);
                break;
            case "DS":
                o_KFB_BASEBALL.N_DS_OPEN = this.hidOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_DS_LOCK_V = this.hidLOpen.Value.Equals("1") ? 1 : 0;
                o_KFB_BASEBALL.N_DS_LOCK_H = this.hidROpen.Value.Equals("1") ? 1 : 0;

                o_KFB_BASEBALL.N_DSDPL = Convert.ToDecimal(this.txtLPL.Value);
                o_KFB_BASEBALL.N_DSSPL = Convert.ToDecimal(this.txtRPL.Value);
                break;
        }
        if (o_KFB_BASEBALL.N_LX.Equals("b_zs"))
        {
            this.objBase.UpdateZS(o_KFB_BASEBALL, o_HtStart);
        }
        else if (o_KFB_BASEBALL.N_LX.Equals("b_zq"))
        {
            this.objBase.UpdateZQ(o_KFB_BASEBALL, o_HtStart);
        }
        else
        {
            this.objBase.Update(o_KFB_BASEBALL, o_HtStart);
        }
        this.objBase.SetTran(o_HtStart);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Close", "refresh(false);", true);
    }

    #endregion

    #region gridview事件

    #endregion

    #region 自定义事件
    private string GeCB(int i_aCB)
    {
        string s_Name = String.Empty;
        switch (i_aCB)
        {
            case 1:
                s_Name = "全場";
                break;
            case 2:
                s_Name = "上半場";
                break;
            case 3:
                s_Name = "下半場";
                break;
        }
        return s_Name;
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Status", "document.getElementById('btnOpen').value=" + this.hidOpen.Value + "==1?\"關閉中\" : \"開放中\";", true);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "StatusL", "document.getElementById('btnLOpen').value=" + this.hidLOpen.Value + "==1?\"關\" : \"開\";", true);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "StatusR", "document.getElementById('btnROpen').value=" + this.hidROpen.Value + "==1?\"關\" : \"開\";", true);
    }
    #endregion

  
}
