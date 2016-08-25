using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;


    public class DelayedManagerDB
    {
        /// <summary>
        /// 得到延時賬號列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMM,N_HYMC,N_HYDJ,N_YXDL,N_HYDLCW,N_DZJDH,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,ROUND(N_KYED,0) AS N_KYED,ROUND(N_SYED,0) AS N_SYED,N_HYDLIP,N_XZSJ,N_ZQCZ,N_LQCZ,N_MZCZ,N_MBCZ,N_RBCZ,N_DLDH,N_TBCZ,N_HYJRSJ,N_XZYC,N_ZSCZ,N_HYXG,N_SMCZ,N_DLTCZ,N_CPCZ,N_LHCCZ,N_JCCZ,N_2XCZ,N_3XCZ,N_4XCZ,N_SSCZ,N_DHHM,N_MAIL,N_QQ ");
            strSql.Append(" FROM KFB_ZHGL ");
            strSql.Append(" where n_xzyc=1 ORDER BY N_HYZH");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到延時會員列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetGLList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMM,N_HYMC,ROUND(N_KYED,0) AS N_KYED,ROUND(N_SYED,0) AS N_SYED,N_WXDJ,N_YXDL,N_YXXZ,N_DLSJ,N_YCXZ,N_DZXX,N_DZJDH,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_DLDH,N_LQTZ,N_MBTZ,N_RBTZ,N_ZQTZ,N_MZTZ,N_CWCS,N_XZSJ,N_HYIP,N_TBTZ,N_HYJR,N_ZSTZ,N_XGSJ,N_SMTZ,N_CPTZ,N_DLTTZ,N_LHCTZ,N_JCTZ,N_TOLLGATE,N_SSTZ,N_DLDH,N_SFSW ");
            strSql.Append(" FROM KFB_HYGL ");
            strSql.Append(" where n_ycxz>0 ORDER BY N_HYZH");
            return DbHelperOra.Query(strSql.ToString());
        }
    }
