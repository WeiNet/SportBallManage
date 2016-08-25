using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using JXGridView;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Xml;
using log4net;
using System.Collections.Generic;
using KingOfBall;
using System.Security.Cryptography;

/// <summary>
/// Comm 的摘要描述
/// </summary>
public class Comm
{   private static string key;
        
    private static string strno = "K1";
    public static string ms_MRDLDH = "K1Z61";
    public static string ms_MRZDLDH = "K1Z51";
    public static ILog LogDB = log4net.LogManager.GetLogger("logDB");
    private static readonly Type ms_LockType = typeof(Comm);
    #region Declare Region
    public bool mb_DateTypeFlag = true;
    public static int maxFC = 20;
    public static double Fcjg = 0.25;
    #endregion

    #region"建構函式"
    public Comm()
    {
          key = "GameTree";
        //
        // TODO: 在此加入建構函式的程式碼
        //
        //this.mb_DateTypeFlag = COMMON.GetDataType().Equals("2") ? true : false;
    }
    #endregion

    /// <summary>
    /// 空轉為0
    /// </summary>
    /// 
    public static string Trim(object obj)
    {
        string strreturn = "";
        if (!obj.Equals(""))
        {
            strreturn = Convert.ToString(obj);
        }
        else
        {
            strreturn = "0";
        }
        return strreturn;
    }

    #region 清空頁面Controls數據
    /// <summary>
    /// 清空頁面數據
    /// </summary>
    /// <param name="o_Contaier">容器對象 this</param>
    /// <param name="s_aFormID">表單ID,如"frmTX3111"</param>
    public static void ClearControlsContent(object o_Contaier, string s_aFormID)
    {
        Page o_aPage = o_Contaier as Page;
        Panel o_Panel = o_Contaier as Panel;
        Table o_Table = o_Contaier as Table;
        LiteralControl o_LiteralControl = o_Contaier as LiteralControl;
        UserControl o_uc = o_Contaier as UserControl;
        ControlCollection cs = null;
        JXGrid o_grid = o_Contaier as JXGrid;
        GridViewRow o_gvr = o_Contaier as GridViewRow;
        DataControlFieldCell o_Cell = o_Contaier as DataControlFieldCell;
        if (o_aPage != null) { cs = o_aPage.FindControl(s_aFormID).Controls; }
        else if (o_Panel != null) { cs = o_Panel.Controls; }
        else if (o_Table != null) { cs = o_Table.Controls; }
        else if (o_uc != null) { cs = o_uc.Controls; }
        else if (o_grid != null) { cs = o_grid.Controls; }
        else if (o_gvr != null) { cs = o_gvr.Controls; }
        else if (o_Cell != null) { cs = o_Cell.Controls; }
        else if (o_LiteralControl != null) { cs = o_LiteralControl.Controls; }
        if (cs == null) return;
        foreach (Control c in cs)
        {
            if (c is Panel || c is Table || c is UserControl || c is JXGrid ||
                c is GridViewRow || c is DataControlFieldCell || c is LiteralControl)
            {
                ClearControlsContent(c, s_aFormID);
            }
            TextBox txt = c as TextBox;
            DropDownList drp = c as DropDownList;
            RadioButton rdo = c as RadioButton;
            RadioButtonList rdol = c as RadioButtonList;
            CheckBox chk = c as CheckBox;
            CheckBoxList chkl = c as CheckBoxList;

            HtmlInputCheckBox hchk = c as HtmlInputCheckBox;
            HtmlInputText htxt = c as HtmlInputText;
            HtmlTextArea htxta = c as HtmlTextArea;
            HtmlInputRadioButton hrdo = c as HtmlInputRadioButton;
            HtmlSelect hdrp = c as HtmlSelect;
            if (txt != null) txt.Text = String.Empty;
            if (drp != null) drp.SelectedIndex = 0;
            if (rdo != null) rdo.Checked = false;
            if (chk != null) chk.Checked = false;
            if (rdol != null) rdol.SelectedIndex = -1;
            if (chkl != null) chkl.SelectedIndex = -1;
            if (htxt != null) htxt.Value = String.Empty;
            if (htxta != null) htxta.Value = String.Empty;
            if (hdrp != null) hdrp.SelectedIndex = 0;
            if (hrdo != null) hrdo.Checked = false;
            if (hchk != null) hchk.Checked = false;
        }
    }
    #endregion

