#region History
///程式代號：      GameCalculation
///程式名稱：      GameCalculation
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

    public partial class GameCalculation :BasePage
    {
        #region 全局变量
        private string pageName = "";

        #endregion
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["bt"] != null)
            {
                switch (Request["bt"])
                {
                    case "b_zq":
                        this.lblball.Text = "足球";
                        pageName = "football";
                        break;
                    case "b_bf":
                        this.lblball.Text = "美足";
                        pageName = "basketball";
                        break;
                    case "b_cq":
                        this.lblball.Text = "彩球";
                        pageName = "basketball";
                        break;
                    case "b_bk":
                        this.lblball.Text = "籃球";
                        pageName = "basketball";
                        break;
                    case "b_bj":
                        this.lblball.Text = "棒球";
                        pageName = "baseball";
                        break;
                    case "b_bq":
                        this.lblball.Text = "冰球";
                        pageName = "baseball";
                        break;
                    case "b_by":
                        this.lblball.Text = "网球";
                        pageName = "baseball";
                        break;
                    case "b_bb":
                        this.lblball.Text = "排球";
                        pageName = "baseball";
                        break;
                }
            }
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    string s_NID = Request["id"].ToString();
                    BaseBallDB objBaseBallDB = new BaseBallDB();
                    DataTable dt = objBaseBallDB.GetRusult(s_NID).Tables[0];
                    this.lblLM.Text = dt.Rows[0]["LM"].ToString();
                    this.lblCB.Text = dt.Rows[0]["CB"].ToString();
                    this.lblDM.Text = dt.Rows[0]["CB"].ToString();
                    this.lblDW.Text = dt.Rows[0]["DW"].ToString();
                    this.lblBSTime.Text = dt.Rows[0]["n_gamedate"].ToString();
                    if (dt.Rows[0]["CB"].Equals("全場") || dt.Rows[0]["CB"].Equals("全场"))
                    {
                        this.trUp.Visible = true;
                    }
                    else
                    {
                        this.trUp.Visible = false;
                    }
                    this.txtVisit.Value = dt.Rows[0]["n_visit_result"].ToString();
                    this.txtHome.Value = dt.Rows[0]["n_home_result"].ToString();
                    this.txtVisit_Up.Value = dt.Rows[0]["n_up_visit_result"].ToString();
                    this.txtHome_Up.Value = dt.Rows[0]["n_up_home_result"].ToString();
                    this.txtRemark.Value = dt.Rows[0]["n_remark"].ToString();
                    this.lblCountDate.Text = dt.Rows[0]["n_counttime"].ToString();
                    if (Request["pt"].Equals("7"))
                    {
                        this.trCountTime.Visible = false;
                        this.ViewState.Add("CBXH", this.Context.Items["CBXH"]);
                        this.ViewState.Add("SFXZ", this.Context.Items["SFXZ"]);
                        this.ViewState.Add("PAGE", this.Context.Items["PAGE"]);
                        this.ViewState.Add("LEAGUE", this.Context.Items["LEAGUE"]);
                        this.ViewState.Add("CurrPage", this.Context.Items["CurrPage"]);
                    }
                    else if (Request["pt"].Equals("8"))
                    {
                        this.ViewState.Add("DATE", this.Context.Items["DATE"]);
                        this.ViewState.Add("PAGE", this.Context.Items["PAGE"]);
                        this.rdoSF9J.SelectedValue = dt.Rows[0]["n_sf9j"].ToString();
                    }
                    else if (Request["pt"].Equals("9"))
                    {
                        this.ViewState.Add("VISIT", this.Context.Items["VISIT"]);
                        this.ViewState.Add("HOME", this.Context.Items["HOME"]);
                        this.ViewState.Add("LMDW", this.Context.Items["LMDW"]);
                        this.ViewState.Add("PAGE", this.Context.Items["PAGE"]);
                        this.rdoSF9J.SelectedValue = dt.Rows[0]["n_sf9j"].ToString();
                    }
                }
                else
                {
                    this.btnCount.Visible = false;
                }
            }
        }
        #endregion

        

        #region 按钮事件
        protected void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                GameCalculationDB o_KFB_BASEBALL_BLL = new GameCalculationDB();
                string s_NID = Request["id"].ToString();
                KFB_BASEBALL o_KFB_BASEBALL = o_KFB_BASEBALL_BLL.GetModel(Convert.ToInt32(s_NID));
                o_KFB_BASEBALL.N_VISIT_RESULT = Convert.ToDecimal(this.txtVisit.Value);
                o_KFB_BASEBALL.N_HOME_RESULT = Convert.ToDecimal(this.txtHome.Value);
                o_KFB_BASEBALL.N_REMARK = this.txtRemark.Value;
                if (this.trUp.Visible)
                {
                    o_KFB_BASEBALL.N_UP_VISIT_RESULT = Convert.ToDecimal(this.txtVisit_Up.Value);
                    o_KFB_BASEBALL.N_UP_HOME_RESULT = Convert.ToDecimal(this.txtHome_Up.Value);
                }
                o_KFB_BASEBALL.N_SF9J = Convert.ToInt32(this.rdoSF9J.SelectedValue);

                string flag = "0";
                if (Request["pt"].Equals("9"))
                {
                    flag = "1";
                }
                else
                {
                    flag = "0";
                }
                GameCalculationBLL objGameCalculationBLL = new GameCalculationBLL();
                objGameCalculationBLL.BallCount(this.txtVisit.Value, this.txtHome.Value, s_NID, this.rdoSF9J.SelectedValue,
                    this.txtVisit_Up.Value, this.txtHome_Up.Value, flag, this.txtRemark.Value);
                this.ShowMsg("比賽結果設置成功，注單計算成功！");
                this.trCountTime.Visible = true;
                o_KFB_BASEBALL.N_COUNTTIME = DateTime.Now;
                this.lblCountDate.Text = o_KFB_BASEBALL.N_COUNTTIME.ToString();
            }
            catch (Exception ex)
            {
               this.WriteLog("用户名=" + mUserID+ex);
                ex.ToString();
                ShowMsg("計算失敗");
            }
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region gridview事件
        #endregion

        #region 自定义事件
        #endregion

    }
