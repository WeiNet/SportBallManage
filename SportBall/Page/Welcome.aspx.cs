#region histroy
///程式代號：      Welcome
///程式名稱：      Welcome
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region Using


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class Welcome : BasePage
{
    #region 全局变量
    DailyPostingDB objDailyDB = new DailyPostingDB();
    string strFlag = "";
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.gridGZ.PageSize = Convert.ToInt32(this.mPageSize);//設定GridView每個頁簽顯示的資料筆數
        this.gridHisData.PageSize = Convert.ToInt32(this.mPageSize);//設定GridView每個頁簽顯示的資料筆數
        DataQuery();
  
    }
    #endregion

    #region 按鈕事件(Button Events)
    protected void btgz_Click(object sender, EventArgs e)
    {
      
        try
        {
            DataTable DT = new DataTable();
            DT = objDailyDB.GetModel().Tables[0];

            int strcxbb = int.Parse(DT.Rows[0]["N_CXBB"].ToString());
            if (!strcxbb.Equals(1))
                objDailyDB.UpdateCXBB(1);

            Button btkf = ((Button)sender);
            int index = ((System.Web.UI.WebControls.GridViewRow)(btkf.Parent.Parent)).RowIndex;
            string strid = ((Label)this.gridGZ.Rows[index].Cells[0].FindControl("lbzwrq")).Text;
            //插入oldbill表中數
           
            // Hashtable htb = new Hashtable();
            ArrayList strar = new ArrayList();
            ArrayList par = new ArrayList();
            //更新彩票
            objDailyDB.TranCPType(strid, strar, par);
            //插入oldbill表中數
            objDailyDB.InsertOld(strid, strar, par);
            //刪除bill表數
            objDailyDB.dele(strid, strar, par);
            //删除旧的比赛
            objDailyDB.InsertOldBALL(strid, strar, par);
            objDailyDB.deleBALL(strid, strar, par);
            //時事跟新過賬記錄
            objDailyDB.TranLiveType(strid, strar, par);

            //赛马
            objDailyDB.InsertSMOld(strid, strar, par);
            objDailyDB.deleSM(strid, strar, par);


            ////時事像old中新增資料，刪除livejl中的資料
            //o_PTZD.InsertOldLive(strid, strar, par);
            //o_PTZD.deleLive(strid, strar, par);

            //更新帳務日

            //更新過
            objDailyDB.trans(strid, mUserID, strar, par);
            //更新六合彩 大乐透
            string[] strlx = new string[] { "lhc", "dlt" };
            for (int i = 0; i < strlx.Length; i++)
            {
                objDailyDB.delelhc(strlx[i].ToString(), strar, par);
            }

           KFB_LHCKPSD mo_LHCKPSD = new KFB_LHCKPSD();
          


            //取出未封盘
           if (!objDailyDB.Exists(0, 0))
            {
                objDailyDB.upFlag("1");
                mo_LHCKPSD.N_NO = Comm.GetNO();
                mo_LHCKPSD.N_TERM = objDailyDB.GetMaxNo() + 1;
                mo_LHCKPSD.N_STARTTIME = DateTime.Now;
                mo_LHCKPSD.N_TBHSTOPTIME = 5;
                mo_LHCKPSD.N_OTHERSHOWTIME = 5;
                mo_LHCKPSD.N_OTHERSTOPTIME = 5;
                mo_LHCKPSD.N_MONEY = 100;
                mo_LHCKPSD.N_DATE = DateTime.Now;
                mo_LHCKPSD.N_FLAG = 0;
                mo_LHCKPSD.N_OPEN = 0;
                mo_LHCKPSD.N_TBH = 0;
                mo_LHCKPSD.N_TT = 0;
                mo_LHCKPSD.N_TH = 0;
                mo_LHCKPSD.N_QCP = 0;
                mo_LHCKPSD.N_234 = 0;
                mo_LHCKPSD.N_JS = 0;

                objDailyDB.Add(mo_LHCKPSD);
            }

              KFB_DLTKPSD mo_DLTKPSD = new KFB_DLTKPSD();
          


            //取出未封盘
              if (!objDailyDB.ExistsTK(0, 0))
            {
                objDailyDB.upFlagTK("1");
                mo_DLTKPSD.N_NO = Comm.GetNO();
                mo_DLTKPSD.N_TERM = objDailyDB.GetTKNO() + 1;
                mo_DLTKPSD.N_STARTTIME = DateTime.Now;
                mo_DLTKPSD.N_TBHSTOPTIME = 5;
                mo_DLTKPSD.N_OTHERSHOWTIME = 5;
                mo_DLTKPSD.N_OTHERSTOPTIME = 5;
                mo_DLTKPSD.N_MONEY = 100;
                mo_DLTKPSD.N_DATE = DateTime.Now;
                mo_DLTKPSD.N_FLAG = 0;
                mo_DLTKPSD.N_OPEN = 0;
                mo_DLTKPSD.N_TBH = 0;
                mo_DLTKPSD.N_TT = 0;
                mo_DLTKPSD.N_TH = 0;
                mo_DLTKPSD.N_QCP = 0;
                mo_DLTKPSD.N_234 = 0;
                mo_DLTKPSD.N_JS = 0;

                objDailyDB.AddTK(mo_DLTKPSD);
            }

              objDailyDB.ExecuteSqlTran(strar, par);

              objDailyDB.UpdateCXBB(strcxbb);
            ShowMsg("过账成功！");
            
        }
        catch (Exception ex)
        {
            this.WriteLog(ex.ToString());
           ShowMsg("过账失败！");
        }

    }
    #endregion

    #region Grid事件(Grid Events)
    protected void gridGZ_DataBound(object sender, EventArgs e)
    {
        if (this.gridGZ.HeaderRow != null)
        {
            this.gridGZ.HeaderRow.Cells[1].ColumnSpan = 4;
            this.gridGZ.HeaderRow.Cells[2].Visible = false;
            this.gridGZ.HeaderRow.Cells[3].Visible = false;
            this.gridGZ.HeaderRow.Cells[4].Visible = false;
        }
        bool rows = true;
        for (int i = 0; i < this.gridGZ.Rows.Count; i++)
        {

            //合并单元格 
            GridViewRow gridrow = this.gridGZ.Rows[i];
            string strzwrq = ((Label)gridrow.Cells[0].FindControl("lbzwrq")).Text;
            string strtype = ((Label)gridrow.Cells[0].FindControl("lbTYPE")).Text;
            if (strzwrq.Equals(""))
            {
                gridrow.Visible = false;
            }
            else
            {
                if (strtype.Equals("999"))
                {
                    rows = true;
                    string strcount = ((Label)gridrow.Cells[0].FindControl("lbcounts")).Text;
                    gridrow.Cells[0].RowSpan = 3;
                    gridrow.Cells[1].Text = "尚未計算注單 ";
                    gridrow.Cells[2].Text = strcount + "筆";

                    //明細
                    string strmx = "";
                    DataSet ds = objDailyDB.GetZWZDMX(strzwrq, "0");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            strmx = strmx + " " + Comm.ChType(ds.Tables[0].Rows[j]["n_bslx"].ToString()) + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                        }
                        gridrow.Cells[3].Text = strmx;
                    }
                    else
                    {

                        ds = objDailyDB.GetAllGame(strzwrq);
                        string stryjs = "";
                        //篮球,棒球
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string strjstime = "";
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                strjstime = ds.Tables[0].Rows[j]["js"].ToString();
                                if (strjstime.Equals("0"))
                                {
                                    strmx = strmx + " " + Comm.ChType(ds.Tables[0].Rows[j]["n_lx"].ToString()) + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }
                                else
                                {
                                    stryjs = stryjs + " " + Comm.ChType(ds.Tables[0].Rows[j]["n_lx"].ToString()) + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }

                            }
                            gridrow.Cells[3].Text = strmx;
                        }
                        //塞马 
                        ds = objDailyDB.GetAllSMGame(strzwrq);
                        //篮球,棒球
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string strjstime = "";
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                strjstime = ds.Tables[0].Rows[j]["js"].ToString();
                                if (strjstime.Equals("0"))
                                {
                                    strmx = strmx + "  賽馬" + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }
                                else
                                {
                                    stryjs = stryjs + " 賽馬" + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }

                            }
                            gridrow.Cells[3].Text = strmx;
                        }
                        //運彩
                        ds = objDailyDB.GetAllYCGame(strzwrq);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string strjstime = "";
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                strjstime = ds.Tables[0].Rows[j]["js"].ToString();
                                if (strjstime.Equals("0"))
                                {
                                    strmx = strmx + "  彩票" + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }
                                else
                                {
                                    stryjs = stryjs + " 彩票" + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }

                            }
                            gridrow.Cells[3].Text = strmx;
                        }

                        //時事
                        ds = objDailyDB.GetAllSSGame(strzwrq);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string strjstime = "";
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                strjstime = ds.Tables[0].Rows[j]["js"].ToString();
                                if (strjstime.Equals("0"))
                                {
                                    strmx = strmx + "  時事" + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }
                                else
                                {
                                    stryjs = stryjs + " 時事" + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                                }

                            }
                            gridrow.Cells[3].Text = strmx;
                        }
                        //提示有多少场比赛没有计算，多少场比赛没有过帐
                        strmx = "沒有計算的比賽有：" + strmx;
                        strmx = strmx + "<br/><br/> 已計算沒有过帐的比賽有：" + stryjs;
                        gridrow.Cells[3].Text = strmx;
                        gridrow.Cells[3].RowSpan = 3;
                        gridrow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                        rows = false;
                    }

                    gridrow.Cells[4].RowSpan = 3;
                    Button btgz = new Button();
                    btgz.Attributes.Add("class","button");
                    btgz.Text = "執行過賬";
                    btgz.Click += new EventHandler(btgz_Click);
                    //if (strcount.Equals("0"))
                    //{
                    //    btgz.Enabled = true;
                    //}
                    //else
                    //{
                    //    btgz.Enabled = false;
                    //}  
                    gridrow.Cells[4].Controls.Add(btgz);
                }
                else if (strtype.Equals("1"))
                {
                    gridrow.Cells[0].Visible = false;
                    gridrow.Cells[1].Text = "單式注單";
                    string strzd = objDailyDB.GetZWZD(strzwrq, "1");
                    gridrow.Cells[2].Text = strzd + "筆";

                    //明細
                    string strmx = "";
                    DataSet ds = objDailyDB.GetZWZDMX(strzwrq, "1");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            strmx = strmx + " " + Comm.ChType(ds.Tables[0].Rows[j]["n_bslx"].ToString()) + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                        }

                    }
                    if (rows == true)
                    {
                        gridrow.Cells[3].Text = strmx;
                    }
                    else
                    {
                        gridrow.Cells[3].Visible = false;
                    }
                    gridrow.Cells[4].Visible = false;
                }
                else if (strtype.Equals("2"))
                {
                    gridrow.Cells[0].Visible = false;
                    gridrow.Cells[1].Text = "過關注單";
                    string strzd = objDailyDB.GetZWZD(strzwrq, "2");
                    gridrow.Cells[2].Text = strzd + "筆";

                    //明細
                    string strmx = "";
                    DataSet ds = objDailyDB.GetZWZDMX(strzwrq, "2");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            strmx = strmx + " " + Comm.ChType(ds.Tables[0].Rows[j]["n_bslx"].ToString()) + " " + ds.Tables[0].Rows[j]["counts"].ToString() + "筆";
                        }
                    }
                    if (rows == true)
                    {
                        gridrow.Cells[3].Text = strmx;
                    }
                    else
                    {
                        gridrow.Cells[3].Visible = false;
                    }
                    gridrow.Cells[4].Visible = false;
                }
            }
        }
    }
    #endregion

    #region 自定義方法(Definition Private Methods)

    public void DataQuery()
    {


        try
        {

            DataTable DT = new DataTable();
            DT = objDailyDB.getPostingData().Tables["ds"];
            if (DT.Rows.Count == 0)
            {
                ShowMsg("查无资料");
            }
            else
            {
                this.gridHisData.DataSource = DT;//把查出的資料傳給grvQuery的數據源
                this.gridHisData.DataBind();  //把資料綁定在grvQuery

            }
            DataSet getds = objDailyDB.GetZWRQ();
            if (getds.Tables[0].Rows.Count > 0)
            {
                DataTable tb = getds.Tables[0];
                int j = tb.Rows.Count;
                for (int i = 0; i < j; i++)
                {
                    int ints = i * 3;
                    tb.Rows[ints]["counts"] = Comm.Trim(objDailyDB.GetZW(tb.Rows[ints]["zwrq"].ToString()));
                    DataRow newrow = tb.NewRow();
                    newrow["zwrq"] = tb.Rows[ints]["zwrq"].ToString();
                    newrow["counts"] = "1";
                    newrow["TYPE"] = "1";
                    tb.Rows.InsertAt(newrow, ints + 1);
                    DataRow newrowt = tb.NewRow();
                    newrowt["zwrq"] = tb.Rows[ints]["zwrq"].ToString();
                    newrowt["counts"] = "1";
                    newrowt["TYPE"] = "2";
                    tb.Rows.InsertAt(newrowt, ints + 2);
                }
                this.gridGZ.DataSource = getds;
                this.gridGZ.DataBind();
            }
        }
        catch (Exception ex) {
            this.WriteLog(ex.ToString());
            this.ShowMsg("查询失败");//查詢失敗
        }


    }
    #endregion

   

    
}
