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

public partial class re_iplist : BasePage
{
    #region 全局变数
    ReportDB objReportDB = new ReportDB();
    KFB_HYGLDB objHygl = new KFB_HYGLDB();
    AgentManageAddDB objAgentManageAddDB = new AgentManageAddDB();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetGrid();
        }
     

    }
    #endregion

    #region 按钮事件
   
    #endregion

    #region gridview事件
    protected void Gridgs_DataBound(object sender, EventArgs e)
    {
        Grid_bound(this.Gridgs);
    }

    protected void Gridhy_DataBound(object sender, EventArgs e)
    {
        Grid_bound(this.Gridhy);

    }
    #endregion

    #region 自定义事件
    public void SetGrid()
    {
       
        this.Gridgs.DataSource = this.objReportDB.GetCS("gs");
        this.Gridgs.DataBind();


        this.Gridhy.DataSource = objReportDB.GetCS("hy");
        this.Gridhy.DataBind();
    }
    protected void Grid_bound(GridView o_grid)
    {
      
        for (int i = 0; i < o_grid.Rows.Count; i++)
        {
            GridViewRow gridrow = o_grid.Rows[i];
            string hydj = gridrow.Cells[1].Text;
            string strhyid = gridrow.Cells[0].Text;
            gridrow.Cells[1].Text = Comm.HYDJ(hydj);
            DataSet ds = new DataSet();
            if (hydj.Equals("10"))
            {
                ds = objReportDB.GetHYDS(strhyid);
            }
            else
            {
                ds = this.objReportDB.GetZHZL(strhyid);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridrow.Cells[2].Text = ds.Tables[0].Rows[0]["n_dzjdh"].ToString();
                gridrow.Cells[3].Text = ds.Tables[0].Rows[0]["n_zjdh"].ToString();
                gridrow.Cells[4].Text = ds.Tables[0].Rows[0]["n_dgddh"].ToString();
                gridrow.Cells[5].Text = ds.Tables[0].Rows[0]["n_gddh"].ToString();
                gridrow.Cells[6].Text = ds.Tables[0].Rows[0]["n_zdldh"].ToString();
                gridrow.Cells[7].Text = ds.Tables[0].Rows[0]["n_dldh"].ToString();
            }
        }
    }
    #endregion
     

}
