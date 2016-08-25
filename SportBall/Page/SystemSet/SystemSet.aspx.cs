#region histroy
///程式代號：      SystemSet
///程式名稱：      SystemSet
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region Using

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class SystemSet : BasePage
{
    #region 全局变量
    SystemSetDB objSysSet = new SystemSetDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.setJS();
            this.getData();
        }
    }




    #endregion

    #region 按鈕事件(Button Events)
    protected void btnreset_Click(object sender, EventArgs e)
    {
        objSysSet.ResetED();
        objSysSet.UpdateResetEDDate(DateTime.Now.ToString("yyyyMMdd"));
        this.ShowMsg("重置成功");
        this.btnreset.Text = "今日已重設";
        this.btnreset.Enabled = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (objSysSet.Exists())
        {
            int i = objSysSet.Update(this.GetKFB_XTSZ());
            if (i > 0)
            {
                this.ShowMsg("存儲成功");
            }
            else
            {
                this.ShowMsg("存储失败");
            }
        }
        else
        {
            int i = objSysSet.Add(this.GetKFB_XTSZ());
            if (i > 0)
            {
                this.ShowMsg("存儲成功");
            }
            else
            {
                this.ShowMsg("存储失败");
            }

        }



    }
    #endregion

    #region Grid事件(Grid Events)
    #endregion

    #region 自定義方法(Definition Private Methods)
    private void setJS()
    {
        this.textDate.Attributes.Add("onblur", "gChangeDate(this);");
        this.textFinishDate.Attributes.Add("onblur", "gChangeDate(this);");


    }
    //初始化数据
    private void getData()
    {
        try
        {
            DataSet DS = new DataSet();
            DS = objSysSet.getData();
            DataTable DT = new DataTable();
            DT = DS.Tables[0];
            if (DT.Rows.Count > 0)
            {
                this.dropMode.SelectedValue = DT.Rows[0]["N_XTMS"].ToString();
                this.textDate.Text = DateTime.Parse(DT.Rows[0]["N_ZWRQ"].ToString()).ToString("yyyy-MM-dd");
                this.textFinishDate.Text = DateTime.Parse(DT.Rows[0]["N_GZZWRQ"].ToString()).ToString("yyyy-MM-dd");
                //o_KFB_XTSZ.N_BLTS;
                this.txtn_hl.Value = Comm.SetRound(decimal.Parse(DT.Rows[0]["N_HL"].ToString()), 1);
                this.dropIsHome.SelectedValue = DT.Rows[0]["N_HUSY"].ToString();
                //o_KFB_XTSZ.N_HUXY;
                if (DT.Rows[0]["N_WXJE"].ToString().Equals(""))
                {
                    this.txtn_wxje.Value = Comm.SetRound(decimal.Parse(DT.Rows[0]["N_WXJE"].ToString()), 1);
                }
                if (DT.Rows[0]["N_ZQBPL"].ToString().Equals(""))
                {
                    this.txtn_zqbpl.Value = Comm.SetRound(decimal.Parse(DT.Rows[0]["N_ZQBPL"].ToString()), 3);
                }
                if (DT.Rows[0]["N_ZQAPL"].ToString().Equals(""))
                {
                    this.txtn_zqapl.Value = Comm.SetRound(decimal.Parse(DT.Rows[0]["N_ZQAPL"].ToString()), 3);
                }
                if (DT.Rows[0]["N_GGXS"].ToString().Equals(""))
                {
                    this.txtn_ggxs.Value = Comm.SetRound(decimal.Parse(DT.Rows[0]["N_GGXS"].ToString()), 1);
                }
                if (DT.Rows[0]["N_HYXX"].ToString().Equals(""))
                {
                    this.txtn_hyxx.Value = Comm.SetRound(decimal.Parse(DT.Rows[0]["N_HYXX"].ToString()), 1);
                }
                this.txtn_ycxz.Value = DT.Rows[0]["N_YCXZ"].ToString();
                this.txtn_zdyc.Value = DT.Rows[0]["N_ZDYC"].ToString();
                this.drpn_gbhy.Value = DT.Rows[0]["N_GBHY"].ToString();
                this.txtIP.Text = DT.Rows[0]["N_CPIP"].ToString();
                //o_KFB_XTSZ.N_CX;
                this.dropIsAllow.SelectedValue = DT.Rows[0]["N_XGCZ"].ToString();
                this.drpn_rzcx.Value = DT.Rows[0]["N_RZCX"].ToString();
                this.drpn_cxbb.Value = DT.Rows[0]["N_CXBB"].ToString();
                this.radIsJump.SelectedValue = DT.Rows[0]["N_STATE_JUMPED"].ToString();
                this.txtJumpedMoneyGeneral.Value = DT.Rows[0]["N_JUMPED_CREDIT_GENERAL"].ToString();
                this.txtJumpedMoneySpecial.Value = DT.Rows[0]["N_JUMPED_CREDIT_SPECIAL"].ToString();
                this.txtJumpedRateGeneral.Value = DT.Rows[0]["N_JUMPED_RATE_GENERAL"].ToString();
                this.txtJumpedRateSpecial.Value = DT.Rows[0]["N_JUMPED_RATE_SPECIAL"].ToString();
                this.txtJumpedMaxGeneral.Value = DT.Rows[0]["N_JUMPED_MAX_GENERAL"].ToString();
                this.txtJumpedMaxSpecial.Value = DT.Rows[0]["N_JUMPED_MAX_SPECIAL"].ToString();
                this.txtDelayTimes.Value = DT.Rows[0]["N_DELAY_TIMES"].ToString();
                this.txtDelayTime.Value = DT.Rows[0]["N_DELAY_TIME"].ToString();
                if (DT.Rows[0]["N_CSED"] != null)
                {
                    if (DateTime.Now.ToString("yyyyMMdd").Equals(DT.Rows[0]["N_CSED"]))
                    {
                        this.btnreset.Text = "今日已重設";
                        this.btnreset.Enabled = false;
                    }
                }
            }
            else
            {
                DateTime dt = DateTime.Now;
                this.textDate.Text = dt.ToString("yyyy-MM-dd");
                this.textFinishDate.Text = dt.ToString("yyyy-MM-dd");
            }
        }
        catch (Exception ex)
        {

            this.ShowMsg("查询失败");
            this.WriteLog(ex.ToString());
        }

    }

    private KFB_XTSZ GetKFB_XTSZ()
    {
        KFB_XTSZ o_KFB_XTSZ = new KFB_XTSZ();
        o_KFB_XTSZ.N_XTMS = this.dropMode.SelectedValue;
        o_KFB_XTSZ.N_ZWRQ = Convert.ToDateTime(this.textDate.Text);
        o_KFB_XTSZ.N_GZZWRQ = Convert.ToDateTime(this.textFinishDate.Text);
        o_KFB_XTSZ.N_BLTS = 0;
        o_KFB_XTSZ.N_HL = Convert.ToDecimal(this.txtn_hl.Value);
        o_KFB_XTSZ.N_HUSY = Convert.ToInt32(this.dropIsHome.SelectedValue);
        o_KFB_XTSZ.N_HUXY = 0;
        o_KFB_XTSZ.N_WXJE = Convert.ToDecimal(this.txtn_wxje.Value);
        o_KFB_XTSZ.N_YCXZ = Convert.ToInt32(this.txtn_ycxz.Value);
        o_KFB_XTSZ.N_ZDYC = Convert.ToInt32(this.txtn_zdyc.Value);
        o_KFB_XTSZ.N_ZQBPL = Convert.ToDecimal(this.txtn_zqbpl.Value);
        o_KFB_XTSZ.N_ZQAPL = Convert.ToDecimal(this.txtn_zqapl.Value);
        o_KFB_XTSZ.N_GBHY = Convert.ToInt32(this.drpn_gbhy.Value);
        o_KFB_XTSZ.N_CPIP = this.txtIP.Text;
        o_KFB_XTSZ.N_GGXS = Convert.ToDecimal(this.txtn_ggxs.Value);
        o_KFB_XTSZ.N_CX = 0;
        o_KFB_XTSZ.N_XGCZ = Convert.ToInt32(this.dropIsAllow.SelectedValue);
        o_KFB_XTSZ.N_HYXX = Convert.ToDecimal(this.txtn_hyxx.Value);
        o_KFB_XTSZ.N_RZCX = Convert.ToInt32(this.drpn_rzcx.Value);
        o_KFB_XTSZ.N_CXBB = Convert.ToInt32(this.drpn_cxbb.Value);

        o_KFB_XTSZ.N_STATE_JUMPED = Convert.ToInt32(this.radIsJump.SelectedValue);
        o_KFB_XTSZ.N_JUMPED_CREDIT_GENERAL = Convert.ToDecimal(this.txtJumpedMoneyGeneral.Value);
        o_KFB_XTSZ.N_JUMPED_CREDIT_SPECIAL = Convert.ToDecimal(this.txtJumpedMoneySpecial.Value);
        o_KFB_XTSZ.N_JUMPED_RATE_GENERAL = Convert.ToDecimal(this.txtJumpedRateGeneral.Value);
        o_KFB_XTSZ.N_JUMPED_RATE_SPECIAL = Convert.ToDecimal(this.txtJumpedRateSpecial.Value);
        o_KFB_XTSZ.N_JUMPED_MAX_GENERAL = Convert.ToInt32(this.txtJumpedMaxGeneral.Value);
        o_KFB_XTSZ.N_JUMPED_MAX_SPECIAL = Convert.ToInt32(this.txtJumpedMaxSpecial.Value);
        o_KFB_XTSZ.N_DELAY_TIMES = Convert.ToInt32(this.txtDelayTimes.Value);
        o_KFB_XTSZ.N_DELAY_TIME = Convert.ToInt32(this.txtDelayTime.Value);
        return o_KFB_XTSZ;
    }
    #endregion





}
