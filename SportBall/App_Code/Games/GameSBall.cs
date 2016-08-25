using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


public class GameSBall
{
    private readonly GamesDB dal = null;
    public GameSBall()
    {
        dal = new GamesDB();
    }
    public GameSBall(int threadCount)
    {
        dal = new GamesDB(threadCount);
    }
    private readonly Type ms_LockType = typeof(GameSBall);

    #region 会员端
    /// <summary>
    /// 足球单式2和早餐0
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientFootBallSigleList(List<int> selectedAllianceList, int courtType, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.GetClientGameList("b_zq", selectedAllianceList, courtType, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL+rateGap,  /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL+rateGap, /*25*/
                    model.N_RRFPL+rateGap, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL+rateGap, /*33*/
                    model.N_DXXPL+rateGap, /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL+rateGap, /*38*/
                    model.N_RDYPL+rateGap, /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //和局            
                    model.N_HJPL2+rateGap,          /*43*/
                    //让分                 
                    model.N_RFLX2,          /*44*/
                    model.N_RFFS2,          /*45*/
                    model.N_RFBL2,          /*46*/
                    model.N_LRFPL2+rateGap, /*47*/
                    model.N_RRFPL2+rateGap, /*48*/
                    model.N_RF_OPEN2,       /*49*/
                    model.N_RF_LOCK_V2,     /*50*/
                    model.N_RF_LOCK_H2,     /*51*/
                    //大小                 
                    model.N_DXLX2,          /*52*/
                    model.N_DXFS2,          /*53*/
                    model.N_DXBL2,          /*54*/
                    model.N_DXDPL2+rateGap, /*55*/
                    model.N_DXXPL2+rateGap, /*56*/
                    model.N_DX_OPEN2,       /*57*/
                    model.N_DX_LOCK_V2,     /*58*/
                    model.N_DX_LOCK_H2,     /*59*/
                    //赌赢                 
                    model.N_LDYPL2+rateGap, /*60*/
                    model.N_RDYPL2+rateGap, /*61*/
                    model.N_DY_OPEN2,       /*62*/
                    model.N_DY_LOCK_V2,     /*63*/
                    model.N_DY_LOCK_H2,     /*64*/
                    
                    model.N_ID2,            /*65*/
                    model.N_LET2,           /*66*/
                    model.N_VISIT2,         /*67*/ 
                    model.N_HOME2           /*68*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientOtherBallPassList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 足球走地
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientFootBallGotoList(List<int> selectedAllianceList, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.GetClientGameList("b_zq", selectedAllianceList, 0, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    //model.N_HOME_JZF,      /*16*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //model.N_VISIT_JZF,     /*21*/
                    model.N_HJPL+rateGap,          /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL+rateGap, /*25*/
                    model.N_RRFPL+rateGap, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL+rateGap, /*33*/
                    model.N_DXXPL+rateGap, /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL+rateGap, /*38*/
                    model.N_RDYPL+rateGap, /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //和局            
                    model.N_HJPL2+rateGap,         /*43*/
                    //让分                 
                    model.N_RFLX2,          /*44*/
                    model.N_RFFS2,          /*45*/
                    model.N_RFBL2,          /*46*/
                    model.N_LRFPL2+rateGap, /*47*/
                    model.N_RRFPL2+rateGap, /*48*/
                    model.N_RF_OPEN2,       /*49*/
                    model.N_RF_LOCK_V2,     /*50*/
                    model.N_RF_LOCK_H2,     /*51*/
                    //大小                 
                    model.N_DXLX2,          /*52*/
                    model.N_DXFS2,          /*53*/
                    model.N_DXBL2,          /*54*/
                    model.N_DXDPL2+rateGap, /*55*/
                    model.N_DXXPL2+rateGap, /*56*/
                    model.N_DX_OPEN2,       /*57*/
                    model.N_DX_LOCK_V2,     /*58*/
                    model.N_DX_LOCK_H2,     /*59*/
                    //赌赢                 
                    model.N_LDYPL2+rateGap, /*60*/
                    model.N_RDYPL2+rateGap, /*61*/
                    model.N_DY_OPEN2,       /*62*/
                    model.N_DY_LOCK_V2,     /*63*/
                    model.N_DY_LOCK_H2,     /*64*/
                    
                    model.N_ID2,            /*65*/
                    model.N_LET2,           /*66*/
                    model.N_VISIT_JZF,      /*67*/
                    model.N_HOME_JZF,       /*68*/
                    //model.N_ZDTIME,         /*69*/
                    GetZDTime(model.N_ZDTIME,model.N_ZDFLAG,model.N_ZDUPTIME.Value),/*69*/
                    model.N_ZDFLAG,         /*70*/
                    model.N_ZDUPTIME,       /*71*/
                    
                    model.N_VISIT2,         /*72*/ 
                    model.N_HOME2,           /*73*/
                    
                    model.N_VISIT_REDCARD,         /*74*/ 
                    model.N_HOME_REDCARD           /*75*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientFootBallGotoList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    private string GetZDTime(string strZDTime, string strZDFlag, DateTime dZDUPTime)
    {
        string strReturn = "";
        if (strZDTime == "ZC")
            strReturn = "中场";
        else
        {
            if (strZDFlag == "Y")
                strReturn = strZDTime;
            else
            {
                DateTime d1 = System.DateTime.Now;
                DateTime d2 = dZDUPTime;
                TimeSpan d3 = d2.Subtract(d1);
                strReturn = Convert.ToString(d3.Minutes + Convert.ToInt32(strZDTime));
            }
        }
        return strReturn;
    }
    /// <summary>
    /// 足球过关
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientFootBallPassList(List<int> selectedAllianceList, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.GetClientGameList("b_zq", selectedAllianceList, 1, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_HJPL+rateGap,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    model.N_HJGGCJ,        /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL+rateGap, /*25*/
                    model.N_RRFPL+rateGap, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    model.N_RF_GG,         /*30*/
                    model.N_LRFCJ,         /*31*/
                    model.N_RRFCJ,         /*32*/
                    //大小                 
                    model.N_DXLX,          /*33*/
                    model.N_DXFS,          /*34*/
                    model.N_DXBL,          /*35*/
                    model.N_DXDPL+rateGap, /*36*/
                    model.N_DXXPL+rateGap, /*37*/
                    model.N_DX_OPEN,       /*38*/
                    model.N_DX_LOCK_V,     /*39*/
                    model.N_DX_LOCK_H,     /*40*/
                    model.N_DX_GG,         /*41*/
                    model.N_DXDCJ,         /*42*/
                    model.N_DXXCJ,         /*43*/
                    //单双                 
                    model.N_DSDPL+rateGap, /*44*/
                    model.N_DSSPL+rateGap, /*45*/
                    model.N_DS_OPEN,       /*46*/
                    model.N_DS_LOCK_V,     /*47*/
                    model.N_DS_LOCK_H,     /*48*/
                    model.N_DS_GG,         /*49*/
                    model.N_DSDCJ,         /*50*/
                    model.N_DSSCJ,         /*51*/
                    //赌赢                 
                    model.N_LDYPL+rateGap, /*52*/
                    model.N_RDYPL+rateGap, /*53*/
                    model.N_DY_OPEN,       /*54*/
                    model.N_DY_LOCK_V,     /*55*/
                    model.N_DY_LOCK_H,     /*56*/
                    model.N_DY_GG,         /*57*/
                    model.N_LDYCJ,         /*58*/
                    model.N_RDYCJ,         /*59*/
                    model.N_SAMETEAM,      /*60*/
                    GetCode(model,"RF","L",1,rateGap),/*61*/
                    GetCode(model,"RF","R",1,rateGap),/*62*/
                    GetCode(model,"DX","L",1,rateGap),/*63*/
                    GetCode(model,"DX","R",1,rateGap),/*64*/
                    GetCode(model,"DY","L",1,rateGap),/*65*/
                    GetCode(model,"DY","R",1,rateGap),/*66*/
                    GetCode(model,"HJ","LR",1,rateGap),/*67*/
                    GetCode(model,"DS","L",1,rateGap),/*68*/
                    GetCode(model,"DS","R",1,rateGap) /*69*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientFootBallPassList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 足球波胆
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientFootBallWaveList(List<int> selectedAllianceList, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;

            List<KFB_BALL> gameList = dal.GetClientGameList("b_zq", selectedAllianceList, 1, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_VISIT_NO,      /*16*/
                    model.N_HOME_NO,       /*17*/
                    model.N_VH,            /*18*/
                    model.N_REMARK,        /*19*/

                    model.N_BD_OPEN,       /*20*/
                    model.N_BDGPL00+rateGap,       /*21*/
                    model.N_BDGPL11+rateGap,       /*22*/
                    model.N_BDGPL22+rateGap,       /*23*/
                    model.N_BDGPL33+rateGap,       /*24*/
                    model.N_BDGPL44+rateGap,       /*25*/
                    model.N_BDKPL10+rateGap,       /*26*/
                    model.N_BDKPL20+rateGap,       /*27*/
                    model.N_BDKPL21+rateGap,       /*28*/
                    model.N_BDKPL30+rateGap,       /*29*/
                    model.N_BDKPL31+rateGap,       /*30*/
                    model.N_BDKPL32+rateGap,       /*31*/
                    model.N_BDKPL40+rateGap,       /*32*/
                    model.N_BDKPL41+rateGap,       /*33*/
                    model.N_BDKPL42+rateGap,       /*34*/
                    model.N_BDKPL43+rateGap,       /*35*/
                    model.N_BDKPL5+rateGap,        /*36*/
                    model.N_BDZPL10+rateGap,       /*37*/
                    model.N_BDZPL20+rateGap,       /*38*/
                    model.N_BDZPL21+rateGap,       /*39*/
                    model.N_BDZPL30+rateGap,       /*40*/
                    model.N_BDZPL31+rateGap,       /*41*/
                    model.N_BDZPL32+rateGap,       /*42*/
                    model.N_BDZPL40+rateGap,       /*43*/
                    model.N_BDZPL41+rateGap,       /*44*/
                    model.N_BDZPL42+rateGap,       /*45*/
                    model.N_BDZPL43+rateGap,       /*46*/
                    model.N_BDZPL5+rateGap         /*47*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientFootBallWaveList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 足球半全场
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientFootBallHalfFullList(List<int> selectedAllianceList, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.GetClientGameList("b_zq", selectedAllianceList, 1, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_VISIT_NO,      /*16*/
                    model.N_HOME_NO,       /*17*/
                    model.N_VH,            /*18*/
                    model.N_REMARK,        /*19*/

                    model.N_BQC_OPEN,      /*20*/
                    model.N_BQCHH+rateGap,        /*21*/
                    model.N_BQCHK+rateGap,        /*22*/
                    model.N_BQCHZ+rateGap,        /*23*/
                    model.N_BQCKH+rateGap,        /*24*/
                    model.N_BQCKK+rateGap,        /*25*/
                    model.N_BQCKZ+rateGap,        /*26*/
                    model.N_BQCZH+rateGap,        /*27*/
                    model.N_BQCZK+rateGap,        /*28*/
                    model.N_BQCZZ+rateGap        /*29*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientFootBallHalfFullList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 足球入球数
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientFootBallGoalList(List<int> selectedAllianceList, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;

            List<KFB_BALL> gameList = dal.GetClientGameList("b_zq", selectedAllianceList, 1, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_VISIT_NO,      /*16*/
                    model.N_HOME_NO,       /*17*/
                    model.N_VH,            /*18*/
                    model.N_REMARK,        /*19*/

                    model.N_RQ_OPEN,       /*20*/
                    model.N_RQSPL01+rateGap,       /*21*/
                    model.N_RQSPL23+rateGap,       /*22*/
                    model.N_RQSPL46+rateGap,       /*23*/
                    model.N_RQSPL7+rateGap,        /*24*/
                    model.N_DSDPL+rateGap,         /*25*/
                    model.N_DSSPL+rateGap          /*26*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientFootBallGoalList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }

    /// <summary>
    /// 其他球单式或早餐
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientOtherBallSigleList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.GetClientGameList(ballType, selectedAllianceList, courtType, OrderName, String.Empty, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL,          /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,         /*25*/
                    model.N_RRFPL,         /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL,         /*33*/
                    model.N_DXXPL,         /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL,         /*38*/
                    model.N_RDYPL,         /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //一输二赢
                    model.N_LSYPL,         /*43*/
                    model.N_RSYPL,         /*44*/
                    model.N_SY_OPEN,       /*45*/
                    model.N_SY_LOCK_V,     /*46*/
                    model.N_SY_LOCK_H,     /*47*/
                    //单双                 
                    model.N_DSDPL,         /*48*/
                    model.N_DSSPL,         /*49*/
                    model.N_DS_OPEN,       /*50*/
                    model.N_DS_LOCK_V,     /*51*/
                    model.N_DS_LOCK_H      /*52*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientOtherBallSigleList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 其他球走地
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientOtherBallGotoList(string ballType, List<int> selectedAllianceList, string OrderName, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.GetClientGameList(ballType, selectedAllianceList, 0, OrderName, String.Empty, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_HOME_JZF,      /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    model.N_VISIT_JZF,     /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,         /*25*/
                    model.N_RRFPL,         /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL,         /*33*/
                    model.N_DXXPL,         /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/

                    model.N_ZDTIME,         /*38*/
                    model.N_ZDFLAG,         /*39*/
                    model.N_ZDUPTIME        /*40*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientOtherBallGotoList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 其他球过关
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetClientOtherBallPassList(string ballType, List<int> selectedAllianceList, string OrderName, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.GetClientGameList(ballType, selectedAllianceList, 1, OrderName, String.Empty, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_HJPL,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    model.N_HJGGCJ,        /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,         /*25*/
                    model.N_RRFPL,         /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    model.N_RF_GG,         /*30*/
                    model.N_LRFCJ,         /*31*/
                    model.N_RRFCJ,         /*32*/
                    //大小                 
                    model.N_DXLX,          /*33*/
                    model.N_DXFS,          /*34*/
                    model.N_DXBL,          /*35*/
                    model.N_DXDPL,         /*36*/
                    model.N_DXXPL,         /*37*/
                    model.N_DX_OPEN,       /*38*/
                    model.N_DX_LOCK_V,     /*39*/
                    model.N_DX_LOCK_H,     /*40*/
                    model.N_DX_GG,         /*41*/
                    model.N_DXDCJ,         /*42*/
                    model.N_DXXCJ,         /*43*/
                    //单双                 
                    model.N_DSDPL,         /*44*/
                    model.N_DSSPL,         /*45*/
                    model.N_DS_OPEN,       /*46*/
                    model.N_DS_LOCK_V,     /*47*/
                    model.N_DS_LOCK_H,     /*48*/
                    model.N_DS_GG,         /*49*/
                    model.N_DSDCJ,         /*50*/
                    model.N_DSSCJ,         /*51*/
                    //赌赢                 
                    model.N_LDYPL,         /*52*/
                    model.N_RDYPL,         /*53*/
                    model.N_DY_OPEN,       /*54*/
                    model.N_DY_LOCK_V,     /*55*/
                    model.N_DY_LOCK_H,     /*56*/
                    model.N_DY_GG,         /*57*/
                    model.N_LDYCJ,         /*58*/
                    model.N_RDYCJ,         /*59*/

                    model.N_SAMETEAM,      /*60*/
                   
                    //一输二赢                 
                    //model.N_LSYPL,         /*61*/
                    //model.N_RSYPL,         /*62*/
                    //model.N_SY_OPEN,       /*63*/
                    //model.N_SY_LOCK_V,     /*64*/
                    //model.N_SY_LOCK_H,     /*65*/
                    //model.N_SY_GG,         /*66*/
                    //model.N_LSYCJ,         /*67*/
                    //model.N_RSYCJ,         /*68*/
                    GetCode(model,"RF","L",1,rateGap),/*61*/
                    GetCode(model,"RF","R",1,rateGap),/*62*/
                    GetCode(model,"DX","L",1,rateGap),/*63*/
                    GetCode(model,"DX","R",1,rateGap),/*64*/
                    GetCode(model,"DY","L",1,rateGap),/*65*/
                    GetCode(model,"DY","R",1,rateGap),/*66*/
                    GetCode(model,"HJ","LR",1,rateGap),/*67*/
                    GetCode(model,"DS","L",1,rateGap),/*68*/
                    GetCode(model,"DS","R",1,rateGap), /*69*/
                    GetCode(model,"SY","L",1,rateGap),/*70*/
                    GetCode(model,"SY","R",1,rateGap) /*71*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientOtherBallPassList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }

    /// <summary>
    /// 比赛结果
    /// </summary>
    /// <param name="ballType">球类型</param>
    /// <param name="selectedAllianceList">联盟</param>
    /// <param name="accDate">帐务日期</param>
    /// <param name="pageIndex">分页索引</param>
    /// <param name="pageSize">分页笔数</param>
    /// <param name="recordCount">总笔数</param>
    /// <param name="allianceModelList">联盟model</param>
    /// <param name="sysAccDate">返回日期</param>
    /// <returns></returns>
    public List<object[]> GetClientResultList(string ballType, string[] alliance, string accDate, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string sysAccDate)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            List<KFB_BALL> gameList = dal.GetClientResultList(ballType, alliance, accDate, pageIndex, pageSize, out recordCount, out allianceModelList, out sysAccDate);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_LX,                /*00*/
                    model.N_ID,                /*01*/
                    model.N_GAMEDATE,          /*02*/
                    model.N_LMNO,              /*03*/
                    model.N_VISIT,             /*04*/
                    model.N_HOME,              /*05*/
                    model.N_VISIT_NAME,        /*06*/
                    model.N_HOME_NAME,         /*07*/
                    model.N_CBXH,              /*08*/
                    model.N_SAMEGAME,          /*09*/
                    model.N_LET,               /*10*/
                    model.N_VISIT_NO,          /*11*/
                    model.N_HOME_NO,           /*12*/
                    model.N_VH,                /*13*/
                    model.N_VISIT_RESULT,      /*14*/
                    model.N_HOME_RESULT,       /*15*/
                    model.N_UP_VISIT_RESULT,   /*16*/
                    model.N_UP_HOME_RESULT,    /*17*/
                    model.N_REMARK             /*18*/
                };
                result.Add(objList);
            });
            return result;
        }
        catch (Exception ex)
        {
            SaveMes(ex.Message, "", "GetClientResultList");
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    #endregion

    #region 管理端
    /// <summary>
    /// 足球单式2和早餐0
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyFootBallSigleList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,              /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL,  /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL, /*25*/
                    model.N_RRFPL, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL, /*33*/
                    model.N_DXXPL, /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL, /*38*/
                    model.N_RDYPL, /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //单双                 
                    model.N_DSDPL,         /*43*/
                    model.N_DSSPL,         /*44*/
                    model.N_DS_OPEN,       /*45*/
                    model.N_DS_LOCK_V,     /*46*/
                    model.N_DS_LOCK_H,     /*47*/
                    GetCountAndSum(model,"l_rf","L",billDic), /*48*/
                    GetCountAndSum(model,"l_rf","R",billDic), /*49*/
                    GetCountAndSum(model,"l_dx","L",billDic), /*50*/
                    GetCountAndSum(model,"l_dx","R",billDic), /*51*/
                    GetCountAndSum(model,"l_dy","L",billDic), /*52*/
                    GetCountAndSum(model,"l_dy","R",billDic), /*53*/
                    GetCountAndSum(model,"l_hj","LR",billDic), /*54*/
                    GetCountAndSum(model,"l_ds","R",billDic), /*55*/
                    GetCountAndSum(model,"l_ds","L",billDic)  /*56*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 足球走地
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyFootBallGotoList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,              /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    model.N_HJPL,          /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,          /*25*/
                    model.N_RRFPL,          /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL,          /*33*/
                    model.N_DXXPL,          /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL,          /*38*/
                    model.N_RDYPL,          /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/

                    GetCountAndSum(model,"l_zdrf","L",billDic),/*43*/
                    GetCountAndSum(model,"l_zdrf","R",billDic),/*44*/
                    GetCountAndSum(model,"l_zddx","L",billDic),/*45*/
                    GetCountAndSum(model,"l_zddx","R",billDic),/*46*/
                    GetCountAndSum(model,"l_zddy","L",billDic),/*47*/
                    GetCountAndSum(model,"l_zddy","R",billDic),/*48*/
                    GetCountAndSum(model,"l_zdhj","LR",billDic),/*49*/
                    
                    model.N_VISIT_JZF,                                              /*50*/
                    model.N_HOME_JZF,                                               /*51*/
                    GetZDTime(model.N_ZDTIME,model.N_ZDFLAG,model.N_ZDUPTIME.Value),/*52*/
                    model.N_ZDFLAG,                                                 /*53*/
                    model.N_ZDUPTIME                                                /*54*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 足球过关
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyFootBallPassList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_HJPL,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    model.N_HJGGCJ,        /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL, /*25*/
                    model.N_RRFPL, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    model.N_RF_GG,         /*30*/
                    model.N_LRFCJ,         /*31*/
                    model.N_RRFCJ,         /*32*/
                    //大小                 
                    model.N_DXLX,          /*33*/
                    model.N_DXFS,          /*34*/
                    model.N_DXBL,          /*35*/
                    model.N_DXDPL, /*36*/
                    model.N_DXXPL, /*37*/
                    model.N_DX_OPEN,       /*38*/
                    model.N_DX_LOCK_V,     /*39*/
                    model.N_DX_LOCK_H,     /*40*/
                    model.N_DX_GG,         /*41*/
                    model.N_DXDCJ,         /*42*/
                    model.N_DXXCJ,         /*43*/
                    //赌赢                 
                    model.N_LDYPL,         /*44*/
                    model.N_RDYPL,         /*45*/
                    model.N_DY_OPEN,       /*46*/
                    model.N_DY_LOCK_V,     /*47*/
                    model.N_DY_LOCK_H,     /*48*/
                    model.N_DY_GG,         /*49*/
                    model.N_LDYCJ,         /*50*/
                    model.N_RDYCJ,         /*51*/
                    //单双                 
                    model.N_DSDPL,         /*52*/
                    model.N_DSSPL,         /*53*/
                    model.N_DS_OPEN,       /*54*/
                    model.N_DS_LOCK_V,     /*55*/
                    model.N_DS_LOCK_H,     /*56*/
                    model.N_DS_GG,         /*57*/
                    model.N_DSDCJ,         /*58*/
                    model.N_DSSCJ,         /*59*/
                    
                    model.N_SAMETEAM,      /*60*/
                    GetCountAndSum(model,"l_rf","L",billDic),/*61*/
                    GetCountAndSum(model,"l_rf","R",billDic),/*62*/
                    GetCountAndSum(model,"l_dx","L",billDic),/*63*/
                    GetCountAndSum(model,"l_dx","R",billDic),/*64*/
                    GetCountAndSum(model,"l_dy","L",billDic),/*65*/
                    GetCountAndSum(model,"l_dy","R",billDic),/*66*/
                    GetCountAndSum(model,"l_hj","LR",billDic),/*67*/
                    GetCountAndSum(model,"l_ds","L",billDic),/*68*/
                    GetCountAndSum(model,"l_ds","R",billDic)/*69*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 足球波胆
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyFootBallWaveList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_VISIT_NO,      /*16*/
                    model.N_HOME_NO,       /*17*/
                    model.N_REMARK,        /*18*/
                    model.N_VH,            /*19*/

                    model.N_BD_OPEN,       /*20*/
                    model.N_BDGPL00,       /*21*/
                    model.N_BDGPL11,       /*22*/
                    model.N_BDGPL22,       /*23*/
                    model.N_BDGPL33,       /*24*/
                    model.N_BDGPL44,       /*25*/
                    model.N_BDKPL10,       /*26*/
                    model.N_BDKPL20,       /*27*/
                    model.N_BDKPL21,       /*28*/
                    model.N_BDKPL30,       /*29*/
                    model.N_BDKPL31,       /*30*/
                    model.N_BDKPL32,       /*31*/
                    model.N_BDKPL40,       /*32*/
                    model.N_BDKPL41,       /*33*/
                    model.N_BDKPL42,       /*34*/
                    model.N_BDKPL43,       /*35*/
                    model.N_BDKPL5,        /*36*/
                    model.N_BDZPL10,       /*37*/
                    model.N_BDZPL20,       /*38*/
                    model.N_BDZPL21,       /*39*/
                    model.N_BDZPL30,       /*40*/
                    model.N_BDZPL31,       /*41*/
                    model.N_BDZPL32,       /*42*/
                    model.N_BDZPL40,       /*43*/
                    model.N_BDZPL41,       /*44*/
                    model.N_BDZPL42,       /*45*/
                    model.N_BDZPL43,       /*46*/
                    model.N_BDZPL5,         /*47*/
                    GetCountAndSum(model,"l_bd00","LR",billDic),/*48*/
                    GetCountAndSum(model,"l_bd11","LR",billDic),/*49*/
                    GetCountAndSum(model,"l_bd22","LR",billDic),/*50*/
                    GetCountAndSum(model,"l_bd33","LR",billDic),/*51*/
                    GetCountAndSum(model,"l_bd44","LR",billDic),/*52*/
                    GetCountAndSum(model,"l_bd10","L",billDic),/*53*/
                    GetCountAndSum(model,"l_bd20","L",billDic),/*54*/
                    GetCountAndSum(model,"l_bd21","L",billDic),/*55*/
                    GetCountAndSum(model,"l_bd30","L",billDic),/*56*/
                    GetCountAndSum(model,"l_bd31","L",billDic),/*57*/
                    GetCountAndSum(model,"l_bd32","L",billDic),/*58*/
                    GetCountAndSum(model,"l_bd40","L",billDic),/*59*/
                    GetCountAndSum(model,"l_bd41","L",billDic),/*60*/
                    GetCountAndSum(model,"l_bd42","L",billDic),/*61*/
                    GetCountAndSum(model,"l_bd43","L",billDic),/*62*/
                    GetCountAndSum(model,"l_bd5","L",billDic),/*63*/
                    GetCountAndSum(model,"l_bd01","R",billDic),/*64*/
                    GetCountAndSum(model,"l_bd02","R",billDic),/*65*/
                    GetCountAndSum(model,"l_bd12","R",billDic),/*66*/
                    GetCountAndSum(model,"l_bd03","R",billDic),/*67*/
                    GetCountAndSum(model,"l_bd13","R",billDic),/*68*/
                    GetCountAndSum(model,"l_bd23","R",billDic),/*69*/
                    GetCountAndSum(model,"l_bd04","R",billDic),/*70*/
                    GetCountAndSum(model,"l_bd14","R",billDic),/*71*/
                    GetCountAndSum(model,"l_bd24","R",billDic),/*72*/
                    GetCountAndSum(model,"l_bd34","R",billDic),/*73*/
                    GetCountAndSum(model,"l_bd5","R",billDic)/*74*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 足球半全场
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyFootBallHalfFullList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,              /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_VISIT_NO,      /*16*/
                    model.N_HOME_NO,       /*17*/
                    model.N_REMARK,        /*18*/
                    model.N_VH,            /*19*/

                    model.N_BQC_OPEN,     /*20*/
                    model.N_BQCZZ,        /*21*/
                    model.N_BQCZH,        /*22*/
                    model.N_BQCZK,        /*23*/
                    model.N_BQCHZ,        /*24*/
                    model.N_BQCHH,        /*25*/
                    model.N_BQCHK,        /*26*/
                    model.N_BQCKZ,        /*27*/
                    model.N_BQCKH,        /*28*/
                    model.N_BQCKK,        /*29*/
                    GetCountAndSum(model,"l_bqczz","",billDic),/*30*/
                    GetCountAndSum(model,"l_bqczh","",billDic),/*31*/
                    GetCountAndSum(model,"l_bqczk","",billDic),/*32*/
                    GetCountAndSum(model,"l_bqchz","",billDic),/*33*/
                    GetCountAndSum(model,"l_bqchh","",billDic),/*34*/
                    GetCountAndSum(model,"l_bqchk","",billDic),/*35*/
                    GetCountAndSum(model,"l_bqckz","",billDic),/*36*/
                    GetCountAndSum(model,"l_bqckh","",billDic),/*37*/
                    GetCountAndSum(model,"l_bqckk","",billDic) /*38*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 足球入球数
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyFootBallGoalList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,              /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_VISIT_NO,      /*16*/
                    model.N_HOME_NO,       /*17*/
                    model.N_REMARK,        /*18*/
                    model.N_VH,            /*19*/

                    model.N_RQ_OPEN,       /*20*/
                    model.N_RQSPL01,       /*21*/
                    model.N_RQSPL23,       /*22*/
                    model.N_RQSPL46,       /*23*/
                    model.N_RQSPL7,        /*24*/
                    model.N_DSDPL,         /*25*/
                    model.N_DSSPL,          /*26*/
                    GetCountAndSum(model,"l_rqs01","",billDic),/*27*/
                    GetCountAndSum(model,"l_rqs23","",billDic),/*28*/
                    GetCountAndSum(model,"l_rqs46","",billDic),/*29*/
                    GetCountAndSum(model,"l_rqs7","",billDic),/*30*/
                    GetCountAndSum(model,"l_rqsd","",billDic),/*31*/
                    GetCountAndSum(model,"l_rqss","",billDic)/*32*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 足球已开赛和历史比赛
    /// </summary>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyFootBallBeganList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,              /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL,  /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL, /*25*/
                    model.N_RRFPL, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL, /*33*/
                    model.N_DXXPL, /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL, /*38*/
                    model.N_RDYPL, /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //单双                 
                    model.N_DSDPL,         /*43*/
                    model.N_DSSPL,         /*44*/
                    model.N_DS_OPEN,       /*45*/
                    model.N_DS_LOCK_V,     /*46*/
                    model.N_DS_LOCK_H,     /*47*/
                    GetCountAndSum(model,"l_rf","L",billDic), /*48*/
                    GetCountAndSum(model,"l_rf","R",billDic), /*49*/
                    GetCountAndSum(model,"l_dx","L",billDic), /*50*/
                    GetCountAndSum(model,"l_dx","R",billDic), /*51*/
                    GetCountAndSum(model,"l_dy","L",billDic), /*52*/
                    GetCountAndSum(model,"l_dy","R",billDic), /*53*/
                    GetCountAndSum(model,"l_hj","LR",billDic), /*54*/
                    GetCountAndSum(model,"l_ds","R",billDic), /*55*/
                    GetCountAndSum(model,"l_ds","L",billDic)  /*56*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 其他球单式或早餐
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyOtherBallSigleList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL,          /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,         /*25*/
                    model.N_RRFPL,         /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL,         /*33*/
                    model.N_DXXPL,         /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL,         /*38*/
                    model.N_RDYPL,         /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //单双                 
                    model.N_DSDPL,          /*43*/
                    model.N_DSSPL,          /*44*/
                    model.N_DS_OPEN,        /*45*/
                    model.N_DS_LOCK_V,      /*46*/
                    model.N_DS_LOCK_H,      /*47*/
                    //一输二赢
                    model.N_LSYPL,          /*48*/
                    model.N_RSYPL,          /*49*/
                    model.N_SY_OPEN,        /*50*/
                    model.N_SY_LOCK_V,      /*51*/
                    model.N_SY_LOCK_H,      /*52*/
                    GetCountAndSum(model,"l_rf","L",billDic),   /*53*/
                    GetCountAndSum(model,"l_rf","R",billDic),   /*54*/
                    GetCountAndSum(model,"l_dx","L",billDic),   /*55*/
                    GetCountAndSum(model,"l_dx","R",billDic),   /*56*/
                    GetCountAndSum(model,"l_dy","L",billDic),   /*57*/
                    GetCountAndSum(model,"l_dy","R",billDic),   /*58*/
                    GetCountAndSum(model,"l_ds","L",billDic),   /*59*/
                    GetCountAndSum(model,"l_ds","R",billDic),   /*60*/
                    GetCountAndSum(model,"l_sy","L",billDic),   /*61*/
                    GetCountAndSum(model,"l_sy","R",billDic)    /*62*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 其他球走地
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyOtherBallGotoList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_HOME_JZF,      /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    model.N_VISIT_JZF,     /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,         /*25*/
                    model.N_RRFPL,         /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL,         /*33*/
                    model.N_DXXPL,         /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/

                    model.N_ZDTIME,         /*38*/
                    model.N_ZDFLAG,         /*39*/
                    model.N_ZDUPTIME,       /*40*/
                    GetCountAndSum(model,"l_zdrf","L",billDic),
                    GetCountAndSum(model,"l_zdrf","R",billDic),
                    GetCountAndSum(model,"l_zddx","L",billDic),
                    GetCountAndSum(model,"l_zddx","R",billDic),
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 其他球过关
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyOtherBallPassList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, 1, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_HJPL,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    model.N_HJGGCJ,        /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,         /*25*/
                    model.N_RRFPL,         /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    model.N_RF_GG,         /*30*/
                    model.N_LRFCJ,         /*31*/
                    model.N_RRFCJ,         /*32*/
                    //大小                 
                    model.N_DXLX,          /*33*/
                    model.N_DXFS,          /*34*/
                    model.N_DXBL,          /*35*/
                    model.N_DXDPL,         /*36*/
                    model.N_DXXPL,         /*37*/
                    model.N_DX_OPEN,       /*38*/
                    model.N_DX_LOCK_V,     /*39*/
                    model.N_DX_LOCK_H,     /*40*/
                    model.N_DX_GG,         /*41*/
                    model.N_DXDCJ,         /*42*/
                    model.N_DXXCJ,         /*43*/
                    //赌赢                 
                    model.N_LDYPL,         /*44*/
                    model.N_RDYPL,         /*45*/
                    model.N_DY_OPEN,       /*46*/
                    model.N_DY_LOCK_V,     /*47*/
                    model.N_DY_LOCK_H,     /*48*/
                    model.N_DY_GG,         /*49*/
                    model.N_LDYCJ,         /*50*/
                    model.N_RDYCJ,         /*51*/
                    //单双                 
                    model.N_DSDPL,         /*52*/
                    model.N_DSSPL,         /*53*/
                    model.N_DS_OPEN,       /*54*/
                    model.N_DS_LOCK_V,     /*55*/
                    model.N_DS_LOCK_H,     /*56*/
                    model.N_DS_GG,         /*57*/
                    model.N_DSDCJ,         /*58*/
                    model.N_DSSCJ,         /*59*/

                    model.N_SAMETEAM,      /*60*/
                   
                    GetCountAndSum(model,"l_rf","L",billDic),
                    GetCountAndSum(model,"l_rf","R",billDic),
                    GetCountAndSum(model,"l_dx","L",billDic),
                    GetCountAndSum(model,"l_dx","R",billDic),
                    GetCountAndSum(model,"l_dy","L",billDic),
                    GetCountAndSum(model,"l_dy","R",billDic),
                    GetCountAndSum(model,"l_ds","L",billDic),
                    GetCountAndSum(model,"l_ds","R",billDic)
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 其他球已开赛和历史比赛
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="userId"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyOtherBallBeganList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL,          /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL,         /*25*/
                    model.N_RRFPL,         /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL,         /*33*/
                    model.N_DXXPL,         /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL,         /*38*/
                    model.N_RDYPL,         /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //单双                 
                    model.N_DSDPL,         /*43*/
                    model.N_DSSPL,         /*44*/
                    model.N_DS_OPEN,       /*45*/
                    model.N_DS_LOCK_V,     /*46*/
                    model.N_DS_LOCK_H,     /*47*/
                    //一输二赢
                    model.N_LSYPL,         /*48*/
                    model.N_RSYPL,         /*49*/
                    model.N_SY_OPEN,       /*50*/
                    model.N_SY_LOCK_V,     /*51*/
                    model.N_SY_LOCK_H,     /*52*/
                    GetCountAndSum(model,"l_rf","L",billDic),
                    GetCountAndSum(model,"l_rf","R",billDic),
                    GetCountAndSum(model,"l_dx","L",billDic),
                    GetCountAndSum(model,"l_dx","R",billDic),
                    GetCountAndSum(model,"l_dy","L",billDic),
                    GetCountAndSum(model,"l_dy","R",billDic),
                    GetCountAndSum(model,"l_ds","L",billDic),
                    GetCountAndSum(model,"l_ds","R",billDic),
                    GetCountAndSum(model,"l_sy","L",billDic),
                    GetCountAndSum(model,"l_sy","R",billDic)
                };
            result.Add(objList);
        });
        return result;
    }

    /// <summary>
    /// 垃圾桶赛事
    /// </summary>
    /// <param name="ballType"></param>
    /// <param name="selectedAllianceList"></param>
    /// <param name="courtType"></param>
    /// <param name="OrderName"></param>
    /// <param name="isBet"></param>
    /// <param name="zwDate"></param>
    /// <param name="playType"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <param name="allianceModelList"></param>
    /// <param name="accDate"></param>
    /// <returns></returns>
    public List<object[]> GetCompanyRecycle(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = new List<object[]>();
        Dictionary<string, string> billDic = new Dictionary<string, string>();
        List<KFB_BALL> gameList = dal.GetCompanyGameList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate, ref billDic);

        gameList.ForEach(delegate(KFB_BALL model)
        {
            object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    playType,              /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL,  /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL, /*25*/
                    model.N_RRFPL, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL, /*33*/
                    model.N_DXXPL, /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL, /*38*/
                    model.N_RDYPL, /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //单双                 
                    model.N_DSDPL,         /*43*/
                    model.N_DSSPL,         /*44*/
                    model.N_DS_OPEN,       /*45*/
                    model.N_DS_LOCK_V,     /*46*/
                    model.N_DS_LOCK_H,     /*47*/
                    GetCountAndSum(model,"l_rf","L",billDic), /*48*/
                    GetCountAndSum(model,"l_rf","R",billDic), /*49*/
                    GetCountAndSum(model,"l_dx","L",billDic), /*50*/
                    GetCountAndSum(model,"l_dx","R",billDic), /*51*/
                    GetCountAndSum(model,"l_dy","L",billDic), /*52*/
                    GetCountAndSum(model,"l_dy","R",billDic), /*53*/
                    GetCountAndSum(model,"l_hj","LR",billDic), /*54*/
                    GetCountAndSum(model,"l_ds","R",billDic), /*55*/
                    GetCountAndSum(model,"l_ds","L",billDic)  /*56*/
                };
            result.Add(objList);
        });
        return result;
    }
    /// <summary>
    /// 加密参数
    /// </summary>
    /// <param name="model"></param>
    /// <param name="playType"></param>
    /// <param name="UpAndDown"></param>
    /// <param name="courtType"></param>
    /// <returns></returns>
    private string GetCode(KFB_BALL model, string playType, string UpAndDown, int courtType, decimal rateGap)
    {
        //ball=b_zq&n_id=3236804&wf=rf&pk=l&let=0&pl=0.690&vh=3236796&sffs=0&date=05/24&hfs=0&hlx=-2&hbl=100&t=1&tid=3236796&sg=tempt12312431243
        List<object> obj = new List<object>();
        /*0*/
        obj.Add(model.N_LX);//球类型ball
        /*1*/
        obj.Add(model.N_ID);//赛事IDn_id
        /*2*/
        obj.Add(playType);//玩法类型wf
        /*3*/
        obj.Add(UpAndDown);//上下队伍pk
        /*4*/
        obj.Add(model.N_LET);//强弱队let
        /*5*/
        obj.Add(model.N_VH);//主队vh
        /*6*/
        obj.Add(model.N_ZWDATE.Value.ToString("MM/dd"));//账务日期data
        /*7*/
        obj.Add(courtType);//场别t
        /*8*/
        if (courtType.Equals(1))//赔率pl
        {
            switch (playType)
            {
                case "RF":
                    #region RF
                    //赔率
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LRFPL + rateGap);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RRFPL + rateGap);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_RFFS);//hfs/*9*/
                    obj.Add(model.N_RFLX);//hlx/*10*/
                    obj.Add(model.N_RFBL);//hbl/*11*/
                    break;
                    #endregion
                case "DX":
                    #region DX
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_DXDPL + rateGap);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_DXXPL + rateGap);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_DXFS);
                    obj.Add(model.N_DXLX);
                    obj.Add(model.N_DXBL);
                    break;
                    #endregion
                case "DY":
                    #region DY
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LDYPL + rateGap);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RDYPL + rateGap);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(0);
                    obj.Add(0);
                    obj.Add(0);
                    break;
                    #endregion
                case "HJ":
                    #region HJ
                    obj.Add(model.N_HJPL + rateGap);
                    obj.Add(0);
                    obj.Add(0);
                    obj.Add(0);
                    break;
                    #endregion
                case "SY":
                    #region SY
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LSYPL + rateGap);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RSYPL + rateGap);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(0);
                    obj.Add(0);
                    obj.Add(0);
                    break;
                    #endregion
                case "DS":
                    #region RF
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_DSDPL + rateGap);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_DSSPL + rateGap);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(0);
                    obj.Add(0);
                    obj.Add(0);
                    break;
                    #endregion
                case "ZDRF":
                    #region RF
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LRFPL + rateGap);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RRFPL + rateGap);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_RFFS);
                    obj.Add(model.N_RFLX);
                    obj.Add(model.N_RFBL);
                    break;
                    #endregion
                case "ZDDX":
                    #region RF
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LRFPL + rateGap);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RRFPL + rateGap);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_RFFS);
                    obj.Add(model.N_RFLX);
                    obj.Add(model.N_RFBL);
                    break;
                    #endregion

            }
            //下注队伍tid/*12*/
            if (UpAndDown.Equals("L"))
            {
                obj.Add(model.N_VISIT);
            }
            else if (UpAndDown.Equals("R"))
            {
                obj.Add(model.N_HOME);
            }
            else
            {
                obj.Add(0);
            }
        }
        else
        {
            switch (playType)
            {
                case "RF":
                    #region RF
                    //赔率
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LRFPL2);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RRFPL2);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_RFFS2);
                    obj.Add(model.N_RFLX2);
                    obj.Add(model.N_RFBL2);
                    break;
                    #endregion
                case "DX":
                    #region DX
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_DXDPL2);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_DXXPL2);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_DXFS2);
                    obj.Add(model.N_DXLX2);
                    obj.Add(model.N_DXBL2);
                    break;
                    #endregion
                case "DY":
                    #region DY
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LDYPL2);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RDYPL2);
                    }
                    else
                    {
                        obj.Add(model.N_HJPL2);
                    }
                    obj.Add(0);
                    obj.Add(0);
                    obj.Add(0);
                    break;
                    #endregion
                case "SY":
                    #region SY
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LSYPL2);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RSYPL2);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(0);
                    obj.Add(0);
                    obj.Add(0);
                    break;
                    #endregion
                case "DS":
                    #region RF
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_DSDPL2);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_DSSPL2);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(0);
                    obj.Add(0);
                    obj.Add(0);
                    break;
                    #endregion
                case "ZDRF":
                    #region RF
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LRFPL2);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RRFPL2);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_RFFS2);
                    obj.Add(model.N_RFLX2);
                    obj.Add(model.N_RFBL2);
                    break;
                    #endregion
                case "ZDDX":
                    #region RF
                    if (UpAndDown.Equals("L"))
                    {
                        obj.Add(model.N_LRFPL);
                    }
                    else if (UpAndDown.Equals("R"))
                    {
                        obj.Add(model.N_RRFPL);
                    }
                    else
                    {
                        obj.Add(0);
                    }
                    obj.Add(model.N_DXFS2);
                    obj.Add(model.N_DXLX2);
                    obj.Add(model.N_DXBL2);
                    break;
                    #endregion

            }
            //下注队伍
            if (UpAndDown.Equals("L"))
            {
                obj.Add(model.N_VISIT2);
            }
            else if (UpAndDown.Equals("R"))
            {
                obj.Add(model.N_HOME2);
            }
            else
            {
                obj.Add(0);
            }
        }
        obj.Add(model.N_SAMETEAM);
        obj.Add(model.N_VISIT_NAME);//主队
        obj.Add(model.N_HOME_NAME);  //客队
        JavaScriptSerializer ser = new JavaScriptSerializer();
        return Comm.Encode(ser.Serialize(obj));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="playType"></param>
    /// <param name="UpAndDown"></param>
    /// <param name="billDic"></param>
    /// <returns></returns>
    private string GetCountAndSum(KFB_BALL model, string playType, string UpAndDown, Dictionary<string, string> billDic)
    {
        string key = model.N_ID.ToString();
        if (UpAndDown.Equals("L"))
        {
            key += "|" + model.N_VISIT.ToString();
        }
        else if (UpAndDown.Equals("R"))
        {
            key += "|" + model.N_HOME.ToString();
        }
        else if (UpAndDown.Equals("LR"))
        {
            key += "|" + model.N_VISIT.ToString();
        }
        else
        {
            key += "|0";
        }
        key += "|" + playType.ToUpper();
        string result = "0/0";
        if (billDic.ContainsKey(key))
        {
            result = billDic[key];
        }
        return result;
    }

    public List<object[]> GetCompanyGameList(string ballType, List<int> selectedAllianceList, int courtType, string OrderName, int isBet, string zwDate, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList, out string accDate)
    {
        List<object[]> result = null;
        switch (playType)
        {
            case 0://早餐
            case 1://单式
                if (ballType.Equals("b_zq"))
                {
                    result = GetCompanyFootBallSigleList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                else
                {
                    result = GetCompanyOtherBallSigleList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                break;
            case 2://滚球
                if (ballType.Equals("b_zq"))
                {
                    result = GetCompanyFootBallGotoList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                else
                {
                    result = GetCompanyOtherBallGotoList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                break;
            case 3://过关
                if (ballType.Equals("b_zq"))
                {
                    result = GetCompanyFootBallPassList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                else
                {
                    result = GetCompanyOtherBallPassList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                break;
            case 4://波胆
                result = GetCompanyFootBallWaveList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                break;
            case 6://半全场
                result = GetCompanyFootBallHalfFullList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                break;
            case 5://入球数
                result = GetCompanyFootBallGoalList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                break;
            case 7://已开赛
            case 8://已计算
            case 9://已过账
                if (ballType.Equals("b_zq"))
                {
                    result = GetCompanyFootBallBeganList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                else
                {
                    result = GetCompanyOtherBallBeganList(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                }
                break;
            case 10://垃圾桶
                result = GetCompanyRecycle(ballType, selectedAllianceList, courtType, OrderName, isBet, zwDate, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out accDate);
                break;
            default:
                recordCount = 0;
                allianceModelList = new List<KFB_LMGL>();
                accDate = "";
                break;
        }
        return result;
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
        try
        {
            return dal.GetBillDetail(qsbh, bsdw, xzwf, status, playType);
        }
        finally
        {
            this.Close();
        }
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
    public DataTable GetBillStat(string qsbh, string bsdw, string xzwf, string status, string playType)
    {
        try
        {
            return dal.GetBillStat(qsbh, bsdw, xzwf, status, playType);
        }
        finally
        {
            this.Close();
        }
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
    public DataTable GetBillCount(string qsbh, string bsdw, string xzwf, string status, string playType)
    {
        try
        {
            return dal.GetBillCount(qsbh, bsdw, xzwf, status, playType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }


    /// <summary>
    /// 得到聯盟
    /// </summary>
    /// <param name="i_aLMLX"></param>
    /// <returns></returns>
    public DataTable GetLeagueList(int i_aLMLX)
    {
        try
        {
            return dal.GetLeagueList(i_aLMLX);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }

    /// <summary>
    /// 得到聯盟
    /// </summary>
    /// <param name="i_aLMLX"></param>
    /// <returns></returns>
    public string GetTeamList(int i_aLMLX)
    {
        try
        {
            return dal.GetTeamList(i_aLMLX);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="playType"></param>
    /// <param name="action"></param>
    /// <param name="id"></param>
    public string SetGameStatus(string playType, int action, string[] id)
    {
        try
        {
            dal.SetGameStatus(playType, action, id);
            return "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }

    /// <summary>
    /// 验证垃圾桶资料是否有注单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetBetCount(string[] id)
    {
        return dal.GetBetCount(id);
    }
    /// <summary>
    ///修改赔率
    /// </summary>
    /// <param name="nid"></param>
    /// <param name="sField"></param>
    /// <param name="nvalue"></param>
    public string SetRate(int nid, string sField, decimal nvalue)
    {
        try
        {
            dal.SetRate(nid, sField, nvalue);
            return "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    #endregion

    #region 单场单注
    /// <summary>
    /// 获取基础单场单注
    /// </summary>
    /// <returns></returns>
    public DataTable GetLimitBase()
    {
        try
        {
            return dal.GetLimitBase();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //dal.DataBase.Close();
        }
    }
    /// <summary>
    /// 获取单场单注
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    public DataTable GetLimitDetail(string site)
    {
        try
        {
            return dal.GetLimitDetail(site);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //dal.DataBase.Close();
        }
    }

    /// <summary>
    /// 获取单场单注
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    public DataTable GetLimitList(string site)
    {
        try
        {
            return dal.GetLimitList(site);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <param name="courtType"></param>
    public void UpdateLimitBase(string playtype, decimal playvalue, int courtType)
    {
        try
        {
            dal.UpdateLimitBase(playtype, playvalue, courtType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //dal.DataBase.Close();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <param name="level"></param>
    /// <param name="credit"></param>
    public void AddLimitDetail(string site, int level, decimal credit)
    {
        try
        {
            dal.AddLimitDetail(site, level, credit);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //dal.DataBase.Close();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <param name="level"></param>
    /// <param name="credit"></param>
    public void UpdateLimitDetail(string site, int level, decimal credit)
    {
        try
        {
            dal.UpdateLimitDetail(site, level, credit);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //dal.DataBase.Close();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DataTable GetSiteList()
    {
        try
        {
            return dal.GetSiteList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //dal.DataBase.Close();
        }
    }
    /// <summary>
    /// 关闭连接
    /// </summary>
    public void Close()
    {
        dal.DbHelper.Close();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <param name="level"></param>
    /// <param name="credit"></param>
    public void SaveLimitDetail(string site, int level, decimal credit)
    {
        try
        {
            if (dal.Exsits(site, level))
            {
                dal.UpdateLimitDetail(site, level, credit);
            }
            else
            {
                dal.AddLimitDetail(site, level, credit);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //dal.DataBase.Close();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="level"></param>
    /// <returns></returns>
    public DataTable GetLeagueList(string type, string level)
    {
        try
        {
            return dal.GetLeagueList(type, level);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.Close();
        }
    }
    public void AddLimitDetail(string site, List<decimal> dCredit)
    {
        try
        {
            dal.AddLimitDetail(site, dCredit);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ModifyLimitDetail(string strOldsite, string site, List<decimal> dCredit)
    {
        try
        {
            dal.ModifyLimitDetail(strOldsite, site, dCredit);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 世界杯
    public List<object[]> sjbSigleList(List<int> selectedAllianceList, int courtType, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.sjbGameList("b_zq", selectedAllianceList, courtType, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //和局                 
                    model.N_HJPL+rateGap,  /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL+rateGap, /*25*/
                    model.N_RRFPL+rateGap, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL+rateGap, /*33*/
                    model.N_DXXPL+rateGap, /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL+rateGap, /*38*/
                    model.N_RDYPL+rateGap, /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //和局            
                    model.N_HJPL2+rateGap,          /*43*/
                    //让分                 
                    model.N_RFLX2,          /*44*/
                    model.N_RFFS2,          /*45*/
                    model.N_RFBL2,          /*46*/
                    model.N_LRFPL2+rateGap, /*47*/
                    model.N_RRFPL2+rateGap, /*48*/
                    model.N_RF_OPEN2,       /*49*/
                    model.N_RF_LOCK_V2,     /*50*/
                    model.N_RF_LOCK_H2,     /*51*/
                    //大小                 
                    model.N_DXLX2,          /*52*/
                    model.N_DXFS2,          /*53*/
                    model.N_DXBL2,          /*54*/
                    model.N_DXDPL2+rateGap, /*55*/
                    model.N_DXXPL2+rateGap, /*56*/
                    model.N_DX_OPEN2,       /*57*/
                    model.N_DX_LOCK_V2,     /*58*/
                    model.N_DX_LOCK_H2,     /*59*/
                    //赌赢                 
                    model.N_LDYPL2+rateGap, /*60*/
                    model.N_RDYPL2+rateGap, /*61*/
                    model.N_DY_OPEN2,       /*62*/
                    model.N_DY_LOCK_V2,     /*63*/
                    model.N_DY_LOCK_H2,     /*64*/
                    
                    model.N_ID2,            /*65*/
                    model.N_LET2,           /*66*/
                    model.N_VISIT2,         /*67*/ 
                    model.N_HOME2           /*68*/
                };
                result.Add(objList);
            });
            return result;
        }
        finally
        {
            this.Close();
        }
    }

    public List<object[]> sjbGotoList(List<int> selectedAllianceList, string OrderName, string userId, int playType, int pageIndex, int pageSize, out int recordCount, out List<KFB_LMGL> allianceModelList)
    {
        try
        {
            List<object[]> result = new List<object[]>();
            decimal rateGap = 0;
            List<KFB_BALL> gameList = dal.sjbGameList("b_zq", selectedAllianceList, 0, OrderName, userId, playType, pageIndex, pageSize, out recordCount, out allianceModelList, out rateGap);

            gameList.ForEach(delegate(KFB_BALL model)
            {
                object[] objList = new object[] { 
                    model.N_ID,            /*0*/               
                    model.N_LX,            /*1*/                 
                    model.N_ZWDATE,        /*2*/            
                    model.N_GAMEDATE,      /*3*/                
                    model.N_LMNO,          /*4*/      
                    "",                    /*5联盟名称在js中获取*/
                    model.N_VISIT,         /*6*/                
                    model.N_VISIT_NAME,    /*7*/
                    model.N_HOME,          /*8*/
                    model.N_HOME_NAME,     /*9*/
                    model.N_CBXH,          /*10*/
                    model.N_SAMEGAME,      /*11*/
                    model.N_LET,           /*12*/
                    model.N_SFXZ,          /*13*/
                    model.N_LOCK,          /*14*/
                    model.N_ZBXH,          /*15*/
                    //model.N_HOME_JZF,      /*16*/
                    model.N_SFZD,          /*16*/
                    model.N_VISIT_NO,      /*17*/
                    model.N_HOME_NO,       /*18*/
                    model.N_VH,            /*19*/
                    model.N_REMARK,        /*20*/
                    //model.N_VISIT_JZF,     /*21*/
                    model.N_HJPL+rateGap,          /*21*/
                    //让分                 
                    model.N_RFLX,          /*22*/
                    model.N_RFFS,          /*23*/
                    model.N_RFBL,          /*24*/
                    model.N_LRFPL+rateGap, /*25*/
                    model.N_RRFPL+rateGap, /*26*/
                    model.N_RF_OPEN,       /*27*/
                    model.N_RF_LOCK_V,     /*28*/
                    model.N_RF_LOCK_H,     /*29*/
                    //大小                 
                    model.N_DXLX,          /*30*/
                    model.N_DXFS,          /*31*/
                    model.N_DXBL,          /*32*/
                    model.N_DXDPL+rateGap, /*33*/
                    model.N_DXXPL+rateGap, /*34*/
                    model.N_DX_OPEN,       /*35*/
                    model.N_DX_LOCK_V,     /*36*/
                    model.N_DX_LOCK_H,     /*37*/
                    //赌赢                  
                    model.N_LDYPL+rateGap, /*38*/
                    model.N_RDYPL+rateGap, /*39*/
                    model.N_DY_OPEN,       /*40*/
                    model.N_DY_LOCK_V,     /*41*/
                    model.N_DY_LOCK_H,     /*42*/
                    //和局            
                    model.N_HJPL2+rateGap,         /*43*/
                    //让分                 
                    model.N_RFLX2,          /*44*/
                    model.N_RFFS2,          /*45*/
                    model.N_RFBL2,          /*46*/
                    model.N_LRFPL2+rateGap, /*47*/
                    model.N_RRFPL2+rateGap, /*48*/
                    model.N_RF_OPEN2,       /*49*/
                    model.N_RF_LOCK_V2,     /*50*/
                    model.N_RF_LOCK_H2,     /*51*/
                    //大小                 
                    model.N_DXLX2,          /*52*/
                    model.N_DXFS2,          /*53*/
                    model.N_DXBL2,          /*54*/
                    model.N_DXDPL2+rateGap, /*55*/
                    model.N_DXXPL2+rateGap, /*56*/
                    model.N_DX_OPEN2,       /*57*/
                    model.N_DX_LOCK_V2,     /*58*/
                    model.N_DX_LOCK_H2,     /*59*/
                    //赌赢                 
                    model.N_LDYPL2+rateGap, /*60*/
                    model.N_RDYPL2+rateGap, /*61*/
                    model.N_DY_OPEN2,       /*62*/
                    model.N_DY_LOCK_V2,     /*63*/
                    model.N_DY_LOCK_H2,     /*64*/
                    
                    model.N_ID2,            /*65*/
                    model.N_LET2,           /*66*/
                    model.N_VISIT_JZF,      /*67*/
                    model.N_HOME_JZF,       /*68*/
                    //model.N_ZDTIME,         /*69*/
                    GetZDTime(model.N_ZDTIME,model.N_ZDFLAG,model.N_ZDUPTIME.Value),/*69*/
                    model.N_ZDFLAG,         /*70*/
                    model.N_ZDUPTIME,       /*71*/
                    
                    model.N_VISIT2,         /*72*/ 
                    model.N_HOME2,           /*73*/
                    
                    model.N_VISIT_REDCARD,         /*74*/ 
                    model.N_HOME_REDCARD           /*75*/
                };
                result.Add(objList);
            });
            return result;
        }
        finally
        {
            this.Close();
        }
    }

    #endregion



    public void SaveMes(string strmes, string s_filename, string s_funtion)
    {
        try
        {
            lock (ms_LockType)
            {

                string s_Log = "C:/LOGYN";
                DateTime dt = DateTime.Now;
                string s_file = dt.ToString("yyyyMMdd") + "Ballerrorlog.txt";
                if (!s_filename.Equals(""))
                {
                    s_file = s_filename;
                }
                StreamWriter sw = File.AppendText(s_Log + "/" + s_file);
                sw.WriteLine(dt.ToLongTimeString() + ";" + strmes);

                sw.Flush();
                sw.Close();

            }
        }
        catch (Exception exp)
        {

        }
    }
    /// <summary>
    /// 查询足球早餐盘的帐务日期
    /// </summary>
    /// <param name="strZWRQ"></param>
    /// <returns></returns>

    public List<DateTime> GetBreakfaseZQ(string strZWRQ)
    {
        return dal.GetBreakfaseZQ(strZWRQ);
    }
    /// <summary>
    /// 查询垃圾桶赛事的帐务日期
    /// </summary>
    /// <param name="strZWRQ"></param>
    /// <returns></returns>

    public List<DateTime> GetRecycleRQ(string strBallType)
    {
        return dal.GetRecycleRQ(strBallType);
    }
}
