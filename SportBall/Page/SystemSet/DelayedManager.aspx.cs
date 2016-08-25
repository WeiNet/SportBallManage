#region histroy
///程式代號：      DelayedManager
///程式名稱：      DelayedManager
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

public partial class DelayedManager : BasePage
{
    #region 全局变量
    DelayedManagerDB objDelayedManagerDB =new DelayedManagerDB();
    #endregion Page_Load
    
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"].Equals("ZH"))
                   
                {
                    //this.lblTitle.Text = "下注延遲的五級用戶清單";
                    this.GetData();
           
                }
                else
                {
                    this.getHYData();
                
                }
            }

        }
    }

   
    #endregion

   

    #region 按钮事件
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SystemSet.aspx");
    }
    #endregion

    #region gridview事件
    protected void grvHYZH_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.Cells[9].Text.Equals("1"))
            {
                e.Row.Cells[9].Text = "是";
            }
            else
            {
                e.Row.Cells[9].Text = "否";
                e.Row.Cells[9].Style.Add("color", "red");
            }
            if (e.Row.Cells[10].Text.Equals("1"))
            {
                e.Row.Cells[10].Text = "是";
            }
            else
            {
                e.Row.Cells[10].Text = "否";
                e.Row.Cells[10].Style.Add("color", "red");
            }
            if (e.Row.Cells[12].Text.Equals("1"))//1:一般會員 2:危險等級一 3:危險等級二 4:危險等級三
            {
                e.Row.Cells[12].Text = "一般會員";
            }
            else if (e.Row.Cells[12].Text.Equals("3"))
            {
                e.Row.Cells[12].Text = "危險會員";
                e.Row.Cells[12].Style.Add("color", "red");
            }
            //else if (e.Row.Cells[12].Text.Equals("3"))
            //{
            //    e.Row.Cells[12].Text = "危險等級二";
            //}
            //else
            //{
            //    e.Row.Cells[12].Text = "危險等級三";
            //}
            //籃球 棒球 网球 排球 足球C盤 美足 指數 樂透 彩票 賽馬 六合彩 今彩539 
            if (DataBinder.Eval(e.Row.DataItem, "n_lqtz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 籃球";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_mbtz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 棒球";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_rbtz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 网球";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_tbtz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 排球";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_zqtz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 足球A盤";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_zqtz").ToString().Equals("2"))
            {
                e.Row.Cells[11].Text += " 足球B盤";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_zqtz").ToString().Equals("3"))
            {
                e.Row.Cells[11].Text += " 足球C盤";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_mztz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 美足";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_zstz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 指數";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_dlttz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 樂透";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_cptz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 彩票";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_smtz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 賽馬";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_lhctz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 六合彩";
            }
            if (DataBinder.Eval(e.Row.DataItem, "n_jctz").ToString().Equals("1"))
            {
                e.Row.Cells[11].Text += " 今彩539";
            }
        }
    }

    protected void grvWJZH_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.Cells[9].Text.Equals("1"))
            {
                e.Row.Cells[9].Text = "是";
            }
            else
            {
                e.Row.Cells[9].Text = "否";
                e.Row.Cells[9].Style.Add("color", "red");
            }
        }

    }
    #endregion

    #region 自定义事件
    private void getHYData()
    {
        DataSet DS = new DataSet();
        DS = objDelayedManagerDB.GetList();
        DataTable DT = new DataTable();
        DS = objDelayedManagerDB.GetList();
        this.grvWJZH.DataSource = DS.Tables[0];
        this.grvWJZH.DataBind();
    }

    private void GetData()
    {
        DataSet DS = new DataSet();
        DS = objDelayedManagerDB.GetGLList();
        DataTable DT = new DataTable();
    
        this.grvHYZH.DataSource = DS.Tables[0];
        this.grvHYZH.DataBind();
       
    }
    #endregion

   


    

    }
