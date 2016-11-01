using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;


public class BasePage : System.Web.UI.Page
{
    public string mUserID;//登入者用戶ID
    public string mUserName;//使用者姓名
    public string mPageSize = ConfigurationManager.AppSettings["PageSize"].ToString();//Grid分頁之每一頁資料筆數
    /// <summary>
    /// 頁面
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        CheckIsLogin();    //驗證是否成功登入
        base.OnInit(e);
    }

    protected override void OnLoad(System.EventArgs e)
    {
       
        this.setPathInfo(); 
        base.OnLoad(e);
    }
    /// <summary>
    /// Log记录
    /// </summary>
    /// <param name="Action"></param>
    public void WriteLog(string Action)
    {
        try
        {
            string strLogName = System.DateTime.Now.ToString("yyyy-MM-dd");
            string strPath = this.Server.MapPath("~");
            string strIP = Request.UserHostAddress + ":" + Request.Url.Port;//訪問者的Ip和端口
            if (!strPath.EndsWith("\\"))
                strPath += "\\";
            strPath += "Log\\";
            //判斷是否有這樣的路徑并創建
            if (System.IO.Directory.Exists(strPath) == false)
            {
                System.IO.Directory.CreateDirectory(strPath);
            }
            strLogName = strPath + strLogName + ".txt";
            ////如果文件不存在，會自動創建
            string strNote = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            strNote += "; " + strIP + ";" + mUserID + ":\n" + Action + "\n\n";
            System.IO.StreamWriter file = new System.IO.StreamWriter(strLogName, true);
            file.WriteLine(strNote);
            file.Close();
            file.Dispose();
        }
        catch//(Exception ex)
        {
            throw;
        }
    }
    public void ShowAndBaseRedirect(string strCode, string StrPara, string url)
    {
        this.ClientScript.RegisterStartupScript(this.GetType(), "messageRedirect", "<script> ShowAndBaseRedirect('" + strCode + "','" + StrPara + "','" + url + "'); </script>");
    }
    /// <summary>
    /// 在頁面上彈出信息提示
    /// </summary>
    /// <param name="strMsg">信息內容</param> 
    public void ShowMsg(string strMsg)
    {
        this.ClientScript.RegisterStartupScript(this.GetType(), "messageshow", "<script> alert(\"" + strMsg + "\"); </script>");
    }

    /// <summary>
    /// 注意BasePage的Page_Load事件在 繼承它的頁面的Page_Load事件之後執行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void setPathInfo()
    {
        //自動添加css,js,calendar,images路徑
        string strScript = "";
        //頁面相應的編碼方式
        ////公用JS函數        
        //strScript += "<script type='text/javascript' src='/Scripts/Common.js'></script>\n";
        //strScript += "<script type='text/javascript' src='/Scripts/MessageBox.js'></script>\n";
        strScript += "<script type='text/javascript' src='/Scripts/Public.js'></script>\n";
        //strScript += "<script type='text/javascript' src='/Scripts/jquery-1.7.2.min.js'></script>\n";
        //strScript += "<script type='text/javascript' src='/Scripts/jquery-ui-1.8.20.custom.min.js'></script>\n";
        strScript += "<script type='text/javascript' src='/Scripts/Common.js'></script>\n";
        strScript += "<script type='text/javascript' src='/Scripts/MessageBox.js'></script>\n";
        //strScript += "<script type='text/javascript' src='/Scripts/jquery-1.7.2.min.js'></script>\n";
        //strScript += "<script type='text/javascript' src='/Scripts/jquery-ui-1.8.20.custom.min.js'></script>\n"; 
        this.ClientScript.RegisterStartupScript(this.Page.GetType(), "basePageScript", strScript); //RegisterStartupScript
    }
    private void SetSession()
    {
        this.mUserID = Session["UserID"].ToString();
   
        Session.Remove("Timeout");
       
      
    }
    #region 驗證是否成功登入
    /// <summary>
    /// CheckIsLogin
    /// </summary>
    public void CheckIsLogin()
    {
        if (this.IsNoCheckSession()) return;
        //所有排除驗證是否登錄的頁面
        if (Session["UserID"] != null && Session["LEVEL"] != null )
        {
            //登入成功
            this.SetSession();
        }
        else
        {
            //登入失敗,並且不在排除驗證的頁面範圍
            funTimeout("", "Timeout!" + "\\n" + "Please login again...");
        }
    }
    private void funTimeout(string Flag, string strMsg)
    {
        string strUrl = Request.Url.ToString();
        string strTimeout = "";
        if (Session["Timeout"] == null || Session["Timeout"] != "Timeout")//避免連續彈出消息
            strTimeout = "?Timeout=Y";
        //主框架程式和login程式在同一目下，不需要加路徑，直接導向login畫面
        if (strUrl.ToUpper().IndexOf("WELCOME.ASPX") >= 0)
        {
            Response.Redirect("Login.aspx" + strTimeout);
        }
        string strPath = "";//首頁程式和Login程式在同一目錄下，不需要加路徑
        if (strUrl.ToUpper().IndexOf("WELCOME.ASPX") < 0)
        {
            strPath = "/Page/";//其它畫面需要加路徑
        }
        string strScript = "";
        //showModalDialog出來的小畫面直接關閉，不需要導向login畫面
        if (Request["showModalDialog"] != null && Request["showModalDialog"].ToString() == "showModalDialog")
        {
            strScript += " try{";
            if (Session["Timeout"] == null || Session["Timeout"] != "Timeout")//避免連續彈出消息
                strScript += " alert('Timeout!" + "\\n" + "Please login again...');";
            strScript += " window.opener=null; window.close();}catch(e){;}";
        }
        else
        {
            if (Flag == "C")//
                strScript += "window.opener=null; window.close();";
            else
            {
                strScript += "try{window.parent.location.href='" + strPath + "Login.aspx" + strTimeout + "';}catch(e){;}";
            }
        }
        Session["Timeout"] = "Timeout";
        Response.Write("<script>" + strScript + "</script>");
        Response.End();
    }
    /// <summary>
    /// 判斷是否不需要確認Session過去
    /// </summary>
    /// <returns></returns>
    private Boolean IsNoCheckSession()
    {
        string[] aryProg = { "LOGIN.ASPX", "WEBFORM1.ASPX" };
        string strUrl = Request.Url.ToString().ToUpper();
        for (int i = 0; i < aryProg.Length; i++)
        {
            if (strUrl.IndexOf(aryProg[i]) >= 0)
                return true;
        }
        return false;
    }
    #endregion
    public string GetIp()
    {
        string strreturn = "";
        if (this.Request.Headers["X-Client-Address"] != null)
        {
            strreturn = this.Request.Headers["X-Client-Address"];
        }
        else
        {
            strreturn = this.Request.UserHostAddress;
        }
        return strreturn;
    }
}
