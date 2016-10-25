using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


public class GameListOtherEditDB
{
    /// <summary>
    /// 得到主客隊伍
    /// </summary>
    /// <param name="i_aLM"></param>
    /// <param name="i_aLX"></param>
    /// <returns></returns>
    public DataSet GetDW(int i_aLM, int i_aLX)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_ID,N_DWMC ");
        strSql.Append(" FROM KFB_DWGL ");
        //strSql.Append(" where N_QDLX=:N_QDLX ");
        strSql.Append(" where N_NO=:N_NO ORDER BY N_DWMC");
        OracleParameter[] parameters = {
					//new OracleParameter(":N_QDLX", OracleType.Number,4),
					new OracleParameter(":N_NO", OracleType.Number,4)
            };
        //parameters[0].Value = i_aLX;
        parameters[0].Value = i_aLM;
        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 得到聯盟
    /// </summary>
    /// <param name="i_aLMLX"></param>
    /// <param name="i_aQDLX"></param>
    /// <returns></returns>
    public DataSet GetBaseBallUnion(int i_aLMLX)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_NO,N_LMMC,N_XH");
        strSql.Append(" FROM KFB_LMGL");
        strSql.Append(" where N_LX=:N_LX ORDER BY N_XH");
        OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.Number,4)
            };
        parameters[0].Value = i_aLMLX;
        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 直播管理
    /// </summary>
    /// <returns></returns>
    public DataSet GetZB()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_ID,N_ZBMC");
        strSql.Append(" FROM KFB_ZBGL");
        return DbHelperOra.Query(strSql.ToString());
    }
}
