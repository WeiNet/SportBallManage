#region History
///程式代號：      GameListDefault
///程式名稱：      GameListDefault
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

    public partial class GameListOtherDefault : BasePage
    {
        #region 全局变量
        private string ms_TYPE = "";
        GamesDB objGamesDB = new GamesDB();
        GameOtherDefaultDB objGameOtherDefaultDB = new GameOtherDefaultDB();
        GameDefaultDB objGameDefaultDB = new GameDefaultDB();
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["bt"] != null)
            {
                ms_TYPE = Request.QueryString["bt"];
                switch (Request.QueryString["bt"])
                {
                    case "b_by":
                        this.lblball.Text = "网球";
                        break;
                    case "b_bj":
                        this.lblball.Text = "棒球";
                        break;
                    case "b_bk":
                        this.lblball.Text = "籃球";
                        break;
                    case "b_bb":
                        this.lblball.Text = "排球";
                        break;
                    case "b_bq":
                        this.lblball.Text = "冰球";
                        break;
                }
            }
            if (!IsPostBack)
            {

                KFB_BSYS o_KFB_BSYS = objGamesDB.GetModel(ms_TYPE);
                if (o_KFB_BSYS != null)
                {
                    if ((o_KFB_BSYS.N_CBXH.Value & 1) == 1)
                    {
                        this.chkCB.Items[0].Selected = true;
                    }
                    if ((o_KFB_BSYS.N_CBXH.Value & 2) == 2)
                    {
                        this.chkCB.Items[1].Selected = true;
                    }
                    if ((o_KFB_BSYS.N_CBXH.Value & 4) == 4)
                    {
                        this.chkCB.Items[2].Selected = true;
                    }
                    this.txtDZSX.Value = o_KFB_BSYS.N_HYDZSX.ToString();
                    this.txtDCSX.Value = o_KFB_BSYS.N_HYDCSX.ToString();
                    this.drpRFFS.Value = o_KFB_BSYS.N_RFFS.ToString();
                    this.drpRFLX.Value = o_KFB_BSYS.N_RFLX.ToString();
                    this.txtRFBL.Value = o_KFB_BSYS.N_RFBL.ToString();
                    this.txtLRFPL.Value = o_KFB_BSYS.N_LRFPL.ToString();
                    this.txtRRFPL.Value = o_KFB_BSYS.N_RRFPL.ToString();
                    this.drpLRFCJ.Value = o_KFB_BSYS.N_LRFCJ.ToString();
                    this.drpRRFCJ.Value = o_KFB_BSYS.N_RRFCJ.ToString();
                    this.txtLRFSX.Value = o_KFB_BSYS.N_LRFSX.ToString();
                    this.txtRRFSX.Value = o_KFB_BSYS.N_RRFSX.ToString();
                    this.txtRFCJJE.Value = o_KFB_BSYS.N_RFCJJE.ToString();
                    this.drpRFCJFS.Value = o_KFB_BSYS.N_RFCJFS.ToString();
                    if (o_KFB_BSYS.N_RFCJFS.Value.Equals(0))
                        this.drpRFCJPL.Value = o_KFB_BSYS.N_RFCJPL.ToString();
                    else
                        this.drpRFCJPL1.Value = o_KFB_BSYS.N_RFCJPL.ToString();
                    this.txtDXFS.Value = o_KFB_BSYS.N_DXFS.ToString();
                    this.drpDXLX.Value = o_KFB_BSYS.N_DXLX.ToString();
                    this.txtDXBL.Value = o_KFB_BSYS.N_DXBL.ToString();
                    this.txtDXDPL.Value = o_KFB_BSYS.N_DXDPL.ToString();
                    this.txtDXXPL.Value = o_KFB_BSYS.N_DXXPL.ToString();
                    this.drpDXDCJ.Value = o_KFB_BSYS.N_DXDCJ.ToString();
                    this.drpDXXCJ.Value = o_KFB_BSYS.N_DXXCJ.ToString();
                    this.txtLDXSX.Value = o_KFB_BSYS.N_LDXSX.ToString();
                    this.txtRDXSX.Value = o_KFB_BSYS.N_RDXSX.ToString();
                    this.txtDXCJ.Value = o_KFB_BSYS.N_DXCJ.ToString();
                    this.drpDXCJPL.Value = o_KFB_BSYS.N_DXCJPL.ToString();


                    this.txtLSYPL.Value = o_KFB_BSYS.N_LSYPL.ToString();
                    this.txtRSYPL.Value = o_KFB_BSYS.N_RSYPL.ToString();
                    this.drpLSYCJ.Value = o_KFB_BSYS.N_LSYCJ.ToString();
                    this.drpRSYCJ.Value = o_KFB_BSYS.N_RSYCJ.ToString();
                    this.txtLSYSX.Value = o_KFB_BSYS.N_LSYSX.ToString();
                    this.txtRSYSX.Value = o_KFB_BSYS.N_RSYSX.ToString();
                    this.txtSYCJ.Value = o_KFB_BSYS.N_SYCJ.ToString();
                    this.drpSYCJPL.Value = o_KFB_BSYS.N_SYCJPL.ToString();

                    this.txtLDYPL.Value = o_KFB_BSYS.N_LDYPL.ToString();
                    this.txtRDYPL.Value = o_KFB_BSYS.N_RDYPL.ToString();
                    this.drpLDYCJ.Value = o_KFB_BSYS.N_LDYCJ.ToString();
                    this.drpRDYCJ.Value = o_KFB_BSYS.N_RDYCJ.ToString();
                    this.txtLDYSX.Value = o_KFB_BSYS.N_LDYSX.ToString();
                    this.txtRDYSX.Value = o_KFB_BSYS.N_RDYSX.ToString();
                    this.txtDYCJ.Value = o_KFB_BSYS.N_DYCJ.ToString();
                    this.drpDYCJPL.Value = o_KFB_BSYS.N_DYCJPL.ToString();
                    this.txtDSDPL.Value = o_KFB_BSYS.N_DSDPL.ToString();
                    this.txtDSSPL.Value = o_KFB_BSYS.N_DSSPL.ToString();
                    this.drpDSDCJ.Value = o_KFB_BSYS.N_DSDCJ.ToString();
                    this.drpDSSCJ.Value = o_KFB_BSYS.N_DSSCJ.ToString();
                    this.txtLDSSX.Value = o_KFB_BSYS.N_LDSSX.ToString();
                    this.txtRDSSX.Value = o_KFB_BSYS.N_RDSSX.ToString();
                    this.txtDSCJ.Value = o_KFB_BSYS.N_DSCJ.ToString();
                    this.drpDSCJPL.Value = o_KFB_BSYS.N_DSCJPL.ToString();

                }
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Keys", "changefenshu(document.getElementById('ContentPlaceHolder11_drpRFCJFS'));", true);
        }
        #endregion

        #region 按钮事件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
              KFB_BSYS o_KFB_BSYS = new KFB_BSYS();
              if (objGameOtherDefaultDB.Exists(ms_TYPE))
                {
                    objGameOtherDefaultDB.UpdateBQ(getKFB_BSYS());
                   this.ShowMsg("修改成功");
                }
                else
                {
                    objGameOtherDefaultDB.AddBQ(getKFB_BSYS());
                   this.ShowMsg("新增成功");
                }
            }
            catch (Exception ex)
            {
               
                this.WriteLog("用户名=" + this.mUserID+ ex.ToString());
               this.ShowMsg("保存失敗");
            }
        }
        #endregion

        #region 自定义事件
        private KFB_BSYS getKFB_BSYS()
        {

            KFB_BSYS o_KFB_BSYS = new KFB_BSYS();

            o_KFB_BSYS.N_LX = ms_TYPE;
            //是否延遲下注
            int i_Count = 0;
            for (int i = 0; i < this.chkCB.Items.Count; i++)
            {
                if (chkCB.Items[i].Selected)
                {
                    i_Count += Convert.ToInt32(chkCB.Items[i].Value);
                }
            }
            o_KFB_BSYS.N_CBXH = i_Count;
            o_KFB_BSYS.N_HYDZSX = Convert.ToSingle(this.txtDZSX.Value);
            o_KFB_BSYS.N_HYDCSX = Convert.ToSingle(this.txtDCSX.Value);
            o_KFB_BSYS.N_RFFS = Convert.ToSingle(this.drpRFFS.Value);
            o_KFB_BSYS.N_RFLX = Convert.ToInt32(this.drpRFLX.Value);
            o_KFB_BSYS.N_RFBL = Convert.ToInt32(this.txtRFBL.Value);
            o_KFB_BSYS.N_LRFPL = Convert.ToSingle(this.txtLRFPL.Value);
            o_KFB_BSYS.N_RRFPL = Convert.ToSingle(this.txtRRFPL.Value);
            o_KFB_BSYS.N_LRFCJ = Convert.ToSingle(this.drpLRFCJ.Value);
            o_KFB_BSYS.N_RRFCJ = Convert.ToSingle(this.drpRRFCJ.Value);
            o_KFB_BSYS.N_LRFSX = Convert.ToSingle(this.txtLRFSX.Value);
            o_KFB_BSYS.N_RRFSX = Convert.ToSingle(this.txtRRFSX.Value);
            o_KFB_BSYS.N_RFCJJE = Convert.ToSingle(this.txtRFCJJE.Value);
            o_KFB_BSYS.N_RFCJFS = Convert.ToInt32(this.drpRFCJFS.Value);
            if (this.drpRFCJFS.Value.Equals("0"))
                o_KFB_BSYS.N_RFCJPL = Convert.ToSingle(this.drpRFCJPL.Value);
            else
                o_KFB_BSYS.N_RFCJPL = Convert.ToSingle(this.drpRFCJPL1.Value);
            o_KFB_BSYS.N_DXFS = Convert.ToSingle(this.txtDXFS.Value);
            o_KFB_BSYS.N_DXLX = Convert.ToInt32(this.drpDXLX.Value);
            o_KFB_BSYS.N_DXBL = Convert.ToInt32(this.txtDXBL.Value);
            o_KFB_BSYS.N_DXDPL = Convert.ToSingle(this.txtDXDPL.Value);
            o_KFB_BSYS.N_DXXPL = Convert.ToSingle(this.txtDXXPL.Value);
            o_KFB_BSYS.N_DXDCJ = Convert.ToSingle(this.drpDXDCJ.Value);
            o_KFB_BSYS.N_DXXCJ = Convert.ToSingle(this.drpDXXCJ.Value);
            o_KFB_BSYS.N_DXDCSX = 0;
            o_KFB_BSYS.N_LDXSX = Convert.ToSingle(this.txtLDXSX.Value);
            o_KFB_BSYS.N_RDXSX = Convert.ToSingle(this.txtRDXSX.Value);
            o_KFB_BSYS.N_DXCJ = Convert.ToSingle(this.txtDXCJ.Value);
            o_KFB_BSYS.N_DXCJPL = Convert.ToSingle(this.drpDXCJPL.Value);
            o_KFB_BSYS.N_LDYPL = Convert.ToSingle(this.txtLDYPL.Value);
            o_KFB_BSYS.N_RDYPL = Convert.ToSingle(this.txtRDYPL.Value);
            o_KFB_BSYS.N_LDYCJ = Convert.ToSingle(this.drpLDYCJ.Value);
            o_KFB_BSYS.N_RDYCJ = Convert.ToSingle(this.drpRDYCJ.Value);
            o_KFB_BSYS.N_LDYSX = Convert.ToSingle(this.txtLDYSX.Value);
            o_KFB_BSYS.N_RDYSX = Convert.ToSingle(this.txtRDYSX.Value);
            o_KFB_BSYS.N_DYCJ = Convert.ToSingle(this.txtDYCJ.Value);
            o_KFB_BSYS.N_DYCJPL = Convert.ToSingle(this.drpDYCJPL.Value);

            o_KFB_BSYS.N_LSYPL = Convert.ToSingle(this.txtLSYPL.Value);
            o_KFB_BSYS.N_RSYPL = Convert.ToSingle(this.txtRSYPL.Value);
            o_KFB_BSYS.N_LSYCJ = Convert.ToSingle(this.drpLSYCJ.Value);
            o_KFB_BSYS.N_RSYCJ = Convert.ToSingle(this.drpRSYCJ.Value);
            o_KFB_BSYS.N_LSYSX = Convert.ToSingle(this.txtLSYSX.Value);
            o_KFB_BSYS.N_RSYSX = Convert.ToSingle(this.txtRSYSX.Value);
            o_KFB_BSYS.N_SYCJ = Convert.ToSingle(this.txtSYCJ.Value);
            o_KFB_BSYS.N_SYCJPL = Convert.ToSingle(this.drpSYCJPL.Value);

            o_KFB_BSYS.N_DSDPL = Convert.ToSingle(this.txtDSDPL.Value);
            o_KFB_BSYS.N_DSSPL = Convert.ToSingle(this.txtDSSPL.Value);
            o_KFB_BSYS.N_DSDCJ = Convert.ToSingle(this.drpDSDCJ.Value);
            o_KFB_BSYS.N_DSSCJ = Convert.ToSingle(this.drpDSSCJ.Value);
            o_KFB_BSYS.N_DSDCSX = 0;
            o_KFB_BSYS.N_LDSSX = Convert.ToSingle(this.txtLDSSX.Value);
            o_KFB_BSYS.N_RDSSX = Convert.ToSingle(this.txtRDSSX.Value);
            o_KFB_BSYS.N_DSCJ = Convert.ToSingle(this.txtDSCJ.Value);
            o_KFB_BSYS.N_DSCJPL = Convert.ToSingle(this.drpDSCJPL.Value);
            return o_KFB_BSYS;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate1", "CountTotal('ContentPlaceHolder11_txtLRFPL','ContentPlaceHolder11_txtRRFPL','ContentPlaceHolder11_txtRFPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate2", "CountTotal('ContentPlaceHolder11_txtDXDPL','ContentPlaceHolder11_txtDXXPL','ContentPlaceHolder11_txtDXPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate3", "CountTotal('ContentPlaceHolder11_txtLDYPL','ContentPlaceHolder11_txtRDYPL','ContentPlaceHolder11_txtDYPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate4", "CountTotal('ContentPlaceHolder11_txtLSYPL','ContentPlaceHolder11_txtRSYPL','ContentPlaceHolder11_txtSYPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate5", "CountTotal('ContentPlaceHolder11_txtDSDPL','ContentPlaceHolder11_txtDSSPL','ContentPlaceHolder11_txtDSPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate1", "ConRate(document.getElementById('ContentPlaceHolder11_drpRFLX'),document.getElementById('ContentPlaceHolder11_txtRFBL'));", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate2", "ConRate(document.getElementById('ContentPlaceHolder11_drpDXLX'),document.getElementById('ContentPlaceHolder11_txtDXBL'));", true);
        }
        #endregion

    }
