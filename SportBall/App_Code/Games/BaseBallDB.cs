using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class BaseBallDB
    {
        /// <summary>
        /// 計算時查詢的值
        /// </summary>
        /// <param name="s_aN_ID"></param>
        /// <returns></returns>
        public DataSet GetRusult(string s_aN_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.n_gamedate,n_home_result,n_visit_result,n_up_visit_result,n_up_home_result,n_sf9j,n_remark,n_counttime,");
            strSql.Append(" (case t.n_vh when t.n_visit then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit) end");
            strSql.Append(" ||' VS '||");
            strSql.Append(" case t.n_vh when t.n_home then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home) end ) as dw ,");
            strSql.Append(" case t.n_cbxh when 1 then '全场' when 2 then '上半场' when 4 then '下半场' end as CB,");
            strSql.Append(" (select l.n_lmmc from kfb_lmgl l where l.n_no = t.n_lmno) as lm,N_VISIT_NO");
            strSql.Append(" FROM KFB_BASEBALL t where t.n_id=" + s_aN_ID);
            strSql.Append(" UNION select t.n_gamedate,n_home_result,n_visit_result,n_up_visit_result,n_up_home_result,n_sf9j,n_remark,n_counttime,");
            strSql.Append(" (case t.n_vh when t.n_visit then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_visit) end");
            strSql.Append(" ||' VS '||");
            strSql.Append(" case t.n_vh when t.n_home then (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home)||'[主]' else (select d.n_dwmc from kfb_dwgl d where d.n_id=t.n_home) end ) as dw ,");
            strSql.Append(" case t.n_cbxh when 1 then '全场' when 2 then '上半场' when 4 then '下半场' end as CB,");
            strSql.Append(" (select l.n_lmmc from kfb_lmgl l where l.n_no = t.n_lmno) as lm,N_VISIT_NO");
            strSql.Append(" FROM KFB_ACCBALL t where t.n_id=" + s_aN_ID);
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到賽事隊伍
        /// </summary>
        /// <param name="s_N_ID"></param>
        /// <returns></returns>
        public string GetDW(string s_N_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" (select d.n_dwmc from kfb_dwgl d where d.n_id = b.n_visit)||case b.n_vh when b.n_visit then '[主]' else '' end");
            strSql.Append(" ||'   '||");
            strSql.Append(" (select d.n_dwmc from kfb_dwgl d where d.n_id = b.n_home)||case b.n_vh when b.n_home then '[主]' else '' end");
            strSql.Append(" from kfb_baseball b where b.n_id=" + s_N_ID);
            return Convert.ToString(DbHelperOra.GetSingle(strSql.ToString()));
        }
        public string GetHyName(string strid)
        {
            string strname = "";
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" select N_HYMC from kfb_zhgl where n_hyzh=:n_hyzh UNION select N_HYMC from kfb_hygl where n_hyzh=:n_hyzh ");

            OracleParameter[] parameters = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100)                            
            };
            parameters[0].Value = strid;

            //KingOfBall.Model.KFB_ZHGL model = new KingOfBall.Model.KFB_ZHGL();
            DataSet ds = DbHelperOra.Query(strSqlup.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                strname = ds.Tables[0].Rows[0][0].ToString();
            }
            return strname;
        }
        /// <summary>
        /// 刪除注單(原因)
        /// </summary>
        /// <param name="s_BillID"></param>
        /// <param name="s_Del"></param>
        public int DeleteBill(string s_BillID, int s_Del, string s_DelYY, string s_XGJL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_PTZD set");
            strSql.Append(" N_DEL=:N_DEL,");
            strSql.Append(" N_DELYY=:N_DELYY,");
            strSql.Append(" N_XGJL=:N_XGJL");
            strSql.Append(" WHERE N_XZDH=:N_XZDH");
            OracleParameter[] parameters = {
					new OracleParameter(":N_DEL", OracleType.Number,1),
                    new OracleParameter(":N_DELYY", OracleType.VarChar,100),
                    new OracleParameter(":N_XGJL", OracleType.VarChar,100),
					new OracleParameter(":N_XZDH", OracleType.VarChar,50)};
            parameters[0].Value = s_Del;
            parameters[1].Value = s_DelYY;
            parameters[2].Value = s_XGJL;
            parameters[3].Value = s_BillID;

           return  DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 刪除注單(已過帳)(原因)
        /// </summary>
        /// <param name="s_BillID"></param>
        /// <param name="s_Del"></param>
        public int DeleteBillHis(string s_BillID, int s_Del, string s_DelYY, string s_XGJL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_OPTZD set");
            strSql.Append(" N_DEL=:N_DEL,");
            strSql.Append(" N_DELYY=:N_DELYY,");
            strSql.Append(" N_XGJL=:N_XGJL");
            strSql.Append(" WHERE N_XZDH=:N_XZDH");
            OracleParameter[] parameters = {
					new OracleParameter(":N_DEL", OracleType.Number,1),
                    new OracleParameter(":N_DELYY", OracleType.VarChar,100),
                    new OracleParameter(":N_XGJL", OracleType.VarChar,100),
					new OracleParameter(":N_XZDH", OracleType.VarChar,50)};
            parameters[0].Value = s_Del;
            parameters[1].Value = s_DelYY;
            parameters[2].Value = s_XGJL;
            parameters[3].Value = s_BillID;

           return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

    }
