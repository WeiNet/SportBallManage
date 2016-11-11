#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class re_xshy : BasePage
{
    #region 全局变数
    ReportDB objReportDB = new ReportDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetGrid("0", "0");
        }

    }
    #endregion

    #region 按钮事件
    protected void btcx_Click(object sender, EventArgs e)
    {

        string strhyzh = this.txthyzh.Text.Equals("") ? "0" : this.txthyzh.Text;
        string strhyip = this.txtip.Text.Equals("") ? "0" : this.txtip.Text;
        SetGrid(strhyzh, strhyip);
    }
    #endregion

    #region gridview事件
    protected void JXGrid1_DataBound(object sender, EventArgs e)
    {

        for (int i = 0; i < this.JXGrid1.Rows.Count; i++)
        {
            GridViewRow gridrow = this.JXGrid1.Rows[i];
            string hydj = gridrow.Cells[1].Text;
            string strhyid = gridrow.Cells[0].Text;
            gridrow.Cells[1].Text = Comm.HYDJ(hydj);
            DataSet ds = new DataSet();
            if (hydj.Equals("10"))
            {
                ds = this.objReportDB.GetHYDS(strhyid);
            }
            else
            {
                ds = objReportDB.GetZHZL(strhyid);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridrow.Cells[3].Text = ds.Tables[0].Rows[0]["n_dzjdh"].ToString();
                gridrow.Cells[4].Text = ds.Tables[0].Rows[0]["n_zjdh"].ToString();
                gridrow.Cells[5].Text = ds.Tables[0].Rows[0]["n_dgddh"].ToString();
                gridrow.Cells[6].Text = ds.Tables[0].Rows[0]["n_gddh"].ToString();
                gridrow.Cells[7].Text = ds.Tables[0].Rows[0]["n_zdldh"].ToString();
                gridrow.Cells[8].Text = ds.Tables[0].Rows[0]["n_dldh"].ToString();
            }
        }
    }
    #endregion

    #region 自定义事件

    public void SetGrid(string strhyzh, string strhyip)
    {
        //清掉
        this.txthyzh.Text = this.txthyzh.Text.ToUpper();
        objReportDB.DeleteXSHY();
        this.JXGrid1.DataSource = objReportDB.GetXSHY(strhyzh, strhyip, ms_GROUP_LEVEL, "0");
        this.JXGrid1.DataBind();
        this.JXGrid2.DataSource = objReportDB.GetXSHYRS(ms_GROUP_LEVEL, "0");
        this.JXGrid2.DataBind();
    }
    #endregion






}
