using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class TeamDB
    {
        public DataSet GetDWbyLM()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.*,B.N_LMMC AS N_LMMC ");
            strSql.Append(" FROM KFB_DWGL A LEFT JOIN KFB_LMGL B ON A.N_NO=B.N_NO ");
            strSql.Append(" WHERE (A.N_DWMC_CN IS NULL OR A.N_DWMC_TW IS NULL) AND (A.N_QDLX=1 OR N_QDLX=4) ORDER BY A.N_QDLX,A.N_NO  ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int N_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete KFB_DWGL ");
            strSql.Append(" where N_ID=:N_ID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4)};
            parameters[0].Value = N_ID;

           return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(KFB_DWGL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_DWGL set ");
            strSql.Append("N_DWMC=:N_DWMC,N_DWMC_EN=:N_DWMC_EN,N_DWMC_CN=:N_DWMC_CN,N_DWMC_TW=:N_DWMC_TW,N_DWMC_TH=:N_DWMC_TH ");
            strSql.Append(" where  N_ID=:N_ID AND N_NO=:N_NO ");
            OracleParameter[] parameters = {
					
					new OracleParameter(":N_DWMC", OracleType.VarChar,100), 
                    new OracleParameter(":N_DWMC_EN", OracleType.NVarChar,100),
                    new OracleParameter(":N_DWMC_CN", OracleType.NVarChar,100),
                    new OracleParameter(":N_DWMC_TW", OracleType.NVarChar,100),
                    new OracleParameter(":N_DWMC_TH", OracleType.NVarChar,100),
                    new OracleParameter(":N_ID", OracleType.Number,4),
                    new OracleParameter(":N_NO", OracleType.Number,4)
            };
   
       
            parameters[0].Value = model.N_DWMC; 
            parameters[1].Value = model.N_DWMC_EN;
            parameters[2].Value = model.N_DWMC_CN;
            parameters[3].Value = model.N_DWMC_TW;
            parameters[4].Value = model.N_DWMC_TH;
            parameters[5].Value = model.N_ID;
            parameters[6].Value = model.N_NO;
           return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
    }

