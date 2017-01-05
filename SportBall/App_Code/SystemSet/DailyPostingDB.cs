#region Histroy
using KingOfBall;
///程式代號：      DailyPostingDB
///程式名稱：      DailyPostingDB
///程式說明：      
///xx.YYYY/MM/DD   VER     AUTHOR       COMMENTS(說明修改的內容)		
///01.2016/08/04          1.00      Abel  	       	CREATE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion



public class DailyPostingDB
{
    /// <summary>
    /// 取得过帐记录
    /// </summary>
    public DataSet getPostingData()
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select * from kfb_lsgz  order by N_zwrq desc  ");

        return DbHelperOra.Query(strSql.ToString());
    }
    /// <summary>
    /// 注单　
    /// </summary>
    public string GetZWZD(string strzwrq, string strtype)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select nvl( sum(counts),0) counts from (  ");
        strSql.Append(" select nvl( count(distinct n_xzdh),0) counts  from kfb_ptzd  ");
        strSql.Append(" where  nvl(n_js,0)!='1' and  nvl(n_del,0)!='1' and to_char(n_zwrq,'yyyy/MM/dd') =:zwrq");
        if (strtype.Equals("1"))
        {
            strSql.Append(" and n_gsty<>3 ");
        }
        else
        {
            strSql.Append(" and n_gsty=3 ");
        }
        strSql.Append(" and n_bslx<>'b_cp' ");

        strSql.Append(" union all ");

        strSql.Append(" select round(power(10, Sum(Log(10, xznum))),0) as xznum from ( select n_bslx, n_xzdh, nvl(length(n_zddy)/2+0.5 ,1) as xznum from kfb_ptzd  ");
        strSql.Append(" where  nvl(n_js,0)!='1' and  nvl(n_del,0)!='1' and to_char(n_zwrq,'yyyy/MM/dd') =:zwrq");
        if (strtype.Equals("1"))
        {
            strSql.Append(" and n_gsty<>3 ");
        }
        else
        {
            strSql.Append(" and n_gsty=3  ");
        }
        strSql.Append(" and n_bslx='b_cp' ");
        strSql.Append(" ) a  group by n_bslx,n_xzdh ) ");

        OracleParameter[] parameters = {
					new OracleParameter(":zwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;

        return DbHelperOra.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString();
    }
    /// <summary>
    /// 注单　明細
    /// </summary>
    public DataSet GetZWZDMX(string strzwrq, string strtype)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append("  select  n_bslx,nvl( count( distinct n_xzdh),0) counts  from kfb_ptzd ");
        strSql.Append(" where nvl(n_js,0)!='1' and  nvl(n_del,0)!='1' and to_char(n_zwrq,'yyyy/MM/dd') =:zwrq ");
        if (strtype.Equals("0"))
        {
            strSql.Append(" and '1'='1'  ");
        }
        else if (strtype.Equals("1"))
        {
            strSql.Append(" and n_gsty<>3 ");
        }
        else
        {
            strSql.Append(" and n_gsty=3 ");
        }
        strSql.Append(" and n_bslx<>'b_cp' ");
        strSql.Append(" group by n_bslx  ");

        strSql.Append(" union  ");

        strSql.Append("  select n_bslx ,sum(xznum) counts  from ( ");
        strSql.Append("  select n_bslx ,n_xzdh,round(power(10, Sum(Log(10, xznum))),0) as xznum from ( select n_bslx, n_xzdh, nvl(length(n_zddy)/2+0.5 ,1) as xznum from kfb_ptzd ");
        strSql.Append("  where nvl(n_js,0)!='1' and  nvl(n_del,0)!='1' and to_char(n_zwrq,'yyyy/MM/dd') =:zwrq ");
        if (strtype.Equals("0"))
        {
            strSql.Append(" and '1'='1'  ");
        }
        else if (strtype.Equals("1"))
        {
            strSql.Append(" and n_gsty<>3 ");
        }
        else
        {
            strSql.Append(" and n_gsty=3 ");
        }
        strSql.Append(" and n_bslx='b_cp' ");
        strSql.Append(") a  group by n_bslx,n_xzdh ) b ");
        strSql.Append(" group by n_bslx  ");


        OracleParameter[] parameters = {
					new OracleParameter(":zwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;

        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 查询比赛结果的联盟
    /// </summary>
    /// <param name="s_lx"></param>
    /// <param name="s_date"></param>
    /// <returns></returns>
    public DataSet GetResultLM(string s_lx, string s_date)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select N_NO, N_LMMC from ( ");
        strSql.Append(" select distinct b.n_lmno as N_NO, (select trim(l.n_lmmc) from kfb_lmgl l where l.n_no = b.n_lmno) as N_LMMC from kfb_baseball b ");
        strSql.Append(" where b.n_lx = '" + s_lx + "' and to_char(n_zwdate, 'yyyy/MM/dd') = '" + s_date + "' and N_COUNTTIME is not null ");
        strSql.Append(" union ");
        strSql.Append(" select distinct b.n_lmno as N_NO, (select trim(l.n_lmmc)  from kfb_lmgl l where l.n_no = b.n_lmno) as N_LMMC from kfb_accball b ");
        strSql.Append(" where b.n_lx = '" + s_lx + "' and to_char(n_zwdate, 'yyyy/MM/dd') = '" + s_date + "' and N_COUNTTIME is not null) a ");
        strSql.Append(" order by n_lmmc ");
        return DbHelperOra.Query(strSql.ToString());
    }


    /// <summary>
    /// 根據帳務日期取得所有的比賽
    /// </summary>
    public DataSet GetAllGame(string strZwData)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select n_lx,sum(counts) counts, js from ( ");
        strSql.Append(" select  n_lx,nvl( count( distinct n_id),0) counts , ");
        strSql.Append(" case when n_counttime is null then '0' else '1' end as js from kfb_baseball ");
        strSql.Append(" where to_char(n_zwdate,'yyyy/mm/dd')=:n_zwdate ");
        strSql.Append(" group by n_lx,n_counttime  ) group by n_lx,js ");
        OracleParameter[] parameters = {
					new OracleParameter(":n_zwdate", OracleType.VarChar,15)
            };
        parameters[0].Value = strZwData;

        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 根據帳務日期取得所有的比賽
    /// </summary>
    public DataSet GetAllSMGame(string strZwData)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select sum(counts) counts, js from ( ");
        strSql.Append(" select  nvl( count( distinct n_id),0) counts , ");
        strSql.Append(" case when n_jstime is null then '0' else '1' end as js from kfb_newhorse ");
        strSql.Append(" where to_char(n_date,'yyyy/mm/dd')=:n_zwdate ");
        strSql.Append(" group by n_jstime  ) group by js ");
        OracleParameter[] parameters = {
					new OracleParameter(":n_zwdate", OracleType.VarChar,15)
            };
        parameters[0].Value = strZwData;

        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 根據帳務日期取得所有的比賽
    /// </summary>
    public DataSet GetAllYCGame(string strZwData)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select count( distinct n_cpno) counts, js from ( ");
        strSql.Append(" select c.n_cpno,case when max(n_counttime) is null then '0' else '1' end as js ");
        strSql.Append(" from kfb_cpcc c left join kfb_cpjl j on c.n_cpno=j.n_cpno(+) ");
        strSql.Append(" where to_char(j.n_accdate,'yyyy/mm/dd')=:n_zwdate and j.n_status<4");
        strSql.Append("group by c.n_cpno ) group by js ");
        OracleParameter[] parameters = {
					new OracleParameter(":n_zwdate", OracleType.VarChar,15)
            };
        parameters[0].Value = strZwData;

        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 根據帳務日期取得所有的比賽
    /// </summary>
    public DataSet GetAllSSGame(string strZwData)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select sum(counts) counts, js from ( ");
        strSql.Append(" select  nvl( count( distinct n_id),0) counts , ");
        strSql.Append(" case when n_jstime is null then '0' else '1' end as js from KFB_LIVEJL ");
        strSql.Append(" where to_char(n_zwdate,'yyyy/mm/dd')=:n_zwdate and n_gzflag=0 ");
        strSql.Append(" group by n_jstime  ) group by js ");
        OracleParameter[] parameters = {
					new OracleParameter(":n_zwdate", OracleType.VarChar,15)
            };
        parameters[0].Value = strZwData;

        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public DataSet GetModel()
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
    /// 修改是否允許查詢報表
    /// </summary>
    /// <param name="N_CX"></param>
    public void UpdateCXBB(int i_CXBB)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_XTSZ set ");
        strSql.Append("N_CXBB=:N_CXBB");
        OracleParameter[] parameters = {
					new OracleParameter(":N_CXBB", OracleType.Number,4)};
        parameters[0].Value = i_CXBB;
        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
  
    public void TranCPType(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_CPJL  set n_status='4'");
        strSql.Append(" WHERE TO_CHAR(N_ACCDATE,'yyyy/MM/dd') =:strzwrq and ");
        strSql.Append(" n_cpno not  in( ");
        strSql.Append(" select  distinct n_cpno  from KFB_CPCC where N_COUNTTIME IS NULL  ) ");

        strSql.Append(" and n_cpno not  in( ");
        strSql.Append(" select  distinct n_lmmc  from KFB_PTZD where n_bslx='b_cp'  ) ");

        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
    }
    /// <summary>
    /// 插入oldbill表中數
    /// </summary>
    public void InsertOld(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into kfb_optzd select * from kfb_ptzd ");
        strSql.Append("where to_char(n_zwrq,'yyyy/MM/dd')=:strzwrq and (n_js='1' or n_del=1) ");


        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 刪除bill表數據
    /// </summary>
    public void dele(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        StringBuilder strSql1 = new StringBuilder();
        strSql1.Append(" update kfb_ptzd set N_GZFLAG = 1 ");
        strSql1.Append("where to_char(n_zwrq,'yyyy/MM/dd')=:strzwrq and n_js='1' ");


        OracleParameter[] parameters1 = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters1[0].Value = strzwrq;
        arsql.Add(strSql1.ToString());
        arpa.Add(parameters1);

        //n_hyjg
        StringBuilder strSql2 = new StringBuilder();
        strSql2.Append(" delete from kfb_ptzd  ");
        strSql2.Append("where to_char(n_zwrq,'yyyy/MM/dd')=:strzwrq and ( n_js='1' or n_del=1) ");


        OracleParameter[] parameters2 = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters2[0].Value = strzwrq;
        arsql.Add(strSql2.ToString());
        arpa.Add(parameters2);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 修改历史 FLAG
    /// </summary>
    public void UpdateOldBall(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" UPDATE KFB_ACCBALL  SET N_GZFLAG='1' ");
        strSql.Append("where to_char(n_zwdate,'yyyy/MM/dd')=:strzwrq");


        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 刪除旧比赛表數據
    /// </summary>
    public void deleBALL(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" delete from kfb_BASEBALL  ");
        strSql.Append("where to_char(n_zwdate,'yyyy/MM/dd')=:strzwrq and n_counttime is not null ");


        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 時事過賬
    /// </summary>
    public void TranLiveType(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_LIVEJL  set n_gzflag=1 ");
        strSql.Append(" WHERE TO_CHAR(N_ZWDATE,'yyyy/MM/dd') =:strzwrq and n_jstime is not null ");
        strSql.Append(" and n_id not in( ");
        strSql.Append(" select distinct n_qsbh from KFB_PTZD where n_bslx='b_ss'  ) ");

        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
    }
    /// <summary>
    /// 插入赛马旧比赛表中數
    /// </summary>
    public void InsertSMOld(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_OLDHORSE select * from kfb_NEWHORSE ");
        strSql.Append("where to_char(n_date,'yyyy/MM/dd')=:strzwrq and n_jstime is not null ");


        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 刪除赛马旧比赛表數據
    /// </summary>
    public void deleSM(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" delete from kfb_NEWHORSE  ");
        strSql.Append("where to_char(n_date,'yyyy/MM/dd')=:strzwrq  and n_jstime is not null ");


        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 添加记录
    /// </summary>
    public void trans(string strzwrq, string strid, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" insert into kfb_lsgz ( n_id,n_zwrq,n_gzsj,n_xgzh) Values ( EXAMPLE_SEQ.nextval,:strzwrq, SYSDATE,:strid)");



        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.DateTime),
                new OracleParameter(":strid", OracleType.VarChar,50)
            };
        parameters[0].Value = strzwrq;
        parameters[1].Value = strid;

        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 插入旧比赛表中數
    /// </summary>
    public void InsertOldBALL(string strzwrq, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_ACCBALL select * from kfb_BASEBALL ");
        strSql.Append("where to_char(n_zwdate,'yyyy/MM/dd')=:strzwrq and n_counttime is not null ");


        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;
        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 删除六合彩
    /// </summary>
    public void delelhc(string strlx, ArrayList arsql, ArrayList arpa)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" delete from  kfb_" + strlx + "bskg  where n_lx=:lx ");

        OracleParameter[] parameters = {
					new OracleParameter(":lx", OracleType.VarChar,20)
            };
        parameters[0].Value = "other";

        arsql.Add(strSql.ToString());
        arpa.Add(parameters);
        // htb.Add(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int N_FLAG, int N_JS)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from KFB_LHCKPSD");
        strSql.Append(" where  N_FLAG=:N_FLAG and N_JS=:N_JS  ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_FLAG", OracleType.Number,4),
					new OracleParameter(":N_JS", OracleType.Number,4),
};

        parameters[0].Value = N_FLAG;
        parameters[1].Value = N_JS;

        return DbHelperOra.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool ExistsTK(int N_FLAG, int N_JS)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from KFB_DLTKPSD");
        strSql.Append(" where  N_FLAG=:N_FLAG and N_JS=:N_JS  ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_FLAG", OracleType.Number,4),
					new OracleParameter(":N_JS", OracleType.Number,4),
            };

        parameters[0].Value = N_FLAG;
        parameters[1].Value = N_JS;

        return DbHelperOra.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// xiugai
    /// </summary>
    public void upFlagTK(string strflag)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" update  KFB_DLTKPSD set n_Flag=:n_Flag ");

        OracleParameter[] parameters = {
					new OracleParameter(":n_Flag", OracleType.VarChar,10)
            };

        parameters[0].Value = strflag;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddTK(KFB_DLTKPSD model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_DLTKPSD(");
        strSql.Append("N_NO,N_TERM,N_STARTTIME,N_TBHSTOPTIME,N_OTHERSTOPTIME,N_OTHERSHOWTIME,N_FLAG,N_OPEN,N_TBH,N_TT,N_TH,N_QCP,N_234,N_JS,N_MONEY,N_DATE)");
        strSql.Append(" values (");
        strSql.Append(":N_NO,:N_TERM,:N_STARTTIME,:N_TBHSTOPTIME,:N_OTHERSTOPTIME,:N_OTHERSHOWTIME,:N_FLAG,:N_OPEN,:N_TBH,:N_TT,:N_TH,:N_QCP,:N_234,:N_JS,:N_MONEY,:N_DATE)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_NO", OracleType.Number,10),
					new OracleParameter(":N_TERM", OracleType.Number,4),
					new OracleParameter(":N_STARTTIME", OracleType.DateTime),
					new OracleParameter(":N_TBHSTOPTIME", OracleType.Number,4),
					new OracleParameter(":N_OTHERSTOPTIME", OracleType.Number,4),
					new OracleParameter(":N_OTHERSHOWTIME", OracleType.Number,4),
					new OracleParameter(":N_FLAG", OracleType.Number,4),
					new OracleParameter(":N_OPEN", OracleType.Number,4),
					new OracleParameter(":N_TBH", OracleType.Number,4),
					new OracleParameter(":N_TT", OracleType.Number,4),
					new OracleParameter(":N_TH", OracleType.Number,4),
					new OracleParameter(":N_QCP", OracleType.Number,4),
					new OracleParameter(":N_234", OracleType.Number,4),
					new OracleParameter(":N_JS", OracleType.Number,4),
					new OracleParameter(":N_MONEY", OracleType.Float,22),
					new OracleParameter(":N_DATE", OracleType.DateTime)};
        parameters[0].Value = model.N_NO;
        parameters[1].Value = model.N_TERM;
        parameters[2].Value = model.N_STARTTIME;
        parameters[3].Value = model.N_TBHSTOPTIME;
        parameters[4].Value = model.N_OTHERSTOPTIME;
        parameters[5].Value = model.N_OTHERSHOWTIME;
        parameters[6].Value = model.N_FLAG;
        parameters[7].Value = model.N_OPEN;
        parameters[8].Value = model.N_TBH;
        parameters[9].Value = model.N_TT;
        parameters[10].Value = model.N_TH;
        parameters[11].Value = model.N_QCP;
        parameters[12].Value = model.N_234;
        parameters[13].Value = model.N_JS;
        parameters[14].Value = model.N_MONEY;
        parameters[15].Value = model.N_DATE;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// xiugai
    /// </summary>
    public void upFlag(string strflag)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" update  KFB_LHCKPSD set n_Flag=:n_Flag ");

        OracleParameter[] parameters = {
					new OracleParameter(":n_Flag", OracleType.VarChar,10)
            };

        parameters[0].Value = strflag;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 執行事物
    /// </summary>
    /// <param name="o_aHt"></param>
    public void ExecuteSqlTran(ArrayList alSql, ArrayList alPar)
    {
        DbHelperOra.ExecuteSqlTran(alSql, alPar);
    }
   
    public int GetMaxNo()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select nvl(max(n_term),0) ");
        strSql.Append(" FROM KFB_LHCKPSD ");

        return Convert.ToInt32(DbHelperOra.Query(strSql.ToString()).Tables[0].Rows[0][0]);
    }
    /// <summary>
    /// 获得最大的ＮＯ
    /// </summary>
    public int GetTKNO()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select nvl(max(n_term),0) ");
        strSql.Append(" FROM KFB_DLTKPSD ");

        return Convert.ToInt32(DbHelperOra.Query(strSql.ToString()).Tables[0].Rows[0][0]);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void Add(KFB_LHCKPSD model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_LHCKPSD(");
        strSql.Append("N_NO,N_TERM,N_STARTTIME,N_TBHSTOPTIME,N_OTHERSTOPTIME,N_OTHERSHOWTIME,N_FLAG,N_OPEN,N_TBH,N_TT,N_TH,N_QCP,N_234,N_JS,N_MONEY,N_DATE)");
        strSql.Append(" values (");
        strSql.Append(":N_NO,:N_TERM,:N_STARTTIME,:N_TBHSTOPTIME,:N_OTHERSTOPTIME,:N_OTHERSHOWTIME,:N_FLAG,:N_OPEN,:N_TBH,:N_TT,:N_TH,:N_QCP,:N_234,:N_JS,:N_MONEY,:N_DATE)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_NO", OracleType.Number,10),
					new OracleParameter(":N_TERM", OracleType.Number,4),
					new OracleParameter(":N_STARTTIME", OracleType.DateTime),
					new OracleParameter(":N_TBHSTOPTIME", OracleType.Number,4),
					new OracleParameter(":N_OTHERSTOPTIME", OracleType.Number,4),
					new OracleParameter(":N_OTHERSHOWTIME", OracleType.Number,4),
					new OracleParameter(":N_FLAG", OracleType.Number,4),
					new OracleParameter(":N_OPEN", OracleType.Number,4),
					new OracleParameter(":N_TBH", OracleType.Number,4),
					new OracleParameter(":N_TT", OracleType.Number,4),
					new OracleParameter(":N_TH", OracleType.Number,4),
					new OracleParameter(":N_QCP", OracleType.Number,4),
					new OracleParameter(":N_234", OracleType.Number,4),
					new OracleParameter(":N_JS", OracleType.Number,4),
					new OracleParameter(":N_MONEY", OracleType.Float,22),
					new OracleParameter(":N_DATE", OracleType.DateTime)};
        parameters[0].Value = model.N_NO;
        parameters[1].Value = model.N_TERM;
        parameters[2].Value = model.N_STARTTIME;
        parameters[3].Value = model.N_TBHSTOPTIME;
        parameters[4].Value = model.N_OTHERSTOPTIME;
        parameters[5].Value = model.N_OTHERSHOWTIME;
        parameters[6].Value = model.N_FLAG;
        parameters[7].Value = model.N_OPEN;
        parameters[8].Value = model.N_TBH;
        parameters[9].Value = model.N_TT;
        parameters[10].Value = model.N_TH;
        parameters[11].Value = model.N_QCP;
        parameters[12].Value = model.N_234;
        parameters[13].Value = model.N_JS;
        parameters[14].Value = model.N_MONEY;
        parameters[15].Value = model.N_DATE;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 取得帳務日期
    /// </summary>
    public DataSet GetZWRQ()
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        // strSql.Append(" select distinct to_char(n_zwrq,'yyyy/MM/dd') zwrq,'11' counts,'999' TYPE  from kfb_ptzd order by zwrq desc  ");

        strSql.Append(" select distinct to_char(n_zwrq,'yyyy/MM/dd') zwrq,'11' counts,'999' TYPE  from kfb_ptzd ");
        strSql.Append(" union select distinct to_char(n_zwdate,'yyyy/MM/dd') zwrq,'11' counts,'999' TYPE  from kfb_baseball ");
        strSql.Append(" union select distinct  to_char(n_date,'yyyy/MM/dd') zwrq,'11' counts,'999' TYPE  from kfb_newhorse ");
        strSql.Append(" union select distinct  to_char(n_accdate,'yyyy/MM/dd') zwrq,'11' counts,'999' TYPE  from kfb_cpjl where n_status<4 ");
        strSql.Append(" union select distinct to_char(n_zwdate, 'yyyy/MM/dd') zwrq, '11' counts, '999' TYPE from kfb_livejl ");
        //    strSql.Append(" union select distinct  to_char(n_date,'yyyy/MM/dd') zwrq,'11' counts,'999' TYPE  from kfb_lhckpsd ");
        //   strSql.Append(" union select distinct  to_char(n_date,'yyyy/MM/dd') zwrq,'11' counts,'999' TYPE  from kfb_dltkpsd ");
        //strSql.Append(" order by zwrq desc  ");
        strSql.Append(" order by zwrq   ");
        return DbHelperOra.Query(strSql.ToString());
    }
    /// <summary>
    /// 每日過賬
    /// </summary>
    public string GetZW(string strzwrq)
    {
        //n_hyjg
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select nvl( sum(counts),0) counts from ( ");
        strSql.Append(" select nvl(count( distinct n_xzdh),0) counts from kfb_ptzd  ");
        strSql.Append(" where nvl(n_js,0)!='1' and  nvl(n_del,0)!='1' and  to_char(n_zwrq,'yyyy/MM/dd')=:strzwrq ");
        strSql.Append(" and n_bslx<>'b_cp' ");
        strSql.Append(" union all ");
        strSql.Append(" select round(power(10, Sum(Log(10, xznum))),0) as xznum from ( select n_bslx, n_xzdh, nvl(length(n_zddy)/2+0.5 ,1) as xznum from kfb_ptzd ");
        strSql.Append(" where nvl(n_js,0)!='1' and  nvl(n_del,0)!='1' and  to_char(n_zwrq,'yyyy/MM/dd')=:strzwrq ");
        strSql.Append(" and n_bslx='b_cp' ");
        strSql.Append(" ) a  group by n_bslx,n_xzdh ) ");
        OracleParameter[] parameters = {
					new OracleParameter(":strzwrq", OracleType.VarChar,20)
            };
        parameters[0].Value = strzwrq;

        return DbHelperOra.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString();
    }
}
