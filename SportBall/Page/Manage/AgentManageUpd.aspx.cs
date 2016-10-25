using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class AgentManageUpd : BasePage
    {
        private string strlvl = "";
        private string strparid = "";
        private string strUpLvl = "";
        AgentManageDB objAgentManageDB = new AgentManageDB();
        AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
        #region"Page_Load"
        protected void Page_Load(object sender, EventArgs e)
        {
            strlvl = Request["lv"];
            if (Request["id"] != null)
            {
                strparid = Request["id"];
            }
            if (!IsPostBack)
            {
                SetPage(strlvl);
            }
            this.ViewState["strlvl"] = strlvl;
            if (Comm.GetFlag(mUserID) == "1")
            {
                bttjzj.Visible = false;
                btdel.Visible = false;
            }
        }
        #endregion
        #region"頁面初始化"
        protected void SetPage(string strlv)
        {
            this.lbtitle.Text = "修改" + Comm.GetLvName(strlv);
            this.lbtitle1.Text = "修改" + Comm.GetLvName(strlv);
            this.lbzh.Text = Comm.GetLvName(strlv) + "帳號：";
            this.lbzhmc.Text = Comm.GetLvName(strlv) + "名稱：";

            bool chxx = objAgentManageDB.Exists(Convert.ToInt32(strlvl), strparid);
            if (chxx)
                this.hiddelxj.Value = "1";
            else
                this.hiddelxj.Value = "0";
            this.Rdyxdl.Items[0].Selected = true;
            this.Rdyxxz.Items[0].Selected = true;
            if (strlvl != "4")
            {
                string strzh = Comm.GetUPID(strparid, strlvl);
                if (Comm.SJYXDL(strzh).Equals(false))
                    this.Rdyxdl.Attributes.Add("onclick", "document.getElementsByName('Rdyxdl')[2].checked=true;");
                if (Comm.SJYXXZ(strzh).Equals(false))
                    this.Rdyxxz.Attributes.Add("onclick", "document.getElementsByName('Rdyxxz')[2].checked=true;");
            }
            this.Rdycxz.Items[1].Selected = true;
            this.bttjzj.Text = "修改" + Comm.GetLvName(strlv);
            this.lbps.Text = "(如果更換密碼，請在此處填寫新密碼，然後單擊「修改總監」按紐)";
            //代理商下注過關限制
            if (!strlv.Equals("9"))
            {
                this.trXiazhuNum.Visible = false;
            }
            //各級赋值
            HYFZ();
            //更改上一级页面初始赋值
            int iUpLvl = Convert.ToInt32(strlv) - 1;
            if (iUpLvl >= 4)
            {
                strUpLvl = iUpLvl.ToString();
                this.hlchangeboss.Text = "更改" + Comm.GetLvName(strUpLvl);
                //this.hlchangeboss.NavigateUrl = "changeUpLvl.aspx?lvl=" + strUpLvl;
                string strUrl = "changeUpLvl.aspx?uplvl=" + strUpLvl + "&hyzh=" + this.lbzj.Text + "&hydj=" + strlvl;
                this.hlchangeboss.Attributes.Add("onclick", "window.open('" + strUrl + "','_blank','height=200,width=500,top=0,left=0,toolbar=no, menubar=no,scrollbars=yes,resizable=yes,location=no,status=no')");
                this.hlchangeboss.NavigateUrl = "#";
            }
            else
            {
                this.hlchangeboss.Text = "";
                this.hlchangeboss.Visible = false;
            }
            //<=赋值
            if (strlvl.Equals("4"))
            {
                ZJFZ();
            }
            else
            {
                //取得上级值
                MaxParen();
            }
            //當剩餘額度為0時，信用額度不能再降
            //if(this.txtsyed.Text.Equals("0"))
            //{
            //    this.txtxyed.ReadOnly = true;
            //}
            //取得下级最大值
            MaxFZ();
            //添加JS
            this.txtczlq.Attributes.Add("onblur", "checkCZ(this,'籃球','" + this.lbczlq.Text + "')");
            this.txtczmb.Attributes.Add("onblur", "checkCZ(this,'棒球','" + this.lbczmb.Text + "')");
            this.txtczrb.Attributes.Add("onblur", "checkCZ(this,'网球','" + this.lbczrb.Text + "')");
            this.txtcztb.Attributes.Add("onblur", "checkCZ(this,'排球','" + this.lbcztb.Text + "')");
            this.txtczmz.Attributes.Add("onblur", "checkCZ(this,'美足','" + this.lbczmz.Text + "')");
            this.txtczzq.Attributes.Add("onblur", "checkCZ(this,'足球','" + this.lbczzq.Text + "')");
            this.txtczzs.Attributes.Add("onblur", "checkCZ(this,'指數','" + this.lbczzs.Text + "')");
            this.txtczdlt.Attributes.Add("onblur", "checkCZ(this,'大樂透','" + this.lbczdlt.Text + "')");
            this.txtczsm.Attributes.Add("onblur", "checkCZ(this,'賽馬','" + this.lbczsm.Text + "')");
            this.txtczlhc.Attributes.Add("onblur", "checkCZ(this,'六合彩','" + this.lbczlhc.Text + "')");
            this.txtcz2x.Attributes.Add("onblur", "checkCZ(this,'二星','" + this.lbcz2x.Text + "')");
            this.txtcz3x.Attributes.Add("onblur", "checkCZ(this,'三星','" + this.lbcz3x.Text + "')");
            this.txtcz4x.Attributes.Add("onblur", "checkCZ(this,'四星','" + this.lbcz4x.Text + "')");
            this.txtczjc539.Attributes.Add("onblur", "checkCZ(this,'今彩539','" + this.lbczjc539.Text + "')");
            this.txtczcp.Attributes.Add("onblur", "checkCZ(this,'運動彩票','" + this.lbczcp.Text + "')");
            this.txtczss.Attributes.Add("onblur", "checkCZ(this,'時事','" + this.lbczss.Text + "')");

            this.txtczbq.Attributes.Add("onblur", "checkCZ(this,'冰球','" + this.lbczbq.Text + "')");
            this.txtczcq.Attributes.Add("onblur", "checkCZ(this,'彩球','" + this.lbczcq.Text + "')");



            this.txtxyed.Attributes.Add("onkeypress", "return inputNubmerFloat();");
            this.bttjzj.Attributes.Add("onclick", " return (checkInput()&& SetAble()&& chMM());");
            //this.txtmm.Attributes.Add("onblur", "chMM();");
            //this.txtzrmm.Attributes.Add("onblur", "chMM();");
            this.txtxyed.Attributes.Add("onblur", " chxyed(this,'0','" + this.hidje.Value + "','" + (Convert.ToDouble(this.hidxy.Value) - Convert.ToDouble(this.txtsyed.Text)) + "');");
            //   this.bttjzj.Attributes.Add("onclick"," ");

            this.txtlqdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtlqtyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtlqdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtlqddALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzqtyaALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzqtybALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzqtycALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzqdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzqdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtsmtyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtsmdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtsmdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtlhctyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtlhcdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtlhcdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtdlttyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtdltdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtdltdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtjc539tyALL.Attributes.Add("onblur","SetAllValue(this)");
            this.txtjc539dzALL.Attributes.Add("onblur","SetAllValue(this)");
            this.txtjc539dcALL.Attributes.Add("onblur","SetAllValue(this)");
            this.txtcptyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtcpdzALL.Attributes.Add("onblur", "CheckZS(this);SetAllValue(this)");
            this.txtcpdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtmztyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtmzdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtmzdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtmbtyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtmbdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtmbdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtrbtyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtrbdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtrbdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txttbtyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txttbdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txttbdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzstyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzsdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtzsdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtsstyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtssdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtssdcALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtddsx.Attributes.Add("onkeypress", "return inputNubmerFloat();");


            this.txtbqtyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtbqdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtbqdcALL.Attributes.Add("onblur", "SetAllValue(this)");

            this.txtcqtyALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtcqdzALL.Attributes.Add("onblur", "SetAllValue(this)");
            this.txtcqdcALL.Attributes.Add("onblur", "SetAllValue(this)");

            //给隐藏栏位复制
            //GetGJZH();

        }
        #endregion
        #region"取得上级值"
        public void MaxParen()
        {
         
            string strzh = Comm.GetUPID(strparid, strlvl);
            KFB_ZHGL mo_zhgl = this.objAgentManageDB.GetModel(strzh);
            //拆帐赋值
            this.lbczlq.Text = mo_zhgl.N_LQCZ.ToString();
            this.lbczmb.Text = mo_zhgl.N_MBCZ.ToString();
            this.lbczrb.Text = mo_zhgl.N_RBCZ.ToString();
            this.lbcztb.Text = mo_zhgl.N_TBCZ.ToString();
            this.lbczmz.Text = mo_zhgl.N_MZCZ.ToString();
            this.lbczzq.Text = mo_zhgl.N_ZQCZ.ToString();
            this.lbczzs.Text = mo_zhgl.N_ZSCZ.ToString();
            this.lbczdlt.Text = mo_zhgl.N_DLTCZ.ToString();
            this.lbczsm.Text = mo_zhgl.N_SMCZ.ToString();
            this.lbczlhc.Text = mo_zhgl.N_LHCCZ.ToString();
            this.lbcz2x.Text = mo_zhgl.N_2XCZ.ToString();
            this.lbcz3x.Text = mo_zhgl.N_3XCZ.ToString();
            this.lbcz4x.Text = mo_zhgl.N_4XCZ.ToString();
            this.lbczjc539.Text = mo_zhgl.N_JCCZ.ToString();
            this.lbczcp.Text = mo_zhgl.N_CPCZ.ToString();
            this.lbczss.Text = mo_zhgl.N_SSCZ.ToString();
            this.txtddsx.Attributes.Add("onblur", "chxyed(this,'1','" + mo_zhgl.N_DDSX.ToString() + "','0')");

            this.lbczbq.Text = mo_zhgl.N_BQCZ.ToString();
            this.lbczcq.Text = mo_zhgl.N_CQCZ.ToString();

            
            KFB_SETUPLQ mo_lq = this.objAgentManageAddDB.GetModelLQ(strzh);

            //篮球 
            #region
            this.lblqtyrf.Text = mo_lq.N_RFTY.ToString();
            this.lblqdzrf.Text = mo_lq.N_RFDZ.ToString();
            this.lblqdcrf.Text = mo_lq.N_RFDC.ToString();
            this.lblqddrf.Text = mo_lq.N_RFDD.ToString();
            this.lblqtydx.Text = mo_lq.N_DXTY.ToString();
            this.lblqdzdx.Text = mo_lq.N_DXDZ.ToString();
            this.lblqdcdx.Text = mo_lq.N_DXDC.ToString();
            this.lblqdddx.Text = mo_lq.N_DXDD.ToString();
            this.lblqtydy.Text = mo_lq.N_DYTY.ToString();
            this.lblqdzdy.Text = mo_lq.N_DYDZ.ToString();
            this.lblqdcdy.Text = mo_lq.N_DYDC.ToString();
            this.lblqdddy.Text = mo_lq.N_DYDD.ToString();
            this.lblqtyds.Text = mo_lq.N_DSTY.ToString();
            this.lblqdzds.Text = mo_lq.N_DSDZ.ToString();
            this.lblqdcds.Text = mo_lq.N_DSDC.ToString();
            this.lblqddds.Text = mo_lq.N_DSDD.ToString();
            this.lblqtyzdrf.Text = mo_lq.N_ZDRFTY.ToString();
            this.lblqdzzdrf.Text = mo_lq.N_ZDRFDZ.ToString();
            this.lblqdczdrf.Text = mo_lq.N_ZDRFDC.ToString();
            this.lblqddzdrf.Text = mo_lq.N_ZDRFDD.ToString();
            this.lblqtyzddx.Text = mo_lq.N_ZDDXTY.ToString();
            this.lblqdzzddx.Text = mo_lq.N_ZDDXDZ.ToString();
            this.lblqdczddx.Text = mo_lq.N_ZDDXDC.ToString();
            this.lblqddzddx.Text = mo_lq.N_ZDDXDD.ToString();
            this.lblqtybcrf.Text = mo_lq.N_BCRFTY.ToString();
            this.lblqdzbcrf.Text = mo_lq.N_BCRFDZ.ToString();
            this.lblqdcbcrf.Text = mo_lq.N_BCRFDC.ToString();
            this.lblqddbcrf.Text = mo_lq.N_BCRFDD.ToString();
            this.lblqtybcdx.Text = mo_lq.N_BCDXTY.ToString();
            this.lblqdzbcdx.Text = mo_lq.N_BCDXDZ.ToString();
            this.lblqdcbcdx.Text = mo_lq.N_BCDXDC.ToString();
            this.lblqddbcdx.Text = mo_lq.N_BCDXDD.ToString();
            this.lblqtybcdy.Text = mo_lq.N_BCDYTY.ToString();
            this.lblqdzbcdy.Text = mo_lq.N_BCDYDZ.ToString();
            this.lblqdcbcdy.Text = mo_lq.N_BCDYDC.ToString();
            this.lblqddbcdy.Text = mo_lq.N_BCDYDD.ToString();
            this.lblqtybcds.Text = mo_lq.N_BCDSTY.ToString();
            this.lblqdzbcds.Text = mo_lq.N_BCDSDZ.ToString();
            this.lblqdcbcds.Text = mo_lq.N_BCDSDC.ToString();
            this.lblqddbcds.Text = mo_lq.N_BCDSDD.ToString();
            this.lblqtygg.Text = mo_lq.N_GGTY.ToString();
            this.lblqdzgg.Text = mo_lq.N_GGDZ.ToString();
            this.lblqdcgg.Text = mo_lq.N_GGDC.ToString();
            this.lblqddgg.Text = mo_lq.N_GGDD.ToString();
            this.lblqtygj.Text = mo_lq.N_GJTY.ToString();
            this.lblqdzgj.Text = mo_lq.N_GJDZ.ToString();
            this.lblqdcgj.Text = mo_lq.N_GJDC.ToString();
            this.lblqddgj.Text = mo_lq.N_GJDD.ToString();
            this.lblqtydjrf.Text = mo_lq.N_DJRFTY.ToString();
            this.lblqdzdjrf.Text = mo_lq.N_DJRFDZ.ToString();
            this.lblqdcdjrf.Text = mo_lq.N_DJRFDC.ToString();
            this.lblqdddjrf.Text = mo_lq.N_DJRFDD.ToString();
            this.lblqtydjdx.Text = mo_lq.N_DJDXTY.ToString();
            this.lblqdzdjdx.Text = mo_lq.N_DJDXDZ.ToString();
            this.lblqdcdjdx.Text = mo_lq.N_DJDXDC.ToString();
            this.lblqdddjdx.Text = mo_lq.N_DJDXDD.ToString();
            this.lblqtydjds.Text = mo_lq.N_DJDSTY.ToString();
            this.lblqdzdjds.Text = mo_lq.N_DJDSDZ.ToString();
            this.lblqdcdjds.Text = mo_lq.N_DJDSDC.ToString();
            this.lblqdddjds.Text = mo_lq.N_DJDSDD.ToString();
            #endregion
            KFB_SETUPMB mo_MB = this.objAgentManageAddDB.GetModelMB(strzh);
            //棒球 
            #region
            this.lbmbtyrf.Text = mo_MB.N_RFTY.ToString();
            this.lbmbdzrf.Text = mo_MB.N_RFDZ.ToString();
            this.lbmbdcrf.Text = mo_MB.N_RFDC.ToString();
            this.lbmbtydx.Text = mo_MB.N_DXTY.ToString();
            this.lbmbdzdx.Text = mo_MB.N_DXDZ.ToString();
            this.lbmbdcdx.Text = mo_MB.N_DXDC.ToString();
            this.lbmbtydy.Text = mo_MB.N_DYTY.ToString();
            this.lbmbdzdy.Text = mo_MB.N_DYDZ.ToString();
            this.lbmbdcdy.Text = mo_MB.N_DYDC.ToString();
            this.lbmbtyds.Text = mo_MB.N_DSTY.ToString();
            this.lbmbdzds.Text = mo_MB.N_DSDZ.ToString();
            this.lbmbdcds.Text = mo_MB.N_DSDC.ToString();
            this.lbmbtyzdrf.Text = mo_MB.N_ZDRFTY.ToString();
            this.lbmbdzzdrf.Text = mo_MB.N_ZDRFDZ.ToString();
            this.lbmbdczdrf.Text = mo_MB.N_ZDRFDC.ToString();
            this.lbmbtyzddx.Text = mo_MB.N_ZDDXTY.ToString();
            this.lbmbdzzddx.Text = mo_MB.N_ZDDXDZ.ToString();
            this.lbmbdczddx.Text = mo_MB.N_ZDDXDC.ToString();
            this.lbmbtysy.Text = mo_MB.N_SYTY.ToString();
            this.lbmbdzsy.Text = mo_MB.N_SYDZ.ToString();
            this.lbmbdcsy.Text = mo_MB.N_SYDC.ToString();
            this.lbmbtygg.Text = mo_MB.N_GGTY.ToString();
            this.lbmbdzgg.Text = mo_MB.N_GGDZ.ToString();
            this.lbmbdcgg.Text = mo_MB.N_GGDC.ToString();
            this.lbmbtybcrf.Text = mo_MB.N_GJTY.ToString();
            this.lbmbdzbcrf.Text = mo_MB.N_GJDZ.ToString();
            this.lbmbdcbcrf.Text = mo_MB.N_GJDC.ToString();
            #endregion
            KFB_SETUPRB mo_RB = this.objAgentManageAddDB.GetModelRB(strzh);
            //网球 
            #region
            this.lbrbtyrf.Text = mo_RB.N_RFTY.ToString();
            this.lbrbdzrf.Text = mo_RB.N_RFDZ.ToString();
            this.lbrbdcrf.Text = mo_RB.N_RFDC.ToString();
            this.lbrbtydx.Text = mo_RB.N_DXTY.ToString();
            this.lbrbdzdx.Text = mo_RB.N_DXDZ.ToString();
            this.lbrbdcdx.Text = mo_RB.N_DXDC.ToString();
            this.lbrbtydy.Text = mo_RB.N_DYTY.ToString();
            this.lbrbdzdy.Text = mo_RB.N_DYDZ.ToString();
            this.lbrbdcdy.Text = mo_RB.N_DYDC.ToString();
            this.lbrbtyds.Text = mo_RB.N_DSTY.ToString();
            this.lbrbdzds.Text = mo_RB.N_DSDZ.ToString();
            this.lbrbdcds.Text = mo_RB.N_DSDC.ToString();
            this.lbrbtyzdrf.Text = mo_RB.N_ZDRFTY.ToString();
            this.lbrbdzzdrf.Text = mo_RB.N_ZDRFDZ.ToString();
            this.lbrbdczdrf.Text = mo_RB.N_ZDRFDC.ToString();
            this.lbrbtyzddx.Text = mo_RB.N_ZDDXTY.ToString();
            this.lbrbdzzddx.Text = mo_RB.N_ZDDXDZ.ToString();
            this.lbrbdczddx.Text = mo_RB.N_ZDDXDC.ToString();
            this.lbrbtysy.Text = mo_RB.N_SYTY.ToString();
            this.lbrbdzsy.Text = mo_RB.N_SYDZ.ToString();
            this.lbrbdcsy.Text = mo_RB.N_SYDC.ToString();
            this.lbrbtygg.Text = mo_RB.N_GGTY.ToString();
            this.lbrbdzgg.Text = mo_RB.N_GGDZ.ToString();
            this.lbrbdcgg.Text = mo_RB.N_GGDC.ToString();
            this.lbrbtybcrf.Text = mo_RB.N_GJTY.ToString();
            this.lbrbdzbcrf.Text = mo_RB.N_GJDZ.ToString();
            this.lbrbdcbcrf.Text = mo_RB.N_GJDC.ToString();
            #endregion
            //排球 
            #region
            KFB_SETUPTB mo_TB = this.objAgentManageAddDB.GetModelTB(strzh);
            this.lbtbtyrf.Text = mo_TB.N_RFTY.ToString();
            this.lbtbdzrf.Text = mo_TB.N_RFDZ.ToString();
            this.lbtbdcrf.Text = mo_TB.N_RFDC.ToString();
            this.lbtbtydx.Text = mo_TB.N_DXTY.ToString();
            this.lbtbdzdx.Text = mo_TB.N_DXDZ.ToString();
            this.lbtbdcdx.Text = mo_TB.N_DXDC.ToString();
            this.lbtbtydy.Text = mo_TB.N_DYTY.ToString();
            this.lbtbdzdy.Text = mo_TB.N_DYDZ.ToString();
            this.lbtbdcdy.Text = mo_TB.N_DYDC.ToString();
            this.lbtbtyds.Text = mo_TB.N_DSTY.ToString();
            this.lbtbdzds.Text = mo_TB.N_DSDZ.ToString();
            this.lbtbdcds.Text = mo_TB.N_DSDC.ToString();
            this.lbtbtyzdrf.Text = mo_TB.N_ZDRFTY.ToString();
            this.lbtbdzzdrf.Text = mo_TB.N_ZDRFDZ.ToString();
            this.lbtbdczdrf.Text = mo_TB.N_ZDRFDC.ToString();
            this.lbtbtyzddx.Text = mo_TB.N_ZDDXTY.ToString();
            this.lbtbdzzddx.Text = mo_TB.N_ZDDXDZ.ToString();
            this.lbtbdczddx.Text = mo_TB.N_ZDDXDC.ToString();
            this.lbtbtysy.Text = mo_TB.N_SYTY.ToString();
            this.lbtbdzsy.Text = mo_TB.N_SYDZ.ToString();
            this.lbtbdcsy.Text = mo_TB.N_SYDC.ToString();
            this.lbtbtygg.Text = mo_TB.N_GGTY.ToString();
            this.lbtbdzgg.Text = mo_TB.N_GGDZ.ToString();
            this.lbtbdcgg.Text = mo_TB.N_GGDC.ToString();
            this.lbtbtybcrf.Text = mo_TB.N_GJTY.ToString();
            this.lbtbdzbcrf.Text = mo_TB.N_GJDZ.ToString();
            this.lbtbdcbcrf.Text = mo_TB.N_GJDC.ToString();
            #endregion
            //足 球 
            #region
            KFB_SETUPZQ mo_ZQ = objAgentManageAddDB.GetModelZQ(strzh);
            this.lbzqtyarf.Text = mo_ZQ.N_ARFTY.ToString();
            this.lbzqtybrf.Text = mo_ZQ.N_BRFTY.ToString();
            this.lbzqtycrf.Text = mo_ZQ.N_CRFTY.ToString();
            this.lbzqdzrf.Text = mo_ZQ.N_RFDZ.ToString();
            this.lbzqdcrf.Text = mo_ZQ.N_RFDC.ToString();
            this.lbzqtyadx.Text = mo_ZQ.N_ADXTY.ToString();
            this.lbzqtybdx.Text = mo_ZQ.N_BDXTY.ToString();
            this.lbzqtycdx.Text = mo_ZQ.N_CDXTY.ToString();
            this.lbzqdzdx.Text = mo_ZQ.N_DXDZ.ToString();
            this.lbzqdcdx.Text = mo_ZQ.N_DXDC.ToString();
            this.lbzqtyady.Text = mo_ZQ.N_ADYTY.ToString();
            this.lbzqtybdy.Text = mo_ZQ.N_BDYTY.ToString();
            this.lbzqtycdy.Text = mo_ZQ.N_CDYTY.ToString();
            this.lbzqdzdy.Text = mo_ZQ.N_DYDZ.ToString();
            this.lbzqdcdy.Text = mo_ZQ.N_DYDC.ToString();
            this.lbzqtyads.Text = mo_ZQ.N_ADSTY.ToString();
            this.lbzqtybds.Text = mo_ZQ.N_BDSTY.ToString();
            this.lbzqtycds.Text = mo_ZQ.N_CDSTY.ToString();
            this.lbzqdzds.Text = mo_ZQ.N_DSDZ.ToString();
            this.lbzqdcds.Text = mo_ZQ.N_DSDC.ToString();
            this.lbzqtyazdrf.Text = mo_ZQ.N_AZDRFTY.ToString();
            this.lbzqtybzdrf.Text = mo_ZQ.N_BZDRFTY.ToString();
            this.lbzqtyczdrf.Text = mo_ZQ.N_CZDRFTY.ToString();
            this.lbzqdzzdrf.Text = mo_ZQ.N_ZDRFDZ.ToString();
            this.lbzqdczdrf.Text = mo_ZQ.N_ZDRFDC.ToString();
            this.lbzqtyazddx.Text = mo_ZQ.N_AZDDXTY.ToString();
            this.lbzqtybzddx.Text = mo_ZQ.N_BZDDXTY.ToString();
            this.lbzqtyczddx.Text = mo_ZQ.N_CZDDXTY.ToString();
            this.lbzqdzzddx.Text = mo_ZQ.N_ZDDXDZ.ToString();
            this.lbzqdczddx.Text = mo_ZQ.N_ZDDXDC.ToString();
            this.lbzqtyabcrf.Text = mo_ZQ.N_ABCRFTY.ToString();
            this.lbzqtybbcrf.Text = mo_ZQ.N_BBCRFTY.ToString();
            this.lbzqtycbcrf.Text = mo_ZQ.N_CBCRFTY.ToString();
            this.lbzqdzbcrf.Text = mo_ZQ.N_BCRFDZ.ToString();
            this.lbzqdcbcrf.Text = mo_ZQ.N_BCRFDC.ToString();
            this.lbzqtyabcdx.Text = mo_ZQ.N_ABCDXTY.ToString();
            this.lbzqtybbcdx.Text = mo_ZQ.N_BBCDXTY.ToString();
            this.lbzqtycbcdx.Text = mo_ZQ.N_CBCDXTY.ToString();
            this.lbzqdzbcdx.Text = mo_ZQ.N_BCDXDZ.ToString();
            this.lbzqdcbcdx.Text = mo_ZQ.N_BCDXDC.ToString();
            this.lbzqtyabcdy.Text = mo_ZQ.N_ABCDYTY.ToString();
            this.lbzqtybbcdy.Text = mo_ZQ.N_BBCDYTY.ToString();
            this.lbzqtycbcdy.Text = mo_ZQ.N_CBCDYTY.ToString();
            this.lbzqdzbcdy.Text = mo_ZQ.N_BCDYDZ.ToString();
            this.lbzqdcbcdy.Text = mo_ZQ.N_BCDYDC.ToString();
            this.lbzqtyarqs.Text = mo_ZQ.N_ARQSTY.ToString();
            this.lbzqtybrqs.Text = mo_ZQ.N_BRQSTY.ToString();
            this.lbzqtycrqs.Text = mo_ZQ.N_CRQSTY.ToString();
            this.lbzqdzrqs.Text = mo_ZQ.N_RQSDZ.ToString();
            this.lbzqdcrqs.Text = mo_ZQ.N_RQSDC.ToString();
            this.lbzqtyabd.Text = mo_ZQ.N_ABDTY.ToString();
            this.lbzqtybbd.Text = mo_ZQ.N_BBDTY.ToString();
            this.lbzqtycbd.Text = mo_ZQ.N_CBDTY.ToString();
            this.lbzqdzbd.Text = mo_ZQ.N_BDDZ.ToString();
            this.lbzqdcbd.Text = mo_ZQ.N_BDDC.ToString();
            this.lbzqtyabqc.Text = mo_ZQ.N_ABQCTY.ToString();
            this.lbzqtybbqc.Text = mo_ZQ.N_BBQCTY.ToString();
            this.lbzqtycbqc.Text = mo_ZQ.N_CBQCTY.ToString();
            this.lbzqdzbqc.Text = mo_ZQ.N_BQCDZ.ToString();
            this.lbzqdcbqc.Text = mo_ZQ.N_BQCDC.ToString();
            this.lbzqtyagg.Text = mo_ZQ.N_AGGTY.ToString();
            this.lbzqtybgg.Text = mo_ZQ.N_BGGTY.ToString();
            this.lbzqtycgg.Text = mo_ZQ.N_CGGTY.ToString();
            this.lbzqdzgg.Text = mo_ZQ.N_GGDZ.ToString();
            this.lbzqdcgg.Text = mo_ZQ.N_GGDC.ToString();
            this.lbzqtyagj.Text = mo_ZQ.N_AGJTY.ToString();
            this.lbzqtybgj.Text = mo_ZQ.N_BGJTY.ToString();
            this.lbzqtycgj.Text = mo_ZQ.N_CGJTY.ToString();
            this.lbzqdzgj.Text = mo_ZQ.N_GJDZ.ToString();
            this.lbzqdcgj.Text = mo_ZQ.N_GJDC.ToString();
            #endregion
            //美足
            #region
            KFB_SETUPMQ mo_MQ = objAgentManageAddDB.GetModelMQ(strzh);
            this.lbmztyrf.Text = mo_MQ.N_RFTY.ToString();
            this.lbmzdzrf.Text = mo_MQ.N_RFDZ.ToString();
            this.lbmzdcrf.Text = mo_MQ.N_RFDC.ToString();
            this.lbmztydx.Text = mo_MQ.N_DXTY.ToString();
            this.lbmzdzdx.Text = mo_MQ.N_DXDZ.ToString();
            this.lbmzdcdx.Text = mo_MQ.N_DXDC.ToString();
            this.lbmztydy.Text = mo_MQ.N_DYTY.ToString();
            this.lbmzdzdy.Text = mo_MQ.N_DYDZ.ToString();
            this.lbmzdcdy.Text = mo_MQ.N_DYDC.ToString();
            this.lbmztyds.Text = mo_MQ.N_DSTY.ToString();
            this.lbmzdzds.Text = mo_MQ.N_DSDZ.ToString();
            this.lbmzdcds.Text = mo_MQ.N_DSDC.ToString();
            this.lbmztyzdrf.Text = mo_MQ.N_ZDRFTY.ToString();
            this.lbmzdzzdrf.Text = mo_MQ.N_ZDRFDZ.ToString();
            this.lbmzdczdrf.Text = mo_MQ.N_ZDRFDC.ToString();
            this.lbmztyzddx.Text = mo_MQ.N_ZDDXTY.ToString();
            this.lbmzdzzddx.Text = mo_MQ.N_ZDDXDZ.ToString();
            this.lbmzdczddx.Text = mo_MQ.N_ZDDXDC.ToString();
            this.lbmztybcrf.Text = mo_MQ.N_BCRFTY.ToString();
            this.lbmzdzbcrf.Text = mo_MQ.N_BCRFDZ.ToString();
            this.lbmzdcbcrf.Text = mo_MQ.N_BCRFDC.ToString();
            this.lbmztybcdx.Text = mo_MQ.N_BCDXTY.ToString();
            this.lbmzdzbcdx.Text = mo_MQ.N_BCDXDZ.ToString();
            this.lbmzdcbcdx.Text = mo_MQ.N_BCDXDC.ToString();
            this.lbmztybcdy.Text = mo_MQ.N_BCDYTY.ToString();
            this.lbmzdzbcdy.Text = mo_MQ.N_BCDYDZ.ToString();
            this.lbmzdcbcdy.Text = mo_MQ.N_BCDYDC.ToString();
            this.lbmztybcds.Text = mo_MQ.N_BCDSTY.ToString();
            this.lbmzdzbcds.Text = mo_MQ.N_BCDSDZ.ToString();
            this.lbmzdcbcds.Text = mo_MQ.N_BCDSDC.ToString();
            this.lbmztygg.Text = mo_MQ.N_GGTY.ToString();
            this.lbmzdzgg.Text = mo_MQ.N_GGDZ.ToString();
            this.lbmzdcgg.Text = mo_MQ.N_GGDC.ToString();
            this.lbmztygj.Text = mo_MQ.N_GJTY.ToString();
            this.lbmzdzgj.Text = mo_MQ.N_GJDZ.ToString();
            this.lbmzdcgj.Text = mo_MQ.N_GJDC.ToString();
            #endregion
            KFB_SETUPBQ mo_BQ = objAgentManageAddDB.GetModelBQ(strzh);
            //冰球
            #region
            this.lbbqtyrf.Text = mo_BQ.N_RFTY.ToString();
            this.lbbqdzrf.Text = mo_BQ.N_RFDZ.ToString();
            this.lbbqdcrf.Text = mo_BQ.N_RFDC.ToString();
            this.lbbqtydx.Text = mo_BQ.N_DXTY.ToString();
            this.lbbqdzdx.Text = mo_BQ.N_DXDZ.ToString();
            this.lbbqdcdx.Text = mo_BQ.N_DXDC.ToString();
            this.lbbqtydy.Text = mo_BQ.N_DYTY.ToString();
            this.lbbqdzdy.Text = mo_BQ.N_DYDZ.ToString();
            this.lbbqdcdy.Text = mo_BQ.N_DYDC.ToString();
            this.lbbqtyds.Text = mo_BQ.N_DSTY.ToString();
            this.lbbqdzds.Text = mo_BQ.N_DSDZ.ToString();
            this.lbbqdcds.Text = mo_BQ.N_DSDC.ToString();
            this.lbbqtyzdrf.Text = mo_BQ.N_ZDRFTY.ToString();
            this.lbbqdzzdrf.Text = mo_BQ.N_ZDRFDZ.ToString();
            this.lbbqdczdrf.Text = mo_BQ.N_ZDRFDC.ToString();
            this.lbbqtyzddx.Text = mo_BQ.N_ZDDXTY.ToString();
            this.lbbqdzzddx.Text = mo_BQ.N_ZDDXDZ.ToString();
            this.lbbqdczddx.Text = mo_BQ.N_ZDDXDC.ToString();
            this.lbbqtysy.Text = mo_BQ.N_SYTY.ToString();
            this.lbbqdzsy.Text = mo_BQ.N_SYDZ.ToString();
            this.lbbqdcsy.Text = mo_BQ.N_SYDC.ToString();
            this.lbbqtygg.Text = mo_BQ.N_GGTY.ToString();
            this.lbbqdzgg.Text = mo_BQ.N_GGDZ.ToString();
            this.lbbqdcgg.Text = mo_BQ.N_GGDC.ToString();
            this.lbbqtybcrf.Text = mo_BQ.N_GJTY.ToString();
            this.lbbqdzbcrf.Text = mo_BQ.N_GJDZ.ToString();
            this.lbbqdcbcrf.Text = mo_BQ.N_GJDC.ToString();
            #endregion
            //彩球
            #region
            KFB_SETUPCQ mo_CQ = objAgentManageAddDB.GetModelCQ(strzh);
            this.lbcqtyrf.Text = mo_CQ.N_RFTY.ToString();
            this.lbcqdzrf.Text = mo_CQ.N_RFDZ.ToString();
            this.lbcqdcrf.Text = mo_CQ.N_RFDC.ToString();
            this.lbcqtydx.Text = mo_CQ.N_DXTY.ToString();
            this.lbcqdzdx.Text = mo_CQ.N_DXDZ.ToString();
            this.lbcqdcdx.Text = mo_CQ.N_DXDC.ToString();
            this.lbcqtydy.Text = mo_CQ.N_DYTY.ToString();
            this.lbcqdzdy.Text = mo_CQ.N_DYDZ.ToString();
            this.lbcqdcdy.Text = mo_CQ.N_DYDC.ToString();
            this.lbcqtyds.Text = mo_CQ.N_DSTY.ToString();
            this.lbcqdzds.Text = mo_CQ.N_DSDZ.ToString();
            this.lbcqdcds.Text = mo_CQ.N_DSDC.ToString();
            this.lbcqtyzdrf.Text = mo_CQ.N_ZDRFTY.ToString();
            this.lbcqdzzdrf.Text = mo_CQ.N_ZDRFDZ.ToString();
            this.lbcqdczdrf.Text = mo_CQ.N_ZDRFDC.ToString();
            this.lbcqtyzddx.Text = mo_CQ.N_ZDDXTY.ToString();
            this.lbcqdzzddx.Text = mo_CQ.N_ZDDXDZ.ToString();
            this.lbcqdczddx.Text = mo_CQ.N_ZDDXDC.ToString();
            this.lbcqtybcrf.Text = mo_CQ.N_BCRFTY.ToString();
            this.lbcqdzbcrf.Text = mo_CQ.N_BCRFDZ.ToString();
            this.lbcqdcbcrf.Text = mo_CQ.N_BCRFDC.ToString();
            this.lbcqtybcdx.Text = mo_CQ.N_BCDXTY.ToString();
            this.lbcqdzbcdx.Text = mo_CQ.N_BCDXDZ.ToString();
            this.lbcqdcbcdx.Text = mo_CQ.N_BCDXDC.ToString();
            this.lbcqtybcdy.Text = mo_CQ.N_BCDYTY.ToString();
            this.lbcqdzbcdy.Text = mo_CQ.N_BCDYDZ.ToString();
            this.lbcqdcbcdy.Text = mo_CQ.N_BCDYDC.ToString();
            this.lbcqtybcds.Text = mo_CQ.N_BCDSTY.ToString();
            this.lbcqdzbcds.Text = mo_CQ.N_BCDSDZ.ToString();
            this.lbcqdcbcds.Text = mo_CQ.N_BCDSDC.ToString();
            this.lbcqtygg.Text = mo_CQ.N_GGTY.ToString();
            this.lbcqdzgg.Text = mo_CQ.N_GGDZ.ToString();
            this.lbcqdcgg.Text = mo_CQ.N_GGDC.ToString();
            this.lbcqtygj.Text = mo_CQ.N_GJTY.ToString();
            this.lbcqdzgj.Text = mo_CQ.N_GJDZ.ToString();
            this.lbcqdcgj.Text = mo_CQ.N_GJDC.ToString();
            #endregion
            //指数
            #region
            KFB_SETUPZS mo_ZS = objAgentManageAddDB.GetModelZS(strzh);
            this.lbzstyrf.Text = mo_ZS.N_RFTY.ToString();
            this.lbzsdzrf.Text = mo_ZS.N_RFDZ.ToString();
            this.lbzsdcrf.Text = mo_ZS.N_RFDC.ToString();
            this.lbzstydx.Text = mo_ZS.N_DXTY.ToString();
            this.lbzsdzdx.Text = mo_ZS.N_DXDZ.ToString();
            this.lbzsdcdx.Text = mo_ZS.N_DXDC.ToString();
            this.lbzstydy.Text = mo_ZS.N_DYTY.ToString();
            this.lbzsdzdy.Text = mo_ZS.N_DYDZ.ToString();
            this.lbzsdcdy.Text = mo_ZS.N_DYDC.ToString();
            this.lbzstyds.Text = mo_ZS.N_DSTY.ToString();
            this.lbzsdzds.Text = mo_ZS.N_DSDZ.ToString();
            this.lbzsdcds.Text = mo_ZS.N_DSDC.ToString();
            this.lbzstyzdrf.Text = mo_ZS.N_ZDRFTY.ToString();
            this.lbzsdzzdrf.Text = mo_ZS.N_ZDRFDZ.ToString();
            this.lbzsdczdrf.Text = mo_ZS.N_ZDRFDC.ToString();
            this.lbzstyzddx.Text = mo_ZS.N_ZDDXTY.ToString();
            this.lbzsdzzddx.Text = mo_ZS.N_ZDDXDZ.ToString();
            this.lbzsdczddx.Text = mo_ZS.N_ZDDXDC.ToString();
            this.lbzstysy.Text = mo_ZS.N_SYTY.ToString();
            this.lbzsdzsy.Text = mo_ZS.N_SYDZ.ToString();
            this.lbzsdcsy.Text = mo_ZS.N_SYDC.ToString();
            this.lbzstybd.Text = mo_ZS.N_BDTY.ToString();
            this.lbzsdzbd.Text = mo_ZS.N_BDDZ.ToString();
            this.lbzsdcbd.Text = mo_ZS.N_BDDC.ToString();
            this.lbzstygg.Text = mo_ZS.N_GGTY.ToString();
            this.lbzsdzgg.Text = mo_ZS.N_GGDZ.ToString();
            this.lbzsdcgg.Text = mo_ZS.N_GGDC.ToString();
            this.lbzstygj.Text = mo_ZS.N_GJTY.ToString();
            this.lbzsdzgj.Text = mo_ZS.N_GJDZ.ToString();
            this.lbzsdcgj.Text = mo_ZS.N_GJDC.ToString();
            #endregion
            //赛马
            #region
            KFB_SETUPSM mo_SM = objAgentManageAddDB.GetModelSM(strzh);
            this.lbsmtydy.Text = mo_SM.N_DYTY.ToString();
            this.lbsmdzdy.Text = mo_SM.N_DYDZ.ToString();
            this.lbsmdcdy.Text = mo_SM.N_DYDC.ToString();
            this.lbsmtywz.Text = mo_SM.N_WZTY.ToString();
            this.lbsmdzwz.Text = mo_SM.N_WZDZ.ToString();
            this.lbsmdcwz.Text = mo_SM.N_WZDC.ToString();
            this.lbsmtyly.Text = mo_SM.N_LYTY.ToString();
            this.lbsmdzly.Text = mo_SM.N_LYDZ.ToString();
            this.lbsmdcly.Text = mo_SM.N_LYDC.ToString();
            this.lbsmtywzq.Text = mo_SM.N_WZQTY.ToString();
            this.lbsmdzwzq.Text = mo_SM.N_WZQDZ.ToString();
            this.lbsmdcwzq.Text = mo_SM.N_WZQDC.ToString();
            #endregion

            //六合彩
            #region
            KFB_SETUPLHC mo_LHC = objAgentManageAddDB.GetModelLHC(strzh);
            this.lblhctytbh.Text = mo_LHC.N_TBHTY.ToString();
            this.lblhcdztbh.Text = mo_LHC.N_TBHDZ.ToString();
            this.lblhcdctbh.Text = mo_LHC.N_TBHDC.ToString();
            this.lblhctytt.Text = mo_LHC.N_TTTY.ToString();
            this.lblhcdztt.Text = mo_LHC.N_TTDZ.ToString();
            this.lblhcdctt.Text = mo_LHC.N_TTDC.ToString();
            this.lblhctyth.Text = mo_LHC.N_THTY.ToString();
            this.lblhcdzth.Text = mo_LHC.N_THDZ.ToString();
            this.lblhcdcth.Text = mo_LHC.N_THDC.ToString();
            this.lblhctyqcp.Text = mo_LHC.N_QCPTY.ToString();
            this.lblhcdzqcp.Text = mo_LHC.N_QCPDZ.ToString();
            this.lblhcdcqcp.Text = mo_LHC.N_QCPDC.ToString();
            this.lblhcty2x.Text = mo_LHC.N_2XTY.ToString();
            this.lblhcdz2x.Text = mo_LHC.N_2XDZ.ToString();
            this.lblhcdc2x.Text = mo_LHC.N_2XDC.ToString();
            this.lblhcty3x.Text = mo_LHC.N_3XTY.ToString();
            this.lblhcdz3x.Text = mo_LHC.N_3XDZ.ToString();
            this.lblhcdc3x.Text = mo_LHC.N_3XDC.ToString();
            this.lblhcty4x.Text = mo_LHC.N_4XTY.ToString();
            this.lblhcdz4x.Text = mo_LHC.N_4XDZ.ToString();
            this.lblhcdc4x.Text = mo_LHC.N_4XDC.ToString();
            this.lblhctygdds.Text = mo_LHC.N_GDDSTY.ToString();
            this.lblhcdzgdds.Text = mo_LHC.N_GDDSDZ.ToString();
            this.lblhcdcgdds.Text = mo_LHC.N_GDDSDC.ToString();
            this.lblhctygddx.Text = mo_LHC.N_GDDXTY.ToString();
            this.lblhcdzgddx.Text = mo_LHC.N_GDDXDZ.ToString();
            this.lblhcdcgddx.Text = mo_LHC.N_GDDXDC.ToString();
            #endregion

            //大乐透
            #region
            KFB_SETUPDLT mo_DLT = objAgentManageAddDB.GetModelDLT(strzh);
            this.lbdlttytbh.Text = mo_DLT.N_TBHTY.ToString();
            this.lbdltdztbh.Text = mo_DLT.N_TBHDZ.ToString();
            this.lbdltdctbh.Text = mo_DLT.N_TBHDC.ToString();
            this.lbdlttytt.Text = mo_DLT.N_TTTY.ToString();
            this.lbdltdztt.Text = mo_DLT.N_TTDZ.ToString();
            this.lbdltdctt.Text = mo_DLT.N_TTDC.ToString();
            this.lbdlttyth.Text = mo_DLT.N_THTY.ToString();
            this.lbdltdzth.Text = mo_DLT.N_THDZ.ToString();
            this.lbdltdcth.Text = mo_DLT.N_THDC.ToString();
            this.lbdlttyqcp.Text = mo_DLT.N_QCPTY.ToString();
            this.lbdltdzqcp.Text = mo_DLT.N_QCPDZ.ToString();
            this.lbdltdcqcp.Text = mo_DLT.N_QCPDC.ToString();
            this.lbdltty2x.Text = mo_DLT.N_2XTY.ToString();
            this.lbdltdz2x.Text = mo_DLT.N_2XDZ.ToString();
            this.lbdltdc2x.Text = mo_DLT.N_2XDC.ToString();
            this.lbdltty3x.Text = mo_DLT.N_3XTY.ToString();
            this.lbdltdz3x.Text = mo_DLT.N_3XDZ.ToString();
            this.lbdltdc3x.Text = mo_DLT.N_3XDC.ToString();
            this.lbdltty4x.Text = mo_DLT.N_4XTY.ToString();
            this.lbdltdz4x.Text = mo_DLT.N_4XDZ.ToString();
            this.lbdltdc4x.Text = mo_DLT.N_4XDC.ToString();
            this.lbdlttygdds.Text = mo_DLT.N_GDDSTY.ToString();
            this.lbdltdzgdds.Text = mo_DLT.N_GDDSDZ.ToString();
            this.lbdltdcgdds.Text = mo_DLT.N_GDDSDC.ToString();
            this.lbdlttygddx.Text = mo_DLT.N_GDDXTY.ToString();
            this.lbdltdzgddx.Text = mo_DLT.N_GDDXDZ.ToString();
            this.lbdltdcgddx.Text = mo_DLT.N_GDDXDC.ToString();
            #endregion
            //JC539
            #region
            KFB_SETUPJC539 mo_JC539 = objAgentManageAddDB.GetModelJC539(strzh);
            this.lbjc539tyqcp.Text = mo_JC539.N_QCPTY.ToString();
            this.lbjc539dzqcp.Text = mo_JC539.N_QCPDZ.ToString();
            this.lbjc539dcqcp.Text = mo_JC539.N_QCPDC.ToString();
            this.lbjc539ty2x.Text = mo_JC539.N_2XTY.ToString();
            this.lbjc539dz2x.Text = mo_JC539.N_2XDZ.ToString();
            this.lbjc539dc2x.Text = mo_JC539.N_2XDC.ToString();
            this.lbjc539ty3x.Text = mo_JC539.N_3XTY.ToString();
            this.lbjc539dz3x.Text = mo_JC539.N_3XDZ.ToString();
            this.lbjc539dc3x.Text = mo_JC539.N_3XDC.ToString();
            this.lbjc539ty4x.Text = mo_JC539.N_4XTY.ToString();
            this.lbjc539dz4x.Text = mo_JC539.N_4XDZ.ToString();
            this.lbjc539dc4x.Text = mo_JC539.N_4XDC.ToString();
            #endregion
            //运动彩票
            #region
            KFB_SETUPCP mo_CP = objAgentManageAddDB.GetModelCP(strzh);
            this.lbcptybq.Text = mo_CP.N_BQTY.ToString();
            this.lbcpdzbq.Text = mo_CP.N_BQDZ.ToString();
            this.lbcpdcbq.Text = mo_CP.N_BQDC.ToString();
            this.lbcptylq.Text = mo_CP.N_LQTY.ToString();
            this.lbcpdzlq.Text = mo_CP.N_LQDZ.ToString();
            this.lbcpdclq.Text = mo_CP.N_LQDC.ToString();
            this.lbcptyzq.Text = mo_CP.N_ZQTY.ToString();
            this.lbcpdzzq.Text = mo_CP.N_ZQDZ.ToString();
            this.lbcpdczq.Text = mo_CP.N_ZQDC.ToString();
            this.lbcptygs.Text = mo_CP.N_GSTY.ToString();
            this.lbcpdzgs.Text = mo_CP.N_GSDZ.ToString();
            this.lbcpdcgs.Text = mo_CP.N_GSDC.ToString();
            this.lbcptyqz.Text = mo_CP.N_QZTY.ToString();
            this.lbcpdzqz.Text = mo_CP.N_QZDZ.ToString();
            this.lbcpdcqz.Text = mo_CP.N_QZDC.ToString();
            #endregion
            //時事
            #region
            KFB_SETUPSS mo_SS = objAgentManageAddDB.GetModelSS(strzh);
            this.lbsstydy.Text = mo_SS.N_DYTY.ToString();
            this.lbssdzdy.Text = mo_SS.N_DYDZ.ToString();
            this.lbssdcdy.Text = mo_SS.N_DYDC.ToString();
            #endregion
        }
        #endregion
        #region"取得下级最大值"
        public void MaxFZ()
        {
            string strSpName = "(" + Comm.GetLvSName(Convert.ToString(Convert.ToDecimal(strlvl) + 1)) + ")";
            KFB_ZHGL mo_zhgl = new KFB_ZHGL();

            mo_zhgl = objAgentManageAddDB.GetXJZH(strlvl, strparid);

            //拆帐赋值
            this.lbczlqt.Text = strSpName + mo_zhgl.N_LQCZ.ToString();
            this.lbczmbt.Text = strSpName + mo_zhgl.N_MBCZ.ToString();
            this.lbczrbt.Text = strSpName + mo_zhgl.N_RBCZ.ToString();
            this.lbcztbt.Text = strSpName + mo_zhgl.N_TBCZ.ToString();
            this.lbczmzt.Text = strSpName + mo_zhgl.N_MZCZ.ToString();
            this.lbczzqt.Text = strSpName + mo_zhgl.N_ZQCZ.ToString();
            this.lbczzst.Text = strSpName + mo_zhgl.N_ZSCZ.ToString();
            this.lbczdltt.Text = strSpName + mo_zhgl.N_DLTCZ.ToString();
            this.lbczsmt.Text = strSpName + mo_zhgl.N_SMCZ.ToString();
            this.lbczlhct.Text = strSpName + mo_zhgl.N_LHCCZ.ToString();
            this.lbcz2xt.Text = strSpName + mo_zhgl.N_2XCZ.ToString();
            this.lbcz3xt.Text = strSpName + mo_zhgl.N_3XCZ.ToString();
            this.lbcz4xt.Text = strSpName + mo_zhgl.N_4XCZ.ToString();
            this.lbczjc539t.Text = strSpName + mo_zhgl.N_JCCZ.ToString();
            this.lbczcpt.Text = strSpName + mo_zhgl.N_CPCZ.ToString();
            this.lbczsst.Text = strSpName + mo_zhgl.N_SSCZ.ToString();

            this.lbczbqt.Text = strSpName + mo_zhgl.N_BQCZ.ToString();
            this.lbczcqt.Text = strSpName + mo_zhgl.N_CQCZ.ToString();

            //篮球 
            #region

            KFB_SETUPLQ mo_lq = objAgentManageAddDB.GetModelLQ(strlvl, strparid);
            this.lblqtyrft.Text = strSpName + mo_lq.N_RFTY.ToString();
            this.lblqdzrft.Text = strSpName + mo_lq.N_RFDZ.ToString();
            this.lblqdcrft.Text = strSpName + mo_lq.N_RFDC.ToString();
            this.lblqddrft.Text = strSpName + mo_lq.N_RFDD.ToString();
            this.lblqtydxt.Text = strSpName + mo_lq.N_DXTY.ToString();
            this.lblqdzdxt.Text = strSpName + mo_lq.N_DXDZ.ToString();
            this.lblqdcdxt.Text = strSpName + mo_lq.N_DXDC.ToString();
            this.lblqdddxt.Text = strSpName + mo_lq.N_DXDD.ToString();
            this.lblqtydyt.Text = strSpName + mo_lq.N_DYTY.ToString();
            this.lblqdzdyt.Text = strSpName + mo_lq.N_DYDZ.ToString();
            this.lblqdcdyt.Text = strSpName + mo_lq.N_DYDC.ToString();
            this.lblqdddyt.Text = strSpName + mo_lq.N_DYDD.ToString();
            this.lblqtydst.Text = strSpName + mo_lq.N_DSTY.ToString();
            this.lblqdzdst.Text = strSpName + mo_lq.N_DSDZ.ToString();
            this.lblqdcdst.Text = strSpName + mo_lq.N_DSDC.ToString();
            this.lblqdddst.Text = strSpName + mo_lq.N_DSDD.ToString();
            this.lblqtyzdrft.Text = strSpName + mo_lq.N_ZDRFTY.ToString();
            this.lblqdzzdrft.Text = strSpName + mo_lq.N_ZDRFDZ.ToString();
            this.lblqdczdrft.Text = strSpName + mo_lq.N_ZDRFDC.ToString();
            this.lblqddzdrft.Text = strSpName + mo_lq.N_ZDRFDD.ToString();
            this.lblqtyzddxt.Text = strSpName + mo_lq.N_ZDDXTY.ToString();
            this.lblqdzzddxt.Text = strSpName + mo_lq.N_ZDDXDZ.ToString();
            this.lblqdczddxt.Text = strSpName + mo_lq.N_ZDDXDC.ToString();
            this.lblqddzddxt.Text = strSpName + mo_lq.N_ZDDXDD.ToString();
            this.lblqtybcrft.Text = strSpName + mo_lq.N_BCRFTY.ToString();
            this.lblqdzbcrft.Text = strSpName + mo_lq.N_BCRFDZ.ToString();
            this.lblqdcbcrft.Text = strSpName + mo_lq.N_BCRFDC.ToString();
            this.lblqddbcrft.Text = strSpName + mo_lq.N_BCRFDD.ToString();
            this.lblqtybcdxt.Text = strSpName + mo_lq.N_BCDXTY.ToString();
            this.lblqdzbcdxt.Text = strSpName + mo_lq.N_BCDXDZ.ToString();
            this.lblqdcbcdxt.Text = strSpName + mo_lq.N_BCDXDC.ToString();
            this.lblqddbcdxt.Text = strSpName + mo_lq.N_BCDXDD.ToString();
            this.lblqtybcdyt.Text = strSpName + mo_lq.N_BCDYTY.ToString();
            this.lblqdzbcdyt.Text = strSpName + mo_lq.N_BCDYDZ.ToString();
            this.lblqdcbcdyt.Text = strSpName + mo_lq.N_BCDYDC.ToString();
            this.lblqddbcdyt.Text = strSpName + mo_lq.N_BCDYDD.ToString();
            this.lblqtybcdst.Text = strSpName + mo_lq.N_BCDSTY.ToString();
            this.lblqdzbcdst.Text = strSpName + mo_lq.N_BCDSDZ.ToString();
            this.lblqdcbcdst.Text = strSpName + mo_lq.N_BCDSDC.ToString();
            this.lblqddbcdst.Text = strSpName + mo_lq.N_BCDSDD.ToString();
            this.lblqtyggt.Text = strSpName + mo_lq.N_GGTY.ToString();
            this.lblqdzggt.Text = strSpName + mo_lq.N_GGDZ.ToString();
            this.lblqdcggt.Text = strSpName + mo_lq.N_GGDC.ToString();
            this.lblqddggt.Text = strSpName + mo_lq.N_GGDD.ToString();
            this.lblqtygjt.Text = strSpName + mo_lq.N_GJTY.ToString();
            this.lblqdzgjt.Text = strSpName + mo_lq.N_GJDZ.ToString();
            this.lblqdcgjt.Text = strSpName + mo_lq.N_GJDC.ToString();
            this.lblqddgjt.Text = strSpName + mo_lq.N_GJDD.ToString();
            this.lblqtydjrft.Text = strSpName + mo_lq.N_DJRFTY.ToString();
            this.lblqdzdjrft.Text = strSpName + mo_lq.N_DJRFDZ.ToString();
            this.lblqdcdjrft.Text = strSpName + mo_lq.N_DJRFDC.ToString();
            this.lblqdddjrft.Text = strSpName + mo_lq.N_DJRFDD.ToString();
            this.lblqtydjdxt.Text = strSpName + mo_lq.N_DJDXTY.ToString();
            this.lblqdzdjdxt.Text = strSpName + mo_lq.N_DJDXDZ.ToString();
            this.lblqdcdjdxt.Text = strSpName + mo_lq.N_DJDXDC.ToString();
            this.lblqdddjdxt.Text = strSpName + mo_lq.N_DJDXDD.ToString();
            this.lblqtydjdst.Text = strSpName + mo_lq.N_DJDSTY.ToString();
            this.lblqdzdjdst.Text = strSpName + mo_lq.N_DJDSDZ.ToString();
            this.lblqdcdjdst.Text = strSpName + mo_lq.N_DJDSDC.ToString();
            this.lblqdddjdst.Text = strSpName + mo_lq.N_DJDSDD.ToString();
            #endregion

            KFB_SETUPMB mo_MB = objAgentManageAddDB.GetModelMB(strlvl, strparid);

            //棒球 
            #region
            this.lbmbtyrft.Text = strSpName + mo_MB.N_RFTY.ToString();
            this.lbmbdzrft.Text = strSpName + mo_MB.N_RFDZ.ToString();
            this.lbmbdcrft.Text = strSpName + mo_MB.N_RFDC.ToString();
            this.lbmbtydxt.Text = strSpName + mo_MB.N_DXTY.ToString();
            this.lbmbdzdxt.Text = strSpName + mo_MB.N_DXDZ.ToString();
            this.lbmbdcdxt.Text = strSpName + mo_MB.N_DXDC.ToString();
            this.lbmbtydyt.Text = strSpName + mo_MB.N_DYTY.ToString();
            this.lbmbdzdyt.Text = strSpName + mo_MB.N_DYDZ.ToString();
            this.lbmbdcdyt.Text = strSpName + mo_MB.N_DYDC.ToString();
            this.lbmbtydst.Text = strSpName + mo_MB.N_DSTY.ToString();
            this.lbmbdzdst.Text = strSpName + mo_MB.N_DSDZ.ToString();
            this.lbmbdcdst.Text = strSpName + mo_MB.N_DSDC.ToString();
            this.lbmbtyzdrft.Text = strSpName + mo_MB.N_ZDRFTY.ToString();
            this.lbmbdzzdrft.Text = strSpName + mo_MB.N_ZDRFDZ.ToString();
            this.lbmbdczdrft.Text = strSpName + mo_MB.N_ZDRFDC.ToString();
            this.lbmbtyzddxt.Text = strSpName + mo_MB.N_ZDDXTY.ToString();
            this.lbmbdzzddxt.Text = strSpName + mo_MB.N_ZDDXDZ.ToString();
            this.lbmbdczddxt.Text = strSpName + mo_MB.N_ZDDXDC.ToString();
            this.lbmbtysyt.Text = strSpName + mo_MB.N_SYTY.ToString();
            this.lbmbdzsyt.Text = strSpName + mo_MB.N_SYDZ.ToString();
            this.lbmbdcsyt.Text = strSpName + mo_MB.N_SYDC.ToString();
            this.lbmbtyggt.Text = strSpName + mo_MB.N_GGTY.ToString();
            this.lbmbdzggt.Text = strSpName + mo_MB.N_GGDZ.ToString();
            this.lbmbdcggt.Text = strSpName + mo_MB.N_GGDC.ToString();
            this.lbmbtybcrft.Text = strSpName + mo_MB.N_GJTY.ToString();
            this.lbmbdzbcrft.Text = strSpName + mo_MB.N_GJDZ.ToString();
            this.lbmbdcbcrft.Text = strSpName + mo_MB.N_GJDC.ToString();
            #endregion

            KFB_SETUPRB mo_RB = objAgentManageAddDB.GetModelRB(strlvl, strparid);
            //网球 
            #region
            this.lbrbtyrft.Text = strSpName + mo_RB.N_RFTY.ToString();
            this.lbrbdzrft.Text = strSpName + mo_RB.N_RFDZ.ToString();
            this.lbrbdcrft.Text = strSpName + mo_RB.N_RFDC.ToString();
            this.lbrbtydxt.Text = strSpName + mo_RB.N_DXTY.ToString();
            this.lbrbdzdxt.Text = strSpName + mo_RB.N_DXDZ.ToString();
            this.lbrbdcdxt.Text = strSpName + mo_RB.N_DXDC.ToString();
            this.lbrbtydyt.Text = strSpName + mo_RB.N_DYTY.ToString();
            this.lbrbdzdyt.Text = strSpName + mo_RB.N_DYDZ.ToString();
            this.lbrbdcdyt.Text = strSpName + mo_RB.N_DYDC.ToString();
            this.lbrbtydst.Text = strSpName + mo_RB.N_DSTY.ToString();
            this.lbrbdzdst.Text = strSpName + mo_RB.N_DSDZ.ToString();
            this.lbrbdcdst.Text = strSpName + mo_RB.N_DSDC.ToString();
            this.lbrbtyzdrft.Text = strSpName + mo_RB.N_ZDRFTY.ToString();
            this.lbrbdzzdrft.Text = strSpName + mo_RB.N_ZDRFDZ.ToString();
            this.lbrbdczdrft.Text = strSpName + mo_RB.N_ZDRFDC.ToString();
            this.lbrbtyzddxt.Text = strSpName + mo_RB.N_ZDDXTY.ToString();
            this.lbrbdzzddxt.Text = strSpName + mo_RB.N_ZDDXDZ.ToString();
            this.lbrbdczddxt.Text = strSpName + mo_RB.N_ZDDXDC.ToString();
            this.lbrbtysyt.Text = strSpName + mo_RB.N_SYTY.ToString();
            this.lbrbdzsyt.Text = strSpName + mo_RB.N_SYDZ.ToString();
            this.lbrbdcsyt.Text = strSpName + mo_RB.N_SYDC.ToString();
            this.lbrbtyggt.Text = strSpName + mo_RB.N_GGTY.ToString();
            this.lbrbdzggt.Text = strSpName + mo_RB.N_GGDZ.ToString();
            this.lbrbdcggt.Text = strSpName + mo_RB.N_GGDC.ToString();
            this.lbrbtybcrft.Text = strSpName + mo_RB.N_GJTY.ToString();
            this.lbrbdzbcrft.Text = strSpName + mo_RB.N_GJDZ.ToString();
            this.lbrbdcbcrft.Text = strSpName + mo_RB.N_GJDC.ToString();
            #endregion

            //排球 
            #region
            KFB_SETUPTB mo_TB = objAgentManageAddDB.GetModelTB(strlvl, strparid);
            this.lbtbtyrft.Text = strSpName + mo_TB.N_RFTY.ToString();
            this.lbtbdzrft.Text = strSpName + mo_TB.N_RFDZ.ToString();
            this.lbtbdcrft.Text = strSpName + mo_TB.N_RFDC.ToString();
            this.lbtbtydxt.Text = strSpName + mo_TB.N_DXTY.ToString();
            this.lbtbdzdxt.Text = strSpName + mo_TB.N_DXDZ.ToString();
            this.lbtbdcdxt.Text = strSpName + mo_TB.N_DXDC.ToString();
            this.lbtbtydyt.Text = strSpName + mo_TB.N_DYTY.ToString();
            this.lbtbdzdyt.Text = strSpName + mo_TB.N_DYDZ.ToString();
            this.lbtbdcdyt.Text = strSpName + mo_TB.N_DYDC.ToString();
            this.lbtbtydst.Text = strSpName + mo_TB.N_DSTY.ToString();
            this.lbtbdzdst.Text = strSpName + mo_TB.N_DSDZ.ToString();
            this.lbtbdcdst.Text = strSpName + mo_TB.N_DSDC.ToString();
            this.lbtbtyzdrft.Text = strSpName + mo_TB.N_ZDRFTY.ToString();
            this.lbtbdzzdrft.Text = strSpName + mo_TB.N_ZDRFDZ.ToString();
            this.lbtbdczdrft.Text = strSpName + mo_TB.N_ZDRFDC.ToString();
            this.lbtbtyzddxt.Text = strSpName + mo_TB.N_ZDDXTY.ToString();
            this.lbtbdzzddxt.Text = strSpName + mo_TB.N_ZDDXDZ.ToString();
            this.lbtbdczddxt.Text = strSpName + mo_TB.N_ZDDXDC.ToString();
            this.lbtbtysyt.Text = strSpName + mo_TB.N_SYTY.ToString();
            this.lbtbdzsyt.Text = strSpName + mo_TB.N_SYDZ.ToString();
            this.lbtbdcsyt.Text = strSpName + mo_TB.N_SYDC.ToString();
            this.lbtbtyggt.Text = strSpName + mo_TB.N_GGTY.ToString();
            this.lbtbdzggt.Text = strSpName + mo_TB.N_GGDZ.ToString();
            this.lbtbdcggt.Text = strSpName + mo_TB.N_GGDC.ToString();
            this.lbtbtybcrft.Text = strSpName + mo_TB.N_GJTY.ToString();
            this.lbtbdzbcrft.Text = strSpName + mo_TB.N_GJDZ.ToString();
            this.lbtbdcbcrft.Text = strSpName + mo_TB.N_GJDC.ToString();
            #endregion

            //足 球 
            #region
            KFB_SETUPZQ mo_ZQ = objAgentManageAddDB.GetModelZQ(strlvl, strparid);
            this.lbzqtyarft.Text = strSpName + mo_ZQ.N_ARFTY.ToString();
            this.lbzqtybrft.Text = strSpName + mo_ZQ.N_BRFTY.ToString();
            this.lbzqtycrft.Text = strSpName + mo_ZQ.N_CRFTY.ToString();
            this.lbzqdzrft.Text = strSpName + mo_ZQ.N_RFDZ.ToString();
            this.lbzqdcrft.Text = strSpName + mo_ZQ.N_RFDC.ToString();
            this.lbzqtyadxt.Text = strSpName + mo_ZQ.N_ADXTY.ToString();
            this.lbzqtybdxt.Text = strSpName + mo_ZQ.N_BDXTY.ToString();
            this.lbzqtycdxt.Text = strSpName + mo_ZQ.N_CDXTY.ToString();
            this.lbzqdzdxt.Text = strSpName + mo_ZQ.N_DXDZ.ToString();
            this.lbzqdcdxt.Text = strSpName + mo_ZQ.N_DXDC.ToString();
            this.lbzqtyadyt.Text = strSpName + mo_ZQ.N_ADYTY.ToString();
            this.lbzqtybdyt.Text = strSpName + mo_ZQ.N_BDYTY.ToString();
            this.lbzqtycdyt.Text = strSpName + mo_ZQ.N_CDYTY.ToString();
            this.lbzqdzdyt.Text = strSpName + mo_ZQ.N_DYDZ.ToString();
            this.lbzqdcdyt.Text = strSpName + mo_ZQ.N_DYDC.ToString();
            this.lbzqtyadst.Text = strSpName + mo_ZQ.N_ADSTY.ToString();
            this.lbzqtybdst.Text = strSpName + mo_ZQ.N_BDSTY.ToString();
            this.lbzqtycdst.Text = strSpName + mo_ZQ.N_CDSTY.ToString();
            this.lbzqdzdst.Text = strSpName + mo_ZQ.N_DSDZ.ToString();
            this.lbzqdcdst.Text = strSpName + mo_ZQ.N_DSDC.ToString();
            this.lbzqtyazdrft.Text = strSpName + mo_ZQ.N_AZDRFTY.ToString();
            this.lbzqtybzdrft.Text = strSpName + mo_ZQ.N_BZDRFTY.ToString();
            this.lbzqtyczdrft.Text = strSpName + mo_ZQ.N_CZDRFTY.ToString();
            this.lbzqdzzdrft.Text = strSpName + mo_ZQ.N_ZDRFDZ.ToString();
            this.lbzqdczdrft.Text = strSpName + mo_ZQ.N_ZDRFDC.ToString();
            this.lbzqtyazddxt.Text = strSpName + mo_ZQ.N_AZDDXTY.ToString();
            this.lbzqtybzddxt.Text = strSpName + mo_ZQ.N_BZDDXTY.ToString();
            this.lbzqtyczddxt.Text = strSpName + mo_ZQ.N_CZDDXTY.ToString();
            this.lbzqdzzddxt.Text = strSpName + mo_ZQ.N_ZDDXDZ.ToString();
            this.lbzqdczddxt.Text = strSpName + mo_ZQ.N_ZDDXDC.ToString();
            this.lbzqtyabcrft.Text = strSpName + mo_ZQ.N_ABCRFTY.ToString();
            this.lbzqtybbcrft.Text = strSpName + mo_ZQ.N_BBCRFTY.ToString();
            this.lbzqtycbcrft.Text = strSpName + mo_ZQ.N_CBCRFTY.ToString();
            this.lbzqdzbcrft.Text = strSpName + mo_ZQ.N_BCRFDZ.ToString();
            this.lbzqdcbcrft.Text = strSpName + mo_ZQ.N_BCRFDC.ToString();
            this.lbzqtyabcdxt.Text = strSpName + mo_ZQ.N_ABCDXTY.ToString();
            this.lbzqtybbcdxt.Text = strSpName + mo_ZQ.N_BBCDXTY.ToString();
            this.lbzqtycbcdxt.Text = strSpName + mo_ZQ.N_CBCDXTY.ToString();
            this.lbzqdzbcdxt.Text = strSpName + mo_ZQ.N_BCDXDZ.ToString();
            this.lbzqdcbcdxt.Text = strSpName + mo_ZQ.N_BCDXDC.ToString();
            this.lbzqtyabcdyt.Text = strSpName + mo_ZQ.N_ABCDYTY.ToString();
            this.lbzqtybbcdyt.Text = strSpName + mo_ZQ.N_BBCDYTY.ToString();
            this.lbzqtycbcdyt.Text = strSpName + mo_ZQ.N_CBCDYTY.ToString();
            this.lbzqdzbcdyt.Text = strSpName + mo_ZQ.N_BCDYDZ.ToString();
            this.lbzqdcbcdyt.Text = strSpName + mo_ZQ.N_BCDYDC.ToString();
            this.lbzqtyarqst.Text = strSpName + mo_ZQ.N_ARQSTY.ToString();
            this.lbzqtybrqst.Text = strSpName + mo_ZQ.N_BRQSTY.ToString();
            this.lbzqtycrqst.Text = strSpName + mo_ZQ.N_CRQSTY.ToString();
            this.lbzqdzrqst.Text = strSpName + mo_ZQ.N_RQSDZ.ToString();
            this.lbzqdcrqst.Text = strSpName + mo_ZQ.N_RQSDC.ToString();
            this.lbzqtyabdt.Text = strSpName + mo_ZQ.N_ABDTY.ToString();
            this.lbzqtybbdt.Text = strSpName + mo_ZQ.N_BBDTY.ToString();
            this.lbzqtycbdt.Text = strSpName + mo_ZQ.N_CBDTY.ToString();
            this.lbzqdzbdt.Text = strSpName + mo_ZQ.N_BDDZ.ToString();
            this.lbzqdcbdt.Text = strSpName + mo_ZQ.N_BDDC.ToString();
            this.lbzqtyabqct.Text = strSpName + mo_ZQ.N_ABQCTY.ToString();
            this.lbzqtybbqct.Text = strSpName + mo_ZQ.N_BBQCTY.ToString();
            this.lbzqtycbqct.Text = strSpName + mo_ZQ.N_CBQCTY.ToString();
            this.lbzqdzbqct.Text = strSpName + mo_ZQ.N_BQCDZ.ToString();
            this.lbzqdcbqct.Text = strSpName + mo_ZQ.N_BQCDC.ToString();
            this.lbzqtyaggt.Text = strSpName + mo_ZQ.N_AGGTY.ToString();
            this.lbzqtybggt.Text = strSpName + mo_ZQ.N_BGGTY.ToString();
            this.lbzqtycggt.Text = strSpName + mo_ZQ.N_CGGTY.ToString();
            this.lbzqdzggt.Text = strSpName + mo_ZQ.N_GGDZ.ToString();
            this.lbzqdcggt.Text = strSpName + mo_ZQ.N_GGDC.ToString();
            this.lbzqtyagjt.Text = strSpName + mo_ZQ.N_AGJTY.ToString();
            this.lbzqtybgjt.Text = strSpName + mo_ZQ.N_BGJTY.ToString();
            this.lbzqtycgjt.Text = strSpName + mo_ZQ.N_CGJTY.ToString();
            this.lbzqdzgjt.Text = strSpName + mo_ZQ.N_GJDZ.ToString();
            this.lbzqdcgjt.Text = strSpName + mo_ZQ.N_GJDC.ToString();
            #endregion


            //美足
            #region
            KFB_SETUPMQ mo_MQ = objAgentManageAddDB.GetModelMQ(strlvl, strparid);
            this.lbmztyrft.Text = strSpName + mo_MQ.N_RFTY.ToString();
            this.lbmzdzrft.Text = strSpName + mo_MQ.N_RFDZ.ToString();
            this.lbmzdcrft.Text = strSpName + mo_MQ.N_RFDC.ToString();
            this.lbmztydxt.Text = strSpName + mo_MQ.N_DXTY.ToString();
            this.lbmzdzdxt.Text = strSpName + mo_MQ.N_DXDZ.ToString();
            this.lbmzdcdxt.Text = strSpName + mo_MQ.N_DXDC.ToString();
            this.lbmztydyt.Text = strSpName + mo_MQ.N_DYTY.ToString();
            this.lbmzdzdyt.Text = strSpName + mo_MQ.N_DYDZ.ToString();
            this.lbmzdcdyt.Text = strSpName + mo_MQ.N_DYDC.ToString();
            this.lbmztydst.Text = strSpName + mo_MQ.N_DSTY.ToString();
            this.lbmzdzdst.Text = strSpName + mo_MQ.N_DSDZ.ToString();
            this.lbmzdcdst.Text = strSpName + mo_MQ.N_DSDC.ToString();
            this.lbmztyzdrft.Text = strSpName + mo_MQ.N_ZDRFTY.ToString();
            this.lbmzdzzdrft.Text = strSpName + mo_MQ.N_ZDRFDZ.ToString();
            this.lbmzdczdrft.Text = strSpName + mo_MQ.N_ZDRFDC.ToString();
            this.lbmztyzddxt.Text = strSpName + mo_MQ.N_ZDDXTY.ToString();
            this.lbmzdzzddxt.Text = strSpName + mo_MQ.N_ZDDXDZ.ToString();
            this.lbmzdczddxt.Text = strSpName + mo_MQ.N_ZDDXDC.ToString();
            this.lbmztybcrft.Text = strSpName + mo_MQ.N_BCRFTY.ToString();
            this.lbmzdzbcrft.Text = strSpName + mo_MQ.N_BCRFDZ.ToString();
            this.lbmzdcbcrft.Text = strSpName + mo_MQ.N_BCRFDC.ToString();
            this.lbmztybcdxt.Text = strSpName + mo_MQ.N_BCDXTY.ToString();
            this.lbmzdzbcdxt.Text = strSpName + mo_MQ.N_BCDXDZ.ToString();
            this.lbmzdcbcdxt.Text = strSpName + mo_MQ.N_BCDXDC.ToString();
            this.lbmztybcdyt.Text = strSpName + mo_MQ.N_BCDYTY.ToString();
            this.lbmzdzbcdyt.Text = strSpName + mo_MQ.N_BCDYDZ.ToString();
            this.lbmzdcbcdyt.Text = strSpName + mo_MQ.N_BCDYDC.ToString();
            this.lbmztybcdst.Text = strSpName + mo_MQ.N_BCDSTY.ToString();
            this.lbmzdzbcdst.Text = strSpName + mo_MQ.N_BCDSDZ.ToString();
            this.lbmzdcbcdst.Text = strSpName + mo_MQ.N_BCDSDC.ToString();
            this.lbmztyggt.Text = strSpName + mo_MQ.N_GGTY.ToString();
            this.lbmzdzggt.Text = strSpName + mo_MQ.N_GGDZ.ToString();
            this.lbmzdcggt.Text = strSpName + mo_MQ.N_GGDC.ToString();
            this.lbmztygjt.Text = strSpName + mo_MQ.N_GJTY.ToString();
            this.lbmzdzgjt.Text = strSpName + mo_MQ.N_GJDZ.ToString();
            this.lbmzdcgjt.Text = strSpName + mo_MQ.N_GJDC.ToString();
            #endregion


            KFB_SETUPBQ mo_BQ = objAgentManageAddDB.GetModelBQ(strlvl, strparid);

            //冰球 
            #region
            this.lbbqtyrft.Text = strSpName + mo_BQ.N_RFTY.ToString();
            this.lbbqdzrft.Text = strSpName + mo_BQ.N_RFDZ.ToString();
            this.lbbqdcrft.Text = strSpName + mo_BQ.N_RFDC.ToString();
            this.lbbqtydxt.Text = strSpName + mo_BQ.N_DXTY.ToString();
            this.lbbqdzdxt.Text = strSpName + mo_BQ.N_DXDZ.ToString();
            this.lbbqdcdxt.Text = strSpName + mo_BQ.N_DXDC.ToString();
            this.lbbqtydyt.Text = strSpName + mo_BQ.N_DYTY.ToString();
            this.lbbqdzdyt.Text = strSpName + mo_BQ.N_DYDZ.ToString();
            this.lbbqdcdyt.Text = strSpName + mo_BQ.N_DYDC.ToString();
            this.lbbqtydst.Text = strSpName + mo_BQ.N_DSTY.ToString();
            this.lbbqdzdst.Text = strSpName + mo_BQ.N_DSDZ.ToString();
            this.lbbqdcdst.Text = strSpName + mo_BQ.N_DSDC.ToString();
            this.lbbqtyzdrft.Text = strSpName + mo_BQ.N_ZDRFTY.ToString();
            this.lbbqdzzdrft.Text = strSpName + mo_BQ.N_ZDRFDZ.ToString();
            this.lbbqdczdrft.Text = strSpName + mo_BQ.N_ZDRFDC.ToString();
            this.lbbqtyzddxt.Text = strSpName + mo_BQ.N_ZDDXTY.ToString();
            this.lbbqdzzddxt.Text = strSpName + mo_BQ.N_ZDDXDZ.ToString();
            this.lbbqdczddxt.Text = strSpName + mo_BQ.N_ZDDXDC.ToString();
            this.lbbqtysyt.Text = strSpName + mo_BQ.N_SYTY.ToString();
            this.lbbqdzsyt.Text = strSpName + mo_BQ.N_SYDZ.ToString();
            this.lbbqdcsyt.Text = strSpName + mo_BQ.N_SYDC.ToString();
            this.lbbqtyggt.Text = strSpName + mo_BQ.N_GGTY.ToString();
            this.lbbqdzggt.Text = strSpName + mo_BQ.N_GGDZ.ToString();
            this.lbbqdcggt.Text = strSpName + mo_BQ.N_GGDC.ToString();
            this.lbbqtybcrft.Text = strSpName + mo_BQ.N_GJTY.ToString();
            this.lbbqdzbcrft.Text = strSpName + mo_BQ.N_GJDZ.ToString();
            this.lbbqdcbcrft.Text = strSpName + mo_BQ.N_GJDC.ToString();
            #endregion

            //彩球
            #region
            KFB_SETUPCQ mo_CQ = objAgentManageAddDB.GetModelCQ(strlvl, strparid);
            this.lbcqtyrft.Text = strSpName + mo_CQ.N_RFTY.ToString();
            this.lbcqdzrft.Text = strSpName + mo_CQ.N_RFDZ.ToString();
            this.lbcqdcrft.Text = strSpName + mo_CQ.N_RFDC.ToString();
            this.lbcqtydxt.Text = strSpName + mo_CQ.N_DXTY.ToString();
            this.lbcqdzdxt.Text = strSpName + mo_CQ.N_DXDZ.ToString();
            this.lbcqdcdxt.Text = strSpName + mo_CQ.N_DXDC.ToString();
            this.lbcqtydyt.Text = strSpName + mo_CQ.N_DYTY.ToString();
            this.lbcqdzdyt.Text = strSpName + mo_CQ.N_DYDZ.ToString();
            this.lbcqdcdyt.Text = strSpName + mo_CQ.N_DYDC.ToString();
            this.lbcqtydst.Text = strSpName + mo_CQ.N_DSTY.ToString();
            this.lbcqdzdst.Text = strSpName + mo_CQ.N_DSDZ.ToString();
            this.lbcqdcdst.Text = strSpName + mo_CQ.N_DSDC.ToString();
            this.lbcqtyzdrft.Text = strSpName + mo_CQ.N_ZDRFTY.ToString();
            this.lbcqdzzdrft.Text = strSpName + mo_CQ.N_ZDRFDZ.ToString();
            this.lbcqdczdrft.Text = strSpName + mo_CQ.N_ZDRFDC.ToString();
            this.lbcqtyzddxt.Text = strSpName + mo_CQ.N_ZDDXTY.ToString();
            this.lbcqdzzddxt.Text = strSpName + mo_CQ.N_ZDDXDZ.ToString();
            this.lbcqdczddxt.Text = strSpName + mo_CQ.N_ZDDXDC.ToString();
            this.lbcqtybcrft.Text = strSpName + mo_CQ.N_BCRFTY.ToString();
            this.lbcqdzbcrft.Text = strSpName + mo_CQ.N_BCRFDZ.ToString();
            this.lbcqdcbcrft.Text = strSpName + mo_CQ.N_BCRFDC.ToString();
            this.lbcqtybcdxt.Text = strSpName + mo_CQ.N_BCDXTY.ToString();
            this.lbcqdzbcdxt.Text = strSpName + mo_CQ.N_BCDXDZ.ToString();
            this.lbcqdcbcdxt.Text = strSpName + mo_CQ.N_BCDXDC.ToString();
            this.lbcqtybcdyt.Text = strSpName + mo_CQ.N_BCDYTY.ToString();
            this.lbcqdzbcdyt.Text = strSpName + mo_CQ.N_BCDYDZ.ToString();
            this.lbcqdcbcdyt.Text = strSpName + mo_CQ.N_BCDYDC.ToString();
            this.lbcqtybcdst.Text = strSpName + mo_CQ.N_BCDSTY.ToString();
            this.lbcqdzbcdst.Text = strSpName + mo_CQ.N_BCDSDZ.ToString();
            this.lbcqdcbcdst.Text = strSpName + mo_CQ.N_BCDSDC.ToString();
            this.lbcqtyggt.Text = strSpName + mo_CQ.N_GGTY.ToString();
            this.lbcqdzggt.Text = strSpName + mo_CQ.N_GGDZ.ToString();
            this.lbcqdcggt.Text = strSpName + mo_CQ.N_GGDC.ToString();
            this.lbcqtygjt.Text = strSpName + mo_CQ.N_GJTY.ToString();
            this.lbcqdzgjt.Text = strSpName + mo_CQ.N_GJDZ.ToString();
            this.lbcqdcgjt.Text = strSpName + mo_CQ.N_GJDC.ToString();

            #endregion




            //指数
            #region
            KFB_SETUPZS mo_ZS = objAgentManageAddDB.GetModelZS(strlvl, strparid);
            this.lbzstyrft.Text = strSpName + mo_ZS.N_RFTY.ToString();
            this.lbzsdzrft.Text = strSpName + mo_ZS.N_RFDZ.ToString();
            this.lbzsdcrft.Text = strSpName + mo_ZS.N_RFDC.ToString();
            this.lbzstydxt.Text = strSpName + mo_ZS.N_DXTY.ToString();
            this.lbzsdzdxt.Text = strSpName + mo_ZS.N_DXDZ.ToString();
            this.lbzsdcdxt.Text = strSpName + mo_ZS.N_DXDC.ToString();
            this.lbzstydyt.Text = strSpName + mo_ZS.N_DYTY.ToString();
            this.lbzsdzdyt.Text = strSpName + mo_ZS.N_DYDZ.ToString();
            this.lbzsdcdyt.Text = strSpName + mo_ZS.N_DYDC.ToString();
            this.lbzstydst.Text = strSpName + mo_ZS.N_DSTY.ToString();
            this.lbzsdzdst.Text = strSpName + mo_ZS.N_DSDZ.ToString();
            this.lbzsdcdst.Text = strSpName + mo_ZS.N_DSDC.ToString();
            this.lbzstyzdrft.Text = strSpName + mo_ZS.N_ZDRFTY.ToString();
            this.lbzsdzzdrft.Text = strSpName + mo_ZS.N_ZDRFDZ.ToString();
            this.lbzsdczdrft.Text = strSpName + mo_ZS.N_ZDRFDC.ToString();
            this.lbzstyzddxt.Text = strSpName + mo_ZS.N_ZDDXTY.ToString();
            this.lbzsdzzddxt.Text = strSpName + mo_ZS.N_ZDDXDZ.ToString();
            this.lbzsdczddxt.Text = strSpName + mo_ZS.N_ZDDXDC.ToString();
            this.lbzstysyt.Text = strSpName + mo_ZS.N_SYTY.ToString();
            this.lbzsdzsyt.Text = strSpName + mo_ZS.N_SYDZ.ToString();
            this.lbzsdcsyt.Text = strSpName + mo_ZS.N_SYDC.ToString();
            this.lbzstybdt.Text = strSpName + mo_ZS.N_BDTY.ToString();
            this.lbzsdzbdt.Text = strSpName + mo_ZS.N_BDDZ.ToString();
            this.lbzsdcbdt.Text = strSpName + mo_ZS.N_BDDC.ToString();
            this.lbzstyggt.Text = strSpName + mo_ZS.N_GGTY.ToString();
            this.lbzsdzggt.Text = strSpName + mo_ZS.N_GGDZ.ToString();
            this.lbzsdcggt.Text = strSpName + mo_ZS.N_GGDC.ToString();
            this.lbzstygjt.Text = strSpName + mo_ZS.N_GJTY.ToString();
            this.lbzsdzgjt.Text = strSpName + mo_ZS.N_GJDZ.ToString();
            this.lbzsdcgjt.Text = strSpName + mo_ZS.N_GJDC.ToString();
            #endregion

            //赛马
            #region
            KFB_SETUPSM mo_SM = objAgentManageAddDB.GetModelSM(strlvl, strparid);
            this.lbsmtydyt.Text = strSpName + mo_SM.N_DYTY.ToString();
            this.lbsmdzdyt.Text = strSpName + mo_SM.N_DYDZ.ToString();
            this.lbsmdcdyt.Text = strSpName + mo_SM.N_DYDC.ToString();
            this.lbsmtywzt.Text = strSpName + mo_SM.N_WZTY.ToString();
            this.lbsmdzwzt.Text = strSpName + mo_SM.N_WZDZ.ToString();
            this.lbsmdcwzt.Text = strSpName + mo_SM.N_WZDC.ToString();
            this.lbsmtylyt.Text = strSpName + mo_SM.N_LYTY.ToString();
            this.lbsmdzlyt.Text = strSpName + mo_SM.N_LYDZ.ToString();
            this.lbsmdclyt.Text = strSpName + mo_SM.N_LYDC.ToString();
            this.lbsmtywzqt.Text = strSpName + mo_SM.N_WZQTY.ToString();
            this.lbsmdzwzqt.Text = strSpName + mo_SM.N_WZQDZ.ToString();
            this.lbsmdcwzqt.Text = strSpName + mo_SM.N_WZQDC.ToString();
            #endregion

            //六合彩
            #region
            KFB_SETUPLHC mo_LHC = objAgentManageAddDB.GetModelLHC(strlvl, strparid);
            this.lblhctytbht.Text = strSpName + mo_LHC.N_TBHTY.ToString();
            this.lblhcdztbht.Text = strSpName + mo_LHC.N_TBHDZ.ToString();
            this.lblhcdctbht.Text = strSpName + mo_LHC.N_TBHDC.ToString();
            this.lblhctyttt.Text = strSpName + mo_LHC.N_TTTY.ToString();
            this.lblhcdzttt.Text = strSpName + mo_LHC.N_TTDZ.ToString();
            this.lblhcdcttt.Text = strSpName + mo_LHC.N_TTDC.ToString();
            this.lblhctytht.Text = strSpName + mo_LHC.N_THTY.ToString();
            this.lblhcdztht.Text = strSpName + mo_LHC.N_THDZ.ToString();
            this.lblhcdctht.Text = strSpName + mo_LHC.N_THDC.ToString();
            this.lblhctyqcpt.Text = strSpName + mo_LHC.N_QCPTY.ToString();
            this.lblhcdzqcpt.Text = strSpName + mo_LHC.N_QCPDZ.ToString();
            this.lblhcdcqcpt.Text = strSpName + mo_LHC.N_QCPDC.ToString();
            this.lblhcty2xt.Text = strSpName + mo_LHC.N_2XTY.ToString();
            this.lblhcdz2xt.Text = strSpName + mo_LHC.N_2XDZ.ToString();
            this.lblhcdc2xt.Text = strSpName + mo_LHC.N_2XDC.ToString();
            this.lblhcty3xt.Text = strSpName + mo_LHC.N_3XTY.ToString();
            this.lblhcdz3xt.Text = strSpName + mo_LHC.N_3XDZ.ToString();
            this.lblhcdc3xt.Text = strSpName + mo_LHC.N_3XDC.ToString();
            this.lblhcty4xt.Text = strSpName + mo_LHC.N_4XTY.ToString();
            this.lblhcdz4xt.Text = strSpName + mo_LHC.N_4XDZ.ToString();
            this.lblhcdc4xt.Text = strSpName + mo_LHC.N_4XDC.ToString();
            this.lblhctygddst.Text = strSpName + mo_LHC.N_GDDSTY.ToString();
            this.lblhcdzgddst.Text = strSpName + mo_LHC.N_GDDSDZ.ToString();
            this.lblhcdcgddst.Text = strSpName + mo_LHC.N_GDDSDC.ToString();
            this.lblhctygddxt.Text = strSpName + mo_LHC.N_GDDXTY.ToString();
            this.lblhcdzgddxt.Text = strSpName + mo_LHC.N_GDDXDZ.ToString();
            this.lblhcdcgddxt.Text = strSpName + mo_LHC.N_GDDXDC.ToString();
            #endregion

            //大乐透
            #region
            KFB_SETUPDLT mo_DLT = objAgentManageAddDB.GetModelDLT(strlvl, strparid);
            this.lbdlttytbht.Text = strSpName + mo_DLT.N_TBHTY.ToString();
            this.lbdltdztbht.Text = strSpName + mo_DLT.N_TBHDZ.ToString();
            this.lbdltdctbht.Text = strSpName + mo_DLT.N_TBHDC.ToString();
            this.lbdlttyttt.Text = strSpName + mo_DLT.N_TTTY.ToString();
            this.lbdltdzttt.Text = strSpName + mo_DLT.N_TTDZ.ToString();
            this.lbdltdcttt.Text = strSpName + mo_DLT.N_TTDC.ToString();
            this.lbdlttytht.Text = strSpName + mo_DLT.N_THTY.ToString();
            this.lbdltdztht.Text = strSpName + mo_DLT.N_THDZ.ToString();
            this.lbdltdctht.Text = strSpName + mo_DLT.N_THDC.ToString();
            this.lbdlttyqcpt.Text = strSpName + mo_DLT.N_QCPTY.ToString();
            this.lbdltdzqcpt.Text = strSpName + mo_DLT.N_QCPDZ.ToString();
            this.lbdltdcqcpt.Text = strSpName + mo_DLT.N_QCPDC.ToString();
            this.lbdltty2xt.Text = strSpName + mo_DLT.N_2XTY.ToString();
            this.lbdltdz2xt.Text = strSpName + mo_DLT.N_2XDZ.ToString();
            this.lbdltdc2xt.Text = strSpName + mo_DLT.N_2XDC.ToString();
            this.lbdltty3xt.Text = strSpName + mo_DLT.N_3XTY.ToString();
            this.lbdltdz3xt.Text = strSpName + mo_DLT.N_3XDZ.ToString();
            this.lbdltdc3xt.Text = strSpName + mo_DLT.N_3XDC.ToString();
            this.lbdltty4xt.Text = strSpName + mo_DLT.N_4XTY.ToString();
            this.lbdltdz4xt.Text = strSpName + mo_DLT.N_4XDZ.ToString();
            this.lbdltdc4xt.Text = strSpName + mo_DLT.N_4XDC.ToString();
            this.lbdlttygddst.Text = strSpName + mo_DLT.N_GDDSTY.ToString();
            this.lbdltdzgddst.Text = strSpName + mo_DLT.N_GDDSDZ.ToString();
            this.lbdltdcgddst.Text = strSpName + mo_DLT.N_GDDSDC.ToString();
            this.lbdlttygddxt.Text = strSpName + mo_DLT.N_GDDXTY.ToString();
            this.lbdltdzgddxt.Text = strSpName + mo_DLT.N_GDDXDZ.ToString();
            this.lbdltdcgddxt.Text = strSpName + mo_DLT.N_GDDXDC.ToString();
            #endregion

            //JC539
            #region
            KFB_SETUPJC539 mo_JC539 = objAgentManageAddDB.GetModelJC539(strlvl, strparid);
            this.lbjc539tyqcpt.Text = strSpName + mo_JC539.N_QCPTY.ToString();
            this.lbjc539dzqcpt.Text = strSpName + mo_JC539.N_QCPDZ.ToString();
            this.lbjc539dcqcpt.Text = strSpName + mo_JC539.N_QCPDC.ToString();
            this.lbjc539ty2xt.Text = strSpName + mo_JC539.N_2XTY.ToString();
            this.lbjc539dz2xt.Text = strSpName + mo_JC539.N_2XDZ.ToString();
            this.lbjc539dc2xt.Text = strSpName + mo_JC539.N_2XDC.ToString();
            this.lbjc539ty3xt.Text = strSpName + mo_JC539.N_3XTY.ToString();
            this.lbjc539dz3xt.Text = strSpName + mo_JC539.N_3XDZ.ToString();
            this.lbjc539dc3xt.Text = strSpName + mo_JC539.N_3XDC.ToString();
            this.lbjc539ty4xt.Text = strSpName + mo_JC539.N_4XTY.ToString();
            this.lbjc539dz4xt.Text = strSpName + mo_JC539.N_4XDZ.ToString();
            this.lbjc539dc4xt.Text = strSpName + mo_JC539.N_4XDC.ToString();
            #endregion
            //运动彩票
            #region
            KFB_SETUPCP mo_CP = objAgentManageAddDB.GetModelCP(strlvl, strparid);
            this.lbcptybqt.Text = strSpName + mo_CP.N_BQTY.ToString();
            this.lbcpdzbqt.Text = strSpName + mo_CP.N_BQDZ.ToString();
            this.lbcpdcbqt.Text = strSpName + mo_CP.N_BQDC.ToString();
            this.lbcptylqt.Text = strSpName + mo_CP.N_LQTY.ToString();
            this.lbcpdzlqt.Text = strSpName + mo_CP.N_LQDZ.ToString();
            this.lbcpdclqt.Text = strSpName + mo_CP.N_LQDC.ToString();
            this.lbcptyzqt.Text = strSpName + mo_CP.N_ZQTY.ToString();
            this.lbcpdzzqt.Text = strSpName + mo_CP.N_ZQDZ.ToString();
            this.lbcpdczqt.Text = strSpName + mo_CP.N_ZQDC.ToString();
            this.lbcptygst.Text = strSpName + mo_CP.N_GSTY.ToString();
            this.lbcpdzgst.Text = strSpName + mo_CP.N_GSDZ.ToString();
            this.lbcpdcgst.Text = strSpName + mo_CP.N_GSDC.ToString();
            this.lbcptyqzt.Text = strSpName + mo_CP.N_QZTY.ToString();
            this.lbcpdzqzt.Text = strSpName + mo_CP.N_QZDZ.ToString();
            this.lbcpdcqzt.Text = strSpName + mo_CP.N_QZDC.ToString();
            #endregion

            //時事
            #region
            KFB_SETUPSS mo_SS = objAgentManageAddDB.GetModelSS(strlvl, strparid);
            this.lbsstydyt.Text = strSpName + mo_SS.N_DYTY.ToString();
            this.lbssdzdyt.Text = strSpName + mo_SS.N_DYDZ.ToString();
            this.lbssdcdyt.Text = strSpName + mo_SS.N_DYDC.ToString();
            #endregion
        }
        #endregion
        #region"总监頁面赋值"
        public void ZJFZ()
        {
          
            KFB_MRZJ mo_mrzj = new KFB_MRZJ();
            mo_mrzj = objAgentManageAddDB.GetModel();

            //拆帐赋值
            this.lbczlq.Text = mo_mrzj.N_LQ.ToString() + "%";
            this.lbczmb.Text = mo_mrzj.N_MB.ToString() + "%";
            this.lbczrb.Text = mo_mrzj.N_RB.ToString() + "%";
            this.lbcztb.Text = mo_mrzj.N_TB.ToString() + "%";
            this.lbczmz.Text = mo_mrzj.N_MZ.ToString() + "%";
            this.lbczzq.Text = mo_mrzj.N_ZQ.ToString() + "%";
            this.lbczzs.Text = mo_mrzj.N_ZS.ToString() + "%";
            this.lbczdlt.Text = mo_mrzj.N_DLT.ToString() + "%";
            this.lbczsm.Text = mo_mrzj.N_SM.ToString() + "%";
            this.lbczlhc.Text = mo_mrzj.N_LHC.ToString() + "%";
            this.lbcz2x.Text = mo_mrzj.N_2X.ToString() + "%";
            this.lbcz3x.Text = mo_mrzj.N_3X.ToString() + "%";
            this.lbcz4x.Text = mo_mrzj.N_4X.ToString() + "%";
            this.lbczjc539.Text = mo_mrzj.N_JC539.ToString() + "%";
            this.lbczcp.Text = mo_mrzj.N_CP.ToString() + "%";
            this.lbczss.Text = mo_mrzj.N_SS.ToString() + "%";


            this.lbczbq.Text = mo_mrzj.N_BQ.ToString() + "%";
            this.lbczcq.Text = mo_mrzj.N_CQ.ToString() + "%";

            //篮球 
            #region
            this.lblqtyrf.Text = mo_mrzj.N_LQRFTY.ToString();
            this.lblqdzrf.Text = mo_mrzj.N_LQRFDZ.ToString();
            this.lblqdcrf.Text = mo_mrzj.N_LQRFDC.ToString();
            this.lblqddrf.Text = mo_mrzj.N_LQRFDD.ToString();
            this.lblqtydx.Text = mo_mrzj.N_LQDXTY.ToString();
            this.lblqdzdx.Text = mo_mrzj.N_LQDXDZ.ToString();
            this.lblqdcdx.Text = mo_mrzj.N_LQDXDC.ToString();
            this.lblqdddx.Text = mo_mrzj.N_LQDXDD.ToString();
            this.lblqtydy.Text = mo_mrzj.N_LQDYTY.ToString();
            this.lblqdzdy.Text = mo_mrzj.N_LQDYDZ.ToString();
            this.lblqdcdy.Text = mo_mrzj.N_LQDYDC.ToString();
            this.lblqdddy.Text = mo_mrzj.N_LQDYDD.ToString();
            this.lblqtyds.Text = mo_mrzj.N_LQDSTY.ToString();
            this.lblqdzds.Text = mo_mrzj.N_LQDSDZ.ToString();
            this.lblqdcds.Text = mo_mrzj.N_LQDSDC.ToString();
            this.lblqddds.Text = mo_mrzj.N_LQDSDD.ToString();
            this.lblqtyzdrf.Text = mo_mrzj.N_LQZDRFTY.ToString();
            this.lblqdzzdrf.Text = mo_mrzj.N_LQZDRFDZ.ToString();
            this.lblqdczdrf.Text = mo_mrzj.N_LQZDRFDC.ToString();
            this.lblqddzdrf.Text = mo_mrzj.N_LQZDRFDD.ToString();
            this.lblqtyzddx.Text = mo_mrzj.N_LQZDDXTY.ToString();
            this.lblqdzzddx.Text = mo_mrzj.N_LQZDDXDZ.ToString();
            this.lblqdczddx.Text = mo_mrzj.N_LQZDDXDC.ToString();
            this.lblqddzddx.Text = mo_mrzj.N_LQZDDXDD.ToString();
            this.lblqtybcrf.Text = mo_mrzj.N_LQBCRFTY.ToString();
            this.lblqdzbcrf.Text = mo_mrzj.N_LQBCRFDZ.ToString();
            this.lblqdcbcrf.Text = mo_mrzj.N_LQBCRFDC.ToString();
            this.lblqddbcrf.Text = mo_mrzj.N_LQBCRFDD.ToString();
            this.lblqtybcdx.Text = mo_mrzj.N_LQBCDXTY.ToString();
            this.lblqdzbcdx.Text = mo_mrzj.N_LQBCDXDZ.ToString();
            this.lblqdcbcdx.Text = mo_mrzj.N_LQBCDXDC.ToString();
            this.lblqddbcdx.Text = mo_mrzj.N_LQBCDXDD.ToString();
            this.lblqtybcdy.Text = mo_mrzj.N_LQBCDYTY.ToString();
            this.lblqdzbcdy.Text = mo_mrzj.N_LQBCDYDZ.ToString();
            this.lblqdcbcdy.Text = mo_mrzj.N_LQBCDYDC.ToString();
            this.lblqddbcdy.Text = mo_mrzj.N_LQBCDYDD.ToString();
            this.lblqtybcds.Text = mo_mrzj.N_LQBCDSTY.ToString();
            this.lblqdzbcds.Text = mo_mrzj.N_LQBCDSDZ.ToString();
            this.lblqdcbcds.Text = mo_mrzj.N_LQBCDSDC.ToString();
            this.lblqddbcds.Text = mo_mrzj.N_LQBCDSDD.ToString();
            this.lblqtygg.Text = mo_mrzj.N_LQGGTY.ToString();
            this.lblqdzgg.Text = mo_mrzj.N_LQGGDZ.ToString();
            this.lblqdcgg.Text = mo_mrzj.N_LQGGDC.ToString();
            this.lblqddgg.Text = mo_mrzj.N_LQGGDD.ToString();
            this.lblqtygj.Text = mo_mrzj.N_LQGJTY.ToString();
            this.lblqdzgj.Text = mo_mrzj.N_LQGJDZ.ToString();
            this.lblqdcgj.Text = mo_mrzj.N_LQGJDC.ToString();
            this.lblqddgj.Text = mo_mrzj.N_LQGJDD.ToString();
            this.lblqtydjrf.Text = mo_mrzj.N_LQDJRFTY.ToString();
            this.lblqdzdjrf.Text = mo_mrzj.N_LQDJRFDZ.ToString();
            this.lblqdcdjrf.Text = mo_mrzj.N_LQDJRFDC.ToString();
            this.lblqdddjrf.Text = mo_mrzj.N_LQDJRFDD.ToString();
            this.lblqtydjdx.Text = mo_mrzj.N_LQDJDXTY.ToString();
            this.lblqdzdjdx.Text = mo_mrzj.N_LQDJDXDZ.ToString();
            this.lblqdcdjdx.Text = mo_mrzj.N_LQDJDXDC.ToString();
            this.lblqdddjdx.Text = mo_mrzj.N_LQDJDXDD.ToString();
            this.lblqtydjds.Text = mo_mrzj.N_LQDJDSTY.ToString();
            this.lblqdzdjds.Text = mo_mrzj.N_LQDJDSDZ.ToString();
            this.lblqdcdjds.Text = mo_mrzj.N_LQDJDSDC.ToString();
            this.lblqdddjds.Text = mo_mrzj.N_LQDJDSDD.ToString();
            #endregion

            //棒球 
            #region
            this.lbmbtyrf.Text = mo_mrzj.N_MBRFTY.ToString();
            this.lbmbdzrf.Text = mo_mrzj.N_MBRFDZ.ToString();
            this.lbmbdcrf.Text = mo_mrzj.N_MBRFDC.ToString();
            this.lbmbtydx.Text = mo_mrzj.N_MBDXTY.ToString();
            this.lbmbdzdx.Text = mo_mrzj.N_MBDXDZ.ToString();
            this.lbmbdcdx.Text = mo_mrzj.N_MBDXDC.ToString();
            this.lbmbtydy.Text = mo_mrzj.N_MBDYTY.ToString();
            this.lbmbdzdy.Text = mo_mrzj.N_MBDYDZ.ToString();
            this.lbmbdcdy.Text = mo_mrzj.N_MBDYDC.ToString();
            this.lbmbtyds.Text = mo_mrzj.N_MBDSTY.ToString();
            this.lbmbdzds.Text = mo_mrzj.N_MBDSDZ.ToString();
            this.lbmbdcds.Text = mo_mrzj.N_MBDSDC.ToString();
            this.lbmbtyzdrf.Text = mo_mrzj.N_MBZDRFTY.ToString();
            this.lbmbdzzdrf.Text = mo_mrzj.N_MBZDRFDZ.ToString();
            this.lbmbdczdrf.Text = mo_mrzj.N_MBZDRFDC.ToString();
            this.lbmbtyzddx.Text = mo_mrzj.N_MBZDDXTY.ToString();
            this.lbmbdzzddx.Text = mo_mrzj.N_MBZDDXDZ.ToString();
            this.lbmbdczddx.Text = mo_mrzj.N_MBZDDXDC.ToString();
            this.lbmbtysy.Text = mo_mrzj.N_MBSYTY.ToString();
            this.lbmbdzsy.Text = mo_mrzj.N_MBSYDZ.ToString();
            this.lbmbdcsy.Text = mo_mrzj.N_MBSYDC.ToString();
            this.lbmbtygg.Text = mo_mrzj.N_MBGGTY.ToString();
            this.lbmbdzgg.Text = mo_mrzj.N_MBGGDZ.ToString();
            this.lbmbdcgg.Text = mo_mrzj.N_MBGGDC.ToString();
            this.lbmbtybcrf.Text = mo_mrzj.N_MBGJTY.ToString();
            this.lbmbdzbcrf.Text = mo_mrzj.N_MBGJDZ.ToString();
            this.lbmbdcbcrf.Text = mo_mrzj.N_MBGJDC.ToString();
            #endregion
            //网球 
            #region
            this.lbrbtyrf.Text = mo_mrzj.N_RBRFTY.ToString();
            this.lbrbdzrf.Text = mo_mrzj.N_RBRFDZ.ToString();
            this.lbrbdcrf.Text = mo_mrzj.N_RBRFDC.ToString();
            this.lbrbtydx.Text = mo_mrzj.N_RBDXTY.ToString();
            this.lbrbdzdx.Text = mo_mrzj.N_RBDXDZ.ToString();
            this.lbrbdcdx.Text = mo_mrzj.N_RBDXDC.ToString();
            this.lbrbtydy.Text = mo_mrzj.N_RBDYTY.ToString();
            this.lbrbdzdy.Text = mo_mrzj.N_RBDYDZ.ToString();
            this.lbrbdcdy.Text = mo_mrzj.N_RBDYDC.ToString();
            this.lbrbtyds.Text = mo_mrzj.N_RBDSTY.ToString();
            this.lbrbdzds.Text = mo_mrzj.N_RBDSDZ.ToString();
            this.lbrbdcds.Text = mo_mrzj.N_RBDSDC.ToString();
            this.lbrbtyzdrf.Text = mo_mrzj.N_RBZDRFTY.ToString();
            this.lbrbdzzdrf.Text = mo_mrzj.N_RBZDRFDZ.ToString();
            this.lbrbdczdrf.Text = mo_mrzj.N_RBZDRFDC.ToString();
            this.lbrbtyzddx.Text = mo_mrzj.N_RBZDDXTY.ToString();
            this.lbrbdzzddx.Text = mo_mrzj.N_RBZDDXDZ.ToString();
            this.lbrbdczddx.Text = mo_mrzj.N_RBZDDXDC.ToString();
            this.lbrbtysy.Text = mo_mrzj.N_RBSYTY.ToString();
            this.lbrbdzsy.Text = mo_mrzj.N_RBSYDZ.ToString();
            this.lbrbdcsy.Text = mo_mrzj.N_RBSYDC.ToString();
            this.lbrbtygg.Text = mo_mrzj.N_RBGGTY.ToString();
            this.lbrbdzgg.Text = mo_mrzj.N_RBGGDZ.ToString();
            this.lbrbdcgg.Text = mo_mrzj.N_RBGGDC.ToString();
            this.lbrbtybcrf.Text = mo_mrzj.N_RBGJTY.ToString();
            this.lbrbdzbcrf.Text = mo_mrzj.N_RBGJDZ.ToString();
            this.lbrbdcbcrf.Text = mo_mrzj.N_RBGJDC.ToString();
            #endregion
            //排球 
            #region
            this.lbtbtyrf.Text = mo_mrzj.N_TBRFTY.ToString();
            this.lbtbdzrf.Text = mo_mrzj.N_TBRFDZ.ToString();
            this.lbtbdcrf.Text = mo_mrzj.N_TBRFDC.ToString();
            this.lbtbtydx.Text = mo_mrzj.N_TBDXTY.ToString();
            this.lbtbdzdx.Text = mo_mrzj.N_TBDXDZ.ToString();
            this.lbtbdcdx.Text = mo_mrzj.N_TBDXDC.ToString();
            this.lbtbtydy.Text = mo_mrzj.N_TBDYTY.ToString();
            this.lbtbdzdy.Text = mo_mrzj.N_TBDYDZ.ToString();
            this.lbtbdcdy.Text = mo_mrzj.N_TBDYDC.ToString();
            this.lbtbtyds.Text = mo_mrzj.N_TBDSTY.ToString();
            this.lbtbdzds.Text = mo_mrzj.N_TBDSDZ.ToString();
            this.lbtbdcds.Text = mo_mrzj.N_TBDSDC.ToString();
            this.lbtbtyzdrf.Text = mo_mrzj.N_TBZDRFTY.ToString();
            this.lbtbdzzdrf.Text = mo_mrzj.N_TBZDRFDZ.ToString();
            this.lbtbdczdrf.Text = mo_mrzj.N_TBZDRFDC.ToString();
            this.lbtbtyzddx.Text = mo_mrzj.N_TBZDDXTY.ToString();
            this.lbtbdzzddx.Text = mo_mrzj.N_TBZDDXDZ.ToString();
            this.lbtbdczddx.Text = mo_mrzj.N_TBZDDXDC.ToString();
            this.lbtbtysy.Text = mo_mrzj.N_TBSYTY.ToString();
            this.lbtbdzsy.Text = mo_mrzj.N_TBSYDZ.ToString();
            this.lbtbdcsy.Text = mo_mrzj.N_TBSYDC.ToString();
            this.lbtbtygg.Text = mo_mrzj.N_TBGGTY.ToString();
            this.lbtbdzgg.Text = mo_mrzj.N_TBGGDZ.ToString();
            this.lbtbdcgg.Text = mo_mrzj.N_TBGGDC.ToString();
            this.lbtbtybcrf.Text = mo_mrzj.N_TBGJTY.ToString();
            this.lbtbdzbcrf.Text = mo_mrzj.N_TBGJDZ.ToString();
            this.lbtbdcbcrf.Text = mo_mrzj.N_TBGJDC.ToString();
            #endregion

            //足 球 
            #region
            this.lbzqtyarf.Text = mo_mrzj.N_ZQARFTY.ToString();
            this.lbzqtybrf.Text = mo_mrzj.N_ZQBRFTY.ToString();
            this.lbzqtycrf.Text = mo_mrzj.N_ZQCRFTY.ToString();
            this.lbzqdzrf.Text = mo_mrzj.N_ZQRFDZ.ToString();
            this.lbzqdcrf.Text = mo_mrzj.N_ZQRFDC.ToString();
            this.lbzqtyadx.Text = mo_mrzj.N_ZQADXTY.ToString();
            this.lbzqtybdx.Text = mo_mrzj.N_ZQBDXTY.ToString();
            this.lbzqtycdx.Text = mo_mrzj.N_ZQCDXTY.ToString();
            this.lbzqdzdx.Text = mo_mrzj.N_ZQDXDZ.ToString();
            this.lbzqdcdx.Text = mo_mrzj.N_ZQDXDC.ToString();
            this.lbzqtyady.Text = mo_mrzj.N_ZQADYTY.ToString();
            this.lbzqtybdy.Text = mo_mrzj.N_ZQBDYTY.ToString();
            this.lbzqtycdy.Text = mo_mrzj.N_ZQCDYTY.ToString();
            this.lbzqdzdy.Text = mo_mrzj.N_ZQDYDZ.ToString();
            this.lbzqdcdy.Text = mo_mrzj.N_ZQDYDC.ToString();
            this.lbzqtyads.Text = mo_mrzj.N_ZQADSTY.ToString();
            this.lbzqtybds.Text = mo_mrzj.N_ZQBDSTY.ToString();
            this.lbzqtycds.Text = mo_mrzj.N_ZQCDSTY.ToString();
            this.lbzqdzds.Text = mo_mrzj.N_ZQDSDZ.ToString();
            this.lbzqdcds.Text = mo_mrzj.N_ZQDSDC.ToString();
            this.lbzqtyazdrf.Text = mo_mrzj.N_ZQAZDRFTY.ToString();
            this.lbzqtybzdrf.Text = mo_mrzj.N_ZQBZDRFTY.ToString();
            this.lbzqtyczdrf.Text = mo_mrzj.N_ZQCZDRFTY.ToString();
            this.lbzqdzzdrf.Text = mo_mrzj.N_ZQZDRFDZ.ToString();
            this.lbzqdczdrf.Text = mo_mrzj.N_ZQZDRFDC.ToString();
            this.lbzqtyazddx.Text = mo_mrzj.N_ZQAZDDXTY.ToString();
            this.lbzqtybzddx.Text = mo_mrzj.N_ZQBZDDXTY.ToString();
            this.lbzqtyczddx.Text = mo_mrzj.N_ZQCZDDXTY.ToString();
            this.lbzqdzzddx.Text = mo_mrzj.N_ZQZDDXDZ.ToString();
            this.lbzqdczddx.Text = mo_mrzj.N_ZQZDDXDC.ToString();
            this.lbzqtyabcrf.Text = mo_mrzj.N_ZQABCRFTY.ToString();
            this.lbzqtybbcrf.Text = mo_mrzj.N_ZQBBCRFTY.ToString();
            this.lbzqtycbcrf.Text = mo_mrzj.N_ZQCBCRFTY.ToString();
            this.lbzqdzbcrf.Text = mo_mrzj.N_ZQBCRFDZ.ToString();
            this.lbzqdcbcrf.Text = mo_mrzj.N_ZQBCRFDC.ToString();
            this.lbzqtyabcdx.Text = mo_mrzj.N_ZQABCDXTY.ToString();
            this.lbzqtybbcdx.Text = mo_mrzj.N_ZQBBCDXTY.ToString();
            this.lbzqtycbcdx.Text = mo_mrzj.N_ZQCBCDXTY.ToString();
            this.lbzqdzbcdx.Text = mo_mrzj.N_ZQBCDXDZ.ToString();
            this.lbzqdcbcdx.Text = mo_mrzj.N_ZQBCDXDC.ToString();
            this.lbzqtyabcdy.Text = mo_mrzj.N_ZQABCDYTY.ToString();
            this.lbzqtybbcdy.Text = mo_mrzj.N_ZQBBCDYTY.ToString();
            this.lbzqtycbcdy.Text = mo_mrzj.N_ZQCBCDYTY.ToString();
            this.lbzqdzbcdy.Text = mo_mrzj.N_ZQBCDYDZ.ToString();
            this.lbzqdcbcdy.Text = mo_mrzj.N_ZQBCDYDC.ToString();
            this.lbzqtyarqs.Text = mo_mrzj.N_ZQARQSTY.ToString();
            this.lbzqtybrqs.Text = mo_mrzj.N_ZQBRQSTY.ToString();
            this.lbzqtycrqs.Text = mo_mrzj.N_ZQCRQSTY.ToString();
            this.lbzqdzrqs.Text = mo_mrzj.N_ZQRQSDZ.ToString();
            this.lbzqdcrqs.Text = mo_mrzj.N_ZQRQSDC.ToString();
            this.lbzqtyabd.Text = mo_mrzj.N_ZQABDTY.ToString();
            this.lbzqtybbd.Text = mo_mrzj.N_ZQBBDTY.ToString();
            this.lbzqtycbd.Text = mo_mrzj.N_ZQCBDTY.ToString();
            this.lbzqdzbd.Text = mo_mrzj.N_ZQBDDZ.ToString();
            this.lbzqdcbd.Text = mo_mrzj.N_ZQBDDC.ToString();
            this.lbzqtyabqc.Text = mo_mrzj.N_ZQABQCTY.ToString();
            this.lbzqtybbqc.Text = mo_mrzj.N_ZQBBQCTY.ToString();
            this.lbzqtycbqc.Text = mo_mrzj.N_ZQCBQCTY.ToString();
            this.lbzqdzbqc.Text = mo_mrzj.N_ZQBQCDZ.ToString();
            this.lbzqdcbqc.Text = mo_mrzj.N_ZQBQCDC.ToString();
            this.lbzqtyagg.Text = mo_mrzj.N_ZQAGGTY.ToString();
            this.lbzqtybgg.Text = mo_mrzj.N_ZQBGGTY.ToString();
            this.lbzqtycgg.Text = mo_mrzj.N_ZQCGGTY.ToString();
            this.lbzqdzgg.Text = mo_mrzj.N_ZQGGDZ.ToString();
            this.lbzqdcgg.Text = mo_mrzj.N_ZQGGDC.ToString();
            this.lbzqtyagj.Text = mo_mrzj.N_ZQAGJTY.ToString();
            this.lbzqtybgj.Text = mo_mrzj.N_ZQBGJTY.ToString();
            this.lbzqtycgj.Text = mo_mrzj.N_ZQCGJTY.ToString();
            this.lbzqdzgj.Text = mo_mrzj.N_ZQGJDZ.ToString();
            this.lbzqdcgj.Text = mo_mrzj.N_ZQGJDC.ToString();
            #endregion
            //美足
            #region
            this.lbmztyrf.Text = mo_mrzj.N_MZRFTY.ToString();
            this.lbmzdzrf.Text = mo_mrzj.N_MZRFDZ.ToString();
            this.lbmzdcrf.Text = mo_mrzj.N_MZRFDC.ToString();
            this.lbmztydx.Text = mo_mrzj.N_MZDXTY.ToString();
            this.lbmzdzdx.Text = mo_mrzj.N_MZDXDZ.ToString();
            this.lbmzdcdx.Text = mo_mrzj.N_MZDXDC.ToString();
            this.lbmztydy.Text = mo_mrzj.N_MZDYTY.ToString();
            this.lbmzdzdy.Text = mo_mrzj.N_MZDYDZ.ToString();
            this.lbmzdcdy.Text = mo_mrzj.N_MZDYDC.ToString();
            this.lbmztyds.Text = mo_mrzj.N_MZDSTY.ToString();
            this.lbmzdzds.Text = mo_mrzj.N_MZDSDZ.ToString();
            this.lbmzdcds.Text = mo_mrzj.N_MZDSDC.ToString();
            this.lbmztyzdrf.Text = mo_mrzj.N_MZZDRFTY.ToString();
            this.lbmzdzzdrf.Text = mo_mrzj.N_MZZDRFDZ.ToString();
            this.lbmzdczdrf.Text = mo_mrzj.N_MZZDRFDC.ToString();
            this.lbmztyzddx.Text = mo_mrzj.N_MZZDDXTY.ToString();
            this.lbmzdzzddx.Text = mo_mrzj.N_MZZDDXDZ.ToString();
            this.lbmzdczddx.Text = mo_mrzj.N_MZZDDXDC.ToString();
            this.lbmztybcrf.Text = mo_mrzj.N_MZBCRFTY.ToString();
            this.lbmzdzbcrf.Text = mo_mrzj.N_MZBCRFDZ.ToString();
            this.lbmzdcbcrf.Text = mo_mrzj.N_MZBCRFDC.ToString();
            this.lbmztybcdx.Text = mo_mrzj.N_MZBCDXTY.ToString();
            this.lbmzdzbcdx.Text = mo_mrzj.N_MZBCDXDZ.ToString();
            this.lbmzdcbcdx.Text = mo_mrzj.N_MZBCDXDC.ToString();
            this.lbmztybcdy.Text = mo_mrzj.N_MZBCDYTY.ToString();
            this.lbmzdzbcdy.Text = mo_mrzj.N_MZBCDYDZ.ToString();
            this.lbmzdcbcdy.Text = mo_mrzj.N_MZBCDYDC.ToString();
            this.lbmztybcds.Text = mo_mrzj.N_MZBCDSTY.ToString();
            this.lbmzdzbcds.Text = mo_mrzj.N_MZBCDSDZ.ToString();
            this.lbmzdcbcds.Text = mo_mrzj.N_MZBCDSDC.ToString();
            this.lbmztygg.Text = mo_mrzj.N_MZGGTY.ToString();
            this.lbmzdzgg.Text = mo_mrzj.N_MZGGDZ.ToString();
            this.lbmzdcgg.Text = mo_mrzj.N_MZGGDC.ToString();
            this.lbmztygj.Text = mo_mrzj.N_MZGJTY.ToString();
            this.lbmzdzgj.Text = mo_mrzj.N_MZGJDZ.ToString();
            this.lbmzdcgj.Text = mo_mrzj.N_MZGJDC.ToString();
            #endregion

            //冰球
            #region
            this.lbbqtyrf.Text = mo_mrzj.N_BQRFTY.ToString();
            this.lbbqdzrf.Text = mo_mrzj.N_BQRFDZ.ToString();
            this.lbbqdcrf.Text = mo_mrzj.N_BQRFDC.ToString();
            this.lbbqtydx.Text = mo_mrzj.N_BQDXTY.ToString();
            this.lbbqdzdx.Text = mo_mrzj.N_BQDXDZ.ToString();
            this.lbbqdcdx.Text = mo_mrzj.N_BQDXDC.ToString();
            this.lbbqtydy.Text = mo_mrzj.N_BQDYTY.ToString();
            this.lbbqdzdy.Text = mo_mrzj.N_BQDYDZ.ToString();
            this.lbbqdcdy.Text = mo_mrzj.N_BQDYDC.ToString();
            this.lbbqtyds.Text = mo_mrzj.N_BQDSTY.ToString();
            this.lbbqdzds.Text = mo_mrzj.N_BQDSDZ.ToString();
            this.lbbqdcds.Text = mo_mrzj.N_BQDSDC.ToString();
            this.lbbqtyzdrf.Text = mo_mrzj.N_BQZDRFTY.ToString();
            this.lbbqdzzdrf.Text = mo_mrzj.N_BQZDRFDZ.ToString();
            this.lbbqdczdrf.Text = mo_mrzj.N_BQZDRFDC.ToString();
            this.lbbqtyzddx.Text = mo_mrzj.N_BQZDDXTY.ToString();
            this.lbbqdzzddx.Text = mo_mrzj.N_BQZDDXDZ.ToString();
            this.lbbqdczddx.Text = mo_mrzj.N_BQZDDXDC.ToString();
            this.lbbqtysy.Text = mo_mrzj.N_BQSYTY.ToString();
            this.lbbqdzsy.Text = mo_mrzj.N_BQSYDZ.ToString();
            this.lbbqdcsy.Text = mo_mrzj.N_BQSYDC.ToString();
            this.lbbqtygg.Text = mo_mrzj.N_BQGGTY.ToString();
            this.lbbqdzgg.Text = mo_mrzj.N_BQGGDZ.ToString();
            this.lbbqdcgg.Text = mo_mrzj.N_BQGGDC.ToString();
            this.lbbqtybcrf.Text = mo_mrzj.N_BQGJTY.ToString();
            this.lbbqdzbcrf.Text = mo_mrzj.N_BQGJDZ.ToString();
            this.lbbqdcbcrf.Text = mo_mrzj.N_BQGJDC.ToString();
            #endregion

            //彩球
            #region
            this.lbcqtyrf.Text = mo_mrzj.N_CQRFTY.ToString();
            this.lbcqdzrf.Text = mo_mrzj.N_CQRFDZ.ToString();
            this.lbcqdcrf.Text = mo_mrzj.N_CQRFDC.ToString();
            this.lbcqtydx.Text = mo_mrzj.N_CQDXTY.ToString();
            this.lbcqdzdx.Text = mo_mrzj.N_CQDXDZ.ToString();
            this.lbcqdcdx.Text = mo_mrzj.N_CQDXDC.ToString();
            this.lbcqtydy.Text = mo_mrzj.N_CQDYTY.ToString();
            this.lbcqdzdy.Text = mo_mrzj.N_CQDYDZ.ToString();
            this.lbcqdcdy.Text = mo_mrzj.N_CQDYDC.ToString();
            this.lbcqtyds.Text = mo_mrzj.N_CQDSTY.ToString();
            this.lbcqdzds.Text = mo_mrzj.N_CQDSDZ.ToString();
            this.lbcqdcds.Text = mo_mrzj.N_CQDSDC.ToString();
            this.lbcqtyzdrf.Text = mo_mrzj.N_CQZDRFTY.ToString();
            this.lbcqdzzdrf.Text = mo_mrzj.N_CQZDRFDZ.ToString();
            this.lbcqdczdrf.Text = mo_mrzj.N_CQZDRFDC.ToString();
            this.lbcqtyzddx.Text = mo_mrzj.N_CQZDDXTY.ToString();
            this.lbcqdzzddx.Text = mo_mrzj.N_CQZDDXDZ.ToString();
            this.lbcqdczddx.Text = mo_mrzj.N_CQZDDXDC.ToString();
            this.lbcqtybcrf.Text = mo_mrzj.N_CQBCRFTY.ToString();
            this.lbcqdzbcrf.Text = mo_mrzj.N_CQBCRFDZ.ToString();
            this.lbcqdcbcrf.Text = mo_mrzj.N_CQBCRFDC.ToString();
            this.lbcqtybcdx.Text = mo_mrzj.N_CQBCDXTY.ToString();
            this.lbcqdzbcdx.Text = mo_mrzj.N_CQBCDXDZ.ToString();
            this.lbcqdcbcdx.Text = mo_mrzj.N_CQBCDXDC.ToString();
            this.lbcqtybcdy.Text = mo_mrzj.N_CQBCDYTY.ToString();
            this.lbcqdzbcdy.Text = mo_mrzj.N_CQBCDYDZ.ToString();
            this.lbcqdcbcdy.Text = mo_mrzj.N_CQBCDYDC.ToString();
            this.lbcqtybcds.Text = mo_mrzj.N_CQBCDSTY.ToString();
            this.lbcqdzbcds.Text = mo_mrzj.N_CQBCDSDZ.ToString();
            this.lbcqdcbcds.Text = mo_mrzj.N_CQBCDSDC.ToString();
            this.lbcqtygg.Text = mo_mrzj.N_CQGGTY.ToString();
            this.lbcqdzgg.Text = mo_mrzj.N_CQGGDZ.ToString();
            this.lbcqdcgg.Text = mo_mrzj.N_CQGGDC.ToString();
            this.lbcqtygj.Text = mo_mrzj.N_CQGJTY.ToString();
            this.lbcqdzgj.Text = mo_mrzj.N_CQGJDZ.ToString();
            this.lbcqdcgj.Text = mo_mrzj.N_CQGJDC.ToString();
            #endregion


            //指数
            #region
            this.lbzstyrf.Text = mo_mrzj.N_ZSRFTY.ToString();
            this.lbzsdzrf.Text = mo_mrzj.N_ZSRFDZ.ToString();
            this.lbzsdcrf.Text = mo_mrzj.N_ZSRFDC.ToString();
            this.lbzstydx.Text = mo_mrzj.N_ZSDXTY.ToString();
            this.lbzsdzdx.Text = mo_mrzj.N_ZSDXDZ.ToString();
            this.lbzsdcdx.Text = mo_mrzj.N_ZSDXDC.ToString();
            this.lbzstydy.Text = mo_mrzj.N_ZSDYTY.ToString();
            this.lbzsdzdy.Text = mo_mrzj.N_ZSDYDZ.ToString();
            this.lbzsdcdy.Text = mo_mrzj.N_ZSDYDC.ToString();
            this.lbzstyds.Text = mo_mrzj.N_ZSDSTY.ToString();
            this.lbzsdzds.Text = mo_mrzj.N_ZSDSDZ.ToString();
            this.lbzsdcds.Text = mo_mrzj.N_ZSDSDC.ToString();
            this.lbzstyzdrf.Text = mo_mrzj.N_ZSZDRFTY.ToString();
            this.lbzsdzzdrf.Text = mo_mrzj.N_ZSZDRFDZ.ToString();
            this.lbzsdczdrf.Text = mo_mrzj.N_ZSZDRFDC.ToString();
            this.lbzstyzddx.Text = mo_mrzj.N_ZSZDDXTY.ToString();
            this.lbzsdzzddx.Text = mo_mrzj.N_ZSZDDXDZ.ToString();
            this.lbzsdczddx.Text = mo_mrzj.N_ZSZDDXDC.ToString();
            this.lbzstysy.Text = mo_mrzj.N_ZSSYTY.ToString();
            this.lbzsdzsy.Text = mo_mrzj.N_ZSSYDZ.ToString();
            this.lbzsdcsy.Text = mo_mrzj.N_ZSSYDC.ToString();
            this.lbzstybd.Text = mo_mrzj.N_ZSBDTY.ToString();
            this.lbzsdzbd.Text = mo_mrzj.N_ZBDDZ.ToString();
            this.lbzsdcbd.Text = mo_mrzj.N_ZSBDDC.ToString();
            this.lbzstygg.Text = mo_mrzj.N_ZSGGTY.ToString();
            this.lbzsdzgg.Text = mo_mrzj.N_ZSGGDZ.ToString();
            this.lbzsdcgg.Text = mo_mrzj.N_ZSGGDC.ToString();
            this.lbzstygj.Text = mo_mrzj.N_ZSGJTY.ToString();
            this.lbzsdzgj.Text = mo_mrzj.N_ZSGJDZ.ToString();
            this.lbzsdcgj.Text = mo_mrzj.N_ZSGJDC.ToString();
            #endregion
            //赛马
            #region
            this.lbsmtydy.Text = mo_mrzj.N_SMTYDY.ToString();
            this.lbsmdzdy.Text = mo_mrzj.N_SMDZDY.ToString();
            this.lbsmdcdy.Text = mo_mrzj.N_SMDCDY.ToString();
            this.lbsmtywz.Text = mo_mrzj.N_SMTYWZ.ToString();
            this.lbsmdzwz.Text = mo_mrzj.N_SMDZWZ.ToString();
            this.lbsmdcwz.Text = mo_mrzj.N_SMDCWZ.ToString();
            this.lbsmtyly.Text = mo_mrzj.N_SMTYLY.ToString();
            this.lbsmdzly.Text = mo_mrzj.N_SMDZLY.ToString();
            this.lbsmdcly.Text = mo_mrzj.N_SMDCLY.ToString();
            this.lbsmtywzq.Text = mo_mrzj.N_SMTYWZQ.ToString();
            this.lbsmdzwzq.Text = mo_mrzj.N_SMDZWZQ.ToString();
            this.lbsmdcwzq.Text = mo_mrzj.N_SMDCWZQ.ToString();
            #endregion
            //六合彩
            #region
            this.lblhctytbh.Text = mo_mrzj.N_LHCTYTBH.ToString();
            this.lblhcdztbh.Text = mo_mrzj.N_LHCDZTBH.ToString();
            this.lblhcdctbh.Text = mo_mrzj.N_LHCDCTBH.ToString();
            this.lblhctytt.Text = mo_mrzj.N_LHCTYTT.ToString();
            this.lblhcdztt.Text = mo_mrzj.N_LHCDZTT.ToString();
            this.lblhcdctt.Text = mo_mrzj.N_LHCDCTT.ToString();
            this.lblhctyth.Text = mo_mrzj.N_LHCTYTH.ToString();
            this.lblhcdzth.Text = mo_mrzj.N_LHCDZTH.ToString();
            this.lblhcdcth.Text = mo_mrzj.N_LHCDCTH.ToString();
            this.lblhctyqcp.Text = mo_mrzj.N_LHCTYQCP.ToString();
            this.lblhcdzqcp.Text = mo_mrzj.N_LHCDZQCP.ToString();
            this.lblhcdcqcp.Text = mo_mrzj.N_LHCDCQCP.ToString();
            this.lblhcty2x.Text = mo_mrzj.N_LHCTY2X.ToString();
            this.lblhcdz2x.Text = mo_mrzj.N_LHCDZ2X.ToString();
            this.lblhcdc2x.Text = mo_mrzj.N_LHCDC2X.ToString();
            this.lblhcty3x.Text = mo_mrzj.N_LHCTY3X.ToString();
            this.lblhcdz3x.Text = mo_mrzj.N_LHCDZ3X.ToString();
            this.lblhcdc3x.Text = mo_mrzj.N_LHCDC3X.ToString();
            this.lblhcty4x.Text = mo_mrzj.N_LHCTY4X.ToString();
            this.lblhcdz4x.Text = mo_mrzj.N_LHCDZ4X.ToString();
            this.lblhcdc4x.Text = mo_mrzj.N_LHCDC4X.ToString();
            this.lblhctygdds.Text = mo_mrzj.N_LHCTYGDDS.ToString();
            this.lblhcdzgdds.Text = mo_mrzj.N_LHCDZGDDS.ToString();
            this.lblhcdcgdds.Text = mo_mrzj.N_LHCDCGDDS.ToString();
            this.lblhctygddx.Text = mo_mrzj.N_LHCTYGDDX.ToString();
            this.lblhcdzgddx.Text = mo_mrzj.N_LHCDZGDDX.ToString();
            this.lblhcdcgddx.Text = mo_mrzj.N_LHCDCGDDX.ToString();
            #endregion
            //大乐透
            #region
            this.lbdlttytbh.Text = mo_mrzj.N_DLTTYTBH.ToString();
            this.lbdltdztbh.Text = mo_mrzj.N_DLTDZTBH.ToString();
            this.lbdltdctbh.Text = mo_mrzj.N_DLTDCTBH.ToString();
            this.lbdlttytt.Text = mo_mrzj.N_DLTTYTT.ToString();
            this.lbdltdztt.Text = mo_mrzj.N_DLTDZTT.ToString();
            this.lbdltdctt.Text = mo_mrzj.N_DLTDCTT.ToString();
            this.lbdlttyth.Text = mo_mrzj.N_DLTTYTH.ToString();
            this.lbdltdzth.Text = mo_mrzj.N_DLTDZTH.ToString();
            this.lbdltdcth.Text = mo_mrzj.N_DLTDCTH.ToString();
            this.lbdlttyqcp.Text = mo_mrzj.N_DLTTYQCP.ToString();
            this.lbdltdzqcp.Text = mo_mrzj.N_DLTDZQCP.ToString();
            this.lbdltdcqcp.Text = mo_mrzj.N_DLTDCQCP.ToString();
            this.lbdltty2x.Text = mo_mrzj.N_DLTTY2X.ToString();
            this.lbdltdz2x.Text = mo_mrzj.N_DLTDZ2X.ToString();
            this.lbdltdc2x.Text = mo_mrzj.N_DLTDC2X.ToString();
            this.lbdltty3x.Text = mo_mrzj.N_DLTTY3X.ToString();
            this.lbdltdz3x.Text = mo_mrzj.N_DLTDZ3X.ToString();
            this.lbdltdc3x.Text = mo_mrzj.N_DLTDC3X.ToString();
            this.lbdltty4x.Text = mo_mrzj.N_DLTTY4X.ToString();
            this.lbdltdz4x.Text = mo_mrzj.N_DLTDZ4X.ToString();
            this.lbdltdc4x.Text = mo_mrzj.N_DLTDC4X.ToString();
            this.lbdlttygdds.Text = mo_mrzj.N_DLTTYGDDS.ToString();
            this.lbdltdzgdds.Text = mo_mrzj.N_DLTDZGDDS.ToString();
            this.lbdltdcgdds.Text = mo_mrzj.N_DLTDCGDDS.ToString();
            this.lbdlttygddx.Text = mo_mrzj.N_DLTTYGDDX.ToString();
            this.lbdltdzgddx.Text = mo_mrzj.N_DLTDZGDDX.ToString();
            this.lbdltdcgddx.Text = mo_mrzj.N_DLTDCGDDX.ToString();
            #endregion
            //大乐透
            #region
            this.lbjc539tyqcp.Text = mo_mrzj.N_JC539TYQCP.ToString();
            this.lbjc539dzqcp.Text = mo_mrzj.N_JC539DZQCP.ToString();
            this.lbjc539dcqcp.Text = mo_mrzj.N_JC539DCQCP.ToString();
            this.lbjc539ty2x.Text = mo_mrzj.N_JC539TY2X.ToString();
            this.lbjc539dz2x.Text = mo_mrzj.N_JC539DZ2X.ToString();
            this.lbjc539dc2x.Text = mo_mrzj.N_JC539DC2X.ToString();
            this.lbjc539ty3x.Text = mo_mrzj.N_JC539TY3X.ToString();
            this.lbjc539dz3x.Text = mo_mrzj.N_JC539DZ3X.ToString();
            this.lbjc539dc3x.Text = mo_mrzj.N_JC539DC3X.ToString();
            this.lbjc539ty4x.Text = mo_mrzj.N_JC539TY4X.ToString();
            this.lbjc539dz4x.Text = mo_mrzj.N_JC539DZ4X.ToString();
            this.lbjc539dc4x.Text = mo_mrzj.N_JC539DC4X.ToString();
            #endregion
            //运动彩票
            #region
            this.lbcptybq.Text = mo_mrzj.N_CPTYBQ.ToString();
            this.lbcpdzbq.Text = mo_mrzj.N_CPDZBQ.ToString();
            this.lbcpdcbq.Text = mo_mrzj.N_CPDCBQ.ToString();
            this.lbcptylq.Text = mo_mrzj.N_CPTYLQ.ToString();
            this.lbcpdzlq.Text = mo_mrzj.N_CPDZLQ.ToString();
            this.lbcpdclq.Text = mo_mrzj.N_CPDCLQ.ToString();
            this.lbcptyzq.Text = mo_mrzj.N_CPTYZQ.ToString();
            this.lbcpdzzq.Text = mo_mrzj.N_CPDZZQ.ToString();
            this.lbcpdczq.Text = mo_mrzj.N_CPDCZQ.ToString();
            this.lbcptygs.Text = mo_mrzj.N_CPTYGS.ToString();
            this.lbcpdzgs.Text = mo_mrzj.N_CPDZGS.ToString();
            this.lbcpdcgs.Text = mo_mrzj.N_CPDCGS.ToString();
            this.lbcptyqz.Text = mo_mrzj.N_CPTYQZ.ToString();
            this.lbcpdzqz.Text = mo_mrzj.N_CPDZQZ.ToString();
            this.lbcpdcqz.Text = mo_mrzj.N_CPDCQZ.ToString();
            #endregion
            //時事
            #region
            this.lbsstydy.Text = mo_mrzj.N_SSTYDY.ToString();
            this.lbssdzdy.Text = mo_mrzj.N_SSDZDY.ToString();
            this.lbssdcdy.Text = mo_mrzj.N_SSDCDY.ToString();
            #endregion
        }

        #endregion
        #region"各級赋值"
        public void HYFZ()
        {

           
            KFB_ZHGL mo_zhgl = this.objAgentManageDB.GetModel(strparid);
            //帳號信息
            this.lbzj.Text = mo_zhgl.N_HYZH.ToString();
            this.txtzjmc.Text = mo_zhgl.N_HYMC.ToString();
            // this.txtmm.Text = "...";
            // this.txtzrmm.Text = "...";
            this.hidxy.Value = mo_zhgl.N_KYED.ToString();
            this.txtxyed.Text = mo_zhgl.N_KYED.ToString();
            this.txtsyed.Text = mo_zhgl.N_SYED.ToString();
            this.Rdyxdl.SelectedValue = mo_zhgl.N_YXDL.ToString();
            this.Rdyxxz.SelectedValue = mo_zhgl.N_YXXZ.ToString();
            this.Rdycxz.SelectedValue = mo_zhgl.N_XZYC.ToString();
            this.txtddsx.Text = mo_zhgl.N_DDSX.ToString();
            //拆帐赋值
            this.txtczlq.Text = mo_zhgl.N_LQCZ.ToString();
            this.txtczmb.Text = mo_zhgl.N_MBCZ.ToString();
            this.txtczrb.Text = mo_zhgl.N_RBCZ.ToString();
            this.txtcztb.Text = mo_zhgl.N_TBCZ.ToString();
            this.txtczmz.Text = mo_zhgl.N_MZCZ.ToString();
            this.txtczzq.Text = mo_zhgl.N_ZQCZ.ToString();
            this.txtczzs.Text = mo_zhgl.N_ZSCZ.ToString();
            this.txtczdlt.Text = mo_zhgl.N_DLTCZ.ToString();
            this.txtczsm.Text = mo_zhgl.N_SMCZ.ToString();
            this.txtczlhc.Text = mo_zhgl.N_LHCCZ.ToString();
            this.txtcz2x.Text = mo_zhgl.N_2XCZ.ToString();
            this.txtcz3x.Text = mo_zhgl.N_3XCZ.ToString();
            this.txtcz4x.Text = mo_zhgl.N_4XCZ.ToString();
            this.txtczjc539.Text = mo_zhgl.N_JCCZ.ToString();
            this.txtczcp.Text = mo_zhgl.N_CPCZ.ToString();
            this.txtczss.Text = mo_zhgl.N_SSCZ.ToString();

            this.txtczbq.Text = mo_zhgl.N_BQCZ.ToString();
            this.txtczcq.Text = mo_zhgl.N_CQCZ.ToString();

            this.drpXiazhuNum.SelectedValue = mo_zhgl.N_TOLLGATE.ToString();

            //取得 已開出的額度
            string strsjzh = "";
            if (!strlvl.Equals("4"))
            {
                strsjzh = this.objAgentManageDB.Getsjzh(strparid, strlvl);
                string stryked = this.objAgentManageDB.Getsyed(strsjzh);
                //string stryked = o_zhgl.Getxyed(strsjzh);
                //string stryyed = o_zhgl.GetED(strsjzh, strlvl);
                // this.hidje.Value = Convert.ToString(Convert.ToDecimal(stryked) - Convert.ToDecimal(stryyed) + Convert.ToDecimal(mo_zhgl.N_KYED));
                this.hidje.Value = Convert.ToString(Convert.ToDecimal(stryked) + Convert.ToDecimal(Comm.Trim(this.txtxyed.Text)));

            }
            else
            {
                this.hidje.Value = "1000000000";
            }


            KFB_SETUPLQ mo_lq = this.objAgentManageAddDB.GetModelLQ(strparid);

            //篮球 
            #region
            this.txtlqtyrf.Text = mo_lq.N_RFTY.ToString();
            this.txtlqdzrf.Text = mo_lq.N_RFDZ.ToString();
            this.txtlqdcrf.Text = mo_lq.N_RFDC.ToString();
            this.txtlqddrf.Text = mo_lq.N_RFDD.ToString();
            this.txtlqtydx.Text = mo_lq.N_DXTY.ToString();
            this.txtlqdzdx.Text = mo_lq.N_DXDZ.ToString();
            this.txtlqdcdx.Text = mo_lq.N_DXDC.ToString();
            this.txtlqdddx.Text = mo_lq.N_DXDD.ToString();
            this.txtlqtydy.Text = mo_lq.N_DYTY.ToString();
            this.txtlqdzdy.Text = mo_lq.N_DYDZ.ToString();
            this.txtlqdcdy.Text = mo_lq.N_DYDC.ToString();
            this.txtlqdddy.Text = mo_lq.N_DYDD.ToString();
            this.txtlqtyds.Text = mo_lq.N_DSTY.ToString();
            this.txtlqdzds.Text = mo_lq.N_DSDZ.ToString();
            this.txtlqdcds.Text = mo_lq.N_DSDC.ToString();
            this.txtlqddds.Text = mo_lq.N_DSDD.ToString();
            this.txtlqtyzdrf.Text = mo_lq.N_ZDRFTY.ToString();
            this.txtlqdzzdrf.Text = mo_lq.N_ZDRFDZ.ToString();
            this.txtlqdczdrf.Text = mo_lq.N_ZDRFDC.ToString();
            this.txtlqddzdrf.Text = mo_lq.N_ZDRFDD.ToString();
            this.txtlqtyzddx.Text = mo_lq.N_ZDDXTY.ToString();
            this.txtlqdzzddx.Text = mo_lq.N_ZDDXDZ.ToString();
            this.txtlqdczddx.Text = mo_lq.N_ZDDXDC.ToString();
            this.txtlqddzddx.Text = mo_lq.N_ZDDXDD.ToString();
            this.txtlqtybcrf.Text = mo_lq.N_BCRFTY.ToString();
            this.txtlqdzbcrf.Text = mo_lq.N_BCRFDZ.ToString();
            this.txtlqdcbcrf.Text = mo_lq.N_BCRFDC.ToString();
            this.txtlqddbcrf.Text = mo_lq.N_BCRFDD.ToString();
            this.txtlqtybcdx.Text = mo_lq.N_BCDXTY.ToString();
            this.txtlqdzbcdx.Text = mo_lq.N_BCDXDZ.ToString();
            this.txtlqdcbcdx.Text = mo_lq.N_BCDXDC.ToString();
            this.txtlqddbcdx.Text = mo_lq.N_BCDXDD.ToString();
            this.txtlqtybcdy.Text = mo_lq.N_BCDYTY.ToString();
            this.txtlqdzbcdy.Text = mo_lq.N_BCDYDZ.ToString();
            this.txtlqdcbcdy.Text = mo_lq.N_BCDYDC.ToString();
            this.txtlqddbcdy.Text = mo_lq.N_BCDYDD.ToString();
            this.txtlqtybcds.Text = mo_lq.N_BCDSTY.ToString();
            this.txtlqdzbcds.Text = mo_lq.N_BCDSDZ.ToString();
            this.txtlqdcbcds.Text = mo_lq.N_BCDSDC.ToString();
            this.txtlqddbcds.Text = mo_lq.N_BCDSDD.ToString();
            this.txtlqtygg.Text = mo_lq.N_GGTY.ToString();
            this.txtlqdzgg.Text = mo_lq.N_GGDZ.ToString();
            this.txtlqdcgg.Text = mo_lq.N_GGDC.ToString();
            this.txtlqddgg.Text = mo_lq.N_GGDD.ToString();
            this.txtlqtygj.Text = mo_lq.N_GJTY.ToString();
            this.txtlqdzgj.Text = mo_lq.N_GJDZ.ToString();
            this.txtlqdcgj.Text = mo_lq.N_GJDC.ToString();
            this.txtlqddgj.Text = mo_lq.N_GJDD.ToString();
            this.txtlqtydjrf.Text = mo_lq.N_DJRFTY.ToString();
            this.txtlqdzdjrf.Text = mo_lq.N_DJRFDZ.ToString();
            this.txtlqdcdjrf.Text = mo_lq.N_DJRFDC.ToString();
            this.txtlqdddjrf.Text = mo_lq.N_DJRFDD.ToString();
            this.txtlqtydjdx.Text = mo_lq.N_DJDXTY.ToString();
            this.txtlqdzdjdx.Text = mo_lq.N_DJDXDZ.ToString();
            this.txtlqdcdjdx.Text = mo_lq.N_DJDXDC.ToString();
            this.txtlqdddjdx.Text = mo_lq.N_DJDXDD.ToString();
            this.txtlqtydjds.Text = mo_lq.N_DJDSTY.ToString();
            this.txtlqdzdjds.Text = mo_lq.N_DJDSDZ.ToString();
            this.txtlqdcdjds.Text = mo_lq.N_DJDSDC.ToString();
            this.txtlqdddjds.Text = mo_lq.N_DJDSDD.ToString();
            #endregion
            KFB_SETUPMB mo_MB = objAgentManageAddDB.GetModelMB(strparid);

            //棒球 
            #region
            this.txtmbtyrf.Text = mo_MB.N_RFTY.ToString();
            this.txtmbdzrf.Text = mo_MB.N_RFDZ.ToString();
            this.txtmbdcrf.Text = mo_MB.N_RFDC.ToString();
            this.txtmbtydx.Text = mo_MB.N_DXTY.ToString();
            this.txtmbdzdx.Text = mo_MB.N_DXDZ.ToString();
            this.txtmbdcdx.Text = mo_MB.N_DXDC.ToString();
            this.txtmbtydy.Text = mo_MB.N_DYTY.ToString();
            this.txtmbdzdy.Text = mo_MB.N_DYDZ.ToString();
            this.txtmbdcdy.Text = mo_MB.N_DYDC.ToString();
            this.txtmbtyds.Text = mo_MB.N_DSTY.ToString();
            this.txtmbdzds.Text = mo_MB.N_DSDZ.ToString();
            this.txtmbdcds.Text = mo_MB.N_DSDC.ToString();
            this.txtmbtyzdrf.Text = mo_MB.N_ZDRFTY.ToString();
            this.txtmbdzzdrf.Text = mo_MB.N_ZDRFDZ.ToString();
            this.txtmbdczdrf.Text = mo_MB.N_ZDRFDC.ToString();
            this.txtmbtyzddx.Text = mo_MB.N_ZDDXTY.ToString();
            this.txtmbdzzddx.Text = mo_MB.N_ZDDXDZ.ToString();
            this.txtmbdczddx.Text = mo_MB.N_ZDDXDC.ToString();
            this.txtmbtysy.Text = mo_MB.N_SYTY.ToString();
            this.txtmbdzsy.Text = mo_MB.N_SYDZ.ToString();
            this.txtmbdcsy.Text = mo_MB.N_SYDC.ToString();
            this.txtmbtygg.Text = mo_MB.N_GGTY.ToString();
            this.txtmbdzgg.Text = mo_MB.N_GGDZ.ToString();
            this.txtmbdcgg.Text = mo_MB.N_GGDC.ToString();
            this.txtmbtybcrf.Text = mo_MB.N_GJTY.ToString();
            this.txtmbdzbcrf.Text = mo_MB.N_GJDZ.ToString();
            this.txtmbdcbcrf.Text = mo_MB.N_GJDC.ToString();
            #endregion
            KFB_SETUPRB mo_RB = objAgentManageAddDB.GetModelRB(strparid);
            //网球 
            #region
            this.txtrbtyrf.Text = mo_RB.N_RFTY.ToString();
            this.txtrbdzrf.Text = mo_RB.N_RFDZ.ToString();
            this.txtrbdcrf.Text = mo_RB.N_RFDC.ToString();
            this.txtrbtydx.Text = mo_RB.N_DXTY.ToString();
            this.txtrbdzdx.Text = mo_RB.N_DXDZ.ToString();
            this.txtrbdcdx.Text = mo_RB.N_DXDC.ToString();
            this.txtrbtydy.Text = mo_RB.N_DYTY.ToString();
            this.txtrbdzdy.Text = mo_RB.N_DYDZ.ToString();
            this.txtrbdcdy.Text = mo_RB.N_DYDC.ToString();
            this.txtrbtyds.Text = mo_RB.N_DSTY.ToString();
            this.txtrbdzds.Text = mo_RB.N_DSDZ.ToString();
            this.txtrbdcds.Text = mo_RB.N_DSDC.ToString();
            this.txtrbtyzdrf.Text = mo_RB.N_ZDRFTY.ToString();
            this.txtrbdzzdrf.Text = mo_RB.N_ZDRFDZ.ToString();
            this.txtrbdczdrf.Text = mo_RB.N_ZDRFDC.ToString();
            this.txtrbtyzddx.Text = mo_RB.N_ZDDXTY.ToString();
            this.txtrbdzzddx.Text = mo_RB.N_ZDDXDZ.ToString();
            this.txtrbdczddx.Text = mo_RB.N_ZDDXDC.ToString();
            this.txtrbtysy.Text = mo_RB.N_SYTY.ToString();
            this.txtrbdzsy.Text = mo_RB.N_SYDZ.ToString();
            this.txtrbdcsy.Text = mo_RB.N_SYDC.ToString();
            this.txtrbtygg.Text = mo_RB.N_GGTY.ToString();
            this.txtrbdzgg.Text = mo_RB.N_GGDZ.ToString();
            this.txtrbdcgg.Text = mo_RB.N_GGDC.ToString();
            this.txtrbtybcrf.Text = mo_RB.N_GJTY.ToString();
            this.txtrbdzbcrf.Text = mo_RB.N_GJDZ.ToString();
            this.txtrbdcbcrf.Text = mo_RB.N_GJDC.ToString();
            #endregion
            //排球 
            #region
            KFB_SETUPTB mo_TB = objAgentManageAddDB.GetModelTB(strparid);
            this.txttbtyrf.Text = mo_TB.N_RFTY.ToString();
            this.txttbdzrf.Text = mo_TB.N_RFDZ.ToString();
            this.txttbdcrf.Text = mo_TB.N_RFDC.ToString();
            this.txttbtydx.Text = mo_TB.N_DXTY.ToString();
            this.txttbdzdx.Text = mo_TB.N_DXDZ.ToString();
            this.txttbdcdx.Text = mo_TB.N_DXDC.ToString();
            this.txttbtydy.Text = mo_TB.N_DYTY.ToString();
            this.txttbdzdy.Text = mo_TB.N_DYDZ.ToString();
            this.txttbdcdy.Text = mo_TB.N_DYDC.ToString();
            this.txttbtyds.Text = mo_TB.N_DSTY.ToString();
            this.txttbdzds.Text = mo_TB.N_DSDZ.ToString();
            this.txttbdcds.Text = mo_TB.N_DSDC.ToString();
            this.txttbtyzdrf.Text = mo_TB.N_ZDRFTY.ToString();
            this.txttbdzzdrf.Text = mo_TB.N_ZDRFDZ.ToString();
            this.txttbdczdrf.Text = mo_TB.N_ZDRFDC.ToString();
            this.txttbtyzddx.Text = mo_TB.N_ZDDXTY.ToString();
            this.txttbdzzddx.Text = mo_TB.N_ZDDXDZ.ToString();
            this.txttbdczddx.Text = mo_TB.N_ZDDXDC.ToString();
            this.txttbtysy.Text = mo_TB.N_SYTY.ToString();
            this.txttbdzsy.Text = mo_TB.N_SYDZ.ToString();
            this.txttbdcsy.Text = mo_TB.N_SYDC.ToString();
            this.txttbtygg.Text = mo_TB.N_GGTY.ToString();
            this.txttbdzgg.Text = mo_TB.N_GGDZ.ToString();
            this.txttbdcgg.Text = mo_TB.N_GGDC.ToString();
            this.txttbtybcrf.Text = mo_TB.N_GJTY.ToString();
            this.txttbdzbcrf.Text = mo_TB.N_GJDZ.ToString();
            this.txttbdcbcrf.Text = mo_TB.N_GJDC.ToString();
            #endregion
            //足 球 
            #region
            KFB_SETUPZQ mo_ZQ = objAgentManageAddDB.GetModelZQ(strparid);
            this.txtzqtyarf.Text = mo_ZQ.N_ARFTY.ToString();
            this.txtzqtybrf.Text = mo_ZQ.N_BRFTY.ToString();
            this.txtzqtycrf.Text = mo_ZQ.N_CRFTY.ToString();
            this.txtzqdzrf.Text = mo_ZQ.N_RFDZ.ToString();
            this.txtzqdcrf.Text = mo_ZQ.N_RFDC.ToString();
            this.txtzqtyadx.Text = mo_ZQ.N_ADXTY.ToString();
            this.txtzqtybdx.Text = mo_ZQ.N_BDXTY.ToString();
            this.txtzqtycdx.Text = mo_ZQ.N_CDXTY.ToString();
            this.txtzqdzdx.Text = mo_ZQ.N_DXDZ.ToString();
            this.txtzqdcdx.Text = mo_ZQ.N_DXDC.ToString();
            this.txtzqtyady.Text = mo_ZQ.N_ADYTY.ToString();
            this.txtzqtybdy.Text = mo_ZQ.N_BDYTY.ToString();
            this.txtzqtycdy.Text = mo_ZQ.N_CDYTY.ToString();
            this.txtzqdzdy.Text = mo_ZQ.N_DYDZ.ToString();
            this.txtzqdcdy.Text = mo_ZQ.N_DYDC.ToString();
            this.txtzqtyads.Text = mo_ZQ.N_ADSTY.ToString();
            this.txtzqtybds.Text = mo_ZQ.N_BDSTY.ToString();
            this.txtzqtycds.Text = mo_ZQ.N_CDSTY.ToString();
            this.txtzqdzds.Text = mo_ZQ.N_DSDZ.ToString();
            this.txtzqdcds.Text = mo_ZQ.N_DSDC.ToString();
            this.txtzqtyazdrf.Text = mo_ZQ.N_AZDRFTY.ToString();
            this.txtzqtybzdrf.Text = mo_ZQ.N_BZDRFTY.ToString();
            this.txtzqtyczdrf.Text = mo_ZQ.N_CZDRFTY.ToString();
            this.txtzqdzzdrf.Text = mo_ZQ.N_ZDRFDZ.ToString();
            this.txtzqdczdrf.Text = mo_ZQ.N_ZDRFDC.ToString();
            this.txtzqtyazddx.Text = mo_ZQ.N_AZDDXTY.ToString();
            this.txtzqtybzddx.Text = mo_ZQ.N_BZDDXTY.ToString();
            this.txtzqtyczddx.Text = mo_ZQ.N_CZDDXTY.ToString();
            this.txtzqdzzddx.Text = mo_ZQ.N_ZDDXDZ.ToString();
            this.txtzqdczddx.Text = mo_ZQ.N_ZDDXDC.ToString();
            this.txtzqtyabcrf.Text = mo_ZQ.N_ABCRFTY.ToString();
            this.txtzqtybbcrf.Text = mo_ZQ.N_BBCRFTY.ToString();
            this.txtzqtycbcrf.Text = mo_ZQ.N_CBCRFTY.ToString();
            this.txtzqdzbcrf.Text = mo_ZQ.N_BCRFDZ.ToString();
            this.txtzqdcbcrf.Text = mo_ZQ.N_BCRFDC.ToString();
            this.txtzqtyabcdx.Text = mo_ZQ.N_ABCDXTY.ToString();
            this.txtzqtybbcdx.Text = mo_ZQ.N_BBCDXTY.ToString();
            this.txtzqtycbcdx.Text = mo_ZQ.N_CBCDXTY.ToString();
            this.txtzqdzbcdx.Text = mo_ZQ.N_BCDXDZ.ToString();
            this.txtzqdcbcdx.Text = mo_ZQ.N_BCDXDC.ToString();
            this.txtzqtyabcdy.Text = mo_ZQ.N_ABCDYTY.ToString();
            this.txtzqtybbcdy.Text = mo_ZQ.N_BBCDYTY.ToString();
            this.txtzqtycbcdy.Text = mo_ZQ.N_CBCDYTY.ToString();
            this.txtzqdzbcdy.Text = mo_ZQ.N_BCDYDZ.ToString();
            this.txtzqdcbcdy.Text = mo_ZQ.N_BCDYDC.ToString();
            this.txtzqtyarqs.Text = mo_ZQ.N_ARQSTY.ToString();
            this.txtzqtybrqs.Text = mo_ZQ.N_BRQSTY.ToString();
            this.txtzqtycrqs.Text = mo_ZQ.N_CRQSTY.ToString();
            this.txtzqdzrqs.Text = mo_ZQ.N_RQSDZ.ToString();
            this.txtzqdcrqs.Text = mo_ZQ.N_RQSDC.ToString();
            this.txtzqtyabd.Text = mo_ZQ.N_ABDTY.ToString();
            this.txtzqtybbd.Text = mo_ZQ.N_BBDTY.ToString();
            this.txtzqtycbd.Text = mo_ZQ.N_CBDTY.ToString();
            this.txtzqdzbd.Text = mo_ZQ.N_BDDZ.ToString();
            this.txtzqdcbd.Text = mo_ZQ.N_BDDC.ToString();
            this.txtzqtyabqc.Text = mo_ZQ.N_ABQCTY.ToString();
            this.txtzqtybbqc.Text = mo_ZQ.N_BBQCTY.ToString();
            this.txtzqtycbqc.Text = mo_ZQ.N_CBQCTY.ToString();
            this.txtzqdzbqc.Text = mo_ZQ.N_BQCDZ.ToString();
            this.txtzqdcbqc.Text = mo_ZQ.N_BQCDC.ToString();
            this.txtzqtyagg.Text = mo_ZQ.N_AGGTY.ToString();
            this.txtzqtybgg.Text = mo_ZQ.N_BGGTY.ToString();
            this.txtzqtycgg.Text = mo_ZQ.N_CGGTY.ToString();
            this.txtzqdzgg.Text = mo_ZQ.N_GGDZ.ToString();
            this.txtzqdcgg.Text = mo_ZQ.N_GGDC.ToString();
            this.txtzqtyagj.Text = mo_ZQ.N_AGJTY.ToString();
            this.txtzqtybgj.Text = mo_ZQ.N_BGJTY.ToString();
            this.txtzqtycgj.Text = mo_ZQ.N_CGJTY.ToString();
            this.txtzqdzgj.Text = mo_ZQ.N_GJDZ.ToString();
            this.txtzqdcgj.Text = mo_ZQ.N_GJDC.ToString();
            #endregion
            //美足
            #region
            KFB_SETUPMQ mo_MQ = objAgentManageAddDB.GetModelMQ(strparid);
            this.txtmztyrf.Text = mo_MQ.N_RFTY.ToString();
            this.txtmzdzrf.Text = mo_MQ.N_RFDZ.ToString();
            this.txtmzdcrf.Text = mo_MQ.N_RFDC.ToString();
            this.txtmztydx.Text = mo_MQ.N_DXTY.ToString();
            this.txtmzdzdx.Text = mo_MQ.N_DXDZ.ToString();
            this.txtmzdcdx.Text = mo_MQ.N_DXDC.ToString();
            this.txtmztydy.Text = mo_MQ.N_DYTY.ToString();
            this.txtmzdzdy.Text = mo_MQ.N_DYDZ.ToString();
            this.txtmzdcdy.Text = mo_MQ.N_DYDC.ToString();
            this.txtmztyds.Text = mo_MQ.N_DSTY.ToString();
            this.txtmzdzds.Text = mo_MQ.N_DSDZ.ToString();
            this.txtmzdcds.Text = mo_MQ.N_DSDC.ToString();
            this.txtmztyzdrf.Text = mo_MQ.N_ZDRFTY.ToString();
            this.txtmzdzzdrf.Text = mo_MQ.N_ZDRFDZ.ToString();
            this.txtmzdczdrf.Text = mo_MQ.N_ZDRFDC.ToString();
            this.txtmztyzddx.Text = mo_MQ.N_ZDDXTY.ToString();
            this.txtmzdzzddx.Text = mo_MQ.N_ZDDXDZ.ToString();
            this.txtmzdczddx.Text = mo_MQ.N_ZDDXDC.ToString();
            this.txtmztybcrf.Text = mo_MQ.N_BCRFTY.ToString();
            this.txtmzdzbcrf.Text = mo_MQ.N_BCRFDZ.ToString();
            this.txtmzdcbcrf.Text = mo_MQ.N_BCRFDC.ToString();
            this.txtmztybcdx.Text = mo_MQ.N_BCDXTY.ToString();
            this.txtmzdzbcdx.Text = mo_MQ.N_BCDXDZ.ToString();
            this.txtmzdcbcdx.Text = mo_MQ.N_BCDXDC.ToString();
            this.txtmztybcdy.Text = mo_MQ.N_BCDYTY.ToString();
            this.txtmzdzbcdy.Text = mo_MQ.N_BCDYDZ.ToString();
            this.txtmzdcbcdy.Text = mo_MQ.N_BCDYDC.ToString();
            this.txtmztybcds.Text = mo_MQ.N_BCDSTY.ToString();
            this.txtmzdzbcds.Text = mo_MQ.N_BCDSDZ.ToString();
            this.txtmzdcbcds.Text = mo_MQ.N_BCDSDC.ToString();
            this.txtmztygg.Text = mo_MQ.N_GGTY.ToString();
            this.txtmzdzgg.Text = mo_MQ.N_GGDZ.ToString();
            this.txtmzdcgg.Text = mo_MQ.N_GGDC.ToString();
            this.txtmztygj.Text = mo_MQ.N_GJTY.ToString();
            this.txtmzdzgj.Text = mo_MQ.N_GJDZ.ToString();
            this.txtmzdcgj.Text = mo_MQ.N_GJDC.ToString();
            #endregion

            KFB_SETUPBQ mo_BQ = objAgentManageAddDB.GetModelBQ(strparid);

            //冰球 
            #region
            this.txtbqtyrf.Text = mo_BQ.N_RFTY.ToString();
            this.txtbqdzrf.Text = mo_BQ.N_RFDZ.ToString();
            this.txtbqdcrf.Text = mo_BQ.N_RFDC.ToString();
            this.txtbqtydx.Text = mo_BQ.N_DXTY.ToString();
            this.txtbqdzdx.Text = mo_BQ.N_DXDZ.ToString();
            this.txtbqdcdx.Text = mo_BQ.N_DXDC.ToString();
            this.txtbqtydy.Text = mo_BQ.N_DYTY.ToString();
            this.txtbqdzdy.Text = mo_BQ.N_DYDZ.ToString();
            this.txtbqdcdy.Text = mo_BQ.N_DYDC.ToString();
            this.txtbqtyds.Text = mo_BQ.N_DSTY.ToString();
            this.txtbqdzds.Text = mo_BQ.N_DSDZ.ToString();
            this.txtbqdcds.Text = mo_BQ.N_DSDC.ToString();
            this.txtbqtyzdrf.Text = mo_BQ.N_ZDRFTY.ToString();
            this.txtbqdzzdrf.Text = mo_BQ.N_ZDRFDZ.ToString();
            this.txtbqdczdrf.Text = mo_BQ.N_ZDRFDC.ToString();
            this.txtbqtyzddx.Text = mo_BQ.N_ZDDXTY.ToString();
            this.txtbqdzzddx.Text = mo_BQ.N_ZDDXDZ.ToString();
            this.txtbqdczddx.Text = mo_BQ.N_ZDDXDC.ToString();
            this.txtbqtysy.Text = mo_BQ.N_SYTY.ToString();
            this.txtbqdzsy.Text = mo_BQ.N_SYDZ.ToString();
            this.txtbqdcsy.Text = mo_BQ.N_SYDC.ToString();
            this.txtbqtygg.Text = mo_BQ.N_GGTY.ToString();
            this.txtbqdzgg.Text = mo_BQ.N_GGDZ.ToString();
            this.txtbqdcgg.Text = mo_BQ.N_GGDC.ToString();
            this.txtbqtybcrf.Text = mo_BQ.N_GJTY.ToString();
            this.txtbqdzbcrf.Text = mo_BQ.N_GJDZ.ToString();
            this.txtbqdcbcrf.Text = mo_BQ.N_GJDC.ToString();
            #endregion
            //彩球
            #region
            KFB_SETUPCQ mo_CQ = objAgentManageAddDB.GetModelCQ(strparid);
            this.txtcqtyrf.Text = mo_CQ.N_RFTY.ToString();
            this.txtcqdzrf.Text = mo_CQ.N_RFDZ.ToString();
            this.txtcqdcrf.Text = mo_CQ.N_RFDC.ToString();
            this.txtcqtydx.Text = mo_CQ.N_DXTY.ToString();
            this.txtcqdzdx.Text = mo_CQ.N_DXDZ.ToString();
            this.txtcqdcdx.Text = mo_CQ.N_DXDC.ToString();
            this.txtcqtydy.Text = mo_CQ.N_DYTY.ToString();
            this.txtcqdzdy.Text = mo_CQ.N_DYDZ.ToString();
            this.txtcqdcdy.Text = mo_CQ.N_DYDC.ToString();
            this.txtcqtyds.Text = mo_CQ.N_DSTY.ToString();
            this.txtcqdzds.Text = mo_CQ.N_DSDZ.ToString();
            this.txtcqdcds.Text = mo_CQ.N_DSDC.ToString();
            this.txtcqtyzdrf.Text = mo_CQ.N_ZDRFTY.ToString();
            this.txtcqdzzdrf.Text = mo_CQ.N_ZDRFDZ.ToString();
            this.txtcqdczdrf.Text = mo_CQ.N_ZDRFDC.ToString();
            this.txtcqtyzddx.Text = mo_CQ.N_ZDDXTY.ToString();
            this.txtcqdzzddx.Text = mo_CQ.N_ZDDXDZ.ToString();
            this.txtcqdczddx.Text = mo_CQ.N_ZDDXDC.ToString();
            this.txtcqtybcrf.Text = mo_CQ.N_BCRFTY.ToString();
            this.txtcqdzbcrf.Text = mo_CQ.N_BCRFDZ.ToString();
            this.txtcqdcbcrf.Text = mo_CQ.N_BCRFDC.ToString();
            this.txtcqtybcdx.Text = mo_CQ.N_BCDXTY.ToString();
            this.txtcqdzbcdx.Text = mo_CQ.N_BCDXDZ.ToString();
            this.txtcqdcbcdx.Text = mo_CQ.N_BCDXDC.ToString();
            this.txtcqtybcdy.Text = mo_CQ.N_BCDYTY.ToString();
            this.txtcqdzbcdy.Text = mo_CQ.N_BCDYDZ.ToString();
            this.txtcqdcbcdy.Text = mo_CQ.N_BCDYDC.ToString();
            this.txtcqtybcds.Text = mo_CQ.N_BCDSTY.ToString();
            this.txtcqdzbcds.Text = mo_CQ.N_BCDSDZ.ToString();
            this.txtcqdcbcds.Text = mo_CQ.N_BCDSDC.ToString();
            this.txtcqtygg.Text = mo_CQ.N_GGTY.ToString();
            this.txtcqdzgg.Text = mo_CQ.N_GGDZ.ToString();
            this.txtcqdcgg.Text = mo_CQ.N_GGDC.ToString();
            this.txtcqtygj.Text = mo_CQ.N_GJTY.ToString();
            this.txtcqdzgj.Text = mo_CQ.N_GJDZ.ToString();
            this.txtcqdcgj.Text = mo_CQ.N_GJDC.ToString();
            #endregion


            //指数
            #region
            KFB_SETUPZS mo_ZS = objAgentManageAddDB.GetModelZS(strparid);
            this.txtzstyrf.Text = mo_ZS.N_RFTY.ToString();
            this.txtzsdzrf.Text = mo_ZS.N_RFDZ.ToString();
            this.txtzsdcrf.Text = mo_ZS.N_RFDC.ToString();
            this.txtzstydx.Text = mo_ZS.N_DXTY.ToString();
            this.txtzsdzdx.Text = mo_ZS.N_DXDZ.ToString();
            this.txtzsdcdx.Text = mo_ZS.N_DXDC.ToString();
            this.txtzstydy.Text = mo_ZS.N_DYTY.ToString();
            this.txtzsdzdy.Text = mo_ZS.N_DYDZ.ToString();
            this.txtzsdcdy.Text = mo_ZS.N_DYDC.ToString();
            this.txtzstyds.Text = mo_ZS.N_DSTY.ToString();
            this.txtzsdzds.Text = mo_ZS.N_DSDZ.ToString();
            this.txtzsdcds.Text = mo_ZS.N_DSDC.ToString();
            this.txtzstyzdrf.Text = mo_ZS.N_ZDRFTY.ToString();
            this.txtzsdzzdrf.Text = mo_ZS.N_ZDRFDZ.ToString();
            this.txtzsdczdrf.Text = mo_ZS.N_ZDRFDC.ToString();
            this.txtzstyzddx.Text = mo_ZS.N_ZDDXTY.ToString();
            this.txtzsdzzddx.Text = mo_ZS.N_ZDDXDZ.ToString();
            this.txtzsdczddx.Text = mo_ZS.N_ZDDXDC.ToString();
            this.txtzstysy.Text = mo_ZS.N_SYTY.ToString();
            this.txtzsdzsy.Text = mo_ZS.N_SYDZ.ToString();
            this.txtzsdcsy.Text = mo_ZS.N_SYDC.ToString();
            this.txtzstybd.Text = mo_ZS.N_BDTY.ToString();
            this.txtzsdzbd.Text = mo_ZS.N_BDDZ.ToString();
            this.txtzsdcbd.Text = mo_ZS.N_BDDC.ToString();
            this.txtzstygg.Text = mo_ZS.N_GGTY.ToString();
            this.txtzsdzgg.Text = mo_ZS.N_GGDZ.ToString();
            this.txtzsdcgg.Text = mo_ZS.N_GGDC.ToString();
            this.txtzstygj.Text = mo_ZS.N_GJTY.ToString();
            this.txtzsdzgj.Text = mo_ZS.N_GJDZ.ToString();
            this.txtzsdcgj.Text = mo_ZS.N_GJDC.ToString();
            #endregion
            //赛马
            #region
            KFB_SETUPSM mo_SM = objAgentManageAddDB.GetModelSM(strparid);
            this.txtsmtydy.Text = mo_SM.N_DYTY.ToString();
            this.txtsmdzdy.Text = mo_SM.N_DYDZ.ToString();
            this.txtsmdcdy.Text = mo_SM.N_DYDC.ToString();
            this.txtsmtywz.Text = mo_SM.N_WZTY.ToString();
            this.txtsmdzwz.Text = mo_SM.N_WZDZ.ToString();
            this.txtsmdcwz.Text = mo_SM.N_WZDC.ToString();
            this.txtsmtyly.Text = mo_SM.N_LYTY.ToString();
            this.txtsmdzly.Text = mo_SM.N_LYDZ.ToString();
            this.txtsmdcly.Text = mo_SM.N_LYDC.ToString();
            this.txtsmtywzq.Text = mo_SM.N_WZQTY.ToString();
            this.txtsmdzwzq.Text = mo_SM.N_WZQDZ.ToString();
            this.txtsmdcwzq.Text = mo_SM.N_WZQDC.ToString();
            #endregion
            //六合彩
            #region
            KFB_SETUPLHC mo_LHC = objAgentManageAddDB.GetModelLHC(strparid);
            this.txtlhctytbh.Text = mo_LHC.N_TBHTY.ToString();
            this.txtlhcdztbh.Text = mo_LHC.N_TBHDZ.ToString();
            this.txtlhcdctbh.Text = mo_LHC.N_TBHDC.ToString();
            this.txtlhctytt.Text = mo_LHC.N_TTTY.ToString();
            this.txtlhcdztt.Text = mo_LHC.N_TTDZ.ToString();
            this.txtlhcdctt.Text = mo_LHC.N_TTDC.ToString();
            this.txtlhctyth.Text = mo_LHC.N_THTY.ToString();
            this.txtlhcdzth.Text = mo_LHC.N_THDZ.ToString();
            this.txtlhcdcth.Text = mo_LHC.N_THDC.ToString();
            this.txtlhctyqcp.Text = mo_LHC.N_QCPTY.ToString();
            this.txtlhcdzqcp.Text = mo_LHC.N_QCPDZ.ToString();
            this.txtlhcdcqcp.Text = mo_LHC.N_QCPDC.ToString();
            this.txtlhcty2x.Text = mo_LHC.N_2XTY.ToString();
            this.txtlhcdz2x.Text = mo_LHC.N_2XDZ.ToString();
            this.txtlhcdc2x.Text = mo_LHC.N_2XDC.ToString();
            this.txtlhcty3x.Text = mo_LHC.N_3XTY.ToString();
            this.txtlhcdz3x.Text = mo_LHC.N_3XDZ.ToString();
            this.txtlhcdc3x.Text = mo_LHC.N_3XDC.ToString();
            this.txtlhcty4x.Text = mo_LHC.N_4XTY.ToString();
            this.txtlhcdz4x.Text = mo_LHC.N_4XDZ.ToString();
            this.txtlhcdc4x.Text = mo_LHC.N_4XDC.ToString();
            this.txtlhctygdds.Text = mo_LHC.N_GDDSTY.ToString();
            this.txtlhcdzgdds.Text = mo_LHC.N_GDDSDZ.ToString();
            this.txtlhcdcgdds.Text = mo_LHC.N_GDDSDC.ToString();
            this.txtlhctygddx.Text = mo_LHC.N_GDDXTY.ToString();
            this.txtlhcdzgddx.Text = mo_LHC.N_GDDXDZ.ToString();
            this.txtlhcdcgddx.Text = mo_LHC.N_GDDXDC.ToString();
            #endregion
            //大乐透
            #region
            KFB_SETUPDLT mo_DLT = objAgentManageAddDB.GetModelDLT(strparid);
            this.txtdlttytbh.Text = mo_DLT.N_TBHTY.ToString();
            this.txtdltdztbh.Text = mo_DLT.N_TBHDZ.ToString();
            this.txtdltdctbh.Text = mo_DLT.N_TBHDC.ToString();
            this.txtdlttytt.Text = mo_DLT.N_TTTY.ToString();
            this.txtdltdztt.Text = mo_DLT.N_TTDZ.ToString();
            this.txtdltdctt.Text = mo_DLT.N_TTDC.ToString();
            this.txtdlttyth.Text = mo_DLT.N_THTY.ToString();
            this.txtdltdzth.Text = mo_DLT.N_THDZ.ToString();
            this.txtdltdcth.Text = mo_DLT.N_THDC.ToString();
            this.txtdlttyqcp.Text = mo_DLT.N_QCPTY.ToString();
            this.txtdltdzqcp.Text = mo_DLT.N_QCPDZ.ToString();
            this.txtdltdcqcp.Text = mo_DLT.N_QCPDC.ToString();
            this.txtdltty2x.Text = mo_DLT.N_2XTY.ToString();
            this.txtdltdz2x.Text = mo_DLT.N_2XDZ.ToString();
            this.txtdltdc2x.Text = mo_DLT.N_2XDC.ToString();
            this.txtdltty3x.Text = mo_DLT.N_3XTY.ToString();
            this.txtdltdz3x.Text = mo_DLT.N_3XDZ.ToString();
            this.txtdltdc3x.Text = mo_DLT.N_3XDC.ToString();
            this.txtdltty4x.Text = mo_DLT.N_4XTY.ToString();
            this.txtdltdz4x.Text = mo_DLT.N_4XDZ.ToString();
            this.txtdltdc4x.Text = mo_DLT.N_4XDC.ToString();
            this.txtdlttygdds.Text = mo_DLT.N_GDDSTY.ToString();
            this.txtdltdzgdds.Text = mo_DLT.N_GDDSDZ.ToString();
            this.txtdltdcgdds.Text = mo_DLT.N_GDDSDC.ToString();
            this.txtdlttygddx.Text = mo_DLT.N_GDDXTY.ToString();
            this.txtdltdzgddx.Text = mo_DLT.N_GDDXDZ.ToString();
            this.txtdltdcgddx.Text = mo_DLT.N_GDDXDC.ToString();
            #endregion
            //JC539
            #region
            KFB_SETUPJC539 mo_JC539 = objAgentManageAddDB.GetModelJC539(strparid);
            this.txtjc539tyqcp.Text = mo_JC539.N_QCPTY.ToString();
            this.txtjc539dzqcp.Text = mo_JC539.N_QCPDZ.ToString();
            this.txtjc539dcqcp.Text = mo_JC539.N_QCPDC.ToString();
            this.txtjc539ty2x.Text = mo_JC539.N_2XTY.ToString();
            this.txtjc539dz2x.Text = mo_JC539.N_2XDZ.ToString();
            this.txtjc539dc2x.Text = mo_JC539.N_2XDC.ToString();
            this.txtjc539ty3x.Text = mo_JC539.N_3XTY.ToString();
            this.txtjc539dz3x.Text = mo_JC539.N_3XDZ.ToString();
            this.txtjc539dc3x.Text = mo_JC539.N_3XDC.ToString();
            this.txtjc539ty4x.Text = mo_JC539.N_4XTY.ToString();
            this.txtjc539dz4x.Text = mo_JC539.N_4XDZ.ToString();
            this.txtjc539dc4x.Text = mo_JC539.N_4XDC.ToString();
            #endregion
            //运动彩票
            #region
            KFB_SETUPCP mo_CP = objAgentManageAddDB.GetModelCP(strparid);
            this.txtcptybq.Text = mo_CP.N_BQTY.ToString();
            this.txtcpdzbq.Text = mo_CP.N_BQDZ.ToString();
            this.txtcpdcbq.Text = mo_CP.N_BQDC.ToString();
            this.txtcptylq.Text = mo_CP.N_LQTY.ToString();
            this.txtcpdzlq.Text = mo_CP.N_LQDZ.ToString();
            this.txtcpdclq.Text = mo_CP.N_LQDC.ToString();
            this.txtcptyzq.Text = mo_CP.N_ZQTY.ToString();
            this.txtcpdzzq.Text = mo_CP.N_ZQDZ.ToString();
            this.txtcpdczq.Text = mo_CP.N_ZQDC.ToString();
            this.txtcptygs.Text = mo_CP.N_GSTY.ToString();
            this.txtcpdzgs.Text = mo_CP.N_GSDZ.ToString();
            this.txtcpdcgs.Text = mo_CP.N_GSDC.ToString();
            this.txtcptyqz.Text = mo_CP.N_QZTY.ToString();
            this.txtcpdzqz.Text = mo_CP.N_QZDZ.ToString();
            this.txtcpdcqz.Text = mo_CP.N_QZDC.ToString();
            #endregion
            //時事
            #region
            KFB_SETUPSS mo_SS = objAgentManageAddDB.GetModelSS(strparid);
            this.txtsstydy.Text = mo_SS.N_DYTY.ToString();
            this.txtssdzdy.Text = mo_SS.N_DYDZ.ToString();
            this.txtssdcdy.Text = mo_SS.N_DYDC.ToString();
            #endregion
        }

        #endregion
        #region"添加帐号"
        protected void bttjzj_Click(object sender, EventArgs e)
        {
            try
            {
                AgentManageDB objAgentManageDB = new AgentManageDB();
                KFB_ZHGL mo_zhgl = new KFB_ZHGL();
                //KingOfBall.BLL.XXZH_BILL o_XXZH_BILL = new XXZH_BILL();
                KFB_SETUPCP mo_cp = new KFB_SETUPCP();
                KFB_SETUPDLT mo_dlt = new KFB_SETUPDLT();
                KFB_SETUPSM mo_sm = new KFB_SETUPSM();
                KFB_SETUPLHC mo_lhc = new KFB_SETUPLHC();
                KFB_SETUPLQ mo_lq = new KFB_SETUPLQ();
                KFB_SETUPMB mo_mb = new KFB_SETUPMB();
                KFB_SETUPRB mo_rb = new KFB_SETUPRB();
                KFB_SETUPTB mo_tb = new KFB_SETUPTB();
                KFB_SETUPMQ mo_mz = new KFB_SETUPMQ();
                KFB_SETUPZQ mo_zq = new KFB_SETUPZQ();
                KFB_SETUPZS mo_zs = new KFB_SETUPZS();
                KFB_SETUPJC539 mo_jc539 = new KFB_SETUPJC539();
                KFB_SETUPSS mo_ss = new KFB_SETUPSS();
                Hashtable GetSql = new Hashtable();
               // KFB_ZHGL_BILL o_ZHGL = new KFB_ZHGL_BILL();

                KFB_SETUPBQ mo_bq = new KFB_SETUPBQ();
                KFB_SETUPCQ mo_cq = new KFB_SETUPCQ();
                //判斷是否存在
                bool chuser = objAgentManageDB.Exists(this.lbzj.Text);

                if (!chuser)
                {
                    this.ShowMsg("該會員已被刪除！");
                }
                else//存在則修改
                {

                    //剩餘額度判斷
                    string strzh = Comm.GetUPID(strparid, strlvl);
                    string strsjsy = "0";
                    if (!strzh.Equals(""))
                    {
                        strsjsy = objAgentManageDB.Getsyed(strzh);
                    }
                    mo_zhgl = objAgentManageDB.GetModel(strparid);
                    if (!strlvl.Equals("4") && (Convert.ToDecimal(mo_zhgl.N_KYED) + Convert.ToDecimal(strsjsy)) < Convert.ToDecimal(this.txtxyed.Text))
                    {
                        this.ShowMsg("上級剩餘額度不足！");
                    }
                    else
                    {
                        //判斷自身額度是否足夠
                        //mo_zhgl = o_ZHGL.GetModel(this.lbzj.Text);

                        decimal dkyed = Convert.ToDecimal(mo_zhgl.N_KYED) - Convert.ToDecimal(mo_zhgl.N_SYED);

                        if (dkyed <= Convert.ToDecimal(this.txtxyed.Text))//額度足夠的時候才能修改
                        {
                            mo_zhgl = new KFB_ZHGL();
                            mo_zhgl = SetModel();
                            objAgentManageDB.Update(mo_zhgl, GetSql);
                            //根據代理商過關關數限制修改會員關數上限
                            if (strlvl.Equals("9") && !mo_zhgl.N_TOLLGATE.ToString().Equals("0"))
                                objAgentManageDB.UpdateTOLLGATE(mo_zhgl.N_HYZH, mo_zhgl.N_TOLLGATE.ToString(), GetSql);
                            //禁止旗下會員登陸
                            if (mo_zhgl.N_YXDL.ToString().Equals("0"))//禁止登陸
                            {
                                objAgentManageDB.NoLogZH(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                                objAgentManageDB.NoLogHY(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                            }
                            //禁止旗下會員下注
                            if (mo_zhgl.N_YXXZ.ToString().Equals("0"))//禁止下注
                            {
                                objAgentManageDB.NoXZZH(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                                objAgentManageDB.NoXZHY(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                            }
                            //修改下級單隊上限
                            objAgentManageDB.UpdateXJDDSX(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, float.Parse(mo_zhgl.N_DDSX.ToString()), GetSql);
                            #region"修改上级剩余额度"
                            objAgentManageDB.Upsj(mo_zhgl);

                            #endregion

                            #region"篮球"
                            //篮球
                            mo_lq.N_HYZH = this.lbzj.Text;
                            mo_lq.N_RFTY = Convert.ToDecimal(this.txtlqtyrf.Text);
                            mo_lq.N_RFDZ = Convert.ToDecimal(this.txtlqdzrf.Text);
                            mo_lq.N_RFDC = Convert.ToDecimal(this.txtlqdcrf.Text);
                            mo_lq.N_RFDD = Convert.ToDecimal(this.txtlqddrf.Text);

                            mo_lq.N_DXTY = Convert.ToDecimal(this.txtlqtydx.Text);
                            mo_lq.N_DXDZ = Convert.ToDecimal(this.txtlqdzdx.Text);
                            mo_lq.N_DXDC = Convert.ToDecimal(this.txtlqdcdx.Text);
                            mo_lq.N_DXDD = Convert.ToDecimal(this.txtlqdddx.Text);

                            mo_lq.N_DYTY = Convert.ToDecimal(this.txtlqtydy.Text);
                            mo_lq.N_DYDZ = Convert.ToDecimal(this.txtlqdzdy.Text);
                            mo_lq.N_DYDC = Convert.ToDecimal(this.txtlqdcdy.Text);
                            mo_lq.N_DYDD = Convert.ToDecimal(this.txtlqdddy.Text);

                            mo_lq.N_DSTY = Convert.ToDecimal(this.txtlqtyds.Text);
                            mo_lq.N_DSDZ = Convert.ToDecimal(this.txtlqdzds.Text);
                            mo_lq.N_DSDC = Convert.ToDecimal(this.txtlqdcds.Text);
                            mo_lq.N_DSDD = Convert.ToDecimal(this.txtlqddds.Text);

                            mo_lq.N_ZDRFTY = Convert.ToDecimal(this.txtlqtyzdrf.Text);
                            mo_lq.N_ZDRFDZ = Convert.ToDecimal(this.txtlqdzzdrf.Text);
                            mo_lq.N_ZDRFDC = Convert.ToDecimal(this.txtlqdczdrf.Text);
                            mo_lq.N_ZDRFDD = Convert.ToDecimal(this.txtlqddzdrf.Text);

                            mo_lq.N_ZDDXTY = Convert.ToDecimal(this.txtlqtyzddx.Text);
                            mo_lq.N_ZDDXDZ = Convert.ToDecimal(this.txtlqdzzddx.Text);
                            mo_lq.N_ZDDXDC = Convert.ToDecimal(this.txtlqdczddx.Text);
                            mo_lq.N_ZDDXDD = Convert.ToDecimal(this.txtlqddzddx.Text);

                            mo_lq.N_BCRFTY = Convert.ToDecimal(this.txtlqtybcrf.Text);
                            mo_lq.N_BCRFDZ = Convert.ToDecimal(this.txtlqdzbcrf.Text);
                            mo_lq.N_BCRFDC = Convert.ToDecimal(this.txtlqdcbcrf.Text);
                            mo_lq.N_BCRFDD = Convert.ToDecimal(this.txtlqddbcrf.Text);

                            mo_lq.N_BCDXTY = Convert.ToDecimal(this.txtlqtybcdx.Text);
                            mo_lq.N_BCDXDZ = Convert.ToDecimal(this.txtlqdzbcdx.Text);
                            mo_lq.N_BCDXDC = Convert.ToDecimal(this.txtlqdcbcdx.Text);
                            mo_lq.N_BCDXDD = Convert.ToDecimal(this.txtlqddbcdx.Text);

                            mo_lq.N_BCDYTY = Convert.ToDecimal(this.txtlqtybcdy.Text);
                            mo_lq.N_BCDYDZ = Convert.ToDecimal(this.txtlqdzbcdy.Text);
                            mo_lq.N_BCDYDC = Convert.ToDecimal(this.txtlqdcbcdy.Text);
                            mo_lq.N_BCDYDD = Convert.ToDecimal(this.txtlqddbcdy.Text);

                            mo_lq.N_BCDSTY = Convert.ToDecimal(this.txtlqtybcds.Text);
                            mo_lq.N_BCDSDZ = Convert.ToDecimal(this.txtlqdzbcds.Text);
                            mo_lq.N_BCDSDC = Convert.ToDecimal(this.txtlqdcbcds.Text);
                            mo_lq.N_BCDSDD = Convert.ToDecimal(this.txtlqddbcds.Text);

                            mo_lq.N_GGTY = Convert.ToDecimal(this.txtlqtygg.Text);
                            mo_lq.N_GGDZ = Convert.ToDecimal(this.txtlqdzgg.Text);
                            mo_lq.N_GGDC = Convert.ToDecimal(this.txtlqdcgg.Text);
                            mo_lq.N_GGDD = Convert.ToDecimal(this.txtlqddgg.Text);

                            mo_lq.N_GJTY = Convert.ToDecimal(this.txtlqtygj.Text);
                            mo_lq.N_GJDZ = Convert.ToDecimal(this.txtlqdzgj.Text);
                            mo_lq.N_GJDC = Convert.ToDecimal(this.txtlqdcgj.Text);
                            mo_lq.N_GJDD = Convert.ToDecimal(this.txtlqddgj.Text);

                            mo_lq.N_DJRFTY = Convert.ToDecimal(this.txtlqtydjrf.Text);
                            mo_lq.N_DJRFDZ = Convert.ToDecimal(this.txtlqdzdjrf.Text);
                            mo_lq.N_DJRFDC = Convert.ToDecimal(this.txtlqdcdjrf.Text);
                            mo_lq.N_DJRFDD = Convert.ToDecimal(this.txtlqdddjrf.Text);

                            mo_lq.N_DJDXTY = Convert.ToDecimal(this.txtlqtydjdx.Text);
                            mo_lq.N_DJDXDZ = Convert.ToDecimal(this.txtlqdzdjdx.Text);
                            mo_lq.N_DJDXDC = Convert.ToDecimal(this.txtlqdcdjdx.Text);
                            mo_lq.N_DJDXDD = Convert.ToDecimal(this.txtlqdddjdx.Text);

                            mo_lq.N_DJDSTY = Convert.ToDecimal(this.txtlqtydjds.Text);
                            mo_lq.N_DJDSDZ = Convert.ToDecimal(this.txtlqdzdjds.Text);
                            mo_lq.N_DJDSDC = Convert.ToDecimal(this.txtlqdcdjds.Text);
                            mo_lq.N_DJDSDD = Convert.ToDecimal(this.txtlqdddjds.Text);

                            objAgentManageDB.UpdateLQ(mo_lq, GetSql);
                            #endregion
                            #region"棒球"
                            //棒球　
                            mo_mb.N_HYZH = this.lbzj.Text;
                            mo_mb.N_RFTY = Convert.ToDecimal(this.txtmbtyrf.Text);
                            mo_mb.N_RFDZ = Convert.ToDecimal(this.txtmbdzrf.Text);
                            mo_mb.N_RFDC = Convert.ToDecimal(this.txtmbdcrf.Text);
                            mo_mb.N_DXTY = Convert.ToDecimal(this.txtmbtydx.Text);
                            mo_mb.N_DXDZ = Convert.ToDecimal(this.txtmbdzdx.Text);
                            mo_mb.N_DXDC = Convert.ToDecimal(this.txtmbdcdx.Text);
                            mo_mb.N_DYTY = Convert.ToDecimal(this.txtmbtydy.Text);
                            mo_mb.N_DYDZ = Convert.ToDecimal(this.txtmbdzdy.Text);
                            mo_mb.N_DYDC = Convert.ToDecimal(this.txtmbdcdy.Text);
                            mo_mb.N_DSTY = Convert.ToDecimal(this.txtmbtyds.Text);
                            mo_mb.N_DSDZ = Convert.ToDecimal(this.txtmbdzds.Text);
                            mo_mb.N_DSDC = Convert.ToDecimal(this.txtmbdcds.Text);
                            mo_mb.N_ZDRFTY = Convert.ToDecimal(this.txtmbtyzdrf.Text);
                            mo_mb.N_ZDRFDZ = Convert.ToDecimal(this.txtmbdzzdrf.Text);
                            mo_mb.N_ZDRFDC = Convert.ToDecimal(this.txtmbdczdrf.Text);
                            mo_mb.N_ZDDXTY = Convert.ToDecimal(this.txtmbtyzddx.Text);
                            mo_mb.N_ZDDXDZ = Convert.ToDecimal(this.txtmbdzzddx.Text);
                            mo_mb.N_ZDDXDC = Convert.ToDecimal(this.txtmbdczddx.Text);
                            mo_mb.N_SYTY = Convert.ToDecimal(this.txtmbtysy.Text);
                            mo_mb.N_SYDZ = Convert.ToDecimal(this.txtmbdzsy.Text);
                            mo_mb.N_SYDC = Convert.ToDecimal(this.txtmbdcsy.Text);
                            mo_mb.N_GGTY = Convert.ToDecimal(this.txtmbtygg.Text);
                            mo_mb.N_GGDZ = Convert.ToDecimal(this.txtmbdzgg.Text);
                            mo_mb.N_GGDC = Convert.ToDecimal(this.txtmbdcgg.Text);
                            mo_mb.N_GJTY = Convert.ToDecimal(this.txtmbtybcrf.Text);
                            mo_mb.N_GJDZ = Convert.ToDecimal(this.txtmbdzbcrf.Text);
                            mo_mb.N_GJDC = Convert.ToDecimal(this.txtmbdcbcrf.Text);
                            objAgentManageDB.UpdateMB(mo_mb, GetSql);
                            #endregion
                            #region"网球"
                            //网球　
                            mo_rb.N_HYZH = this.lbzj.Text;
                            mo_rb.N_RFTY = Convert.ToDecimal(this.txtrbtyrf.Text);
                            mo_rb.N_RFDZ = Convert.ToDecimal(this.txtrbdzrf.Text);
                            mo_rb.N_RFDC = Convert.ToDecimal(this.txtrbdcrf.Text);
                            mo_rb.N_DXTY = Convert.ToDecimal(this.txtrbtydx.Text);
                            mo_rb.N_DXDZ = Convert.ToDecimal(this.txtrbdzdx.Text);
                            mo_rb.N_DXDC = Convert.ToDecimal(this.txtrbdcdx.Text);
                            mo_rb.N_DYTY = Convert.ToDecimal(this.txtrbtydy.Text);
                            mo_rb.N_DYDZ = Convert.ToDecimal(this.txtrbdzdy.Text);
                            mo_rb.N_DYDC = Convert.ToDecimal(this.txtrbdcdy.Text);
                            mo_rb.N_DSTY = Convert.ToDecimal(this.txtrbtyds.Text);
                            mo_rb.N_DSDZ = Convert.ToDecimal(this.txtrbdzds.Text);
                            mo_rb.N_DSDC = Convert.ToDecimal(this.txtrbdcds.Text);
                            mo_rb.N_ZDRFTY = Convert.ToDecimal(this.txtrbtyzdrf.Text);
                            mo_rb.N_ZDRFDZ = Convert.ToDecimal(this.txtrbdzzdrf.Text);
                            mo_rb.N_ZDRFDC = Convert.ToDecimal(this.txtrbdczdrf.Text);
                            mo_rb.N_ZDDXTY = Convert.ToDecimal(this.txtrbtyzddx.Text);
                            mo_rb.N_ZDDXDZ = Convert.ToDecimal(this.txtrbdzzddx.Text);
                            mo_rb.N_ZDDXDC = Convert.ToDecimal(this.txtrbdczddx.Text);
                            mo_rb.N_SYTY = Convert.ToDecimal(this.txtrbtysy.Text);
                            mo_rb.N_SYDZ = Convert.ToDecimal(this.txtrbdzsy.Text);
                            mo_rb.N_SYDC = Convert.ToDecimal(this.txtrbdcsy.Text);
                            mo_rb.N_GGTY = Convert.ToDecimal(this.txtrbtygg.Text);
                            mo_rb.N_GGDZ = Convert.ToDecimal(this.txtrbdzgg.Text);
                            mo_rb.N_GGDC = Convert.ToDecimal(this.txtrbdcgg.Text);
                            mo_rb.N_GJTY = Convert.ToDecimal(this.txtrbtybcrf.Text);
                            mo_rb.N_GJDZ = Convert.ToDecimal(this.txtrbdzbcrf.Text);
                            mo_rb.N_GJDC = Convert.ToDecimal(this.txtrbdcbcrf.Text);
                            objAgentManageDB.UpdateRB(mo_rb, GetSql);
                            #endregion
                            #region"排球"
                            //排球　
                            mo_tb.N_HYZH = this.lbzj.Text;
                            mo_tb.N_RFTY = Convert.ToDecimal(this.txttbtyrf.Text);
                            mo_tb.N_RFDZ = Convert.ToDecimal(this.txttbdzrf.Text);
                            mo_tb.N_RFDC = Convert.ToDecimal(this.txttbdcrf.Text);
                            mo_tb.N_DXTY = Convert.ToDecimal(this.txttbtydx.Text);
                            mo_tb.N_DXDZ = Convert.ToDecimal(this.txttbdzdx.Text);
                            mo_tb.N_DXDC = Convert.ToDecimal(this.txttbdcdx.Text);
                            mo_tb.N_DYTY = Convert.ToDecimal(this.txttbtydy.Text);
                            mo_tb.N_DYDZ = Convert.ToDecimal(this.txttbdzdy.Text);
                            mo_tb.N_DYDC = Convert.ToDecimal(this.txttbdcdy.Text);
                            mo_tb.N_DSTY = Convert.ToDecimal(this.txttbtyds.Text);
                            mo_tb.N_DSDZ = Convert.ToDecimal(this.txttbdzds.Text);
                            mo_tb.N_DSDC = Convert.ToDecimal(this.txttbdcds.Text);
                            mo_tb.N_ZDRFTY = Convert.ToDecimal(this.txttbtyzdrf.Text);
                            mo_tb.N_ZDRFDZ = Convert.ToDecimal(this.txttbdzzdrf.Text);
                            mo_tb.N_ZDRFDC = Convert.ToDecimal(this.txttbdczdrf.Text);
                            mo_tb.N_ZDDXTY = Convert.ToDecimal(this.txttbtyzddx.Text);
                            mo_tb.N_ZDDXDZ = Convert.ToDecimal(this.txttbdzzddx.Text);
                            mo_tb.N_ZDDXDC = Convert.ToDecimal(this.txttbdczddx.Text);
                            mo_tb.N_SYTY = Convert.ToDecimal(this.txttbtysy.Text);
                            mo_tb.N_SYDZ = Convert.ToDecimal(this.txttbdzsy.Text);
                            mo_tb.N_SYDC = Convert.ToDecimal(this.txttbdcsy.Text);
                            mo_tb.N_GGTY = Convert.ToDecimal(this.txttbtygg.Text);
                            mo_tb.N_GGDZ = Convert.ToDecimal(this.txttbdzgg.Text);
                            mo_tb.N_GGDC = Convert.ToDecimal(this.txttbdcgg.Text);
                            mo_tb.N_GJTY = Convert.ToDecimal(this.txttbtybcrf.Text);
                            mo_tb.N_GJDZ = Convert.ToDecimal(this.txttbdzbcrf.Text);
                            mo_tb.N_GJDC = Convert.ToDecimal(this.txttbdcbcrf.Text);
                            objAgentManageDB.UpdateTB(mo_tb, GetSql);
                            #endregion
                            #region"足球"
                            //足球
                            mo_zq.N_HYZH = this.lbzj.Text;
                            mo_zq.N_ARFTY = Convert.ToDecimal(this.txtzqtyarf.Text);
                            mo_zq.N_ADXTY = Convert.ToDecimal(this.txtzqtyadx.Text);
                            mo_zq.N_ADYTY = Convert.ToDecimal(this.txtzqtyady.Text);
                            mo_zq.N_ADSTY = Convert.ToDecimal(this.txtzqtyads.Text);
                            mo_zq.N_AZDRFTY = Convert.ToDecimal(this.txtzqtyazdrf.Text);
                            mo_zq.N_AZDDXTY = Convert.ToDecimal(this.txtzqtyazddx.Text);
                            mo_zq.N_ABCRFTY = Convert.ToDecimal(this.txtzqtyabcrf.Text);
                            mo_zq.N_ABCDXTY = Convert.ToDecimal(this.txtzqtyabcdx.Text);
                            mo_zq.N_ABCDYTY = Convert.ToDecimal(this.txtzqtyabcdy.Text);
                            mo_zq.N_ARQSTY = Convert.ToDecimal(this.txtzqtyarqs.Text);
                            mo_zq.N_ABDTY = Convert.ToDecimal(this.txtzqtyabd.Text);
                            mo_zq.N_ABQCTY = Convert.ToDecimal(this.txtzqtyabqc.Text);
                            mo_zq.N_AGGTY = Convert.ToDecimal(this.txtzqtyagg.Text);
                            mo_zq.N_AGJTY = Convert.ToDecimal(this.txtzqtyagj.Text);

                            mo_zq.N_BRFTY = Convert.ToDecimal(this.txtzqtybrf.Text);
                            mo_zq.N_BDXTY = Convert.ToDecimal(this.txtzqtybdx.Text);
                            mo_zq.N_BDYTY = Convert.ToDecimal(this.txtzqtybdy.Text);
                            mo_zq.N_BDSTY = Convert.ToDecimal(this.txtzqtybds.Text);
                            mo_zq.N_BZDRFTY = Convert.ToDecimal(this.txtzqtybzdrf.Text);
                            mo_zq.N_BZDDXTY = Convert.ToDecimal(this.txtzqtybzddx.Text);
                            mo_zq.N_BBCRFTY = Convert.ToDecimal(this.txtzqtybbcrf.Text);
                            mo_zq.N_BBCDXTY = Convert.ToDecimal(this.txtzqtybbcdx.Text);
                            mo_zq.N_BBCDYTY = Convert.ToDecimal(this.txtzqtybbcdy.Text);
                            mo_zq.N_BRQSTY = Convert.ToDecimal(this.txtzqtybrqs.Text);
                            mo_zq.N_BBDTY = Convert.ToDecimal(this.txtzqtybbd.Text);
                            mo_zq.N_BBQCTY = Convert.ToDecimal(this.txtzqtybbqc.Text);
                            mo_zq.N_BGGTY = Convert.ToDecimal(this.txtzqtybgg.Text);
                            mo_zq.N_BGJTY = Convert.ToDecimal(this.txtzqtybgj.Text);

                            mo_zq.N_CRFTY = Convert.ToDecimal(this.txtzqtycrf.Text);
                            mo_zq.N_CDXTY = Convert.ToDecimal(this.txtzqtycdx.Text);
                            mo_zq.N_CDYTY = Convert.ToDecimal(this.txtzqtycdy.Text);
                            mo_zq.N_CDSTY = Convert.ToDecimal(this.txtzqtycds.Text);
                            mo_zq.N_CZDRFTY = Convert.ToDecimal(this.txtzqtyczdrf.Text);
                            mo_zq.N_CZDDXTY = Convert.ToDecimal(this.txtzqtyczddx.Text);
                            mo_zq.N_CBCRFTY = Convert.ToDecimal(this.txtzqtycbcrf.Text);
                            mo_zq.N_CBCDXTY = Convert.ToDecimal(this.txtzqtycbcdx.Text);
                            mo_zq.N_CBCDYTY = Convert.ToDecimal(this.txtzqtycbcdy.Text);
                            mo_zq.N_CRQSTY = Convert.ToDecimal(this.txtzqtycrqs.Text);
                            mo_zq.N_CBDTY = Convert.ToDecimal(this.txtzqtycbd.Text);
                            mo_zq.N_CBQCTY = Convert.ToDecimal(this.txtzqtycbqc.Text);
                            mo_zq.N_CGGTY = Convert.ToDecimal(this.txtzqtycgg.Text);
                            mo_zq.N_CGJTY = Convert.ToDecimal(this.txtzqtycgj.Text);

                            mo_zq.N_RFDZ = Convert.ToDecimal(this.txtzqdzrf.Text);
                            mo_zq.N_RFDC = Convert.ToDecimal(this.txtzqdcrf.Text);
                            mo_zq.N_DXDZ = Convert.ToDecimal(this.txtzqdzdx.Text);
                            mo_zq.N_DXDC = Convert.ToDecimal(this.txtzqdcdx.Text);
                            mo_zq.N_DYDZ = Convert.ToDecimal(this.txtzqdzdy.Text);
                            mo_zq.N_DYDC = Convert.ToDecimal(this.txtzqdcdy.Text);
                            mo_zq.N_DSDZ = Convert.ToDecimal(this.txtzqdzds.Text);
                            mo_zq.N_DSDC = Convert.ToDecimal(this.txtzqdcds.Text);
                            mo_zq.N_ZDRFDZ = Convert.ToDecimal(this.txtzqdzzdrf.Text);
                            mo_zq.N_ZDRFDC = Convert.ToDecimal(this.txtzqdczdrf.Text);
                            mo_zq.N_ZDDXDZ = Convert.ToDecimal(this.txtzqdzzddx.Text);
                            mo_zq.N_ZDDXDC = Convert.ToDecimal(this.txtzqdczddx.Text);
                            mo_zq.N_BCRFDZ = Convert.ToDecimal(this.txtzqdzbcrf.Text);
                            mo_zq.N_BCRFDC = Convert.ToDecimal(this.txtzqdcbcrf.Text);
                            mo_zq.N_BCDXDZ = Convert.ToDecimal(this.txtzqdzbcdx.Text);
                            mo_zq.N_BCDXDC = Convert.ToDecimal(this.txtzqdcbcdx.Text);
                            mo_zq.N_BCDYDZ = Convert.ToDecimal(this.txtzqdzbcdy.Text);
                            mo_zq.N_BCDYDC = Convert.ToDecimal(this.txtzqdcbcdy.Text);
                            mo_zq.N_RQSDZ = Convert.ToDecimal(this.txtzqdzrqs.Text);
                            mo_zq.N_RQSDC = Convert.ToDecimal(this.txtzqdcrqs.Text);
                            mo_zq.N_BDDZ = Convert.ToDecimal(this.txtzqdzbd.Text);
                            mo_zq.N_BDDC = Convert.ToDecimal(this.txtzqdcbd.Text);
                            mo_zq.N_BQCDZ = Convert.ToDecimal(this.txtzqdzbqc.Text);
                            mo_zq.N_BQCDC = Convert.ToDecimal(this.txtzqdcbqc.Text);
                            mo_zq.N_GGDZ = Convert.ToDecimal(this.txtzqdzgg.Text);
                            mo_zq.N_GGDC = Convert.ToDecimal(this.txtzqdcgg.Text);
                            mo_zq.N_GJDZ = Convert.ToDecimal(this.txtzqdzgj.Text);
                            mo_zq.N_GJDC = Convert.ToDecimal(this.txtzqdcgj.Text);
                            objAgentManageDB.UpdateZQ(mo_zq, GetSql);
                            #endregion
                            #region"美足"
                            //美足　
                            mo_mz.N_HYZH = this.lbzj.Text;
                            mo_mz.N_RFTY = Convert.ToDecimal(this.txtmztyrf.Text);
                            mo_mz.N_RFDZ = Convert.ToDecimal(this.txtmzdzrf.Text);
                            mo_mz.N_RFDC = Convert.ToDecimal(this.txtmzdcrf.Text);
                            mo_mz.N_DXTY = Convert.ToDecimal(this.txtmztydx.Text);
                            mo_mz.N_DXDZ = Convert.ToDecimal(this.txtmzdzdx.Text);
                            mo_mz.N_DXDC = Convert.ToDecimal(this.txtmzdcdx.Text);
                            mo_mz.N_DYTY = Convert.ToDecimal(this.txtmztydy.Text);
                            mo_mz.N_DYDZ = Convert.ToDecimal(this.txtmzdzdy.Text);
                            mo_mz.N_DYDC = Convert.ToDecimal(this.txtmzdcdy.Text);
                            mo_mz.N_DSTY = Convert.ToDecimal(this.txtmztyds.Text);
                            mo_mz.N_DSDZ = Convert.ToDecimal(this.txtmzdzds.Text);
                            mo_mz.N_DSDC = Convert.ToDecimal(this.txtmzdcds.Text);
                            mo_mz.N_ZDRFTY = Convert.ToDecimal(this.txtmztyzdrf.Text);
                            mo_mz.N_ZDRFDZ = Convert.ToDecimal(this.txtmzdzzdrf.Text);
                            mo_mz.N_ZDRFDC = Convert.ToDecimal(this.txtmzdczdrf.Text);
                            mo_mz.N_ZDDXTY = Convert.ToDecimal(this.txtmztyzddx.Text);
                            mo_mz.N_ZDDXDZ = Convert.ToDecimal(this.txtmzdzzddx.Text);
                            mo_mz.N_ZDDXDC = Convert.ToDecimal(this.txtmzdczddx.Text);
                            mo_mz.N_BCRFTY = Convert.ToDecimal(this.txtmztybcrf.Text);
                            mo_mz.N_BCRFDZ = Convert.ToDecimal(this.txtmzdzbcrf.Text);
                            mo_mz.N_BCRFDC = Convert.ToDecimal(this.txtmzdcbcrf.Text);
                            mo_mz.N_BCDXTY = Convert.ToDecimal(this.txtmztybcdx.Text);
                            mo_mz.N_BCDXDZ = Convert.ToDecimal(this.txtmzdzbcdx.Text);
                            mo_mz.N_BCDXDC = Convert.ToDecimal(this.txtmzdcbcdx.Text);
                            mo_mz.N_BCDYTY = Convert.ToDecimal(this.txtmztybcdy.Text);
                            mo_mz.N_BCDYDZ = Convert.ToDecimal(this.txtmzdzbcdy.Text);
                            mo_mz.N_BCDYDC = Convert.ToDecimal(this.txtmzdcbcdy.Text);
                            mo_mz.N_BCDSTY = Convert.ToDecimal(this.txtmztybcds.Text);
                            mo_mz.N_BCDSDZ = Convert.ToDecimal(this.txtmzdzbcds.Text);
                            mo_mz.N_BCDSDC = Convert.ToDecimal(this.txtmzdcbcds.Text);
                            mo_mz.N_GGTY = Convert.ToDecimal(this.txtmztygg.Text);
                            mo_mz.N_GGDZ = Convert.ToDecimal(this.txtmzdzgg.Text);
                            mo_mz.N_GGDC = Convert.ToDecimal(this.txtmzdcgg.Text);
                            mo_mz.N_GJTY = Convert.ToDecimal(this.txtmztygj.Text);
                            mo_mz.N_GJDZ = Convert.ToDecimal(this.txtmzdzgj.Text);
                            mo_mz.N_GJDC = Convert.ToDecimal(this.txtmzdcgj.Text);
                            objAgentManageDB.UpdateMQ(mo_mz, GetSql);
                            #endregion

                            #region"冰球"
                            //冰球　
                            mo_bq.N_HYZH = this.lbzj.Text;
                            mo_bq.N_RFTY = Convert.ToDecimal(this.txtbqtyrf.Text);
                            mo_bq.N_RFDZ = Convert.ToDecimal(this.txtbqdzrf.Text);
                            mo_bq.N_RFDC = Convert.ToDecimal(this.txtbqdcrf.Text);
                            mo_bq.N_DXTY = Convert.ToDecimal(this.txtbqtydx.Text);
                            mo_bq.N_DXDZ = Convert.ToDecimal(this.txtbqdzdx.Text);
                            mo_bq.N_DXDC = Convert.ToDecimal(this.txtbqdcdx.Text);
                            mo_bq.N_DYTY = Convert.ToDecimal(this.txtbqtydy.Text);
                            mo_bq.N_DYDZ = Convert.ToDecimal(this.txtbqdzdy.Text);
                            mo_bq.N_DYDC = Convert.ToDecimal(this.txtbqdcdy.Text);
                            mo_bq.N_DSTY = Convert.ToDecimal(this.txtbqtyds.Text);
                            mo_bq.N_DSDZ = Convert.ToDecimal(this.txtbqdzds.Text);
                            mo_bq.N_DSDC = Convert.ToDecimal(this.txtbqdcds.Text);
                            mo_bq.N_ZDRFTY = Convert.ToDecimal(this.txtbqtyzdrf.Text);
                            mo_bq.N_ZDRFDZ = Convert.ToDecimal(this.txtbqdzzdrf.Text);
                            mo_bq.N_ZDRFDC = Convert.ToDecimal(this.txtbqdczdrf.Text);
                            mo_bq.N_ZDDXTY = Convert.ToDecimal(this.txtbqtyzddx.Text);
                            mo_bq.N_ZDDXDZ = Convert.ToDecimal(this.txtbqdzzddx.Text);
                            mo_bq.N_ZDDXDC = Convert.ToDecimal(this.txtbqdczddx.Text);
                            mo_bq.N_SYTY = Convert.ToDecimal(this.txtbqtysy.Text);
                            mo_bq.N_SYDZ = Convert.ToDecimal(this.txtbqdzsy.Text);
                            mo_bq.N_SYDC = Convert.ToDecimal(this.txtbqdcsy.Text);
                            mo_bq.N_GGTY = Convert.ToDecimal(this.txtbqtygg.Text);
                            mo_bq.N_GGDZ = Convert.ToDecimal(this.txtbqdzgg.Text);
                            mo_bq.N_GGDC = Convert.ToDecimal(this.txtbqdcgg.Text);
                            mo_bq.N_GJTY = Convert.ToDecimal(this.txtbqtybcrf.Text);
                            mo_bq.N_GJDZ = Convert.ToDecimal(this.txtbqdzbcrf.Text);
                            mo_bq.N_GJDC = Convert.ToDecimal(this.txtbqdcbcrf.Text);
                            objAgentManageDB.UpdateBQ(mo_bq, GetSql);
                            #endregion
                            #region"彩球"
                            //彩球　
                            mo_cq.N_HYZH = this.lbzj.Text;
                            mo_cq.N_RFTY = Convert.ToDecimal(this.txtcqtyrf.Text);
                            mo_cq.N_RFDZ = Convert.ToDecimal(this.txtcqdzrf.Text);
                            mo_cq.N_RFDC = Convert.ToDecimal(this.txtcqdcrf.Text);
                            mo_cq.N_DXTY = Convert.ToDecimal(this.txtcqtydx.Text);
                            mo_cq.N_DXDZ = Convert.ToDecimal(this.txtcqdzdx.Text);
                            mo_cq.N_DXDC = Convert.ToDecimal(this.txtcqdcdx.Text);
                            mo_cq.N_DYTY = Convert.ToDecimal(this.txtcqtydy.Text);
                            mo_cq.N_DYDZ = Convert.ToDecimal(this.txtcqdzdy.Text);
                            mo_cq.N_DYDC = Convert.ToDecimal(this.txtcqdcdy.Text);
                            mo_cq.N_DSTY = Convert.ToDecimal(this.txtcqtyds.Text);
                            mo_cq.N_DSDZ = Convert.ToDecimal(this.txtcqdzds.Text);
                            mo_cq.N_DSDC = Convert.ToDecimal(this.txtcqdcds.Text);
                            mo_cq.N_ZDRFTY = Convert.ToDecimal(this.txtcqtyzdrf.Text);
                            mo_cq.N_ZDRFDZ = Convert.ToDecimal(this.txtcqdzzdrf.Text);
                            mo_cq.N_ZDRFDC = Convert.ToDecimal(this.txtcqdczdrf.Text);
                            mo_cq.N_ZDDXTY = Convert.ToDecimal(this.txtcqtyzddx.Text);
                            mo_cq.N_ZDDXDZ = Convert.ToDecimal(this.txtcqdzzddx.Text);
                            mo_cq.N_ZDDXDC = Convert.ToDecimal(this.txtcqdczddx.Text);
                            mo_cq.N_BCRFTY = Convert.ToDecimal(this.txtcqtybcrf.Text);
                            mo_cq.N_BCRFDZ = Convert.ToDecimal(this.txtcqdzbcrf.Text);
                            mo_cq.N_BCRFDC = Convert.ToDecimal(this.txtcqdcbcrf.Text);
                            mo_cq.N_BCDXTY = Convert.ToDecimal(this.txtcqtybcdx.Text);
                            mo_cq.N_BCDXDZ = Convert.ToDecimal(this.txtcqdzbcdx.Text);
                            mo_cq.N_BCDXDC = Convert.ToDecimal(this.txtcqdcbcdx.Text);
                            mo_cq.N_BCDYTY = Convert.ToDecimal(this.txtcqtybcdy.Text);
                            mo_cq.N_BCDYDZ = Convert.ToDecimal(this.txtcqdzbcdy.Text);
                            mo_cq.N_BCDYDC = Convert.ToDecimal(this.txtcqdcbcdy.Text);
                            mo_cq.N_BCDSTY = Convert.ToDecimal(this.txtcqtybcds.Text);
                            mo_cq.N_BCDSDZ = Convert.ToDecimal(this.txtcqdzbcds.Text);
                            mo_cq.N_BCDSDC = Convert.ToDecimal(this.txtcqdcbcds.Text);
                            mo_cq.N_GGTY = Convert.ToDecimal(this.txtcqtygg.Text);
                            mo_cq.N_GGDZ = Convert.ToDecimal(this.txtcqdzgg.Text);
                            mo_cq.N_GGDC = Convert.ToDecimal(this.txtcqdcgg.Text);
                            mo_cq.N_GJTY = Convert.ToDecimal(this.txtcqtygj.Text);
                            mo_cq.N_GJDZ = Convert.ToDecimal(this.txtcqdzgj.Text);
                            mo_cq.N_GJDC = Convert.ToDecimal(this.txtcqdcgj.Text);
                            objAgentManageDB.UpdateCQ(mo_cq, GetSql);
                            #endregion
                            #region"指 數"
                            //指 數　
                            mo_zs.N_HYZH = this.lbzj.Text;
                            mo_zs.N_RFTY = Convert.ToDecimal(this.txtzstyrf.Text);
                            mo_zs.N_RFDZ = Convert.ToDecimal(this.txtzsdzrf.Text);
                            mo_zs.N_RFDC = Convert.ToDecimal(this.txtzsdcrf.Text);
                            mo_zs.N_DXTY = Convert.ToDecimal(this.txtzstydx.Text);
                            mo_zs.N_DXDZ = Convert.ToDecimal(this.txtzsdzdx.Text);
                            mo_zs.N_DXDC = Convert.ToDecimal(this.txtzsdcdx.Text);
                            mo_zs.N_DYTY = Convert.ToDecimal(this.txtzstydy.Text);
                            mo_zs.N_DYDZ = Convert.ToDecimal(this.txtzsdzdy.Text);
                            mo_zs.N_DYDC = Convert.ToDecimal(this.txtzsdcdy.Text);
                            mo_zs.N_DSTY = Convert.ToDecimal(this.txtzstyds.Text);
                            mo_zs.N_DSDZ = Convert.ToDecimal(this.txtzsdzds.Text);
                            mo_zs.N_DSDC = Convert.ToDecimal(this.txtzsdcds.Text);
                            mo_zs.N_ZDRFTY = Convert.ToDecimal(this.txtzstyzdrf.Text);
                            mo_zs.N_ZDRFDZ = Convert.ToDecimal(this.txtzsdzzdrf.Text);
                            mo_zs.N_ZDRFDC = Convert.ToDecimal(this.txtzsdczdrf.Text);
                            mo_zs.N_ZDDXTY = Convert.ToDecimal(this.txtzstyzddx.Text);
                            mo_zs.N_ZDDXDZ = Convert.ToDecimal(this.txtzsdzzddx.Text);
                            mo_zs.N_ZDDXDC = Convert.ToDecimal(this.txtzsdczddx.Text);
                            mo_zs.N_SYTY = Convert.ToDecimal(this.txtzstysy.Text);
                            mo_zs.N_SYDZ = Convert.ToDecimal(this.txtzsdzsy.Text);
                            mo_zs.N_SYDC = Convert.ToDecimal(this.txtzsdcsy.Text);
                            mo_zs.N_BDTY = Convert.ToDecimal(this.txtzstybd.Text);
                            mo_zs.N_BDDZ = Convert.ToDecimal(this.txtzsdzbd.Text);
                            mo_zs.N_BDDC = Convert.ToDecimal(this.txtzsdcbd.Text);
                            mo_zs.N_GGTY = Convert.ToDecimal(this.txtzstygg.Text);
                            mo_zs.N_GGDZ = Convert.ToDecimal(this.txtzsdzgg.Text);
                            mo_zs.N_GGDC = Convert.ToDecimal(this.txtzsdcgg.Text);
                            mo_zs.N_GJTY = Convert.ToDecimal(this.txtzstygj.Text);
                            mo_zs.N_GJDZ = Convert.ToDecimal(this.txtzsdzgj.Text);
                            mo_zs.N_GJDC = Convert.ToDecimal(this.txtzsdcgj.Text);
                            objAgentManageDB.UpdateZS(mo_zs, GetSql);
                            #endregion
                            #region"赛马"
                            //赛马　
                            mo_sm.N_HYDH = this.lbzj.Text;
                            mo_sm.N_DYTY = Convert.ToDecimal(this.txtsmtydy.Text);
                            mo_sm.N_DYDZ = Convert.ToDecimal(this.txtsmdzdy.Text);
                            mo_sm.N_DYDC = Convert.ToDecimal(this.txtsmdcdy.Text);
                            mo_sm.N_WZTY = Convert.ToDecimal(this.txtsmtywz.Text);
                            mo_sm.N_WZDZ = Convert.ToDecimal(this.txtsmdzwz.Text);
                            mo_sm.N_WZDC = Convert.ToDecimal(this.txtsmdcwz.Text);
                            mo_sm.N_LYTY = Convert.ToDecimal(this.txtsmtyly.Text);
                            mo_sm.N_LYDZ = Convert.ToDecimal(this.txtsmdzly.Text);
                            mo_sm.N_LYDC = Convert.ToDecimal(this.txtsmdcly.Text);
                            mo_sm.N_WZQTY = Convert.ToDecimal(this.txtsmtywzq.Text);
                            mo_sm.N_WZQDZ = Convert.ToDecimal(this.txtsmdzwzq.Text);
                            mo_sm.N_WZQDC = Convert.ToDecimal(this.txtsmdcwzq.Text);
                            objAgentManageDB.UpdateSM(mo_sm, GetSql);
                            #endregion
                            #region"六合彩"
                            //六合彩　
                            mo_lhc.N_HYDH = this.lbzj.Text;
                            mo_lhc.N_TBHTY = Convert.ToDecimal(this.txtlhctytbh.Text);
                            mo_lhc.N_TBHDZ = Convert.ToDecimal(this.txtlhcdztbh.Text);
                            mo_lhc.N_TBHDC = Convert.ToDecimal(this.txtlhcdctbh.Text);
                            mo_lhc.N_TTTY = Convert.ToDecimal(this.txtlhctytt.Text);
                            mo_lhc.N_TTDZ = Convert.ToDecimal(this.txtlhcdztt.Text);
                            mo_lhc.N_TTDC = Convert.ToDecimal(this.txtlhcdctt.Text);
                            mo_lhc.N_THTY = Convert.ToDecimal(this.txtlhctyth.Text);
                            mo_lhc.N_THDZ = Convert.ToDecimal(this.txtlhcdzth.Text);
                            mo_lhc.N_THDC = Convert.ToDecimal(this.txtlhcdcth.Text);
                            mo_lhc.N_QCPTY = Convert.ToDecimal(this.txtlhctyqcp.Text);
                            mo_lhc.N_QCPDZ = Convert.ToDecimal(this.txtlhcdzqcp.Text);
                            mo_lhc.N_QCPDC = Convert.ToDecimal(this.txtlhcdcqcp.Text);
                            mo_lhc.N_2XTY = Convert.ToDecimal(this.txtlhcty2x.Text);
                            mo_lhc.N_2XDZ = Convert.ToDecimal(this.txtlhcdz2x.Text);
                            mo_lhc.N_2XDC = Convert.ToDecimal(this.txtlhcdc2x.Text);
                            mo_lhc.N_3XTY = Convert.ToDecimal(this.txtlhcty3x.Text);
                            mo_lhc.N_3XDZ = Convert.ToDecimal(this.txtlhcdz3x.Text);
                            mo_lhc.N_3XDC = Convert.ToDecimal(this.txtlhcdc3x.Text);
                            mo_lhc.N_4XTY = Convert.ToDecimal(this.txtlhcty4x.Text);
                            mo_lhc.N_4XDZ = Convert.ToDecimal(this.txtlhcdz4x.Text);
                            mo_lhc.N_4XDC = Convert.ToDecimal(this.txtlhcdc4x.Text);
                            mo_lhc.N_GDDSTY = Convert.ToDecimal(this.txtlhctygdds.Text);
                            mo_lhc.N_GDDSDZ = Convert.ToDecimal(this.txtlhcdzgdds.Text);
                            mo_lhc.N_GDDSDC = Convert.ToDecimal(this.txtlhcdcgdds.Text);
                            mo_lhc.N_GDDXTY = Convert.ToDecimal(this.txtlhctygddx.Text);
                            mo_lhc.N_GDDXDZ = Convert.ToDecimal(this.txtlhcdzgddx.Text);
                            mo_lhc.N_GDDXDC = Convert.ToDecimal(this.txtlhcdcgddx.Text);
                            objAgentManageDB.UpdateLHC(mo_lhc, GetSql);
                            #endregion
                            #region"大樂透"
                            //大樂透　
                            mo_dlt.N_HYDH = this.lbzj.Text;
                            mo_dlt.N_TBHTY = Convert.ToDecimal(this.txtdlttytbh.Text);
                            mo_dlt.N_TBHDZ = Convert.ToDecimal(this.txtdltdztbh.Text);
                            mo_dlt.N_TBHDC = Convert.ToDecimal(this.txtdltdctbh.Text);
                            mo_dlt.N_TTTY = Convert.ToDecimal(this.txtdlttytt.Text);
                            mo_dlt.N_TTDZ = Convert.ToDecimal(this.txtdltdztt.Text);
                            mo_dlt.N_TTDC = Convert.ToDecimal(this.txtdltdctt.Text);
                            mo_dlt.N_THTY = Convert.ToDecimal(this.txtdlttyth.Text);
                            mo_dlt.N_THDZ = Convert.ToDecimal(this.txtdltdzth.Text);
                            mo_dlt.N_THDC = Convert.ToDecimal(this.txtdltdcth.Text);
                            mo_dlt.N_QCPTY = Convert.ToDecimal(this.txtdlttyqcp.Text);
                            mo_dlt.N_QCPDZ = Convert.ToDecimal(this.txtdltdzqcp.Text);
                            mo_dlt.N_QCPDC = Convert.ToDecimal(this.txtdltdcqcp.Text);
                            mo_dlt.N_2XTY = Convert.ToDecimal(this.txtdltty2x.Text);
                            mo_dlt.N_2XDZ = Convert.ToDecimal(this.txtdltdz2x.Text);
                            mo_dlt.N_2XDC = Convert.ToDecimal(this.txtdltdc2x.Text);
                            mo_dlt.N_3XTY = Convert.ToDecimal(this.txtdltty3x.Text);
                            mo_dlt.N_3XDZ = Convert.ToDecimal(this.txtdltdz3x.Text);
                            mo_dlt.N_3XDC = Convert.ToDecimal(this.txtdltdc3x.Text);
                            mo_dlt.N_4XTY = Convert.ToDecimal(this.txtdltty4x.Text);
                            mo_dlt.N_4XDZ = Convert.ToDecimal(this.txtdltdz4x.Text);
                            mo_dlt.N_4XDC = Convert.ToDecimal(this.txtdltdc4x.Text);
                            mo_dlt.N_GDDSTY = Convert.ToDecimal(this.txtdlttygdds.Text);
                            mo_dlt.N_GDDSDZ = Convert.ToDecimal(this.txtdltdzgdds.Text);
                            mo_dlt.N_GDDSDC = Convert.ToDecimal(this.txtdltdcgdds.Text);
                            mo_dlt.N_GDDXTY = Convert.ToDecimal(this.txtdlttygddx.Text);
                            mo_dlt.N_GDDXDZ = Convert.ToDecimal(this.txtdltdzgddx.Text);
                            mo_dlt.N_GDDXDC = Convert.ToDecimal(this.txtdltdcgddx.Text);
                            objAgentManageDB.UpdateDLT(mo_dlt, GetSql);
                            #endregion
                            #region"今彩539"
                            //今彩539　
                            mo_jc539.N_HYDH = this.lbzj.Text;
                            mo_jc539.N_QCPTY = Convert.ToDecimal(this.txtjc539tyqcp.Text);
                            mo_jc539.N_QCPDZ = Convert.ToDecimal(this.txtjc539dzqcp.Text);
                            mo_jc539.N_QCPDC = Convert.ToDecimal(this.txtjc539dcqcp.Text);
                            mo_jc539.N_2XTY = Convert.ToDecimal(this.txtjc539ty2x.Text);
                            mo_jc539.N_2XDZ = Convert.ToDecimal(this.txtjc539dz2x.Text);
                            mo_jc539.N_2XDC = Convert.ToDecimal(this.txtjc539dc2x.Text);
                            mo_jc539.N_3XTY = Convert.ToDecimal(this.txtjc539ty3x.Text);
                            mo_jc539.N_3XDZ = Convert.ToDecimal(this.txtjc539dz3x.Text);
                            mo_jc539.N_3XDC = Convert.ToDecimal(this.txtjc539dc3x.Text);
                            mo_jc539.N_4XTY = Convert.ToDecimal(this.txtjc539ty4x.Text);
                            mo_jc539.N_4XDZ = Convert.ToDecimal(this.txtjc539dz4x.Text);
                            mo_jc539.N_4XDC = Convert.ToDecimal(this.txtjc539dc4x.Text);
                            objAgentManageDB.UpdateJC539(mo_jc539, GetSql);
                            #endregion
                            #region"運動彩票"
                            //運動彩票　
                            mo_cp.N_HYDH = this.lbzj.Text;
                            mo_cp.N_BQTY = Convert.ToDecimal(this.txtcptybq.Text);
                            mo_cp.N_BQDZ = Convert.ToDecimal(this.txtcpdzbq.Text);
                            mo_cp.N_BQDC = Convert.ToDecimal(this.txtcpdcbq.Text);
                            mo_cp.N_LQTY = Convert.ToDecimal(this.txtcptylq.Text);
                            mo_cp.N_LQDZ = Convert.ToDecimal(this.txtcpdzlq.Text);
                            mo_cp.N_LQDC = Convert.ToDecimal(this.txtcpdclq.Text);
                            mo_cp.N_ZQTY = Convert.ToDecimal(this.txtcptyzq.Text);
                            mo_cp.N_ZQDZ = Convert.ToDecimal(this.txtcpdzzq.Text);
                            mo_cp.N_ZQDC = Convert.ToDecimal(this.txtcpdczq.Text);
                            mo_cp.N_GSTY = Convert.ToDecimal(this.txtcptygs.Text);
                            mo_cp.N_GSDZ = Convert.ToDecimal(this.txtcpdzgs.Text);
                            mo_cp.N_GSDC = Convert.ToDecimal(this.txtcpdcgs.Text);
                            mo_cp.N_QZTY = Convert.ToDecimal(this.txtcptyqz.Text);
                            mo_cp.N_QZDZ = Convert.ToDecimal(this.txtcpdzqz.Text);
                            mo_cp.N_QZDC = Convert.ToDecimal(this.txtcpdcqz.Text);
                            objAgentManageDB.UpdateCP(mo_cp, GetSql);
                            #endregion
                            #region"時事"
                            //時事　
                            mo_ss.N_HYDH = this.lbzj.Text;
                            mo_ss.N_DYTY = Convert.ToDecimal(this.txtsstydy.Text);
                            mo_ss.N_DYDZ = Convert.ToDecimal(this.txtssdzdy.Text);
                            mo_ss.N_DYDC = Convert.ToDecimal(this.txtssdcdy.Text);
                            objAgentManageDB.UpdateSS(mo_ss, GetSql);
                            #endregion

                            objAgentManageDB.UpdateHT(GetSql);

                            objAgentManageDB.UpZJ(this.txtxyed.Text, this.hidxy.Value, mo_zhgl.N_HYZH);
                            #region"修改下綫"
                            string strhidvalue = this.hidvalue.Value;
                            string strZH = "";
                            string strFlag = "";
                            DataSet getds = new DataSet();
                            if (strhidvalue.IndexOf(":") > -1)
                            {
                                //取出所有會員
                                if (!strlvl.Equals("9"))
                                {
                                    getds = objAgentManageDB.GetZH(strlvl, this.lbzj.Text);
                                    if (getds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < getds.Tables[0].Rows.Count; i++)
                                        {
                                            strZH = strZH + strFlag + "'" + getds.Tables[0].Rows[i]["n_hyzh"].ToString() + "'";
                                            strFlag = ",";
                                        }
                                    }
                                }
                                getds = objAgentManageDB.GetHYZH(strlvl, this.lbzj.Text);
                                if (getds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < getds.Tables[0].Rows.Count; i++)
                                    {
                                        strZH = strZH + strFlag + "'" + getds.Tables[0].Rows[i]["n_hyzh"].ToString() + "'";
                                        strFlag = ",";
                                    }
                                }
                                if (!strZH.Equals(""))
                                {
                                    string[] strarr = strhidvalue.Split(';');
                                    for (int i = 0; i < strarr.Length - 1; i++)
                                    {
                                        string[] strElement = strarr[i].ToString().Split(':');
                                        string strtable = strElement[0];
                                        string[] strvalue = strElement[1].ToString().Split(',');
                                        if (!strtable.Equals("cz"))
                                        {
                                            if (strtable.Equals("mz"))
                                            {
                                                strtable = "mq";
                                            }
                                            objAgentManageDB.Update(strtable, strvalue[0].ToString(), strvalue[1].ToString(), strZH);
                                        }
                                        else
                                        {
                                            objAgentManageDB.UpdateZHGL(Comm.GetColum(strvalue[0].ToString()), strvalue[1].ToString(), strZH);
                                        }

                                    }
                                }
                            }
                            #endregion
                            SetPage(this.ViewState["strlvl"].ToString());
                            this.ShowMsg("修改成功");
                        }
                        else
                        {
                            this.ShowMsg("剩餘額度不足！");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.WriteLog("用户名=" + mUserID+ex.ToString()); 
                this.Response.Write("對不起，系統繁忙，請稍候再操作！<br>" + ex.Message + "<br>" + ex.StackTrace);
                this.Response.End();
            }
        }
        #endregion
        #region"取得最大ID"
        public int GetMaxID()
        {

            return Convert.ToInt32(objAgentManageDB.GetMaxID()) + 1;
        }
        #endregion
        #region"取得各级帐号"
        public string GetGJZH(int intlv, int intzh)
        {
          
            string strreturn = string.Empty;
            if (intlv < intzh)
            {
                strreturn = "";
            }
            else if (intlv == intzh)
            {
                strreturn = this.lbzj.Text;
            }
            else
            {
                string strcname = string.Empty;
                switch (intzh)
                {
                    case 4: strcname = "n_dzjdh"; break;
                    case 5: strcname = "n_zjdh"; break;
                    case 6: strcname = "n_dgddh"; break;
                    case 7: strcname = "n_gddh"; break;
                    case 8: strcname = "n_zdldh"; break;
                    case 9: strcname = "n_dldh"; break;
                }
                strreturn = this.objAgentManageAddDB.GetGJZH(strcname, strparid);
            }
            return strreturn;
        }
        #endregion
        #region"给隐藏栏位复制"
        public void GetGJZH()
        {
            /*
           this.hidlq.Value=this.txtlq.Text;
           this.hidmb.Value=this.txtmb.Text;
           this.hidrb.Value=this.txtrb.Text;
           this.hidtb.Value=this.txttb.Text;
           this.hidmz.Value=this.txtmz.Text;
           this.hidzq.Value=this.txtzq.Text;
           this.hidzs.Value=this.txtzs.Text;
           this.hiddlt.Value=this.txtdlt.Text;
           this.hidsm.Value=this.txtsm.Text;
           this.hidlhc.Value=this.txtlhc.Text;
           this.hid2x.Value=this.txt2x.Text;
           this.hia3x.value= this.txt3x.Text;
           this.hia4x.value = this.txt4x.Text;
           this.hidjc539.Value=this.txtjc539.Text;
           this.hidcp.Value= this.txtcp.Text;
             * */
        }
        #endregion
        //帳號管理 修改上级剩余额度
        #region"帳號管理" 修改上级剩余额度
        public KFB_ZHGL SetModel()
        {
            KFB_ZHGL mo_zhgl = new KFB_ZHGL();
    
            mo_zhgl = this.objAgentManageDB.GetModel(this.lbzj.Text);
            //帳號管理
            #region"帳號管理"
            string strMD5 = FormsAuthPasswordFormat.MD5.ToString();

            mo_zhgl.N_HYZH = this.lbzj.Text;
            mo_zhgl.N_HYMC = this.txtzjmc.Text;
            mo_zhgl.N_HYDJ = Convert.ToInt32(strlvl);
            mo_zhgl.N_YXDL = Convert.ToInt32(this.Rdyxdl.SelectedValue);
            mo_zhgl.N_YXXZ = Convert.ToInt32(this.Rdyxxz.SelectedValue);
            mo_zhgl.N_DZJDH = GetGJZH(Convert.ToInt32(strlvl), 4);
            mo_zhgl.N_ZJDH = GetGJZH(Convert.ToInt32(strlvl), 5);
            mo_zhgl.N_DGDDH = GetGJZH(Convert.ToInt32(strlvl), 6);
            mo_zhgl.N_GDDH = GetGJZH(Convert.ToInt32(strlvl), 7);
            mo_zhgl.N_ZDLDH = GetGJZH(Convert.ToInt32(strlvl), 8);
            mo_zhgl.N_DLDH = GetGJZH(Convert.ToInt32(strlvl), 9);
            mo_zhgl.N_KYED = Convert.ToDecimal(this.txtxyed.Text);
            //mo_zhgl.N_SYED = Convert.ToDecimal(this.txtsyed.Text);
            mo_zhgl.N_SYED = Convert.ToDecimal(mo_zhgl.N_SYED.Value);
            if (this.txtmm.Text.Equals(this.txtzrmm.Text) && !this.txtmm.Text.Equals("***"))
            {
                mo_zhgl.N_HYMM = FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtmm.Text.ToUpper(), strMD5);
            }
            mo_zhgl.N_ZQCZ = Convert.ToInt32(this.txtczzq.Text);
            mo_zhgl.N_LQCZ = Convert.ToInt32(this.txtczlq.Text);
            mo_zhgl.N_MZCZ = Convert.ToInt32(this.txtczmz.Text);
            mo_zhgl.N_MBCZ = Convert.ToInt32(this.txtczmb.Text);
            mo_zhgl.N_RBCZ = Convert.ToInt32(this.txtczrb.Text);
            mo_zhgl.N_TBCZ = Convert.ToInt32(this.txtcztb.Text);
            mo_zhgl.N_ZSCZ = Convert.ToInt32(this.txtczzs.Text);
            mo_zhgl.N_SMCZ = Convert.ToInt32(this.txtczsm.Text);
            mo_zhgl.N_DLTCZ = Convert.ToInt32(this.txtczdlt.Text);
            mo_zhgl.N_CPCZ = Convert.ToInt32(this.txtczcp.Text);
            mo_zhgl.N_LHCCZ = Convert.ToInt32(this.txtczlhc.Text);
            mo_zhgl.N_JCCZ = Convert.ToInt32(this.txtczjc539.Text);
            mo_zhgl.N_2XCZ = Convert.ToInt32(this.txtcz2x.Text);
            mo_zhgl.N_3XCZ = Convert.ToInt32(this.txtcz3x.Text);
            mo_zhgl.N_4XCZ = Convert.ToInt32(this.txtcz4x.Text);
            mo_zhgl.N_SSCZ = Convert.ToInt32(this.txtczss.Text);
            mo_zhgl.N_DDSX = float.Parse(this.txtddsx.Text);

            mo_zhgl.N_BQCZ = Convert.ToInt32(this.txtczbq.Text);
            mo_zhgl.N_CQCZ = Convert.ToInt32(this.txtczcq.Text);
            //   mo_zhgl.N_HYJRSJ = DateTime.Now;
            mo_zhgl.N_HYXG = DateTime.Now;
            mo_zhgl.N_XZYC = Convert.ToInt32(this.Rdycxz.SelectedValue);
            mo_zhgl.N_TOLLGATE = Convert.ToInt32(this.drpXiazhuNum.SelectedValue);

            #endregion
            return mo_zhgl;
        }
        #endregion
        protected void btfh_Click(object sender, EventArgs e)
        {
            string strpage = Comm.GetPage(this.ViewState["strlvl"].ToString(), strparid);
            this.Server.Transfer(strpage);
        }
        protected void btdel_Click(object sender, EventArgs e)
        {
         
            string strpage = Comm.GetPage(this.ViewState["strlvl"].ToString(), strparid); 
            KFB_ZHGL mo_zhgl = new KFB_ZHGL(); 
            ////判断是否有下线
            //bool chxx = o_KFB_ZHGL.Exists(Convert.ToInt32(strlvl), strparid);
            //if (chxx)
            //{
            //    this.ShowMsg("存在下级会员，不能删除！");
            //}
            //判断是否有注單
            int i_Count = this.objAgentManageDB.GetZD(strparid, Comm.GetZHCol(strlvl));
            if (i_Count > 0)
            {
                this.ShowMsg("本賬號已有注單，無法删除！");
                return;
            }

            int i_HYCount = this.objAgentManageDB.GetHYZD(strparid, Comm.GetZHCol(strlvl));
            if (i_HYCount > 0)
            {
                this.ShowMsg("本賬號下級會員已有注單，無法删除！");
                return;
            }

            int i_oCount = this.objAgentManageDB.GetOZD(strparid, Comm.GetZHCol(strlvl));
            if (i_oCount > 0)
            {
                this.ShowMsg("本賬號已有歷史注單，無法删除！");
                return;
            }

            int i_oHYCount = this.objAgentManageDB.GetOHYZD(strparid, Comm.GetZHCol(strlvl));
            if (i_oHYCount > 0)
            {
                this.ShowMsg("本賬號下級會員已有歷史注單，無法删除！");
                return;
            }

            try
            {
                //判斷是否存在
                bool chuser = this.objAgentManageDB.Exists(this.lbzj.Text);
                if (!chuser)
                {
                    this.ShowMsg("該會員已被刪除！");
                }
                else//存在則修改
                {
                    mo_zhgl = SetModel();
                    #region"修改上级剩余额度"
                    this.objAgentManageDB.UpSJED(mo_zhgl);

                    #endregion
                    //o_KFB_ZHGL.Delete(strparid, Convert.ToInt32(strlvl));
                    this.objAgentManageDB.DeleteAll(strparid, Comm.GetZHCol(strlvl));

                    this.ShowMsg("刪除成功");
                }
            }
            catch (Exception ex)
            {
                this.WriteLog(ex.ToString());
                this.ShowMsg("刪除失败");
            }

        }
    }
