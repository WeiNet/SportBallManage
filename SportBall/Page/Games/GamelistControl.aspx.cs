#region History
///程式代號：      GamelistControl
///程式名稱：      GamelistControl
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

public partial class GamelistControl : BasePage
{
    #region 全局变量
    private int mi_TYPE = -1;
    GameListControlDB objControl = new GameListControlDB();
    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ball"] != null)
        {
            switch (Request.QueryString["ball"])
            {
                case "b_zq":
                    mi_TYPE = 4;
                    this.lblball.Text = "足球";
                    this.lblball1.Text = "足球";
                    this.lblballJZ.Text = "足球";
                    this.lblballJZ1.Text = "足球";
                    break;
            }
        }
        if (!IsPostBack)
        {
            ;
            KFB_BBKG o_KFB_BBKG = this.objControl.GetModel(mi_TYPE);
            if (o_KFB_BBKG != null)
            {
                this.chkRFOpen.Checked = !o_KFB_BBKG.N_Z_RF.HasValue ? false : (o_KFB_BBKG.N_Z_RF.Value.Equals(1) ? true : false);
                this.chkDXOpen.Checked = !o_KFB_BBKG.N_Z_DX.HasValue ? false : (o_KFB_BBKG.N_Z_DX.Value.Equals(1) ? true : false);
                this.chkDYOpen.Checked = !o_KFB_BBKG.N_Z_DY.HasValue ? false : (o_KFB_BBKG.N_Z_DY.Value.Equals(1) ? true : false);
                this.chkDSOpen.Checked = !o_KFB_BBKG.N_Z_DS.HasValue ? false : (o_KFB_BBKG.N_Z_DS.Value.Equals(1) ? true : false);
                this.chkZDRFOpen.Checked = !o_KFB_BBKG.N_Z_ZDRF.HasValue ? false : (o_KFB_BBKG.N_Z_ZDRF.Value.Equals(1) ? true : false);
                this.chkZDDXOpen.Checked = !o_KFB_BBKG.N_Z_ZDDX.HasValue ? false : (o_KFB_BBKG.N_Z_ZDDX.Value.Equals(1) ? true : false);
                //this.chkSYOpen.Checked = !o_KFB_BBKG.N_Z_YSEY.HasValue ? false : (o_KFB_BBKG.N_Z_YSEY.Value.Equals(1) ? true : false);
                //this.chkBCDXOpen.Checked = !o_KFB_BBKG.N_Z_BCDX.HasValue ? false : (o_KFB_BBKG.N_Z_BCDX.Value.Equals(1) ? true : false);
                //this.chkBCDYOpen.Checked = !o_KFB_BBKG.N_Z_BCDY.HasValue ? false : (o_KFB_BBKG.N_Z_BCDY.Value.Equals(1) ? true : false);
                //this.chkBCRFOpen.Checked = !o_KFB_BBKG.N_Z_BCRF.HasValue ? false : (o_KFB_BBKG.N_Z_BCRF.Value.Equals(1) ? true : false);
                this.chkBDOpen.Checked = !o_KFB_BBKG.N_Z_BD.HasValue ? false : (o_KFB_BBKG.N_Z_BD.Value.Equals(1) ? true : false);
                this.chkRQSOpen.Checked = !o_KFB_BBKG.N_Z_RQS.HasValue ? false : (o_KFB_BBKG.N_Z_RQS.Value.Equals(1) ? true : false);
                this.chkBQCOpen.Checked = !o_KFB_BBKG.N_Z_BQC.HasValue ? false : (o_KFB_BBKG.N_Z_BQC.Value.Equals(1) ? true : false);

                this.chkGGOpen.Checked = !o_KFB_BBKG.N_Z_GG.HasValue ? false : (o_KFB_BBKG.N_Z_GG.Value.Equals(1) ? true : false);
                this.chkRFDXOpen.Checked = !o_KFB_BBKG.N_Z_GJ.HasValue ? false : (o_KFB_BBKG.N_Z_GJ.Value.Equals(1) ? true : false);
                this.chkJZFOpen.Checked = !o_KFB_BBKG.N_Z_JZF.HasValue ? false : (o_KFB_BBKG.N_Z_JZF.Value.Equals(1) ? true : false);

                this.txtRFTop.Text = o_KFB_BBKG.N_X_RF.ToString();
                this.txtDXTop.Text = o_KFB_BBKG.N_X_DX.ToString();
                this.txtDYTop.Text = o_KFB_BBKG.N_X_DY.ToString();
                this.txtDSTop.Text = o_KFB_BBKG.N_X_DS.ToString();
                this.txtZDRFTop.Text = o_KFB_BBKG.N_X_ZDRF.ToString();
                this.txtZDDXTop.Text = o_KFB_BBKG.N_X_ZDDX.ToString();
                //this.txtSYTop.Text = o_KFB_BBKG.N_X_YSEY.ToString();
                this.txtBCDXTop.Text = o_KFB_BBKG.N_X_BCDX.ToString();
                this.txtBCDYTop.Text = o_KFB_BBKG.N_X_BCDY.ToString();
                this.txtBCRFTop.Text = o_KFB_BBKG.N_X_BCRF.ToString();
                this.txtBDTop.Text = o_KFB_BBKG.N_X_BD.ToString();
                this.txtRQSTop.Text = o_KFB_BBKG.N_X_RQS.ToString();
                this.txtBQCXTop.Text = o_KFB_BBKG.N_X_BQC.ToString();

                this.txtGGTop.Text = o_KFB_BBKG.N_X_GG.ToString();
                this.txtRFDXTop.Text = o_KFB_BBKG.N_X_GJ.ToString();

                this.txtRFDZ.Text = o_KFB_BBKG.N_S_RF.ToString();
                this.txtDXDZ.Text = o_KFB_BBKG.N_S_DX.ToString();
                this.txtDYDZ.Text = o_KFB_BBKG.N_S_DY.ToString();
                this.txtDSDZ.Text = o_KFB_BBKG.N_S_DS.ToString();
                this.txtZDRFDZ.Text = o_KFB_BBKG.N_S_ZDRF.ToString();
                this.txtZDDXDZ.Text = o_KFB_BBKG.N_S_ZDDX.ToString();
                this.txtBCDXDZ.Text = o_KFB_BBKG.N_S_BCDX.ToString();
                this.txtBCDYDZ.Text = o_KFB_BBKG.N_S_BCDY.ToString();
                this.txtBCRFDZ.Text = o_KFB_BBKG.N_S_BCRF.ToString();
                this.txtBDDZ.Text = o_KFB_BBKG.N_S_BD.ToString();
                this.txtRQSDZ.Text = o_KFB_BBKG.N_S_RQS.ToString();
                this.txtBQCXDZ.Text = o_KFB_BBKG.N_S_BQC.ToString();
                this.txtGGDZ.Text = o_KFB_BBKG.N_S_GG.ToString();
                this.txtRFDXDZ.Text = o_KFB_BBKG.N_S_GJ.ToString();

                this.txtRFSingle.Text = o_KFB_BBKG.N_D_RF.ToString();
                this.txtDXSingle.Text = o_KFB_BBKG.N_D_DX.ToString();
                this.txtDYSingle.Text = o_KFB_BBKG.N_D_DY.ToString();
                this.txtDSSingle.Text = o_KFB_BBKG.N_D_DS.ToString();
                this.txtZDRFSingle.Text = o_KFB_BBKG.N_D_ZDRF.ToString();
                this.txtZDDXSingle.Text = o_KFB_BBKG.N_D_ZDDX.ToString();
                // this.txtSYSingle.Text = o_KFB_BBKG.N_D_YSEY.ToString();
                this.txtBCRFSingle.Text = o_KFB_BBKG.N_D_BCRF.ToString();
                this.txtBCDYSingle.Text = o_KFB_BBKG.N_D_BCDY.ToString();
                this.txtBCDXSingle.Text = o_KFB_BBKG.N_D_BCDX.ToString();
                this.txtBDSingle.Text = o_KFB_BBKG.N_D_BD.ToString();
                this.txtBQCSingle.Text = o_KFB_BBKG.N_D_BQC.ToString();
                this.txtRQSSingle.Text = o_KFB_BBKG.N_D_RQS.ToString();

                this.txtRFRate.Text = o_KFB_BBKG.N_J_RF.ToString();
                this.txtDXRate.Text = o_KFB_BBKG.N_J_DX.ToString();
                this.txtDYRate.Text = o_KFB_BBKG.N_J_DY.ToString();
                this.txtDSRate.Text = o_KFB_BBKG.N_J_DS.ToString();
                this.txtZDRFRate.Text = o_KFB_BBKG.N_J_ZDRF.ToString();
                this.txtZDDXRate.Text = o_KFB_BBKG.N_J_ZDDX.ToString();
                // this.txtSYRate.Text = o_KFB_BBKG.N_J_YSEY.ToString();
                this.txtBCDYRate.Text = o_KFB_BBKG.N_J_SBCDY.ToString();
                this.txtBCDXRate.Text = o_KFB_BBKG.N_J_SBCDX.ToString();
                this.txtBCRFRate.Text = o_KFB_BBKG.N_J_SBCRF.ToString();

                this.txtRFCJ.Text = o_KFB_BBKG.N_BJGPRFCJ.ToString();
                this.txtDXCJ.Text = o_KFB_BBKG.N_BJGPDXCJ.ToString();
                this.txtDSCJ.Text = o_KFB_BBKG.N_BJGPDSCJ.ToString();
            }
            else
            {
                this.ShowMsg( "請設定比賽控管！否則不能下注");
            }
            
            this.drpLM.DataSource = this.objControl.GetLM(mi_TYPE.ToString());
            this.drpLM.DataValueField = "N_NO";
            this.drpLM.DataTextField = "N_LMMC";
            this.drpLM.DataBind();
            this.drpLM.Items.Insert(0, new ListItem("全部", "0"));
        }
    }
    #endregion

    #region 按钮事件
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            KFB_BBKG o_KFB_BBKG = getKFB_BBKG();
            switch (((Button)sender).CommandName)
            {
                case "RF":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateRF(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");

                    }
                    else
                    {
                        objControl.AddRF(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "DX":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateDX(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddDX(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "DY":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateDY(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddDY(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "DS":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateDS(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddDS(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "ZDRF":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateZR(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddZR(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "ZDDX":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateZD(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddZD(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "BCRF":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateZQBCRF(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddZQBCRF(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "BCDX":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateZQBCDX(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddZQBCDX(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "BCDY":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateZQBCDY(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddZQBCDY(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "BD":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateBD(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddBD(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "RQS":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateRQS(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddRQS(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "BQC":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateBQC(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddBQC(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "GG":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateGG(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddGG(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "RFDX":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateRD(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddRD(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "JZF":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateJZ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddJZ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "RFCJ":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateRFCJ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddRFCJ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "DXCJ":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateDXCJ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddDXCJ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
                case "DSCJ":
                    if (objControl.Exists(mi_TYPE))
                    {
                        objControl.UpdateDSCJ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    else
                    {
                        objControl.AddDSCJ(o_KFB_BBKG);
                        this.ShowMsg("存儲成功");
                    }
                    break;
            }

        }
        catch (Exception ex)
        {
            this.WriteLog("用户名=" + this.mUserID + ex.ToString());
            ex.ToString();
            this.ShowMsg("存儲失敗");
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {

        KFB_BBKG o_KFB_BBKG = getKFB_BBKG();

        try
        {
            if (this.objControl.Exists(mi_TYPE))
            {
                this.objControl.UpdateZQ(o_KFB_BBKG);
            }
            else
            {
                this.objControl.AddZQ(o_KFB_BBKG);
            }
            this.ShowMsg("全部存儲成功");
        }
        catch (Exception ex)
        {
            this.WriteLog("用户名=" + this.mUserID + ex.ToString());
            ex.ToString();
            this.ShowMsg("全部存儲失敗");
        }
    }

    protected void btnJZModify_Click(object sender, EventArgs e)
    {


        KFB_BBKGJZ o_KFB_BBKGJZ = new KFB_BBKGJZ();
        getKFB_BBKGJZ(o_KFB_BBKGJZ);
        ArrayList arrLM = getArrList(this.drpLM);
        ArrayList arrCB = getArrList(this.drpCB);
        foreach (string strLM in arrLM)
        {
            o_KFB_BBKGJZ.N_LMNO = Convert.ToInt32(strLM);
            foreach (string strCB in arrCB)
            {
                o_KFB_BBKGJZ.N_CBXH = Convert.ToInt32(strCB);
                if (!this.objControl.Exists(mi_TYPE, Convert.ToInt32(strLM), Convert.ToInt32(strCB)))
                    objControl.Add(o_KFB_BBKGJZ);
                else
                    objControl.Update(o_KFB_BBKGJZ);
            }
        }
        this.ShowMsg("全部存儲成功");
    }

    protected void btnJZUpdate_Click(object sender, EventArgs e)
    {

        KFB_BBKGJZ o_KFB_BBKGJZ = new KFB_BBKGJZ();
        getKFB_BBKGJZ(o_KFB_BBKGJZ);
        ArrayList arrLM = getArrList(this.drpLM);
        ArrayList arrCB = getArrList(this.drpCB);
        foreach (string strLM in arrLM)
        {
            o_KFB_BBKGJZ.N_LMNO = Convert.ToInt32(strLM);
            foreach (string strCB in arrCB)
            {
                o_KFB_BBKGJZ.N_CBXH = Convert.ToInt32(strCB);
                if (!this.objControl.Exists(mi_TYPE, Convert.ToInt32(strLM), Convert.ToInt32(strCB)))
                    this.objControl.AddWF(o_KFB_BBKGJZ, (((Button)sender).CommandName));
                else
                    objControl.UpdateWF(o_KFB_BBKGJZ, (((Button)sender).CommandName));
            }
        }

        this.ShowMsg("存儲成功");
    }

    protected void drpLM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.drpLM.SelectedValue.Equals("0") && !this.drpCB.SelectedValue.Equals("0"))
        {

            KFB_BBKGJZ o_KFB_BBKGJZ = this.objControl.GetModel(mi_TYPE, Convert.ToInt32(this.drpLM.SelectedValue), Convert.ToInt32(this.drpCB.SelectedValue));
            setJZList(o_KFB_BBKGJZ);
        }
        else
        {
            setJZZero();
        }
    }

    protected void drpCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.drpLM.SelectedValue.Equals("0") && !this.drpCB.SelectedValue.Equals("0"))
        {

            KFB_BBKGJZ o_KFB_BBKGJZ = this.objControl.GetModel(mi_TYPE, Convert.ToInt32(this.drpLM.SelectedValue), Convert.ToInt32(this.drpCB.SelectedValue));
            setJZList(o_KFB_BBKGJZ);
        }
        else
        {
            setJZZero();
        }
    }
    #endregion

    #region 自定义事件
    private void setJZList(KFB_BBKGJZ o_KFB_BBKGJZ)
    {
        if (o_KFB_BBKGJZ != null)
        {
            this.txtRFJZRate.Text = o_KFB_BBKGJZ.N_J_RF.ToString().Equals("") ? "0" : o_KFB_BBKGJZ.N_J_RF.ToString();
            this.txtDXJZRate.Text = o_KFB_BBKGJZ.N_J_DX.ToString().Equals("") ? "0" : o_KFB_BBKGJZ.N_J_DX.ToString();
            this.txtDYJZRate.Text = o_KFB_BBKGJZ.N_J_DY.ToString().Equals("") ? "0" : o_KFB_BBKGJZ.N_J_DY.ToString();
            this.txtDSJZRate.Text = o_KFB_BBKGJZ.N_J_DS.ToString().Equals("") ? "0" : o_KFB_BBKGJZ.N_J_DS.ToString();
            this.txtZDRFJZRate.Text = o_KFB_BBKGJZ.N_J_ZDRF.ToString().Equals("") ? "0" : o_KFB_BBKGJZ.N_J_ZDRF.ToString();
            this.txtZDDXJZRate.Text = o_KFB_BBKGJZ.N_J_ZDDX.ToString().Equals("") ? "0" : o_KFB_BBKGJZ.N_J_ZDDX.ToString();
            //this.txtSYJZRate.Text = o_KFB_BBKGJZ.N_J_YSEY.ToString().Equals("") ? "0" : o_KFB_BBKGJZ.N_J_YSEY.ToString();
        }
        else
        {
            setJZZero();
        }
    }

    private void setJZZero()
    {
        this.txtRFJZRate.Text = "0";
        this.txtDXJZRate.Text = "0";
        this.txtDYJZRate.Text = "0";
        this.txtDSJZRate.Text = "0";
        this.txtZDRFJZRate.Text = "0";
        this.txtZDDXJZRate.Text = "0";
        //this.txtSYJZRate.Text = "0";
    }

    private KFB_BBKG getKFB_BBKG()
    {
        KFB_BBKG o_KFB_BBKG = new KFB_BBKG();
        o_KFB_BBKG.N_TYPE = mi_TYPE;
        o_KFB_BBKG.N_Z_RF = this.chkRFOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_DX = this.chkDXOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_DY = this.chkDYOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_DS = this.chkDSOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_ZDRF = this.chkZDRFOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_ZDDX = this.chkZDDXOpen.Checked ? 1 : 0;
        // o_KFB_BBKG.N_Z_YSEY = this.chkSYOpen.Checked ? 1 : 0;
        //o_KFB_BBKG.N_Z_BCDX = this.chkBCDXOpen.Checked ? 1 : 0;
        //o_KFB_BBKG.N_Z_BCDY = this.chkBCDYOpen.Checked ? 1 : 0;
        //o_KFB_BBKG.N_Z_BCRF = this.chkBCRFOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_BD = this.chkBDOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_RQS = this.chkRQSOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_BQC = this.chkBQCOpen.Checked ? 1 : 0;


        o_KFB_BBKG.N_Z_GG = this.chkGGOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_GJ = this.chkRFDXOpen.Checked ? 1 : 0;
        o_KFB_BBKG.N_Z_JZF = this.chkJZFOpen.Checked ? 1 : 0;

        o_KFB_BBKG.N_X_RF = Convert.ToSingle(this.txtRFTop.Text);
        o_KFB_BBKG.N_X_DX = Convert.ToSingle(this.txtDXTop.Text);
        o_KFB_BBKG.N_X_DY = Convert.ToSingle(this.txtDYTop.Text);
        o_KFB_BBKG.N_X_DS = Convert.ToSingle(this.txtDSTop.Text);
        o_KFB_BBKG.N_X_ZDRF = Convert.ToSingle(this.txtZDRFTop.Text);
        o_KFB_BBKG.N_X_ZDDX = Convert.ToSingle(this.txtZDDXTop.Text);
        o_KFB_BBKG.N_X_BCDX = Convert.ToSingle(this.txtBCDXTop.Text);
        o_KFB_BBKG.N_X_BCDY = Convert.ToSingle(this.txtBCDYTop.Text);
        o_KFB_BBKG.N_X_BCRF = Convert.ToSingle(this.txtBCRFTop.Text);
        o_KFB_BBKG.N_X_BD = Convert.ToSingle(this.txtBDTop.Text);
        o_KFB_BBKG.N_X_RQS = Convert.ToSingle(this.txtRQSTop.Text);
        o_KFB_BBKG.N_X_BQC = Convert.ToSingle(this.txtBQCXTop.Text);
        o_KFB_BBKG.N_X_GG = Convert.ToSingle(this.txtGGTop.Text);
        o_KFB_BBKG.N_X_GJ = Convert.ToSingle(this.txtRFDXTop.Text);

        o_KFB_BBKG.N_S_RF = Convert.ToSingle(this.txtRFDZ.Text);
        o_KFB_BBKG.N_S_DX = Convert.ToSingle(this.txtDXDZ.Text);
        o_KFB_BBKG.N_S_DY = Convert.ToSingle(this.txtDYDZ.Text);
        o_KFB_BBKG.N_S_DS = Convert.ToSingle(this.txtDSDZ.Text);
        o_KFB_BBKG.N_S_ZDRF = Convert.ToSingle(this.txtZDRFDZ.Text);
        o_KFB_BBKG.N_S_ZDDX = Convert.ToSingle(this.txtZDDXDZ.Text);
        o_KFB_BBKG.N_S_BCDX = Convert.ToSingle(this.txtBCDXDZ.Text);
        o_KFB_BBKG.N_S_BCDY = Convert.ToSingle(this.txtBCDYDZ.Text);
        o_KFB_BBKG.N_S_BCRF = Convert.ToSingle(this.txtBCRFDZ.Text);
        o_KFB_BBKG.N_S_BD = Convert.ToSingle(this.txtBDDZ.Text);
        o_KFB_BBKG.N_S_RQS = Convert.ToSingle(this.txtRQSDZ.Text);
        o_KFB_BBKG.N_S_BQC = Convert.ToSingle(this.txtBQCXDZ.Text);
        o_KFB_BBKG.N_S_GG = Convert.ToSingle(this.txtGGDZ.Text);
        o_KFB_BBKG.N_S_GJ = Convert.ToSingle(this.txtRFDXDZ.Text);

        o_KFB_BBKG.N_D_RF = Convert.ToSingle(this.txtRFSingle.Text);
        o_KFB_BBKG.N_D_DX = Convert.ToSingle(this.txtDXSingle.Text);
        o_KFB_BBKG.N_D_DY = Convert.ToSingle(this.txtDYSingle.Text);
        o_KFB_BBKG.N_D_DS = Convert.ToSingle(this.txtDSSingle.Text);
        o_KFB_BBKG.N_D_ZDRF = Convert.ToSingle(this.txtZDRFSingle.Text);
        o_KFB_BBKG.N_D_ZDDX = Convert.ToSingle(this.txtZDDXSingle.Text);
        // o_KFB_BBKG.N_D_YSEY = Convert.ToSingle(this.txtSYSingle.Text);
        o_KFB_BBKG.N_D_BCDX = Convert.ToSingle(this.txtBCDXSingle.Text);
        o_KFB_BBKG.N_D_BCDY = Convert.ToSingle(this.txtBCDYSingle.Text);
        o_KFB_BBKG.N_D_BCRF = Convert.ToSingle(this.txtBCRFSingle.Text);
        o_KFB_BBKG.N_D_BD = Convert.ToSingle(this.txtBDSingle.Text);
        o_KFB_BBKG.N_D_BQC = Convert.ToSingle(this.txtBQCSingle.Text);
        o_KFB_BBKG.N_D_RQS = Convert.ToSingle(this.txtRQSSingle.Text);



        // o_KFB_BBKG.N_D_BCRF = 0;
        // o_KFB_BBKG.N_D_BCDX = 0;
        // o_KFB_BBKG.N_D_BCDY = 0;
        o_KFB_BBKG.N_D_GG = 0;
        o_KFB_BBKG.N_D_GJ = 0;

        o_KFB_BBKG.N_J_RF = Convert.ToSingle(this.txtRFRate.Text);
        o_KFB_BBKG.N_J_DX = Convert.ToSingle(this.txtDXRate.Text);
        o_KFB_BBKG.N_J_DY = Convert.ToSingle(this.txtDYRate.Text);
        o_KFB_BBKG.N_J_DS = Convert.ToSingle(this.txtDSRate.Text);
        o_KFB_BBKG.N_J_ZDRF = Convert.ToSingle(this.txtZDRFRate.Text);
        o_KFB_BBKG.N_J_ZDDX = Convert.ToSingle(this.txtZDDXRate.Text);

        o_KFB_BBKG.N_J_SBCRF = Convert.ToSingle(this.txtBCRFRate.Text);
        o_KFB_BBKG.N_J_SBCDX = Convert.ToSingle(this.txtBCDXRate.Text);
        o_KFB_BBKG.N_J_SBCDY = Convert.ToSingle(this.txtBCDYRate.Text);

        o_KFB_BBKG.N_J_XBCRF = 0;
        o_KFB_BBKG.N_J_XBCDS = 0;
        o_KFB_BBKG.N_J_XBCDY = 0;



        o_KFB_BBKG.N_J_GG = 0;
        o_KFB_BBKG.N_J_GJ = 0;

        o_KFB_BBKG.N_BJGPRFCJ = Convert.ToSingle(this.txtRFCJ.Text);
        o_KFB_BBKG.N_BJGPDXCJ = Convert.ToSingle(this.txtDXCJ.Text);
        o_KFB_BBKG.N_BJGPDSCJ = Convert.ToSingle(this.txtDSCJ.Text);
        return o_KFB_BBKG;
    }

    /// <summary>
    /// 兩邊賠率加總控管(跟盤) 取得頁面欄位值
    /// </summary>
    /// <returns></returns>
    private void getKFB_BBKGJZ(KFB_BBKGJZ o_KFB_BBKGJZ)
    {
        o_KFB_BBKGJZ.N_TYPE = mi_TYPE;
        o_KFB_BBKGJZ.N_J_RF = Convert.ToSingle(this.txtRFJZRate.Text);
        o_KFB_BBKGJZ.N_J_DX = Convert.ToSingle(this.txtDXJZRate.Text);
        o_KFB_BBKGJZ.N_J_DY = Convert.ToSingle(this.txtDYJZRate.Text);
        o_KFB_BBKGJZ.N_J_DS = Convert.ToSingle(this.txtDSJZRate.Text);
        o_KFB_BBKGJZ.N_J_ZDRF = Convert.ToSingle(this.txtZDRFJZRate.Text);
        o_KFB_BBKGJZ.N_J_ZDDX = Convert.ToSingle(this.txtZDDXJZRate.Text);
        o_KFB_BBKGJZ.N_J_YSEY = Convert.ToSingle("0");
    }

    private ArrayList getArrList(DropDownList drpType)
    {
        ArrayList arr = new ArrayList();
        if (drpType.SelectedValue.Equals("0"))
        {
            foreach (ListItem list in drpType.Items)
            {
                arr.Add(list.Value);
            }
            arr.Remove("0");
        }
        else
            arr.Add(drpType.SelectedValue);
        return arr;
    }
    #endregion

}
