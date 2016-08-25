#region histroy
///程式代號：      Union
///程式名稱：      Union
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

public partial class Team : BasePage
{
    #region 全局变量
    private int mi_TYPE = -1;
    TeamDB objTeamDB = new TeamDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ball"] != null)
            {
                switch (Request.QueryString["ball"])
                {
                    case "b_zq":
                        mi_TYPE = 4;
                        this.lblball.Text = "足球";
                        break;
                }
            }
            if (!IsPostBack)
            {
                this.grvTeam.PageSize = Convert.ToInt32(this.mPageSize);//設定GridView每個頁簽顯示的資料筆數
                Query();
            }
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());

            this.ShowMsg("頁面加載失敗");
        }
    }
    #endregion

    #region 按钮事件
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    KFB_LMGL o_KFB_LMGL = new KFB_LMGL();
        //    o_KFB_LMGL.N_LMMC = this.txtName.Text;
        //    o_KFB_LMGL.N_LMMC_EN = this.txtName_EN.Text;
        //    o_KFB_LMGL.N_LMMC_CN = this.txtName_CN.Text;
        //    o_KFB_LMGL.N_LMMC_TW = this.txtName_TW.Text;
        //    o_KFB_LMGL.N_LMMC_TH = this.txtName_TH.Text;
        //    o_KFB_LMGL.N_LX = mi_TYPE;//棒球/冰球
        //    o_KFB_LMGL.N_XH = Convert.ToInt32(this.txtNo.Text);
        //    o_KFB_LMGL.N_LEVEL = Convert.ToInt32(this.drpLevel.SelectedValue);

        //    int i = objUnionDB.Add(o_KFB_LMGL);
        //    if (i > 0)
        //    {

        //        this.txtNo.Text = "";
        //        this.txtName.Text = "";
        //        this.txtName_EN.Text = "";
        //        this.txtName_CN.Text = "";
        //        this.txtName_TW.Text = "";
        //        this.txtName_TH.Text = "";
        //        this.btnAdd.Text = "新增聯盟";
        //        Query();

        //        this.ShowMsg("新增成功");
        //    }
        //    else
        //    {
        //        this.ShowMsg("新增失败");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    this.WriteLog(ex.ToString());
        //    this.ShowMsg("新增失败");
        //}
    }
    #endregion

    #region grid事件
    protected void grvTeam_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
          

            string grvhidNO = ((HiddenField)this.grvTeam.Rows[e.RowIndex].FindControl("grvhidNO")).Value.Trim();
            string grvhidID = ((HiddenField)this.grvTeam.Rows[e.RowIndex].FindControl("grvhidID")).Value.Trim();
            string grvtxtName = ((TextBox)this.grvTeam.Rows[e.RowIndex].FindControl("grvtxtName")).Text.Trim();
            string grvtxtName_EN = ((TextBox)this.grvTeam.Rows[e.RowIndex].FindControl("grvtxtName_EN")).Text.Trim();
            string grvltxtName_CN = ((TextBox)this.grvTeam.Rows[e.RowIndex].FindControl("grvltxtName_CN")).Text.Trim();
            string grvltxtName_TW = ((TextBox)this.grvTeam.Rows[e.RowIndex].FindControl("grvltxtName_TW")).Text.Trim();
            string grvltxtName_TH = ((TextBox)this.grvTeam.Rows[e.RowIndex].FindControl("grvltxtName_TH")).Text.Trim();
         
            KFB_DWGL o_KFB_DWGL = new KFB_DWGL();
            o_KFB_DWGL.N_DWMC = grvtxtName;
            o_KFB_DWGL.N_DWMC_EN = grvtxtName_EN;
            o_KFB_DWGL.N_DWMC_CN = grvltxtName_CN;
            o_KFB_DWGL.N_DWMC_TW = grvltxtName_TW;
            o_KFB_DWGL.N_DWMC_TH = grvltxtName_TH;
            o_KFB_DWGL.N_NO = Convert.ToInt32(grvhidNO);
            o_KFB_DWGL.N_ID = Convert.ToInt32(grvhidID);

            int i = objTeamDB.Update(o_KFB_DWGL); ;
            if (i > 0)
            {

                grvTeam.EditIndex = -1;
                Query();
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

    protected void grvTeam_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.grvTeam.EditIndex = e.NewEditIndex;
        this.Query();//查詢
    }

    protected void grvTeam_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.grvTeam.EditIndex = -1;
        this.Query();//查詢
    }

    protected void grvTeam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strN_NO = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "N_NO").ToString());
            string strn_id = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_id").ToString());
            string strn_dwmc = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_dwmc").ToString());
            string strn_dwmc_EN = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_dwmc_EN").ToString());
            string strn_dwmc_CN = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_dwmc_CN").ToString());
            string strn_dwmc_TW = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_dwmc_TW").ToString());
            string strn_dwmc_TH = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_dwmc_TH").ToString()); 
            ImageButton grvibtnUpdate = (ImageButton)e.Row.FindControl("grvibtnUpdate");
            ImageButton ibtnDelete = (ImageButton)e.Row.FindControl("ibtnDelete"); 
            TextBox grvtxtName = (TextBox)e.Row.FindControl("grvtxtName");
            TextBox grvtxtName_EN = (TextBox)e.Row.FindControl("grvtxtName_EN");
            TextBox grvltxtName_CN = (TextBox)e.Row.FindControl("grvltxtName_CN");
            TextBox grvltxtName_TW = (TextBox)e.Row.FindControl("grvltxtName_TW");
            TextBox grvltxtName_TH = (TextBox)e.Row.FindControl("grvltxtName_TH"); 
            HiddenField grvhidNO = (HiddenField)e.Row.FindControl("grvhidNO");
            HiddenField grvhidID = (HiddenField)e.Row.FindControl("grvhidID");
            if (ibtnDelete != null)
            {
                ibtnDelete.Attributes.Add("onclick", "return funConfirm()");
            }
            if (grvhidID != null)
            {
                grvhidID.Value = strn_id;
            }
            if (grvhidNO != null)
            {
                grvhidNO.Value = strN_NO;
            }
            if (grvtxtName != null)
            {

                grvibtnUpdate.Attributes.Add("onclick", "return funSave('" + grvtxtName.ClientID + "','" + grvtxtName_EN.ClientID + "','" + grvltxtName_CN.ClientID + "','" + grvltxtName_TW.ClientID + "','" + grvltxtName_TH.ClientID + "';");
                grvtxtName.Text = strn_dwmc;
            }
            if (grvtxtName_EN != null)
            {
                grvtxtName_EN.Text = strn_dwmc_EN;
            }
            if (grvltxtName_CN != null)
            {
                grvltxtName_CN.Text = strn_dwmc_CN;
            }
            if (grvltxtName_TW != null)
            {
                grvltxtName_TW.Text = strn_dwmc_TW;
            }
            if (grvltxtName_TH != null)
            {
                grvltxtName_TH.Text = strn_dwmc_TH;
            }
         

        }

    }
    protected void grvTeam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string s_N_ID = ((HiddenField)this.grvTeam.Rows[e.RowIndex].FindControl("grvhidN_ID")).Value;
            int flag = objTeamDB.Delete(Convert.ToInt32(s_N_ID));
            if (flag>0)
            {

                grvTeam.EditIndex = -1;
                Query();
                this.ShowMsg("删除成功");
            }
            else
            {
                this.ShowMsg("删除失败");
            }

        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("删除失败");
        }

    }
    #endregion

    #region 自定义事件
    private void Query()
    {
        try
        {
            DataSet DS = new DataSet();
            DS = this.objTeamDB.GetDWbyLM();
            DataTable DT = new DataTable();
            DT = DS.Tables[0];
            if (DT.Rows.Count > 0)
            {
                this.grvTeam.DataSource = DT;
                this.grvTeam.DataBind();

            }
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
            this.ShowMsg("查询失败");
        }
    }
    #endregion












}
