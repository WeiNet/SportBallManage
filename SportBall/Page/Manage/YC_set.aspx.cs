using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class YC_set : BasePage
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
            #region"修改運彩設定檔"
            KFB_SETUPCP mo_cp = new KFB_SETUPCP();
            Hashtable GetSql = new Hashtable();
            KFB_ZHGL mo_zhgl = new KFB_ZHGL();
            mo_zhgl = this.objAgentManageDB.GetModel(this.lblName.Text.ToString().Trim());

            mo_cp.N_HYDH = this.lblName.Text;
            mo_cp.N_BQTY = Convert.ToDecimal(this.drptybq.Text);
            mo_cp.N_BQDZ = Convert.ToDecimal(this.txtdzbq.Text);
            mo_cp.N_BQDC = Convert.ToDecimal(this.txtdcbq.Text);
            mo_cp.N_LQTY = Convert.ToDecimal(this.drptylq.Text);
            mo_cp.N_LQDZ = Convert.ToDecimal(this.txtdzlq.Text);
            mo_cp.N_LQDC = Convert.ToDecimal(this.txtdclq.Text);
            mo_cp.N_ZQTY = Convert.ToDecimal(this.drptyzq.Text);
            mo_cp.N_ZQDZ = Convert.ToDecimal(this.txtdzzq.Text);
            mo_cp.N_ZQDC = Convert.ToDecimal(this.txtdczq.Text);
            mo_cp.N_GSTY = Convert.ToDecimal(this.drptygs.Text);
            mo_cp.N_GSDZ = Convert.ToDecimal(this.txtdzgs.Text);
            mo_cp.N_GSDC = Convert.ToDecimal(this.txtdcgs.Text);
            mo_cp.N_QZTY = Convert.ToDecimal(this.drptyqz.Text);
            mo_cp.N_QZDZ = Convert.ToDecimal(this.txtdzqz.Text);
            mo_cp.N_QZDC = Convert.ToDecimal(this.txtdcqz.Text);
            this.objAgentManageDB.UpdateCP(mo_cp, GetSql);

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
                        objAgentManageDB.Update("cp", strvalue[0].ToString(), strvalue[1].ToString(), strZH);
                    }
                }
            }
            #endregion


            this.ShowMsg( "修改成功！");
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

        KFB_SETUPCP mo_ZQ = this.objAgentManageAddDB.GetModelCP(this.GetUser);
        this.txtdzbq.Text = mo_ZQ.N_BQDZ.ToString();
        this.txtdcbq.Text = mo_ZQ.N_BQDC.ToString();
        this.txtdzlq.Text = mo_ZQ.N_LQDZ.ToString();
        this.txtdclq.Text = mo_ZQ.N_LQDC.ToString();
        this.txtdzzq.Text = mo_ZQ.N_ZQDZ.ToString();
        this.txtdczq.Text = mo_ZQ.N_ZQDC.ToString();
        this.txtdzgs.Text = mo_ZQ.N_GSDZ.ToString();
        this.txtdcgs.Text = mo_ZQ.N_GSDC.ToString();
        this.txtdzqz.Text = mo_ZQ.N_QZDZ.ToString();
        this.txtdcqz.Text = mo_ZQ.N_QZDC.ToString();

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

        this.drptybq.SelectedValue = mo_ZQ.N_BQTY.ToString();
        this.drptylq.SelectedValue = mo_ZQ.N_BQDC.ToString();
        this.drptyzq.SelectedValue = mo_ZQ.N_ZQTY.ToString();
        this.drptygs.SelectedValue = mo_ZQ.N_GSTY.ToString();
        this.drptyqz.SelectedValue = mo_ZQ.N_QZTY.ToString();

    }



    /// <summary>
    /// 大總監上級帳號賦值（大總監默認拆賬）
    /// </summary>
    public void DZJFZ()
    {
       
        KFB_MRZJ mo_mrzj = new KFB_MRZJ();
        mo_mrzj = this.objAgentManageAddDB.GetModel();


        this.lbdzbq.Text = mo_mrzj.N_CPDZBQ.ToString();
        this.lbdcbq.Text = mo_mrzj.N_CPDCBQ.ToString();
        this.lbdzlq.Text = mo_mrzj.N_CPDZLQ.ToString();
        this.lbdclq.Text = mo_mrzj.N_CPDCLQ.ToString();
        this.lbdzzq.Text = mo_mrzj.N_CPDZZQ.ToString();
        this.lbdczq.Text = mo_mrzj.N_CPDCZQ.ToString();
        this.lbdzgs.Text = mo_mrzj.N_CPDZGS.ToString();
        this.lbdcgs.Text = mo_mrzj.N_CPDCGS.ToString();
        this.lbdzqz.Text = mo_mrzj.N_CPDZQZ.ToString();
        this.lbdcqz.Text = mo_mrzj.N_CPDCQZ.ToString();

        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CPTYBQ.Value / 100), this.drptybq);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CPTYLQ.Value / 100), this.drptylq);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CPTYZQ.Value / 100), this.drptyzq);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CPTYGS.Value / 100), this.drptygs);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_CPTYQZ.Value / 100), this.drptyqz);


        string s_TYA = "N_CPTYBQ,N_CPTYLQ,N_CPTYZQ,N_CPTYGS,N_CPTYQZ ";
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
        KFB_SETUPCP mo_lq = this.objAgentManageAddDB.GetModelCP(strzh);

        this.lbdzbq.Text = mo_lq.N_BQDZ.ToString();
        this.lbdcbq.Text = mo_lq.N_BQDC.ToString();
        this.lbdzlq.Text = mo_lq.N_LQDZ.ToString();
        this.lbdclq.Text = mo_lq.N_LQDC.ToString();
        this.lbdzzq.Text = mo_lq.N_ZQDZ.ToString();
        this.lbdczq.Text = mo_lq.N_ZQDC.ToString();
        this.lbdzgs.Text = mo_lq.N_GSDZ.ToString();
        this.lbdcgs.Text = mo_lq.N_GSDC.ToString();
        this.lbdzqz.Text = mo_lq.N_QZDZ.ToString();
        this.lbdcqz.Text = mo_lq.N_QZDC.ToString();

        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_BQTY.Value / 100), this.drptybq);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_LQTY.Value / 100), this.drptylq);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_ZQTY.Value / 100), this.drptyzq);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_GSTY.Value / 100), this.drptygs);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_QZTY.Value / 100), this.drptyqz);

        string s_TYA = "N_BQTY,N_LQTY,N_ZQTY,N_GSTY,N_QZTY";
        string s_LeastA = this.objAgentManageAddDB.GetLeast("kfb_setupcp", "least", s_TYA, " where n_hydh='" + GetUser + "'");

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
        KFB_SETUPCP mo_lq = this.objAgentManageAddDB.GetModelCP(strlvl, strparid);

        this.lbtybqt.Text = mo_lq.N_BQTY.ToString();
        this.lbdzbqt.Text = mo_lq.N_BQDZ.ToString();
        this.lbdcbqt.Text = mo_lq.N_BQDC.ToString();
        this.lbtylqt.Text = mo_lq.N_LQTY.ToString();
        this.lbdzlqt.Text = mo_lq.N_LQDZ.ToString();
        this.lbdclqt.Text = mo_lq.N_LQDC.ToString();
        this.lbtyzqt.Text = mo_lq.N_ZQTY.ToString();
        this.lbdzzqt.Text = mo_lq.N_ZQDZ.ToString();
        this.lbdczqt.Text = mo_lq.N_ZQDC.ToString();
        this.lbtygst.Text = mo_lq.N_GSTY.ToString();
        this.lbdzgst.Text = mo_lq.N_GSDZ.ToString();
        this.lbdcgst.Text = mo_lq.N_GSDC.ToString();
        this.lbtyqzt.Text = mo_lq.N_QZTY.ToString();
        this.lbdzqzt.Text = mo_lq.N_QZDZ.ToString();
        this.lbdcqzt.Text = mo_lq.N_QZDC.ToString();
    }

    #endregion
}
