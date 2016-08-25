#region Histroy
///程式代號：      SystemSetDB
///程式名稱：      SystemSetDB
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion
using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


public class UserManagementDB
{
    /// <summary>
    /// 获得管理端列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM KFB_ZHGL");
        //strSql.Append(" where N_HYDJ in " + strWhere + "and substr(n_hyzh,1,1)<'9' and substr(n_hyzh,1,1)>'0'");
        strSql.Append(" where N_HYDJ in " + strWhere);
        strSql.Append(" ORDER BY N_ID");
        return DbHelperOra.Query(strSql.ToString());
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public int Update(KFB_ZHGL model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_ZHGL set ");
        strSql.Append("N_HYZH=:N_HYZH,");
        strSql.Append("N_HYMM=:N_HYMM,");
        strSql.Append("N_HYMC=:N_HYMC,");
        strSql.Append("N_HYDJ=:N_HYDJ,");
        strSql.Append("N_XZSJ=:N_XZSJ,");
        strSql.Append("N_HYJRSJ=:N_HYJRSJ,");
        strSql.Append("N_HYXG=:N_HYXG,");
        strSql.Append("N_YXDL=:N_YXDL");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYMM", OracleType.VarChar,100),
					new OracleParameter(":N_HYMC", OracleType.VarChar,100),
					new OracleParameter(":N_HYDJ", OracleType.Number,4),
					new OracleParameter(":N_XZSJ", OracleType.DateTime),
					new OracleParameter(":N_HYJRSJ", OracleType.DateTime),
					new OracleParameter(":N_HYXG", OracleType.DateTime),
					new OracleParameter(":N_YXDL", OracleType.Number,4)};
        parameters[0].Value = model.N_HYZH;
        parameters[1].Value = model.N_HYMM;
        parameters[2].Value = model.N_HYMC;
        parameters[3].Value = model.N_HYDJ;
        parameters[4].Value = model.N_XZSJ;
        parameters[5].Value = model.N_HYJRSJ;
        parameters[6].Value = model.N_HYXG;
        parameters[7].Value = model.N_YXDL;

       return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 删除一条数据
    /// </summary>
    public int Delete(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete KFB_ZHGL ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

       return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add(KFB_ZHGL model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_ZHGL(");
        strSql.Append("N_ID,N_HYZH,N_HYMM,N_HYMC,N_HYDJ,N_XZSJ,N_HYJRSJ,N_HYXG,N_YXDL,N_DZJDH)");
        strSql.Append(" values (");
        strSql.Append("EXAMPLE_SEQ.nextval,:N_HYZH,:N_HYMM,:N_HYMC,:N_HYDJ,:N_XZSJ,:N_HYJRSJ,:N_HYXG,:N_YXDL,:N_DZJDH)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYMM", OracleType.VarChar,100),
					new OracleParameter(":N_HYMC", OracleType.VarChar,100),
					new OracleParameter(":N_HYDJ", OracleType.Number,4),
					new OracleParameter(":N_XZSJ", OracleType.DateTime),
					new OracleParameter(":N_HYJRSJ", OracleType.DateTime),
					new OracleParameter(":N_HYXG", OracleType.DateTime),
					new OracleParameter(":N_YXDL", OracleType.Number,4),
                    new OracleParameter(":N_DZJDH", OracleType.VarChar,100)
            };
        parameters[0].Value = model.N_HYZH;
        parameters[1].Value = model.N_HYMM;
        parameters[2].Value = model.N_HYMC;
        parameters[3].Value = model.N_HYDJ;
        parameters[4].Value = model.N_XZSJ;
        parameters[5].Value = model.N_HYJRSJ;
        parameters[6].Value = model.N_HYXG;
        parameters[7].Value = model.N_YXDL;
        parameters[8].Value = model.N_DZJDH;

       return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
}
