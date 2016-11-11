
using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


public class ZZBGDB
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KFB_ZHGL");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
            parameters[0].Value = N_HYZH;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KFB_ZHGL model)
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

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KFB_ZHGL GetModel(string N_HYZH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMM,N_HYMC,N_HYDJ,N_XZSJ,N_HYJRSJ,N_HYXG,N_YXDL from KFB_ZHGL ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
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
                if (ds.Tables[0].Rows[0]["N_HYDJ"].ToString() != "")
                {
                    model.N_HYDJ = int.Parse(ds.Tables[0].Rows[0]["N_HYDJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_XZSJ"].ToString() != "")
                {
                    model.N_XZSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_XZSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYJRSJ"].ToString() != "")
                {
                    model.N_HYJRSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_HYJRSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYXG"].ToString() != "")
                {
                    model.N_HYXG = DateTime.Parse(ds.Tables[0].Rows[0]["N_HYXG"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YXDL"].ToString() != "")
                {
                    model.N_YXDL = int.Parse(ds.Tables[0].Rows[0]["N_YXDL"].ToString());
                }
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
        public void Update(KFB_ZHGL model)
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

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }


        public DataSet GetCreditLogList(string userId, string dates, string datee, string billId, string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select h.n_date,h.n_type,h.n_uid,h.n_creditbefer,h.n_creitafter,p.n_xzdh,p.n_xzje,p.n_hyjg_b,p.n_hyjg_a ");
            strSql.Append(" from kfb_ptzdlog p right join kfb_hycreditlog h on h.n_id=p.n_id");
            strSql.Append(" where h.n_uid=:n_uid and h.n_date between :n_dates and :n_datee");
            if (type != "-1")
            {
                strSql.Append(" and h.n_type=:n_type");
            }
            else
            {
                strSql.Append(" and :n_type=:n_type");
            }
            if (billId != "")
            {
                strSql.Append(" and p.n_xzdh=:n_xzdh");
            }
            else
            {
                strSql.Append(" and :n_xzdh is null");
            }
            strSql.Append(" order by h.n_id desc");
            OracleParameter[] parameters = {
					new OracleParameter(":n_uid", OracleType.VarChar,30),
					new OracleParameter(":n_dates", OracleType.DateTime),
					new OracleParameter(":n_datee", OracleType.DateTime),
					new OracleParameter(":n_type", OracleType.VarChar,2),
					new OracleParameter(":n_xzdh", OracleType.VarChar,30)
            };
            parameters[0].Value = userId;
            parameters[1].Value = Convert.ToDateTime(dates);
            parameters[2].Value = Convert.ToDateTime(datee).AddDays(1);
            parameters[3].Value = type;
            parameters[4].Value = billId;

            return DbHelperOra.Query(strSql.ToString(), parameters);
        }
    }

