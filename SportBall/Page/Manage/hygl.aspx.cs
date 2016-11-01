using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class hygl : BasePage
{
    private AgentManageDB objAgentManageDB = new AgentManageDB();
    private AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.grvUserManage.RowColor = Color.FromName("#ddeeff");

            if (!IsPostBack)
            {
                this.btnAddUser.Visible = false;
                this.drpZJ.Visible = false;
                /* --------Modify By Jean
                this.drpZJ.Visible = false;
                KFB_HYGL_BLL o_KFB_HYGL_BLL = new KFB_HYGL_BLL();
                this.drpZJ.DataSource = o_KFB_HYGL_BLL.GetZJ();
                this.drpZJ.DataTextField = "n_hymc";
                this.drpZJ.DataValueField = "n_hyzh";
                this.drpZJ.DataBind();
                this.drpZJ.Items.Insert(0, new ListItem("未選擇", ""));
                this.drpDLS.DataSource = o_KFB_HYGL_BLL.GetZJ_DLS(this.drpZJ.SelectedValue);
                this.drpDLS.DataTextField = "DLSName";
                this.drpDLS.DataValueField = "DLSID";
                this.drpDLS.DataBind();
                this.drpDLS.Items.Insert(0, new ListItem("未選擇", ""));
                if (Request.QueryString["N_DZJDH"] != null)
                {
                    this.drpZJ.SelectedValue = Convert.ToString(Request.QueryString["N_DZJDH"]);
                    drpZJ_SelectedIndexChanged(sender, e);
                    this.drpDLS.SelectedValue = Request.QueryString["N_DZJDH"]
                        + "-" + Request.QueryString["N_ZJDH"]
                        + "-" + Request.QueryString["N_DGDDH"]
                        + "-" + Request.QueryString["N_GDDH"]
                        + "-" + Request.QueryString["N_ZDLDH"]
                        + "-" + Request.QueryString["N_DLDH"];
                    drpDLS_SelectedIndexChanged(sender, e);
                }
                else
                    this.trsj.Visible = false;
                 */
                if (Request.QueryString["gdid"] != null)
                {
                    this.drpDLS.DataSource = objAgentManageDB.GetMember("9", "7", Request.QueryString["gdid"]);
                    this.drpDLS.DataTextField = "N_HYZH";
                    this.drpDLS.DataValueField = "N_HYZH";
                    this.drpDLS.DataBind();
                    this.drpDLS.Items.Insert(0, new ListItem("未選擇", ""));
                }
                if (Request.QueryString["N_DLDH"] != null)
                {
                    this.drpDLS.DataSource = objAgentManageDB.GetMember("9", "8", Request.QueryString["N_ZDLDH"]);
                    this.drpDLS.DataTextField = "N_HYZH";
                    this.drpDLS.DataValueField = "N_HYZH";
                    this.drpDLS.DataBind();
                    this.drpDLS.Items.Insert(0, new ListItem("未選擇", ""));
                    this.drpDLS.SelectedValue = Request.QueryString["N_DLDH"];
                    drpDLS_SelectedIndexChanged(sender, e);
                }
            }

            //string[] strZHSJ = getZHSJ().Split(',');
            //DataSet dsbj = o_zhgl.GetMember("10", strZHSJ[0], strZHSJ[1]);
            DataSet dsbj = objAgentManageDB.GetMember("10");
            this.lbbj.Text = dsbj.Tables[0].Rows.Count.ToString();
            if (Comm.GetFlag(mUserID) == "1")
                btnAddUser.Visible = false;

        }
        catch (Exception ex)
        {
            this.WriteLog("用户名=" + mUserID + ex.ToString());
            this.ShowMsg("頁面加載失敗");
        }
    }
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        string s_DLS = "";
        string s_ZDL = "";
        string s_GD = "";
        string s_DGD = "";
        string s_ZJ = "";
        if (this.drpDLS.SelectedValue.Split('-').Length >= 5)
        {
            s_DLS = this.drpDLS.SelectedValue.Split('-')[5].ToString();
            s_ZDL = this.drpDLS.SelectedValue.Split('-')[4].ToString();
            s_GD = this.drpDLS.SelectedValue.Split('-')[3].ToString();
            s_DGD = this.drpDLS.SelectedValue.Split('-')[2].ToString();
            s_ZJ = this.drpDLS.SelectedValue.Split('-')[1].ToString();
        }

        string s_DZJ = this.drpZJ.SelectedValue.ToString();
        Response.Redirect(String.Format("xzhy.aspx?n_hyzh={0}&n_dldh={1}&n_zdldh={2}&n_gddh={3}&n_dgddh={4}&n_zjdh={5}&n_dzjdh={6}", "", s_DLS, s_ZDL, s_GD, s_DGD, s_ZJ, s_DZJ));
    }
    protected void drpZJ_SelectedIndexChanged(object sender, EventArgs e)
    {

        this.drpDLS.DataSource = objAgentManageDB.GetDZJ_DLS(this.drpZJ.SelectedValue);
        this.drpDLS.DataTextField = "DLSName";
        this.drpDLS.DataValueField = "DLSID";
        this.drpDLS.DataBind();
        this.drpDLS.Items.Insert(0, new ListItem("未選擇", ""));
        if (this.drpZJ.SelectedValue.Equals(String.Empty))
        {
            this.btnAddUser.Visible = false;
            this.grvUserManage.DataSource = new DataTable(String.Empty);
            this.grvUserManage.DataBind();
        }
        else if (!this.drpDLS.SelectedValue.Equals(String.Empty))
        {
            this.btnAddUser.Visible = true;
        }

        if (Comm.GetFlag(mUserID) == "1")
            btnAddUser.Visible = false;
    }
    protected void drpDLS_SelectedIndexChanged(object sender, EventArgs e)
    {


        string s_DLS = String.Empty;
        if (this.drpDLS.SelectedValue.Equals(String.Empty))
        {
            s_DLS = this.drpDLS.SelectedValue;
            this.btnAddUser.Visible = false;
            this.btnBack.Visible = false;
        }
        else
        {
            // s_DLS = this.drpDLS.SelectedValue.Split('-')[5].ToString();
            string[] s_dls = this.drpDLS.SelectedValue.Split('-');
            if (s_dls.Length == 7)
            {
                s_DLS = s_dls[5].ToString() + "-" + s_dls[6].ToString();
            }
            else if (s_dls.Length == 6)
            {
                s_DLS = s_dls[5].ToString();
            }
            else
            {
                s_DLS = this.drpDLS.SelectedValue;
            }
            this.btnAddUser.Visible = true;
            this.btnBack.Visible = true;
        }

        DataSet ds = objAgentManageDB.GetHYZH(s_DLS);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.trsj.Visible = true;
            this.lbxj.Text = ds.Tables[0].Rows.Count.ToString();
            KFB_ZHGL mo_zhgl = new KFB_ZHGL();
            mo_zhgl = objAgentManageDB.GetModel(s_DLS);
            this.lbsj.Text = mo_zhgl.N_HYMC;
            this.lbm1.Text = Convert.ToString(Convert.ToDouble(objAgentManageDB.Getxyed(s_DLS)) - Convert.ToDouble(objAgentManageDB.Getsyed(s_DLS)));
            this.lbm2.Text = objAgentManageDB.Getsyed(s_DLS);
            this.trbj.Visible = false;
        }
        else
        {
            this.trsj.Visible = false;
            this.trbj.Visible = true;
        }
        this.grvUserManage.DataSource = ds;
        this.grvUserManage.DataBind();
        if (Comm.GetFlag(mUserID) == "1")
            btnAddUser.Visible = false;
    }
    //protected void grvUserManage_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowIndex > -1)
    //    {
    //        e.Row.Cells[2].Text = e.Row.Cells[2].Text + "(萬)";
    //        e.Row.Cells[3].Text = e.Row.Cells[3].Text + "(萬)";
    //        if (e.Row.Cells[4].Text.Equals("1"))
    //        {
    //            e.Row.Cells[4].Text = "是";
    //            e.Row.Cells[4].Style.Add("color", "blue");
    //        }
    //        else
    //        {
    //            e.Row.Cells[4].Text = "否";
    //            e.Row.Cells[4].Style.Add("color", "red");
    //        }
    //        if (e.Row.Cells[5].Text.Equals("1"))
    //        {
    //            e.Row.Cells[5].Text = "是";
    //            e.Row.Cells[5].Style.Add("color", "green");
    //        }
    //        else
    //        {
    //            e.Row.Cells[5].Text = "否";
    //            e.Row.Cells[5].Style.Add("color", "red");
    //        }
    //        if (e.Row.Cells[7].Text.Equals("1"))//1:一般會員 2:危險會員 3:危險等級二 4:危險等級三
    //        {
    //            e.Row.Cells[7].Text = "一般會員";
    //        }
    //        else if (e.Row.Cells[7].Text.Equals("3"))
    //        {
    //            e.Row.Cells[7].Text = "危險會員";
    //            e.Row.Cells[7].Style.Add("color", "red");
    //        }
    //        //else if (e.Row.Cells[7].Text.Equals("3"))
    //        //{
    //        //    e.Row.Cells[7].Text = "危險等級二";
    //        //}
    //        //else
    //        //{
    //        //    e.Row.Cells[7].Text = "危險等級三";
    //        //}
    //        //string s_Name = String.Empty;
    //        //for (int i = 0; i < 12; i++)
    //        //{
    //        //    int i_Index = Count(2, i);
    //        //    if ((Convert.ToInt32(e.Row.Cells[6].Text) & i_Index) == i_Index)
    //        //        s_Name += "," + GetCompeteName(i_Index.ToString());
    //        //}
    //        //e.Row.Cells[6].Text = s_Name.Equals("") ? "" : s_Name.Substring(1);
    //        e.Row.Cells[6].Text = "";
    //        //籃球 棒球 网球 排球 足球C盤 美足 指數 樂透 彩票 賽馬 六合彩 今彩539 
    //        if (DataBinder.Eval(e.Row.DataItem, "n_lqtz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 籃球";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_mbtz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 棒球";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_rbtz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 网球";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_tbtz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 排球";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_zqtz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 足球A盤";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_zqtz").ToString().Equals("2"))
    //        {
    //            e.Row.Cells[6].Text += " 足球B盤";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_zqtz").ToString().Equals("3"))
    //        {
    //            e.Row.Cells[6].Text += " 足球C盤";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_mztz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 美足";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_zstz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 指數";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_dlttz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 大樂透";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_cptz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 彩票";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_smtz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 賽馬";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_lhctz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 六合彩";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_jctz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 今彩539";
    //        }
    //        if (DataBinder.Eval(e.Row.DataItem, "n_sstz").ToString().Equals("1"))
    //        {
    //            e.Row.Cells[6].Text += " 時事";
    //        }
    //    }
    //}

    protected void grvUserManage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string s_HYZH = dr["N_HYZH"].ToString().Trim();
            e.Row.Cells[2].Text = e.Row.Cells[2].Text + "(萬)";
            e.Row.Cells[3].Text = e.Row.Cells[3].Text + "(萬)";
            if (e.Row.Cells[9].Text.ToString() == "0")
                e.Row.Cells[9].Text = "";
            else if (e.Row.Cells[9].Text.ToString() == "1")
                e.Row.Cells[9].Text = "A";
            else if (e.Row.Cells[9].Text.ToString() == "2")
                e.Row.Cells[9].Text = "B";
            else if (e.Row.Cells[9].Text.ToString() == "3")
                e.Row.Cells[9].Text = "C";

            string stryxdl = dr["n_yxdl"].ToString();
            string stryxxz = dr["n_yxxz"].ToString();
            if (stryxdl.Equals("1"))
            {
                e.Row.Cells[7].Text = "啟用";
                ((LinkButton)e.Row.FindControl("lbtnTY")).Text = "停用";
            }
            else
            {
                e.Row.Cells[7].Text = "停用";
                ((LinkButton)e.Row.FindControl("lbtnTY")).Text = "啟用";
            }

            if (stryxxz.Equals("1"))
            {
                ((LinkButton)e.Row.FindControl("lbtnTZXZ")).Text = "停止押注";
            }
            else
            {
                ((LinkButton)e.Row.FindControl("lbtnTZXZ")).Text = "解除停押";
            }
            ((LinkButton)e.Row.FindControl("lbtnJBZL")).Attributes.Add("onclick", "window.location.href='xzhy.aspx?n_hyzh=" + dr["n_hyzh"].ToString() + "&n_dldh=" + dr["n_dldh"].ToString() + "&n_zdldh=" + dr["n_zdldh"].ToString() + "&n_gddh=" + dr["n_gddh"].ToString() + "&n_dgddh=" + dr["n_dgddh"].ToString() + "&n_zjdh=" + dr["n_zjdh"].ToString() + "&n_dzjdh=" + dr["n_dzjdh"].ToString() + "';return false;");
            ((LinkButton)e.Row.FindControl("lbtnTY")).Attributes.Add("onclick", "if(confirm('確定停用/啟用" + s_HYZH + "?')){return true;} else{return false;}");
            ((LinkButton)e.Row.FindControl("lbtnTZXZ")).Attributes.Add("onclick", "if(confirm('確定要對該帳號停押/解除停押?')){return true;} else{return false;}");
            ((LinkButton)e.Row.FindControl("lbtnSC")).Attributes.Add("onclick", "if(confirm('確定要刪除" + s_HYZH + "?')){return true;} else{return false;}");
            ((LinkButton)e.Row.FindControl("lbtnQXXSD")).Attributes.Add("onclick", "window.open('ZQ_set.aspx?UserName=" + s_HYZH + "')");
            //((LinkButton)e.Row.FindControl("lbtnCXXSD")).Attributes.Add("onclick", "window.open('../htm/lottery_set_3d.htm','','width=650,height=710,scrollbars=1,toolbar=0,menubar=0,location=0,directories=0,statu=0');return false;");
        }
    }
    /// <summary>
    /// 计算x的y次方的值
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private int Count(int x, int y)
    {
        if (y == 0)
        {
            return 1;
        }
        else
        {
            return x * Count(x, y - 1);
        }
    }
    private string GetCompeteName(string s_aID)
    {
        string s_Name = String.Empty;
        switch (s_aID)
        {
            case "1":
                s_Name = "籃球";
                break;
            case "2":
                s_Name = "棒球";
                break;
            case "4":
                s_Name = "网球";
                break;
            case "8":
                s_Name = "排球";
                break;
            case "16":
                s_Name = "美足";
                break;
            case "32":
                s_Name = "足球";
                break;
            case "64":
                s_Name = "指數";
                break;
            case "128":
                s_Name = "賽馬";
                break;
            case "256":
                s_Name = "六合彩";
                break;
            case "512":
                s_Name = "大樂透";
                break;
            case "1024":
                s_Name = "今彩539";
                break;
            case "2048":
                s_Name = "運動彩票";
                break;
        }
        return s_Name;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (this.drpDLS.SelectedValue != "")
        {
            //string s_ZDL = this.drpDLS.SelectedValue.Split('-')[4].ToString();
            //string s_GD = this.drpDLS.SelectedValue.Split('-')[3].ToString();
            //string s_DGD = this.drpDLS.SelectedValue.Split('-')[2].ToString();
            //string s_ZJ = this.drpDLS.SelectedValue.Split('-')[1].ToString();
            //string s_DZJ = this.drpZJ.SelectedValue.ToString();
            //Response.Redirect(String.Format("dlgl.aspx?n_zdldh={0}&n_gddh={1}&n_dgddh={2}&n_zjdh={3}&n_dzjdh={4}", s_ZDL, s_GD, s_DGD, s_ZJ, s_DZJ));
            Response.Redirect("dlgl.aspx" + Request.Url.Query);
        }
        else
            Response.Redirect("dlgl.aspx");
    }
    #region 返回會員總人數
    private string getZHSJ()
    {


        string strZHSJ = "";
        if (!this.drpDLS.SelectedValue.Equals(""))
        {
            string[] s_dls = this.drpDLS.SelectedValue.Split('-');
            string s_dlsdh = "";
            if (s_dls.Length == 7)
            {
                s_dlsdh = s_dls[5].ToString() + "-" + s_dls[6].ToString();
            }
            else
            {
                s_dlsdh = s_dls[5].ToString();
            }
            strZHSJ = "9," + s_dlsdh;
        }
        else if (!this.drpZJ.SelectedValue.Equals(""))
            strZHSJ = "4," + this.drpZJ.SelectedValue;
        else
            strZHSJ = ",";
        return strZHSJ;
    }
    #endregion

    protected void btnOperate_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable GetSql = new Hashtable();
            LinkButton btn = (LinkButton)sender;
            int i_Index = ((GridViewRow)(btn.Parent.Parent)).RowIndex;

            string s_NID = "";
            s_NID = ((Label)((GridViewRow)(btn.Parent.Parent)).FindControl("lblHYZH")).Text.ToString();
            KFB_HYGL mo_zhgl = objAgentManageDB.GetModelHYGL(s_NID);

            if (btn.Text == "啟用")
            {
                objAgentManageDB.NoLogHY("N_HYZH", mo_zhgl.N_HYZH, "1", GetSql);
            }
            else if (btn.Text == "停用")
            {
                objAgentManageDB.NoLogHY("N_HYZH", mo_zhgl.N_HYZH, "0", GetSql);
            }

            else if (btn.Text == "解除停押")
            {
                objAgentManageDB.NoXZHY("N_HYZH", mo_zhgl.N_HYZH, "1", GetSql);
            }
            else
            {
                objAgentManageDB.NoXZHY("N_HYZH", mo_zhgl.N_HYZH, "0", GetSql);
            }
            objAgentManageDB.Update(GetSql);
            drpDLS_SelectedIndexChanged(sender, e);
        }
        catch
        {
            this.ShowMsg("修改失敗");
        }
    }

    protected void btdel_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        int i_Index = ((GridViewRow)(btn.Parent.Parent)).RowIndex;

        string s_NID = ((Label)((GridViewRow)(btn.Parent.Parent)).FindControl("lblHYZH")).Text.ToString();

        KFB_HYGL mo_hygl = new KFB_HYGL();
        mo_hygl = objAgentManageDB.GetModelHYGL(s_NID);
        Hashtable mo_Ht = new Hashtable();
        int i_Count = objAgentManageDB.GetZD(s_NID);
        int i_OCount = objAgentManageDB.GetOZD(s_NID);
        i_Count = i_Count + i_OCount;

        DataSet ds = objAgentManageDB.GetList("N_HYZH='" + s_NID + "'");
        if (i_Count > 0)
        {
            this.ShowMsg("本賬號已有" + i_Count + "筆注單,無法刪除");
        }
        else if (ds.Tables[0].Rows.Count > 0)
        {
            this.ShowMsg("本賬號已有現金流操作,無法刪除");
        }
        else if (objAgentManageDB.Exists(s_NID))
        {
            objAgentManageDB.Delete(s_NID, mo_Ht);
            objAgentManageDB.SetDLSED(mo_hygl.N_DLDH.ToString(), -Convert.ToDecimal(mo_hygl.N_SYED.ToString()), mo_Ht);
            objAgentManageDB.SetTran(mo_Ht);
            drpDLS_SelectedIndexChanged(sender, e);
        }
        else
        {
            this.ShowMsg("本賬號已經刪除");
        }
    }
}
