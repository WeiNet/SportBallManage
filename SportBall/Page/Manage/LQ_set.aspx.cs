using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class LQ_set :BasePage
    {
        AgentManageDB objAgentManageDB = new AgentManageDB();
        AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
        KFB_HYGLDB objHYGL = new KFB_HYGLDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetUI();
        }

        #region "屬性"
        public string GetUser
        {
            get
            {
                if (this.Request["UserName"] != null && this.Request["UserName"].ToString() != "")
                    return this.Request["UserName"].ToString();
                else
                    return "";
            }
        }
        #endregion

        #region"按鈕事件"

        /// <summary>
        /// 保存按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region"修改籃球設定檔"
                KFB_SETUPLQ mo_lq = new KFB_SETUPLQ();
                Hashtable GetSql = new Hashtable();
                KFB_ZHGL mo_zhgl = new KFB_ZHGL();
                mo_zhgl = this.objAgentManageDB.GetModel(this.lblName.Text.ToString().Trim());

                mo_lq.N_HYZH = this.lblName.Text;
                mo_lq.N_RFTY = Convert.ToDecimal(this.drptyrf.SelectedValue.ToString());
                mo_lq.N_RFDZ = Convert.ToDecimal(this.txtdzrf.Text);
                mo_lq.N_RFDC = Convert.ToDecimal(this.txtdcrf.Text);
                mo_lq.N_RFDD = Convert.ToDecimal(this.txtddrf.Text);

                mo_lq.N_DXTY = Convert.ToDecimal(this.drptydx.SelectedValue.ToString());
                mo_lq.N_DXDZ = Convert.ToDecimal(this.txtdzdx.Text);
                mo_lq.N_DXDC = Convert.ToDecimal(this.txtdcdx.Text);
                mo_lq.N_DXDD = Convert.ToDecimal(this.txtdddx.Text);

                mo_lq.N_DYTY = Convert.ToDecimal(this.drptydy.SelectedValue.ToString());
                mo_lq.N_DYDZ = Convert.ToDecimal(this.txtdzdy.Text);
                mo_lq.N_DYDC = Convert.ToDecimal(this.txtdcdy.Text);
                mo_lq.N_DYDD = Convert.ToDecimal(this.txtdddy.Text);

                mo_lq.N_DSTY = Convert.ToDecimal(this.drptyds.SelectedValue.ToString());
                mo_lq.N_DSDZ = Convert.ToDecimal(this.txtdzds.Text);
                mo_lq.N_DSDC = Convert.ToDecimal(this.txtdcds.Text);
                mo_lq.N_DSDD = Convert.ToDecimal(this.txtddds.Text);

                mo_lq.N_ZDRFTY = Convert.ToDecimal(this.drptyzdrf.SelectedValue.ToString());
                mo_lq.N_ZDRFDZ = Convert.ToDecimal(this.txtdzzdrf.Text);
                mo_lq.N_ZDRFDC = Convert.ToDecimal(this.txtdczdrf.Text);
                mo_lq.N_ZDRFDD = Convert.ToDecimal(this.txtddzdrf.Text);

                mo_lq.N_ZDDXTY = Convert.ToDecimal(this.drptyzddx.SelectedValue.ToString());
                mo_lq.N_ZDDXDZ = Convert.ToDecimal(this.txtdzzddx.Text);
                mo_lq.N_ZDDXDC = Convert.ToDecimal(this.txtdczddx.Text);
                mo_lq.N_ZDDXDD = Convert.ToDecimal(this.txtddzddx.Text);

                mo_lq.N_BCRFTY = Convert.ToDecimal(this.drptybcrf.SelectedValue.ToString());
                mo_lq.N_BCRFDZ = Convert.ToDecimal(this.txtdzbcrf.Text);
                mo_lq.N_BCRFDC = Convert.ToDecimal(this.txtdcbcrf.Text);
                mo_lq.N_BCRFDD = Convert.ToDecimal(this.txtddbcrf.Text);

                mo_lq.N_BCDXTY = Convert.ToDecimal(this.drptybcdx.SelectedValue.ToString());
                mo_lq.N_BCDXDZ = Convert.ToDecimal(this.txtdzbcdx.Text);
                mo_lq.N_BCDXDC = Convert.ToDecimal(this.txtdcbcdx.Text);
                mo_lq.N_BCDXDD = Convert.ToDecimal(this.txtddbcdx.Text);

                mo_lq.N_BCDYTY = Convert.ToDecimal(this.drptybcdy.SelectedValue.ToString());
                mo_lq.N_BCDYDZ = Convert.ToDecimal(this.txtdzbcdy.Text);
                mo_lq.N_BCDYDC = Convert.ToDecimal(this.txtdcbcdy.Text);
                mo_lq.N_BCDYDD = Convert.ToDecimal(this.txtddbcdy.Text);

                mo_lq.N_BCDSTY = Convert.ToDecimal(this.drptybcds.SelectedValue.ToString());
                mo_lq.N_BCDSDZ = Convert.ToDecimal(this.txtdzbcds.Text);
                mo_lq.N_BCDSDC = Convert.ToDecimal(this.txtdcbcds.Text);
                mo_lq.N_BCDSDD = Convert.ToDecimal(this.txtddbcds.Text);

                mo_lq.N_GGTY = Convert.ToDecimal(this.drptygg.SelectedValue.ToString());
                mo_lq.N_GGDZ = Convert.ToDecimal(this.txtdzgg.Text);
                mo_lq.N_GGDC = Convert.ToDecimal(this.txtdcgg.Text);
                mo_lq.N_GGDD = Convert.ToDecimal(this.txtddgg.Text);

                mo_lq.N_GJTY = Convert.ToDecimal(this.drptygj.SelectedValue.ToString());
                mo_lq.N_GJDZ = Convert.ToDecimal(this.txtdzgj.Text);
                mo_lq.N_GJDC = Convert.ToDecimal(this.txtdcgj.Text);
                mo_lq.N_GJDD = Convert.ToDecimal(this.txtddgj.Text);

                mo_lq.N_DJRFTY = Convert.ToDecimal(this.drptydjrf.SelectedValue.ToString());
                mo_lq.N_DJRFDZ = Convert.ToDecimal(this.txtdzdjrf.Text);
                mo_lq.N_DJRFDC = Convert.ToDecimal(this.txtdcdjrf.Text);
                mo_lq.N_DJRFDD = Convert.ToDecimal(this.txtdddjrf.Text);

                mo_lq.N_DJDXTY = Convert.ToDecimal(this.drptydjdx.SelectedValue.ToString());
                mo_lq.N_DJDXDZ = Convert.ToDecimal(this.txtdzdjdx.Text);
                mo_lq.N_DJDXDC = Convert.ToDecimal(this.txtdcdjdx.Text);
                mo_lq.N_DJDXDD = Convert.ToDecimal(this.txtdddjdx.Text);

                mo_lq.N_DJDSTY = Convert.ToDecimal(this.drptydjds.SelectedValue.ToString());
                mo_lq.N_DJDSDZ = Convert.ToDecimal(this.txtdzdjds.Text);
                mo_lq.N_DJDSDC = Convert.ToDecimal(this.txtdcdjds.Text);
                mo_lq.N_DJDSDD = Convert.ToDecimal(this.txtdddjds.Text);

                this.objAgentManageDB.UpdateLQ(mo_lq, GetSql);
                this.objAgentManageDB.Update(GetSql);
                #endregion

                #region"修改下綫"
                string strhidvalue = this.hidvalue.Value;
                string strZH = "";
                string strFlag = "";
                DataSet getds = new DataSet();
                if (strhidvalue.IndexOf(":") > -1)
                {
                    //取出所有會員
                    if (mo_zhgl.N_HYDJ.ToString() != "9")//取得下屬帳號
                    {
                        getds = this.objAgentManageDB.GetZH(mo_zhgl.N_HYDJ.ToString(), this.lblName.Text);
                        if (getds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < getds.Tables[0].Rows.Count; i++)
                            {
                                strZH = strZH + strFlag + "'" + getds.Tables[0].Rows[i]["n_hyzh"].ToString() + "'";
                                strFlag = ",";
                            }
                        }
                    }
                    getds = this.objAgentManageDB.GetHYZH(mo_zhgl.N_HYDJ.ToString(), this.lblName.Text);//取得下屬會員
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
                             this.objAgentManageDB.Update("lq", strvalue[0].ToString(), strvalue[1].ToString(), strZH);
                        }
                    }
                }
                #endregion


                this.ShowMsg("修改成功！");
            }
            catch (Exception ex)
            {
                this.ShowMsg("修改失败请联系管理员！");
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, true);
        }

        #endregion

        #region"自定義事件"

        /// <summary>
        /// 查詢帳號本身的設定
        /// </summary>
        public void SetUI()
        {

            KFB_SETUPLQ mo_ZQ = this.objAgentManageAddDB.GetModelLQ(this.GetUser);
            this.txtdzrf.Text = mo_ZQ.N_RFDZ.ToString();
            this.txtdcrf.Text = mo_ZQ.N_RFDC.ToString();
            this.txtddrf.Text = mo_ZQ.N_RFDD.ToString();
            this.txtdzdx.Text = mo_ZQ.N_DXDZ.ToString();
            this.txtdcdx.Text = mo_ZQ.N_DXDC.ToString();
            this.txtdddx.Text = mo_ZQ.N_DXDD.ToString();
            this.txtdzdy.Text = mo_ZQ.N_DYDZ.ToString();
            this.txtdcdy.Text = mo_ZQ.N_DYDC.ToString();
            this.txtdddy.Text = mo_ZQ.N_DYDD.ToString();
            this.txtdzds.Text = mo_ZQ.N_DSDZ.ToString();
            this.txtdcds.Text = mo_ZQ.N_DSDC.ToString();
            this.txtddds.Text = mo_ZQ.N_DSDD.ToString();
            this.txtdzzdrf.Text = mo_ZQ.N_ZDRFDZ.ToString();
            this.txtdczdrf.Text = mo_ZQ.N_ZDRFDC.ToString();
            this.txtddzdrf.Text = mo_ZQ.N_ZDRFDD.ToString();
            this.txtdzzddx.Text = mo_ZQ.N_ZDDXDZ.ToString();
            this.txtdczddx.Text = mo_ZQ.N_ZDDXDC.ToString();
            this.txtddzddx.Text = mo_ZQ.N_ZDDXDD.ToString();
            this.txtdzbcrf.Text = mo_ZQ.N_BCRFDZ.ToString();
            this.txtdcbcrf.Text = mo_ZQ.N_BCRFDC.ToString();
            this.txtddbcrf.Text = mo_ZQ.N_BCRFDD.ToString();
            this.txtdzbcdx.Text = mo_ZQ.N_BCDXDZ.ToString();
            this.txtdcbcdx.Text = mo_ZQ.N_BCDXDC.ToString();
            this.txtddbcdx.Text = mo_ZQ.N_BCDXDD.ToString();
            this.txtdzbcdy.Text = mo_ZQ.N_BCDYDZ.ToString();
            this.txtdcbcdy.Text = mo_ZQ.N_BCDYDC.ToString();
            this.txtddbcdy.Text = mo_ZQ.N_BCDYDD.ToString();
            this.txtdzbcds.Text = mo_ZQ.N_BCDSDZ.ToString();
            this.txtdcbcds.Text = mo_ZQ.N_BCDSDC.ToString();
            this.txtddbcds.Text = mo_ZQ.N_BCDSDD.ToString();
            this.txtdzgg.Text = mo_ZQ.N_GGDZ.ToString();
            this.txtdcgg.Text = mo_ZQ.N_GGDC.ToString();
            this.txtddgg.Text = mo_ZQ.N_GGDD.ToString();
            this.txtdzgj.Text = mo_ZQ.N_GJDZ.ToString();
            this.txtdcgj.Text = mo_ZQ.N_GJDC.ToString();
            this.txtddgj.Text = mo_ZQ.N_GJDD.ToString();
            this.txtdzdjrf.Text = mo_ZQ.N_DJRFDZ.ToString();
            this.txtdcdjrf.Text = mo_ZQ.N_DJRFDC.ToString();
            this.txtdddjrf.Text = mo_ZQ.N_DJRFDD.ToString();
            this.txtdzdjdx.Text = mo_ZQ.N_DJDXDZ.ToString();
            this.txtdcdjdx.Text = mo_ZQ.N_DJDXDC.ToString();
            this.txtdddjdx.Text = mo_ZQ.N_DJDXDD.ToString();
            this.txtdzdjds.Text = mo_ZQ.N_DJDSDZ.ToString();
            this.txtdcdjds.Text = mo_ZQ.N_DJDSDC.ToString();
            this.txtdddjds.Text = mo_ZQ.N_DJDSDD.ToString();



            KFB_ZHGL mo_zhgl = new KFB_ZHGL(); 
            mo_zhgl = this.objAgentManageDB.GetModel(this.GetUser);
            if (mo_zhgl == null)
            {
              
                KFB_HYGL mo_hygl = this.objHYGL.GetModel(this.GetUser);
                this.ZHFZ(mo_hygl.N_HYZH.ToString(), "10");
                this.lblName.Text = mo_hygl.N_HYZH.ToString();
                this.lblRealName.Text = mo_hygl.N_HYMC.ToString();
                this.lblDJ.Text = "會員";
            }
            else
            {
                if (mo_zhgl.N_HYDJ.ToString() != "4")
                    this.ZHFZ(mo_zhgl.N_HYZH.ToString(), mo_zhgl.N_HYDJ.ToString());
                else
                    this.DZJFZ();
                this.lblName.Text = mo_zhgl.N_HYZH.ToString();
                this.lblRealName.Text = mo_zhgl.N_HYMC.ToString();
                this.lblDJ.Text = Comm.GetLvName(mo_zhgl.N_HYDJ.ToString());
                GetSUB(mo_zhgl.N_HYDJ.ToString(), mo_zhgl.N_HYZH.ToString());
            }

            this.drptyrf.SelectedValue = mo_ZQ.N_RFTY.ToString();
            this.drptydx.SelectedValue = mo_ZQ.N_DXTY.ToString();
            this.drptydy.SelectedValue = mo_ZQ.N_DYTY.ToString();
            this.drptyds.SelectedValue = mo_ZQ.N_DSTY.ToString();
            this.drptyzdrf.SelectedValue = mo_ZQ.N_ZDRFTY.ToString();
            this.drptyzddx.SelectedValue = mo_ZQ.N_ZDDXTY.ToString();
            this.drptybcrf.SelectedValue = mo_ZQ.N_BCRFTY.ToString();
            this.drptybcdx.SelectedValue = mo_ZQ.N_BCDXTY.ToString();
            this.drptybcdy.SelectedValue = mo_ZQ.N_BCDYTY.ToString();
            this.drptygg.SelectedValue = mo_ZQ.N_GGTY.ToString();
            this.drptygj.SelectedValue = mo_ZQ.N_GJTY.ToString();

            this.drptyrf.SelectedValue = mo_ZQ.N_RFTY.ToString();
            this.drptybcds.SelectedValue = mo_ZQ.N_BCDSTY.ToString();
            this.drptydjrf.SelectedValue = mo_ZQ.N_DJRFTY.ToString();
            this.drptydjdx.SelectedValue = mo_ZQ.N_DJDXTY.ToString();
            this.drptydjds.SelectedValue = mo_ZQ.N_DJDSTY.ToString();
        }

        /// <summary>
        /// 大總監上級帳號賦值（大總監默認拆賬）
        /// </summary>
        public void DZJFZ()
        {

    
            KFB_MRZJ mo_mrzj = new KFB_MRZJ();
            mo_mrzj = this.objAgentManageAddDB.GetModel();

            this.lbdzrf.Text = mo_mrzj.N_LQRFDZ.ToString();
            this.lbdcrf.Text = mo_mrzj.N_LQRFDC.ToString();
            this.lbddrf.Text = mo_mrzj.N_LQRFDD.ToString();
            this.lbdzdx.Text = mo_mrzj.N_LQDXDZ.ToString();
            this.lbdcdx.Text = mo_mrzj.N_LQDXDC.ToString();
            this.lbdddx.Text = mo_mrzj.N_LQDXDD.ToString();
            this.lbdzdy.Text = mo_mrzj.N_LQDYDZ.ToString();
            this.lbdcdy.Text = mo_mrzj.N_LQDYDC.ToString();
            this.lbdddy.Text = mo_mrzj.N_LQDYDD.ToString();
            this.lbdzds.Text = mo_mrzj.N_LQDSDZ.ToString();
            this.lbdcds.Text = mo_mrzj.N_LQDSDC.ToString();
            this.lbddds.Text = mo_mrzj.N_LQDSDD.ToString();
            this.lbdzzdrf.Text = mo_mrzj.N_LQZDRFDZ.ToString();
            this.lbdczdrf.Text = mo_mrzj.N_LQZDRFDC.ToString();
            this.lbddzdrf.Text = mo_mrzj.N_LQZDRFDD.ToString();
            this.lbdzzddx.Text = mo_mrzj.N_LQZDDXDZ.ToString();
            this.lbdczddx.Text = mo_mrzj.N_LQZDDXDC.ToString();
            this.lbddzddx.Text = mo_mrzj.N_LQZDDXDD.ToString();
            this.lbdzbcrf.Text = mo_mrzj.N_LQBCRFDZ.ToString();
            this.lbdcbcrf.Text = mo_mrzj.N_LQBCRFDC.ToString();
            this.lbddbcrf.Text = mo_mrzj.N_LQBCRFDD.ToString();
            this.lbdzbcdx.Text = mo_mrzj.N_LQBCDXDZ.ToString();
            this.lbdcbcdx.Text = mo_mrzj.N_LQBCDXDC.ToString();
            this.lbddbcdx.Text = mo_mrzj.N_LQBCDXDD.ToString();
            this.lbdzbcdy.Text = mo_mrzj.N_LQBCDYDZ.ToString();
            this.lbdcbcdy.Text = mo_mrzj.N_LQBCDYDC.ToString();
            this.lbddbcdy.Text = mo_mrzj.N_LQBCDYDD.ToString();
            this.lbdzbcds.Text = mo_mrzj.N_LQBCDSDZ.ToString();
            this.lbdcbcds.Text = mo_mrzj.N_LQBCDSDC.ToString();
            this.lbddbcds.Text = mo_mrzj.N_LQBCDSDD.ToString();
            this.lbdzgg.Text = mo_mrzj.N_LQGGDZ.ToString();
            this.lbdcgg.Text = mo_mrzj.N_LQGGDC.ToString();
            this.lbddgg.Text = mo_mrzj.N_LQGGDD.ToString();
            this.lbdzgj.Text = mo_mrzj.N_LQGJDZ.ToString();
            this.lbdcgj.Text = mo_mrzj.N_LQGJDC.ToString();
            this.lbddgj.Text = mo_mrzj.N_LQGJDD.ToString();
            this.lbdzdjrf.Text = mo_mrzj.N_LQDJRFDZ.ToString();
            this.lbdcdjrf.Text = mo_mrzj.N_LQDJRFDC.ToString();
            this.lbdddjrf.Text = mo_mrzj.N_LQDJRFDD.ToString();
            this.lbdzdjdx.Text = mo_mrzj.N_LQDJDXDZ.ToString();
            this.lbdcdjdx.Text = mo_mrzj.N_LQDJDXDC.ToString();
            this.lbdddjdx.Text = mo_mrzj.N_LQDJDXDD.ToString();
            this.lbdzdjds.Text = mo_mrzj.N_LQDJDSDZ.ToString();
            this.lbdcdjds.Text = mo_mrzj.N_LQDJDSDC.ToString();
            this.lbdddjds.Text = mo_mrzj.N_LQDJDSDD.ToString();

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQBCDXTY.Value / 100), this.drptybcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQBCDYTY.Value / 100), this.drptybcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQBCRFTY.Value / 100), this.drptybcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQDSTY.Value / 100), this.drptyds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQDXTY.Value / 100), this.drptydx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQDYTY.Value / 100), this.drptydy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQGGTY.Value / 100), this.drptygg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQGJTY.Value / 100), this.drptygj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQRFTY.Value / 100), this.drptyrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQZDDXTY.Value / 100), this.drptyzddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQZDRFTY.Value / 100), this.drptyzdrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQBCDSTY.Value / 100), this.drptybcds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQDJRFTY.Value / 100), this.drptydjrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQDJDSTY.Value / 100), this.drptydjdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_LQDJDSTY.Value / 100), this.drptydjds);


            string s_TYA = "N_LQBCDXTY,N_LQBCDYTY,N_LQBCRFTY,N_LQDSTY,N_LQDXTY,N_LQDYTY,N_LQRFTY,N_LQZDDXTY,N_LQZDRFTY,N_LQBCDSTY,N_LQDJRFTY,N_LQDJDSTY,N_LQDJDSTY";
            string s_LeastA = this.objAgentManageAddDB.GetLeast("kfb_mrzj", "least", s_TYA, " where n_update=(select max(n_update) from kfb_mrzj)");

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastA) / 100, this.drptyall);


        }

        /// <summary>
        /// 上級帳號上層賦值
        /// </summary>
        public void ZHFZ(string strparid, string strlvl)
        {
          
            string strzh = "";
            if (strlvl == "10")
            {
                
                KFB_HYGL mo_hygl = this.objHYGL.GetModel(strparid);
                strzh = mo_hygl.N_DLDH;
            }
            else
            {
                strzh = Comm.GetUPID(strparid, strlvl);
            }
            KFB_SETUPLQ mo_lq = this.objAgentManageAddDB.GetModelLQ(strzh);

            this.lbdzrf.Text = mo_lq.N_RFDZ.ToString();
            this.lbdzdx.Text = mo_lq.N_DXDZ.ToString();
            this.lbdzdy.Text = mo_lq.N_DYDZ.ToString();
            this.lbdzds.Text = mo_lq.N_DSDZ.ToString();
            this.lbdzzdrf.Text = mo_lq.N_ZDRFDZ.ToString();
            this.lbdzzddx.Text = mo_lq.N_ZDDXDZ.ToString();
            this.lbdzbcrf.Text = mo_lq.N_BCRFDZ.ToString();
            this.lbdzbcdx.Text = mo_lq.N_BCDXDZ.ToString();
            this.lbdzbcdy.Text = mo_lq.N_BCDYDZ.ToString();
            this.lbdzbcds.Text = mo_lq.N_BCDSDZ.ToString();
            this.lbdzgg.Text = mo_lq.N_GGDZ.ToString();
            this.lbdzgj.Text = mo_lq.N_GJDZ.ToString();
            this.lbdzdjrf.Text = mo_lq.N_DJRFDZ.ToString();
            this.lbdzdjdx.Text = mo_lq.N_DJDXDZ.ToString();
            this.lbdzdjds.Text = mo_lq.N_DJDSDZ.ToString();

            this.lbdcrf.Text = mo_lq.N_RFDC.ToString();
            this.lbdcdx.Text = mo_lq.N_DXDC.ToString();
            this.lbdcdy.Text = mo_lq.N_DYDC.ToString();
            this.lbdcds.Text = mo_lq.N_DSDC.ToString();
            this.lbdczdrf.Text = mo_lq.N_ZDRFDC.ToString();
            this.lbdczddx.Text = mo_lq.N_ZDDXDC.ToString();
            this.lbdcbcrf.Text = mo_lq.N_BCRFDC.ToString();
            this.lbdcbcdx.Text = mo_lq.N_BCDXDC.ToString();
            this.lbdcbcdy.Text = mo_lq.N_BCDYDC.ToString();
            this.lbdcbcds.Text = mo_lq.N_BCDSDC.ToString();
            this.lbdcgg.Text = mo_lq.N_GGDC.ToString();
            this.lbdcgj.Text = mo_lq.N_GJDC.ToString();
            this.lbdcdjrf.Text = mo_lq.N_DJRFDC.ToString();
            this.lbdcdjdx.Text = mo_lq.N_DJDXDC.ToString();
            this.lbdcdjds.Text = mo_lq.N_DJDSDC.ToString();

            this.lbddrf.Text = mo_lq.N_RFDD.ToString();  //單隊讓分
            this.lbdddx.Text = mo_lq.N_DXDD.ToString();  //單隊大小
            this.lbdddy.Text = mo_lq.N_DYDD.ToString();  //單隊獨贏
            this.lbddds.Text = mo_lq.N_DSDD.ToString();  //單隊單雙
            this.lbddzdrf.Text = mo_lq.N_ZDRFDD.ToString();     //單隊走地讓分
            this.lbddzddx.Text = mo_lq.N_ZDDXDD.ToString();     //單隊走地大小
            this.lbddbcrf.Text = mo_lq.N_BCRFDD.ToString();     //單隊半場讓分
            this.lbddbcdx.Text = mo_lq.N_BCDXDD.ToString();     //單隊半場大小
            this.lbddbcdy.Text = mo_lq.N_BCDYDD.ToString();     //單隊半場獨贏
            this.lbddbcds.Text = mo_lq.N_BCDSDD.ToString();     //單隊半場單雙
            this.lbddgg.Text = mo_lq.N_GGDD.ToString();     //單隊過關
            this.lbddgj.Text = mo_lq.N_GJDD.ToString();     //單隊冠軍
            this.lbdddjrf.Text = mo_lq.N_DJRFDD.ToString();     //單隊單節讓分
            this.lbdddjdx.Text = mo_lq.N_DJDXDD.ToString();     //單隊單節大小
            this.lbdddjds.Text = mo_lq.N_DJDSDD.ToString();

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCDXTY.Value / 100), this.drptybcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCDYTY.Value / 100), this.drptybcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCRFTY.Value / 100), this.drptybcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCDSTY.Value / 100), this.drptybcds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DSTY.Value / 100), this.drptyds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DXTY.Value / 100), this.drptydx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DYTY.Value / 100), this.drptydy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_GGTY.Value / 100), this.drptygg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_GJTY.Value / 100), this.drptygj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_RFTY.Value / 100), this.drptyrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_ZDRFTY.Value / 100), this.drptyzdrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_ZDDXTY.Value / 100), this.drptyzddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DJRFTY.Value / 100), this.drptydjrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DJDXTY.Value / 100), this.drptydjdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DJDSTY.Value / 100), this.drptydjds);

            string s_TYA = "N_BCDXTY,N_BCDYTY,N_BCRFTY,N_BCDSTY,N_DSTY,N_DXTY,N_DYTY,N_RFTY,N_ZDRFTY,N_ZDDXTY,N_DJRFTY,N_DJDXTY,N_DJDSTY";
            string s_LeastA = this.objAgentManageAddDB.GetLeast("kfb_setuplq", "least", s_TYA, " where n_hyzh='" + GetUser + "'");

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastA) / 100, this.drptyall);
        }

        /// <summary>
        /// 取得下級的設置
        /// </summary>
        /// <param name="strlvl"></param>
        /// <param name="strparid"></param>
        public void GetSUB(string strlvl, string strparid)
        {

         
            string strSpName = "(" + Comm.GetLvSName(Convert.ToString(Convert.ToDecimal(strlvl) + 1)) + ")";
            KFB_SETUPLQ mo_lq = this.objAgentManageAddDB.GetModelLQ(strlvl, strparid);
            this.lbtyrft.Text = strSpName + mo_lq.N_RFTY.ToString();
            this.lbdzrft.Text = strSpName + mo_lq.N_RFDZ.ToString();
            this.lbdcrft.Text = strSpName + mo_lq.N_RFDC.ToString();
            this.lbddrft.Text = strSpName + mo_lq.N_RFDD.ToString();
            this.lbtydxt.Text = strSpName + mo_lq.N_DXTY.ToString();
            this.lbdzdxt.Text = strSpName + mo_lq.N_DXDZ.ToString();
            this.lbdcdxt.Text = strSpName + mo_lq.N_DXDC.ToString();
            this.lbdddxt.Text = strSpName + mo_lq.N_DXDD.ToString();
            this.lbtydyt.Text = strSpName + mo_lq.N_DYTY.ToString();
            this.lbdzdyt.Text = strSpName + mo_lq.N_DYDZ.ToString();
            this.lbdcdyt.Text = strSpName + mo_lq.N_DYDC.ToString();
            this.lbdddyt.Text = strSpName + mo_lq.N_DYDD.ToString();
            this.lbtydst.Text = strSpName + mo_lq.N_DSTY.ToString();
            this.lbdzdst.Text = strSpName + mo_lq.N_DSDZ.ToString();
            this.lbdcdst.Text = strSpName + mo_lq.N_DSDC.ToString();
            this.lbdddst.Text = strSpName + mo_lq.N_DSDD.ToString();
            this.lbtyzdrft.Text = strSpName + mo_lq.N_ZDRFTY.ToString();
            this.lbdzzdrft.Text = strSpName + mo_lq.N_ZDRFDZ.ToString();
            this.lbdczdrft.Text = strSpName + mo_lq.N_ZDRFDC.ToString();
            this.lbddzdrft.Text = strSpName + mo_lq.N_ZDRFDD.ToString();
            this.lbtyzddxt.Text = strSpName + mo_lq.N_ZDDXTY.ToString();
            this.lbdzzddxt.Text = strSpName + mo_lq.N_ZDDXDZ.ToString();
            this.lbdczddxt.Text = strSpName + mo_lq.N_ZDDXDC.ToString();
            this.lbddzddxt.Text = strSpName + mo_lq.N_ZDDXDD.ToString();
            this.lbtybcrft.Text = strSpName + mo_lq.N_BCRFTY.ToString();
            this.lbdzbcrft.Text = strSpName + mo_lq.N_BCRFDZ.ToString();
            this.lbdcbcrft.Text = strSpName + mo_lq.N_BCRFDC.ToString();
            this.lbddbcrft.Text = strSpName + mo_lq.N_BCRFDD.ToString();
            this.lbtybcdxt.Text = strSpName + mo_lq.N_BCDXTY.ToString();
            this.lbdzbcdxt.Text = strSpName + mo_lq.N_BCDXDZ.ToString();
            this.lbdcbcdxt.Text = strSpName + mo_lq.N_BCDXDC.ToString();
            this.lbddbcdxt.Text = strSpName + mo_lq.N_BCDXDD.ToString();
            this.lbtybcdyt.Text = strSpName + mo_lq.N_BCDYTY.ToString();
            this.lbdzbcdyt.Text = strSpName + mo_lq.N_BCDYDZ.ToString();
            this.lbdcbcdyt.Text = strSpName + mo_lq.N_BCDYDC.ToString();
            this.lbddbcdyt.Text = strSpName + mo_lq.N_BCDYDD.ToString();
            this.lbtybcdst.Text = strSpName + mo_lq.N_BCDSTY.ToString();
            this.lbdzbcdst.Text = strSpName + mo_lq.N_BCDSDZ.ToString();
            this.lbdcbcdst.Text = strSpName + mo_lq.N_BCDSDC.ToString();
            this.lbddbcdst.Text = strSpName + mo_lq.N_BCDSDD.ToString();
            this.lbtyggt.Text = strSpName + mo_lq.N_GGTY.ToString();
            this.lbdzggt.Text = strSpName + mo_lq.N_GGDZ.ToString();
            this.lbdcggt.Text = strSpName + mo_lq.N_GGDC.ToString();
            this.lbddggt.Text = strSpName + mo_lq.N_GGDD.ToString();
            this.lbtygjt.Text = strSpName + mo_lq.N_GJTY.ToString();
            this.lbdzgjt.Text = strSpName + mo_lq.N_GJDZ.ToString();
            this.lbdcgjt.Text = strSpName + mo_lq.N_GJDC.ToString();
            this.lbddgjt.Text = strSpName + mo_lq.N_GJDD.ToString();
            this.lbtydjrft.Text = strSpName + mo_lq.N_DJRFTY.ToString();
            this.lbdzdjrft.Text = strSpName + mo_lq.N_DJRFDZ.ToString();
            this.lbdcdjrft.Text = strSpName + mo_lq.N_DJRFDC.ToString();
            this.lbdddjrft.Text = strSpName + mo_lq.N_DJRFDD.ToString();
            this.lbtydjdxt.Text = strSpName + mo_lq.N_DJDXTY.ToString();
            this.lbdzdjdxt.Text = strSpName + mo_lq.N_DJDXDZ.ToString();
            this.lbdcdjdxt.Text = strSpName + mo_lq.N_DJDXDC.ToString();
            this.lbdddjdxt.Text = strSpName + mo_lq.N_DJDXDD.ToString();
            this.lbtydjdst.Text = strSpName + mo_lq.N_DJDSTY.ToString();
            this.lbdzdjdst.Text = strSpName + mo_lq.N_DJDSDZ.ToString();
            this.lbdcdjdst.Text = strSpName + mo_lq.N_DJDSDC.ToString();
            this.lbdddjdst.Text = strSpName + mo_lq.N_DJDSDD.ToString();
        }

        #endregion
    }