    #region 判斷級別
    /// <summary>
    /// 判斷級別
    /// </summary>
    public static string GetLvName(string strlv)
    {
        string strReturn = "";
        switch (strlv)
        {
            case "3":
                strReturn = "操盤手"; break;
            case "2":
                strReturn = "操盤手(小球)"; break;
            case "4":
                strReturn = "大總監"; break;
            case "5":
                strReturn = "總監"; break;
            case "6":
                strReturn = "大股東"; break;
            case "7":
                strReturn = "股東"; break;
            case "8":
                strReturn = "總代理"; break;
            case "9":
                strReturn = "代理"; break;

        }
        return strReturn;
    }
    #endregion

    #region 判斷級別(简写)
    /// <summary>
    /// 判斷級別
    /// </summary>
    public static string GetLvSName(string strlv)
    {
        string strReturn = "";
        switch (strlv)
        {
            case "4":
                strReturn = "大總"; break;
            case "5":
                strReturn = "總"; break;
            case "6":
                strReturn = "大"; break;
            case "7":
                strReturn = "股"; break;
            case "8":
                strReturn = "總"; break;
            case "9":
                strReturn = "代"; break;
            case "10":
                strReturn = "會"; break;


        }
        return strReturn;
    }
    #endregion

 

    #region 判斷是否鎖比賽
    public static bool GetLock(object o_aLock)
    {
        return o_aLock.ToString().Equals("2") || o_aLock.ToString().Equals("5") || o_aLock.ToString().Equals("6");
    }
    #endregion



    /// <summary>
    /// 小於10補0
    /// </summary>
    /// <param name="i_aNum"></param>
    /// <returns></returns>
    public static string GetNum(int i_aNum)
    {
        if (i_aNum < 10)
        {
            return "0" + i_aNum.ToString();
        }
        else
        {
            return i_aNum.ToString();
        }
    }

    /// <summary>
    /// 保留幾位小數
    /// </summary>
    /// <param name="dec"></param>
    /// <param name="decimals"></param>
    /// <returns></returns>
    public static string SetRound(decimal? dec, int decimals)
    {
        return Convert.ToString(Math.Round(dec.Value, decimals));
    }
    #region 根据lv取得要返回的页面
    /// <summary>
    /// 
    /// </summary>
    /// 
    public static string GetPage(string strlv)
    {
        string strturn = "";
        switch (strlv)
        {
            case "4": strturn = "dzjgl.aspx"; break;
            case "5": strturn = "zjgl.aspx"; break;
            case "6": strturn = "dgdgl.aspx"; break;
            case "7": strturn = "gdgl.aspx"; break;
            case "8": strturn = "zdlgl.aspx"; break;
            case "9": strturn = "dlgl.aspx"; break;
        }
        return strturn;
    }
    #endregion

