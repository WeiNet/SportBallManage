#region History
///程式代號：      GameListOtherEdit
///程式名稱：      GameListOtherEdit
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

    public partial class GameListOtherEdit : BasePage
    {
        #region 全局变量
        private Hashtable mo_Ht = new Hashtable();
        private string ms_TYPE = "b_bj";
        private int mi_TYPE = -1;
        private GamesDB objGame = new GamesDB();
        private GameListOtherEditDB objGameListOtherEditDB = new GameListOtherEditDB();

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["bt"] != null)
            {
                //ms_TYPE = Request.QueryString["ball"];
                switch (Request.QueryString["bt"])
                {
                    case "b_bj":
                        this.lblball.Text = "棒球";
                        this.lblType.Text = "棒球";
                        mi_TYPE = 2;
                        ms_TYPE = "b_bj";
                        break;
                    case "b_bq":
                        this.lblball.Text = "冰球";
                        this.lblType.Text = "冰球";
                        mi_TYPE = 13;
                        ms_TYPE = "b_bq";
                        break;
                    case "b_by":
                        this.lblball.Text = "网球";
                        this.lblType.Text = "网球";
                        mi_TYPE = 3;
                        ms_TYPE = "b_by";
                        break;
                    case "b_bb":
                        this.lblball.Text = "排球";
                        this.lblType.Text = "排球";
                        mi_TYPE = 6;
                        ms_TYPE = "b_bb";
                        break;
                    case "b_bk":
                        this.lblball.Text = "篮球";
                        this.lblType.Text = "篮球";
                        mi_TYPE = 1;
                        ms_TYPE = "b_bk";
                        break;
                }
            }
            if (Request.QueryString["LM"] != null)
            {

                DataSet ds = objGameListOtherEditDB.GetDW(Convert.ToInt32(Request.QueryString["LM"].ToString()), mi_TYPE);
                Response.Clear();
                Response.Write(ds.GetXml());
                Response.Flush();
                Response.End();
            }
            if (!IsPostBack)
            {
               
                this.drpLM.DataSource = this.objGameListOtherEditDB.GetBaseBallUnion(mi_TYPE);
                this.drpLM.DataTextField = "N_LMMC";
                this.drpLM.DataValueField = "N_NO";
                this.drpLM.DataBind();

                this.drpLM.Items.Insert(0, new ListItem("請選擇聯盟", "-1"));
                this.drpZBName.DataSource = this.objGameListOtherEditDB.GetZB();
                this.drpZBName.DataTextField = "N_ZBMC";
                this.drpZBName.DataValueField = "N_ID";
                this.drpZBName.DataBind();
                this.drpZBName.Items.Insert(0, new ListItem("請選擇直播名稱", "-1"));
                if (Request.QueryString["id"] != null)//修改
                {
                    this.hidMode.Value = "Modify";
                    this.hidN_ID.Value = Request.QueryString["id"].ToString();
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
                    if (objGame.Exists(Convert.ToInt32(this.hidN_ID.Value)))
                    {
                        objGame.Update(GetKFB_BASEBALL(this.rdoCB.SelectedValue), mo_Ht);
                        objGame.SetTran(mo_Ht);
                        this.ShowMsg("修改成功");
                     
                        this.WriteLog("用户名=" + mUserID + "；操作=修改" + this.lblball.Text + "比赛");
                        btnBack_Click(sender, e);
                    }
                    else
                    {
                        this.ShowMsg("該比賽已經刪除");
                    }
                }
                else
                {
                    hidTeam.Value = "team" + Request.Form["hidVisit"] + Request.Form["hidHome"] + DateTime.Now.Millisecond.ToString();
                    for (int i = 0; i < this.chkCB.Items.Count; i++)
                    {
                        if (this.chkCB.Items[i].Selected)
                            objGame.Add(GetKFB_BASEBALL(this.chkCB.Items[i].Value), mo_Ht);

                    }
                    objGame.SetTran(mo_Ht);
                    this.ShowMsg("新增成功");
                    this.WriteLog("用户名=" + mUserID + "；操作=新增" + this.lblball.Text + "比赛");
               
                    this.hidMode.Value = "Add";
                }
            }
            catch (Exception ex)
            {
                this.WriteLog(ex.ToString());
                this.ShowMsg("存儲失敗");
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Context.Items.Add("CBXH", this.ViewState["CBXH"]);
            this.Context.Items.Add("SFXZ", this.ViewState["SFXZ"]);
            this.Context.Items.Add("PAGE", this.ViewState["PAGE"]);
            this.Context.Items.Add("LMNO", this.ViewState["LMNO"]);
            this.Context.Items.Add("ZWRQ", this.ViewState["ZWRQ"]);
            this.Context.Items.Add("BSSJ", this.ViewState["BSSJ"]);
            if (Request.QueryString["TYPE"] != null)
            {
                if (Request.QueryString["TYPE"].Equals("DS"))
                    Server.Transfer("baseball_dsgame.aspx");
                else if (Request.QueryString["TYPE"].Equals("ZD"))
                    Server.Transfer("baseball_zdgame.aspx");
                else if (Request.QueryString["TYPE"].Equals("KS"))
                    Server.Transfer("baseball_begingame.aspx");
            }
        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                GameCalculationDB o_KFB_BASEBALL_BLL = new GameCalculationDB();
                KFB_BASEBALL o_KFB_BASEBALL = o_KFB_BASEBALL_BLL.GetModel(Convert.ToInt32(this.hidN_ID.Value));
                objGame.Add(o_KFB_BASEBALL, mo_Ht);
                objGame.SetTran(mo_Ht);
                this.ShowMsg("複製成功");
            }
            catch (Exception ex)
            {
                this.WriteLog("用户名=" + mUserID + "；操作=复制" + this.lblball.Text + "比赛");
                ex.ToString();
                this.ShowMsg("複製失敗");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (objGame.ExistsZD(Convert.ToInt32(this.hidN_ID.Value)))
                {
                    this.ShowMsg("該賽事已有注單，不可以刪除");
                }
                else
                {
                    objGame.Delete(Convert.ToInt32(this.hidN_ID.Value));
                    this.ShowMsg("刪除成功");
                    btnBack_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                this.WriteLog("用户名=" + this.mUserID+ ex.ToString());
              
                this.ShowMsg("刪除失敗");
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
                this.rdoVisit.Checked = false;
                this.rdoHome.Checked = true;
                this.hidVisit.Value = "-1";
                this.hidHome.Value = "-1";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate1", "ConRate(document.getElementById('ContentPlaceHolder11_drpRFLX'),document.getElementById('ContentPlaceHolder11_txtRFBL'));", true);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ConRate2", "ConRate(document.getElementById('ContentPlaceHolder11_drpDXLX'),document.getElementById('ContentPlaceHolder11_txtDXBL'));", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "LM", "$('#ContentPlaceHolder11_drpLM').val($('ContentPlaceHolder11_hidLM').val());getTeamList($('#ContentPlaceHolder11_drpLM').get(0),true);$('#ContentPlaceHolder11_drpLM').attr('disabled',true);", true);
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate1", "CountTotal('ContentPlaceHolder11_txtLRFPL','ContentPlaceHolder11_txtRRFPL','ContentPlaceHolder11_txtRFPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate2", "CountTotal('ContentPlaceHolder11_txtDXDPL','ContentPlaceHolder11_txtDXXPL','ContentPlaceHolder11_txtDXPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate3", "CountTotal('ContentPlaceHolder11_txtLDYPL','ContentPlaceHolder11_txtRDYPL','ContentPlaceHolder11_txtDYPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate4", "CountTotal('ContentPlaceHolder11_txtLSYPL','ContentPlaceHolder11_txtRSYPL','ContentPlaceHolder11_txtSYPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Rate5", "CountTotal('ContentPlaceHolder11_txtDSDPL','ContentPlaceHolder11_txtDSSPL','ContentPlaceHolder11_txtDSPLJZ');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "LM", "document.getElementById('ContentPlaceHolder11_drpLM').value=document.getElementById('ContentPlaceHolder11_hidLM').value;getDW(document.getElementById('ContentPlaceHolder11_drpLM'),'baseball');document.getElementById('ContentPlaceHolder11_drpVisit').value=document.getElementById('ContentPlaceHolder11_hidVisit').value;document.getElementById('ContentPlaceHolder11_drpHome').value=document.getElementById('ContentPlaceHolder11_hidHome').value;", true);
        }
        #endregion

        #region grid事件
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
            this.hidVisit.Value = o_KFB_BASEBALL.N_VISIT.ToString();
            this.hidHome.Value = o_KFB_BASEBALL.N_HOME.ToString();
            if (o_KFB_BASEBALL.N_VH.Value.Equals(o_KFB_BASEBALL.N_VISIT))
                this.rdoVisit.Checked = true;
            else
                this.rdoHome.Checked = true;
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

            this.txtDXFS.Value = o_KFB_BASEBALL.N_DXFS.ToString();
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

            this.txtLSYPL.Value = o_KFB_BASEBALL.N_LSYPL.ToString();
            this.txtRSYPL.Value = o_KFB_BASEBALL.N_RSYPL.ToString();
            this.drpLSYCJ.Value = o_KFB_BASEBALL.N_LSYCJ.ToString();
            this.drpRSYCJ.Value = o_KFB_BASEBALL.N_RSYCJ.ToString();
            this.txtLSYSX.Value = o_KFB_BASEBALL.N_LSYSX.ToString();
            this.txtRSYSX.Value = o_KFB_BASEBALL.N_RSYSX.ToString();
            this.txtSYCJ.Value = o_KFB_BASEBALL.N_SYCJ.ToString();
            this.drpSYCJPL.Value = o_KFB_BASEBALL.N_SYCJPL.ToString();

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
            this.chkSYClose.Checked = o_KFB_BASEBALL.N_SY_OPEN.Value.Equals(1) ? true : false;
            this.chkDSClose.Checked = o_KFB_BASEBALL.N_DS_OPEN.Value.Equals(1) ? true : false;

            this.chkRFGGClose.Checked = o_KFB_BASEBALL.N_RF_GG.Value.Equals(1) ? true : false;
            this.chkDXGGClose.Checked = o_KFB_BASEBALL.N_DX_GG.Value.Equals(1) ? true : false;
            this.chkDYGGClose.Checked = o_KFB_BASEBALL.N_DY_GG.Value.Equals(1) ? true : false;
            this.chkSYGGClose.Checked = o_KFB_BASEBALL.N_SY_GG.Value.Equals(1) ? true : false;
            this.chkDSGGClose.Checked = o_KFB_BASEBALL.N_DS_GG.Value.Equals(1) ? true : false;
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

            KFB_BSYS o_KFB_BSYS = objGame.GetModel(ms_TYPE);
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
                this.chkSYClose.Checked = true;
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
                this.txtLDYPL.Value = o_KFB_BSYS.N_LDYPL.ToString();
                this.txtRDYPL.Value = o_KFB_BSYS.N_RDYPL.ToString();
                this.drpLDYCJ.Value = o_KFB_BSYS.N_LDYCJ.ToString();
                this.drpRDYCJ.Value = o_KFB_BSYS.N_RDYCJ.ToString();
                this.txtLDYSX.Value = o_KFB_BSYS.N_LDYSX.ToString();
                this.txtRDYSX.Value = o_KFB_BSYS.N_RDYSX.ToString();
                this.txtDYCJ.Value = o_KFB_BSYS.N_DYCJ.ToString();
                this.drpDYCJPL.Value = o_KFB_BSYS.N_DYCJPL.ToString();
                this.txtLSYPL.Value = o_KFB_BSYS.N_LSYPL.ToString();
                this.txtRSYPL.Value = o_KFB_BSYS.N_RSYPL.ToString();
                this.drpLSYCJ.Value = o_KFB_BSYS.N_LSYCJ.ToString();
                this.drpRSYCJ.Value = o_KFB_BSYS.N_RSYCJ.ToString();
                this.txtLSYSX.Value = o_KFB_BSYS.N_LSYSX.ToString();
                this.txtRSYSX.Value = o_KFB_BSYS.N_RSYSX.ToString();
                this.txtSYCJ.Value = o_KFB_BSYS.N_SYCJ.ToString();
                this.drpSYCJPL.Value = o_KFB_BSYS.N_SYCJPL.ToString();
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
                this.chkSYGGClose.Checked = true;
                this.chkDSGGClose.Checked = true;
            }
            #endregion
        }
        private KFB_BASEBALL GetKFB_BASEBALL(string s_aCBXH)
        {
            KFB_BASEBALL o_KFB_BASEBALL = new KFB_BASEBALL();
            o_KFB_BASEBALL.N_RF_LOCK_V = 0;
            o_KFB_BASEBALL.N_RF_LOCK_H = 0;
            o_KFB_BASEBALL.N_DX_LOCK_V = 0;
            o_KFB_BASEBALL.N_DX_LOCK_H = 0;
            o_KFB_BASEBALL.N_DY_LOCK_V = 0;
            o_KFB_BASEBALL.N_DY_LOCK_H = 0;
            o_KFB_BASEBALL.N_SY_LOCK_V = 0;
            o_KFB_BASEBALL.N_SY_LOCK_H = 0;
            o_KFB_BASEBALL.N_DS_LOCK_V = 0;
            o_KFB_BASEBALL.N_DS_LOCK_H = 0;
            o_KFB_BASEBALL.N_VISIT_RESULT = 0;
            o_KFB_BASEBALL.N_HOME_RESULT = 0;
            o_KFB_BASEBALL.N_REMARK = "";
            o_KFB_BASEBALL.N_SF9J = 0;//0:打滿九局 1:未滿九局
            o_KFB_BASEBALL.N_SFDS = 0;//新比賽是否移至單式0:否 1:是
            o_KFB_BASEBALL.N_SFGP = 0;//0:不跟盤 1:跟盤
            o_KFB_BASEBALL.N_UP_VISIT_RESULT = 0;//上半場客隊結果比賽結果
            o_KFB_BASEBALL.N_UP_HOME_RESULT = 0;//上半場主隊結果比賽結果
            o_KFB_BASEBALL.N_SFXZ = 0;//會員是否下注,0:關閉會員下注 1:開放會員下注(走地) 2:開放會員下注(單式)
            o_KFB_BASEBALL.N_XZZT = 0;//0:移至未開賽(單式or走地) 1:移至已開賽
            o_KFB_BASEBALL.N_LOCK = 0;//0:不鎖定 1:強制鎖定
            o_KFB_BASEBALL.N_SAMETEAM = hidTeam.Value;
            if (this.hidMode.Value.Equals("Modify"))
            {
                GameCalculationDB o_KFB_BASEBALL_BLL = new GameCalculationDB();
                o_KFB_BASEBALL = o_KFB_BASEBALL_BLL.GetModel(Convert.ToInt32(this.hidN_ID.Value));
            }
            o_KFB_BASEBALL.N_ID = Convert.ToInt32(this.hidN_ID.Value);
            o_KFB_BASEBALL.N_LX = ms_TYPE;
            o_KFB_BASEBALL.N_CBXH = Convert.ToInt32(s_aCBXH);
            o_KFB_BASEBALL.N_ZWDATE = Convert.ToDateTime(this.drpZWYear.Value + "/" + this.drpZWMonth.Value + "/" + this.drpZWDay.Value);
            o_KFB_BASEBALL.N_GAMEDATE = Convert.ToDateTime(this.drpBSYear.Value + "/" + this.drpBSMonth.Value + "/" + this.drpBSDay.Value).AddHours(double.Parse(this.drpBSHour.Value)).AddMinutes(double.Parse(this.drpBSMinute.Value));
            o_KFB_BASEBALL.N_LMNO = Convert.ToInt32(Request.Form["hidLM"]);
            o_KFB_BASEBALL.N_VISIT = Convert.ToInt32(Request.Form["hidVisit"]);
            o_KFB_BASEBALL.N_HOME = Convert.ToInt32(Request.Form["hidHome"]);
            if (this.rdoVisit.Checked)
                o_KFB_BASEBALL.N_VH = o_KFB_BASEBALL.N_VISIT;
            else if (this.rdoHome.Checked)
                o_KFB_BASEBALL.N_VH = o_KFB_BASEBALL.N_HOME;
            o_KFB_BASEBALL.N_SFZD = Convert.ToInt32(this.rdoZD.SelectedValue);//0:不開走地 1:開走地 2:走地中
            o_KFB_BASEBALL.N_VISIT_NO = Convert.ToInt32(this.txtVisitNo.Text);
            o_KFB_BASEBALL.N_HOME_NO = Convert.ToInt32(this.txtHomeNo.Text);
            o_KFB_BASEBALL.N_TSA = this.txtVisitTSNo.Text;
            o_KFB_BASEBALL.N_TSB = this.txtHomeTSNo.Text;
            o_KFB_BASEBALL.N_VISIT_JZF = Convert.ToInt32(this.txtVisitJZF.Text);
            o_KFB_BASEBALL.N_HOME_JZF = Convert.ToInt32(this.txtHomeJZF.Text);
            o_KFB_BASEBALL.N_SFJZF = Convert.ToInt32(this.rdoOpenJZF.SelectedValue);
            o_KFB_BASEBALL.N_ZBXH = Convert.ToInt32(this.drpZBName.SelectedValue);
            o_KFB_BASEBALL.N_HYDZSX = Convert.ToDecimal(this.txtDZSX.Text);
            o_KFB_BASEBALL.N_HYDCSX = Convert.ToDecimal(this.txtDCSX.Text);
            o_KFB_BASEBALL.N_RFFS = Convert.ToDecimal(this.drpRFFS.Value);
            o_KFB_BASEBALL.N_RFLX = Convert.ToInt32(this.drpRFLX.Value);
            o_KFB_BASEBALL.N_RFBL = Convert.ToInt32(this.txtRFBL.Value);
            o_KFB_BASEBALL.N_LRFPL = Convert.ToDecimal(this.txtLRFPL.Value);
            o_KFB_BASEBALL.N_RRFPL = Convert.ToDecimal(this.txtRRFPL.Value);
            o_KFB_BASEBALL.N_LRFCJ = Convert.ToDecimal(this.drpLRFCJ.Value);
            o_KFB_BASEBALL.N_RRFCJ = Convert.ToDecimal(this.drpRRFCJ.Value);
            o_KFB_BASEBALL.N_LRFSX = Convert.ToDecimal(this.txtLRFSX.Value);
            o_KFB_BASEBALL.N_RRFSX = Convert.ToDecimal(this.txtRRFSX.Value);
            o_KFB_BASEBALL.N_RFCJJE = Convert.ToDecimal(this.txtRFCJJE.Value);
            o_KFB_BASEBALL.N_RFCJFS = Convert.ToInt32(this.drpRFCJFS.Value);
            if (this.drpRFCJFS.Value.Equals("0"))
                o_KFB_BASEBALL.N_RFCJPL = Convert.ToDecimal(this.drpRFCJPL.Value);
            else
                o_KFB_BASEBALL.N_RFCJPL = Convert.ToDecimal(this.drpRFCJPL1.Value);
            o_KFB_BASEBALL.N_DXFS = Convert.ToDecimal(this.txtDXFS.Value);
            o_KFB_BASEBALL.N_DXLX = Convert.ToInt32(this.drpDXLX.Value);
            o_KFB_BASEBALL.N_DXBL = Convert.ToInt32(this.txtDXBL.Value);
            o_KFB_BASEBALL.N_DXDPL = Convert.ToDecimal(this.txtDXDPL.Value);
            o_KFB_BASEBALL.N_DXXPL = Convert.ToDecimal(this.txtDXXPL.Value);
            o_KFB_BASEBALL.N_DXDCJ = Convert.ToDecimal(this.drpDXDCJ.Value);
            o_KFB_BASEBALL.N_DXXCJ = Convert.ToDecimal(this.drpDXXCJ.Value);
            o_KFB_BASEBALL.N_DXDCSX = 0;
            o_KFB_BASEBALL.N_LDXSX = Convert.ToDecimal(this.txtLDXSX.Value);
            o_KFB_BASEBALL.N_RDXSX = Convert.ToDecimal(this.txtRDXSX.Value);
            o_KFB_BASEBALL.N_DXCJ = Convert.ToDecimal(this.txtDXCJ.Value);
            o_KFB_BASEBALL.N_DXCJPL = Convert.ToDecimal(this.drpDXCJPL.Value);
            if ((this.chkLet.Value.Equals("0") && this.chkLet.Checked) || (this.chkLet.Value.Equals("1") && !this.chkLet.Checked))
            {
                o_KFB_BASEBALL.N_LDYPL = Convert.ToDecimal(this.txtRDYPL.Value);
                o_KFB_BASEBALL.N_RDYPL = Convert.ToDecimal(this.txtLDYPL.Value);
            }
            else
            {
                o_KFB_BASEBALL.N_LDYPL = Convert.ToDecimal(this.txtLDYPL.Value);
                o_KFB_BASEBALL.N_RDYPL = Convert.ToDecimal(this.txtRDYPL.Value);
            }
            o_KFB_BASEBALL.N_LDYCJ = Convert.ToDecimal(this.drpLDYCJ.Value);
            o_KFB_BASEBALL.N_RDYCJ = Convert.ToDecimal(this.drpRDYCJ.Value);
            o_KFB_BASEBALL.N_LDYSX = Convert.ToDecimal(this.txtLDYSX.Value);
            o_KFB_BASEBALL.N_RDYSX = Convert.ToDecimal(this.txtRDYSX.Value);
            o_KFB_BASEBALL.N_DYCJ = Convert.ToDecimal(this.txtDYCJ.Value);
            o_KFB_BASEBALL.N_DYCJPL = Convert.ToDecimal(this.drpDYCJPL.Value);
            if ((this.chkLet.Value.Equals("0") && this.chkLet.Checked) || (this.chkLet.Value.Equals("1") && !this.chkLet.Checked))
            {
                o_KFB_BASEBALL.N_LSYPL = Convert.ToDecimal(this.txtRSYPL.Value);
                o_KFB_BASEBALL.N_RSYPL = Convert.ToDecimal(this.txtLSYPL.Value);
            }
            else
            {
                o_KFB_BASEBALL.N_LSYPL = Convert.ToDecimal(this.txtLSYPL.Value);
                o_KFB_BASEBALL.N_RSYPL = Convert.ToDecimal(this.txtRSYPL.Value);
            }
            o_KFB_BASEBALL.N_LSYCJ = Convert.ToDecimal(this.drpLSYCJ.Value);
            o_KFB_BASEBALL.N_RSYCJ = Convert.ToDecimal(this.drpRSYCJ.Value);
            o_KFB_BASEBALL.N_LSYSX = Convert.ToDecimal(this.txtLSYSX.Value);
            o_KFB_BASEBALL.N_RSYSX = Convert.ToDecimal(this.txtRSYSX.Value);
            o_KFB_BASEBALL.N_SYCJ = Convert.ToDecimal(this.txtSYCJ.Value);
            o_KFB_BASEBALL.N_SYCJPL = Convert.ToDecimal(this.drpSYCJPL.Value);
            o_KFB_BASEBALL.N_DSDPL = Convert.ToDecimal(this.txtDSDPL.Value);
            o_KFB_BASEBALL.N_DSSPL = Convert.ToDecimal(this.txtDSSPL.Value);
            o_KFB_BASEBALL.N_DSDCJ = Convert.ToDecimal(this.drpDSDCJ.Value);
            o_KFB_BASEBALL.N_DSSCJ = Convert.ToDecimal(this.drpDSSCJ.Value);
            o_KFB_BASEBALL.N_DSDCSX = 0;
            o_KFB_BASEBALL.N_LDSSX = Convert.ToDecimal(this.txtLDSSX.Value);
            o_KFB_BASEBALL.N_RDSSX = Convert.ToDecimal(this.txtRDSSX.Value);
            o_KFB_BASEBALL.N_DSCJ = Convert.ToDecimal(this.txtDSCJ.Value);
            o_KFB_BASEBALL.N_DSCJPL = Convert.ToDecimal(this.drpDSCJPL.Value);
            o_KFB_BASEBALL.N_LET = this.chkLet.Checked ? 1 : 0;//讓分互換
            o_KFB_BASEBALL.N_RF_OPEN = this.chkRFClose.Checked ? 1 : 0;//讓分關閉
            o_KFB_BASEBALL.N_DX_OPEN = this.chkDXClose.Checked ? 1 : 0;
            o_KFB_BASEBALL.N_DY_OPEN = this.chkDYClose.Checked ? 1 : 0;
            o_KFB_BASEBALL.N_SY_OPEN = this.chkSYClose.Checked ? 1 : 0;
            o_KFB_BASEBALL.N_DS_OPEN = this.chkDSClose.Checked ? 1 : 0;

            o_KFB_BASEBALL.N_RF_GG = this.chkRFGGClose.Checked ? 1 : 0;
            o_KFB_BASEBALL.N_DX_GG = this.chkDXGGClose.Checked ? 1 : 0;
            o_KFB_BASEBALL.N_DY_GG = this.chkDYGGClose.Checked ? 1 : 0;
            o_KFB_BASEBALL.N_SY_GG = this.chkSYGGClose.Checked ? 1 : 0;
            o_KFB_BASEBALL.N_DS_GG = this.chkDSGGClose.Checked ? 1 : 0;

            return o_KFB_BASEBALL;
        }
        #endregion


    }
