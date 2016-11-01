using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class MB_set :BasePage
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
                #region"修改棒球設定檔"
                KFB_SETUPMB mo_mb = new KFB_SETUPMB();
                Hashtable GetSql = new Hashtable();
                KFB_ZHGL mo_zhgl = new KFB_ZHGL();
                mo_zhgl = objAgentManageDB.GetModel(this.lblName.Text.ToString().Trim());

                mo_mb.N_HYZH = this.lblName.Text;
                mo_mb.N_RFTY = Convert.ToDecimal(this.drptyrf.Text);
                mo_mb.N_RFDZ = Convert.ToDecimal(this.txtdzrf.Text);
                mo_mb.N_RFDC = Convert.ToDecimal(this.txtdcrf.Text);
                mo_mb.N_DXTY = Convert.ToDecimal(this.drptydx.Text);
                mo_mb.N_DXDZ = Convert.ToDecimal(this.txtdzdx.Text);
                mo_mb.N_DXDC = Convert.ToDecimal(this.txtdcdx.Text);
                mo_mb.N_DYTY = Convert.ToDecimal(this.drptydy.Text);
                mo_mb.N_DYDZ = Convert.ToDecimal(this.txtdzdy.Text);
                mo_mb.N_DYDC = Convert.ToDecimal(this.txtdcdy.Text);
                mo_mb.N_DSTY = Convert.ToDecimal(this.drptyds.Text);
                mo_mb.N_DSDZ = Convert.ToDecimal(this.txtdzds.Text);
                mo_mb.N_DSDC = Convert.ToDecimal(this.txtdcds.Text);
                mo_mb.N_ZDRFTY = Convert.ToDecimal(this.drptyzdrf.Text);
                mo_mb.N_ZDRFDZ = Convert.ToDecimal(this.txtdzzdrf.Text);
                mo_mb.N_ZDRFDC = Convert.ToDecimal(this.txtdczdrf.Text);
                mo_mb.N_ZDDXTY = Convert.ToDecimal(this.drptyzddx.Text);
                mo_mb.N_ZDDXDZ = Convert.ToDecimal(this.txtdzzddx.Text);
                mo_mb.N_ZDDXDC = Convert.ToDecimal(this.txtdczddx.Text);
                mo_mb.N_SYTY = Convert.ToDecimal(this.drptysy.Text);
                mo_mb.N_SYDZ = Convert.ToDecimal(this.txtdzsy.Text);
                mo_mb.N_SYDC = Convert.ToDecimal(this.txtdcsy.Text);
                mo_mb.N_GGTY = Convert.ToDecimal(this.drptygg.Text);
                mo_mb.N_GGDZ = Convert.ToDecimal(this.txtdzgg.Text);
                mo_mb.N_GGDC = Convert.ToDecimal(this.txtdcgg.Text);
                mo_mb.N_GJTY = Convert.ToDecimal(this.drptybcrf.Text);
                mo_mb.N_GJDZ = Convert.ToDecimal(this.txtdzbcrf.Text);
                mo_mb.N_GJDC = Convert.ToDecimal(this.txtdcbcrf.Text);
                objAgentManageDB.UpdateMB(mo_mb, GetSql);
                objAgentManageDB.Update(GetSql);
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
                        getds = objAgentManageDB.GetZH(mo_zhgl.N_HYDJ.ToString(), this.lblName.Text);
                        if (getds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < getds.Tables[0].Rows.Count; i++)
                            {
                                strZH = strZH + strFlag + "'" + getds.Tables[0].Rows[i]["n_hyzh"].ToString() + "'";
                                strFlag = ",";
                            }
                        }
                    }
                    getds = objAgentManageDB.GetHYZH(mo_zhgl.N_HYDJ.ToString(), this.lblName.Text);//取得下屬會員
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
                            objAgentManageDB.Update("mb", strvalue[0].ToString(), strvalue[1].ToString(), strZH);
                        }
                    }
                }
                #endregion


                ShowMsg("修改成功！");
            }
            catch (Exception ex)
            {
                ShowMsg("修改失敗，請通知管理員！");
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

           KFB_SETUPMB mo_ZQ = this.objAgentManageAddDB.GetModelMB(this.GetUser); 
            this.txtdzrf.Text = mo_ZQ.N_RFDZ.ToString();
            this.txtdcrf.Text = mo_ZQ.N_RFDC.ToString();
            this.txtdzdx.Text = mo_ZQ.N_DXDZ.ToString();
            this.txtdcdx.Text = mo_ZQ.N_DXDC.ToString();
            this.txtdzdy.Text = mo_ZQ.N_DYDZ.ToString();
            this.txtdcdy.Text = mo_ZQ.N_DYDC.ToString();
            this.txtdzds.Text = mo_ZQ.N_DSDZ.ToString();
            this.txtdcds.Text = mo_ZQ.N_DSDC.ToString();
            this.txtdzzdrf.Text = mo_ZQ.N_ZDRFDZ.ToString();
            this.txtdczdrf.Text = mo_ZQ.N_ZDRFDC.ToString();
            this.txtdzzddx.Text = mo_ZQ.N_ZDDXDZ.ToString();
            this.txtdczddx.Text = mo_ZQ.N_ZDDXDC.ToString();
            this.txtdzbcrf.Text = mo_ZQ.N_GJDZ.ToString();
            this.txtdcbcrf.Text = mo_ZQ.N_GJDC.ToString();
            this.txtdzgg.Text = mo_ZQ.N_GGDZ.ToString();
            this.txtdcgg.Text = mo_ZQ.N_GGDC.ToString();
            this.txtdcsy.Text = mo_ZQ.N_SYDC.ToString();
            this.txtdzsy.Text = mo_ZQ.N_SYDZ.ToString();

            KFB_ZHGL mo_zhgl = new KFB_ZHGL();
            mo_zhgl = objAgentManageDB.GetModel(this.GetUser);
            if (mo_zhgl == null)
            {
               
                KFB_HYGL mo_hygl = objHYGL.GetModel(this.GetUser);
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
            this.drptybcrf.SelectedValue = mo_ZQ.N_GJTY.ToString();
            this.drptygg.SelectedValue = mo_ZQ.N_GGTY.ToString();
            this.drptysy.SelectedValue = mo_ZQ.N_SYTY.ToString();
            this.drptyrf.SelectedValue = mo_ZQ.N_RFTY.ToString();
        }

      

        /// <summary>
        /// 大總監上級帳號賦值（大總監默認拆賬）
        /// </summary>
        public void DZJFZ()
        {


         
            KFB_MRZJ mo_mrzj = new KFB_MRZJ();
            mo_mrzj = objAgentManageAddDB.GetModel();

            this.lbdzrf.Text = mo_mrzj.N_MBRFDZ.ToString();
            this.lbdcrf.Text = mo_mrzj.N_MBRFDC.ToString();
            this.lbdzdx.Text = mo_mrzj.N_MBDXDZ.ToString();
            this.lbdcdx.Text = mo_mrzj.N_MBDXDC.ToString();
            this.lbdzdy.Text = mo_mrzj.N_MBDYDZ.ToString();
            this.lbdcdy.Text = mo_mrzj.N_MBDYDC.ToString();
            this.lbdzds.Text = mo_mrzj.N_MBDSDZ.ToString();
            this.lbdcds.Text = mo_mrzj.N_MBDSDC.ToString();
            this.lbdzzdrf.Text = mo_mrzj.N_MBZDRFDZ.ToString();
            this.lbdczdrf.Text = mo_mrzj.N_MBZDRFDC.ToString();
            this.lbdzzddx.Text = mo_mrzj.N_MBZDDXDZ.ToString();
            this.lbdczddx.Text = mo_mrzj.N_MBZDDXDC.ToString();
            this.lbdzbcrf.Text = mo_mrzj.N_MBGJDZ.ToString();
            this.lbdcbcrf.Text = mo_mrzj.N_MBGJDC.ToString();
            this.lbdzgg.Text = mo_mrzj.N_MBGGDZ.ToString();
            this.lbdcgg.Text = mo_mrzj.N_MBGGDC.ToString();
            this.lbdcsy.Text = mo_mrzj.N_MBSYDC.ToString();
            this.lbdzsy.Text = mo_mrzj.N_MBSYDZ.ToString();

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBGJTY.Value / 100), this.drptybcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBDSTY.Value / 100), this.drptyds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBDXTY.Value / 100), this.drptydx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBDYTY.Value / 100), this.drptydy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBGGTY.Value / 100), this.drptygg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBRFTY.Value / 100), this.drptyrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBZDDXTY.Value / 100), this.drptyzddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBZDRFTY.Value / 100), this.drptyzdrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_MBSYTY.Value / 100), this.drptysy);


            string s_TYA = "N_MBGJTY,N_MBDSTY,N_MBDXTY,N_MBDYTY,N_MBRFTY,N_MBZDDXTY,N_MBZDRFTY,N_MBSYTY";
            string s_LeastA = objAgentManageAddDB.GetLeast("kfb_mrzj", "least", s_TYA, " where n_update=(select max(n_update) from kfb_mrzj)");

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastA) / 100, this.drptyall);

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

            KFB_HYGL mo_hygl = objHYGL.GetModel(strparid);
            strzh = mo_hygl.N_DLDH;
        }
        else
        {
            strzh = Comm.GetUPID(strparid, strlvl);
        }
        KFB_SETUPMB mo_lq = objAgentManageAddDB.GetModelMB(strzh);

        this.lbdzrf.Text = mo_lq.N_RFDZ.ToString();
        this.lbdzdx.Text = mo_lq.N_DXDZ.ToString();
        this.lbdzdy.Text = mo_lq.N_DYDZ.ToString();
        this.lbdzds.Text = mo_lq.N_DSDZ.ToString();
        this.lbdzzdrf.Text = mo_lq.N_ZDRFDZ.ToString();
        this.lbdzzddx.Text = mo_lq.N_ZDDXDZ.ToString();
        this.lbdzbcrf.Text = mo_lq.N_GJDZ.ToString();
        this.lbdzgg.Text = mo_lq.N_GGDZ.ToString();

        this.lbdcrf.Text = mo_lq.N_RFDC.ToString();
        this.lbdcdx.Text = mo_lq.N_DXDC.ToString();
        this.lbdcdy.Text = mo_lq.N_DYDC.ToString();
        this.lbdcds.Text = mo_lq.N_DSDC.ToString();
        this.lbdczdrf.Text = mo_lq.N_ZDRFDC.ToString();
        this.lbdczddx.Text = mo_lq.N_ZDDXDC.ToString();
        this.lbdcbcrf.Text = mo_lq.N_GJDC.ToString();
        this.lbdcgg.Text = mo_lq.N_GGDC.ToString();
        this.lbdcsy.Text = mo_lq.N_SYDC.ToString();
        this.lbdzsy.Text = mo_lq.N_SYDZ.ToString();



        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_GJTY.Value / 100), this.drptybcrf);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DSTY.Value / 100), this.drptyds);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DXTY.Value / 100), this.drptydx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DYTY.Value / 100), this.drptydy);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_GGTY.Value / 100), this.drptygg);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_RFTY.Value / 100), this.drptyrf);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_ZDRFTY.Value / 100), this.drptyzdrf);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_ZDDXTY.Value / 100), this.drptyzddx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_SYTY.Value / 100), this.drptysy);

        string s_TYA = "N_GJTY,N_DSTY,N_DXTY,N_DYTY,N_RFTY,N_ZDRFTY,N_ZDDXTY,N_SYTY";
        string s_LeastA = objAgentManageAddDB.GetLeast("kfb_setupmb", "least", s_TYA, " where n_hyzh='" + GetUser + "'");

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
            KFB_SETUPMB mo_lq = objAgentManageAddDB.GetModelMB(strlvl, strparid);
            this.lbtyrft.Text = strSpName + mo_lq.N_RFTY.ToString();
            this.lbdzrft.Text = strSpName + mo_lq.N_RFDZ.ToString();
            this.lbdcrft.Text = strSpName + mo_lq.N_RFDC.ToString();
            this.lbtydxt.Text = strSpName + mo_lq.N_DXTY.ToString();
            this.lbdzdxt.Text = strSpName + mo_lq.N_DXDZ.ToString();
            this.lbdcdxt.Text = strSpName + mo_lq.N_DXDC.ToString();
            this.lbtydyt.Text = strSpName + mo_lq.N_DYTY.ToString();
            this.lbdzdyt.Text = strSpName + mo_lq.N_DYDZ.ToString();
            this.lbdcdyt.Text = strSpName + mo_lq.N_DYDC.ToString();
            this.lbtydst.Text = strSpName + mo_lq.N_DSTY.ToString();
            this.lbdzdst.Text = strSpName + mo_lq.N_DSDZ.ToString();
            this.lbdcdst.Text = strSpName + mo_lq.N_DSDC.ToString();
            this.lbtyzdrft.Text = strSpName + mo_lq.N_ZDRFTY.ToString();
            this.lbdzzdrft.Text = strSpName + mo_lq.N_ZDRFDZ.ToString();
            this.lbdczdrft.Text = strSpName + mo_lq.N_ZDRFDC.ToString();
            this.lbtyzddxt.Text = strSpName + mo_lq.N_ZDDXTY.ToString();
            this.lbdzzddxt.Text = strSpName + mo_lq.N_ZDDXDZ.ToString();
            this.lbdczddxt.Text = strSpName + mo_lq.N_ZDDXDC.ToString();
            this.lbtybcrft.Text = strSpName + mo_lq.N_GJTY.ToString();
            this.lbdzbcrft.Text = strSpName + mo_lq.N_GJDZ.ToString();
            this.lbdcbcrft.Text = strSpName + mo_lq.N_GJDC.ToString();
            this.lbtyggt.Text = strSpName + mo_lq.N_GGTY.ToString();
            this.lbdzggt.Text = strSpName + mo_lq.N_GGDZ.ToString();
            this.lbdcggt.Text = strSpName + mo_lq.N_GGDC.ToString();
            this.lbtysyt.Text = strSpName + mo_lq.N_SYTY.ToString();
            this.lbdzsyt.Text = strSpName + mo_lq.N_SYDZ.ToString();
            this.lbdcsyt.Text = strSpName + mo_lq.N_SYDC.ToString();
        }

        #endregion
    }
