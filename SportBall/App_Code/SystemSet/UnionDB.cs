using KingOfBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


public class UnionDB
{
    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetListLM()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_NO,N_LMMC,N_LX,N_XH,N_LEVEL,N_LMMC_EN,N_LMMC_CN,N_LMMC_TW,N_LMMC_TH ");
        strSql.Append(" FROM KFB_LMGL ");
        strSql.Append(" where (N_LMMC_TW is null or N_LMMC_CN is null) AND (N_LX=1 OR N_LX=4)");
        strSql.Append(" ORDER BY n_lx,N_LEVEL,N_XH");
        return DbHelperOra.Query(strSql.ToString());
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public int Update(KFB_LMGL model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_LMGL set ");
        strSql.Append("N_LMMC=:N_LMMC,");
        strSql.Append("N_LX=:N_LX,");
        strSql.Append("N_XH=:N_XH,");
        strSql.Append("N_LEVEL=:N_LEVEL,");
        strSql.Append("N_LMMC_EN=:N_LMMC_EN,");
        strSql.Append("N_LMMC_CN=:N_LMMC_CN,");
        strSql.Append("N_LMMC_TW=:N_LMMC_TW,");
        strSql.Append("N_LMMC_TH=:N_LMMC_TH");
        strSql.Append(" where N_NO=:N_NO  ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_NO", OracleType.Number,4),
					new OracleParameter(":N_LMMC", OracleType.VarChar,100),
					new OracleParameter(":N_LX", OracleType.Number,4),
					new OracleParameter(":N_XH", OracleType.Number,4),
					new OracleParameter(":N_LEVEL", OracleType.Number,4),
                    new OracleParameter(":N_LMMC_EN", OracleType.NVarChar,100),
                    new OracleParameter(":N_LMMC_CN", OracleType.NVarChar,100),
                    new OracleParameter(":N_LMMC_TW", OracleType.NVarChar,100),
                    new OracleParameter(":N_LMMC_TH", OracleType.NVarChar,100)
            };
        parameters[0].Value = model.N_NO;
        parameters[1].Value = model.N_LMMC;
        parameters[2].Value = model.N_LX;
        parameters[3].Value = model.N_XH;
        parameters[4].Value = model.N_LEVEL;
        parameters[5].Value = model.N_LMMC_EN;
        parameters[6].Value = model.N_LMMC_CN;
        parameters[7].Value = model.N_LMMC_TW;
        parameters[8].Value = model.N_LMMC_TH;

        return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }


    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool Delete(int N_NO)
    {

        ArrayList aryLstSql = new ArrayList();
        ArrayList aryLstPa = new ArrayList();
        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete KFB_DWGL ");
        strSql.Append(" where N_NO=:N_NO ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_NO", OracleType.Number,4)
            };
        parameters[0].Value = N_NO;
        aryLstPa.Add(parameters);
        aryLstSql.Add(strSql.ToString());
       
        StringBuilder strSql1 = new StringBuilder();
        strSql1.Append("delete KFB_LMGL ");
        strSql1.Append(" where N_NO=:N_NO ");
        OracleParameter[] parameters1 = {
					new OracleParameter(":N_NO", OracleType.Number,4)
            };
        parameters1[0].Value = N_NO;
        aryLstPa.Add(parameters1);
        aryLstSql.Add(strSql1.ToString());
    
       
        return DbHelperOra.ExecuteSqlTran(aryLstSql, aryLstPa);
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add(KFB_LMGL model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_LMGL(");
        strSql.Append("N_NO,N_LMMC,N_LX,N_XH,N_LEVEL,N_LMMC_EN,N_LMMC_CN,N_LMMC_TW,N_LMMC_TH)");
        strSql.Append(" values (");
        strSql.Append(" EXAMPLE_SEQ.nextval,:N_LMMC,:N_LX,:N_XH,:N_LEVEL,:N_LMMC_EN,:N_LMMC_CN,:N_LMMC_TW,:N_LMMC_TH)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_LMMC", OracleType.VarChar,100),
					new OracleParameter(":N_LX", OracleType.Number,4),
					new OracleParameter(":N_XH", OracleType.Number,4),
					new OracleParameter(":N_LEVEL", OracleType.Number,4),
                    new OracleParameter(":N_LMMC_EN", OracleType.NVarChar,100),
                    new OracleParameter(":N_LMMC_CN", OracleType.NVarChar,100),
                    new OracleParameter(":N_LMMC_TW", OracleType.NVarChar,100),
                    new OracleParameter(":N_LMMC_TH", OracleType.NVarChar,100)
            };
        parameters[0].Value = model.N_LMMC;
        parameters[1].Value = model.N_LX;
        parameters[2].Value = model.N_XH;
        parameters[3].Value = model.N_LEVEL;
        parameters[4].Value = model.N_LMMC_EN;
        parameters[5].Value = model.N_LMMC_CN;
        parameters[6].Value = model.N_LMMC_TW;
        parameters[7].Value = model.N_LMMC_TH;

       return  DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
}
