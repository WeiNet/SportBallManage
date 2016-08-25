#region histroy
///程式代號：      DelayedManager
///程式名稱：      DelayedManager
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion


public partial class GameLimit : BasePage
{
    #region 全局变量
    GameLimitDB objGameLimitDB = new GameLimitDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//頁面首次加載
        {
            this.grvLimitBase.PageSize = Convert.ToInt32(this.mPageSize);//設定GridView每個頁簽顯示的資料筆數
            this.setJS();
            this.SetData();
            this.bindGrid();
            this.QuerySingle("ALL");
            this.QueryCourt();
        }

    }

   

    #endregion

    #region 按钮事件
    protected void drpSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        QueryCourt();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        try
        {
          
            DataSet ds = objGameLimitDB.GetLimitDetail(this.txtFZBH.Text.ToString().ToUpper());
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                ShowMsg("无符合条件资料");
                SetData();
                return;
            }
            else
            {
                ViewState["Old"] = dt;
                this.hidFlag.Value = "1";//修改状态
                this.txt1.Text = dt.Rows[0]["n_credit"].ToString();
                this.txt2.Text = dt.Rows[1]["n_credit"].ToString();
                this.txt3.Text = dt.Rows[2]["n_credit"].ToString();
                this.txt4.Text = dt.Rows[3]["n_credit"].ToString();
                this.txt5.Text = dt.Rows[4]["n_credit"].ToString();
                this.txtFZBH.Text = dt.Rows[0]["n_site"].ToString();
                this.btnAdd.Text = "修改分站限红";
                this.WriteLog(this.mUserID + " 修改前分站" + this.txtFZBH.Text + " 限红为" + this.txt1.Text + ";" + this.txt2.Text + ";" + this.txt3.Text + ";" + this.txt4.Text + ";" + this.txt5.Text);
            }
        }
        catch (Exception ex)
        {
            ShowMsg("查询失败，请联系管理员");
            this.WriteLog(ex.ToString());
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            decimal d1 = 0;
            decimal d2 = 0;
            decimal d3 = 0;
            decimal d4 = 0;
            decimal d5 = 0;

            decimal.TryParse(this.txt1.Text.ToString(), out d1);
            decimal.TryParse(this.txt2.Text.ToString(), out d2);
            decimal.TryParse(this.txt3.Text.ToString(), out d3);
            decimal.TryParse(this.txt4.Text.ToString(), out d4);
            decimal.TryParse(this.txt5.Text.ToString(), out d5);
            List<decimal> creditlist = new List<decimal>();

            creditlist.Add(d1);
            creditlist.Add(d2);
            creditlist.Add(d3);
            creditlist.Add(d4);
            creditlist.Add(d5);

            DataSet ds = objGameLimitDB.GetLimitDetail(this.txtFZBH.Text.ToString().ToUpper());
            DataTable dt = ds.Tables[0];
      
            if (dt.Rows.Count > 0 && this.hidFlag.Value == "0")
            {
                ShowMsg("已经存在改分站的限红，不能新增。");
                return;
            }
            if (this.hidFlag.Value == "1")
            {
                DataTable dtOld = ViewState["Old"] as DataTable;
               bool flag= objGameLimitDB.ModifyLimitDetail(dtOld.Rows[0]["N_Site"].ToString(), this.txtFZBH.Text.Trim().ToUpper(), creditlist);
               if (flag)
               {
                   ShowMsg("修改成功");
               }
               else {
                   ShowMsg("修改失败");
               }
             
                this.WriteLog(this.mUserID + " 修改分站" + dtOld.Rows[0]["N_Site"].ToString() + "为" + this.txtFZBH.Text + " 限红为" + this.txt1.Text + ";" + this.txt2.Text + ";" + this.txt3.Text + ";" + this.txt4.Text + ";" + this.txt5.Text);

            }
            else
            {
                bool flag = objGameLimitDB.AddLimitDetail(this.txtFZBH.Text.Trim().ToUpper(), creditlist);
                if (flag)
                {
                    ShowMsg("新增成功");
                }
                else
                {
                    ShowMsg("新增失败");
                }
                this.WriteLog(this.mUserID + " 新增分站" + this.txtFZBH.Text + " 限红" + this.txt1.Text + ";" + this.txt2.Text + ";" + this.txt3.Text + ";" + this.txt4.Text + ";" + this.txt5.Text);
           
            }
            SetData();
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
             this.ShowMsg("操作失败，请联系管理员");
        }
    }

    #endregion

    #region grid事件
    protected void grvLimitBase_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strPlayValue = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "N_PLAYVALUE").ToString());
            string courtType = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_courttype").ToString());
            string playName = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_playtype").ToString());
            TextBox txtPlayValue = (TextBox)e.Row.FindControl("grvtxtPlayValue");
            HiddenField hidPlayType = (HiddenField)e.Row.FindControl("hidPlayType");
            HiddenField hidCourtType = (HiddenField)e.Row.FindControl("hidCourtType");
            ImageButton grvibtnUpdate = (ImageButton)e.Row.FindControl("grvibtnUpdate");
            if (txtPlayValue != null)
            {  
                txtPlayValue.Attributes.Add("onkeypress", "return inputNubmer();");//Email的驗證
                grvibtnUpdate.Attributes.Add("onclick", "return funSave('" + txtPlayValue.ClientID + "');");
                txtPlayValue.Text = strPlayValue;
            } if (hidPlayType != null)
            {
                hidPlayType.Value = playName;
            }
            if (hidCourtType != null)
            {
                hidCourtType.Value = courtType;
            }




            switch (playName)
            {
                case "RF":
                    playName = "让分";
                    break;
                case "DX":
                    playName = "大小";
                    break;
                case "DY":
                    playName = "独赢";
                    break;
                case "DS":
                    playName = "单双";
                    break;
                case "HJ":
                    playName = "和局";
                    break;
                case "ZDRF":
                    playName = "滚球让分";
                    break;
                case "ZDDX":
                    playName = "滚球大小";
                    break;
                case "ZDDY":
                    playName = "滚球独赢";
                    break;
                case "ZDHJ":
                    playName = "滚球和局";
                    break;
                case "RQS":
                    playName = "入球数";
                    break;
                case "BQC":
                    playName = "半全场";
                    break;
                case "BD":
                    playName = "波胆";
                    break;
                case "GG":
                    playName = "过关";
                    break;
            }
            if (courtType.Equals("1"))//场别类型
            {
                playName = "全场" + playName;
            }
            else if (courtType.Equals("2"))
            {
                playName = "上半场" + playName;
            }
            else
            {
                playName = "下半场" + playName;
            }
            e.Row.Cells[0].Text = playName;

        }
    }

    protected void grvLimitBase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.grvLimitBase.EditIndex = e.NewEditIndex;
        this.bindGrid();//查詢
    }

    protected void grvLimitBase_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.grvLimitBase.EditIndex = -1;
        this.bindGrid();//查詢

    }

    protected void grvLimitBase_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            string strPlayType = ((HiddenField)this.grvLimitBase.Rows[e.RowIndex].FindControl("hidPlayType")).Value.Trim();
            string strCourtType = ((HiddenField)this.grvLimitBase.Rows[e.RowIndex].FindControl("hidCourtType")).Value.Trim();
            string strPlayValue = ((TextBox)this.grvLimitBase.Rows[e.RowIndex].FindControl("grvtxtPlayValue")).Text.Trim();

            int i = objGameLimitDB.UpdateLimitBase(strPlayType, Convert.ToDecimal(strPlayValue), Convert.ToInt32(strCourtType));
            if (i > 0)
            {
                
                grvLimitBase.EditIndex = -1;
                this.bindGrid();
                this.ShowMsg("修改成功");
            }
            else
            {
                this.ShowMsg("修改失败");
            }

          

        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("修改失败");
        }


    }
    protected void grvLimitSingle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strN_LEVEL = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "N_LEVEL").ToString());
            string strN_CREDIT = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "N_CREDIT").ToString());
            ImageButton grvibtnUpdate = (ImageButton)e.Row.FindControl("grvibtnUpdate");
            TextBox grvtxtCREDIT = (TextBox)e.Row.FindControl("grvtxtCREDIT");
            HiddenField hidLEVEL = (HiddenField)e.Row.FindControl("hidLEVEL");
            if (grvtxtCREDIT != null)
            {
                grvtxtCREDIT.Attributes.Add("onkeypress", "return inputNubmer();");//Email的驗證
                grvibtnUpdate.Attributes.Add("onclick", "return funSave('" + grvtxtCREDIT.ClientID + "');");
                grvtxtCREDIT.Text = strN_CREDIT;
            } if (hidLEVEL != null)
            {
                hidLEVEL.Value = strN_LEVEL;
            }
         
        }

    }
    protected void grvLimitSingle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvLimitSingle.EditIndex = -1;
        QuerySingle("ALL");
    }

    protected void grvLimitSingle_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvLimitSingle.EditIndex = e.NewEditIndex;
        QuerySingle("ALL");

    }

    protected void grvLimitSingle_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      
        try
        {

            string strLEVEL = ((HiddenField)this.grvLimitSingle.Rows[e.RowIndex].FindControl("hidLEVEL")).Value.Trim();
            string strCREDIT = ((TextBox)this.grvLimitSingle.Rows[e.RowIndex].FindControl("grvtxtCREDIT")).Text.Trim();

            int i = objGameLimitDB.UpdateLimitDetail("ALL", Convert.ToInt32(strLEVEL), Convert.ToDecimal(strCREDIT));
            if (i > 0)
            {
                
                grvLimitSingle.EditIndex = -1;
                QuerySingle("ALL");
                this.ShowMsg("修改成功");
            }
            else
            {
                this.ShowMsg("修改失败");
            }



        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("修改失败");
        }

    }
   
    protected void grvLimitCourt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strN_LEVEL = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "N_LEVEL").ToString());
            string strN_CREDIT = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "N_CREDIT").ToString());
            ImageButton grvibtnUpdate = (ImageButton)e.Row.FindControl("grvibtnUpdate");
            TextBox grvtxtCREDIT = (TextBox)e.Row.FindControl("grvtxtCREDIT");
            HiddenField hidLEVEL = (HiddenField)e.Row.FindControl("hidLEVEL");
            if (grvtxtCREDIT != null)
            {
                grvtxtCREDIT.Attributes.Add("onkeypress", "return inputNubmer();");//Email的驗證
                grvibtnUpdate.Attributes.Add("onclick", "return funSave('" + grvtxtCREDIT.ClientID + "');");
                grvtxtCREDIT.Text = strN_CREDIT;
            } if (hidLEVEL != null)
            {
                hidLEVEL.Value = strN_LEVEL;
            }

        }

    }

   

    protected void grvLimitCourt_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvLimitCourt.EditIndex = e.NewEditIndex;
        QueryCourt();
    }

    protected void grvLimitCourt_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
         try
        {

            string strLEVEL = ((HiddenField)this.grvLimitCourt.Rows[e.RowIndex].FindControl("hidLEVEL")).Value.Trim();
            string strCREDIT = ((TextBox)this.grvLimitCourt.Rows[e.RowIndex].FindControl("grvtxtCREDIT")).Text.Trim();

            int i = objGameLimitDB.UpdateLimitDetail(this.drpSite.SelectedValue, Convert.ToInt32(strLEVEL), Convert.ToDecimal(strCREDIT));
            if (i > 0)
            {
                grvLimitCourt.EditIndex = -1;
                QueryCourt();
                this.ShowMsg("修改成功");
               
            }
            else
            {
                this.ShowMsg("修改失败");
            }



        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("修改失败");
        }

    }

    protected void grvLimitCourt_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvLimitCourt.EditIndex = -1;
        QueryCourt();

    }
    #endregion

    #region 自定义事件

    private void bindGrid()
    {
        try
        {
            DataSet DS = new DataSet();
            DS = objGameLimitDB.GetLimitBase();
            DataTable DT = new DataTable();
            DT = DS.Tables[0];
            if (DT.Rows.Count > 0)
            {
                this.grvLimitBase.DataSource = DT;
                this.grvLimitBase.DataBind();

            }
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("查询失败");
        }

    }
    /// <summary>
    /// 获取单注设定
    /// </summary>
    private void QuerySingle(string strFlag)
    {
        try
        {
            DataSet DS = new DataSet();
            DS = objGameLimitDB.GetLimitDetail(strFlag);
            DataTable DT = new DataTable();
            DT = DS.Tables[0];
            if (DT.Rows.Count > 0)
            {
                this.grvLimitSingle.DataSource = DT;
                this.grvLimitSingle.DataBind();

            }
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("查询失败");
        }
    
    }
    public void SetData()
    {
        this.txt1.Text = "10000";
        this.txt2.Text = "20000";
        this.txt3.Text = "30000";
        this.txt4.Text = "60000";
        this.txt5.Text = "100000";
        this.txtFZBH.Text = "";
        this.hidFlag.Value = "0";//新增状态

        this.drpSite.DataSource = objGameLimitDB.GetSiteList();//查询分站
        this.drpSite.DataTextField = "n_site";
        this.drpSite.DataValueField = "n_site";
        this.drpSite.DataBind();
        this.btnAdd.Text = "新增分站限红";
    }
    /// <summary>
    /// 根据不同的分站编号取得不同的单场设定
    /// </summary>
    private void QueryCourt()
    {
        try
        {
            DataSet DS = new DataSet();
            DS = objGameLimitDB.GetLimitDetail(this.drpSite.SelectedValue);
            DataTable DT = new DataTable();
            DT = DS.Tables[0];
            if (DT.Rows.Count > 0)
            {
                this.grvLimitCourt.DataSource = DT;
                this.grvLimitCourt.DataBind();

            }
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("查询失败");
        }


        
    }
    private void setJS()
    {
        this.btnQuery.Attributes.Add("onclick", "return funQuery();");
        this.btnAdd.Attributes.Add("onclick", "return funAdd();");
    }

    #endregion

   

    

  

    



}
