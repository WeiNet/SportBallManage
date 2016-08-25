#region Histroy
///程式代號：      SystemSetDB
///程式名稱：      SystemSetDB
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE
#endregion
#region Using
using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;
#endregion

public class SystemSetDB
    {

        internal System.Data.DataSet getData()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from KFB_XTSZ ");
            //strSql.Append(" where N_XTMS=:N_XTMS ");
            //OracleParameter[] parameters = {
            //        new OracleParameter(":N_XTMS", OracleType.VarChar,50)};
            //parameters[0].Value = N_XTMS;

         
            DataSet ds = DbHelperOra.Query(strSql.ToString());
            return ds;
        }
        /// <summary>
        /// 重設剩餘額度
        /// </summary>
        public void ResetED()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_syed=n_kyed");
            DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 修改重設會員額度日期
        /// </summary>
        /// <param name="N_CX"></param>
        public void UpdateResetEDDate(string N_CSED)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_XTSZ set ");
            strSql.Append("N_CSED=:N_CSED");
            OracleParameter[] parameters = {
					new OracleParameter(":N_CSED", OracleType.Number,8)};
            parameters[0].Value = N_CSED;
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KFB_XTSZ");
            return DbHelperOra.Exists(strSql.ToString());
        }

        internal int Update(KFB_XTSZ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_XTSZ set ");
            strSql.Append("N_XTMS=:N_XTMS,");
            strSql.Append("N_ZWRQ=:N_ZWRQ,");
            strSql.Append("N_GZZWRQ=:N_GZZWRQ,");
            strSql.Append("N_BLTS=:N_BLTS,");
            strSql.Append("N_HL=:N_HL,");
            strSql.Append("N_HUSY=:N_HUSY,");
            strSql.Append("N_HUXY=:N_HUXY,");
            strSql.Append("N_WXJE=:N_WXJE,");
            strSql.Append("N_YCXZ=:N_YCXZ,");
            strSql.Append("N_ZDYC=:N_ZDYC,");
            strSql.Append("N_ZQBPL=:N_ZQBPL,");
            strSql.Append("N_ZQAPL=:N_ZQAPL,");
            strSql.Append("N_GBHY=:N_GBHY,");
            strSql.Append("N_CPIP=:N_CPIP,");
            strSql.Append("N_GGXS=:N_GGXS,");
            strSql.Append("N_CX=:N_CX,");
            strSql.Append("N_XGCZ=:N_XGCZ,");
            strSql.Append("N_HYXX=:N_HYXX,");
            strSql.Append("N_RZCX=:N_RZCX,");
            strSql.Append("N_CXBB=:N_CXBB,");
            strSql.Append("N_STATE_JUMPED=:N_STATE_JUMPED,");
            strSql.Append("N_JUMPED_CREDIT_SPECIAL=:N_JUMPED_CREDIT_SPECIAL,");
            strSql.Append("N_JUMPED_RATE_SPECIAL=:N_JUMPED_RATE_SPECIAL,");
            strSql.Append("N_JUMPED_CREDIT_GENERAL=:N_JUMPED_CREDIT_GENERAL,");
            strSql.Append("N_JUMPED_RATE_GENERAL=:N_JUMPED_RATE_GENERAL,");
            strSql.Append("N_JUMPED_MAX_SPECIAL=:N_JUMPED_MAX_SPECIAL,");
            strSql.Append("N_JUMPED_MAX_GENERAL=:N_JUMPED_MAX_GENERAL,");
            strSql.Append("N_DELAY_TIMES=:N_DELAY_TIMES,");
            strSql.Append("N_DELAY_TIME=:N_DELAY_TIME,");
            strSql.Append("N_ISGGLOCK=:N_ISGGLOCK,");
            strSql.Append("N_ISDSLOCK=:N_ISDSLOCK,");
            strSql.Append("N_ISZDLOCK=:N_ISZDLOCK,");
            strSql.Append("N_ISBDLOCK=:N_ISBDLOCK,");
            strSql.Append("N_ISRQSLOCK=:N_ISRQSLOCK,");
            strSql.Append("N_ISBQCLOCK=:N_ISBQCLOCK,");
            strSql.Append("N_ISZCLOCK=:N_ISZCLOCK");
            //strSql.Append(" where N_XTMS=:N_XTMS ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_XTMS", OracleType.VarChar,50),
					new OracleParameter(":N_ZWRQ", OracleType.DateTime),
					new OracleParameter(":N_GZZWRQ", OracleType.DateTime),
					new OracleParameter(":N_BLTS", OracleType.Number,4),
					new OracleParameter(":N_HL", OracleType.Float,22),
					new OracleParameter(":N_HUSY", OracleType.Number,4),
					new OracleParameter(":N_HUXY", OracleType.Float,22),
					new OracleParameter(":N_WXJE", OracleType.Float,22),
					new OracleParameter(":N_YCXZ", OracleType.Number,4),
					new OracleParameter(":N_ZDYC", OracleType.Number,4),
					new OracleParameter(":N_ZQBPL", OracleType.Float,22),
					new OracleParameter(":N_ZQAPL", OracleType.Float,22),
					new OracleParameter(":N_GBHY", OracleType.Number,4),
					new OracleParameter(":N_CPIP", OracleType.VarChar,4000),
					new OracleParameter(":N_GGXS", OracleType.Float,22),
					new OracleParameter(":N_CX", OracleType.Number,4),
					new OracleParameter(":N_XGCZ", OracleType.Number,4),
					new OracleParameter(":N_HYXX", OracleType.Float,22),
					new OracleParameter(":N_RZCX", OracleType.Number,4),
                    new OracleParameter(":N_CXBB", OracleType.Number,4),
                    new OracleParameter(":N_STATE_JUMPED", OracleType.Number),
                    new OracleParameter(":N_JUMPED_CREDIT_SPECIAL", OracleType.Number),
                    new OracleParameter(":N_JUMPED_RATE_SPECIAL", OracleType.Number),
                    new OracleParameter(":N_JUMPED_CREDIT_GENERAL", OracleType.Number),
                    new OracleParameter(":N_JUMPED_RATE_GENERAL", OracleType.Number),
                    new OracleParameter(":N_JUMPED_MAX_SPECIAL", OracleType.Number),
                    new OracleParameter(":N_JUMPED_MAX_GENERAL", OracleType.Number),
                    new OracleParameter(":N_DELAY_TIMES", OracleType.Number),
                    new OracleParameter(":N_DELAY_TIME", OracleType.Number),
                    new OracleParameter(":N_ISGGLOCK", OracleType.Number),
                    new OracleParameter(":N_ISDSLOCK", OracleType.Number),
                    new OracleParameter(":N_ISZDLOCK", OracleType.Number),
                    new OracleParameter(":N_ISBDLOCK", OracleType.Number),
                    new OracleParameter(":N_ISRQSLOCK", OracleType.Number),
                    new OracleParameter(":N_ISBQCLOCK", OracleType.Number),
                    new OracleParameter(":N_ISZCLOCK", OracleType.Number)};
            parameters[0].Value = model.N_XTMS;
            parameters[1].Value = model.N_ZWRQ;
            parameters[2].Value = model.N_GZZWRQ;
            parameters[3].Value = model.N_BLTS;
            parameters[4].Value = model.N_HL;
            parameters[5].Value = model.N_HUSY;
            parameters[6].Value = model.N_HUXY;
            parameters[7].Value = model.N_WXJE;
            parameters[8].Value = model.N_YCXZ;
            parameters[9].Value = model.N_ZDYC;
            parameters[10].Value = model.N_ZQBPL;
            parameters[11].Value = model.N_ZQAPL;
            parameters[12].Value = model.N_GBHY;
            parameters[13].Value = model.N_CPIP;
            parameters[14].Value = model.N_GGXS;
            parameters[15].Value = model.N_CX;
            parameters[16].Value = model.N_XGCZ;
            parameters[17].Value = model.N_HYXX;
            parameters[18].Value = model.N_RZCX;
            parameters[19].Value = model.N_CXBB;
            parameters[20].Value = model.N_STATE_JUMPED;
            parameters[21].Value = model.N_JUMPED_CREDIT_SPECIAL;
            parameters[22].Value = model.N_JUMPED_RATE_SPECIAL;
            parameters[23].Value = model.N_JUMPED_CREDIT_GENERAL;
            parameters[24].Value = model.N_JUMPED_RATE_GENERAL;
            parameters[25].Value = model.N_JUMPED_MAX_SPECIAL;
            parameters[26].Value = model.N_JUMPED_MAX_GENERAL;
            parameters[27].Value = model.N_DELAY_TIMES;
            parameters[28].Value = model.N_DELAY_TIME;
            parameters[29].Value = model.N_ISGGLOCK;
            parameters[30].Value = model.N_ISDSLOCK;
            parameters[31].Value = model.N_ISZDLOCK;
            parameters[32].Value = model.N_ISBDLOCK;
            parameters[33].Value = model.N_ISRQSLOCK;
            parameters[34].Value = model.N_ISBQCLOCK;
            parameters[35].Value = model.N_ISZCLOCK;

          return  DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        internal int Add(KFB_XTSZ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_XTSZ(");
            strSql.Append("N_XTMS,N_ZWRQ,N_GZZWRQ,N_BLTS,N_HL,N_HUSY,N_HUXY,N_WXJE,N_YCXZ,N_ZDYC,N_ZQBPL,N_ZQAPL,N_GBHY,N_CPIP,N_GGXS,N_CX,N_XGCZ,N_HYXX,N_RZCX,N_ISGGLOCK)");
            strSql.Append(" values (");
            strSql.Append(":N_XTMS,:N_ZWRQ,:N_GZZWRQ,:N_BLTS,:N_HL,:N_HUSY,:N_HUXY,:N_WXJE,:N_YCXZ,:N_ZDYC,:N_ZQBPL,:N_ZQAPL,:N_GBHY,:N_CPIP,:N_GGXS,:N_CX,:N_XGCZ,:N_HYXX,:N_RZCX:N_ISGGLOCK)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_XTMS", OracleType.VarChar,50),
					new OracleParameter(":N_ZWRQ", OracleType.DateTime),
					new OracleParameter(":N_GZZWRQ", OracleType.DateTime),
					new OracleParameter(":N_BLTS", OracleType.Number,4),
					new OracleParameter(":N_HL", OracleType.Float,22),
					new OracleParameter(":N_HUSY", OracleType.Number,4),
					new OracleParameter(":N_HUXY", OracleType.Float,22),
					new OracleParameter(":N_WXJE", OracleType.Float,22),
					new OracleParameter(":N_YCXZ", OracleType.Number,4),
					new OracleParameter(":N_ZDYC", OracleType.Number,4),
					new OracleParameter(":N_ZQBPL", OracleType.Float,22),
					new OracleParameter(":N_ZQAPL", OracleType.Float,22),
					new OracleParameter(":N_GBHY", OracleType.Number,4),
					new OracleParameter(":N_CPIP", OracleType.VarChar,4000),
					new OracleParameter(":N_GGXS", OracleType.Float,22),
					new OracleParameter(":N_CX", OracleType.Number,4),
					new OracleParameter(":N_XGCZ", OracleType.Number,4),
					new OracleParameter(":N_HYXX", OracleType.Float,22),
					new OracleParameter(":N_RZCX", OracleType.Number,4),
					new OracleParameter(":N_ISGGLOCK", OracleType.Number,1)};
            parameters[0].Value = model.N_XTMS;
            parameters[1].Value = model.N_ZWRQ;
            parameters[2].Value = model.N_GZZWRQ;
            parameters[3].Value = model.N_BLTS;
            parameters[4].Value = model.N_HL;
            parameters[5].Value = model.N_HUSY;
            parameters[6].Value = model.N_HUXY;
            parameters[7].Value = model.N_WXJE;
            parameters[8].Value = model.N_YCXZ;
            parameters[9].Value = model.N_ZDYC;
            parameters[10].Value = model.N_ZQBPL;
            parameters[11].Value = model.N_ZQAPL;
            parameters[12].Value = model.N_GBHY;
            parameters[13].Value = model.N_CPIP;
            parameters[14].Value = model.N_GGXS;
            parameters[15].Value = model.N_CX;
            parameters[16].Value = model.N_XGCZ;
            parameters[17].Value = model.N_HYXX;
            parameters[18].Value = model.N_RZCX;
            parameters[19].Value = model.N_ISGGLOCK;

          return  DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KFB_XTSZ GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from KFB_XTSZ ");
            //strSql.Append(" where N_XTMS=:N_XTMS ");
            //OracleParameter[] parameters = {
            //        new OracleParameter(":N_XTMS", OracleType.VarChar,50)};
            //parameters[0].Value = N_XTMS;

          KFB_XTSZ model = new KFB_XTSZ();
            DataSet ds = DbHelperOra.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.N_XTMS = ds.Tables[0].Rows[0]["N_XTMS"].ToString();
                if (ds.Tables[0].Rows[0]["N_ZWRQ"].ToString() != "")
                {
                    model.N_ZWRQ = DateTime.Parse(ds.Tables[0].Rows[0]["N_ZWRQ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_GZZWRQ"].ToString() != "")
                {
                    model.N_GZZWRQ = DateTime.Parse(ds.Tables[0].Rows[0]["N_GZZWRQ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_BLTS"].ToString() != "")
                {
                    model.N_BLTS = int.Parse(ds.Tables[0].Rows[0]["N_BLTS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HL"].ToString() != "")
                {
                    model.N_HL = decimal.Parse(ds.Tables[0].Rows[0]["N_HL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HUSY"].ToString() != "")
                {
                    model.N_HUSY = int.Parse(ds.Tables[0].Rows[0]["N_HUSY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HUXY"].ToString() != "")
                {
                    model.N_HUXY = decimal.Parse(ds.Tables[0].Rows[0]["N_HUXY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_WXJE"].ToString() != "")
                {
                    model.N_WXJE = decimal.Parse(ds.Tables[0].Rows[0]["N_WXJE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YCXZ"].ToString() != "")
                {
                    model.N_YCXZ = int.Parse(ds.Tables[0].Rows[0]["N_YCXZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZDYC"].ToString() != "")
                {
                    model.N_ZDYC = int.Parse(ds.Tables[0].Rows[0]["N_ZDYC"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZQBPL"].ToString() != "")
                {
                    model.N_ZQBPL = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQBPL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZQAPL"].ToString() != "")
                {
                    model.N_ZQAPL = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQAPL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_GBHY"].ToString() != "")
                {
                    model.N_GBHY = int.Parse(ds.Tables[0].Rows[0]["N_GBHY"].ToString());
                }
                model.N_CPIP = ds.Tables[0].Rows[0]["N_CPIP"].ToString();
                if (ds.Tables[0].Rows[0]["N_GGXS"].ToString() != "")
                {
                    model.N_GGXS = decimal.Parse(ds.Tables[0].Rows[0]["N_GGXS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_CX"].ToString() != "")
                {
                    model.N_CX = int.Parse(ds.Tables[0].Rows[0]["N_CX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_XGCZ"].ToString() != "")
                {
                    model.N_XGCZ = int.Parse(ds.Tables[0].Rows[0]["N_XGCZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYXX"].ToString() != "")
                {
                    model.N_HYXX = decimal.Parse(ds.Tables[0].Rows[0]["N_HYXX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_RZCX"].ToString() != "")
                {
                    model.N_RZCX = int.Parse(ds.Tables[0].Rows[0]["N_RZCX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SFQR"].ToString() != "")
                {
                    model.N_SFQR = int.Parse(ds.Tables[0].Rows[0]["N_SFQR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_CSED"].ToString() != "")
                {
                    model.N_CSED = ds.Tables[0].Rows[0]["N_CSED"].ToString();
                }
                if (ds.Tables[0].Rows[0]["N_CXBB"].ToString() != "")
                {
                    model.N_CXBB = int.Parse(ds.Tables[0].Rows[0]["N_CXBB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_STATE_JUMPED"].ToString() != "")
                {
                    model.N_STATE_JUMPED = int.Parse(ds.Tables[0].Rows[0]["N_STATE_JUMPED"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JUMPED_CREDIT_SPECIAL"].ToString() != "")
                {
                    model.N_JUMPED_CREDIT_SPECIAL = decimal.Parse(ds.Tables[0].Rows[0]["N_JUMPED_CREDIT_SPECIAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JUMPED_RATE_SPECIAL"].ToString() != "")
                {
                    model.N_JUMPED_RATE_SPECIAL = decimal.Parse(ds.Tables[0].Rows[0]["N_JUMPED_RATE_SPECIAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JUMPED_CREDIT_GENERAL"].ToString() != "")
                {
                    model.N_JUMPED_CREDIT_GENERAL = decimal.Parse(ds.Tables[0].Rows[0]["N_JUMPED_CREDIT_GENERAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JUMPED_RATE_GENERAL"].ToString() != "")
                {
                    model.N_JUMPED_RATE_GENERAL = decimal.Parse(ds.Tables[0].Rows[0]["N_JUMPED_RATE_GENERAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JUMPED_MAX_SPECIAL"].ToString() != "")
                {
                    model.N_JUMPED_MAX_SPECIAL = int.Parse(ds.Tables[0].Rows[0]["N_JUMPED_MAX_SPECIAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JUMPED_MAX_GENERAL"].ToString() != "")
                {
                    model.N_JUMPED_MAX_GENERAL = int.Parse(ds.Tables[0].Rows[0]["N_JUMPED_MAX_GENERAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DELAY_TIMES"].ToString() != "")
                {
                    model.N_DELAY_TIMES = int.Parse(ds.Tables[0].Rows[0]["N_DELAY_TIMES"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DELAY_TIME"].ToString() != "")
                {
                    model.N_DELAY_TIME = int.Parse(ds.Tables[0].Rows[0]["N_DELAY_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ISGGLOCK"].ToString() != "")
                {
                    model.N_ISGGLOCK = int.Parse(ds.Tables[0].Rows[0]["N_ISGGLOCK"].ToString());
                }

                if (ds.Tables[0].Rows[0]["N_ISDSLOCK"].ToString() != "")
                {
                    model.N_ISDSLOCK = int.Parse(ds.Tables[0].Rows[0]["N_ISDSLOCK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ISZDLOCK"].ToString() != "")
                {
                    model.N_ISZDLOCK = int.Parse(ds.Tables[0].Rows[0]["N_ISZDLOCK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ISBDLOCK"].ToString() != "")
                {
                    model.N_ISBDLOCK = int.Parse(ds.Tables[0].Rows[0]["N_ISBDLOCK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ISRQSLOCK"].ToString() != "")
                {
                    model.N_ISRQSLOCK = int.Parse(ds.Tables[0].Rows[0]["N_ISRQSLOCK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ISBQCLOCK"].ToString() != "")
                {
                    model.N_ISBQCLOCK = int.Parse(ds.Tables[0].Rows[0]["N_ISBQCLOCK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ISZCLOCK"].ToString() != "")
                {
                    model.N_ISZCLOCK = int.Parse(ds.Tables[0].Rows[0]["N_ISZCLOCK"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
