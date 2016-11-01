using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SM_set : BasePage
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
            #region"修改赛马設定檔"
            KFB_SETUPSM mo_sm = new KFB_SETUPSM();
            Hashtable GetSql = new Hashtable();
            KFB_ZHGL mo_zhgl = new KFB_ZHGL();
            mo_zhgl = this.objAgentManageDB.GetModel(this.lblName.Text.ToString().Trim());

            mo_sm.N_HYDH = this.lblName.Text;
            mo_sm.N_DYTY = Convert.ToDecimal(this.drptydy.Text);
            mo_sm.N_DYDZ = Convert.ToDecimal(this.txtdzdy.Text);
            mo_sm.N_DYDC = Convert.ToDecimal(this.txtdcdy.Text);
            mo_sm.N_WZTY = Convert.ToDecimal(this.drptywz.Text);
            mo_sm.N_WZDZ = Convert.ToDecimal(this.txtdzwz.Text);
            mo_sm.N_WZDC = Convert.ToDecimal(this.txtdcwz.Text);
            mo_sm.N_LYTY = Convert.ToDecimal(this.drptyly.Text);
            mo_sm.N_LYDZ = Convert.ToDecimal(this.txtdzly.Text);
            mo_sm.N_LYDC = Convert.ToDecimal(this.txtdcly.Text);
            mo_sm.N_WZQTY = Convert.ToDecimal(this.drptywzq.Text);
            mo_sm.N_WZQDZ = Convert.ToDecimal(this.txtdzwzq.Text);
            mo_sm.N_WZQDC = Convert.ToDecimal(this.txtdcwzq.Text);
            this.objAgentManageDB.UpdateSM(mo_sm, GetSql);

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
                        objAgentManageDB.Update("sm", strvalue[0].ToString(), strvalue[1].ToString(), strZH);
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



       
        KFB_SETUPSM mo_ZQ = this.objAgentManageAddDB.GetModelSM(this.GetUser);

        this.txtdzdy.Text = mo_ZQ.N_DYDZ.ToString();
        this.txtdcdy.Text = mo_ZQ.N_DYDC.ToString();
        this.txtdzwz.Text = mo_ZQ.N_WZDZ.ToString();
        this.txtdcwz.Text = mo_ZQ.N_WZDC.ToString();
        this.txtdzly.Text = mo_ZQ.N_LYDZ.ToString();
        this.txtdcly.Text = mo_ZQ.N_LYDC.ToString();
        this.txtdzwzq.Text = mo_ZQ.N_WZQDZ.ToString();
        this.txtdcwzq.Text = mo_ZQ.N_WZQDC.ToString();

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

        this.drptydy.SelectedValue = mo_ZQ.N_DYTY.ToString();
        this.drptywz.SelectedValue = mo_ZQ.N_WZTY.ToString();
        this.drptyly.SelectedValue = mo_ZQ.N_LYTY.ToString();
        this.drptywzq.SelectedValue = mo_ZQ.N_WZQTY.ToString();

    }



    /// <summary>
    /// 大總監上級帳號賦值（大總監默認拆賬）
    /// </summary>
    public void DZJFZ()
    {

       
        KFB_MRZJ mo_mrzj = new KFB_MRZJ();
        mo_mrzj = this.objAgentManageAddDB.GetModel();

        this.lbdzdy.Text = mo_mrzj.N_SMDZDY.ToString();
        this.lbdcdy.Text = mo_mrzj.N_SMDCDY.ToString();
        this.lbdzwz.Text = mo_mrzj.N_SMDZWZ.ToString();
        this.lbdcwz.Text = mo_mrzj.N_SMDCWZ.ToString();
        this.lbdzly.Text = mo_mrzj.N_SMDZLY.ToString();
        this.lbdcly.Text = mo_mrzj.N_SMDCLY.ToString();
        this.lbdzwzq.Text = mo_mrzj.N_SMDZWZQ.ToString();
        this.lbdcwzq.Text = mo_mrzj.N_SMDCWZQ.ToString();

        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_SMTYDY.Value / 100), this.drptydy);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_SMTYWZ.Value / 100), this.drptywz);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_SMTYLY.Value / 100), this.drptyly);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_mrzj.N_SMTYWZQ.Value / 100), this.drptywzq);

        //string s_TYA = "N_ZSDSTY,N_ZSDXTY,N_ZSDYTY,N_ZSRFTY,N_ZSZDDXTY,N_ZSZDRFTY,N_ZSSYTY,N_ZSBDTY,N_ZSGJTY ";
        string s_TYA = "N_SMTYDY,N_SMTYWZ,N_SMTYLY,N_SMTYWZQ ";
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
        KFB_SETUPSM mo_lq = this.objAgentManageAddDB.GetModelSM(strzh);

        this.lbdzdy.Text = mo_lq.N_DYDZ.ToString();
        this.lbdcdy.Text = mo_lq.N_DYDC.ToString();
        this.lbdzwz.Text = mo_lq.N_WZDZ.ToString();
        this.lbdcwz.Text = mo_lq.N_WZDC.ToString();
        this.lbdzly.Text = mo_lq.N_LYDZ.ToString();
        this.lbdcly.Text = mo_lq.N_LYDC.ToString();
        this.lbdzwzq.Text = mo_lq.N_WZQDZ.ToString();
        this.lbdcwzq.Text = mo_lq.N_WZQDC.ToString();

        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_DYTY.Value / 100), this.drptydy);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_WZTY.Value / 100), this.drptywz);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_LYTY.Value / 100), this.drptyly);
        Comm.SetTS(Comm.Fcjg, Convert.ToDouble(mo_lq.N_WZQTY.Value / 100), this.drptywzq);

        //string s_TYA = "N_DSTY,N_DXTY,N_DYTY,N_GGTY,N_RFTY,N_ZDRFTY,N_ZDDXTY,N_BDTY,N_SYTY,N_GJTY";
        string s_TYA = "N_DYTY,N_WZTY,N_LYTY,N_WZQTY";
        string s_LeastA = this.objAgentManageAddDB.GetLeast("kfb_setupsm", "least", s_TYA, " where n_hydh='" + GetUser + "'");

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
        KFB_SETUPSM mo_lq = this.objAgentManageAddDB.GetModelSM(strlvl, strparid);
        this.lbtydyt.Text = strSpName + mo_lq.N_DYTY.ToString();
        this.lbdzdyt.Text = strSpName + mo_lq.N_DYDZ.ToString();
        this.lbdcdyt.Text = strSpName + mo_lq.N_DYDC.ToString();
        this.lbtywzt.Text = strSpName + mo_lq.N_WZTY.ToString();
        this.lbdzwzt.Text = strSpName + mo_lq.N_WZDZ.ToString();
        this.lbdcwzt.Text = strSpName + mo_lq.N_WZDC.ToString();
        this.lbtylyt.Text = strSpName + mo_lq.N_LYTY.ToString();
        this.lbdzlyt.Text = strSpName + mo_lq.N_LYDZ.ToString();
        this.lbdclyt.Text = strSpName + mo_lq.N_LYDC.ToString();
        this.lbtywzqt.Text = strSpName + mo_lq.N_WZQTY.ToString();
        this.lbdzwzqt.Text = strSpName + mo_lq.N_WZQDZ.ToString();
        this.lbdcwzqt.Text = strSpName + mo_lq.N_WZQDC.ToString();
    }

    #endregion
}
