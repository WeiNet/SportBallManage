using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class dlgl : BasePage
    {
        private AgentManageDB objAgentManageDB = new AgentManageDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ZJGrid.RowColor = System.Drawing.Color.FromName("#ddeeff");
            if (!IsPostBack)
            {
                SetPage();
                if (Request["n_dzjdh"] != null)
                {
                    string strzjid = Request["n_dzjdh"].ToString();
                    this.drzj.SelectedValue = strzjid;
                    GetDGD(strzjid);
                    strzjid = Request["n_zjdh"].ToString();
                    this.drdgd.SelectedValue = strzjid;
                    GetGD(strzjid);
                    strzjid = Request["n_dgddh"].ToString();
                    this.drgd.SelectedValue = strzjid;
                    GetZDL(strzjid);
                    strzjid = Request["n_gddh"].ToString();
                    this.drzdl.SelectedValue = strzjid;
                    GetDL(strzjid);
                    strzjid = Request["n_zdldh"].ToString();
                    this.drdl.SelectedValue = strzjid;
                    //GetGD(strzjid);
                    SetGrid(strzjid);
                }
                else if (Request["gdid"] != null)
                {
                    GetDL(Request["gdid"]);
                }
                else
                {
                    this.trsj.Visible = false;

                }
            }
            else
            {
                string strzj = this.drzj.SelectedValue;
                //GetDGD(strzj);
                //strzj = this.drdgd.SelectedValue;
                //GetGD(strzj);
                //strzj = this.drgd.SelectedValue;
                //GetZDL(strzj);
                //strzj = this.drzdl.SelectedValue;
                //GetDL(strzj);
                strzj = this.drdl.SelectedValue;
                SetGrid(strzj);

            }
            if (this.drdl.SelectedValue.Equals("0"))
            {
                this.btnAdd.Visible = false;
                this.btnBack.Visible = false;
            }
            else
            {
                this.btnAdd.Visible = true;
                this.btnBack.Visible = true;
            }
            if (Comm.GetFlag(this.mUserID) == "1")
                btnAdd.Visible = false;
        }
        protected void Adddgd_Click(object sender, EventArgs e)
        {
            this.Server.Transfer("AgentManageAdd.aspx?lv=9&parid=" + this.drdl.SelectedValue);
        }
        #region"頁面初始化"
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
            DataSet dsbj = objAgentManageDB.GetMember("9");
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
        protected void GetDL(string strzj)
        {
            if (!strzj.Equals(this.hiddl.Value))
            {
                this.hiddl.Value = strzj;

                DataSet ds = objAgentManageDB.GetMember("8", strzj);
                this.drdl.Items.Clear();
                ListItem liitems = new ListItem();
                liitems.Value = "0";
                liitems.Text = "未選擇";
                this.drdl.Items.Add(liitems);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem liitem = new ListItem();
                    liitem.Value = ds.Tables[0].Rows[i]["n_hyzh"].ToString();
                    liitem.Text = ds.Tables[0].Rows[i]["n_hyzh"].ToString() + "[" + ds.Tables[0].Rows[i]["n_hymc"].ToString() + "]";
                    this.drdl.Items.Add(liitem);
                }
            }
        }
        #endregion
        #region"GRID數據邦定"
        protected void SetGrid(string strname)
        {

            this.ZJGrid.DataSource = objAgentManageDB.GetMember("9", strname);
            this.ZJGrid.DataBind();
            if (strname.Equals("0"))
            {
                string[] strZHSJ = getZHSJ().Split(',');
                DataSet dsbj = objAgentManageDB.GetMember("9", strZHSJ[0], strZHSJ[1]);
                this.lbbj.Text = dsbj.Tables[0].Rows.Count.ToString();
            }
        }
        #endregion
        #region"編輯GRID"
        //protected void ZJGrid_DataBound(object sender, EventArgs e)
        //{
        //    KingOfBall.BLL.KFB_ZHGL_BILL o_zhgl = new KingOfBall.BLL.KFB_ZHGL_BILL();
        //    for (int i = 0; i < this.ZJGrid.Rows.Count; i++)
        //    {
        //        HyperLink o_hl = new HyperLink();
        //        o_hl.NavigateUrl = "xgzh.aspx?id=" + this.ZJGrid.Rows[i].Cells[0].Text + "&lv=9"; ;
        //        o_hl.Text = this.ZJGrid.Rows[i].Cells[0].Text;
        //        this.ZJGrid.Rows[i].Cells[0].Controls.Add(o_hl);
        //        string stryxdl = this.ZJGrid.Rows[i].Cells[4].Text;
        //        string stryxxz = this.ZJGrid.Rows[i].Cells[5].Text;
        //        if (stryxdl.Equals("1"))
        //        {
        //            this.ZJGrid.Rows[i].Cells[4].Text = "允許登入";
        //            this.ZJGrid.Rows[i].Cells[4].Style.Add("color", "blue");
        //        }
        //        else
        //        {
        //            this.ZJGrid.Rows[i].Cells[4].Text = "不允許登入";
        //            this.ZJGrid.Rows[i].Cells[4].Style.Add("color", "red");
        //        }
        //        if (stryxxz.Equals("1"))
        //        {
        //            this.ZJGrid.Rows[i].Cells[5].Text = "允許下注";
        //            this.ZJGrid.Rows[i].Cells[5].Style.Add("color", "green");
        //        }
        //        else
        //        {
        //            this.ZJGrid.Rows[i].Cells[5].Text = "不允許下注";
        //            this.ZJGrid.Rows[i].Cells[5].Style.Add("color", "red");
        //        }
        //        string strcz = "籃球=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbLQCZ")).Text + "%,";
        //        strcz = strcz + "棒球=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbMBCZ")).Text + "%,";
        //        strcz = strcz + "网球=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbRBCZ")).Text + "%,";
        //        strcz = strcz + "排球=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbTBCZ")).Text + "%,";
        //        strcz = strcz + "足球=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbZQCZ")).Text + "%,";
        //        strcz = strcz + "美足=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbMZCZ")).Text + "%,";
        //        strcz = strcz + "冰球=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbMBCZ")).Text + "%,";
        //        strcz = strcz + "指數=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbZSCZ")).Text + "%,";
        //        strcz = strcz + "<br>樂透=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbDLTCZ")).Text + "%,";
        //        strcz = strcz + "運彩=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbCPCZ")).Text + "%,";
        //        strcz = strcz + "賽馬=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbSMCZ")).Text + "%,";
        //        strcz = strcz + "六合=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbLHCCZ")).Text + "%,";
        //        strcz = strcz + "二星=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lb2XCZ")).Text + "%,";
        //        strcz = strcz + "三星=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lb3XCZ")).Text + "%,";
        //        strcz = strcz + "四星=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lb4XCZ")).Text + "%,";
        //        strcz = strcz + "今彩=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbJCCZ")).Text + "%,";
        //        strcz = strcz + "時事=" + ((Label)this.ZJGrid.Rows[i].Cells[8].FindControl("lbSSCZ")).Text + "%,";
        //        this.ZJGrid.Rows[i].Cells[6].Text = strcz;
        //        string strcount = o_zhgl.GetHYMember( this.ZJGrid.Rows[i].Cells[0].Text).Tables[0].Rows.Count.ToString();
        //        HyperLink o_Mem = new HyperLink();
        //        //o_Mem.NavigateUrl = "hygl.aspx.aspx?id=" + this.ZJGrid.Rows[i].Cells[0].Text;
        //        o_Mem.NavigateUrl = "hygl.aspx?n_dzjdh=" + this.drzj.SelectedValue + "&n_zjdh=" + this.drdgd.SelectedValue + "&n_dgddh=" + this.drgd.SelectedValue + "&n_gddh=" + this.drzdl.SelectedValue + "&n_zdldh=" +this.drdl.SelectedValue+ "&n_dldh=" + this.ZJGrid.Rows[i].Cells[0].Text;
        //        o_Mem.Text = strcount;
        //        this.ZJGrid.Rows[i].Cells[7].Controls.Add(o_Mem);

        //    }
        //    if (this.ZJGrid.Rows.Count > 0)
        //    {
        //        this.trsj.Visible = true;
        //        this.lbxj.Text = this.ZJGrid.Rows.Count.ToString();
        //        string strsj = this.drdl.SelectedItem.Value;
        //        this.lbsj.Text = this.drdl.SelectedItem.Text;
        //        this.lbm1.Text = Convert.ToString(Convert.ToDouble(o_zhgl.Getxyed(strsj)) - Convert.ToDouble(o_zhgl.Getsyed(strsj)));
        //        this.lbm2.Text = o_zhgl.Getsyed(strsj);
        //        this.trbj.Visible = false;
        //    }
        //    else
        //    {
        //        this.trsj.Visible = false;
        //        this.trbj.Visible = true;
        //    }
        //}

        protected void ZJGrid_DataBound(object sender, EventArgs e)
        {
            //KingOfBall.BLL.KFB_ZHGL_BILL o_zhgl = new KingOfBall.BLL.KFB_ZHGL_BILL();
            for (int i = 0; i < this.ZJGrid.Rows.Count; i++)
            {
                HyperLink o_hl = new HyperLink();
                o_hl.NavigateUrl = "AgentManageUpd.aspx?id=" + this.ZJGrid.Rows[i].Cells[0].Text + "&lv=9"; ;
                o_hl.Text = this.ZJGrid.Rows[i].Cells[0].Text;
                this.ZJGrid.Rows[i].Cells[0].Controls.Add(o_hl);
                string strcount = objAgentManageDB.GetHYMember(this.ZJGrid.Rows[i].Cells[0].Text).Tables[0].Rows.Count.ToString();
                HyperLink o_Mem = new HyperLink();
                o_Mem.NavigateUrl = "hygl.aspx?n_dzjdh=" + this.drzj.SelectedValue + "&n_zjdh=" + this.drdgd.SelectedValue + "&n_dgddh=" + this.drgd.SelectedValue + "&n_gddh=" + this.drzdl.SelectedValue + "&n_zdldh=" + this.drdl.SelectedValue + "&n_dldh=" + this.ZJGrid.Rows[i].Cells[0].Text;
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
                ((LinkButton)this.ZJGrid.Rows[i].FindControl("lbtnJBZL")).Attributes.Add("onclick", "window.location.href='AgentManageUpd.aspx?id=" + this.ZJGrid.Rows[i].Cells[0].Text + "&lv=9';return false;");
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
                string strsj = this.drdl.SelectedItem.Value;
                this.lbsj.Text = this.drdl.SelectedItem.Text;
                this.lbm1.Text = Convert.ToString(Convert.ToDouble(this.objAgentManageDB.Getxyed(strsj)) - Convert.ToDouble(this.objAgentManageDB.Getsyed(strsj)));
                this.lbm2.Text = this.objAgentManageDB.Getsyed(strsj);
                this.trbj.Visible = false;
            }
            else
            {
                this.trsj.Visible = false;
                this.trbj.Visible = true;
            }
        }
        #endregion
        protected void btnBack_Click(object sender, EventArgs e)
        {
            string sjid = "";
            if (this.drzdl.SelectedValue != "0")
                sjid = "?&dzjid=" + this.drzj.SelectedValue + "&zjid=" + this.drdgd.SelectedValue + "&dgdid=" + this.drgd.SelectedValue + "&gdid=" + this.drzdl.SelectedValue;
            this.Server.Transfer("AgentManage.aspx" + sjid);
        }
        #region 返回代理總人數
        private string getZHSJ()
        {
            string strZHSJ = "";
            if (!this.drdl.SelectedValue.Equals("0"))
                strZHSJ = "8," + this.drdl.SelectedValue;
            else if (!this.drzdl.SelectedValue.Equals("0"))
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

        protected void btnOperate_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable GetSql = new Hashtable();
             

                LinkButton btn = (LinkButton)sender;
                int i_Index = ((GridViewRow)(btn.Parent.Parent)).RowIndex;

                string s_NID = "";
                s_NID = ((GridView)(btn.Parent.Parent.Parent.Parent)).Rows[i_Index].Cells[0].Text.ToString().Trim();
                KFB_ZHGL mo_zhgl = this.objAgentManageDB.GetModel(s_NID);

                if (btn.Text == "啟用")
                {
                    this.objAgentManageDB.NoLogZH("N_HYZH", mo_zhgl.N_HYZH, "1", GetSql);
                }
                else if (btn.Text == "停用")
                {
                    this.objAgentManageDB.NoLogZH(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                    this.objAgentManageDB.NoLogHY(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                }

                else if (btn.Text == "解除停押")
                {
                    this.objAgentManageDB.NoXZZH("N_HYZH", mo_zhgl.N_HYZH, "1", GetSql);
                }
                else
                {
                    this.objAgentManageDB.NoXZZH(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                    this.objAgentManageDB.NoXZHY(Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()), mo_zhgl.N_HYZH, "0", GetSql);
                }
                this.objAgentManageDB.Update(GetSql);

                SetGrid(this.drdl.SelectedValue);
            }
            catch
            {
                this.ShowMsg("修改失敗");
            }
        }

        protected void btdel_Click(object sender, EventArgs e)
        {
         
            KFB_ZHGL mo_zhgl = new KFB_ZHGL(); 
            LinkButton btn = (LinkButton)sender;
            int i_Index = ((GridViewRow)(btn.Parent.Parent)).RowIndex;

            string s_NID = "";
            s_NID = ((GridView)(btn.Parent.Parent.Parent.Parent)).Rows[i_Index].Cells[0].Text.ToString().Trim();
            mo_zhgl = this.objAgentManageDB.GetModel(s_NID);

            //判断是否有注單
            int i_Count = this.objAgentManageDB.GetZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
            if (i_Count > 0)
            {
                this.ShowMsg("本賬號已有注單，無法删除！");
                return;
            }

            int i_HYCount = this.objAgentManageDB.GetHYZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
            if (i_HYCount > 0)
            {
                this.ShowMsg("本賬號下級會員已有注單，無法删除！");
                return;
            }

            int i_oCount = this.objAgentManageDB.GetOZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
            if (i_oCount > 0)
            {
                this.ShowMsg("本賬號已有歷史注單，無法删除！");
                return;
            }

            int i_oHYCount = this.objAgentManageDB.GetOHYZD(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));
            if (i_oHYCount > 0)
            {
                this.ShowMsg("本賬號下級會員已有歷史注單，無法删除！");
                return;
            }

            try
            {
                //判斷是否存在
                bool chuser = this.objAgentManageDB.Exists(s_NID);
                if (!chuser)
                {
                    this.ShowMsg("該會員已被刪除！");
                }
                else//存在則修改
                {
                    #region"修改上级剩余额度"
                    this.objAgentManageDB.UpSJED(mo_zhgl);

                    #endregion
                    //o_KFB_ZHGL.Delete(strparid, Convert.ToInt32(strlvl));
                    this.objAgentManageDB.DeleteAll(s_NID, Comm.GetZHCol(mo_zhgl.N_HYDJ.ToString()));

                    SetGrid(this.drdl.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                this.WriteLog("用户名="+mUserID+ex.ToString()); 
                this.ShowMsg("删除失败");
            }

        }
    }
