using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class ZQ_set :BasePage
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
                #region"修改足球設定檔"
                KFB_SETUPZQ mo_zq = new KFB_SETUPZQ();
                Hashtable GetSql = new Hashtable();
                KFB_ZHGL mo_zhgl = new KFB_ZHGL();
                mo_zhgl = objAgentManageDB.GetModel(this.lblName.Text.ToString().Trim());
                mo_zq.N_HYZH = this.lblName.Text.ToString().Trim();
                mo_zq.N_ARFTY = Convert.ToDecimal(this.drptyarf.Text);
                mo_zq.N_ADXTY = Convert.ToDecimal(this.drptyadx.Text);
                mo_zq.N_ADYTY = Convert.ToDecimal(this.drptyady.Text);
                mo_zq.N_ADSTY = Convert.ToDecimal(this.drptyads.Text);
                mo_zq.N_AZDRFTY = Convert.ToDecimal(this.drptyazdrf.Text);
                mo_zq.N_AZDDXTY = Convert.ToDecimal(this.drptyazddx.Text);
                mo_zq.N_ABCRFTY = Convert.ToDecimal(this.drptyabcrf.Text);
                mo_zq.N_ABCDXTY = Convert.ToDecimal(this.drptyabcdx.Text);
                mo_zq.N_ABCDYTY = Convert.ToDecimal(this.drptyabcdy.Text);
                mo_zq.N_ARQSTY = Convert.ToDecimal(this.drptyarqs.Text);
                mo_zq.N_ABDTY = Convert.ToDecimal(this.drptyabd.Text);
                mo_zq.N_ABQCTY = Convert.ToDecimal(this.drptyabqc.Text);
                mo_zq.N_AGGTY = Convert.ToDecimal(this.drptyagg.Text);
                mo_zq.N_AGJTY = Convert.ToDecimal(this.drptyagj.Text);

                mo_zq.N_BRFTY = Convert.ToDecimal(this.drptybrf.Text);
                mo_zq.N_BDXTY = Convert.ToDecimal(this.drptybdx.Text);
                mo_zq.N_BDYTY = Convert.ToDecimal(this.drptybdy.Text);
                mo_zq.N_BDSTY = Convert.ToDecimal(this.drptybds.Text);
                mo_zq.N_BZDRFTY = Convert.ToDecimal(this.drptybzdrf.Text);
                mo_zq.N_BZDDXTY = Convert.ToDecimal(this.drptybzddx.Text);
                mo_zq.N_BBCRFTY = Convert.ToDecimal(this.drptybbcrf.Text);
                mo_zq.N_BBCDXTY = Convert.ToDecimal(this.drptybbcdx.Text);
                mo_zq.N_BBCDYTY = Convert.ToDecimal(this.drptybbcdy.Text);
                mo_zq.N_BRQSTY = Convert.ToDecimal(this.drptybrqs.Text);
                mo_zq.N_BBDTY = Convert.ToDecimal(this.drptybbd.Text);
                mo_zq.N_BBQCTY = Convert.ToDecimal(this.drptybbqc.Text);
                mo_zq.N_BGGTY = Convert.ToDecimal(this.drptybgg.Text);
                mo_zq.N_BGJTY = Convert.ToDecimal(this.drptybgj.Text);

                mo_zq.N_CRFTY = Convert.ToDecimal(this.drptycrf.Text);
                mo_zq.N_CDXTY = Convert.ToDecimal(this.drptycdx.Text);
                mo_zq.N_CDYTY = Convert.ToDecimal(this.drptycdy.Text);
                mo_zq.N_CDSTY = Convert.ToDecimal(this.drptycds.Text);
                mo_zq.N_CZDRFTY = Convert.ToDecimal(this.drptyczdrf.Text);
                mo_zq.N_CZDDXTY = Convert.ToDecimal(this.drptyczddx.Text);
                mo_zq.N_CBCRFTY = Convert.ToDecimal(this.drptycbcrf.Text);
                mo_zq.N_CBCDXTY = Convert.ToDecimal(this.drptycbcdx.Text);
                mo_zq.N_CBCDYTY = Convert.ToDecimal(this.drptycbcdy.Text);
                mo_zq.N_CRQSTY = Convert.ToDecimal(this.drptycrqs.Text);
                mo_zq.N_CBDTY = Convert.ToDecimal(this.drptycbd.Text);
                mo_zq.N_CBQCTY = Convert.ToDecimal(this.drptycbqc.Text);
                mo_zq.N_CGGTY = Convert.ToDecimal(this.drptycgg.Text);
                mo_zq.N_CGJTY = Convert.ToDecimal(this.drptycgj.Text);

                mo_zq.N_RFDZ = Convert.ToDecimal(this.txtdzrf.Text);
                mo_zq.N_RFDC = Convert.ToDecimal(this.txtdcrf.Text);
                mo_zq.N_DXDZ = Convert.ToDecimal(this.txtdzdx.Text);
                mo_zq.N_DXDC = Convert.ToDecimal(this.txtdcdx.Text);
                mo_zq.N_DYDZ = Convert.ToDecimal(this.txtdzdy.Text);
                mo_zq.N_DYDC = Convert.ToDecimal(this.txtdcdy.Text);
                mo_zq.N_DSDZ = Convert.ToDecimal(this.txtdzds.Text);
                mo_zq.N_DSDC = Convert.ToDecimal(this.txtdcds.Text);
                mo_zq.N_ZDRFDZ = Convert.ToDecimal(this.txtdzzdrf.Text);
                mo_zq.N_ZDRFDC = Convert.ToDecimal(this.txtdczdrf.Text);
                mo_zq.N_ZDDXDZ = Convert.ToDecimal(this.txtdzzddx.Text);
                mo_zq.N_ZDDXDC = Convert.ToDecimal(this.txtdczddx.Text);
                mo_zq.N_BCRFDZ = Convert.ToDecimal(this.txtdzbcrf.Text);
                mo_zq.N_BCRFDC = Convert.ToDecimal(this.txtdcbcrf.Text);
                mo_zq.N_BCDXDZ = Convert.ToDecimal(this.txtdzbcdx.Text);
                mo_zq.N_BCDXDC = Convert.ToDecimal(this.txtdcbcdx.Text);
                mo_zq.N_BCDYDZ = Convert.ToDecimal(this.txtdzbcdy.Text);
                mo_zq.N_BCDYDC = Convert.ToDecimal(this.txtdcbcdy.Text);
                mo_zq.N_RQSDZ = Convert.ToDecimal(this.txtdzrqs.Text);
                mo_zq.N_RQSDC = Convert.ToDecimal(this.txtdcrqs.Text);
                mo_zq.N_BDDZ = Convert.ToDecimal(this.txtdzbd.Text);
                mo_zq.N_BDDC = Convert.ToDecimal(this.txtdcbd.Text);
                mo_zq.N_BQCDZ = Convert.ToDecimal(this.txtdzbqc.Text);
                mo_zq.N_BQCDC = Convert.ToDecimal(this.txtdcbqc.Text);
                mo_zq.N_GGDZ = Convert.ToDecimal(this.txtdzgg.Text);
                mo_zq.N_GGDC = Convert.ToDecimal(this.txtdcgg.Text);
                mo_zq.N_GJDZ = Convert.ToDecimal(this.txtdzgj.Text);
                mo_zq.N_GJDC = Convert.ToDecimal(this.txtdcgj.Text);
                objAgentManageDB.UpdateZQ(mo_zq, GetSql);
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
                            objAgentManageDB.Update("zq", strvalue[0].ToString(), strvalue[1].ToString(), strZH);
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

            KFB_SETUPZQ mo_ZQ = this.objAgentManageAddDB.GetModelZQ(this.GetUser);
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
            this.txtdzbcrf.Text = mo_ZQ.N_BCRFDZ.ToString();
            this.txtdcbcrf.Text = mo_ZQ.N_BCRFDC.ToString();
            this.txtdzbcdx.Text = mo_ZQ.N_BCDXDZ.ToString();
            this.txtdcbcdx.Text = mo_ZQ.N_BCDXDC.ToString();
            this.txtdzbcdy.Text = mo_ZQ.N_BCDYDZ.ToString();
            this.txtdcbcdy.Text = mo_ZQ.N_BCDYDC.ToString();
            this.txtdzrqs.Text = mo_ZQ.N_RQSDZ.ToString();
            this.txtdcrqs.Text = mo_ZQ.N_RQSDC.ToString();
            this.txtdzbd.Text = mo_ZQ.N_BDDZ.ToString();
            this.txtdcbd.Text = mo_ZQ.N_BDDC.ToString();
            this.txtdzbqc.Text = mo_ZQ.N_BQCDZ.ToString();
            this.txtdcbqc.Text = mo_ZQ.N_BQCDC.ToString();
            this.txtdzgg.Text = mo_ZQ.N_GGDZ.ToString();
            this.txtdcgg.Text = mo_ZQ.N_GGDC.ToString();
            this.txtdzgj.Text = mo_ZQ.N_GJDZ.ToString();
            this.txtdcgj.Text = mo_ZQ.N_GJDC.ToString();

            KFB_ZHGL mo_zhgl = new KFB_ZHGL();
    
            mo_zhgl = this.objAgentManageDB.GetModel(this.GetUser);
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
            this.drptyarf.SelectedValue = mo_ZQ.N_ARFTY.ToString();
            this.drptybrf.SelectedValue = mo_ZQ.N_BRFTY.ToString();
            this.drptycrf.SelectedValue = mo_ZQ.N_CRFTY.ToString();
            this.drptyadx.SelectedValue = mo_ZQ.N_ADXTY.ToString();
            this.drptybdx.SelectedValue = mo_ZQ.N_BDXTY.ToString();
            this.drptycdx.SelectedValue = mo_ZQ.N_CDXTY.ToString();
            this.drptyady.SelectedValue = mo_ZQ.N_ADYTY.ToString();
            this.drptybdy.SelectedValue = mo_ZQ.N_BDYTY.ToString();
            this.drptycdy.SelectedValue = mo_ZQ.N_CDYTY.ToString();
            this.drptyads.SelectedValue = mo_ZQ.N_ADSTY.ToString();
            this.drptybds.SelectedValue = mo_ZQ.N_BDSTY.ToString();
            this.drptycds.SelectedValue = mo_ZQ.N_CDSTY.ToString();
            this.drptyazdrf.SelectedValue = mo_ZQ.N_AZDRFTY.ToString();
            this.drptybzdrf.SelectedValue = mo_ZQ.N_BZDRFTY.ToString();
            this.drptyczdrf.SelectedValue = mo_ZQ.N_CZDRFTY.ToString();
            this.drptyazddx.SelectedValue = mo_ZQ.N_AZDDXTY.ToString();
            this.drptybzddx.SelectedValue = mo_ZQ.N_BZDDXTY.ToString();
            this.drptyczddx.SelectedValue = mo_ZQ.N_CZDDXTY.ToString();
            this.drptyabcrf.SelectedValue = mo_ZQ.N_ABCRFTY.ToString();
            this.drptybbcrf.SelectedValue = mo_ZQ.N_BBCRFTY.ToString();
            this.drptycbcrf.SelectedValue = mo_ZQ.N_CBCRFTY.ToString();
            this.drptyabcdx.SelectedValue = mo_ZQ.N_ABCDXTY.ToString();
            this.drptybbcdx.SelectedValue = mo_ZQ.N_BBCDXTY.ToString();
            this.drptycbcdx.SelectedValue = mo_ZQ.N_CBCDXTY.ToString();
            this.drptyabcdy.SelectedValue = mo_ZQ.N_ABCDYTY.ToString();
            this.drptybbcdy.SelectedValue = mo_ZQ.N_BBCDYTY.ToString();
            this.drptycbcdy.SelectedValue = mo_ZQ.N_CBCDYTY.ToString();
            this.drptyarqs.SelectedValue = mo_ZQ.N_ARQSTY.ToString();
            this.drptybrqs.SelectedValue = mo_ZQ.N_BRQSTY.ToString();
            this.drptycrqs.SelectedValue = mo_ZQ.N_CRQSTY.ToString();
            this.drptyabd.SelectedValue = mo_ZQ.N_ABDTY.ToString();
            this.drptybbd.SelectedValue = mo_ZQ.N_BBDTY.ToString();
            this.drptycbd.SelectedValue = mo_ZQ.N_CBDTY.ToString();
            this.drptyabqc.SelectedValue = mo_ZQ.N_ABQCTY.ToString();
            this.drptybbqc.SelectedValue = mo_ZQ.N_BBQCTY.ToString();
            this.drptycbqc.SelectedValue = mo_ZQ.N_CBQCTY.ToString();
            this.drptyagg.SelectedValue = mo_ZQ.N_AGGTY.ToString();
            this.drptybgg.SelectedValue = mo_ZQ.N_BGGTY.ToString();
            this.drptycgg.SelectedValue = mo_ZQ.N_CGGTY.ToString();
            this.drptyagj.SelectedValue = mo_ZQ.N_AGJTY.ToString();
            this.drptybgj.SelectedValue = mo_ZQ.N_BGJTY.ToString();
            this.drptycgj.SelectedValue = mo_ZQ.N_CGJTY.ToString();
        }

        /// <summary>
        /// 大總監上級帳號賦值（大總監默認拆賬）
        /// </summary>
        public void DZJFZ()
        {
           
            KFB_MRZJ mo_mrzj = new KFB_MRZJ();
            mo_mrzj = this.objAgentManageAddDB.GetModel();
            this.lbdzrf.Text = mo_mrzj.N_ZQRFDZ.ToString();
            this.lbdcrf.Text = mo_mrzj.N_ZQRFDC.ToString();
            this.lbdzdx.Text = mo_mrzj.N_ZQDXDZ.ToString();
            this.lbdcdx.Text = mo_mrzj.N_ZQDXDC.ToString(); ;
            this.lbdzdy.Text = mo_mrzj.N_ZQDYDZ.ToString();
            this.lbdcdy.Text = mo_mrzj.N_ZQDYDC.ToString();
            this.lbdzds.Text = mo_mrzj.N_ZQDSDZ.ToString();
            this.lbdcds.Text = mo_mrzj.N_ZQDSDC.ToString();
            this.lbdzzdrf.Text = mo_mrzj.N_ZQZDRFDZ.ToString();
            this.lbdczdrf.Text = mo_mrzj.N_ZQZDRFDC.ToString();
            this.lbdzzddx.Text = mo_mrzj.N_ZQZDDXDZ.ToString();
            this.lbdczddx.Text = mo_mrzj.N_ZQZDDXDC.ToString();
            this.lbdzbcrf.Text = mo_mrzj.N_ZQBCRFDZ.ToString();
            this.lbdcbcrf.Text = mo_mrzj.N_ZQBCRFDC.ToString();
            this.lbdzbcdx.Text = mo_mrzj.N_ZQBCDXDZ.ToString();
            this.lbdcbcdx.Text = mo_mrzj.N_ZQBCDXDC.ToString(); ;
            this.lbdzbcdy.Text = mo_mrzj.N_ZQBCDYDZ.ToString();
            this.lbdcbcdy.Text = mo_mrzj.N_ZQBCDYDC.ToString();
            this.lbdzrqs.Text = mo_mrzj.N_ZQRQSDZ.ToString();
            this.lbdcrqs.Text = mo_mrzj.N_ZQRQSDC.ToString();
            this.lbdzbd.Text = mo_mrzj.N_ZQBDDZ.ToString();
            this.lbdcbd.Text = mo_mrzj.N_ZQBDDC.ToString();
            this.lbdzbqc.Text = mo_mrzj.N_ZQBQCDZ.ToString();
            this.lbdcbqc.Text = mo_mrzj.N_ZQBQCDC.ToString();
            this.lbdzgg.Text = mo_mrzj.N_ZQGGDZ.ToString();
            this.lbdcgg.Text = mo_mrzj.N_ZQGGDC.ToString();
            this.lbdzgj.Text = mo_mrzj.N_ZQGJDZ.ToString();
            this.lbdcgj.Text = mo_mrzj.N_ZQGJDC.ToString();
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQABCDXTY.Value / 100), this.drptyabcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQABCDYTY.Value / 100), this.drptyabcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQABCRFTY.Value / 100), this.drptyabcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQABDTY.Value / 100), this.drptyabd);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQABQCTY.Value / 100), this.drptyabqc);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQADSTY.Value / 100), this.drptyads);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQADXTY.Value / 100), this.drptyadx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQADYTY.Value / 100), this.drptyady);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQAGGTY.Value / 100), this.drptyagg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQAGJTY.Value / 100), this.drptyagj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQARFTY.Value / 100), this.drptyarf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQARQSTY.Value / 100), this.drptyarqs);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQAZDDXTY.Value / 100), this.drptyazddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQAZDRFTY.Value / 100), this.drptyazdrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBBCDXTY.Value / 100), this.drptybbcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBBCDYTY.Value / 100), this.drptybbcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBBCRFTY.Value / 100), this.drptybbcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBBDTY.Value / 100), this.drptybbd);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBBQCTY.Value / 100), this.drptybbqc);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBDSTY.Value / 100), this.drptybds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBDXTY.Value / 100), this.drptybdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBDYTY.Value / 100), this.drptybdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBGGTY.Value / 100), this.drptybgg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBGJTY.Value / 100), this.drptybgj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBRFTY.Value / 100), this.drptybrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBRQSTY.Value / 100), this.drptybrqs);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBZDDXTY.Value / 100), this.drptybzddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQBZDRFTY.Value / 100), this.drptybzdrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCBCDXTY.Value / 100), this.drptycbcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCBCDYTY.Value / 100), this.drptycbcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCBCRFTY.Value / 100), this.drptycbcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCBDTY.Value / 100), this.drptycbd);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCBQCTY.Value / 100), this.drptycbqc);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCDSTY.Value / 100), this.drptycds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCDXTY.Value / 100), this.drptycdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCDYTY.Value / 100), this.drptycdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCGGTY.Value / 100), this.drptycgg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCGJTY.Value / 100), this.drptycgj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCRFTY.Value / 100), this.drptycrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCRQSTY.Value / 100), this.drptycrqs);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCZDDXTY.Value / 100), this.drptyczddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_ZQCZDRFTY.Value / 100), this.drptyczdrf);


            string s_TYA = "N_ZQABCDXTY,N_ZQABCDYTY,N_ZQABCRFTY,N_ZQABDTY,N_ZQABQCTY,N_ZQADSTY,N_ZQADXTY,N_ZQADYTY,N_ZQAGGTY,N_ZQARFTY,N_ZQARQSTY,N_ZQAZDDXTY,N_ZQAZDRFTY";
            string s_LeastA = this.objAgentManageAddDB.GetLeast("kfb_mrzj", "least", s_TYA, " where n_update=(select max(n_update) from kfb_mrzj)");

            string s_TYB = "N_ZQBBCDXTY,N_ZQBBCDYTY,N_ZQBBCRFTY,N_ZQBBDTY,N_ZQBBQCTY,N_ZQBDSTY,N_ZQBDXTY,N_ZQBDYTY,N_ZQBGGTY,N_ZQBRFTY,N_ZQBRQSTY,N_ZQBZDDXTY,N_ZQBZDRFTY";
            string s_LeastB = this.objAgentManageAddDB.GetLeast("kfb_mrzj", "least", s_TYB, " where n_update=(select max(n_update) from kfb_mrzj)");

            string s_TYC = "N_ZQCBCDXTY,N_ZQCBCDYTY,N_ZQCBCRFTY,N_ZQCBDTY,N_ZQCBQCTY,N_ZQCDSTY,N_ZQCDXTY,N_ZQCDYTY,N_ZQCGGTY,N_ZQCRFTY,N_ZQCRQSTY,N_ZQCZDDXTY,N_ZQCZDRFTY";
            string s_LeastC = this.objAgentManageAddDB.GetLeast("kfb_mrzj", "least", s_TYC, " where n_update=(select max(n_update) from kfb_mrzj)");

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastA) / 100, this.drptyaall);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastB) / 100, this.drptyball);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastC) / 100, this.drptycall);

        }

        /// <summary>
        /// 上級帳號上層賦值
        /// </summary>
        public void ZHFZ(string strparid, string strlvl)
        {
           
            string strzh = "";
            if (strlvl == "10")
            {

                KFB_HYGL mo_hygl = this.objAgentManageDB.GetModelHYGL(strparid);
                strzh = mo_hygl.N_DLDH;
            }
            else
            {
                strzh = Comm.GetUPID(strparid, strlvl);
            }

            KFB_SETUPZQ mo_ZQ = this.objAgentManageAddDB.GetModelZQ(strzh);
            this.lbdzrf.Text = mo_ZQ.N_RFDZ.ToString();
            this.lbdcrf.Text = mo_ZQ.N_RFDC.ToString();
            this.lbdzdx.Text = mo_ZQ.N_DXDZ.ToString();
            this.lbdcdx.Text = mo_ZQ.N_DXDC.ToString();
            this.lbdzdy.Text = mo_ZQ.N_DYDZ.ToString();
            this.lbdcdy.Text = mo_ZQ.N_DYDC.ToString();
            this.lbdzds.Text = mo_ZQ.N_DSDZ.ToString();
            this.lbdcds.Text = mo_ZQ.N_DSDC.ToString();
            this.lbdzzdrf.Text = mo_ZQ.N_ZDRFDZ.ToString();
            this.lbdczdrf.Text = mo_ZQ.N_ZDRFDC.ToString();
            this.lbdzzddx.Text = mo_ZQ.N_ZDDXDZ.ToString();
            this.lbdczddx.Text = mo_ZQ.N_ZDDXDC.ToString();
            this.lbdzbcrf.Text = mo_ZQ.N_BCRFDZ.ToString();
            this.lbdcbcrf.Text = mo_ZQ.N_BCRFDC.ToString();
            this.lbdzbcdx.Text = mo_ZQ.N_BCDXDZ.ToString();
            this.lbdcbcdx.Text = mo_ZQ.N_BCDXDC.ToString();
            this.lbdzbcdy.Text = mo_ZQ.N_BCDYDZ.ToString();
            this.lbdcbcdy.Text = mo_ZQ.N_BCDYDC.ToString();
            this.lbdzrqs.Text = mo_ZQ.N_RQSDZ.ToString();
            this.lbdcrqs.Text = mo_ZQ.N_RQSDC.ToString();
            this.lbdzbd.Text = mo_ZQ.N_BDDZ.ToString();
            this.lbdcbd.Text = mo_ZQ.N_BDDC.ToString();
            this.lbdzbqc.Text = mo_ZQ.N_BQCDZ.ToString();
            this.lbdcbqc.Text = mo_ZQ.N_BQCDC.ToString();
            this.lbdzgg.Text = mo_ZQ.N_GGDZ.ToString();
            this.lbdcgg.Text = mo_ZQ.N_GGDC.ToString();
            this.lbdzgj.Text = mo_ZQ.N_GJDZ.ToString();
            this.lbdcgj.Text = mo_ZQ.N_GJDC.ToString();

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ABCDXTY.Value / 100), this.drptyabcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ABCDYTY.Value / 100), this.drptyabcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ABCRFTY.Value / 100), this.drptyabcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ABDTY.Value / 100), this.drptyabd);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ABQCTY.Value / 100), this.drptyabqc);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ADSTY.Value / 100), this.drptyads);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ADXTY.Value / 100), this.drptyadx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ADYTY.Value / 100), this.drptyady);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_AGGTY.Value / 100), this.drptyagg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_AGJTY.Value / 100), this.drptyagj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ARFTY.Value / 100), this.drptyarf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_ARQSTY.Value / 100), this.drptyarqs);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_AZDDXTY.Value / 100), this.drptyazddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_AZDRFTY.Value / 100), this.drptyazdrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BBCDXTY.Value / 100), this.drptybbcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BBCDYTY.Value / 100), this.drptybbcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BBCRFTY.Value / 100), this.drptybbcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BBDTY.Value / 100), this.drptybbd);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BBQCTY.Value / 100), this.drptybbqc);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BDSTY.Value / 100), this.drptybds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BDXTY.Value / 100), this.drptybdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BDYTY.Value / 100), this.drptybdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BGGTY.Value / 100), this.drptybgg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BGJTY.Value / 100), this.drptybgj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BRFTY.Value / 100), this.drptybrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BRQSTY.Value / 100), this.drptybrqs);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BZDDXTY.Value / 100), this.drptybzddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_BZDRFTY.Value / 100), this.drptybzdrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CBCDXTY.Value / 100), this.drptycbcdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CBCDYTY.Value / 100), this.drptycbcdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CBCRFTY.Value / 100), this.drptycbcrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CBDTY.Value / 100), this.drptycbd);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CBQCTY.Value / 100), this.drptycbqc);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CDSTY.Value / 100), this.drptycds);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CDXTY.Value / 100), this.drptycdx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CDYTY.Value / 100), this.drptycdy);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CGGTY.Value / 100), this.drptycgg);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CGJTY.Value / 100), this.drptycgj);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CRFTY.Value / 100), this.drptycrf);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CRQSTY.Value / 100), this.drptycrqs);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CZDDXTY.Value / 100), this.drptyczddx);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_ZQ.N_CZDRFTY.Value / 100), this.drptyczdrf);

            string s_TYA = "N_ABCDXTY,N_ABCDYTY,N_ABCRFTY,N_ABDTY,N_ABQCTY,N_ADSTY,N_ADXTY,N_ADYTY,N_AGGTY,N_ARFTY,N_ARQSTY,N_AZDDXTY,N_AZDRFTY";
            string s_LeastA = this.objAgentManageAddDB.GetLeast("kfb_setupzq", "least", s_TYA, " where n_hyzh='" + GetUser + "'");

            string s_TYB = "N_BBCDXTY,N_BBCDYTY,N_BBCRFTY,N_BBDTY,N_BBQCTY,N_BDSTY,N_BDXTY,N_BDYTY,N_BGGTY,N_BRFTY,N_BRQSTY,N_BZDDXTY,N_BZDRFTY";
            string s_LeastB = objAgentManageAddDB.GetLeast("kfb_setupzq", "least", s_TYB, " where n_hyzh='" + GetUser + "'");

            string s_TYC = "N_CBCDXTY,N_CBCDYTY,N_CBCRFTY,N_CBDTY,N_CBQCTY,N_CDSTY,N_CDXTY,N_CDYTY,N_CGGTY,N_CRFTY,N_CRQSTY,N_CZDDXTY,N_CZDRFTY";
            string s_LeastC = objAgentManageAddDB.GetLeast("kfb_setupzq", "least", s_TYC, " where n_hyzh='" + GetUser + "'");

            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastA) / 100, this.drptyaall);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastB) / 100, this.drptyball);
            Comm.SetTS(Comm.Fcjg, Convert.ToDouble(s_LeastC) / 100, this.drptycall);
        }

        /// <summary>
        /// 取得下級的設置
        /// </summary>
        /// <param name="strlvl"></param>
        /// <param name="strparid"></param>
        public void GetSUB(string strlvl, string strparid)
        {
            
            KFB_SETUPZQ mo_ZQ = this.objAgentManageAddDB.GetModelZQ(strlvl, strparid);
            string strSpName = "(" + Comm.GetLvSName(Convert.ToString(Convert.ToDecimal(strlvl) + 1)) + ")";
            this.lbtyarft.Text = strSpName + mo_ZQ.N_ARFTY.ToString();
            this.lbtybrft.Text = strSpName + mo_ZQ.N_BRFTY.ToString();
            this.lbtycrft.Text = strSpName + mo_ZQ.N_CRFTY.ToString();
            this.lbdzrft.Text = strSpName + mo_ZQ.N_RFDZ.ToString();
            this.lbdcrft.Text = strSpName + mo_ZQ.N_RFDC.ToString();
            this.lbtyadxt.Text = strSpName + mo_ZQ.N_ADXTY.ToString();
            this.lbtybdxt.Text = strSpName + mo_ZQ.N_BDXTY.ToString();
            this.lbtycdxt.Text = strSpName + mo_ZQ.N_CDXTY.ToString();
            this.lbdzdxt.Text = strSpName + mo_ZQ.N_DXDZ.ToString();
            this.lbdcdxt.Text = strSpName + mo_ZQ.N_DXDC.ToString();
            this.lbtyadyt.Text = strSpName + mo_ZQ.N_ADYTY.ToString();
            this.lbtybdyt.Text = strSpName + mo_ZQ.N_BDYTY.ToString();
            this.lbtycdyt.Text = strSpName + mo_ZQ.N_CDYTY.ToString();
            this.lbdzdyt.Text = strSpName + mo_ZQ.N_DYDZ.ToString();
            this.lbdcdyt.Text = strSpName + mo_ZQ.N_DYDC.ToString();
            this.lbtyadst.Text = strSpName + mo_ZQ.N_ADSTY.ToString();
            this.lbtybdst.Text = strSpName + mo_ZQ.N_BDSTY.ToString();
            this.lbtycdst.Text = strSpName + mo_ZQ.N_CDSTY.ToString();
            this.lbdzdst.Text = strSpName + mo_ZQ.N_DSDZ.ToString();
            this.lbdcdst.Text = strSpName + mo_ZQ.N_DSDC.ToString();
            this.lbtyazdrft.Text = strSpName + mo_ZQ.N_AZDRFTY.ToString();
            this.lbtybzdrft.Text = strSpName + mo_ZQ.N_BZDRFTY.ToString();
            this.lbtyczdrft.Text = strSpName + mo_ZQ.N_CZDRFTY.ToString();
            this.lbdzzdrft.Text = strSpName + mo_ZQ.N_ZDRFDZ.ToString();
            this.lbdczdrft.Text = strSpName + mo_ZQ.N_ZDRFDC.ToString();
            this.lbtyazddxt.Text = strSpName + mo_ZQ.N_AZDDXTY.ToString();
            this.lbtybzddxt.Text = strSpName + mo_ZQ.N_BZDDXTY.ToString();
            this.lbtyczddxt.Text = strSpName + mo_ZQ.N_CZDDXTY.ToString();
            this.lbdzzddxt.Text = strSpName + mo_ZQ.N_ZDDXDZ.ToString();
            this.lbdczddxt.Text = strSpName + mo_ZQ.N_ZDDXDC.ToString();
            this.lbtyabcrft.Text = strSpName + mo_ZQ.N_ABCRFTY.ToString();
            this.lbtybbcrft.Text = strSpName + mo_ZQ.N_BBCRFTY.ToString();
            this.lbtycbcrft.Text = strSpName + mo_ZQ.N_CBCRFTY.ToString();
            this.lbdzbcrft.Text = strSpName + mo_ZQ.N_BCRFDZ.ToString();
            this.lbdcbcrft.Text = strSpName + mo_ZQ.N_BCRFDC.ToString();
            this.lbtyabcdxt.Text = strSpName + mo_ZQ.N_ABCDXTY.ToString();
            this.lbtybbcdxt.Text = strSpName + mo_ZQ.N_BBCDXTY.ToString();
            this.lbtycbcdxt.Text = strSpName + mo_ZQ.N_CBCDXTY.ToString();
            this.lbdzbcdxt.Text = strSpName + mo_ZQ.N_BCDXDZ.ToString();
            this.lbdcbcdxt.Text = strSpName + mo_ZQ.N_BCDXDC.ToString();
            this.lbtyabcdyt.Text = strSpName + mo_ZQ.N_ABCDYTY.ToString();
            this.lbtybbcdyt.Text = strSpName + mo_ZQ.N_BBCDYTY.ToString();
            this.lbtycbcdyt.Text = strSpName + mo_ZQ.N_CBCDYTY.ToString();
            this.lbdzbcdyt.Text = strSpName + mo_ZQ.N_BCDYDZ.ToString();
            this.lbdcbcdyt.Text = strSpName + mo_ZQ.N_BCDYDC.ToString();
            this.lbtyarqst.Text = strSpName + mo_ZQ.N_ARQSTY.ToString();
            this.lbtybrqst.Text = strSpName + mo_ZQ.N_BRQSTY.ToString();
            this.lbtycrqst.Text = strSpName + mo_ZQ.N_CRQSTY.ToString();
            this.lbdzrqst.Text = strSpName + mo_ZQ.N_RQSDZ.ToString();
            this.lbdcrqst.Text = strSpName + mo_ZQ.N_RQSDC.ToString();
            this.lbtyabdt.Text = strSpName + mo_ZQ.N_ABDTY.ToString();
            this.lbtybbdt.Text = strSpName + mo_ZQ.N_BBDTY.ToString();
            this.lbtycbdt.Text = strSpName + mo_ZQ.N_CBDTY.ToString();
            this.lbdzbdt.Text = strSpName + mo_ZQ.N_BDDZ.ToString();
            this.lbdcbdt.Text = strSpName + mo_ZQ.N_BDDC.ToString();
            this.lbtyabqct.Text = strSpName + mo_ZQ.N_ABQCTY.ToString();
            this.lbtybbqct.Text = strSpName + mo_ZQ.N_BBQCTY.ToString();
            this.lbtycbqct.Text = strSpName + mo_ZQ.N_CBQCTY.ToString();
            this.lbdzbqct.Text = strSpName + mo_ZQ.N_BQCDZ.ToString();
            this.lbdcbqct.Text = strSpName + mo_ZQ.N_BQCDC.ToString();
            this.lbtyaggt.Text = strSpName + mo_ZQ.N_AGGTY.ToString();
            this.lbtybggt.Text = strSpName + mo_ZQ.N_BGGTY.ToString();
            this.lbtycggt.Text = strSpName + mo_ZQ.N_CGGTY.ToString();
            this.lbdzggt.Text = strSpName + mo_ZQ.N_GGDZ.ToString();
            this.lbdcggt.Text = strSpName + mo_ZQ.N_GGDC.ToString();
            this.lbtyagjt.Text = strSpName + mo_ZQ.N_AGJTY.ToString();
            this.lbtybgjt.Text = strSpName + mo_ZQ.N_BGJTY.ToString();
            this.lbtycgjt.Text = strSpName + mo_ZQ.N_CGJTY.ToString();
            this.lbdzgjt.Text = strSpName + mo_ZQ.N_GJDZ.ToString();
            this.lbdcgjt.Text = strSpName + mo_ZQ.N_GJDC.ToString();
        }

        #endregion
    }
