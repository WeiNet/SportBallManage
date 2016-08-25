#region histroy
///程式代號：      UserManagement
///程式名稱：      UserManagement
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
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion


public partial class UserManagement : BasePage
{
    #region 全局变量
    UserManagementDB objUserManagement = new UserManagementDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Query();
        }
    }


    #endregion

    #region 按钮事件
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strMD5 = FormsAuthPasswordFormat.MD5.ToString();

        string strMd5 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.textPassWord.Text.ToUpper(), strMD5).ToUpper();
        KFB_ZHGL o_KFB_ZHGL = new KFB_ZHGL();

        o_KFB_ZHGL.N_HYZH = this.txtUser.Text.ToUpper();
        o_KFB_ZHGL.N_HYMM = strMd5;
        o_KFB_ZHGL.N_HYMC = this.txtTitle.Text;
        o_KFB_ZHGL.N_HYDJ = Convert.ToInt32(this.dropType.SelectedValue);
        o_KFB_ZHGL.N_YXDL = 1;
        o_KFB_ZHGL.N_HYJRSJ = DateTime.Now;
        o_KFB_ZHGL.N_XZSJ = DateTime.Now;
        o_KFB_ZHGL.N_HYXG = DateTime.Now;
        o_KFB_ZHGL.N_DZJDH = "";
        int i = objUserManagement.Add(o_KFB_ZHGL);
        if (i > 0)
        {

         
            Query();
            this.ShowMsg("新增成功");
        }
        else
        {
            this.ShowMsg("新增失败");
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region grid的事件

    protected void grvUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string grvhidNO = ((HiddenField)this.grvUser.Rows[e.RowIndex].FindControl("grvhidNO")).Value.Trim();
        string grvtxtName = ((TextBox)this.grvUser.Rows[e.RowIndex].FindControl("grvtxtName")).Text;
        string grvtxtPassword = ((TextBox)this.grvUser.Rows[e.RowIndex].FindControl("grvtxtPassword")).Text.ToUpper();
        string grvltxtName_CN = ((TextBox)this.grvUser.Rows[e.RowIndex].FindControl("grvltxtName_CN")).Text.Trim();
        string grvdrpType = ((DropDownList)this.grvUser.Rows[e.RowIndex].FindControl("grvdrpType")).SelectedValue;
        string strMD5 = FormsAuthPasswordFormat.MD5.ToString();

        string strMd5 = FormsAuthentication.HashPasswordForStoringInConfigFile(grvtxtPassword, strMD5).ToUpper();
        KFB_ZHGL o_KFB_ZHGL = new KFB_ZHGL();

        o_KFB_ZHGL.N_HYZH = grvhidNO;
        o_KFB_ZHGL.N_HYMM = strMd5;
        o_KFB_ZHGL.N_HYMC = grvltxtName_CN;
        o_KFB_ZHGL.N_HYDJ = Convert.ToInt32(grvdrpType);
        o_KFB_ZHGL.N_YXDL = 1;
        o_KFB_ZHGL.N_HYJRSJ = DateTime.Now;
        o_KFB_ZHGL.N_XZSJ = DateTime.Now;
        o_KFB_ZHGL.N_HYXG = DateTime.Now;
        o_KFB_ZHGL.N_DZJDH = "";
        int i=objUserManagement.Update(o_KFB_ZHGL);
        if (i > 0)
        {

            grvUser.EditIndex = -1;
            Query();
            this.ShowMsg("修改成功");
        }
        else
        {
            this.ShowMsg("修改失败");
        }
    }

    protected void grvUser_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.grvUser.EditIndex = e.NewEditIndex;
        this.Query();//查詢
    }

    protected void grvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string s_N_NO = ((Label)this.grvUser.Rows[e.RowIndex].FindControl("grvlblName")).Text;
        int i = objUserManagement.Delete(s_N_NO);
        if (i > 0)
        {

         
            Query();
            this.ShowMsg("删除成功");
        }
        else
        {
            this.ShowMsg("删除失败");
        }
    }

    protected void grvUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strN_NO = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_hyzh").ToString());
            string strn_hymm = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_hymm").ToString());
            string n_hymc = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_hymc").ToString());
            string n_hydj = Server.HtmlEncode(DataBinder.Eval(e.Row.DataItem, "n_hydj").ToString());
            ImageButton grvibtnUpdate = (ImageButton)e.Row.FindControl("grvibtnUpdate");
            ImageButton ibtnDelete = (ImageButton)e.Row.FindControl("ibtnDelete");
            HiddenField grvhidNO = (HiddenField)e.Row.FindControl("grvhidNO");
            TextBox grvtxtName = (TextBox)e.Row.FindControl("grvtxtName");
            TextBox grvtxtPassword = (TextBox)e.Row.FindControl("grvtxtPassword");
            TextBox grvltxtName_CN = (TextBox)e.Row.FindControl("grvltxtName_CN");
            DropDownList grvdrpType = (DropDownList)e.Row.FindControl("grvdrpType");
            Label grvllblType = (Label)e.Row.FindControl("grvllblType");
            Label grvlblPassword = (Label)e.Row.FindControl("grvlblPassword");

            if (ibtnDelete != null)
            {
                ibtnDelete.Attributes.Add("onclick", "return funConfirm()");
            }

            if (grvhidNO != null)
            {
                grvhidNO.Value = strN_NO;
            }
            if (grvtxtName != null)
            {

                grvibtnUpdate.Attributes.Add("onclick", "return funSave('" + grvtxtName.ClientID + "','" + grvtxtPassword.ClientID + "','" + grvltxtName_CN.ClientID + "');");
                grvtxtName.Text = strN_NO;
            }
            if (grvllblType != null)
            {
                grvlblPassword.Text = "******";
                if (n_hydj.Equals("0"))
                {
                    grvllblType.Text = "超级用户";
                }
                else
                {
                    grvllblType.Text = "系统管理员";
                }

            }
            if (grvltxtName_CN != null)
            {
                grvltxtName_CN.Text = n_hymc;
            }
            if (grvdrpType != null)
            {
                grvdrpType.SelectedValue = n_hydj;
            }


        }

    }

    protected void grvUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.grvUser.EditIndex = -1;
        this.Query();//查詢

    }
    #endregion

    #region 自定义事件
    private void Query()
    {
        try
        {
            DataSet DS = new DataSet();
            DS = objUserManagement.GetList("(0,1)");
            DataTable DT = new DataTable();
            DT = DS.Tables[0];
            if (DT.Rows.Count > 0)
            {
                this.grvUser.DataSource = DT;
                this.grvUser.DataBind();

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
