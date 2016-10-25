#region Histroy
///程式代號：      GamesSet
///程式名稱：      GameDetail
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


public partial class GameListEdit : BasePage
{
    #region 全局变量
    private Hashtable mo_Ht = new Hashtable();
    private GamesDB objGame = new GamesDB();
    private string ms_TYPE = "b_bj";
    private int mi_TYPE = -1;
    #endregion
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request["bt"] != null)
        {
            ms_TYPE = Request["bt"];
            switch (Request["bt"])
            {

                case "b_zq":
                    this.lblball.Text = "足球";
                    mi_TYPE = 4;
                    break;
            }
        }
        if (!IsPostBack)
        {
            this.drpLM.DataSource = objGame.GetLeagueList(mi_TYPE);
            this.drpLM.DataTextField = "N_LMMC";
            this.drpLM.DataValueField = "N_NO";
            this.drpLM.DataBind();
            this.drpLM.Items.Insert(0, new ListItem("請選擇聯盟", "-1"));


            this.drpZBName.DataSource = objGame.GetZB();
            this.drpZBName.DataTextField = "N_ZBMC";
            this.drpZBName.DataValueField = "N_ID";
            this.drpZBName.DataBind();
            this.drpZBName.Items.Insert(0, new ListItem("請選擇直播名稱", "-1"));
            if (Request["id"] != null)//修改
            {
                this.hidMode.Value = "Modify";
                this.hidN_ID.Value = Request["id"].ToString();
                InitUpdatePage();
            }
            else//新增
            {
                InitInsertPage();
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

            if (this.hidMode.Value.Equals("Modify"))
            {
                if (this.objGame.Exists(Convert.ToInt32(this.hidN_ID.Value)))
                {
                    this.objGame.UpdateZQ(GetKFB_BASEBALL(this.rdoCB.SelectedValue), mo_Ht);
                    this.objGame.SetTran(mo_Ht);
                    this.ShowMsg("修改成功");
                    this.WriteLog("用户名=" + mUserID + "；操作=修改" + this.lblball.Text + "比赛");
                    btnBack_Click(sender, e);
                }
                else
                {
                    ShowMsg("該比賽已經刪除");
                }
            }
            else
            {
                hidTeam.Value = "team" + Request.Form["drpVisit"] + Request.Form["drpHome"] + DateTime.Now.Millisecond.ToString();
                for (int i = 0; i < this.chkCB.Items.Count; i++)
                {
                    if (this.chkCB.Items[i].Selected)
                        this.objGame.AddZQ(GetKFB_BASEBALL(this.chkCB.Items[i].Value), mo_Ht);

                }
                this.objGame.SetTran(mo_Ht);
                this.ShowMsg("新增成功");
                this.WriteLog("用户名=" + mUserID + "；操作=新增" + this.lblball.Text + "比赛");
                this.hidMode.Value = "Add";
            }
        }
        catch (Exception ex)
        {
            this.WriteLog("用户名=" + mUserID + ex.ToString());
            this.ShowMsg("存儲失败！");
        }
        finally
        {
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (this.hidMode.Value.Equals("Add"))
        {
            //Comm.ClearControlsContent(this.Page, "form1");
            InitInsertPage();
            this.rdoZD.SelectedValue = "1";
            this.txtVisitJZF.Text = "0";
            this.txtHomeJZF.Text = "0";
            this.rdoOpenJZF.SelectedValue = "0";
            this.rdoVisit.Checked = false;
            this.rdoHome.Checked = true;
            this.rdoHj.Checked = false;
            this.hidVisit.Value = "-1";
            this.hidHome.Value = "-1";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate1", "ConRate(document.getElementById('ContentPlaceHolder11_drpRFLX'),document.getElementById('ContentPlaceHolder11_txtRFBL'));", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate2", "ConRate(document.getElementById('ContentPlaceHolder11_drpDXLX'),document.getElementById('ContentPlaceHolder11_txtDXBL'));", true);
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "LM", "$('#ContentPlaceHolder11_drpLM').val($('#ContentPlaceHolder11_hidLM').val());getTeamList($('#ContentPlaceHolder11_drpLM').get(0),true);$('#ContentPlaceHolder11_drpLM').attr('disabled',true);", true);
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Modify", "document.getElementById('drpLM').disabled = true;document.getElementById('drpVisit').disabled = true;document.getElementById('drpHome').disabled = true;", true);
        }
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate1", "CountTotal('ContentPlaceHolder11_txtLRFPL','ContentPlaceHolder11_txtRRFPL','ContentPlaceHolder11_txtRFPLJZ');", true);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate2", "CountTotal('ContentPlaceHolder11_txtDXDPL','ContentPlaceHolder11_txtDXXPL','ContentPlaceHolder11_txtDXPLJZ');", true);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate3", "CountTotal('ContentPlaceHolder11_txtLDYPL','ContentPlaceHolder11_txtRDYPL','ContentPlaceHolder11_txtDYPLJZ');", true);
        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate4", "CountTotal('txtLSYPL','txtRSYPL','txtSYPLJZ');", true);
        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate5", "CountTotal('txtDSDPL','txtDSSPL','txtDSPLJZ');", true);
        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "LM", "document.getElementById('drpLM').value=document.getElementById('hidLM').value;getTeamList(document.getElementById('drpLM'));document.getElementById('drpVisit').value=document.getElementById('hidVisit').value;document.getElementById('drpHome').value=document.getElementById('hidHome').value;", true);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Context.Items.Add("CBXH", this.ViewState["CBXH"]);
        this.Context.Items.Add("SFXZ", this.ViewState["SFXZ"]);
        this.Context.Items.Add("PAGE", this.ViewState["PAGE"]);
        this.Context.Items.Add("LMNO", this.ViewState["LMNO"]);
        this.Context.Items.Add("ZWRQ", this.ViewState["ZWRQ"]);
        this.Context.Items.Add("BSSJ", this.ViewState["BSSJ"]);
        this.Context.Items.Add("LEAGUE", this.ViewState["LEAGUE"]);
        this.Context.Items.Add("DATE", this.ViewState["DATE"]);
        this.Context.Items.Add("CurrPage", this.ViewState["CurrPage"]);
        if (Request.QueryString["TYPE"] != null)
        {
            if (Request.QueryString["TYPE"].Equals("DS"))
                Server.Transfer("football_dsgame.aspx");
            else if (Request.QueryString["TYPE"].Equals("ZD"))
                Server.Transfer("football_zdgame.aspx");
            else if (Request.QueryString["TYPE"].Equals("KS"))
                Server.Transfer("football_begingame.aspx");
            else if (Request.QueryString["TYPE"].Equals("ZC"))
                Server.Transfer("football_zcgame.aspx");
        }
    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {
            GameCalculationDB o_KFB_BASEBALL_BLL = new GameCalculationDB();
            KFB_BASEBALL o_KFB_BASEBALL = o_KFB_BASEBALL_BLL.GetModel(Convert.ToInt32(this.hidN_ID.Value));
            this.objGame.AddZQ(o_KFB_BASEBALL, mo_Ht);
            this.objGame.SetTran(mo_Ht);
            this.ShowMsg("複製成功");
        }
        catch (Exception ex)
        {
            this.WriteLog("用户名=" + mUserID + ex.ToString());

            this.ShowMsg("複製失敗");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            if (this.objGame.ExistsZD(Convert.ToInt32(this.hidN_ID.Value)))
            {
                ShowMsg("該賽事已有注單，不可以刪除");
            }
            else
            {
                this.objGame.Delete(Convert.ToInt32(this.hidN_ID.Value));
                ShowMsg("刪除成功");
                btnBack_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            this.WriteLog("用户名=" + this.mUserID + ex.ToString());

            this.ShowMsg("刪除失敗");
        }
    }
    #endregion

    #region 自定义事件
    private void InitUpdatePage()
    {
        GameCalculationDB o_KFB_BASEBALL_BLL = new GameCalculationDB();
        #region 修改狀態下
        KFB_BASEBALL o_KFB_BASEBALL = o_KFB_BASEBALL_BLL.GetModel(Convert.ToInt32(Request.QueryString["id"]));
        this.rdoCB.Visible = true;
        this.chkCB.Visible = false;
        this.trJZF.Visible = true;
        this.chkLet.Disabled = false;
        this.btnBack.Visible = true;
        this.btnCopy.Visible = true;
        this.btnDelete.Visible = true;
        this.chkLet.Checked = o_KFB_BASEBALL.N_LET.Value.Equals(1) ? true : false;
        this.chkLet.Value = o_KFB_BASEBALL.N_LET.ToString();
        this.drpZBName.SelectedValue = o_KFB_BASEBALL.N_ZBXH.ToString();
        this.ViewState.Add("CBXH", this.Context.Items["CBXH"]);
        this.ViewState.Add("SFXZ", this.Context.Items["SFXZ"]);
        this.ViewState.Add("PAGE", this.Context.Items["PAGE"]);
        this.ViewState.Add("LMNO", this.Context.Items["LMNO"]);
        this.ViewState.Add("ZWRQ", this.Context.Items["ZWRQ"]);
        this.ViewState.Add("BSSJ", this.Context.Items["BSSJ"]);
        this.ViewState.Add("LEAGUE", this.Context.Items["LEAGUE"]);
        this.ViewState.Add("DATE", this.Context.Items["DATE"]);
        this.ViewState.Add("CurrPage", this.Context.Items["CurrPage"]);
        this.drpZWYear.Value = o_KFB_BASEBALL.N_ZWDATE.Value.Year.ToString();
        this.drpZWMonth.Value = o_KFB_BASEBALL.N_ZWDATE.Value.Month.ToString().PadLeft(2, '0');
        this.drpZWDay.Value = o_KFB_BASEBALL.N_ZWDATE.Value.Day.ToString().PadLeft(2, '0');
        this.drpBSYear.Value = o_KFB_BASEBALL.N_GAMEDATE.Value.Year.ToString();
        this.drpBSMonth.Value = o_KFB_BASEBALL.N_GAMEDATE.Value.Month.ToString().PadLeft(2, '0');
        this.drpBSDay.Value = o_KFB_BASEBALL.N_GAMEDATE.Value.Day.ToString().PadLeft(2, '0');
        this.drpBSHour.Value = o_KFB_BASEBALL.N_GAMEDATE.Value.Hour.ToString().PadLeft(2, '0');
        this.drpBSMinute.Value = o_KFB_BASEBALL.N_GAMEDATE.Value.Minute.ToString().PadLeft(2, '0');
        this.rdoCB.SelectedValue = o_KFB_BASEBALL.N_CBXH.ToString();
        if (o_KFB_BASEBALL.N_SFZD.Equals(2))
        {
            this.rdoZD.Items.Add(new ListItem("滾球中", "2"));
            this.rdoZD.SelectedValue = "2";
        }
        else
        {
            this.rdoZD.SelectedValue = o_KFB_BASEBALL.N_SFZD.ToString();
        }
        this.hidLM.Value = o_KFB_BASEBALL.N_LMNO.ToString();
        this.rdoOpenJZF.SelectedValue = o_KFB_BASEBALL.N_SFJZF.ToString();
        this.txtVisitJZF.Text = o_KFB_BASEBALL.N_VISIT_JZF.ToString();
        this.txtHomeJZF.Text = o_KFB_BASEBALL.N_HOME_JZF.ToString();
        this.hidVisit.Value = o_KFB_BASEBALL.N_VISIT.ToString();
        this.hidHome.Value = o_KFB_BASEBALL.N_HOME.ToString();
        if (o_KFB_BASEBALL.N_VH.Value.Equals(o_KFB_BASEBALL.N_VISIT))
            this.rdoVisit.Checked = true;
        else if (o_KFB_BASEBALL.N_VH.Value.Equals(o_KFB_BASEBALL.N_HOME))
            this.rdoHome.Checked = true;
        else
            this.rdoHj.Checked = true;
        this.txtVisitNo.Text = o_KFB_BASEBALL.N_VISIT_NO.ToString();
        this.txtHomeNo.Text = o_KFB_BASEBALL.N_HOME_NO.ToString();
        this.txtVisitTSNo.Text = o_KFB_BASEBALL.N_TSA.ToString();
        this.txtHomeTSNo.Text = o_KFB_BASEBALL.N_TSB.ToString();
        this.txtDZSX.Text = o_KFB_BASEBALL.N_HYDZSX.ToString();
        this.txtDCSX.Text = o_KFB_BASEBALL.N_HYDCSX.ToString();

        this.drpRFFS.Value = o_KFB_BASEBALL.N_RFFS.ToString();
        this.drpRFLX.Value = o_KFB_BASEBALL.N_RFLX.ToString();
        this.txtRFBL.Value = o_KFB_BASEBALL.N_RFBL.ToString();
        this.txtLRFPL.Value = o_KFB_BASEBALL.N_LRFPL.ToString();
        this.txtRRFPL.Value = o_KFB_BASEBALL.N_RRFPL.ToString();
        this.drpLRFCJ.Value = o_KFB_BASEBALL.N_LRFCJ.ToString();
        this.drpRRFCJ.Value = o_KFB_BASEBALL.N_RRFCJ.ToString();
        this.txtLRFSX.Value = o_KFB_BASEBALL.N_LRFSX.ToString();
        this.txtRRFSX.Value = o_KFB_BASEBALL.N_RRFSX.ToString();
        this.txtRFCJJE.Value = o_KFB_BASEBALL.N_RFCJJE.ToString();
        this.drpRFCJFS.Value = o_KFB_BASEBALL.N_RFCJFS.ToString();
        if (o_KFB_BASEBALL.N_RFCJFS.Value.Equals(0))
            this.drpRFCJPL.Value = o_KFB_BASEBALL.N_RFCJPL.ToString();
        else
            this.drpRFCJPL1.Value = o_KFB_BASEBALL.N_RFCJPL.ToString();

        this.drpDXFS.Value = o_KFB_BASEBALL.N_DXFS.ToString();
        this.drpDXLX.Value = o_KFB_BASEBALL.N_DXLX.ToString();
        this.txtDXBL.Value = o_KFB_BASEBALL.N_DXBL.ToString();
        this.txtDXDPL.Value = o_KFB_BASEBALL.N_DXDPL.ToString();
        this.txtDXXPL.Value = o_KFB_BASEBALL.N_DXXPL.ToString();
        this.drpDXDCJ.Value = o_KFB_BASEBALL.N_DXDCJ.ToString();
        this.drpDXXCJ.Value = o_KFB_BASEBALL.N_DXXCJ.ToString();
        this.txtLDXSX.Value = o_KFB_BASEBALL.N_LDXSX.ToString();
        this.txtRDXSX.Value = o_KFB_BASEBALL.N_RDXSX.ToString();
        this.txtDXCJ.Value = o_KFB_BASEBALL.N_DXCJ.ToString();
        this.drpDXCJPL.Value = o_KFB_BASEBALL.N_DXCJPL.ToString();

        //if(this.chkLet.Checked)
        this.txtLDYPL.Value = o_KFB_BASEBALL.N_LDYPL.ToString();
        this.txtRDYPL.Value = o_KFB_BASEBALL.N_RDYPL.ToString();
        this.drpLDYCJ.Value = o_KFB_BASEBALL.N_LDYCJ.ToString();
        this.drpRDYCJ.Value = o_KFB_BASEBALL.N_RDYCJ.ToString();
        this.txtLDYSX.Value = o_KFB_BASEBALL.N_LDYSX.ToString();
        this.txtRDYSX.Value = o_KFB_BASEBALL.N_RDYSX.ToString();
        this.txtDYCJ.Value = o_KFB_BASEBALL.N_DYCJ.ToString();
        this.drpDYCJPL.Value = o_KFB_BASEBALL.N_DYCJPL.ToString();

        //this.txtLSYPL.Value = o_KFB_BASEBALL.N_LSYPL.ToString();
        //this.txtRSYPL.Value = o_KFB_BASEBALL.N_RSYPL.ToString();
        //this.drpLSYCJ.Value = o_KFB_BASEBALL.N_LSYCJ.ToString();
        //this.drpRSYCJ.Value = o_KFB_BASEBALL.N_RSYCJ.ToString();
        //this.txtLSYSX.Value = o_KFB_BASEBALL.N_LSYSX.ToString();
        //this.txtRSYSX.Value = o_KFB_BASEBALL.N_RSYSX.ToString();
        //this.txtSYCJ.Value = o_KFB_BASEBALL.N_SYCJ.ToString();
        //this.drpSYCJPL.Value = o_KFB_BASEBALL.N_SYCJPL.ToString();

        this.txtDSDPL.Value = o_KFB_BASEBALL.N_DSDPL.ToString();
        this.txtDSSPL.Value = o_KFB_BASEBALL.N_DSSPL.ToString();
        this.drpDSDCJ.Value = o_KFB_BASEBALL.N_DSDCJ.ToString();
        this.drpDSSCJ.Value = o_KFB_BASEBALL.N_DSSCJ.ToString();
        this.txtLDSSX.Value = o_KFB_BASEBALL.N_LDSSX.ToString();
        this.txtRDSSX.Value = o_KFB_BASEBALL.N_RDSSX.ToString();
        this.txtDSCJ.Value = o_KFB_BASEBALL.N_DSCJ.ToString();
        this.drpDSCJPL.Value = o_KFB_BASEBALL.N_DSCJPL.ToString();

        this.chkRFClose.Checked = o_KFB_BASEBALL.N_RF_OPEN.Value.Equals(1) ? true : false;
        this.chkDXClose.Checked = o_KFB_BASEBALL.N_DX_OPEN.Value.Equals(1) ? true : false;
        this.chkDYClose.Checked = o_KFB_BASEBALL.N_DY_OPEN.Value.Equals(1) ? true : false;
        //this.chkSYClose.Checked = o_KFB_BASEBALL.N_SY_OPEN.Value.Equals(1) ? true : false;
        this.chkDSClose.Checked = o_KFB_BASEBALL.N_DS_OPEN.Value.Equals(1) ? true : false;

        this.chkRQClose.Checked = o_KFB_BASEBALL.N_RQ_OPEN.Value.Equals(1) ? true : false;
        this.chkBDClose.Checked = o_KFB_BASEBALL.N_BD_OPEN.Value.Equals(1) ? true : false;
        this.chkBQCClose.Checked = o_KFB_BASEBALL.N_BQC_OPEN.Value.Equals(1) ? true : false;

        this.chkRFGGClose.Checked = o_KFB_BASEBALL.N_RF_GG.Value.Equals(1) ? true : false;
        this.chkDXGGClose.Checked = o_KFB_BASEBALL.N_DX_GG.Value.Equals(1) ? true : false;
        this.chkDYGGClose.Checked = o_KFB_BASEBALL.N_DY_GG.Value.Equals(1) ? true : false;
        //this.chkSYGGClose.Checked = o_KFB_BASEBALL.N_SY_GG.Value.Equals(1) ? true : false;
        this.chkDSGGClose.Checked = o_KFB_BASEBALL.N_DS_GG.Value.Equals(1) ? true : false;


        this.txt00.Text = o_KFB_BASEBALL.N_BDGPL00.ToString();
        this.txt11.Text = o_KFB_BASEBALL.N_BDGPL11.ToString();
        this.txt22.Text = o_KFB_BASEBALL.N_BDGPL22.ToString();
        this.txt33.Text = o_KFB_BASEBALL.N_BDGPL33.ToString();
        this.txt44.Text = o_KFB_BASEBALL.N_BDGPL44.ToString();
        this.txtkc10.Text = o_KFB_BASEBALL.N_BDKPL10.ToString();
        this.txtkc20.Text = o_KFB_BASEBALL.N_BDKPL20.ToString();
        this.txtkc21.Text = o_KFB_BASEBALL.N_BDKPL21.ToString();
        this.txtkc30.Text = o_KFB_BASEBALL.N_BDKPL30.ToString();
        this.txtkc31.Text = o_KFB_BASEBALL.N_BDKPL31.ToString();
        this.txtkc32.Text = o_KFB_BASEBALL.N_BDKPL32.ToString();
        this.txtkc40.Text = o_KFB_BASEBALL.N_BDKPL40.ToString();
        this.txtkc41.Text = o_KFB_BASEBALL.N_BDKPL41.ToString();
        this.txtkc42.Text = o_KFB_BASEBALL.N_BDKPL42.ToString();
        this.txtkc43.Text = o_KFB_BASEBALL.N_BDKPL43.ToString();
        this.txtkc5.Text = o_KFB_BASEBALL.N_BDKPL5.ToString();
        this.txtbdsx.Text = o_KFB_BASEBALL.N_BDSX.ToString();
        this.txtzc10.Text = o_KFB_BASEBALL.N_BDZPL10.ToString();
        this.txtzc20.Text = o_KFB_BASEBALL.N_BDZPL20.ToString();
        this.txtzc21.Text = o_KFB_BASEBALL.N_BDZPL21.ToString();
        this.txtzc30.Text = o_KFB_BASEBALL.N_BDZPL30.ToString();
        this.txtzc31.Text = o_KFB_BASEBALL.N_BDZPL31.ToString();
        this.txtzc32.Text = o_KFB_BASEBALL.N_BDZPL32.ToString();
        this.txtzc40.Text = o_KFB_BASEBALL.N_BDZPL40.ToString();
        this.txtzc41.Text = o_KFB_BASEBALL.N_BDZPL41.ToString();
        this.txtzc42.Text = o_KFB_BASEBALL.N_BDZPL42.ToString();
        this.txtzc43.Text = o_KFB_BASEBALL.N_BDZPL43.ToString();
        this.txtzc5.Text = o_KFB_BASEBALL.N_BDZPL5.ToString();

        this.txtbqchh.Text = o_KFB_BASEBALL.N_BQCHH.ToString();
        this.txtbqchk.Text = o_KFB_BASEBALL.N_BQCHK.ToString();
        this.txtbqchz.Text = o_KFB_BASEBALL.N_BQCHZ.ToString();
        this.txtbqckh.Text = o_KFB_BASEBALL.N_BQCKH.ToString();
        this.txtbqckk.Text = o_KFB_BASEBALL.N_BQCKK.ToString();

        this.txtbqckz.Text = o_KFB_BASEBALL.N_BQCKZ.ToString();
        this.txtbqcsx.Text = o_KFB_BASEBALL.N_BQCSX.ToString();
        this.txtbqczh.Text = o_KFB_BASEBALL.N_BQCZH.ToString();
        this.txtbqczk.Text = o_KFB_BASEBALL.N_BQCZK.ToString();
        this.txtbqczz.Text = o_KFB_BASEBALL.N_BQCZZ.ToString();
        this.txtrqs01.Text = o_KFB_BASEBALL.N_RQSPL01.ToString();
        this.txtrqs23.Text = o_KFB_BASEBALL.N_RQSPL23.ToString();
        this.txtrqs46.Text = o_KFB_BASEBALL.N_RQSPL46.ToString();
        this.txtrqs7.Text = o_KFB_BASEBALL.N_RQSPL7.ToString();
        this.txtrqssx.Text = o_KFB_BASEBALL.N_RQSSX.ToString();
        this.txtN_HJPL.Value = o_KFB_BASEBALL.N_HJPL.ToString();
        this.drpN_HJGGCJ.Value = o_KFB_BASEBALL.N_HJGGCJ.ToString();
        this.txtN_HJSX.Value = o_KFB_BASEBALL.N_HJSX.ToString();
        #endregion
    }

    private void InitInsertPage()
    {

        #region 新增狀態下帶出默認值
        DateTime dt = this.objGame.GetZWDate();
        this.drpZWYear.Value = dt.Year.ToString();
        this.drpZWMonth.Value = dt.Month.ToString().PadLeft(2, '0');
        this.drpZWDay.Value = dt.Day.ToString().PadLeft(2, '0');
        this.drpBSYear.Value = DateTime.Now.Year.ToString();
        this.drpBSMonth.Value = DateTime.Now.Month.ToString().PadLeft(2, '0');
        this.drpBSDay.Value = DateTime.Now.Day.ToString().PadLeft(2, '0');
        this.drpBSHour.Value = DateTime.Now.Hour.ToString().PadLeft(2, '0');
        this.drpBSMinute.Value = DateTime.Now.Minute.ToString().PadLeft(2, '0');
        this.chkLet.Value = "0";

        KFB_BSYS o_KFB_BSYS = this.objGame.GetModel(ms_TYPE);
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

            this.chkDSClose.Checked = true;
            this.chkDXClose.Checked = true;
            this.chkDYClose.Checked = true;
            this.chkRFClose.Checked = true;
            //this.chkSYClose.Checked = true;
            this.txtDZSX.Text = o_KFB_BSYS.N_HYDZSX.ToString();
            this.txtDCSX.Text = o_KFB_BSYS.N_HYDCSX.ToString();
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

            this.chkRFGGClose.Checked = true;
            this.chkDXGGClose.Checked = true;
            this.chkDYGGClose.Checked = true;
            //this.chkSYGGClose.Checked = true;
            this.chkDSGGClose.Checked = true;

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
            this.drpN_HJGGCJ.Value = o_KFB_BSYS.N_HJGGCJ.ToString();
            this.txtN_HJSX.Value = o_KFB_BSYS.N_HJSX.ToString();
        }
        #endregion
    }

    private KFB_BASEBALL GetKFB_BASEBALL(string s_aCBXH)
    {
        KFB_BASEBALL mo_KFB_BASEBALL = new KFB_BASEBALL();
        mo_KFB_BASEBALL.N_RF_LOCK_V = 0;
        mo_KFB_BASEBALL.N_RF_LOCK_H = 0;
        mo_KFB_BASEBALL.N_DX_LOCK_V = 0;
        mo_KFB_BASEBALL.N_DX_LOCK_H = 0;
        mo_KFB_BASEBALL.N_DY_LOCK_V = 0;
        mo_KFB_BASEBALL.N_DY_LOCK_H = 0;
        mo_KFB_BASEBALL.N_SY_LOCK_V = 0;
        mo_KFB_BASEBALL.N_SY_LOCK_H = 0;
        mo_KFB_BASEBALL.N_DS_LOCK_V = 0;
        mo_KFB_BASEBALL.N_DS_LOCK_H = 0;
        mo_KFB_BASEBALL.N_VISIT_RESULT = 0;
        mo_KFB_BASEBALL.N_HOME_RESULT = 0;
        mo_KFB_BASEBALL.N_REMARK = "";
        mo_KFB_BASEBALL.N_SF9J = 0;//0:打滿九局 1:未滿九局
        mo_KFB_BASEBALL.N_SFDS = 0;//新比賽是否移至單式0:否 1:是
        mo_KFB_BASEBALL.N_SFGP = 0;//0:不跟盤 1:跟盤
        mo_KFB_BASEBALL.N_UP_VISIT_RESULT = 0;//上半場客隊結果比賽結果
        mo_KFB_BASEBALL.N_UP_HOME_RESULT = 0;//上半場主隊結果比賽結果
        mo_KFB_BASEBALL.N_SFXZ = 0;//會員是否下注,0:關閉會員下注 1:開放會員下注(走地) 2:開放會員下注(單式)
        mo_KFB_BASEBALL.N_XZZT = 0;//0:移至未開賽(單式or走地) 1:移至已開賽
        mo_KFB_BASEBALL.N_LOCK = 0;//0:不鎖定 1:強制鎖定
        mo_KFB_BASEBALL.N_SAMETEAM = hidTeam.Value;
        GameCalculationDB o_KFB_BASEBALL_BLL = new GameCalculationDB();
        if (this.hidMode.Value.Equals("Modify"))
        {

            mo_KFB_BASEBALL = o_KFB_BASEBALL_BLL.GetModel(Convert.ToInt32(this.hidN_ID.Value));
        }
        if (!this.hidN_ID.Value.Equals("-1"))
        {
            mo_KFB_BASEBALL.N_ID = Convert.ToInt32(this.hidN_ID.Value);
        }
        else
        {
            mo_KFB_BASEBALL.N_ID = Convert.ToInt32(Comm.GetNO());
        }
        mo_KFB_BASEBALL.N_LX = ms_TYPE;
        mo_KFB_BASEBALL.N_CBXH = Convert.ToInt32(s_aCBXH);
        mo_KFB_BASEBALL.N_ZWDATE = Convert.ToDateTime(this.drpZWYear.Value + "/" + this.drpZWMonth.Value + "/" + this.drpZWDay.Value);
        mo_KFB_BASEBALL.N_GAMEDATE = Convert.ToDateTime(this.drpBSYear.Value + "/" + this.drpBSMonth.Value + "/" + this.drpBSDay.Value).AddHours(double.Parse(this.drpBSHour.Value)).AddMinutes(double.Parse(this.drpBSMinute.Value));
        mo_KFB_BASEBALL.N_LMNO = Convert.ToInt32(Request.Form["hidLM"]);
        mo_KFB_BASEBALL.N_VISIT = Convert.ToInt32(Request.Form["hidVisit"]);
        mo_KFB_BASEBALL.N_HOME = Convert.ToInt32(Request.Form["hidHome"]);
        if (this.rdoVisit.Checked)
            mo_KFB_BASEBALL.N_VH = mo_KFB_BASEBALL.N_VISIT;
        else if (this.rdoHome.Checked)
            mo_KFB_BASEBALL.N_VH = mo_KFB_BASEBALL.N_HOME;
        else
            mo_KFB_BASEBALL.N_VH = 0;
        mo_KFB_BASEBALL.N_SFZD = Convert.ToInt32(this.rdoZD.SelectedValue);//0:不開走地 1:開走地 2:走地中
        mo_KFB_BASEBALL.N_VISIT_NO = Convert.ToInt32(this.txtVisitNo.Text);
        mo_KFB_BASEBALL.N_HOME_NO = Convert.ToInt32(this.txtHomeNo.Text);
        mo_KFB_BASEBALL.N_TSA = this.txtVisitTSNo.Text;
        mo_KFB_BASEBALL.N_TSB = this.txtHomeTSNo.Text;
        mo_KFB_BASEBALL.N_VISIT_JZF = Convert.ToInt32(this.txtVisitJZF.Text);
        mo_KFB_BASEBALL.N_HOME_JZF = Convert.ToInt32(this.txtHomeJZF.Text);
        mo_KFB_BASEBALL.N_SFJZF = Convert.ToInt32(this.rdoOpenJZF.SelectedValue);
        mo_KFB_BASEBALL.N_ZBXH = Convert.ToInt32(this.drpZBName.SelectedValue);
        mo_KFB_BASEBALL.N_HYDZSX = Convert.ToDecimal(this.txtDZSX.Text);
        mo_KFB_BASEBALL.N_HYDCSX = Convert.ToDecimal(this.txtDCSX.Text);
        mo_KFB_BASEBALL.N_RFFS = Convert.ToDecimal(this.drpRFFS.Value);
        mo_KFB_BASEBALL.N_RFLX = Convert.ToInt32(this.drpRFLX.Value);
        mo_KFB_BASEBALL.N_RFBL = Convert.ToInt32(this.txtRFBL.Value);
        mo_KFB_BASEBALL.N_LRFPL = Convert.ToDecimal(this.txtLRFPL.Value);
        mo_KFB_BASEBALL.N_RRFPL = Convert.ToDecimal(this.txtRRFPL.Value);
        mo_KFB_BASEBALL.N_LRFCJ = Convert.ToDecimal(this.drpLRFCJ.Value);
        mo_KFB_BASEBALL.N_RRFCJ = Convert.ToDecimal(this.drpRRFCJ.Value);
        mo_KFB_BASEBALL.N_LRFSX = Convert.ToDecimal(this.txtLRFSX.Value);
        mo_KFB_BASEBALL.N_RRFSX = Convert.ToDecimal(this.txtRRFSX.Value);
        mo_KFB_BASEBALL.N_RFCJJE = Convert.ToDecimal(this.txtRFCJJE.Value);
        mo_KFB_BASEBALL.N_RFCJFS = Convert.ToInt32(this.drpRFCJFS.Value);
        if (this.drpRFCJFS.Value.Equals("0"))
            mo_KFB_BASEBALL.N_RFCJPL = Convert.ToDecimal(this.drpRFCJPL.Value);
        else
            mo_KFB_BASEBALL.N_RFCJPL = Convert.ToDecimal(this.drpRFCJPL1.Value);
        mo_KFB_BASEBALL.N_DXFS = Convert.ToDecimal(this.drpDXFS.Value);
        mo_KFB_BASEBALL.N_DXLX = Convert.ToInt32(this.drpDXLX.Value);
        mo_KFB_BASEBALL.N_DXBL = Convert.ToInt32(this.txtDXBL.Value);
        mo_KFB_BASEBALL.N_DXDPL = Convert.ToDecimal(this.txtDXDPL.Value);
        mo_KFB_BASEBALL.N_DXXPL = Convert.ToDecimal(this.txtDXXPL.Value);
        mo_KFB_BASEBALL.N_DXDCJ = Convert.ToDecimal(this.drpDXDCJ.Value);
        mo_KFB_BASEBALL.N_DXXCJ = Convert.ToDecimal(this.drpDXXCJ.Value);
        mo_KFB_BASEBALL.N_DXDCSX = 0;
        mo_KFB_BASEBALL.N_LDXSX = Convert.ToDecimal(this.txtLDXSX.Value);
        mo_KFB_BASEBALL.N_RDXSX = Convert.ToDecimal(this.txtRDXSX.Value);
        mo_KFB_BASEBALL.N_DXCJ = Convert.ToDecimal(this.txtDXCJ.Value);
        mo_KFB_BASEBALL.N_DXCJPL = Convert.ToDecimal(this.drpDXCJPL.Value);
        if ((this.chkLet.Value.Equals("0") && this.chkLet.Checked) || (this.chkLet.Value.Equals("1") && !this.chkLet.Checked))
        {
            mo_KFB_BASEBALL.N_LDYPL = Convert.ToDecimal(this.txtRDYPL.Value);
            mo_KFB_BASEBALL.N_RDYPL = Convert.ToDecimal(this.txtLDYPL.Value);
        }
        else
        {
            mo_KFB_BASEBALL.N_LDYPL = Convert.ToDecimal(this.txtLDYPL.Value);
            mo_KFB_BASEBALL.N_RDYPL = Convert.ToDecimal(this.txtRDYPL.Value);
        }
        mo_KFB_BASEBALL.N_LDYCJ = Convert.ToDecimal(this.drpLDYCJ.Value);
        mo_KFB_BASEBALL.N_RDYCJ = Convert.ToDecimal(this.drpRDYCJ.Value);
        mo_KFB_BASEBALL.N_LDYSX = Convert.ToDecimal(this.txtLDYSX.Value);
        mo_KFB_BASEBALL.N_RDYSX = Convert.ToDecimal(this.txtRDYSX.Value);
        mo_KFB_BASEBALL.N_DYCJ = Convert.ToDecimal(this.txtDYCJ.Value);
        mo_KFB_BASEBALL.N_DYCJPL = Convert.ToDecimal(this.drpDYCJPL.Value);
        //if ((this.chkLet.Value.Equals("0") && this.chkLet.Checked) || (this.chkLet.Value.Equals("1") && !this.chkLet.Checked))
        //{
        //    mo_KFB_BASEBALL.N_LSYPL = Convert.ToDecimal(this.txtRSYPL.Value);
        //    mo_KFB_BASEBALL.N_RSYPL = Convert.ToDecimal(this.txtLSYPL.Value);
        //}
        //else
        //{
        //    mo_KFB_BASEBALL.N_LSYPL = Convert.ToDecimal(this.txtLSYPL.Value);
        //    mo_KFB_BASEBALL.N_RSYPL = Convert.ToDecimal(this.txtRSYPL.Value);
        //}
        //mo_KFB_BASEBALL.N_LSYCJ = Convert.ToDecimal(this.drpLSYCJ.Value);
        //mo_KFB_BASEBALL.N_RSYCJ = Convert.ToDecimal(this.drpRSYCJ.Value);
        //mo_KFB_BASEBALL.N_LSYSX = Convert.ToDecimal(this.txtLSYSX.Value);
        //mo_KFB_BASEBALL.N_RSYSX = Convert.ToDecimal(this.txtRSYSX.Value);
        //mo_KFB_BASEBALL.N_SYCJ = Convert.ToDecimal(this.txtSYCJ.Value);
        //mo_KFB_BASEBALL.N_SYCJPL = Convert.ToDecimal(this.drpSYCJPL.Value);
        mo_KFB_BASEBALL.N_LSYPL = 0;
        mo_KFB_BASEBALL.N_RSYPL = 0;
        mo_KFB_BASEBALL.N_LSYCJ = 0;
        mo_KFB_BASEBALL.N_RSYCJ = 0;
        mo_KFB_BASEBALL.N_LSYSX = 0;
        mo_KFB_BASEBALL.N_RSYSX = 0;
        mo_KFB_BASEBALL.N_SYCJ = 0;
        mo_KFB_BASEBALL.N_SYCJPL = 0;

        mo_KFB_BASEBALL.N_DSDPL = Convert.ToDecimal(this.txtDSDPL.Value);
        mo_KFB_BASEBALL.N_DSSPL = Convert.ToDecimal(this.txtDSSPL.Value);
        mo_KFB_BASEBALL.N_DSDCJ = Convert.ToDecimal(this.drpDSDCJ.Value);
        mo_KFB_BASEBALL.N_DSSCJ = Convert.ToDecimal(this.drpDSSCJ.Value);
        mo_KFB_BASEBALL.N_DSDCSX = 0;
        mo_KFB_BASEBALL.N_LDSSX = Convert.ToDecimal(this.txtLDSSX.Value);
        mo_KFB_BASEBALL.N_RDSSX = Convert.ToDecimal(this.txtRDSSX.Value);
        mo_KFB_BASEBALL.N_DSCJ = Convert.ToDecimal(this.txtDSCJ.Value);
        mo_KFB_BASEBALL.N_DSCJPL = Convert.ToDecimal(this.drpDSCJPL.Value);
        mo_KFB_BASEBALL.N_LET = this.chkLet.Checked ? 1 : 0;//讓分互換
        mo_KFB_BASEBALL.N_RF_OPEN = this.chkRFClose.Checked ? 1 : 0;//讓分關閉
        mo_KFB_BASEBALL.N_DX_OPEN = this.chkDXClose.Checked ? 1 : 0;
        mo_KFB_BASEBALL.N_DY_OPEN = this.chkDYClose.Checked ? 1 : 0;
        mo_KFB_BASEBALL.N_SY_OPEN = 0;
        mo_KFB_BASEBALL.N_DS_OPEN = this.chkDSClose.Checked ? 1 : 0;

        mo_KFB_BASEBALL.N_RQ_OPEN = this.chkRQClose.Checked ? 1 : 0;
        mo_KFB_BASEBALL.N_BD_OPEN = this.chkBDClose.Checked ? 1 : 0;
        mo_KFB_BASEBALL.N_BQC_OPEN = this.chkBQCClose.Checked ? 1 : 0;


        mo_KFB_BASEBALL.N_RF_GG = this.chkRFGGClose.Checked ? 1 : 0;
        mo_KFB_BASEBALL.N_DX_GG = this.chkDXGGClose.Checked ? 1 : 0;
        mo_KFB_BASEBALL.N_DY_GG = this.chkDYGGClose.Checked ? 1 : 0;
        mo_KFB_BASEBALL.N_SY_GG = 0;
        mo_KFB_BASEBALL.N_DS_GG = this.chkDSGGClose.Checked ? 1 : 0;

        mo_KFB_BASEBALL.N_BDGPL00 = Convert.ToDecimal(this.txt00.Text);
        mo_KFB_BASEBALL.N_BDGPL11 = Convert.ToDecimal(this.txt11.Text);
        mo_KFB_BASEBALL.N_BDGPL22 = Convert.ToDecimal(this.txt22.Text);
        mo_KFB_BASEBALL.N_BDGPL33 = Convert.ToDecimal(this.txt33.Text);
        mo_KFB_BASEBALL.N_BDGPL44 = Convert.ToDecimal(this.txt44.Text);
        mo_KFB_BASEBALL.N_BDKPL10 = Convert.ToDecimal(this.txtkc10.Text);
        mo_KFB_BASEBALL.N_BDKPL20 = Convert.ToDecimal(this.txtkc20.Text);
        mo_KFB_BASEBALL.N_BDKPL21 = Convert.ToDecimal(this.txtkc21.Text);
        mo_KFB_BASEBALL.N_BDKPL30 = Convert.ToDecimal(this.txtkc30.Text);
        mo_KFB_BASEBALL.N_BDKPL31 = Convert.ToDecimal(this.txtkc31.Text);
        mo_KFB_BASEBALL.N_BDKPL32 = Convert.ToDecimal(this.txtkc32.Text);
        mo_KFB_BASEBALL.N_BDKPL40 = Convert.ToDecimal(this.txtkc40.Text);
        mo_KFB_BASEBALL.N_BDKPL41 = Convert.ToDecimal(this.txtkc41.Text);
        mo_KFB_BASEBALL.N_BDKPL42 = Convert.ToDecimal(this.txtkc42.Text);
        mo_KFB_BASEBALL.N_BDKPL43 = Convert.ToDecimal(this.txtkc43.Text);
        mo_KFB_BASEBALL.N_BDKPL5 = Convert.ToDecimal(this.txtkc5.Text);
        mo_KFB_BASEBALL.N_BDZPL10 = Convert.ToDecimal(this.txtzc10.Text);
        mo_KFB_BASEBALL.N_BDZPL20 = Convert.ToDecimal(this.txtzc20.Text);
        mo_KFB_BASEBALL.N_BDZPL21 = Convert.ToDecimal(this.txtzc21.Text);
        mo_KFB_BASEBALL.N_BDZPL30 = Convert.ToDecimal(this.txtzc30.Text);
        mo_KFB_BASEBALL.N_BDZPL31 = Convert.ToDecimal(this.txtzc31.Text);
        mo_KFB_BASEBALL.N_BDZPL32 = Convert.ToDecimal(this.txtzc32.Text);
        mo_KFB_BASEBALL.N_BDZPL40 = Convert.ToDecimal(this.txtzc40.Text);
        mo_KFB_BASEBALL.N_BDZPL41 = Convert.ToDecimal(this.txtzc41.Text);
        mo_KFB_BASEBALL.N_BDZPL42 = Convert.ToDecimal(this.txtzc42.Text);
        mo_KFB_BASEBALL.N_BDZPL43 = Convert.ToDecimal(this.txtzc43.Text);
        mo_KFB_BASEBALL.N_BDZPL5 = Convert.ToDecimal(this.txtzc5.Text);
        mo_KFB_BASEBALL.N_BDSX = Convert.ToDecimal(this.txtbdsx.Text);

        mo_KFB_BASEBALL.N_BQCHH = Convert.ToDecimal(this.txtbqchh.Text);
        mo_KFB_BASEBALL.N_BQCHK = Convert.ToDecimal(this.txtbqchk.Text);
        mo_KFB_BASEBALL.N_BQCHZ = Convert.ToDecimal(this.txtbqchz.Text);
        mo_KFB_BASEBALL.N_BQCKH = Convert.ToDecimal(this.txtbqckh.Text);
        mo_KFB_BASEBALL.N_BQCKK = Convert.ToDecimal(this.txtbqckk.Text);
        mo_KFB_BASEBALL.N_BQCKZ = Convert.ToDecimal(this.txtbqckz.Text);
        mo_KFB_BASEBALL.N_BQCZH = Convert.ToDecimal(this.txtbqczh.Text);
        mo_KFB_BASEBALL.N_BQCZK = Convert.ToDecimal(this.txtbqczk.Text);
        mo_KFB_BASEBALL.N_BQCZZ = Convert.ToDecimal(this.txtbqczz.Text);
        mo_KFB_BASEBALL.N_BQCSX = Convert.ToDecimal(this.txtbqcsx.Text);

        mo_KFB_BASEBALL.N_RQSPL01 = Convert.ToDecimal(this.txtrqs01.Text);
        mo_KFB_BASEBALL.N_RQSPL23 = Convert.ToDecimal(this.txtrqs23.Text);
        mo_KFB_BASEBALL.N_RQSPL46 = Convert.ToDecimal(this.txtrqs46.Text);
        mo_KFB_BASEBALL.N_RQSPL7 = Convert.ToDecimal(this.txtrqs7.Text);
        mo_KFB_BASEBALL.N_RQSSX = Convert.ToDecimal(this.txtrqssx.Text);

        mo_KFB_BASEBALL.N_HJPL = Convert.ToDecimal(this.txtN_HJPL.Value);
        mo_KFB_BASEBALL.N_HJGGCJ = Convert.ToDecimal(this.drpN_HJGGCJ.Value);
        mo_KFB_BASEBALL.N_HJSX = Convert.ToDecimal(this.txtN_HJSX.Value);

        return mo_KFB_BASEBALL;
    }

    #endregion


}
