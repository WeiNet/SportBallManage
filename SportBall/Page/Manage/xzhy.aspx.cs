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


    public partial class xzhy : BasePage
    {
        AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
        AgentManageDB objAgentManage = new AgentManageDB();
        private XZHYDB objXZHYDB = new XZHYDB();
        private KFB_HYGLDB objHYGL = new KFB_HYGLDB();
        public KFB_SETUPCP mo_KFB_SETUPCP = new KFB_SETUPCP();
        public KFB_SETUPDLT mo_KFB_SETUPDLT = new KFB_SETUPDLT();
        public KFB_SETUPJC539 mo_KFB_SETUPJC539 = new KFB_SETUPJC539();
        public KFB_SETUPLHC mo_KFB_SETUPLHC = new KFB_SETUPLHC();
        public KFB_SETUPLQ mo_KFB_SETUPLQ = new KFB_SETUPLQ();
        public KFB_SETUPMB mo_KFB_SETUPMB = new KFB_SETUPMB();
        public KFB_SETUPMQ mo_KFB_SETUPMQ = new KFB_SETUPMQ();
        public KFB_SETUPRB mo_KFB_SETUPRB = new KFB_SETUPRB();
        public KFB_SETUPSM mo_KFB_SETUPSM = new KFB_SETUPSM();
        public KFB_SETUPTB mo_KFB_SETUPTB = new KFB_SETUPTB();
        public KFB_SETUPZQ mo_KFB_SETUPZQ = new KFB_SETUPZQ();
        public KFB_SETUPZS mo_KFB_SETUPZS = new KFB_SETUPZS();
        public KFB_SETUPSS mo_KFB_SETUPSS = new KFB_SETUPSS();

        public KFB_SETUPBQ mo_KFB_SETUPBQ = new KFB_SETUPBQ();
        public KFB_SETUPCQ mo_KFB_SETUPCQ = new KFB_SETUPCQ();

        public KFB_SETUPCP mo_KFB_SETUPCP1 = new KFB_SETUPCP();
        public KFB_SETUPDLT mo_KFB_SETUPDLT1 = new KFB_SETUPDLT();
        public KFB_SETUPJC539 mo_KFB_SETUPJC5391 = new KFB_SETUPJC539();
        public KFB_SETUPLHC mo_KFB_SETUPLHC1 = new KFB_SETUPLHC();
        public KFB_SETUPLQ mo_KFB_SETUPLQ1 = new KFB_SETUPLQ();
        public KFB_SETUPMB mo_KFB_SETUPMB1 = new KFB_SETUPMB();
        public KFB_SETUPMQ mo_KFB_SETUPMQ1 = new KFB_SETUPMQ();
        public KFB_SETUPRB mo_KFB_SETUPRB1 = new KFB_SETUPRB();
        public KFB_SETUPSM mo_KFB_SETUPSM1 = new KFB_SETUPSM();
        public KFB_SETUPTB mo_KFB_SETUPTB1 = new KFB_SETUPTB();
        public KFB_SETUPZQ mo_KFB_SETUPZQ1 = new KFB_SETUPZQ();
        public KFB_SETUPZS mo_KFB_SETUPZS1 = new KFB_SETUPZS();
        public KFB_SETUPSS mo_KFB_SETUPSS1 = new KFB_SETUPSS();


        public KFB_SETUPBQ mo_KFB_SETUPBQ1 = new KFB_SETUPBQ();
        public KFB_SETUPCQ mo_KFB_SETUPCQ1 = new KFB_SETUPCQ();

        private Hashtable mo_Ht = new Hashtable();
         protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
             
                string s_N_HYDH = String.Empty;
                if (Request.QueryString["n_dldh"] != null)
                {
                    s_N_HYDH = Request.QueryString["n_dldh"].ToString();//代理商账号
                    this.lblDLS.Text = s_N_HYDH;
                    InitPage_N_TOLLGATE(s_N_HYDH);
                }
                this.txtDLSED.Text = this.objHYGL.GetDLSED(s_N_HYDH).ToString();
                if (Request.QueryString["n_hyzh"] != null && Request.QueryString["n_hyzh"] != "")
                {
                    //修改时带出会员的信息
                    InitPage(Request.QueryString["n_hyzh"].ToString());
                    s_N_HYDH = Request.QueryString["n_hyzh"].ToString();//会员账号
                    this.drpEndUser.Visible = false;
                    this.hidMode.Value = "Update";
                    this.btnSave.Text = "修改會員";
                    this.tr_add.Visible = false;
                }
                else
                {
                    //新增时带出所属代理商信息
                    this.drpEndUser.DataSource = Comm.GetGetNotUseHYZH(s_N_HYDH);
                    this.drpEndUser.DataTextField = "N_HYZH";
                    this.drpEndUser.DataValueField = "N_HYZH";
                    this.drpEndUser.DataBind();
                    this.hidMode.Value = "Add";
                    this.btnSave.Text = "新增會員";
                }
                if (this.hidMode.Value == "Update")
                {
                    SetDLBall(Request.QueryString["n_hyzh"].ToString());
                    SetHYBall(Request.QueryString["n_dldh"].ToString());
                }
                else
                {
                    SetDLBall(Request.QueryString["n_dldh"].ToString());
                }
            }
            else
            {
                this.txtLeftED.Text = this.Request.Form["ctl00$ContentPlaceHolder11$txtLeftED"].ToString();
                #region 籃 球
                mo_KFB_SETUPLQ.N_RFTY = Convert.ToDecimal(this.Request.Form["N_LQRFTY"].ToString());
                mo_KFB_SETUPLQ.N_RFTY = Convert.ToDecimal(this.Request.Form["N_LQRFTY"].ToString());
                mo_KFB_SETUPLQ.N_DXTY = Convert.ToDecimal(this.Request.Form["N_LQDXTY"].ToString());
                mo_KFB_SETUPLQ.N_DYTY = Convert.ToDecimal(this.Request.Form["N_LQDYTY"].ToString());
                mo_KFB_SETUPLQ.N_DSTY = Convert.ToDecimal(this.Request.Form["N_LQDSTY"].ToString());
                mo_KFB_SETUPLQ.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_LQZDRFTY"].ToString());
                mo_KFB_SETUPLQ.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_LQZDDXTY"].ToString());
                mo_KFB_SETUPLQ.N_BCRFTY = Convert.ToDecimal(this.Request.Form["N_LQBCRFTY"].ToString());
                mo_KFB_SETUPLQ.N_BCDXTY = Convert.ToDecimal(this.Request.Form["N_LQBCDXTY"].ToString());
                mo_KFB_SETUPLQ.N_BCDYTY = Convert.ToDecimal(this.Request.Form["N_LQBCDYTY"].ToString());
                mo_KFB_SETUPLQ.N_BCDSTY = Convert.ToDecimal(this.Request.Form["N_LQBCDSTY"].ToString());
                mo_KFB_SETUPLQ.N_GGTY = Convert.ToDecimal(this.Request.Form["N_LQGGTY"].ToString());
                mo_KFB_SETUPLQ.N_GJTY = Convert.ToDecimal(this.Request.Form["N_LQGJTY"].ToString());
                mo_KFB_SETUPLQ.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_LQRFDZ"].ToString());
                mo_KFB_SETUPLQ.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_LQDXDZ"].ToString());
                mo_KFB_SETUPLQ.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_LQDYDZ"].ToString());
                mo_KFB_SETUPLQ.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_LQDSDZ"].ToString());
                mo_KFB_SETUPLQ.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_LQZDRFDZ"].ToString());
                mo_KFB_SETUPLQ.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_LQZDDXDZ"].ToString());
                mo_KFB_SETUPLQ.N_BCRFDZ = Convert.ToDecimal(this.Request.Form["N_LQBCRFDZ"].ToString());
                mo_KFB_SETUPLQ.N_BCDXDZ = Convert.ToDecimal(this.Request.Form["N_LQBCDXDZ"].ToString());
                mo_KFB_SETUPLQ.N_BCDYDZ = Convert.ToDecimal(this.Request.Form["N_LQBCDYDZ"].ToString());
                mo_KFB_SETUPLQ.N_BCDSDZ = Convert.ToDecimal(this.Request.Form["N_LQBCDSDZ"].ToString());
                mo_KFB_SETUPLQ.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_LQGGDZ"].ToString());
                mo_KFB_SETUPLQ.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_LQGJDZ"].ToString());
                mo_KFB_SETUPLQ.N_RFDC = Convert.ToDecimal(this.Request.Form["N_LQRFDC"].ToString());
                mo_KFB_SETUPLQ.N_DXDC = Convert.ToDecimal(this.Request.Form["N_LQDXDC"].ToString());
                mo_KFB_SETUPLQ.N_DYDC = Convert.ToDecimal(this.Request.Form["N_LQDYDC"].ToString());
                mo_KFB_SETUPLQ.N_DSDC = Convert.ToDecimal(this.Request.Form["N_LQDSDC"].ToString());
                mo_KFB_SETUPLQ.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_LQZDRFDC"].ToString());
                mo_KFB_SETUPLQ.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_LQZDDXDC"].ToString());
                mo_KFB_SETUPLQ.N_BCRFDC = Convert.ToDecimal(this.Request.Form["N_LQBCRFDC"].ToString());
                mo_KFB_SETUPLQ.N_BCDXDC = Convert.ToDecimal(this.Request.Form["N_LQBCDXDC"].ToString());
                mo_KFB_SETUPLQ.N_BCDYDC = Convert.ToDecimal(this.Request.Form["N_LQBCDYDC"].ToString());
                mo_KFB_SETUPLQ.N_BCDSDC = Convert.ToDecimal(this.Request.Form["N_LQBCDSDC"].ToString());
                mo_KFB_SETUPLQ.N_GGDC = Convert.ToDecimal(this.Request.Form["N_LQGGDC"].ToString());
                mo_KFB_SETUPLQ.N_GJDC = Convert.ToDecimal(this.Request.Form["N_LQGJDC"].ToString());
                mo_KFB_SETUPLQ.N_RFDD = Convert.ToDecimal(this.Request.Form["N_LQRFDD"].ToString());
                mo_KFB_SETUPLQ.N_DXDD = Convert.ToDecimal(this.Request.Form["N_LQDXDD"].ToString());
                mo_KFB_SETUPLQ.N_DYDD = Convert.ToDecimal(this.Request.Form["N_LQDYDD"].ToString());
                mo_KFB_SETUPLQ.N_DSDD = Convert.ToDecimal(this.Request.Form["N_LQDSDD"].ToString());
                mo_KFB_SETUPLQ.N_ZDRFDD = Convert.ToDecimal(this.Request.Form["N_LQZDRFDD"].ToString());
                mo_KFB_SETUPLQ.N_ZDDXDD = Convert.ToDecimal(this.Request.Form["N_LQZDDXDD"].ToString());
                mo_KFB_SETUPLQ.N_BCRFDD = Convert.ToDecimal(this.Request.Form["N_LQBCRFDD"].ToString());
                mo_KFB_SETUPLQ.N_BCDXDD = Convert.ToDecimal(this.Request.Form["N_LQBCDXDD"].ToString());
                mo_KFB_SETUPLQ.N_BCDYDD = Convert.ToDecimal(this.Request.Form["N_LQBCDYDD"].ToString());
                mo_KFB_SETUPLQ.N_BCDSDD = Convert.ToDecimal(this.Request.Form["N_LQBCDSDD"].ToString());
                mo_KFB_SETUPLQ.N_GGDD = Convert.ToDecimal(this.Request.Form["N_LQGGDD"].ToString());
                mo_KFB_SETUPLQ.N_GJDD = Convert.ToDecimal(this.Request.Form["N_LQGJDD"].ToString());
                mo_KFB_SETUPLQ.N_DJRFTY = Convert.ToDecimal(this.Request.Form["N_LQDJRFTY"].ToString());
                mo_KFB_SETUPLQ.N_DJDXTY = Convert.ToDecimal(this.Request.Form["N_LQDJDXTY"].ToString());
                mo_KFB_SETUPLQ.N_DJDSTY = Convert.ToDecimal(this.Request.Form["N_LQDJDSTY"].ToString());
                mo_KFB_SETUPLQ.N_DJRFDZ = Convert.ToDecimal(this.Request.Form["N_LQDJRFDZ"].ToString());
                mo_KFB_SETUPLQ.N_DJDXDZ = Convert.ToDecimal(this.Request.Form["N_LQDJDXDZ"].ToString());
                mo_KFB_SETUPLQ.N_DJDSDZ = Convert.ToDecimal(this.Request.Form["N_LQDJDSDZ"].ToString());
                mo_KFB_SETUPLQ.N_DJRFDC = Convert.ToDecimal(this.Request.Form["N_LQDJRFDC"].ToString());
                mo_KFB_SETUPLQ.N_DJDXDC = Convert.ToDecimal(this.Request.Form["N_LQDJDXDC"].ToString());
                mo_KFB_SETUPLQ.N_DJDSDC = Convert.ToDecimal(this.Request.Form["N_LQDJDSDC"].ToString());
                mo_KFB_SETUPLQ.N_DJRFDD = Convert.ToDecimal(this.Request.Form["N_LQDJRFDD"].ToString());
                mo_KFB_SETUPLQ.N_DJDXDD = Convert.ToDecimal(this.Request.Form["N_LQDJDXDD"].ToString());
                mo_KFB_SETUPLQ.N_DJDSDD = Convert.ToDecimal(this.Request.Form["N_LQDJDSDD"].ToString());
                #endregion

                #region 美 棒
                mo_KFB_SETUPMB.N_RFTY = Convert.ToDecimal(this.Request.Form["N_MBRFTY"].ToString());
                mo_KFB_SETUPMB.N_DXTY = Convert.ToDecimal(this.Request.Form["N_MBDXTY"].ToString());
                mo_KFB_SETUPMB.N_DYTY = Convert.ToDecimal(this.Request.Form["N_MBDYTY"].ToString());
                mo_KFB_SETUPMB.N_DSTY = Convert.ToDecimal(this.Request.Form["N_MBDSTY"].ToString());
                mo_KFB_SETUPMB.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_MBZDRFTY"].ToString());
                mo_KFB_SETUPMB.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_MBZDDXTY"].ToString());
                mo_KFB_SETUPMB.N_SYTY = Convert.ToDecimal(this.Request.Form["N_MBSYTY"].ToString());
                mo_KFB_SETUPMB.N_GGTY = Convert.ToDecimal(this.Request.Form["N_MBGGTY"].ToString());
                mo_KFB_SETUPMB.N_GJTY = Convert.ToDecimal(this.Request.Form["N_MBGJTY"].ToString());
                mo_KFB_SETUPMB.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_MBRFDZ"].ToString());
                mo_KFB_SETUPMB.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_MBDXDZ"].ToString());
                mo_KFB_SETUPMB.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_MBDYDZ"].ToString());
                mo_KFB_SETUPMB.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_MBDSDZ"].ToString());
                mo_KFB_SETUPMB.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_MBZDRFDZ"].ToString());
                mo_KFB_SETUPMB.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_MBZDDXDZ"].ToString());
                mo_KFB_SETUPMB.N_SYDZ = Convert.ToDecimal(this.Request.Form["N_MBSYDZ"].ToString());
                mo_KFB_SETUPMB.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_MBGGDZ"].ToString());
                mo_KFB_SETUPMB.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_MBGJDZ"].ToString());
                mo_KFB_SETUPMB.N_RFDC = Convert.ToDecimal(this.Request.Form["N_MBRFDC"].ToString());
                mo_KFB_SETUPMB.N_DXDC = Convert.ToDecimal(this.Request.Form["N_MBDXDC"].ToString());
                mo_KFB_SETUPMB.N_DYDC = Convert.ToDecimal(this.Request.Form["N_MBDYDC"].ToString());
                mo_KFB_SETUPMB.N_DSDC = Convert.ToDecimal(this.Request.Form["N_MBDSDC"].ToString());
                mo_KFB_SETUPMB.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_MBZDRFDC"].ToString());
                mo_KFB_SETUPMB.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_MBZDDXDC"].ToString());
                mo_KFB_SETUPMB.N_SYDC = Convert.ToDecimal(this.Request.Form["N_MBSYDC"].ToString());
                mo_KFB_SETUPMB.N_GGDC = Convert.ToDecimal(this.Request.Form["N_MBGGDC"].ToString());
                mo_KFB_SETUPMB.N_GJDC = Convert.ToDecimal(this.Request.Form["N_MBGJDC"].ToString());
                #endregion

                #region 冰球
                mo_KFB_SETUPBQ.N_RFTY = Convert.ToDecimal(this.Request.Form["N_BQRFTY"].ToString());
                mo_KFB_SETUPBQ.N_DXTY = Convert.ToDecimal(this.Request.Form["N_BQDXTY"].ToString());
                mo_KFB_SETUPBQ.N_DYTY = Convert.ToDecimal(this.Request.Form["N_BQDYTY"].ToString());
                mo_KFB_SETUPBQ.N_DSTY = Convert.ToDecimal(this.Request.Form["N_BQDSTY"].ToString());
                mo_KFB_SETUPBQ.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_BQZDRFTY"].ToString());
                mo_KFB_SETUPBQ.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_BQZDDXTY"].ToString());
                mo_KFB_SETUPBQ.N_SYTY = Convert.ToDecimal(this.Request.Form["N_BQSYTY"].ToString());
                mo_KFB_SETUPBQ.N_GGTY = Convert.ToDecimal(this.Request.Form["N_BQGGTY"].ToString());
                mo_KFB_SETUPBQ.N_GJTY = Convert.ToDecimal(this.Request.Form["N_BQGJTY"].ToString());
                mo_KFB_SETUPBQ.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_BQRFDZ"].ToString());
                mo_KFB_SETUPBQ.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_BQDXDZ"].ToString());
                mo_KFB_SETUPBQ.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_BQDYDZ"].ToString());
                mo_KFB_SETUPBQ.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_BQDSDZ"].ToString());
                mo_KFB_SETUPBQ.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_BQZDRFDZ"].ToString());
                mo_KFB_SETUPBQ.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_BQZDDXDZ"].ToString());
                mo_KFB_SETUPBQ.N_SYDZ = Convert.ToDecimal(this.Request.Form["N_BQSYDZ"].ToString());
                mo_KFB_SETUPBQ.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_BQGGDZ"].ToString());
                mo_KFB_SETUPBQ.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_BQGJDZ"].ToString());
                mo_KFB_SETUPBQ.N_RFDC = Convert.ToDecimal(this.Request.Form["N_BQRFDC"].ToString());
                mo_KFB_SETUPBQ.N_DXDC = Convert.ToDecimal(this.Request.Form["N_BQDXDC"].ToString());
                mo_KFB_SETUPBQ.N_DYDC = Convert.ToDecimal(this.Request.Form["N_BQDYDC"].ToString());
                mo_KFB_SETUPBQ.N_DSDC = Convert.ToDecimal(this.Request.Form["N_BQDSDC"].ToString());
                mo_KFB_SETUPBQ.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_BQZDRFDC"].ToString());
                mo_KFB_SETUPBQ.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_BQZDDXDC"].ToString());
                mo_KFB_SETUPBQ.N_SYDC = Convert.ToDecimal(this.Request.Form["N_BQSYDC"].ToString());
                mo_KFB_SETUPBQ.N_GGDC = Convert.ToDecimal(this.Request.Form["N_BQGGDC"].ToString());
                mo_KFB_SETUPBQ.N_GJDC = Convert.ToDecimal(this.Request.Form["N_BQGJDC"].ToString());
                #endregion


                #region 网球
                mo_KFB_SETUPRB.N_RFTY = Convert.ToDecimal(this.Request.Form["N_RBRFTY"].ToString());
                mo_KFB_SETUPRB.N_DXTY = Convert.ToDecimal(this.Request.Form["N_RBDXTY"].ToString());
                mo_KFB_SETUPRB.N_DYTY = Convert.ToDecimal(this.Request.Form["N_RBDYTY"].ToString());
                mo_KFB_SETUPRB.N_DSTY = Convert.ToDecimal(this.Request.Form["N_RBDSTY"].ToString());
                mo_KFB_SETUPRB.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_RBZDRFTY"].ToString());
                mo_KFB_SETUPRB.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_RBZDDXTY"].ToString());
                mo_KFB_SETUPRB.N_SYTY = Convert.ToDecimal(this.Request.Form["N_RBSYTY"].ToString());
                mo_KFB_SETUPRB.N_GGTY = Convert.ToDecimal(this.Request.Form["N_RBGGTY"].ToString());
                mo_KFB_SETUPRB.N_GJTY = Convert.ToDecimal(this.Request.Form["N_RBGJTY"].ToString());
                mo_KFB_SETUPRB.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_RBRFDZ"].ToString());
                mo_KFB_SETUPRB.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_RBDXDZ"].ToString());
                mo_KFB_SETUPRB.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_RBDYDZ"].ToString());
                mo_KFB_SETUPRB.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_RBDSDZ"].ToString());
                mo_KFB_SETUPRB.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_RBZDRFDZ"].ToString());
                mo_KFB_SETUPRB.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_RBZDDXDZ"].ToString());
                mo_KFB_SETUPRB.N_SYDZ = Convert.ToDecimal(this.Request.Form["N_RBSYDZ"].ToString());
                mo_KFB_SETUPRB.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_RBGGDZ"].ToString());
                mo_KFB_SETUPRB.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_RBGJDZ"].ToString());
                mo_KFB_SETUPRB.N_RFDC = Convert.ToDecimal(this.Request.Form["N_RBRFDC"].ToString());
                mo_KFB_SETUPRB.N_DXDC = Convert.ToDecimal(this.Request.Form["N_RBDXDC"].ToString());
                mo_KFB_SETUPRB.N_DYDC = Convert.ToDecimal(this.Request.Form["N_RBDYDC"].ToString());
                mo_KFB_SETUPRB.N_DSDC = Convert.ToDecimal(this.Request.Form["N_RBDSDC"].ToString());
                mo_KFB_SETUPRB.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_RBZDRFDC"].ToString());
                mo_KFB_SETUPRB.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_RBZDDXDC"].ToString());
                mo_KFB_SETUPRB.N_SYDC = Convert.ToDecimal(this.Request.Form["N_RBSYDC"].ToString());
                mo_KFB_SETUPRB.N_GGDC = Convert.ToDecimal(this.Request.Form["N_RBGGDC"].ToString());
                mo_KFB_SETUPRB.N_GJDC = Convert.ToDecimal(this.Request.Form["N_RBGJDC"].ToString());
                #endregion

                #region 足球
                mo_KFB_SETUPZQ.N_ARFTY = Convert.ToDecimal(this.Request.Form["N_ZQARFTY"].ToString());
                mo_KFB_SETUPZQ.N_ADXTY = Convert.ToDecimal(this.Request.Form["N_ZQADXTY"].ToString());
                mo_KFB_SETUPZQ.N_ADYTY = Convert.ToDecimal(this.Request.Form["N_ZQADYTY"].ToString());
                mo_KFB_SETUPZQ.N_ADSTY = Convert.ToDecimal(this.Request.Form["N_ZQADSTY"].ToString());
                mo_KFB_SETUPZQ.N_AZDRFTY = Convert.ToDecimal(this.Request.Form["N_ZQAZDRFTY"].ToString());
                mo_KFB_SETUPZQ.N_AZDDXTY = Convert.ToDecimal(this.Request.Form["N_ZQAZDDXTY"].ToString());
                mo_KFB_SETUPZQ.N_ABCRFTY = Convert.ToDecimal(this.Request.Form["N_ZQABCRFTY"].ToString());
                mo_KFB_SETUPZQ.N_ABCDXTY = Convert.ToDecimal(this.Request.Form["N_ZQABCDXTY"].ToString());
                mo_KFB_SETUPZQ.N_ABCDYTY = Convert.ToDecimal(this.Request.Form["N_ZQABCDYTY"].ToString());
                mo_KFB_SETUPZQ.N_ARQSTY = Convert.ToDecimal(this.Request.Form["N_ZQARQSTY"].ToString());
                mo_KFB_SETUPZQ.N_ABDTY = Convert.ToDecimal(this.Request.Form["N_ZQABDTY"].ToString());
                mo_KFB_SETUPZQ.N_ABQCTY = Convert.ToDecimal(this.Request.Form["N_ZQABQCTY"].ToString());
                mo_KFB_SETUPZQ.N_AGGTY = Convert.ToDecimal(this.Request.Form["N_ZQAGGTY"].ToString());
                mo_KFB_SETUPZQ.N_AGJTY = Convert.ToDecimal(this.Request.Form["N_ZQAGJTY"].ToString());
                mo_KFB_SETUPZQ.N_BRFTY = Convert.ToDecimal(this.Request.Form["N_ZQBRFTY"].ToString());
                mo_KFB_SETUPZQ.N_BDXTY = Convert.ToDecimal(this.Request.Form["N_ZQBDXTY"].ToString());
                mo_KFB_SETUPZQ.N_BDYTY = Convert.ToDecimal(this.Request.Form["N_ZQBDYTY"].ToString());
                mo_KFB_SETUPZQ.N_BDSTY = Convert.ToDecimal(this.Request.Form["N_ZQBDSTY"].ToString());
                mo_KFB_SETUPZQ.N_BZDRFTY = Convert.ToDecimal(this.Request.Form["N_ZQBZDRFTY"].ToString());
                mo_KFB_SETUPZQ.N_BZDDXTY = Convert.ToDecimal(this.Request.Form["N_ZQBZDDXTY"].ToString());
                mo_KFB_SETUPZQ.N_BBCRFTY = Convert.ToDecimal(this.Request.Form["N_ZQBBCRFTY"].ToString());
                mo_KFB_SETUPZQ.N_BBCDXTY = Convert.ToDecimal(this.Request.Form["N_ZQBBCDXTY"].ToString());
                mo_KFB_SETUPZQ.N_BBCDYTY = Convert.ToDecimal(this.Request.Form["N_ZQBBCDYTY"].ToString());
                mo_KFB_SETUPZQ.N_BRQSTY = Convert.ToDecimal(this.Request.Form["N_ZQBRQSTY"].ToString());
                mo_KFB_SETUPZQ.N_BBDTY = Convert.ToDecimal(this.Request.Form["N_ZQBBDTY"].ToString());
                mo_KFB_SETUPZQ.N_BBQCTY = Convert.ToDecimal(this.Request.Form["N_ZQBBQCTY"].ToString());
                mo_KFB_SETUPZQ.N_BGGTY = Convert.ToDecimal(this.Request.Form["N_ZQBGGTY"].ToString());
                mo_KFB_SETUPZQ.N_BGJTY = Convert.ToDecimal(this.Request.Form["N_ZQBGJTY"].ToString());
                mo_KFB_SETUPZQ.N_CRFTY = Convert.ToDecimal(this.Request.Form["N_ZQCRFTY"].ToString());
                mo_KFB_SETUPZQ.N_CDXTY = Convert.ToDecimal(this.Request.Form["N_ZQCDXTY"].ToString());
                mo_KFB_SETUPZQ.N_CDYTY = Convert.ToDecimal(this.Request.Form["N_ZQCDYTY"].ToString());
                mo_KFB_SETUPZQ.N_CDSTY = Convert.ToDecimal(this.Request.Form["N_ZQCDSTY"].ToString());
                mo_KFB_SETUPZQ.N_CZDRFTY = Convert.ToDecimal(this.Request.Form["N_ZQCZDRFTY"].ToString());
                mo_KFB_SETUPZQ.N_CZDDXTY = Convert.ToDecimal(this.Request.Form["N_ZQCZDDXTY"].ToString());
                mo_KFB_SETUPZQ.N_CBCRFTY = Convert.ToDecimal(this.Request.Form["N_ZQCBCRFTY"].ToString());
                mo_KFB_SETUPZQ.N_CBCDXTY = Convert.ToDecimal(this.Request.Form["N_ZQCBCDXTY"].ToString());
                mo_KFB_SETUPZQ.N_CBCDYTY = Convert.ToDecimal(this.Request.Form["N_ZQCBCDYTY"].ToString());
                mo_KFB_SETUPZQ.N_CRQSTY = Convert.ToDecimal(this.Request.Form["N_ZQCRQSTY"].ToString());
                mo_KFB_SETUPZQ.N_CBDTY = Convert.ToDecimal(this.Request.Form["N_ZQCBDTY"].ToString());
                mo_KFB_SETUPZQ.N_CBQCTY = Convert.ToDecimal(this.Request.Form["N_ZQCBQCTY"].ToString());
                mo_KFB_SETUPZQ.N_CGGTY = Convert.ToDecimal(this.Request.Form["N_ZQCGGTY"].ToString());
                mo_KFB_SETUPZQ.N_CGJTY = Convert.ToDecimal(this.Request.Form["N_ZQCGJTY"].ToString());
                mo_KFB_SETUPZQ.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_ZQRFDZ"].ToString());
                mo_KFB_SETUPZQ.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_ZQDXDZ"].ToString());
                mo_KFB_SETUPZQ.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_ZQDYDZ"].ToString());
                mo_KFB_SETUPZQ.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_ZQDSDZ"].ToString());
                mo_KFB_SETUPZQ.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_ZQZDRFDZ"].ToString());
                mo_KFB_SETUPZQ.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_ZQZDDXDZ"].ToString());
                mo_KFB_SETUPZQ.N_BCRFDZ = Convert.ToDecimal(this.Request.Form["N_ZQBCRFDZ"].ToString());
                mo_KFB_SETUPZQ.N_BCDXDZ = Convert.ToDecimal(this.Request.Form["N_ZQBCDXDZ"].ToString());
                mo_KFB_SETUPZQ.N_BCDYDZ = Convert.ToDecimal(this.Request.Form["N_ZQBCDYDZ"].ToString());
                mo_KFB_SETUPZQ.N_RQSDZ = Convert.ToDecimal(this.Request.Form["N_ZQRQSDZ"].ToString());
                mo_KFB_SETUPZQ.N_BDDZ = Convert.ToDecimal(this.Request.Form["N_ZQBDDZ"].ToString());
                mo_KFB_SETUPZQ.N_BQCDZ = Convert.ToDecimal(this.Request.Form["N_ZQBQCDZ"].ToString());
                mo_KFB_SETUPZQ.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_ZQGGDZ"].ToString());
                mo_KFB_SETUPZQ.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_ZQGJDZ"].ToString());
                mo_KFB_SETUPZQ.N_RFDC = Convert.ToDecimal(this.Request.Form["N_ZQRFDC"].ToString());
                mo_KFB_SETUPZQ.N_DXDC = Convert.ToDecimal(this.Request.Form["N_ZQDXDC"].ToString());
                mo_KFB_SETUPZQ.N_DYDC = Convert.ToDecimal(this.Request.Form["N_ZQDYDC"].ToString());
                mo_KFB_SETUPZQ.N_DSDC = Convert.ToDecimal(this.Request.Form["N_ZQDSDC"].ToString());
                mo_KFB_SETUPZQ.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_ZQZDRFDC"].ToString());
                mo_KFB_SETUPZQ.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_ZQZDDXDC"].ToString());
                mo_KFB_SETUPZQ.N_BCRFDC = Convert.ToDecimal(this.Request.Form["N_ZQBCRFDC"].ToString());
                mo_KFB_SETUPZQ.N_BCDXDC = Convert.ToDecimal(this.Request.Form["N_ZQBCDXDC"].ToString());
                mo_KFB_SETUPZQ.N_BCDYDC = Convert.ToDecimal(this.Request.Form["N_ZQBCDYDC"].ToString());
                mo_KFB_SETUPZQ.N_RQSDC = Convert.ToDecimal(this.Request.Form["N_ZQRQSDC"].ToString());
                mo_KFB_SETUPZQ.N_BDDC = Convert.ToDecimal(this.Request.Form["N_ZQBDDC"].ToString());
                mo_KFB_SETUPZQ.N_BQCDC = Convert.ToDecimal(this.Request.Form["N_ZQBQCDC"].ToString());
                mo_KFB_SETUPZQ.N_GGDC = Convert.ToDecimal(this.Request.Form["N_ZQGGDC"].ToString());
                mo_KFB_SETUPZQ.N_GJDC = Convert.ToDecimal(this.Request.Form["N_ZQGJDC"].ToString());
                #endregion

                #region 美足
                mo_KFB_SETUPMQ.N_RFTY = Convert.ToDecimal(this.Request.Form["N_MQRFTY"].ToString());
                mo_KFB_SETUPMQ.N_DXTY = Convert.ToDecimal(this.Request.Form["N_MQDXTY"].ToString());
                mo_KFB_SETUPMQ.N_DYTY = Convert.ToDecimal(this.Request.Form["N_MQDYTY"].ToString());
                mo_KFB_SETUPMQ.N_DSTY = Convert.ToDecimal(this.Request.Form["N_MQDSTY"].ToString());
                mo_KFB_SETUPMQ.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_MQZDRFTY"].ToString());
                mo_KFB_SETUPMQ.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_MQZDDXTY"].ToString());
                mo_KFB_SETUPMQ.N_BCRFTY = Convert.ToDecimal(this.Request.Form["N_MQBCRFTY"].ToString());
                mo_KFB_SETUPMQ.N_BCDXTY = Convert.ToDecimal(this.Request.Form["N_MQBCDXTY"].ToString());
                mo_KFB_SETUPMQ.N_BCDYTY = Convert.ToDecimal(this.Request.Form["N_MQBCDYTY"].ToString());
                mo_KFB_SETUPMQ.N_BCDSTY = Convert.ToDecimal(this.Request.Form["N_MQBCDSTY"].ToString());
                mo_KFB_SETUPMQ.N_GGTY = Convert.ToDecimal(this.Request.Form["N_MQGGTY"].ToString());
                mo_KFB_SETUPMQ.N_GJTY = Convert.ToDecimal(this.Request.Form["N_MQGJTY"].ToString());
                mo_KFB_SETUPMQ.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_MQRFDZ"].ToString());
                mo_KFB_SETUPMQ.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_MQDXDZ"].ToString());
                mo_KFB_SETUPMQ.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_MQDYDZ"].ToString());
                mo_KFB_SETUPMQ.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_MQDSDZ"].ToString());
                mo_KFB_SETUPMQ.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_MQZDRFDZ"].ToString());
                mo_KFB_SETUPMQ.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_MQZDDXDZ"].ToString());
                mo_KFB_SETUPMQ.N_BCRFDZ = Convert.ToDecimal(this.Request.Form["N_MQBCRFDZ"].ToString());
                mo_KFB_SETUPMQ.N_BCDXDZ = Convert.ToDecimal(this.Request.Form["N_MQBCDXDZ"].ToString());
                mo_KFB_SETUPMQ.N_BCDYDZ = Convert.ToDecimal(this.Request.Form["N_MQBCDYDZ"].ToString());
                mo_KFB_SETUPMQ.N_BCDSDZ = Convert.ToDecimal(this.Request.Form["N_MQBCDSDZ"].ToString());
                mo_KFB_SETUPMQ.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_MQGGDZ"].ToString());
                mo_KFB_SETUPMQ.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_MQGJDZ"].ToString());
                mo_KFB_SETUPMQ.N_RFDC = Convert.ToDecimal(this.Request.Form["N_MQRFDC"].ToString());
                mo_KFB_SETUPMQ.N_DXDC = Convert.ToDecimal(this.Request.Form["N_MQDXDC"].ToString());
                mo_KFB_SETUPMQ.N_DYDC = Convert.ToDecimal(this.Request.Form["N_MQDYDC"].ToString());
                mo_KFB_SETUPMQ.N_DSDC = Convert.ToDecimal(this.Request.Form["N_MQDSDC"].ToString());
                mo_KFB_SETUPMQ.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_MQZDRFDC"].ToString());
                mo_KFB_SETUPMQ.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_MQZDDXDC"].ToString());
                mo_KFB_SETUPMQ.N_BCRFDC = Convert.ToDecimal(this.Request.Form["N_MQBCRFDC"].ToString());
                mo_KFB_SETUPMQ.N_BCDXDC = Convert.ToDecimal(this.Request.Form["N_MQBCDXDC"].ToString());
                mo_KFB_SETUPMQ.N_BCDYDC = Convert.ToDecimal(this.Request.Form["N_MQBCDYDC"].ToString());
                mo_KFB_SETUPMQ.N_BCDSDC = Convert.ToDecimal(this.Request.Form["N_MQBCDSDC"].ToString());
                mo_KFB_SETUPMQ.N_GGDC = Convert.ToDecimal(this.Request.Form["N_MQGGDC"].ToString());
                mo_KFB_SETUPMQ.N_GJDC = Convert.ToDecimal(this.Request.Form["N_MQGJDC"].ToString());
                #endregion

                #region 彩球
                mo_KFB_SETUPCQ.N_RFTY = Convert.ToDecimal(this.Request.Form["N_CQRFTY"].ToString());
                mo_KFB_SETUPCQ.N_DXTY = Convert.ToDecimal(this.Request.Form["N_CQDXTY"].ToString());
                mo_KFB_SETUPCQ.N_DYTY = Convert.ToDecimal(this.Request.Form["N_CQDYTY"].ToString());
                mo_KFB_SETUPCQ.N_DSTY = Convert.ToDecimal(this.Request.Form["N_CQDSTY"].ToString());
                mo_KFB_SETUPCQ.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_CQZDRFTY"].ToString());
                mo_KFB_SETUPCQ.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_CQZDDXTY"].ToString());
                mo_KFB_SETUPCQ.N_BCRFTY = Convert.ToDecimal(this.Request.Form["N_CQBCRFTY"].ToString());
                mo_KFB_SETUPCQ.N_BCDXTY = Convert.ToDecimal(this.Request.Form["N_CQBCDXTY"].ToString());
                mo_KFB_SETUPCQ.N_BCDYTY = Convert.ToDecimal(this.Request.Form["N_CQBCDYTY"].ToString());
                mo_KFB_SETUPCQ.N_BCDSTY = Convert.ToDecimal(this.Request.Form["N_CQBCDSTY"].ToString());
                mo_KFB_SETUPCQ.N_GGTY = Convert.ToDecimal(this.Request.Form["N_CQGGTY"].ToString());
                mo_KFB_SETUPCQ.N_GJTY = Convert.ToDecimal(this.Request.Form["N_CQGJTY"].ToString());
                mo_KFB_SETUPCQ.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_CQRFDZ"].ToString());
                mo_KFB_SETUPCQ.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_CQDXDZ"].ToString());
                mo_KFB_SETUPCQ.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_CQDYDZ"].ToString());
                mo_KFB_SETUPCQ.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_CQDSDZ"].ToString());
                mo_KFB_SETUPCQ.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_CQZDRFDZ"].ToString());
                mo_KFB_SETUPCQ.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_CQZDDXDZ"].ToString());
                mo_KFB_SETUPCQ.N_BCRFDZ = Convert.ToDecimal(this.Request.Form["N_CQBCRFDZ"].ToString());
                mo_KFB_SETUPCQ.N_BCDXDZ = Convert.ToDecimal(this.Request.Form["N_CQBCDXDZ"].ToString());
                mo_KFB_SETUPCQ.N_BCDYDZ = Convert.ToDecimal(this.Request.Form["N_CQBCDYDZ"].ToString());
                mo_KFB_SETUPCQ.N_BCDSDZ = Convert.ToDecimal(this.Request.Form["N_CQBCDSDZ"].ToString());
                mo_KFB_SETUPCQ.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_CQGGDZ"].ToString());
                mo_KFB_SETUPCQ.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_CQGJDZ"].ToString());
                mo_KFB_SETUPCQ.N_RFDC = Convert.ToDecimal(this.Request.Form["N_CQRFDC"].ToString());
                mo_KFB_SETUPCQ.N_DXDC = Convert.ToDecimal(this.Request.Form["N_CQDXDC"].ToString());
                mo_KFB_SETUPCQ.N_DYDC = Convert.ToDecimal(this.Request.Form["N_CQDYDC"].ToString());
                mo_KFB_SETUPCQ.N_DSDC = Convert.ToDecimal(this.Request.Form["N_CQDSDC"].ToString());
                mo_KFB_SETUPCQ.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_CQZDRFDC"].ToString());
                mo_KFB_SETUPCQ.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_CQZDDXDC"].ToString());
                mo_KFB_SETUPCQ.N_BCRFDC = Convert.ToDecimal(this.Request.Form["N_CQBCRFDC"].ToString());
                mo_KFB_SETUPCQ.N_BCDXDC = Convert.ToDecimal(this.Request.Form["N_CQBCDXDC"].ToString());
                mo_KFB_SETUPCQ.N_BCDYDC = Convert.ToDecimal(this.Request.Form["N_CQBCDYDC"].ToString());
                mo_KFB_SETUPCQ.N_BCDSDC = Convert.ToDecimal(this.Request.Form["N_CQBCDSDC"].ToString());
                mo_KFB_SETUPCQ.N_GGDC = Convert.ToDecimal(this.Request.Form["N_CQGGDC"].ToString());
                mo_KFB_SETUPCQ.N_GJDC = Convert.ToDecimal(this.Request.Form["N_CQGJDC"].ToString());
                #endregion


                #region 臺棒
                mo_KFB_SETUPTB.N_RFTY = Convert.ToDecimal(this.Request.Form["N_TBRFTY"].ToString());
                mo_KFB_SETUPTB.N_DXTY = Convert.ToDecimal(this.Request.Form["N_TBDXTY"].ToString());
                mo_KFB_SETUPTB.N_DYTY = Convert.ToDecimal(this.Request.Form["N_TBDYTY"].ToString());
                mo_KFB_SETUPTB.N_DSTY = Convert.ToDecimal(this.Request.Form["N_TBDSTY"].ToString());
                mo_KFB_SETUPTB.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_TBZDRFTY"].ToString());
                mo_KFB_SETUPTB.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_TBZDDXTY"].ToString());
                mo_KFB_SETUPTB.N_SYTY = Convert.ToDecimal(this.Request.Form["N_TBSYTY"].ToString());
                mo_KFB_SETUPTB.N_GGTY = Convert.ToDecimal(this.Request.Form["N_TBGGTY"].ToString());
                mo_KFB_SETUPTB.N_GJTY = Convert.ToDecimal(this.Request.Form["N_TBGJTY"].ToString());
                mo_KFB_SETUPTB.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_TBRFDZ"].ToString());
                mo_KFB_SETUPTB.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_TBDXDZ"].ToString());
                mo_KFB_SETUPTB.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_TBDYDZ"].ToString());
                mo_KFB_SETUPTB.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_TBDSDZ"].ToString());
                mo_KFB_SETUPTB.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_TBZDRFDZ"].ToString());
                mo_KFB_SETUPTB.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_TBZDDXDZ"].ToString());
                mo_KFB_SETUPTB.N_SYDZ = Convert.ToDecimal(this.Request.Form["N_TBSYDZ"].ToString());
                mo_KFB_SETUPTB.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_TBGGDZ"].ToString());
                mo_KFB_SETUPTB.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_TBGJDZ"].ToString());
                mo_KFB_SETUPTB.N_RFDC = Convert.ToDecimal(this.Request.Form["N_TBRFDC"].ToString());
                mo_KFB_SETUPTB.N_DXDC = Convert.ToDecimal(this.Request.Form["N_TBDXDC"].ToString());
                mo_KFB_SETUPTB.N_DYDC = Convert.ToDecimal(this.Request.Form["N_TBDYDC"].ToString());
                mo_KFB_SETUPTB.N_DSDC = Convert.ToDecimal(this.Request.Form["N_TBDSDC"].ToString());
                mo_KFB_SETUPTB.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_TBZDRFDC"].ToString());
                mo_KFB_SETUPTB.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_TBZDDXDC"].ToString());
                mo_KFB_SETUPTB.N_SYDC = Convert.ToDecimal(this.Request.Form["N_TBSYDC"].ToString());
                mo_KFB_SETUPTB.N_GGDC = Convert.ToDecimal(this.Request.Form["N_TBGGDC"].ToString());
                mo_KFB_SETUPTB.N_GJDC = Convert.ToDecimal(this.Request.Form["N_TBGJDC"].ToString());
                #endregion

                #region 指数
                mo_KFB_SETUPZS.N_RFTY = Convert.ToDecimal(this.Request.Form["N_ZSRFTY"].ToString());
                mo_KFB_SETUPZS.N_DXTY = Convert.ToDecimal(this.Request.Form["N_ZSDXTY"].ToString());
                mo_KFB_SETUPZS.N_DYTY = Convert.ToDecimal(this.Request.Form["N_ZSDYTY"].ToString());
                mo_KFB_SETUPZS.N_DSTY = Convert.ToDecimal(this.Request.Form["N_ZSDSTY"].ToString());
                mo_KFB_SETUPZS.N_ZDRFTY = Convert.ToDecimal(this.Request.Form["N_ZSZDRFTY"].ToString());
                mo_KFB_SETUPZS.N_ZDDXTY = Convert.ToDecimal(this.Request.Form["N_ZSZDDXTY"].ToString());
                mo_KFB_SETUPZS.N_SYTY = Convert.ToDecimal(this.Request.Form["N_ZSSYTY"].ToString());
                mo_KFB_SETUPZS.N_GGTY = Convert.ToDecimal(this.Request.Form["N_ZSGGTY"].ToString());
                mo_KFB_SETUPZS.N_GJTY = Convert.ToDecimal(this.Request.Form["N_ZSGJTY"].ToString());
                mo_KFB_SETUPZS.N_RFDZ = Convert.ToDecimal(this.Request.Form["N_ZSRFDZ"].ToString());
                mo_KFB_SETUPZS.N_DXDZ = Convert.ToDecimal(this.Request.Form["N_ZSDXDZ"].ToString());
                mo_KFB_SETUPZS.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_ZSDYDZ"].ToString());
                mo_KFB_SETUPZS.N_DSDZ = Convert.ToDecimal(this.Request.Form["N_ZSDSDZ"].ToString());
                mo_KFB_SETUPZS.N_ZDRFDZ = Convert.ToDecimal(this.Request.Form["N_ZSZDRFDZ"].ToString());
                mo_KFB_SETUPZS.N_ZDDXDZ = Convert.ToDecimal(this.Request.Form["N_ZSZDDXDZ"].ToString());
                mo_KFB_SETUPZS.N_SYDZ = Convert.ToDecimal(this.Request.Form["N_ZSSYDZ"].ToString());
                mo_KFB_SETUPZS.N_GGDZ = Convert.ToDecimal(this.Request.Form["N_ZSGGDZ"].ToString());
                mo_KFB_SETUPZS.N_GJDZ = Convert.ToDecimal(this.Request.Form["N_ZSGJDZ"].ToString());
                mo_KFB_SETUPZS.N_RFDC = Convert.ToDecimal(this.Request.Form["N_ZSRFDC"].ToString());
                mo_KFB_SETUPZS.N_DXDC = Convert.ToDecimal(this.Request.Form["N_ZSDXDC"].ToString());
                mo_KFB_SETUPZS.N_DYDC = Convert.ToDecimal(this.Request.Form["N_ZSDYDC"].ToString());
                mo_KFB_SETUPZS.N_DSDC = Convert.ToDecimal(this.Request.Form["N_ZSDSDC"].ToString());
                mo_KFB_SETUPZS.N_ZDRFDC = Convert.ToDecimal(this.Request.Form["N_ZSZDRFDC"].ToString());
                mo_KFB_SETUPZS.N_ZDDXDC = Convert.ToDecimal(this.Request.Form["N_ZSZDDXDC"].ToString());
                mo_KFB_SETUPZS.N_SYDC = Convert.ToDecimal(this.Request.Form["N_ZSSYDC"].ToString());
                mo_KFB_SETUPZS.N_GGDC = Convert.ToDecimal(this.Request.Form["N_ZSGGDC"].ToString());
                mo_KFB_SETUPZS.N_GJDC = Convert.ToDecimal(this.Request.Form["N_ZSGJDC"].ToString());
                mo_KFB_SETUPZS.N_BDTY = Convert.ToDecimal(this.Request.Form["N_ZSBDTY"].ToString());
                mo_KFB_SETUPZS.N_BDDZ = Convert.ToDecimal(this.Request.Form["N_ZSBDDZ"].ToString());
                mo_KFB_SETUPZS.N_BDDC = Convert.ToDecimal(this.Request.Form["N_ZSBDDC"].ToString());
                #endregion

                #region 赛马
                mo_KFB_SETUPSM.N_DYTY = Convert.ToDecimal(this.Request.Form["N_SMDYTY"].ToString());
                mo_KFB_SETUPSM.N_WZTY = Convert.ToDecimal(this.Request.Form["N_SMWZTY"].ToString());
                mo_KFB_SETUPSM.N_LYTY = Convert.ToDecimal(this.Request.Form["N_SMLYTY"].ToString());
                mo_KFB_SETUPSM.N_WZQTY = Convert.ToDecimal(this.Request.Form["N_SMWZQTY"].ToString());
                mo_KFB_SETUPSM.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_SMDYDZ"].ToString());
                mo_KFB_SETUPSM.N_WZDZ = Convert.ToDecimal(this.Request.Form["N_SMWZDZ"].ToString());
                mo_KFB_SETUPSM.N_LYDZ = Convert.ToDecimal(this.Request.Form["N_SMLYDZ"].ToString());
                mo_KFB_SETUPSM.N_WZQDZ = Convert.ToDecimal(this.Request.Form["N_SMWZQDZ"].ToString());
                mo_KFB_SETUPSM.N_DYDC = Convert.ToDecimal(this.Request.Form["N_SMDYDC"].ToString());
                mo_KFB_SETUPSM.N_WZDC = Convert.ToDecimal(this.Request.Form["N_SMWZDC"].ToString());
                mo_KFB_SETUPSM.N_LYDC = Convert.ToDecimal(this.Request.Form["N_SMLYDC"].ToString());
                mo_KFB_SETUPSM.N_WZQDC = Convert.ToDecimal(this.Request.Form["N_SMWZQDC"].ToString());
                #endregion

                #region 彩票
                mo_KFB_SETUPCP.N_BQTY = Convert.ToDecimal(this.Request.Form["N_CPBQTY"].ToString());
                mo_KFB_SETUPCP.N_LQTY = Convert.ToDecimal(this.Request.Form["N_CPLQTY"].ToString());
                mo_KFB_SETUPCP.N_ZQTY = Convert.ToDecimal(this.Request.Form["N_CPZQTY"].ToString());
                mo_KFB_SETUPCP.N_GSTY = Convert.ToDecimal(this.Request.Form["N_CPGSTY"].ToString());
                mo_KFB_SETUPCP.N_QZTY = Convert.ToDecimal(this.Request.Form["N_CPQZTY"].ToString());
                mo_KFB_SETUPCP.N_BQDZ = Convert.ToDecimal(this.Request.Form["N_CPBQDZ"].ToString());
                mo_KFB_SETUPCP.N_LQDZ = Convert.ToDecimal(this.Request.Form["N_CPLQDZ"].ToString());
                mo_KFB_SETUPCP.N_ZQDZ = Convert.ToDecimal(this.Request.Form["N_CPZQDZ"].ToString());
                mo_KFB_SETUPCP.N_GSDZ = Convert.ToDecimal(this.Request.Form["N_CPGSDZ"].ToString());
                mo_KFB_SETUPCP.N_QZDZ = Convert.ToDecimal(this.Request.Form["N_CPQZDZ"].ToString());
                mo_KFB_SETUPCP.N_BQDC = Convert.ToDecimal(this.Request.Form["N_CPBQDC"].ToString());
                mo_KFB_SETUPCP.N_LQDC = Convert.ToDecimal(this.Request.Form["N_CPLQDC"].ToString());
                mo_KFB_SETUPCP.N_ZQDC = Convert.ToDecimal(this.Request.Form["N_CPZQDC"].ToString());
                mo_KFB_SETUPCP.N_GSDC = Convert.ToDecimal(this.Request.Form["N_CPGSDC"].ToString());
                mo_KFB_SETUPCP.N_QZDC = Convert.ToDecimal(this.Request.Form["N_CPQZDC"].ToString());
                #endregion

                #region 六合彩
                mo_KFB_SETUPLHC.N_TBHTY = Convert.ToDecimal(this.Request.Form["N_LHCTBHTY"].ToString());
                mo_KFB_SETUPLHC.N_TTTY = Convert.ToDecimal(this.Request.Form["N_LHCTTTY"].ToString());
                mo_KFB_SETUPLHC.N_THTY = Convert.ToDecimal(this.Request.Form["N_LHCTHTY"].ToString());
                mo_KFB_SETUPLHC.N_QCPTY = Convert.ToDecimal(this.Request.Form["N_LHCQCPTY"].ToString());
                mo_KFB_SETUPLHC.N_2XTY = Convert.ToDecimal(this.Request.Form["N_LHC2XTY"].ToString());
                mo_KFB_SETUPLHC.N_3XTY = Convert.ToDecimal(this.Request.Form["N_LHC3XTY"].ToString());
                mo_KFB_SETUPLHC.N_4XTY = Convert.ToDecimal(this.Request.Form["N_LHC4XTY"].ToString());
                mo_KFB_SETUPLHC.N_GDDSTY = Convert.ToDecimal(this.Request.Form["N_LHCGDDSTY"].ToString());
                mo_KFB_SETUPLHC.N_GDDXTY = Convert.ToDecimal(this.Request.Form["N_LHCGDDXTY"].ToString());
                mo_KFB_SETUPLHC.N_TBHDZ = Convert.ToDecimal(this.Request.Form["N_LHCTBHDZ"].ToString());
                mo_KFB_SETUPLHC.N_TTDZ = Convert.ToDecimal(this.Request.Form["N_LHCTTDZ"].ToString());
                mo_KFB_SETUPLHC.N_THDZ = Convert.ToDecimal(this.Request.Form["N_LHCTHDZ"].ToString());
                mo_KFB_SETUPLHC.N_QCPDZ = Convert.ToDecimal(this.Request.Form["N_LHCQCPDZ"].ToString());
                mo_KFB_SETUPLHC.N_2XDZ = Convert.ToDecimal(this.Request.Form["N_LHC2XDZ"].ToString());
                mo_KFB_SETUPLHC.N_3XDZ = Convert.ToDecimal(this.Request.Form["N_LHC3XDZ"].ToString());
                mo_KFB_SETUPLHC.N_4XDZ = Convert.ToDecimal(this.Request.Form["N_LHC4XDZ"].ToString());
                mo_KFB_SETUPLHC.N_GDDSDZ = Convert.ToDecimal(this.Request.Form["N_LHCGDDSDZ"].ToString());
                mo_KFB_SETUPLHC.N_GDDXDZ = Convert.ToDecimal(this.Request.Form["N_LHCGDDXDZ"].ToString());
                mo_KFB_SETUPLHC.N_TBHDC = Convert.ToDecimal(this.Request.Form["N_LHCTBHDC"].ToString());
                mo_KFB_SETUPLHC.N_TTDC = Convert.ToDecimal(this.Request.Form["N_LHCTTDC"].ToString());
                mo_KFB_SETUPLHC.N_THDC = Convert.ToDecimal(this.Request.Form["N_LHCTHDC"].ToString());
                mo_KFB_SETUPLHC.N_QCPDC = Convert.ToDecimal(this.Request.Form["N_LHCQCPDC"].ToString());
                mo_KFB_SETUPLHC.N_2XDC = Convert.ToDecimal(this.Request.Form["N_LHC2XDC"].ToString());
                mo_KFB_SETUPLHC.N_3XDC = Convert.ToDecimal(this.Request.Form["N_LHC3XDC"].ToString());
                mo_KFB_SETUPLHC.N_4XDC = Convert.ToDecimal(this.Request.Form["N_LHC4XDC"].ToString());
                mo_KFB_SETUPLHC.N_GDDSDC = Convert.ToDecimal(this.Request.Form["N_LHCGDDSDC"].ToString());
                mo_KFB_SETUPLHC.N_GDDXDC = Convert.ToDecimal(this.Request.Form["N_LHCGDDXDC"].ToString());
                #endregion

                #region 大乐透
                mo_KFB_SETUPDLT.N_TBHTY = Convert.ToDecimal(this.Request.Form["N_DLTTBHTY"].ToString());
                mo_KFB_SETUPDLT.N_TTTY = Convert.ToDecimal(this.Request.Form["N_DLTTTTY"].ToString());
                mo_KFB_SETUPDLT.N_THTY = Convert.ToDecimal(this.Request.Form["N_DLTTHTY"].ToString());
                mo_KFB_SETUPDLT.N_QCPTY = Convert.ToDecimal(this.Request.Form["N_DLTQCPTY"].ToString());
                mo_KFB_SETUPDLT.N_2XTY = Convert.ToDecimal(this.Request.Form["N_DLT2XTY"].ToString());
                mo_KFB_SETUPDLT.N_3XTY = Convert.ToDecimal(this.Request.Form["N_DLT3XTY"].ToString());
                mo_KFB_SETUPDLT.N_4XTY = Convert.ToDecimal(this.Request.Form["N_DLT4XTY"].ToString());
                mo_KFB_SETUPDLT.N_GDDSTY = Convert.ToDecimal(this.Request.Form["N_DLTGDDSTY"].ToString());
                mo_KFB_SETUPDLT.N_GDDXTY = Convert.ToDecimal(this.Request.Form["N_DLTGDDXTY"].ToString());
                mo_KFB_SETUPDLT.N_TBHDZ = Convert.ToDecimal(this.Request.Form["N_DLTTBHDZ"].ToString());
                mo_KFB_SETUPDLT.N_TTDZ = Convert.ToDecimal(this.Request.Form["N_DLTTTDZ"].ToString());
                mo_KFB_SETUPDLT.N_THDZ = Convert.ToDecimal(this.Request.Form["N_DLTTHDZ"].ToString());
                mo_KFB_SETUPDLT.N_QCPDZ = Convert.ToDecimal(this.Request.Form["N_DLTQCPDZ"].ToString());
                mo_KFB_SETUPDLT.N_2XDZ = Convert.ToDecimal(this.Request.Form["N_DLT2XDZ"].ToString());
                mo_KFB_SETUPDLT.N_3XDZ = Convert.ToDecimal(this.Request.Form["N_DLT3XDZ"].ToString());
                mo_KFB_SETUPDLT.N_4XDZ = Convert.ToDecimal(this.Request.Form["N_DLT4XDZ"].ToString());
                mo_KFB_SETUPDLT.N_GDDSDZ = Convert.ToDecimal(this.Request.Form["N_DLTGDDSDZ"].ToString());
                mo_KFB_SETUPDLT.N_GDDXDZ = Convert.ToDecimal(this.Request.Form["N_DLTGDDXDZ"].ToString());
                mo_KFB_SETUPDLT.N_TBHDC = Convert.ToDecimal(this.Request.Form["N_DLTTBHDC"].ToString());
                mo_KFB_SETUPDLT.N_TTDC = Convert.ToDecimal(this.Request.Form["N_DLTTTDC"].ToString());
                mo_KFB_SETUPDLT.N_THDC = Convert.ToDecimal(this.Request.Form["N_DLTTHDC"].ToString());
                mo_KFB_SETUPDLT.N_QCPDC = Convert.ToDecimal(this.Request.Form["N_DLTQCPDC"].ToString());
                mo_KFB_SETUPDLT.N_2XDC = Convert.ToDecimal(this.Request.Form["N_DLT2XDC"].ToString());
                mo_KFB_SETUPDLT.N_3XDC = Convert.ToDecimal(this.Request.Form["N_DLT3XDC"].ToString());
                mo_KFB_SETUPDLT.N_4XDC = Convert.ToDecimal(this.Request.Form["N_DLT4XDC"].ToString());
                mo_KFB_SETUPDLT.N_GDDSDC = Convert.ToDecimal(this.Request.Form["N_DLTGDDSDC"].ToString());
                mo_KFB_SETUPDLT.N_GDDXDC = Convert.ToDecimal(this.Request.Form["N_DLTGDDXDC"].ToString());
                #endregion

                #region 今彩539
                mo_KFB_SETUPJC539.N_QCPTY = Convert.ToDecimal(this.Request.Form["N_JCQCPTY"].ToString());
                mo_KFB_SETUPJC539.N_2XTY = Convert.ToDecimal(this.Request.Form["N_JC2XTY"].ToString());
                mo_KFB_SETUPJC539.N_3XTY = Convert.ToDecimal(this.Request.Form["N_JC3XTY"].ToString());
                mo_KFB_SETUPJC539.N_4XTY = Convert.ToDecimal(this.Request.Form["N_JC4XTY"].ToString());
                mo_KFB_SETUPJC539.N_QCPDZ = Convert.ToDecimal(this.Request.Form["N_JCQCPDZ"].ToString());
                mo_KFB_SETUPJC539.N_2XDZ = Convert.ToDecimal(this.Request.Form["N_JC2XDZ"].ToString());
                mo_KFB_SETUPJC539.N_3XDZ = Convert.ToDecimal(this.Request.Form["N_JC3XDZ"].ToString());
                mo_KFB_SETUPJC539.N_4XDZ = Convert.ToDecimal(this.Request.Form["N_JC4XDZ"].ToString());
                mo_KFB_SETUPJC539.N_QCPDC = Convert.ToDecimal(this.Request.Form["N_JCQCPDC"].ToString());
                mo_KFB_SETUPJC539.N_2XDC = Convert.ToDecimal(this.Request.Form["N_JC2XDC"].ToString());
                mo_KFB_SETUPJC539.N_3XDC = Convert.ToDecimal(this.Request.Form["N_JC3XDC"].ToString());
                mo_KFB_SETUPJC539.N_4XDC = Convert.ToDecimal(this.Request.Form["N_JC4XDC"].ToString());
                #endregion

                #region 時事
                mo_KFB_SETUPSS.N_DYTY = Convert.ToDecimal(this.Request.Form["N_SSDYTY"].ToString());
                mo_KFB_SETUPSS.N_DYDZ = Convert.ToDecimal(this.Request.Form["N_SSDYDZ"].ToString());
                mo_KFB_SETUPSS.N_DYDC = Convert.ToDecimal(this.Request.Form["N_SSDYDC"].ToString());
                #endregion
            }

        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            ShowMsg( "頁面加載失敗");
        }
    }
    /// <summary>
    /// 得到代理商的各球额度
    /// </summary>
    /// <param name="s_N_HYDH">代理商代号</param>
    private void SetDLBall(string s_N_HYDH)
    {
       
        mo_KFB_SETUPCP = objAgentManageAddDB.GetModelCP(s_N_HYDH);
        if (mo_KFB_SETUPCP == null)
            mo_KFB_SETUPCP = new KFB_SETUPCP();
        mo_KFB_SETUPDLT = objAgentManageAddDB.GetModelDLT(s_N_HYDH);
        if (mo_KFB_SETUPDLT == null)
            mo_KFB_SETUPDLT = new KFB_SETUPDLT();
        mo_KFB_SETUPJC539 = objAgentManageAddDB.GetModelJC539(s_N_HYDH);
        if (mo_KFB_SETUPJC539 == null)
            mo_KFB_SETUPJC539 = new KFB_SETUPJC539();
        mo_KFB_SETUPLHC = objAgentManageAddDB.GetModelLHC(s_N_HYDH);
        if (mo_KFB_SETUPLHC == null)
            mo_KFB_SETUPLHC = new KFB_SETUPLHC();
        mo_KFB_SETUPLQ = objAgentManageAddDB.GetModelLQ(s_N_HYDH);
        if (mo_KFB_SETUPLQ == null)
            mo_KFB_SETUPLQ = new KFB_SETUPLQ();
        mo_KFB_SETUPMB = objAgentManageAddDB.GetModelMB(s_N_HYDH);
        if (mo_KFB_SETUPMB == null)
            mo_KFB_SETUPMB = new KFB_SETUPMB();
        mo_KFB_SETUPMQ = objAgentManageAddDB.GetModelMQ(s_N_HYDH);
        if (mo_KFB_SETUPMQ == null)
            mo_KFB_SETUPMQ = new KFB_SETUPMQ();


        mo_KFB_SETUPBQ = objAgentManageAddDB.GetModelBQ(s_N_HYDH);
        if (mo_KFB_SETUPBQ == null)
            mo_KFB_SETUPBQ = new KFB_SETUPBQ();
        mo_KFB_SETUPCQ = objAgentManageAddDB.GetModelCQ(s_N_HYDH);
        if (mo_KFB_SETUPCQ == null)
            mo_KFB_SETUPCQ = new KFB_SETUPCQ();

        mo_KFB_SETUPRB = objAgentManageAddDB.GetModelRB(s_N_HYDH);
        if (mo_KFB_SETUPRB == null)
            mo_KFB_SETUPRB = new KFB_SETUPRB();
        mo_KFB_SETUPSM = objAgentManageAddDB.GetModelSM(s_N_HYDH);
        if (mo_KFB_SETUPSM == null)
            mo_KFB_SETUPSM = new KFB_SETUPSM();
        mo_KFB_SETUPTB = objAgentManageAddDB.GetModelTB(s_N_HYDH);
        if (mo_KFB_SETUPTB == null)
            mo_KFB_SETUPTB = new KFB_SETUPTB();
        mo_KFB_SETUPZQ = objAgentManageAddDB.GetModelZQ(s_N_HYDH);
        if (mo_KFB_SETUPZQ == null)
            mo_KFB_SETUPZQ = new KFB_SETUPZQ();
        mo_KFB_SETUPZS = objAgentManageAddDB.GetModelZS(s_N_HYDH);
        if (mo_KFB_SETUPZS == null)
            mo_KFB_SETUPZS = new KFB_SETUPZS();
        mo_KFB_SETUPSS = objAgentManageAddDB.GetModelSS(s_N_HYDH);
        if (mo_KFB_SETUPSS == null)
            mo_KFB_SETUPSS = new KFB_SETUPSS();
    }
    /// <summary>
    /// 得到会员的各球额度
    /// </summary>
    /// <param name="s_N_HYDH">会员代号</param>
    private void SetHYBall(string s_N_HYDH)
    {

        mo_KFB_SETUPCP1 = objAgentManageAddDB.GetModelCP(s_N_HYDH);
        if (mo_KFB_SETUPCP1 == null)
            mo_KFB_SETUPCP1 = new KFB_SETUPCP();
        mo_KFB_SETUPDLT1 = objAgentManageAddDB.GetModelDLT(s_N_HYDH);
        if (mo_KFB_SETUPDLT1 == null)
            mo_KFB_SETUPDLT1 = new KFB_SETUPDLT();
        mo_KFB_SETUPJC5391 = objAgentManageAddDB.GetModelJC539(s_N_HYDH);
        if (mo_KFB_SETUPJC5391 == null)
            mo_KFB_SETUPJC5391 = new KFB_SETUPJC539();
        mo_KFB_SETUPLHC1 = objAgentManageAddDB.GetModelLHC(s_N_HYDH);
        if (mo_KFB_SETUPLHC1 == null)
            mo_KFB_SETUPLHC1 = new KFB_SETUPLHC();
        mo_KFB_SETUPLQ1 = objAgentManageAddDB.GetModelLQ(s_N_HYDH);
        if (mo_KFB_SETUPLQ1 == null)
            mo_KFB_SETUPLQ1 = new KFB_SETUPLQ();
        mo_KFB_SETUPMB1 = objAgentManageAddDB.GetModelMB(s_N_HYDH);
        if (mo_KFB_SETUPMB1 == null)
            mo_KFB_SETUPMB1 = new KFB_SETUPMB();
        mo_KFB_SETUPMQ1 = objAgentManageAddDB.GetModelMQ(s_N_HYDH);
        if (mo_KFB_SETUPMQ1 == null)
            mo_KFB_SETUPMQ1 = new KFB_SETUPMQ();

        mo_KFB_SETUPBQ1 = objAgentManageAddDB.GetModelBQ(s_N_HYDH);
        if (mo_KFB_SETUPBQ1 == null)
            mo_KFB_SETUPBQ1 = new KFB_SETUPBQ();
        mo_KFB_SETUPCQ1 = objAgentManageAddDB.GetModelCQ(s_N_HYDH);
        if (mo_KFB_SETUPCQ1 == null)
            mo_KFB_SETUPCQ1 = new KFB_SETUPCQ();


        mo_KFB_SETUPRB1 = objAgentManageAddDB.GetModelRB(s_N_HYDH);
        if (mo_KFB_SETUPRB1 == null)
            mo_KFB_SETUPRB1 = new KFB_SETUPRB();
        mo_KFB_SETUPSM1 = objAgentManageAddDB.GetModelSM(s_N_HYDH);
        if (mo_KFB_SETUPSM1 == null)
            mo_KFB_SETUPSM1 = new KFB_SETUPSM();
        mo_KFB_SETUPTB1 = objAgentManageAddDB.GetModelTB(s_N_HYDH);
        if (mo_KFB_SETUPTB1 == null)
            mo_KFB_SETUPTB1 = new KFB_SETUPTB();
        mo_KFB_SETUPZQ1 = objAgentManageAddDB.GetModelZQ(s_N_HYDH);
        if (mo_KFB_SETUPZQ1 == null)
            mo_KFB_SETUPZQ1 = new KFB_SETUPZQ();
        mo_KFB_SETUPZS1 = objAgentManageAddDB.GetModelZS(s_N_HYDH);
        if (mo_KFB_SETUPZS1 == null)
            mo_KFB_SETUPZS1 = new KFB_SETUPZS();
        mo_KFB_SETUPSS1 = objAgentManageAddDB.GetModelSS(s_N_HYDH);
        if (mo_KFB_SETUPSS1 == null)
            mo_KFB_SETUPSS1 = new KFB_SETUPSS();
    }
    /// <summary>
    /// 初始化页面,設定過關下注關數限制
    /// </summary>
    /// <param name="s_N_HYDH">代理商代号</param>
    private void InitPage_N_TOLLGATE(string s_N_HYDH)
    {
        KFB_ZHGL o_KFB_ZHGL_M = new KFB_ZHGL(); 
        o_KFB_ZHGL_M = objAgentManage.GetModel(s_N_HYDH);
        string s_N_TOLLGATE = o_KFB_ZHGL_M.N_TOLLGATE.ToString().Trim();
        int i_N_TOLLGATE = 10;
        if (!s_N_TOLLGATE.Equals("") && !s_N_TOLLGATE.Equals("0"))
            i_N_TOLLGATE = Convert.ToInt32(s_N_TOLLGATE);
        else
            this.drpXiazhuNum.Items.Add(new ListItem("不限制", "0"));
        for (int i = 1; i <= i_N_TOLLGATE; i++)
            this.drpXiazhuNum.Items.Add(new ListItem(i.ToString() + "關", i.ToString()));
        if (!s_N_TOLLGATE.Equals("") && !s_N_TOLLGATE.Equals("0"))
            this.drpXiazhuNum.SelectedValue = Convert.ToString(i_N_TOLLGATE);
        else
            this.drpXiazhuNum.SelectedValue = "0";

        this.rdoLogin.SelectedValue = o_KFB_ZHGL_M.N_YXDL.ToString();
        this.rdoXiazhu.SelectedValue = o_KFB_ZHGL_M.N_YXXZ.ToString();
        //if (Comm.SJYXDL(o_KFB_ZHGL_M.N_DLDH).Equals(false))
        //    this.rdoLogin.Attributes.Add("onclick", "document.getElementsByName('ctl00$ContentPlaceHolder11$rdoLogin')[2].checked=true;");
        //if (Comm.SJYXXZ(o_KFB_ZHGL_M.N_DLDH).Equals(false))
        //    this.rdoXiazhu.Attributes.Add("onclick", "document.getElementsByName('ctl00$ContentPlaceHolder11$rdoXiazhu')[2].checked=true;");

    }
    /// <summary>
    /// 修改时初始化页面
    /// </summary>
    /// <param name="s_aHYZH"></param>
    private void InitPage(string s_aHYZH)
    {

        KFB_HYGL o_KFB_HYGL = this.objAgentManage.GetModelHYGL(s_aHYZH);
        this.lblEndUser.Text = o_KFB_HYGL.N_HYZH;
        this.txtUserName.Value = o_KFB_HYGL.N_HYMC;
        this.txtPwd.Attributes.Add("value", o_KFB_HYGL.N_HYMM);
        this.txtPwdS.Attributes.Add("value", o_KFB_HYGL.N_HYMM);
        this.rdoLogin.SelectedValue = o_KFB_HYGL.N_YXDL.ToString();
        this.rdoXiazhu.SelectedValue = o_KFB_HYGL.N_YXXZ.ToString();
        //if (Comm.SJYXDL(o_KFB_HYGL.N_DLDH).Equals(false))
        //    this.rdoLogin.Attributes.Add("onclick", "document.getElementsByName('ctl00$ContentPlaceHolder11$rdoLogin')[2].checked=true;");
        //if (Comm.SJYXXZ(o_KFB_HYGL.N_DLDH).Equals(false))
        //    this.rdoXiazhu.Attributes.Add("onclick", "document.getElementsByName('ctl00$ContentPlaceHolder11$rdoXiazhu')[2].checked=true;");
        this.txtPay.Value = Convert.ToString(Math.Round(o_KFB_HYGL.N_KYED.Value, 1));
        this.lblPay.Text = this.txtPay.Value;
        this.txtLeftED.Text = Convert.ToString(Math.Round(o_KFB_HYGL.N_SYED.Value, 1));
        this.lbLeftED.Text = this.txtLeftED.Text;
        this.txtDZXX.Value = o_KFB_HYGL.N_DZXX.ToString();
        //是否延遲下注
        for (int i = 0; i < this.chkYSXZ.Items.Count; i++)
        {
            int i_Index = Count(2, i);
            if ((o_KFB_HYGL.N_YCXZ & i_Index) == i_Index)
                this.chkYSXZ.Items[i].Selected = true;
        }
        //比賽類別
        this.chkLQ.Checked = o_KFB_HYGL.N_LQTZ.Equals(1) ? true : false;
        this.chkMB.Checked = o_KFB_HYGL.N_MBTZ.Equals(1) ? true : false;
        this.chkRB.Checked = o_KFB_HYGL.N_RBTZ.Equals(1) ? true : false;
        this.chkTB.Checked = o_KFB_HYGL.N_TBTZ.Equals(1) ? true : false;
        this.chkMQ.Checked = o_KFB_HYGL.N_MZTZ.Equals(1) ? true : false;
        if (o_KFB_HYGL.N_ZQTZ.Equals(0))
        {
            this.chkZQ.Checked = false;
        }
        else
        {
            this.drpPB.Value = o_KFB_HYGL.N_ZQTZ.ToString();
        }
        this.chkZS.Checked = o_KFB_HYGL.N_ZSTZ.Equals(1) ? true : false;
        this.chkLT.Checked = o_KFB_HYGL.N_DLTTZ.Equals(1) ? true : false;
        this.chkCP.Checked = o_KFB_HYGL.N_CPTZ.Equals(1) ? true : false;
        this.chkSM.Checked = o_KFB_HYGL.N_SMTZ.Equals(1) ? true : false;
        this.chkLHC.Checked = o_KFB_HYGL.N_LHCTZ.Equals(1) ? true : false;
        this.chkJC.Checked = o_KFB_HYGL.N_JCTZ.Equals(1) ? true : false;
        this.chkSS.Checked = o_KFB_HYGL.N_SSTZ.Equals(1) ? true : false;


        this.chkBQ.Checked = o_KFB_HYGL.N_BQTZ.Equals(1) ? true : false;
        this.chkCQ.Checked = o_KFB_HYGL.N_CQTZ.Equals(1) ? true : false;

        this.drpSafeType.SelectedValue = o_KFB_HYGL.N_WXDJ.ToString();
        this.drpXiazhuNum.SelectedValue = o_KFB_HYGL.N_TOLLGATE.ToString();
        this.lblLoginTime.Text = o_KFB_HYGL.N_DLSJ.ToString();
        this.lblXIaZhuTime.Text = o_KFB_HYGL.N_XZSJ.ToString();
    }
    /// <summary>
    /// 计算x的y次方的值
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private int Count(int x, int y)
    {
        if (y == 0)
        {
            return 1;
        }
        else
        {
            return x * Count(x, y - 1);
        }
    }
    /// <summary>
    /// 得到會員Model
    /// </summary>
    /// <returns></returns>
    private KFB_HYGL GetKFB_HYGL()
    {
       
        KFB_HYGL o_KFB_HYGL = new KFB_HYGL();
        o_KFB_HYGL.N_DLSJ = DateTime.Now;
        o_KFB_HYGL.N_XZSJ = DateTime.Now;
        o_KFB_HYGL.N_HYIP = Request.ServerVariables["remote_addr"];
        o_KFB_HYGL.N_HYJR = DateTime.Now;
        o_KFB_HYGL.N_CWCS = 0;
        o_KFB_HYGL.N_DZJDH = Convert.ToString(Request.QueryString["N_DZJDH"]);
        o_KFB_HYGL.N_ZJDH = Convert.ToString(Request.QueryString["N_ZJDH"]);
        o_KFB_HYGL.N_DGDDH = Convert.ToString(Request.QueryString["N_DGDDH"]);
        o_KFB_HYGL.N_GDDH = Convert.ToString(Request.QueryString["N_GDDH"]);
        o_KFB_HYGL.N_ZDLDH = Convert.ToString(Request.QueryString["N_ZDLDH"]);
        o_KFB_HYGL.N_DLDH = Convert.ToString(Request.QueryString["N_DLDH"]);
        o_KFB_HYGL.N_HYZH = this.drpEndUser.SelectedValue;
        o_KFB_HYGL.N_SYED = Convert.ToDecimal(this.txtPay.Value);
        if (this.hidMode.Value == "Update")
        {
            o_KFB_HYGL = this.objAgentManage.GetModelHYGL(Request.QueryString["n_hyzh"].ToString());
            o_KFB_HYGL.N_SYED = Convert.ToDecimal(this.txtPay.Value) - o_KFB_HYGL.N_KYED.Value + o_KFB_HYGL.N_SYED.Value;
            //o_KFB_HYGL.N_SYED = Convert.ToDecimal(this.Request.Form["txtLeftED"]);
        }
        else if (this.hidMode.Value == "Modify")
        {
            o_KFB_HYGL = this.objAgentManage.GetModelHYGL(this.lblEndUser.Text);
            o_KFB_HYGL.N_SYED = Convert.ToDecimal(this.txtPay.Value) - o_KFB_HYGL.N_KYED.Value + o_KFB_HYGL.N_SYED.Value;
            //o_KFB_HYGL.N_SYED = Convert.ToDecimal(this.Request.Form["txtLeftED"]);
        }
        o_KFB_HYGL.N_XGSJ = DateTime.Now;
        o_KFB_HYGL.N_HYMC = this.txtUserName.Value;
        if (!this.txtPwd.Text.Equals("******"))
        {
            string strMD5 = FormsAuthPasswordFormat.MD5.ToString();
            this.txtPwd.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtPwd.Text.ToUpper(), strMD5).ToUpper();
            o_KFB_HYGL.N_HYMM = this.txtPwd.Text;
        }
        o_KFB_HYGL.N_YXDL = Convert.ToInt32(this.rdoLogin.SelectedValue);
        o_KFB_HYGL.N_YXXZ = Convert.ToInt32(this.rdoXiazhu.SelectedValue);
        o_KFB_HYGL.N_KYED = Convert.ToDecimal(this.txtPay.Value);
        o_KFB_HYGL.N_DZXX = Convert.ToDecimal(this.txtDZXX.Value);
        //是否延遲下注
        int i_Count = 0;
        for (int i = 0; i < this.chkYSXZ.Items.Count; i++)
        {
            if (chkYSXZ.Items[i].Selected)
            {
                i_Count += Convert.ToInt32(chkYSXZ.Items[i].Value);
            }
        }
        o_KFB_HYGL.N_YCXZ = i_Count;
        //比賽類別
        o_KFB_HYGL.N_LQTZ = this.chkLQ.Checked ? 1 : 0;
        o_KFB_HYGL.N_MBTZ = this.chkMB.Checked ? 1 : 0;
        o_KFB_HYGL.N_RBTZ = this.chkRB.Checked ? 1 : 0;
        o_KFB_HYGL.N_TBTZ = this.chkTB.Checked ? 1 : 0;
        o_KFB_HYGL.N_MZTZ = this.chkMQ.Checked ? 1 : 0;

        o_KFB_HYGL.N_BQTZ = this.chkBQ.Checked ? 1 : 0;
        o_KFB_HYGL.N_CQTZ = this.chkCQ.Checked ? 1 : 0;

        if (this.chkZQ.Checked)
        {
            o_KFB_HYGL.N_ZQTZ = Convert.ToInt32(this.drpPB.Value);
        }
        else
        {
            o_KFB_HYGL.N_ZQTZ = 0;
        }
        o_KFB_HYGL.N_ZSTZ = this.chkZS.Checked ? 1 : 0;
        o_KFB_HYGL.N_DLTTZ = this.chkLT.Checked ? 1 : 0;
        o_KFB_HYGL.N_CPTZ = this.chkCP.Checked ? 1 : 0;
        o_KFB_HYGL.N_SMTZ = this.chkSM.Checked ? 1 : 0;
        o_KFB_HYGL.N_LHCTZ = this.chkLHC.Checked ? 1 : 0;
        o_KFB_HYGL.N_JCTZ = this.chkJC.Checked ? 1 : 0;
        o_KFB_HYGL.N_SSTZ = this.chkSS.Checked ? 1 : 0;
        o_KFB_HYGL.N_WXDJ = Convert.ToInt32(this.drpSafeType.SelectedValue);
        o_KFB_HYGL.N_TOLLGATE = Convert.ToInt32(this.drpXiazhuNum.SelectedValue);
        o_KFB_HYGL.N_TKYZM = "";                    //新提款验证码
        o_KFB_HYGL.N_HBDM = "RMB";                  //货币代码
        o_KFB_HYGL.N_DHHM = "";                     //电话号码
        o_KFB_HYGL.N_MAIL = "";                     //email
        o_KFB_HYGL.N_QQ = "";                       //qq
        o_KFB_HYGL.N_DLZH = "";                     //代理
        o_KFB_HYGL.N_SFSW = "N";
        /********************************新增性別，生日，國家，安全提問**********************************/
        o_KFB_HYGL.N_SEX = "0";
        o_KFB_HYGL.N_BIRTHDAY =DateTime.Now;
        o_KFB_HYGL.N_COUNTRY = "";
        o_KFB_HYGL.N_ANSWER = "";
        o_KFB_HYGL.N_ASK = "";
        /********************************新增性別，生日，國家，安全提問**********************************/
        return o_KFB_HYGL;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            mo_Ht.Clear();

            this.txtDLSED.Text = this.objHYGL.GetDLSED(this.lblDLS.Text).ToString();
            if (this.hidMode.Value == "Update" || this.hidMode.Value == "Modify")
            {
                if (objHYGL.Exists(this.lblEndUser.Text))
                {
                    KFB_HYGL o_KFB_HYGL = this.objAgentManage.GetModelHYGL(this.lblEndUser.Text);
                    this.lbLeftED.Text = o_KFB_HYGL.N_SYED.ToString();
                    this.lblPay.Text = o_KFB_HYGL.N_KYED.ToString();
                    if (Convert.ToDecimal(this.txtPay.Value) > (Convert.ToDecimal(txtDLSED.Text) + Convert.ToDecimal(lblPay.Text)))
                    {
                        ShowMsg("分配的信用额度不能大于所属代理商的信用额度" + Convert.ToString(Convert.ToDecimal(txtDLSED.Text) + Convert.ToDecimal(lblPay.Text)) + "萬!");
                    }
                    else if (Convert.ToDecimal(this.txtPay.Value) < Convert.ToDecimal(lblPay.Text) - Convert.ToDecimal(lbLeftED.Text))
                    {
                        ShowMsg("分配的信用额度不能小于額度" + Convert.ToString(Convert.ToDecimal(lblPay.Text) - Convert.ToDecimal(lbLeftED.Text)) + "萬!");
                    }
                    else
                    {
                        mo_KFB_SETUPCP.N_HYDH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateCP(mo_KFB_SETUPCP, mo_Ht);
                        mo_KFB_SETUPDLT.N_HYDH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateDLT(mo_KFB_SETUPDLT, mo_Ht);
                        mo_KFB_SETUPJC539.N_HYDH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateJC539(mo_KFB_SETUPJC539, mo_Ht);
                        mo_KFB_SETUPLHC.N_HYDH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateLHC(mo_KFB_SETUPLHC, mo_Ht);
                        mo_KFB_SETUPLQ.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateLQ(mo_KFB_SETUPLQ, mo_Ht);
                        mo_KFB_SETUPMB.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateMB(mo_KFB_SETUPMB, mo_Ht);
                        mo_KFB_SETUPMQ.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateMQ(mo_KFB_SETUPMQ, mo_Ht);
                        mo_KFB_SETUPRB.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateRB(mo_KFB_SETUPRB, mo_Ht);
                        mo_KFB_SETUPSM.N_HYDH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateSM(mo_KFB_SETUPSM, mo_Ht);
                        mo_KFB_SETUPTB.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateTB(mo_KFB_SETUPTB, mo_Ht);
                        mo_KFB_SETUPZQ.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateZQ(mo_KFB_SETUPZQ, mo_Ht);
                        mo_KFB_SETUPZS.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateZS(mo_KFB_SETUPZS, mo_Ht);
                        mo_KFB_SETUPSS.N_HYDH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateSS(mo_KFB_SETUPSS, mo_Ht);
                        mo_KFB_SETUPBQ.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateBQ(mo_KFB_SETUPBQ, mo_Ht);
                        mo_KFB_SETUPCQ.N_HYZH = this.lblEndUser.Text;
                        this.objAgentManage.UpdateCQ(mo_KFB_SETUPCQ, mo_Ht);

                        this.objXZHYDB.Update(GetKFB_HYGL(), mo_Ht);
                        this.objXZHYDB.SetDLSED(Request.QueryString["n_dldh"], Convert.ToDecimal(txtPay.Value) - Convert.ToDecimal(lblPay.Text), mo_Ht);
                        this.objAgentManage.SetTran(mo_Ht);
                        ShowMsg("修改成功");
                        this.lblPay.Text = this.txtPay.Value;
                        this.lbLeftED.Text = this.txtLeftED.Text;
                    }
                }
                else
                {
                    btnBack_Click(sender, e);
                    ShowAndBaseRedirect("00000", "不存在會員" + this.lblEndUser.Text + "，請重新選擇會員新增！！"
                        , String.Format("xzhy.aspx?n_hyzh={0}&n_dldh={1}&n_zdldh={2}&n_gddh={3}&n_dgddh={4}&n_zjdh={5}&n_dzjdh={6}", this.lblEndUser.Text, Request.QueryString["n_dldh"], Request.QueryString["n_zdldh"], Request.QueryString["n_gddh"], Request.QueryString["n_dgddh"], Request.QueryString["n_zjdh"], Request.QueryString["n_dzjdh"]));
                }
            }
            else
            {
                if (!objHYGL.Exists(this.drpEndUser.SelectedValue))
                {
                    if (Convert.ToDecimal(this.txtPay.Value) <= Convert.ToDecimal(this.txtDLSED.Text))
                    {
                        objHYGL.DeleteALL(this.drpEndUser.SelectedValue, mo_Ht);
                        objHYGL.SetTran(mo_Ht);
                        mo_Ht.Clear();
                        mo_KFB_SETUPCP.N_HYDH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddCP(mo_KFB_SETUPCP, mo_Ht);
                        mo_KFB_SETUPDLT.N_HYDH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddDLT(mo_KFB_SETUPDLT, mo_Ht);
                        mo_KFB_SETUPJC539.N_HYDH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddJC539(mo_KFB_SETUPJC539, mo_Ht);
                        mo_KFB_SETUPLHC.N_HYDH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddLHC(mo_KFB_SETUPLHC, mo_Ht);
                        mo_KFB_SETUPLQ.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddLQ(mo_KFB_SETUPLQ, mo_Ht);
                        mo_KFB_SETUPMB.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddMB(mo_KFB_SETUPMB, mo_Ht);
                        mo_KFB_SETUPMQ.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddMQ(mo_KFB_SETUPMQ, mo_Ht);
                        mo_KFB_SETUPRB.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddRB(mo_KFB_SETUPRB, mo_Ht);
                        mo_KFB_SETUPSM.N_HYDH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddSM(mo_KFB_SETUPSM, mo_Ht);
                        mo_KFB_SETUPTB.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddTB(mo_KFB_SETUPTB, mo_Ht);
                        mo_KFB_SETUPZQ.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddZQ(mo_KFB_SETUPZQ, mo_Ht);
                        mo_KFB_SETUPZS.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddZS(mo_KFB_SETUPZS, mo_Ht);
                        mo_KFB_SETUPSS.N_HYDH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddSS(mo_KFB_SETUPSS, mo_Ht);


                        mo_KFB_SETUPBQ.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddBQ(mo_KFB_SETUPBQ, mo_Ht);
                        mo_KFB_SETUPCQ.N_HYZH = this.drpEndUser.SelectedValue;
                        objXZHYDB.AddCQ(mo_KFB_SETUPCQ, mo_Ht);

                        objHYGL.Add(GetKFB_HYGL(), mo_Ht);
                        objHYGL.SetDLSED(Request.QueryString["n_dldh"], Convert.ToDecimal(txtPay.Value), mo_Ht);
                        objHYGL.SetTran(mo_Ht);
                        ShowMsg("新增成功");
                        this.hidMode.Value = "Modify";
                        this.btnSave.Text = "修改會員";
                        this.tr_add.Visible = false;
                        this.lblEndUser.Visible = true;
                        this.drpEndUser.Visible = false;
                        this.lblEndUser.Text = this.drpEndUser.SelectedValue;
                        this.lblPay.Text = this.txtPay.Value;
                        this.txtLeftED.Text = this.txtPay.Value;
                        this.lbLeftED.Text = this.txtLeftED.Text;
                    }
                    else
                    {
                        ShowMsg("分配的信用額度不可以大於所屬代理商的額度" + this.txtDLSED.Text);
                    }
                }
                else
                {
                    //ShowMsg( "已存在會員" + this.drpEndUser.SelectedValue + "，請重新選擇會員新增！！");
                    ShowAndBaseRedirect("00000", "已存在會員" + this.lblEndUser.Text + "，請重新選擇會員新增！！"
                        , String.Format("xzhy.aspx?n_hyzh={0}&n_dldh={1}&n_zdldh={2}&n_gddh={3}&n_dgddh={4}&n_zjdh={5}&n_dzjdh={6}", this.lblEndUser.Text, Request.QueryString["n_dldh"], Request.QueryString["n_zdldh"], Request.QueryString["n_gddh"], Request.QueryString["n_dgddh"], Request.QueryString["n_zjdh"], Request.QueryString["n_dzjdh"]));
                }
            }
            SetHYBall(Request.QueryString["n_dldh"].ToString());

        }
        catch (Exception ex)
        {

            this.WriteLog(ex.ToString());
            ex.ToString();
            ShowMsg( "保存失敗!<br>" + ex.Message + "<br>" + ex.StackTrace);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("hygl.aspx?n_hyzh={0}&n_dldh={1}&n_zdldh={2}&n_gddh={3}&n_dgddh={4}&n_zjdh={5}&n_dzjdh={6}",
            this.lblEndUser.Text,
            Convert.ToString(Request.QueryString["N_DLDH"]),
            Convert.ToString(Request.QueryString["N_ZDLDH"]),
            Convert.ToString(Request.QueryString["N_GDDH"]),
            Convert.ToString(Request.QueryString["N_DGDDH"]),
            Convert.ToString(Request.QueryString["N_ZJDH"]),
            Convert.ToString(Request.QueryString["N_DZJDH"])));
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

        this.txtDLSED.Text = this.objHYGL.GetDLSED(this.lblDLS.Text).ToString();
        if (this.hidMode.Value == "Update" || this.hidMode.Value == "Modify")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ED", "document.getElementById('spnSed').style.display='';document.getElementById('spnLeftED').style.display='';document.getElementById('trTime').style.display='';", true);
            this.btnZD.Visible = true;
            this.btnCopy.Visible = true;
            this.txtPwd.Attributes.Add("Value", "******");
            this.txtPwdS.Attributes.Add("Value", "******");
            this.txtPay.Attributes.Add("onblur", "return checkED(this,'" + this.hidMode.Value + "');");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ED", "document.getElementById('spnSed').style.display='none';document.getElementById('spnLeftED').style.display='none';document.getElementById('trTime').style.display='none';", true);
            this.btnZD.Visible = false;
            this.btnCopy.Visible = false;
            this.txtPay.Attributes.Add("onblur", "return checkED(this);");
        }

        if (Comm.GetFlag(this.mUserID) == "1")
        {
            btnCopy.Visible = false;
            btnSave.Visible = false;
            btnZD.Visible = false;
        }
    }
    protected void btnZD_Click(object sender, EventArgs e)
    {
        
        mo_Ht.Clear();
        int i_Count = this.objAgentManage.GetZD(this.lblEndUser.Text);
        int i_OCount = objAgentManage.GetOZD(this.lblEndUser.Text);
        i_Count = i_Count + i_OCount;

        DataSet ds = objHYGL.GetListCASH("N_HYZH='" + this.lblEndUser.Text + "'");
        if (i_Count > 0)
        {
            ShowMsg( "本賬號已有" + i_Count + "筆注單,無法刪除");
        }
        else if (ds.Tables[0].Rows.Count > 0)
        {
            ShowMsg( "本賬號已有現金流操作,無法刪除");
        }
        else if (objHYGL.Exists(this.lblEndUser.Text))
        {
            objHYGL.DeleteALL(this.lblEndUser.Text, mo_Ht);
          objHYGL.SetDLSED(Request.QueryString["n_dldh"], -Convert.ToDecimal(lbLeftED.Text), mo_Ht);
          objHYGL.SetTran(mo_Ht);
            btnBack_Click(sender, e);
        }
        else
        {
            ShowMsg( "本賬號已經刪除");
        }
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        btnBack_Click(sender, e);
    }


    }
