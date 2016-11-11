#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
#endregion

public partial class re_zdqr : BasePage
{
    #region 全局变数
    ReportDB objReportDB = new ReportDB();

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request["nid"] != null)
        {
            string strnid = this.Request["nid"].ToString();
            KFB_PTZD mo_PTZD = objReportDB.GetModel(strnid);
            string strmes = "";
            if (mo_PTZD.N_QR.ToString().Equals("1"))
            {
                strmes = "PS:確認時間已過，會員下注已經成功！";
            }
            else
            {
                if (this.Request["status"].Equals("0"))
                {
                    //o_PTZD.COZDQR(strnid,"1", "0");
                    if (mo_PTZD != null)//如果注单存在  做删单操作
                    {
                        string strdel = mo_PTZD.N_DEL.ToString();//注单时候删除标识位  0或者“”为未删除   1表示已经删除
                        decimal n_xzje = (decimal)mo_PTZD.N_XZJE;
                        objReportDB.Delete(strnid);
                        //KingOfBall.BLL.KFB_COUNT_BLL count = new KingOfBall.BLL.KFB_COUNT_BLL();
                        //int no = count.GetNo();
                        //count.InsertBillLog(no, mo_PTZD.N_HYDH, mo_PTZD.N_XZDH, mo_PTZD.N_QSBH.Value.ToString(), n_xzje, 0, 0, DateTime.Now, "6");
                        if (!n_xzje.Equals(0) && strdel != "1")//下注金额不等于0并且该注单未被删除，此时需要恢复会员的额度
                        {

                            objReportDB.HuiFuHYYE(mo_PTZD.N_HYDH, n_xzje / 10000);
                        }
                    }
                }
                else
                {
                    objReportDB.ZDQR(strnid, "1");
                }
                // strmes = "操作成功！";
                strmes = "";
            }
            //if (mo_PTZD == null)// && mo_PTZD.N_QR.ToString().Equals("1"))
            //{
            //    strmes = "PS:確認時間已過，該筆注單已被刪除！";
            //}
            //else
            //{
            //    o_PTZD.ZDQR(strnid, "1");
            //}
            this.Response.Write(strmes);
            this.Response.Flush();
            this.Response.End(); ;
        }
        if (this.Request["time"] != null && this.Request["type"] != null)
        {
            string strreturn = "";
            string strtime = this.Request["time"].ToString();
            string strtype = this.Request["type"].ToString();
            if (strtime.Equals(""))
            {
             
                strtime = this.objReportDB.GetSystemTime().ToString("yyyy/MM/dd HH:mm:ss");
            }
            strtype = strtype.Replace("ch", "b_"); 
            string strbslx = "'l_zdrf','l_zddx','l_zddy','l_zdhj','l_zdds','l_zdye'";
            DataSet ds = objReportDB.GetZDQuick(strtime.Replace('-', '/'), strtype, strbslx);
            // DataSet ds = o_PTZD.GetQuick("2008/01/01 12:00:00", strtype);
            XmlDocument CreateXml = new XmlDocument();
            XmlNode xmlNode = CreateXml.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            CreateXml.AppendChild(xmlNode);

            XmlElement xmlRoot = CreateXml.CreateElement("", "ZDTB", "");
            CreateXml.AppendChild(xmlRoot);

            XmlElement xmlTime = CreateXml.CreateElement("", "Time", "");
            //XmlText xmlTimeText = CreateXml.CreateTextNode(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace('-', '/'));
            XmlText xmlTimeText = CreateXml.CreateTextNode(strtime.Replace('-', '/'));
            xmlTime.AppendChild(xmlTimeText);
            CreateXml.ChildNodes[1].AppendChild(xmlTime);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string strn_xzdh = "";
                string strn_xzrq = "";
                string strn_hydh = "";
                string strnr = "";
                string strn_xzwf = "";
                string strn_xzje = "";
                string strlx = "";
                string strnid = "";
                string strwxdj = "";
                string strdbzd = "";
                string strXZNR = "";
                string strQR = "";
                string strdx = "";
                string strdxbl = "";
                string strdxxt = "";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strn_xzdh = ds.Tables[0].Rows[i]["N_XZDH"].ToString();
                    strn_xzrq = DateTime.Parse(ds.Tables[0].Rows[i]["N_XZRQ"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    strn_hydh = ds.Tables[0].Rows[i]["N_HYDH"].ToString();
                    strn_xzje = ds.Tables[0].Rows[i]["N_XZJE"].ToString();
                    strn_xzwf = ds.Tables[0].Rows[i]["N_XZWF"].ToString();
                    strlx = ds.Tables[0].Rows[i]["N_BSLX"].ToString();
                    strnid = ds.Tables[0].Rows[i]["N_ID"].ToString();
                    strwxdj = ds.Tables[0].Rows[i]["N_WXDJ"].ToString();
                    strdbzd = ds.Tables[0].Rows[i]["N_DBZD"].ToString();
                    strXZNR = ds.Tables[0].Rows[i]["XZNR"].ToString();
                    strQR = ds.Tables[0].Rows[i]["N_QR"].ToString();
                    strdx = ds.Tables[0].Rows[i]["N_DX"].ToString();
                    strdxbl = ds.Tables[0].Rows[i]["N_DXBL"].ToString();
                    strdxxt = ds.Tables[0].Rows[i]["N_DXXT"].ToString();

                    XmlElement xmlRow = CreateXml.CreateElement("", "Rows", "");
                    CreateXml.ChildNodes[1].AppendChild(xmlRow);
                    //下注單號
                    XmlElement elemtEQUIP_NAME = CreateXml.CreateElement("", "N_XZDH", "");
                    XmlText EQUIP_NAMEtext = CreateXml.CreateTextNode(strn_xzdh);
                    elemtEQUIP_NAME.AppendChild(EQUIP_NAMEtext);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(elemtEQUIP_NAME);
                    //下注日期
                    XmlElement elemtMapPath = CreateXml.CreateElement("", "N_XZRQ", "");
                    XmlText MapPathtext = CreateXml.CreateTextNode(strn_xzrq);
                    elemtMapPath.AppendChild(MapPathtext);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(elemtMapPath);
                    //會員代號
                    XmlElement elemtPURPOSE = CreateXml.CreateElement("", "N_HYDH", "");
                    XmlText PURPOSEtext = CreateXml.CreateTextNode(strn_hydh);
                    elemtPURPOSE.AppendChild(PURPOSEtext);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(elemtPURPOSE);
                    //下注金額
                    XmlElement eleN_XZJE = CreateXml.CreateElement("", "N_XZJE", "");
                    XmlText N_XZJEText = CreateXml.CreateTextNode(strn_xzje);
                    eleN_XZJE.AppendChild(N_XZJEText);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_XZJE);
                    //下注金額
                    XmlElement eleN_XZWF = CreateXml.CreateElement("", "N_XZWF", "");
                    //XmlText N_XZWFText = CreateXml.CreateTextNode(Comm.ChType(strn_xzwf));
                    XmlText N_XZWFText = CreateXml.CreateTextNode(Comm.GetPlayName(strn_xzwf, "2"));
                    eleN_XZWF.AppendChild(N_XZWFText);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_XZWF);





                    if (!strn_xzwf.Equals("l_gg"))
                    {
                        // strnr = dsnr.Tables[0].Rows[0]["n_xznr"].ToString();
                        strnr = strXZNR.Replace("#", "");
                    }
                    else
                    {
                        strnr = " <table  class='eng_12_bk'> ";
                        string[] strsplit = strXZNR.Split('#');
                        for (int j = 0; j < strsplit.Length - 1; j++)
                        {
                            strnr = strnr + " <tr> <td width='10' bgcolor='#FFFFFF' > " + Convert.ToString(j + 1) + "</td> <td bgcolor='#FFFFFF' >" + strsplit[j].ToString() + " </td> </tr> ";

                        }
                        strnr = strnr + " </table > ";
                    }

                    //下注内容
                    XmlElement eleN_XZNR = CreateXml.CreateElement("", "N_XZNR", "");
                    XmlText N_XZNRText = CreateXml.CreateTextNode(string.Format(strnr, "", ""));
                    eleN_XZNR.AppendChild(N_XZNRText);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_XZNR);

                    //N_ID
                    XmlElement eleN_ID = CreateXml.CreateElement("", "N_ID", "");
                    XmlText N_N_IDText = CreateXml.CreateTextNode(Comm.ChType(strnid));
                    eleN_ID.AppendChild(N_N_IDText);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_ID);

                    //危險等級
                    XmlElement eleN_WXDJ = CreateXml.CreateElement("", "N_WXDJ", "");
                    XmlText N_WXDJText = CreateXml.CreateTextNode(Comm.ChType(strwxdj));
                    eleN_WXDJ.AppendChild(N_WXDJText);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_WXDJ);

                    //大筆注單
                    XmlElement eleN_DBZD = CreateXml.CreateElement("", "N_DBZD", "");
                    XmlText N_DBZDText = CreateXml.CreateTextNode(Comm.ChType(strdbzd));
                    eleN_DBZD.AppendChild(N_DBZDText);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_DBZD);

                    //是否确认
                    XmlElement eleN_QR = CreateXml.CreateElement("", "N_QR", "");
                    XmlText N_QRText = CreateXml.CreateTextNode(Comm.ChType(strdbzd));
                    eleN_QR.AppendChild(N_QRText);
                    CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_QR);

                    //DA xiao qiu tou
                    if ((strn_xzwf.Equals("l_zddx") || strn_xzwf.Equals("l_dx")) && strdx.Equals("0") && strdxbl.Equals("0") && strdxxt.Equals("0"))
                    {
                        XmlElement eleN_DXQT = CreateXml.CreateElement("", "N_DXQT", "");
                        XmlText N_DXQTText = CreateXml.CreateTextNode("1");
                        eleN_DXQT.AppendChild(N_DXQTText);
                        CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_DXQT);
                    }
                    else
                    {
                        XmlElement eleN_DXQT = CreateXml.CreateElement("", "N_DXQT", "");
                        XmlText N_DXQTText = CreateXml.CreateTextNode("0");
                        eleN_DXQT.AppendChild(N_DXQTText);
                        CreateXml.ChildNodes[1].ChildNodes[i + 1].AppendChild(eleN_DXQT);
                    }

                }
            }
            strreturn = CreateXml.InnerXml.ToString();
            this.Response.Write(strreturn);
            this.Response.Flush();
            this.Response.End(); ;
        }
      
    }

  
    #endregion

    #region 按钮事件
 
    #endregion

    #region gridview事件
   
    #endregion

    #region 自定义事件
   
    #endregion 
}