    #region 六合彩判斷類型
    /// <summary>
    /// 六合彩判斷類型
    /// </summary>
    /// 
    public static string ChType(string strtype)
    {
        string strreturn = "";
        switch (strtype)
        {
            case "tdan": strreturn = "固單"; break;
            case "ts": strreturn = "固雙"; break;
            case "tda": strreturn = "固大"; break;
            case "tx": strreturn = "固小"; break;
            case "hb": strreturn = "紅波"; break;
            case "lab": strreturn = "藍波"; break;
            case "lvb": strreturn = "綠波"; break;
            case "da": strreturn = "大"; break;
            case "xiao": strreturn = "小"; break;
            case "dan": strreturn = "單"; break;
            case "shuang": strreturn = "雙"; break;
            case "ldan": strreturn = "單號"; break;
            case "lsh": strreturn = "雙號"; break;
            case "hdan": strreturn = "合單"; break;
            case "hs": strreturn = "合雙"; break;
            case "not": strreturn = "不用"; break;
            case "cancle": strreturn = "取消"; break;
            //球類
            case "b_lhc": strreturn = "六合彩"; break;
            case "b_sm": strreturn = "賽馬"; break;
            case "b_lq": strreturn = "籃球"; break;
            case "b_bk": strreturn = "籃球"; break;
            case "b_bj": strreturn = "棒球"; break;
            case "b_by": strreturn = "网球"; break;
            case "b_bb": strreturn = "排球"; break;
            case "b_dlt": strreturn = "大樂透"; break;// 
            case "b_zs": strreturn = "指數"; break;// 
            case "b_zq": strreturn = "足球"; break;
            case "b_bf": strreturn = "美足"; break;
            case "b_cp": strreturn = "彩票"; break;
            case "b_ss": strreturn = "特殊投注"; break;
            case "b_bq": strreturn = "冰球"; break;
            case "b_cq": strreturn = "彩球"; break;

            //玩法
            case "l_tbh": strreturn = "特別號"; break;
            case "l_gg": strreturn = "過關"; break;
            case "l_th": strreturn = "台號"; break;
            case "l_tt": strreturn = "台特"; break;
            case "l_qcp": strreturn = "全車碰"; break;
            case "l_234": strreturn = "二三四星"; break;
            case "l_dy": strreturn = "獨贏"; break;
            case "l_ly": strreturn = "連贏"; break;
            case "l_wz": strreturn = "位置"; break;
            case "l_wzq": strreturn = "位置Q"; break;
            case "l_rf": strreturn = "讓(分)球"; break;
            case "l_zdrf": strreturn = "滾球讓(分)球"; break;
            case "l_zddx": strreturn = "滾球大小"; break;
            case "l_ds": strreturn = "單雙"; break;
            case "l_dx": strreturn = "大小"; break;
            case "l_sy": strreturn = "一輸二贏"; break;
            case "l_hj": strreturn = "和局"; break;

            // case "l_sy": strreturn = "一輸二贏";

            default: strreturn = strtype; break;

        }
        if (strtype.IndexOf("l_bd") > -1)
        {
            strreturn = "波膽";
        }
        if (strtype.IndexOf("l_rqs") > -1)
        {
            strreturn = "入球數";
        }
        if (strtype.IndexOf("l_bqc") > -1)
        {
            strreturn = "半全場";
        }
        return strreturn;
    }
    #endregion


    /// <summary>
    /// 获得序號
    /// </summary>
    public static int GetNO()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select EXAMPLE_SEQ.nextval from dual");
        return Convert.ToInt32(DbHelperOra.Query(strSql.ToString()).Tables[0].Rows[0][0]);
    }
    /// <summary>
    /// 取得系统帐务日期
    /// </summary>
    /// 
    public static DateTime GetZWRQ()
    {
        DateTime dt = dt = DateTime.Now;
      KFB_XTSZ mo_XTSZ = new KFB_XTSZ();
      SystemSetDB objSystemSetDB = new SystemSetDB();
      mo_XTSZ = objSystemSetDB.GetModel();
        if (mo_XTSZ.N_ZWRQ != null)
        {
            dt = Convert.ToDateTime(mo_XTSZ.N_ZWRQ);
        }
        return dt;
    }
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="str"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string Encode(string str)
    {
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
        provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
        //byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        MemoryStream stream = new MemoryStream();
        CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
        stream2.Write(bytes, 0, bytes.Length);
        stream2.FlushFinalBlock();
        StringBuilder builder = new StringBuilder();
        foreach (byte num in stream.ToArray())
        {
            builder.AppendFormat("{0:X2}", num);
        }
        stream.Close();
        return builder.ToString();
    }
}