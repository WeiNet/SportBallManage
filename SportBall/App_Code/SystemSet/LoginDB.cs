#region Histroy
///程式代號：      LoginDB
///程式名稱：      LoginDB
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
using KingOfBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

public class LoginDB
    {



        public bool IsLogin(string strUserName, string strPw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM KFB_ZHGL");
            strSql.Append(" WHERE n_hyzh=:USERID");
            strSql.Append(" and  n_hymm=:USER_PASSWORD AND (n_hydj<4 or n_hydj>10  )");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.VarChar,100),
                    new OracleParameter(":USER_PASSWORD", OracleType.VarChar,100)
				};
            parameters[0].Value = strUserName;
            parameters[1].Value = strPw;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        internal bool checkLogin(string strUserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_DZJDH,N_HYZH,N_HYMM,N_HYMC,N_HYDJ,N_YXDL,N_YXXZ,N_HYDLCW,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_KYED,N_SYED,N_HYDLIP,N_XZSJ,N_ZQCZ,N_LQCZ,N_MZCZ,N_MBCZ,N_RBCZ,N_DLDH,N_TBCZ,N_HYJRSJ,N_XZYC,N_ZSCZ,N_HYXG,N_SMCZ,N_DLTCZ,N_CPCZ,N_LHCCZ,N_JCCZ,N_2XCZ,N_3XCZ,N_4XCZ ,N_DDSX,N_TOLLGATE,N_ADDFLAG,N_SSCZ,N_DHHM,N_MAIL,N_QQ,N_YJLX,N_SQZT,N_BQCZ,N_CQCZ from KFB_ZHGL ");
            strSql.Append(" where   N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)
            };
            parameters[0].Value = strUserName;

         
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            string isLogin = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["N_YXDL"].ToString() != "")
                {
                    isLogin = ds.Tables[0].Rows[0]["N_YXDL"].ToString();
                    return isLogin == "1" ? true : false;
                }
                else {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        public string GetLEVEL(string strUserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT n_hydj FROM KFB_ZHGL");
            strSql.Append(" WHERE n_hyzh=:USERID");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.VarChar,100)
				};
            parameters[0].Value = strUserName;
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            string strdj = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                strdj = ds.Tables[0].Rows[0][0].ToString();
            }
            return strdj;
        }

        internal bool Exists(string strid, int N_HYDJ)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KFB_XSHY");
            strSql.Append(" where N_HYZH=:N_HYZH and N_HYDJ=:N_HYDJ ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50),
					new OracleParameter(":N_HYDJ", OracleType.Number,4)
            };
            parameters[0].Value = strid;
            parameters[1].Value = N_HYDJ;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        internal void Add(KFB_XSHY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_XSHY(");
            strSql.Append("N_HYZH,N_HYDJ,N_HYIP,N_DLSJ,N_SYSJ)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_HYDJ,:N_HYIP,:N_DLSJ,:N_SYSJ)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYDJ", OracleType.Number,4),
					new OracleParameter(":N_HYIP", OracleType.VarChar,50),
					new OracleParameter(":N_DLSJ", OracleType.DateTime),
					new OracleParameter(":N_SYSJ", OracleType.DateTime)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_HYDJ;
            parameters[2].Value = model.N_HYIP;
            parameters[3].Value = model.N_DLSJ;
            parameters[4].Value = model.N_SYSJ;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        internal void Update(KFB_XSHY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_XSHY set ");
            strSql.Append("N_HYIP=:N_HYIP,");
            strSql.Append("N_DLSJ=:N_DLSJ,");
            strSql.Append("N_SYSJ=:N_SYSJ");
            strSql.Append(" where N_HYZH=:N_HYZH and N_HYDJ=:N_HYDJ ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYDJ", OracleType.Number,4),
					new OracleParameter(":N_HYIP", OracleType.VarChar,50),
					new OracleParameter(":N_DLSJ", OracleType.DateTime),
					new OracleParameter(":N_SYSJ", OracleType.DateTime)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_HYDJ;
            parameters[2].Value = model.N_HYIP;
            parameters[3].Value = model.N_DLSJ;
            parameters[4].Value = model.N_SYSJ;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }


        internal void addDLIP(KFB_DLIP model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_DLIP(  ");
            strSql.Append("N_HYZH,N_HYIP,N_CGCS,N_SPCS,N_ZJDLSJ,N_HYDJ)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_HYIP,:N_CGCS,:N_SPCS,:N_ZJDLSJ,:N_HYDJ)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYIP", OracleType.VarChar,50),
					new OracleParameter(":N_CGCS", OracleType.Number,4),
					new OracleParameter(":N_SPCS", OracleType.Number,4),
					new OracleParameter(":N_ZJDLSJ", OracleType.DateTime),
                    new OracleParameter(":N_HYDJ", OracleType.VarChar,4)
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_HYIP;
            parameters[2].Value = model.N_CGCS;
            parameters[3].Value = model.N_SPCS;
            parameters[4].Value = model.N_ZJDLSJ;
            parameters[5].Value = model.N_HYDJ;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
    }
