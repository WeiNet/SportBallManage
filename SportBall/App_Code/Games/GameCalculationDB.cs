using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;

public class GameCalculationDB
{
    protected OracleConnection conn;
    protected OracleTransaction tran;
    public GameCalculationDB(bool isTran)
    {
        if (isTran)
        {
            conn = DbHelperOra.Open();
            tran = conn.BeginTransaction();
        }
        else
        {
            conn = DbHelperOra.Open();
        }
    }
    public GameCalculationDB()
    {
        conn = DbHelperOra.Open();
    }
    public void Close()
    {
        if (conn.State != ConnectionState.Closed)
        {
            conn.Close();
        }
    }
    public void Commit()
    {
        tran.Commit();
    }
    public void Rollback()
    {
        tran.Rollback();
    }
    public void Tran()
    {
        tran = conn.BeginTransaction();
    }
    public void Open()
    {
        conn = DbHelperOra.Open();
    }
    private void WriteLog(string funcName, string strSql, OracleParameter[] parameters)
    {
        string param = "";
        foreach (OracleParameter p in parameters)
        {
            param += p.ParameterName + ":" + p.Value + ",";
        }
        DbHelperOra.LogDB.Info(funcName + ":\r\nSQL=" + strSql + "\r\n" + "PARAM=" + param);
    }
    /// <summary>
    /// 获取系统时间
    /// </summary>
    /// <returns></returns>
    public DateTime GetSysDate()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select sysdate from dual");
        return Convert.ToDateTime(DbHelperOra.GetSingle(conn, tran, strSql.ToString()));
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
        DataSet ds = DbHelperOra.Query(conn, tran, strSql.ToString(), parameters);
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
    ///  计算赛事
    /// </summary>
    /// <param name="model"></param>
    public void CountMatch(KFB_BASEBALL model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BASEBALL set ");
        strSql.Append("N_VISIT_RESULT=:N_VISIT_RESULT,");
        strSql.Append("N_HOME_RESULT=:N_HOME_RESULT,");
        strSql.Append("N_UP_VISIT_RESULT=:N_UP_VISIT_RESULT,");
        strSql.Append("N_UP_HOME_RESULT=:N_UP_HOME_RESULT,");
        strSql.Append("N_REMARK=:N_REMARK,");
        strSql.Append("N_COUNTTIME=:N_COUNTTIME,");
        strSql.Append("N_SFXZ=0,");
        strSql.Append("N_XZZT=1,");
        strSql.Append("N_SF9J=:N_SF9J");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4),
					new OracleParameter(":N_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_UP_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_UP_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_REMARK", OracleType.NVarChar),
					new OracleParameter(":N_COUNTTIME", OracleType.DateTime),
					new OracleParameter(":N_SF9J", OracleType.Number,4)};
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_VISIT_RESULT;
        parameters[2].Value = model.N_HOME_RESULT;
        parameters[3].Value = model.N_UP_VISIT_RESULT;
        parameters[4].Value = model.N_UP_HOME_RESULT;
        parameters[5].Value = model.N_REMARK;
        parameters[6].Value = model.N_COUNTTIME;
        parameters[7].Value = model.N_SF9J;

        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
    }
    /// <summary>
    ///  重新计算赛事
    /// </summary>
    /// <param name="model"></param>
    public void ReCountMatch(KFB_BASEBALL model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_ACCBALL set ");
        strSql.Append("N_VISIT_RESULT=:N_VISIT_RESULT,");
        strSql.Append("N_HOME_RESULT=:N_HOME_RESULT,");
        strSql.Append("N_UP_VISIT_RESULT=:N_UP_VISIT_RESULT,");
        strSql.Append("N_UP_HOME_RESULT=:N_UP_HOME_RESULT,");
        strSql.Append("N_REMARK=:N_REMARK,");
        strSql.Append("N_COUNTTIME=:N_COUNTTIME,");
        strSql.Append("N_SFXZ=0,");
        strSql.Append("N_XZZT=1,");
        strSql.Append("N_SF9J=:N_SF9J");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4),
					new OracleParameter(":N_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_UP_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_UP_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_REMARK", OracleType.NVarChar),
					new OracleParameter(":N_COUNTTIME", OracleType.DateTime),
					new OracleParameter(":N_SF9J", OracleType.Number,4)};
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_VISIT_RESULT;
        parameters[2].Value = model.N_HOME_RESULT;
        parameters[3].Value = model.N_UP_VISIT_RESULT;
        parameters[4].Value = model.N_UP_HOME_RESULT;
        parameters[5].Value = model.N_REMARK;
        parameters[6].Value = model.N_COUNTTIME;
        parameters[7].Value = model.N_SF9J;

        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
    }
    /// <summary>
    /// 赛事计算记录  
    /// </summary>
    /// <param name="n_matchid"></param>
    /// <param name="n_lmno"></param>
    /// <param name="n_visit_result_b"></param>
    /// <param name="n_visit_result_a"></param>
    /// <param name="n_home_result_b"></param>
    /// <param name="n_home_result_a"></param>
    /// <param name="n_counttime_b"></param>
    /// <param name="n_counttime_a"></param>
    public void InsertBallLog(int n_matchid, decimal n_visit_rbf, decimal n_home_raf, decimal n_visit_rbu, decimal n_home_rau, DateTime n_date)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into kfb_baseballlog(n_id, n_matchid, n_visit_rbf, n_home_raf, n_visit_rbu, n_home_rau, n_date) ");
        strSql.Append("values(example_seq.nextval, :n_matchid, :n_visit_rbf, :n_home_raf, :n_visit_rbu, :n_home_rau, :n_date)");
        OracleParameter[] parameters = {
					new OracleParameter(":n_matchid", OracleType.Number),
					new OracleParameter(":n_visit_rbf", OracleType.Number),
					new OracleParameter(":n_home_raf", OracleType.Number),
					new OracleParameter(":n_visit_rbu", OracleType.Number),
					new OracleParameter(":n_home_rau", OracleType.Number),
					new OracleParameter(":n_date", OracleType.DateTime)
            };
        parameters[0].Value = n_matchid;
        parameters[1].Value = n_visit_rbf;
        parameters[2].Value = n_home_raf;
        parameters[3].Value = n_visit_rbu;
        parameters[4].Value = n_home_rau;
        parameters[5].Value = n_date;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
    }
    /// <summary>
    /// 获取赛事下所有注单列表
    /// </summary>
    /// <param name="N_BSLX"></param>
    /// <param name="N_ID"></param>
    /// <param name="n_xzcb"></param>
    /// <returns></returns>
    public DataSet GetBillList(string N_BSLX, string N_ID, string n_xzcb)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select * from KFB_PTZD  ");
        strSql.Append(" where N_BSLX=:N_BSLX and n_qsbh=:N_ID and n_xzcb=:n_xzcb ");
        strSql.Append(" union select * from KFB_OPTZD  ");
        strSql.Append(" where N_BSLX=:N_BSLX and n_qsbh=:N_ID and n_xzcb=:n_xzcb ");

        OracleParameter[] parameters = {
					new OracleParameter(":N_BSLX", OracleType.VarChar,50),
                    new OracleParameter(":N_ID", OracleType.Number,10),
                    new OracleParameter(":n_xzcb", OracleType.VarChar,50)
            };
        parameters[0].Value = N_BSLX;
        parameters[1].Value = Convert.ToInt32(N_ID);
        parameters[2].Value = n_xzcb;


        return DbHelperOra.Query(conn, tran, strSql.ToString(), parameters);
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_PTZD GetModel(string N_ID)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select T.*,0 AS N_FLAG from KFB_PTZD T");
        strSql.Append(" where N_ID=:N_ID");
        strSql.Append(" UNION select T.*,1 AS N_FLAG from KFB_OPTZD T");
        strSql.Append(" where N_ID=:N_ID");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.VarChar,50)};
        parameters[0].Value = N_ID;

        KFB_PTZD model = new KFB_PTZD();
        DataSet ds = DbHelperOra.Query(conn, tran, strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_ID = ds.Tables[0].Rows[0]["N_ID"].ToString();
            if (ds.Tables[0].Rows[0]["N_ZWRQ"].ToString() != "")
            {
                model.N_ZWRQ = DateTime.Parse(ds.Tables[0].Rows[0]["N_ZWRQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_XZRQ"].ToString() != "")
            {
                model.N_XZRQ = DateTime.Parse(ds.Tables[0].Rows[0]["N_XZRQ"].ToString());
            }
            model.N_XZDH = ds.Tables[0].Rows[0]["N_XZDH"].ToString();
            model.N_BSLX = ds.Tables[0].Rows[0]["N_BSLX"].ToString();
            model.N_XZWF = ds.Tables[0].Rows[0]["N_XZWF"].ToString();
            model.N_XZCB = ds.Tables[0].Rows[0]["N_XZCB"].ToString();
            model.N_XZNR = ds.Tables[0].Rows[0]["N_XZNR"].ToString();
            if (ds.Tables[0].Rows[0]["N_PL"].ToString() != "")
            {
                model.N_PL = decimal.Parse(ds.Tables[0].Rows[0]["N_PL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_XZJE"].ToString() != "")
            {
                model.N_XZJE = decimal.Parse(ds.Tables[0].Rows[0]["N_XZJE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYJG"].ToString() != "")
            {
                model.N_SYJG = decimal.Parse(ds.Tables[0].Rows[0]["N_SYJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TY"].ToString() != "")
            {
                model.N_TY = decimal.Parse(ds.Tables[0].Rows[0]["N_TY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HYJG"].ToString() != "")
            {
                model.N_HYJG = decimal.Parse(ds.Tables[0].Rows[0]["N_HYJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HYDH"].ToString() != "")
            {
                model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            }
            model.N_BSDW = ds.Tables[0].Rows[0]["N_BSDW"].ToString();
            if (ds.Tables[0].Rows[0]["N_QSBH"].ToString() != "")
            {
                model.N_QSBH = int.Parse(ds.Tables[0].Rows[0]["N_QSBH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_KYJE"].ToString() != "")
            {
                model.N_KYJE = decimal.Parse(ds.Tables[0].Rows[0]["N_KYJE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JS"].ToString() != "")
            {
                model.N_JS = int.Parse(ds.Tables[0].Rows[0]["N_JS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WXDJ"].ToString() != "")
            {
                model.N_WXDJ = int.Parse(ds.Tables[0].Rows[0]["N_WXDJ"].ToString());
            }
            model.N_LMMC = ds.Tables[0].Rows[0]["N_LMMC"].ToString();
            model.N_DZJDH = ds.Tables[0].Rows[0]["N_DZJDH"].ToString();
            model.N_ZJDH = ds.Tables[0].Rows[0]["N_ZJDH"].ToString();
            model.N_DGDDH = ds.Tables[0].Rows[0]["N_DGDDH"].ToString();
            model.N_GDDH = ds.Tables[0].Rows[0]["N_GDDH"].ToString();
            model.N_ZDLDH = ds.Tables[0].Rows[0]["N_ZDLDH"].ToString();
            model.N_DLDH = ds.Tables[0].Rows[0]["N_DLDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_ZJCZ"].ToString() != "")
            {
                model.N_ZJCZ = int.Parse(ds.Tables[0].Rows[0]["N_ZJCZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZGDCZ"].ToString() != "")
            {
                model.N_ZGDCZ = int.Parse(ds.Tables[0].Rows[0]["N_ZGDCZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDCZ"].ToString() != "")
            {
                model.N_GDCZ = int.Parse(ds.Tables[0].Rows[0]["N_GDCZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDLCZ"].ToString() != "")
            {
                model.N_ZDLCZ = int.Parse(ds.Tables[0].Rows[0]["N_ZDLCZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLCZ"].ToString() != "")
            {
                model.N_DLCZ = int.Parse(ds.Tables[0].Rows[0]["N_DLCZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DGDJG"].ToString() != "")
            {
                model.N_DGDJG = decimal.Parse(ds.Tables[0].Rows[0]["N_DGDJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDJG"].ToString() != "")
            {
                model.N_GDJG = decimal.Parse(ds.Tables[0].Rows[0]["N_GDJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDLJG"].ToString() != "")
            {
                model.N_ZDLJG = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDLJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLSJG"].ToString() != "")
            {
                model.N_DLSJG = decimal.Parse(ds.Tables[0].Rows[0]["N_DLSJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RF"].ToString() != "")
            {
                model.N_RF = decimal.Parse(ds.Tables[0].Rows[0]["N_RF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFXT"].ToString() != "")
            {
                model.N_RFXT = decimal.Parse(ds.Tables[0].Rows[0]["N_RFXT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFBL"].ToString() != "")
            {
                model.N_RFBL = decimal.Parse(ds.Tables[0].Rows[0]["N_RFBL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFFS"].ToString() != "")
            {
                model.N_RFFS = decimal.Parse(ds.Tables[0].Rows[0]["N_RFFS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DX"].ToString() != "")
            {
                model.N_DX = decimal.Parse(ds.Tables[0].Rows[0]["N_DX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXXT"].ToString() != "")
            {
                model.N_DXXT = decimal.Parse(ds.Tables[0].Rows[0]["N_DXXT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXBL"].ToString() != "")
            {
                model.N_DXBL = decimal.Parse(ds.Tables[0].Rows[0]["N_DXBL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DEL"].ToString() != "")
            {
                model.N_DEL = decimal.Parse(ds.Tables[0].Rows[0]["N_DEL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GSTY"].ToString() != "")
            {
                model.N_GSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DGDTY"].ToString() != "")
            {
                model.N_DGDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DGDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDTY"].ToString() != "")
            {
                model.N_GDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDLTY"].ToString() != "")
            {
                model.N_ZDLTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDLTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTY"].ToString() != "")
            {
                model.N_DLTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DLTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZJTY"].ToString() != "")
            {
                model.N_ZJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZJTY"].ToString());
            }
            model.N_HYIP = ds.Tables[0].Rows[0]["N_HYIP"].ToString();
            if (ds.Tables[0].Rows[0]["N_GSJG"].ToString() != "")
            {
                model.N_GSJG = decimal.Parse(ds.Tables[0].Rows[0]["N_GSJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZJJG"].ToString() != "")
            {
                model.N_ZJJG = decimal.Parse(ds.Tables[0].Rows[0]["N_ZJJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLSWCZ"].ToString() != "")
            {
                model.N_DLSWCZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DLSWCZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDF"].ToString() != "")
            {
                model.N_ZDF = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDF"].ToString() != "")
            {
                model.N_RDF = decimal.Parse(ds.Tables[0].Rows[0]["N_RDF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JZF"].ToString() != "")
            {
                model.N_JZF = decimal.Parse(ds.Tables[0].Rows[0]["N_JZF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_YS"].ToString() != "")
            {
                model.N_YS = decimal.Parse(ds.Tables[0].Rows[0]["N_YS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DZJCZ"].ToString() != "")
            {
                model.N_DZJCZ = int.Parse(ds.Tables[0].Rows[0]["N_DZJCZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DZJJG"].ToString() != "")
            {
                model.N_DZJJG = decimal.Parse(ds.Tables[0].Rows[0]["N_DZJJG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DZJTY"].ToString() != "")
            {
                model.N_DZJTY = int.Parse(ds.Tables[0].Rows[0]["N_DZJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QR"] != null)
            {
                model.N_QR = ds.Tables[0].Rows[0]["N_QR"].ToString();
            }
            model.N_FLAG = ds.Tables[0].Rows[0]["N_FLAG"].ToString();
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 获取剩余额度
    /// </summary>
    /// <param name="N_HYZH"></param>
    /// <returns></returns>
    public decimal GetCredit(string N_HYZH)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select  N_SYED");
        strSql.Append(" FROM KFB_HYGL WHERE N_HYZH=:N_HYZH");
        OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100)
            };
        parameters[0].Value = N_HYZH;
        return Convert.ToDecimal(DbHelperOra.GetSingle(conn, tran, strSql.ToString(), parameters));
    }

    /// <summary>
    /// 获得序號
    /// </summary>
    public int GetNo()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select EXAMPLE_SEQ.nextval from dual");
        return Convert.ToInt32(DbHelperOra.GetSingle(conn, tran, strSql.ToString()));
    }
    /// <summary>
    /// 恢复额度
    /// </summary>
    /// <param name="N_HYZH"></param>
    /// <param name="N_KYED"></param>
    public void ReSetCredit(string N_HYZH, decimal N_KYED)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" update kfb_hygl set n_syed=n_syed+:N_SYED ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_SYED", OracleType.Number,4),
            };
        parameters[0].Value = N_HYZH;
        parameters[1].Value = N_KYED;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
    }
    /// <summary>
    /// 计算注单
    /// </summary>
    /// <param name="model"></param>
    public void CountBill(KFB_PTZD model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_PTZD set ");
        strSql.Append("N_SYJG=:N_SYJG,");
        strSql.Append("N_HYJG=:N_HYJG,");
        strSql.Append("N_DLSJG=:N_DLSJG,");
        strSql.Append("N_ZDLJG=:N_ZDLJG,");
        strSql.Append("N_GDJG=:N_GDJG,");
        strSql.Append("N_DGDJG=:N_DGDJG,");
        strSql.Append("N_ZJJG=:N_ZJJG,");
        strSql.Append("N_GSJG=:N_GSJG,");
        strSql.Append("N_KYJE=:N_KYJE,");
        strSql.Append("N_XZNR=:N_XZNR ,");
        strSql.Append("n_js=:n_js , ");
        strSql.Append("N_DZJJG=:N_DZJJG, ");
        strSql.Append("N_DLSWCZ=:N_DLSWCZ ");
        strSql.Append(" where N_ID=:N_ID");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.VarChar,9),
					new OracleParameter(":N_SYJG", OracleType.Float,22),
					new OracleParameter(":N_HYJG", OracleType.Float,22),
					new OracleParameter(":N_DLSJG", OracleType.Float,22),
					new OracleParameter(":N_ZDLJG", OracleType.Float,22),
					new OracleParameter(":N_GDJG", OracleType.Float,22),
					new OracleParameter(":N_DGDJG", OracleType.Float,22),
					new OracleParameter(":N_ZJJG", OracleType.Float,22),
					new OracleParameter(":N_GSJG", OracleType.Float,22),
					new OracleParameter(":N_KYJE", OracleType.Float,22),
					new OracleParameter(":N_XZNR", OracleType.VarChar,500),
                    new OracleParameter(":n_js", OracleType.Number,4),
                    new OracleParameter(":N_DZJJG", OracleType.Float,22),
                    new OracleParameter(":N_DLSWCZ", OracleType.Float,22)
            };
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_SYJG;
        parameters[2].Value = model.N_HYJG;
        parameters[3].Value = model.N_DLSJG;
        parameters[4].Value = model.N_ZDLJG;
        parameters[5].Value = model.N_GDJG;
        parameters[6].Value = model.N_DGDJG;
        parameters[7].Value = model.N_ZJJG;
        parameters[8].Value = model.N_GSJG;
        parameters[9].Value = model.N_KYJE;
        parameters[10].Value = model.N_XZNR;
        parameters[11].Value = model.N_JS;
        parameters[12].Value = model.N_DZJJG;
        parameters[13].Value = model.N_DLSWCZ;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        //WriteLog("UPJS", strSql.ToString(), parameters);
    }
    /// <summary>
    /// 重新计算注单
    /// </summary>
    /// <param name="model"></param>
    public void ReCountBill(KFB_PTZD model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_OPTZD set ");
        strSql.Append("N_SYJG=:N_SYJG,");
        strSql.Append("N_HYJG=:N_HYJG,");
        strSql.Append("N_DLSJG=:N_DLSJG,");
        strSql.Append("N_ZDLJG=:N_ZDLJG,");
        strSql.Append("N_GDJG=:N_GDJG,");
        strSql.Append("N_DGDJG=:N_DGDJG,");
        strSql.Append("N_ZJJG=:N_ZJJG,");
        strSql.Append("N_GSJG=:N_GSJG,");
        strSql.Append("N_KYJE=:N_KYJE,");
        strSql.Append("N_XZNR=:N_XZNR ,");
        strSql.Append("n_js=:n_js , ");
        strSql.Append("N_DZJJG=:N_DZJJG, ");
        strSql.Append("N_DLSWCZ=:N_DLSWCZ ");
        strSql.Append(" where N_ID=:N_ID");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.VarChar,9),
					new OracleParameter(":N_SYJG", OracleType.Float,22),
					new OracleParameter(":N_HYJG", OracleType.Float,22),
					new OracleParameter(":N_DLSJG", OracleType.Float,22),
					new OracleParameter(":N_ZDLJG", OracleType.Float,22),
					new OracleParameter(":N_GDJG", OracleType.Float,22),
					new OracleParameter(":N_DGDJG", OracleType.Float,22),
					new OracleParameter(":N_ZJJG", OracleType.Float,22),
					new OracleParameter(":N_GSJG", OracleType.Float,22),
					new OracleParameter(":N_KYJE", OracleType.Float,22),
					new OracleParameter(":N_XZNR", OracleType.VarChar,500),
                    new OracleParameter(":n_js", OracleType.Number,4),
                    new OracleParameter(":N_DZJJG", OracleType.Float,22),
                    new OracleParameter(":N_DLSWCZ", OracleType.Float,22)
            };
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_SYJG;
        parameters[2].Value = model.N_HYJG;
        parameters[3].Value = model.N_DLSJG;
        parameters[4].Value = model.N_ZDLJG;
        parameters[5].Value = model.N_GDJG;
        parameters[6].Value = model.N_DGDJG;
        parameters[7].Value = model.N_ZJJG;
        parameters[8].Value = model.N_GSJG;
        parameters[9].Value = model.N_KYJE;
        parameters[10].Value = model.N_XZNR;
        parameters[11].Value = model.N_JS;
        parameters[12].Value = model.N_DZJJG;
        parameters[13].Value = model.N_DLSWCZ;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        //WriteLog("UPOJS", strSql.ToString(), parameters);
    }


    /// <summary>
    /// 重新设置过关注单
    /// </summary>
    /// <param name="model"></param>
    public void ReSetPassBill(KFB_PTZD model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_OPTZD set ");
        strSql.Append("N_GGJG=:N_GGJG,");
        strSql.Append("N_XZNR=:N_XZNR ,");
        strSql.Append("N_JS=:N_JS");
        strSql.Append(" where N_ID=:N_ID");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.VarChar,9),
					new OracleParameter(":N_GGJG", OracleType.Float,22),
					new OracleParameter(":N_XZNR", OracleType.VarChar,500),
                    new OracleParameter(":N_JS", OracleType.Number,4)
            };
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_GGJG;
        parameters[2].Value = model.N_XZNR;
        parameters[3].Value = model.N_JS;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        //WriteLog("UPOGG", strSql.ToString(), parameters);
    }
    /// <summary>
    /// 额度变化记录
    /// </summary>
    /// <param name="n_id"></param>
    /// <param name="n_date"></param>
    /// <param name="n_type"></param>
    /// <param name="n_uid"></param>
    /// <param name="n_creditbefer"></param>
    /// <param name="n_creitafter"></param>
    public void InsertCreditLog(int n_id, DateTime n_date, string n_type, string n_uid, decimal n_creditbefer, decimal n_creitafter)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into kfb_hycreditlog(n_id, n_date, n_type, n_uid, n_creditbefer, n_creitafter) ");
        strSql.Append("values(:n_id, :n_date, :n_type, :n_uid, :n_creditbefer, :n_creitafter)");
        OracleParameter[] parameters = {
					new OracleParameter(":n_id", OracleType.Number),
					new OracleParameter(":n_date", OracleType.DateTime),
					new OracleParameter(":n_type", OracleType.Char,1),
					new OracleParameter(":n_uid", OracleType.VarChar,50),
					new OracleParameter(":n_creditbefer", OracleType.Number),
					new OracleParameter(":n_creitafter", OracleType.Number)
            };
        parameters[0].Value = n_id;
        parameters[1].Value = n_date;
        parameters[2].Value = n_type;
        parameters[3].Value = n_uid;
        parameters[4].Value = n_creditbefer;
        parameters[5].Value = n_creitafter;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
    }
    /// <summary>
    /// 注单下注和计算记录
    /// </summary>
    /// <param name="n_id"></param>
    /// <param name="n_hyzh"></param>
    /// <param name="n_xzdh"></param>
    /// <param name="n_matchid"></param>
    /// <param name="n_syed_b"></param>
    /// <param name="n_syed_a"></param>
    /// <param name="n_xzje"></param>
    /// <param name="n_hyjg_b"></param>
    /// <param name="n_hyjg_a"></param>
    /// <param name="n_updatetime_b"></param>
    /// <param name="n_updatetime_a"></param>
    /// <param name="n_type"></param>
    public void InsertBillLog(int n_id, string n_hyzh, string n_xzdh, string n_matchid, decimal n_xzje,
        decimal n_hyjg_b, decimal n_hyjg_a, DateTime n_date, string n_type)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into kfb_ptzdlog(n_id, n_hyzh, n_xzdh, n_matchid,  n_xzje, n_hyjg_b, n_hyjg_a, n_date, n_type) ");
        strSql.Append("values(:n_id, :n_hyzh, :n_xzdh, :n_matchid, :n_xzje, :n_hyjg_b, :n_hyjg_a, :n_date, :n_type)");
        OracleParameter[] parameters = {
					new OracleParameter(":n_id", OracleType.Number),
					new OracleParameter(":n_hyzh", OracleType.VarChar,50),
					new OracleParameter(":n_xzdh", OracleType.VarChar,50),
					new OracleParameter(":n_matchid", OracleType.VarChar,1000),
					new OracleParameter(":n_xzje", OracleType.Number),
					new OracleParameter(":n_hyjg_b", OracleType.Number),
					new OracleParameter(":n_hyjg_a", OracleType.Number),
					new OracleParameter(":n_date", OracleType.DateTime),
					new OracleParameter(":n_type", OracleType.Char,1)
            };
        parameters[0].Value = n_id;
        parameters[1].Value = n_hyzh;
        parameters[2].Value = n_xzdh;
        parameters[3].Value = n_matchid;
        parameters[4].Value = n_xzje;
        parameters[5].Value = n_hyjg_b;
        parameters[6].Value = n_hyjg_a;
        parameters[7].Value = n_date;
        parameters[8].Value = n_type;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
    }

    /// <summary>
    /// 设置过关注单
    /// </summary>
    /// <param name="model"></param>
    public void SetPassBill(KFB_PTZD model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_PTZD set ");
        strSql.Append("N_GGJG=:N_GGJG,");
        strSql.Append("N_XZNR=:N_XZNR ,");
        strSql.Append("N_JS=:N_JS");
        strSql.Append(" where N_ID=:N_ID");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.VarChar,9),
					new OracleParameter(":N_GGJG", OracleType.Float,22),
					new OracleParameter(":N_XZNR", OracleType.VarChar,500),
                    new OracleParameter(":N_JS", OracleType.Number,4)
            };
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_GGJG;
        parameters[2].Value = model.N_XZNR;
        parameters[3].Value = model.N_JS;
        DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        //WriteLog("UPGG", strSql.ToString(), parameters);
    }
}
