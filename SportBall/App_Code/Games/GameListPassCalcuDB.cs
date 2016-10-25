using KingOfBall;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class GameListPassCalcuDB
    {
        protected OracleConnection conn;
        protected OracleTransaction tran;
        public static ILog LogDB = log4net.LogManager.GetLogger("logCount");
         public GameListPassCalcuDB(bool isTran)
        {
            if (isTran)
            {
                conn = DbHelperOra.Open();
                tran = conn.BeginTransaction();
            }
            else
            {
                conn = DbHelperOra.Open();
            }
        }
         public GameListPassCalcuDB()
        {
            conn = DbHelperOra.Open();
        }
        public void Close()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        public void Commit()
        {
            tran.Commit();
        }
        public void Rollback()
        {
            tran.Rollback();
        }
        public void Tran()
        {
            tran = conn.BeginTransaction();
        }
        public void Open()
        {
            conn = DbHelperOra.Open();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strrq"></param>
        /// <param name="strlx"></param>
        /// <returns></returns>
        public DataSet GetGG(DateTime strrq, string strlx)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" 	select n_xzdh,n_xzrq,n_bslx,n_gsty ,n_xzje,n_kyje ,n_syjg, n_xzwf ,n_js,n_del, GETHYZDNR(n_xzdh) XZNR");
            strSql.Append(" from ( select distinct n_xzdh,n_xzrq,n_bslx,n_gsty ,n_xzje,n_kyje ,n_syjg, case n_gsty when 3 then 'l_gg' else n_xzwf end as n_xzwf ,n_js,n_del ");
            strSql.Append("  from kfb_ptzd where n_zwrq=:n_xzrq and n_bslx=:n_bslx AND NVL(N_JS,0)=0 and  n_gsty=3) ");
            strSql.Append(" UNION	select n_xzdh,n_xzrq,n_bslx,n_gsty ,n_xzje,n_kyje ,n_syjg, n_xzwf ,n_js,n_del, GETHYZDNR(n_xzdh) XZNR");
            strSql.Append(" from ( select distinct n_xzdh,n_xzrq,n_bslx,n_gsty ,n_xzje,n_kyje ,n_syjg, case n_gsty when 3 then 'l_gg' else n_xzwf end as n_xzwf ,n_js,n_del ");
            strSql.Append("  from kfb_optzd where n_zwrq=:n_xzrq and n_bslx=:n_bslx AND NVL(N_JS,0)=0  and  n_gsty=3) ");
            OracleParameter[] parameters = {
					new OracleParameter(":n_xzrq", OracleType.DateTime),
                    new OracleParameter(":n_bslx", OracleType.VarChar,10)
            };
            parameters[0].Value = strrq;
            parameters[1].Value = strlx;


            return DbHelperOra.Query(strSql.ToString(), parameters);
        }
        #region　过关　计算
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strrq"></param>
        /// <param name="strball"></param>
        public  void BallPassCount(string strrq, string strball)
        {
            //KingOfBall.BLL.KFB_COUNT_BLL count = new KingOfBall.BLL.KFB_COUNT_BLL();
            try
            {
                Decimal gsjg = 0;
                decimal strgszc = 100M;
                //BY KEWEN
                // KingOfBall.BLL.KFB_MRZJ_BLL O_MRZJ = new KingOfBall.BLL.KFB_MRZJ_BLL();
                // KFB_MRZJ M_MRZJ = new KFB_MRZJ();

                //KingOfBall.BLL.KFB_PTZD_BLL o_PTZD = new KingOfBall.BLL.KFB_PTZD_BLL();
                DataSet ds = GetPassBillList(Convert.ToDateTime(strrq), strball);
                KFB_PTZD mo_PTZD = new KFB_PTZD();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //DataRow dr = ds.Tables[0].Rows[i];
                    Decimal dhyty = Convert.ToDecimal(dr["n_ty"].ToString());
                    int bsjscount = PassCountNum(dr["n_xzdh"].ToString());
                    if (bsjscount > 0)
                        continue;
                    //bool CheckGG = new KingOfBall.BLL.KFB_BET_BLL().CheckGG(dr["n_xzdh"].ToString());
                    //if (CheckGG)
                    //    continue;
                    decimal tempHYJG = 0;
                    string tempJS = dr["n_js"].ToString();
                    string tempHYDH = dr["n_hydh"].ToString();
                    string tempDEL = GetColValue(dr["n_xzdh"].ToString(), "n_del");
                    if (tempJS.Equals("1"))
                    {
                        tempHYJG = decimal.Parse(GetColValue(dr["n_xzdh"].ToString(), "n_hyjg"));
                    }

                    //type
                    string strbslx = dr["N_BSLX"].ToString();

                    decimal strdlty = Convert.ToDecimal(dr["n_dlty"]);
                    decimal strzdlty = Convert.ToDecimal(dr["n_zdlty"]);
                    decimal strgdty = Convert.ToDecimal(dr["n_gdty"]);
                    decimal strzgdty = Convert.ToDecimal(dr["n_dgdty"]);
                    decimal strzjty = Convert.ToDecimal(dr["n_zjty"]);
                    decimal strdzjty = Convert.ToDecimal(dr["n_dzjty"]);

                    decimal strdlcz = Convert.ToDecimal(dr["n_dlcz"]);
                    decimal strzdlcz = Convert.ToDecimal(dr["n_zdlcz"]);
                    decimal strgdcz = Convert.ToDecimal(dr["n_gdcz"]);
                    decimal strzgdcz = Convert.ToDecimal(dr["n_zgdcz"]);
                    decimal strzjcz = Convert.ToDecimal(dr["n_zjcz"]);
                    decimal strdzjcz = Convert.ToDecimal(dr["n_dzjcz"]);
                    string strjs = dr["n_js"].ToString();

                    string strkyje = dr["n_kyje"].ToString();
                    Decimal dljg = 0;
                    Decimal zdljg = 0;
                    Decimal gdjg = 0;
                    Decimal dgdjg = 0;
                    Decimal zjjg = 0;
                    Decimal dzjjg = 0;
                    string strid = dr["n_xzdh"].ToString();
                    Decimal dxzje = Convert.ToDecimal(dr["n_xzje"].ToString());
                    DataSet dsgg = GetPassResult(strid);
                    Decimal kyje = 1;
                    //Decimal dcs = 1;
                    Decimal dlscz = 0;
                    bool che = true;
                    string matchId = "";
                    foreach (DataRow drr in dsgg.Tables[0].Rows)
                    {
                        Decimal ggjg = Convert.ToDecimal(drr["N_GGJG"].ToString());
                        matchId += drr["N_QSBH"].ToString() + ",";
                        if (ggjg != -1)
                        {
                            if (ggjg < 0)
                            {
                                if (Math.Abs(ggjg) == dxzje)
                                {
                                    che = false;
                                }
                            }


                            kyje = kyje * (dxzje + ggjg) / dxzje;
                        }
                        // dcs = dcs * dxzje;

                    }
                    if (!che)
                    {
                        kyje = -1 * dxzje * (1 - (dhyty / 10000));
                    }
                    else
                    {
                        kyje = (dxzje * kyje) - dxzje;
                    }
                    //if (kyje > 1000000)
                    //{
                    //    kyje = 1000000;
                    //}
                    //原来是高于100万 改为高于20万
                    if (kyje > 200000)
                    {
                        kyje = 200000;
                    }

                    mo_PTZD.N_SYJG = (kyje);
                    mo_PTZD.N_HYJG = (kyje);
                    mo_PTZD.N_XZDH = strid;


                    if ((kyje) == 0)
                    {
                        dljg = 0;
                        zdljg = 0;
                        gdjg = 0;
                        dgdjg = 0;
                        zjjg = 0;
                        dzjjg = 0;
                        dlscz = 0;
                        gsjg = 0;
                    }
                    else if ((kyje) > 0)
                    {
                        dljg = (kyje) * (1 - (strdlcz) / 100);
                        zdljg = (kyje) * (1 - (strzdlcz) / 100);
                        gdjg = (kyje) * (1 - (strgdcz) / 100);
                        dgdjg = (kyje) * (1 - (strzgdcz) / 100);
                        zjjg = (kyje) * (1 - (strzjcz) / 100);
                        dzjjg = (kyje) * (1 - (strdzjcz) / 100);
                        dlscz = (kyje);

                        //strgszc = Comm.GetZC(strbslx, M_MRZJ);
                        gsjg = (kyje) * (1 - (strgszc) / 100);
                    }
                    else if (che)
                    {
                        mo_PTZD.N_SYJG = (kyje) + ((-1) * (kyje) * (dhyty) / 10000);
                        mo_PTZD.N_HYJG = (kyje) + ((-1) * (kyje) * (dhyty) / 10000);
                        dljg = ((kyje) + ((-1) * (kyje) * (strdlty) / 10000)) * (1 - (strdlcz) / 100);
                        zdljg = ((kyje) + ((-1) * (kyje) * (strzdlty) / 10000)) * (1 - (strzdlcz) / 100);
                        gdjg = ((kyje) + ((-1) * (kyje) * (strgdty) / 10000)) * (1 - (strgdcz) / 100);
                        dgdjg = ((kyje) + ((-1) * (kyje) * (strzgdty) / 10000)) * (1 - (strzgdcz) / 100);
                        zjjg = ((kyje) + ((-1) * (kyje) * (strzjty) / 10000)) * (1 - (strzjcz) / 100);
                        dzjjg = ((kyje) + ((-1) * (kyje) * (strdzjty) / 10000)) * (1 - (strdzjcz) / 100);
                        dlscz = ((kyje) + ((-1) * (kyje) * (strdlty) / 10000));

                        //strgszc = Comm.GetZC(strbslx, M_MRZJ);
                        gsjg = ((kyje) + ((-1) * (kyje) * (strdzjty) / 10000)) * (1 - (strgszc) / 100);
                    }
                    else
                    {
                        //dljg = (kyje) * (1 - (strdlcz) / 100) + (dxzje) * (((strdlty) - dhyty) / 10000);
                        //zdljg = (kyje) * (1 - (strzdlcz) / 100) + (dxzje) * (((strzdlty) - (strdlty)) / 10000);
                        //gdjg = (kyje) * (1 - (strgdcz) / 100) + (dxzje) * (((strgdty) - (strzdlty)) / 10000);
                        //dgdjg = (kyje) * (1 - (strzgdcz) / 100) + (dxzje) * (((strzgdty) - (strgdty)) / 10000);
                        //zjjg = (kyje) * (1 - (strzjcz) / 100) + (dxzje) * (((strzjty) - (strzgdty)) / 10000);
                        //dzjjg = (kyje) * (1 - (strdzjcz) / 100) + (dxzje) * (((strdzjty) - (strzjty)) / 10000);
                        dljg = ((-1) * (dxzje) + ((dxzje) * (strdlty) / 10000)) * (1 - (strdlcz) / 100);
                        zdljg = ((-1) * (dxzje) + ((dxzje) * (strzdlty) / 10000)) * (1 - (strzdlcz) / 100);
                        gdjg = ((-1) * (dxzje) + ((dxzje) * (strgdty) / 10000)) * (1 - (strgdcz) / 100);
                        dgdjg = ((-1) * (dxzje) + ((dxzje) * (strzgdty) / 10000)) * (1 - (strzgdcz) / 100);
                        zjjg = ((-1) * (dxzje) + ((dxzje) * (strzjty) / 10000)) * (1 - (strzjcz) / 100);
                        dzjjg = ((-1) * (dxzje) + ((dxzje) * (strdzjty) / 10000)) * (1 - (strdzjcz) / 100);
                        dlscz = ((-1) * (dxzje) + ((dxzje) * (strdlty) / 10000));

                        //strgszc = Comm.GetZC(strbslx, M_MRZJ);
                        gsjg = ((-1) * (dxzje) + ((dxzje) * (strdzjty) / 10000)) * (1 - (strgszc) / 100);
                    }



                    mo_PTZD.N_DLSJG = dljg;
                    mo_PTZD.N_ZDLJG = zdljg;
                    mo_PTZD.N_GDJG = gdjg;
                    mo_PTZD.N_DGDJG = dgdjg;
                    mo_PTZD.N_ZJJG = zjjg;
                    mo_PTZD.N_GSJG = gsjg;
                    mo_PTZD.N_DZJJG = dzjjg;
                    mo_PTZD.N_JS = 1;
                    mo_PTZD.N_DLSWCZ = dlscz;

                    //KingOfBall.BLL.KFB_HYGL_BLL o_HYGL = new KingOfBall.BLL.KFB_HYGL_BLL();
                    mo_PTZD.N_HYDH = dr["n_hydh"].ToString();
                    mo_PTZD.N_XZJE = Convert.ToDecimal(dr["n_xzje"]);
                    decimal creditBeore = GetCredit(mo_PTZD.N_HYDH);
                    int no = GetNo();
                    string type = "";
                    Tran();
                    if (!tempDEL.Equals("1"))
                    {
                        if (tempJS.Equals("1"))//已進行過計算
                        {
                            ReSetCredit(tempHYDH, (mo_PTZD.N_HYJG.Value - tempHYJG) / 10000);
                            type = "3";
                        }
                        else
                        {
                            ReSetCredit(tempHYDH, (dxzje + mo_PTZD.N_HYJG.Value) / 10000);
                            type = "2";
                        }
                    }
                    else
                    {
                        if (tempJS.Equals("1"))//已進行過計算
                        {
                            type = "3";
                        }
                        else
                        {
                            type = "2";
                        }
                    }
                    //注單存在
                    bool bcz = Exists(dr["n_xzdh"].ToString());
                    if (bcz)
                    {
                        CountPassBill(mo_PTZD);
                    }
                    else
                    {

                        ReCountPassBill(mo_PTZD);
                    }
                    DateTime sysDateNow = GetSysDate();
                    decimal creditAfter = GetCredit(mo_PTZD.N_HYDH);
                    InsertCreditLog(no, sysDateNow, type, mo_PTZD.N_HYDH, creditBeore * 10000M, creditAfter * 10000M);
                    InsertBillLog(no, mo_PTZD.N_HYDH, mo_PTZD.N_XZDH, matchId.Substring(0, matchId.Length - 1), mo_PTZD.N_XZJE.Value, tempHYJG, mo_PTZD.N_HYJG.Value, sysDateNow, type);

                    Commit();
                }
            }
            catch (Exception ex)
            {
                Rollback();
                //LogDB.Error("Count Error！！", ex);
            }
            finally
            {
                Close();
            }
        }
   
        /// <summary>
        /// 注单下注和计算记录
        /// </summary>
        /// <param name="n_id"></param>
        /// <param name="n_hyzh"></param>
        /// <param name="n_xzdh"></param>
        /// <param name="n_matchid"></param>
        /// <param name="n_syed_b"></param>
        /// <param name="n_syed_a"></param>
        /// <param name="n_xzje"></param>
        /// <param name="n_hyjg_b"></param>
        /// <param name="n_hyjg_a"></param>
        /// <param name="n_updatetime_b"></param>
        /// <param name="n_updatetime_a"></param>
        /// <param name="n_type"></param>
        public void InsertBillLog(int n_id, string n_hyzh, string n_xzdh, string n_matchid, decimal n_xzje,
            decimal n_hyjg_b, decimal n_hyjg_a, DateTime n_date, string n_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into kfb_ptzdlog(n_id, n_hyzh, n_xzdh, n_matchid,  n_xzje, n_hyjg_b, n_hyjg_a, n_date, n_type) ");
            strSql.Append("values(:n_id, :n_hyzh, :n_xzdh, :n_matchid, :n_xzje, :n_hyjg_b, :n_hyjg_a, :n_date, :n_type)");
            OracleParameter[] parameters = {
					new OracleParameter(":n_id", OracleType.Number),
					new OracleParameter(":n_hyzh", OracleType.VarChar,50),
					new OracleParameter(":n_xzdh", OracleType.VarChar,50),
					new OracleParameter(":n_matchid", OracleType.VarChar,1000),
					new OracleParameter(":n_xzje", OracleType.Number),
					new OracleParameter(":n_hyjg_b", OracleType.Number),
					new OracleParameter(":n_hyjg_a", OracleType.Number),
					new OracleParameter(":n_date", OracleType.DateTime),
					new OracleParameter(":n_type", OracleType.Char,1)
            };
            parameters[0].Value = n_id;
            parameters[1].Value = n_hyzh;
            parameters[2].Value = n_xzdh;
            parameters[3].Value = n_matchid;
            parameters[4].Value = n_xzje;
            parameters[5].Value = n_hyjg_b;
            parameters[6].Value = n_hyjg_a;
            parameters[7].Value = n_date;
            parameters[8].Value = n_type;
            DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 重新计算过关注单
        /// </summary>
        /// <param name="model"></param>
        public void ReCountPassBill(KFB_PTZD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_OPTZD set ");
            strSql.Append("N_SYJG=:N_SYJG,");
            strSql.Append("N_HYJG=:N_HYJG,");
            strSql.Append("N_DLSJG=:N_DLSJG,");
            strSql.Append("N_ZDLJG=:N_ZDLJG,");
            strSql.Append("N_GDJG=:N_GDJG,");
            strSql.Append("N_DGDJG=:N_DGDJG,");
            strSql.Append("N_ZJJG=:N_ZJJG,");
            strSql.Append("N_DZJJG=:N_DZJJG,");
            strSql.Append("N_GSJG=:N_GSJG,");
            strSql.Append("n_js=:n_js,");
            strSql.Append("N_DLSWCZ=:N_DLSWCZ ");
            strSql.Append(" where n_xzdh=:n_xzdh  and  n_gsty=3");
            OracleParameter[] parameters = {
					new OracleParameter(":n_xzdh", OracleType.VarChar,30),
					new OracleParameter(":N_SYJG", OracleType.Float,22),
					new OracleParameter(":N_HYJG", OracleType.Float,22),
					new OracleParameter(":N_DLSJG", OracleType.Float,22),
					new OracleParameter(":N_ZDLJG", OracleType.Float,22),
					new OracleParameter(":N_GDJG", OracleType.Float,22),
					new OracleParameter(":N_DGDJG", OracleType.Float,22),
					new OracleParameter(":N_ZJJG", OracleType.Float,22),
					new OracleParameter(":N_GSJG", OracleType.Float,22),
                    new OracleParameter(":n_js", OracleType.Number,4),
                    new OracleParameter(":N_DZJJG", OracleType.Float,22),
                    new OracleParameter(":N_DLSWCZ", OracleType.Float,22)
            };
            parameters[0].Value = model.N_XZDH;
            parameters[1].Value = model.N_SYJG;
            parameters[2].Value = model.N_HYJG;
            parameters[3].Value = model.N_DLSJG;
            parameters[4].Value = model.N_ZDLJG;
            parameters[5].Value = model.N_GDJG;
            parameters[6].Value = model.N_DGDJG;
            parameters[7].Value = model.N_ZJJG;
            parameters[8].Value = model.N_GSJG;
            parameters[9].Value = model.N_JS;
            parameters[10].Value = model.N_DZJJG;
            parameters[11].Value = model.N_DLSWCZ;
            DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得序號
        /// </summary>
        public int GetNo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EXAMPLE_SEQ.nextval from dual");
            return Convert.ToInt32(DbHelperOra.GetSingle(conn, tran, strSql.ToString()));
        }
        /// <summary>
        ///  取得过关注单结果
        /// </summary>
        /// <param name="strid"></param>
        /// <returns></returns>
        public DataSet GetPassResult(string strid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  nvl(N_GGJG,0) N_GGJG,N_QSBH");
            strSql.Append(" from kfb_ptzd where n_xzdh=:n_xzdh and  n_gsty=3 ");
            strSql.Append(" union all	select  nvl(N_GGJG,0) N_GGJG,N_QSBH");
            strSql.Append(" from kfb_optzd where n_xzdh=:n_xzdh and  n_gsty=3 ");
            OracleParameter[] parameters = {
					new OracleParameter(":n_xzdh", OracleType.VarChar,30)
            };
            parameters[0].Value = strid;

            return DbHelperOra.Query(conn, tran, strSql.ToString(), parameters);
        }
        #endregion
        /// <summary>
        /// 额度变化记录
        /// </summary>
        /// <param name="n_id"></param>
        /// <param name="n_date"></param>
        /// <param name="n_type"></param>
        /// <param name="n_uid"></param>
        /// <param name="n_creditbefer"></param>
        /// <param name="n_creitafter"></param>
        public void InsertCreditLog(int n_id, DateTime n_date, string n_type, string n_uid, decimal n_creditbefer, decimal n_creitafter)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into kfb_hycreditlog(n_id, n_date, n_type, n_uid, n_creditbefer, n_creitafter) ");
            strSql.Append("values(:n_id, :n_date, :n_type, :n_uid, :n_creditbefer, :n_creitafter)");
            OracleParameter[] parameters = {
					new OracleParameter(":n_id", OracleType.Number),
					new OracleParameter(":n_date", OracleType.DateTime),
					new OracleParameter(":n_type", OracleType.Char,1),
					new OracleParameter(":n_uid", OracleType.VarChar,50),
					new OracleParameter(":n_creditbefer", OracleType.Number),
					new OracleParameter(":n_creitafter", OracleType.Number)
            };
            parameters[0].Value = n_id;
            parameters[1].Value = n_date;
            parameters[2].Value = n_type;
            parameters[3].Value = n_uid;
            parameters[4].Value = n_creditbefer;
            parameters[5].Value = n_creitafter;
            DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetSysDate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sysdate from dual");
            return Convert.ToDateTime(DbHelperOra.GetSingle(conn, tran, strSql.ToString()));
        }
       
        /// <summary>
        /// 过关计算列表
        /// </summary>
        /// <param name="strrq"></param>
        /// <param name="strlx"></param>
        /// <returns></returns>
        public DataSet GetPassBillList(DateTime strrq, string strlx)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select distinct n_xzdh,n_xzrq,n_bslx,n_gsty ,n_xzje,n_kyje ,n_syjg, case n_gsty when 3 then 'l_gg' else n_xzwf end as n_xzwf ,n_js,");
            strSql.Append("  n_zjcz,n_zgdcz,n_gdcz,n_zdlcz,n_dlcz,n_dgdty,n_gdty,n_zdlty,n_dlty,n_zjty ,n_dzjcz,n_dzjty ,n_ty,n_hydh");
            strSql.Append("  from kfb_ptzd where n_zwrq=:n_zwrq and n_bslx=:n_bslx and nvl(n_js,0)=0  and  n_gsty=3 ");
            strSql.Append(" UNION select distinct n_xzdh,n_xzrq,n_bslx,n_gsty ,n_xzje,n_kyje ,n_syjg, case n_gsty when 3 then 'l_gg' else n_xzwf end as n_xzwf ,n_js,");
            strSql.Append("  n_zjcz,n_zgdcz,n_gdcz,n_zdlcz,n_dlcz,n_dgdty,n_gdty,n_zdlty,n_dlty,n_zjty ,n_dzjcz,n_dzjty ,n_ty,n_hydh");
            strSql.Append("  from kfb_optzd where n_zwrq=:n_zwrq and n_bslx=:n_bslx and nvl(n_js,0)=0  and  n_gsty=3 ");
            OracleParameter[] parameters = {
					new OracleParameter(":n_zwrq", OracleType.DateTime),
                    new OracleParameter(":n_bslx", OracleType.VarChar,10)
            };
            parameters[0].Value = strrq;
            parameters[1].Value = strlx;
            return DbHelperOra.Query(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 过关是否计算完
        /// </summary>
        /// <param name="strN_XZDH"></param>
        /// <returns></returns>
        public int PassCountNum(string strN_XZDH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(n_id) from kfb_baseball where n_id in(select n_qsbh from  kfb_ptzd where n_xzdh=:n_xzdh) and n_counttime is null ");
            OracleParameter[] parameters = {
                    new OracleParameter(":n_xzdh", OracleType.VarChar,20)
            };
            parameters[0].Value = strN_XZDH;
            return int.Parse(DbHelperOra.GetSingle(conn, tran, strSql.ToString(), parameters).ToString());
        }
        /// <summary>
        /// 获取某栏位值
        /// </summary>
        /// <param name="strid"></param>
        /// <param name="strCOL"></param>
        /// <returns></returns>
        public string GetColValue(string strid, string strCOL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  nvl(" + strCOL + ",0)  N_COL  ");
            strSql.Append(" from kfb_ptzd where n_xzdh=:n_xzdh and n_gsty=3");
            strSql.Append(" union select   nvl(" + strCOL + ",0)  N_COL  ");
            strSql.Append(" from kfb_optzd where n_xzdh=:n_xzdh and n_gsty=3");
            OracleParameter[] parameters = {
					new OracleParameter(":n_xzdh", OracleType.VarChar,30)
            };
            parameters[0].Value = strid;

            return DbHelperOra.GetSingle(conn, tran, strSql.ToString(), parameters).ToString();
        }
    
        /// <summary>
        /// 额度日志
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="N_KYED"></param>
        public void CreditLog(string N_HYZH, decimal N_KYED, string N_XZDH, string N_CONTENT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into KFB_BETCREDITLOG(N_ID,N_HYZH,N_CREDIT,N_XZDH,N_ADDTIME,N_CONTENT) ");
            strSql.Append(" values(EXAMPLE_SEQ.nextval,:N_HYZH,:N_CREDIT,:N_XZDH,sysdate,:N_CONTENT) ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,50),
                new OracleParameter(":N_CREDIT", OracleType.Number,4),
                new OracleParameter(":N_XZDH", OracleType.VarChar,50),
                new OracleParameter(":N_CONTENT", OracleType.VarChar,500)
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_KYED;
            parameters[2].Value = N_XZDH;
            parameters[3].Value = N_CONTENT;
            DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 恢复额度
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="N_KYED"></param>
        public void ReSetCredit(string N_HYZH, decimal N_KYED)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_syed=n_syed+:N_SYED ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_SYED", OracleType.Number,4),
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_KYED;
            DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        ///  判断过关注单是否存在
        /// </summary>
        /// <param name="s_xzdh"></param>
        /// <returns></returns>
        public bool Exists(string s_xzdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KFB_PTZD");
            strSql.Append(" where N_XZDH=:N_XZDH");

            OracleParameter[] parameters = {
		    	new OracleParameter(":N_XZDH", OracleType.VarChar,100)
            };
            parameters[0].Value = s_xzdh;
            return DbHelperOra.Exists(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 计算过关注单
        /// </summary>
        /// <param name="model"></param>
        public void CountPassBill(KFB_PTZD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_PTZD set ");
            strSql.Append("N_SYJG=:N_SYJG,");
            strSql.Append("N_HYJG=:N_HYJG,");
            strSql.Append("N_DLSJG=:N_DLSJG,");
            strSql.Append("N_ZDLJG=:N_ZDLJG,");
            strSql.Append("N_GDJG=:N_GDJG,");
            strSql.Append("N_DGDJG=:N_DGDJG,");
            strSql.Append("N_ZJJG=:N_ZJJG,");
            strSql.Append("N_DZJJG=:N_DZJJG,");
            strSql.Append("N_GSJG=:N_GSJG,");
            strSql.Append("n_js=:n_js,");
            strSql.Append("N_DLSWCZ=:N_DLSWCZ ");
            strSql.Append(" where n_xzdh=:n_xzdh  and  n_gsty=3");
            OracleParameter[] parameters = {
					new OracleParameter(":n_xzdh", OracleType.VarChar,20),
					new OracleParameter(":N_SYJG", OracleType.Float,22),
					new OracleParameter(":N_HYJG", OracleType.Float,22),
					new OracleParameter(":N_DLSJG", OracleType.Float,22),
					new OracleParameter(":N_ZDLJG", OracleType.Float,22),
					new OracleParameter(":N_GDJG", OracleType.Float,22),
					new OracleParameter(":N_DGDJG", OracleType.Float,22),
					new OracleParameter(":N_ZJJG", OracleType.Float,22),
					new OracleParameter(":N_GSJG", OracleType.Float,22),
                    new OracleParameter(":n_js", OracleType.Number,4),
                    new OracleParameter(":N_DZJJG", OracleType.Float,22),
                    new OracleParameter(":N_DLSWCZ", OracleType.Float,22)
            };
            parameters[0].Value = model.N_XZDH;
            parameters[1].Value = model.N_SYJG;
            parameters[2].Value = model.N_HYJG;
            parameters[3].Value = model.N_DLSJG;
            parameters[4].Value = model.N_ZDLJG;
            parameters[5].Value = model.N_GDJG;
            parameters[6].Value = model.N_DGDJG;
            parameters[7].Value = model.N_ZJJG;
            parameters[8].Value = model.N_GSJG;
            parameters[9].Value = model.N_JS;
            parameters[10].Value = model.N_DZJJG;
            parameters[11].Value = model.N_DLSWCZ;
            DbHelperOra.ExecuteSql(conn, tran, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取剩余额度
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <returns></returns>
        public decimal GetCredit(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  N_SYED");
            strSql.Append(" FROM KFB_HYGL WHERE N_HYZH=:N_HYZH");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100)
            };
            parameters[0].Value = N_HYZH;
            return Convert.ToDecimal(DbHelperOra.GetSingle(conn, tran, strSql.ToString(), parameters));
        }
    
    }
