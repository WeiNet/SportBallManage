using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class AgentManageAdd : BasePage
    {
        private string strlvl = "";
        private string struser = "";
        private string strparid = "";
        #region"Page_Load"
        protected void Page_Load(object sender, EventArgs e)
        {

            strlvl = Request["lv"];
            if (Request["user"] != null)
            {
                struser = Request["user"];
            }
            if (Request["parid"] != null)
            {
                strparid = Request["parid"];
            }
            if (!IsPostBack)
            {
                SetPage(strlvl);
            }

        }
        #endregion
        #region"頁面初始化"
        protected void SetPage(string strlv)
        {
            this.lbtitle.Text = "&nbsp;&nbsp;&nbsp;&nbsp;" + Comm.GetLvName(strlv) + "管理";  // 新增" + Comm.GetLvName(strlv);
            this.lbtitle1.Text = "新增" + Comm.GetLvName(strlv);
            this.lbzh.Text = Comm.GetLvName(strlv) + "帳號：";
            this.lbzhmc.Text = Comm.GetLvName(strlv) + "名稱：";
            this.Rdyxdl.Items[0].Selected = true;
            this.Rdyxxz.Items[0].Selected = true;
            this.Rdycxz.Items[1].Selected = true;
            if (strlvl != "4")
            {
                string strzh = Comm.GetUPID(strparid, strlvl);
                if (Comm.SJYXDL(strzh).Equals(false))
                {
                    this.Rdyxdl.Attributes.Add("onclick", "document.getElementsByName('Rdyxdl')[2].checked=true;");
                    this.Rdyxdl.Items[1].Selected = true;
                }
                if (Comm.SJYXXZ(strzh).Equals(false))
                {
                    this.Rdyxxz.Attributes.Add("onclick", "document.getElementsByName('Rdyxxz')[2].checked=true;");
                    this.Rdyxxz.Items[1].Selected = true;
                }
            }
            //this.bttjzj.Text = "添加" + Comm.GetLvName(strlv);
            this.bttjzj.Text = "確定";
            this.btAddzj.Text = "新增" + Comm.GetLvName(strlv);
            string[] strHYDH = Comm.GetZH(strlv, strparid).Split(',');
            if (!strlv.Equals("9"))
            {
                this.tdcol.ColSpan = 3;
                this.tdlbXiazhuNum.Visible = false;
                this.tddrpXiazhuNum.Visible = false;
            }
            for (int i = 0; i < strHYDH.Length - 1; i++)
            {
                this.drzjzh.Items.Add(strHYDH[i]);
            }
            if (strlv.Equals("4"))
            {
                DZJFZ();
            }
            else
            {
                HYFZ();
            }
            //添加JS
            this.txtlq.Attributes.Add("onblur", "checkCZ(this,'籃球','" + this.txtlq.Text + "')");
            this.txtmb.Attributes.Add("onblur", "checkCZ(this,'棒球','" + this.txtmb.Text + "')");
            this.txtrb.Attributes.Add("onblur", "checkCZ(this,'网球','" + this.txtrb.Text + "')");
            this.txttb.Attributes.Add("onblur", "checkCZ(this,'排球','" + this.txttb.Text + "')");
            this.txtmz.Attributes.Add("onblur", "checkCZ(this,'美足','" + this.txtmz.Text + "')");
            this.txtzq.Attributes.Add("onblur", "checkCZ(this,'足球','" + this.txtzq.Text + "')");
            this.txtzs.Attributes.Add("onblur", "checkCZ(this,'指數','" + this.txtzs.Text + "')");
            this.txtdlt.Attributes.Add("onblur", "checkCZ(this,'大樂透','" + this.txtdlt.Text + "')");
            this.txtsm.Attributes.Add("onblur", "checkCZ(this,'賽馬','" + this.txtsm.Text + "')");
            this.txtlhc.Attributes.Add("onblur", "checkCZ(this,'六合彩','" + this.txtlhc.Text + "')");
            this.txt2x.Attributes.Add("onblur", "checkCZ(this,'二星','" + this.txt2x.Text + "')");
            this.txt3x.Attributes.Add("onblur", "checkCZ(this,'三星','" + this.txt3x.Text + "')");
            this.txt4x.Attributes.Add("onblur", "checkCZ(this,'四星','" + this.txt4x.Text + "')");
            this.txtjc539.Attributes.Add("onblur", "checkCZ(this,'今彩539','" + this.txtjc539.Text + "')");
            this.txtcp.Attributes.Add("onblur", "checkCZ(this,'運動彩票','" + this.txtcp.Text + "')");
            this.txtss.Attributes.Add("onblur", "checkCZ(this,'時事','" + this.txtss.Text + "')");

            this.txtbq.Attributes.Add("onblur", "checkCZ(this,'冰球','" + this.txtbq.Text + "')");
            this.txtcq.Attributes.Add("onblur", "checkCZ(this,'彩球','" + this.txtcq.Text + "')");

            this.txtxyed.Attributes.Add("onkeypress", "return inputNubmerFloat();");
            this.txtddsx.Attributes.Add("onkeypress", "return inputNubmerFloat();");
            this.bttjzj.Attributes.Add("onclick", " return (checkInput() && chMM());");
            this.btAddzj.Attributes.Add("onclick", " return (checkInput() && chMM());");
            //this.txtmm.Attributes.Add("onblur", "chMM();");
            //this.txtzrmm.Attributes.Add("onblur", "chMM();");
            this.txtxyed.Attributes.Add("onblur", " chxyed(this,'0','" + this.hidje.Value + "');");
            //给隐藏栏位复制
            //GetGJZH();

        }
        #endregion
        #region"大总监頁面赋值"
        public void DZJFZ()
        {
            AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
           
            KFB_MRZJ mo_mrzj = new KFB_MRZJ();
            mo_mrzj = objAgentManageAddDB.GetModel();
            //拆帐赋值
            this.txtlq.Text = mo_mrzj.N_LQ.ToString();
            this.txtmb.Text = mo_mrzj.N_MB.ToString();
            this.txtrb.Text = mo_mrzj.N_RB.ToString();
            this.txttb.Text = mo_mrzj.N_TB.ToString();
            this.txtmz.Text = mo_mrzj.N_MZ.ToString();
            this.txtzq.Text = mo_mrzj.N_ZQ.ToString();
            this.txtzs.Text = mo_mrzj.N_ZS.ToString();
            this.txtdlt.Text = mo_mrzj.N_DLT.ToString();
            this.txtsm.Text = mo_mrzj.N_SM.ToString();
            this.txtlhc.Text = mo_mrzj.N_LHC.ToString();
            this.txt2x.Text = mo_mrzj.N_2X.ToString();
            this.txt3x.Text = mo_mrzj.N_3X.ToString();
            this.txt4x.Text = mo_mrzj.N_4X.ToString();
            this.txtjc539.Text = mo_mrzj.N_JC539.ToString();
            this.txtcp.Text = mo_mrzj.N_CP.ToString();
            this.txtss.Text = mo_mrzj.N_SS.ToString();


            this.txtbq.Text = mo_mrzj.N_BQ.ToString();
            this.txtcq.Text = mo_mrzj.N_CQ.ToString();
            //篮球 
            #region
            this.txtlqtyrf.Text = mo_mrzj.N_LQRFTY.ToString();
            this.txtlqdzrf.Text = mo_mrzj.N_LQRFDZ.ToString();
            this.txtlqdcrf.Text = mo_mrzj.N_LQRFDC.ToString();
            this.txtlqtydx.Text = mo_mrzj.N_LQDXTY.ToString();
            this.txtlqdzdx.Text = mo_mrzj.N_LQDXDZ.ToString();
            this.txtlqdcdx.Text = mo_mrzj.N_LQDXDC.ToString();
            this.txtlqtydy.Text = mo_mrzj.N_LQDYTY.ToString();
            this.txtlqdzdy.Text = mo_mrzj.N_LQDYDZ.ToString();
            this.txtlqdcdy.Text = mo_mrzj.N_LQDYDC.ToString();
            this.txtlqtyds.Text = mo_mrzj.N_LQDSTY.ToString();
            this.txtlqdzds.Text = mo_mrzj.N_LQDSDZ.ToString();
            this.txtlqdcds.Text = mo_mrzj.N_LQDSDC.ToString();
            this.txtlqtyzdrf.Text = mo_mrzj.N_LQZDRFTY.ToString();
            this.txtlqdzzdrf.Text = mo_mrzj.N_LQZDRFDZ.ToString();
            this.txtlqdczdrf.Text = mo_mrzj.N_LQZDRFDC.ToString();
            this.txtlqtyzddx.Text = mo_mrzj.N_LQZDDXTY.ToString();
            this.txtlqdzzddx.Text = mo_mrzj.N_LQZDDXDZ.ToString();
            this.txtlqdczddx.Text = mo_mrzj.N_LQZDDXDC.ToString();
            this.txtlqtybcrf.Text = mo_mrzj.N_LQBCRFTY.ToString();
            this.txtlqdzbcrf.Text = mo_mrzj.N_LQBCRFDZ.ToString();
            this.txtlqdcbcrf.Text = mo_mrzj.N_LQBCRFDC.ToString();
            this.txtlqtybcdx.Text = mo_mrzj.N_LQBCDXTY.ToString();
            this.txtlqdzbcdx.Text = mo_mrzj.N_LQBCDXDZ.ToString();
            this.txtlqdcbcdx.Text = mo_mrzj.N_LQBCDXDC.ToString();
            this.txtlqtybcdy.Text = mo_mrzj.N_LQBCDYTY.ToString();
            this.txtlqdzbcdy.Text = mo_mrzj.N_LQBCDYDZ.ToString();
            this.txtlqdcbcdy.Text = mo_mrzj.N_LQBCDYDC.ToString();
            this.txtlqtybcds.Text = mo_mrzj.N_LQBCDSTY.ToString();
            this.txtlqdzbcds.Text = mo_mrzj.N_LQBCDSDZ.ToString();
            this.txtlqdcbcds.Text = mo_mrzj.N_LQBCDSDC.ToString();
            this.txtlqtygg.Text = mo_mrzj.N_LQGGTY.ToString();
            this.txtlqdzgg.Text = mo_mrzj.N_LQGGDZ.ToString();
            this.txtlqdcgg.Text = mo_mrzj.N_LQGGDC.ToString();
            this.txtlqtygj.Text = mo_mrzj.N_LQGJTY.ToString();
            this.txtlqdzgj.Text = mo_mrzj.N_LQGJDZ.ToString();
            this.txtlqdcgj.Text = mo_mrzj.N_LQGJDC.ToString();

            this.txtlqddrf.Text = mo_mrzj.N_LQRFDD.ToString();
            this.txtlqdddx.Text = mo_mrzj.N_LQDXDD.ToString();
            this.txtlqdddy.Text = mo_mrzj.N_LQDYDD.ToString();
            this.txtlqddds.Text = mo_mrzj.N_LQDSDD.ToString();
            this.txtlqddzdrf.Text = mo_mrzj.N_LQZDRFDD.ToString();
            this.txtlqddzddx.Text = mo_mrzj.N_LQZDDXDD.ToString();
            this.txtlqddbcrf.Text = mo_mrzj.N_LQBCRFDD.ToString();
            this.txtlqddbcdx.Text = mo_mrzj.N_LQBCDXDD.ToString();
            this.txtlqddbcdy.Text = mo_mrzj.N_LQBCDYDD.ToString();
            this.txtlqddbcds.Text = mo_mrzj.N_LQBCDSDD.ToString();
            this.txtlqddgg.Text = mo_mrzj.N_LQGGDD.ToString();
            this.txtlqddgj.Text = mo_mrzj.N_LQGJDD.ToString();
            this.txtlqtydjrf.Text = mo_mrzj.N_LQDJRFTY.ToString();
            this.txtlqtydjdx.Text = mo_mrzj.N_LQDJDXTY.ToString();
            this.txtlqtydjds.Text = mo_mrzj.N_LQDJDSTY.ToString();
            this.txtlqdzdjrf.Text = mo_mrzj.N_LQDJRFDZ.ToString();
            this.txtlqdzdjdx.Text = mo_mrzj.N_LQDJDXDZ.ToString();
            this.txtlqdzdjds.Text = mo_mrzj.N_LQDJDSDZ.ToString();
            this.txtlqdcdjrf.Text = mo_mrzj.N_LQDJRFDC.ToString();
            this.txtlqdcdjdx.Text = mo_mrzj.N_LQDJDXDC.ToString();
            this.txtlqdcdjds.Text = mo_mrzj.N_LQDJDSDC.ToString();
            this.txtlqdddjrf.Text = mo_mrzj.N_LQDJRFDD.ToString();
            this.txtlqdddjdx.Text = mo_mrzj.N_LQDJDXDD.ToString();
            this.txtlqdddjds.Text = mo_mrzj.N_LQDJDSDD.ToString();
            #endregion

            //棒球 
            #region
            this.txtmbtyrf.Text = mo_mrzj.N_MBRFTY.ToString();
            this.txtmbdzrf.Text = mo_mrzj.N_MBRFDZ.ToString();
            this.txtmbdcrf.Text = mo_mrzj.N_MBRFDC.ToString();
            this.txtmbtydx.Text = mo_mrzj.N_MBDXTY.ToString();
            this.txtmbdzdx.Text = mo_mrzj.N_MBDXDZ.ToString();
            this.txtmbdcdx.Text = mo_mrzj.N_MBDXDC.ToString();
            this.txtmbtydy.Text = mo_mrzj.N_MBDYTY.ToString();
            this.txtmbdzdy.Text = mo_mrzj.N_MBDYDZ.ToString();
            this.txtmbdcdy.Text = mo_mrzj.N_MBDYDC.ToString();
            this.txtmbtyds.Text = mo_mrzj.N_MBDSTY.ToString();
            this.txtmbdzds.Text = mo_mrzj.N_MBDSDZ.ToString();
            this.txtmbdcds.Text = mo_mrzj.N_MBDSDC.ToString();
            this.txtmbtyzdrf.Text = mo_mrzj.N_MBZDRFTY.ToString();
            this.txtmbdzzdrf.Text = mo_mrzj.N_MBZDRFDZ.ToString();
            this.txtmbdczdrf.Text = mo_mrzj.N_MBZDRFDC.ToString();
            this.txtmbtyzddx.Text = mo_mrzj.N_MBZDDXTY.ToString();
            this.txtmbdzzddx.Text = mo_mrzj.N_MBZDDXDZ.ToString();
            this.txtmbdczddx.Text = mo_mrzj.N_MBZDDXDC.ToString();
            this.txtmbtysy.Text = mo_mrzj.N_MBSYTY.ToString();
            this.txtmbdzsy.Text = mo_mrzj.N_MBSYDZ.ToString();
            this.txtmbdcsy.Text = mo_mrzj.N_MBSYDC.ToString();
            this.txtmbtygg.Text = mo_mrzj.N_MBGGTY.ToString();
            this.txtmbdzgg.Text = mo_mrzj.N_MBGGDZ.ToString();
            this.txtmbdcgg.Text = mo_mrzj.N_MBGGDC.ToString();
            this.txtmbtybcrf.Text = mo_mrzj.N_MBGJTY.ToString();
            this.txtmbdzbcrf.Text = mo_mrzj.N_MBGJDZ.ToString();
            this.txtmbdcbcrf.Text = mo_mrzj.N_MBGJDC.ToString();
            #endregion


            //冰球
            #region
            this.txtbqtyrf.Text = mo_mrzj.N_BQRFTY.ToString();
            this.txtbqdzrf.Text = mo_mrzj.N_BQRFDZ.ToString();
            this.txtbqdcrf.Text = mo_mrzj.N_BQRFDC.ToString();
            this.txtbqtydx.Text = mo_mrzj.N_BQDXTY.ToString();
            this.txtbqdzdx.Text = mo_mrzj.N_BQDXDZ.ToString();
            this.txtbqdcdx.Text = mo_mrzj.N_BQDXDC.ToString();
            this.txtbqtydy.Text = mo_mrzj.N_BQDYTY.ToString();
            this.txtbqdzdy.Text = mo_mrzj.N_BQDYDZ.ToString();
            this.txtbqdcdy.Text = mo_mrzj.N_BQDYDC.ToString();
            this.txtbqtyds.Text = mo_mrzj.N_BQDSTY.ToString();
            this.txtbqdzds.Text = mo_mrzj.N_BQDSDZ.ToString();
            this.txtbqdcds.Text = mo_mrzj.N_BQDSDC.ToString();
            this.txtbqtyzdrf.Text = mo_mrzj.N_BQZDRFTY.ToString();
            this.txtbqdzzdrf.Text = mo_mrzj.N_BQZDRFDZ.ToString();
            this.txtbqdczdrf.Text = mo_mrzj.N_BQZDRFDC.ToString();
            this.txtbqtyzddx.Text = mo_mrzj.N_BQZDDXTY.ToString();
            this.txtbqdzzddx.Text = mo_mrzj.N_BQZDDXDZ.ToString();
            this.txtbqdczddx.Text = mo_mrzj.N_BQZDDXDC.ToString();
            this.txtbqtysy.Text = mo_mrzj.N_BQSYTY.ToString();
            this.txtbqdzsy.Text = mo_mrzj.N_BQSYDZ.ToString();
            this.txtbqdcsy.Text = mo_mrzj.N_BQSYDC.ToString();
            this.txtbqtygg.Text = mo_mrzj.N_BQGGTY.ToString();
            this.txtbqdzgg.Text = mo_mrzj.N_BQGGDZ.ToString();
            this.txtbqdcgg.Text = mo_mrzj.N_BQGGDC.ToString();
            this.txtbqtybcrf.Text = mo_mrzj.N_BQGJTY.ToString();
            this.txtbqdzbcrf.Text = mo_mrzj.N_BQGJDZ.ToString();
            this.txtbqdcbcrf.Text = mo_mrzj.N_BQGJDC.ToString();
            #endregion

            //网球 
            #region
            this.txtrbtyrf.Text = mo_mrzj.N_RBRFTY.ToString();
            this.txtrbdzrf.Text = mo_mrzj.N_RBRFDZ.ToString();
            this.txtrbdcrf.Text = mo_mrzj.N_RBRFDC.ToString();
            this.txtrbtydx.Text = mo_mrzj.N_RBDXTY.ToString();
            this.txtrbdzdx.Text = mo_mrzj.N_RBDXDZ.ToString();
            this.txtrbdcdx.Text = mo_mrzj.N_RBDXDC.ToString();
            this.txtrbtydy.Text = mo_mrzj.N_RBDYTY.ToString();
            this.txtrbdzdy.Text = mo_mrzj.N_RBDYDZ.ToString();
            this.txtrbdcdy.Text = mo_mrzj.N_RBDYDC.ToString();
            this.txtrbtyds.Text = mo_mrzj.N_RBDSTY.ToString();
            this.txtrbdzds.Text = mo_mrzj.N_RBDSDZ.ToString();
            this.txtrbdcds.Text = mo_mrzj.N_RBDSDC.ToString();
            this.txtrbtyzdrf.Text = mo_mrzj.N_RBZDRFTY.ToString();
            this.txtrbdzzdrf.Text = mo_mrzj.N_RBZDRFDZ.ToString();
            this.txtrbdczdrf.Text = mo_mrzj.N_RBZDRFDC.ToString();
            this.txtrbtyzddx.Text = mo_mrzj.N_RBZDDXTY.ToString();
            this.txtrbdzzddx.Text = mo_mrzj.N_RBZDDXDZ.ToString();
            this.txtrbdczddx.Text = mo_mrzj.N_RBZDDXDC.ToString();
            this.txtrbtysy.Text = mo_mrzj.N_RBSYTY.ToString();
            this.txtrbdzsy.Text = mo_mrzj.N_RBSYDZ.ToString();
            this.txtrbdcsy.Text = mo_mrzj.N_RBSYDC.ToString();
            this.txtrbtygg.Text = mo_mrzj.N_RBGGTY.ToString();
            this.txtrbdzgg.Text = mo_mrzj.N_RBGGDZ.ToString();
            this.txtrbdcgg.Text = mo_mrzj.N_RBGGDC.ToString();
            this.txtrbtybcrf.Text = mo_mrzj.N_RBGJTY.ToString();
            this.txtrbdzbcrf.Text = mo_mrzj.N_RBGJDZ.ToString();
            this.txtrbdcbcrf.Text = mo_mrzj.N_RBGJDC.ToString();
            #endregion
            //排球 
            #region
            this.txttbtyrf.Text = mo_mrzj.N_TBRFTY.ToString();
            this.txttbdzrf.Text = mo_mrzj.N_TBRFDZ.ToString();
            this.txttbdcrf.Text = mo_mrzj.N_TBRFDC.ToString();
            this.txttbtydx.Text = mo_mrzj.N_TBDXTY.ToString();
            this.txttbdzdx.Text = mo_mrzj.N_TBDXDZ.ToString();
            this.txttbdcdx.Text = mo_mrzj.N_TBDXDC.ToString();
            this.txttbtydy.Text = mo_mrzj.N_TBDYTY.ToString();
            this.txttbdzdy.Text = mo_mrzj.N_TBDYDZ.ToString();
            this.txttbdcdy.Text = mo_mrzj.N_TBDYDC.ToString();
            this.txttbtyds.Text = mo_mrzj.N_TBDSTY.ToString();
            this.txttbdzds.Text = mo_mrzj.N_TBDSDZ.ToString();
            this.txttbdcds.Text = mo_mrzj.N_TBDSDC.ToString();
            this.txttbtyzdrf.Text = mo_mrzj.N_TBZDRFTY.ToString();
            this.txttbdzzdrf.Text = mo_mrzj.N_TBZDRFDZ.ToString();
            this.txttbdczdrf.Text = mo_mrzj.N_TBZDRFDC.ToString();
            this.txttbtyzddx.Text = mo_mrzj.N_TBZDDXTY.ToString();
            this.txttbdzzddx.Text = mo_mrzj.N_TBZDDXDZ.ToString();
            this.txttbdczddx.Text = mo_mrzj.N_TBZDDXDC.ToString();
            this.txttbtysy.Text = mo_mrzj.N_TBSYTY.ToString();
            this.txttbdzsy.Text = mo_mrzj.N_TBSYDZ.ToString();
            this.txttbdcsy.Text = mo_mrzj.N_TBSYDC.ToString();
            this.txttbtygg.Text = mo_mrzj.N_TBGGTY.ToString();
            this.txttbdzgg.Text = mo_mrzj.N_TBGGDZ.ToString();
            this.txttbdcgg.Text = mo_mrzj.N_TBGGDC.ToString();
            this.txttbtybcrf.Text = mo_mrzj.N_TBGJTY.ToString();
            this.txttbdzbcrf.Text = mo_mrzj.N_TBGJDZ.ToString();
            this.txttbdcbcrf.Text = mo_mrzj.N_TBGJDC.ToString();
            #endregion


            //足 球 
            #region
            this.txtzqatyrf.Text = mo_mrzj.N_ZQARFTY.ToString();
            this.txtzqbtyrf.Text = mo_mrzj.N_ZQBRFTY.ToString();
            this.txtzqctyrf.Text = mo_mrzj.N_ZQCRFTY.ToString();
            this.txtzqdzrf.Text = mo_mrzj.N_ZQRFDZ.ToString();
            this.txtzqdcrf.Text = mo_mrzj.N_ZQRFDC.ToString();
            this.txtzqatydx.Text = mo_mrzj.N_ZQADXTY.ToString();
            this.txtzqbtydx.Text = mo_mrzj.N_ZQBDXTY.ToString();
            this.txtzqctydx.Text = mo_mrzj.N_ZQCDXTY.ToString();
            this.txtzqdzdx.Text = mo_mrzj.N_ZQDXDZ.ToString();
            this.txtzqdcdx.Text = mo_mrzj.N_ZQDXDC.ToString();
            this.txtzqatydy.Text = mo_mrzj.N_ZQADYTY.ToString();
            this.txtzqbtydy.Text = mo_mrzj.N_ZQBDYTY.ToString();
            this.txtzqctydy.Text = mo_mrzj.N_ZQCDYTY.ToString();
            this.txtzqdzdy.Text = mo_mrzj.N_ZQDYDZ.ToString();
            this.txtzqdcdy.Text = mo_mrzj.N_ZQDYDC.ToString();
            this.txtzqatyds.Text = mo_mrzj.N_ZQADSTY.ToString();
            this.txtzqbtyds.Text = mo_mrzj.N_ZQBDSTY.ToString();
            this.txtzqctyds.Text = mo_mrzj.N_ZQCDSTY.ToString();
            this.txtzqdzds.Text = mo_mrzj.N_ZQDSDZ.ToString();
            this.txtzqdcds.Text = mo_mrzj.N_ZQDSDC.ToString();
            this.txtzqatyzdrf.Text = mo_mrzj.N_ZQAZDRFTY.ToString();
            this.txtzqbtyzdrf.Text = mo_mrzj.N_ZQBZDRFTY.ToString();
            this.txtzqctyzdrf.Text = mo_mrzj.N_ZQCZDRFTY.ToString();
            this.txtzqdzzdrf.Text = mo_mrzj.N_ZQZDRFDZ.ToString();
            this.txtzqdczdrf.Text = mo_mrzj.N_ZQZDRFDC.ToString();
            this.txtzqatyzddx.Text = mo_mrzj.N_ZQAZDDXTY.ToString();
            this.txtzqbtyzddx.Text = mo_mrzj.N_ZQBZDDXTY.ToString();
            this.txtzqctyzddx.Text = mo_mrzj.N_ZQCZDDXTY.ToString();
            this.txtzqdzzddx.Text = mo_mrzj.N_ZQZDDXDZ.ToString();
            this.txtzqdczddx.Text = mo_mrzj.N_ZQZDDXDC.ToString();
            this.txtzqatybcrf.Text = mo_mrzj.N_ZQABCRFTY.ToString();
            this.txtzqbtybcrf.Text = mo_mrzj.N_ZQBBCRFTY.ToString();
            this.txtzqctybcrf.Text = mo_mrzj.N_ZQCBCRFTY.ToString();
            this.txtzqdzbcrf.Text = mo_mrzj.N_ZQBCRFDZ.ToString();
            this.txtzqdcbcrf.Text = mo_mrzj.N_ZQBCRFDC.ToString();
            this.txtzqatybcdx.Text = mo_mrzj.N_ZQABCDXTY.ToString();
            this.txtzqbtybcdx.Text = mo_mrzj.N_ZQBBCDXTY.ToString();
            this.txtzqctybcdx.Text = mo_mrzj.N_ZQCBCDXTY.ToString();
            this.txtzqdzbcdx.Text = mo_mrzj.N_ZQBCDXDZ.ToString();
            this.txtzqdcbcdx.Text = mo_mrzj.N_ZQBCDXDC.ToString();
            this.txtzqatybcdy.Text = mo_mrzj.N_ZQABCDYTY.ToString();
            this.txtzqbtybcdy.Text = mo_mrzj.N_ZQBBCDYTY.ToString();
            this.txtzqctybcdy.Text = mo_mrzj.N_ZQCBCDYTY.ToString();
            this.txtzqdzbcdy.Text = mo_mrzj.N_ZQBCDYDZ.ToString();
            this.txtzqdcbcdy.Text = mo_mrzj.N_ZQBCDYDC.ToString();
            this.txtzqatyrqs.Text = mo_mrzj.N_ZQARQSTY.ToString();
            this.txtzqbtyrqs.Text = mo_mrzj.N_ZQBRQSTY.ToString();
            this.txtzqctyrqs.Text = mo_mrzj.N_ZQCRQSTY.ToString();
            this.txtzqdzrqs.Text = mo_mrzj.N_ZQRQSDZ.ToString();
            this.txtzqdcrqs.Text = mo_mrzj.N_ZQRQSDC.ToString();
            this.txtzqatybd.Text = mo_mrzj.N_ZQABDTY.ToString();
            this.txtzqbtybd.Text = mo_mrzj.N_ZQBBDTY.ToString();
            this.txtzqctybd.Text = mo_mrzj.N_ZQCBDTY.ToString();
            this.txtzqdzbd.Text = mo_mrzj.N_ZQBDDZ.ToString();
            this.txtzqdcbd.Text = mo_mrzj.N_ZQBDDC.ToString();
            this.txtzqatybqc.Text = mo_mrzj.N_ZQABQCTY.ToString();
            this.txtzqbtybqc.Text = mo_mrzj.N_ZQBBQCTY.ToString();
            this.txtzqctybqc.Text = mo_mrzj.N_ZQCBQCTY.ToString();
            this.txtzqdzbqc.Text = mo_mrzj.N_ZQBQCDZ.ToString();
            this.txtzqdcbqc.Text = mo_mrzj.N_ZQBQCDC.ToString();
            this.txtzqatygg.Text = mo_mrzj.N_ZQAGGTY.ToString();
            this.txtzqbtygg.Text = mo_mrzj.N_ZQBGGTY.ToString();
            this.txtzqctygg.Text = mo_mrzj.N_ZQCGGTY.ToString();
            this.txtzqdzgg.Text = mo_mrzj.N_ZQGGDZ.ToString();
            this.txtzqdcgg.Text = mo_mrzj.N_ZQGGDC.ToString();
            this.txtzqatygj.Text = mo_mrzj.N_ZQAGJTY.ToString();
            this.txtzqbtygj.Text = mo_mrzj.N_ZQBGJTY.ToString();
            this.txtzqctygj.Text = mo_mrzj.N_ZQCGJTY.ToString();
            this.txtzqdzgj.Text = mo_mrzj.N_ZQGJDZ.ToString();
            this.txtzqdcgj.Text = mo_mrzj.N_ZQGJDC.ToString();
            #endregion
            //美足
            #region
            this.txtmztyrf.Text = mo_mrzj.N_MZRFTY.ToString();
            this.txtmzdzrf.Text = mo_mrzj.N_MZRFDZ.ToString();
            this.txtmzdcrf.Text = mo_mrzj.N_MZRFDC.ToString();
            this.txtmztydx.Text = mo_mrzj.N_MZDXTY.ToString();
            this.txtmzdzdx.Text = mo_mrzj.N_MZDXDZ.ToString();
            this.txtmzdcdx.Text = mo_mrzj.N_MZDXDC.ToString();
            this.txtmztydy.Text = mo_mrzj.N_MZDYTY.ToString();
            this.txtmzdzdy.Text = mo_mrzj.N_MZDYDZ.ToString();
            this.txtmzdcdy.Text = mo_mrzj.N_MZDYDC.ToString();
            this.txtmztyds.Text = mo_mrzj.N_MZDSTY.ToString();
            this.txtmzdzds.Text = mo_mrzj.N_MZDSDZ.ToString();
            this.txtmzdcds.Text = mo_mrzj.N_MZDSDC.ToString();
            this.txtmztyzdrf.Text = mo_mrzj.N_MZZDRFTY.ToString();
            this.txtmzdzzdrf.Text = mo_mrzj.N_MZZDRFDZ.ToString();
            this.txtmzdczdrf.Text = mo_mrzj.N_MZZDRFDC.ToString();
            this.txtmztyzddx.Text = mo_mrzj.N_MZZDDXTY.ToString();
            this.txtmzdzzddx.Text = mo_mrzj.N_MZZDDXDZ.ToString();
            this.txtmzdczddx.Text = mo_mrzj.N_MZZDDXDC.ToString();
            this.txtmztybcrf.Text = mo_mrzj.N_MZBCRFTY.ToString();
            this.txtmzdzbcrf.Text = mo_mrzj.N_MZBCRFDZ.ToString();
            this.txtmzdcbcrf.Text = mo_mrzj.N_MZBCRFDC.ToString();
            this.txtmztybcdx.Text = mo_mrzj.N_MZBCDXTY.ToString();
            this.txtmzdzbcdx.Text = mo_mrzj.N_MZBCDXDZ.ToString();
            this.txtmzdcbcdx.Text = mo_mrzj.N_MZBCDXDC.ToString();
            this.txtmztybcdy.Text = mo_mrzj.N_MZBCDYTY.ToString();
            this.txtmzdzbcdy.Text = mo_mrzj.N_MZBCDYDZ.ToString();
            this.txtmzdcbcdy.Text = mo_mrzj.N_MZBCDYDC.ToString();
            this.txtmztybcds.Text = mo_mrzj.N_MZBCDSTY.ToString();
            this.txtmzdzbcds.Text = mo_mrzj.N_MZBCDSDZ.ToString();
            this.txtmzdcbcds.Text = mo_mrzj.N_MZBCDSDC.ToString();
            this.txtmztygg.Text = mo_mrzj.N_MZGGTY.ToString();
            this.txtmzdzgg.Text = mo_mrzj.N_MZGGDZ.ToString();
            this.txtmzdcgg.Text = mo_mrzj.N_MZGGDC.ToString();
            this.txtmztygj.Text = mo_mrzj.N_MZGJTY.ToString();
            this.txtmzdzgj.Text = mo_mrzj.N_MZGJDZ.ToString();
            this.txtmzdcgj.Text = mo_mrzj.N_MZGJDC.ToString();
            #endregion

            //彩球
            #region
            this.txtcqtyrf.Text = mo_mrzj.N_CQRFTY.ToString();
            this.txtcqdzrf.Text = mo_mrzj.N_CQRFDZ.ToString();
            this.txtcqdcrf.Text = mo_mrzj.N_CQRFDC.ToString();
            this.txtcqtydx.Text = mo_mrzj.N_CQDXTY.ToString();
            this.txtcqdzdx.Text = mo_mrzj.N_CQDXDZ.ToString();
            this.txtcqdcdx.Text = mo_mrzj.N_CQDXDC.ToString();
            this.txtcqtydy.Text = mo_mrzj.N_CQDYTY.ToString();
            this.txtcqdzdy.Text = mo_mrzj.N_CQDYDZ.ToString();
            this.txtcqdcdy.Text = mo_mrzj.N_CQDYDC.ToString();
            this.txtcqtyds.Text = mo_mrzj.N_CQDSTY.ToString();
            this.txtcqdzds.Text = mo_mrzj.N_CQDSDZ.ToString();
            this.txtcqdcds.Text = mo_mrzj.N_CQDSDC.ToString();
            this.txtcqtyzdrf.Text = mo_mrzj.N_CQZDRFTY.ToString();
            this.txtcqdzzdrf.Text = mo_mrzj.N_CQZDRFDZ.ToString();
            this.txtcqdczdrf.Text = mo_mrzj.N_CQZDRFDC.ToString();
            this.txtcqtyzddx.Text = mo_mrzj.N_CQZDDXTY.ToString();
            this.txtcqdzzddx.Text = mo_mrzj.N_CQZDDXDZ.ToString();
            this.txtcqdczddx.Text = mo_mrzj.N_CQZDDXDC.ToString();
            this.txtcqtybcrf.Text = mo_mrzj.N_CQBCRFTY.ToString();
            this.txtcqdzbcrf.Text = mo_mrzj.N_CQBCRFDZ.ToString();
            this.txtcqdcbcrf.Text = mo_mrzj.N_CQBCRFDC.ToString();
            this.txtcqtybcdx.Text = mo_mrzj.N_CQBCDXTY.ToString();
            this.txtcqdzbcdx.Text = mo_mrzj.N_CQBCDXDZ.ToString();
            this.txtcqdcbcdx.Text = mo_mrzj.N_CQBCDXDC.ToString();
            this.txtcqtybcdy.Text = mo_mrzj.N_CQBCDYTY.ToString();
            this.txtcqdzbcdy.Text = mo_mrzj.N_CQBCDYDZ.ToString();
            this.txtcqdcbcdy.Text = mo_mrzj.N_CQBCDYDC.ToString();
            this.txtcqtybcds.Text = mo_mrzj.N_CQBCDSTY.ToString();
            this.txtcqdzbcds.Text = mo_mrzj.N_CQBCDSDZ.ToString();
            this.txtcqdcbcds.Text = mo_mrzj.N_CQBCDSDC.ToString();
            this.txtcqtygg.Text = mo_mrzj.N_CQGGTY.ToString();
            this.txtcqdzgg.Text = mo_mrzj.N_CQGGDZ.ToString();
            this.txtcqdcgg.Text = mo_mrzj.N_CQGGDC.ToString();
            this.txtcqtygj.Text = mo_mrzj.N_CQGJTY.ToString();
            this.txtcqdzgj.Text = mo_mrzj.N_CQGJDZ.ToString();
            this.txtcqdcgj.Text = mo_mrzj.N_CQGJDC.ToString();
            #endregion

            //指数
            #region
            this.txtzstyrf.Text = mo_mrzj.N_ZSRFTY.ToString();
            this.txtzsdzrf.Text = mo_mrzj.N_ZSRFDZ.ToString();
            this.txtzsdcrf.Text = mo_mrzj.N_ZSRFDC.ToString();
            this.txtzstydx.Text = mo_mrzj.N_ZSDXTY.ToString();
            this.txtzsdzdx.Text = mo_mrzj.N_ZSDXDZ.ToString();
            this.txtzsdcdx.Text = mo_mrzj.N_ZSDXDC.ToString();
            this.txtzstydy.Text = mo_mrzj.N_ZSDYTY.ToString();
            this.txtzsdzdy.Text = mo_mrzj.N_ZSDYDZ.ToString();
            this.txtzsdcdy.Text = mo_mrzj.N_ZSDYDC.ToString();
            this.txtzstyds.Text = mo_mrzj.N_ZSDSTY.ToString();
            this.txtzsdzds.Text = mo_mrzj.N_ZSDSDZ.ToString();
            this.txtzsdcds.Text = mo_mrzj.N_ZSDSDC.ToString();
            this.txtzstyzdrf.Text = mo_mrzj.N_ZSZDRFTY.ToString();
            this.txtzsdzzdrf.Text = mo_mrzj.N_ZSZDRFDZ.ToString();
            this.txtzsdczdrf.Text = mo_mrzj.N_ZSZDRFDC.ToString();
            this.txtzstyzddx.Text = mo_mrzj.N_ZSZDDXTY.ToString();
            this.txtzsdzzddx.Text = mo_mrzj.N_ZSZDDXDZ.ToString();
            this.txtzsdczddx.Text = mo_mrzj.N_ZSZDDXDC.ToString();
            this.txtzstysy.Text = mo_mrzj.N_ZSSYTY.ToString();
            this.txtzsdzsy.Text = mo_mrzj.N_ZSSYDZ.ToString();
            this.txtzsdcsy.Text = mo_mrzj.N_ZSSYDC.ToString();
            this.txtzstybd.Text = mo_mrzj.N_ZSBDTY.ToString();
            this.txtzsdzbd.Text = mo_mrzj.N_ZBDDZ.ToString();
            this.txtzsdcbd.Text = mo_mrzj.N_ZSBDDC.ToString();
            this.txtzstygg.Text = mo_mrzj.N_ZSGGTY.ToString();
            this.txtzsdzgg.Text = mo_mrzj.N_ZSGGDZ.ToString();
            this.txtzsdcgg.Text = mo_mrzj.N_ZSGGDC.ToString();
            this.txtzstygj.Text = mo_mrzj.N_ZSGJTY.ToString();
            this.txtzsdzgj.Text = mo_mrzj.N_ZSGJDZ.ToString();
            this.txtzsdcgj.Text = mo_mrzj.N_ZSGJDC.ToString();
            #endregion
            //赛马
            #region
            this.txtsmtydy.Text = mo_mrzj.N_SMTYDY.ToString();
            this.txtsmdzdy.Text = mo_mrzj.N_SMDZDY.ToString();
            this.txtsmdcdy.Text = mo_mrzj.N_SMDCDY.ToString();
            this.txtsmtywz.Text = mo_mrzj.N_SMTYWZ.ToString();
            this.txtsmdzwz.Text = mo_mrzj.N_SMDZWZ.ToString();
            this.txtsmdcwz.Text = mo_mrzj.N_SMDCWZ.ToString();
            this.txtsmtyly.Text = mo_mrzj.N_SMTYLY.ToString();
            this.txtsmdzly.Text = mo_mrzj.N_SMDZLY.ToString();
            this.txtsmdcly.Text = mo_mrzj.N_SMDCLY.ToString();
            this.txtsmtywzq.Text = mo_mrzj.N_SMTYWZQ.ToString();
            this.txtsmdzwzq.Text = mo_mrzj.N_SMDZWZQ.ToString();
            this.txtsmdcwzq.Text = mo_mrzj.N_SMDCWZQ.ToString();
            #endregion
            //六合彩
            #region
            this.txtlhctytbh.Text = mo_mrzj.N_LHCTYTBH.ToString();
            this.txtlhcdztbh.Text = mo_mrzj.N_LHCDZTBH.ToString();
            this.txtlhcdctbh.Text = mo_mrzj.N_LHCDCTBH.ToString();
            this.txtlhctytt.Text = mo_mrzj.N_LHCTYTT.ToString();
            this.txtlhcdztt.Text = mo_mrzj.N_LHCDZTT.ToString();
            this.txtlhcdctt.Text = mo_mrzj.N_LHCDCTT.ToString();
            this.txtlhctyth.Text = mo_mrzj.N_LHCTYTH.ToString();
            this.txtlhcdzth.Text = mo_mrzj.N_LHCDZTH.ToString();
            this.txtlhcdcth.Text = mo_mrzj.N_LHCDCTH.ToString();
            this.txtlhctyqcp.Text = mo_mrzj.N_LHCTYQCP.ToString();
            this.txtlhcdzqcp.Text = mo_mrzj.N_LHCDZQCP.ToString();
            this.txtlhcdcqcp.Text = mo_mrzj.N_LHCDCQCP.ToString();
            this.txtlhcty2x.Text = mo_mrzj.N_LHCTY2X.ToString();
            this.txtlhcdz2x.Text = mo_mrzj.N_LHCDZ2X.ToString();
            this.txtlhcdc2x.Text = mo_mrzj.N_LHCDC2X.ToString();
            this.txtlhcty3x.Text = mo_mrzj.N_LHCTY3X.ToString();
            this.txtlhcdz3x.Text = mo_mrzj.N_LHCDZ3X.ToString();
            this.txtlhcdc3x.Text = mo_mrzj.N_LHCDC3X.ToString();
            this.txtlhcty4x.Text = mo_mrzj.N_LHCTY4X.ToString();
            this.txtlhcdz4x.Text = mo_mrzj.N_LHCDZ4X.ToString();
            this.txtlhcdc4x.Text = mo_mrzj.N_LHCDC4X.ToString();
            this.txtlhctygds.Text = mo_mrzj.N_LHCTYGDDS.ToString();
            this.txtlhcdzgds.Text = mo_mrzj.N_LHCDZGDDS.ToString();
            this.txtlhcdcgds.Text = mo_mrzj.N_LHCDCGDDS.ToString();
            this.txtlhctygdx.Text = mo_mrzj.N_LHCTYGDDX.ToString();
            this.txtlhcdzgdx.Text = mo_mrzj.N_LHCDZGDDX.ToString();
            this.txtlhcdcgdx.Text = mo_mrzj.N_LHCDCGDDX.ToString();
            #endregion
            //大乐透
            #region
            this.txtdlttytbh.Text = mo_mrzj.N_DLTTYTBH.ToString();
            this.txtdltdztbh.Text = mo_mrzj.N_DLTDZTBH.ToString();
            this.txtdltdctbh.Text = mo_mrzj.N_DLTDCTBH.ToString();
            this.txtdlttytt.Text = mo_mrzj.N_DLTTYTT.ToString();
            this.txtdltdztt.Text = mo_mrzj.N_DLTDZTT.ToString();
            this.txtdltdctt.Text = mo_mrzj.N_DLTDCTT.ToString();
            this.txtdlttyth.Text = mo_mrzj.N_DLTTYTH.ToString();
            this.txtdltdzth.Text = mo_mrzj.N_DLTDZTH.ToString();
            this.txtdltdcth.Text = mo_mrzj.N_DLTDCTH.ToString();
            this.txtdlttyqcp.Text = mo_mrzj.N_DLTTYQCP.ToString();
            this.txtdltdzqcp.Text = mo_mrzj.N_DLTDZQCP.ToString();
            this.txtdltdcqcp.Text = mo_mrzj.N_DLTDCQCP.ToString();
            this.txtdltty2x.Text = mo_mrzj.N_DLTTY2X.ToString();
            this.txtdltdz2x.Text = mo_mrzj.N_DLTDZ2X.ToString();
            this.txtdltdc2x.Text = mo_mrzj.N_DLTDC2X.ToString();
            this.txtdltty3x.Text = mo_mrzj.N_DLTTY3X.ToString();
            this.txtdltdz3x.Text = mo_mrzj.N_DLTDZ3X.ToString();
            this.txtdltdc3x.Text = mo_mrzj.N_DLTDC3X.ToString();
            this.txtdltty4x.Text = mo_mrzj.N_DLTTY4X.ToString();
            this.txtdltdz4x.Text = mo_mrzj.N_DLTDZ4X.ToString();
            this.txtdltdc4x.Text = mo_mrzj.N_DLTDC4X.ToString();
            this.txtdlttygds.Text = mo_mrzj.N_DLTTYGDDS.ToString();
            this.txtdltdzgds.Text = mo_mrzj.N_DLTDZGDDS.ToString();
            this.txtdltdcgds.Text = mo_mrzj.N_DLTDCGDDS.ToString();
            this.txtdlttygdx.Text = mo_mrzj.N_DLTTYGDDX.ToString();
            this.txtdltdzgdx.Text = mo_mrzj.N_DLTDZGDDX.ToString();
            this.txtdltdcgdx.Text = mo_mrzj.N_DLTDCGDDX.ToString();
            #endregion
            //大乐透
            #region
            this.txtjc539tyqcp.Text = mo_mrzj.N_JC539TYQCP.ToString();
            this.txtjc539dzqcp.Text = mo_mrzj.N_JC539DZQCP.ToString();
            this.txtjc539dcqcp.Text = mo_mrzj.N_JC539DCQCP.ToString();
            this.txtjc539ty2x.Text = mo_mrzj.N_JC539TY2X.ToString();
            this.txtjc539dz2x.Text = mo_mrzj.N_JC539DZ2X.ToString();
            this.txtjc539dc2x.Text = mo_mrzj.N_JC539DC2X.ToString();
            this.txtjc539ty3x.Text = mo_mrzj.N_JC539TY3X.ToString();
            this.txtjc539dz3x.Text = mo_mrzj.N_JC539DZ3X.ToString();
            this.txtjc539dc3x.Text = mo_mrzj.N_JC539DC3X.ToString();
            this.txtjc539ty4x.Text = mo_mrzj.N_JC539TY4X.ToString();
            this.txtjc539dz4x.Text = mo_mrzj.N_JC539DZ4X.ToString();
            this.txtjc539dc4x.Text = mo_mrzj.N_JC539DC4X.ToString();
            #endregion
            //运动彩票
            #region
            this.txtbqcpty.Text = mo_mrzj.N_CPTYBQ.ToString();
            this.txtbqcpdz.Text = mo_mrzj.N_CPDZBQ.ToString();
            this.txtbqcpdc.Text = mo_mrzj.N_CPDCBQ.ToString();
            this.txtlqcpty.Text = mo_mrzj.N_CPTYLQ.ToString();
            this.txtlqcpdz.Text = mo_mrzj.N_CPDZLQ.ToString();
            this.txtlqcpdc.Text = mo_mrzj.N_CPDCLQ.ToString();
            this.txtzqcpty.Text = mo_mrzj.N_CPTYZQ.ToString();
            this.txtzqcpdz.Text = mo_mrzj.N_CPDZZQ.ToString();
            this.txtzqcpdc.Text = mo_mrzj.N_CPDCZQ.ToString();
            this.txtgscpty.Text = mo_mrzj.N_CPTYGS.ToString();
            this.txtgscpdz.Text = mo_mrzj.N_CPDZGS.ToString();
            this.txtgscpdc.Text = mo_mrzj.N_CPDCGS.ToString();
            this.txtzscpty.Text = mo_mrzj.N_CPTYQZ.ToString();
            this.txtzscpdz.Text = mo_mrzj.N_CPDZQZ.ToString();
            this.txtzscpdc.Text = mo_mrzj.N_CPDCQZ.ToString();
            #endregion
            //時事
            #region
            this.txtsstydy.Text = mo_mrzj.N_SSTYDY.ToString();
            this.txtssdzdy.Text = mo_mrzj.N_SSDZDY.ToString();
            this.txtssdcdy.Text = mo_mrzj.N_SSDCDY.ToString();
            #endregion
        }

        #endregion
        #region"各級赋值"
        public void HYFZ()
        {

            AgentManageDB objAgentManageDB = new AgentManageDB();
            AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
            KFB_ZHGL mo_zhgl = objAgentManageDB.GetModel(strparid);
            //拆帐赋值
            this.txtlq.Text = mo_zhgl.N_LQCZ.ToString();
            this.txtmb.Text = mo_zhgl.N_MBCZ.ToString();
            this.txtrb.Text = mo_zhgl.N_RBCZ.ToString();
            this.txttb.Text = mo_zhgl.N_TBCZ.ToString();
            this.txtmz.Text = mo_zhgl.N_MZCZ.ToString();
            this.txtzq.Text = mo_zhgl.N_ZQCZ.ToString();
            this.txtzs.Text = mo_zhgl.N_ZSCZ.ToString();
            this.txtdlt.Text = mo_zhgl.N_DLTCZ.ToString();
            this.txtsm.Text = mo_zhgl.N_SMCZ.ToString();
            this.txtlhc.Text = mo_zhgl.N_LHCCZ.ToString();
            this.txt2x.Text = mo_zhgl.N_2XCZ.ToString();
            this.txt3x.Text = mo_zhgl.N_3XCZ.ToString();
            this.txt4x.Text = mo_zhgl.N_4XCZ.ToString();
            this.txtjc539.Text = mo_zhgl.N_JCCZ.ToString();
            this.txtcp.Text = mo_zhgl.N_CPCZ.ToString();
            this.txtss.Text = mo_zhgl.N_SSCZ.ToString();
            this.txtddsx.Text = mo_zhgl.N_DDSX.ToString();
            this.txtddsx.Attributes.Add("onblur", "chxyed(this,'1','" + mo_zhgl.N_DDSX.ToString() + "','0')");


            this.txtbq.Text = mo_zhgl.N_BQCZ.ToString();
            this.txtcq.Text = mo_zhgl.N_CQCZ.ToString();
            //取得 已開出的額度
            //string stryked = o_zhgl.GetED(strparid, strlvl);
            //this.hidje.Value = Convert.ToString(Convert.ToDecimal(mo_zhgl.N_KYED) - Convert.ToDecimal(stryked));
            this.hidje.Value = mo_zhgl.N_SYED.ToString();


            KFB_SETUPLQ mo_lq = objAgentManageAddDB.GetModelLQ(strparid);

            //篮球 
            #region
            this.txtlqtyrf.Text = mo_lq.N_RFTY.ToString();
            this.txtlqdzrf.Text = mo_lq.N_RFDZ.ToString();
            this.txtlqdcrf.Text = mo_lq.N_RFDC.ToString();
            this.txtlqtydx.Text = mo_lq.N_DXTY.ToString();
            this.txtlqdzdx.Text = mo_lq.N_DXDZ.ToString();
            this.txtlqdcdx.Text = mo_lq.N_DXDC.ToString();
            this.txtlqtydy.Text = mo_lq.N_DYTY.ToString();
            this.txtlqdzdy.Text = mo_lq.N_DYDZ.ToString();
            this.txtlqdcdy.Text = mo_lq.N_DYDC.ToString();
            this.txtlqtyds.Text = mo_lq.N_DSTY.ToString();
            this.txtlqdzds.Text = mo_lq.N_DSDZ.ToString();
            this.txtlqdcds.Text = mo_lq.N_DSDC.ToString();
            this.txtlqtyzdrf.Text = mo_lq.N_ZDRFTY.ToString();
            this.txtlqdzzdrf.Text = mo_lq.N_ZDRFDZ.ToString();
            this.txtlqdczdrf.Text = mo_lq.N_ZDRFDC.ToString();
            this.txtlqtyzddx.Text = mo_lq.N_ZDDXTY.ToString();
            this.txtlqdzzddx.Text = mo_lq.N_ZDDXDZ.ToString();
            this.txtlqdczddx.Text = mo_lq.N_ZDDXDC.ToString();
            this.txtlqtybcrf.Text = mo_lq.N_BCRFTY.ToString();
            this.txtlqdzbcrf.Text = mo_lq.N_BCRFDZ.ToString();
            this.txtlqdcbcrf.Text = mo_lq.N_BCRFDC.ToString();
            this.txtlqtybcdx.Text = mo_lq.N_BCDXTY.ToString();
            this.txtlqdzbcdx.Text = mo_lq.N_BCDXDZ.ToString();
            this.txtlqdcbcdx.Text = mo_lq.N_BCDXDC.ToString();
            this.txtlqtybcdy.Text = mo_lq.N_BCDYTY.ToString();
            this.txtlqdzbcdy.Text = mo_lq.N_BCDYDZ.ToString();
            this.txtlqdcbcdy.Text = mo_lq.N_BCDYDC.ToString();
            this.txtlqtybcds.Text = mo_lq.N_BCDSTY.ToString();
            this.txtlqdzbcds.Text = mo_lq.N_BCDSDZ.ToString();
            this.txtlqdcbcds.Text = mo_lq.N_BCDSDC.ToString();
            this.txtlqtygg.Text = mo_lq.N_GGTY.ToString();
            this.txtlqdzgg.Text = mo_lq.N_GGDZ.ToString();
            this.txtlqdcgg.Text = mo_lq.N_GGDC.ToString();
            this.txtlqtygj.Text = mo_lq.N_GJTY.ToString();
            this.txtlqdzgj.Text = mo_lq.N_GJDZ.ToString();
            this.txtlqdcgj.Text = mo_lq.N_GJDC.ToString();

            this.txtlqddrf.Text = mo_lq.N_RFDD.ToString();
            this.txtlqdddx.Text = mo_lq.N_DXDD.ToString();
            this.txtlqdddy.Text = mo_lq.N_DYDD.ToString();
            this.txtlqddds.Text = mo_lq.N_DSDD.ToString();
            this.txtlqddzdrf.Text = mo_lq.N_ZDRFDD.ToString();
            this.txtlqddzddx.Text = mo_lq.N_ZDDXDD.ToString();
            this.txtlqddbcrf.Text = mo_lq.N_BCRFDD.ToString();
            this.txtlqddbcdx.Text = mo_lq.N_BCDXDD.ToString();
            this.txtlqddbcdy.Text = mo_lq.N_BCDYDD.ToString();
            this.txtlqddbcds.Text = mo_lq.N_BCDSDD.ToString();
            this.txtlqddgg.Text = mo_lq.N_GGDD.ToString();
            this.txtlqddgj.Text = mo_lq.N_GJDD.ToString();
            this.txtlqtydjrf.Text = mo_lq.N_DJRFTY.ToString();
            this.txtlqtydjdx.Text = mo_lq.N_DJDXTY.ToString();
            this.txtlqtydjds.Text = mo_lq.N_DJDSTY.ToString();
            this.txtlqdzdjrf.Text = mo_lq.N_DJRFDZ.ToString();
            this.txtlqdzdjdx.Text = mo_lq.N_DJDXDZ.ToString();
            this.txtlqdzdjds.Text = mo_lq.N_DJDSDZ.ToString();
            this.txtlqdcdjrf.Text = mo_lq.N_DJRFDC.ToString();
            this.txtlqdcdjdx.Text = mo_lq.N_DJDXDC.ToString();
            this.txtlqdcdjds.Text = mo_lq.N_DJDSDC.ToString();
            this.txtlqdddjrf.Text = mo_lq.N_DJRFDD.ToString();
            this.txtlqdddjdx.Text = mo_lq.N_DJDXDD.ToString();
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
            this.txtzqatyrf.Text = mo_ZQ.N_ARFTY.ToString();
            this.txtzqbtyrf.Text = mo_ZQ.N_BRFTY.ToString();
            this.txtzqctyrf.Text = mo_ZQ.N_CRFTY.ToString();
            this.txtzqdzrf.Text = mo_ZQ.N_RFDZ.ToString();
            this.txtzqdcrf.Text = mo_ZQ.N_RFDC.ToString();
            this.txtzqatydx.Text = mo_ZQ.N_ADXTY.ToString();
            this.txtzqbtydx.Text = mo_ZQ.N_BDXTY.ToString();
            this.txtzqctydx.Text = mo_ZQ.N_CDXTY.ToString();
            this.txtzqdzdx.Text = mo_ZQ.N_DXDZ.ToString();
            this.txtzqdcdx.Text = mo_ZQ.N_DXDC.ToString();
            this.txtzqatydy.Text = mo_ZQ.N_ADYTY.ToString();
            this.txtzqbtydy.Text = mo_ZQ.N_BDYTY.ToString();
            this.txtzqctydy.Text = mo_ZQ.N_CDYTY.ToString();
            this.txtzqdzdy.Text = mo_ZQ.N_DYDZ.ToString();
            this.txtzqdcdy.Text = mo_ZQ.N_DYDC.ToString();
            this.txtzqatyds.Text = mo_ZQ.N_ADSTY.ToString();
            this.txtzqbtyds.Text = mo_ZQ.N_BDSTY.ToString();
            this.txtzqctyds.Text = mo_ZQ.N_CDSTY.ToString();
            this.txtzqdzds.Text = mo_ZQ.N_DSDZ.ToString();
            this.txtzqdcds.Text = mo_ZQ.N_DSDC.ToString();
            this.txtzqatyzdrf.Text = mo_ZQ.N_AZDRFTY.ToString();
            this.txtzqbtyzdrf.Text = mo_ZQ.N_BZDRFTY.ToString();
            this.txtzqctyzdrf.Text = mo_ZQ.N_CZDRFTY.ToString();
            this.txtzqdzzdrf.Text = mo_ZQ.N_ZDRFDZ.ToString();
            this.txtzqdczdrf.Text = mo_ZQ.N_ZDRFDC.ToString();
            this.txtzqatyzddx.Text = mo_ZQ.N_AZDDXTY.ToString();
            this.txtzqbtyzddx.Text = mo_ZQ.N_BZDDXTY.ToString();
            this.txtzqctyzddx.Text = mo_ZQ.N_CZDDXTY.ToString();
            this.txtzqdzzddx.Text = mo_ZQ.N_ZDDXDZ.ToString();
            this.txtzqdczddx.Text = mo_ZQ.N_ZDDXDC.ToString();
            this.txtzqatybcrf.Text = mo_ZQ.N_ABCRFTY.ToString();
            this.txtzqbtybcrf.Text = mo_ZQ.N_BBCRFTY.ToString();
            this.txtzqctybcrf.Text = mo_ZQ.N_CBCRFTY.ToString();
            this.txtzqdzbcrf.Text = mo_ZQ.N_BCRFDZ.ToString();
            this.txtzqdcbcrf.Text = mo_ZQ.N_BCRFDC.ToString();
            this.txtzqatybcdx.Text = mo_ZQ.N_ABCDXTY.ToString();
            this.txtzqbtybcdx.Text = mo_ZQ.N_BBCDXTY.ToString();
            this.txtzqctybcdx.Text = mo_ZQ.N_CBCDXTY.ToString();
            this.txtzqdzbcdx.Text = mo_ZQ.N_BCDXDZ.ToString();
            this.txtzqdcbcdx.Text = mo_ZQ.N_BCDXDC.ToString();
            this.txtzqatybcdy.Text = mo_ZQ.N_ABCDYTY.ToString();
            this.txtzqbtybcdy.Text = mo_ZQ.N_BBCDYTY.ToString();
            this.txtzqctybcdy.Text = mo_ZQ.N_CBCDYTY.ToString();
            this.txtzqdzbcdy.Text = mo_ZQ.N_BCDYDZ.ToString();
            this.txtzqdcbcdy.Text = mo_ZQ.N_BCDYDC.ToString();
            this.txtzqatyrqs.Text = mo_ZQ.N_ARQSTY.ToString();
            this.txtzqbtyrqs.Text = mo_ZQ.N_BRQSTY.ToString();
            this.txtzqctyrqs.Text = mo_ZQ.N_CRQSTY.ToString();
            this.txtzqdzrqs.Text = mo_ZQ.N_RQSDZ.ToString();
            this.txtzqdcrqs.Text = mo_ZQ.N_RQSDC.ToString();
            this.txtzqatybd.Text = mo_ZQ.N_ABDTY.ToString();
            this.txtzqbtybd.Text = mo_ZQ.N_BBDTY.ToString();
            this.txtzqctybd.Text = mo_ZQ.N_CBDTY.ToString();
            this.txtzqdzbd.Text = mo_ZQ.N_BDDZ.ToString();
            this.txtzqdcbd.Text = mo_ZQ.N_BDDC.ToString();
            this.txtzqatybqc.Text = mo_ZQ.N_ABQCTY.ToString();
            this.txtzqbtybqc.Text = mo_ZQ.N_BBQCTY.ToString();
            this.txtzqctybqc.Text = mo_ZQ.N_CBQCTY.ToString();
            this.txtzqdzbqc.Text = mo_ZQ.N_BQCDZ.ToString();
            this.txtzqdcbqc.Text = mo_ZQ.N_BQCDC.ToString();
            this.txtzqatygg.Text = mo_ZQ.N_AGGTY.ToString();
            this.txtzqbtygg.Text = mo_ZQ.N_BGGTY.ToString();
            this.txtzqctygg.Text = mo_ZQ.N_CGGTY.ToString();
            this.txtzqdzgg.Text = mo_ZQ.N_GGDZ.ToString();
            this.txtzqdcgg.Text = mo_ZQ.N_GGDC.ToString();
            this.txtzqatygj.Text = mo_ZQ.N_AGJTY.ToString();
            this.txtzqbtygj.Text = mo_ZQ.N_BGJTY.ToString();
            this.txtzqctygj.Text = mo_ZQ.N_CGJTY.ToString();
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
            this.txtlhctygds.Text = mo_LHC.N_GDDSTY.ToString();
            this.txtlhcdzgds.Text = mo_LHC.N_GDDSDZ.ToString();
            this.txtlhcdcgds.Text = mo_LHC.N_GDDSDC.ToString();
            this.txtlhctygdx.Text = mo_LHC.N_GDDXTY.ToString();
            this.txtlhcdzgdx.Text = mo_LHC.N_GDDXDZ.ToString();
            this.txtlhcdcgdx.Text = mo_LHC.N_GDDXDC.ToString();
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
            this.txtdlttygds.Text = mo_DLT.N_GDDSTY.ToString();
            this.txtdltdzgds.Text = mo_DLT.N_GDDSDZ.ToString();
            this.txtdltdcgds.Text = mo_DLT.N_GDDSDC.ToString();
            this.txtdlttygdx.Text = mo_DLT.N_GDDXTY.ToString();
            this.txtdltdzgdx.Text = mo_DLT.N_GDDXDZ.ToString();
            this.txtdltdcgdx.Text = mo_DLT.N_GDDXDC.ToString();
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
            this.txtbqcpty.Text = mo_CP.N_BQTY.ToString();
            this.txtbqcpdz.Text = mo_CP.N_BQDZ.ToString();
            this.txtbqcpdc.Text = mo_CP.N_BQDC.ToString();
            this.txtlqcpty.Text = mo_CP.N_LQTY.ToString();
            this.txtlqcpdz.Text = mo_CP.N_LQDZ.ToString();
            this.txtlqcpdc.Text = mo_CP.N_LQDC.ToString();
            this.txtzqcpty.Text = mo_CP.N_ZQTY.ToString();
            this.txtzqcpdz.Text = mo_CP.N_ZQDZ.ToString();
            this.txtzqcpdc.Text = mo_CP.N_ZQDC.ToString();
            this.txtgscpty.Text = mo_CP.N_GSTY.ToString();
            this.txtgscpdz.Text = mo_CP.N_GSDZ.ToString();
            this.txtgscpdc.Text = mo_CP.N_GSDC.ToString();
            this.txtzscpty.Text = mo_CP.N_QZTY.ToString();
            this.txtzscpdz.Text = mo_CP.N_QZDZ.ToString();
            this.txtzscpdc.Text = mo_CP.N_QZDC.ToString();
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
            AgentManageDB objAgentManageDB = new AgentManageDB();
            AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
            try
            {
                 KFB_ZHGL mo_zhgl = new KFB_ZHGL();
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
           
                KFB_SETUPBQ mo_bq = new KFB_SETUPBQ();
                KFB_SETUPCQ mo_cq = new KFB_SETUPCQ();

                //判斷是否存在
                bool chuser = objAgentManageDB.Exists(this.drzjzh.SelectedValue);

                if (chuser)
                {
                    this.ShowMsg( "該會員已存在！");
                }
                else//不存在則新增
                {
                    //剩餘額度判斷
                    mo_zhgl = objAgentManageDB.GetModel(strparid);
                    if (!(strlvl.Equals("4") && mo_zhgl == null) && Convert.ToDecimal(mo_zhgl.N_SYED) < Convert.ToDecimal(this.txtxyed.Text))
                    {
                        this.ShowMsg( "上級剩餘額度不足！");
                    }
                    else
                    {

                        //帳號管理
                        #region"帳號管理"
                        mo_zhgl = new KFB_ZHGL();
                        string strMD5 = FormsAuthPasswordFormat.MD5.ToString();
                        //mo_zhgl.N_ID = GetMaxID();
                        mo_zhgl.N_HYZH = this.drzjzh.SelectedValue;
                        mo_zhgl.N_HYMM = FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtmm.Text.ToUpper(), strMD5);
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
                        mo_zhgl.N_SYED = Convert.ToDecimal(this.txtxyed.Text);
                        mo_zhgl.N_ZQCZ = Convert.ToInt32(this.txtzq.Text);
                        mo_zhgl.N_LQCZ = Convert.ToInt32(this.txtlq.Text);
                        mo_zhgl.N_MZCZ = Convert.ToInt32(this.txtmz.Text);
                        mo_zhgl.N_MBCZ = Convert.ToInt32(this.txtmb.Text);
                        mo_zhgl.N_RBCZ = Convert.ToInt32(this.txtrb.Text);
                        mo_zhgl.N_TBCZ = Convert.ToInt32(this.txttb.Text);
                        mo_zhgl.N_ZSCZ = Convert.ToInt32(this.txtzs.Text);
                        mo_zhgl.N_SMCZ = Convert.ToInt32(this.txtsm.Text);
                        mo_zhgl.N_DLTCZ = Convert.ToInt32(this.txtdlt.Text);
                        mo_zhgl.N_CPCZ = Convert.ToInt32(this.txtcp.Text);
                        mo_zhgl.N_LHCCZ = Convert.ToInt32(this.txtlhc.Text);
                        mo_zhgl.N_JCCZ = Convert.ToInt32(this.txtjc539.Text);
                        mo_zhgl.N_2XCZ = Convert.ToInt32(this.txt2x.Text);
                        mo_zhgl.N_3XCZ = Convert.ToInt32(this.txt3x.Text);
                        mo_zhgl.N_4XCZ = Convert.ToInt32(this.txt4x.Text);
                        mo_zhgl.N_SSCZ = Convert.ToInt32(this.txtss.Text);

                        mo_zhgl.N_BQCZ = Convert.ToInt32(this.txtbq.Text);
                        mo_zhgl.N_CQCZ = Convert.ToInt32(this.txtcq.Text);

                        mo_zhgl.N_HYJRSJ = DateTime.Now;
                        mo_zhgl.N_HYXG = DateTime.Now;
                        mo_zhgl.N_XZSJ = DateTime.Now;
                        mo_zhgl.N_XZYC = Convert.ToInt32(this.Rdycxz.SelectedValue);
                        mo_zhgl.N_DDSX = float.Parse(this.txtddsx.Text);
                        mo_zhgl.N_TOLLGATE = Convert.ToInt32(this.drpXiazhuNum.SelectedValue);
                        mo_zhgl.N_DHHM = "";
                        mo_zhgl.N_MAIL = "";
                        mo_zhgl.N_QQ = "";
                        mo_zhgl.N_YJLX = 0;
                        mo_zhgl.N_SQZT = "3";
                        mo_zhgl.N_HYDLIP = Request.ServerVariables["remote_addr"];
                        mo_zhgl.N_XZSJ = DateTime.Now;
                        #endregion
                        #region"先清資料"
                        string strhyzh = this.drzjzh.SelectedValue;
                        objAgentManageDB.DelZHSetUP("KFB_SETUPCP", "N_HYDH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPDLT", "N_HYDH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPSM", "N_HYDH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPLHC", "N_HYDH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPLQ", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPMB", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPRB", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPTB", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPMQ", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPZQ", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPZS", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPJC539", "N_HYDH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPSS", "N_HYDH", strhyzh);

                        objAgentManageDB.DelZHSetUP("KFB_SETUPBQ", "N_HYZH", strhyzh);
                        objAgentManageDB.DelZHSetUP("KFB_SETUPCQ", "N_HYZH", strhyzh);
                        #endregion
                        #region"篮球"
                        //篮球
                        mo_lq.N_HYZH = this.drzjzh.SelectedValue;
                        mo_lq.N_RFTY = Convert.ToDecimal(this.txtlqtyrf.Text);
                        mo_lq.N_RFDZ = Convert.ToDecimal(this.txtlqdzrf.Text);
                        mo_lq.N_RFDC = Convert.ToDecimal(this.txtlqdcrf.Text);
                        mo_lq.N_DXTY = Convert.ToDecimal(this.txtlqtydx.Text);
                        mo_lq.N_DXDZ = Convert.ToDecimal(this.txtlqdzdx.Text);
                        mo_lq.N_DXDC = Convert.ToDecimal(this.txtlqdcdx.Text);
                        mo_lq.N_DYTY = Convert.ToDecimal(this.txtlqtydy.Text);
                        mo_lq.N_DYDZ = Convert.ToDecimal(this.txtlqdzdy.Text);
                        mo_lq.N_DYDC = Convert.ToDecimal(this.txtlqdcdy.Text);
                        mo_lq.N_DSTY = Convert.ToDecimal(this.txtlqtyds.Text);
                        mo_lq.N_DSDZ = Convert.ToDecimal(this.txtlqdzds.Text);
                        mo_lq.N_DSDC = Convert.ToDecimal(this.txtlqdcds.Text);
                        mo_lq.N_ZDRFTY = Convert.ToDecimal(this.txtlqtyzdrf.Text);
                        mo_lq.N_ZDRFDZ = Convert.ToDecimal(this.txtlqdzzdrf.Text);
                        mo_lq.N_ZDRFDC = Convert.ToDecimal(this.txtlqdczdrf.Text);
                        mo_lq.N_ZDDXTY = Convert.ToDecimal(this.txtlqtyzddx.Text);
                        mo_lq.N_ZDDXDZ = Convert.ToDecimal(this.txtlqdzzddx.Text);
                        mo_lq.N_ZDDXDC = Convert.ToDecimal(this.txtlqdczddx.Text);
                        mo_lq.N_BCRFTY = Convert.ToDecimal(this.txtlqtybcrf.Text);
                        mo_lq.N_BCRFDZ = Convert.ToDecimal(this.txtlqdzbcrf.Text);
                        mo_lq.N_BCRFDC = Convert.ToDecimal(this.txtlqdcbcrf.Text);
                        mo_lq.N_BCDXTY = Convert.ToDecimal(this.txtlqtybcdx.Text);
                        mo_lq.N_BCDXDZ = Convert.ToDecimal(this.txtlqdzbcdx.Text);
                        mo_lq.N_BCDXDC = Convert.ToDecimal(this.txtlqdcbcdx.Text);
                        mo_lq.N_BCDYTY = Convert.ToDecimal(this.txtlqtybcdy.Text);
                        mo_lq.N_BCDYDZ = Convert.ToDecimal(this.txtlqdzbcdy.Text);
                        mo_lq.N_BCDYDC = Convert.ToDecimal(this.txtlqdcbcdy.Text);
                        mo_lq.N_BCDSTY = Convert.ToDecimal(this.txtlqtybcds.Text);
                        mo_lq.N_BCDSDZ = Convert.ToDecimal(this.txtlqdzbcds.Text);
                        mo_lq.N_BCDSDC = Convert.ToDecimal(this.txtlqdcbcds.Text);
                        mo_lq.N_GGTY = Convert.ToDecimal(this.txtlqtygg.Text);
                        mo_lq.N_GGDZ = Convert.ToDecimal(this.txtlqdzgg.Text);
                        mo_lq.N_GGDC = Convert.ToDecimal(this.txtlqdcgg.Text);
                        mo_lq.N_GJTY = Convert.ToDecimal(this.txtlqtygj.Text);
                        mo_lq.N_GJDZ = Convert.ToDecimal(this.txtlqdzgj.Text);
                        mo_lq.N_GJDC = Convert.ToDecimal(this.txtlqdcgj.Text);

                        mo_lq.N_RFDD = Convert.ToDecimal(this.txtlqddrf.Text);
                        mo_lq.N_DXDD = Convert.ToDecimal(this.txtlqdddx.Text);
                        mo_lq.N_DYDD = Convert.ToDecimal(this.txtlqdddy.Text);
                        mo_lq.N_DSDD = Convert.ToDecimal(this.txtlqddds.Text);
                        mo_lq.N_ZDRFDD = Convert.ToDecimal(this.txtlqddzdrf.Text);
                        mo_lq.N_ZDDXDD = Convert.ToDecimal(this.txtlqddzddx.Text);
                        mo_lq.N_BCRFDD = Convert.ToDecimal(this.txtlqddbcrf.Text);
                        mo_lq.N_BCDXDD = Convert.ToDecimal(this.txtlqddbcdx.Text);
                        mo_lq.N_BCDYDD = Convert.ToDecimal(this.txtlqddbcdy.Text);
                        mo_lq.N_BCDSDD = Convert.ToDecimal(this.txtlqddbcds.Text);
                        mo_lq.N_GGDD = Convert.ToDecimal(this.txtlqddgg.Text);
                        mo_lq.N_GJDD = Convert.ToDecimal(this.txtlqddgj.Text);

                        mo_lq.N_DJRFTY = Convert.ToDecimal(this.txtlqtydjrf.Text);
                        mo_lq.N_DJDXTY = Convert.ToDecimal(this.txtlqtydjdx.Text);
                        mo_lq.N_DJDSTY = Convert.ToDecimal(this.txtlqtydjds.Text);
                        mo_lq.N_DJRFDZ = Convert.ToDecimal(this.txtlqdzdjrf.Text);
                        mo_lq.N_DJDXDZ = Convert.ToDecimal(this.txtlqdzdjdx.Text);
                        mo_lq.N_DJDSDZ = Convert.ToDecimal(this.txtlqdzdjds.Text);
                        mo_lq.N_DJRFDC = Convert.ToDecimal(this.txtlqdcdjrf.Text);
                        mo_lq.N_DJDXDC = Convert.ToDecimal(this.txtlqdcdjdx.Text);
                        mo_lq.N_DJDSDC = Convert.ToDecimal(this.txtlqdcdjds.Text);
                        mo_lq.N_DJRFDD = Convert.ToDecimal(this.txtlqdddjrf.Text);
                        mo_lq.N_DJDXDD = Convert.ToDecimal(this.txtlqdddjdx.Text);
                        mo_lq.N_DJDSDD = Convert.ToDecimal(this.txtlqdddjds.Text);

                        #endregion
                        #region"棒球"
                        //棒球　
                        mo_mb.N_HYZH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"冰球"
                        //冰球　
                        mo_bq.N_HYZH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"网球"
                        //网球　
                        mo_rb.N_HYZH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"排球"
                        //排球　
                        mo_tb.N_HYZH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"足球"
                        //足球
                        mo_zq.N_HYZH = this.drzjzh.SelectedValue;
                        mo_zq.N_ARFTY = Convert.ToDecimal(this.txtzqatyrf.Text);
                        mo_zq.N_ADXTY = Convert.ToDecimal(this.txtzqatydx.Text);
                        mo_zq.N_ADYTY = Convert.ToDecimal(this.txtzqatydy.Text);
                        mo_zq.N_ADSTY = Convert.ToDecimal(this.txtzqatyds.Text);
                        mo_zq.N_AZDRFTY = Convert.ToDecimal(this.txtzqatyzdrf.Text);
                        mo_zq.N_AZDDXTY = Convert.ToDecimal(this.txtzqatyzddx.Text);
                        mo_zq.N_ABCRFTY = Convert.ToDecimal(this.txtzqatybcrf.Text);
                        mo_zq.N_ABCDXTY = Convert.ToDecimal(this.txtzqatybcdx.Text);
                        mo_zq.N_ABCDYTY = Convert.ToDecimal(this.txtzqatybcdy.Text);
                        mo_zq.N_ARQSTY = Convert.ToDecimal(this.txtzqatyrqs.Text);
                        mo_zq.N_ABDTY = Convert.ToDecimal(this.txtzqatybd.Text);
                        mo_zq.N_ABQCTY = Convert.ToDecimal(this.txtzqatybqc.Text);
                        mo_zq.N_AGGTY = Convert.ToDecimal(this.txtzqatygg.Text);
                        mo_zq.N_AGJTY = Convert.ToDecimal(this.txtzqatygj.Text);

                        mo_zq.N_BRFTY = Convert.ToDecimal(this.txtzqbtyrf.Text);
                        mo_zq.N_BDXTY = Convert.ToDecimal(this.txtzqbtydx.Text);
                        mo_zq.N_BDYTY = Convert.ToDecimal(this.txtzqbtydy.Text);
                        mo_zq.N_BDSTY = Convert.ToDecimal(this.txtzqbtyds.Text);
                        mo_zq.N_BZDRFTY = Convert.ToDecimal(this.txtzqbtyzdrf.Text);
                        mo_zq.N_BZDDXTY = Convert.ToDecimal(this.txtzqbtyzddx.Text);
                        mo_zq.N_BBCRFTY = Convert.ToDecimal(this.txtzqbtybcrf.Text);
                        mo_zq.N_BBCDXTY = Convert.ToDecimal(this.txtzqbtybcdx.Text);
                        mo_zq.N_BBCDYTY = Convert.ToDecimal(this.txtzqbtybcdy.Text);
                        mo_zq.N_BRQSTY = Convert.ToDecimal(this.txtzqbtyrqs.Text);
                        mo_zq.N_BBDTY = Convert.ToDecimal(this.txtzqbtybd.Text);
                        mo_zq.N_BBQCTY = Convert.ToDecimal(this.txtzqbtybqc.Text);
                        mo_zq.N_BGGTY = Convert.ToDecimal(this.txtzqbtygg.Text);
                        mo_zq.N_BGJTY = Convert.ToDecimal(this.txtzqbtygj.Text);

                        mo_zq.N_CRFTY = Convert.ToDecimal(this.txtzqctyrf.Text);
                        mo_zq.N_CDXTY = Convert.ToDecimal(this.txtzqctydx.Text);
                        mo_zq.N_CDYTY = Convert.ToDecimal(this.txtzqctydy.Text);
                        mo_zq.N_CDSTY = Convert.ToDecimal(this.txtzqctyds.Text);
                        mo_zq.N_CZDRFTY = Convert.ToDecimal(this.txtzqctyzdrf.Text);
                        mo_zq.N_CZDDXTY = Convert.ToDecimal(this.txtzqctyzddx.Text);
                        mo_zq.N_CBCRFTY = Convert.ToDecimal(this.txtzqctybcrf.Text);
                        mo_zq.N_CBCDXTY = Convert.ToDecimal(this.txtzqctybcdx.Text);
                        mo_zq.N_CBCDYTY = Convert.ToDecimal(this.txtzqctybcdy.Text);
                        mo_zq.N_CRQSTY = Convert.ToDecimal(this.txtzqctyrqs.Text);
                        mo_zq.N_CBDTY = Convert.ToDecimal(this.txtzqctybd.Text);
                        mo_zq.N_CBQCTY = Convert.ToDecimal(this.txtzqctybqc.Text);
                        mo_zq.N_CGGTY = Convert.ToDecimal(this.txtzqctygg.Text);
                        mo_zq.N_CGJTY = Convert.ToDecimal(this.txtzqctygj.Text);

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
                        #endregion
                        #region"美足"
                        //美足　
                        mo_mz.N_HYZH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"彩球"
                        //彩球　
                        mo_cq.N_HYZH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"指 數"
                        //指 數　
                        mo_zs.N_HYZH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"赛马"
                        //赛马　
                        mo_sm.N_HYDH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"六合彩"
                        //六合彩　
                        mo_lhc.N_HYDH = this.drzjzh.SelectedValue;
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
                        mo_lhc.N_GDDSTY = Convert.ToDecimal(this.txtlhctygds.Text);
                        mo_lhc.N_GDDSDZ = Convert.ToDecimal(this.txtlhcdzgds.Text);
                        mo_lhc.N_GDDSDC = Convert.ToDecimal(this.txtlhcdcgds.Text);
                        mo_lhc.N_GDDXTY = Convert.ToDecimal(this.txtlhctygdx.Text);
                        mo_lhc.N_GDDXDZ = Convert.ToDecimal(this.txtlhcdzgdx.Text);
                        mo_lhc.N_GDDXDC = Convert.ToDecimal(this.txtlhcdcgdx.Text);
                        #endregion
                        #region"大樂透"
                        //大樂透　
                        mo_dlt.N_HYDH = this.drzjzh.SelectedValue;
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
                        mo_dlt.N_GDDSTY = Convert.ToDecimal(this.txtdlttygds.Text);
                        mo_dlt.N_GDDSDZ = Convert.ToDecimal(this.txtdltdzgds.Text);
                        mo_dlt.N_GDDSDC = Convert.ToDecimal(this.txtdltdcgds.Text);
                        mo_dlt.N_GDDXTY = Convert.ToDecimal(this.txtdlttygdx.Text);
                        mo_dlt.N_GDDXDZ = Convert.ToDecimal(this.txtdltdzgdx.Text);
                        mo_dlt.N_GDDXDC = Convert.ToDecimal(this.txtdltdcgdx.Text);
                        #endregion
                        #region"今彩539"
                        //今彩539　
                        mo_jc539.N_HYDH = this.drzjzh.SelectedValue;
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
                        #endregion
                        #region"運動彩票"
                        //運動彩票　
                        mo_cp.N_HYDH = this.drzjzh.SelectedValue;
                        mo_cp.N_BQTY = Convert.ToDecimal(this.txtbqcpty.Text);
                        mo_cp.N_BQDZ = Convert.ToDecimal(this.txtbqcpdz.Text);
                        mo_cp.N_BQDC = Convert.ToDecimal(this.txtbqcpdc.Text);
                        mo_cp.N_LQTY = Convert.ToDecimal(this.txtlqcpty.Text);
                        mo_cp.N_LQDZ = Convert.ToDecimal(this.txtlqcpdz.Text);
                        mo_cp.N_LQDC = Convert.ToDecimal(this.txtlqcpdc.Text);
                        mo_cp.N_ZQTY = Convert.ToDecimal(this.txtzqcpty.Text);
                        mo_cp.N_ZQDZ = Convert.ToDecimal(this.txtzqcpdz.Text);
                        mo_cp.N_ZQDC = Convert.ToDecimal(this.txtzqcpdc.Text);
                        mo_cp.N_GSTY = Convert.ToDecimal(this.txtgscpty.Text);
                        mo_cp.N_GSDZ = Convert.ToDecimal(this.txtgscpdz.Text);
                        mo_cp.N_GSDC = Convert.ToDecimal(this.txtgscpdc.Text);
                        mo_cp.N_QZTY = Convert.ToDecimal(this.txtzscpty.Text);
                        mo_cp.N_QZDZ = Convert.ToDecimal(this.txtzscpdz.Text);
                        mo_cp.N_QZDC = Convert.ToDecimal(this.txtzscpdc.Text);
                        #endregion
                        #region"政治時事"
                        //政治時事　
                        mo_ss.N_HYDH = this.drzjzh.SelectedValue;
                        mo_ss.N_DYTY = Convert.ToDecimal(this.txtsstydy.Text);
                        mo_ss.N_DYDZ = Convert.ToDecimal(this.txtssdzdy.Text);
                        mo_ss.N_DYDC = Convert.ToDecimal(this.txtssdcdy.Text);
                        #endregion

                        objAgentManageAddDB.SetData(mo_zhgl, mo_lq, mo_mb, mo_rb, mo_tb, mo_zq, mo_mz, mo_zs, mo_sm, mo_lhc, mo_dlt, mo_jc539, mo_cp, mo_ss, mo_bq, mo_cq); 
                        Server.Transfer("AgentManageUpd.aspx?id=" + this.drzjzh.SelectedValue + "&lv=" + strlvl, true);
                    }
                }
            }
            catch (Exception ex)
            {
                this.WriteLog("用户名=" + this.mUserID+ ex.ToString());
                this.Response.Write("對不起，系統繁忙，請稍候再操作！<br>" + ex.Message + "<br>" + ex.StackTrace);
                this.Response.End();
            }
        }
        #endregion
        #region"取得最大ID"
        public int GetMaxID()
        {
            AgentManageDB objAgentManageDB = new AgentManageDB();
            return Convert.ToInt32(objAgentManageDB.GetMaxID()) + 1;
        }
        #endregion
        #region"取得各级帐号"
        public string GetGJZH(int intlv, int intzh)
        {
            AgentManageAddDB objAgentManageDB = new AgentManageAddDB();
            string strreturn = string.Empty;
            if (intlv < intzh)
            {
                strreturn = "";
            }
            else if (intlv == intzh)
            {
                strreturn = this.drzjzh.SelectedValue;
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
                strreturn = objAgentManageDB.GetGJZH(strcname, strparid);
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
        protected void btfh_Click(object sender, EventArgs e)
        {
            //this.Server.Transfer("zjgl.aspx");
            string strpage = Comm.GetPage(strlvl, strparid);
            this.Server.Transfer(strpage);
        }
    }
