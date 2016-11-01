using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class QZ_set : BasePage
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
            #region"修改彩球設定檔"
            KFB_SETUPCQ mo_cq = new KFB_SETUPCQ();
            Hashtable GetSql = new Hashtable();
            KFB_ZHGL mo_zhgl = new KFB_ZHGL();
            mo_zhgl = this.objAgentManageDB.GetModel(this.lblName.Text.ToString().Trim());

            mo_cq.N_HYZH = this.lblName.Text;
            mo_cq.N_RFTY = Convert.ToDecimal(this.drptyrf.Text);
            mo_cq.N_RFDZ = Convert.ToDecimal(this.txtdzrf.Text);
            mo_cq.N_RFDC = Convert.ToDecimal(this.txtdcrf.Text);
            mo_cq.N_DXTY = Convert.ToDecimal(this.drptydx.Text);
            mo_cq.N_DXDZ = Convert.ToDecimal(this.txtdzdx.Text);
            mo_cq.N_DXDC = Convert.ToDecimal(this.txtdcdx.Text);
            mo_cq.N_DYTY = Convert.ToDecimal(this.drptydy.Text);
            mo_cq.N_DYDZ = Convert.ToDecimal(this.txtdzdy.Text);
            mo_cq.N_DYDC = Convert.ToDecimal(this.txtdcdy.Text);
            mo_cq.N_DSTY = Convert.ToDecimal(this.drptyds.Text);
            mo_cq.N_DSDZ = Convert.ToDecimal(this.txtdzds.Text);
            mo_cq.N_DSDC = Convert.ToDecimal(this.txtdcds.Text);
            mo_cq.N_ZDRFTY = Convert.ToDecimal(this.drptyzdrf.Text);
            mo_cq.N_ZDRFDZ = Convert.ToDecimal(this.txtdzzdrf.Text);
            mo_cq.N_ZDRFDC = Convert.ToDecimal(this.txtdczdrf.Text);
            mo_cq.N_ZDDXTY = Convert.ToDecimal(this.drptyzddx.Text);
            mo_cq.N_ZDDXDZ = Convert.ToDecimal(this.txtdzzddx.Text);
            mo_cq.N_ZDDXDC = Convert.ToDecimal(this.txtdczddx.Text);
            mo_cq.N_BCRFTY = Convert.ToDecimal(this.drptybcrf.Text);
            mo_cq.N_BCRFDZ = Convert.ToDecimal(this.txtdzbcrf.Text);
            mo_cq.N_BCRFDC = Convert.ToDecimal(this.txtdcbcrf.Text);
            mo_cq.N_BCDXTY = Convert.ToDecimal(this.drptybcdx.Text);
            mo_cq.N_BCDXDZ = Convert.ToDecimal(this.txtdzbcdx.Text);
            mo_cq.N_BCDXDC = Convert.ToDecimal(this.txtdcbcdx.Text);
            mo_cq.N_BCDYTY = Convert.ToDecimal(this.drptybcdy.Text);
            mo_cq.N_BCDYDZ = Convert.ToDecimal(this.txtdzbcdy.Text);
            mo_cq.N_BCDYDC = Convert.ToDecimal(this.txtdcbcdy.Text);
            mo_cq.N_BCDSTY = Convert.ToDecimal(this.drptybcds.Text);
            mo_cq.N_BCDSDZ = Convert.ToDecimal(this.txtdzbcds.Text);
            mo_cq.N_BCDSDC = Convert.ToDecimal(this.txtdcbcds.Text);
            mo_cq.N_GGTY = Convert.ToDecimal(this.drptygg.Text);
            mo_cq.N_GGDZ = Convert.ToDecimal(this.txtdzgg.Text);
            mo_cq.N_GGDC = Convert.ToDecimal(this.txtdcgg.Text);
            mo_cq.N_GJTY = Convert.ToDecimal(this.drptygj.Text);
            mo_cq.N_GJDZ = Convert.ToDecimal(this.txtdzgj.Text);
            mo_cq.N_GJDC = Convert.ToDecimal(this.txtdcgj.Text);
            this.objAgentManageDB.UpdateCQ(mo_cq, GetSql);

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
                        objAgentManageDB.Update("cq", strvalue[0].ToString(), strvalue[1].ToString(), strZH);
                    }
                }
            }
            #endregion


            this.ShowMsg("修改成功！");
        }
        catch (Exception ex)
        {
            this.ShowMsg("修改失敗，請通知管理員！");
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

       
        KFB_SETUPCQ mo_ZQ = this.objAgentManageAddDB.GetModelCQ(this.GetUser);

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
        this.txtdzgg.Text = mo_ZQ.N_GGDZ.ToString();
        this.txtdcgg.Text = mo_ZQ.N_GGDC.ToString();

        this.txtdzbcdx.Text = mo_ZQ.N_BCDXDZ.ToString();
        this.txtdcbcdx.Text = mo_ZQ.N_BCDXDC.ToString();
        this.txtdzbcdy.Text = mo_ZQ.N_BCDYDZ.ToString();
        this.txtdcbcdy.Text = mo_ZQ.N_BCDYDC.ToString();
        this.txtdzbcds.Text = mo_ZQ.N_BCDSDZ.ToString();
        this.txtdcbcds.Text = mo_ZQ.N_BCDSDC.ToString();
        this.txtdzbcrf.Text = mo_ZQ.N_BCRFDZ.ToString();
        this.txtdcbcrf.Text = mo_ZQ.N_BCRFDC.ToString();
        this.txtdzgj.Text = mo_ZQ.N_GJDZ.ToString();
        this.txtdcgj.Text = mo_ZQ.N_GJDC.ToString();





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
        this.drptygg.SelectedValue = mo_ZQ.N_GGTY.ToString();
        this.drptyrf.SelectedValue = mo_ZQ.N_RFTY.ToString();
        this.drptybcdx.SelectedValue = mo_ZQ.N_BCDXTY.ToString();
        this.drptybcds.SelectedValue = mo_ZQ.N_BCDSTY.ToString();
        this.drptybcdy.SelectedValue = mo_ZQ.N_BCDYTY.ToString();
        this.drptybcrf.SelectedValue = mo_ZQ.N_BCRFTY.ToString();
        this.drptygj.SelectedValue = mo_ZQ.N_GJTY.ToString();

    }



    /// <summary>
    /// 大總監上級帳號賦值（大總監默認拆賬）
    /// </summary>
    public void DZJFZ()
    {
       
        KFB_MRZJ mo_mrzj = new KFB_MRZJ();
        mo_mrzj = this.objAgentManageAddDB.GetModel();

        this.lbdzrf.Text = mo_mrzj.N_CQRFDZ.ToString();
        this.lbdcrf.Text = mo_mrzj.N_CQRFDC.ToString();
        this.lbdzdx.Text = mo_mrzj.N_CQDXDZ.ToString();
        this.lbdcdx.Text = mo_mrzj.N_CQDXDC.ToString();
        this.lbdzdy.Text = mo_mrzj.N_CQDYDZ.ToString();
        this.lbdcdy.Text = mo_mrzj.N_CQDYDC.ToString();
        this.lbdzds.Text = mo_mrzj.N_CQDSDZ.ToString();
        this.lbdcds.Text = mo_mrzj.N_CQDSDC.ToString();
        this.lbdzzdrf.Text = mo_mrzj.N_CQZDRFDZ.ToString();
        this.lbdczdrf.Text = mo_mrzj.N_CQZDRFDC.ToString();
        this.lbdzzddx.Text = mo_mrzj.N_CQZDDXDZ.ToString();
        this.lbdczddx.Text = mo_mrzj.N_CQZDDXDC.ToString();
        this.lbdzgg.Text = mo_mrzj.N_CQGGDZ.ToString();
        this.lbdcgg.Text = mo_mrzj.N_CQGGDC.ToString();

        this.lbdzbcdx.Text = mo_mrzj.N_CQBCDXDZ.ToString();
        this.lbdcbcdx.Text = mo_mrzj.N_CQBCDXDC.ToString();
        this.lbdzbcdy.Text = mo_mrzj.N_CQBCDYDZ.ToString();
        this.lbdcbcdy.Text = mo_mrzj.N_CQBCDYDC.ToString();
        this.lbdzbcds.Text = mo_mrzj.N_CQBCDSDZ.ToString();
        this.lbdcbcds.Text = mo_mrzj.N_CQBCDSDC.ToString();
        this.lbdzbcrf.Text = mo_mrzj.N_CQBCRFDZ.ToString();
        this.lbdcbcrf.Text = mo_mrzj.N_CQBCRFDC.ToString();
        this.lbdzgj.Text = mo_mrzj.N_CQGJDZ.ToString();
        this.lbdcgj.Text = mo_mrzj.N_CQGJDC.ToString();

        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQDSTY.Value / 100), this.drptyds);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQDXTY.Value / 100), this.drptydx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQDYTY.Value / 100), this.drptydy);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQGGTY.Value / 100), this.drptygg);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQRFTY.Value / 100), this.drptyrf);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQZDDXTY.Value / 100), this.drptyzddx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQZDRFTY.Value / 100), this.drptyzdrf);


        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQBCDXTY.Value / 100), this.drptybcdx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQBCDSTY.Value / 100), this.drptybcds);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQBCDYTY.Value / 100), this.drptybcdy);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQGJTY.Value / 100), this.drptygj);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CQBCRFTY.Value / 100), this.drptybcrf);

        string s_TYA = "N_CQDSTY,N_CQDXTY,N_CQDYTY,N_CQRFTY,N_CQZDDXTY,N_CQZDRFTY,N_CQBCDXTY,N_CQBCDSTY,N_CQBCDYTY,N_CQGJTY,N_CQBCRFTY";
        string s_LeastA = objAgentManageAddDB.GetLeast("kfb_mrzj", "least", s_TYA, " where n_update=(select max(n_update) from kfb_mrzj)");

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
        KFB_SETUPCQ mo_lq = this.objAgentManageAddDB.GetModelCQ(strzh);

        this.lbdzrf.Text = mo_lq.N_RFDZ.ToString();
        this.lbdzdx.Text = mo_lq.N_DXDZ.ToString();
        this.lbdzdy.Text = mo_lq.N_DYDZ.ToString();
        this.lbdzds.Text = mo_lq.N_DSDZ.ToString();
        this.lbdzzdrf.Text = mo_lq.N_ZDRFDZ.ToString();
        this.lbdzzddx.Text = mo_lq.N_ZDDXDZ.ToString();
        this.lbdzgg.Text = mo_lq.N_GGDZ.ToString();
        this.lbdcrf.Text = mo_lq.N_RFDC.ToString();
        this.lbdcdx.Text = mo_lq.N_DXDC.ToString();
        this.lbdcdy.Text = mo_lq.N_DYDC.ToString();
        this.lbdcds.Text = mo_lq.N_DSDC.ToString();
        this.lbdczdrf.Text = mo_lq.N_ZDRFDC.ToString();
        this.lbdczddx.Text = mo_lq.N_ZDDXDC.ToString();
        this.lbdcgg.Text = mo_lq.N_GGDC.ToString();

        this.lbdzbcdx.Text = mo_lq.N_BCDXDZ.ToString();
        this.lbdcbcdx.Text = mo_lq.N_BCDXDC.ToString();
        this.lbdzbcdy.Text = mo_lq.N_BCDYDZ.ToString();
        this.lbdcbcdy.Text = mo_lq.N_BCDYDC.ToString();
        this.lbdzbcds.Text = mo_lq.N_BCDSDZ.ToString();
        this.lbdcbcds.Text = mo_lq.N_BCDSDC.ToString();
        this.lbdzbcrf.Text = mo_lq.N_BCRFDZ.ToString();
        this.lbdcbcrf.Text = mo_lq.N_BCRFDC.ToString();
        this.lbdzgj.Text = mo_lq.N_GJDZ.ToString();
        this.lbdcgj.Text = mo_lq.N_GJDC.ToString();


        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DSTY.Value / 100), this.drptyds);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DXTY.Value / 100), this.drptydx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DYTY.Value / 100), this.drptydy);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_GGTY.Value / 100), this.drptygg);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_RFTY.Value / 100), this.drptyrf);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_ZDRFTY.Value / 100), this.drptyzdrf);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_ZDDXTY.Value / 100), this.drptyzddx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCDXTY.Value / 100), this.drptybcdx);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCDSTY.Value / 100), this.drptybcds);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCDYTY.Value / 100), this.drptybcdy);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_GJTY.Value / 100), this.drptygj);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BCRFTY.Value / 100), this.drptybcrf);


        string s_TYA = "N_DSTY,N_DXTY,N_DYTY,N_RFTY,N_ZDRFTY,N_ZDDXTY,N_BCDXTY,N_BCDSTY,N_BCDYTY,N_GJTY,N_BCRFTY";
        string s_LeastA = this.objAgentManageAddDB.GetLeast("kfb_setupcq", "least", s_TYA, " where n_hyzh='" + GetUser + "'");

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
        KFB_SETUPCQ mo_lq = this.objAgentManageAddDB.GetModelCQ(strlvl, strparid);
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
        this.lbtyggt.Text = strSpName + mo_lq.N_GGTY.ToString();
        this.lbdzggt.Text = strSpName + mo_lq.N_GGDZ.ToString();
        this.lbdcggt.Text = strSpName + mo_lq.N_GGDC.ToString();

        this.lbdzbcdxt.Text = strSpName + mo_lq.N_BCDXDZ.ToString();
        this.lbdcbcdxt.Text = strSpName + mo_lq.N_BCDXDC.ToString();
        this.lbtybcdxt.Text = strSpName + mo_lq.N_BCDXTY.ToString();

        this.lbdzbcdyt.Text = strSpName + mo_lq.N_BCDYDZ.ToString();
        this.lbdcbcdyt.Text = strSpName + mo_lq.N_BCDYDC.ToString();
        this.lbtybcdyt.Text = strSpName + mo_lq.N_BCDYTY.ToString();

        this.lbdzbcdst.Text = strSpName + mo_lq.N_BCDSDZ.ToString();
        this.lbdcbcdst.Text = strSpName + mo_lq.N_BCDSDC.ToString();
        this.lbtybcdst.Text = strSpName + mo_lq.N_BCDSTY.ToString();

        this.lbdzgjt.Text = strSpName + mo_lq.N_GJDZ.ToString();
        this.lbdcgjt.Text = strSpName + mo_lq.N_GJDC.ToString();
        this.lbtygjt.Text = strSpName + mo_lq.N_GJTY.ToString();

        this.lbdzbcrft.Text = strSpName + mo_lq.N_BCRFDZ.ToString();
        this.lbdcbcrft.Text = strSpName + mo_lq.N_BCRFDC.ToString();
        this.lbtybcrft.Text = strSpName + mo_lq.N_BCRFTY.ToString();
    }

    #endregion
}
