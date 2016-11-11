using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class NoticeDB
    {

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_CODE,N_NAME ");
            strSql.Append(" FROM KFB_SITE ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetNoticeList(string strDates, string strDatee)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_NR,N_YXSJ,N_QDXX,N_FBDX,N_XXTT,N_FBSJ,N_NR_EN,N_NR_CN,N_NR_TW,N_NR_TH,S.N_NAME ");
            strSql.Append(" FROM KFB_XXGL X LEFT JOIN KFB_SITE S ON X.N_FBDX = S.N_CODE");
            if (!strDates.Equals(String.Empty) && !strDates.Equals(String.Empty))
            {
                strSql.Append(" where X.N_FBSJ BETWEEN TO_DATE(:N_DATES,'YYYY/MM/DD') AND TO_DATE(:N_DATEE,'YYYY/MM/DD')+1");
            }
            OracleParameter[] parameters = {
					new OracleParameter(":N_DATES", OracleType.VarChar,10),
					new OracleParameter(":N_DATEE", OracleType.VarChar,10)};
            parameters[0].Value = strDates;
            parameters[1].Value = strDatee;
            strSql.Append(" ORDER BY N_FBSJ DESC");
            return DbHelperOra.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int N_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete KFB_XXGL ");
            strSql.Append(" where N_ID=:N_ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4)};
            parameters[0].Value = N_ID;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  KFB_XXGL GetModel(int N_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_NR,N_YXSJ,N_QDXX,N_FBDX,N_XXTT,N_FBSJ,N_NR_EN,N_NR_CN,N_NR_TW,N_NR_TH from KFB_XXGL ");
            strSql.Append(" where N_ID=:N_ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4)};
            parameters[0].Value = N_ID;

             KFB_XXGL model = new  KFB_XXGL();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["N_ID"].ToString() != "")
                {
                    model.N_ID = int.Parse(ds.Tables[0].Rows[0]["N_ID"].ToString());
                }
                model.N_NR = ds.Tables[0].Rows[0]["N_NR"].ToString();
                if (ds.Tables[0].Rows[0]["N_YXSJ"].ToString() != "")
                {
                    model.N_YXSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_YXSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_QDXX"].ToString() != "")
                {
                    model.N_QDXX = int.Parse(ds.Tables[0].Rows[0]["N_QDXX"].ToString());
                }
                model.N_FBDX = ds.Tables[0].Rows[0]["N_FBDX"].ToString();
                model.N_XXTT = ds.Tables[0].Rows[0]["N_XXTT"].ToString();
                if (ds.Tables[0].Rows[0]["N_FBSJ"].ToString() != "")
                {
                    model.N_FBSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_FBSJ"].ToString());
                }
                model.N_NR_EN = ds.Tables[0].Rows[0]["N_NR_EN"].ToString();
                model.N_NR_CN = ds.Tables[0].Rows[0]["N_NR_CN"].ToString();
                model.N_NR_TW = ds.Tables[0].Rows[0]["N_NR_TW"].ToString();
                model.N_NR_TH = ds.Tables[0].Rows[0]["N_NR_TH"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KFB_XXGL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_XXGL set ");
            strSql.Append("N_ID=:N_ID,");
            strSql.Append("N_NR=:N_NR,");
            strSql.Append("N_YXSJ=:N_YXSJ,");
            strSql.Append("N_QDXX=:N_QDXX,");
            strSql.Append("N_FBDX=:N_FBDX,");
            strSql.Append("N_XXTT=:N_XXTT,");
            strSql.Append("N_FBSJ=:N_FBSJ,");
            strSql.Append("N_NR_EN=:N_NR_EN,");
            strSql.Append("N_NR_CN=:N_NR_CN,");
            strSql.Append("N_NR_TW=:N_NR_TW,");
            strSql.Append("N_NR_TH=:N_NR_TH");
            strSql.Append(" where N_ID=:N_ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4),
					new OracleParameter(":N_NR", OracleType.VarChar,4000),
					new OracleParameter(":N_YXSJ", OracleType.DateTime),
					new OracleParameter(":N_QDXX", OracleType.Number,4),
					new OracleParameter(":N_FBDX", OracleType.VarChar,50),
					new OracleParameter(":N_XXTT", OracleType.VarChar,1000),
					new OracleParameter(":N_FBSJ", OracleType.DateTime),
                    new OracleParameter(":N_NR_EN", OracleType.VarChar,4000),
                    new OracleParameter(":N_NR_CN", OracleType.VarChar,4000),
                    new OracleParameter(":N_NR_TW", OracleType.VarChar,4000),
                    new OracleParameter(":N_NR_TH", OracleType.VarChar,4000)
            };
            parameters[0].Value = model.N_ID;
            parameters[1].Value = model.N_NR;
            parameters[2].Value = model.N_YXSJ;
            parameters[3].Value = model.N_QDXX;
            parameters[4].Value = model.N_FBDX;
            parameters[5].Value = model.N_XXTT;
            parameters[6].Value = model.N_FBSJ;
            parameters[7].Value = model.N_NR_EN;
            parameters[8].Value = model.N_NR_CN;
            parameters[9].Value = model.N_NR_TW;
            parameters[10].Value = model.N_NR_TH;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KFB_XXGL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_XXGL(");
            strSql.Append("N_ID,N_NR,N_YXSJ,N_QDXX,N_FBDX,N_XXTT,N_FBSJ,N_NR_EN,N_NR_CN,N_NR_TW,N_NR_TH)");
            strSql.Append(" values (");
            strSql.Append("EXAMPLE_SEQ.nextval,:N_NR,:N_YXSJ,:N_QDXX,:N_FBDX,:N_XXTT,:N_FBSJ,:N_NR_EN,:N_NR_CN,:N_NR_TW,:N_NR_TH)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_NR", OracleType.VarChar,4000),
					new OracleParameter(":N_YXSJ", OracleType.DateTime),
					new OracleParameter(":N_QDXX", OracleType.Number,4),
					new OracleParameter(":N_FBDX", OracleType.VarChar,50),
					new OracleParameter(":N_XXTT", OracleType.VarChar,1000),
					new OracleParameter(":N_FBSJ", OracleType.DateTime),
                    new OracleParameter(":N_NR_EN", OracleType.VarChar,4000),
                    new OracleParameter(":N_NR_CN", OracleType.VarChar,4000),
                    new OracleParameter(":N_NR_TW", OracleType.VarChar,4000),
                    new OracleParameter(":N_NR_TH", OracleType.VarChar,4000)
            };
            parameters[0].Value = model.N_NR;
            parameters[1].Value = model.N_YXSJ;
            parameters[2].Value = model.N_QDXX;
            parameters[3].Value = model.N_FBDX;
            parameters[4].Value = model.N_XXTT;
            parameters[5].Value = model.N_FBSJ;
            parameters[6].Value = model.N_NR_EN;
            parameters[7].Value = model.N_NR_CN;
            parameters[8].Value = model.N_NR_TW;
            parameters[9].Value = model.N_NR_TH;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
    }
