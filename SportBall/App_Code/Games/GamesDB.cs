using KingOfBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;


public class GamesDB : CommLib.DbCommon
{
    /// <summary>
    /// 设定最大线程数
    /// </summary>
    private readonly int COUNT_THREAD = 0;
    /// <summary>
    /// 单线程查询
    /// </summary>
    public GamesDB()
    {
        COUNT_THREAD = 0;
    }
    /// <summary>
    /// 多线程查询
    /// </summary>
    /// <param name="threadCount"></param>
    public GamesDB(int threadCount)
    {
        COUNT_THREAD = threadCount > 64 ? 64 : threadCount;
    }

    #region 会员端

    #region 方法一
    public List<List<object>> GetClientFootBallSigleList(string[] alliance, string user, string OrderName, int isSingle, int pageIndex, int pageSize, out int recordCount, out decimal rateGap, out List<List<object>> listLM)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar),
                new OracleParameter("n_hydh",OracleType.VarChar,20),
                new OracleParameter("isSingle",OracleType.Int32),
                new OracleParameter("orderName",OracleType.VarChar,200),
                new OracleParameter("pageIndex",OracleType.Int32),
                new OracleParameter("pageSize",OracleType.Int32),
                new OracleParameter("t_lmlist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor),
                new OracleParameter("recordCount", OracleType.Int32),
                new OracleParameter("rategap", OracleType.Number)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = user;
        parameter[2].Value = isSingle;
        parameter[3].Value = OrderName.Equals("1") ? "N_GAMEDATE" : "N_VISIT_NO";
        parameter[4].Value = pageIndex;
        parameter[5].Value = pageSize;
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        parameter[8].Direction = System.Data.ParameterDirection.Output;
        parameter[9].Direction = System.Data.ParameterDirection.Output;
        parameter[10].Direction = System.Data.ParameterDirection.Output;
        List<List<object>> gameList = new List<List<object>>();
        List<List<object>> templm = new List<List<object>>();
        using (OracleDataReader dr = DbHelperOra.RunProcedure("pkg_client_football_singlelist.sp_client_football_singlelist", parameter))
        {
            //allianceDic = new Dictionary<int, string>();
            Dictionary<int, string> teamDic = new Dictionary<int, string>();
            Dictionary<int, string> lmDic = new Dictionary<int, string>();
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://联盟列表
                        while (dr.Read())
                        {
                            //allianceDic.Add(dr.GetInt32(0), dr.GetString(1));

                            lmDic.Add(dr.GetInt32(0), dr.GetString(1));
                            List<object> o_lm = new List<object>();
                            o_lm.Add(dr.GetInt32(0));
                            o_lm.Add(dr.GetString(1));
                            templm.Add(o_lm);
                        }
                        break;
                    case 1://队伍列表
                        while (dr.Read())
                        {
                            teamDic.Add(dr.GetInt32(0), dr.GetString(1));
                        }
                        break;
                    case 2://赛事列表
                        #region 赛事
                        while (dr.Read())
                        {
                            List<object> gameAll = gameList.Find(delegate(List<object> sameGame)
                            {
                                return sameGame[11].Equals(dr["N_SAMEGAME"]) && Convert.ToInt32(sameGame[10]) == 1 && Convert.ToInt32(dr["N_CBXH"]) == 2;
                            });
                            if (gameAll == null)
                            {
                                List<object> game = new List<object>();
                                game.Add(dr["n_id"]);                               /*0*/
                                game.Add(dr["n_lx"]);                               /*1*/
                                game.Add(dr["n_zwdate"]);                           /*2*/
                                game.Add(dr["n_gamedate"]);                         /*3*/
                                game.Add(dr["n_lmno"]);                             /*4*/
                                game.Add(lmDic[Convert.ToInt32(dr["n_lmno"])]);     /*5*/
                                game.Add(dr["n_visit"]);                            /*6*/
                                game.Add(teamDic[Convert.ToInt32(dr["n_visit"])]);  /*7*/
                                game.Add(dr["n_home"]);                             /*8*/
                                game.Add(teamDic[Convert.ToInt32(dr["n_home"])]);   /*9*/
                                game.Add(dr["N_CBXH"]);                             /*10*/
                                game.Add(dr["N_SAMEGAME"]);                         /*11*/
                                game.Add(dr["N_LET"]);                              /*12*/
                                game.Add(dr["N_SFXZ"]);                             /*13*/
                                game.Add(dr["N_LOCK"]);                             /*14*/
                                game.Add(dr["N_ZBXH"]);                             /*15*/
                                game.Add(dr["N_SFZD"]);                             /*16*/
                                game.Add(dr["N_VISIT_NO"]);                         /*17*/
                                game.Add(dr["N_HOME_NO"]);                          /*18*/
                                game.Add(dr["N_VH"]);                               /*19*/
                                game.Add(dr["N_REMARK"]);                           /*20*/
                                //和局
                                game.Add(dr["N_HJPL"]);                             /*21*/
                                //让分
                                game.Add(dr["N_RFLX"]);                             /*22*/
                                game.Add(dr["N_RFFS"]);                             /*23*/
                                game.Add(dr["N_RFBL"]);                             /*24*/
                                game.Add(dr["N_LRFPL"]);                            /*25*/
                                game.Add(dr["N_RRFPL"]);                            /*26*/
                                game.Add(dr["N_RF_OPEN"]);                          /*27*/
                                game.Add(dr["N_RF_LOCK_V"]);                        /*28*/
                                game.Add(dr["N_RF_LOCK_H"]);                        /*29*/
                                //大小
                                game.Add(dr["N_DXLX"]);                             /*30*/
                                game.Add(dr["N_DXFS"]);                             /*31*/
                                game.Add(dr["N_DXBL"]);                             /*32*/
                                game.Add(dr["N_DXDPL"]);                            /*33*/
                                game.Add(dr["N_DXXPL"]);                            /*34*/
                                game.Add(dr["N_DX_OPEN"]);                          /*35*/
                                game.Add(dr["N_DX_LOCK_V"]);                        /*36*/
                                game.Add(dr["N_DX_LOCK_H"]);                        /*37*/
                                //赌赢                                             
                                game.Add(dr["N_LDYPL"]);                            /*38*/
                                game.Add(dr["N_RDYPL"]);                            /*39*/
                                game.Add(dr["N_DY_OPEN"]);                          /*40*/
                                game.Add(dr["N_DY_LOCK_V"]);                        /*41*/
                                game.Add(dr["N_DY_LOCK_H"]);                        /*42*/
                                //上半场补空
                                //和局
                                game.Add(String.Empty);                             /*43*/
                                //让分
                                game.Add(String.Empty);                             /*44*/
                                game.Add(String.Empty);                             /*45*/
                                game.Add(String.Empty);                             /*46*/
                                game.Add(String.Empty);                             /*47*/
                                game.Add(String.Empty);                             /*48*/
                                game.Add(String.Empty);                             /*49*/
                                game.Add(String.Empty);                             /*50*/
                                game.Add(String.Empty);                             /*51*/
                                //大小
                                game.Add(String.Empty);                             /*52*/
                                game.Add(String.Empty);                             /*53*/
                                game.Add(String.Empty);                             /*54*/
                                game.Add(String.Empty);                             /*55*/
                                game.Add(String.Empty);                             /*56*/
                                game.Add(String.Empty);                             /*57*/
                                game.Add(String.Empty);                             /*58*/
                                game.Add(String.Empty);                             /*59*/
                                //赌赢
                                game.Add(String.Empty);                             /*60*/
                                game.Add(String.Empty);                             /*61*/
                                game.Add(String.Empty);                             /*62*/
                                game.Add(String.Empty);                             /*63*/
                                game.Add(String.Empty);                             /*64*/

                                /*如果有加新字段，可再次后面添加，并加上索引注释*/
                                game.Add(String.Empty);                             /*65*/
                                game.Add(String.Empty);                             /*66*/
                                gameList.Add(game);
                            }
                            else
                            {
                                //复写上半场数据到全场
                                gameAll[43] = dr["N_HJPL"];
                                gameAll[44] = dr["N_RFLX"];
                                gameAll[45] = dr["N_RFFS"];
                                gameAll[46] = dr["N_RFBL"];
                                gameAll[47] = dr["N_LRFPL"];
                                gameAll[48] = dr["N_RRFPL"];
                                gameAll[49] = dr["N_RF_OPEN"];
                                gameAll[50] = dr["N_RF_LOCK_V"];
                                gameAll[51] = dr["N_RF_LOCK_H"];
                                gameAll[52] = dr["N_DXLX"];
                                gameAll[53] = dr["N_DXFS"];
                                gameAll[54] = dr["N_DXBL"];
                                gameAll[55] = dr["N_DXDPL"];
                                gameAll[56] = dr["N_DXXPL"];
                                gameAll[57] = dr["N_DX_OPEN"];
                                gameAll[58] = dr["N_DX_LOCK_V"];
                                gameAll[59] = dr["N_DX_LOCK_H"];
                                gameAll[60] = dr["N_LDYPL"];
                                gameAll[61] = dr["N_RDYPL"];
                                gameAll[62] = dr["N_DY_OPEN"];
                                gameAll[63] = dr["N_DY_LOCK_V"];
                                gameAll[64] = dr["N_DY_LOCK_H"];

                                gameAll[65] = dr["N_ID"];
                                gameAll[66] = dr["N_LET"];
                            }
                        }
                        break;
                        #endregion
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        recordCount = Convert.ToInt32(parameter[9].Value);
        rateGap = Convert.ToDecimal(parameter[10].Value);
        listLM = templm;
        return gameList;
    }
    public List<List<object>> GetClientFootBallGoToList(string[] alliance, string user, string OrderName, int pageIndex, int pageSize, out int recordCount, out decimal rateGap, out List<List<object>> listLM)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar),
                new OracleParameter("n_hydh",OracleType.VarChar,20),
                new OracleParameter("orderName",OracleType.VarChar,200),
                new OracleParameter("pageIndex",OracleType.Int32),
                new OracleParameter("pageSize",OracleType.Int32),
                new OracleParameter("t_lmlist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor),
                new OracleParameter("recordCount", OracleType.Int32),
                new OracleParameter("rategap", OracleType.Number)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = user;
        parameter[2].Value = OrderName.Equals("1") ? "N_GAMEDATE" : "N_VISIT_NO";
        parameter[3].Value = pageIndex;
        parameter[4].Value = pageSize;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        parameter[8].Direction = System.Data.ParameterDirection.Output;
        parameter[9].Direction = System.Data.ParameterDirection.Output;
        List<List<object>> gameList = new List<List<object>>();
        List<List<object>> templm = new List<List<object>>();
        using (OracleDataReader dr = DbHelperOra.RunProcedure("pkg_client_football_gotolist.sp_client_football_gotolist", parameter))
        {
            Dictionary<int, string> lmDic = new Dictionary<int, string>();
            Dictionary<int, string> teamDic = new Dictionary<int, string>();
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://联盟列表
                        while (dr.Read())
                        {
                            lmDic.Add(dr.GetInt32(0), dr.GetString(1));
                            List<object> o_lm = new List<object>();
                            o_lm.Add(dr.GetInt32(0));
                            o_lm.Add(dr.GetString(1));
                            templm.Add(o_lm);
                        }
                        break;
                    case 1://队伍列表
                        while (dr.Read())
                        {
                            teamDic.Add(dr.GetInt32(0), dr.GetString(1));
                        }
                        break;
                    case 2://赛事列表
                        #region 赛事
                        while (dr.Read())
                        {
                            List<object> gameAll = gameList.Find(delegate(List<object> sameGame)
                            {
                                return sameGame[11].Equals(dr["N_SAMEGAME"]) && Convert.ToInt32(sameGame[10]) == 1 && Convert.ToInt32(dr["N_CBXH"]) == 2;
                            });
                            if (gameAll == null)
                            {
                                List<object> game = new List<object>();
                                game.Add(dr["n_id"]);                               /*0*/
                                game.Add(dr["n_lx"]);                               /*1*/
                                game.Add(dr["n_zwdate"]);                           /*2*/
                                game.Add(dr["n_gamedate"]);                         /*3*/
                                game.Add(dr["n_lmno"]);                             /*4*/
                                game.Add(lmDic[Convert.ToInt32(dr["n_lmno"])]);     /*5*/
                                game.Add(dr["n_visit"]);                            /*6*/
                                game.Add(teamDic[Convert.ToInt32(dr["n_visit"])]);  /*7*/
                                game.Add(dr["n_home"]);                             /*8*/
                                game.Add(teamDic[Convert.ToInt32(dr["n_home"])]);   /*9*/
                                game.Add(dr["N_CBXH"]);                             /*10*/
                                game.Add(dr["N_SAMEGAME"]);                         /*11*/
                                game.Add(dr["N_LET"]);                              /*12*/
                                game.Add(dr["N_SFXZ"]);                             /*13*/
                                game.Add(dr["N_LOCK"]);                             /*14*/
                                game.Add(dr["N_ZBXH"]);                             /*15*/
                                game.Add(dr["N_SFZD"]);                             /*16*/
                                game.Add(dr["N_VISIT_NO"]);                         /*17*/
                                game.Add(dr["N_HOME_NO"]);                          /*18*/
                                game.Add(dr["N_VH"]);                               /*19*/
                                game.Add(dr["N_REMARK"]);                           /*20*/
                                //和局
                                game.Add(dr["N_HJPL"]);                             /*21*/
                                //让分
                                game.Add(dr["N_RFLX"]);                             /*22*/
                                game.Add(dr["N_RFFS"]);                             /*23*/
                                game.Add(dr["N_RFBL"]);                             /*24*/
                                game.Add(dr["N_LRFPL"]);                            /*25*/
                                game.Add(dr["N_RRFPL"]);                            /*26*/
                                game.Add(dr["N_RF_OPEN"]);                          /*27*/
                                game.Add(dr["N_RF_LOCK_V"]);                        /*28*/
                                game.Add(dr["N_RF_LOCK_H"]);                        /*29*/
                                //大小
                                game.Add(dr["N_DXLX"]);                             /*30*/
                                game.Add(dr["N_DXFS"]);                             /*31*/
                                game.Add(dr["N_DXBL"]);                             /*32*/
                                game.Add(dr["N_DXDPL"]);                            /*33*/
                                game.Add(dr["N_DXXPL"]);                            /*34*/
                                game.Add(dr["N_DX_OPEN"]);                          /*35*/
                                game.Add(dr["N_DX_LOCK_V"]);                        /*36*/
                                game.Add(dr["N_DX_LOCK_H"]);                        /*37*/
                                //赌赢                                             
                                game.Add(dr["N_LDYPL"]);                            /*38*/
                                game.Add(dr["N_RDYPL"]);                            /*39*/
                                game.Add(dr["N_DY_OPEN"]);                          /*40*/
                                game.Add(dr["N_DY_LOCK_V"]);                        /*41*/
                                game.Add(dr["N_DY_LOCK_H"]);                        /*42*/
                                //上半场补空
                                //和局
                                game.Add(String.Empty);                             /*43*/
                                //让分
                                game.Add(String.Empty);                             /*44*/
                                game.Add(String.Empty);                             /*45*/
                                game.Add(String.Empty);                             /*46*/
                                game.Add(String.Empty);                             /*47*/
                                game.Add(String.Empty);                             /*48*/
                                game.Add(String.Empty);                             /*49*/
                                game.Add(String.Empty);                             /*50*/
                                game.Add(String.Empty);                             /*51*/
                                //大小
                                game.Add(String.Empty);                             /*52*/
                                game.Add(String.Empty);                             /*53*/
                                game.Add(String.Empty);                             /*54*/
                                game.Add(String.Empty);                             /*55*/
                                game.Add(String.Empty);                             /*56*/
                                game.Add(String.Empty);                             /*57*/
                                game.Add(String.Empty);                             /*58*/
                                game.Add(String.Empty);                             /*59*/
                                //赌赢
                                game.Add(String.Empty);                             /*60*/
                                game.Add(String.Empty);                             /*61*/
                                game.Add(String.Empty);                             /*62*/
                                game.Add(String.Empty);                             /*63*/
                                game.Add(String.Empty);                             /*64*/

                                /*如果有加新字段，可再次后面添加，并加上索引注释*/
                                game.Add(String.Empty);                             /*65*/
                                game.Add(String.Empty);                             /*66*/

                                game.Add(dr["N_VISIT_JZF"]);                        /*67*/
                                game.Add(dr["N_HOME_JZF"]);                         /*68*/
                                game.Add(dr["N_ZDTIME"]);                           /*69*/
                                game.Add(dr["N_ZDFLAG"]);                           /*70*/
                                game.Add(dr["N_ZDUPTIME"]);                         /*71*///n_zduptime  lpad(to_char(nvl(n_zdtime, 0)+round((sysdate - n_zduptime) * 24 * 60, 0)),2,'0')
                                gameList.Add(game);
                            }
                            else
                            {
                                //复写上半场数据到全场
                                gameAll[43] = dr["N_HJPL"];
                                gameAll[44] = dr["N_RFLX"];
                                gameAll[45] = dr["N_RFFS"];
                                gameAll[46] = dr["N_RFBL"];
                                gameAll[47] = dr["N_LRFPL"];
                                gameAll[48] = dr["N_RRFPL"];
                                gameAll[49] = dr["N_RF_OPEN"];
                                gameAll[50] = dr["N_RF_LOCK_V"];
                                gameAll[51] = dr["N_RF_LOCK_H"];
                                gameAll[52] = dr["N_DXLX"];
                                gameAll[53] = dr["N_DXFS"];
                                gameAll[54] = dr["N_DXBL"];
                                gameAll[55] = dr["N_DXDPL"];
                                gameAll[56] = dr["N_DXXPL"];
                                gameAll[57] = dr["N_DX_OPEN"];
                                gameAll[58] = dr["N_DX_LOCK_V"];
                                gameAll[59] = dr["N_DX_LOCK_H"];
                                gameAll[60] = dr["N_LDYPL"];
                                gameAll[61] = dr["N_RDYPL"];
                                gameAll[62] = dr["N_DY_OPEN"];
                                gameAll[63] = dr["N_DY_LOCK_V"];
                                gameAll[64] = dr["N_DY_LOCK_H"];

                                gameAll[65] = dr["N_ID"];
                                gameAll[66] = dr["N_LET"];
                            }
                        }
                        break;
                        #endregion
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        recordCount = Convert.ToInt32(parameter[8].Value);
        rateGap = Convert.ToDecimal(parameter[9].Value);
        listLM = templm;
        return gameList;
    }
    public List<List<object>> GetClientFootBallPassList(string[] alliance, string user, string OrderName, int pageIndex, int pageSize, out int recordCount, out decimal rateGap, out List<List<object>> listLM)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar),
                new OracleParameter("n_hydh",OracleType.VarChar,20),
                new OracleParameter("orderName",OracleType.VarChar,200),
                new OracleParameter("pageIndex",OracleType.Int32),
                new OracleParameter("pageSize",OracleType.Int32),
                new OracleParameter("t_lmlist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor),
                new OracleParameter("recordCount", OracleType.Int32),
                new OracleParameter("rategap", OracleType.Number)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = user;
        parameter[2].Value = OrderName.Equals("1") ? "N_GAMEDATE" : "N_VISIT_NO";
        parameter[3].Value = pageIndex;
        parameter[4].Value = pageSize;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        parameter[8].Direction = System.Data.ParameterDirection.Output;
        parameter[9].Direction = System.Data.ParameterDirection.Output;
        List<List<object>> gameList = new List<List<object>>();
        List<List<object>> templm = new List<List<object>>();
        using (OracleDataReader dr = DbHelperOra.RunProcedure("pkg_client_football_passlist.sp_client_football_passlist", parameter))
        {
            Dictionary<int, string> teamDic = new Dictionary<int, string>();
            Dictionary<int, string> lmDic = new Dictionary<int, string>();
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://联盟列表
                        while (dr.Read())
                        {
                            lmDic.Add(dr.GetInt32(0), dr.GetString(1));
                            List<object> o_lm = new List<object>();
                            o_lm.Add(dr.GetInt32(0));
                            o_lm.Add(dr.GetString(1));
                            templm.Add(o_lm);
                        }
                        break;
                    case 1://队伍列表
                        while (dr.Read())
                        {
                            teamDic.Add(dr.GetInt32(0), dr.GetString(1));
                        }
                        break;
                    case 2://赛事列表
                        #region 赛事
                        while (dr.Read())
                        {
                            List<object> game = new List<object>();
                            game.Add(dr["n_id"]);                               /*0*/
                            game.Add(dr["n_lx"]);                               /*1*/
                            game.Add(dr["n_zwdate"]);                           /*2*/
                            game.Add(dr["n_gamedate"]);                         /*3*/
                            game.Add(dr["n_lmno"]);                             /*4*/
                            game.Add(lmDic[Convert.ToInt32(dr["n_lmno"])]);     /*5*/
                            game.Add(dr["n_visit"]);                            /*6*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_visit"])]);  /*7*/
                            game.Add(dr["n_home"]);                             /*8*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_home"])]);   /*9*/
                            game.Add(dr["N_CBXH"]);                             /*10*/
                            game.Add(dr["N_SAMEGAME"]);                         /*11*/
                            game.Add(dr["N_LET"]);                              /*12*/
                            game.Add(dr["N_SFXZ"]);                             /*13*/
                            game.Add(dr["N_LOCK"]);                             /*14*/
                            game.Add(dr["N_ZBXH"]);                             /*15*/
                            game.Add(dr["N_HJPL"]);                             /*16*/
                            game.Add(dr["N_VISIT_NO"]);                         /*17*/
                            game.Add(dr["N_HOME_NO"]);                          /*18*/
                            game.Add(dr["N_VH"]);                               /*19*/
                            game.Add(dr["N_REMARK"]);                           /*20*/
                            game.Add(dr["N_HJGGCJ"]);                           /*21*/
                            //让分
                            game.Add(dr["N_RFLX"]);                             /*22*/
                            game.Add(dr["N_RFFS"]);                             /*23*/
                            game.Add(dr["N_RFBL"]);                             /*24*/
                            game.Add(dr["N_LRFPL"]);                            /*25*/
                            game.Add(dr["N_RRFPL"]);                            /*26*/
                            game.Add(dr["N_RF_OPEN"]);                          /*27*/
                            game.Add(dr["N_RF_LOCK_V"]);                        /*28*/
                            game.Add(dr["N_RF_LOCK_H"]);                        /*29*/
                            game.Add(dr["N_RF_GG"]);                            /*30*/
                            game.Add(dr["N_LRFCJ"]);                            /*31*/
                            game.Add(dr["N_RRFCJ"]);                            /*32*/
                            //大小
                            game.Add(dr["N_DXLX"]);                             /*33*/
                            game.Add(dr["N_DXFS"]);                             /*34*/
                            game.Add(dr["N_DXBL"]);                             /*35*/
                            game.Add(dr["N_DXDPL"]);                            /*36*/
                            game.Add(dr["N_DXXPL"]);                            /*37*/
                            game.Add(dr["N_DX_OPEN"]);                          /*38*/
                            game.Add(dr["N_DX_LOCK_V"]);                        /*39*/
                            game.Add(dr["N_DX_LOCK_H"]);                        /*40*/
                            game.Add(dr["N_DX_GG"]);                            /*41*/
                            game.Add(dr["N_DXDCJ"]);                            /*42*/
                            game.Add(dr["N_DXXCJ"]);                            /*43*/
                            //单双
                            game.Add(dr["N_DSDPL"]);                            /*44*/
                            game.Add(dr["N_DSSPL"]);                            /*45*/
                            game.Add(dr["N_DS_OPEN"]);                          /*46*/
                            game.Add(dr["N_DS_LOCK_V"]);                        /*47*/
                            game.Add(dr["N_DS_LOCK_H"]);                        /*48*/
                            game.Add(dr["N_DS_GG"]);                            /*49*/
                            game.Add(dr["N_DSDCJ"]);                            /*50*/
                            game.Add(dr["N_DSSCJ"]);                            /*51*/
                            //独赢
                            game.Add(dr["N_LDYPL"]);                            /*52*/
                            game.Add(dr["N_RDYPL"]);                            /*53*/
                            game.Add(dr["N_DY_OPEN"]);                          /*54*/
                            game.Add(dr["N_DY_LOCK_V"]);                        /*55*/
                            game.Add(dr["N_DY_LOCK_H"]);                        /*56*/
                            game.Add(dr["N_DY_GG"]);                            /*57*/
                            game.Add(dr["N_LDYCJ"]);                            /*58*/
                            game.Add(dr["N_RDYCJ"]);                            /*59*/
                            game.Add(dr["N_SAMETEAM"]);                         /*60*/

                            gameList.Add(game);
                        }
                        break;
                        #endregion
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        recordCount = Convert.ToInt32(parameter[8].Value);
        rateGap = Convert.ToDecimal(parameter[9].Value);
        listLM = templm;
        return gameList;
    }
    public List<List<object>> GetClientOtherBallSigleList(string[] alliance, string OrderName, int isSingle, int pageIndex, int pageSize, out int recordCount, out List<List<object>> listLM, string ballType, int courtType)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar),
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32),
                new OracleParameter("isSingle",OracleType.Int32),
                new OracleParameter("orderName",OracleType.VarChar,20),
                new OracleParameter("pageIndex",OracleType.Int32),
                new OracleParameter("pageSize",OracleType.Int32),
                new OracleParameter("t_lmlist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor),
                new OracleParameter("recordCount", OracleType.Int32)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = ballType;
        parameter[2].Value = courtType;
        parameter[3].Value = isSingle;
        parameter[4].Value = OrderName.Equals("1") ? "N_GAMEDATE" : "N_VISIT_NO";
        parameter[5].Value = pageIndex;
        parameter[6].Value = pageSize;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        parameter[8].Direction = System.Data.ParameterDirection.Output;
        parameter[9].Direction = System.Data.ParameterDirection.Output;
        parameter[10].Direction = System.Data.ParameterDirection.Output;
        List<List<object>> gameList = new List<List<object>>();
        List<List<object>> templm = new List<List<object>>();
        using (OracleDataReader dr = DbHelperOra.RunProcedure("pkg_client_singlelist.sp_client_singlelist", parameter))
        {
            Dictionary<int, string> teamDic = new Dictionary<int, string>();
            Dictionary<int, string> lmDic = new Dictionary<int, string>();
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://联盟列表
                        while (dr.Read())
                        {
                            lmDic.Add(dr.GetInt32(0), dr.GetString(1));
                            List<object> o_lm = new List<object>();
                            o_lm.Add(dr.GetInt32(0));
                            o_lm.Add(dr.GetString(1));
                            templm.Add(o_lm);
                        }
                        break;
                    case 1://队伍列表
                        while (dr.Read())
                        {
                            teamDic.Add(dr.GetInt32(0), dr.GetString(1));
                        }
                        break;
                    case 2://赛事列表
                        #region 赛事
                        while (dr.Read())
                        {
                            List<object> game = new List<object>();
                            game.Add(dr["n_id"]);                               /*0*/
                            game.Add(dr["n_lx"]);                               /*1*/
                            game.Add(dr["n_zwdate"]);                           /*2*/
                            game.Add(dr["n_gamedate"]);                         /*3*/
                            game.Add(dr["n_lmno"]);                             /*4*/
                            game.Add(lmDic[Convert.ToInt32(dr["n_lmno"])]);/*5*/
                            game.Add(dr["n_visit"]);                            /*6*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_visit"])]);  /*7*/
                            game.Add(dr["n_home"]);                             /*8*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_home"])]);   /*9*/
                            game.Add(dr["N_CBXH"]);                             /*10*/
                            game.Add(dr["N_SAMEGAME"]);                         /*11*/
                            game.Add(dr["N_LET"]);                              /*12*/
                            game.Add(dr["N_SFXZ"]);                             /*13*/
                            game.Add(dr["N_LOCK"]);                             /*14*/
                            game.Add(dr["N_ZBXH"]);                             /*15*/
                            game.Add(dr["N_SFZD"]);                             /*16*/
                            game.Add(dr["N_VISIT_NO"]);                         /*17*/
                            game.Add(dr["N_HOME_NO"]);                          /*18*/
                            game.Add(dr["N_VH"]);                               /*19*/
                            game.Add(dr["N_REMARK"]);                           /*20*/
                            game.Add(dr["N_HJPL"]);                             /*21*/
                            //让分
                            game.Add(dr["N_RFLX"]);                             /*22*/
                            game.Add(dr["N_RFFS"]);                             /*23*/
                            game.Add(dr["N_RFBL"]);                             /*24*/
                            game.Add(dr["N_LRFPL"]);                            /*25*/
                            game.Add(dr["N_RRFPL"]);                            /*26*/
                            game.Add(dr["N_RF_OPEN"]);                          /*27*/
                            game.Add(dr["N_RF_LOCK_V"]);                        /*28*/
                            game.Add(dr["N_RF_LOCK_H"]);                        /*29*/
                            //大小
                            game.Add(dr["N_DXLX"]);                             /*30*/
                            game.Add(dr["N_DXFS"]);                             /*31*/
                            game.Add(dr["N_DXBL"]);                             /*32*/
                            game.Add(dr["N_DXDPL"]);                            /*33*/
                            game.Add(dr["N_DXXPL"]);                            /*34*/
                            game.Add(dr["N_DX_OPEN"]);                          /*35*/
                            game.Add(dr["N_DX_LOCK_V"]);                        /*36*/
                            game.Add(dr["N_DX_LOCK_H"]);                        /*37*/
                            //赌赢                                             
                            game.Add(dr["N_LDYPL"]);                            /*38*/
                            game.Add(dr["N_RDYPL"]);                            /*39*/
                            game.Add(dr["N_DY_OPEN"]);                          /*40*/
                            game.Add(dr["N_DY_LOCK_V"]);                        /*41*/
                            game.Add(dr["N_DY_LOCK_H"]);                        /*42*/
                            //一输二赢
                            game.Add(dr["N_LSYPL"]);                             /*43*/
                            game.Add(dr["N_RSYPL"]);                             /*44*/
                            game.Add(dr["N_DY_OPEN"]);                           /*45*/
                            game.Add(dr["N_DY_LOCK_V"]);                         /*46*/
                            game.Add(dr["N_DY_LOCK_H"]);                         /*47*/
                            //单双
                            game.Add(dr["N_DSDPL"]);                             /*48*/
                            game.Add(dr["N_DSSPL"]);                             /*49*/
                            game.Add(dr["N_DS_OPEN"]);                           /*50*/
                            game.Add(dr["N_DS_LOCK_V"]);                         /*51*/
                            game.Add(dr["N_DS_LOCK_H"]);                         /*52*/

                            /*如果有加新字段，可再次后面添加，并加上索引注释*/
                            gameList.Add(game);

                        }
                        break;
                        #endregion
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        recordCount = Convert.ToInt32(parameter[10].Value);
        listLM = templm;
        return gameList;
    }
    public List<List<object>> GetClientOtherBallGoToList(string[] alliance, string OrderName, int pageIndex, int pageSize, out int recordCount, out List<List<object>> listLM, string ballType)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar),
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("orderName",OracleType.VarChar,200),
                new OracleParameter("pageIndex",OracleType.Int32),
                new OracleParameter("pageSize",OracleType.Int32),
                new OracleParameter("t_lmlist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor),
                new OracleParameter("recordCount", OracleType.Int32)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = ballType;
        parameter[2].Value = OrderName.Equals("1") ? "N_GAMEDATE" : "N_VISIT_NO";
        parameter[3].Value = pageIndex;
        parameter[4].Value = pageSize;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        parameter[8].Direction = System.Data.ParameterDirection.Output;
        List<List<object>> gameList = new List<List<object>>();
        List<List<object>> templm = new List<List<object>>();
        using (OracleDataReader dr = DbHelperOra.RunProcedure("pkg_client_gotolist.sp_client_gotolist", parameter))
        {
            Dictionary<int, string> lmDic = new Dictionary<int, string>();
            Dictionary<int, string> teamDic = new Dictionary<int, string>();
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://联盟列表
                        while (dr.Read())
                        {
                            lmDic.Add(dr.GetInt32(0), dr.GetString(1));
                            List<object> o_lm = new List<object>();
                            o_lm.Add(dr.GetInt32(0));
                            o_lm.Add(dr.GetString(1));
                            templm.Add(o_lm);
                        }
                        break;
                    case 1://队伍列表
                        while (dr.Read())
                        {
                            teamDic.Add(dr.GetInt32(0), dr.GetString(1));
                        }
                        break;
                    case 2://赛事列表
                        #region 赛事
                        while (dr.Read())
                        {
                            List<object> game = new List<object>();
                            game.Add(dr["n_id"]);                               /*0*/
                            game.Add(dr["n_lx"]);                               /*1*/
                            game.Add(dr["n_zwdate"]);                           /*2*/
                            game.Add(dr["n_gamedate"]);                         /*3*/
                            game.Add(dr["n_lmno"]);                             /*4*/
                            game.Add(lmDic[Convert.ToInt32(dr["n_lmno"])]);     /*5*/
                            game.Add(dr["n_visit"]);                            /*6*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_visit"])]);  /*7*/
                            game.Add(dr["n_home"]);                             /*8*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_home"])]);   /*9*/
                            game.Add(dr["N_CBXH"]);                             /*10*/
                            game.Add(dr["N_SAMEGAME"]);                         /*11*/
                            game.Add(dr["N_LET"]);                              /*12*/
                            game.Add(dr["N_SFXZ"]);                             /*13*/
                            game.Add(dr["N_LOCK"]);                             /*14*/
                            game.Add(dr["N_ZBXH"]);                             /*15*/
                            game.Add(dr["N_HOME_JZF"]);                         /*16*/
                            game.Add(dr["N_VISIT_NO"]);                         /*17*/
                            game.Add(dr["N_HOME_NO"]);                          /*18*/
                            game.Add(dr["N_VH"]);                               /*19*/
                            game.Add(dr["N_REMARK"]);                           /*20*/
                            game.Add(dr["N_VISIT_JZF"]);                        /*21*/
                            //让分
                            game.Add(dr["N_RFLX"]);                             /*22*/
                            game.Add(dr["N_RFFS"]);                             /*23*/
                            game.Add(dr["N_RFBL"]);                             /*24*/
                            game.Add(dr["N_LRFPL"]);                            /*25*/
                            game.Add(dr["N_RRFPL"]);                            /*26*/
                            game.Add(dr["N_RF_OPEN"]);                          /*27*/
                            game.Add(dr["N_RF_LOCK_V"]);                        /*28*/
                            game.Add(dr["N_RF_LOCK_H"]);                        /*29*/
                            //大小
                            game.Add(dr["N_DXLX"]);                             /*30*/
                            game.Add(dr["N_DXFS"]);                             /*31*/
                            game.Add(dr["N_DXBL"]);                             /*32*/
                            game.Add(dr["N_DXDPL"]);                            /*33*/
                            game.Add(dr["N_DXXPL"]);                            /*34*/
                            game.Add(dr["N_DX_OPEN"]);                          /*35*/
                            game.Add(dr["N_DX_LOCK_V"]);                        /*36*/
                            game.Add(dr["N_DX_LOCK_H"]);                        /*37*/
                            gameList.Add(game);
                        }
                        break;
                        #endregion
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        recordCount = Convert.ToInt32(parameter[8].Value);
        listLM = templm;
        return gameList;
    }
    public List<List<object>> GetClientOtherBallPassList(string[] alliance, string OrderName, int pageIndex, int pageSize, out int recordCount, out List<List<object>> listLM, string ballType)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar),
                new OracleParameter("n_lx",OracleType.VarChar,20),
                new OracleParameter("orderName",OracleType.VarChar,200),
                new OracleParameter("pageIndex",OracleType.Int32),
                new OracleParameter("pageSize",OracleType.Int32),
                new OracleParameter("t_lmlist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor),
                new OracleParameter("recordCount", OracleType.Int32)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = ballType;
        parameter[2].Value = OrderName.Equals("1") ? "N_GAMEDATE" : "N_VISIT_NO";
        parameter[3].Value = pageIndex;
        parameter[4].Value = pageSize;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        parameter[8].Direction = System.Data.ParameterDirection.Output;
        List<List<object>> gameList = new List<List<object>>();
        List<List<object>> templm = new List<List<object>>();
        using (OracleDataReader dr = DbHelperOra.RunProcedure("pkg_client_passlist.sp_client_passlist", parameter))
        {
            Dictionary<int, string> lmDic = new Dictionary<int, string>();
            Dictionary<int, string> teamDic = new Dictionary<int, string>();
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://联盟列表
                        while (dr.Read())
                        {
                            lmDic.Add(dr.GetInt32(0), dr.GetString(1));
                            List<object> o_lm = new List<object>();
                            o_lm.Add(dr.GetInt32(0));
                            o_lm.Add(dr.GetString(1));
                            templm.Add(o_lm);
                        }
                        break;
                    case 1://队伍列表
                        while (dr.Read())
                        {
                            teamDic.Add(dr.GetInt32(0), dr.GetString(1));
                        }
                        break;
                    case 2://赛事列表
                        #region 赛事
                        while (dr.Read())
                        {
                            List<object> game = new List<object>();
                            game.Add(dr["n_id"]);                               /*0*/
                            game.Add(dr["n_lx"]);                               /*1*/
                            game.Add(dr["n_zwdate"]);                           /*2*/
                            game.Add(dr["n_gamedate"]);                         /*3*/
                            game.Add(dr["n_lmno"]);                             /*4*/
                            game.Add(lmDic[Convert.ToInt32(dr["n_lmno"])]);     /*5*/
                            game.Add(dr["n_visit"]);                            /*6*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_visit"])]);  /*7*/
                            game.Add(dr["n_home"]);                             /*8*/
                            game.Add(teamDic[Convert.ToInt32(dr["n_home"])]);   /*9*/
                            game.Add(dr["N_CBXH"]);                             /*10*/
                            game.Add(dr["N_SAMEGAME"]);                         /*11*/
                            game.Add(dr["N_LET"]);                              /*12*/
                            game.Add(dr["N_SFXZ"]);                             /*13*/
                            game.Add(dr["N_LOCK"]);                             /*14*/
                            game.Add(dr["N_ZBXH"]);                             /*15*/
                            game.Add(dr["N_HJPL"]);                             /*16*/
                            game.Add(dr["N_VISIT_NO"]);                         /*17*/
                            game.Add(dr["N_HOME_NO"]);                          /*18*/
                            game.Add(dr["N_VH"]);                               /*19*/
                            game.Add(dr["N_REMARK"]);                           /*20*/
                            game.Add(dr["N_HJGGCJ"]);                           /*21*/
                            //让分
                            game.Add(dr["N_RFLX"]);                             /*22*/
                            game.Add(dr["N_RFFS"]);                             /*23*/
                            game.Add(dr["N_RFBL"]);                             /*24*/
                            game.Add(dr["N_LRFPL"]);                            /*25*/
                            game.Add(dr["N_RRFPL"]);                            /*26*/
                            game.Add(dr["N_RF_OPEN"]);                          /*27*/
                            game.Add(dr["N_RF_LOCK_V"]);                        /*28*/
                            game.Add(dr["N_RF_LOCK_H"]);                        /*29*/
                            game.Add(dr["N_RF_GG"]);                            /*30*/
                            game.Add(dr["N_LRFCJ"]);                            /*31*/
                            game.Add(dr["N_RRFCJ"]);                            /*32*/
                            //大小
                            game.Add(dr["N_DXLX"]);                             /*33*/
                            game.Add(dr["N_DXFS"]);                             /*34*/
                            game.Add(dr["N_DXBL"]);                             /*35*/
                            game.Add(dr["N_DXDPL"]);                            /*36*/
                            game.Add(dr["N_DXXPL"]);                            /*37*/
                            game.Add(dr["N_DX_OPEN"]);                          /*38*/
                            game.Add(dr["N_DX_LOCK_V"]);                        /*39*/
                            game.Add(dr["N_DX_LOCK_H"]);                        /*40*/
                            game.Add(dr["N_DX_GG"]);                            /*41*/
                            game.Add(dr["N_DXDCJ"]);                            /*42*/
                            game.Add(dr["N_DXXCJ"]);                            /*43*/
                            //单双
                            game.Add(dr["N_DSDPL"]);                            /*44*/
                            game.Add(dr["N_DSSPL"]);                            /*45*/
                            game.Add(dr["N_DS_OPEN"]);                          /*46*/
                            game.Add(dr["N_DS_LOCK_V"]);                        /*47*/
                            game.Add(dr["N_DS_LOCK_H"]);                        /*48*/
                            game.Add(dr["N_DS_GG"]);                            /*49*/
                            game.Add(dr["N_DSDCJ"]);                            /*50*/
                            game.Add(dr["N_DSSCJ"]);                            /*51*/
                            //独赢
                            game.Add(dr["N_LDYPL"]);                            /*52*/
                            game.Add(dr["N_RDYPL"]);                            /*53*/
                            game.Add(dr["N_DY_OPEN"]);                          /*54*/
                            game.Add(dr["N_DY_LOCK_V"]);                        /*55*/
                            game.Add(dr["N_DY_LOCK_H"]);                        /*56*/
                            game.Add(dr["N_DY_GG"]);                            /*57*/
                            game.Add(dr["N_LDYCJ"]);                            /*58*/
                            game.Add(dr["N_RDYCJ"]);                            /*59*/

                            game.Add(dr["N_SAMETEAM"]);                         /*60*/
                            //一输二赢
                            game.Add(dr["N_LSYPL"]);                            /*61*/
                            game.Add(dr["N_RSYPL"]);                            /*62*/
                            game.Add(dr["N_SY_OPEN"]);                          /*63*/
                            game.Add(dr["N_SY_LOCK_V"]);                        /*64*/
                            game.Add(dr["N_SY_LOCK_H"]);                        /*64*/
                            game.Add(dr["N_SY_GG"]);                            /*66*/
                            game.Add(dr["N_LSYCJ"]);                            /*67*/
                            game.Add(dr["N_RSYCJ"]);                            /*68*/
                            gameList.Add(game);
                        }
                        break;
                        #endregion
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        recordCount = Convert.ToInt32(parameter[8].Value);
        listLM = templm;
        return gameList;
    }
    #endregion

    #region 方法二
    public enum OrderName
    {
        EMPTY = 2,
        N_GAMEDATE = 0,//开赛时间
        N_VISIT_NO = 1 //场次编号
    }
    /// <summary>
    /// 足球特殊玩法
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="ballType"></param>
    /// <param name="courtType"></param>
    /// <param name="playType"></param>
    /// <param name="teamDic"></param>
    /// <param name="alliance"></param>
    /// <returns></returns>
    private List<KFB_BALL> GetClientSpecialGameList(string ballType, int courtType, int playType, Dictionary<int, KFB_DWGL> teamDic, params string[] alliance)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar,2000),
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32,20),
                new OracleParameter("playtype",OracleType.Int32,1),
                //new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor)};
        parameter[0].Value = string.Join(",", alliance); ;
        parameter[1].Value = ballType;
        parameter[2].Value = courtType;
        parameter[3].Value = playType;//--玩法类型，1单式，2走地，0早餐，3过关,4波胆，5半全场，6入球数
        parameter[4].Direction = System.Data.ParameterDirection.Output;
        //parameter[5].Direction = System.Data.ParameterDirection.Output;
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_client_special_gamelist.sp_client_special_gamelist", parameter))
        {
            #region 赛事
            while (dr.Read())
            {
                KFB_BALL model = new KFB_BALL();
                model.N_LX = Convert.ToString(dr["n_lx"]);
                model.N_ID = Convert.ToInt32(dr["n_id"]);
                model.N_ZWDATE = Convert.ToDateTime(dr["n_zwdate"]);
                model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                model.N_LMNO = Convert.ToInt32(dr["n_lmno"]);
                model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                model.N_HOME = Convert.ToInt32(dr["n_home"]);
                model.N_VISIT_NAME = teamDic[model.N_VISIT.Value].N_DWMC;
                model.N_HOME_NAME = teamDic[model.N_HOME.Value].N_DWMC;
                model.N_CBXH = Convert.ToInt32(dr["N_CBXH"]);
                model.N_SAMEGAME = Convert.ToInt32(dr["N_SAMEGAME"]);
                model.N_SAMETEAM = Convert.ToString(dr["N_SAMETEAM"]);
                model.N_LET = Convert.ToInt32(dr["N_LET"]);
                model.N_SFXZ = Convert.ToInt32(dr["N_SFXZ"]);
                model.N_LOCK = Convert.ToInt32(dr["N_LOCK"]);
                model.N_ZBXH = Convert.ToInt32(dr["N_ZBXH"]);
                model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                model.N_VH = Convert.ToInt32(dr["N_VH"]);
                model.N_VISIT_JZF = Convert.ToInt32(dr["N_VISIT_JZF"]);
                model.N_HOME_JZF = Convert.ToDecimal(dr["N_HOME_JZF"]);
                model.N_ZDTIME = Convert.ToString(dr["N_ZDTIME"]);
                model.N_ZDFLAG = Convert.ToString(dr["N_ZDFLAG"]);
                model.N_ZDUPTIME = Convert.ToDateTime(dr["N_ZDUPTIME"]);
                //model.N_ZDUPTIME = Convert.ToDateTime(dr["SYSDATE"]);//lpad(to_char(nvl(T.N_ZDTIME, 0)+round((sysdate - T.N_ZDUPTIME) * 24 * 60, 0)),2,''0'') as N_ZDUPTIME
                model.N_REMARK = Convert.ToString(dr["N_REMARK"]);

                model.N_BD_OPEN = Convert.ToInt32(dr["N_BD_OPEN"]);
                model.N_BDGPL00 = Convert.ToDecimal(dr["N_BDGPL00"]);
                model.N_BDGPL11 = Convert.ToDecimal(dr["N_BDGPL11"]);
                model.N_BDGPL22 = Convert.ToDecimal(dr["N_BDGPL22"]);
                model.N_BDGPL33 = Convert.ToDecimal(dr["N_BDGPL33"]);
                model.N_BDGPL44 = Convert.ToDecimal(dr["N_BDGPL44"]);
                model.N_BDKPL10 = Convert.ToDecimal(dr["N_BDKPL10"]);
                model.N_BDKPL20 = Convert.ToDecimal(dr["N_BDKPL20"]);
                model.N_BDKPL21 = Convert.ToDecimal(dr["N_BDKPL21"]);
                model.N_BDKPL30 = Convert.ToDecimal(dr["N_BDKPL30"]);
                model.N_BDKPL31 = Convert.ToDecimal(dr["N_BDKPL31"]);
                model.N_BDKPL32 = Convert.ToDecimal(dr["N_BDKPL32"]);
                model.N_BDKPL40 = Convert.ToDecimal(dr["N_BDKPL40"]);
                model.N_BDKPL41 = Convert.ToDecimal(dr["N_BDKPL41"]);
                model.N_BDKPL42 = Convert.ToDecimal(dr["N_BDKPL42"]);
                model.N_BDKPL43 = Convert.ToDecimal(dr["N_BDKPL43"]);
                model.N_BDKPL5 = Convert.ToDecimal(dr["N_BDKPL5"]);
                model.N_BDZPL10 = Convert.ToDecimal(dr["N_BDZPL10"]);
                model.N_BDZPL20 = Convert.ToDecimal(dr["N_BDZPL20"]);
                model.N_BDZPL21 = Convert.ToDecimal(dr["N_BDZPL21"]);
                model.N_BDZPL30 = Convert.ToDecimal(dr["N_BDZPL30"]);
                model.N_BDZPL31 = Convert.ToDecimal(dr["N_BDZPL31"]);
                model.N_BDZPL32 = Convert.ToDecimal(dr["N_BDZPL32"]);
                model.N_BDZPL40 = Convert.ToDecimal(dr["N_BDZPL40"]);
                model.N_BDZPL41 = Convert.ToDecimal(dr["N_BDZPL41"]);
                model.N_BDZPL42 = Convert.ToDecimal(dr["N_BDZPL42"]);
                model.N_BDZPL43 = Convert.ToDecimal(dr["N_BDZPL43"]);
                model.N_BDZPL5 = Convert.ToDecimal(dr["N_BDZPL5"]);

                model.N_BQC_OPEN = Convert.ToInt32(dr["N_BQC_OPEN"]);
                model.N_BQCHH = Convert.ToDecimal(dr["N_BQCHH"]);
                model.N_BQCHK = Convert.ToDecimal(dr["N_BQCHK"]);
                model.N_BQCHZ = Convert.ToDecimal(dr["N_BQCHZ"]);
                model.N_BQCKH = Convert.ToDecimal(dr["N_BQCKH"]);
                model.N_BQCKK = Convert.ToDecimal(dr["N_BQCKK"]);
                model.N_BQCKZ = Convert.ToDecimal(dr["N_BQCKZ"]);
                model.N_BQCZH = Convert.ToDecimal(dr["N_BQCZH"]);
                model.N_BQCZK = Convert.ToDecimal(dr["N_BQCZK"]);
                model.N_BQCZZ = Convert.ToDecimal(dr["N_BQCZZ"]);

                model.N_RQ_OPEN = Convert.ToInt32(dr["N_RQ_OPEN"]);
                model.N_RQSPL01 = Convert.ToDecimal(dr["N_RQSPL01"]);
                model.N_RQSPL23 = Convert.ToDecimal(dr["N_RQSPL23"]);
                model.N_RQSPL46 = Convert.ToDecimal(dr["N_RQSPL46"]);
                model.N_RQSPL7 = Convert.ToDecimal(dr["N_RQSPL7"]);
                model.N_DSDPL = Convert.ToDecimal(dr["N_DSDPL"]);
                model.N_DSSPL = Convert.ToDecimal(dr["N_DSSPL"]);
                gameList.Add(model);
            }
            #endregion
        }
        return gameList;
    }
    /// <summary>
    /// 1单式，2走地，0早餐，3过关, 4波胆，5半全场，6入球数
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="ballType"></param>
    /// <param name="courtType"></param>
    /// <param name="playType"></param>
    /// <param name="teamDic"></param>
    /// <param name="alliance"></param>
    /// <returns></returns>
    private List<KFB_BALL> GetClientAllGameList(string ballType, int courtType, int playType, Dictionary<int, KFB_DWGL> teamDic, params string[] alliance)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar,2000),
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32,20),
                new OracleParameter("playtype",OracleType.Int32,1),
                new OracleParameter("t_gamelist", OracleType.Cursor)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = ballType;
        parameter[2].Value = courtType;
        parameter[3].Value = playType;//--玩法类型，1单式，2走地，0早餐，3过关, 4波胆，5半全场，6入球数
        parameter[4].Direction = System.Data.ParameterDirection.Output;
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_client_allball_gamelist.sp_client_allball_gamelist", parameter))
        {
            #region 赛事
            while (dr.Read())
            {
                KFB_BALL model;
                if (ballType == "b_zq" && playType != 3)
                {
                    if (dr["N_CBXH"].Equals(2M))//足球上半场
                    {
                        model = gameList.Find(delegate(KFB_BALL fullModel)
                        {
                            return fullModel.N_SAMEGAME == Convert.ToInt32(dr["N_SAMEGAME"]) && fullModel.N_CBXH.Value == 1;// && Convert.ToInt32(dr["N_CBXH"]) == 2;
                        });
                        if (model == null)
                        {
                            model = new KFB_BALL();
                            model.N_LX = Convert.ToString(dr["n_lx"]);
                            model.N_ZWDATE = Convert.ToDateTime(dr["n_zwdate"]);
                            model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                            model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                            model.N_HOME = Convert.ToInt32(dr["n_home"]);
                            model.N_VISIT_NAME = teamDic[model.N_VISIT.Value].N_DWMC;
                            model.N_HOME_NAME = teamDic[model.N_HOME.Value].N_DWMC;
                            model.N_SAMEGAME = Convert.ToInt32(dr["N_SAMEGAME"]);
                            model.N_SAMETEAM = Convert.ToString(dr["N_SAMETEAM"]);
                            model.N_SFXZ = Convert.ToInt32(dr["N_SFXZ"]);
                            model.N_LOCK = Convert.ToInt32(dr["N_LOCK"]);
                            model.N_ZBXH = Convert.ToInt32(dr["N_ZBXH"]);
                            model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                            model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                            model.N_VH = Convert.ToInt32(dr["N_VH"]);
                            model.N_VISIT_JZF = Convert.ToInt32(dr["N_VISIT_JZF"]);
                            model.N_HOME_JZF = Convert.ToDecimal(dr["N_HOME_JZF"]);
                            model.N_ZDTIME = Convert.ToString(dr["N_ZDTIME"]);
                            model.N_ZDFLAG = Convert.ToString(dr["N_ZDFLAG"]);
                            model.N_ZDUPTIME = Convert.ToDateTime(dr["N_ZDUPTIME"]);
                            model.N_REMARK = Convert.ToString(dr["N_REMARK"]);
                            model.N_VISIT_REDCARD = Convert.ToInt32(dr["N_VISIT_REDCARD"]);
                            model.N_HOME_REDCARD = Convert.ToInt32(dr["N_HOME_REDCARD"]);
                        }

                        model.N_ID2 = Convert.ToInt32(dr["N_ID"]);
                        model.N_LET2 = Convert.ToInt32(dr["N_LET"]);
                        model.N_CBXH2 = Convert.ToInt32(dr["N_CBXH"]);
                        model.N_HJPL2 = Convert.ToDecimal(dr["N_HJPL"]);

                        model.N_LMNO2 = Convert.ToInt32(dr["n_lmno"]);
                        model.N_VISIT2 = Convert.ToInt32(dr["n_visit"]);
                        model.N_HOME2 = Convert.ToInt32(dr["n_home"]);

                        model.N_RFLX2 = Convert.ToInt32(dr["N_RFLX"]);
                        model.N_RFFS2 = Convert.ToDecimal(dr["N_RFFS"]);
                        model.N_RFBL2 = Convert.ToInt32(dr["N_RFBL"]);
                        model.N_LRFPL2 = Convert.ToDecimal(dr["N_LRFPL"]);
                        model.N_RRFPL2 = Convert.ToDecimal(dr["N_RRFPL"]);
                        model.N_RF_OPEN2 = Convert.ToInt32(dr["N_RF_OPEN"]);
                        model.N_RF_LOCK_V2 = Convert.ToInt32(dr["N_RF_LOCK_V"]);
                        model.N_RF_LOCK_H2 = Convert.ToInt32(dr["N_RF_LOCK_H"]);

                        model.N_DXLX2 = Convert.ToInt32(dr["N_DXLX"]);
                        model.N_DXFS2 = Convert.ToDecimal(dr["N_DXFS"]);
                        model.N_DXBL2 = Convert.ToInt32(dr["N_DXBL"]);
                        model.N_DXDPL2 = Convert.ToDecimal(dr["N_DXDPL"]);
                        model.N_DXXPL2 = Convert.ToDecimal(dr["N_DXXPL"]);
                        model.N_DX_OPEN2 = Convert.ToInt32(dr["N_DX_OPEN"]);
                        model.N_DX_LOCK_V2 = Convert.ToInt32(dr["N_DX_LOCK_V"]);
                        model.N_DX_LOCK_H2 = Convert.ToInt32(dr["N_DX_LOCK_H"]);

                        model.N_DSDPL2 = Convert.ToDecimal(dr["N_DSDPL"]);
                        model.N_DSSPL2 = Convert.ToDecimal(dr["N_DSSPL"]);
                        model.N_DS_OPEN2 = Convert.ToInt32(dr["N_DS_OPEN"]);
                        model.N_DS_LOCK_V2 = Convert.ToInt32(dr["N_DS_LOCK_V"]);
                        model.N_DS_LOCK_H2 = Convert.ToInt32(dr["N_DS_LOCK_H"]);

                        model.N_LDYPL2 = Convert.ToDecimal(dr["N_LDYPL"]);
                        model.N_RDYPL2 = Convert.ToDecimal(dr["N_RDYPL"]);
                        model.N_DY_OPEN2 = Convert.ToInt32(dr["N_DY_OPEN"]);
                        model.N_DY_LOCK_V2 = Convert.ToInt32(dr["N_DY_LOCK_V"]);
                        model.N_DY_LOCK_H2 = Convert.ToInt32(dr["N_DY_LOCK_H"]);

                        model.N_LSYPL2 = Convert.ToDecimal(dr["N_LSYPL"]);
                        model.N_RSYPL2 = Convert.ToDecimal(dr["N_RSYPL"]);
                        model.N_SY_OPEN2 = Convert.ToInt32(dr["N_SY_OPEN"]);
                        model.N_SY_LOCK_V2 = Convert.ToInt32(dr["N_SY_LOCK_V"]);
                        model.N_SY_LOCK_H2 = Convert.ToInt32(dr["N_SY_LOCK_H"]);
                        continue;
                    }
                }
                model = new KFB_BALL();
                model.N_LX = Convert.ToString(dr["n_lx"]);
                model.N_ID = Convert.ToInt32(dr["n_id"]);
                model.N_ZWDATE = Convert.ToDateTime(dr["n_zwdate"]);
                model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                model.N_LMNO = Convert.ToInt32(dr["n_lmno"]);
                model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                model.N_HOME = Convert.ToInt32(dr["n_home"]);
                model.N_VISIT_NAME = teamDic[model.N_VISIT.Value].N_DWMC;
                model.N_HOME_NAME = teamDic[model.N_HOME.Value].N_DWMC;
                model.N_CBXH = Convert.ToInt32(dr["N_CBXH"]);
                model.N_SAMEGAME = Convert.ToInt32(dr["N_SAMEGAME"]);
                model.N_SAMETEAM = Convert.ToString(dr["N_SAMETEAM"]);
                model.N_LET = Convert.ToInt32(dr["N_LET"]);
                model.N_SFXZ = Convert.ToInt32(dr["N_SFXZ"]);
                model.N_LOCK = Convert.ToInt32(dr["N_LOCK"]);
                model.N_ZBXH = Convert.ToInt32(dr["N_ZBXH"]);
                model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                model.N_VH = Convert.ToInt32(dr["N_VH"]);
                model.N_VISIT_JZF = Convert.ToInt32(dr["N_VISIT_JZF"]);
                model.N_HOME_JZF = Convert.ToDecimal(dr["N_HOME_JZF"]);
                model.N_ZDTIME = Convert.ToString(dr["N_ZDTIME"]);
                model.N_ZDFLAG = Convert.ToString(dr["N_ZDFLAG"]);
                model.N_ZDUPTIME = Convert.ToDateTime(dr["N_ZDUPTIME"]);
                //model.N_ZDUPTIME = Convert.ToDateTime(dr["SYSDATE"]);//lpad(to_char(nvl(T.N_ZDTIME, 0)+round((sysdate - T.N_ZDUPTIME) * 24 * 60, 0)),2,''0'') as N_ZDUPTIME
                model.N_REMARK = Convert.ToString(dr["N_REMARK"]);
                model.N_HJPL = Convert.ToDecimal(dr["N_HJPL"]);
                model.N_HJGGCJ = Convert.ToDecimal(dr["N_HJGGCJ"]);
                model.N_VISIT_REDCARD = Convert.ToInt32(dr["N_VISIT_REDCARD"]);
                model.N_HOME_REDCARD = Convert.ToInt32(dr["N_HOME_REDCARD"]);

                model.N_RFLX = Convert.ToInt32(dr["N_RFLX"]);
                model.N_RFFS = Convert.ToDecimal(dr["N_RFFS"]);
                model.N_RFBL = Convert.ToInt32(dr["N_RFBL"]);
                model.N_LRFPL = Convert.ToDecimal(dr["N_LRFPL"]);
                model.N_RRFPL = Convert.ToDecimal(dr["N_RRFPL"]);
                model.N_RF_OPEN = Convert.ToInt32(dr["N_RF_OPEN"]);
                model.N_RF_LOCK_V = Convert.ToInt32(dr["N_RF_LOCK_V"]);
                model.N_RF_LOCK_H = Convert.ToInt32(dr["N_RF_LOCK_H"]);
                model.N_RF_GG = Convert.ToInt32(dr["N_RF_GG"]);
                model.N_LRFCJ = Convert.ToDecimal(dr["N_LRFCJ"]);
                model.N_RRFCJ = Convert.ToDecimal(dr["N_RRFCJ"]);
                model.N_DXLX = Convert.ToInt32(dr["N_DXLX"]);
                model.N_DXFS = Convert.ToDecimal(dr["N_DXFS"]);
                model.N_DXBL = Convert.ToInt32(dr["N_DXBL"]);
                model.N_DXDPL = Convert.ToDecimal(dr["N_DXDPL"]);
                model.N_DXXPL = Convert.ToDecimal(dr["N_DXXPL"]);
                model.N_DX_OPEN = Convert.ToInt32(dr["N_DX_OPEN"]);
                model.N_DX_LOCK_V = Convert.ToInt32(dr["N_DX_LOCK_V"]);
                model.N_DX_LOCK_H = Convert.ToInt32(dr["N_DX_LOCK_H"]);
                model.N_DX_GG = Convert.ToInt32(dr["N_DX_GG"]);
                model.N_DXDCJ = Convert.ToDecimal(dr["N_DXDCJ"]);
                model.N_DXXCJ = Convert.ToDecimal(dr["N_DXXCJ"]);
                model.N_DSDPL = Convert.ToDecimal(dr["N_DSDPL"]);
                model.N_DSSPL = Convert.ToDecimal(dr["N_DSSPL"]);
                model.N_DS_OPEN = Convert.ToInt32(dr["N_DS_OPEN"]);
                model.N_DS_LOCK_V = Convert.ToInt32(dr["N_DS_LOCK_V"]);
                model.N_DS_LOCK_H = Convert.ToInt32(dr["N_DS_LOCK_H"]);
                model.N_DS_GG = Convert.ToInt32(dr["N_DS_GG"]);
                model.N_DSDCJ = Convert.ToDecimal(dr["N_DSDCJ"]);
                model.N_DSSCJ = Convert.ToDecimal(dr["N_DSSCJ"]);
                model.N_LDYPL = Convert.ToDecimal(dr["N_LDYPL"]);
                model.N_RDYPL = Convert.ToDecimal(dr["N_RDYPL"]);
                model.N_DY_OPEN = Convert.ToInt32(dr["N_DY_OPEN"]);
                model.N_DY_LOCK_V = Convert.ToInt32(dr["N_DY_LOCK_V"]);
                model.N_DY_LOCK_H = Convert.ToInt32(dr["N_DY_LOCK_H"]);
                model.N_DY_GG = Convert.ToInt32(dr["N_DY_GG"]);
                model.N_LDYCJ = Convert.ToDecimal(dr["N_LDYCJ"]);
                model.N_RDYCJ = Convert.ToDecimal(dr["N_RDYCJ"]);
                model.N_LSYPL = Convert.ToDecimal(dr["N_LSYPL"]);
                model.N_RSYPL = Convert.ToDecimal(dr["N_RSYPL"]);
                model.N_SY_OPEN = Convert.ToInt32(dr["N_SY_OPEN"]);
                model.N_SY_LOCK_V = Convert.ToInt32(dr["N_SY_LOCK_V"]);
                model.N_SY_LOCK_H = Convert.ToInt32(dr["N_SY_LOCK_H"]);
                model.N_SY_GG = Convert.ToInt32(dr["N_SY_GG"]);
                model.N_LSYCJ = Convert.ToDecimal(dr["N_LSYCJ"]);
                model.N_RSYCJ = Convert.ToDecimal(dr["N_RSYCJ"]);
                model.N_SFZD = Convert.ToInt32(dr["N_SFZD"]);
                gameList.Add(model);
            }
            #endregion
        }
        return gameList;
    }
    /// <summary>
    /// 查询联盟
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="playType"></param>
    /// <param name="ballType"></param>
    /// <param name="courtType"></param>
    /// <param name="userId"></param>
    /// <param name="rateGap"></param>
    /// <param name="teamDic"></param>
    /// <returns></returns>
    private List<KFB_LMGL> GetClientAllianceList(int playType, string ballType, int courtType, string userId, out decimal rateGap, out Dictionary<int, KFB_DWGL> teamDic)
    {
        List<KFB_LMGL> modelList = new List<KFB_LMGL>();
        OracleParameter[] parameter = { 
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32,1),
                new OracleParameter("playtype",OracleType.Int32,1),
                new OracleParameter("userid",OracleType.VarChar,50),
                new OracleParameter("t_alliancelist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("rategap", OracleType.Number)};
        parameter[0].Value = ballType;
        parameter[1].Value = courtType;
        parameter[2].Value = playType;
        parameter[3].Value = userId;
        parameter[4].Direction = System.Data.ParameterDirection.Output;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;

        teamDic = new Dictionary<int, KFB_DWGL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_client_alliancelist.sp_client_alliancelist", parameter))
        {
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://队伍列表
                        while (dr.Read())
                        {
                            KFB_LMGL model = new KFB_LMGL();
                            model.N_NO = dr.GetInt32(0);
                            model.N_LMMC = dr.GetString(1);
                            modelList.Add(model);
                        }
                        break;
                    case 1://联盟列表
                        while (dr.Read())
                        {
                            KFB_DWGL model = new KFB_DWGL();
                            model.N_ID = dr.GetInt32(0);
                            model.N_DWMC = dr.GetString(1);
                            teamDic.Add(model.N_ID, model);
                        }
                        break;
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        rateGap = Convert.ToDecimal(parameter[6].Value);
        return modelList;
    }
    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="gameList"></param>
    /// <param name="OrderID"></param>
    private void Sort(List<KFB_BALL> gameList, int OrderID)
    {
        string OrderName = ((OrderName)OrderID).ToString();
        int result = 0;
        System.Collections.CaseInsensitiveComparer compare = new System.Collections.CaseInsensitiveComparer();
        gameList.Sort(delegate(KFB_BALL model1, KFB_BALL model2)
       {
           object obj1 = null;
           object obj2 = null;
           if ((result = model1.N_CBXH.Value.CompareTo(model2.N_CBXH.Value)) != 0)
           {
               return result;
           }
           else if (!OrderName.Equals("EMPTY"))
           {
               obj1 = model1.GetType().InvokeMember(OrderName, System.Reflection.BindingFlags.GetProperty, null, model1, null);
               obj2 = model2.GetType().InvokeMember(OrderName, System.Reflection.BindingFlags.GetProperty, null, model2, null);
           }
           if ((result = compare.Compare(obj1, obj2)) != 0)
           {
               return result;
           }
           else if ((result = model1.N_GAMEDATE.Value.CompareTo(model2.N_GAMEDATE.Value)) != 0)
           {
               return result;
           }
           else if ((result = model1.N_LMNO.Value.CompareTo(model2.N_LMNO.Value)) != 0)
           {
               return result;
           }
           else if ((result = model1.N_CBXH.Value.CompareTo(model2.N_CBXH.Value)) != 0)
           {
               return result;
           }
           else if ((result = model1.N_ID.CompareTo(model2.N_ID)) != 0)
           {
               return result;
           }
           else
           {
               return 0;
           }
       });
    }
    /// <summary>
    /// 查询数据
    /// </summary>
    /// <param name="ballType">球类型 足球 篮球 棒球</param>
    /// <param name="selectedAllianceList">选择的联盟</param>
    /// <param name="courtType">场别</param>
    /// <param name="OrderName">排序方式</param>
    /// <param name="userId">用户id</param>
    /// <param name="playType">玩法类型，1单式，2走地，0早餐，3过关,4波胆，5半全场，6入球数 </param>
    /// <param name="pageIndex">查询第几页数据</param>
    /// <param name="pageSize">每页显示多少</param>
    /// <param name="recordCount">总笔数</param>
    /// <param name="allianceModelList">返回所有联盟</param>
    /// <param name="rateGap">abc盘差距</param>
    /// <returns></returns>
    public List<KFB_BALL> GetClientGameList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out decimal rateGap)
    {
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        AutoResetEvent[] waitEvents = null;//new AutoResetEvent[selectedAllianceList.Count];
        try
        {
            List<List<int>> allianceGroup = new List<List<int>>();
            Dictionary<int, KFB_DWGL> teamDic = null;
            allianceModelList = GetClientAllianceList(playType, ballType, courtType, userId, out rateGap, out teamDic);
            //if (selectedAllianceList.Count == 0)//查询全部联盟
            //{
            //    //waitEvents = new AutoResetEvent[allianceModelList.Count];
            //    foreach (KFB_LMGL model in allianceModelList)
            //    {
            //        selectedAllianceList.Add(model.N_NO);
            //    }
            //}
            if (COUNT_THREAD == 0)
            {
                #region 单线程查询
                if (playType >= 4)
                {
                    gameList = GetClientSpecialGameList(ballType, courtType, playType, teamDic,
                        selectedAllianceList.ConvertAll<string>(delegate(int index)
                    {
                        return index.ToString();
                    }).ToArray());//波胆，入球数，半全场特殊玩法
                }
                else
                {
                    gameList = GetClientAllGameList(ballType, courtType, playType, teamDic,
                        selectedAllianceList.ConvertAll<string>(delegate(int index)
                    {
                        return index.ToString();
                    }).ToArray());
                }
                #endregion
            }
            else
            {
                #region 多线程查询
                if (selectedAllianceList.Count > COUNT_THREAD)//大于设定线程数
                {
                    int length = Convert.ToInt32(Math.Ceiling(selectedAllianceList.Count / Convert.ToDouble(COUNT_THREAD)));
                    int len = length;
                    for (int i = 1; i <= COUNT_THREAD; i++)
                    {
                        int index = (i - 1) * length;
                        if (i * length > selectedAllianceList.Count)
                        {
                            len = length - (i * length - selectedAllianceList.Count);
                        }
                        if (len > 0)
                        {
                            allianceGroup.Add(selectedAllianceList.GetRange(index, len));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= selectedAllianceList.Count; i++)
                    {
                        allianceGroup.Add(selectedAllianceList.GetRange(i - 1, 1));
                    }
                }
                waitEvents = new AutoResetEvent[allianceGroup.Count];
                for (int i = 0; i < allianceGroup.Count; i++)
                {
                    waitEvents[i] = new AutoResetEvent(false);
                    Thread thread = new Thread(new ParameterizedThreadStart(delegate(object j)
                    {
                        int k = Convert.ToInt32(j);
                        try
                        {
                            List<KFB_BALL> ballList = null;
                            if (playType >= 4)
                            {
                                ballList = GetClientSpecialGameList(ballType, courtType, playType, teamDic,
                                    allianceGroup[k].ConvertAll<string>(delegate(int index)
                                {
                                    return index.ToString();
                                }).ToArray());
                                lock (gameList)
                                {
                                    gameList.AddRange(ballList);//波胆，入球数，半全场特殊玩法
                                }
                            }
                            else
                            {
                                ballList = GetClientAllGameList(ballType, courtType, playType, teamDic,
                                    allianceGroup[k].ConvertAll<string>(delegate(int index)
                                {
                                    return index.ToString();
                                }).ToArray());
                                lock (gameList)
                                {
                                    gameList.AddRange(ballList);
                                }
                            }
                        }
                        //catch (Exception ex)
                        //{
                        //    Console.Write(ex.Message);
                        //    Console.ReadLine();
                        //}
                        finally
                        {
                            if (waitEvents[k] != null)
                            {
                                waitEvents[k].Set();
                            }
                        }
                    }));
                    thread.Start(i);
                }

                //if (waitEvents.Length > 0)
                //{
                //    int countThread = Convert.ToInt32(Math.Ceiling(waitEvents.Length / 64.0));
                //    List<AutoResetEvent> events = new List<AutoResetEvent>(waitEvents);
                //    for (int i = 1; i <= countThread; i++)
                //    {
                //        int length = 64;
                //        if (i * 64 > waitEvents.Length)
                //        {
                //            length = 64 - (i * 64 - waitEvents.Length);
                //        }
                //        int index = (i - 1) * 64;
                //        WaitHandle.WaitAll(events.GetRange(index, length).ToArray());
                //    }
                //}

                if (waitEvents.Length > 0)
                {
                    WaitHandle.WaitAll(waitEvents);
                }
                #endregion
            }
        }
        finally
        {
            if (waitEvents != null)
            {
                for (int i = 0; i < waitEvents.Length; i++)
                {
                    if (waitEvents[i] != null)
                    {
                        waitEvents[i].Close();
                    }
                    waitEvents[i] = null;
                }
                waitEvents = null;
            }
        }
        //排序
        int orderId = 0;
        int.TryParse(OrderName, out orderId);
        Sort(gameList, orderId);
        recordCount = gameList.Count;
        int count = pageSize;
        if (pageIndex * pageSize > recordCount)
        {
            count = pageSize - (pageIndex * pageSize - recordCount);
        }
        int start = (pageIndex - 1) * pageSize;
        return gameList.GetRange(start, count);//分页
    }
    /// <summary>
    /// 比赛结果
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="alliance"></param>
    /// <param name="accDate"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <param name="sysAccDate"></param>
    /// <returns></returns>
    public List<KFB_BALL> GetClientResultList(string ballType, string[] alliance, string accDate, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string sysAccDate)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar),
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_accdate",OracleType.VarChar,12),
                new OracleParameter("pageIndex",OracleType.Int32),
                new OracleParameter("pageSize",OracleType.Int32),
                new OracleParameter("t_lmlist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor),
                new OracleParameter("recordCount", OracleType.Int32),
                new OracleParameter("accdate",OracleType.VarChar,12)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = ballType;
        parameter[2].Value = accDate;
        parameter[3].Value = pageIndex;
        parameter[4].Value = pageSize;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        parameter[8].Direction = System.Data.ParameterDirection.Output;
        parameter[9].Direction = System.Data.ParameterDirection.Output;
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_client_resultlist.sp_client_resultlist", parameter))
        {
            allianceModelList = new List<KFB_LMGL>();
            Dictionary<int, string> teamDic = new Dictionary<int, string>();
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://队伍列表
                        while (dr.Read())
                        {
                            KFB_LMGL lmModel = new KFB_LMGL();
                            lmModel.N_NO = dr.GetInt32(0);
                            lmModel.N_LMMC = dr.GetString(1);
                            allianceModelList.Add(lmModel);
                        }
                        break;
                    case 1://队伍列表
                        while (dr.Read())
                        {
                            teamDic.Add(dr.GetInt32(0), dr.GetString(1));
                        }
                        break;
                    case 2://赛事列表
                        #region 赛事
                        while (dr.Read())
                        {
                            KFB_BALL model = new KFB_BALL();
                            model.N_LX = Convert.ToString(dr["n_lx"]);
                            model.N_ID = 0;// Convert.ToInt32(dr["n_id"]);
                            model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                            model.N_LMNO = Convert.ToInt32(dr["n_lmno"]);
                            model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                            model.N_HOME = Convert.ToInt32(dr["n_home"]);
                            model.N_VISIT_NAME = teamDic[model.N_VISIT.Value];
                            model.N_HOME_NAME = teamDic[model.N_HOME.Value];
                            model.N_CBXH = Convert.ToInt32(dr["N_CBXH"]);
                            model.N_SAMEGAME = 0;// Convert.ToInt32(dr["N_SAMEGAME"]);
                            model.N_LET = Convert.ToInt32(dr["N_LET"]);
                            model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                            model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                            model.N_VH = Convert.ToInt32(dr["N_VH"]);
                            model.N_VISIT_RESULT = Convert.ToDecimal(dr["N_VISIT_RESULT"]);
                            model.N_HOME_RESULT = Convert.ToDecimal(dr["N_HOME_RESULT"]);
                            model.N_UP_VISIT_RESULT = Convert.ToDecimal(dr["N_UP_VISIT_RESULT"]);
                            model.N_UP_HOME_RESULT = Convert.ToDecimal(dr["N_UP_HOME_RESULT"]);
                            model.N_REMARK = Convert.ToString(dr["N_REMARK"]);

                            gameList.Add(model);
                        }
                        break;
                        #endregion
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        recordCount = Convert.ToInt32(parameter[8].Value);
        sysAccDate = Convert.ToString(parameter[9].Value);
        return gameList;
    }

    #endregion
    #endregion

    #region 管理端
    /// <summary>
    /// 足球特殊玩法
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="ballType"></param>
    /// <param name="courtType"></param>
    /// <param name="playType"></param>
    /// <param name="teamDic"></param>
    /// <param name="alliance"></param>
    /// <returns></returns>
    private List<KFB_BALL> GetCompanySpecialGameList(string ballType, int courtType, int playType, int isbet, string zwDate, Dictionary<int, KFB_DWGL> teamDic, ref Dictionary<string, string> billDic, params string[] alliance)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_lmno",OracleType.VarChar,2000),
                new OracleParameter("p_sfxz",OracleType.Int32,1),
                new OracleParameter("playtype",OracleType.Int32,1),
                new OracleParameter("t_billlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor)};
        parameter[0].Value = ballType;
        parameter[1].Value = string.Join(",", alliance);
        parameter[2].Value = isbet;
        parameter[3].Value = playType;//玩法类型，4波胆，5半全场，6入球数
        parameter[4].Direction = System.Data.ParameterDirection.Output;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_company_special_gamelist.sp_company_special_gamelist", parameter))
        {
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0:
                        #region 注单
                        while (dr.Read())
                        {
                            string key = dr["N_QSBH"].ToString() + "|" + dr["N_BSDW"].ToString() + "|" + dr["N_XZWF"].ToString().ToUpper();
                            string value = dr["BILLCOUNT"].ToString() + "/" + Convert.ToString(int.Parse(dr["BETSUM"].ToString()) / 1000);
                            if (dr["N_WXDJ"].ToString() != "0")
                                value += "/" + dr["N_WXDJ"].ToString();
                            billDic.Add(key, value);

                        }
                        #endregion
                        break;
                    case 1:
                        #region 赛事
                        while (dr.Read())
                        {
                            KFB_BALL model = new KFB_BALL();
                            model.N_LX = Convert.ToString(dr["n_lx"]);
                            model.N_ID = Convert.ToInt32(dr["n_id"]);
                            model.N_ZWDATE = Convert.ToDateTime(dr["n_zwdate"]);
                            model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                            model.N_LMNO = Convert.ToInt32(dr["n_lmno"]);
                            model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                            model.N_HOME = Convert.ToInt32(dr["n_home"]);
                            model.N_VISIT_NAME = teamDic[model.N_VISIT.Value].N_DWMC;
                            model.N_HOME_NAME = teamDic[model.N_HOME.Value].N_DWMC;
                            model.N_CBXH = Convert.ToInt32(dr["N_CBXH"]);
                            model.N_SAMEGAME = Convert.ToInt32(dr["N_SAMEGAME"]);
                            model.N_SAMETEAM = Convert.ToString(dr["N_SAMETEAM"]);
                            model.N_LET = Convert.ToInt32(dr["N_LET"]);
                            model.N_SFXZ = Convert.ToInt32(dr["N_SFXZ"]);
                            model.N_LOCK = Convert.ToInt32(dr["N_LOCK"]);
                            model.N_ZBXH = Convert.ToInt32(dr["N_ZBXH"]);
                            model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                            model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                            model.N_VH = Convert.ToInt32(dr["N_VH"]);
                            model.N_VISIT_JZF = Convert.ToInt32(dr["N_VISIT_JZF"]);
                            model.N_HOME_JZF = Convert.ToDecimal(dr["N_HOME_JZF"]);
                            model.N_ZDTIME = Convert.ToString(dr["N_ZDTIME"]);
                            model.N_ZDFLAG = Convert.ToString(dr["N_ZDFLAG"]);
                            model.N_ZDUPTIME = Convert.ToDateTime(dr["N_ZDUPTIME"]);
                            model.N_REMARK = Convert.ToString(dr["N_REMARK"]);

                            model.N_BD_OPEN = Convert.ToInt32(dr["N_BD_OPEN"]);
                            model.N_BDGPL00 = Convert.ToDecimal(dr["N_BDGPL00"]);
                            model.N_BDGPL11 = Convert.ToDecimal(dr["N_BDGPL11"]);
                            model.N_BDGPL22 = Convert.ToDecimal(dr["N_BDGPL22"]);
                            model.N_BDGPL33 = Convert.ToDecimal(dr["N_BDGPL33"]);
                            model.N_BDGPL44 = Convert.ToDecimal(dr["N_BDGPL44"]);
                            model.N_BDKPL10 = Convert.ToDecimal(dr["N_BDKPL10"]);
                            model.N_BDKPL20 = Convert.ToDecimal(dr["N_BDKPL20"]);
                            model.N_BDKPL21 = Convert.ToDecimal(dr["N_BDKPL21"]);
                            model.N_BDKPL30 = Convert.ToDecimal(dr["N_BDKPL30"]);
                            model.N_BDKPL31 = Convert.ToDecimal(dr["N_BDKPL31"]);
                            model.N_BDKPL32 = Convert.ToDecimal(dr["N_BDKPL32"]);
                            model.N_BDKPL40 = Convert.ToDecimal(dr["N_BDKPL40"]);
                            model.N_BDKPL41 = Convert.ToDecimal(dr["N_BDKPL41"]);
                            model.N_BDKPL42 = Convert.ToDecimal(dr["N_BDKPL42"]);
                            model.N_BDKPL43 = Convert.ToDecimal(dr["N_BDKPL43"]);
                            model.N_BDKPL5 = Convert.ToDecimal(dr["N_BDKPL5"]);
                            model.N_BDZPL10 = Convert.ToDecimal(dr["N_BDZPL10"]);
                            model.N_BDZPL20 = Convert.ToDecimal(dr["N_BDZPL20"]);
                            model.N_BDZPL21 = Convert.ToDecimal(dr["N_BDZPL21"]);
                            model.N_BDZPL30 = Convert.ToDecimal(dr["N_BDZPL30"]);
                            model.N_BDZPL31 = Convert.ToDecimal(dr["N_BDZPL31"]);
                            model.N_BDZPL32 = Convert.ToDecimal(dr["N_BDZPL32"]);
                            model.N_BDZPL40 = Convert.ToDecimal(dr["N_BDZPL40"]);
                            model.N_BDZPL41 = Convert.ToDecimal(dr["N_BDZPL41"]);
                            model.N_BDZPL42 = Convert.ToDecimal(dr["N_BDZPL42"]);
                            model.N_BDZPL43 = Convert.ToDecimal(dr["N_BDZPL43"]);
                            model.N_BDZPL5 = Convert.ToDecimal(dr["N_BDZPL5"]);

                            model.N_BQC_OPEN = Convert.ToInt32(dr["N_BQC_OPEN"]);
                            model.N_BQCHH = Convert.ToDecimal(dr["N_BQCHH"]);
                            model.N_BQCHK = Convert.ToDecimal(dr["N_BQCHK"]);
                            model.N_BQCHZ = Convert.ToDecimal(dr["N_BQCHZ"]);
                            model.N_BQCKH = Convert.ToDecimal(dr["N_BQCKH"]);
                            model.N_BQCKK = Convert.ToDecimal(dr["N_BQCKK"]);
                            model.N_BQCKZ = Convert.ToDecimal(dr["N_BQCKZ"]);
                            model.N_BQCZH = Convert.ToDecimal(dr["N_BQCZH"]);
                            model.N_BQCZK = Convert.ToDecimal(dr["N_BQCZK"]);
                            model.N_BQCZZ = Convert.ToDecimal(dr["N_BQCZZ"]);

                            model.N_RQ_OPEN = Convert.ToInt32(dr["N_RQ_OPEN"]);
                            model.N_RQSPL01 = Convert.ToDecimal(dr["N_RQSPL01"]);
                            model.N_RQSPL23 = Convert.ToDecimal(dr["N_RQSPL23"]);
                            model.N_RQSPL46 = Convert.ToDecimal(dr["N_RQSPL46"]);
                            model.N_RQSPL7 = Convert.ToDecimal(dr["N_RQSPL7"]);
                            model.N_DSDPL = Convert.ToDecimal(dr["N_DSDPL"]);
                            model.N_DSSPL = Convert.ToDecimal(dr["N_DSSPL"]);
                            gameList.Add(model);
                        }
                        #endregion
                        break;
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        return gameList;
    }
    /// <summary>
    /// 1单式，2走地，0早餐，3过关, 4波胆，5半全场，6入球数
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="ballType"></param>
    /// <param name="courtType"></param>
    /// <param name="playType"></param>
    /// <param name="teamDic"></param>
    /// <param name="alliance"></param>
    /// <returns></returns>
    private List<KFB_BALL> GetCompanyAllGameList(string ballType, int courtType, int playType, int isbet, string zwDate, Dictionary<int, KFB_DWGL> teamDic, ref Dictionary<string, string> billDic, params string[] alliance)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32,1),
                new OracleParameter("n_lmno",OracleType.VarChar,2000),
                new OracleParameter("p_sfxz",OracleType.Int32,1),
                new OracleParameter("p_zwdate",OracleType.VarChar,10),
                new OracleParameter("playtype",OracleType.Int32,1),
                new OracleParameter("t_billlist", OracleType.Cursor),
                new OracleParameter("t_gamelist", OracleType.Cursor)};
        parameter[0].Value = ballType;
        parameter[1].Value = courtType;
        parameter[2].Value = string.Join(",", alliance);
        parameter[3].Value = isbet;
        parameter[4].Value = zwDate;
        parameter[5].Value = playType;//玩法类型，0早餐，1單式，2走地，3過關, 7已开赛，8已计算，9历史比赛
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_company_allball_gamelist.sp_company_allball_gamelist", parameter))
        {
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0:
                        #region 注单
                        while (dr.Read())
                        {
                            string key = dr["N_QSBH"].ToString() + "|" + dr["N_BSDW"].ToString() + "|" + dr["N_XZWF"].ToString().ToUpper();
                            string value = dr["BILLCOUNT"].ToString() + "/" + Convert.ToString(int.Parse(dr["BETSUM"].ToString()) / 1000);
                            if (dr["N_WXDJ"].ToString() != "0")
                                value += "/" + dr["N_WXDJ"].ToString();
                            billDic.Add(key, value);

                        }
                        #endregion
                        break;
                    case 1:
                        #region 赛事
                        while (dr.Read())
                        {
                            KFB_BALL model = new KFB_BALL();
                            model.N_LX = Convert.ToString(dr["n_lx"]);
                            model.N_ID = Convert.ToInt32(dr["n_id"]);
                            model.N_ZWDATE = Convert.ToDateTime(dr["n_zwdate"]);
                            model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                            model.N_LMNO = Convert.ToInt32(dr["n_lmno"]);
                            model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                            model.N_HOME = Convert.ToInt32(dr["n_home"]);
                            model.N_VISIT_NAME = teamDic[model.N_VISIT.Value].N_DWMC;
                            model.N_HOME_NAME = teamDic[model.N_HOME.Value].N_DWMC;
                            model.N_CBXH = Convert.ToInt32(dr["N_CBXH"]);
                            //model.N_SAMEGAME = Convert.ToInt32(dr["N_SAMEGAME"] );
                            model.N_SAMETEAM = Convert.ToString(dr["N_SAMETEAM"]);
                            model.N_LET = Convert.ToInt32(dr["N_LET"]);
                            model.N_SFXZ = Convert.ToInt32(dr["N_SFXZ"]);
                            model.N_LOCK = Convert.ToInt32(dr["N_LOCK"]);
                            model.N_ZBXH = Convert.ToInt32(dr["N_ZBXH"]);
                            model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                            model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                            model.N_VH = Convert.ToInt32(dr["N_VH"]);
                            model.N_VISIT_JZF = Convert.ToInt32(dr["N_VISIT_JZF"]);
                            model.N_HOME_JZF = Convert.ToDecimal(dr["N_HOME_JZF"]);
                            model.N_ZDTIME = Convert.ToString(dr["N_ZDTIME"]);
                            model.N_ZDFLAG = Convert.ToString(dr["N_ZDFLAG"]);
                            model.N_ZDUPTIME = Convert.ToDateTime(dr["N_ZDUPTIME"]);
                            model.N_SFZD = Convert.ToInt32(dr["N_SFZD"]);
                            model.N_REMARK = Convert.ToString(dr["N_REMARK"]);
                            model.N_HJPL = Convert.ToDecimal(dr["N_HJPL"]);
                            model.N_HJGGCJ = Convert.ToDecimal(dr["N_HJGGCJ"]);

                            model.N_RFLX = Convert.ToInt32(dr["N_RFLX"]);
                            model.N_RFFS = Convert.ToDecimal(dr["N_RFFS"]);
                            model.N_RFBL = Convert.ToInt32(dr["N_RFBL"]);
                            model.N_LRFPL = Convert.ToDecimal(dr["N_LRFPL"]);
                            model.N_RRFPL = Convert.ToDecimal(dr["N_RRFPL"]);
                            model.N_RF_OPEN = Convert.ToInt32(dr["N_RF_OPEN"]);
                            model.N_RF_LOCK_V = Convert.ToInt32(dr["N_RF_LOCK_V"]);
                            model.N_RF_LOCK_H = Convert.ToInt32(dr["N_RF_LOCK_H"]);
                            model.N_RF_GG = Convert.ToInt32(dr["N_RF_GG"]);
                            model.N_LRFCJ = Convert.ToDecimal(dr["N_LRFCJ"]);
                            model.N_RRFCJ = Convert.ToDecimal(dr["N_RRFCJ"]);

                            model.N_DXLX = Convert.ToInt32(dr["N_DXLX"]);
                            model.N_DXFS = Convert.ToDecimal(dr["N_DXFS"]);
                            model.N_DXBL = Convert.ToInt32(dr["N_DXBL"]);
                            model.N_DXDPL = Convert.ToDecimal(dr["N_DXDPL"]);
                            model.N_DXXPL = Convert.ToDecimal(dr["N_DXXPL"]);
                            model.N_DX_OPEN = Convert.ToInt32(dr["N_DX_OPEN"]);
                            model.N_DX_LOCK_V = Convert.ToInt32(dr["N_DX_LOCK_V"]);
                            model.N_DX_LOCK_H = Convert.ToInt32(dr["N_DX_LOCK_H"]);
                            model.N_DX_GG = Convert.ToInt32(dr["N_DX_GG"]);
                            model.N_DXDCJ = Convert.ToDecimal(dr["N_DXDCJ"]);
                            model.N_DXXCJ = Convert.ToDecimal(dr["N_DXXCJ"]);

                            model.N_DSDPL = Convert.ToDecimal(dr["N_DSDPL"]);
                            model.N_DSSPL = Convert.ToDecimal(dr["N_DSSPL"]);
                            model.N_DS_OPEN = Convert.ToInt32(dr["N_DS_OPEN"]);
                            model.N_DS_LOCK_V = Convert.ToInt32(dr["N_DS_LOCK_V"]);
                            model.N_DS_LOCK_H = Convert.ToInt32(dr["N_DS_LOCK_H"]);
                            model.N_DS_GG = Convert.ToInt32(dr["N_DS_GG"]);
                            model.N_DSDCJ = Convert.ToDecimal(dr["N_DSDCJ"]);
                            model.N_DSSCJ = Convert.ToDecimal(dr["N_DSSCJ"]);

                            model.N_LDYPL = Convert.ToDecimal(dr["N_LDYPL"]);
                            model.N_RDYPL = Convert.ToDecimal(dr["N_RDYPL"]);
                            model.N_DY_OPEN = Convert.ToInt32(dr["N_DY_OPEN"]);
                            model.N_DY_LOCK_V = Convert.ToInt32(dr["N_DY_LOCK_V"]);
                            model.N_DY_LOCK_H = Convert.ToInt32(dr["N_DY_LOCK_H"]);
                            model.N_DY_GG = Convert.ToInt32(dr["N_DY_GG"]);
                            model.N_LDYCJ = Convert.ToDecimal(dr["N_LDYCJ"]);
                            model.N_RDYCJ = Convert.ToDecimal(dr["N_RDYCJ"]);

                            model.N_LSYPL = Convert.ToDecimal(dr["N_LSYPL"]);
                            model.N_RSYPL = Convert.ToDecimal(dr["N_RSYPL"]);
                            model.N_SY_OPEN = Convert.ToInt32(dr["N_SY_OPEN"]);
                            model.N_SY_LOCK_V = Convert.ToInt32(dr["N_SY_LOCK_V"]);
                            model.N_SY_LOCK_H = Convert.ToInt32(dr["N_SY_LOCK_H"]);
                            model.N_SY_GG = Convert.ToInt32(dr["N_SY_GG"]);
                            model.N_LSYCJ = Convert.ToDecimal(dr["N_LSYCJ"]);
                            model.N_RSYCJ = Convert.ToDecimal(dr["N_RSYCJ"]);


                            gameList.Add(model);
                        }
                        #endregion
                        break;
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        return gameList;
    }
    /// <summary>
    /// 查询联盟
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="playType"></param>
    /// <param name="ballType"></param>
    /// <param name="courtType"></param>
    /// <param name="userId"></param>
    /// <param name="rateGap"></param>
    /// <param name="teamDic"></param>
    /// <returns></returns>
    private List<KFB_LMGL> GetCompanyAllianceList(int playType, string ballType, int courtType, int isBet, string zwDate, out string accDate, out Dictionary<int, KFB_DWGL> teamDic)
    {
        List<KFB_LMGL> modelList = new List<KFB_LMGL>();
        OracleParameter[] parameter = { 
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32,1),
                new OracleParameter("p_sfxz",OracleType.Int32,1),
                new OracleParameter("p_zwdate",OracleType.VarChar,10),
                new OracleParameter("playtype",OracleType.Int32,1),
                new OracleParameter("t_alliancelist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("p_accdate", OracleType.VarChar,10)};
        parameter[0].Value = ballType;
        parameter[1].Value = courtType;
        parameter[2].Value = isBet;
        parameter[3].Value = zwDate;
        parameter[4].Value = playType;//玩法类型，0早餐，1單式，2走地，3過關, 4波胆，5半全场，6入球数，7已开赛，8已计算，9历史比赛
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;
        parameter[7].Direction = System.Data.ParameterDirection.Output;

        teamDic = new Dictionary<int, KFB_DWGL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_company_alliancelist.sp_company_alliancelist", parameter))
        {
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://队伍列表
                        while (dr.Read())
                        {
                            KFB_LMGL model = new KFB_LMGL();
                            model.N_NO = dr.GetInt32(0);
                            model.N_LMMC = dr.GetString(1);
                            modelList.Add(model);
                        }
                        break;
                    case 1://联盟列表
                        while (dr.Read())
                        {
                            KFB_DWGL model = new KFB_DWGL();
                            model.N_ID = dr.GetInt32(0);
                            model.N_DWMC = dr.GetString(1);
                            teamDic.Add(model.N_ID, model);
                        }
                        break;
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        accDate = parameter[7].Value.ToString();
        return modelList;
    }
    /// <summary>
    /// 查询数据
    /// </summary>
    /// <param name="ballType">球类型 足球 篮球 棒球</param>
    /// <param name="selectedAllianceList">选择的联盟</param>
    /// <param name="courtType">场别</param>
    /// <param name="OrderName">排序方式</param>
    /// <param name="userId">用户id</param>
    /// <param name="playType">玩法类型，1单式，2走地，0早餐，3过关,4波胆，5半全场，6入球数 </param>
    /// <param name="pageIndex">查询第几页数据</param>
    /// <param name="pageSize">每页显示多少</param>
    /// <param name="recordCount">总笔数</param>
    /// <param name="allianceModelList">返回所有联盟</param>
    /// <param name="rateGap">abc盘差距</param>
    /// <returns></returns>
    public List<KFB_BALL> GetCompanyGameList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate, ref Dictionary<string, string> billDic)
    {
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        AutoResetEvent[] waitEvents = null;
        try
        {
            List<List<int>> allianceGroup = new List<List<int>>();
            Dictionary<int, KFB_DWGL> teamDic = null;
            allianceModelList = GetCompanyAllianceList(playType, ballType, courtType, isBet, zwDate, out accDate, out teamDic);
            if (COUNT_THREAD == 0)
            {
                #region 单线程查询
                if (playType >= 4 && playType <= 6)
                {
                    gameList = GetCompanySpecialGameList(ballType, courtType, playType, isBet, zwDate, teamDic, ref billDic,
                        selectedAllianceList.ConvertAll<string>(delegate(int index)
                    {
                        return index.ToString();
                    }).ToArray());//波胆，入球数，半全场特殊玩法
                }
                else
                {
                    gameList = GetCompanyAllGameList(ballType, courtType, playType, isBet, zwDate, teamDic, ref billDic,
                        selectedAllianceList.ConvertAll<string>(delegate(int index)
                    {
                        return index.ToString();
                    }).ToArray());
                }
                #endregion
            }
            else
            {
                #region 多线程查询
                if (selectedAllianceList.Count > COUNT_THREAD)//大于设定线程数
                {
                    int length = Convert.ToInt32(Math.Ceiling(selectedAllianceList.Count / Convert.ToDouble(COUNT_THREAD)));
                    int len = length;
                    for (int i = 1; i <= COUNT_THREAD; i++)
                    {
                        int index = (i - 1) * length;
                        if (i * length > selectedAllianceList.Count)
                        {
                            len = length - (i * length - selectedAllianceList.Count);
                        }
                        if (len > 0)
                        {
                            allianceGroup.Add(selectedAllianceList.GetRange(index, len));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= selectedAllianceList.Count; i++)
                    {
                        allianceGroup.Add(selectedAllianceList.GetRange(i - 1, 1));
                    }
                }
                waitEvents = new AutoResetEvent[allianceGroup.Count];
                Dictionary<string, string> temptBillDic = billDic;
                for (int i = 0; i < allianceGroup.Count; i++)
                {
                    waitEvents[i] = new AutoResetEvent(false);
                    Thread thread = new Thread(new ParameterizedThreadStart(delegate(object j)
                    {
                        int k = Convert.ToInt32(j);
                        try
                        {
                            List<KFB_BALL> ballList = null;
                            if (playType >= 4)
                            {
                                ballList = GetCompanySpecialGameList(ballType, courtType, playType, isBet, zwDate, teamDic, ref temptBillDic,
                                    allianceGroup[k].ConvertAll<string>(delegate(int index)
                                {
                                    return index.ToString();
                                }).ToArray());
                                lock (gameList)
                                {
                                    gameList.AddRange(ballList);//波胆，入球数，半全场特殊玩法
                                }
                            }
                            else
                            {
                                ballList = GetCompanyAllGameList(ballType, courtType, playType, isBet, zwDate, teamDic, ref temptBillDic,
                                    allianceGroup[k].ConvertAll<string>(delegate(int index)
                                {
                                    return index.ToString();
                                }).ToArray());
                                lock (gameList)
                                {
                                    gameList.AddRange(ballList);
                                }
                            }
                        }
                        //catch (Exception ex)
                        //{
                        //    Console.Write(ex.Message);
                        //    Console.ReadLine();
                        //}
                        finally
                        {
                            if (waitEvents[k] != null)
                            {
                                waitEvents[k].Set();
                            }
                        }
                    }));
                    thread.Start(i);
                }
                billDic = temptBillDic;
                if (waitEvents.Length > 0)
                {
                    WaitHandle.WaitAll(waitEvents);
                }
                #endregion
            }
        }
        finally
        {
            if (waitEvents != null)
            {
                for (int i = 0; i < waitEvents.Length; i++)
                {
                    if (waitEvents[i] != null)
                    {
                        waitEvents[i].Close();
                    }
                    waitEvents[i] = null;
                }
                waitEvents = null;
            }
            this.DbHelper.Close();
        }
        //排序
        int orderId = 0;
        int.TryParse(OrderName, out orderId);
        Sort(gameList, orderId);
        recordCount = gameList.Count;
        int count = pageSize;
        if (pageIndex * pageSize > recordCount)
        {
            count = pageSize - (pageIndex * pageSize - recordCount);
        }
        int start = (pageIndex - 1) * pageSize;
        return gameList.GetRange(start, count);//分页
    }
    /// <summary>
    /// 注單明細 
    /// </summary>
    /// <param name="qsbh">賽事編號</param>
    /// <param name="bsdw">比賽隊伍</param>
    /// <param name="xzwf">玩法</param>
    /// <param name="status"></param>
    /// <param name="playType"></param>
    /// <returns></returns>
    public DataTable GetBillDetail(string qsbh, string bsdw, string xzwf, string status, string playType)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select to_char(p.n_xzrq,'yyyy/mm/dd hh24:mi:ss') as n_xzrq,p.n_xzdh,p.n_xznr,");
        strSql.Append(" n_xzwf,p.n_xzdh||'<br/>'||p.n_hyip as xzdh,p.n_hydh,");
        strSql.Append(" p.n_xzje,p.n_xzje*(1-p.n_dzjcz/100) as gsje,");
        strSql.Append(" nvl(p.n_syjg,0) as n_syjg,");
        strSql.Append(" nvl(p.n_ty,0) as n_ty,");
        strSql.Append(" nvl(p.n_hyjg,0) as n_hyjg,");
        strSql.Append(" nvl(p.n_gsjg,0) as n_gsjg,nvl(p.n_del,0) as n_del,nvl(n_wxdj,0) as n_wxdj,case nvl(n_del,'') when 1 then nvl(n_delyy,'') else '' end as n_delyy,n_dbzd ");
        if (playType.Equals("9"))
        {
            strSql.Append(" from kfb_optzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        else
        {
            strSql.Append(" from kfb_ptzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        if (xzwf.ToLower().Equals("all"))
        {
            strSql.Append(" and :n_xzwf = :n_xzwf");
        }
        else
        {
            strSql.Append(" and p.n_xzwf = :n_xzwf");
        }
        switch (status)
        {
            case "1"://有效的
                strSql.Append(" and p.n_wxdj=1 and p.n_del=0");
                break;
            case "2"://無效的
                strSql.Append(" and p.n_wxdj<>1 and p.n_del=0");
                break;
            case "3"://已刪除
                strSql.Append(" and p.n_del=1");
                break;
            case "4"://已確認
                strSql.Append(" and p.n_qr=1");
                break;
            case "5"://未確認
                strSql.Append(" and (p.n_qr=0 or p.n_qr is null) and p.n_del=0");
                break;
        }
        if (Convert.ToInt32(playType) < 7)
        {
            strSql.Append(" and p.n_gsty = :n_gsty");
        }
        else
        {
            strSql.Append(" and :n_gsty = :n_gsty");
        }
        strSql.Append(" order by to_char(p.n_xzrq,'yyyy/mm/dd hh24:mi:ss') desc ");

        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_qsbh", qsbh, DbType.Int32, 10),
                this.DbHelper.CreateDbParameter(":n_bsdw", bsdw, DbType.String, 20),
                this.DbHelper.CreateDbParameter(":n_xzwf", xzwf, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_gsty", playType, DbType.Int32, 10)
            };
        return this.DbHelper.Query(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 盤口統計 
    /// </summary>
    /// <param name="s_n_qsbh"></param>
    /// <param name="s_n_bsdw"></param>
    /// <param name="s_n_bslx"></param>
    /// <param name="s_n_xzwf"></param>
    /// <param name="s_aPK"></param>
    /// <returns></returns>
    public DataTable GetBillStat(string qsbh, string bsdw, string xzwf, string status, string playType)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select * from(");
        strSql.Append(" select 1 as id,Count(dw) as  bs,dw,sum(n_xzje) as n_xzje,sum(gsje) as gsje,sum(n_syjg) as n_syjg,sum(n_ty) as n_ty,sum(n_hyjg) as n_hyjg,sum(n_gsjg) as n_gsjg from");
        strSql.Append(" (select (case p.n_xzwf");
        strSql.Append(" when 'l_rf' then case p.n_rfxt when 1 then p.n_rf||'+'||p.n_rfbl when 0 then (case p.n_rf when 0 then '平手' else p.n_rf||'平' end) when -1 then p.n_rf||'-'||p.n_rfbl when -2 then p.n_rf||'輸' end ");
        strSql.Append(" ||'@讓分@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_dx' then case p.n_dxxt when 1 then p.n_dx||'+'||p.n_dxbl when 0 then (case p.n_dx when 0 then '平手' else p.n_dx||'平' end) when -1 then p.n_dx||'-'||p.n_dxbl when -2 then p.n_dx||'.5' end ");
        strSql.Append(" ||'@大小@'||case p.n_bsdw when (select to_char(b.n_visit) from kfb_baseball b where b.n_id = p.n_qsbh) then '大' else '小' end");
        strSql.Append(" when 'l_hj' then 'PK@和局@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_dy' then 'PK@獨贏@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_sy' then '1輸@一輸二贏@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_rqs' then case p.n_bsdw when 'd' then '單' when 's' then '雙' else p.n_bsdw end||'@入球數@'");
        strSql.Append(" when 'l_bqc' then case p.n_bsdw when 'zz' then '主/主' when 'zh' then '主/和' when 'zk' then '主/客' when 'hz' then '和/主' when 'hh' then '和/和' when 'hk' then '和/客' when 'kz' then '客/主' when 'kh' then '客/和' when 'kk' then '客/客' end||'@入球數@'");
        strSql.Append(" when 'l_ds' then '@單雙@'||case p.n_bsdw when (select to_char(b.n_visit) from kfb_baseball b where b.n_id = p.n_qsbh) then '單' else '雙' end");
        strSql.Append(" when 'l_zdrf' then case p.n_rfxt when 1 then p.n_rf||'+'||p.n_rfbl when 0 then (case p.n_rf when 0 then '平手' else p.n_rf||'平' end) when -1 then p.n_rf||'-'||p.n_rfbl when -2 then p.n_rf||'輸' end ");
        strSql.Append(" ||'@'||'滾球讓分@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_zddx' then case p.n_dxxt when 1 then p.n_dx||'+'||p.n_dxbl when 0 then (case p.n_dx when 0 then '平手' else p.n_dx||'平' end) when -1 then p.n_dx||'-'||p.n_dxbl when -2 then p.n_dx||'.5' end ");
        strSql.Append(" ||'@滾球大小@'|| case p.n_bsdw when (select to_char(b.n_visit) from kfb_baseball b where b.n_id = p.n_qsbh) then '大' else '小' end");
        strSql.Append(" when 'l_zdhj' then 'PK@和局@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_zddy' then 'PK@獨贏@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" end) as dw,");
        strSql.Append(" p.n_xzje,");
        strSql.Append(" p.n_xzje*(1-p.n_dzjcz/100) as gsje,");
        strSql.Append(" nvl(p.n_syjg,0) as n_syjg,");
        strSql.Append(" nvl(p.n_ty,0) as n_ty,");
        strSql.Append(" nvl(p.n_hyjg,0) as n_hyjg,");
        strSql.Append(" nvl(p.n_gsjg,0) as n_gsjg");
        if (playType.Equals("9"))
        {
            strSql.Append(" from kfb_optzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        else
        {
            strSql.Append(" from kfb_ptzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        if (string.IsNullOrEmpty(xzwf))
        {
            strSql.Append(" and p.n_xzwf = :n_xzwf");
        }
        else
        {
            strSql.Append(" and :n_xzwf = :n_xzwf");
        }
        switch (status)
        {
            case "1"://有效的
                strSql.Append(" and p.n_wxdj=1 and p.n_del=0");
                break;
            case "2"://無效的
                strSql.Append(" and p.n_wxdj<>1 and p.n_del=0");
                break;
            case "3"://已刪除
                strSql.Append(" and p.n_del=1");
                break;
            case "4"://已確認
                strSql.Append(" and p.n_qr=1");
                break;
            case "5"://未確認
                strSql.Append(" and (p.n_qr=0 or p.n_qr is null) and p.n_del=0");
                break;
        }
        if (Convert.ToInt32(playType) < 7)
        {
            strSql.Append(" and p.n_gsty = :n_gsty");
        }
        else
        {
            strSql.Append(" and :n_gsty = :n_gsty");
        }
        strSql.Append(") group by dw");
        strSql.Append(" union select 2 as id,");
        strSql.Append(" Count(p.n_id) as  bs,'合計：' as dw,sum(p.n_xzje) as n_xzje,sum(p.n_xzje*(1-p.n_dzjcz/100)) as gsje,");
        strSql.Append(" sum(nvl(p.n_syjg,0)) as n_syjg,sum(p.n_ty) as n_ty,sum(nvl(p.n_hyjg,0)) as n_hyjg,sum(nvl(p.n_gsjg,0)) as n_gsjg");
        if (playType.Equals("9"))
        {
            strSql.Append(" from kfb_optzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        else
        {
            strSql.Append(" from kfb_ptzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        if (string.IsNullOrEmpty(xzwf))
        {
            strSql.Append(" and p.n_xzwf = :n_xzwf");
        }
        else
        {
            strSql.Append(" and :n_xzwf = :n_xzwf");
        }
        switch (status)
        {
            case "1"://有效的
                strSql.Append(" and p.n_wxdj=1 and p.n_del=0");
                break;
            case "2"://無效的
                strSql.Append(" and p.n_wxdj<>1 and p.n_del=0");
                break;
            case "3"://已刪除
                strSql.Append(" and p.n_del=1");
                break;
            case "4"://已確認
                strSql.Append(" and p.n_qr=1");
                break;
            case "5"://未確認
                strSql.Append(" and (p.n_qr=0 or p.n_qr is null) and p.n_del=0");
                break;
        }
        if (Convert.ToInt32(playType) < 7)
        {
            strSql.Append(" and p.n_gsty = :n_gsty");
        }
        else
        {
            strSql.Append(" and :n_gsty = :n_gsty");
        }
        strSql.Append(" )order by id, bs");
        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_qsbh", qsbh, DbType.Int32, 10),
                this.DbHelper.CreateDbParameter(":n_bsdw", bsdw, DbType.String, 20),
                this.DbHelper.CreateDbParameter(":n_xzwf", xzwf, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_gsty", playType, DbType.Int32, 10)
            };
        return this.DbHelper.Query(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 盤口計算 
    /// </summary>
    /// <param name="s_n_qsbh"></param>
    /// <param name="s_n_bsdw"></param>
    /// <param name="s_n_bslx"></param>
    /// <param name="s_n_xzwf"></param>
    /// <param name="s_aPK"></param>
    /// <returns></returns>
    public DataTable GetBillCount(string qsbh, string bsdw, string xzwf, string status, string playType)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select * from(");
        strSql.Append(" select 1 as id,Count(dw) as  bs,dw,sum(n_xzje) as n_xzje,sum(gsje) as gsje,sum(n_syjg) as n_syjg,sum(n_ty) as n_ty,sum(n_hyjg) as n_hyjg,sum(n_gsjg) as n_gsjg from");
        strSql.Append(" (select (case p.n_xzwf");
        strSql.Append(" when 'l_rf' then case p.n_rfxt when 1 then p.n_rf||'+'||p.n_rfbl when 0 then (case p.n_rf when 0 then '平手' else p.n_rf||'平' end) when -1 then p.n_rf||'-'||p.n_rfbl when -2 then p.n_rf||'輸' end ");
        strSql.Append(" ||'@讓分@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_dx' then case p.n_dxxt when 1 then p.n_dx||'+'||p.n_dxbl when 0 then (case p.n_dx when 0 then '平手' else p.n_dx||'平' end) when -1 then p.n_dx||'-'||p.n_dxbl when -2 then p.n_dx||'.5' end ");
        strSql.Append(" ||'@大小@'||case p.n_bsdw when (select to_char(b.n_visit) from kfb_baseball b where b.n_id = p.n_qsbh) then '大' else '小' end");
        strSql.Append(" when 'l_hj' then 'PK@和局@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_dy' then 'PK@獨贏@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_sy' then '1輸@一輸二贏@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_rqs' then case p.n_bsdw when 'd' then '單' when 's' then '雙' else p.n_bsdw end||'@入球數@'");
        strSql.Append(" when 'l_bqc' then case p.n_bsdw when 'zz' then '主/主' when 'zh' then '主/和' when 'zk' then '主/客' when 'hz' then '和/主' when 'hh' then '和/和' when 'hk' then '和/客' when 'kz' then '客/主' when 'kh' then '客/和' when 'kk' then '客/客' end||'@入球數@'");
        strSql.Append(" when 'l_ds' then '@單雙@'||case p.n_bsdw when (select to_char(b.n_visit) from kfb_baseball b where b.n_id = p.n_qsbh) then '單' else '雙' end");
        strSql.Append(" when 'l_zdrf' then case p.n_rfxt when 1 then p.n_rf||'+'||p.n_rfbl when 0 then (case p.n_rf when 0 then '平手' else p.n_rf||'平' end) when -1 then p.n_rf||'-'||p.n_rfbl when -2 then p.n_rf||'輸' end ");
        strSql.Append(" ||'@'||'滾球讓分@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_zddx' then case p.n_dxxt when 1 then p.n_dx||'+'||p.n_dxbl when 0 then (case p.n_dx when 0 then '平手' else p.n_dx||'平' end) when -1 then p.n_dx||'-'||p.n_dxbl when -2 then p.n_dx||'.5' end ");
        strSql.Append(" ||'@滾球大小@'|| case p.n_bsdw when (select to_char(b.n_visit) from kfb_baseball b where b.n_id = p.n_qsbh) then '大' else '小' end");
        strSql.Append(" when 'l_zdhj' then 'PK@和局@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" when 'l_zddy' then 'PK@獨贏@'||(select d.n_dwmc from kfb_dwgl d where d.n_id = p.n_bsdw)");
        strSql.Append(" end) as dw,");
        strSql.Append(" p.n_xzje,");
        strSql.Append(" p.n_xzje*(1-p.n_dzjcz/100) as gsje,");
        strSql.Append(" nvl(p.n_syjg,0) as n_syjg,");
        strSql.Append(" nvl(p.n_ty,0) as n_ty,");
        strSql.Append(" nvl(p.n_hyjg,0) as n_hyjg,");
        strSql.Append(" nvl(p.n_gsjg,0) as n_gsjg");
        if (playType.Equals("9"))
        {
            strSql.Append(" from kfb_optzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        else
        {
            strSql.Append(" from kfb_ptzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        if (string.IsNullOrEmpty(xzwf))
        {
            strSql.Append(" and p.n_xzwf = :n_xzwf");
        }
        else
        {
            strSql.Append(" and :n_xzwf = :n_xzwf");
        }
        switch (status)
        {
            case "1"://有效的
                strSql.Append(" and p.n_wxdj=1 and p.n_del=0");
                break;
            case "2"://無效的
                strSql.Append(" and p.n_wxdj<>1 and p.n_del=0");
                break;
            case "3"://已刪除
                strSql.Append(" and p.n_del=1");
                break;
            case "4"://已確認
                strSql.Append(" and p.n_qr=1");
                break;
            case "5"://未確認
                strSql.Append(" and (p.n_qr=0 or p.n_qr is null) and p.n_del=0");
                break;
        }
        if (Convert.ToInt32(playType) < 7)
        {
            strSql.Append(" and p.n_gsty = :n_gsty");
        }
        else
        {
            strSql.Append(" and :n_gsty = :n_gsty");
        }
        strSql.Append(") group by dw");
        strSql.Append(" union select 2 as id,");
        strSql.Append(" Count(p.n_id) as  bs,'合計：' as dw,sum(p.n_xzje) as n_xzje,sum(p.n_xzje*(1-p.n_dzjcz/100)) as gsje,");
        strSql.Append(" sum(nvl(p.n_syjg,0)) as n_syjg,sum(p.n_ty) as n_ty,sum(nvl(p.n_hyjg,0)) as n_hyjg,sum(nvl(p.n_gsjg,0)) as n_gsjg");
        if (playType.Equals("9"))
        {
            strSql.Append(" from kfb_optzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        else
        {
            strSql.Append(" from kfb_ptzd p where p.n_qsbh=:n_qsbh and (p.n_bsdw=:n_bsdw or :n_bsdw='-1')");
        }
        if (string.IsNullOrEmpty(xzwf))
        {
            strSql.Append(" and p.n_xzwf = :n_xzwf");
        }
        else
        {
            strSql.Append(" and :n_xzwf = :n_xzwf");
        }
        switch (status)
        {
            case "1"://有效的
                strSql.Append(" and p.n_wxdj=1 and p.n_del=0");
                break;
            case "2"://無效的
                strSql.Append(" and p.n_wxdj<>1 and p.n_del=0");
                break;
            case "3"://已刪除
                strSql.Append(" and p.n_del=1");
                break;
            case "4"://已確認
                strSql.Append(" and p.n_qr=1");
                break;
            case "5"://未確認
                strSql.Append(" and (p.n_qr=0 or p.n_qr is null) and p.n_del=0");
                break;
        }
        if (Convert.ToInt32(playType) < 7)
        {
            strSql.Append(" and p.n_gsty = :n_gsty");
        }
        else
        {
            strSql.Append(" and :n_gsty = :n_gsty");
        }
        strSql.Append(" )order by id, bs");
        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_qsbh", qsbh, DbType.Int32, 10),
                this.DbHelper.CreateDbParameter(":n_bsdw", bsdw, DbType.String, 20),
                this.DbHelper.CreateDbParameter(":n_xzwf", xzwf, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_gsty", playType, DbType.Int32, 10)
            };
        return this.DbHelper.Query(strSql.ToString(), parameter);
    }

    /// <summary>
    /// 得到聯盟
    /// </summary>
    /// <param name="i_aLMLX"></param>
    /// <returns></returns>
    public DataTable GetLeagueList(int i_aLMLX)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_NO,N_LMMC,N_XH");
        strSql.Append(" FROM KFB_LMGL");
        strSql.Append(" where N_LX=:N_LX ORDER BY N_XH");

        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":N_LX", i_aLMLX, DbType.Int32, 4)
            };
        return this.DbHelper.Query(strSql.ToString(), parameter);
    }

    /// <summary>
    /// 得到隊伍
    /// </summary>
    /// <param name="i_aLM"></param>
    /// <returns></returns>
    public string GetTeamList(int i_aLM)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_ID,N_DWMC ");
        strSql.Append(" FROM KFB_DWGL ");
        strSql.Append(" where N_NO=:N_NO ORDER BY N_DWMC");

        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":N_NO", i_aLM, DbType.Int32, 4)
            };
        return this.DbHelper.ExecuteJson(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="playType"></param>
    /// <param name="action"></param>
    /// <param name="id"></param>
    public void SetGameStatus(string playType, int action, string[] id)
    {
        try
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strZDSql = new StringBuilder();

            strSql.Append("UPDATE KFB_BASEBALL B  SET ");
            switch (action)
            {
                case 0:
                    strSql.Append("B.N_LOCK = 3");//去垃圾桶
                    break;
                case 1:
                    if (playType.Equals("2"))
                    {
                        strSql.Append("B.N_SFXZ = 1");//开滚球
                    }
                    else
                    {
                        strSql.Append("B.N_SFXZ = 2");//开单式
                    }
                    break;
                case 2:
                    strSql.Append("B.N_SFXZ = 0");//关盘
                    break;
                case 3:
                    strSql.Append("B.N_LOCK = 2");//锁
                    break;
                case 4:
                    strSql.Append("B.N_LOCK = 1");//跟
                    break;
                case 5:
                    if (playType.Equals("2"))
                    {
                        strSql.Append("B.N_SFZD = 1,B.N_XZZT = 0,B.N_SFXZ = 0");//去单式
                    }
                    else
                    {
                        strSql.Append("B.N_SFZD = (CASE B.N_SFZD WHEN 2 THEN 1 ELSE B.N_SFZD END),B.N_XZZT = 0,B.N_SFXZ = 0");//去单式
                    }
                    break;
                case 6:
                    strSql.Append("B.N_SFZD = 2,B.N_XZZT = 0,B.N_SFXZ = 0");//去滚球
                    break;
                case 7:
                    if (playType.Equals("8"))//从已计算去已开赛
                    {
                        strSql.Append("B.N_XZZT = 1,B.N_SFXZ = 0,");//去已开赛

                        strSql.Append("B.N_VISIT_RESULT = 0,B.N_HOME_RESULT = 0,B.N_SF9J=0,B.N_COUNTTIME = NULL");
                        strZDSql.Append("update KFB_PTZD set ");
                        strZDSql.Append(" N_DEL=2 ");
                        strZDSql.Append(" where 1=1 ");
                    }
                    else
                    {
                        strSql.Append("B.N_COUNTTIME = NULL,B.N_XZZT = 1,B.N_SFXZ = 0");//去已开赛
                    }
                    break;
                case 8:
                    strSql.Append("B.N_LOCK = 0");//锁
                    break;
                case 9:
                    strSql.Length = 0;
                    strSql.Append(" DELETE KFB_BASEBALL B");//彻底删除
                    break;
            }
            strSql.Append(" WHERE 1 <> 1");
            List<DbParameter> paramters = new List<DbParameter>();
            List<DbParameter> Zdparamters = new List<DbParameter>();

            for (int i = 0; i < id.Length; i++)
            {
                string paramName = ":N_ID" + i.ToString();
                string ZdparamName = ":N_QSBH" + i.ToString();
                strSql.Append(" OR B.N_ID = " + paramName);
                strZDSql.Append(" and N_QSBH = " + ZdparamName);
                paramters.Add(this.DbHelper.CreateDbParameter(paramName, id[i], DbType.Int32, 10));
                Zdparamters.Add(this.DbHelper.CreateDbParameter(ZdparamName, id[i], DbType.Int32, 10));
            }

            this.DbHelper.BeginTran();

            if (action == 7 && playType == "8")
                this.DbHelper.ExecuteNonQuery(strZDSql.ToString(), Zdparamters.ToArray());
            this.DbHelper.ExecuteNonQuery(strSql.ToString(), paramters.ToArray());
            this.DbHelper.CommitTran();
        }
        catch
        {
            this.DbHelper.RollbackTran();
        }
        finally
        {
            this.DbHelper.Close();
        }
    }

    /// <summary>
    /// 验证垃圾桶资料是否有注单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetBetCount(string[] id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" SELECT COUNT(0) FROM  KFB_PTZD B  ");
        strSql.Append(" WHERE 1 <> 1");
        List<DbParameter> paramters = new List<DbParameter>();
        for (int i = 0; i < id.Length; i++)
        {
            string paramName = ":N_QSBH" + i.ToString();
            strSql.Append(" OR B.N_QSBH = " + paramName);
            paramters.Add(this.DbHelper.CreateDbParameter(paramName, id[i], DbType.Int32, 10));
        }
        object exists = this.DbHelper.ExecuteScalar(strSql.ToString(), paramters.ToArray());
        return Convert.ToInt32(exists);
    }
    /// <summary>
    /// 修改賠率
    /// </summary>
    public void SetRate(int nid, string sField, decimal nvalue)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" update KFB_BASEBALL set ");
        strSql.Append(" " + sField + "=:nvalue ");
        strSql.Append(" where n_id=:nid ");
        OracleParameter[] parameters = {
				new OracleParameter(":nvalue", OracleType.Float,22),
                new OracleParameter(":nid", OracleType.Number,10),
            };
        parameters[0].Value = nvalue;
        parameters[1].Value = nid;

        this.DbHelper.ExecuteNonQuery(strSql.ToString(), parameters);
    }
    #endregion

    #region 单场单注
    /// <summary>
    /// 获取基础单场单注
    /// </summary>
    /// <returns></returns>
    public DataTable GetLimitBase()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select n_playtype, n_playvalue, n_courttype from kfb_limit_base order by n_order");
        return this.DbHelper.Query(strSql.ToString());
    }
    /// <summary>
    /// 获取单场单注
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    public DataTable GetLimitDetail(string site)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select n_site, n_level, n_credit from kfb_limit_detail where n_site = :n_site order by n_level");
        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_site", site, DbType.String, 10, ParameterDirection.Input)
            };
        return this.DbHelper.Query(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 获取单场单注
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    public DataTable GetLimitList(string site)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("SELECT A.N_LEVEL,A.N_CREDIT AS DZ,B.N_CREDIT DC FROM ");
        strSql.Append("(select n_site, n_level, n_credit*(SELECT C.N_PLAYVALUE FROM KFB_LIMIT_BASE C WHERE C.N_PLAYTYPE='RF' AND C.N_COURTTYPE=1 AND ROWNUM = 1) AS n_credit from kfb_limit_detail where n_site = 'ALL' ) A,");
        strSql.Append("(select n_site, n_level, n_credit from kfb_limit_detail where n_site = :n_site) B ");
        strSql.Append("WHERE A.N_LEVEL=B.N_LEVEL");
        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_site", site, DbType.String, 10, ParameterDirection.Input)
            };
        return this.DbHelper.Query(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="playtype"></param>
    /// <param name="playvalue"></param>
    /// <param name="courtType"></param>
    public void UpdateLimitBase(string playtype, decimal playvalue, int courtType)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update kfb_limit_base set n_playvalue=:n_playvalue where n_playtype = :n_playtype and n_courttype=:n_courttype");
        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_playtype", playtype, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_playvalue", playvalue, DbType.Decimal, 10),
                this.DbHelper.CreateDbParameter(":n_courttype", courtType, DbType.Int32, 4)
            };
        this.DbHelper.ExecuteNonQuery(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <param name="level"></param>
    /// <param name="credit"></param>
    public void AddLimitDetail(string site, int level, decimal credit)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into kfb_limit_detail (n_site,n_level,n_credit) values (:n_site,:n_level,:n_credit)");
        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_site", site, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_level", level, DbType.Int32, 4),
                this.DbHelper.CreateDbParameter(":n_credit", credit, DbType.Decimal, 10)
            };
        this.DbHelper.ExecuteNonQuery(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <param name="level"></param>
    /// <param name="credit"></param>
    public void UpdateLimitDetail(string site, int level, decimal credit)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update kfb_limit_detail set n_credit = :n_credit where n_site = :n_site and n_level = :n_level");
        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_site", site, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_level", level, DbType.Int32, 4),
                this.DbHelper.CreateDbParameter(":n_credit", credit, DbType.Decimal, 10)
            };
        this.DbHelper.ExecuteNonQuery(strSql.ToString(), parameter);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DataTable GetSiteList()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select  distinct n_site from kfb_limit_detail where n_site <> 'ALL'");
        return this.DbHelper.Query(strSql.ToString());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Exsits(string site, int level)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from kfb_limit_detail where n_site = :n_site and n_level = :n_level");

        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_site", site, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_level", level, DbType.Int32, 4)
            };
        return !this.DbHelper.ExecuteScalar(strSql.ToString(), parameter).Equals("0");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="level"></param>
    /// <returns></returns>
    public DataTable GetLeagueList(string type, string level)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select n_no, n_lmmc, n_lx, n_xh, n_level from kfb_lmgl where n_lx = :n_lx and n_level = :n_level");

        DbParameter[] parameter = {
                this.DbHelper.CreateDbParameter(":n_lx", type, DbType.String, 10),
                this.DbHelper.CreateDbParameter(":n_level", level, DbType.Int32, 4)
            };
        return this.DbHelper.Query(strSql.ToString(), parameter);
    }

    public void AddLimitDetail(string site, List<decimal> dCredit)
    {

        ArrayList arrSql = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            StringBuilder strSql = new StringBuilder();
            int level = i + 1;
            strSql.Append("insert into kfb_limit_detail(n_site,n_level,n_credit) values('" + site + "'," + level + "," + dCredit[i] + ") ");
            arrSql.Add(strSql.ToString());
        }
        DbHelperOra.ExecuteSqlTran(arrSql);
    }

    public void ModifyLimitDetail(string strOldsite, string site, List<decimal> dCredit)
    {

        ArrayList arrSql = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            StringBuilder strSql = new StringBuilder();
            int level = i + 1;
            strSql.Append("update kfb_limit_detail set n_credit=" + dCredit[i] + " ,n_site='" + site + "' where n_site='" + strOldsite + "' and n_level=" + level);
            arrSql.Add(strSql.ToString());
        }
        DbHelperOra.ExecuteSqlTran(arrSql);
    }
    #endregion

    #region  世界杯
    public List<KFB_BALL> sjbGameList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out decimal rateGap)
    {
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        AutoResetEvent[] waitEvents = null;//new AutoResetEvent[selectedAllianceList.Count];
        try
        {
            List<List<int>> allianceGroup = new List<List<int>>();
            Dictionary<int, KFB_DWGL> teamDic = null;
            allianceModelList = sjbAllianceList(playType, ballType, courtType, userId, out rateGap, out teamDic);
            if (COUNT_THREAD == 0)
            {
                #region 单线程查询
                //if (playType >= 4)
                //{
                //    gameList = GetClientSpecialGameList(ballType, courtType, playType, teamDic,
                //        selectedAllianceList.ConvertAll<string>(delegate(int index)
                //    {
                //        return index.ToString();
                //    }).ToArray());//波胆，入球数，半全场特殊玩法
                //}
                //else
                //{
                gameList = sjbAllGameList(ballType, courtType, playType, teamDic,
                        selectedAllianceList.ConvertAll<string>(delegate(int index)
                    {
                        return index.ToString();
                    }).ToArray());
                //}
                #endregion
            }
            else
            {
                #region 多线程查询
                if (selectedAllianceList.Count > COUNT_THREAD)//大于设定线程数
                {
                    int length = Convert.ToInt32(Math.Ceiling(selectedAllianceList.Count / Convert.ToDouble(COUNT_THREAD)));
                    int len = length;
                    for (int i = 1; i <= COUNT_THREAD; i++)
                    {
                        int index = (i - 1) * length;
                        if (i * length > selectedAllianceList.Count)
                        {
                            len = length - (i * length - selectedAllianceList.Count);
                        }
                        if (len > 0)
                        {
                            allianceGroup.Add(selectedAllianceList.GetRange(index, len));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= selectedAllianceList.Count; i++)
                    {
                        allianceGroup.Add(selectedAllianceList.GetRange(i - 1, 1));
                    }
                }
                waitEvents = new AutoResetEvent[allianceGroup.Count];
                for (int i = 0; i < allianceGroup.Count; i++)
                {
                    waitEvents[i] = new AutoResetEvent(false);
                    Thread thread = new Thread(new ParameterizedThreadStart(delegate(object j)
                    {
                        int k = Convert.ToInt32(j);
                        try
                        {
                            List<KFB_BALL> ballList = null;
                            if (playType >= 4)
                            {
                                ballList = GetClientSpecialGameList(ballType, courtType, playType, teamDic,
                                    allianceGroup[k].ConvertAll<string>(delegate(int index)
                                {
                                    return index.ToString();
                                }).ToArray());
                                lock (gameList)
                                {
                                    gameList.AddRange(ballList);//波胆，入球数，半全场特殊玩法
                                }
                            }
                            else
                            {
                                ballList = GetClientAllGameList(ballType, courtType, playType, teamDic,
                                    allianceGroup[k].ConvertAll<string>(delegate(int index)
                                {
                                    return index.ToString();
                                }).ToArray());
                                lock (gameList)
                                {
                                    gameList.AddRange(ballList);
                                }
                            }
                        }
                        finally
                        {
                            if (waitEvents[k] != null)
                            {
                                waitEvents[k].Set();
                            }
                        }
                    }));
                    thread.Start(i);
                }
                if (waitEvents.Length > 0)
                {
                    WaitHandle.WaitAll(waitEvents);
                }
                #endregion
            }
        }
        finally
        {
            if (waitEvents != null)
            {
                for (int i = 0; i < waitEvents.Length; i++)
                {
                    if (waitEvents[i] != null)
                    {
                        waitEvents[i].Close();
                    }
                    waitEvents[i] = null;
                }
                waitEvents = null;
            }
        }
        //排序
        int orderId = 0;
        int.TryParse(OrderName, out orderId);
        Sort(gameList, orderId);
        recordCount = gameList.Count;
        int count = pageSize;
        if (pageIndex * pageSize > recordCount)
        {
            count = pageSize - (pageIndex * pageSize - recordCount);
        }
        int start = (pageIndex - 1) * pageSize;
        return gameList.GetRange(start, count);//分页
    }

    private List<KFB_LMGL> sjbAllianceList(int playType, string ballType, int courtType, string userId, out decimal rateGap, out Dictionary<int, KFB_DWGL> teamDic)
    {
        List<KFB_LMGL> modelList = new List<KFB_LMGL>();
        OracleParameter[] parameter = { 
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32,1),
                new OracleParameter("playtype",OracleType.Int32,1),
                new OracleParameter("userid",OracleType.VarChar,50),
                new OracleParameter("t_alliancelist", OracleType.Cursor),
                new OracleParameter("t_teamlist", OracleType.Cursor),
                new OracleParameter("rategap", OracleType.Number)};
        parameter[0].Value = ballType;
        parameter[1].Value = courtType;
        parameter[2].Value = playType;
        parameter[3].Value = userId;
        parameter[4].Direction = System.Data.ParameterDirection.Output;
        parameter[5].Direction = System.Data.ParameterDirection.Output;
        parameter[6].Direction = System.Data.ParameterDirection.Output;

        teamDic = new Dictionary<int, KFB_DWGL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_sjb_alliancelist.sp_sjb_alliancelist", parameter))
        {
            int tableIndex = 0;
            do
            {
                switch (tableIndex)
                {
                    case 0://队伍列表
                        while (dr.Read())
                        {
                            KFB_LMGL model = new KFB_LMGL();
                            model.N_NO = dr.GetInt32(0);
                            model.N_LMMC = dr.GetString(1);
                            modelList.Add(model);
                        }
                        break;
                    case 1://联盟列表
                        while (dr.Read())
                        {
                            KFB_DWGL model = new KFB_DWGL();
                            model.N_ID = dr.GetInt32(0);
                            model.N_DWMC = dr.GetString(1);
                            teamDic.Add(model.N_ID, model);
                        }
                        break;
                }
                tableIndex++;
            }
            while (dr.NextResult());
        }
        rateGap = Convert.ToDecimal(parameter[6].Value);
        return modelList;
    }

    private List<KFB_BALL> sjbAllGameList(string ballType, int courtType, int playType, Dictionary<int, KFB_DWGL> teamDic, params string[] alliance)
    {
        OracleParameter[] parameter = { 
                new OracleParameter("n_lmno",OracleType.VarChar,2000),
                new OracleParameter("n_lx",OracleType.VarChar,5),
                new OracleParameter("n_cbxh",OracleType.Int32,20),
                new OracleParameter("playtype",OracleType.Int32,1),
                new OracleParameter("t_gamelist", OracleType.Cursor)};
        parameter[0].Value = string.Join(",", alliance);
        parameter[1].Value = ballType;
        parameter[2].Value = courtType;
        parameter[3].Value = playType;//--玩法类型，1单式，2走地，0早餐，3过关, 4波胆，5半全场，6入球数
        parameter[4].Direction = System.Data.ParameterDirection.Output;
        List<KFB_BALL> gameList = new List<KFB_BALL>();
        using (DbDataReader dr = this.DbHelper.ExecuteReader("pkg_sjb_gamelist.sp_sjb_gamelist", parameter))
        {
            #region 赛事
            while (dr.Read())
            {
                KFB_BALL model;
                if (ballType == "b_zq" && playType != 3)
                {
                    if (dr["N_CBXH"].Equals(2M))//足球上半场
                    {
                        model = gameList.Find(delegate(KFB_BALL fullModel)
                        {
                            return fullModel.N_SAMEGAME == Convert.ToInt32(dr["N_SAMEGAME"]) && fullModel.N_CBXH.Value == 1;// && Convert.ToInt32(dr["N_CBXH"]) == 2;
                        });
                        if (model == null)
                        {
                            model = new KFB_BALL();
                            model.N_LX = Convert.ToString(dr["n_lx"]);
                            model.N_ZWDATE = Convert.ToDateTime(dr["n_zwdate"]);
                            model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                            model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                            model.N_HOME = Convert.ToInt32(dr["n_home"]);
                            model.N_VISIT_NAME = teamDic[model.N_VISIT.Value].N_DWMC;
                            model.N_HOME_NAME = teamDic[model.N_HOME.Value].N_DWMC;
                            model.N_SAMEGAME = Convert.ToInt32(dr["N_SAMEGAME"]);
                            model.N_SAMETEAM = Convert.ToString(dr["N_SAMETEAM"]);
                            model.N_SFXZ = Convert.ToInt32(dr["N_SFXZ"]);
                            model.N_LOCK = Convert.ToInt32(dr["N_LOCK"]);
                            model.N_ZBXH = Convert.ToInt32(dr["N_ZBXH"]);
                            model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                            model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                            model.N_VH = Convert.ToInt32(dr["N_VH"]);
                            model.N_VISIT_JZF = Convert.ToInt32(dr["N_VISIT_JZF"]);
                            model.N_HOME_JZF = Convert.ToDecimal(dr["N_HOME_JZF"]);
                            model.N_ZDTIME = Convert.ToString(dr["N_ZDTIME"]);
                            model.N_ZDFLAG = Convert.ToString(dr["N_ZDFLAG"]);
                            model.N_ZDUPTIME = Convert.ToDateTime(dr["N_ZDUPTIME"]);
                            model.N_REMARK = Convert.ToString(dr["N_REMARK"]);
                            model.N_VISIT_REDCARD = Convert.ToInt32(dr["N_VISIT_REDCARD"]);
                            model.N_HOME_REDCARD = Convert.ToInt32(dr["N_HOME_REDCARD"]);
                        }

                        model.N_ID2 = Convert.ToInt32(dr["N_ID"]);
                        model.N_LET2 = Convert.ToInt32(dr["N_LET"]);
                        model.N_CBXH2 = Convert.ToInt32(dr["N_CBXH"]);
                        model.N_HJPL2 = Convert.ToDecimal(dr["N_HJPL"]);

                        model.N_LMNO2 = Convert.ToInt32(dr["n_lmno"]);
                        model.N_VISIT2 = Convert.ToInt32(dr["n_visit"]);
                        model.N_HOME2 = Convert.ToInt32(dr["n_home"]);

                        model.N_RFLX2 = Convert.ToInt32(dr["N_RFLX"]);
                        model.N_RFFS2 = Convert.ToDecimal(dr["N_RFFS"]);
                        model.N_RFBL2 = Convert.ToInt32(dr["N_RFBL"]);
                        model.N_LRFPL2 = Convert.ToDecimal(dr["N_LRFPL"]);
                        model.N_RRFPL2 = Convert.ToDecimal(dr["N_RRFPL"]);
                        model.N_RF_OPEN2 = Convert.ToInt32(dr["N_RF_OPEN"]);
                        model.N_RF_LOCK_V2 = Convert.ToInt32(dr["N_RF_LOCK_V"]);
                        model.N_RF_LOCK_H2 = Convert.ToInt32(dr["N_RF_LOCK_H"]);

                        model.N_DXLX2 = Convert.ToInt32(dr["N_DXLX"]);
                        model.N_DXFS2 = Convert.ToDecimal(dr["N_DXFS"]);
                        model.N_DXBL2 = Convert.ToInt32(dr["N_DXBL"]);
                        model.N_DXDPL2 = Convert.ToDecimal(dr["N_DXDPL"]);
                        model.N_DXXPL2 = Convert.ToDecimal(dr["N_DXXPL"]);
                        model.N_DX_OPEN2 = Convert.ToInt32(dr["N_DX_OPEN"]);
                        model.N_DX_LOCK_V2 = Convert.ToInt32(dr["N_DX_LOCK_V"]);
                        model.N_DX_LOCK_H2 = Convert.ToInt32(dr["N_DX_LOCK_H"]);

                        model.N_DSDPL2 = Convert.ToDecimal(dr["N_DSDPL"]);
                        model.N_DSSPL2 = Convert.ToDecimal(dr["N_DSSPL"]);
                        model.N_DS_OPEN2 = Convert.ToInt32(dr["N_DS_OPEN"]);
                        model.N_DS_LOCK_V2 = Convert.ToInt32(dr["N_DS_LOCK_V"]);
                        model.N_DS_LOCK_H2 = Convert.ToInt32(dr["N_DS_LOCK_H"]);

                        model.N_LDYPL2 = Convert.ToDecimal(dr["N_LDYPL"]);
                        model.N_RDYPL2 = Convert.ToDecimal(dr["N_RDYPL"]);
                        model.N_DY_OPEN2 = Convert.ToInt32(dr["N_DY_OPEN"]);
                        model.N_DY_LOCK_V2 = Convert.ToInt32(dr["N_DY_LOCK_V"]);
                        model.N_DY_LOCK_H2 = Convert.ToInt32(dr["N_DY_LOCK_H"]);

                        model.N_LSYPL2 = Convert.ToDecimal(dr["N_LSYPL"]);
                        model.N_RSYPL2 = Convert.ToDecimal(dr["N_RSYPL"]);
                        model.N_SY_OPEN2 = Convert.ToInt32(dr["N_SY_OPEN"]);
                        model.N_SY_LOCK_V2 = Convert.ToInt32(dr["N_SY_LOCK_V"]);
                        model.N_SY_LOCK_H2 = Convert.ToInt32(dr["N_SY_LOCK_H"]);
                        continue;
                    }
                }
                model = new KFB_BALL();
                model.N_LX = Convert.ToString(dr["n_lx"]);
                model.N_ID = Convert.ToInt32(dr["n_id"]);
                model.N_ZWDATE = Convert.ToDateTime(dr["n_zwdate"]);
                model.N_GAMEDATE = Convert.ToDateTime(dr["n_gamedate"]);
                model.N_LMNO = Convert.ToInt32(dr["n_lmno"]);
                model.N_VISIT = Convert.ToInt32(dr["n_visit"]);
                model.N_HOME = Convert.ToInt32(dr["n_home"]);
                model.N_VISIT_NAME = teamDic[model.N_VISIT.Value].N_DWMC;
                model.N_HOME_NAME = teamDic[model.N_HOME.Value].N_DWMC;
                model.N_CBXH = Convert.ToInt32(dr["N_CBXH"]);
                model.N_SAMEGAME = Convert.ToInt32(dr["N_SAMEGAME"]);
                model.N_SAMETEAM = Convert.ToString(dr["N_SAMETEAM"]);
                model.N_LET = Convert.ToInt32(dr["N_LET"]);
                model.N_SFXZ = Convert.ToInt32(dr["N_SFXZ"]);
                model.N_LOCK = Convert.ToInt32(dr["N_LOCK"]);
                model.N_ZBXH = Convert.ToInt32(dr["N_ZBXH"]);
                model.N_VISIT_NO = Convert.ToInt32(dr["N_VISIT_NO"]);
                model.N_HOME_NO = Convert.ToInt32(dr["N_HOME_NO"]);
                model.N_VH = Convert.ToInt32(dr["N_VH"]);
                model.N_VISIT_JZF = Convert.ToInt32(dr["N_VISIT_JZF"]);
                model.N_HOME_JZF = Convert.ToDecimal(dr["N_HOME_JZF"]);
                model.N_ZDTIME = Convert.ToString(dr["N_ZDTIME"]);
                model.N_ZDFLAG = Convert.ToString(dr["N_ZDFLAG"]);
                model.N_ZDUPTIME = Convert.ToDateTime(dr["N_ZDUPTIME"]);
                //model.N_ZDUPTIME = Convert.ToDateTime(dr["SYSDATE"]);//lpad(to_char(nvl(T.N_ZDTIME, 0)+round((sysdate - T.N_ZDUPTIME) * 24 * 60, 0)),2,''0'') as N_ZDUPTIME
                model.N_REMARK = Convert.ToString(dr["N_REMARK"]);
                model.N_HJPL = Convert.ToDecimal(dr["N_HJPL"]);
                model.N_HJGGCJ = Convert.ToDecimal(dr["N_HJGGCJ"]);
                model.N_VISIT_REDCARD = Convert.ToInt32(dr["N_VISIT_REDCARD"]);
                model.N_HOME_REDCARD = Convert.ToInt32(dr["N_HOME_REDCARD"]);

                model.N_RFLX = Convert.ToInt32(dr["N_RFLX"]);
                model.N_RFFS = Convert.ToDecimal(dr["N_RFFS"]);
                model.N_RFBL = Convert.ToInt32(dr["N_RFBL"]);
                model.N_LRFPL = Convert.ToDecimal(dr["N_LRFPL"]);
                model.N_RRFPL = Convert.ToDecimal(dr["N_RRFPL"]);
                model.N_RF_OPEN = Convert.ToInt32(dr["N_RF_OPEN"]);
                model.N_RF_LOCK_V = Convert.ToInt32(dr["N_RF_LOCK_V"]);
                model.N_RF_LOCK_H = Convert.ToInt32(dr["N_RF_LOCK_H"]);
                model.N_RF_GG = Convert.ToInt32(dr["N_RF_GG"]);
                model.N_LRFCJ = Convert.ToDecimal(dr["N_LRFCJ"]);
                model.N_RRFCJ = Convert.ToDecimal(dr["N_RRFCJ"]);
                model.N_DXLX = Convert.ToInt32(dr["N_DXLX"]);
                model.N_DXFS = Convert.ToDecimal(dr["N_DXFS"]);
                model.N_DXBL = Convert.ToInt32(dr["N_DXBL"]);
                model.N_DXDPL = Convert.ToDecimal(dr["N_DXDPL"]);
                model.N_DXXPL = Convert.ToDecimal(dr["N_DXXPL"]);
                model.N_DX_OPEN = Convert.ToInt32(dr["N_DX_OPEN"]);
                model.N_DX_LOCK_V = Convert.ToInt32(dr["N_DX_LOCK_V"]);
                model.N_DX_LOCK_H = Convert.ToInt32(dr["N_DX_LOCK_H"]);
                model.N_DX_GG = Convert.ToInt32(dr["N_DX_GG"]);
                model.N_DXDCJ = Convert.ToDecimal(dr["N_DXDCJ"]);
                model.N_DXXCJ = Convert.ToDecimal(dr["N_DXXCJ"]);
                model.N_DSDPL = Convert.ToDecimal(dr["N_DSDPL"]);
                model.N_DSSPL = Convert.ToDecimal(dr["N_DSSPL"]);
                model.N_DS_OPEN = Convert.ToInt32(dr["N_DS_OPEN"]);
                model.N_DS_LOCK_V = Convert.ToInt32(dr["N_DS_LOCK_V"]);
                model.N_DS_LOCK_H = Convert.ToInt32(dr["N_DS_LOCK_H"]);
                model.N_DS_GG = Convert.ToInt32(dr["N_DS_GG"]);
                model.N_DSDCJ = Convert.ToDecimal(dr["N_DSDCJ"]);
                model.N_DSSCJ = Convert.ToDecimal(dr["N_DSSCJ"]);
                model.N_LDYPL = Convert.ToDecimal(dr["N_LDYPL"]);
                model.N_RDYPL = Convert.ToDecimal(dr["N_RDYPL"]);
                model.N_DY_OPEN = Convert.ToInt32(dr["N_DY_OPEN"]);
                model.N_DY_LOCK_V = Convert.ToInt32(dr["N_DY_LOCK_V"]);
                model.N_DY_LOCK_H = Convert.ToInt32(dr["N_DY_LOCK_H"]);
                model.N_DY_GG = Convert.ToInt32(dr["N_DY_GG"]);
                model.N_LDYCJ = Convert.ToDecimal(dr["N_LDYCJ"]);
                model.N_RDYCJ = Convert.ToDecimal(dr["N_RDYCJ"]);
                model.N_LSYPL = Convert.ToDecimal(dr["N_LSYPL"]);
                model.N_RSYPL = Convert.ToDecimal(dr["N_RSYPL"]);
                model.N_SY_OPEN = Convert.ToInt32(dr["N_SY_OPEN"]);
                model.N_SY_LOCK_V = Convert.ToInt32(dr["N_SY_LOCK_V"]);
                model.N_SY_LOCK_H = Convert.ToInt32(dr["N_SY_LOCK_H"]);
                model.N_SY_GG = Convert.ToInt32(dr["N_SY_GG"]);
                model.N_LSYCJ = Convert.ToDecimal(dr["N_LSYCJ"]);
                model.N_RSYCJ = Convert.ToDecimal(dr["N_RSYCJ"]);
                model.N_SFZD = Convert.ToInt32(dr["N_SFZD"]);
                gameList.Add(model);
            }
            #endregion
        }
        return gameList;
    }


    #endregion
    /// <summary>
    /// 查询足球早餐盘的帐务日期
    /// </summary>
    /// <param name="strZWRQ"></param>
    /// <returns></returns>

    public List<DateTime> GetBreakfaseZQ(string strZWRQ)
    {
        List<DateTime> listZWRQ = new List<DateTime>();

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select distinct n_zwdate from kfb_baseball T ");
        strSql.Append(" WHERE T.N_LX='b_zq'  AND T.N_ZWDATE > TO_DATE(:N_ZWDATE,'YYYY/MM/DD') AND T.N_XZZT='0' order by n_zwdate ");

        OracleParameter[] parameters = {
                    new OracleParameter(":N_ZWDATE", OracleType.VarChar,20)
                };
        parameters[0].Value = strZWRQ;
        using (OracleDataReader dr = DbHelperOra.ExecuteReader(strSql.ToString(), parameters))
        {
            while (dr.Read())
            {
                listZWRQ.Add(dr.GetDateTime(0));
            }
        }
        return listZWRQ;
    }
    /// <summary>
    /// 查询垃圾桶赛事的帐务日期
    /// </summary>
    /// <param name="strZWRQ"></param>
    /// <returns></returns>

    public List<DateTime> GetRecycleRQ(string strBallType)
    {
        List<DateTime> listZWRQ = new List<DateTime>();

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select distinct n_zwdate from kfb_baseball T ");
        strSql.Append(" WHERE T.N_LX=:N_LX  AND T.N_LOCK=3 order by n_zwdate ");

        OracleParameter[] parameters = {
                    new OracleParameter(":N_LX", OracleType.VarChar,20)
                };
        parameters[0].Value = strBallType;
        using (OracleDataReader dr = DbHelperOra.ExecuteReader(strSql.ToString(), parameters))
        {
            while (dr.Read())
            {
                listZWRQ.Add(dr.GetDateTime(0));
            }
        }
        return listZWRQ;
    }
    /// <summary>
    /// 直播管理
    /// </summary>
    /// <returns></returns>
    public DataSet GetZB()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_ID,N_ZBMC");
        strSql.Append(" FROM KFB_ZBGL");
        return DbHelperOra.Query(strSql.ToString());
    }
    /// <summary>
    /// 得到系統賬務日期
    /// </summary>
    /// <returns></returns>
    public DateTime GetZWDate()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_ZWRQ from kfb_xtsz where rownum =1");
        return Convert.ToDateTime(DbHelperOra.GetSingle(strSql.ToString()));
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_BSYS GetModel(string N_LX)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from KFB_BSYS ");
        strSql.Append(" where N_LX=:N_LX ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.VarChar,50)};
        parameters[0].Value = N_LX;

        KFB_BSYS model = new KFB_BSYS();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_LX = ds.Tables[0].Rows[0]["N_LX"].ToString();
            if (ds.Tables[0].Rows[0]["N_HYDZSX"].ToString() != "")
            {
                model.N_HYDZSX = float.Parse(ds.Tables[0].Rows[0]["N_HYDZSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HYDCSX"].ToString() != "")
            {
                model.N_HYDCSX = float.Parse(ds.Tables[0].Rows[0]["N_HYDCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYSX"].ToString() != "")
            {
                model.N_DYSX = int.Parse(ds.Tables[0].Rows[0]["N_DYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZSX"].ToString() != "")
            {
                model.N_WZSX = int.Parse(ds.Tables[0].Rows[0]["N_WZSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LYSX"].ToString() != "")
            {
                model.N_LYSX = int.Parse(ds.Tables[0].Rows[0]["N_LYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZQSX"].ToString() != "")
            {
                model.N_WZQSX = int.Parse(ds.Tables[0].Rows[0]["N_WZQSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBXH"].ToString() != "")
            {
                model.N_CBXH = int.Parse(ds.Tables[0].Rows[0]["N_CBXH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFFS"].ToString() != "")
            {
                model.N_RFFS = float.Parse(ds.Tables[0].Rows[0]["N_RFFS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFLX"].ToString() != "")
            {
                model.N_RFLX = int.Parse(ds.Tables[0].Rows[0]["N_RFLX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFBL"].ToString() != "")
            {
                model.N_RFBL = int.Parse(ds.Tables[0].Rows[0]["N_RFBL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LRFPL"].ToString() != "")
            {
                model.N_LRFPL = float.Parse(ds.Tables[0].Rows[0]["N_LRFPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RRFPL"].ToString() != "")
            {
                model.N_RRFPL = float.Parse(ds.Tables[0].Rows[0]["N_RRFPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LRFCJ"].ToString() != "")
            {
                model.N_LRFCJ = float.Parse(ds.Tables[0].Rows[0]["N_LRFCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RRFCJ"].ToString() != "")
            {
                model.N_RRFCJ = float.Parse(ds.Tables[0].Rows[0]["N_RRFCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LRFSX"].ToString() != "")
            {
                model.N_LRFSX = float.Parse(ds.Tables[0].Rows[0]["N_LRFSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RRFSX"].ToString() != "")
            {
                model.N_RRFSX = float.Parse(ds.Tables[0].Rows[0]["N_RRFSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFCJJE"].ToString() != "")
            {
                model.N_RFCJJE = float.Parse(ds.Tables[0].Rows[0]["N_RFCJJE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFCJFS"].ToString() != "")
            {
                model.N_RFCJFS = int.Parse(ds.Tables[0].Rows[0]["N_RFCJFS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFCJPL"].ToString() != "")
            {
                model.N_RFCJPL = float.Parse(ds.Tables[0].Rows[0]["N_RFCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXFS"].ToString() != "")
            {
                model.N_DXFS = float.Parse(ds.Tables[0].Rows[0]["N_DXFS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXLX"].ToString() != "")
            {
                model.N_DXLX = int.Parse(ds.Tables[0].Rows[0]["N_DXLX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXBL"].ToString() != "")
            {
                model.N_DXBL = int.Parse(ds.Tables[0].Rows[0]["N_DXBL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDPL"].ToString() != "")
            {
                model.N_DXDPL = float.Parse(ds.Tables[0].Rows[0]["N_DXDPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXXPL"].ToString() != "")
            {
                model.N_DXXPL = float.Parse(ds.Tables[0].Rows[0]["N_DXXPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDCJ"].ToString() != "")
            {
                model.N_DXDCJ = float.Parse(ds.Tables[0].Rows[0]["N_DXDCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXXCJ"].ToString() != "")
            {
                model.N_DXXCJ = float.Parse(ds.Tables[0].Rows[0]["N_DXXCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDCSX"].ToString() != "")
            {
                model.N_DXDCSX = float.Parse(ds.Tables[0].Rows[0]["N_DXDCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDXSX"].ToString() != "")
            {
                model.N_LDXSX = float.Parse(ds.Tables[0].Rows[0]["N_LDXSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDXSX"].ToString() != "")
            {
                model.N_RDXSX = float.Parse(ds.Tables[0].Rows[0]["N_RDXSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXCJ"].ToString() != "")
            {
                model.N_DXCJ = float.Parse(ds.Tables[0].Rows[0]["N_DXCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXCJPL"].ToString() != "")
            {
                model.N_DXCJPL = float.Parse(ds.Tables[0].Rows[0]["N_DXCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDYPL"].ToString() != "")
            {
                model.N_LDYPL = float.Parse(ds.Tables[0].Rows[0]["N_LDYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDYPL"].ToString() != "")
            {
                model.N_RDYPL = float.Parse(ds.Tables[0].Rows[0]["N_RDYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDYCJ"].ToString() != "")
            {
                model.N_LDYCJ = float.Parse(ds.Tables[0].Rows[0]["N_LDYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDYCJ"].ToString() != "")
            {
                model.N_RDYCJ = float.Parse(ds.Tables[0].Rows[0]["N_RDYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDYSX"].ToString() != "")
            {
                model.N_LDYSX = float.Parse(ds.Tables[0].Rows[0]["N_LDYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDYSX"].ToString() != "")
            {
                model.N_RDYSX = float.Parse(ds.Tables[0].Rows[0]["N_RDYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYCJ"].ToString() != "")
            {
                model.N_DYCJ = float.Parse(ds.Tables[0].Rows[0]["N_DYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYCJPL"].ToString() != "")
            {
                model.N_DYCJPL = float.Parse(ds.Tables[0].Rows[0]["N_DYCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LSYPL"].ToString() != "")
            {
                model.N_LSYPL = float.Parse(ds.Tables[0].Rows[0]["N_LSYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RSYPL"].ToString() != "")
            {
                model.N_RSYPL = float.Parse(ds.Tables[0].Rows[0]["N_RSYPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LSYCJ"].ToString() != "")
            {
                model.N_LSYCJ = float.Parse(ds.Tables[0].Rows[0]["N_LSYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RSYCJ"].ToString() != "")
            {
                model.N_RSYCJ = float.Parse(ds.Tables[0].Rows[0]["N_RSYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LSYSX"].ToString() != "")
            {
                model.N_LSYSX = float.Parse(ds.Tables[0].Rows[0]["N_LSYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RSYSX"].ToString() != "")
            {
                model.N_RSYSX = float.Parse(ds.Tables[0].Rows[0]["N_RSYSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYCJ"].ToString() != "")
            {
                model.N_SYCJ = float.Parse(ds.Tables[0].Rows[0]["N_SYCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYCJPL"].ToString() != "")
            {
                model.N_SYCJPL = float.Parse(ds.Tables[0].Rows[0]["N_SYCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDPL"].ToString() != "")
            {
                model.N_DSDPL = float.Parse(ds.Tables[0].Rows[0]["N_DSDPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSSPL"].ToString() != "")
            {
                model.N_DSSPL = float.Parse(ds.Tables[0].Rows[0]["N_DSSPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDCJ"].ToString() != "")
            {
                model.N_DSDCJ = float.Parse(ds.Tables[0].Rows[0]["N_DSDCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSSCJ"].ToString() != "")
            {
                model.N_DSSCJ = float.Parse(ds.Tables[0].Rows[0]["N_DSSCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDCSX"].ToString() != "")
            {
                model.N_DSDCSX = float.Parse(ds.Tables[0].Rows[0]["N_DSDCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LDSSX"].ToString() != "")
            {
                model.N_LDSSX = float.Parse(ds.Tables[0].Rows[0]["N_LDSSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RDSSX"].ToString() != "")
            {
                model.N_RDSSX = float.Parse(ds.Tables[0].Rows[0]["N_RDSSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSCJ"].ToString() != "")
            {
                model.N_DSCJ = float.Parse(ds.Tables[0].Rows[0]["N_DSCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSCJPL"].ToString() != "")
            {
                model.N_DSCJPL = float.Parse(ds.Tables[0].Rows[0]["N_DSCJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSPL01"].ToString() != "")
            {
                model.N_RQSPL01 = float.Parse(ds.Tables[0].Rows[0]["N_RQSPL01"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSPL23"].ToString() != "")
            {
                model.N_RQSPL23 = float.Parse(ds.Tables[0].Rows[0]["N_RQSPL23"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSPL46"].ToString() != "")
            {
                model.N_RQSPL46 = float.Parse(ds.Tables[0].Rows[0]["N_RQSPL46"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSPL7"].ToString() != "")
            {
                model.N_RQSPL7 = float.Parse(ds.Tables[0].Rows[0]["N_RQSPL7"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSSX"].ToString() != "")
            {
                model.N_RQSSX = float.Parse(ds.Tables[0].Rows[0]["N_RQSSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL00"].ToString() != "")
            {
                model.N_BDGPL00 = float.Parse(ds.Tables[0].Rows[0]["N_BDGPL00"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL10"].ToString() != "")
            {
                model.N_BDZPL10 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL10"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL11"].ToString() != "")
            {
                model.N_BDGPL11 = float.Parse(ds.Tables[0].Rows[0]["N_BDGPL11"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL20"].ToString() != "")
            {
                model.N_BDZPL20 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL20"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL21"].ToString() != "")
            {
                model.N_BDZPL21 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL21"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL22"].ToString() != "")
            {
                model.N_BDGPL22 = float.Parse(ds.Tables[0].Rows[0]["N_BDGPL22"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL30"].ToString() != "")
            {
                model.N_BDZPL30 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL30"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL31"].ToString() != "")
            {
                model.N_BDZPL31 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL31"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL32"].ToString() != "")
            {
                model.N_BDZPL32 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL32"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL33"].ToString() != "")
            {
                model.N_BDGPL33 = float.Parse(ds.Tables[0].Rows[0]["N_BDGPL33"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL41"].ToString() != "")
            {
                model.N_BDZPL41 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL41"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL40"].ToString() != "")
            {
                model.N_BDZPL40 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL40"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL42"].ToString() != "")
            {
                model.N_BDZPL42 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL42"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL43"].ToString() != "")
            {
                model.N_BDZPL43 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL43"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL10"].ToString() != "")
            {
                model.N_BDKPL10 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL10"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL20"].ToString() != "")
            {
                model.N_BDKPL20 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL20"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL21"].ToString() != "")
            {
                model.N_BDKPL21 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL21"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL30"].ToString() != "")
            {
                model.N_BDKPL30 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL30"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL31"].ToString() != "")
            {
                model.N_BDKPL31 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL31"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL32"].ToString() != "")
            {
                model.N_BDKPL32 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL32"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL40"].ToString() != "")
            {
                model.N_BDKPL40 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL40"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL41"].ToString() != "")
            {
                model.N_BDKPL41 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL41"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL42"].ToString() != "")
            {
                model.N_BDKPL42 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL42"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL43"].ToString() != "")
            {
                model.N_BDKPL43 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL43"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDGPL44"].ToString() != "")
            {
                model.N_BDGPL44 = float.Parse(ds.Tables[0].Rows[0]["N_BDGPL44"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDZPL5"].ToString() != "")
            {
                model.N_BDZPL5 = float.Parse(ds.Tables[0].Rows[0]["N_BDZPL5"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDKPL5"].ToString() != "")
            {
                model.N_BDKPL5 = float.Parse(ds.Tables[0].Rows[0]["N_BDKPL5"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDSX"].ToString() != "")
            {
                model.N_BDSX = float.Parse(ds.Tables[0].Rows[0]["N_BDSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCZZ"].ToString() != "")
            {
                model.N_BQCZZ = float.Parse(ds.Tables[0].Rows[0]["N_BQCZZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCZH"].ToString() != "")
            {
                model.N_BQCZH = float.Parse(ds.Tables[0].Rows[0]["N_BQCZH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCZK"].ToString() != "")
            {
                model.N_BQCZK = float.Parse(ds.Tables[0].Rows[0]["N_BQCZK"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCHH"].ToString() != "")
            {
                model.N_BQCHH = float.Parse(ds.Tables[0].Rows[0]["N_BQCHH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCHZ"].ToString() != "")
            {
                model.N_BQCHZ = float.Parse(ds.Tables[0].Rows[0]["N_BQCHZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCHK"].ToString() != "")
            {
                model.N_BQCHK = float.Parse(ds.Tables[0].Rows[0]["N_BQCHK"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCKK"].ToString() != "")
            {
                model.N_BQCKK = float.Parse(ds.Tables[0].Rows[0]["N_BQCKK"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCKZ"].ToString() != "")
            {
                model.N_BQCKZ = float.Parse(ds.Tables[0].Rows[0]["N_BQCKZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCKH"].ToString() != "")
            {
                model.N_BQCKH = float.Parse(ds.Tables[0].Rows[0]["N_BQCKH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCSX"].ToString() != "")
            {
                model.N_BQCSX = float.Parse(ds.Tables[0].Rows[0]["N_BQCSX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HJPL"].ToString() != "")
            {
                model.N_HJPL = float.Parse(ds.Tables[0].Rows[0]["N_HJPL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HJGGCJ"].ToString() != "")
            {
                model.N_HJGGCJ = float.Parse(ds.Tables[0].Rows[0]["N_HJGGCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_HJSX"].ToString() != "")
            {
                model.N_HJSX = float.Parse(ds.Tables[0].Rows[0]["N_HJSX"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM KFB_BSYS ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperOra.Query(strSql.ToString());
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddBQ(KFB_BSYS model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BSYS(");
        strSql.Append("N_LX,N_HYDZSX,N_HYDCSX,N_CBXH,N_RFFS,N_RFLX,N_RFBL,N_LRFPL,N_RRFPL,N_LRFCJ,N_RRFCJ,N_LRFSX,N_RRFSX,N_RFCJJE,N_RFCJFS,N_RFCJPL,N_DXFS,N_DXLX,N_DXBL,N_DXDPL,N_DXXPL,N_DXDCJ,N_DXXCJ,N_DXDCSX,N_DXCJ,N_DXCJPL,N_LDYPL,N_RDYPL,N_LDYCJ,N_RDYCJ,N_LDYSX,N_RDYSX,N_DYCJ,N_DYCJPL,N_LSYPL,N_RSYPL,N_LSYCJ,N_RSYCJ,N_LSYSX,N_RSYSX,N_SYCJ,N_SYCJPL,N_DSDPL,N_DSSPL,N_DSDCJ,N_DSSCJ,N_DSDCSX,N_DSCJ,N_DSCJPL,N_LDXSX,N_RDXSX,N_LDSSX,N_RDSSX)");
        strSql.Append(" values (");
        strSql.Append(":N_LX,:N_HYDZSX,:N_HYDCSX,:N_CBXH,:N_RFFS,:N_RFLX,:N_RFBL,:N_LRFPL,:N_RRFPL,:N_LRFCJ,:N_RRFCJ,:N_LRFSX,:N_RRFSX,:N_RFCJJE,:N_RFCJFS,:N_RFCJPL,:N_DXFS,:N_DXLX,:N_DXBL,:N_DXDPL,:N_DXXPL,:N_DXDCJ,:N_DXXCJ,:N_DXDCSX,:N_DXCJ,:N_DXCJPL,:N_LDYPL,:N_RDYPL,:N_LDYCJ,:N_RDYCJ,:N_LDYSX,:N_RDYSX,:N_DYCJ,:N_DYCJPL,:N_LSYPL,:N_RSYPL,:N_LSYCJ,:N_RSYCJ,:N_LSYSX,:N_RSYSX,:N_SYCJ,:N_SYCJPL,:N_DSDPL,:N_DSSPL,:N_DSDCJ,:N_DSSCJ,:N_DSDCSX,:N_DSCJ,:N_DSCJPL,:N_LDXSX,:N_RDXSX,:N_LDSSX,:N_RDSSX)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_HYDZSX", OracleType.Float,22),
					new OracleParameter(":N_HYDCSX", OracleType.Float,22),
					new OracleParameter(":N_CBXH", OracleType.Number,4),
					new OracleParameter(":N_RFFS", OracleType.Float,22),
					new OracleParameter(":N_RFLX", OracleType.Number,4),
					new OracleParameter(":N_RFBL", OracleType.Number,4),
					new OracleParameter(":N_LRFPL", OracleType.Float,22),
					new OracleParameter(":N_RRFPL", OracleType.Float,22),
					new OracleParameter(":N_LRFCJ", OracleType.Float,22),
					new OracleParameter(":N_RRFCJ", OracleType.Float,22),
					new OracleParameter(":N_LRFSX", OracleType.Float,22),
					new OracleParameter(":N_RRFSX", OracleType.Float,22),
					new OracleParameter(":N_RFCJJE", OracleType.Float,22),
					new OracleParameter(":N_RFCJFS", OracleType.Number,4),
					new OracleParameter(":N_RFCJPL", OracleType.Float,22),
					new OracleParameter(":N_DXFS", OracleType.Float,22),
					new OracleParameter(":N_DXLX", OracleType.Number,4),
					new OracleParameter(":N_DXBL", OracleType.Number,4),
					new OracleParameter(":N_DXDPL", OracleType.Float,22),
					new OracleParameter(":N_DXXPL", OracleType.Float,22),
					new OracleParameter(":N_DXDCJ", OracleType.Float,22),
					new OracleParameter(":N_DXXCJ", OracleType.Float,22),
					new OracleParameter(":N_DXDCSX", OracleType.Float,22),
					new OracleParameter(":N_DXCJ", OracleType.Float,22),
					new OracleParameter(":N_DXCJPL", OracleType.Float,22),
					new OracleParameter(":N_LDYPL", OracleType.Float,22),
					new OracleParameter(":N_RDYPL", OracleType.Float,22),
					new OracleParameter(":N_LDYCJ", OracleType.Float,22),
					new OracleParameter(":N_RDYCJ", OracleType.Float,22),
					new OracleParameter(":N_LDYSX", OracleType.Float,22),
					new OracleParameter(":N_RDYSX", OracleType.Float,22),
					new OracleParameter(":N_DYCJ", OracleType.Float,22),
					new OracleParameter(":N_DYCJPL", OracleType.Float,22),
					new OracleParameter(":N_LSYPL", OracleType.Float,22),
					new OracleParameter(":N_RSYPL", OracleType.Float,22),
					new OracleParameter(":N_LSYCJ", OracleType.Float,22),
					new OracleParameter(":N_RSYCJ", OracleType.Float,22),
					new OracleParameter(":N_LSYSX", OracleType.Float,22),
					new OracleParameter(":N_RSYSX", OracleType.Float,22),
					new OracleParameter(":N_SYCJ", OracleType.Float,22),
					new OracleParameter(":N_SYCJPL", OracleType.Float,22),
					new OracleParameter(":N_DSDPL", OracleType.Float,22),
					new OracleParameter(":N_DSSPL", OracleType.Float,22),
					new OracleParameter(":N_DSDCJ", OracleType.Float,22),
					new OracleParameter(":N_DSSCJ", OracleType.Float,22),
					new OracleParameter(":N_DSDCSX", OracleType.Float,22),
					new OracleParameter(":N_DSCJ", OracleType.Float,22),
					new OracleParameter(":N_DSCJPL", OracleType.Float,22),
					new OracleParameter(":N_LDXSX", OracleType.Number,4),
					new OracleParameter(":N_RDXSX", OracleType.Number,4),
					new OracleParameter(":N_LDSSX", OracleType.Number,4),
					new OracleParameter(":N_RDSSX", OracleType.Number,4)};
        parameters[0].Value = model.N_LX;
        parameters[1].Value = model.N_HYDZSX;
        parameters[2].Value = model.N_HYDCSX;
        parameters[3].Value = model.N_CBXH;
        parameters[4].Value = model.N_RFFS;
        parameters[5].Value = model.N_RFLX;
        parameters[6].Value = model.N_RFBL;
        parameters[7].Value = model.N_LRFPL;
        parameters[8].Value = model.N_RRFPL;
        parameters[9].Value = model.N_LRFCJ;
        parameters[10].Value = model.N_RRFCJ;
        parameters[11].Value = model.N_LRFSX;
        parameters[12].Value = model.N_RRFSX;
        parameters[13].Value = model.N_RFCJJE;
        parameters[14].Value = model.N_RFCJFS;
        parameters[15].Value = model.N_RFCJPL;
        parameters[16].Value = model.N_DXFS;
        parameters[17].Value = model.N_DXLX;
        parameters[18].Value = model.N_DXBL;
        parameters[19].Value = model.N_DXDPL;
        parameters[20].Value = model.N_DXXPL;
        parameters[21].Value = model.N_DXDCJ;
        parameters[22].Value = model.N_DXXCJ;
        parameters[23].Value = model.N_DXDCSX;
        parameters[24].Value = model.N_DXCJ;
        parameters[25].Value = model.N_DXCJPL;
        parameters[26].Value = model.N_LDYPL;
        parameters[27].Value = model.N_RDYPL;
        parameters[28].Value = model.N_LDYCJ;
        parameters[29].Value = model.N_RDYCJ;
        parameters[30].Value = model.N_LDYSX;
        parameters[31].Value = model.N_RDYSX;
        parameters[32].Value = model.N_DYCJ;
        parameters[33].Value = model.N_DYCJPL;
        parameters[34].Value = model.N_LSYPL;
        parameters[35].Value = model.N_RSYPL;
        parameters[36].Value = model.N_LSYCJ;
        parameters[37].Value = model.N_RSYCJ;
        parameters[38].Value = model.N_LSYSX;
        parameters[39].Value = model.N_RSYSX;
        parameters[40].Value = model.N_SYCJ;
        parameters[41].Value = model.N_SYCJPL;
        parameters[42].Value = model.N_DSDPL;
        parameters[43].Value = model.N_DSSPL;
        parameters[44].Value = model.N_DSDCJ;
        parameters[45].Value = model.N_DSSCJ;
        parameters[46].Value = model.N_DSDCSX;
        parameters[47].Value = model.N_DSCJ;
        parameters[48].Value = model.N_DSCJPL;
        parameters[49].Value = model.N_LDXSX;
        parameters[50].Value = model.N_RDXSX;
        parameters[51].Value = model.N_LDSSX;
        parameters[52].Value = model.N_RDSSX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int N_ID)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from KFB_BASEBALL");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4)};
        parameters[0].Value = N_ID;

        return DbHelperOra.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZQ(KFB_BASEBALL model, Hashtable o_aHt)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BASEBALL set ");
        strSql.Append("N_ID=:N_ID,");
        strSql.Append("N_LX=:N_LX,");
        strSql.Append("N_ZWDATE=:N_ZWDATE,");
        strSql.Append("N_GAMEDATE=:N_GAMEDATE,");
        strSql.Append("N_LMNO=:N_LMNO,");
        strSql.Append("N_VISIT=:N_VISIT,");
        strSql.Append("N_HOME=:N_HOME,");
        strSql.Append("N_VISIT_RESULT=:N_VISIT_RESULT,");
        strSql.Append("N_HOME_RESULT=:N_HOME_RESULT,");
        strSql.Append("N_TSA=:N_TSA,");
        strSql.Append("N_TSB=:N_TSB,");
        strSql.Append("N_VISIT_NO=:N_VISIT_NO,");
        strSql.Append("N_HOME_NO=:N_HOME_NO,");
        strSql.Append("N_SFZD=:N_SFZD,");
        strSql.Append("N_SFXZ=:N_SFXZ,");
        strSql.Append("N_XZZT=:N_XZZT,");
        strSql.Append("N_VH=:N_VH,");
        strSql.Append("N_LOCK=:N_LOCK,");
        strSql.Append("N_SF9J=:N_SF9J,");
        strSql.Append("N_SFDS=:N_SFDS,");
        strSql.Append("N_SFGP=:N_SFGP,");
        strSql.Append("N_HYDZSX=:N_HYDZSX,");
        strSql.Append("N_HYDCSX=:N_HYDCSX,");
        strSql.Append("N_SFJZF=:N_SFJZF,");
        strSql.Append("N_ZBXH=:N_ZBXH,");
        strSql.Append("N_CBXH=:N_CBXH,");
        strSql.Append("N_RFFS=:N_RFFS,");
        strSql.Append("N_RFLX=:N_RFLX,");
        strSql.Append("N_RFBL=:N_RFBL,");
        strSql.Append("N_LRFPL=:N_LRFPL,");
        strSql.Append("N_RRFPL=:N_RRFPL,");
        strSql.Append("N_LRFCJ=:N_LRFCJ,");
        strSql.Append("N_RRFCJ=:N_RRFCJ,");
        strSql.Append("N_LRFSX=:N_LRFSX,");
        strSql.Append("N_RRFSX=:N_RRFSX,");
        strSql.Append("N_RFCJJE=:N_RFCJJE,");
        strSql.Append("N_RFCJFS=:N_RFCJFS,");
        strSql.Append("N_RFCJPL=:N_RFCJPL,");
        strSql.Append("N_DXFS=:N_DXFS,");
        strSql.Append("N_DXLX=:N_DXLX,");
        strSql.Append("N_DXBL=:N_DXBL,");
        strSql.Append("N_DXDPL=:N_DXDPL,");
        strSql.Append("N_DXXPL=:N_DXXPL,");
        strSql.Append("N_DXDCJ=:N_DXDCJ,");
        strSql.Append("N_DXXCJ=:N_DXXCJ,");
        strSql.Append("N_DXDCSX=:N_DXDCSX,");
        strSql.Append("N_DXCJ=:N_DXCJ,");
        strSql.Append("N_DXCJPL=:N_DXCJPL,");
        strSql.Append("N_LDYPL=:N_LDYPL,");
        strSql.Append("N_RDYPL=:N_RDYPL,");
        strSql.Append("N_LDYCJ=:N_LDYCJ,");
        strSql.Append("N_RDYCJ=:N_RDYCJ,");
        strSql.Append("N_LDYSX=:N_LDYSX,");
        strSql.Append("N_RDYSX=:N_RDYSX,");
        strSql.Append("N_DYCJ=:N_DYCJ,");
        strSql.Append("N_DYCJPL=:N_DYCJPL,");
        strSql.Append("N_LSYPL=:N_LSYPL,");
        strSql.Append("N_RSYPL=:N_RSYPL,");
        strSql.Append("N_LSYCJ=:N_LSYCJ,");
        strSql.Append("N_RSYCJ=:N_RSYCJ,");
        strSql.Append("N_LSYSX=:N_LSYSX,");
        strSql.Append("N_RSYSX=:N_RSYSX,");
        strSql.Append("N_SYCJ=:N_SYCJ,");
        strSql.Append("N_SYCJPL=:N_SYCJPL,");
        strSql.Append("N_DSDPL=:N_DSDPL,");
        strSql.Append("N_DSSPL=:N_DSSPL,");
        strSql.Append("N_DSDCJ=:N_DSDCJ,");
        strSql.Append("N_DSSCJ=:N_DSSCJ,");
        strSql.Append("N_DSDCSX=:N_DSDCSX,");
        strSql.Append("N_DSCJ=:N_DSCJ,");
        strSql.Append("N_DSCJPL=:N_DSCJPL,");
        strSql.Append("N_UP_VISIT_RESULT=:N_UP_VISIT_RESULT,");
        strSql.Append("N_UP_HOME_RESULT=:N_UP_HOME_RESULT,");
        strSql.Append("N_VISIT_JZF=:N_VISIT_JZF,");
        strSql.Append("N_HOME_JZF=:N_HOME_JZF,");
        strSql.Append("N_RF_OPEN=:N_RF_OPEN,");
        strSql.Append("N_DX_OPEN=:N_DX_OPEN,");
        strSql.Append("N_DY_OPEN=:N_DY_OPEN,");
        strSql.Append("N_SY_OPEN=:N_SY_OPEN,");
        strSql.Append("N_DS_OPEN=:N_DS_OPEN,");
        strSql.Append("N_RQ_OPEN=:N_RQ_OPEN,");
        strSql.Append("N_BD_OPEN=:N_BD_OPEN,");
        strSql.Append("N_BQC_OPEN=:N_BQC_OPEN,");
        strSql.Append("N_RF_GG=:N_RF_GG,");
        strSql.Append("N_DX_GG=:N_DX_GG,");
        strSql.Append("N_DY_GG=:N_DY_GG,");
        strSql.Append("N_SY_GG=:N_SY_GG,");
        strSql.Append("N_DS_GG=:N_DS_GG,");
        strSql.Append("N_LET=:N_LET,");
        strSql.Append("N_RF_LOCK_V=:N_RF_LOCK_V,");
        strSql.Append("N_RF_LOCK_H=:N_RF_LOCK_H,");
        strSql.Append("N_DX_LOCK_V=:N_DX_LOCK_V,");
        strSql.Append("N_DX_LOCK_H=:N_DX_LOCK_H,");
        strSql.Append("N_DY_LOCK_V=:N_DY_LOCK_V,");
        strSql.Append("N_DY_LOCK_H=:N_DY_LOCK_H,");
        strSql.Append("N_SY_LOCK_V=:N_SY_LOCK_V,");
        strSql.Append("N_SY_LOCK_H=:N_SY_LOCK_H,");
        strSql.Append("N_DS_LOCK_V=:N_DS_LOCK_V,");
        strSql.Append("N_DS_LOCK_H=:N_DS_LOCK_H,");
        strSql.Append("N_REMARK=:N_REMARK,");
        //strSql.Append("N_COUNTTIME=:N_COUNTTIME,");
        strSql.Append("N_SAMETEAM=:N_SAMETEAM,");
        //strSql.Append("N_GZFLAG=:N_GZFLAG,");
        strSql.Append("N_RQSPL01=:N_RQSPL01,");
        strSql.Append("N_RQSPL23=:N_RQSPL23,");
        strSql.Append("N_RQSPL46=:N_RQSPL46,");
        strSql.Append("N_RQSPL7=:N_RQSPL7,");
        strSql.Append("N_RQSSX=:N_RQSSX,");
        strSql.Append("N_BDGPL00=:N_BDGPL00,");
        strSql.Append("N_BDZPL10=:N_BDZPL10,");
        strSql.Append("N_BDGPL11=:N_BDGPL11,");
        strSql.Append("N_BDZPL20=:N_BDZPL20,");
        strSql.Append("N_BDZPL21=:N_BDZPL21,");
        strSql.Append("N_BDGPL22=:N_BDGPL22,");
        strSql.Append("N_BDZPL30=:N_BDZPL30,");
        strSql.Append("N_BDZPL31=:N_BDZPL31,");
        strSql.Append("N_BDZPL32=:N_BDZPL32,");
        strSql.Append("N_BDGPL33=:N_BDGPL33,");
        strSql.Append("N_BDZPL41=:N_BDZPL41,");
        strSql.Append("N_BDZPL40=:N_BDZPL40,");
        strSql.Append("N_BDZPL42=:N_BDZPL42,");
        strSql.Append("N_BDZPL43=:N_BDZPL43,");
        strSql.Append("N_BDKPL10=:N_BDKPL10,");
        strSql.Append("N_BDKPL20=:N_BDKPL20,");
        strSql.Append("N_BDKPL21=:N_BDKPL21,");
        strSql.Append("N_BDKPL30=:N_BDKPL30,");
        strSql.Append("N_BDKPL31=:N_BDKPL31,");
        strSql.Append("N_BDKPL32=:N_BDKPL32,");
        strSql.Append("N_BDKPL40=:N_BDKPL40,");
        strSql.Append("N_BDKPL41=:N_BDKPL41,");
        strSql.Append("N_BDKPL42=:N_BDKPL42,");
        strSql.Append("N_BDKPL43=:N_BDKPL43,");
        strSql.Append("N_BDGPL44=:N_BDGPL44,");
        strSql.Append("N_BDZPL5=:N_BDZPL5,");
        strSql.Append("N_BDKPL5=:N_BDKPL5,");
        strSql.Append("N_BDSX=:N_BDSX,");
        strSql.Append("N_BQCZZ=:N_BQCZZ,");
        strSql.Append("N_BQCZH=:N_BQCZH,");
        strSql.Append("N_BQCZK=:N_BQCZK,");
        strSql.Append("N_BQCHH=:N_BQCHH,");
        strSql.Append("N_BQCHZ=:N_BQCHZ,");
        strSql.Append("N_BQCHK=:N_BQCHK,");
        strSql.Append("N_BQCKK=:N_BQCKK,");
        strSql.Append("N_BQCKZ=:N_BQCKZ,");
        strSql.Append("N_BQCKH=:N_BQCKH,");
        strSql.Append("N_BQCSX=:N_BQCSX,");
        strSql.Append("N_HJPL=:N_HJPL,");
        strSql.Append("N_HJGGCJ=:N_HJGGCJ,");
        strSql.Append("N_HJSX=:N_HJSX,");
        strSql.Append("N_LDXSX=:N_LDXSX,");
        strSql.Append("N_RDXSX=:N_RDXSX,");
        strSql.Append("N_LDSSX=:N_LDSSX,");
        strSql.Append("N_RDSSX=:N_RDSSX");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,10),
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_ZWDATE", OracleType.DateTime),
					new OracleParameter(":N_GAMEDATE", OracleType.DateTime),
					new OracleParameter(":N_LMNO", OracleType.Number,4),
					new OracleParameter(":N_VISIT", OracleType.Number,4),
					new OracleParameter(":N_HOME", OracleType.Number,4),
					new OracleParameter(":N_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_TSA", OracleType.VarChar,100),
					new OracleParameter(":N_TSB", OracleType.VarChar,100),
					new OracleParameter(":N_VISIT_NO", OracleType.Number,4),
					new OracleParameter(":N_HOME_NO", OracleType.Number,4),
					new OracleParameter(":N_SFZD", OracleType.Number,4),
					new OracleParameter(":N_SFXZ", OracleType.Number,4),
					new OracleParameter(":N_XZZT", OracleType.Number,4),
					new OracleParameter(":N_VH", OracleType.Number,4),
					new OracleParameter(":N_LOCK", OracleType.Number,4),
					new OracleParameter(":N_SF9J", OracleType.Number,4),
					new OracleParameter(":N_SFDS", OracleType.Number,4),
					new OracleParameter(":N_SFGP", OracleType.Number,4),
					new OracleParameter(":N_HYDZSX", OracleType.Number,4),
					new OracleParameter(":N_HYDCSX", OracleType.Number,4),
					new OracleParameter(":N_SFJZF", OracleType.Number,4),
					new OracleParameter(":N_ZBXH", OracleType.Number,4),
					new OracleParameter(":N_CBXH", OracleType.Number,4),
					new OracleParameter(":N_RFFS", OracleType.Number,4),
					new OracleParameter(":N_RFLX", OracleType.Number,4),
					new OracleParameter(":N_RFBL", OracleType.Number,4),
					new OracleParameter(":N_LRFPL", OracleType.Number,4),
					new OracleParameter(":N_RRFPL", OracleType.Number,4),
					new OracleParameter(":N_LRFCJ", OracleType.Number,4),
					new OracleParameter(":N_RRFCJ", OracleType.Number,4),
					new OracleParameter(":N_LRFSX", OracleType.Number,4),
					new OracleParameter(":N_RRFSX", OracleType.Number,4),
					new OracleParameter(":N_RFCJJE", OracleType.Number,4),
					new OracleParameter(":N_RFCJFS", OracleType.Number,4),
					new OracleParameter(":N_RFCJPL", OracleType.Number,4),
					new OracleParameter(":N_DXFS", OracleType.Number,4),
					new OracleParameter(":N_DXLX", OracleType.Number,4),
					new OracleParameter(":N_DXBL", OracleType.Number,4),
					new OracleParameter(":N_DXDPL", OracleType.Number,4),
					new OracleParameter(":N_DXXPL", OracleType.Number,4),
					new OracleParameter(":N_DXDCJ", OracleType.Number,4),
					new OracleParameter(":N_DXXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXDCSX", OracleType.Number,4),
					new OracleParameter(":N_DXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXCJPL", OracleType.Number,4),
					new OracleParameter(":N_LDYPL", OracleType.Number,4),
					new OracleParameter(":N_RDYPL", OracleType.Number,4),
					new OracleParameter(":N_LDYCJ", OracleType.Number,4),
					new OracleParameter(":N_RDYCJ", OracleType.Number,4),
					new OracleParameter(":N_LDYSX", OracleType.Number,4),
					new OracleParameter(":N_RDYSX", OracleType.Number,4),
					new OracleParameter(":N_DYCJ", OracleType.Number,4),
					new OracleParameter(":N_DYCJPL", OracleType.Number,4),
					new OracleParameter(":N_LSYPL", OracleType.Number,4),
					new OracleParameter(":N_RSYPL", OracleType.Number,4),
					new OracleParameter(":N_LSYCJ", OracleType.Number,4),
					new OracleParameter(":N_RSYCJ", OracleType.Number,4),
					new OracleParameter(":N_LSYSX", OracleType.Number,4),
					new OracleParameter(":N_RSYSX", OracleType.Number,4),
					new OracleParameter(":N_SYCJ", OracleType.Number,4),
					new OracleParameter(":N_SYCJPL", OracleType.Number,4),
					new OracleParameter(":N_DSDPL", OracleType.Number,4),
					new OracleParameter(":N_DSSPL", OracleType.Number,4),
					new OracleParameter(":N_DSDCJ", OracleType.Number,4),
					new OracleParameter(":N_DSSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSDCSX", OracleType.Number,4),
					new OracleParameter(":N_DSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSCJPL", OracleType.Number,4),
					new OracleParameter(":N_UP_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_UP_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_VISIT_JZF", OracleType.Number,4),
					new OracleParameter(":N_HOME_JZF", OracleType.Number,4),
					new OracleParameter(":N_RF_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DX_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_SY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DS_OPEN", OracleType.Number,4),
					new OracleParameter(":N_RQ_OPEN", OracleType.Number,4),
					new OracleParameter(":N_BD_OPEN", OracleType.Number,4),
					new OracleParameter(":N_BQC_OPEN", OracleType.Number,4),
					new OracleParameter(":N_RF_GG", OracleType.Number,4),
					new OracleParameter(":N_DX_GG", OracleType.Number,4),
					new OracleParameter(":N_DY_GG", OracleType.Number,4),
					new OracleParameter(":N_SY_GG", OracleType.Number,4),
					new OracleParameter(":N_DS_GG", OracleType.Number,4),
					new OracleParameter(":N_LET", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_REMARK", OracleType.VarChar,100),
					//new OracleParameter(":N_COUNTTIME", OracleType.DateTime),
					new OracleParameter(":N_SAMETEAM", OracleType.VarChar,20),
					//new OracleParameter(":N_GZFLAG", OracleType.Number,4),
					new OracleParameter(":N_RQSPL01",OracleType.Float,22),
					new OracleParameter(":N_RQSPL23",OracleType.Float,22),
					new OracleParameter(":N_RQSPL46",OracleType.Float,22),
					new OracleParameter(":N_RQSPL7",OracleType.Float,22),
					new OracleParameter(":N_RQSSX",OracleType.Float,22),
					new OracleParameter(":N_BDGPL00",OracleType.Float,22),
					new OracleParameter(":N_BDZPL10",OracleType.Float,22),
					new OracleParameter(":N_BDGPL11",OracleType.Float,22),
					new OracleParameter(":N_BDZPL20",OracleType.Float,22),
					new OracleParameter(":N_BDZPL21",OracleType.Float,22),
					new OracleParameter(":N_BDGPL22",OracleType.Float,22),
					new OracleParameter(":N_BDZPL30",OracleType.Float,22),
					new OracleParameter(":N_BDZPL31",OracleType.Float,22),
					new OracleParameter(":N_BDZPL32",OracleType.Float,22),
					new OracleParameter(":N_BDGPL33",OracleType.Float,22),
					new OracleParameter(":N_BDZPL41",OracleType.Float,22),
					new OracleParameter(":N_BDZPL40",OracleType.Float,22),
					new OracleParameter(":N_BDZPL42",OracleType.Float,22),
					new OracleParameter(":N_BDZPL43",OracleType.Float,22),
					new OracleParameter(":N_BDKPL10",OracleType.Float,22),
					new OracleParameter(":N_BDKPL20",OracleType.Float,22),
					new OracleParameter(":N_BDKPL21",OracleType.Float,22),
					new OracleParameter(":N_BDKPL30",OracleType.Float,22),
					new OracleParameter(":N_BDKPL31",OracleType.Float,22),
					new OracleParameter(":N_BDKPL32",OracleType.Float,22),
					new OracleParameter(":N_BDKPL40",OracleType.Float,22),
					new OracleParameter(":N_BDKPL41",OracleType.Float,22),
					new OracleParameter(":N_BDKPL42",OracleType.Float,22),
					new OracleParameter(":N_BDKPL43",OracleType.Float,22),
					new OracleParameter(":N_BDGPL44",OracleType.Float,22),
					new OracleParameter(":N_BDZPL5",OracleType.Float,22),
					new OracleParameter(":N_BDKPL5",OracleType.Float,22),
					new OracleParameter(":N_BDSX",OracleType.Float,22),
					new OracleParameter(":N_BQCZZ",OracleType.Float,22),
					new OracleParameter(":N_BQCZH",OracleType.Float,22),
					new OracleParameter(":N_BQCZK",OracleType.Float,22),
					new OracleParameter(":N_BQCHH",OracleType.Float,22),
					new OracleParameter(":N_BQCHZ",OracleType.Float,22),
					new OracleParameter(":N_BQCHK",OracleType.Float,22),
					new OracleParameter(":N_BQCKK",OracleType.Float,22),
					new OracleParameter(":N_BQCKZ",OracleType.Float,22),
					new OracleParameter(":N_BQCKH",OracleType.Float,22),
					new OracleParameter(":N_BQCSX",OracleType.Float,22),
					new OracleParameter(":N_HJPL",OracleType.Float,22),
					new OracleParameter(":N_HJGGCJ",OracleType.Float,22),
					new OracleParameter(":N_HJSX",OracleType.Float,22),
					new OracleParameter(":N_LDXSX", OracleType.Number,4),
					new OracleParameter(":N_RDXSX", OracleType.Number,4),
					new OracleParameter(":N_LDSSX", OracleType.Number,4),
					new OracleParameter(":N_RDSSX", OracleType.Number,4)};
        parameters[0].Value = model.N_ID;
        parameters[1].Value = model.N_LX;
        parameters[2].Value = model.N_ZWDATE;
        parameters[3].Value = model.N_GAMEDATE;
        parameters[4].Value = model.N_LMNO;
        parameters[5].Value = model.N_VISIT;
        parameters[6].Value = model.N_HOME;
        parameters[7].Value = model.N_VISIT_RESULT;
        parameters[8].Value = model.N_HOME_RESULT;
        parameters[9].Value = model.N_TSA;
        parameters[10].Value = model.N_TSB;
        parameters[11].Value = model.N_VISIT_NO;
        parameters[12].Value = model.N_HOME_NO;
        parameters[13].Value = model.N_SFZD;
        parameters[14].Value = model.N_SFXZ;
        parameters[15].Value = model.N_XZZT;
        parameters[16].Value = model.N_VH;
        parameters[17].Value = model.N_LOCK;
        parameters[18].Value = model.N_SF9J;
        parameters[19].Value = model.N_SFDS;
        parameters[20].Value = model.N_SFGP;
        parameters[21].Value = model.N_HYDZSX;
        parameters[22].Value = model.N_HYDCSX;
        parameters[23].Value = model.N_SFJZF;
        parameters[24].Value = model.N_ZBXH;
        parameters[25].Value = model.N_CBXH;
        parameters[26].Value = model.N_RFFS;
        parameters[27].Value = model.N_RFLX;
        parameters[28].Value = model.N_RFBL;
        parameters[29].Value = model.N_LRFPL;
        parameters[30].Value = model.N_RRFPL;
        parameters[31].Value = model.N_LRFCJ;
        parameters[32].Value = model.N_RRFCJ;
        parameters[33].Value = model.N_LRFSX;
        parameters[34].Value = model.N_RRFSX;
        parameters[35].Value = model.N_RFCJJE;
        parameters[36].Value = model.N_RFCJFS;
        parameters[37].Value = model.N_RFCJPL;
        parameters[38].Value = model.N_DXFS;
        parameters[39].Value = model.N_DXLX;
        parameters[40].Value = model.N_DXBL;
        parameters[41].Value = model.N_DXDPL;
        parameters[42].Value = model.N_DXXPL;
        parameters[43].Value = model.N_DXDCJ;
        parameters[44].Value = model.N_DXXCJ;
        parameters[45].Value = model.N_DXDCSX;
        parameters[46].Value = model.N_DXCJ;
        parameters[47].Value = model.N_DXCJPL;
        parameters[48].Value = model.N_LDYPL;
        parameters[49].Value = model.N_RDYPL;
        parameters[50].Value = model.N_LDYCJ;
        parameters[51].Value = model.N_RDYCJ;
        parameters[52].Value = model.N_LDYSX;
        parameters[53].Value = model.N_RDYSX;
        parameters[54].Value = model.N_DYCJ;
        parameters[55].Value = model.N_DYCJPL;
        parameters[56].Value = model.N_LSYPL;
        parameters[57].Value = model.N_RSYPL;
        parameters[58].Value = model.N_LSYCJ;
        parameters[59].Value = model.N_RSYCJ;
        parameters[60].Value = model.N_LSYSX;
        parameters[61].Value = model.N_RSYSX;
        parameters[62].Value = model.N_SYCJ;
        parameters[63].Value = model.N_SYCJPL;
        parameters[64].Value = model.N_DSDPL;
        parameters[65].Value = model.N_DSSPL;
        parameters[66].Value = model.N_DSDCJ;
        parameters[67].Value = model.N_DSSCJ;
        parameters[68].Value = model.N_DSDCSX;
        parameters[69].Value = model.N_DSCJ;
        parameters[70].Value = model.N_DSCJPL;
        parameters[71].Value = model.N_UP_VISIT_RESULT;
        parameters[72].Value = model.N_UP_HOME_RESULT;
        parameters[73].Value = model.N_VISIT_JZF;
        parameters[74].Value = model.N_HOME_JZF;
        parameters[75].Value = model.N_RF_OPEN;
        parameters[76].Value = model.N_DX_OPEN;
        parameters[77].Value = model.N_DY_OPEN;
        parameters[78].Value = model.N_SY_OPEN;
        parameters[79].Value = model.N_DS_OPEN;
        parameters[80].Value = model.N_RQ_OPEN;
        parameters[81].Value = model.N_BD_OPEN;
        parameters[82].Value = model.N_BQC_OPEN;
        parameters[83].Value = model.N_RF_GG;
        parameters[84].Value = model.N_DX_GG;
        parameters[85].Value = model.N_DY_GG;
        parameters[86].Value = model.N_SY_GG;
        parameters[87].Value = model.N_DS_GG;
        parameters[88].Value = model.N_LET;
        parameters[89].Value = model.N_RF_LOCK_V;
        parameters[90].Value = model.N_RF_LOCK_H;
        parameters[91].Value = model.N_DX_LOCK_V;
        parameters[92].Value = model.N_DX_LOCK_H;
        parameters[93].Value = model.N_DY_LOCK_V;
        parameters[94].Value = model.N_DY_LOCK_H;
        parameters[95].Value = model.N_SY_LOCK_V;
        parameters[96].Value = model.N_SY_LOCK_H;
        parameters[97].Value = model.N_DS_LOCK_V;
        parameters[98].Value = model.N_DS_LOCK_H;
        parameters[99].Value = model.N_REMARK;
        //parameters[97].Value = model.N_COUNTTIME;
        parameters[100].Value = model.N_SAMETEAM;
        //parameters[99].Value = model.N_GZFLAG;
        parameters[101].Value = model.N_RQSPL01;
        parameters[102].Value = model.N_RQSPL23;
        parameters[103].Value = model.N_RQSPL46;
        parameters[104].Value = model.N_RQSPL7;
        parameters[105].Value = model.N_RQSSX;
        parameters[106].Value = model.N_BDGPL00;
        parameters[107].Value = model.N_BDZPL10;
        parameters[108].Value = model.N_BDGPL11;
        parameters[109].Value = model.N_BDZPL20;
        parameters[110].Value = model.N_BDZPL21;
        parameters[111].Value = model.N_BDGPL22;
        parameters[112].Value = model.N_BDZPL30;
        parameters[113].Value = model.N_BDZPL31;
        parameters[114].Value = model.N_BDZPL32;
        parameters[115].Value = model.N_BDGPL33;
        parameters[116].Value = model.N_BDZPL41;
        parameters[117].Value = model.N_BDZPL40;
        parameters[118].Value = model.N_BDZPL42;
        parameters[119].Value = model.N_BDZPL43;
        parameters[120].Value = model.N_BDKPL10;
        parameters[121].Value = model.N_BDKPL20;
        parameters[122].Value = model.N_BDKPL21;
        parameters[123].Value = model.N_BDKPL30;
        parameters[124].Value = model.N_BDKPL31;
        parameters[125].Value = model.N_BDKPL32;
        parameters[126].Value = model.N_BDKPL40;
        parameters[127].Value = model.N_BDKPL41;
        parameters[128].Value = model.N_BDKPL42;
        parameters[129].Value = model.N_BDKPL43;
        parameters[130].Value = model.N_BDGPL44;
        parameters[131].Value = model.N_BDZPL5;
        parameters[132].Value = model.N_BDKPL5;
        parameters[133].Value = model.N_BDSX;
        parameters[134].Value = model.N_BQCZZ;
        parameters[135].Value = model.N_BQCZH;
        parameters[136].Value = model.N_BQCZK;
        parameters[137].Value = model.N_BQCHH;
        parameters[138].Value = model.N_BQCHZ;
        parameters[139].Value = model.N_BQCHK;
        parameters[140].Value = model.N_BQCKK;
        parameters[141].Value = model.N_BQCKZ;
        parameters[142].Value = model.N_BQCKH;
        parameters[143].Value = model.N_BQCSX;
        parameters[144].Value = model.N_HJPL;
        parameters[145].Value = model.N_HJGGCJ;
        parameters[146].Value = model.N_HJSX;
        parameters[147].Value = model.N_LDXSX;
        parameters[148].Value = model.N_RDXSX;
        parameters[149].Value = model.N_LDSSX;
        parameters[150].Value = model.N_RDSSX;

        o_aHt.Add(strSql, parameters);
    }
    /// <summary>
    /// 執行事物
    /// </summary>
    /// <param name="o_aHt"></param>
    public void SetTran(Hashtable o_aHt)
    {
        DbHelperOra.ExecuteSqlTran(o_aHt);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZQ(KFB_BASEBALL model, Hashtable o_aHt)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BASEBALL(");
        strSql.Append("N_ID,N_LX,N_ZWDATE,N_GAMEDATE,N_LMNO,N_VISIT,N_HOME,N_VISIT_RESULT,N_HOME_RESULT,N_TSA,N_TSB,N_VISIT_NO,N_HOME_NO,N_SFZD,N_SFXZ,N_XZZT,N_VH,N_LOCK,N_SF9J,N_SFDS,N_SFGP,N_HYDZSX,N_HYDCSX,N_SFJZF,N_ZBXH,N_CBXH,N_RFFS,N_RFLX,N_RFBL,N_LRFPL,N_RRFPL,N_LRFCJ,N_RRFCJ,N_LRFSX,N_RRFSX,N_RFCJJE,N_RFCJFS,N_RFCJPL,N_DXFS,N_DXLX,N_DXBL,N_DXDPL,N_DXXPL,N_DXDCJ,N_DXXCJ,N_DXDCSX,N_DXCJ,N_DXCJPL,N_LDYPL,N_RDYPL,N_LDYCJ,N_RDYCJ,N_LDYSX,N_RDYSX,N_DYCJ,N_DYCJPL,N_LSYPL,N_RSYPL,N_LSYCJ,N_RSYCJ,N_LSYSX,N_RSYSX,N_SYCJ,N_SYCJPL,N_DSDPL,N_DSSPL,N_DSDCJ,N_DSSCJ,N_DSDCSX,N_DSCJ,N_DSCJPL,N_UP_VISIT_RESULT,N_UP_HOME_RESULT,N_VISIT_JZF,N_HOME_JZF,N_RF_OPEN,N_DX_OPEN,N_DY_OPEN,N_SY_OPEN,N_DS_OPEN,N_RQ_OPEN,N_BD_OPEN,N_BQC_OPEN,N_RF_GG,N_DX_GG,N_DY_GG,N_SY_GG,N_DS_GG,N_LET,N_RF_LOCK_V,N_RF_LOCK_H,N_DX_LOCK_V,N_DX_LOCK_H,N_DY_LOCK_V,N_DY_LOCK_H,N_SY_LOCK_V,N_SY_LOCK_H,N_DS_LOCK_V,N_DS_LOCK_H,N_REMARK,N_SAMETEAM,N_RQSPL01,N_RQSPL23,N_RQSPL46,N_RQSPL7,N_RQSSX,N_BDGPL00,N_BDZPL10,N_BDGPL11,N_BDZPL20,N_BDZPL21,N_BDGPL22,N_BDZPL30,N_BDZPL31,N_BDZPL32,N_BDGPL33,N_BDZPL41,N_BDZPL40,N_BDZPL42,N_BDZPL43,N_BDKPL10,N_BDKPL20,N_BDKPL21,N_BDKPL30,N_BDKPL31,N_BDKPL32,N_BDKPL40,N_BDKPL41,N_BDKPL42,N_BDKPL43,N_BDGPL44,N_BDZPL5,N_BDKPL5,N_BDSX,N_BQCZZ,N_BQCZH,N_BQCZK,N_BQCHH,N_BQCHZ,N_BQCHK,N_BQCKK,N_BQCKZ,N_BQCKH,N_BQCSX,N_HJPL,N_HJGGCJ,N_HJSX,N_LDXSX,N_RDXSX,N_LDSSX,N_RDSSX)");
        strSql.Append(" values (");
        strSql.Append("EXAMPLE_SEQ.nextval,:N_LX,:N_ZWDATE,:N_GAMEDATE,:N_LMNO,:N_VISIT,:N_HOME,:N_VISIT_RESULT,:N_HOME_RESULT,:N_TSA,:N_TSB,:N_VISIT_NO,:N_HOME_NO,:N_SFZD,:N_SFXZ,:N_XZZT,:N_VH,:N_LOCK,:N_SF9J,:N_SFDS,:N_SFGP,:N_HYDZSX,:N_HYDCSX,:N_SFJZF,:N_ZBXH,:N_CBXH,:N_RFFS,:N_RFLX,:N_RFBL,:N_LRFPL,:N_RRFPL,:N_LRFCJ,:N_RRFCJ,:N_LRFSX,:N_RRFSX,:N_RFCJJE,:N_RFCJFS,:N_RFCJPL,:N_DXFS,:N_DXLX,:N_DXBL,:N_DXDPL,:N_DXXPL,:N_DXDCJ,:N_DXXCJ,:N_DXDCSX,:N_DXCJ,:N_DXCJPL,:N_LDYPL,:N_RDYPL,:N_LDYCJ,:N_RDYCJ,:N_LDYSX,:N_RDYSX,:N_DYCJ,:N_DYCJPL,:N_LSYPL,:N_RSYPL,:N_LSYCJ,:N_RSYCJ,:N_LSYSX,:N_RSYSX,:N_SYCJ,:N_SYCJPL,:N_DSDPL,:N_DSSPL,:N_DSDCJ,:N_DSSCJ,:N_DSDCSX,:N_DSCJ,:N_DSCJPL,:N_UP_VISIT_RESULT,:N_UP_HOME_RESULT,:N_VISIT_JZF,:N_HOME_JZF,:N_RF_OPEN,:N_DX_OPEN,:N_DY_OPEN,:N_SY_OPEN,:N_DS_OPEN,:N_RQ_OPEN,:N_BD_OPEN,:N_BQC_OPEN,:N_RF_GG,:N_DX_GG,:N_DY_GG,:N_SY_GG,:N_DS_GG,:N_LET,:N_RF_LOCK_V,:N_RF_LOCK_H,:N_DX_LOCK_V,:N_DX_LOCK_H,:N_DY_LOCK_V,:N_DY_LOCK_H,:N_SY_LOCK_V,:N_SY_LOCK_H,:N_DS_LOCK_V,:N_DS_LOCK_H,:N_REMARK,:N_SAMETEAM,:N_RQSPL01,:N_RQSPL23,:N_RQSPL46,:N_RQSPL7,:N_RQSSX,:N_BDGPL00,:N_BDZPL10,:N_BDGPL11,:N_BDZPL20,:N_BDZPL21,:N_BDGPL22,:N_BDZPL30,:N_BDZPL31,:N_BDZPL32,:N_BDGPL33,:N_BDZPL41,:N_BDZPL40,:N_BDZPL42,:N_BDZPL43,:N_BDKPL10,:N_BDKPL20,:N_BDKPL21,:N_BDKPL30,:N_BDKPL31,:N_BDKPL32,:N_BDKPL40,:N_BDKPL41,:N_BDKPL42,:N_BDKPL43,:N_BDGPL44,:N_BDZPL5,:N_BDKPL5,:N_BDSX,:N_BQCZZ,:N_BQCZH,:N_BQCZK,:N_BQCHH,:N_BQCHZ,:N_BQCHK,:N_BQCKK,:N_BQCKZ,:N_BQCKH,:N_BQCSX,:N_HJPL,:N_HJGGCJ,:N_HJSX,:N_LDXSX,:N_RDXSX,:N_LDSSX,:N_RDSSX)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_ZWDATE", OracleType.DateTime),
					new OracleParameter(":N_GAMEDATE", OracleType.DateTime),
					new OracleParameter(":N_LMNO", OracleType.Number,4),
					new OracleParameter(":N_VISIT", OracleType.Number,4),
					new OracleParameter(":N_HOME", OracleType.Number,4),
					new OracleParameter(":N_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_TSA", OracleType.VarChar,100),
					new OracleParameter(":N_TSB", OracleType.VarChar,100),
					new OracleParameter(":N_VISIT_NO", OracleType.Number,4),
					new OracleParameter(":N_HOME_NO", OracleType.Number,4),
					new OracleParameter(":N_SFZD", OracleType.Number,4),
					new OracleParameter(":N_SFXZ", OracleType.Number,4),
					new OracleParameter(":N_XZZT", OracleType.Number,4),
					new OracleParameter(":N_VH", OracleType.Number,4),
					new OracleParameter(":N_LOCK", OracleType.Number,4),
					new OracleParameter(":N_SF9J", OracleType.Number,4),
					new OracleParameter(":N_SFDS", OracleType.Number,4),
					new OracleParameter(":N_SFGP", OracleType.Number,4),
					new OracleParameter(":N_HYDZSX", OracleType.Number,4),
					new OracleParameter(":N_HYDCSX", OracleType.Number,4),
					new OracleParameter(":N_SFJZF", OracleType.Number,4),
					new OracleParameter(":N_ZBXH", OracleType.Number,4),
					new OracleParameter(":N_CBXH", OracleType.Number,4),
					new OracleParameter(":N_RFFS", OracleType.Number,4),
					new OracleParameter(":N_RFLX", OracleType.Number,4),
					new OracleParameter(":N_RFBL", OracleType.Number,4),
					new OracleParameter(":N_LRFPL", OracleType.Number,4),
					new OracleParameter(":N_RRFPL", OracleType.Number,4),
					new OracleParameter(":N_LRFCJ", OracleType.Number,4),
					new OracleParameter(":N_RRFCJ", OracleType.Number,4),
					new OracleParameter(":N_LRFSX", OracleType.Number,4),
					new OracleParameter(":N_RRFSX", OracleType.Number,4),
					new OracleParameter(":N_RFCJJE", OracleType.Number,4),
					new OracleParameter(":N_RFCJFS", OracleType.Number,4),
					new OracleParameter(":N_RFCJPL", OracleType.Number,4),
					new OracleParameter(":N_DXFS", OracleType.Number,4),
					new OracleParameter(":N_DXLX", OracleType.Number,4),
					new OracleParameter(":N_DXBL", OracleType.Number,4),
					new OracleParameter(":N_DXDPL", OracleType.Number,4),
					new OracleParameter(":N_DXXPL", OracleType.Number,4),
					new OracleParameter(":N_DXDCJ", OracleType.Number,4),
					new OracleParameter(":N_DXXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXDCSX", OracleType.Number,4),
					new OracleParameter(":N_DXCJ", OracleType.Number,4),
					new OracleParameter(":N_DXCJPL", OracleType.Number,4),
					new OracleParameter(":N_LDYPL", OracleType.Number,4),
					new OracleParameter(":N_RDYPL", OracleType.Number,4),
					new OracleParameter(":N_LDYCJ", OracleType.Number,4),
					new OracleParameter(":N_RDYCJ", OracleType.Number,4),
					new OracleParameter(":N_LDYSX", OracleType.Number,4),
					new OracleParameter(":N_RDYSX", OracleType.Number,4),
					new OracleParameter(":N_DYCJ", OracleType.Number,4),
					new OracleParameter(":N_DYCJPL", OracleType.Number,4),
					new OracleParameter(":N_LSYPL", OracleType.Number,4),
					new OracleParameter(":N_RSYPL", OracleType.Number,4),
					new OracleParameter(":N_LSYCJ", OracleType.Number,4),
					new OracleParameter(":N_RSYCJ", OracleType.Number,4),
					new OracleParameter(":N_LSYSX", OracleType.Number,4),
					new OracleParameter(":N_RSYSX", OracleType.Number,4),
					new OracleParameter(":N_SYCJ", OracleType.Number,4),
					new OracleParameter(":N_SYCJPL", OracleType.Number,4),
					new OracleParameter(":N_DSDPL", OracleType.Number,4),
					new OracleParameter(":N_DSSPL", OracleType.Number,4),
					new OracleParameter(":N_DSDCJ", OracleType.Number,4),
					new OracleParameter(":N_DSSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSDCSX", OracleType.Number,4),
					new OracleParameter(":N_DSCJ", OracleType.Number,4),
					new OracleParameter(":N_DSCJPL", OracleType.Number,4),
					new OracleParameter(":N_UP_VISIT_RESULT", OracleType.Number,4),
					new OracleParameter(":N_UP_HOME_RESULT", OracleType.Number,4),
					new OracleParameter(":N_VISIT_JZF", OracleType.Number,4),
					new OracleParameter(":N_HOME_JZF", OracleType.Number,4),
					new OracleParameter(":N_RF_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DX_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_SY_OPEN", OracleType.Number,4),
					new OracleParameter(":N_DS_OPEN", OracleType.Number,4),
					new OracleParameter(":N_RQ_OPEN", OracleType.Number,4),
					new OracleParameter(":N_BD_OPEN", OracleType.Number,4),
					new OracleParameter(":N_BQC_OPEN", OracleType.Number,4),
					new OracleParameter(":N_RF_GG", OracleType.Number,4),
					new OracleParameter(":N_DX_GG", OracleType.Number,4),
					new OracleParameter(":N_DY_GG", OracleType.Number,4),
					new OracleParameter(":N_SY_GG", OracleType.Number,4),
					new OracleParameter(":N_DS_GG", OracleType.Number,4),
					new OracleParameter(":N_LET", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_RF_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DX_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_SY_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_V", OracleType.Number,4),
					new OracleParameter(":N_DS_LOCK_H", OracleType.Number,4),
					new OracleParameter(":N_REMARK", OracleType.VarChar,100),
					//new OracleParameter(":N_COUNTTIME", OracleType.DateTime),
					new OracleParameter(":N_SAMETEAM", OracleType.VarChar,20),
					//new OracleParameter(":N_GZFLAG", OracleType.Number,4),
					new OracleParameter(":N_RQSPL01",OracleType.Float,22),
					new OracleParameter(":N_RQSPL23",OracleType.Float,22),
					new OracleParameter(":N_RQSPL46",OracleType.Float,22),
					new OracleParameter(":N_RQSPL7",OracleType.Float,22),
					new OracleParameter(":N_RQSSX",OracleType.Float,22),
					new OracleParameter(":N_BDGPL00",OracleType.Float,22),
					new OracleParameter(":N_BDZPL10",OracleType.Float,22),
					new OracleParameter(":N_BDGPL11",OracleType.Float,22),
					new OracleParameter(":N_BDZPL20",OracleType.Float,22),
					new OracleParameter(":N_BDZPL21",OracleType.Float,22),
					new OracleParameter(":N_BDGPL22",OracleType.Float,22),
					new OracleParameter(":N_BDZPL30",OracleType.Float,22),
					new OracleParameter(":N_BDZPL31",OracleType.Float,22),
					new OracleParameter(":N_BDZPL32",OracleType.Float,22),
					new OracleParameter(":N_BDGPL33",OracleType.Float,22),
					new OracleParameter(":N_BDZPL41",OracleType.Float,22),
					new OracleParameter(":N_BDZPL40",OracleType.Float,22),
					new OracleParameter(":N_BDZPL42",OracleType.Float,22),
					new OracleParameter(":N_BDZPL43",OracleType.Float,22),
					new OracleParameter(":N_BDKPL10",OracleType.Float,22),
					new OracleParameter(":N_BDKPL20",OracleType.Float,22),
					new OracleParameter(":N_BDKPL21",OracleType.Float,22),
					new OracleParameter(":N_BDKPL30",OracleType.Float,22),
					new OracleParameter(":N_BDKPL31",OracleType.Float,22),
					new OracleParameter(":N_BDKPL32",OracleType.Float,22),
					new OracleParameter(":N_BDKPL40",OracleType.Float,22),
					new OracleParameter(":N_BDKPL41",OracleType.Float,22),
					new OracleParameter(":N_BDKPL42",OracleType.Float,22),
					new OracleParameter(":N_BDKPL43",OracleType.Float,22),
					new OracleParameter(":N_BDGPL44",OracleType.Float,22),
					new OracleParameter(":N_BDZPL5",OracleType.Float,22),
					new OracleParameter(":N_BDKPL5",OracleType.Float,22),
					new OracleParameter(":N_BDSX",OracleType.Float,22),
					new OracleParameter(":N_BQCZZ",OracleType.Float,22),
					new OracleParameter(":N_BQCZH",OracleType.Float,22),
					new OracleParameter(":N_BQCZK",OracleType.Float,22),
					new OracleParameter(":N_BQCHH",OracleType.Float,22),
					new OracleParameter(":N_BQCHZ",OracleType.Float,22),
					new OracleParameter(":N_BQCHK",OracleType.Float,22),
					new OracleParameter(":N_BQCKK",OracleType.Float,22),
					new OracleParameter(":N_BQCKZ",OracleType.Float,22),
					new OracleParameter(":N_BQCKH",OracleType.Float,22),
					new OracleParameter(":N_BQCSX",OracleType.Float,22),
					new OracleParameter(":N_HJPL",OracleType.Float,22),
					new OracleParameter(":N_HJGGCJ",OracleType.Float,22),
					new OracleParameter(":N_HJSX",OracleType.Float,22),
					new OracleParameter(":N_LDXSX", OracleType.Number,4),
					new OracleParameter(":N_RDXSX", OracleType.Number,4),
					new OracleParameter(":N_LDSSX", OracleType.Number,4),
					new OracleParameter(":N_RDSSX", OracleType.Number,4)};
        parameters[0].Value = model.N_LX;
        parameters[1].Value = model.N_ZWDATE;
        parameters[2].Value = model.N_GAMEDATE;
        parameters[3].Value = model.N_LMNO;
        parameters[4].Value = model.N_VISIT;
        parameters[5].Value = model.N_HOME;
        parameters[6].Value = model.N_VISIT_RESULT;
        parameters[7].Value = model.N_HOME_RESULT;
        parameters[8].Value = model.N_TSA;
        parameters[9].Value = model.N_TSB;
        parameters[10].Value = model.N_VISIT_NO;
        parameters[11].Value = model.N_HOME_NO;
        parameters[12].Value = model.N_SFZD;
        parameters[13].Value = model.N_SFXZ;
        parameters[14].Value = model.N_XZZT;
        parameters[15].Value = model.N_VH;
        parameters[16].Value = model.N_LOCK;
        parameters[17].Value = model.N_SF9J;
        parameters[18].Value = model.N_SFDS;
        parameters[19].Value = model.N_SFGP;
        parameters[20].Value = model.N_HYDZSX;
        parameters[21].Value = model.N_HYDCSX;
        parameters[22].Value = model.N_SFJZF;
        parameters[23].Value = model.N_ZBXH;
        parameters[24].Value = model.N_CBXH;
        parameters[25].Value = model.N_RFFS;
        parameters[26].Value = model.N_RFLX;
        parameters[27].Value = model.N_RFBL;
        parameters[28].Value = model.N_LRFPL;
        parameters[29].Value = model.N_RRFPL;
        parameters[30].Value = model.N_LRFCJ;
        parameters[31].Value = model.N_RRFCJ;
        parameters[32].Value = model.N_LRFSX;
        parameters[33].Value = model.N_RRFSX;
        parameters[34].Value = model.N_RFCJJE;
        parameters[35].Value = model.N_RFCJFS;
        parameters[36].Value = model.N_RFCJPL;
        parameters[37].Value = model.N_DXFS;
        parameters[38].Value = model.N_DXLX;
        parameters[39].Value = model.N_DXBL;
        parameters[40].Value = model.N_DXDPL;
        parameters[41].Value = model.N_DXXPL;
        parameters[42].Value = model.N_DXDCJ;
        parameters[43].Value = model.N_DXXCJ;
        parameters[44].Value = model.N_DXDCSX;
        parameters[45].Value = model.N_DXCJ;
        parameters[46].Value = model.N_DXCJPL;
        parameters[47].Value = model.N_LDYPL;
        parameters[48].Value = model.N_RDYPL;
        parameters[49].Value = model.N_LDYCJ;
        parameters[50].Value = model.N_RDYCJ;
        parameters[51].Value = model.N_LDYSX;
        parameters[52].Value = model.N_RDYSX;
        parameters[53].Value = model.N_DYCJ;
        parameters[54].Value = model.N_DYCJPL;
        parameters[55].Value = model.N_LSYPL;
        parameters[56].Value = model.N_RSYPL;
        parameters[57].Value = model.N_LSYCJ;
        parameters[58].Value = model.N_RSYCJ;
        parameters[59].Value = model.N_LSYSX;
        parameters[60].Value = model.N_RSYSX;
        parameters[61].Value = model.N_SYCJ;
        parameters[62].Value = model.N_SYCJPL;
        parameters[63].Value = model.N_DSDPL;
        parameters[64].Value = model.N_DSSPL;
        parameters[65].Value = model.N_DSDCJ;
        parameters[66].Value = model.N_DSSCJ;
        parameters[67].Value = model.N_DSDCSX;
        parameters[68].Value = model.N_DSCJ;
        parameters[69].Value = model.N_DSCJPL;
        parameters[70].Value = model.N_UP_VISIT_RESULT;
        parameters[71].Value = model.N_UP_HOME_RESULT;
        parameters[72].Value = model.N_VISIT_JZF;
        parameters[73].Value = model.N_HOME_JZF;
        parameters[74].Value = model.N_RF_OPEN;
        parameters[75].Value = model.N_DX_OPEN;
        parameters[76].Value = model.N_DY_OPEN;
        parameters[77].Value = model.N_SY_OPEN;
        parameters[78].Value = model.N_DS_OPEN;
        parameters[79].Value = model.N_RQ_OPEN;
        parameters[80].Value = model.N_BD_OPEN;
        parameters[81].Value = model.N_BQC_OPEN;
        parameters[82].Value = model.N_RF_GG;
        parameters[83].Value = model.N_DX_GG;
        parameters[84].Value = model.N_DY_GG;
        parameters[85].Value = model.N_SY_GG;
        parameters[86].Value = model.N_DS_GG;
        parameters[87].Value = model.N_LET;
        parameters[88].Value = model.N_RF_LOCK_V;
        parameters[89].Value = model.N_RF_LOCK_H;
        parameters[90].Value = model.N_DX_LOCK_V;
        parameters[91].Value = model.N_DX_LOCK_H;
        parameters[92].Value = model.N_DY_LOCK_V;
        parameters[93].Value = model.N_DY_LOCK_H;
        parameters[94].Value = model.N_SY_LOCK_V;
        parameters[95].Value = model.N_SY_LOCK_H;
        parameters[96].Value = model.N_DS_LOCK_V;
        parameters[97].Value = model.N_DS_LOCK_H;
        parameters[98].Value = model.N_REMARK;
        parameters[99].Value = model.N_SAMETEAM;
        parameters[100].Value = model.N_RQSPL01;
        parameters[101].Value = model.N_RQSPL23;
        parameters[102].Value = model.N_RQSPL46;
        parameters[103].Value = model.N_RQSPL7;
        parameters[104].Value = model.N_RQSSX;
        parameters[105].Value = model.N_BDGPL00;
        parameters[106].Value = model.N_BDZPL10;
        parameters[107].Value = model.N_BDGPL11;
        parameters[108].Value = model.N_BDZPL20;
        parameters[109].Value = model.N_BDZPL21;
        parameters[110].Value = model.N_BDGPL22;
        parameters[111].Value = model.N_BDZPL30;
        parameters[112].Value = model.N_BDZPL31;
        parameters[113].Value = model.N_BDZPL32;
        parameters[114].Value = model.N_BDGPL33;
        parameters[115].Value = model.N_BDZPL41;
        parameters[116].Value = model.N_BDZPL40;
        parameters[117].Value = model.N_BDZPL42;
        parameters[118].Value = model.N_BDZPL43;
        parameters[119].Value = model.N_BDKPL10;
        parameters[120].Value = model.N_BDKPL20;
        parameters[121].Value = model.N_BDKPL21;
        parameters[122].Value = model.N_BDKPL30;
        parameters[123].Value = model.N_BDKPL31;
        parameters[124].Value = model.N_BDKPL32;
        parameters[125].Value = model.N_BDKPL40;
        parameters[126].Value = model.N_BDKPL41;
        parameters[127].Value = model.N_BDKPL42;
        parameters[128].Value = model.N_BDKPL43;
        parameters[129].Value = model.N_BDGPL44;
        parameters[130].Value = model.N_BDZPL5;
        parameters[131].Value = model.N_BDKPL5;
        parameters[132].Value = model.N_BDSX;
        parameters[133].Value = model.N_BQCZZ;
        parameters[134].Value = model.N_BQCZH;
        parameters[135].Value = model.N_BQCZK;
        parameters[136].Value = model.N_BQCHH;
        parameters[137].Value = model.N_BQCHZ;
        parameters[138].Value = model.N_BQCHK;
        parameters[139].Value = model.N_BQCKK;
        parameters[140].Value = model.N_BQCKZ;
        parameters[141].Value = model.N_BQCKH;
        parameters[142].Value = model.N_BQCSX;
        parameters[143].Value = model.N_HJPL;
        parameters[144].Value = model.N_HJGGCJ;
        parameters[145].Value = model.N_HJSX;
        parameters[146].Value = model.N_LDXSX;
        parameters[147].Value = model.N_RDXSX;
        parameters[148].Value = model.N_LDSSX;
        parameters[149].Value = model.N_RDSSX;
        o_aHt.Add(strSql, parameters);
    }
    /// <summary>
    /// 判斷賽事是否下注
    /// </summary>
    /// <param name="N_ID"></param>
    /// <returns></returns>
    public bool ExistsZD(int N_ID)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from KFB_PTZD");
        strSql.Append(" where N_QSBH=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4)};
        parameters[0].Value = N_ID;

        return DbHelperOra.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 删除一条数据
    /// </summary>
    public void Delete(int N_ID)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete KFB_BASEBALL ");
        strSql.Append(" where N_ID=:N_ID ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_ID", OracleType.Number,4)};
        parameters[0].Value = N_ID;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

}
