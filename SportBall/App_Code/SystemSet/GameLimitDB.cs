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

    public class GameLimitDB
    {
        /// <summary>
        /// 获取基础单场单注
        /// </summary>
        /// <returns></returns>
        public DataSet GetLimitBase()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_playtype, n_playvalue, n_courttype from kfb_limit_base order by n_order");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="playtype"></param>
        /// <param name="playvalue"></param>
        /// <param name="courtType"></param>
        public int UpdateLimitBase(string playtype, decimal playvalue, int courtType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update kfb_limit_base set n_playvalue=:n_playvalue where n_playtype = :n_playtype and n_courttype=:n_courttype");
          
            OracleParameter[] parameters = {
					new OracleParameter(":n_playtype", OracleType.VarChar,10),
					new OracleParameter(":n_playvalue", OracleType.Number,10),
					new OracleParameter(":n_courttype", OracleType.Number,10)};
            parameters[0].Value = playtype;
            parameters[1].Value = playvalue;
            parameters[2].Value = courtType;
    
           return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            
        }
        /// <summary>
        /// 获取单场单注
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public DataSet GetLimitDetail(string site)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_site, n_level, n_credit from kfb_limit_detail where n_site = :n_site order by n_level");

            OracleParameter[] parameters = {
					new OracleParameter(":n_site", OracleType.VarChar,10)};
            parameters[0].Value = site;

            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            return ds;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetSiteList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  distinct n_site from kfb_limit_detail where n_site <> 'ALL'");
            DataSet ds = new DataSet();
            ds=DbHelperOra.Query(strSql.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        /// <param name="level"></param>
        /// <param name="credit"></param>
        public int UpdateLimitDetail(string site, int level, decimal credit)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update kfb_limit_detail set n_credit = :n_credit where n_site = :n_site and n_level = :n_level");
         

            OracleParameter[] parameters = {
					new OracleParameter(":n_site", OracleType.VarChar,10),
					new OracleParameter(":n_level", OracleType.Int32,10),
					new OracleParameter(":n_credit", OracleType.Number,10)};
            parameters[0].Value = site;
            parameters[1].Value = level;
            parameters[2].Value = credit;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool ModifyLimitDetail(string strOldsite, string site, List<decimal> dCredit)
        {
            ArrayList aryLstSql = new ArrayList();
            ArrayList aryLstPa = new ArrayList();
            
         
            ArrayList arrSql = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                StringBuilder strSql = new StringBuilder();
                int level = i + 1;
                strSql.Append("update kfb_limit_detail set n_credit= :n_credit ,n_site=:n_site where n_site=:site and n_level=:n_level");
                OracleParameter[] parameters = {
					new OracleParameter(":n_credit", OracleType.Number,10),
					new OracleParameter(":n_site", OracleType.VarChar,10),
                    new OracleParameter(":site", OracleType.VarChar,10),
					new OracleParameter(":n_level", OracleType.Int32,10)};
                parameters[0].Value =  dCredit[i];
                parameters[1].Value = site;
                parameters[2].Value = site;
                parameters[3].Value = level;
                aryLstSql.Add(strSql.ToString());
                aryLstPa.Add(parameters);
            }
           return DbHelperOra.ExecuteSqlTran(aryLstSql, aryLstPa);
        }
        public bool AddLimitDetail(string site, List<decimal> dCredit)
        {
            ArrayList aryLstSql = new ArrayList();
            ArrayList aryLstPa = new ArrayList();
            ArrayList arrSql = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                StringBuilder strSql = new StringBuilder();
                int level = i + 1;
                strSql.Append("insert into kfb_limit_detail(n_site,n_level,n_credit) values(:n_site,:n_level,:n_credit) ");
                OracleParameter[] parameters = {
					new OracleParameter(":n_site", OracleType.VarChar,10),
					new OracleParameter(":n_level", OracleType.Int32,10),
                    new OracleParameter(":n_credit", OracleType.Number,10),
					};
                parameters[0].Value = site;
                parameters[1].Value = level;
                parameters[2].Value = dCredit[i]; 
                aryLstSql.Add(strSql.ToString());
                aryLstPa.Add(parameters);
           
            }
           return DbHelperOra.ExecuteSqlTran(aryLstSql, aryLstPa);
        }

    }
