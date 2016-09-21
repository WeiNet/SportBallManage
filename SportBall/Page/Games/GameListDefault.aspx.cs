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

    public partial class GameListDefault : BasePage
    {
        #region 全局变量
        private string ms_TYPE = "";
        GamesDB objGamesDB = new GamesDB();
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
                    case "b_zq":
                        this.lblball.Text = "足球";
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
                    this.drpDXFS.Value = o_KFB_BSYS.N_DXFS.ToString();
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
                    this.txtLDYPL.Value = o_KFB_BSYS.N_LDYPL.ToString();
                    this.txtRDYPL.Value = o_KFB_BSYS.N_RDYPL.ToString();
                    this.drpLDYCJ.Value = o_KFB_BSYS.N_LDYCJ.ToString();
                    this.drpRDYCJ.Value = o_KFB_BSYS.N_RDYCJ.ToString();
                    this.txtLDYSX.Value = o_KFB_BSYS.N_LDYSX.ToString();
                    this.txtRDYSX.Value = o_KFB_BSYS.N_RDYSX.ToString();
                    this.txtDYCJ.Value = o_KFB_BSYS.N_DYCJ.ToString();
                    this.drpDYCJPL.Value = o_KFB_BSYS.N_DYCJPL.ToString();
                    //this.txtLSYPL.Value = o_KFB_BSYS.N_LSYPL.ToString();
                    //this.txtRSYPL.Value = o_KFB_BSYS.N_RSYPL.ToString();
                    //this.drpLSYCJ.Value = o_KFB_BSYS.N_LSYCJ.ToString();
                    //this.drpRSYCJ.Value = o_KFB_BSYS.N_RSYCJ.ToString();
                    //this.txtLSYSX.Value = o_KFB_BSYS.N_LSYSX.ToString();
                    //this.txtRSYSX.Value = o_KFB_BSYS.N_RSYSX.ToString();
                    //this.txtSYCJ.Value = o_KFB_BSYS.N_SYCJ.ToString();
                    //this.drpSYCJPL.Value = o_KFB_BSYS.N_SYCJPL.ToString();
                    this.txtDSDPL.Value = o_KFB_BSYS.N_DSDPL.ToString();
                    this.txtDSSPL.Value = o_KFB_BSYS.N_DSSPL.ToString();
                    this.drpDSDCJ.Value = o_KFB_BSYS.N_DSDCJ.ToString();
                    this.drpDSSCJ.Value = o_KFB_BSYS.N_DSSCJ.ToString();
                    this.txtLDSSX.Value = o_KFB_BSYS.N_LDSSX.ToString();
                    this.txtRDSSX.Value = o_KFB_BSYS.N_RDSSX.ToString();
                    this.txtDSCJ.Value = o_KFB_BSYS.N_DSCJ.ToString();
                    this.drpDSCJPL.Value = o_KFB_BSYS.N_DSCJPL.ToString();

                    this.txt00.Text = o_KFB_BSYS.N_BDGPL00.ToString();
                    this.txt11.Text = o_KFB_BSYS.N_BDGPL11.ToString();
                    this.txt22.Text = o_KFB_BSYS.N_BDGPL22.ToString();
                    this.txt33.Text = o_KFB_BSYS.N_BDGPL33.ToString();
                    this.txt44.Text = o_KFB_BSYS.N_BDGPL44.ToString();
                    this.txtkc10.Text = o_KFB_BSYS.N_BDKPL10.ToString();
                    this.txtkc20.Text = o_KFB_BSYS.N_BDKPL20.ToString();
                    this.txtkc21.Text = o_KFB_BSYS.N_BDKPL21.ToString();
                    this.txtkc30.Text = o_KFB_BSYS.N_BDKPL30.ToString();
                    this.txtkc31.Text = o_KFB_BSYS.N_BDKPL31.ToString();
                    this.txtkc32.Text = o_KFB_BSYS.N_BDKPL32.ToString();
                    this.txtkc40.Text = o_KFB_BSYS.N_BDKPL40.ToString();
                    this.txtkc41.Text = o_KFB_BSYS.N_BDKPL41.ToString();
                    this.txtkc42.Text = o_KFB_BSYS.N_BDKPL42.ToString();
                    this.txtkc43.Text = o_KFB_BSYS.N_BDKPL43.ToString();
                    this.txtkc5.Text = o_KFB_BSYS.N_BDKPL5.ToString();
                    this.txtbdsx.Text = o_KFB_BSYS.N_BDSX.ToString();
                    this.txtzc10.Text = o_KFB_BSYS.N_BDZPL10.ToString();
                    this.txtzc20.Text = o_KFB_BSYS.N_BDZPL20.ToString();
                    this.txtzc21.Text = o_KFB_BSYS.N_BDZPL21.ToString();
                    this.txtzc30.Text = o_KFB_BSYS.N_BDZPL30.ToString();
                    this.txtzc31.Text = o_KFB_BSYS.N_BDZPL31.ToString();
                    this.txtzc32.Text = o_KFB_BSYS.N_BDZPL32.ToString();
                    this.txtzc40.Text = o_KFB_BSYS.N_BDZPL40.ToString();
                    this.txtzc41.Text = o_KFB_BSYS.N_BDZPL41.ToString();
                    this.txtzc42.Text = o_KFB_BSYS.N_BDZPL42.ToString();
                    this.txtzc43.Text = o_KFB_BSYS.N_BDZPL43.ToString();
                    this.txtzc5.Text = o_KFB_BSYS.N_BDZPL5.ToString();

                    this.txtbqchh.Text = o_KFB_BSYS.N_BQCHH.ToString();
                    this.txtbqchk.Text = o_KFB_BSYS.N_BQCHK.ToString();
                    this.txtbqchz.Text = o_KFB_BSYS.N_BQCHZ.ToString();
                    this.txtbqckh.Text = o_KFB_BSYS.N_BQCKH.ToString();
                    this.txtbqckk.Text = o_KFB_BSYS.N_BQCKK.ToString();

                    this.txtbqckz.Text = o_KFB_BSYS.N_BQCKZ.ToString();
                    this.txtbqcsx.Text = o_KFB_BSYS.N_BQCSX.ToString();
                    this.txtbqczh.Text = o_KFB_BSYS.N_BQCZH.ToString();
                    this.txtbqczk.Text = o_KFB_BSYS.N_BQCZK.ToString();
                    this.txtbqczz.Text = o_KFB_BSYS.N_BQCZZ.ToString();
                    this.txtrqs01.Text = o_KFB_BSYS.N_RQSPL01.ToString();
                    this.txtrqs23.Text = o_KFB_BSYS.N_RQSPL23.ToString();
                    this.txtrqs46.Text = o_KFB_BSYS.N_RQSPL46.ToString();
                    this.txtrqs7.Text = o_KFB_BSYS.N_RQSPL7.ToString();
                    this.txtrqssx.Text = o_KFB_BSYS.N_RQSSX.ToString();
                    this.txtN_HJPL.Value = o_KFB_BSYS.N_HJPL.ToString();
                    this.txtN_HJGGCJ.Value = o_KFB_BSYS.N_HJGGCJ.ToString();
                    this.txtN_HJSX.Value = o_KFB_BSYS.N_HJSX.ToString();
                }
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Keys", "changefenshu(document.getElementById('drpRFCJFS'));", true);
        }
        #endregion

        #region 按钮事件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                KFB_BSYS o_KFB_BSYS = new KFB_BSYS();
                if (objGameDefaultDB.Exists(ms_TYPE))
                {
                    objGameDefaultDB.UpdateZQ(getKFB_BSYS());
                    this.ShowMsg( "修改成功");
                }
                else
                {
                    objGameDefaultDB.AddZQ(getKFB_BSYS());
                    this.ShowMsg("新增成功");
                }
            }
            catch (Exception ex)
            {
              this.WriteLog("用户名=" + this.mUserID+ex.ToString());
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
            o_KFB_BSYS.N_DXFS = Convert.ToSingle(this.drpDXFS.Value);
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

            o_KFB_BSYS.N_LSYPL = 0;
            o_KFB_BSYS.N_RSYPL = 0;
            o_KFB_BSYS.N_LSYCJ = 0;
            o_KFB_BSYS.N_RSYCJ = 0;
            o_KFB_BSYS.N_LSYSX = 0;
            o_KFB_BSYS.N_RSYSX = 0;
            o_KFB_BSYS.N_SYCJ = 0;
            o_KFB_BSYS.N_SYCJPL = 0;

            o_KFB_BSYS.N_DSDPL = Convert.ToSingle(this.txtDSDPL.Value);
            o_KFB_BSYS.N_DSSPL = Convert.ToSingle(this.txtDSSPL.Value);
            o_KFB_BSYS.N_DSDCJ = Convert.ToSingle(this.drpDSDCJ.Value);
            o_KFB_BSYS.N_DSSCJ = Convert.ToSingle(this.drpDSSCJ.Value);
            o_KFB_BSYS.N_DSDCSX = 0;
            o_KFB_BSYS.N_LDSSX = Convert.ToSingle(this.txtLDSSX.Value);
            o_KFB_BSYS.N_RDSSX = Convert.ToSingle(this.txtRDSSX.Value);
            o_KFB_BSYS.N_DSCJ = Convert.ToSingle(this.txtDSCJ.Value);
            o_KFB_BSYS.N_DSCJPL = Convert.ToSingle(this.drpDSCJPL.Value);

            o_KFB_BSYS.N_BDGPL00 = Convert.ToSingle(this.txt00.Text);
            o_KFB_BSYS.N_BDGPL11 = Convert.ToSingle(this.txt11.Text);
            o_KFB_BSYS.N_BDGPL22 = Convert.ToSingle(this.txt22.Text);
            o_KFB_BSYS.N_BDGPL33 = Convert.ToSingle(this.txt33.Text);
            o_KFB_BSYS.N_BDGPL44 = Convert.ToSingle(this.txt44.Text);
            o_KFB_BSYS.N_BDKPL10 = Convert.ToSingle(this.txtkc10.Text);
            o_KFB_BSYS.N_BDKPL20 = Convert.ToSingle(this.txtkc20.Text);
            o_KFB_BSYS.N_BDKPL21 = Convert.ToSingle(this.txtkc21.Text);
            o_KFB_BSYS.N_BDKPL30 = Convert.ToSingle(this.txtkc30.Text);
            o_KFB_BSYS.N_BDKPL31 = Convert.ToSingle(this.txtkc31.Text);
            o_KFB_BSYS.N_BDKPL32 = Convert.ToSingle(this.txtkc32.Text);
            o_KFB_BSYS.N_BDKPL40 = Convert.ToSingle(this.txtkc40.Text);
            o_KFB_BSYS.N_BDKPL41 = Convert.ToSingle(this.txtkc41.Text);
            o_KFB_BSYS.N_BDKPL42 = Convert.ToSingle(this.txtkc42.Text);
            o_KFB_BSYS.N_BDKPL43 = Convert.ToSingle(this.txtkc43.Text);
            o_KFB_BSYS.N_BDKPL5 = Convert.ToSingle(this.txtkc5.Text);
            o_KFB_BSYS.N_BDSX = Convert.ToSingle(this.txtbdsx.Text);
            o_KFB_BSYS.N_BDZPL10 = Convert.ToSingle(this.txtzc10.Text);
            o_KFB_BSYS.N_BDZPL20 = Convert.ToSingle(this.txtzc20.Text);
            o_KFB_BSYS.N_BDZPL21 = Convert.ToSingle(this.txtzc21.Text);
            o_KFB_BSYS.N_BDZPL30 = Convert.ToSingle(this.txtzc30.Text);
            o_KFB_BSYS.N_BDZPL31 = Convert.ToSingle(this.txtzc31.Text);
            o_KFB_BSYS.N_BDZPL32 = Convert.ToSingle(this.txtzc32.Text);
            o_KFB_BSYS.N_BDZPL40 = Convert.ToSingle(this.txtzc40.Text);
            o_KFB_BSYS.N_BDZPL41 = Convert.ToSingle(this.txtzc41.Text);
            o_KFB_BSYS.N_BDZPL42 = Convert.ToSingle(this.txtzc42.Text);
            o_KFB_BSYS.N_BDZPL43 = Convert.ToSingle(this.txtzc43.Text);
            o_KFB_BSYS.N_BDZPL5 = Convert.ToSingle(this.txtzc5.Text);

            o_KFB_BSYS.N_BQCHH = Convert.ToSingle(this.txtbqchh.Text);
            o_KFB_BSYS.N_BQCHK = Convert.ToSingle(this.txtbqchk.Text);
            o_KFB_BSYS.N_BQCHZ = Convert.ToSingle(this.txtbqchz.Text);
            o_KFB_BSYS.N_BQCKH = Convert.ToSingle(this.txtbqckh.Text);
            o_KFB_BSYS.N_BQCKK = Convert.ToSingle(this.txtbqckk.Text);

            o_KFB_BSYS.N_BQCKZ = Convert.ToSingle(this.txtbqckz.Text);
            o_KFB_BSYS.N_BQCSX = Convert.ToSingle(this.txtbqcsx.Text);
            o_KFB_BSYS.N_BQCZH = Convert.ToSingle(this.txtbqczh.Text);
            o_KFB_BSYS.N_BQCZK = Convert.ToSingle(this.txtbqczk.Text);
            o_KFB_BSYS.N_BQCZZ = Convert.ToSingle(this.txtbqczz.Text);
            o_KFB_BSYS.N_RQSPL01 = Convert.ToSingle(this.txtrqs01.Text);
            o_KFB_BSYS.N_RQSPL23 = Convert.ToSingle(this.txtrqs23.Text);
            o_KFB_BSYS.N_RQSPL46 = Convert.ToSingle(this.txtrqs46.Text);
            o_KFB_BSYS.N_RQSPL7 = Convert.ToSingle(this.txtrqs7.Text);
            o_KFB_BSYS.N_RQSSX = Convert.ToSingle(this.txtrqssx.Text);

            o_KFB_BSYS.N_DYSX = 0;
            o_KFB_BSYS.N_WZSX = 0;
            o_KFB_BSYS.N_LYSX = 0;
            o_KFB_BSYS.N_WZQSX = 0;

            o_KFB_BSYS.N_HJPL = Convert.ToSingle(this.txtN_HJPL.Value);
            o_KFB_BSYS.N_HJGGCJ = Convert.ToSingle(this.txtN_HJGGCJ.Value);
            o_KFB_BSYS.N_HJSX = Convert.ToSingle(this.txtN_HJSX.Value);

            return o_KFB_BSYS;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate1", "CountTotal('txtLRFPL','txtRRFPL','txtRFPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate2", "CountTotal('txtDXDPL','txtDXXPL','txtDXPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate3", "CountTotal('txtLDYPL','txtRDYPL','txtDYPLJZ');", true);
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate4", "CountTotal('txtLSYPL','txtRSYPL','txtSYPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate5", "CountTotal('txtDSDPL','txtDSSPL','txtDSPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate1", "ConRate(document.getElementById('drpRFLX'),document.getElementById('txtRFBL'));", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate2", "ConRate(document.getElementById('drpDXLX'),document.getElementById('txtDXBL'));", true);
        }
        #endregion

    }
