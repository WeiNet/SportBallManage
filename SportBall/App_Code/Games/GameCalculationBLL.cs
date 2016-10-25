using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

public class GameCalculationBLL
{
    public static ILog LogDB = log4net.LogManager.GetLogger("logCount");
    /// <summary>
    /// 计算
    /// </summary>
    /// <param name="fullvisitscores"></param>
    /// <param name="fullhomescores"></param>
    /// <param name="strid"></param>
    /// <param name="str9j"></param>
    /// <param name="halfvisitscores"></param>
    /// <param name="halfhomescores"></param>
    /// <param name="strflag"></param>
    /// <param name="remark"></param>
    public  void BallCount(string fullvisitscores, string fullhomescores, string strid, string str9j,
        string halfvisitscores, string halfhomescores, string strflag, string remark)
    {
        GameCalculationDB count = new GameCalculationDB(true);
        try
        {
            int matchId = Convert.ToInt32(strid);
            DateTime sysDateNow = count.GetSysDate();
            KFB_BASEBALL o_KFB_BASEBALL = count.GetModel(matchId);
            o_KFB_BASEBALL.N_VISIT_RESULT = Convert.ToDecimal(fullvisitscores);
            o_KFB_BASEBALL.N_HOME_RESULT = Convert.ToDecimal(fullhomescores);
            o_KFB_BASEBALL.N_REMARK = remark;
            o_KFB_BASEBALL.N_UP_VISIT_RESULT = Convert.ToDecimal(halfvisitscores);
            o_KFB_BASEBALL.N_UP_HOME_RESULT = Convert.ToDecimal(halfhomescores);
            o_KFB_BASEBALL.N_SF9J = Convert.ToInt32(str9j);
            o_KFB_BASEBALL.N_COUNTTIME = sysDateNow;
            o_KFB_BASEBALL.N_ID = Convert.ToInt32(strid);
            string strdw1 = o_KFB_BASEBALL.N_VISIT.Value.ToString();
            string strdw2 = o_KFB_BASEBALL.N_HOME.Value.ToString();
            string strlx = o_KFB_BASEBALL.N_LX;
            string strcb = o_KFB_BASEBALL.N_CBXH.Value.ToString();
            if (strflag.Equals("0"))
            {
                count.CountMatch(o_KFB_BASEBALL);
            }
            else
            {
                count.ReCountMatch(o_KFB_BASEBALL);
            }

            //像赛事记录表里面新增资料
            count.InsertBallLog(matchId, Convert.ToInt32(fullvisitscores), Convert.ToInt32(fullhomescores), Convert.ToInt32(halfvisitscores), Convert.ToInt32(halfhomescores), sysDateNow);

            string strdw1yfs = fullvisitscores;
            string strdw2yfs = fullhomescores;
            //KingOfBall.BLL.KFB_PTZD_BLL o_PTZD = new KingOfBall.BLL.KFB_PTZD_BLL();
            KFB_PTZD mo_PTZD = new KFB_PTZD();
            //DataSet ds = o_PTZD.GetQL(strlx, strid, strcb);

            //BY KEWEN
            //KingOfBall.BLL.KFB_MRZJ_BLL O_MRZJ = new KingOfBall.BLL.KFB_MRZJ_BLL();
            //KFB_MRZJ M_MRZJ = new KFB_MRZJ();
            //M_MRZJ = O_MRZJ.GetModel();

            //获取赛事下所有注单列表
            DataSet ds = count.GetBillList(strlx, strid, strcb);
            Decimal gsjg = 0;
            string strgszc = "100";

            foreach (DataRow rows in ds.Tables[0].Rows)
            {

                fullvisitscores = strdw1yfs;
                fullhomescores = strdw2yfs;
                //DataRow rows = ds.Tables[0].Rows[i];
                string strzdid = rows["n_id"].ToString();
                string strtype = rows["n_gsty"].ToString();
                string strxzwf = rows["n_xzwf"].ToString();

                //获取一笔注单
                mo_PTZD = count.GetModel(strzdid);
                decimal tempHYJG = 0;
                string tempJS = mo_PTZD.N_JS.ToString();//记录注单的计算状态
                if (tempJS.Equals("1"))
                {
                    tempHYJG = mo_PTZD.N_HYJG.Value;//已经计算的注单 记录会员的会员结果
                }
                //注單存在
                //bool bcz = o_PTZD.Exists(mo_PTZD);
                bool bcz = mo_PTZD.N_FLAG == "0";//判断注单是在ptzd还是在optzd  0在ptzd  1在optzd
                string strkyed = "0";
                string strdlcz = rows["n_dlcz"].ToString();
                string strzdlcz = rows["n_zdlcz"].ToString();
                string strgdcz = rows["n_gdcz"].ToString();
                string strzgdcz = rows["n_zgdcz"].ToString();
                string strzjcz = rows["n_zjcz"].ToString();
                string strdzjcz = rows["n_dzjcz"].ToString();
                string strrffs = rows["n_rffs"].ToString();
                string strrfs = rows["n_rf"].ToString();
                string strxt = rows["n_rfxt"].ToString();
                string strdw = rows["n_bsdw"].ToString();
                //string strkyje = rows["n_kyje"].ToString();

                //type
                string strbslx = rows["N_BSLX"].ToString();

                string strxzje = rows["n_xzje"].ToString();
                string strty = rows["n_ty"].ToString();
                string strbl = rows["n_rfbl"].ToString();
                string strqsbh = rows["n_qsbh"].ToString();
                Decimal dpl = Convert.ToDecimal(rows["n_pl"].ToString());
                //add by amanda 現金版賠率-1 
                //足球  讓分 大小除外
                //籃球  單雙 独赢
                //美足  單雙
                //彩球  單雙
                //棒球  獨贏
                //冰球  獨贏
                //指數  單雙
                //if ((strxzwf != "l_rf" && strxzwf != "l_dx" && strxzwf != "l_zdrf" && strxzwf != "l_zddx" && dpl > 0 && strbslx == "b_zq") || ((strbslx == "b_cq" || strbslx == "b_bk" || strbslx == "b_bf" || strbslx == "b_zs" || strbslx == "b_bb") && strxzwf == "l_ds") || (strbslx == "b_bj" && strxzwf == "l_dy") || (strbslx == "b_bk" && strxzwf == "l_dy"))
                if (strxzwf != "l_rf" && strxzwf != "l_dx" && strxzwf != "l_zdrf" && strxzwf != "l_zddx")
                    dpl = dpl - 1;

                Decimal dggje = Convert.ToDecimal(strxzje) * dpl;
                if (dpl < 0)
                    dggje = Convert.ToDecimal(strxzje);

                string strkyje = Convert.ToString(Convert.ToDecimal(strxzje) * Convert.ToDecimal(rows["n_pl"].ToString()));
                //add by amanda 現金版賠率-1
                //if ((strxzwf != "l_rf" && strxzwf != "l_dx" && strxzwf != "l_zdrf" && strxzwf != "l_zddx" && dpl > 0 && strbslx == "b_zq") || ((strbslx == "b_cq" || strbslx == "b_bk" || strbslx == "b_bf" || strbslx == "b_zs" || strbslx == "b_bb") && strxzwf == "l_ds") || (strbslx == "b_bj" && strxzwf == "l_dy") || (strbslx == "b_bk" && strxzwf == "l_dy"))
                if (strxzwf != "l_rf" && strxzwf != "l_dx" && strxzwf != "l_zdrf" && strxzwf != "l_zddx")
                    strkyje = Convert.ToString(Convert.ToDecimal(strxzje) * dpl);
                if (dpl < 0)
                    strkyje = strxzje;
                //大小
                string strdx = rows["n_dx"].ToString();
                string strdxxt = rows["n_dxxt"].ToString();//n_dxbl
                string strdxbl = rows["n_dxbl"].ToString();
                //基準分
                string strjzf = rows["n_jzf"].ToString();
                decimal d_zdf = Convert.ToDecimal(rows["n_zdf"].ToString());
                decimal d_rdf = Convert.ToDecimal(rows["n_rdf"].ToString());
                //是否刪除
                string strdel = rows["n_del"].ToString();
                Decimal dgg = 0;
                int ics = 0;
                //固定腿水
                Double dts = Convert.ToDouble(strxzje) * Convert.ToDouble(strty) / 10000;
                bool ck9j = true;
                //是否中洞
                bool chzd = false;
                //不計算刪除的注單
                if (strdel.Equals("1"))
                {
                    strkyed = "0";
                    dgg = 0;
                    ck9j = false;
                }

                if (str9j.Equals("0"))
                {
                    if (strxzwf.Equals("l_zdrf") || strxzwf.Equals("l_sy") || strxzwf.Equals("l_dx") || strxzwf.Equals("l_zddx") || strxzwf.Equals("l_ds") || strxzwf.Equals("l_zdds"))
                    {
                        strkyed = "0";
                        dgg = 0;
                        ck9j = false;
                        //continue;
                    }
                }
                //string strcode = "kfbballleft" + strzdid + strbslx + strxzwf + Convert.ToDouble(rows["n_pl"]) + strxzje + strdw + strqsbh + rows["n_xzdh"].ToString();
                //string strMD5 = FormsAuthPasswordFormat.MD5.ToString();
                //if (strxzwf.Equals("l_rf") || strxzwf.Equals("l_zdrf") || strxzwf.Equals("l_sy") || strxzwf.Equals("l_zdsy"))
                //{
                //    strcode += strrfs + strxt + strbl + strrffs + "end";
                //}
                //else if (strxzwf.Equals("l_dx") || strxzwf.Equals("l_zddx"))
                //{
                //    strcode += strdx + strdxxt + strdxbl + strrffs + "end";
                //}
                ////else if (strxzwf.Equals("l_dy") || strxzwf.Equals("l_zddy"))
                ////{
                ////    strcode += "000" + strrffs + "end";
                ////}
                //else
                //{
                //    strcode += "000" + strrffs + "end";
                //}
                //string strmdcode = FormsAuthentication.HashPasswordForStoringInConfigFile(strcode, strMD5).ToUpper();
                //KingOfBall.BLL.KFB_BET_BLL bet = new KFB_BET_BLL();
                //if (!bet.IsExist(strzdid, strmdcode))
                //{
                //    SaveMes(strcode + "  xzdh=" + rows["n_xzdh"].ToString(), "ballpor", "");
                //    bet.UpdateAdd(strzdid, "1");
                //    continue;
                //}
                //if(!strtype.Equals("2"))
                //{
                string strps = "";
                if (ck9j)
                {
                    //如果比赛取消 ,则退出计算
                    if (!(fullvisitscores.Equals("-1") || fullhomescores.Equals("-1")))
                    {
                        //不是过关
                        #region　让分　计算
                        if (strxzwf.Equals("l_rf") || strxzwf.Equals("l_zdrf") || strxzwf.Equals("l_sy") || strxzwf.Equals("l_zdsy"))
                        {
                            //走地 判斷是否 開基準分
                            if (strxzwf.Equals("l_zdrf") || strxzwf.Equals("l_zdsy"))
                            {
                                //是否開機准分
                                // if (strjzf.Equals("1"))
                                if (strlx.Equals("b_zq"))
                                {
                                    fullvisitscores = Convert.ToString(Convert.ToDecimal(fullvisitscores) - d_zdf);
                                    fullhomescores = Convert.ToString(Convert.ToDecimal(fullhomescores) - d_rdf);
                                }
                            }


                            //输赢　判断-->
                            #region 输赢　判断
                            //左讓右
                            if (strrffs.Equals("0"))
                            {
                                ics = Convert.ToInt32(fullvisitscores) - Convert.ToInt32(fullhomescores);
                                //左队赢
                                if (ics > Convert.ToInt32(strrfs))
                                {
                                    if (strdw.Equals(strdw1))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                //两堆平
                                else if (ics == Convert.ToInt32(strrfs))
                                {
                                    chzd = true;
                                    //１平
                                    if (Convert.ToInt32(strxt) != 0)
                                    {

                                        if (strdw.Equals(strdw1))
                                        {
                                            if (Convert.ToInt32(strxt) >= 0)
                                            {
                                                strkyed = Convert.ToString(Convert.ToDouble(strkyje) * Convert.ToDouble(strbl) / 100 + dts * Convert.ToDouble(strbl) / 100);
                                                dgg = dggje * Convert.ToDecimal(strbl) / 100;
                                            }
                                            else
                                            {

                                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strbl) / 100 * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                                dgg = -1 * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strbl) / 100;
                                                if (dpl < 0)
                                                {
                                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strbl) / 100 * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                                    dgg = dpl * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strbl) / 100;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(strxt) >= 0)
                                            {

                                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strbl) / 100 * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                                dgg = -1 * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strbl) / 100;
                                                if (dpl < 0)
                                                {
                                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strbl) / 100 * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                                    dgg = dpl * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strbl) / 100;
                                                }

                                            }
                                            else
                                            {
                                                strkyed = Convert.ToString(Convert.ToDouble(strkyje) * Convert.ToDouble(strbl) / 100 + dts * Convert.ToDouble(strbl) / 100);
                                                dgg = dggje * Convert.ToDecimal(strbl) / 100;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        strkyed = "0";
                                        dgg = 0;
                                    }
                                }
                                //左队输
                                else
                                {
                                    if (strdw.Equals(strdw1))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                }
                            }
                            //右讓左
                            else
                            {
                                ics = Convert.ToInt32(fullhomescores) - Convert.ToInt32(fullvisitscores);
                                //右队赢
                                if (ics > Convert.ToInt32(strrfs))
                                {
                                    if (strdw.Equals(strdw2))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                //两堆平
                                else if (ics == Convert.ToInt32(strrfs))
                                {
                                    chzd = true;
                                    //１平
                                    if (Convert.ToInt32(strxt) != 0)
                                    {
                                        if (strdw.Equals(strdw2))
                                        {
                                            if (Convert.ToInt32(strxt) >= 0)
                                            {
                                                strkyed = Convert.ToString((Convert.ToDouble(strkyje) * Convert.ToDouble(strbl) / 100) + dts * Convert.ToDouble(strbl) / 100);
                                                dgg = dggje * (Convert.ToDecimal(strbl) / 100);
                                            }
                                            else
                                            {
                                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000) * Convert.ToDouble(strbl) / 100);
                                                dgg = -1 * Convert.ToDecimal(strxzje) * (Convert.ToDecimal(strbl) / 100);
                                                if (dpl < 0)
                                                {
                                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000) * Convert.ToDouble(strbl) / 100);
                                                    dgg = dpl * Convert.ToDecimal(strxzje) * (Convert.ToDecimal(strbl) / 100);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(strxt) >= 0)
                                            {
                                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000) * Convert.ToDouble(strbl) / 100);
                                                dgg = -1 * Convert.ToDecimal(strxzje) * (Convert.ToDecimal(strbl) / 100);
                                                if (dpl < 0)
                                                {
                                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000) * Convert.ToDouble(strbl) / 100);
                                                    dgg = dpl * Convert.ToDecimal(strxzje) * (Convert.ToDecimal(strbl) / 100);
                                                }
                                            }
                                            else
                                            {
                                                strkyed = Convert.ToString((Convert.ToDouble(strkyje) * Convert.ToDouble(strbl) / 100) + dts * Convert.ToDouble(strbl) / 100);
                                                dgg = dggje * (Convert.ToDecimal(strbl) / 100);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        strkyed = "0";
                                        dgg = 0;
                                    }
                                }
                                //右队输
                                else
                                {
                                    if (strdw.Equals(strdw2))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                }
                            }
                            #endregion
                            //＜－－－输赢　判断

                        }
                        #endregion
                        #region　大小　计算
                        else if (strxzwf.Equals("l_dx") || strxzwf.Equals("l_zddx"))
                        {
                            //走地 判斷是否 開基準分
                            //if (strxzwf.Equals("l_zddx"))
                            //{
                            //    ////是否開機准分
                            //    //if (strjzf.Equals("1"))
                            //    //{
                            //    //    fullvisitscores = strdw1yfs;
                            //    //    fullhomescores = strdw2yfs;
                            //    //    fullvisitscores = Convert.ToString(Convert.ToDecimal(fullvisitscores) - d_zdf);
                            //    //    fullhomescores = Convert.ToString(Convert.ToDecimal(fullhomescores) - d_rdf);
                            //    //}
                            //}
                            if (strlx.Equals("b_zs"))
                            {
                                ics = Convert.ToInt32(GetGWS(fullvisitscores));
                                if (ics >= 5)
                                {
                                    if (strdw.Equals("dx_d"))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                else
                                {
                                    if (strdw.Equals("dx_x"))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                #region 输赢　判断
                                ics = Convert.ToInt32(fullvisitscores) + Convert.ToInt32(fullhomescores);
                                if (ics > Convert.ToInt32(strdx))
                                {
                                    if (strdw.Equals(strdw1))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                else if (ics == Convert.ToInt32(strdx))
                                {
                                    chzd = true;
                                    //１平
                                    if (Convert.ToInt32(strdxxt) != 0)
                                    {
                                        if (strdw.Equals(strdw1))
                                        {
                                            if (Convert.ToInt32(strdxxt) >= 0)
                                            {
                                                strkyed = Convert.ToString((Convert.ToDouble(strkyje) * Convert.ToDouble(strdxbl) / 100) + dts * Convert.ToDouble(strdxbl) / 100);
                                                dgg = dggje * Convert.ToDecimal(strdxbl) / 100;
                                            }
                                            else
                                            {
                                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strdxbl) / 100 * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                                dgg = -1 * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strdxbl) / 100;
                                                if (dpl < 0)
                                                {
                                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strdxbl) / 100 * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                                    dgg = dpl * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strdxbl) / 100;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(strdxxt) >= 0)
                                            {
                                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strdxbl) / 100 * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                                dgg = -1 * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strdxbl) / 100;
                                                if (dpl < 0)
                                                {
                                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(strdxbl) / 100 * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                                    dgg = dpl * Convert.ToDecimal(strxzje) * Convert.ToDecimal(strdxbl) / 100;
                                                }
                                            }
                                            else
                                            {
                                                strkyed = Convert.ToString((Convert.ToDouble(strkyje) * Convert.ToDouble(strdxbl) / 100) + dts * Convert.ToDouble(strdxbl) / 100);
                                                dgg = dggje * Convert.ToDecimal(strdxbl) / 100;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        strkyed = "0";
                                        dgg = 0;
                                    }
                                }
                                else
                                {
                                    if (strdw.Equals(strdw2))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion
                        #region　独赢 　计算
                        else if (strxzwf.Equals("l_dy") || strxzwf.Equals("l_zddy"))
                        {
                            #region 输赢　判断
                            if (Convert.ToInt32(fullvisitscores) > Convert.ToInt32(fullhomescores))
                            {
                                if (strdw.Equals(strdw1))
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                    dgg = dggje;
                                }
                                else
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = -1 * Convert.ToDecimal(strxzje);
                                    if (dpl < 0)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = dpl * Convert.ToDecimal(strxzje);
                                    }
                                }
                            }
                            else if (Convert.ToInt32(fullvisitscores) < Convert.ToInt32(fullhomescores))
                            {
                                if (strdw.Equals(strdw2))
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                    dgg = dggje;
                                }
                                else
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = -1 * Convert.ToDecimal(strxzje);
                                    if (dpl < 0)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = dpl * Convert.ToDecimal(strxzje);
                                    }
                                }
                            }
                            else
                            {

                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                dgg = -1 * Convert.ToDecimal(strxzje);
                                if (dpl < 0)
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = dpl * Convert.ToDecimal(strxzje);
                                }
                            }

                            #endregion
                        }
                        #endregion
                        #region　單双　计算
                        else if (strxzwf.Equals("l_ds") || strxzwf.Equals("l_zdds"))
                        {
                            if (strlx.Equals("b_zs"))
                            {
                                ics = Convert.ToInt32(GetGWS(fullvisitscores));
                                if (ChDS(ics).Equals("單"))
                                {
                                    if (strdw.Equals("ds_d"))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                else
                                {
                                    if (strdw.Equals("ds_s"))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                #region 输赢　判断
                                ics = Convert.ToInt32(fullvisitscores) + Convert.ToInt32(fullhomescores);
                                if (ChDS(ics).Equals("單"))
                                {
                                    if (strdw.Equals(strdw1))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                else
                                {
                                    if (strdw.Equals(strdw2))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion

                        #region　和局　计算
                        else if (strxzwf.Equals("l_hj") || strxzwf.Equals("l_zdhj"))
                        {
                            #region 输赢　判断
                            if (Convert.ToInt32(fullvisitscores) == Convert.ToInt32(fullhomescores))
                            {
                                strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                dgg = dggje;
                            }
                            else
                            {
                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                dgg = -1 * Convert.ToDecimal(strxzje);
                                if (dpl < 0)
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = dpl * Convert.ToDecimal(strxzje);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region　波胆　计算
                        else if (strxzwf.IndexOf("l_bd") > -1)
                        {
                            if (strlx.Equals("b_zq"))
                            {
                                #region 输赢　判断
                                string strbs = strxzwf.Replace("l_bd", "");
                                string strfs = "";
                                //if (strdw.Equals(strdw1))
                                //{
                                strfs = fullvisitscores + fullhomescores;
                                //}
                                //else
                                //{
                                //    strfs = fullhomescores + fullvisitscores;
                                //}

                                //if (Convert.ToInt32(strbs) > 5 || Convert.ToInt32(strbs) == 0)//<5的情况
                                if (strbs != "5")//<5的情况
                                {
                                    if (strfs.Equals(strbs))
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                else//>=5的情况
                                {
                                    bool ch5 = false;
                                    if (Convert.ToInt32(fullvisitscores) >= 5 || Convert.ToInt32(fullhomescores) >= 5)
                                    {
                                        ch5 = true;
                                    }
                                    //if (strdw.Equals(strdw1))
                                    //{
                                    //    if (Convert.ToInt32(fullvisitscores) < 5)
                                    //    {
                                    //        ch5 = false;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    if (Convert.ToInt32(fullhomescores) < 5)
                                    //    {
                                    //        ch5 = false;
                                    //    }
                                    //}
                                    if (ch5)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                #endregion
                            }
                            else if (strlx.Equals("b_zs"))
                            {
                                #region 输赢　判断
                                ics = Convert.ToInt32(GetGWS(fullvisitscores));
                                string strbs = strxzwf.Replace("l_bd", "");
                                if (ics.ToString().Equals(strbs))//贏
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                    dgg = dggje;
                                }
                                else//輸
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = -1 * Convert.ToDecimal(strxzje);
                                    if (dpl < 0)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = dpl * Convert.ToDecimal(strxzje);
                                    }
                                }

                                #endregion
                            }
                        }
                        #endregion

                        #region　入球数 计算
                        else if (strxzwf.IndexOf("l_rqs") > -1)
                        {
                            #region 输赢　判断
                            string strbs = strxzwf.Replace("l_rqs", "");
                            int strfs = Convert.ToInt32(fullvisitscores) + Convert.ToInt32(fullhomescores);

                            string strds = ChDS(strfs);
                            if (strbs.Equals("s"))
                            {

                                if (strds.Equals("雙"))//雙
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                    dgg = dggje;
                                }
                                else
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = -1 * Convert.ToDecimal(strxzje);
                                    if (dpl < 0)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = dpl * Convert.ToDecimal(strxzje);
                                    }
                                }
                            }
                            else if (strbs.Equals("d"))
                            {
                                if (strds.Equals("單"))//雙
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                    dgg = dggje;
                                }
                                else
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = -1 * Convert.ToDecimal(strxzje);
                                    if (dpl < 0)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = dpl * Convert.ToDecimal(strxzje);
                                    }
                                }
                            }
                            else
                            {
                                if (strbs.Equals("7"))
                                {
                                    if (strfs >= 7)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }
                                else
                                {
                                    int imin = Convert.ToInt32(strbs.Substring(0, 1));
                                    int imax = Convert.ToInt32(strbs.Substring(1, 1));
                                    if (imin <= strfs && strfs <= imax)
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                        dgg = dggje;
                                    }
                                    else
                                    {
                                        strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                        dgg = -1 * Convert.ToDecimal(strxzje);
                                        if (dpl < 0)
                                        {
                                            strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                            dgg = dpl * Convert.ToDecimal(strxzje);
                                        }
                                    }
                                }

                            }
                            #endregion
                        }
                        #endregion

                        #region　半全场  计算
                        else if (strxzwf.IndexOf("l_bqc") > -1)
                        {
                            #region 输赢　判断
                            string strbs = strxzwf.Replace("l_bqc", "");
                            int iuphfs = 0; int.TryParse(halfvisitscores, out iuphfs);
                            int iupvfs = 0; int.TryParse(halfhomescores, out iupvfs);
                            int iqhfs = 0; int.TryParse(fullvisitscores, out iqhfs);
                            int iqvfs = 0; int.TryParse(fullhomescores, out iqvfs);
                            string strsb = "";
                            string strqb = "";
                            if (iuphfs == iupvfs)
                            {
                                strsb = "h";
                            }
                            else if (iuphfs > iupvfs)
                            {
                                //if (strdw1.Equals(strdw))
                                //{
                                strsb = "z";
                                //}
                                //else
                                //{
                                //    strsb = "k";
                                //}
                            }
                            else
                            {
                                //if (strdw2.Equals(strdw))
                                //{
                                //    strsb = "z";
                                //}
                                //else
                                //{
                                strsb = "k";
                                //}
                            }
                            if (iqhfs == iqvfs)
                            {
                                strqb = "h";
                            }
                            else if (iqhfs > iqvfs)
                            {
                                //if (strdw1.Equals(strdw))
                                //{
                                strqb = "z";
                                //}
                                //else
                                //{
                                //    strqb = "k";
                                //}
                            }
                            else
                            {
                                //if (strdw2.Equals(strdw))
                                //{
                                //    strqb = "z";
                                //}
                                //else
                                //{
                                strqb = "k";
                                //}
                            }
                            string strfs = strsb + strqb;


                            if (strbs.Equals(strfs))//雙
                            {
                                strkyed = Convert.ToString(Convert.ToDouble(strkyje) + dts);
                                dgg = dggje;
                            }
                            else
                            {
                                strkyed = Convert.ToString(Convert.ToDouble(strxzje) * (-1) * (1 - Convert.ToDouble(strty) / 10000));
                                dgg = -1 * Convert.ToDecimal(strxzje);
                                if (dpl < 0)
                                {
                                    strkyed = Convert.ToString(Convert.ToDouble(strxzje) * Convert.ToDouble(dpl) * (1 - Convert.ToDouble(strty) / 10000));
                                    dgg = dpl * Convert.ToDecimal(strxzje);
                                }
                            }
                            #endregion
                        }
                        #endregion

                    }
                    else
                    {
                        strps = "賽事取消";
                        dgg = -1;
                    }
                }
                string dkyje = rows["n_kyje"].ToString();
                string strdlty = rows["n_dlty"].ToString();
                string strzdlty = rows["n_zdlty"].ToString();
                string strgdty = rows["n_gdty"].ToString();
                string strzgdty = rows["n_dgdty"].ToString();
                string strzjty = rows["n_zjty"].ToString();
                string strdzjty = rows["n_dzjty"].ToString();
                Decimal dljg = 0;
                Decimal zdljg = 0;
                Decimal gdjg = 0;
                Decimal dgdjg = 0;
                Decimal zjjg = 0;
                Decimal dzjjg = 0;
                Decimal dlscz = 0;

                if (!strtype.Equals("3"))
                {


                    mo_PTZD.N_SYJG = Convert.ToDecimal(strkyed);
                    mo_PTZD.N_HYJG = Convert.ToDecimal(strkyed);

                    string strnr = matchBillContent(rows, strdw1yfs, strdw2yfs);
                    mo_PTZD.N_XZNR = strnr.Replace("賽事取消", "") + " " + strps;


                    //實際輸贏
                    Decimal dzs = Convert.ToDecimal(strxzje);
                    Decimal dhysy = 0;
                    if (chzd == true)
                    {
                        if (!strbl.Equals("0"))
                        {
                            dzs = dzs * Convert.ToDecimal(strbl) / 100;
                        }
                        else if (!strdxbl.Equals("0"))
                        {
                            dzs = dzs * Convert.ToDecimal(strdxbl) / 100;
                        }
                    }


                    Decimal hysq = dzs * Convert.ToDecimal(strty) / 10000;
                    dhysy = Convert.ToDecimal(strkyed) - Convert.ToDecimal(hysq);
                    dlscz = Convert.ToDecimal(dhysy) + (dzs * Convert.ToDecimal(strdlty) / 10000);


                    if (!strkyed.Equals("0"))
                    {
                        dljg = (dhysy + dzs * (Convert.ToDecimal(strdlty) / 10000)) * (1 - Convert.ToDecimal(strdlcz) / 100);
                        zdljg = (dhysy + dzs * (Convert.ToDecimal(strzdlty) / 10000)) * (1 - Convert.ToDecimal(strzdlcz) / 100);
                        gdjg = (dhysy + dzs * (Convert.ToDecimal(strgdty) / 10000)) * (1 - Convert.ToDecimal(strgdcz) / 100);
                        dgdjg = (dhysy + dzs * (Convert.ToDecimal(strzgdty) / 10000)) * (1 - Convert.ToDecimal(strzgdcz) / 100);
                        zjjg = (dhysy + dzs * (Convert.ToDecimal(strzjty) / 10000)) * (1 - Convert.ToDecimal(strzjcz) / 100);
                        dzjjg = (dhysy + dzs * (Convert.ToDecimal(strdzjty) / 10000)) * (1 - Convert.ToDecimal(strdzjcz) / 100);

                        //strgszc = Comm.GetZC(strbslx, M_MRZJ);
                        gsjg = (dhysy + dzs * (Convert.ToDecimal(strdzjty) / 10000)) * (1 - Convert.ToDecimal(strgszc) / 100);
                    }
                    else
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


                    mo_PTZD.N_DLSJG = dljg;
                    mo_PTZD.N_ZDLJG = zdljg;
                    mo_PTZD.N_GDJG = gdjg;
                    mo_PTZD.N_DGDJG = dgdjg;
                    mo_PTZD.N_ZJJG = zjjg;
                    mo_PTZD.N_DZJJG = dzjjg;
                    mo_PTZD.N_GSJG = gsjg;
                    mo_PTZD.N_JS = 1;
                    mo_PTZD.N_DLSWCZ = dlscz;

                    //if (!strflag.Equals("1"))
                    //{
                    //    o_PTZD.UPJS(mo_PTZD);
                    //}
                    //else
                    //{
                    //    o_PTZD.UPOJS(mo_PTZD);
                    //}
                    //KingOfBall.BLL.KFB_HYGL_BLL o_HYGL = new KingOfBall.BLL.KFB_HYGL_BLL();
                    decimal creditBeore = count.GetCredit(mo_PTZD.N_HYDH);
                    int no = count.GetNo();
                    string type = "";
                    if (mo_PTZD.N_DEL.Value != 1)
                    {
                        if (tempJS.Equals("1"))//已進行過計算
                        {
                            count.ReSetCredit(mo_PTZD.N_HYDH, (mo_PTZD.N_HYJG.Value - tempHYJG) / 10000);
                            type = "3";
                        }
                        else
                        {
                            count.ReSetCredit(mo_PTZD.N_HYDH, (mo_PTZD.N_XZJE.Value + mo_PTZD.N_HYJG.Value) / 10000);
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
                    if (bcz)
                    {
                        count.CountBill(mo_PTZD);
                    }
                    else
                    {
                        count.ReCountBill(mo_PTZD);
                    }
                    decimal creditAfter = count.GetCredit(mo_PTZD.N_HYDH);
                    count.InsertCreditLog(no, sysDateNow, type, mo_PTZD.N_HYDH, creditBeore * 10000M, creditAfter * 10000M);
                    count.InsertBillLog(no, mo_PTZD.N_HYDH, mo_PTZD.N_XZDH, strid, mo_PTZD.N_XZJE.Value, tempHYJG, mo_PTZD.N_HYJG.Value, sysDateNow, type);

                }
                else//过关
                {
                    string strnr = matchBillContent(rows, strdw1yfs, strdw2yfs);
                    mo_PTZD.N_XZNR = strnr.Replace("賽事取消", "") + " " + strps;

                    if (dgg == 0)
                    {
                        dgg = -1;
                    }
                    mo_PTZD.N_GGJG = dgg;
                    // mo_PTZD.N_JS = 1;
                    //o_PTZD.UPGG(mo_PTZD);

                    if (bcz)
                    {
                        count.SetPassBill(mo_PTZD);
                    }
                    else
                    {
                        count.ReSetPassBill(mo_PTZD);
                    }
                }
            }
            count.Commit();
        }
        catch (Exception ex)
        {
            count.Rollback();
            LogDB.Error("Count Error！！", ex);
            throw ex;
        }
        finally
        {
            count.Close();
            LogDB.Info("fullvisitscores:" + fullvisitscores + ",fullhomescores:" + fullhomescores + ",strid:" + strid + ",str9j:" + str9j + ",halfvisitscores:" + halfvisitscores + ",halfhomescores:" + halfhomescores + ",strflag:" + strflag);
        }
    }
    #region 取得個位數
    /// <summary>
    /// 取得個位數
    /// </summary>
    /// <param name="o_aPK"></param>
    /// <returns></returns>
    public static string GetGWS(string strtype)
    {
        string s_Result = "";
        if (strtype.IndexOf(".") > -1)
        {
            s_Result = strtype.Substring(strtype.IndexOf(".") - 1, 1);
        }
        else
        {
            s_Result = strtype.Substring(strtype.Length - 1, 1);
        }
        return s_Result;
    }
    #endregion
    /// <summary>
    /// 判斷單雙
    /// </summary>
    /// 
    public static string ChDS(int i_num)
    {
        string strreturn = "";
        if (i_num >= 0)
        {
            if (i_num % 2 == 1)
            {
                strreturn = "單";
            }
            else
            {
                strreturn = "雙";
            }
        }
        return strreturn;
    }
    private static string matchBillContent(DataRow dr, string visitResult, string homeResult)
    {
        string result1 = "[" + visitResult + "]";
        string result2 = "[" + homeResult + "]";
        if (dr["n_rffs"].ToString().Equals("1") && dr["n_xzwf"].ToString().ToUpper().IndexOf("RF") > -1)//只有让分才互换比赛结果
        {
            result1 = "[" + homeResult + "]";
            result2 = "[" + visitResult + "]";
        }
        Regex reg = new Regex(@"\[[0-9-]+\]");
        int index = 0;
        string result = reg.Replace(dr["n_xznr"].ToString(), new MatchEvaluator(delegate(Match match)
        {
            index++;
            if (index == 1)
            {
                return result1;
            }
            else
            {
                return result2;
            }
        }));
        result = string.Format(result, result1, result2);
        return result;
    }
}
