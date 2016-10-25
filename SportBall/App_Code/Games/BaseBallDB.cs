using CommLib;
using KingOfBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


public class BaseBallDB
{
    /// <summary>
    /// 計算時查詢的值
    /// </summary>
    /// <param name="s_aN_ID"></param>
    /// <returns></returns>
    public DataSet GetRusult(string s_aN_ID)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select t.n_gamedate,n_home_result,n_visit_result,n_up_visit_result,n_up_home_result,n_sf9j,n_remark,n_counttime,");
        strSql.Append(" (case t.n_vh when t.n_visit then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit) end");
        strSql.Append(" ||' VS '||");
        strSql.Append(" case t.n_vh when t.n_home then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home) end ) as dw ,");
        strSql.Append(" case t.n_cbxh when 1 then '全场' when 2 then '上半场' when 4 then '下半场' end as CB,");
        strSql.Append(" (select l.n_lmmc from kfb_lmgl l where l.n_no = t.n_lmno) as lm,N_VISIT_NO");
        strSql.Append(" FROM KFB_BASEBALL t where t.n_id=" + s_aN_ID);
        strSql.Append(" UNION select t.n_gamedate,n_home_result,n_visit_result,n_up_visit_result,n_up_home_result,n_sf9j,n_remark,n_counttime,");
        strSql.Append(" (case t.n_vh when t.n_visit then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit) end");
        strSql.Append(" ||' VS '||");
        strSql.Append(" case t.n_vh when t.n_home then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home) end ) as dw ,");
        strSql.Append(" case t.n_cbxh when 1 then '全场' when 2 then '上半场' when 4 then '下半场' end as CB,");
        strSql.Append(" (select l.n_lmmc from kfb_lmgl l where l.n_no = t.n_lmno) as lm,N_VISIT_NO");
        strSql.Append(" FROM KFB_ACCBALL t where t.n_id=" + s_aN_ID);
        return DbHelperOra.Query(strSql.ToString());
    }
    /// <summary>
    /// 得到賽事隊伍
    /// </summary>
    /// <param name="s_N_ID"></param>
    /// <returns></returns>
    public string GetDW(string s_N_ID)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select ");
        strSql.Append(" (select d.n_dwmc from kfb_dwgl d where d.n_id = b.n_visit)||case b.n_vh when b.n_visit then '[主]' else '' end");
        strSql.Append(" ||'   '||");
        strSql.Append(" (select d.n_dwmc from kfb_dwgl d where d.n_id = b.n_home)||case b.n_vh when b.n_home then '[主]' else '' end");
        strSql.Append(" from kfb_baseball b where b.n_id=" + s_N_ID);
        return Convert.ToString(DbHelperOra.GetSingle(strSql.ToString()));
    }
    public string GetHyName(string strid)
    {
        string strname = "";
        StringBuilder strSqlup = new StringBuilder();
        strSqlup.Append(" select N_HYMC from kfb_zhgl where n_hyzh=:n_hyzh UNION select N_HYMC from kfb_hygl where n_hyzh=:n_hyzh ");

        OracleParameter[] parameters = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100)                            
            };
        parameters[0].Value = strid;

        //KFB_ZHGL model = new KFB_ZHGL();
        DataSet ds = DbHelperOra.Query(strSqlup.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            strname = ds.Tables[0].Rows[0][0].ToString();
        }
        return strname;
    }
    /// <summary>
    /// 刪除注單(原因)
    /// </summary>
    /// <param name="s_BillID"></param>
    /// <param name="s_Del"></param>
    public int DeleteBill(string s_BillID, int s_Del, string s_DelYY, string s_XGJL)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_PTZD set");
        strSql.Append(" N_DEL=:N_DEL,");
        strSql.Append(" N_DELYY=:N_DELYY,");
        strSql.Append(" N_XGJL=:N_XGJL");
        strSql.Append(" WHERE N_XZDH=:N_XZDH");
        OracleParameter[] parameters = {
					new OracleParameter(":N_DEL", OracleType.Number,1),
                    new OracleParameter(":N_DELYY", OracleType.VarChar,100),
                    new OracleParameter(":N_XGJL", OracleType.VarChar,100),
					new OracleParameter(":N_XZDH", OracleType.VarChar,50)};
        parameters[0].Value = s_Del;
        parameters[1].Value = s_DelYY;
        parameters[2].Value = s_XGJL;
        parameters[3].Value = s_BillID;

        return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 刪除注單(已過帳)(原因)
    /// </summary>
    /// <param name="s_BillID"></param>
    /// <param name="s_Del"></param>
    public int DeleteBillHis(string s_BillID, int s_Del, string s_DelYY, string s_XGJL)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_OPTZD set");
        strSql.Append(" N_DEL=:N_DEL,");
        strSql.Append(" N_DELYY=:N_DELYY,");
        strSql.Append(" N_XGJL=:N_XGJL");
        strSql.Append(" WHERE N_XZDH=:N_XZDH");
        OracleParameter[] parameters = {
					new OracleParameter(":N_DEL", OracleType.Number,1),
                    new OracleParameter(":N_DELYY", OracleType.VarChar,100),
                    new OracleParameter(":N_XGJL", OracleType.VarChar,100),
					new OracleParameter(":N_XZDH", OracleType.VarChar,50)};
        parameters[0].Value = s_Del;
        parameters[1].Value = s_DelYY;
        parameters[2].Value = s_XGJL;
        parameters[3].Value = s_BillID;

        return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_BASEBALL GetModel(int N_ID)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from KFB_BASEBALL ");
        strSql.Append(" where N_ID=:N_ID ");
        strSql.Append(" union ");
        strSql.Append(" select * from KFB_ACCBALL ");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4)};
        parameters[0].Value = N_ID;

        KFB_BASEBALL model = new KFB_BASEBALL();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["N_ID"].ToString() != "")
            {
                model.N_ID = int.Parse(ds.Tables[0].Rows[0]["N_ID"].ToString());
            }
            model.N_LX = ds.Tables[0].Rows[0]["N_LX"].ToString();
            if (ds.Tables[0].Rows[0]["N_ZWDATE"].ToString() != "")
            {
                model.N_ZWDATE = DateTime.Parse(ds.Tables[0].Rows[0]["N_ZWDATE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GAMEDATE"].ToString() != "")
            {
                model.N_GAMEDATE = DateTime.Parse(ds.Tables[0].Rows[0]["N_GAMEDATE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LMNO"].ToString() != "")
            {
                model.N_LMNO = int.Parse(ds.Tables[0].Rows[0]["N_LMNO"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_VISIT"].ToString() != "")
            {
                model.N_VISIT = int.Parse(ds.Tables[0].Rows[0]["N_VISIT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HOME"].ToString() != "")
            {
                model.N_HOME = int.Parse(ds.Tables[0].Rows[0]["N_HOME"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_VISIT_RESULT"].ToString() != "")
            {
                model.N_VISIT_RESULT = decimal.Parse(ds.Tables[0].Rows[0]["N_VISIT_RESULT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HOME_RESULT"].ToString() != "")
            {
                model.N_HOME_RESULT = decimal.Parse(ds.Tables[0].Rows[0]["N_HOME_RESULT"].ToString());
            }
            model.N_TSA = ds.Tables[0].Rows[0]["N_TSA"].ToString();
            model.N_TSB = ds.Tables[0].Rows[0]["N_TSB"].ToString();
            if (ds.Tables[0].Rows[0]["N_VISIT_NO"].ToString() != "")
            {
                model.N_VISIT_NO = int.Parse(ds.Tables[0].Rows[0]["N_VISIT_NO"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HOME_NO"].ToString() != "")
            {
                model.N_HOME_NO = int.Parse(ds.Tables[0].Rows[0]["N_HOME_NO"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SFZD"].ToString() != "")
            {
                model.N_SFZD = int.Parse(ds.Tables[0].Rows[0]["N_SFZD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SFXZ"].ToString() != "")
            {
                model.N_SFXZ = int.Parse(ds.Tables[0].Rows[0]["N_SFXZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_XZZT"].ToString() != "")
            {
                model.N_XZZT = int.Parse(ds.Tables[0].Rows[0]["N_XZZT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LET"].ToString() != "")
            {
                model.N_LET = int.Parse(ds.Tables[0].Rows[0]["N_LET"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LOCK"].ToString() != "")
            {
                model.N_LOCK = int.Parse(ds.Tables[0].Rows[0]["N_LOCK"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_VH"].ToString() != "")
            {
                model.N_VH = int.Parse(ds.Tables[0].Rows[0]["N_VH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SF9J"].ToString() != "")
            {
                model.N_SF9J = int.Parse(ds.Tables[0].Rows[0]["N_SF9J"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SFDS"].ToString() != "")
            {
                model.N_SFDS = int.Parse(ds.Tables[0].Rows[0]["N_SFDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SFGP"].ToString() != "")
            {
                model.N_SFGP = int.Parse(ds.Tables[0].Rows[0]["N_SFGP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HYDZSX"].ToString() != "")
            {
                model.N_HYDZSX = decimal.Parse(ds.Tables[0].Rows[0]["N_HYDZSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HYDCSX"].ToString() != "")
            {
                model.N_HYDCSX = decimal.Parse(ds.Tables[0].Rows[0]["N_HYDCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SFJZF"].ToString() != "")
            {
                model.N_SFJZF = int.Parse(ds.Tables[0].Rows[0]["N_SFJZF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZBXH"].ToString() != "")
            {
                model.N_ZBXH = int.Parse(ds.Tables[0].Rows[0]["N_ZBXH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBXH"].ToString() != "")
            {
                model.N_CBXH = int.Parse(ds.Tables[0].Rows[0]["N_CBXH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFFS"].ToString() != "")
            {
                model.N_RFFS = decimal.Parse(ds.Tables[0].Rows[0]["N_RFFS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFLX"].ToString() != "")
            {
                model.N_RFLX = int.Parse(ds.Tables[0].Rows[0]["N_RFLX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFBL"].ToString() != "")
            {
                model.N_RFBL = int.Parse(ds.Tables[0].Rows[0]["N_RFBL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LRFPL"].ToString() != "")
            {
                model.N_LRFPL = decimal.Parse(ds.Tables[0].Rows[0]["N_LRFPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RRFPL"].ToString() != "")
            {
                model.N_RRFPL = decimal.Parse(ds.Tables[0].Rows[0]["N_RRFPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LRFCJ"].ToString() != "")
            {
                model.N_LRFCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_LRFCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RRFCJ"].ToString() != "")
            {
                model.N_RRFCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_RRFCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LRFSX"].ToString() != "")
            {
                model.N_LRFSX = decimal.Parse(ds.Tables[0].Rows[0]["N_LRFSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RRFSX"].ToString() != "")
            {
                model.N_RRFSX = decimal.Parse(ds.Tables[0].Rows[0]["N_RRFSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFCJJE"].ToString() != "")
            {
                model.N_RFCJJE = decimal.Parse(ds.Tables[0].Rows[0]["N_RFCJJE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFCJFS"].ToString() != "")
            {
                model.N_RFCJFS = int.Parse(ds.Tables[0].Rows[0]["N_RFCJFS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFCJPL"].ToString() != "")
            {
                model.N_RFCJPL = decimal.Parse(ds.Tables[0].Rows[0]["N_RFCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXFS"].ToString() != "")
            {
                model.N_DXFS = decimal.Parse(ds.Tables[0].Rows[0]["N_DXFS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXLX"].ToString() != "")
            {
                model.N_DXLX = int.Parse(ds.Tables[0].Rows[0]["N_DXLX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXBL"].ToString() != "")
            {
                model.N_DXBL = int.Parse(ds.Tables[0].Rows[0]["N_DXBL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDPL"].ToString() != "")
            {
                model.N_DXDPL = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXXPL"].ToString() != "")
            {
                model.N_DXXPL = decimal.Parse(ds.Tables[0].Rows[0]["N_DXXPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDCJ"].ToString() != "")
            {
                model.N_DXDCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXXCJ"].ToString() != "")
            {
                model.N_DXXCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXXCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDCSX"].ToString() != "")
            {
                model.N_DXDCSX = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDXSX"].ToString() != "")
            {
                model.N_LDXSX = decimal.Parse(ds.Tables[0].Rows[0]["N_LDXSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDXSX"].ToString() != "")
            {
                model.N_RDXSX = decimal.Parse(ds.Tables[0].Rows[0]["N_RDXSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXCJ"].ToString() != "")
            {
                model.N_DXCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXCJPL"].ToString() != "")
            {
                model.N_DXCJPL = decimal.Parse(ds.Tables[0].Rows[0]["N_DXCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDYPL"].ToString() != "")
            {
                model.N_LDYPL = decimal.Parse(ds.Tables[0].Rows[0]["N_LDYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDYPL"].ToString() != "")
            {
                model.N_RDYPL = decimal.Parse(ds.Tables[0].Rows[0]["N_RDYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDYCJ"].ToString() != "")
            {
                model.N_LDYCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_LDYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDYCJ"].ToString() != "")
            {
                model.N_RDYCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_RDYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDYSX"].ToString() != "")
            {
                model.N_LDYSX = decimal.Parse(ds.Tables[0].Rows[0]["N_LDYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDYSX"].ToString() != "")
            {
                model.N_RDYSX = decimal.Parse(ds.Tables[0].Rows[0]["N_RDYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYCJ"].ToString() != "")
            {
                model.N_DYCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYCJPL"].ToString() != "")
            {
                model.N_DYCJPL = decimal.Parse(ds.Tables[0].Rows[0]["N_DYCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LSYPL"].ToString() != "")
            {
                model.N_LSYPL = decimal.Parse(ds.Tables[0].Rows[0]["N_LSYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RSYPL"].ToString() != "")
            {
                model.N_RSYPL = decimal.Parse(ds.Tables[0].Rows[0]["N_RSYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LSYCJ"].ToString() != "")
            {
                model.N_LSYCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_LSYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RSYCJ"].ToString() != "")
            {
                model.N_RSYCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_RSYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LSYSX"].ToString() != "")
            {
                model.N_LSYSX = decimal.Parse(ds.Tables[0].Rows[0]["N_LSYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RSYSX"].ToString() != "")
            {
                model.N_RSYSX = decimal.Parse(ds.Tables[0].Rows[0]["N_RSYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYCJ"].ToString() != "")
            {
                model.N_SYCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYCJPL"].ToString() != "")
            {
                model.N_SYCJPL = decimal.Parse(ds.Tables[0].Rows[0]["N_SYCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDPL"].ToString() != "")
            {
                model.N_DSDPL = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSSPL"].ToString() != "")
            {
                model.N_DSSPL = decimal.Parse(ds.Tables[0].Rows[0]["N_DSSPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDCJ"].ToString() != "")
            {
                model.N_DSDCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSSCJ"].ToString() != "")
            {
                model.N_DSSCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSSCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDCSX"].ToString() != "")
            {
                model.N_DSDCSX = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDSSX"].ToString() != "")
            {
                model.N_LDSSX = decimal.Parse(ds.Tables[0].Rows[0]["N_LDSSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDSSX"].ToString() != "")
            {
                model.N_RDSSX = decimal.Parse(ds.Tables[0].Rows[0]["N_RDSSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSCJ"].ToString() != "")
            {
                model.N_DSCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSCJPL"].ToString() != "")
            {
                model.N_DSCJPL = decimal.Parse(ds.Tables[0].Rows[0]["N_DSCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_UP_VISIT_RESULT"].ToString() != "")
            {
                model.N_UP_VISIT_RESULT = decimal.Parse(ds.Tables[0].Rows[0]["N_UP_VISIT_RESULT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_UP_HOME_RESULT"].ToString() != "")
            {
                model.N_UP_HOME_RESULT = decimal.Parse(ds.Tables[0].Rows[0]["N_UP_HOME_RESULT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_VISIT_JZF"].ToString() != "")
            {
                model.N_VISIT_JZF = decimal.Parse(ds.Tables[0].Rows[0]["N_VISIT_JZF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HOME_JZF"].ToString() != "")
            {
                model.N_HOME_JZF = decimal.Parse(ds.Tables[0].Rows[0]["N_HOME_JZF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RF_OPEN"].ToString() != "")
            {
                model.N_RF_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_RF_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DX_OPEN"].ToString() != "")
            {
                model.N_DX_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_DX_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DY_OPEN"].ToString() != "")
            {
                model.N_DY_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_DY_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SY_OPEN"].ToString() != "")
            {
                model.N_SY_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_SY_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DS_OPEN"].ToString() != "")
            {
                model.N_DS_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_DS_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQ_OPEN"].ToString() != "")
            {
                model.N_RQ_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_RQ_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BD_OPEN"].ToString() != "")
            {
                model.N_BD_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_BD_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQC_OPEN"].ToString() != "")
            {
                model.N_BQC_OPEN = int.Parse(ds.Tables[0].Rows[0]["N_BQC_OPEN"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RF_GG"].ToString() != "")
            {
                model.N_RF_GG = int.Parse(ds.Tables[0].Rows[0]["N_RF_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DX_GG"].ToString() != "")
            {
                model.N_DX_GG = int.Parse(ds.Tables[0].Rows[0]["N_DX_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DY_GG"].ToString() != "")
            {
                model.N_DY_GG = int.Parse(ds.Tables[0].Rows[0]["N_DY_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SY_GG"].ToString() != "")
            {
                model.N_SY_GG = int.Parse(ds.Tables[0].Rows[0]["N_SY_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DS_GG"].ToString() != "")
            {
                model.N_DS_GG = int.Parse(ds.Tables[0].Rows[0]["N_DS_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RF_LOCK_V"].ToString() != "")
            {
                model.N_RF_LOCK_V = int.Parse(ds.Tables[0].Rows[0]["N_RF_LOCK_V"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RF_LOCK_H"].ToString() != "")
            {
                model.N_RF_LOCK_H = int.Parse(ds.Tables[0].Rows[0]["N_RF_LOCK_H"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DX_LOCK_V"].ToString() != "")
            {
                model.N_DX_LOCK_V = int.Parse(ds.Tables[0].Rows[0]["N_DX_LOCK_V"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DX_LOCK_H"].ToString() != "")
            {
                model.N_DX_LOCK_H = int.Parse(ds.Tables[0].Rows[0]["N_DX_LOCK_H"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DY_LOCK_V"].ToString() != "")
            {
                model.N_DY_LOCK_V = int.Parse(ds.Tables[0].Rows[0]["N_DY_LOCK_V"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DY_LOCK_H"].ToString() != "")
            {
                model.N_DY_LOCK_H = int.Parse(ds.Tables[0].Rows[0]["N_DY_LOCK_H"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SY_LOCK_V"].ToString() != "")
            {
                model.N_SY_LOCK_V = int.Parse(ds.Tables[0].Rows[0]["N_SY_LOCK_V"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SY_LOCK_H"].ToString() != "")
            {
                model.N_SY_LOCK_H = int.Parse(ds.Tables[0].Rows[0]["N_SY_LOCK_H"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DS_LOCK_V"].ToString() != "")
            {
                model.N_DS_LOCK_V = int.Parse(ds.Tables[0].Rows[0]["N_DS_LOCK_V"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DS_LOCK_H"].ToString() != "")
            {
                model.N_DS_LOCK_H = int.Parse(ds.Tables[0].Rows[0]["N_DS_LOCK_H"].ToString());
            }
            model.N_REMARK = ds.Tables[0].Rows[0]["N_REMARK"].ToString();
            if (ds.Tables[0].Rows[0]["N_COUNTTIME"].ToString() != "")
            {
                model.N_COUNTTIME = DateTime.Parse(ds.Tables[0].Rows[0]["N_COUNTTIME"].ToString());
            }
            model.N_SAMETEAM = ds.Tables[0].Rows[0]["N_SAMETEAM"].ToString();
            if (ds.Tables[0].Rows[0]["N_RQSPL01"].ToString() != "")
            {
                model.N_RQSPL01 = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSPL01"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSPL23"].ToString() != "")
            {
                model.N_RQSPL23 = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSPL23"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSPL46"].ToString() != "")
            {
                model.N_RQSPL46 = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSPL46"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSPL7"].ToString() != "")
            {
                model.N_RQSPL7 = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSPL7"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSSX"].ToString() != "")
            {
                model.N_RQSSX = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL00"].ToString() != "")
            {
                model.N_BDGPL00 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDGPL00"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL10"].ToString() != "")
            {
                model.N_BDZPL10 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL10"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL11"].ToString() != "")
            {
                model.N_BDGPL11 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDGPL11"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL20"].ToString() != "")
            {
                model.N_BDZPL20 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL20"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL21"].ToString() != "")
            {
                model.N_BDZPL21 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL21"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL22"].ToString() != "")
            {
                model.N_BDGPL22 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDGPL22"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL30"].ToString() != "")
            {
                model.N_BDZPL30 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL30"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL31"].ToString() != "")
            {
                model.N_BDZPL31 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL31"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL32"].ToString() != "")
            {
                model.N_BDZPL32 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL32"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL33"].ToString() != "")
            {
                model.N_BDGPL33 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDGPL33"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL41"].ToString() != "")
            {
                model.N_BDZPL41 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL41"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL40"].ToString() != "")
            {
                model.N_BDZPL40 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL40"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL42"].ToString() != "")
            {
                model.N_BDZPL42 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL42"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL43"].ToString() != "")
            {
                model.N_BDZPL43 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL43"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL10"].ToString() != "")
            {
                model.N_BDKPL10 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL10"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL20"].ToString() != "")
            {
                model.N_BDKPL20 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL20"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL21"].ToString() != "")
            {
                model.N_BDKPL21 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL21"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL30"].ToString() != "")
            {
                model.N_BDKPL30 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL30"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL31"].ToString() != "")
            {
                model.N_BDKPL31 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL31"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL32"].ToString() != "")
            {
                model.N_BDKPL32 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL32"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL40"].ToString() != "")
            {
                model.N_BDKPL40 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL40"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL41"].ToString() != "")
            {
                model.N_BDKPL41 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL41"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL42"].ToString() != "")
            {
                model.N_BDKPL42 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL42"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL43"].ToString() != "")
            {
                model.N_BDKPL43 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL43"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL44"].ToString() != "")
            {
                model.N_BDGPL44 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDGPL44"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL5"].ToString() != "")
            {
                model.N_BDZPL5 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDZPL5"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL5"].ToString() != "")
            {
                model.N_BDKPL5 = decimal.Parse(ds.Tables[0].Rows[0]["N_BDKPL5"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDSX"].ToString() != "")
            {
                model.N_BDSX = decimal.Parse(ds.Tables[0].Rows[0]["N_BDSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCZZ"].ToString() != "")
            {
                model.N_BQCZZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCZZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCZH"].ToString() != "")
            {
                model.N_BQCZH = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCZH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCZK"].ToString() != "")
            {
                model.N_BQCZK = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCZK"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCHH"].ToString() != "")
            {
                model.N_BQCHH = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCHH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCHZ"].ToString() != "")
            {
                model.N_BQCHZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCHZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCHK"].ToString() != "")
            {
                model.N_BQCHK = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCHK"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCKK"].ToString() != "")
            {
                model.N_BQCKK = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCKK"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCKZ"].ToString() != "")
            {
                model.N_BQCKZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCKZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCKH"].ToString() != "")
            {
                model.N_BQCKH = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCKH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCSX"].ToString() != "")
            {
                model.N_BQCSX = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HJPL"].ToString() != "")
            {
                model.N_HJPL = decimal.Parse(ds.Tables[0].Rows[0]["N_HJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HJGGCJ"].ToString() != "")
            {
                model.N_HJGGCJ = decimal.Parse(ds.Tables[0].Rows[0]["N_HJGGCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HJSX"].ToString() != "")
            {
                model.N_HJSX = decimal.Parse(ds.Tables[0].Rows[0]["N_HJSX"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到隊伍名稱
    /// </summary>
    /// <param name="i_aXH"></param>
    /// <returns></returns>
    public string GetBallName(int i_aXH)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select n_dwmc");
        strSql.Append(" FROM kfb_dwgl where n_id = " + i_aXH);
        return Convert.ToString(DbHelperOra.GetSingle(strSql.ToString()));
    }

    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZS(KFB_BASEBALL model, Hashtable o_aHt)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BASEBALL set ");
        strSql.Append("N_LX=:N_LX,");
        strSql.Append("N_ZWDATE=:N_ZWDATE,");
        strSql.Append("N_GAMEDATE=:N_GAMEDATE,");
        strSql.Append("N_LMNO=:N_LMNO,");
        strSql.Append("N_VISIT=:N_VISIT,");
        strSql.Append("N_VISIT_RESULT=:N_VISIT_RESULT,");
        strSql.Append("N_VISIT_NO=:N_VISIT_NO,");
        strSql.Append("N_LOCK=:N_LOCK,");
        strSql.Append("N_SFDS=:N_SFDS,");
        strSql.Append("N_HYDZSX=:N_HYDZSX,");
        strSql.Append("N_HYDCSX=:N_HYDCSX,");
        strSql.Append("N_ZBXH=:N_ZBXH,");
        strSql.Append("N_CBXH=:N_CBXH,");
        strSql.Append("N_DXFS=:N_DXFS,");
        strSql.Append("N_DXLX=:N_DXLX,");
        strSql.Append("N_DXBL=:N_DXBL,");
        strSql.Append("N_DXDPL=:N_DXDPL,");
        strSql.Append("N_DXXPL=:N_DXXPL,");
        strSql.Append("N_DXDCJ=:N_DXDCJ,");
        strSql.Append("N_DXXCJ=:N_DXXCJ,");
        strSql.Append("N_DXDCSX=:N_DXDCSX,");
        strSql.Append("N_DXCJ=:N_DXCJ,");
        strSql.Append("N_DXCJPL=:N_DXCJPL,");
        strSql.Append("N_DSDPL=:N_DSDPL,");
        strSql.Append("N_DSSPL=:N_DSSPL,");
        strSql.Append("N_DSDCJ=:N_DSDCJ,");
        strSql.Append("N_DSSCJ=:N_DSSCJ,");
        strSql.Append("N_DSDCSX=:N_DSDCSX,");
        strSql.Append("N_DSCJ=:N_DSCJ,");
        strSql.Append("N_DSCJPL=:N_DSCJPL,");
        strSql.Append("N_DX_OPEN=:N_DX_OPEN,");
        strSql.Append("N_DS_OPEN=:N_DS_OPEN,");
        strSql.Append("N_DX_LOCK_V=:N_DX_LOCK_V,");
        strSql.Append("N_DX_LOCK_H=:N_DX_LOCK_H,");
        strSql.Append("N_DS_LOCK_V=:N_DS_LOCK_V,");
        strSql.Append("N_DS_LOCK_H=:N_DS_LOCK_H,");
        strSql.Append("N_BDSX=:N_BDSX,");
        strSql.Append("N_BQCZZ=:N_BQCZZ,");
        strSql.Append("N_BQCZH=:N_BQCZH,");
        strSql.Append("N_BQCZK=:N_BQCZK,");
        strSql.Append("N_BQCHH=:N_BQCHH,");
        strSql.Append("N_BQCHZ=:N_BQCHZ,");
        strSql.Append("N_BQCHK=:N_BQCHK,");
        strSql.Append("N_BQCKK=:N_BQCKK,");
        strSql.Append("N_BQCKZ=:N_BQCKZ,");
        strSql.Append("N_BQCKH=:N_BQCKH,");
        strSql.Append("N_BQCSX=:N_BQCSX,");
        strSql.Append("N_BD_OPEN=:N_BD_OPEN,");
        strSql.Append("N_XZZT=:N_XZZT,");
        strSql.Append("N_SFXZ=:N_SFXZ,");
        strSql.Append("N_REMARK=:N_REMARK");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4),
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_ZWDATE", OracleType.DateTime),
					new OracleParameter(":N_GAMEDATE", OracleType.DateTime),
					new OracleParameter(":N_LMNO", OracleType.Number,4),
					new OracleParameter(":N_VISIT", OracleType.Number,4),
					new OracleParameter(":N_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_VISIT_NO", OracleType.Number,4),
					new OracleParameter(":N_LOCK", OracleType.Number,4),
					new OracleParameter(":N_SFDS", OracleType.Number,4),
					new OracleParameter(":N_HYDZSX", OracleType.Number,4),
					new OracleParameter(":N_HYDCSX", OracleType.Number,4),
					new OracleParameter(":N_ZBXH", OracleType.Number,4),
					new OracleParameter(":N_CBXH", OracleType.Number,4),
					new OracleParameter(":N_DXFS", OracleType.Number,4),
					new OracleParameter(":N_DXLX", OracleType.Number,4),
					new OracleParameter(":N_DXBL", OracleType.Number,4),
					new OracleParameter(":N_DXDPL", OracleType.Number,4),
					new OracleParameter(":N_DXXPL", OracleType.Number,4),
					new OracleParameter(":N_DXDCJ", OracleType.Number,4),
					new OracleParameter(":N_DXXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXDCSX", OracleType.Number,4),
					new OracleParameter(":N_DXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXCJPL", OracleType.Number,4),
					new OracleParameter(":N_DSDPL", OracleType.Number,4),
					new OracleParameter(":N_DSSPL", OracleType.Number,4),
					new OracleParameter(":N_DSDCJ", OracleType.Number,4),
					new OracleParameter(":N_DSSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSDCSX", OracleType.Number,4),
					new OracleParameter(":N_DSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSCJPL", OracleType.Number,4),
					new OracleParameter(":N_DX_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DS_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_BDSX", OracleType.Number,4),
					new OracleParameter(":N_BQCZZ", OracleType.Number,4),
					new OracleParameter(":N_BQCZH", OracleType.Number,4),
					new OracleParameter(":N_BQCZK", OracleType.Number,4),
					new OracleParameter(":N_BQCHH", OracleType.Number,4),
					new OracleParameter(":N_BQCHZ", OracleType.Number,4),
					new OracleParameter(":N_BQCHK", OracleType.Number,4),
					new OracleParameter(":N_BQCKK", OracleType.Number,4),
					new OracleParameter(":N_BQCKZ", OracleType.Number,4),
					new OracleParameter(":N_BQCKH", OracleType.Number,4),
					new OracleParameter(":N_BQCSX", OracleType.Number,4),
					new OracleParameter(":N_BD_OPEN", OracleType.Number,4),
					new OracleParameter(":N_XZZT", OracleType.Number,4),
					new OracleParameter(":N_SFXZ", OracleType.Number,4),
					new OracleParameter(":N_REMARK", OracleType.VarChar,100)};
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_LX;
        parameters[2].Value = model.N_ZWDATE;
        parameters[3].Value = model.N_GAMEDATE;
        parameters[4].Value = model.N_LMNO;
        parameters[5].Value = model.N_VISIT;
        parameters[6].Value = model.N_VISIT_RESULT;
        parameters[7].Value = model.N_VISIT_NO;
        parameters[8].Value = model.N_LOCK;
        parameters[9].Value = model.N_SFDS;
        parameters[10].Value = model.N_HYDZSX;
        parameters[11].Value = model.N_HYDCSX;
        parameters[12].Value = model.N_ZBXH;
        parameters[13].Value = model.N_CBXH;
        parameters[14].Value = model.N_DXFS;
        parameters[15].Value = model.N_DXLX;
        parameters[16].Value = model.N_DXBL;
        parameters[17].Value = model.N_DXDPL;
        parameters[18].Value = model.N_DXXPL;
        parameters[19].Value = model.N_DXDCJ;
        parameters[20].Value = model.N_DXXCJ;
        parameters[21].Value = model.N_DXDCSX;
        parameters[22].Value = model.N_DXCJ;
        parameters[23].Value = model.N_DXCJPL;
        parameters[24].Value = model.N_DSDPL;
        parameters[25].Value = model.N_DSSPL;
        parameters[26].Value = model.N_DSDCJ;
        parameters[27].Value = model.N_DSSCJ;
        parameters[28].Value = model.N_DSDCSX;
        parameters[29].Value = model.N_DSCJ;
        parameters[30].Value = model.N_DSCJPL;
        parameters[31].Value = model.N_DX_OPEN;
        parameters[32].Value = model.N_DS_OPEN;
        parameters[33].Value = model.N_DX_LOCK_V;
        parameters[34].Value = model.N_DX_LOCK_H;
        parameters[35].Value = model.N_DS_LOCK_V;
        parameters[36].Value = model.N_DS_LOCK_H;
        parameters[37].Value = model.N_BDSX;
        parameters[38].Value = model.N_BQCZZ;
        parameters[39].Value = model.N_BQCZH;
        parameters[40].Value = model.N_BQCZK;
        parameters[41].Value = model.N_BQCHH;
        parameters[42].Value = model.N_BQCHZ;
        parameters[43].Value = model.N_BQCHK;
        parameters[44].Value = model.N_BQCKK;
        parameters[45].Value = model.N_BQCKZ;
        parameters[46].Value = model.N_BQCKH;
        parameters[47].Value = model.N_BQCSX;
        parameters[48].Value = model.N_BD_OPEN;
        parameters[49].Value = model.N_XZZT;
        parameters[50].Value = model.N_SFXZ;
        parameters[51].Value = model.N_REMARK;

        o_aHt.Add(strSql, parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZQ(KFB_BASEBALL model, Hashtable o_aHt)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BASEBALL set ");
        strSql.Append("N_ID=:N_ID,");
        strSql.Append("N_LX=:N_LX,");
        strSql.Append("N_ZWDATE=:N_ZWDATE,");
        strSql.Append("N_GAMEDATE=:N_GAMEDATE,");
        strSql.Append("N_LMNO=:N_LMNO,");
        strSql.Append("N_VISIT=:N_VISIT,");
        strSql.Append("N_HOME=:N_HOME,");
        strSql.Append("N_VISIT_RESULT=:N_VISIT_RESULT,");
        strSql.Append("N_HOME_RESULT=:N_HOME_RESULT,");
        strSql.Append("N_TSA=:N_TSA,");
        strSql.Append("N_TSB=:N_TSB,");
        strSql.Append("N_VISIT_NO=:N_VISIT_NO,");
        strSql.Append("N_HOME_NO=:N_HOME_NO,");
        strSql.Append("N_SFZD=:N_SFZD,");
        strSql.Append("N_SFXZ=:N_SFXZ,");
        strSql.Append("N_XZZT=:N_XZZT,");
        strSql.Append("N_VH=:N_VH,");
        strSql.Append("N_LOCK=:N_LOCK,");
        strSql.Append("N_SF9J=:N_SF9J,");
        strSql.Append("N_SFDS=:N_SFDS,");
        strSql.Append("N_SFGP=:N_SFGP,");
        strSql.Append("N_HYDZSX=:N_HYDZSX,");
        strSql.Append("N_HYDCSX=:N_HYDCSX,");
        strSql.Append("N_SFJZF=:N_SFJZF,");
        strSql.Append("N_ZBXH=:N_ZBXH,");
        strSql.Append("N_CBXH=:N_CBXH,");
        strSql.Append("N_RFFS=:N_RFFS,");
        strSql.Append("N_RFLX=:N_RFLX,");
        strSql.Append("N_RFBL=:N_RFBL,");
        strSql.Append("N_LRFPL=:N_LRFPL,");
        strSql.Append("N_RRFPL=:N_RRFPL,");
        strSql.Append("N_LRFCJ=:N_LRFCJ,");
        strSql.Append("N_RRFCJ=:N_RRFCJ,");
        strSql.Append("N_LRFSX=:N_LRFSX,");
        strSql.Append("N_RRFSX=:N_RRFSX,");
        strSql.Append("N_RFCJJE=:N_RFCJJE,");
        strSql.Append("N_RFCJFS=:N_RFCJFS,");
        strSql.Append("N_RFCJPL=:N_RFCJPL,");
        strSql.Append("N_DXFS=:N_DXFS,");
        strSql.Append("N_DXLX=:N_DXLX,");
        strSql.Append("N_DXBL=:N_DXBL,");
        strSql.Append("N_DXDPL=:N_DXDPL,");
        strSql.Append("N_DXXPL=:N_DXXPL,");
        strSql.Append("N_DXDCJ=:N_DXDCJ,");
        strSql.Append("N_DXXCJ=:N_DXXCJ,");
        strSql.Append("N_DXDCSX=:N_DXDCSX,");
        strSql.Append("N_DXCJ=:N_DXCJ,");
        strSql.Append("N_DXCJPL=:N_DXCJPL,");
        strSql.Append("N_LDYPL=:N_LDYPL,");
        strSql.Append("N_RDYPL=:N_RDYPL,");
        strSql.Append("N_LDYCJ=:N_LDYCJ,");
        strSql.Append("N_RDYCJ=:N_RDYCJ,");
        strSql.Append("N_LDYSX=:N_LDYSX,");
        strSql.Append("N_RDYSX=:N_RDYSX,");
        strSql.Append("N_DYCJ=:N_DYCJ,");
        strSql.Append("N_DYCJPL=:N_DYCJPL,");
        strSql.Append("N_LSYPL=:N_LSYPL,");
        strSql.Append("N_RSYPL=:N_RSYPL,");
        strSql.Append("N_LSYCJ=:N_LSYCJ,");
        strSql.Append("N_RSYCJ=:N_RSYCJ,");
        strSql.Append("N_LSYSX=:N_LSYSX,");
        strSql.Append("N_RSYSX=:N_RSYSX,");
        strSql.Append("N_SYCJ=:N_SYCJ,");
        strSql.Append("N_SYCJPL=:N_SYCJPL,");
        strSql.Append("N_DSDPL=:N_DSDPL,");
        strSql.Append("N_DSSPL=:N_DSSPL,");
        strSql.Append("N_DSDCJ=:N_DSDCJ,");
        strSql.Append("N_DSSCJ=:N_DSSCJ,");
        strSql.Append("N_DSDCSX=:N_DSDCSX,");
        strSql.Append("N_DSCJ=:N_DSCJ,");
        strSql.Append("N_DSCJPL=:N_DSCJPL,");
        strSql.Append("N_UP_VISIT_RESULT=:N_UP_VISIT_RESULT,");
        strSql.Append("N_UP_HOME_RESULT=:N_UP_HOME_RESULT,");
        strSql.Append("N_VISIT_JZF=:N_VISIT_JZF,");
        strSql.Append("N_HOME_JZF=:N_HOME_JZF,");
        strSql.Append("N_RF_OPEN=:N_RF_OPEN,");
        strSql.Append("N_DX_OPEN=:N_DX_OPEN,");
        strSql.Append("N_DY_OPEN=:N_DY_OPEN,");
        strSql.Append("N_SY_OPEN=:N_SY_OPEN,");
        strSql.Append("N_DS_OPEN=:N_DS_OPEN,");
        strSql.Append("N_RQ_OPEN=:N_RQ_OPEN,");
        strSql.Append("N_BD_OPEN=:N_BD_OPEN,");
        strSql.Append("N_BQC_OPEN=:N_BQC_OPEN,");
        strSql.Append("N_RF_GG=:N_RF_GG,");
        strSql.Append("N_DX_GG=:N_DX_GG,");
        strSql.Append("N_DY_GG=:N_DY_GG,");
        strSql.Append("N_SY_GG=:N_SY_GG,");
        strSql.Append("N_DS_GG=:N_DS_GG,");
        strSql.Append("N_LET=:N_LET,");
        strSql.Append("N_RF_LOCK_V=:N_RF_LOCK_V,");
        strSql.Append("N_RF_LOCK_H=:N_RF_LOCK_H,");
        strSql.Append("N_DX_LOCK_V=:N_DX_LOCK_V,");
        strSql.Append("N_DX_LOCK_H=:N_DX_LOCK_H,");
        strSql.Append("N_DY_LOCK_V=:N_DY_LOCK_V,");
        strSql.Append("N_DY_LOCK_H=:N_DY_LOCK_H,");
        strSql.Append("N_SY_LOCK_V=:N_SY_LOCK_V,");
        strSql.Append("N_SY_LOCK_H=:N_SY_LOCK_H,");
        strSql.Append("N_DS_LOCK_V=:N_DS_LOCK_V,");
        strSql.Append("N_DS_LOCK_H=:N_DS_LOCK_H,");
        strSql.Append("N_REMARK=:N_REMARK,");
        //strSql.Append("N_COUNTTIME=:N_COUNTTIME,");
        strSql.Append("N_SAMETEAM=:N_SAMETEAM,");
        //strSql.Append("N_GZFLAG=:N_GZFLAG,");
        strSql.Append("N_RQSPL01=:N_RQSPL01,");
        strSql.Append("N_RQSPL23=:N_RQSPL23,");
        strSql.Append("N_RQSPL46=:N_RQSPL46,");
        strSql.Append("N_RQSPL7=:N_RQSPL7,");
        strSql.Append("N_RQSSX=:N_RQSSX,");
        strSql.Append("N_BDGPL00=:N_BDGPL00,");
        strSql.Append("N_BDZPL10=:N_BDZPL10,");
        strSql.Append("N_BDGPL11=:N_BDGPL11,");
        strSql.Append("N_BDZPL20=:N_BDZPL20,");
        strSql.Append("N_BDZPL21=:N_BDZPL21,");
        strSql.Append("N_BDGPL22=:N_BDGPL22,");
        strSql.Append("N_BDZPL30=:N_BDZPL30,");
        strSql.Append("N_BDZPL31=:N_BDZPL31,");
        strSql.Append("N_BDZPL32=:N_BDZPL32,");
        strSql.Append("N_BDGPL33=:N_BDGPL33,");
        strSql.Append("N_BDZPL41=:N_BDZPL41,");
        strSql.Append("N_BDZPL40=:N_BDZPL40,");
        strSql.Append("N_BDZPL42=:N_BDZPL42,");
        strSql.Append("N_BDZPL43=:N_BDZPL43,");
        strSql.Append("N_BDKPL10=:N_BDKPL10,");
        strSql.Append("N_BDKPL20=:N_BDKPL20,");
        strSql.Append("N_BDKPL21=:N_BDKPL21,");
        strSql.Append("N_BDKPL30=:N_BDKPL30,");
        strSql.Append("N_BDKPL31=:N_BDKPL31,");
        strSql.Append("N_BDKPL32=:N_BDKPL32,");
        strSql.Append("N_BDKPL40=:N_BDKPL40,");
        strSql.Append("N_BDKPL41=:N_BDKPL41,");
        strSql.Append("N_BDKPL42=:N_BDKPL42,");
        strSql.Append("N_BDKPL43=:N_BDKPL43,");
        strSql.Append("N_BDGPL44=:N_BDGPL44,");
        strSql.Append("N_BDZPL5=:N_BDZPL5,");
        strSql.Append("N_BDKPL5=:N_BDKPL5,");
        strSql.Append("N_BDSX=:N_BDSX,");
        strSql.Append("N_BQCZZ=:N_BQCZZ,");
        strSql.Append("N_BQCZH=:N_BQCZH,");
        strSql.Append("N_BQCZK=:N_BQCZK,");
        strSql.Append("N_BQCHH=:N_BQCHH,");
        strSql.Append("N_BQCHZ=:N_BQCHZ,");
        strSql.Append("N_BQCHK=:N_BQCHK,");
        strSql.Append("N_BQCKK=:N_BQCKK,");
        strSql.Append("N_BQCKZ=:N_BQCKZ,");
        strSql.Append("N_BQCKH=:N_BQCKH,");
        strSql.Append("N_BQCSX=:N_BQCSX,");
        strSql.Append("N_HJPL=:N_HJPL,");
        strSql.Append("N_HJGGCJ=:N_HJGGCJ,");
        strSql.Append("N_HJSX=:N_HJSX,");
        strSql.Append("N_LDXSX=:N_LDXSX,");
        strSql.Append("N_RDXSX=:N_RDXSX,");
        strSql.Append("N_LDSSX=:N_LDSSX,");
        strSql.Append("N_RDSSX=:N_RDSSX");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,10),
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_ZWDATE", OracleType.DateTime),
					new OracleParameter(":N_GAMEDATE", OracleType.DateTime),
					new OracleParameter(":N_LMNO", OracleType.Number,4),
					new OracleParameter(":N_VISIT", OracleType.Number,4),
					new OracleParameter(":N_HOME", OracleType.Number,4),
					new OracleParameter(":N_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_TSA", OracleType.VarChar,100),
					new OracleParameter(":N_TSB", OracleType.VarChar,100),
					new OracleParameter(":N_VISIT_NO", OracleType.Number,4),
					new OracleParameter(":N_HOME_NO", OracleType.Number,4),
					new OracleParameter(":N_SFZD", OracleType.Number,4),
					new OracleParameter(":N_SFXZ", OracleType.Number,4),
					new OracleParameter(":N_XZZT", OracleType.Number,4),
					new OracleParameter(":N_VH", OracleType.Number,4),
					new OracleParameter(":N_LOCK", OracleType.Number,4),
					new OracleParameter(":N_SF9J", OracleType.Number,4),
					new OracleParameter(":N_SFDS", OracleType.Number,4),
					new OracleParameter(":N_SFGP", OracleType.Number,4),
					new OracleParameter(":N_HYDZSX", OracleType.Number,4),
					new OracleParameter(":N_HYDCSX", OracleType.Number,4),
					new OracleParameter(":N_SFJZF", OracleType.Number,4),
					new OracleParameter(":N_ZBXH", OracleType.Number,4),
					new OracleParameter(":N_CBXH", OracleType.Number,4),
					new OracleParameter(":N_RFFS", OracleType.Number,4),
					new OracleParameter(":N_RFLX", OracleType.Number,4),
					new OracleParameter(":N_RFBL", OracleType.Number,4),
					new OracleParameter(":N_LRFPL", OracleType.Number,4),
					new OracleParameter(":N_RRFPL", OracleType.Number,4),
					new OracleParameter(":N_LRFCJ", OracleType.Number,4),
					new OracleParameter(":N_RRFCJ", OracleType.Number,4),
					new OracleParameter(":N_LRFSX", OracleType.Number,4),
					new OracleParameter(":N_RRFSX", OracleType.Number,4),
					new OracleParameter(":N_RFCJJE", OracleType.Number,4),
					new OracleParameter(":N_RFCJFS", OracleType.Number,4),
					new OracleParameter(":N_RFCJPL", OracleType.Number,4),
					new OracleParameter(":N_DXFS", OracleType.Number,4),
					new OracleParameter(":N_DXLX", OracleType.Number,4),
					new OracleParameter(":N_DXBL", OracleType.Number,4),
					new OracleParameter(":N_DXDPL", OracleType.Number,4),
					new OracleParameter(":N_DXXPL", OracleType.Number,4),
					new OracleParameter(":N_DXDCJ", OracleType.Number,4),
					new OracleParameter(":N_DXXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXDCSX", OracleType.Number,4),
					new OracleParameter(":N_DXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXCJPL", OracleType.Number,4),
					new OracleParameter(":N_LDYPL", OracleType.Number,4),
					new OracleParameter(":N_RDYPL", OracleType.Number,4),
					new OracleParameter(":N_LDYCJ", OracleType.Number,4),
					new OracleParameter(":N_RDYCJ", OracleType.Number,4),
					new OracleParameter(":N_LDYSX", OracleType.Number,4),
					new OracleParameter(":N_RDYSX", OracleType.Number,4),
					new OracleParameter(":N_DYCJ", OracleType.Number,4),
					new OracleParameter(":N_DYCJPL", OracleType.Number,4),
					new OracleParameter(":N_LSYPL", OracleType.Number,4),
					new OracleParameter(":N_RSYPL", OracleType.Number,4),
					new OracleParameter(":N_LSYCJ", OracleType.Number,4),
					new OracleParameter(":N_RSYCJ", OracleType.Number,4),
					new OracleParameter(":N_LSYSX", OracleType.Number,4),
					new OracleParameter(":N_RSYSX", OracleType.Number,4),
					new OracleParameter(":N_SYCJ", OracleType.Number,4),
					new OracleParameter(":N_SYCJPL", OracleType.Number,4),
					new OracleParameter(":N_DSDPL", OracleType.Number,4),
					new OracleParameter(":N_DSSPL", OracleType.Number,4),
					new OracleParameter(":N_DSDCJ", OracleType.Number,4),
					new OracleParameter(":N_DSSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSDCSX", OracleType.Number,4),
					new OracleParameter(":N_DSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSCJPL", OracleType.Number,4),
					new OracleParameter(":N_UP_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_UP_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_VISIT_JZF", OracleType.Number,4),
					new OracleParameter(":N_HOME_JZF", OracleType.Number,4),
					new OracleParameter(":N_RF_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DX_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_SY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DS_OPEN", OracleType.Number,4),
					new OracleParameter(":N_RQ_OPEN", OracleType.Number,4),
					new OracleParameter(":N_BD_OPEN", OracleType.Number,4),
					new OracleParameter(":N_BQC_OPEN", OracleType.Number,4),
					new OracleParameter(":N_RF_GG", OracleType.Number,4),
					new OracleParameter(":N_DX_GG", OracleType.Number,4),
					new OracleParameter(":N_DY_GG", OracleType.Number,4),
					new OracleParameter(":N_SY_GG", OracleType.Number,4),
					new OracleParameter(":N_DS_GG", OracleType.Number,4),
					new OracleParameter(":N_LET", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_REMARK", OracleType.VarChar,100),
					//new OracleParameter(":N_COUNTTIME", OracleType.DateTime),
					new OracleParameter(":N_SAMETEAM", OracleType.VarChar,20),
					//new OracleParameter(":N_GZFLAG", OracleType.Number,4),
					new OracleParameter(":N_RQSPL01",OracleType.Float,22),
					new OracleParameter(":N_RQSPL23",OracleType.Float,22),
					new OracleParameter(":N_RQSPL46",OracleType.Float,22),
					new OracleParameter(":N_RQSPL7",OracleType.Float,22),
					new OracleParameter(":N_RQSSX",OracleType.Float,22),
					new OracleParameter(":N_BDGPL00",OracleType.Float,22),
					new OracleParameter(":N_BDZPL10",OracleType.Float,22),
					new OracleParameter(":N_BDGPL11",OracleType.Float,22),
					new OracleParameter(":N_BDZPL20",OracleType.Float,22),
					new OracleParameter(":N_BDZPL21",OracleType.Float,22),
					new OracleParameter(":N_BDGPL22",OracleType.Float,22),
					new OracleParameter(":N_BDZPL30",OracleType.Float,22),
					new OracleParameter(":N_BDZPL31",OracleType.Float,22),
					new OracleParameter(":N_BDZPL32",OracleType.Float,22),
					new OracleParameter(":N_BDGPL33",OracleType.Float,22),
					new OracleParameter(":N_BDZPL41",OracleType.Float,22),
					new OracleParameter(":N_BDZPL40",OracleType.Float,22),
					new OracleParameter(":N_BDZPL42",OracleType.Float,22),
					new OracleParameter(":N_BDZPL43",OracleType.Float,22),
					new OracleParameter(":N_BDKPL10",OracleType.Float,22),
					new OracleParameter(":N_BDKPL20",OracleType.Float,22),
					new OracleParameter(":N_BDKPL21",OracleType.Float,22),
					new OracleParameter(":N_BDKPL30",OracleType.Float,22),
					new OracleParameter(":N_BDKPL31",OracleType.Float,22),
					new OracleParameter(":N_BDKPL32",OracleType.Float,22),
					new OracleParameter(":N_BDKPL40",OracleType.Float,22),
					new OracleParameter(":N_BDKPL41",OracleType.Float,22),
					new OracleParameter(":N_BDKPL42",OracleType.Float,22),
					new OracleParameter(":N_BDKPL43",OracleType.Float,22),
					new OracleParameter(":N_BDGPL44",OracleType.Float,22),
					new OracleParameter(":N_BDZPL5",OracleType.Float,22),
					new OracleParameter(":N_BDKPL5",OracleType.Float,22),
					new OracleParameter(":N_BDSX",OracleType.Float,22),
					new OracleParameter(":N_BQCZZ",OracleType.Float,22),
					new OracleParameter(":N_BQCZH",OracleType.Float,22),
					new OracleParameter(":N_BQCZK",OracleType.Float,22),
					new OracleParameter(":N_BQCHH",OracleType.Float,22),
					new OracleParameter(":N_BQCHZ",OracleType.Float,22),
					new OracleParameter(":N_BQCHK",OracleType.Float,22),
					new OracleParameter(":N_BQCKK",OracleType.Float,22),
					new OracleParameter(":N_BQCKZ",OracleType.Float,22),
					new OracleParameter(":N_BQCKH",OracleType.Float,22),
					new OracleParameter(":N_BQCSX",OracleType.Float,22),
					new OracleParameter(":N_HJPL",OracleType.Float,22),
					new OracleParameter(":N_HJGGCJ",OracleType.Float,22),
					new OracleParameter(":N_HJSX",OracleType.Float,22),
					new OracleParameter(":N_LDXSX", OracleType.Number,4),
					new OracleParameter(":N_RDXSX", OracleType.Number,4),
					new OracleParameter(":N_LDSSX", OracleType.Number,4),
					new OracleParameter(":N_RDSSX", OracleType.Number,4)};
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_LX;
        parameters[2].Value = model.N_ZWDATE;
        parameters[3].Value = model.N_GAMEDATE;
        parameters[4].Value = model.N_LMNO;
        parameters[5].Value = model.N_VISIT;
        parameters[6].Value = model.N_HOME;
        parameters[7].Value = model.N_VISIT_RESULT;
        parameters[8].Value = model.N_HOME_RESULT;
        parameters[9].Value = model.N_TSA;
        parameters[10].Value = model.N_TSB;
        parameters[11].Value = model.N_VISIT_NO;
        parameters[12].Value = model.N_HOME_NO;
        parameters[13].Value = model.N_SFZD;
        parameters[14].Value = model.N_SFXZ;
        parameters[15].Value = model.N_XZZT;
        parameters[16].Value = model.N_VH;
        parameters[17].Value = model.N_LOCK;
        parameters[18].Value = model.N_SF9J;
        parameters[19].Value = model.N_SFDS;
        parameters[20].Value = model.N_SFGP;
        parameters[21].Value = model.N_HYDZSX;
        parameters[22].Value = model.N_HYDCSX;
        parameters[23].Value = model.N_SFJZF;
        parameters[24].Value = model.N_ZBXH;
        parameters[25].Value = model.N_CBXH;
        parameters[26].Value = model.N_RFFS;
        parameters[27].Value = model.N_RFLX;
        parameters[28].Value = model.N_RFBL;
        parameters[29].Value = model.N_LRFPL;
        parameters[30].Value = model.N_RRFPL;
        parameters[31].Value = model.N_LRFCJ;
        parameters[32].Value = model.N_RRFCJ;
        parameters[33].Value = model.N_LRFSX;
        parameters[34].Value = model.N_RRFSX;
        parameters[35].Value = model.N_RFCJJE;
        parameters[36].Value = model.N_RFCJFS;
        parameters[37].Value = model.N_RFCJPL;
        parameters[38].Value = model.N_DXFS;
        parameters[39].Value = model.N_DXLX;
        parameters[40].Value = model.N_DXBL;
        parameters[41].Value = model.N_DXDPL;
        parameters[42].Value = model.N_DXXPL;
        parameters[43].Value = model.N_DXDCJ;
        parameters[44].Value = model.N_DXXCJ;
        parameters[45].Value = model.N_DXDCSX;
        parameters[46].Value = model.N_DXCJ;
        parameters[47].Value = model.N_DXCJPL;
        parameters[48].Value = model.N_LDYPL;
        parameters[49].Value = model.N_RDYPL;
        parameters[50].Value = model.N_LDYCJ;
        parameters[51].Value = model.N_RDYCJ;
        parameters[52].Value = model.N_LDYSX;
        parameters[53].Value = model.N_RDYSX;
        parameters[54].Value = model.N_DYCJ;
        parameters[55].Value = model.N_DYCJPL;
        parameters[56].Value = model.N_LSYPL;
        parameters[57].Value = model.N_RSYPL;
        parameters[58].Value = model.N_LSYCJ;
        parameters[59].Value = model.N_RSYCJ;
        parameters[60].Value = model.N_LSYSX;
        parameters[61].Value = model.N_RSYSX;
        parameters[62].Value = model.N_SYCJ;
        parameters[63].Value = model.N_SYCJPL;
        parameters[64].Value = model.N_DSDPL;
        parameters[65].Value = model.N_DSSPL;
        parameters[66].Value = model.N_DSDCJ;
        parameters[67].Value = model.N_DSSCJ;
        parameters[68].Value = model.N_DSDCSX;
        parameters[69].Value = model.N_DSCJ;
        parameters[70].Value = model.N_DSCJPL;
        parameters[71].Value = model.N_UP_VISIT_RESULT;
        parameters[72].Value = model.N_UP_HOME_RESULT;
        parameters[73].Value = model.N_VISIT_JZF;
        parameters[74].Value = model.N_HOME_JZF;
        parameters[75].Value = model.N_RF_OPEN;
        parameters[76].Value = model.N_DX_OPEN;
        parameters[77].Value = model.N_DY_OPEN;
        parameters[78].Value = model.N_SY_OPEN;
        parameters[79].Value = model.N_DS_OPEN;
        parameters[80].Value = model.N_RQ_OPEN;
        parameters[81].Value = model.N_BD_OPEN;
        parameters[82].Value = model.N_BQC_OPEN;
        parameters[83].Value = model.N_RF_GG;
        parameters[84].Value = model.N_DX_GG;
        parameters[85].Value = model.N_DY_GG;
        parameters[86].Value = model.N_SY_GG;
        parameters[87].Value = model.N_DS_GG;
        parameters[88].Value = model.N_LET;
        parameters[89].Value = model.N_RF_LOCK_V;
        parameters[90].Value = model.N_RF_LOCK_H;
        parameters[91].Value = model.N_DX_LOCK_V;
        parameters[92].Value = model.N_DX_LOCK_H;
        parameters[93].Value = model.N_DY_LOCK_V;
        parameters[94].Value = model.N_DY_LOCK_H;
        parameters[95].Value = model.N_SY_LOCK_V;
        parameters[96].Value = model.N_SY_LOCK_H;
        parameters[97].Value = model.N_DS_LOCK_V;
        parameters[98].Value = model.N_DS_LOCK_H;
        parameters[99].Value = model.N_REMARK;
        //parameters[97].Value = model.N_COUNTTIME;
        parameters[100].Value = model.N_SAMETEAM;
        //parameters[99].Value = model.N_GZFLAG;
        parameters[101].Value = model.N_RQSPL01;
        parameters[102].Value = model.N_RQSPL23;
        parameters[103].Value = model.N_RQSPL46;
        parameters[104].Value = model.N_RQSPL7;
        parameters[105].Value = model.N_RQSSX;
        parameters[106].Value = model.N_BDGPL00;
        parameters[107].Value = model.N_BDZPL10;
        parameters[108].Value = model.N_BDGPL11;
        parameters[109].Value = model.N_BDZPL20;
        parameters[110].Value = model.N_BDZPL21;
        parameters[111].Value = model.N_BDGPL22;
        parameters[112].Value = model.N_BDZPL30;
        parameters[113].Value = model.N_BDZPL31;
        parameters[114].Value = model.N_BDZPL32;
        parameters[115].Value = model.N_BDGPL33;
        parameters[116].Value = model.N_BDZPL41;
        parameters[117].Value = model.N_BDZPL40;
        parameters[118].Value = model.N_BDZPL42;
        parameters[119].Value = model.N_BDZPL43;
        parameters[120].Value = model.N_BDKPL10;
        parameters[121].Value = model.N_BDKPL20;
        parameters[122].Value = model.N_BDKPL21;
        parameters[123].Value = model.N_BDKPL30;
        parameters[124].Value = model.N_BDKPL31;
        parameters[125].Value = model.N_BDKPL32;
        parameters[126].Value = model.N_BDKPL40;
        parameters[127].Value = model.N_BDKPL41;
        parameters[128].Value = model.N_BDKPL42;
        parameters[129].Value = model.N_BDKPL43;
        parameters[130].Value = model.N_BDGPL44;
        parameters[131].Value = model.N_BDZPL5;
        parameters[132].Value = model.N_BDKPL5;
        parameters[133].Value = model.N_BDSX;
        parameters[134].Value = model.N_BQCZZ;
        parameters[135].Value = model.N_BQCZH;
        parameters[136].Value = model.N_BQCZK;
        parameters[137].Value = model.N_BQCHH;
        parameters[138].Value = model.N_BQCHZ;
        parameters[139].Value = model.N_BQCHK;
        parameters[140].Value = model.N_BQCKK;
        parameters[141].Value = model.N_BQCKZ;
        parameters[142].Value = model.N_BQCKH;
        parameters[143].Value = model.N_BQCSX;
        parameters[144].Value = model.N_HJPL;
        parameters[145].Value = model.N_HJGGCJ;
        parameters[146].Value = model.N_HJSX;
        parameters[147].Value = model.N_LDXSX;
        parameters[148].Value = model.N_RDXSX;
        parameters[149].Value = model.N_LDSSX;
        parameters[150].Value = model.N_RDSSX;

        o_aHt.Add(strSql, parameters);
    }

    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void Update(KFB_BASEBALL model, Hashtable o_aHt)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BASEBALL set ");
        strSql.Append("N_LX=:N_LX,");
        strSql.Append("N_ZWDATE=:N_ZWDATE,");
        strSql.Append("N_GAMEDATE=:N_GAMEDATE,");
        strSql.Append("N_LMNO=:N_LMNO,");
        strSql.Append("N_VISIT=:N_VISIT,");
        strSql.Append("N_HOME=:N_HOME,");
        strSql.Append("N_VISIT_RESULT=:N_VISIT_RESULT,");
        strSql.Append("N_HOME_RESULT=:N_HOME_RESULT,");
        strSql.Append("N_TSA=:N_TSA,");
        strSql.Append("N_TSB=:N_TSB,");
        strSql.Append("N_VISIT_NO=:N_VISIT_NO,");
        strSql.Append("N_HOME_NO=:N_HOME_NO,");
        strSql.Append("N_SFZD=:N_SFZD,");
        strSql.Append("N_SFXZ=:N_SFXZ,");
        strSql.Append("N_XZZT=:N_XZZT,");
        strSql.Append("N_LET=:N_LET,");
        strSql.Append("N_LOCK=:N_LOCK,");
        strSql.Append("N_VH=:N_VH,");
        strSql.Append("N_SF9J=:N_SF9J,");
        strSql.Append("N_SFDS=:N_SFDS,");
        strSql.Append("N_SFGP=:N_SFGP,");
        strSql.Append("N_HYDZSX=:N_HYDZSX,");
        strSql.Append("N_HYDCSX=:N_HYDCSX,");
        strSql.Append("N_SFJZF=:N_SFJZF,");
        strSql.Append("N_ZBXH=:N_ZBXH,");
        strSql.Append("N_CBXH=:N_CBXH,");
        strSql.Append("N_RFFS=:N_RFFS,");
        strSql.Append("N_RFLX=:N_RFLX,");
        strSql.Append("N_RFBL=:N_RFBL,");
        strSql.Append("N_LRFPL=:N_LRFPL,");
        strSql.Append("N_RRFPL=:N_RRFPL,");
        strSql.Append("N_LRFCJ=:N_LRFCJ,");
        strSql.Append("N_RRFCJ=:N_RRFCJ,");
        strSql.Append("N_LRFSX=:N_LRFSX,");
        strSql.Append("N_RRFSX=:N_RRFSX,");
        strSql.Append("N_RFCJJE=:N_RFCJJE,");
        strSql.Append("N_RFCJFS=:N_RFCJFS,");
        strSql.Append("N_RFCJPL=:N_RFCJPL,");
        strSql.Append("N_DXFS=:N_DXFS,");
        strSql.Append("N_DXLX=:N_DXLX,");
        strSql.Append("N_DXBL=:N_DXBL,");
        strSql.Append("N_DXDPL=:N_DXDPL,");
        strSql.Append("N_DXXPL=:N_DXXPL,");
        strSql.Append("N_DXDCJ=:N_DXDCJ,");
        strSql.Append("N_DXXCJ=:N_DXXCJ,");
        strSql.Append("N_DXDCSX=:N_DXDCSX,");
        strSql.Append("N_DXCJ=:N_DXCJ,");
        strSql.Append("N_DXCJPL=:N_DXCJPL,");
        strSql.Append("N_LDYPL=:N_LDYPL,");
        strSql.Append("N_RDYPL=:N_RDYPL,");
        strSql.Append("N_LDYCJ=:N_LDYCJ,");
        strSql.Append("N_RDYCJ=:N_RDYCJ,");
        strSql.Append("N_LDYSX=:N_LDYSX,");
        strSql.Append("N_RDYSX=:N_RDYSX,");
        strSql.Append("N_DYCJ=:N_DYCJ,");
        strSql.Append("N_DYCJPL=:N_DYCJPL,");
        strSql.Append("N_LSYPL=:N_LSYPL,");
        strSql.Append("N_RSYPL=:N_RSYPL,");
        strSql.Append("N_LSYCJ=:N_LSYCJ,");
        strSql.Append("N_RSYCJ=:N_RSYCJ,");
        strSql.Append("N_LSYSX=:N_LSYSX,");
        strSql.Append("N_RSYSX=:N_RSYSX,");
        strSql.Append("N_SYCJ=:N_SYCJ,");
        strSql.Append("N_SYCJPL=:N_SYCJPL,");
        strSql.Append("N_DSDPL=:N_DSDPL,");
        strSql.Append("N_DSSPL=:N_DSSPL,");
        strSql.Append("N_DSDCJ=:N_DSDCJ,");
        strSql.Append("N_DSSCJ=:N_DSSCJ,");
        strSql.Append("N_DSDCSX=:N_DSDCSX,");
        strSql.Append("N_DSCJ=:N_DSCJ,");
        strSql.Append("N_DSCJPL=:N_DSCJPL,");
        strSql.Append("N_UP_VISIT_RESULT=:N_UP_VISIT_RESULT,");
        strSql.Append("N_UP_HOME_RESULT=:N_UP_HOME_RESULT,");
        strSql.Append("N_VISIT_JZF=:N_VISIT_JZF,");
        strSql.Append("N_HOME_JZF=:N_HOME_JZF,");
        strSql.Append("N_RF_OPEN=:N_RF_OPEN,");
        strSql.Append("N_DX_OPEN=:N_DX_OPEN,");
        strSql.Append("N_DY_OPEN=:N_DY_OPEN,");
        strSql.Append("N_SY_OPEN=:N_SY_OPEN,");
        strSql.Append("N_DS_OPEN=:N_DS_OPEN,");
        strSql.Append("N_RF_GG=:N_RF_GG,");
        strSql.Append("N_DX_GG=:N_DX_GG,");
        strSql.Append("N_DY_GG=:N_DY_GG,");
        strSql.Append("N_SY_GG=:N_SY_GG,");
        strSql.Append("N_DS_GG=:N_DS_GG,");
        strSql.Append("N_RF_LOCK_V=:N_RF_LOCK_V,");
        strSql.Append("N_RF_LOCK_H=:N_RF_LOCK_H,");
        strSql.Append("N_DX_LOCK_V=:N_DX_LOCK_V,");
        strSql.Append("N_DX_LOCK_H=:N_DX_LOCK_H,");
        strSql.Append("N_DY_LOCK_V=:N_DY_LOCK_V,");
        strSql.Append("N_DY_LOCK_H=:N_DY_LOCK_H,");
        strSql.Append("N_SY_LOCK_V=:N_SY_LOCK_V,");
        strSql.Append("N_SY_LOCK_H=:N_SY_LOCK_H,");
        strSql.Append("N_DS_LOCK_V=:N_DS_LOCK_V,");
        strSql.Append("N_DS_LOCK_H=:N_DS_LOCK_H,");
        strSql.Append("N_REMARK=:N_REMARK,");
        strSql.Append("N_LDXSX=:N_LDXSX,");
        strSql.Append("N_RDXSX=:N_RDXSX,");
        strSql.Append("N_LDSSX=:N_LDSSX,");
        strSql.Append("N_RDSSX=:N_RDSSX");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4),
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_ZWDATE", OracleType.DateTime),
					new OracleParameter(":N_GAMEDATE", OracleType.DateTime),
					new OracleParameter(":N_LMNO", OracleType.Number,4),
					new OracleParameter(":N_VISIT", OracleType.Number,4),
					new OracleParameter(":N_HOME", OracleType.Number,4),
					new OracleParameter(":N_VISIT_RESULT", OracleType.Float,22),
					new OracleParameter(":N_HOME_RESULT", OracleType.Float,22),
					new OracleParameter(":N_TSA", OracleType.NVarChar),
					new OracleParameter(":N_TSB", OracleType.NVarChar),
					new OracleParameter(":N_VISIT_NO", OracleType.Number,4),
					new OracleParameter(":N_HOME_NO", OracleType.Number,4),
					new OracleParameter(":N_SFZD", OracleType.Number,4),
					new OracleParameter(":N_SFXZ", OracleType.Number,4),
					new OracleParameter(":N_XZZT", OracleType.Number,4),
					new OracleParameter(":N_LET", OracleType.Number,4),
					new OracleParameter(":N_LOCK", OracleType.Number,4),
					new OracleParameter(":N_VH", OracleType.Number,4),
					new OracleParameter(":N_SF9J", OracleType.Number,4),
					new OracleParameter(":N_SFDS", OracleType.Number,4),
					new OracleParameter(":N_SFGP", OracleType.Number,4),
					new OracleParameter(":N_HYDZSX", OracleType.Float,22),
					new OracleParameter(":N_HYDCSX", OracleType.Float,22),
					new OracleParameter(":N_SFJZF", OracleType.Number,4),
					new OracleParameter(":N_ZBXH", OracleType.Number,4),
					new OracleParameter(":N_CBXH", OracleType.Number,4),
					new OracleParameter(":N_RFFS", OracleType.Float,22),
					new OracleParameter(":N_RFLX", OracleType.Number,4),
					new OracleParameter(":N_RFBL", OracleType.Number,4),
					new OracleParameter(":N_LRFPL", OracleType.Float,22),
					new OracleParameter(":N_RRFPL", OracleType.Float,22),
					new OracleParameter(":N_LRFCJ", OracleType.Float,22),
					new OracleParameter(":N_RRFCJ", OracleType.Float,22),
					new OracleParameter(":N_LRFSX", OracleType.Float,22),
					new OracleParameter(":N_RRFSX", OracleType.Float,22),
					new OracleParameter(":N_RFCJJE", OracleType.Float,22),
					new OracleParameter(":N_RFCJFS", OracleType.Number,4),
					new OracleParameter(":N_RFCJPL", OracleType.Float,22),
					new OracleParameter(":N_DXFS", OracleType.Float,22),
					new OracleParameter(":N_DXLX", OracleType.Number,4),
					new OracleParameter(":N_DXBL", OracleType.Number,4),
					new OracleParameter(":N_DXDPL", OracleType.Float,22),
					new OracleParameter(":N_DXXPL", OracleType.Float,22),
					new OracleParameter(":N_DXDCJ", OracleType.Float,22),
					new OracleParameter(":N_DXXCJ", OracleType.Float,22),
					new OracleParameter(":N_DXDCSX", OracleType.Float,22),
					new OracleParameter(":N_DXCJ", OracleType.Float,22),
					new OracleParameter(":N_DXCJPL", OracleType.Float,22),
					new OracleParameter(":N_LDYPL", OracleType.Float,22),
					new OracleParameter(":N_RDYPL", OracleType.Float,22),
					new OracleParameter(":N_LDYCJ", OracleType.Float,22),
					new OracleParameter(":N_RDYCJ", OracleType.Float,22),
					new OracleParameter(":N_LDYSX", OracleType.Float,22),
					new OracleParameter(":N_RDYSX", OracleType.Float,22),
					new OracleParameter(":N_DYCJ", OracleType.Float,22),
					new OracleParameter(":N_DYCJPL", OracleType.Float,22),
					new OracleParameter(":N_LSYPL", OracleType.Float,22),
					new OracleParameter(":N_RSYPL", OracleType.Float,22),
					new OracleParameter(":N_LSYCJ", OracleType.Float,22),
					new OracleParameter(":N_RSYCJ", OracleType.Float,22),
					new OracleParameter(":N_LSYSX", OracleType.Float,22),
					new OracleParameter(":N_RSYSX", OracleType.Float,22),
					new OracleParameter(":N_SYCJ", OracleType.Float,22),
					new OracleParameter(":N_SYCJPL", OracleType.Float,22),
					new OracleParameter(":N_DSDPL", OracleType.Float,22),
					new OracleParameter(":N_DSSPL", OracleType.Float,22),
					new OracleParameter(":N_DSDCJ", OracleType.Float,22),
					new OracleParameter(":N_DSSCJ", OracleType.Float,22),
					new OracleParameter(":N_DSDCSX", OracleType.Float,22),
					new OracleParameter(":N_DSCJ", OracleType.Float,22),
					new OracleParameter(":N_DSCJPL", OracleType.Float,22),
					new OracleParameter(":N_UP_VISIT_RESULT", OracleType.Float,22),
					new OracleParameter(":N_UP_HOME_RESULT", OracleType.Float,22),
					new OracleParameter(":N_VISIT_JZF", OracleType.Float,22),
					new OracleParameter(":N_HOME_JZF", OracleType.Float,22),
					new OracleParameter(":N_RF_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DX_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_SY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DS_OPEN", OracleType.Number,4),
					new OracleParameter(":N_RF_GG", OracleType.Number,4),
					new OracleParameter(":N_DX_GG", OracleType.Number,4),
					new OracleParameter(":N_DY_GG", OracleType.Number,4),
					new OracleParameter(":N_SY_GG", OracleType.Number,4),
					new OracleParameter(":N_DS_GG", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_REMARK", OracleType.NVarChar),
					new OracleParameter(":N_LDXSX", OracleType.Number,4),
					new OracleParameter(":N_RDXSX", OracleType.Number,4),
					new OracleParameter(":N_LDSSX", OracleType.Number,4),
					new OracleParameter(":N_RDSSX", OracleType.Number,4)
            };
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_LX;
        parameters[2].Value = model.N_ZWDATE;
        parameters[3].Value = model.N_GAMEDATE;
        parameters[4].Value = model.N_LMNO;
        parameters[5].Value = model.N_VISIT;
        parameters[6].Value = model.N_HOME;
        parameters[7].Value = model.N_VISIT_RESULT;
        parameters[8].Value = model.N_HOME_RESULT;
        parameters[9].Value = model.N_TSA;
        parameters[10].Value = model.N_TSB;
        parameters[11].Value = model.N_VISIT_NO;
        parameters[12].Value = model.N_HOME_NO;
        parameters[13].Value = model.N_SFZD;
        parameters[14].Value = model.N_SFXZ;
        parameters[15].Value = model.N_XZZT;
        parameters[16].Value = model.N_LET;
        parameters[17].Value = model.N_LOCK;
        parameters[18].Value = model.N_VH;
        parameters[19].Value = model.N_SF9J;
        parameters[20].Value = model.N_SFDS;
        parameters[21].Value = model.N_SFGP;
        parameters[22].Value = model.N_HYDZSX;
        parameters[23].Value = model.N_HYDCSX;
        parameters[24].Value = model.N_SFJZF;
        parameters[25].Value = model.N_ZBXH;
        parameters[26].Value = model.N_CBXH;
        parameters[27].Value = model.N_RFFS;
        parameters[28].Value = model.N_RFLX;
        parameters[29].Value = model.N_RFBL;
        parameters[30].Value = model.N_LRFPL;
        parameters[31].Value = model.N_RRFPL;
        parameters[32].Value = model.N_LRFCJ;
        parameters[33].Value = model.N_RRFCJ;
        parameters[34].Value = model.N_LRFSX;
        parameters[35].Value = model.N_RRFSX;
        parameters[36].Value = model.N_RFCJJE;
        parameters[37].Value = model.N_RFCJFS;
        parameters[38].Value = model.N_RFCJPL;
        parameters[39].Value = model.N_DXFS;
        parameters[40].Value = model.N_DXLX;
        parameters[41].Value = model.N_DXBL;
        parameters[42].Value = model.N_DXDPL;
        parameters[43].Value = model.N_DXXPL;
        parameters[44].Value = model.N_DXDCJ;
        parameters[45].Value = model.N_DXXCJ;
        parameters[46].Value = model.N_DXDCSX;
        parameters[47].Value = model.N_DXCJ;
        parameters[48].Value = model.N_DXCJPL;
        parameters[49].Value = model.N_LDYPL;
        parameters[50].Value = model.N_RDYPL;
        parameters[51].Value = model.N_LDYCJ;
        parameters[52].Value = model.N_RDYCJ;
        parameters[53].Value = model.N_LDYSX;
        parameters[54].Value = model.N_RDYSX;
        parameters[55].Value = model.N_DYCJ;
        parameters[56].Value = model.N_DYCJPL;
        parameters[57].Value = model.N_LSYPL;
        parameters[58].Value = model.N_RSYPL;
        parameters[59].Value = model.N_LSYCJ;
        parameters[60].Value = model.N_RSYCJ;
        parameters[61].Value = model.N_LSYSX;
        parameters[62].Value = model.N_RSYSX;
        parameters[63].Value = model.N_SYCJ;
        parameters[64].Value = model.N_SYCJPL;
        parameters[65].Value = model.N_DSDPL;
        parameters[66].Value = model.N_DSSPL;
        parameters[67].Value = model.N_DSDCJ;
        parameters[68].Value = model.N_DSSCJ;
        parameters[69].Value = model.N_DSDCSX;
        parameters[70].Value = model.N_DSCJ;
        parameters[71].Value = model.N_DSCJPL;
        parameters[72].Value = model.N_UP_VISIT_RESULT;
        parameters[73].Value = model.N_UP_HOME_RESULT;
        parameters[74].Value = model.N_VISIT_JZF;
        parameters[75].Value = model.N_HOME_JZF;
        parameters[76].Value = model.N_RF_OPEN;
        parameters[77].Value = model.N_DX_OPEN;
        parameters[78].Value = model.N_DY_OPEN;
        parameters[79].Value = model.N_SY_OPEN;
        parameters[80].Value = model.N_DS_OPEN;
        parameters[81].Value = model.N_RF_GG;
        parameters[82].Value = model.N_DX_GG;
        parameters[83].Value = model.N_DY_GG;
        parameters[84].Value = model.N_SY_GG;
        parameters[85].Value = model.N_DS_GG;
        parameters[86].Value = model.N_RF_LOCK_V;
        parameters[87].Value = model.N_RF_LOCK_H;
        parameters[88].Value = model.N_DX_LOCK_V;
        parameters[89].Value = model.N_DX_LOCK_H;
        parameters[90].Value = model.N_DY_LOCK_V;
        parameters[91].Value = model.N_DY_LOCK_H;
        parameters[92].Value = model.N_SY_LOCK_V;
        parameters[93].Value = model.N_SY_LOCK_H;
        parameters[94].Value = model.N_DS_LOCK_V;
        parameters[95].Value = model.N_DS_LOCK_H;
        parameters[96].Value = model.N_REMARK;
        parameters[97].Value = model.N_LDXSX;
        parameters[98].Value = model.N_RDXSX;
        parameters[99].Value = model.N_LDSSX;
        parameters[100].Value = model.N_RDSSX;

        o_aHt.Add(strSql, parameters);
    }

    /// <summary>
    /// 執行事物
    /// </summary>
    /// <param name="o_aHt"></param>
    public void SetTran(Hashtable o_aHt)
    {
        DbHelperOra.ExecuteSqlTran(o_aHt);
    }
}
