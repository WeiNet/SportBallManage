#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class AgentManage : BasePage
{
    #region 全局变量
    AgentManageDB objAgentManageDB = new AgentManageDB();
    string strgdid = "";
    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ZJGrid.RowColor = System.Drawing.Color.FromName("#ddeeff");
        if (!IsPostBack)
        {
            SetPage();
            if (Request["dzjid"] != null)
            {
                string strzjid = Request["dzjid"].ToString();
                this.drzj.SelectedValue = strzjid;
                GetDGD(strzjid);
                strzjid = Request["zjid"].ToString();
                this.drdgd.SelectedValue = strzjid;
                GetGD(strzjid);
                strzjid = Request["dgdid"].ToString();
                this.drgd.SelectedValue = strzjid;
                GetZDL(strzjid);
                strgdid = Request["gdid"].ToString();
                strzjid = Request["gdid"].ToString();
                this.drzdl.SelectedValue = strzjid;
                //GetGD(strzjid);
                SetGrid(strzjid);
            }
            else
                this.trsj.Visible = false;
        }
        else
        {
            string strzj = this.drzj.SelectedValue;
            GetDGD(strzj);
            strzj = this.drdgd.SelectedValue;
            GetGD(strzj);
            strzj = this.drgd.SelectedValue;
            GetZDL(strzj);
            strzj = this.drzdl.SelectedValue;
            SetGrid(strzj);

        }
        if (this.drzdl.SelectedValue.Equals("0"))
        {
            this.btnAdd.Visible = false;
        }
        else
        {
            this.btnAdd.Visible = true;
        }
        if (Comm.GetFlag(mUserID) == "1")
            btnAdd.Visible = false;

    }
    #endregion

    #region  按钮事件
    protected void Adddgd_Click(object sender, EventArgs e)
    {
        this.Server.Transfer("AgentManageAdd.aspx?lv=8&parid=" + this.drzdl.SelectedValue);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        string sjid = "";
        if (this.drgd.SelectedValue != "0")
            sjid = "?&dzjid=" + this.drzj.SelectedValue + "&zjid=" + this.drdgd.SelectedValue + "&dgdid=" + this.drgd.SelectedValue;
        this.Server.Transfer("gdgl.aspx" + sjid);

    }
    protected void btdel_Click(object sender, EventArgs e)
    {
      
          KFB_ZHGL mo_zhgl = new KFB_ZHGL(); 
        LinkButton btn = (LinkButton)sender;
        int i_Index = ((GridViewRow)(btn.Parent.Parent)).RowIndex;

        string s_NID = "";
        s_NID = ((GridView)(btn.Parent.Parent.Parent.Parent)).Rows[i_Index].Cells[0].Text.ToString().Trim();
        mo_zhgl = objAgentManageDB.GetModel(s_NID);

        //判断是否有注單
        int i_Count = objAgentManageDB.GetZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
        if (i_Count > 0)
        {
            
           this.ShowMsg("本賬號已有注單，無法删除！");
            return;
        }

        int i_HYCount = objAgentManageDB.GetHYZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
        if (i_HYCount > 0)
        {
           this.ShowMsg("本賬號下級會員已有注單，無法删除！");
            return;
        }

        int i_oCount = objAgentManageDB.GetOZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
        if (i_oCount > 0)
        {
           this.ShowMsg("本賬號已有歷史注單，無法删除！");
            return;
        }

        int i_oHYCount = objAgentManageDB.GetOHYZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
        if (i_oHYCount > 0)
        {
           this.ShowMsg("本賬號下級會員已有歷史注單，無法删除！");
            return;
        }

        try
        {
            //判斷是否存在
            bool chuser = objAgentManageDB.Exists(s_NID);
            if (!chuser)
            {
               this.ShowMsg("該會員已被刪除！");
            }
            else//存在則修改
            {
                #region"修改上级剩余额度"
                objAgentManageDB.UpSJED(mo_zhgl);

                #endregion
                //o_KFB_ZHGL.Delete(strparid, Convert.ToInt32(strlvl));
                objAgentManageDB.DeleteAll(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));

                SetGrid(this.drzdl.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            this.WriteLog("用户名=" + mUserID+ex.ToString());
            this.ShowMsg("删除失败");
        }

    }
    protected void btnOperate_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable GetSql = new Hashtable(); 
            LinkButton btn = (LinkButton)sender;
            int i_Index = ((GridViewRow)(btn.Parent.Parent)).RowIndex;

            string s_NID = "";
            s_NID = ((GridView)(btn.Parent.Parent.Parent.Parent)).Rows[i_Index].Cells[0].Text.ToString().Trim();
            KFB_ZHGL mo_zhgl = objAgentManageDB.GetModel(s_NID);

            if (btn.Text == "啟用")
            {
                objAgentManageDB.NoLogZH("N_HYZH", mo_zhgl.N_HYZH, "1", GetSql);
            }
            else if (btn.Text == "停用")
            {
                objAgentManageDB.NoLogZH(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                objAgentManageDB.NoLogHY(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
            }

            else if (btn.Text == "解除停押")
            {
                objAgentManageDB.NoXZZH("N_HYZH", mo_zhgl.N_HYZH, "1", GetSql);
            }
            else
            {
                objAgentManageDB.NoXZZH(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                objAgentManageDB.NoXZHY(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
            }
            objAgentManageDB.Update(GetSql);

            SetGrid(this.drzdl.SelectedValue);
        }
        catch
        {
            this.ShowMsg("修改失敗");
          
        }
    }
    #endregion

    #region gridview事件

    protected void ZJGrid_DataBound(object sender, EventArgs e)
    {
      
        for (int i = 0; i < this.ZJGrid.Rows.Count; i++)
        {
            HyperLink o_hl = new HyperLink();
            o_hl.NavigateUrl = "AgentManageUpd.aspx?id=" + this.ZJGrid.Rows[i].Cells[0].Text + "&lv=8"; ;
            o_hl.Text = this.ZJGrid.Rows[i].Cells[0].Text;
            this.ZJGrid.Rows[i].Cells[0].Controls.Add(o_hl);

            string strcount = objAgentManageDB.GetMember("9", this.ZJGrid.Rows[i].Cells[0].Text).Tables[0].Rows.Count.ToString();
            HyperLink o_Mem = new HyperLink();
            o_Mem.NavigateUrl = "dlgl.aspx?n_dzjdh=" + this.drzj.SelectedValue + "&n_zjdh=" + this.drdgd.SelectedValue + "&n_dgddh=" + this.drgd.SelectedValue + "&n_gddh=" + this.drzdl.SelectedValue + "&n_zdldh=" + this.ZJGrid.Rows[i].Cells[0].Text;
            o_Mem.Text = strcount;
            this.ZJGrid.Rows[i].Cells[5].Controls.Add(o_Mem);
            string stryxdl = this.ZJGrid.Rows[i].Cells[7].Text;
            string stryxxz = ((Label)this.ZJGrid.Rows[i].FindControl("lblYXXZ")).Text;
            if (stryxdl.Equals("1"))
            {
                this.ZJGrid.Rows[i].Cells[7].Text = "啟用";
                ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnTY")).Text = "停用";
            }
            else
            {
                this.ZJGrid.Rows[i].Cells[7].Text = "停用";
                ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnTY")).Text = "啟用";
            }

            if (stryxxz.Equals("1"))
            {
                ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnTZXZ")).Text = "停止押注";
            }
            else
            {
                ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnTZXZ")).Text = "解除停押";
            }
            ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnJBZL")).Attributes.Add("onclick", "window.location.href='AgentManageUpd.aspx?id=" + this.ZJGrid.Rows[i].Cells[0].Text + "&lv=8';return false;");
            ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnTY")).Attributes.Add("onclick", "if(confirm('確定停用/啟用" + this.ZJGrid.Rows[i].Cells[0].Text + "?')){return true;} else{return false;}");
            ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnTZXZ")).Attributes.Add("onclick", "if(confirm('確定要對該帳號停押/解除停押?')){return true;} else{return false;}");
            ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnSC")).Attributes.Add("onclick", "if(confirm('確定要刪除" + this.ZJGrid.Rows[i].Cells[0].Text + "?')){return true;} else{return false;}");
            ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnQXXSD")).Attributes.Add("onclick", "window.open('ZQ_set.aspx?UserName=" + this.ZJGrid.Rows[i].Cells[0].Text + "')");
            //((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnCXXSD")).Attributes.Add("onclick", "window.open('../htm/lottery_set_3d.htm','','width=650,height=710,scrollbars=1,toolbar=0,menubar=0,location=0,directories=0,statu=0');return false;");
        }
        if (this.ZJGrid.Rows.Count > 0)
        {
            this.trsj.Visible = true;
            this.lbxj.Text = this.ZJGrid.Rows.Count.ToString();
            string strsj = this.drzdl.SelectedItem.Value;
            this.lbsj.Text = strgdid;
            if (!strgdid.Equals(""))
            {
                this.lbm1.Text = Convert.ToString(Convert.ToDouble(objAgentManageDB.Getxyed(strgdid)) - Convert.ToDouble(objAgentManageDB.Getsyed(strgdid)));
                this.lbm2.Text = objAgentManageDB.Getsyed(strgdid);
            }
          
            this.trbj.Visible = false;
        }
        else
        {
            this.trsj.Visible = false;
            this.trbj.Visible = true;
        }
    }
    #endregion



    #region 自定义事件
    protected void SetPage()
    {

        DataSet ds = objAgentManageDB.GetMember("4");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem liitem = new ListItem();
            liitem.Value = ds.Tables[0].Rows[i]["n_hyzh"].ToString();
            liitem.Text = ds.Tables[0].Rows[i]["n_hyzh"].ToString() + "[" + ds.Tables[0].Rows[i]["n_hymc"].ToString() + "]";
            this.drzj.Items.Add(liitem);
        }
        DataSet dsbj = objAgentManageDB.GetMember("8");
        this.lbbj.Text = dsbj.Tables[0].Rows.Count.ToString();

    }
    protected void GetDGD(string strzj)
    {
        if (!strzj.Equals(this.hidzj.Value))
        {
            this.hidzj.Value = strzj;

            DataSet ds = objAgentManageDB.GetMember("5", strzj);
            this.drdgd.Items.Clear();
            ListItem liitems = new ListItem();
            liitems.Value = "0";
            liitems.Text = "未選擇";
            this.drdgd.Items.Add(liitems);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem liitem = new ListItem();
                liitem.Value = ds.Tables[0].Rows[i]["n_hyzh"].ToString();
                liitem.Text = ds.Tables[0].Rows[i]["n_hyzh"].ToString() + "[" + ds.Tables[0].Rows[i]["n_hymc"].ToString() + "]";
                this.drdgd.Items.Add(liitem);
            }
        }
    }
    protected void GetGD(string strzj)
    {
        if (!strzj.Equals(this.hiddgd.Value))
        {
            this.hiddgd.Value = strzj;

            DataSet ds = objAgentManageDB.GetMember("6", strzj);
            this.drgd.Items.Clear();
            ListItem liitems = new ListItem();
            liitems.Value = "0";
            liitems.Text = "未選擇";
            this.drgd.Items.Add(liitems);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem liitem = new ListItem();
                liitem.Value = ds.Tables[0].Rows[i]["n_hyzh"].ToString();
                liitem.Text = ds.Tables[0].Rows[i]["n_hyzh"].ToString() + "[" + ds.Tables[0].Rows[i]["n_hymc"].ToString() + "]";
                this.drgd.Items.Add(liitem);
            }
        }
    }
    protected void GetZDL(string strzj)
    {
        if (!strzj.Equals(this.hidzdl.Value))
        {
            this.hidzdl.Value = strzj;

            DataSet ds = objAgentManageDB.GetMember("7", strzj);
            this.drzdl.Items.Clear();
            ListItem liitems = new ListItem();
            liitems.Value = "0";
            liitems.Text = "未選擇";
            this.drzdl.Items.Add(liitems);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem liitem = new ListItem();
                liitem.Value = ds.Tables[0].Rows[i]["n_hyzh"].ToString();
                liitem.Text = ds.Tables[0].Rows[i]["n_hyzh"].ToString() + "[" + ds.Tables[0].Rows[i]["n_hymc"].ToString() + "]";
                this.drzdl.Items.Add(liitem);
            }
        }
    }


    protected void SetGrid(string strname)
    {

        this.ZJGrid.DataSource = objAgentManageDB.GetMember("8", strname);
        this.ZJGrid.DataBind();
        if (strname.Equals("0"))
        {
            string[] strZHSJ = getZHSJ().Split(',');
            DataSet dsbj = objAgentManageDB.GetMember("8", strZHSJ[0], strZHSJ[1]);
            this.lbbj.Text = dsbj.Tables[0].Rows.Count.ToString();
        }
    }
    private string getZHSJ()
    {
        string strZHSJ = "";
        if (!this.drzdl.SelectedValue.Equals("0"))
            strZHSJ = "7," + this.drzdl.SelectedValue;
        else if (!this.drgd.SelectedValue.Equals("0"))
            strZHSJ = "6," + this.drgd.SelectedValue;
        else if (!this.drdgd.SelectedValue.Equals("0"))
            strZHSJ = "5," + this.drdgd.SelectedValue;
        else if (!this.drzj.SelectedValue.Equals("0"))
            strZHSJ = "4," + this.drzj.SelectedValue;
        else
            strZHSJ = ",";
        return strZHSJ;
    }

    #endregion
}
