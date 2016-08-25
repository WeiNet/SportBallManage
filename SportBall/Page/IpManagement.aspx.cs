#region histroy
///程式代號：      IpManagement
///程式名稱：      IpManagement
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
#endregion

    public partial class IpManagement : BasePage
    {
        #region 全局变量

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
               this. Query();
            }
        }
        #endregion

        #region 按钮事件
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ////if (this.mUserID != "188WEN")
                ////{
                ////    this.ShowMsg("您没有新增IP的权限");
                ////    return;
                ////}
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Current.Server.MapPath("../Data/IpList.xml"));
                XmlNode root = xmlDoc.SelectSingleNode("IpList");


                XmlNodeList xnl = root.ChildNodes;
                foreach (XmlNode xnf in xnl)
                {
                    XmlElement xe = (XmlElement)xnf;
                    if (this.txtIP.Text.ToString().Trim() == xe.InnerText.Trim())
                    {
                        this.ShowMsg("IP已经存在");
                        return;
                    }
                }

                XmlElement ipsub = xmlDoc.CreateElement("ip");
                ipsub.InnerText = this.txtIP.Text.ToString().Trim();
                root.AppendChild(ipsub);
                xmlDoc.Save(HttpContext.Current.Server.MapPath("../Data/IpList.xml"));
                Query();
            }
            catch (Exception ex)
            {
               this.WriteLog(ex.ToString());
                ShowMsg("保存失敗");
            }

        }
        #endregion

        #region grid事件
        protected void grvip_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string strip = this.grvip.Rows[e.RowIndex].Cells[0].Text.ToString().Trim();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Current.Server.MapPath("../Data/IpList.xml"));
                XmlNode xn = xmlDoc.SelectSingleNode("IpList");
                XmlNodeList xnl = xn.ChildNodes;

                foreach (XmlNode xnf in xnl)
                {
                    XmlElement xe = (XmlElement)xnf;
                    if (strip == xe.InnerText.Trim())
                    {
                        xn.RemoveChild(xe);
                    }
                }

                xmlDoc.Save(HttpContext.Current.Server.MapPath("../Data/IpList.xml"));
                Query();
            }
            catch (Exception ex)
            {
                this.WriteLog(ex.ToString());
                ShowMsg("删除失敗");
            }
        }
        #endregion

        #region 自定义事件
        private void Query()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("../Data/IpList.xml"));
            XmlNode xn = xmlDoc.SelectSingleNode("IpList");
            XmlNodeList xnl = xn.ChildNodes;
            DataTable dt = new DataTable();
            dt.Columns.Add("IP", typeof(string));
            foreach (XmlNode xnf in xnl)
            {
                DataRow dr = dt.NewRow();
                XmlElement xe = (XmlElement)xnf;
                dr["IP"] = xe.InnerText.Trim();
                dt.Rows.Add(dr);
            }

            this.grvip.DataSource = dt;
            this.grvip.DataBind();
        }

        #endregion

        protected void grvip_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ibtnDelete = (ImageButton)e.Row.FindControl("ibtnDelete");
                if (ibtnDelete != null)
                {
                    ibtnDelete.Attributes.Add("onclick", "return funConfirm()");
                }
            }

        }

        
    }
