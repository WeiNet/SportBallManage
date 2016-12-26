#region histroy
///程式代號：      Login
///程式名稱：      Login
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region using

using System;
using System.Web.Security;
using System.Web.Configuration;
#endregion



public partial class Login : BasePage
{
    #region 全局变量
    LoginDB objLogin = new LoginDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            this.SetJS();

        }

        if (Request["ACT"] != null && Request["ACT"].ToString() == "Logout")
        {

            Session.Remove("LEVEL");
            Session.Remove("UserID");

        }
        if (Request["Timeout"] != null && Request["Timeout"].ToString() == "Y")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Timeout", "alert('Timeout!" + "\\n" + "Please login again...');", true);
        }
        this.textUserName.Focus();

    }
    #endregion

    #region 按钮事件
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            this.textUserName.Text = this.textUserName.Text.ToUpper();

            string strMD5 = FormsAuthPasswordFormat.MD5.ToString();
            this.textPassWord.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(this.textPassWord.Text.ToUpper(), strMD5).ToUpper();
            LoginCo(this.textUserName.Text, this.textPassWord.Text);
        }
        catch (Exception ex)
        {
            this.ShowMsg("帳號或密碼錯誤，請重新登錄");
            this.WriteLog(ex.ToString());

        }
    }


    #endregion

    #region 自定义事件
    //加載Js
    private void SetJS()
    {
        this.btnLogin.Attributes.Add("onclick", "return FnLogin();");

    }
    //登录
    private void LoginCo(string strUserName, string strPw)
    {
      
        bool blnIsLogin = objLogin.IsLogin(strUserName, strPw);
        string strLEVEL = objLogin.GetLEVEL(strUserName);
        if (blnIsLogin)
        {
            bool checkIsLogin = objLogin.checkLogin(strUserName);
            
            if (checkIsLogin)
            {
                
                Session["LEVEL"] = strLEVEL;
                Session["UserID"] = strUserName;

                Response.Cookies["XTDBALLCOUSER"].Value = strUserName;
                Response.Cookies["XTDBALLCOLV"].Value = strLEVEL;
                Response.Cookies["XTDBALLCOUSER"].Expires = DateTime.Now.AddHours(24);
                Response.Cookies["XTDBALLCOLV"].Expires = DateTime.Now.AddHours(24);
                this.SetSXHY(strLEVEL, strUserName);
                this.Setdl(strLEVEL, strUserName, "cg");
                Response.Redirect("~/Page/Welcome.aspx", false);
                
            }
            else
            {
                this.ShowMsg("該帳號已被鎖定，不能登陸！");

            }

        }
        else
        {
            this.Setdl(strLEVEL, strUserName, "sb");
            this.ShowMsg("帳號或密碼錯誤，請重新登錄！");
            this.textPassWord.Focus();

        }
    }
    /// <summary>
    /// 取得流水號
    /// </summary>
    public void SetSXHY(string strlv, string strid)
    {

        KFB_XSHY objXSHY = new KFB_XSHY();
        objXSHY.N_HYDJ = Convert.ToInt32(Session["LEVEL"].ToString());
        objXSHY.N_HYZH = Session["UserID"].ToString();
        objXSHY.N_HYIP = CommLib.Utility.GetIpAddress();
        objXSHY.N_SYSJ = DateTime.Now;
        objXSHY.N_DLSJ = DateTime.Now;
        if (!objLogin.Exists(strid, Convert.ToInt32(strlv)))
        {
            objLogin.Add(objXSHY);
        }
        else
        {
            objLogin.Update(objXSHY);
        }

    }
    //修改会员登录次数
    public void Setdl(string strlv, string strid, string strty)
    {
        KFB_DLIP mo_DLIP = new KFB_DLIP();

        //if (!o_DLIP.Exists(strid))
        //{
        mo_DLIP.N_HYDJ = strlv;
        mo_DLIP.N_HYZH = strid;
        mo_DLIP.N_HYIP = this.Request.UserHostAddress;
        mo_DLIP.N_ZJDLSJ = DateTime.Now;
        if (strty.Equals("cg"))
        {
            mo_DLIP.N_CGCS = 1;
            mo_DLIP.N_SPCS = 0;
        }
        else if (strty.Equals("sb"))
        {
            mo_DLIP.N_CGCS = 0;
            mo_DLIP.N_SPCS = 1;
        }
        objLogin.addDLIP(mo_DLIP);
       

    }
    #endregion

 
}
