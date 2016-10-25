using KingOfBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class AgentManageDB
    {
        private KFB_HYGLDB mo_KFB_HYGL = new KFB_HYGLDB();
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KFB_ZHGL GetModel(string N_HYZH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_DZJDH,N_HYZH,N_HYMM,N_HYMC,N_HYDJ,N_YXDL,N_YXXZ,N_HYDLCW,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_KYED,N_SYED,N_HYDLIP,N_XZSJ,N_ZQCZ,N_LQCZ,N_MZCZ,N_MBCZ,N_RBCZ,N_DLDH,N_TBCZ,N_HYJRSJ,N_XZYC,N_ZSCZ,N_HYXG,N_SMCZ,N_DLTCZ,N_CPCZ,N_LHCCZ,N_JCCZ,N_2XCZ,N_3XCZ,N_4XCZ ,N_DDSX,N_TOLLGATE,N_ADDFLAG,N_SSCZ,N_DHHM,N_MAIL,N_QQ,N_YJLX,N_SQZT,N_BQCZ,N_CQCZ from KFB_ZHGL ");
            strSql.Append(" where   N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)
            };
            parameters[0].Value = N_HYZH;

          KFB_ZHGL model = new KFB_ZHGL();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["N_ID"].ToString() != "")
                {
                    model.N_ID = int.Parse(ds.Tables[0].Rows[0]["N_ID"].ToString());
                }
                model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
                model.N_HYMM = ds.Tables[0].Rows[0]["N_HYMM"].ToString();
                model.N_HYMC = ds.Tables[0].Rows[0]["N_HYMC"].ToString();
                if (ds.Tables[0].Rows[0]["N_DDSX"].ToString() != "")
                {
                    model.N_DDSX = float.Parse(ds.Tables[0].Rows[0]["N_DDSX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYDJ"].ToString() != "")
                {
                    model.N_HYDJ = int.Parse(ds.Tables[0].Rows[0]["N_HYDJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DZJDH"].ToString() != "")
                {
                    model.N_DZJDH = ds.Tables[0].Rows[0]["N_DZJDH"].ToString();
                }
                if (ds.Tables[0].Rows[0]["N_YXDL"].ToString() != "")
                {
                    model.N_YXDL = int.Parse(ds.Tables[0].Rows[0]["N_YXDL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YXXZ"].ToString() != "")
                {
                    model.N_YXXZ = int.Parse(ds.Tables[0].Rows[0]["N_YXXZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYDLCW"].ToString() != "")
                {
                    model.N_HYDLCW = int.Parse(ds.Tables[0].Rows[0]["N_HYDLCW"].ToString());
                }
                model.N_ZJDH = ds.Tables[0].Rows[0]["N_ZJDH"].ToString();
                model.N_DGDDH = ds.Tables[0].Rows[0]["N_DGDDH"].ToString();
                model.N_GDDH = ds.Tables[0].Rows[0]["N_GDDH"].ToString();
                model.N_ZDLDH = ds.Tables[0].Rows[0]["N_ZDLDH"].ToString();
                if (ds.Tables[0].Rows[0]["N_KYED"].ToString() != "")
                {
                    model.N_KYED = decimal.Parse(ds.Tables[0].Rows[0]["N_KYED"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SYED"].ToString() != "")
                {
                    model.N_SYED = decimal.Parse(ds.Tables[0].Rows[0]["N_SYED"].ToString());
                }
                model.N_HYDLIP = ds.Tables[0].Rows[0]["N_HYDLIP"].ToString();
                if (ds.Tables[0].Rows[0]["N_XZSJ"].ToString() != "")
                {
                    model.N_XZSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_XZSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZQCZ"].ToString() != "")
                {
                    model.N_ZQCZ = int.Parse(ds.Tables[0].Rows[0]["N_ZQCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_LQCZ"].ToString() != "")
                {
                    model.N_LQCZ = int.Parse(ds.Tables[0].Rows[0]["N_LQCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_MZCZ"].ToString() != "")
                {
                    model.N_MZCZ = int.Parse(ds.Tables[0].Rows[0]["N_MZCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_MBCZ"].ToString() != "")
                {
                    model.N_MBCZ = int.Parse(ds.Tables[0].Rows[0]["N_MBCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_RBCZ"].ToString() != "")
                {
                    model.N_RBCZ = int.Parse(ds.Tables[0].Rows[0]["N_RBCZ"].ToString());
                }
                model.N_DLDH = ds.Tables[0].Rows[0]["N_DLDH"].ToString();
                if (ds.Tables[0].Rows[0]["N_TBCZ"].ToString() != "")
                {
                    model.N_TBCZ = int.Parse(ds.Tables[0].Rows[0]["N_TBCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYJRSJ"].ToString() != "")
                {
                    model.N_HYJRSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_HYJRSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_XZYC"].ToString() != "")
                {
                    model.N_XZYC = int.Parse(ds.Tables[0].Rows[0]["N_XZYC"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZSCZ"].ToString() != "")
                {
                    model.N_ZSCZ = int.Parse(ds.Tables[0].Rows[0]["N_ZSCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYXG"].ToString() != "")
                {
                    model.N_HYXG = DateTime.Parse(ds.Tables[0].Rows[0]["N_HYXG"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SMCZ"].ToString() != "")
                {
                    model.N_SMCZ = int.Parse(ds.Tables[0].Rows[0]["N_SMCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DLTCZ"].ToString() != "")
                {
                    model.N_DLTCZ = int.Parse(ds.Tables[0].Rows[0]["N_DLTCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_CPCZ"].ToString() != "")
                {
                    model.N_CPCZ = int.Parse(ds.Tables[0].Rows[0]["N_CPCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_LHCCZ"].ToString() != "")
                {
                    model.N_LHCCZ = int.Parse(ds.Tables[0].Rows[0]["N_LHCCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JCCZ"].ToString() != "")
                {
                    model.N_JCCZ = int.Parse(ds.Tables[0].Rows[0]["N_JCCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_2XCZ"].ToString() != "")
                {
                    model.N_2XCZ = int.Parse(ds.Tables[0].Rows[0]["N_2XCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_3XCZ"].ToString() != "")
                {
                    model.N_3XCZ = int.Parse(ds.Tables[0].Rows[0]["N_3XCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_4XCZ"].ToString() != "")
                {
                    model.N_4XCZ = int.Parse(ds.Tables[0].Rows[0]["N_4XCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_TOLLGATE"].ToString() != "")
                {
                    model.N_TOLLGATE = int.Parse(ds.Tables[0].Rows[0]["N_TOLLGATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ADDFLAG"].ToString() != "")
                {
                    model.N_ADDFLAG = ds.Tables[0].Rows[0]["N_ADDFLAG"].ToString();
                }
                if (ds.Tables[0].Rows[0]["N_SSCZ"].ToString() != "")
                {
                    model.N_SSCZ = int.Parse(ds.Tables[0].Rows[0]["N_SSCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_BQCZ"].ToString() != "")
                {
                    model.N_BQCZ = int.Parse(ds.Tables[0].Rows[0]["N_BQCZ"].ToString());
                }

                if (ds.Tables[0].Rows[0]["N_CQCZ"].ToString() != "")
                {
                    model.N_CQCZ = int.Parse(ds.Tables[0].Rows[0]["N_CQCZ"].ToString());
                }

                model.N_DHHM = ds.Tables[0].Rows[0]["N_DHHM"].ToString();
                model.N_MAIL = ds.Tables[0].Rows[0]["N_MAIL"].ToString();
                model.N_QQ = ds.Tables[0].Rows[0]["N_QQ"].ToString();
                if (ds.Tables[0].Rows[0]["N_YJLX"].ToString() != "")
                {
                    model.N_YJLX = int.Parse(ds.Tables[0].Rows[0]["N_YJLX"].ToString());
                }
                model.N_SQZT = ds.Tables[0].Rows[0]["N_SQZT"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KFB_HYGL GetModelHYGL(string N_HYZH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from KFB_HYGL ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100)};
            parameters[0].Value = N_HYZH;

            KFB_HYGL model = new KFB_HYGL();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["N_ID"].ToString() != "")
                {
                    model.N_ID = int.Parse(ds.Tables[0].Rows[0]["N_ID"].ToString());
                }
                model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
                model.N_HYMM = ds.Tables[0].Rows[0]["N_HYMM"].ToString();
                model.N_HYMC = ds.Tables[0].Rows[0]["N_HYMC"].ToString();
                if (ds.Tables[0].Rows[0]["N_KYED"].ToString() != "")
                {
                    model.N_KYED = decimal.Parse(ds.Tables[0].Rows[0]["N_KYED"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SYED"].ToString() != "")
                {
                    model.N_SYED = decimal.Parse(ds.Tables[0].Rows[0]["N_SYED"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_WXDJ"].ToString() != "")
                {
                    model.N_WXDJ = int.Parse(ds.Tables[0].Rows[0]["N_WXDJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YXDL"].ToString() != "")
                {
                    model.N_YXDL = int.Parse(ds.Tables[0].Rows[0]["N_YXDL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YXXZ"].ToString() != "")
                {
                    model.N_YXXZ = int.Parse(ds.Tables[0].Rows[0]["N_YXXZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DLSJ"].ToString() != "")
                {
                    model.N_DLSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_DLSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YCXZ"].ToString() != "")
                {
                    model.N_YCXZ = int.Parse(ds.Tables[0].Rows[0]["N_YCXZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DZXX"].ToString() != "")
                {
                    model.N_DZXX = decimal.Parse(ds.Tables[0].Rows[0]["N_DZXX"].ToString());
                }
                model.N_DZJDH = ds.Tables[0].Rows[0]["N_DZJDH"].ToString();
                model.N_ZJDH = ds.Tables[0].Rows[0]["N_ZJDH"].ToString();
                model.N_DGDDH = ds.Tables[0].Rows[0]["N_DGDDH"].ToString();
                model.N_GDDH = ds.Tables[0].Rows[0]["N_GDDH"].ToString();
                model.N_ZDLDH = ds.Tables[0].Rows[0]["N_ZDLDH"].ToString();
                model.N_DLDH = ds.Tables[0].Rows[0]["N_DLDH"].ToString();
                if (ds.Tables[0].Rows[0]["N_LQTZ"].ToString() != "")
                {
                    model.N_LQTZ = int.Parse(ds.Tables[0].Rows[0]["N_LQTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_MBTZ"].ToString() != "")
                {
                    model.N_MBTZ = int.Parse(ds.Tables[0].Rows[0]["N_MBTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_RBTZ"].ToString() != "")
                {
                    model.N_RBTZ = int.Parse(ds.Tables[0].Rows[0]["N_RBTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZQTZ"].ToString() != "")
                {
                    model.N_ZQTZ = int.Parse(ds.Tables[0].Rows[0]["N_ZQTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_MZTZ"].ToString() != "")
                {
                    model.N_MZTZ = int.Parse(ds.Tables[0].Rows[0]["N_MZTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_CWCS"].ToString() != "")
                {
                    model.N_CWCS = int.Parse(ds.Tables[0].Rows[0]["N_CWCS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_XZSJ"].ToString() != "")
                {
                    model.N_XZSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_XZSJ"].ToString());
                }
                model.N_HYIP = ds.Tables[0].Rows[0]["N_HYIP"].ToString();
                if (ds.Tables[0].Rows[0]["N_TBTZ"].ToString() != "")
                {
                    model.N_TBTZ = int.Parse(ds.Tables[0].Rows[0]["N_TBTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYJR"].ToString() != "")
                {
                    model.N_HYJR = DateTime.Parse(ds.Tables[0].Rows[0]["N_HYJR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZSTZ"].ToString() != "")
                {
                    model.N_ZSTZ = int.Parse(ds.Tables[0].Rows[0]["N_ZSTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_XGSJ"].ToString() != "")
                {
                    model.N_XGSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_XGSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SMTZ"].ToString() != "")
                {
                    model.N_SMTZ = int.Parse(ds.Tables[0].Rows[0]["N_SMTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_CPTZ"].ToString() != "")
                {
                    model.N_CPTZ = int.Parse(ds.Tables[0].Rows[0]["N_CPTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DLTTZ"].ToString() != "")
                {
                    model.N_DLTTZ = int.Parse(ds.Tables[0].Rows[0]["N_DLTTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_LHCTZ"].ToString() != "")
                {
                    model.N_LHCTZ = int.Parse(ds.Tables[0].Rows[0]["N_LHCTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JCTZ"].ToString() != "")
                {
                    model.N_JCTZ = int.Parse(ds.Tables[0].Rows[0]["N_JCTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_TOLLGATE"].ToString() != "")
                {
                    model.N_TOLLGATE = int.Parse(ds.Tables[0].Rows[0]["N_TOLLGATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZJXZSJ"].ToString() != "")
                {
                    model.N_ZJXZSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_ZJXZSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SSTZ"].ToString() != "")
                {
                    model.N_SSTZ = int.Parse(ds.Tables[0].Rows[0]["N_SSTZ"].ToString());
                }

                if (ds.Tables[0].Rows[0]["N_BQTZ"].ToString() != "")
                {
                    model.N_BQTZ = int.Parse(ds.Tables[0].Rows[0]["N_BQTZ"].ToString());
                }

                if (ds.Tables[0].Rows[0]["N_CQTZ"].ToString() != "")
                {
                    model.N_CQTZ = int.Parse(ds.Tables[0].Rows[0]["N_CQTZ"].ToString());
                }

                model.N_TKYZM = ds.Tables[0].Rows[0]["N_TKYZM"].ToString();
                model.N_HBDM = ds.Tables[0].Rows[0]["N_HBDM"].ToString();
                model.N_DHHM = ds.Tables[0].Rows[0]["N_DHHM"].ToString();
                model.N_MAIL = ds.Tables[0].Rows[0]["N_MAIL"].ToString();
                model.N_QQ = ds.Tables[0].Rows[0]["N_QQ"].ToString();
                model.N_DLDH = ds.Tables[0].Rows[0]["N_DLDH"].ToString();
                model.N_SFSW = ds.Tables[0].Rows[0]["N_SFSW"].ToString();
                model.N_SQZT = ds.Tables[0].Rows[0]["N_SQZT"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得總監，大股東。。
        /// </summary>
        public DataSet GetMember(string strlv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_hyzh,n_hymc ");
            strSql.Append(" FROM KFB_ZHGL ");
            strSql.Append(" where 1=1 and  ");
            strSql.Append(" n_hydj=:strlv  ");
            OracleParameter[] parameters = {
					new OracleParameter(":strlv", OracleType.Number,4)
				};
            parameters[0].Value = strlv;
            return KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得下級成員數
        /// </summary>
        public DataSet GetMember(string strlv, string strname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KFB_ZHGL ");
            strSql.Append(" where 1=1 and  ");
            strSql.Append(" n_hydj=:strlv   ");
            if (!strname.Equals(""))
            {
                if (strlv.Equals("5"))
                {
                    strSql.Append(" and  n_dzjdh='" + strname + "'  ");
                }
                else if (strlv.Equals("6"))
                {
                    strSql.Append(" and n_zjdh='" + strname + "'  ");
                }
                else if (strlv.Equals("7"))
                {
                    strSql.Append("and  n_dgddh='" + strname + "'  ");
                }
                else if (strlv.Equals("8"))
                {
                    strSql.Append(" and n_gddh='" + strname + "' ");
                }
                else if (strlv.Equals("9"))
                {
                    strSql.Append(" and  n_zdldh='" + strname + "'  ");
                }
            }
            else
            {
                // strSql.Append(" (n_hydlip=:strname or 1=1) ");
                strSql.Append(" and  '4'='" + strlv + "' ");

            }
            strSql.Append(" order by length(n_hyzh) , N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":strlv", OracleType.Number,4)
				};
            parameters[0].Value = strlv;
            DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
            return GetDS;
        }
        /// <summary>
        /// 获得某一級成員數
        /// </summary>
        public DataSet GetMember(string strlv, string strlvsj, string strname)
        {
            //strname = strname.Replace("=","-");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            if (strlv.Equals("10"))
                strSql.Append(" FROM KFB_HYGL ");
            else
                strSql.Append(" FROM KFB_ZHGL ");
            strSql.Append(" where 1=1 and  ");
            if (!strlv.Equals("10"))
                strSql.Append(" n_hydj=:strlv   ");
            else
                strSql.Append(" 10=:strlv   ");
            if (!strname.Equals(""))
            {
                if (strlvsj.Equals("4"))
                {
                    strSql.Append(" and  n_dzjdh='" + strname + "'  ");
                }
                else if (strlvsj.Equals("5"))
                {
                    strSql.Append(" and n_zjdh='" + strname + "'  ");
                }
                else if (strlvsj.Equals("6"))
                {
                    strSql.Append("and  n_dgddh='" + strname + "'  ");
                }
                else if (strlvsj.Equals("7"))
                {
                    strSql.Append(" and n_gddh='" + strname + "' ");
                }
                else if (strlvsj.Equals("8"))
                {
                    strSql.Append(" and  n_zdldh='" + strname + "'  ");
                }
                else if (strlvsj.Equals("9"))
                {
                    strSql.Append(" and  n_dldh='" + strname + "'  ");
                }
            }

            strSql.Append(" order by length(n_hyzh) , N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":strlv", OracleType.Number,4)
				};
            parameters[0].Value = strlv;
            DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
            return GetDS;
        }

        public void NoLogZH(string strdjdh, string strid, string stryxdl, Hashtable o_aHt)
        {
            string strname = "";
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" update kfb_zhgl set n_yxdl=:n_yxdl where " + strdjdh + "='" + strid + "'");

            OracleParameter[] parameters = {
                    new OracleParameter(":n_yxdl", OracleType.VarChar,100)                            
            };
            parameters[0].Value = stryxdl;
            // DbHelperOra.ExecuteSql(strSqlup.ToString(), parameters);    
            o_aHt.Add(strSqlup.ToString(), parameters);
        }
        /// <summary>
        /// 判斷各級是否有注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetZD(string s_aHYZH, string s_aZHlvl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_ptzd ");
            strSql.Append(" where " + s_aZHlvl + " ='" + s_aHYZH + "'");
            strSql.Append(" and rownum < 2  ");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }
        /// 判斷各級的會員是否有注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetHYZD(string s_aHYZH, string s_aZHlvl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_ptzd ");
            strSql.Append(" where n_hydh in (select n_hyzh from kfb_hygl where " + s_aZHlvl + " ='" + s_aHYZH + "')");
            strSql.Append(" and rownum < 2  ");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 判斷各級是否有已過帳注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetOZD(string s_aHYZH, string s_aZHlvl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_optzd ");
            strSql.Append(" where " + s_aZHlvl + " ='" + s_aHYZH + "'");
            strSql.Append(" and rownum < 2  ");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 判斷各級的會員是否有已過帳注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetOHYZD(string s_aHYZH, string s_aZHlvl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_optzd ");
            strSql.Append(" where n_hydh in (select n_hyzh from kfb_hygl where " + s_aZHlvl + " ='" + s_aHYZH + "')");
            strSql.Append(" and rownum < 2  ");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KFB_ZHGL");
            strSql.Append(" where   N_HYZH=:N_HYZH  ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)
		 };
            parameters[0].Value = N_HYZH;


            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        public void UpSJED(KFB_ZHGL mo_zhgl)
        {
            if (mo_zhgl.N_HYDJ > 4)
            {
                string strn_hyzh = "";
                switch (mo_zhgl.N_HYDJ.ToString())
                {
                    case "5": strn_hyzh = mo_zhgl.N_DZJDH; break;
                    case "6": strn_hyzh = mo_zhgl.N_ZJDH; break;
                    case "7": strn_hyzh = mo_zhgl.N_DGDDH; break;
                    case "8": strn_hyzh = mo_zhgl.N_GDDH; break;
                    case "9": strn_hyzh = mo_zhgl.N_ZDLDH; break;
                }
                StringBuilder strSqlup = new StringBuilder();
                strSqlup.Append(" update kfb_zhgl set n_syed=(n_syed+(select N_KYED from kfb_zhgl where n_hyzh='" + mo_zhgl.N_HYZH + "' ))  where n_hyzh=:n_hyzh ");

                OracleParameter[] parametersup = {
                        new OracleParameter(":n_hyzh", OracleType.VarChar,100)

				    };
                parametersup[0].Value = strn_hyzh;
                DbHelperOra.ExecuteSql(strSqlup.ToString(), parametersup);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteAll(string N_HYZH, string N_HYLVL)
        {

            StringBuilder strSqlZH = new StringBuilder();
            strSqlZH.Append("delete KFB_ZHGL ");
            strSqlZH.Append(" where " + N_HYLVL + "=:N_HYZH ");
            OracleParameter[] parameterszh = {
				new OracleParameter(":N_HYZH", OracleType.VarChar,100)
            };
            parameterszh[0].Value = N_HYZH;
            DbHelperOra.ExecuteSql(strSqlZH.ToString(), parameterszh);

            StringBuilder strSqlHY = new StringBuilder();
            strSqlHY.Append("delete KFB_HYGL ");
            strSqlHY.Append(" where " + N_HYLVL + "=:N_HYZH ");
            OracleParameter[] parametershy = {
				new OracleParameter(":N_HYZH", OracleType.VarChar,100)
            };
            parametershy[0].Value = N_HYZH;
            DbHelperOra.ExecuteSql(strSqlHY.ToString(), parametershy);
        }
        public void NoLogHY(string strdjdh, string strid, string stryxdl, Hashtable o_aHt)
        {
            string strname = "";
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" update kfb_hygl set n_yxdl=:n_yxdl where " + strdjdh + "='" + strid + "'");

            OracleParameter[] parameters = {
                    new OracleParameter(":n_yxdl", OracleType.VarChar,100)                            
            };
            parameters[0].Value = stryxdl;
            // DbHelperOra.ExecuteSql(strSqlup.ToString(), parameters);
            o_aHt.Add(strSqlup.ToString(), parameters);
        }
        public void NoXZZH(string strdjdh, string strid, string stryxxz, Hashtable o_aHt)
        {
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" update kfb_zhgl set n_yxxz=:n_yxxz where " + strdjdh + "='" + strid + "'");

            OracleParameter[] parameters = {
                    new OracleParameter(":n_yxxz", OracleType.Number,4)                            
            };
            parameters[0].Value = stryxxz;
            // DbHelperOra.ExecuteSql(strSqlup.ToString(), parameters);    
            o_aHt.Add(strSqlup.ToString(), parameters);
        }
   
        #region"禁止會員下注"
        public void NoXZHY(string strdjdh, string strid, string stryxxz, Hashtable o_aHt)
        {
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" update kfb_hygl set n_yxxz=:n_yxxz where " + strdjdh + "='" + strid + "'");

            OracleParameter[] parameters = {
                    new OracleParameter(":n_yxxz", OracleType.Number,4)                            
            };
            parameters[0].Value = stryxxz;
            // DbHelperOra.ExecuteSql(strSqlup.ToString(), parameters);
            o_aHt.Add(strSqlup.ToString(), parameters);
        }

        #endregion
        /// <summary>
        /// 更新多筆数据
        /// </summary>
        public void UpdateHT(Hashtable o_aHt)
        {

            DbHelperOra.ExecuteSqlTran(o_aHt);
        }
        /// <summary>
        ///根據帳號去信用額度
        /// </summary>
        public string Getxyed(string strzh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("   select n_kyed from KFB_ZHGL  where n_hyzh=:n_hyzh  ");
            OracleParameter[] parameters = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100)
				};
            parameters[0].Value = strzh;
            return KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        ///根據帳號去剩余額度
        /// </summary>
        public string Getsyed(string strzh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("   select n_syed from KFB_ZHGL  where n_hyzh=:n_hyzh  ");
            OracleParameter[] parameters = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100)
				};
            parameters[0].Value = strzh;
            return KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString();
        }

        public string GetHY(string strLv)
        {
            string strReturn = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT n_hyzh FROM kfb_zhgl");
            strSql.Append(" WHERE n_hydj=:strLv");
            OracleParameter[] parameters = {
					new OracleParameter(":strLv", OracleType.Number,4)
				};
            parameters[0].Value = Convert.ToInt32(strLv);
            DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
            for (int i = 0; i < GetDS.Tables[0].Rows.Count; i++)
            {
                strReturn = strReturn + GetDS.Tables[0].Rows[i][0].ToString() + ",";
            }
            return strReturn;
        }
        /// <summary>
        /// 获得同一总监下級成員數
        /// </summary>
        public DataSet GetZJXCY(string strlv, string strname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KFB_ZHGL ");
            strSql.Append(" where 1=1 and  ");
            // strSql.Append(" n_hydj=:strlv  and n_dzjdh=:strname" );
            strSql.Append(" n_hydj=:strlv  ");
            OracleParameter[] parameters = {
					new OracleParameter(":strlv", OracleType.Number,4),
                   // new OracleParameter(":strname", OracleType.VarChar,100)
				};
            parameters[0].Value = strlv;
            //  parameters[1].Value = strname;
            DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
            return GetDS;
        }
        public void DelZHSetUP(string strtb, string strcolname, string strname)
        {
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" delete  from " + strtb + " where " + strcolname + "='" + strname + "'");

            DbHelperOra.ExecuteSql(strSqlup.ToString());
        }
       
        /// <summary>
        /// 是否存在下线
        /// </summary>
        public bool Exists(int ilv, string strVN)
        {
            string strCN = "";
            switch (ilv)
            {
                case 4: strCN = "N_DZJDH"; break;
                case 5: strCN = "N_ZJDH"; break;
                case 6: strCN = "N_DGDDH"; break;
                case 7: strCN = "N_GDDH"; break;
                case 8: strCN = "N_ZDLDH"; break;
                case 9: strCN = "N_DLDH"; break;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(sums) sumd from ( ");
            strSql.Append(" select count(1) sums from kfb_zhgl where  " + strCN + "='" + strVN + "' AND n_hyzh!='" + strVN + "' ");
            strSql.Append(" union ");
            strSql.Append(" select count(1) sums from kfb_hygl  where  " + strCN + "='" + strVN + "' AND n_hyzh!='" + strVN + "' )");

            return DbHelperOra.Exists(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KFB_ZHGL model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_ZHGL set ");
            strSql.Append("N_HYMM=:N_HYMM,");
            strSql.Append("N_HYMC=:N_HYMC,");
            strSql.Append("N_HYDJ=:N_HYDJ,");
            strSql.Append("N_YXDL=:N_YXDL,");
            strSql.Append("N_YXXZ=:N_YXXZ,");
            //strSql.Append("N_HYDLCW=:N_HYDLCW,");
            strSql.Append("N_ZJDH=:N_ZJDH,");
            strSql.Append("N_DGDDH=:N_DGDDH,");
            strSql.Append("N_GDDH=:N_GDDH,");
            strSql.Append("N_ZDLDH=:N_ZDLDH,");
            strSql.Append("N_KYED=:N_KYED,");
            strSql.Append("N_SYED=:N_SYED,");
            //strSql.Append("N_HYDLIP=:N_HYDLIP,");
            //strSql.Append("N_XZSJ=:N_XZSJ,");
            strSql.Append("N_ZQCZ=:N_ZQCZ,");
            strSql.Append("N_LQCZ=:N_LQCZ,");
            strSql.Append("N_MZCZ=:N_MZCZ,");
            strSql.Append("N_MBCZ=:N_MBCZ,");
            strSql.Append("N_RBCZ=:N_RBCZ,");
            strSql.Append("N_DLDH=:N_DLDH,");
            strSql.Append("N_TBCZ=:N_TBCZ,");
            strSql.Append("N_HYJRSJ=:N_HYJRSJ,");
            strSql.Append("N_XZYC=:N_XZYC,");
            strSql.Append("N_ZSCZ=:N_ZSCZ,");
            strSql.Append("N_HYXG=:N_HYXG,");
            strSql.Append("N_SMCZ=:N_SMCZ,");
            strSql.Append("N_DLTCZ=:N_DLTCZ,");
            strSql.Append("N_CPCZ=:N_CPCZ,");
            strSql.Append("N_LHCCZ=:N_LHCCZ,");
            strSql.Append("N_JCCZ=:N_JCCZ,");
            strSql.Append("N_2XCZ=:N_2XCZ,");
            strSql.Append("N_3XCZ=:N_3XCZ,");
            strSql.Append("N_4XCZ=:N_4XCZ,");
            strSql.Append("N_DZJDH=:N_DZJDH,");
            strSql.Append("N_DDSX=:N_DDSX,");
            strSql.Append("N_TOLLGATE=:N_TOLLGATE,");
            strSql.Append("N_SSCZ=:N_SSCZ,");
            strSql.Append("N_DHHM=:N_DHHM,");
            strSql.Append("N_MAIL=:N_MAIL,");
            strSql.Append("N_QQ=:N_QQ, ");
            strSql.Append("N_BQCZ=:N_BQCZ, ");
            strSql.Append("N_CQCZ=:N_CQCZ ");
            strSql.Append(" where N_ID=:N_ID and N_HYZH=:N_HYZH  ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,9),
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYMM", OracleType.VarChar,100),
					new OracleParameter(":N_HYMC", OracleType.VarChar,100),
					new OracleParameter(":N_HYDJ", OracleType.Number,4),
					new OracleParameter(":N_YXDL", OracleType.Number,4),
					//new OracleParameter(":N_HYDLCW", OracleType.Number,4),
					new OracleParameter(":N_ZJDH", OracleType.VarChar,100),
					new OracleParameter(":N_DGDDH", OracleType.VarChar,100),
					new OracleParameter(":N_GDDH", OracleType.VarChar,100),
					new OracleParameter(":N_ZDLDH", OracleType.VarChar,100),
					new OracleParameter(":N_KYED", OracleType.Float,22),
					new OracleParameter(":N_SYED", OracleType.Float,22),
                    //new OracleParameter(":N_HYDLIP", OracleType.VarChar,1000),
					//new OracleParameter(":N_XZSJ", OracleType.DateTime),
					new OracleParameter(":N_ZQCZ", OracleType.Number,4),
					new OracleParameter(":N_LQCZ", OracleType.Number,4),
					new OracleParameter(":N_MZCZ", OracleType.Number,4),
					new OracleParameter(":N_MBCZ", OracleType.Number,4),
					new OracleParameter(":N_RBCZ", OracleType.Number,4),
					new OracleParameter(":N_DLDH", OracleType.VarChar,100),
					new OracleParameter(":N_TBCZ", OracleType.Number,4),
					new OracleParameter(":N_HYJRSJ", OracleType.DateTime),
					new OracleParameter(":N_XZYC", OracleType.Number,4),
					new OracleParameter(":N_ZSCZ", OracleType.Number,4),
					new OracleParameter(":N_HYXG", OracleType.DateTime),
					new OracleParameter(":N_SMCZ", OracleType.Number,4),
					new OracleParameter(":N_DLTCZ", OracleType.Number,4),
					new OracleParameter(":N_CPCZ", OracleType.Number,4),
					new OracleParameter(":N_LHCCZ", OracleType.Number,4),
					new OracleParameter(":N_JCCZ", OracleType.Number,4),
					new OracleParameter(":N_2XCZ", OracleType.Number,4),
					new OracleParameter(":N_3XCZ", OracleType.Number,4),
					new OracleParameter(":N_4XCZ", OracleType.Number,4),
                    new OracleParameter(":N_DZJDH", OracleType.VarChar,100),
                    new OracleParameter(":N_DDSX", OracleType.Float,8),
                    new OracleParameter(":N_TOLLGATE",OracleType.Int32,4),
                    new OracleParameter(":N_YXXZ", OracleType.Number,4),
                    new OracleParameter(":N_SSCZ", OracleType.Number,4),
					new OracleParameter(":N_DHHM", OracleType.VarChar,50),
					new OracleParameter(":N_MAIL", OracleType.VarChar,50),
					new OracleParameter(":N_QQ", OracleType.VarChar,50),
                new OracleParameter(":N_BQCZ", OracleType.VarChar,50),
                new OracleParameter(":N_CQCZ", OracleType.VarChar,50)
            };
            parameters[0].Value = model.N_ID;
            parameters[1].Value = model.N_HYZH;
            parameters[2].Value = model.N_HYMM;
            parameters[3].Value = model.N_HYMC;
            parameters[4].Value = model.N_HYDJ;
            parameters[5].Value = model.N_YXDL;
            //parameters[6].Value = model.N_HYDLCW;
            parameters[6].Value = model.N_ZJDH;
            parameters[7].Value = model.N_DGDDH;
            parameters[8].Value = model.N_GDDH;
            parameters[9].Value = model.N_ZDLDH;
            parameters[10].Value = model.N_KYED;
            parameters[11].Value = model.N_SYED;
            //parameters[12].Value = model.N_HYDLIP;
            //parameters[14].Value = model.N_XZSJ;
            parameters[12].Value = model.N_ZQCZ;
            parameters[13].Value = model.N_LQCZ;
            parameters[14].Value = model.N_MZCZ;
            parameters[15].Value = model.N_MBCZ;
            parameters[16].Value = model.N_RBCZ;
            parameters[17].Value = model.N_DLDH;
            parameters[18].Value = model.N_TBCZ;
            parameters[19].Value = model.N_HYJRSJ;
            parameters[20].Value = model.N_XZYC;
            parameters[21].Value = model.N_ZSCZ;
            parameters[22].Value = model.N_HYXG;
            parameters[23].Value = model.N_SMCZ;
            parameters[24].Value = model.N_DLTCZ;
            parameters[25].Value = model.N_CPCZ;
            parameters[26].Value = model.N_LHCCZ;
            parameters[27].Value = model.N_JCCZ;
            parameters[28].Value = model.N_2XCZ;
            parameters[29].Value = model.N_3XCZ;
            parameters[30].Value = model.N_4XCZ;
            parameters[31].Value = model.N_DZJDH;
            parameters[32].Value = model.N_DDSX;
            parameters[33].Value = model.N_TOLLGATE;
            parameters[34].Value = model.N_YXXZ;
            parameters[35].Value = model.N_SSCZ;
            parameters[36].Value = model.N_DHHM;
            parameters[37].Value = model.N_MAIL;
            parameters[38].Value = model.N_QQ;

            parameters[39].Value = model.N_BQCZ;
            parameters[40].Value = model.N_CQCZ;
            //	DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根據代理商過關關數限制修改會員關數上限
        /// </summary>
        /// <param name="N_DLZH">代理商帳號</param>
        /// <param name="N_TOLLGATE">關數限制上限值</param>
        public void UpdateTOLLGATE(string N_DLZH, string N_TOLLGATE, Hashtable htab)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" UPDATE KFB_HYGL SET N_TOLLGATE = :n_TOLLGATE");
            strSql.Append(" WHERE (N_TOLLGATE > :n_TOLLGATE OR N_TOLLGATE = 0) AND N_DLDH = :n_DLZH ");
            OracleParameter[] parameters = {
				new OracleParameter(":n_TOLLGATE", OracleType.Number,4),
                new OracleParameter(":n_DLZH", OracleType.VarChar,100)
            };
            parameters[0].Value = Convert.ToInt32(N_TOLLGATE);
            parameters[1].Value = N_DLZH;
            htab.Add(strSql, parameters);
        }

        public void UpdateXJDDSX(string strdjdh, string strid, float strddsx, Hashtable o_aHt)
        {
            if (strddsx.Equals(0))
                return;
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" update kfb_zhgl set n_ddsx=:n_ddsx where " + strdjdh + "='" + strid + "'");
            strSqlup.Append(" and (n_ddsx>:n_ddsx or n_ddsx=0) ");
            OracleParameter[] parameters = {
                    new OracleParameter(":n_ddsx", OracleType.Float,8)                            
            };
            parameters[0].Value = strddsx;
            // DbHelperOra.ExecuteSql(strSqlup.ToString(), parameters);    
            o_aHt.Add(strSqlup.ToString(), parameters);
        }
        public void Upsj(KFB_ZHGL mo_zhgl)
        {
            if (mo_zhgl.N_HYDJ > 4)
            {
                string strn_hyzh = "";
                switch (mo_zhgl.N_HYDJ.ToString())
                {
                    case "5": strn_hyzh = mo_zhgl.N_DZJDH; break;
                    case "6": strn_hyzh = mo_zhgl.N_ZJDH; break;
                    case "7": strn_hyzh = mo_zhgl.N_DGDDH; break;
                    case "8": strn_hyzh = mo_zhgl.N_GDDH; break;
                    case "9": strn_hyzh = mo_zhgl.N_ZDLDH; break;
                }
                StringBuilder strSqlup = new StringBuilder();
                strSqlup.Append(" update kfb_zhgl set n_syed=n_syed-(" + mo_zhgl.N_KYED + "-(select N_KYED from kfb_zhgl where n_hyzh='" + mo_zhgl.N_HYZH + "' ))  where n_hyzh=:n_hyzh ");

                OracleParameter[] parametersup = {
                        new OracleParameter(":n_hyzh", OracleType.VarChar,100)

				    };
                parametersup[0].Value = strn_hyzh;
                DbHelperOra.ExecuteSql(strSqlup.ToString(), parametersup);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateLQ(KFB_SETUPLQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPLQ set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_BCRFTY=:N_BCRFTY,");
            strSql.Append("N_BCDXTY=:N_BCDXTY,");
            strSql.Append("N_BCDYTY=:N_BCDYTY,");
            strSql.Append("N_BCDSTY=:N_BCDSTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_BCRFDZ=:N_BCRFDZ,");
            strSql.Append("N_BCDXDZ=:N_BCDXDZ,");
            strSql.Append("N_BCDYDZ=:N_BCDYDZ,");
            strSql.Append("N_BCDSDZ=:N_BCDSDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_BCRFDC=:N_BCRFDC,");
            strSql.Append("N_BCDXDC=:N_BCDXDC,");
            strSql.Append("N_BCDYDC=:N_BCDYDC,");
            strSql.Append("N_BCDSDC=:N_BCDSDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC,");
            strSql.Append("N_RFDD=:N_RFDD,");
            strSql.Append("N_DXDD=:N_DXDD,");
            strSql.Append("N_DYDD=:N_DYDD,");
            strSql.Append("N_DSDD=:N_DSDD,");
            strSql.Append("N_ZDRFDD=:N_ZDRFDD,");
            strSql.Append("N_ZDDXDD=:N_ZDDXDD,");
            strSql.Append("N_BCRFDD=:N_BCRFDD,");
            strSql.Append("N_BCDXDD=:N_BCDXDD,");
            strSql.Append("N_BCDYDD=:N_BCDYDD,");
            strSql.Append("N_BCDSDD=:N_BCDSDD,");
            strSql.Append("N_GGDD=:N_GGDD,");
            strSql.Append("N_GJDD=:N_GJDD,");
            strSql.Append("N_DJRFTY=:N_DJRFTY,");
            strSql.Append("N_DJDXTY=:N_DJDXTY,");
            strSql.Append("N_DJDSTY=:N_DJDSTY,");
            strSql.Append("N_DJRFDZ=:N_DJRFDZ,");
            strSql.Append("N_DJDXDZ=:N_DJDXDZ,");
            strSql.Append("N_DJDSDZ=:N_DJDSDZ,");
            strSql.Append("N_DJRFDC=:N_DJRFDC,");
            strSql.Append("N_DJDXDC=:N_DJDXDC,");
            strSql.Append("N_DJDSDC=:N_DJDSDC,");
            strSql.Append("N_DJRFDD=:N_DJRFDD,");
            strSql.Append("N_DJDXDD=:N_DJDXDD,");
            strSql.Append("N_DJDSDD=:N_DJDSDD");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCRFTY", OracleType.Float,22),
					new OracleParameter(":N_BCDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCDYTY", OracleType.Float,22),
					new OracleParameter(":N_BCDSTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCRFDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDYDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCRFDC", OracleType.Float,22),
					new OracleParameter(":N_BCDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCDYDC", OracleType.Float,22),
					new OracleParameter(":N_BCDSDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22),
                    new OracleParameter(":N_RFDD", OracleType.Float,22),
					new OracleParameter(":N_DXDD", OracleType.Float,22),
					new OracleParameter(":N_DYDD", OracleType.Float,22),
					new OracleParameter(":N_DSDD", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDD", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDD", OracleType.Float,22),
					new OracleParameter(":N_BCRFDD", OracleType.Float,22),
					new OracleParameter(":N_BCDXDD", OracleType.Float,22),
					new OracleParameter(":N_BCDYDD", OracleType.Float,22),
					new OracleParameter(":N_BCDSDD", OracleType.Float,22),
					new OracleParameter(":N_GGDD", OracleType.Float,22),
					new OracleParameter(":N_GJDD", OracleType.Float,22),
                    new OracleParameter(":N_DJRFTY", OracleType.Float,22),
					new OracleParameter(":N_DJDXTY", OracleType.Float,22),
                    new OracleParameter(":N_DJDSTY", OracleType.Float,22),
                    new OracleParameter(":N_DJRFDZ", OracleType.Float,22),
					new OracleParameter(":N_DJDXDZ", OracleType.Float,22),
                    new OracleParameter(":N_DJDSDZ", OracleType.Float,22),
                    new OracleParameter(":N_DJRFDC", OracleType.Float,22),
					new OracleParameter(":N_DJDXDC", OracleType.Float,22),
                    new OracleParameter(":N_DJDSDC", OracleType.Float,22),
                    new OracleParameter(":N_DJRFDD", OracleType.Float,22),
					new OracleParameter(":N_DJDXDD", OracleType.Float,22),
                    new OracleParameter(":N_DJDSDD", OracleType.Float,22)
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_BCRFTY;
            parameters[8].Value = model.N_BCDXTY;
            parameters[9].Value = model.N_BCDYTY;
            parameters[10].Value = model.N_BCDSTY;
            parameters[11].Value = model.N_GGTY;
            parameters[12].Value = model.N_GJTY;
            parameters[13].Value = model.N_RFDZ;
            parameters[14].Value = model.N_DXDZ;
            parameters[15].Value = model.N_DYDZ;
            parameters[16].Value = model.N_DSDZ;
            parameters[17].Value = model.N_ZDRFDZ;
            parameters[18].Value = model.N_ZDDXDZ;
            parameters[19].Value = model.N_BCRFDZ;
            parameters[20].Value = model.N_BCDXDZ;
            parameters[21].Value = model.N_BCDYDZ;
            parameters[22].Value = model.N_BCDSDZ;
            parameters[23].Value = model.N_GGDZ;
            parameters[24].Value = model.N_GJDZ;
            parameters[25].Value = model.N_RFDC;
            parameters[26].Value = model.N_DXDC;
            parameters[27].Value = model.N_DYDC;
            parameters[28].Value = model.N_DSDC;
            parameters[29].Value = model.N_ZDRFDC;
            parameters[30].Value = model.N_ZDDXDC;
            parameters[31].Value = model.N_BCRFDC;
            parameters[32].Value = model.N_BCDXDC;
            parameters[33].Value = model.N_BCDYDC;
            parameters[34].Value = model.N_BCDSDC;
            parameters[35].Value = model.N_GGDC;
            parameters[36].Value = model.N_GJDC;
            parameters[37].Value = model.N_RFDD;
            parameters[38].Value = model.N_DXDD;
            parameters[39].Value = model.N_DYDD;
            parameters[40].Value = model.N_DSDD;
            parameters[41].Value = model.N_ZDRFDD;
            parameters[42].Value = model.N_ZDDXDD;
            parameters[43].Value = model.N_BCRFDD;
            parameters[44].Value = model.N_BCDXDD;
            parameters[45].Value = model.N_BCDYDD;
            parameters[46].Value = model.N_BCDSDD;
            parameters[47].Value = model.N_GGDD;
            parameters[48].Value = model.N_GJDD;
            parameters[49].Value = model.N_DJRFTY;
            parameters[50].Value = model.N_DJDXTY;
            parameters[51].Value = model.N_DJDSTY;
            parameters[52].Value = model.N_DJRFDZ;
            parameters[53].Value = model.N_DJDXDZ;
            parameters[54].Value = model.N_DJDSDZ;
            parameters[55].Value = model.N_DJRFDC;
            parameters[56].Value = model.N_DJDXDC;
            parameters[57].Value = model.N_DJDSDC;
            parameters[58].Value = model.N_DJRFDD;
            parameters[59].Value = model.N_DJDXDD;
            parameters[60].Value = model.N_DJDSDD;
            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateMB(KFB_SETUPMB model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPMB set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_SYTY=:N_SYTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_SYDZ=:N_SYDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_SYDC=:N_SYDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateRB(KFB_SETUPRB model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPRB set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_SYTY=:N_SYTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_SYDZ=:N_SYDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_SYDC=:N_SYDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateTB(KFB_SETUPTB model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPTB set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_SYTY=:N_SYTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_SYDZ=:N_SYDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_SYDC=:N_SYDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateZQ(KFB_SETUPZQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPZQ set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_ARFTY=:N_ARFTY,");
            strSql.Append("N_ADXTY=:N_ADXTY,");
            strSql.Append("N_ADYTY=:N_ADYTY,");
            strSql.Append("N_ADSTY=:N_ADSTY,");
            strSql.Append("N_AZDRFTY=:N_AZDRFTY,");
            strSql.Append("N_AZDDXTY=:N_AZDDXTY,");
            strSql.Append("N_ABCRFTY=:N_ABCRFTY,");
            strSql.Append("N_ABCDXTY=:N_ABCDXTY,");
            strSql.Append("N_ABCDYTY=:N_ABCDYTY,");
            strSql.Append("N_ARQSTY=:N_ARQSTY,");
            strSql.Append("N_ABDTY=:N_ABDTY,");
            strSql.Append("N_ABQCTY=:N_ABQCTY,");
            strSql.Append("N_AGGTY=:N_AGGTY,");
            strSql.Append("N_AGJTY=:N_AGJTY,");
            strSql.Append("N_BRFTY=:N_BRFTY,");
            strSql.Append("N_BDXTY=:N_BDXTY,");
            strSql.Append("N_BDYTY=:N_BDYTY,");
            strSql.Append("N_BDSTY=:N_BDSTY,");
            strSql.Append("N_BZDRFTY=:N_BZDRFTY,");
            strSql.Append("N_BZDDXTY=:N_BZDDXTY,");
            strSql.Append("N_BBCRFTY=:N_BBCRFTY,");
            strSql.Append("N_BBCDXTY=:N_BBCDXTY,");
            strSql.Append("N_BBCDYTY=:N_BBCDYTY,");
            strSql.Append("N_BRQSTY=:N_BRQSTY,");
            strSql.Append("N_BBDTY=:N_BBDTY,");
            strSql.Append("N_BBQCTY=:N_BBQCTY,");
            strSql.Append("N_BGGTY=:N_BGGTY,");
            strSql.Append("N_BGJTY=:N_BGJTY,");
            strSql.Append("N_CRFTY=:N_CRFTY,");
            strSql.Append("N_CDXTY=:N_CDXTY,");
            strSql.Append("N_CDYTY=:N_CDYTY,");
            strSql.Append("N_CDSTY=:N_CDSTY,");
            strSql.Append("N_CZDRFTY=:N_CZDRFTY,");
            strSql.Append("N_CZDDXTY=:N_CZDDXTY,");
            strSql.Append("N_CBCRFTY=:N_CBCRFTY,");
            strSql.Append("N_CBCDXTY=:N_CBCDXTY,");
            strSql.Append("N_CBCDYTY=:N_CBCDYTY,");
            strSql.Append("N_CRQSTY=:N_CRQSTY,");
            strSql.Append("N_CBDTY=:N_CBDTY,");
            strSql.Append("N_CBQCTY=:N_CBQCTY,");
            strSql.Append("N_CGGTY=:N_CGGTY,");
            strSql.Append("N_CGJTY=:N_CGJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_BCRFDZ=:N_BCRFDZ,");
            strSql.Append("N_BCDXDZ=:N_BCDXDZ,");
            strSql.Append("N_BCDYDZ=:N_BCDYDZ,");
            strSql.Append("N_RQSDZ=:N_RQSDZ,");
            strSql.Append("N_BDDZ=:N_BDDZ,");
            strSql.Append("N_BQCDZ=:N_BQCDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_BCRFDC=:N_BCRFDC,");
            strSql.Append("N_BCDXDC=:N_BCDXDC,");
            strSql.Append("N_BCDYDC=:N_BCDYDC,");
            strSql.Append("N_RQSDC=:N_RQSDC,");
            strSql.Append("N_BDDC=:N_BDDC,");
            strSql.Append("N_BQCDC=:N_BQCDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_ARFTY", OracleType.Float,22),
					new OracleParameter(":N_ADXTY", OracleType.Float,22),
					new OracleParameter(":N_ADYTY", OracleType.Float,22),
					new OracleParameter(":N_ADSTY", OracleType.Float,22),
					new OracleParameter(":N_AZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_AZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_ABCRFTY", OracleType.Float,22),
					new OracleParameter(":N_ABCDXTY", OracleType.Float,22),
					new OracleParameter(":N_ABCDYTY", OracleType.Float,22),
					new OracleParameter(":N_ARQSTY", OracleType.Float,22),
					new OracleParameter(":N_ABDTY", OracleType.Float,22),
					new OracleParameter(":N_ABQCTY", OracleType.Float,22),
					new OracleParameter(":N_AGGTY", OracleType.Float,22),
					new OracleParameter(":N_AGJTY", OracleType.Float,22),
					new OracleParameter(":N_BRFTY", OracleType.Float,22),
					new OracleParameter(":N_BDXTY", OracleType.Float,22),
					new OracleParameter(":N_BDYTY", OracleType.Float,22),
					new OracleParameter(":N_BDSTY", OracleType.Float,22),
					new OracleParameter(":N_BZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_BZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_BBCRFTY", OracleType.Float,22),
					new OracleParameter(":N_BBCDXTY", OracleType.Float,22),
					new OracleParameter(":N_BBCDYTY", OracleType.Float,22),
					new OracleParameter(":N_BRQSTY", OracleType.Float,22),
					new OracleParameter(":N_BBDTY", OracleType.Float,22),
					new OracleParameter(":N_BBQCTY", OracleType.Float,22),
					new OracleParameter(":N_BGGTY", OracleType.Float,22),
					new OracleParameter(":N_BGJTY", OracleType.Float,22),
					new OracleParameter(":N_CRFTY", OracleType.Float,22),
					new OracleParameter(":N_CDXTY", OracleType.Float,22),
					new OracleParameter(":N_CDYTY", OracleType.Float,22),
					new OracleParameter(":N_CDSTY", OracleType.Float,22),
					new OracleParameter(":N_CZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_CZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_CBCRFTY", OracleType.Float,22),
					new OracleParameter(":N_CBCDXTY", OracleType.Float,22),
					new OracleParameter(":N_CBCDYTY", OracleType.Float,22),
					new OracleParameter(":N_CRQSTY", OracleType.Float,22),
					new OracleParameter(":N_CBDTY", OracleType.Float,22),
					new OracleParameter(":N_CBQCTY", OracleType.Float,22),
					new OracleParameter(":N_CGGTY", OracleType.Float,22),
					new OracleParameter(":N_CGJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCRFDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDYDZ", OracleType.Float,22),
					new OracleParameter(":N_RQSDZ", OracleType.Float,22),
					new OracleParameter(":N_BDDZ", OracleType.Float,22),
					new OracleParameter(":N_BQCDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCRFDC", OracleType.Float,22),
					new OracleParameter(":N_BCDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCDYDC", OracleType.Float,22),
					new OracleParameter(":N_RQSDC", OracleType.Float,22),
					new OracleParameter(":N_BDDC", OracleType.Float,22),
					new OracleParameter(":N_BQCDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_ARFTY;
            parameters[2].Value = model.N_ADXTY;
            parameters[3].Value = model.N_ADYTY;
            parameters[4].Value = model.N_ADSTY;
            parameters[5].Value = model.N_AZDRFTY;
            parameters[6].Value = model.N_AZDDXTY;
            parameters[7].Value = model.N_ABCRFTY;
            parameters[8].Value = model.N_ABCDXTY;
            parameters[9].Value = model.N_ABCDYTY;
            parameters[10].Value = model.N_ARQSTY;
            parameters[11].Value = model.N_ABDTY;
            parameters[12].Value = model.N_ABQCTY;
            parameters[13].Value = model.N_AGGTY;
            parameters[14].Value = model.N_AGJTY;
            parameters[15].Value = model.N_BRFTY;
            parameters[16].Value = model.N_BDXTY;
            parameters[17].Value = model.N_BDYTY;
            parameters[18].Value = model.N_BDSTY;
            parameters[19].Value = model.N_BZDRFTY;
            parameters[20].Value = model.N_BZDDXTY;
            parameters[21].Value = model.N_BBCRFTY;
            parameters[22].Value = model.N_BBCDXTY;
            parameters[23].Value = model.N_BBCDYTY;
            parameters[24].Value = model.N_BRQSTY;
            parameters[25].Value = model.N_BBDTY;
            parameters[26].Value = model.N_BBQCTY;
            parameters[27].Value = model.N_BGGTY;
            parameters[28].Value = model.N_BGJTY;
            parameters[29].Value = model.N_CRFTY;
            parameters[30].Value = model.N_CDXTY;
            parameters[31].Value = model.N_CDYTY;
            parameters[32].Value = model.N_CDSTY;
            parameters[33].Value = model.N_CZDRFTY;
            parameters[34].Value = model.N_CZDDXTY;
            parameters[35].Value = model.N_CBCRFTY;
            parameters[36].Value = model.N_CBCDXTY;
            parameters[37].Value = model.N_CBCDYTY;
            parameters[38].Value = model.N_CRQSTY;
            parameters[39].Value = model.N_CBDTY;
            parameters[40].Value = model.N_CBQCTY;
            parameters[41].Value = model.N_CGGTY;
            parameters[42].Value = model.N_CGJTY;
            parameters[43].Value = model.N_RFDZ;
            parameters[44].Value = model.N_DXDZ;
            parameters[45].Value = model.N_DYDZ;
            parameters[46].Value = model.N_DSDZ;
            parameters[47].Value = model.N_ZDRFDZ;
            parameters[48].Value = model.N_ZDDXDZ;
            parameters[49].Value = model.N_BCRFDZ;
            parameters[50].Value = model.N_BCDXDZ;
            parameters[51].Value = model.N_BCDYDZ;
            parameters[52].Value = model.N_RQSDZ;
            parameters[53].Value = model.N_BDDZ;
            parameters[54].Value = model.N_BQCDZ;
            parameters[55].Value = model.N_GGDZ;
            parameters[56].Value = model.N_GJDZ;
            parameters[57].Value = model.N_RFDC;
            parameters[58].Value = model.N_DXDC;
            parameters[59].Value = model.N_DYDC;
            parameters[60].Value = model.N_DSDC;
            parameters[61].Value = model.N_ZDRFDC;
            parameters[62].Value = model.N_ZDDXDC;
            parameters[63].Value = model.N_BCRFDC;
            parameters[64].Value = model.N_BCDXDC;
            parameters[65].Value = model.N_BCDYDC;
            parameters[66].Value = model.N_RQSDC;
            parameters[67].Value = model.N_BDDC;
            parameters[68].Value = model.N_BQCDC;
            parameters[69].Value = model.N_GGDC;
            parameters[70].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateMQ(KFB_SETUPMQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPMQ set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_BCRFTY=:N_BCRFTY,");
            strSql.Append("N_BCDXTY=:N_BCDXTY,");
            strSql.Append("N_BCDYTY=:N_BCDYTY,");
            strSql.Append("N_BCDSTY=:N_BCDSTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_BCRFDZ=:N_BCRFDZ,");
            strSql.Append("N_BCDXDZ=:N_BCDXDZ,");
            strSql.Append("N_BCDYDZ=:N_BCDYDZ,");
            strSql.Append("N_BCDSDZ=:N_BCDSDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_BCRFDC=:N_BCRFDC,");
            strSql.Append("N_BCDXDC=:N_BCDXDC,");
            strSql.Append("N_BCDYDC=:N_BCDYDC,");
            strSql.Append("N_BCDSDC=:N_BCDSDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCRFTY", OracleType.Float,22),
					new OracleParameter(":N_BCDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCDYTY", OracleType.Float,22),
					new OracleParameter(":N_BCDSTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCRFDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDYDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCRFDC", OracleType.Float,22),
					new OracleParameter(":N_BCDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCDYDC", OracleType.Float,22),
					new OracleParameter(":N_BCDSDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_BCRFTY;
            parameters[8].Value = model.N_BCDXTY;
            parameters[9].Value = model.N_BCDYTY;
            parameters[10].Value = model.N_BCDSTY;
            parameters[11].Value = model.N_GGTY;
            parameters[12].Value = model.N_GJTY;
            parameters[13].Value = model.N_RFDZ;
            parameters[14].Value = model.N_DXDZ;
            parameters[15].Value = model.N_DYDZ;
            parameters[16].Value = model.N_DSDZ;
            parameters[17].Value = model.N_ZDRFDZ;
            parameters[18].Value = model.N_ZDDXDZ;
            parameters[19].Value = model.N_BCRFDZ;
            parameters[20].Value = model.N_BCDXDZ;
            parameters[21].Value = model.N_BCDYDZ;
            parameters[22].Value = model.N_BCDSDZ;
            parameters[23].Value = model.N_GGDZ;
            parameters[24].Value = model.N_GJDZ;
            parameters[25].Value = model.N_RFDC;
            parameters[26].Value = model.N_DXDC;
            parameters[27].Value = model.N_DYDC;
            parameters[28].Value = model.N_DSDC;
            parameters[29].Value = model.N_ZDRFDC;
            parameters[30].Value = model.N_ZDDXDC;
            parameters[31].Value = model.N_BCRFDC;
            parameters[32].Value = model.N_BCDXDC;
            parameters[33].Value = model.N_BCDYDC;
            parameters[34].Value = model.N_BCDSDC;
            parameters[35].Value = model.N_GGDC;
            parameters[36].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        public void UpdateBQ(KFB_SETUPBQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPBQ set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_SYTY=:N_SYTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_SYDZ=:N_SYDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_SYDC=:N_SYDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            //strSql.Append("N_RFDD=:N_RFDD,");
            //strSql.Append("N_DXDD=:N_DXDD,");
            //strSql.Append("N_DYDD=:N_DYDD,");
            //strSql.Append("N_DSDD=:N_DSDD,");
            //strSql.Append("N_ZDRFDD=:N_ZDRFDD,");
            //strSql.Append("N_ZDDXDD=:N_ZDDXDD,");
            //strSql.Append("N_SYDD=:N_SYDD,");
            //strSql.Append("N_GGDD=:N_GGDD,");
            //strSql.Append("N_GJDD=:N_GJDD");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22),
                    //new OracleParameter(":N_RFDD", OracleType.Float,22),
                    //new OracleParameter(":N_DXDD", OracleType.Float,22),
                    //new OracleParameter(":N_DYDD", OracleType.Float,22),
                    //new OracleParameter(":N_DSDD", OracleType.Float,22),
                    //new OracleParameter(":N_ZDRFDD", OracleType.Float,22),
                    //new OracleParameter(":N_ZDDXDD", OracleType.Float,22),
                    //new OracleParameter(":N_SYDD", OracleType.Float,22),
                    //new OracleParameter(":N_GGDD", OracleType.Float,22),
                    //new OracleParameter(":N_GJDD", OracleType.Float,22)
            
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;
            //parameters[28].Value = model.N_RFDD;
            //parameters[29].Value = model.N_DXDD;
            //parameters[30].Value = model.N_DYDD;
            //parameters[31].Value = model.N_DSDD;
            //parameters[32].Value = model.N_ZDRFDD;
            //parameters[33].Value = model.N_ZDDXDD;
            //parameters[34].Value = model.N_SYDD;
            //parameters[35].Value = model.N_GGDD;
            //parameters[36].Value = model.N_GJDD;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateCQ(KFB_SETUPCQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPCQ set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_BCRFTY=:N_BCRFTY,");
            strSql.Append("N_BCDXTY=:N_BCDXTY,");
            strSql.Append("N_BCDYTY=:N_BCDYTY,");
            strSql.Append("N_BCDSTY=:N_BCDSTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_BCRFDZ=:N_BCRFDZ,");
            strSql.Append("N_BCDXDZ=:N_BCDXDZ,");
            strSql.Append("N_BCDYDZ=:N_BCDYDZ,");
            strSql.Append("N_BCDSDZ=:N_BCDSDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_BCRFDC=:N_BCRFDC,");
            strSql.Append("N_BCDXDC=:N_BCDXDC,");
            strSql.Append("N_BCDYDC=:N_BCDYDC,");
            strSql.Append("N_BCDSDC=:N_BCDSDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCRFTY", OracleType.Float,22),
					new OracleParameter(":N_BCDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCDYTY", OracleType.Float,22),
					new OracleParameter(":N_BCDSTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCRFDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDYDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCRFDC", OracleType.Float,22),
					new OracleParameter(":N_BCDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCDYDC", OracleType.Float,22),
					new OracleParameter(":N_BCDSDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_BCRFTY;
            parameters[8].Value = model.N_BCDXTY;
            parameters[9].Value = model.N_BCDYTY;
            parameters[10].Value = model.N_BCDSTY;
            parameters[11].Value = model.N_GGTY;
            parameters[12].Value = model.N_GJTY;
            parameters[13].Value = model.N_RFDZ;
            parameters[14].Value = model.N_DXDZ;
            parameters[15].Value = model.N_DYDZ;
            parameters[16].Value = model.N_DSDZ;
            parameters[17].Value = model.N_ZDRFDZ;
            parameters[18].Value = model.N_ZDDXDZ;
            parameters[19].Value = model.N_BCRFDZ;
            parameters[20].Value = model.N_BCDXDZ;
            parameters[21].Value = model.N_BCDYDZ;
            parameters[22].Value = model.N_BCDSDZ;
            parameters[23].Value = model.N_GGDZ;
            parameters[24].Value = model.N_GJDZ;
            parameters[25].Value = model.N_RFDC;
            parameters[26].Value = model.N_DXDC;
            parameters[27].Value = model.N_DYDC;
            parameters[28].Value = model.N_DSDC;
            parameters[29].Value = model.N_ZDRFDC;
            parameters[30].Value = model.N_ZDDXDC;
            parameters[31].Value = model.N_BCRFDC;
            parameters[32].Value = model.N_BCDXDC;
            parameters[33].Value = model.N_BCDYDC;
            parameters[34].Value = model.N_BCDSDC;
            parameters[35].Value = model.N_GGDC;
            parameters[36].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateZS(KFB_SETUPZS model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPZS set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_RFTY=:N_RFTY,");
            strSql.Append("N_DXTY=:N_DXTY,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DSTY=:N_DSTY,");
            strSql.Append("N_ZDRFTY=:N_ZDRFTY,");
            strSql.Append("N_ZDDXTY=:N_ZDDXTY,");
            strSql.Append("N_SYTY=:N_SYTY,");
            strSql.Append("N_BDTY=:N_BDTY,");
            strSql.Append("N_GGTY=:N_GGTY,");
            strSql.Append("N_GJTY=:N_GJTY,");
            strSql.Append("N_RFDZ=:N_RFDZ,");
            strSql.Append("N_DXDZ=:N_DXDZ,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DSDZ=:N_DSDZ,");
            strSql.Append("N_ZDRFDZ=:N_ZDRFDZ,");
            strSql.Append("N_ZDDXDZ=:N_ZDDXDZ,");
            strSql.Append("N_SYDZ=:N_SYDZ,");
            strSql.Append("N_BDDZ=:N_BDDZ,");
            strSql.Append("N_GGDZ=:N_GGDZ,");
            strSql.Append("N_GJDZ=:N_GJDZ,");
            strSql.Append("N_RFDC=:N_RFDC,");
            strSql.Append("N_DXDC=:N_DXDC,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_DSDC=:N_DSDC,");
            strSql.Append("N_ZDRFDC=:N_ZDRFDC,");
            strSql.Append("N_ZDDXDC=:N_ZDDXDC,");
            strSql.Append("N_SYDC=:N_SYDC,");
            strSql.Append("N_BDDC=:N_BDDC,");
            strSql.Append("N_GGDC=:N_GGDC,");
            strSql.Append("N_GJDC=:N_GJDC");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_BDTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_BDDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_BDDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_BDTY;
            parameters[9].Value = model.N_GGTY;
            parameters[10].Value = model.N_GJTY;
            parameters[11].Value = model.N_RFDZ;
            parameters[12].Value = model.N_DXDZ;
            parameters[13].Value = model.N_DYDZ;
            parameters[14].Value = model.N_DSDZ;
            parameters[15].Value = model.N_ZDRFDZ;
            parameters[16].Value = model.N_ZDDXDZ;
            parameters[17].Value = model.N_SYDZ;
            parameters[18].Value = model.N_BDDZ;
            parameters[19].Value = model.N_GGDZ;
            parameters[20].Value = model.N_GJDZ;
            parameters[21].Value = model.N_RFDC;
            parameters[22].Value = model.N_DXDC;
            parameters[23].Value = model.N_DYDC;
            parameters[24].Value = model.N_DSDC;
            parameters[25].Value = model.N_ZDRFDC;
            parameters[26].Value = model.N_ZDDXDC;
            parameters[27].Value = model.N_SYDC;
            parameters[28].Value = model.N_BDDC;
            parameters[29].Value = model.N_GGDC;
            parameters[30].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSM(KFB_SETUPSM model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPSM set ");
            strSql.Append("N_HYDH=:N_HYDH,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_WZTY=:N_WZTY,");
            strSql.Append("N_LYTY=:N_LYTY,");
            strSql.Append("N_WZQTY=:N_WZQTY,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_WZDZ=:N_WZDZ,");
            strSql.Append("N_LYDZ=:N_LYDZ,");
            strSql.Append("N_WZQDZ=:N_WZQDZ,");
            strSql.Append("N_DYDC=:N_DYDC,");
            strSql.Append("N_WZDC=:N_WZDC,");
            strSql.Append("N_LYDC=:N_LYDC,");
            strSql.Append("N_WZQDC=:N_WZQDC");
            strSql.Append(" where N_HYDH=:N_HYDH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_WZTY", OracleType.Float,22),
					new OracleParameter(":N_LYTY", OracleType.Float,22),
					new OracleParameter(":N_WZQTY", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_WZDZ", OracleType.Float,22),
					new OracleParameter(":N_LYDZ", OracleType.Float,22),
					new OracleParameter(":N_WZQDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_WZDC", OracleType.Float,22),
					new OracleParameter(":N_LYDC", OracleType.Float,22),
					new OracleParameter(":N_WZQDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_DYTY;
            parameters[2].Value = model.N_WZTY;
            parameters[3].Value = model.N_LYTY;
            parameters[4].Value = model.N_WZQTY;
            parameters[5].Value = model.N_DYDZ;
            parameters[6].Value = model.N_WZDZ;
            parameters[7].Value = model.N_LYDZ;
            parameters[8].Value = model.N_WZQDZ;
            parameters[9].Value = model.N_DYDC;
            parameters[10].Value = model.N_WZDC;
            parameters[11].Value = model.N_LYDC;
            parameters[12].Value = model.N_WZQDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateLHC(KFB_SETUPLHC model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPLHC set ");
            strSql.Append("N_HYDH=:N_HYDH,");
            strSql.Append("N_TBHTY=:N_TBHTY,");
            strSql.Append("N_TTTY=:N_TTTY,");
            strSql.Append("N_THTY=:N_THTY,");
            strSql.Append("N_QCPTY=:N_QCPTY,");
            strSql.Append("N_2XTY=:N_2XTY,");
            strSql.Append("N_3XTY=:N_3XTY,");
            strSql.Append("N_4XTY=:N_4XTY,");
            strSql.Append("N_GDDSTY=:N_GDDSTY,");
            strSql.Append("N_GDDXTY=:N_GDDXTY,");
            strSql.Append("N_TBHDZ=:N_TBHDZ,");
            strSql.Append("N_TTDZ=:N_TTDZ,");
            strSql.Append("N_THDZ=:N_THDZ,");
            strSql.Append("N_QCPDZ=:N_QCPDZ,");
            strSql.Append("N_2XDZ=:N_2XDZ,");
            strSql.Append("N_3XDZ=:N_3XDZ,");
            strSql.Append("N_4XDZ=:N_4XDZ,");
            strSql.Append("N_GDDSDZ=:N_GDDSDZ,");
            strSql.Append("N_GDDXDZ=:N_GDDXDZ,");
            strSql.Append("N_TBHDC=:N_TBHDC,");
            strSql.Append("N_TTDC=:N_TTDC,");
            strSql.Append("N_THDC=:N_THDC,");
            strSql.Append("N_QCPDC=:N_QCPDC,");
            strSql.Append("N_2XDC=:N_2XDC,");
            strSql.Append("N_3XDC=:N_3XDC,");
            strSql.Append("N_4XDC=:N_4XDC,");
            strSql.Append("N_GDDSDC=:N_GDDSDC,");
            strSql.Append("N_GDDXDC=:N_GDDXDC");
            strSql.Append(" where N_HYDH=:N_HYDH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_TBHTY", OracleType.Float,22),
					new OracleParameter(":N_TTTY", OracleType.Float,22),
					new OracleParameter(":N_THTY", OracleType.Float,22),
					new OracleParameter(":N_QCPTY", OracleType.Float,22),
					new OracleParameter(":N_2XTY", OracleType.Float,22),
					new OracleParameter(":N_3XTY", OracleType.Float,22),
					new OracleParameter(":N_4XTY", OracleType.Float,22),
					new OracleParameter(":N_GDDSTY", OracleType.Float,22),
					new OracleParameter(":N_GDDXTY", OracleType.Float,22),
					new OracleParameter(":N_TBHDZ", OracleType.Float,22),
					new OracleParameter(":N_TTDZ", OracleType.Float,22),
					new OracleParameter(":N_THDZ", OracleType.Float,22),
					new OracleParameter(":N_QCPDZ", OracleType.Float,22),
					new OracleParameter(":N_2XDZ", OracleType.Float,22),
					new OracleParameter(":N_3XDZ", OracleType.Float,22),
					new OracleParameter(":N_4XDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_TBHDC", OracleType.Float,22),
					new OracleParameter(":N_TTDC", OracleType.Float,22),
					new OracleParameter(":N_THDC", OracleType.Float,22),
					new OracleParameter(":N_QCPDC", OracleType.Float,22),
					new OracleParameter(":N_2XDC", OracleType.Float,22),
					new OracleParameter(":N_3XDC", OracleType.Float,22),
					new OracleParameter(":N_4XDC", OracleType.Float,22),
					new OracleParameter(":N_GDDSDC", OracleType.Float,22),
					new OracleParameter(":N_GDDXDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_TBHTY;
            parameters[2].Value = model.N_TTTY;
            parameters[3].Value = model.N_THTY;
            parameters[4].Value = model.N_QCPTY;
            parameters[5].Value = model.N_2XTY;
            parameters[6].Value = model.N_3XTY;
            parameters[7].Value = model.N_4XTY;
            parameters[8].Value = model.N_GDDSTY;
            parameters[9].Value = model.N_GDDXTY;
            parameters[10].Value = model.N_TBHDZ;
            parameters[11].Value = model.N_TTDZ;
            parameters[12].Value = model.N_THDZ;
            parameters[13].Value = model.N_QCPDZ;
            parameters[14].Value = model.N_2XDZ;
            parameters[15].Value = model.N_3XDZ;
            parameters[16].Value = model.N_4XDZ;
            parameters[17].Value = model.N_GDDSDZ;
            parameters[18].Value = model.N_GDDXDZ;
            parameters[19].Value = model.N_TBHDC;
            parameters[20].Value = model.N_TTDC;
            parameters[21].Value = model.N_THDC;
            parameters[22].Value = model.N_QCPDC;
            parameters[23].Value = model.N_2XDC;
            parameters[24].Value = model.N_3XDC;
            parameters[25].Value = model.N_4XDC;
            parameters[26].Value = model.N_GDDSDC;
            parameters[27].Value = model.N_GDDXDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateDLT(KFB_SETUPDLT model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPDLT set ");
            strSql.Append("N_HYDH=:N_HYDH,");
            strSql.Append("N_TBHTY=:N_TBHTY,");
            strSql.Append("N_TTTY=:N_TTTY,");
            strSql.Append("N_THTY=:N_THTY,");
            strSql.Append("N_QCPTY=:N_QCPTY,");
            strSql.Append("N_2XTY=:N_2XTY,");
            strSql.Append("N_3XTY=:N_3XTY,");
            strSql.Append("N_4XTY=:N_4XTY,");
            strSql.Append("N_GDDSTY=:N_GDDSTY,");
            strSql.Append("N_GDDXTY=:N_GDDXTY,");
            strSql.Append("N_TBHDZ=:N_TBHDZ,");
            strSql.Append("N_TTDZ=:N_TTDZ,");
            strSql.Append("N_THDZ=:N_THDZ,");
            strSql.Append("N_QCPDZ=:N_QCPDZ,");
            strSql.Append("N_2XDZ=:N_2XDZ,");
            strSql.Append("N_3XDZ=:N_3XDZ,");
            strSql.Append("N_4XDZ=:N_4XDZ,");
            strSql.Append("N_GDDSDZ=:N_GDDSDZ,");
            strSql.Append("N_GDDXDZ=:N_GDDXDZ,");
            strSql.Append("N_TBHDC=:N_TBHDC,");
            strSql.Append("N_TTDC=:N_TTDC,");
            strSql.Append("N_THDC=:N_THDC,");
            strSql.Append("N_QCPDC=:N_QCPDC,");
            strSql.Append("N_2XDC=:N_2XDC,");
            strSql.Append("N_3XDC=:N_3XDC,");
            strSql.Append("N_4XDC=:N_4XDC,");
            strSql.Append("N_GDDSDC=:N_GDDSDC,");
            strSql.Append("N_GDDXDC=:N_GDDXDC");
            strSql.Append(" where N_HYDH=:N_HYDH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_TBHTY", OracleType.Float,22),
					new OracleParameter(":N_TTTY", OracleType.Float,22),
					new OracleParameter(":N_THTY", OracleType.Float,22),
					new OracleParameter(":N_QCPTY", OracleType.Float,22),
					new OracleParameter(":N_2XTY", OracleType.Float,22),
					new OracleParameter(":N_3XTY", OracleType.Float,22),
					new OracleParameter(":N_4XTY", OracleType.Float,22),
					new OracleParameter(":N_GDDSTY", OracleType.Float,22),
					new OracleParameter(":N_GDDXTY", OracleType.Float,22),
					new OracleParameter(":N_TBHDZ", OracleType.Float,22),
					new OracleParameter(":N_TTDZ", OracleType.Float,22),
					new OracleParameter(":N_THDZ", OracleType.Float,22),
					new OracleParameter(":N_QCPDZ", OracleType.Float,22),
					new OracleParameter(":N_2XDZ", OracleType.Float,22),
					new OracleParameter(":N_3XDZ", OracleType.Float,22),
					new OracleParameter(":N_4XDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_TBHDC", OracleType.Float,22),
					new OracleParameter(":N_TTDC", OracleType.Float,22),
					new OracleParameter(":N_THDC", OracleType.Float,22),
					new OracleParameter(":N_QCPDC", OracleType.Float,22),
					new OracleParameter(":N_2XDC", OracleType.Float,22),
					new OracleParameter(":N_3XDC", OracleType.Float,22),
					new OracleParameter(":N_4XDC", OracleType.Float,22),
					new OracleParameter(":N_GDDSDC", OracleType.Float,22),
					new OracleParameter(":N_GDDXDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_TBHTY;
            parameters[2].Value = model.N_TTTY;
            parameters[3].Value = model.N_THTY;
            parameters[4].Value = model.N_QCPTY;
            parameters[5].Value = model.N_2XTY;
            parameters[6].Value = model.N_3XTY;
            parameters[7].Value = model.N_4XTY;
            parameters[8].Value = model.N_GDDSTY;
            parameters[9].Value = model.N_GDDXTY;
            parameters[10].Value = model.N_TBHDZ;
            parameters[11].Value = model.N_TTDZ;
            parameters[12].Value = model.N_THDZ;
            parameters[13].Value = model.N_QCPDZ;
            parameters[14].Value = model.N_2XDZ;
            parameters[15].Value = model.N_3XDZ;
            parameters[16].Value = model.N_4XDZ;
            parameters[17].Value = model.N_GDDSDZ;
            parameters[18].Value = model.N_GDDXDZ;
            parameters[19].Value = model.N_TBHDC;
            parameters[20].Value = model.N_TTDC;
            parameters[21].Value = model.N_THDC;
            parameters[22].Value = model.N_QCPDC;
            parameters[23].Value = model.N_2XDC;
            parameters[24].Value = model.N_3XDC;
            parameters[25].Value = model.N_4XDC;
            parameters[26].Value = model.N_GDDSDC;
            parameters[27].Value = model.N_GDDXDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateJC539(KFB_SETUPJC539 model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPJC539 set ");
            strSql.Append("N_HYDH=:N_HYDH,");
            strSql.Append("N_QCPTY=:N_QCPTY,");
            strSql.Append("N_2XTY=:N_2XTY,");
            strSql.Append("N_3XTY=:N_3XTY,");
            strSql.Append("N_4XTY=:N_4XTY,");
            strSql.Append("N_QCPDZ=:N_QCPDZ,");
            strSql.Append("N_2XDZ=:N_2XDZ,");
            strSql.Append("N_3XDZ=:N_3XDZ,");
            strSql.Append("N_4XDZ=:N_4XDZ,");
            strSql.Append("N_QCPDC=:N_QCPDC,");
            strSql.Append("N_2XDC=:N_2XDC,");
            strSql.Append("N_3XDC=:N_3XDC,");
            strSql.Append("N_4XDC=:N_4XDC");
            strSql.Append(" where N_HYDH=:N_HYDH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_QCPTY", OracleType.Float,22),
					new OracleParameter(":N_2XTY", OracleType.Float,22),
					new OracleParameter(":N_3XTY", OracleType.Float,22),
					new OracleParameter(":N_4XTY", OracleType.Float,22),
					new OracleParameter(":N_QCPDZ", OracleType.Float,22),
					new OracleParameter(":N_2XDZ", OracleType.Float,22),
					new OracleParameter(":N_3XDZ", OracleType.Float,22),
					new OracleParameter(":N_4XDZ", OracleType.Float,22),
					new OracleParameter(":N_QCPDC", OracleType.Float,22),
					new OracleParameter(":N_2XDC", OracleType.Float,22),
					new OracleParameter(":N_3XDC", OracleType.Float,22),
					new OracleParameter(":N_4XDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_QCPTY;
            parameters[2].Value = model.N_2XTY;
            parameters[3].Value = model.N_3XTY;
            parameters[4].Value = model.N_4XTY;
            parameters[5].Value = model.N_QCPDZ;
            parameters[6].Value = model.N_2XDZ;
            parameters[7].Value = model.N_3XDZ;
            parameters[8].Value = model.N_4XDZ;
            parameters[9].Value = model.N_QCPDC;
            parameters[10].Value = model.N_2XDC;
            parameters[11].Value = model.N_3XDC;
            parameters[12].Value = model.N_4XDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateCP(KFB_SETUPCP model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPCP set ");
            strSql.Append("N_HYDH=:N_HYDH,");
            strSql.Append("N_BQTY=:N_BQTY,");
            strSql.Append("N_LQTY=:N_LQTY,");
            strSql.Append("N_ZQTY=:N_ZQTY,");
            strSql.Append("N_GSTY=:N_GSTY,");
            strSql.Append("N_QZTY=:N_QZTY,");
            strSql.Append("N_BQDZ=:N_BQDZ,");
            strSql.Append("N_LQDZ=:N_LQDZ,");
            strSql.Append("N_ZQDZ=:N_ZQDZ,");
            strSql.Append("N_GSDZ=:N_GSDZ,");
            strSql.Append("N_QZDZ=:N_QZDZ,");
            strSql.Append("N_BQDC=:N_BQDC,");
            strSql.Append("N_LQDC=:N_LQDC,");
            strSql.Append("N_ZQDC=:N_ZQDC,");
            strSql.Append("N_GSDC=:N_GSDC,");
            strSql.Append("N_QZDC=:N_QZDC");
            strSql.Append(" where N_HYDH=:N_HYDH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_BQTY", OracleType.Float,22),
					new OracleParameter(":N_LQTY", OracleType.Float,22),
					new OracleParameter(":N_ZQTY", OracleType.Float,22),
					new OracleParameter(":N_GSTY", OracleType.Float,22),
					new OracleParameter(":N_QZTY", OracleType.Float,22),
					new OracleParameter(":N_BQDZ", OracleType.Float,22),
					new OracleParameter(":N_LQDZ", OracleType.Float,22),
					new OracleParameter(":N_ZQDZ", OracleType.Float,22),
					new OracleParameter(":N_GSDZ", OracleType.Float,22),
					new OracleParameter(":N_QZDZ", OracleType.Float,22),
					new OracleParameter(":N_BQDC", OracleType.Float,22),
					new OracleParameter(":N_LQDC", OracleType.Float,22),
					new OracleParameter(":N_ZQDC", OracleType.Float,22),
					new OracleParameter(":N_GSDC", OracleType.Float,22),
					new OracleParameter(":N_QZDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_BQTY;
            parameters[2].Value = model.N_LQTY;
            parameters[3].Value = model.N_ZQTY;
            parameters[4].Value = model.N_GSTY;
            parameters[5].Value = model.N_QZTY;
            parameters[6].Value = model.N_BQDZ;
            parameters[7].Value = model.N_LQDZ;
            parameters[8].Value = model.N_ZQDZ;
            parameters[9].Value = model.N_GSDZ;
            parameters[10].Value = model.N_QZDZ;
            parameters[11].Value = model.N_BQDC;
            parameters[12].Value = model.N_LQDC;
            parameters[13].Value = model.N_ZQDC;
            parameters[14].Value = model.N_GSDC;
            parameters[15].Value = model.N_QZDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSS(KFB_SETUPSS model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_SETUPSS set ");
            strSql.Append("N_HYDH=:N_HYDH,");
            strSql.Append("N_DYTY=:N_DYTY,");
            strSql.Append("N_DYDZ=:N_DYDZ,");
            strSql.Append("N_DYDC=:N_DYDC");
            strSql.Append(" where N_HYDH=:N_HYDH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_DYTY;
            parameters[2].Value = model.N_DYDZ;
            parameters[3].Value = model.N_DYDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新多筆数据
        /// </summary>
        public void Update(Hashtable o_aHt)
        {

            DbHelperOra.ExecuteSqlTran(o_aHt);
        }
        public void UpZJ(string strxy, string strhidxy, string strhy)
        {
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" update kfb_zhgl set n_syed=n_syed+" + (Convert.ToDouble(strxy) - Convert.ToDouble(strhidxy)) + "  where n_hyzh=:n_hyzh ");

            OracleParameter[] parametersup = {
                        new OracleParameter(":n_hyzh", OracleType.VarChar,100)

				    };
            parametersup[0].Value = strhy;
            DbHelperOra.ExecuteSql(strSqlup.ToString(), parametersup);
        }
        /// <summary>
        /// 获得下級帳號
        /// </summary>
        public DataSet GetZH(string strlv, string strname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_hyzh ");
            strSql.Append(" FROM KFB_ZHGL ");
            strSql.Append(" where 1=1 and  ");
            if (!strname.Equals(""))
            {
                if (strlv.Equals("0"))
                {
                    strSql.Append("  :strname=:strname  AND N_HYDJ='4' ");
                }
                else if (strlv.Equals("4"))
                {
                    strSql.Append(" n_dzjdh=:strname  ");
                }
                else if (strlv.Equals("5"))
                {
                    strSql.Append(" n_zjdh=:strname  ");
                }
                else if (strlv.Equals("6"))
                {
                    strSql.Append(" n_dgddh=:strname  ");
                }
                else if (strlv.Equals("7"))
                {
                    strSql.Append(" n_gddh=:strname  ");
                }
                else if (strlv.Equals("8"))
                {
                    strSql.Append(" n_zdldh=:strname  ");
                }
            }
            OracleParameter[] parameters = {
                    new OracleParameter(":strname", OracleType.VarChar,100)
				};
            parameters[0].Value = strname;
            DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
            return GetDS;
        }
        /// <summary>
        /// 获得會員帳號
        /// </summary>
        public DataSet GetHYZH(string strlv, string strname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_hyzh ");
            strSql.Append(" FROM kfb_hygl ");
            strSql.Append(" where 1=1 and  ");
            if (!strname.Equals(""))
            {
                if (strlv.Equals("4"))
                {
                    strSql.Append(" n_dzjdh=:strname  ");
                }
                else if (strlv.Equals("5"))
                {
                    strSql.Append(" n_zjdh=:strname  ");
                }
                else if (strlv.Equals("6"))
                {
                    strSql.Append(" n_dgddh=:strname  ");
                }
                else if (strlv.Equals("7"))
                {
                    strSql.Append(" n_gddh=:strname  ");
                }
                else if (strlv.Equals("8"))
                {
                    strSql.Append(" n_zdldh=:strname  ");
                }
                else if (strlv.Equals("9"))
                {
                    strSql.Append(" n_dldh=:strname  ");
                }
            }
            OracleParameter[] parameters = {
                    new OracleParameter(":strname", OracleType.VarChar,100)
				};
            parameters[0].Value = strname;
            DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
            return GetDS;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(string strTable, string strColum, string strvalue, string strZH)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" update kfb_setup" + strTable + " set n_" + strColum + "=:value ");
            //if (strTable.Equals("sm") || strTable.Equals("lhc") || strTable.Equals("jc539") || strTable.Equals("dlt") || strTable.Equals("cp"))
            //{
            //    strSql.Append(" where n_hydh  in ");
            //}
            //else 
            //{
            //    strSql.Append(" where n_hyzh  in ");
            //}
            //strSql.Append(" (" + strZH + ") ");
            //strSql.Append(" and n_" + strColum + ">:value ");
            //OracleParameter[] parameters = {
            //        new OracleParameter(":value", OracleType.Number,4)
            //};
            //parameters[0].Value = Convert.ToDecimal(strvalue);


            //DbHelperOra.ExecuteSql(strSql.ToString(), parameters);

            StringBuilder strSql = new StringBuilder();
            if ((strTable.Equals("mb") || strTable.Equals("bq") || strTable.Equals("tb") || strTable.Equals("rb")) && strColum.IndexOf("bcrf") > -1)
            {
                strColum = strColum.Replace("bcrf", "gj");
            }
            strSql.Append(" update kfb_setup" + strTable + " set n_" + strColum + "=:value ");
            if (strTable.Equals("sm") || strTable.Equals("lhc") || strTable.Equals("jc539") || strTable.Equals("dlt") || strTable.Equals("cp") || strTable.Equals("ss"))
            {
                strSql.Append(" where n_hydh  in ");
            }
            else
            {
                strSql.Append(" where n_hyzh  in ");
            }
            strSql.Append(" (" + strZH + ") ");
            strSql.Append(" and n_" + strColum + ">:value ");
            OracleParameter[] parameters = {
					new OracleParameter(":value", OracleType.Number,4)
					//new OracleParameter(":ZH", OracleType.VarChar,1000),
                //new OracleParameter(":vas", OracleType.Number,4)
            };
            parameters[0].Value = Math.Round(Convert.ToDecimal(strvalue), 2);
            // parameters[1].Value = strZH;
            //  parameters[1].Value = Convert.ToInt32(strvalue);

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateZHGL(string strColum, string strvalue, string strZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update  kfb_zhgl set " + strColum + "=:value ");
            strSql.Append(" where n_hyzh  in ");
            strSql.Append(" (" + strZH + ") ");
            strSql.Append(" and " + strColum + ">:value ");
            OracleParameter[] parameters = {
					new OracleParameter(":value", OracleType.Number,4)
					//new OracleParameter(":ZH", OracleType.VarChar,1000),
                //new OracleParameter(":vas", OracleType.Number,4)
            };
            parameters[0].Value = Convert.ToInt32(strvalue);
            // parameters[1].Value = strZH;
            //  parameters[1].Value = Convert.ToInt32(strvalue);

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        public string GetMaxID()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT nvl(max(n_id),'0')  FROM kfb_zhgl");
            DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString());
            return GetDS.Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        ///獲得上一級的帳號
        /// </summary>
        public string Getsjzh(string strzh, string strlv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  ");
            if (strlv.Equals("5"))
            {
                strSql.Append(" n_dzjdh ");
            }
            else if (strlv.Equals("6"))
            {
                strSql.Append(" n_zjdh ");
            }
            else if (strlv.Equals("7"))
            {
                strSql.Append(" n_dgddh ");
            }
            else if (strlv.Equals("8"))
            {
                strSql.Append("  n_gddh   ");
            }
            else if (strlv.Equals("9"))
            {
                strSql.Append("  n_zdldh   ");
            }
            strSql.Append("   FROM KFB_ZHGL ");
            strSql.Append(" where  n_hyzh=:n_hyzh  ");
            OracleParameter[] parameters = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100)
				};
            parameters[0].Value = strzh;
            return KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        ///会员
        /// </summary>
        public DataSet GetHYMember(string strname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_hyzh,n_hymc ");
            strSql.Append(" FROM kfb_hygl ");
            strSql.Append(" where 1=1 and  ");
            strSql.Append(" n_dldh=:n_dldh  ");
            OracleParameter[] parameters = {
					new OracleParameter(":n_dldh", OracleType.VarChar,100)
				};
            parameters[0].Value = strname;
            return KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根據大总监得到代理商
        /// </summary>
        /// <returns></returns>
        public DataSet GetDZJ_DLS(string s_aZJZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT");
            strSql.Append(" (n_dzjdh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_dzjdh)||']-'||");
            strSql.Append(" n_zjdh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zjdh)||']-'||");
            strSql.Append(" n_dgddh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_dgddh)||']-'||");
            strSql.Append(" n_gddh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_gddh)||']-'||");
            strSql.Append(" n_zdldh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zdldh)||']-'||");
            strSql.Append(" n_hyzh||'['||n_hymc||']') as DLSName,");
            strSql.Append(" n_dzjdh||'-'||n_zjdh||'-'||n_dgddh||'-'||n_gddh||'-'||n_zdldh||'-'||n_hyzh as DLSID");
            strSql.Append(" from kfb_zhgl A where n_hydj = 9 and n_dzjdh = '" + s_aZJZH + "' order by DLSID desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得会员账号
        /// </summary>
        public DataSet GetHYZH(string s_aDLS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMM,N_HYMC,round(N_KYED) as N_KYED,round(N_SYED) as N_SYED,N_WXDJ,N_YXDL,N_YXXZ,N_DLSJ,N_YCXZ,N_DZXX,N_DZJDH,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_DLDH,N_LQTZ,N_MBTZ,N_RBTZ,N_ZQTZ,N_MZTZ,N_CWCS,N_XZSJ,N_HYIP,N_TBTZ,N_HYJR,N_ZSTZ,N_XGSJ,N_SMTZ,N_CPTZ,N_DLTTZ,N_LHCTZ,N_JCTZ,n_tollgate,N_SSTZ,N_DLDH,N_SFSW,N_SQZT ");
            strSql.Append(" FROM KFB_HYGL ");
            strSql.Append(" where n_dldh ='" + s_aDLS + "'");
            //strSql.Append(" ORDER BY N_ID");
            strSql.Append(" ORDER BY length(N_HYZH),N_HYZH");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 判斷會員是否有注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetZD(string s_aHYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_ptzd ");
            strSql.Append(" where n_hydh ='" + s_aHYZH + "'");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 判斷會員是否有已過帳注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetOZD(string s_aHYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_optzd ");
            strSql.Append(" where n_hydh ='" + s_aHYZH + "'");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMC,N_LLDH,N_MAIL,N_JYBH,N_YHFKID,N_YHFK,N_JYYHID,N_JYYH,N_JYSJ,N_JYJE,N_FKFSID,N_FKFS,N_JYLX,N_JYZT,N_HBDM,N_JYFY,N_DEL,N_XGSJ,N_CKZH,N_BZ,N_CKYH ");
            strSql.Append(" FROM KFB_CASH ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除所有
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="o_aHt"></param>
        public void Delete(string N_HYDH, Hashtable o_aHt)
        {
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);

            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
            mo_KFB_HYGL.Delete(N_HYDH, o_aHt);
        }
        /// <summary>
        /// 消耗會員所屬代理商的信用額度
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public void SetDLSED(string s_aDLS, decimal d_aHYED, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update kfb_zhgl set n_syed = n_syed - :n_syed");
            strSql.Append(" where n_hyzh =:n_hyzh");
            OracleParameter[] parameters = {
					new OracleParameter(":n_hyzh", OracleType.VarChar,100),
					new OracleParameter(":n_syed", OracleType.Number,4)};
            parameters[0].Value = s_aDLS;
            parameters[1].Value = d_aHYED;

            o_aHt.Add(strSql.ToString(), parameters);
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
