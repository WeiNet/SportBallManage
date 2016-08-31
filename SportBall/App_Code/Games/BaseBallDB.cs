using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
