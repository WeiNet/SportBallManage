using KingOfBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


public class AgentManageAddDB
{
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_MRZJ GetModel()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("SELECT * FROM ( SELECT  * from KFB_MRZJ  ORDER BY N_UPDATE   DESC ) WHERE ROWNUM=1");
        KFB_MRZJ model = new KFB_MRZJ();
        DataSet ds = DbHelperOra.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["N_LQRFTY"].ToString() != "")
            {
                model.N_LQRFTY = float.Parse(ds.Tables[0].Rows[0]["N_LQRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDXTY"].ToString() != "")
            {
                model.N_LQDXTY = float.Parse(ds.Tables[0].Rows[0]["N_LQDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDYTY"].ToString() != "")
            {
                model.N_LQDYTY = float.Parse(ds.Tables[0].Rows[0]["N_LQDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDSTY"].ToString() != "")
            {
                model.N_LQDSTY = float.Parse(ds.Tables[0].Rows[0]["N_LQDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDRFTY"].ToString() != "")
            {
                model.N_LQZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_LQZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDDXTY"].ToString() != "")
            {
                model.N_LQZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_LQZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCRFTY"].ToString() != "")
            {
                model.N_LQBCRFTY = float.Parse(ds.Tables[0].Rows[0]["N_LQBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDXTY"].ToString() != "")
            {
                model.N_LQBCDXTY = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDYTY"].ToString() != "")
            {
                model.N_LQBCDYTY = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDSTY"].ToString() != "")
            {
                model.N_LQBCDSTY = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGGTY"].ToString() != "")
            {
                model.N_LQGGTY = float.Parse(ds.Tables[0].Rows[0]["N_LQGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGJTY"].ToString() != "")
            {
                model.N_LQGJTY = float.Parse(ds.Tables[0].Rows[0]["N_LQGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQRFDZ"].ToString() != "")
            {
                model.N_LQRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDXDZ"].ToString() != "")
            {
                model.N_LQDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDYDZ"].ToString() != "")
            {
                model.N_LQDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDSDZ"].ToString() != "")
            {
                model.N_LQDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDRFDZ"].ToString() != "")
            {
                model.N_LQZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDDXDZ"].ToString() != "")
            {
                model.N_LQZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCRFDZ"].ToString() != "")
            {
                model.N_LQBCRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQBCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDXDZ"].ToString() != "")
            {
                model.N_LQBCDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDYDZ"].ToString() != "")
            {
                model.N_LQBCDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDSDZ"].ToString() != "")
            {
                model.N_LQBCDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGGDZ"].ToString() != "")
            {
                model.N_LQGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGJDZ"].ToString() != "")
            {
                model.N_LQGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQRFDC"].ToString() != "")
            {
                model.N_LQRFDC = float.Parse(ds.Tables[0].Rows[0]["N_LQRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDXDC"].ToString() != "")
            {
                model.N_LQDXDC = float.Parse(ds.Tables[0].Rows[0]["N_LQDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDYDC"].ToString() != "")
            {
                model.N_LQDYDC = float.Parse(ds.Tables[0].Rows[0]["N_LQDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDSDC"].ToString() != "")
            {
                model.N_LQDSDC = float.Parse(ds.Tables[0].Rows[0]["N_LQDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDRFDC"].ToString() != "")
            {
                model.N_LQZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_LQZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDDXDC"].ToString() != "")
            {
                model.N_LQZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_LQZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCRFDC"].ToString() != "")
            {
                model.N_LQBCRFDC = float.Parse(ds.Tables[0].Rows[0]["N_LQBCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDXDC"].ToString() != "")
            {
                model.N_LQBCDXDC = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDYDC"].ToString() != "")
            {
                model.N_LQBCDYDC = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDSDC"].ToString() != "")
            {
                model.N_LQBCDSDC = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGGDC"].ToString() != "")
            {
                model.N_LQGGDC = float.Parse(ds.Tables[0].Rows[0]["N_LQGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGJDC"].ToString() != "")
            {
                model.N_LQGJDC = float.Parse(ds.Tables[0].Rows[0]["N_LQGJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBRFTY"].ToString() != "")
            {
                model.N_MBRFTY = float.Parse(ds.Tables[0].Rows[0]["N_MBRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDXTY"].ToString() != "")
            {
                model.N_MBDXTY = float.Parse(ds.Tables[0].Rows[0]["N_MBDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDYTY"].ToString() != "")
            {
                model.N_MBDYTY = float.Parse(ds.Tables[0].Rows[0]["N_MBDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDSTY"].ToString() != "")
            {
                model.N_MBDSTY = float.Parse(ds.Tables[0].Rows[0]["N_MBDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBZDRFTY"].ToString() != "")
            {
                model.N_MBZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_MBZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBZDDXTY"].ToString() != "")
            {
                model.N_MBZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_MBZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBSYTY"].ToString() != "")
            {
                model.N_MBSYTY = float.Parse(ds.Tables[0].Rows[0]["N_MBSYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBGGTY"].ToString() != "")
            {
                model.N_MBGGTY = float.Parse(ds.Tables[0].Rows[0]["N_MBGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBGJTY"].ToString() != "")
            {
                model.N_MBGJTY = float.Parse(ds.Tables[0].Rows[0]["N_MBGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBRFDZ"].ToString() != "")
            {
                model.N_MBRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDXDZ"].ToString() != "")
            {
                model.N_MBDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDYDZ"].ToString() != "")
            {
                model.N_MBDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDSDZ"].ToString() != "")
            {
                model.N_MBDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBZDRFDZ"].ToString() != "")
            {
                model.N_MBZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBZDDXDZ"].ToString() != "")
            {
                model.N_MBZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBSYDZ"].ToString() != "")
            {
                model.N_MBSYDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBSYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBGGDZ"].ToString() != "")
            {
                model.N_MBGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBGJDZ"].ToString() != "")
            {
                model.N_MBGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_MBGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBRFDC"].ToString() != "")
            {
                model.N_MBRFDC = float.Parse(ds.Tables[0].Rows[0]["N_MBRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDXDC"].ToString() != "")
            {
                model.N_MBDXDC = float.Parse(ds.Tables[0].Rows[0]["N_MBDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDYDC"].ToString() != "")
            {
                model.N_MBDYDC = float.Parse(ds.Tables[0].Rows[0]["N_MBDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBDSDC"].ToString() != "")
            {
                model.N_MBDSDC = float.Parse(ds.Tables[0].Rows[0]["N_MBDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBZDRFDC"].ToString() != "")
            {
                model.N_MBZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_MBZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBZDDXDC"].ToString() != "")
            {
                model.N_MBZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_MBZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBSYDC"].ToString() != "")
            {
                model.N_MBSYDC = float.Parse(ds.Tables[0].Rows[0]["N_MBSYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBGGDC"].ToString() != "")
            {
                model.N_MBGGDC = float.Parse(ds.Tables[0].Rows[0]["N_MBGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MBGJDC"].ToString() != "")
            {
                model.N_MBGJDC = float.Parse(ds.Tables[0].Rows[0]["N_MBGJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBRFTY"].ToString() != "")
            {
                model.N_RBRFTY = float.Parse(ds.Tables[0].Rows[0]["N_RBRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDXTY"].ToString() != "")
            {
                model.N_RBDXTY = float.Parse(ds.Tables[0].Rows[0]["N_RBDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDYTY"].ToString() != "")
            {
                model.N_RBDYTY = float.Parse(ds.Tables[0].Rows[0]["N_RBDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDSTY"].ToString() != "")
            {
                model.N_RBDSTY = float.Parse(ds.Tables[0].Rows[0]["N_RBDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBZDRFTY"].ToString() != "")
            {
                model.N_RBZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_RBZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBZDDXTY"].ToString() != "")
            {
                model.N_RBZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_RBZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBSYTY"].ToString() != "")
            {
                model.N_RBSYTY = float.Parse(ds.Tables[0].Rows[0]["N_RBSYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBGGTY"].ToString() != "")
            {
                model.N_RBGGTY = float.Parse(ds.Tables[0].Rows[0]["N_RBGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBGJTY"].ToString() != "")
            {
                model.N_RBGJTY = float.Parse(ds.Tables[0].Rows[0]["N_RBGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBRFDZ"].ToString() != "")
            {
                model.N_RBRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDXDZ"].ToString() != "")
            {
                model.N_RBDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDYDZ"].ToString() != "")
            {
                model.N_RBDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDSDZ"].ToString() != "")
            {
                model.N_RBDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBZDRFDZ"].ToString() != "")
            {
                model.N_RBZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBZDDXDZ"].ToString() != "")
            {
                model.N_RBZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBSYDZ"].ToString() != "")
            {
                model.N_RBSYDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBSYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBGGDZ"].ToString() != "")
            {
                model.N_RBGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBGJDZ"].ToString() != "")
            {
                model.N_RBGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_RBGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBRFDC"].ToString() != "")
            {
                model.N_RBRFDC = float.Parse(ds.Tables[0].Rows[0]["N_RBRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDXDC"].ToString() != "")
            {
                model.N_RBDXDC = float.Parse(ds.Tables[0].Rows[0]["N_RBDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDYDC"].ToString() != "")
            {
                model.N_RBDYDC = float.Parse(ds.Tables[0].Rows[0]["N_RBDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBDSDC"].ToString() != "")
            {
                model.N_RBDSDC = float.Parse(ds.Tables[0].Rows[0]["N_RBDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBZDRFDC"].ToString() != "")
            {
                model.N_RBZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_RBZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBZDDXDC"].ToString() != "")
            {
                model.N_RBZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_RBZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBSYDC"].ToString() != "")
            {
                model.N_RBSYDC = float.Parse(ds.Tables[0].Rows[0]["N_RBSYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBGGDC"].ToString() != "")
            {
                model.N_RBGGDC = float.Parse(ds.Tables[0].Rows[0]["N_RBGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RBGJDC"].ToString() != "")
            {
                model.N_RBGJDC = float.Parse(ds.Tables[0].Rows[0]["N_RBGJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQARFTY"].ToString() != "")
            {
                model.N_ZQARFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQARFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQADXTY"].ToString() != "")
            {
                model.N_ZQADXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQADXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQADYTY"].ToString() != "")
            {
                model.N_ZQADYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQADYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQADSTY"].ToString() != "")
            {
                model.N_ZQADSTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQADSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQAZDRFTY"].ToString() != "")
            {
                model.N_ZQAZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQAZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQAZDDXTY"].ToString() != "")
            {
                model.N_ZQAZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQAZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQABCRFTY"].ToString() != "")
            {
                model.N_ZQABCRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQABCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQABCDXTY"].ToString() != "")
            {
                model.N_ZQABCDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQABCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQABCDYTY"].ToString() != "")
            {
                model.N_ZQABCDYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQABCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQARQSTY"].ToString() != "")
            {
                model.N_ZQARQSTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQARQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQABDTY"].ToString() != "")
            {
                model.N_ZQABDTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQABDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQABQCTY"].ToString() != "")
            {
                model.N_ZQABQCTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQABQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQAGGTY"].ToString() != "")
            {
                model.N_ZQAGGTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQAGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQAGJTY"].ToString() != "")
            {
                model.N_ZQAGJTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQAGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBRFTY"].ToString() != "")
            {
                model.N_ZQBRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBDXTY"].ToString() != "")
            {
                model.N_ZQBDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBDYTY"].ToString() != "")
            {
                model.N_ZQBDYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBDSTY"].ToString() != "")
            {
                model.N_ZQBDSTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBZDRFTY"].ToString() != "")
            {
                model.N_ZQBZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBZDDXTY"].ToString() != "")
            {
                model.N_ZQBZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBBCRFTY"].ToString() != "")
            {
                model.N_ZQBBCRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBBCDXTY"].ToString() != "")
            {
                model.N_ZQBBCDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBBCDYTY"].ToString() != "")
            {
                model.N_ZQBBCDYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBRQSTY"].ToString() != "")
            {
                model.N_ZQBRQSTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBRQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBBDTY"].ToString() != "")
            {
                model.N_ZQBBDTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBBDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBBQCTY"].ToString() != "")
            {
                model.N_ZQBBQCTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBBQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBGGTY"].ToString() != "")
            {
                model.N_ZQBGGTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBGJTY"].ToString() != "")
            {
                model.N_ZQBGJTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQBGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCRFTY"].ToString() != "")
            {
                model.N_ZQCRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCDXTY"].ToString() != "")
            {
                model.N_ZQCDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCDYTY"].ToString() != "")
            {
                model.N_ZQCDYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCDSTY"].ToString() != "")
            {
                model.N_ZQCDSTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCZDRFTY"].ToString() != "")
            {
                model.N_ZQCZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCZDDXTY"].ToString() != "")
            {
                model.N_ZQCZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCBCRFTY"].ToString() != "")
            {
                model.N_ZQCBCRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCBCDXTY"].ToString() != "")
            {
                model.N_ZQCBCDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCBCDYTY"].ToString() != "")
            {
                model.N_ZQCBCDYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCRQSTY"].ToString() != "")
            {
                model.N_ZQCRQSTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCRQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCBDTY"].ToString() != "")
            {
                model.N_ZQCBDTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCBDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCBQCTY"].ToString() != "")
            {
                model.N_ZQCBQCTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCBQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCGGTY"].ToString() != "")
            {
                model.N_ZQCGGTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQCGJTY"].ToString() != "")
            {
                model.N_ZQCGJTY = float.Parse(ds.Tables[0].Rows[0]["N_ZQCGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQRFDZ"].ToString() != "")
            {
                model.N_ZQRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDXDZ"].ToString() != "")
            {
                model.N_ZQDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDYDZ"].ToString() != "")
            {
                model.N_ZQDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDSDZ"].ToString() != "")
            {
                model.N_ZQDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQZDRFDZ"].ToString() != "")
            {
                model.N_ZQZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQZDDXDZ"].ToString() != "")
            {
                model.N_ZQZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBCRFDZ"].ToString() != "")
            {
                model.N_ZQBCRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQBCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBCDXDZ"].ToString() != "")
            {
                model.N_ZQBCDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQBCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBCDYDZ"].ToString() != "")
            {
                model.N_ZQBCDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQBCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQRQSDZ"].ToString() != "")
            {
                model.N_ZQRQSDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQRQSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBDDZ"].ToString() != "")
            {
                model.N_ZQBDDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQBDDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBQCDZ"].ToString() != "")
            {
                model.N_ZQBQCDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQBQCDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQGGDZ"].ToString() != "")
            {
                model.N_ZQGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQGJDZ"].ToString() != "")
            {
                model.N_ZQGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZQGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQRFDC"].ToString() != "")
            {
                model.N_ZQRFDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDXDC"].ToString() != "")
            {
                model.N_ZQDXDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDYDC"].ToString() != "")
            {
                model.N_ZQDYDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDSDC"].ToString() != "")
            {
                model.N_ZQDSDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQZDRFDC"].ToString() != "")
            {
                model.N_ZQZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQZDDXDC"].ToString() != "")
            {
                model.N_ZQZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBCRFDC"].ToString() != "")
            {
                model.N_ZQBCRFDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQBCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBCDXDC"].ToString() != "")
            {
                model.N_ZQBCDXDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQBCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBCDYDC"].ToString() != "")
            {
                model.N_ZQBCDYDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQBCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQRQSDC"].ToString() != "")
            {
                model.N_ZQRQSDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQRQSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBDDC"].ToString() != "")
            {
                model.N_ZQBDDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQBDDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQBQCDC"].ToString() != "")
            {
                model.N_ZQBQCDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQBQCDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQGGDC"].ToString() != "")
            {
                model.N_ZQGGDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQGJDC"].ToString() != "")
            {
                model.N_ZQGJDC = float.Parse(ds.Tables[0].Rows[0]["N_ZQGJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZRFTY"].ToString() != "")
            {
                model.N_MZRFTY = float.Parse(ds.Tables[0].Rows[0]["N_MZRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDXTY"].ToString() != "")
            {
                model.N_MZDXTY = float.Parse(ds.Tables[0].Rows[0]["N_MZDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDYTY"].ToString() != "")
            {
                model.N_MZDYTY = float.Parse(ds.Tables[0].Rows[0]["N_MZDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDSTY"].ToString() != "")
            {
                model.N_MZDSTY = float.Parse(ds.Tables[0].Rows[0]["N_MZDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZZDRFTY"].ToString() != "")
            {
                model.N_MZZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_MZZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZZDDXTY"].ToString() != "")
            {
                model.N_MZZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_MZZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCRFTY"].ToString() != "")
            {
                model.N_MZBCRFTY = float.Parse(ds.Tables[0].Rows[0]["N_MZBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDXTY"].ToString() != "")
            {
                model.N_MZBCDXTY = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDYTY"].ToString() != "")
            {
                model.N_MZBCDYTY = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDSTY"].ToString() != "")
            {
                model.N_MZBCDSTY = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZGGTY"].ToString() != "")
            {
                model.N_MZGGTY = float.Parse(ds.Tables[0].Rows[0]["N_MZGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZGJTY"].ToString() != "")
            {
                model.N_MZGJTY = float.Parse(ds.Tables[0].Rows[0]["N_MZGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZRFDZ"].ToString() != "")
            {
                model.N_MZRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDXDZ"].ToString() != "")
            {
                model.N_MZDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDYDZ"].ToString() != "")
            {
                model.N_MZDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDSDZ"].ToString() != "")
            {
                model.N_MZDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZZDRFDZ"].ToString() != "")
            {
                model.N_MZZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZZDDXDZ"].ToString() != "")
            {
                model.N_MZZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCRFDZ"].ToString() != "")
            {
                model.N_MZBCRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZBCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDXDZ"].ToString() != "")
            {
                model.N_MZBCDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDYDZ"].ToString() != "")
            {
                model.N_MZBCDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDSDZ"].ToString() != "")
            {
                model.N_MZBCDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZGGDZ"].ToString() != "")
            {
                model.N_MZGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZGJDZ"].ToString() != "")
            {
                model.N_MZGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_MZGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZRFDC"].ToString() != "")
            {
                model.N_MZRFDC = float.Parse(ds.Tables[0].Rows[0]["N_MZRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDXDC"].ToString() != "")
            {
                model.N_MZDXDC = float.Parse(ds.Tables[0].Rows[0]["N_MZDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDYDC"].ToString() != "")
            {
                model.N_MZDYDC = float.Parse(ds.Tables[0].Rows[0]["N_MZDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZDSDC"].ToString() != "")
            {
                model.N_MZDSDC = float.Parse(ds.Tables[0].Rows[0]["N_MZDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZZDRFDC"].ToString() != "")
            {
                model.N_MZZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_MZZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZZDDXDC"].ToString() != "")
            {
                model.N_MZZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_MZZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCRFDC"].ToString() != "")
            {
                model.N_MZBCRFDC = float.Parse(ds.Tables[0].Rows[0]["N_MZBCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDXDC"].ToString() != "")
            {
                model.N_MZBCDXDC = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDYDC"].ToString() != "")
            {
                model.N_MZBCDYDC = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZBCDSDC"].ToString() != "")
            {
                model.N_MZBCDSDC = float.Parse(ds.Tables[0].Rows[0]["N_MZBCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZGGDC"].ToString() != "")
            {
                model.N_MZGGDC = float.Parse(ds.Tables[0].Rows[0]["N_MZGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZGJDC"].ToString() != "")
            {
                model.N_MZGJDC = float.Parse(ds.Tables[0].Rows[0]["N_MZGJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBRFTY"].ToString() != "")
            {
                model.N_TBRFTY = float.Parse(ds.Tables[0].Rows[0]["N_TBRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDXTY"].ToString() != "")
            {
                model.N_TBDXTY = float.Parse(ds.Tables[0].Rows[0]["N_TBDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDYTY"].ToString() != "")
            {
                model.N_TBDYTY = float.Parse(ds.Tables[0].Rows[0]["N_TBDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDSTY"].ToString() != "")
            {
                model.N_TBDSTY = float.Parse(ds.Tables[0].Rows[0]["N_TBDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBZDRFTY"].ToString() != "")
            {
                model.N_TBZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_TBZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBZDDXTY"].ToString() != "")
            {
                model.N_TBZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_TBZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBSYTY"].ToString() != "")
            {
                model.N_TBSYTY = float.Parse(ds.Tables[0].Rows[0]["N_TBSYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBGGTY"].ToString() != "")
            {
                model.N_TBGGTY = float.Parse(ds.Tables[0].Rows[0]["N_TBGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBGJTY"].ToString() != "")
            {
                model.N_TBGJTY = float.Parse(ds.Tables[0].Rows[0]["N_TBGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBRFDZ"].ToString() != "")
            {
                model.N_TBRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDXDZ"].ToString() != "")
            {
                model.N_TBDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDYDZ"].ToString() != "")
            {
                model.N_TBDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDSDZ"].ToString() != "")
            {
                model.N_TBDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBZDRFDZ"].ToString() != "")
            {
                model.N_TBZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBZDDXDZ"].ToString() != "")
            {
                model.N_TBZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBSYDZ"].ToString() != "")
            {
                model.N_TBSYDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBSYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBGGDZ"].ToString() != "")
            {
                model.N_TBGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBGJDZ"].ToString() != "")
            {
                model.N_TBGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_TBGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBRFDC"].ToString() != "")
            {
                model.N_TBRFDC = float.Parse(ds.Tables[0].Rows[0]["N_TBRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDXDC"].ToString() != "")
            {
                model.N_TBDXDC = float.Parse(ds.Tables[0].Rows[0]["N_TBDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDYDC"].ToString() != "")
            {
                model.N_TBDYDC = float.Parse(ds.Tables[0].Rows[0]["N_TBDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBDSDC"].ToString() != "")
            {
                model.N_TBDSDC = float.Parse(ds.Tables[0].Rows[0]["N_TBDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBZDRFDC"].ToString() != "")
            {
                model.N_TBZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_TBZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBZDDXDC"].ToString() != "")
            {
                model.N_TBZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_TBZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBSYDC"].ToString() != "")
            {
                model.N_TBSYDC = float.Parse(ds.Tables[0].Rows[0]["N_TBSYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBGGDC"].ToString() != "")
            {
                model.N_TBGGDC = float.Parse(ds.Tables[0].Rows[0]["N_TBGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBGJDC"].ToString() != "")
            {
                model.N_TBGJDC = float.Parse(ds.Tables[0].Rows[0]["N_TBGJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQ"].ToString() != "")
            {
                model.N_LQ = int.Parse(ds.Tables[0].Rows[0]["N_LQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MB"].ToString() != "")
            {
                model.N_MB = int.Parse(ds.Tables[0].Rows[0]["N_MB"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RB"].ToString() != "")
            {
                model.N_RB = int.Parse(ds.Tables[0].Rows[0]["N_RB"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TB"].ToString() != "")
            {
                model.N_TB = int.Parse(ds.Tables[0].Rows[0]["N_TB"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQ"].ToString() != "")
            {
                model.N_ZQ = int.Parse(ds.Tables[0].Rows[0]["N_ZQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_MZ"].ToString() != "")
            {
                model.N_MZ = int.Parse(ds.Tables[0].Rows[0]["N_MZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZS"].ToString() != "")
            {
                model.N_ZS = int.Parse(ds.Tables[0].Rows[0]["N_ZS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SM"].ToString() != "")
            {
                model.N_SM = int.Parse(ds.Tables[0].Rows[0]["N_SM"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLT"].ToString() != "")
            {
                model.N_DLT = int.Parse(ds.Tables[0].Rows[0]["N_DLT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CP"].ToString() != "")
            {
                model.N_CP = int.Parse(ds.Tables[0].Rows[0]["N_CP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2X"].ToString() != "")
            {
                model.N_2X = int.Parse(ds.Tables[0].Rows[0]["N_2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3X"].ToString() != "")
            {
                model.N_3X = int.Parse(ds.Tables[0].Rows[0]["N_3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4X"].ToString() != "")
            {
                model.N_4X = int.Parse(ds.Tables[0].Rows[0]["N_4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSRFTY"].ToString() != "")
            {
                model.N_ZSRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDXTY"].ToString() != "")
            {
                model.N_ZSDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDYTY"].ToString() != "")
            {
                model.N_ZSDYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDSTY"].ToString() != "")
            {
                model.N_ZSDSTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSZDRFTY"].ToString() != "")
            {
                model.N_ZSZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSZDDXTY"].ToString() != "")
            {
                model.N_ZSZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSSYTY"].ToString() != "")
            {
                model.N_ZSSYTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSSYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSGGTY"].ToString() != "")
            {
                model.N_ZSGGTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSGJTY"].ToString() != "")
            {
                model.N_ZSGJTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSRFDZ"].ToString() != "")
            {
                model.N_ZSRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDXDZ"].ToString() != "")
            {
                model.N_ZSDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDYDZ"].ToString() != "")
            {
                model.N_ZSDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDSDZ"].ToString() != "")
            {
                model.N_ZSDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSZDRFDZ"].ToString() != "")
            {
                model.N_ZSZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSZDDXDZ"].ToString() != "")
            {
                model.N_ZSZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSSYDZ"].ToString() != "")
            {
                model.N_ZSSYDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSSYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSGGDZ"].ToString() != "")
            {
                model.N_ZSGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSGJDZ"].ToString() != "")
            {
                model.N_ZSGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZSGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSRFDC"].ToString() != "")
            {
                model.N_ZSRFDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDXDC"].ToString() != "")
            {
                model.N_ZSDXDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDYDC"].ToString() != "")
            {
                model.N_ZSDYDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSDSDC"].ToString() != "")
            {
                model.N_ZSDSDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSZDRFDC"].ToString() != "")
            {
                model.N_ZSZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSZDDXDC"].ToString() != "")
            {
                model.N_ZSZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSSYDC"].ToString() != "")
            {
                model.N_ZSSYDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSSYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSGGDC"].ToString() != "")
            {
                model.N_ZSGGDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSGJDC"].ToString() != "")
            {
                model.N_ZSGJDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSGJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSBDTY"].ToString() != "")
            {
                model.N_ZSBDTY = float.Parse(ds.Tables[0].Rows[0]["N_ZSBDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZBDDZ"].ToString() != "")
            {
                model.N_ZBDDZ = float.Parse(ds.Tables[0].Rows[0]["N_ZBDDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZSBDDC"].ToString() != "")
            {
                model.N_ZSBDDC = float.Parse(ds.Tables[0].Rows[0]["N_ZSBDDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMTYDY"].ToString() != "")
            {
                model.N_SMTYDY = float.Parse(ds.Tables[0].Rows[0]["N_SMTYDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMTYWZ"].ToString() != "")
            {
                model.N_SMTYWZ = float.Parse(ds.Tables[0].Rows[0]["N_SMTYWZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMTYLY"].ToString() != "")
            {
                model.N_SMTYLY = float.Parse(ds.Tables[0].Rows[0]["N_SMTYLY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMTYWZQ"].ToString() != "")
            {
                model.N_SMTYWZQ = float.Parse(ds.Tables[0].Rows[0]["N_SMTYWZQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDZDY"].ToString() != "")
            {
                model.N_SMDZDY = float.Parse(ds.Tables[0].Rows[0]["N_SMDZDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDZWZ"].ToString() != "")
            {
                model.N_SMDZWZ = float.Parse(ds.Tables[0].Rows[0]["N_SMDZWZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDZLY"].ToString() != "")
            {
                model.N_SMDZLY = float.Parse(ds.Tables[0].Rows[0]["N_SMDZLY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDZWZQ"].ToString() != "")
            {
                model.N_SMDZWZQ = float.Parse(ds.Tables[0].Rows[0]["N_SMDZWZQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDCDY"].ToString() != "")
            {
                model.N_SMDCDY = float.Parse(ds.Tables[0].Rows[0]["N_SMDCDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDCWZ"].ToString() != "")
            {
                model.N_SMDCWZ = float.Parse(ds.Tables[0].Rows[0]["N_SMDCWZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDCLY"].ToString() != "")
            {
                model.N_SMDCLY = float.Parse(ds.Tables[0].Rows[0]["N_SMDCLY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SMDCWZQ"].ToString() != "")
            {
                model.N_SMDCWZQ = float.Parse(ds.Tables[0].Rows[0]["N_SMDCWZQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPTYBQ"].ToString() != "")
            {
                model.N_CPTYBQ = float.Parse(ds.Tables[0].Rows[0]["N_CPTYBQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPTYLQ"].ToString() != "")
            {
                model.N_CPTYLQ = float.Parse(ds.Tables[0].Rows[0]["N_CPTYLQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPTYZQ"].ToString() != "")
            {
                model.N_CPTYZQ = float.Parse(ds.Tables[0].Rows[0]["N_CPTYZQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPTYGS"].ToString() != "")
            {
                model.N_CPTYGS = float.Parse(ds.Tables[0].Rows[0]["N_CPTYGS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPTYQZ"].ToString() != "")
            {
                model.N_CPTYQZ = float.Parse(ds.Tables[0].Rows[0]["N_CPTYQZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDZBQ"].ToString() != "")
            {
                model.N_CPDZBQ = float.Parse(ds.Tables[0].Rows[0]["N_CPDZBQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDZLQ"].ToString() != "")
            {
                model.N_CPDZLQ = float.Parse(ds.Tables[0].Rows[0]["N_CPDZLQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDZZQ"].ToString() != "")
            {
                model.N_CPDZZQ = float.Parse(ds.Tables[0].Rows[0]["N_CPDZZQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDZGS"].ToString() != "")
            {
                model.N_CPDZGS = float.Parse(ds.Tables[0].Rows[0]["N_CPDZGS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDZQZ"].ToString() != "")
            {
                model.N_CPDZQZ = float.Parse(ds.Tables[0].Rows[0]["N_CPDZQZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDCBQ"].ToString() != "")
            {
                model.N_CPDCBQ = float.Parse(ds.Tables[0].Rows[0]["N_CPDCBQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDCLQ"].ToString() != "")
            {
                model.N_CPDCLQ = float.Parse(ds.Tables[0].Rows[0]["N_CPDCLQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDCZQ"].ToString() != "")
            {
                model.N_CPDCZQ = float.Parse(ds.Tables[0].Rows[0]["N_CPDCZQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDCGS"].ToString() != "")
            {
                model.N_CPDCGS = float.Parse(ds.Tables[0].Rows[0]["N_CPDCGS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CPDCQZ"].ToString() != "")
            {
                model.N_CPDCQZ = float.Parse(ds.Tables[0].Rows[0]["N_CPDCQZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHC"].ToString() != "")
            {
                model.N_LHC = int.Parse(ds.Tables[0].Rows[0]["N_LHC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCL"].ToString() != "")
            {
                model.N_LHCL = int.Parse(ds.Tables[0].Rows[0]["N_LHCL"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539"].ToString() != "")
            {
                model.N_JC539 = int.Parse(ds.Tables[0].Rows[0]["N_JC539"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539L"].ToString() != "")
            {
                model.N_JC539L = int.Parse(ds.Tables[0].Rows[0]["N_JC539L"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTYTBH"].ToString() != "")
            {
                model.N_LHCTYTBH = float.Parse(ds.Tables[0].Rows[0]["N_LHCTYTBH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTYTT"].ToString() != "")
            {
                model.N_LHCTYTT = float.Parse(ds.Tables[0].Rows[0]["N_LHCTYTT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTYTH"].ToString() != "")
            {
                model.N_LHCTYTH = float.Parse(ds.Tables[0].Rows[0]["N_LHCTYTH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTYQCP"].ToString() != "")
            {
                model.N_LHCTYQCP = float.Parse(ds.Tables[0].Rows[0]["N_LHCTYQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTY2X"].ToString() != "")
            {
                model.N_LHCTY2X = float.Parse(ds.Tables[0].Rows[0]["N_LHCTY2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTY3X"].ToString() != "")
            {
                model.N_LHCTY3X = float.Parse(ds.Tables[0].Rows[0]["N_LHCTY3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTY4X"].ToString() != "")
            {
                model.N_LHCTY4X = float.Parse(ds.Tables[0].Rows[0]["N_LHCTY4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTYGDDS"].ToString() != "")
            {
                model.N_LHCTYGDDS = float.Parse(ds.Tables[0].Rows[0]["N_LHCTYGDDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCTYGDDX"].ToString() != "")
            {
                model.N_LHCTYGDDX = float.Parse(ds.Tables[0].Rows[0]["N_LHCTYGDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZTBH"].ToString() != "")
            {
                model.N_LHCDZTBH = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZTBH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZTT"].ToString() != "")
            {
                model.N_LHCDZTT = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZTT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZTH"].ToString() != "")
            {
                model.N_LHCDZTH = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZTH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZQCP"].ToString() != "")
            {
                model.N_LHCDZQCP = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZ2X"].ToString() != "")
            {
                model.N_LHCDZ2X = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZ2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZ3X"].ToString() != "")
            {
                model.N_LHCDZ3X = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZ3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZ4X"].ToString() != "")
            {
                model.N_LHCDZ4X = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZ4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZGDDS"].ToString() != "")
            {
                model.N_LHCDZGDDS = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZGDDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDZGDDX"].ToString() != "")
            {
                model.N_LHCDZGDDX = float.Parse(ds.Tables[0].Rows[0]["N_LHCDZGDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDCTBH"].ToString() != "")
            {
                model.N_LHCDCTBH = float.Parse(ds.Tables[0].Rows[0]["N_LHCDCTBH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDCTT"].ToString() != "")
            {
                model.N_LHCDCTT = float.Parse(ds.Tables[0].Rows[0]["N_LHCDCTT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDCTH"].ToString() != "")
            {
                model.N_LHCDCTH = float.Parse(ds.Tables[0].Rows[0]["N_LHCDCTH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDCQCP"].ToString() != "")
            {
                model.N_LHCDCQCP = float.Parse(ds.Tables[0].Rows[0]["N_LHCDCQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDC2X"].ToString() != "")
            {
                model.N_LHCDC2X = float.Parse(ds.Tables[0].Rows[0]["N_LHCDC2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDC3X"].ToString() != "")
            {
                model.N_LHCDC3X = float.Parse(ds.Tables[0].Rows[0]["N_LHCDC3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDC4X"].ToString() != "")
            {
                model.N_LHCDC4X = float.Parse(ds.Tables[0].Rows[0]["N_LHCDC4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDCGDDS"].ToString() != "")
            {
                model.N_LHCDCGDDS = float.Parse(ds.Tables[0].Rows[0]["N_LHCDCGDDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LHCDCGDDX"].ToString() != "")
            {
                model.N_LHCDCGDDX = float.Parse(ds.Tables[0].Rows[0]["N_LHCDCGDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTYTBH"].ToString() != "")
            {
                model.N_DLTTYTBH = float.Parse(ds.Tables[0].Rows[0]["N_DLTTYTBH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTYTT"].ToString() != "")
            {
                model.N_DLTTYTT = float.Parse(ds.Tables[0].Rows[0]["N_DLTTYTT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTYTH"].ToString() != "")
            {
                model.N_DLTTYTH = float.Parse(ds.Tables[0].Rows[0]["N_DLTTYTH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTYQCP"].ToString() != "")
            {
                model.N_DLTTYQCP = float.Parse(ds.Tables[0].Rows[0]["N_DLTTYQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTY2X"].ToString() != "")
            {
                model.N_DLTTY2X = float.Parse(ds.Tables[0].Rows[0]["N_DLTTY2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTY3X"].ToString() != "")
            {
                model.N_DLTTY3X = float.Parse(ds.Tables[0].Rows[0]["N_DLTTY3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTY4X"].ToString() != "")
            {
                model.N_DLTTY4X = float.Parse(ds.Tables[0].Rows[0]["N_DLTTY4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTYGDDS"].ToString() != "")
            {
                model.N_DLTTYGDDS = float.Parse(ds.Tables[0].Rows[0]["N_DLTTYGDDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTTYGDDX"].ToString() != "")
            {
                model.N_DLTTYGDDX = float.Parse(ds.Tables[0].Rows[0]["N_DLTTYGDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZTBH"].ToString() != "")
            {
                model.N_DLTDZTBH = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZTBH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZTT"].ToString() != "")
            {
                model.N_DLTDZTT = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZTT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZTH"].ToString() != "")
            {
                model.N_DLTDZTH = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZTH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZQCP"].ToString() != "")
            {
                model.N_DLTDZQCP = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZ2X"].ToString() != "")
            {
                model.N_DLTDZ2X = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZ2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZ3X"].ToString() != "")
            {
                model.N_DLTDZ3X = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZ3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZ4X"].ToString() != "")
            {
                model.N_DLTDZ4X = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZ4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZGDDS"].ToString() != "")
            {
                model.N_DLTDZGDDS = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZGDDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDZGDDX"].ToString() != "")
            {
                model.N_DLTDZGDDX = float.Parse(ds.Tables[0].Rows[0]["N_DLTDZGDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDCTBH"].ToString() != "")
            {
                model.N_DLTDCTBH = float.Parse(ds.Tables[0].Rows[0]["N_DLTDCTBH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDCTT"].ToString() != "")
            {
                model.N_DLTDCTT = float.Parse(ds.Tables[0].Rows[0]["N_DLTDCTT"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDCTH"].ToString() != "")
            {
                model.N_DLTDCTH = float.Parse(ds.Tables[0].Rows[0]["N_DLTDCTH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDCQCP"].ToString() != "")
            {
                model.N_DLTDCQCP = float.Parse(ds.Tables[0].Rows[0]["N_DLTDCQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDC2X"].ToString() != "")
            {
                model.N_DLTDC2X = float.Parse(ds.Tables[0].Rows[0]["N_DLTDC2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDC3X"].ToString() != "")
            {
                model.N_DLTDC3X = float.Parse(ds.Tables[0].Rows[0]["N_DLTDC3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDC4X"].ToString() != "")
            {
                model.N_DLTDC4X = float.Parse(ds.Tables[0].Rows[0]["N_DLTDC4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDCGDDS"].ToString() != "")
            {
                model.N_DLTDCGDDS = float.Parse(ds.Tables[0].Rows[0]["N_DLTDCGDDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DLTDCGDDX"].ToString() != "")
            {
                model.N_DLTDCGDDX = float.Parse(ds.Tables[0].Rows[0]["N_DLTDCGDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539TYQCP"].ToString() != "")
            {
                model.N_JC539TYQCP = float.Parse(ds.Tables[0].Rows[0]["N_JC539TYQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539TY2X"].ToString() != "")
            {
                model.N_JC539TY2X = float.Parse(ds.Tables[0].Rows[0]["N_JC539TY2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539TY3X"].ToString() != "")
            {
                model.N_JC539TY3X = float.Parse(ds.Tables[0].Rows[0]["N_JC539TY3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539TY4X"].ToString() != "")
            {
                model.N_JC539TY4X = float.Parse(ds.Tables[0].Rows[0]["N_JC539TY4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DZQCP"].ToString() != "")
            {
                model.N_JC539DZQCP = float.Parse(ds.Tables[0].Rows[0]["N_JC539DZQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DZ2X"].ToString() != "")
            {
                model.N_JC539DZ2X = float.Parse(ds.Tables[0].Rows[0]["N_JC539DZ2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DZ3X"].ToString() != "")
            {
                model.N_JC539DZ3X = float.Parse(ds.Tables[0].Rows[0]["N_JC539DZ3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DZ4X"].ToString() != "")
            {
                model.N_JC539DZ4X = float.Parse(ds.Tables[0].Rows[0]["N_JC539DZ4X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DCQCP"].ToString() != "")
            {
                model.N_JC539DCQCP = float.Parse(ds.Tables[0].Rows[0]["N_JC539DCQCP"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DC2X"].ToString() != "")
            {
                model.N_JC539DC2X = float.Parse(ds.Tables[0].Rows[0]["N_JC539DC2X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DC3X"].ToString() != "")
            {
                model.N_JC539DC3X = float.Parse(ds.Tables[0].Rows[0]["N_JC539DC3X"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_JC539DC4X"].ToString() != "")
            {
                model.N_JC539DC4X = float.Parse(ds.Tables[0].Rows[0]["N_JC539DC4X"].ToString());
            }
            //if (ds.Tables[0].Rows[0]["N_GYXZC"].ToString() != "")
            //{
            //    model.N_GYXZC = float.Parse(ds.Tables[0].Rows[0]["N_GYXZC"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_GYXGDZC"].ToString() != "")
            //{
            //    model.N_GYXGDZC = float.Parse(ds.Tables[0].Rows[0]["N_GYXGDZC"].ToString());
            //}
            if (ds.Tables[0].Rows[0]["N_LQRFDD"].ToString() != "")
            {
                model.N_LQRFDD = float.Parse(ds.Tables[0].Rows[0]["N_LQRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDXDD"].ToString() != "")
            {
                model.N_LQDXDD = float.Parse(ds.Tables[0].Rows[0]["N_LQDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDYDD"].ToString() != "")
            {
                model.N_LQDYDD = float.Parse(ds.Tables[0].Rows[0]["N_LQDYDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDSDD"].ToString() != "")
            {
                model.N_LQDSDD = float.Parse(ds.Tables[0].Rows[0]["N_LQDSDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDRFDD"].ToString() != "")
            {
                model.N_LQZDRFDD = float.Parse(ds.Tables[0].Rows[0]["N_LQZDRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQZDDXDD"].ToString() != "")
            {
                model.N_LQZDDXDD = float.Parse(ds.Tables[0].Rows[0]["N_LQZDDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCRFDD"].ToString() != "")
            {
                model.N_LQBCRFDD = float.Parse(ds.Tables[0].Rows[0]["N_LQBCRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDXDD"].ToString() != "")
            {
                model.N_LQBCDXDD = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDYDD"].ToString() != "")
            {
                model.N_LQBCDYDD = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDYDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQBCDSDD"].ToString() != "")
            {
                model.N_LQBCDSDD = float.Parse(ds.Tables[0].Rows[0]["N_LQBCDSDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGGDD"].ToString() != "")
            {
                model.N_LQGGDD = float.Parse(ds.Tables[0].Rows[0]["N_LQGGDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQGJDD"].ToString() != "")
            {
                model.N_LQGJDD = float.Parse(ds.Tables[0].Rows[0]["N_LQGJDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJRFTY"].ToString() != "")
            {
                model.N_LQDJRFTY = float.Parse(ds.Tables[0].Rows[0]["N_LQDJRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDXTY"].ToString() != "")
            {
                model.N_LQDJDXTY = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDSTY"].ToString() != "")
            {
                model.N_LQDJDSTY = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJRFDZ"].ToString() != "")
            {
                model.N_LQDJRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQDJRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDXDZ"].ToString() != "")
            {
                model.N_LQDJDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDSDZ"].ToString() != "")
            {
                model.N_LQDJDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJRFDC"].ToString() != "")
            {
                model.N_LQDJRFDC = float.Parse(ds.Tables[0].Rows[0]["N_LQDJRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDXDC"].ToString() != "")
            {
                model.N_LQDJDXDC = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDSDC"].ToString() != "")
            {
                model.N_LQDJDSDC = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJRFDD"].ToString() != "")
            {
                model.N_LQDJRFDD = float.Parse(ds.Tables[0].Rows[0]["N_LQDJRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDXDD"].ToString() != "")
            {
                model.N_LQDJDXDD = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDJDSDD"].ToString() != "")
            {
                model.N_LQDJDSDD = float.Parse(ds.Tables[0].Rows[0]["N_LQDJDSDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SS"].ToString() != "")
            {
                model.N_SS = int.Parse(ds.Tables[0].Rows[0]["N_SS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SSTYDY"].ToString() != "")
            {
                model.N_SSTYDY = float.Parse(ds.Tables[0].Rows[0]["N_SSTYDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SSDZDY"].ToString() != "")
            {
                model.N_SSDZDY = float.Parse(ds.Tables[0].Rows[0]["N_SSDZDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SSDCDY"].ToString() != "")
            {
                model.N_SSDCDY = float.Parse(ds.Tables[0].Rows[0]["N_SSDCDY"].ToString());
            }
            //冰球
            #region 冰球
            if (ds.Tables[0].Rows[0]["N_BQ"].ToString() != "")
            {
                model.N_BQ = int.Parse(ds.Tables[0].Rows[0]["N_BQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQRFTY"].ToString() != "")
            {
                model.N_BQRFTY = float.Parse(ds.Tables[0].Rows[0]["N_BQRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDXTY"].ToString() != "")
            {
                model.N_BQDXTY = float.Parse(ds.Tables[0].Rows[0]["N_BQDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDYTY"].ToString() != "")
            {
                model.N_BQDYTY = float.Parse(ds.Tables[0].Rows[0]["N_BQDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDSTY"].ToString() != "")
            {
                model.N_BQDSTY = float.Parse(ds.Tables[0].Rows[0]["N_BQDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQZDRFTY"].ToString() != "")
            {
                model.N_BQZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_BQZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQZDDXTY"].ToString() != "")
            {
                model.N_BQZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_BQZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQSYTY"].ToString() != "")
            {
                model.N_BQSYTY = float.Parse(ds.Tables[0].Rows[0]["N_BQSYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQGGTY"].ToString() != "")
            {
                model.N_BQGGTY = float.Parse(ds.Tables[0].Rows[0]["N_BQGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQGJTY"].ToString() != "")
            {
                model.N_BQGJTY = float.Parse(ds.Tables[0].Rows[0]["N_BQGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQRFDZ"].ToString() != "")
            {
                model.N_BQRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDXDZ"].ToString() != "")
            {
                model.N_BQDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDYDZ"].ToString() != "")
            {
                model.N_BQDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDSDZ"].ToString() != "")
            {
                model.N_BQDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQZDRFDZ"].ToString() != "")
            {
                model.N_BQZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQZDDXDZ"].ToString() != "")
            {
                model.N_BQZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQSYDZ"].ToString() != "")
            {
                model.N_BQSYDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQSYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQGGDZ"].ToString() != "")
            {
                model.N_BQGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQGJDZ"].ToString() != "")
            {
                model.N_BQGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_BQGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQRFDC"].ToString() != "")
            {
                model.N_BQRFDC = float.Parse(ds.Tables[0].Rows[0]["N_BQRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDXDC"].ToString() != "")
            {
                model.N_BQDXDC = float.Parse(ds.Tables[0].Rows[0]["N_BQDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDYDC"].ToString() != "")
            {
                model.N_BQDYDC = float.Parse(ds.Tables[0].Rows[0]["N_BQDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDSDC"].ToString() != "")
            {
                model.N_BQDSDC = float.Parse(ds.Tables[0].Rows[0]["N_BQDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQZDRFDC"].ToString() != "")
            {
                model.N_BQZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_BQZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQZDDXDC"].ToString() != "")
            {
                model.N_BQZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_BQZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQSYDC"].ToString() != "")
            {
                model.N_BQSYDC = float.Parse(ds.Tables[0].Rows[0]["N_BQSYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQGGDC"].ToString() != "")
            {
                model.N_BQGGDC = float.Parse(ds.Tables[0].Rows[0]["N_BQGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQGJDC"].ToString() != "")
            {
                model.N_BQGJDC = float.Parse(ds.Tables[0].Rows[0]["N_BQGJDC"].ToString());
            }
            //if (ds.Tables[0].Rows[0]["N_BQRFDD"].ToString() != "")
            //{
            //    model.N_BQRFDD = float.Parse(ds.Tables[0].Rows[0]["N_BQRFDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQDXDD"].ToString() != "")
            //{
            //    model.N_BQDXDD = float.Parse(ds.Tables[0].Rows[0]["N_BQDXDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQDYDD"].ToString() != "")
            //{
            //    model.N_BQDYDD = float.Parse(ds.Tables[0].Rows[0]["N_BQDYDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQDSDD"].ToString() != "")
            //{
            //    model.N_BQDSDD = float.Parse(ds.Tables[0].Rows[0]["N_BQDSDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQZDRFDD"].ToString() != "")
            //{
            //    model.N_BQZDRFDD = float.Parse(ds.Tables[0].Rows[0]["N_BQZDRFDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQZDDXDD"].ToString() != "")
            //{
            //    model.N_BQZDDXDD = float.Parse(ds.Tables[0].Rows[0]["N_BQZDDXDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQSYDD"].ToString() != "")
            //{
            //    model.N_BQSYDD = float.Parse(ds.Tables[0].Rows[0]["N_BQSYDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQGGDD"].ToString() != "")
            //{
            //    model.N_BQGGDD = float.Parse(ds.Tables[0].Rows[0]["N_BQGGDD"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["N_BQGJDD"].ToString() != "")
            //{
            //    model.N_BQGJDD = float.Parse(ds.Tables[0].Rows[0]["N_BQGJDD"].ToString());
            //}
            #endregion
            //彩球
            #region 彩球
            if (ds.Tables[0].Rows[0]["N_CQ"].ToString() != "")
            {
                model.N_CQ = int.Parse(ds.Tables[0].Rows[0]["N_CQ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQRFTY"].ToString() != "")
            {
                model.N_CQRFTY = float.Parse(ds.Tables[0].Rows[0]["N_CQRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDXTY"].ToString() != "")
            {
                model.N_CQDXTY = float.Parse(ds.Tables[0].Rows[0]["N_CQDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDYTY"].ToString() != "")
            {
                model.N_CQDYTY = float.Parse(ds.Tables[0].Rows[0]["N_CQDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDSTY"].ToString() != "")
            {
                model.N_CQDSTY = float.Parse(ds.Tables[0].Rows[0]["N_CQDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQZDRFTY"].ToString() != "")
            {
                model.N_CQZDRFTY = float.Parse(ds.Tables[0].Rows[0]["N_CQZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQZDDXTY"].ToString() != "")
            {
                model.N_CQZDDXTY = float.Parse(ds.Tables[0].Rows[0]["N_CQZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCRFTY"].ToString() != "")
            {
                model.N_CQBCRFTY = float.Parse(ds.Tables[0].Rows[0]["N_CQBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDXTY"].ToString() != "")
            {
                model.N_CQBCDXTY = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDYTY"].ToString() != "")
            {
                model.N_CQBCDYTY = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDSTY"].ToString() != "")
            {
                model.N_CQBCDSTY = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQGGTY"].ToString() != "")
            {
                model.N_CQGGTY = float.Parse(ds.Tables[0].Rows[0]["N_CQGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQGJTY"].ToString() != "")
            {
                model.N_CQGJTY = float.Parse(ds.Tables[0].Rows[0]["N_CQGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQRFDZ"].ToString() != "")
            {
                model.N_CQRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDXDZ"].ToString() != "")
            {
                model.N_CQDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDYDZ"].ToString() != "")
            {
                model.N_CQDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDSDZ"].ToString() != "")
            {
                model.N_CQDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQZDRFDZ"].ToString() != "")
            {
                model.N_CQZDRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQZDDXDZ"].ToString() != "")
            {
                model.N_CQZDDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCRFDZ"].ToString() != "")
            {
                model.N_CQBCRFDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQBCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDXDZ"].ToString() != "")
            {
                model.N_CQBCDXDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDYDZ"].ToString() != "")
            {
                model.N_CQBCDYDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDSDZ"].ToString() != "")
            {
                model.N_CQBCDSDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQGGDZ"].ToString() != "")
            {
                model.N_CQGGDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQGGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQGJDZ"].ToString() != "")
            {
                model.N_CQGJDZ = float.Parse(ds.Tables[0].Rows[0]["N_CQGJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQRFDC"].ToString() != "")
            {
                model.N_CQRFDC = float.Parse(ds.Tables[0].Rows[0]["N_CQRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDXDC"].ToString() != "")
            {
                model.N_CQDXDC = float.Parse(ds.Tables[0].Rows[0]["N_CQDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDYDC"].ToString() != "")
            {
                model.N_CQDYDC = float.Parse(ds.Tables[0].Rows[0]["N_CQDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQDSDC"].ToString() != "")
            {
                model.N_CQDSDC = float.Parse(ds.Tables[0].Rows[0]["N_CQDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQZDRFDC"].ToString() != "")
            {
                model.N_CQZDRFDC = float.Parse(ds.Tables[0].Rows[0]["N_CQZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQZDDXDC"].ToString() != "")
            {
                model.N_CQZDDXDC = float.Parse(ds.Tables[0].Rows[0]["N_CQZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCRFDC"].ToString() != "")
            {
                model.N_CQBCRFDC = float.Parse(ds.Tables[0].Rows[0]["N_CQBCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDXDC"].ToString() != "")
            {
                model.N_CQBCDXDC = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDYDC"].ToString() != "")
            {
                model.N_CQBCDYDC = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQBCDSDC"].ToString() != "")
            {
                model.N_CQBCDSDC = float.Parse(ds.Tables[0].Rows[0]["N_CQBCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQGGDC"].ToString() != "")
            {
                model.N_CQGGDC = float.Parse(ds.Tables[0].Rows[0]["N_CQGGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CQGJDC"].ToString() != "")
            {
                model.N_CQGJDC = float.Parse(ds.Tables[0].Rows[0]["N_CQGJDC"].ToString());
            }
            #endregion
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPLQ GetModelLQ(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC, ");
        strSql.Append(" N_RFDD,N_DXDD,N_DYDD,N_DSDD,N_ZDRFDD,N_ZDDXDD,N_BCRFDD,N_BCDXDD,N_BCDYDD,N_BCDSDD,N_GGDD,N_GJDD,N_DJRFTY,N_DJDXTY,N_DJDSTY,N_DJRFDZ,N_DJDXDZ,N_DJDSDZ,N_DJRFDC,N_DJDXDC,N_DJDSDC,N_DJRFDD,N_DJDXDD,N_DJDSDD from KFB_SETUPLQ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPLQ model = new KFB_SETUPLQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFTY"].ToString() != "")
            {
                model.N_BCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXTY"].ToString() != "")
            {
                model.N_BCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYTY"].ToString() != "")
            {
                model.N_BCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSTY"].ToString() != "")
            {
                model.N_BCDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString() != "")
            {
                model.N_BCDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDC"].ToString() != "")
            {
                model.N_BCDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDD"].ToString() != "")
            {
                model.N_RFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDD"].ToString() != "")
            {
                model.N_DXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDD"].ToString() != "")
            {
                model.N_DYDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDD"].ToString() != "")
            {
                model.N_DSDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDD"].ToString() != "")
            {
                model.N_ZDRFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDD"].ToString() != "")
            {
                model.N_ZDDXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDD"].ToString() != "")
            {
                model.N_BCRFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDD"].ToString() != "")
            {
                model.N_BCDXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDD"].ToString() != "")
            {
                model.N_BCDYDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDD"].ToString() != "")
            {
                model.N_BCDSDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDD"].ToString() != "")
            {
                model.N_GGDD = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDD"].ToString() != "")
            {
                model.N_GJDD = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFTY"].ToString() != "")
            {
                model.N_DJRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXTY"].ToString() != "")
            {
                model.N_DJDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSTY"].ToString() != "")
            {
                model.N_DJDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFDZ"].ToString() != "")
            {
                model.N_DJRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXDZ"].ToString() != "")
            {
                model.N_DJDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSDZ"].ToString() != "")
            {
                model.N_DJDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFDC"].ToString() != "")
            {
                model.N_DJRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXDC"].ToString() != "")
            {
                model.N_DJDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSDC"].ToString() != "")
            {
                model.N_DJDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFDD"].ToString() != "")
            {
                model.N_DJRFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXDD"].ToString() != "")
            {
                model.N_DJDXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSDD"].ToString() != "")
            {
                model.N_DJDSDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSDD"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPBQ GetModelBQ(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC from KFB_SETUPBQ ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPBQ model = new KFB_SETUPBQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }

            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPMB GetModelMB(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC from KFB_SETUPMB ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPMB model = new KFB_SETUPMB();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPRB GetModelRB(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC from KFB_SETUPRB ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPRB model = new KFB_SETUPRB();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPTB GetModelTB(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC from KFB_SETUPTB ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPTB model = new KFB_SETUPTB();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPZQ GetModelZQ(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_ARFTY,N_ADXTY,N_ADYTY,N_ADSTY,N_AZDRFTY,N_AZDDXTY,N_ABCRFTY,N_ABCDXTY,N_ABCDYTY,N_ARQSTY,N_ABDTY,N_ABQCTY,N_AGGTY,N_AGJTY,N_BRFTY,N_BDXTY,N_BDYTY,N_BDSTY,N_BZDRFTY,N_BZDDXTY,N_BBCRFTY,N_BBCDXTY,N_BBCDYTY,N_BRQSTY,N_BBDTY,N_BBQCTY,N_BGGTY,N_BGJTY,N_CRFTY,N_CDXTY,N_CDYTY,N_CDSTY,N_CZDRFTY,N_CZDDXTY,N_CBCRFTY,N_CBCDXTY,N_CBCDYTY,N_CRQSTY,N_CBDTY,N_CBQCTY,N_CGGTY,N_CGJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_RQSDZ,N_BDDZ,N_BQCDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_RQSDC,N_BDDC,N_BQCDC,N_GGDC,N_GJDC from KFB_SETUPZQ ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

       KFB_SETUPZQ model = new KFB_SETUPZQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_ARFTY"].ToString() != "")
            {
                model.N_ARFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ARFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ADXTY"].ToString() != "")
            {
                model.N_ADXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ADXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ADYTY"].ToString() != "")
            {
                model.N_ADYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ADYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ADSTY"].ToString() != "")
            {
                model.N_ADSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ADSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AZDRFTY"].ToString() != "")
            {
                model.N_AZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AZDDXTY"].ToString() != "")
            {
                model.N_AZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABCRFTY"].ToString() != "")
            {
                model.N_ABCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABCDXTY"].ToString() != "")
            {
                model.N_ABCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABCDYTY"].ToString() != "")
            {
                model.N_ABCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ARQSTY"].ToString() != "")
            {
                model.N_ARQSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ARQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABDTY"].ToString() != "")
            {
                model.N_ABDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABQCTY"].ToString() != "")
            {
                model.N_ABQCTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AGGTY"].ToString() != "")
            {
                model.N_AGGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AGJTY"].ToString() != "")
            {
                model.N_AGJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BRFTY"].ToString() != "")
            {
                model.N_BRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDXTY"].ToString() != "")
            {
                model.N_BDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDYTY"].ToString() != "")
            {
                model.N_BDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDSTY"].ToString() != "")
            {
                model.N_BDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BZDRFTY"].ToString() != "")
            {
                model.N_BZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BZDDXTY"].ToString() != "")
            {
                model.N_BZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBCRFTY"].ToString() != "")
            {
                model.N_BBCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBCDXTY"].ToString() != "")
            {
                model.N_BBCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBCDYTY"].ToString() != "")
            {
                model.N_BBCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BRQSTY"].ToString() != "")
            {
                model.N_BRQSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BRQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBDTY"].ToString() != "")
            {
                model.N_BBDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBQCTY"].ToString() != "")
            {
                model.N_BBQCTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BGGTY"].ToString() != "")
            {
                model.N_BGGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BGJTY"].ToString() != "")
            {
                model.N_BGJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CRFTY"].ToString() != "")
            {
                model.N_CRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CDXTY"].ToString() != "")
            {
                model.N_CDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CDYTY"].ToString() != "")
            {
                model.N_CDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CDSTY"].ToString() != "")
            {
                model.N_CDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CZDRFTY"].ToString() != "")
            {
                model.N_CZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CZDDXTY"].ToString() != "")
            {
                model.N_CZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBCRFTY"].ToString() != "")
            {
                model.N_CBCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBCDXTY"].ToString() != "")
            {
                model.N_CBCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBCDYTY"].ToString() != "")
            {
                model.N_CBCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CRQSTY"].ToString() != "")
            {
                model.N_CRQSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CRQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBDTY"].ToString() != "")
            {
                model.N_CBDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBQCTY"].ToString() != "")
            {
                model.N_CBQCTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CGGTY"].ToString() != "")
            {
                model.N_CGGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CGJTY"].ToString() != "")
            {
                model.N_CGJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSDZ"].ToString() != "")
            {
                model.N_RQSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDZ"].ToString() != "")
            {
                model.N_BDDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCDZ"].ToString() != "")
            {
                model.N_BQCDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSDC"].ToString() != "")
            {
                model.N_RQSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDC"].ToString() != "")
            {
                model.N_BDDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCDC"].ToString() != "")
            {
                model.N_BQCDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPMQ GetModelMQ(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC from KFB_SETUPMQ ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPMQ model = new KFB_SETUPMQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFTY"].ToString() != "")
            {
                model.N_BCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXTY"].ToString() != "")
            {
                model.N_BCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYTY"].ToString() != "")
            {
                model.N_BCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSTY"].ToString() != "")
            {
                model.N_BCDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString() != "")
            {
                model.N_BCDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDC"].ToString() != "")
            {
                model.N_BCDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPCQ GetModelCQ(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC from KFB_SETUPCQ ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPCQ model = new KFB_SETUPCQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFTY"].ToString() != "")
            {
                model.N_BCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXTY"].ToString() != "")
            {
                model.N_BCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYTY"].ToString() != "")
            {
                model.N_BCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSTY"].ToString() != "")
            {
                model.N_BCDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString() != "")
            {
                model.N_BCDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDC"].ToString() != "")
            {
                model.N_BCDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPZS GetModelZS(string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_BDTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_BDDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_BDDC,N_GGDC,N_GJDC from KFB_SETUPZS ");
        strSql.Append(" where N_HYZH=:N_HYZH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYZH;

        KFB_SETUPZS model = new KFB_SETUPZS();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDTY"].ToString() != "")
            {
                model.N_BDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDZ"].ToString() != "")
            {
                model.N_BDDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDC"].ToString() != "")
            {
                model.N_BDDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPSM GetModelSM(string N_HYDH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYDH,N_DYTY,N_WZTY,N_LYTY,N_WZQTY,N_DYDZ,N_WZDZ,N_LYDZ,N_WZQDZ,N_DYDC,N_WZDC,N_LYDC,N_WZQDC from KFB_SETUPSM ");
        strSql.Append(" where N_HYDH=:N_HYDH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYDH;

        KFB_SETUPSM model = new KFB_SETUPSM();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZTY"].ToString() != "")
            {
                model.N_WZTY = decimal.Parse(ds.Tables[0].Rows[0]["N_WZTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LYTY"].ToString() != "")
            {
                model.N_LYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_LYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZQTY"].ToString() != "")
            {
                model.N_WZQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_WZQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZDZ"].ToString() != "")
            {
                model.N_WZDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_WZDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LYDZ"].ToString() != "")
            {
                model.N_LYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_LYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZQDZ"].ToString() != "")
            {
                model.N_WZQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_WZQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZDC"].ToString() != "")
            {
                model.N_WZDC = decimal.Parse(ds.Tables[0].Rows[0]["N_WZDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LYDC"].ToString() != "")
            {
                model.N_LYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_LYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZQDC"].ToString() != "")
            {
                model.N_WZQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_WZQDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPLHC GetModelLHC(string N_HYDH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYDH,N_TBHTY,N_TTTY,N_THTY,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_GDDSTY,N_GDDXTY,N_TBHDZ,N_TTDZ,N_THDZ,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_GDDSDZ,N_GDDXDZ,N_TBHDC,N_TTDC,N_THDC,N_QCPDC,N_2XDC,N_3XDC,N_4XDC,N_GDDSDC,N_GDDXDC from KFB_SETUPLHC ");
        strSql.Append(" where N_HYDH=:N_HYDH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYDH;

        KFB_SETUPLHC model = new KFB_SETUPLHC();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_TBHTY"].ToString() != "")
            {
                model.N_TBHTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTTY"].ToString() != "")
            {
                model.N_TTTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TTTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THTY"].ToString() != "")
            {
                model.N_THTY = decimal.Parse(ds.Tables[0].Rows[0]["N_THTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPTY"].ToString() != "")
            {
                model.N_QCPTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XTY"].ToString() != "")
            {
                model.N_2XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_2XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XTY"].ToString() != "")
            {
                model.N_3XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_3XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XTY"].ToString() != "")
            {
                model.N_4XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_4XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSTY"].ToString() != "")
            {
                model.N_GDDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXTY"].ToString() != "")
            {
                model.N_GDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDZ"].ToString() != "")
            {
                model.N_TBHDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDZ"].ToString() != "")
            {
                model.N_TTDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDZ"].ToString() != "")
            {
                model.N_THDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_THDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDZ"].ToString() != "")
            {
                model.N_QCPDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDZ"].ToString() != "")
            {
                model.N_2XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDZ"].ToString() != "")
            {
                model.N_3XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDZ"].ToString() != "")
            {
                model.N_4XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString() != "")
            {
                model.N_GDDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString() != "")
            {
                model.N_GDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDC"].ToString() != "")
            {
                model.N_TBHDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDC"].ToString() != "")
            {
                model.N_TTDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDC"].ToString() != "")
            {
                model.N_THDC = decimal.Parse(ds.Tables[0].Rows[0]["N_THDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDC"].ToString() != "")
            {
                model.N_QCPDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDC"].ToString() != "")
            {
                model.N_2XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDC"].ToString() != "")
            {
                model.N_3XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDC"].ToString() != "")
            {
                model.N_4XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDC"].ToString() != "")
            {
                model.N_GDDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDC"].ToString() != "")
            {
                model.N_GDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPDLT GetModelDLT(string N_HYDH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYDH,N_TBHTY,N_TTTY,N_THTY,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_GDDSTY,N_GDDXTY,N_TBHDZ,N_TTDZ,N_THDZ,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_GDDSDZ,N_GDDXDZ,N_TBHDC,N_TTDC,N_THDC,N_QCPDC,N_2XDC,N_3XDC,N_4XDC,N_GDDSDC,N_GDDXDC from KFB_SETUPDLT ");
        strSql.Append(" where N_HYDH=:N_HYDH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYDH;

        KFB_SETUPDLT model = new KFB_SETUPDLT();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_TBHTY"].ToString() != "")
            {
                model.N_TBHTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTTY"].ToString() != "")
            {
                model.N_TTTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TTTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THTY"].ToString() != "")
            {
                model.N_THTY = decimal.Parse(ds.Tables[0].Rows[0]["N_THTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPTY"].ToString() != "")
            {
                model.N_QCPTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XTY"].ToString() != "")
            {
                model.N_2XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_2XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XTY"].ToString() != "")
            {
                model.N_3XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_3XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XTY"].ToString() != "")
            {
                model.N_4XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_4XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSTY"].ToString() != "")
            {
                model.N_GDDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXTY"].ToString() != "")
            {
                model.N_GDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDZ"].ToString() != "")
            {
                model.N_TBHDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDZ"].ToString() != "")
            {
                model.N_TTDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDZ"].ToString() != "")
            {
                model.N_THDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_THDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDZ"].ToString() != "")
            {
                model.N_QCPDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDZ"].ToString() != "")
            {
                model.N_2XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDZ"].ToString() != "")
            {
                model.N_3XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDZ"].ToString() != "")
            {
                model.N_4XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString() != "")
            {
                model.N_GDDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString() != "")
            {
                model.N_GDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDC"].ToString() != "")
            {
                model.N_TBHDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDC"].ToString() != "")
            {
                model.N_TTDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDC"].ToString() != "")
            {
                model.N_THDC = decimal.Parse(ds.Tables[0].Rows[0]["N_THDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDC"].ToString() != "")
            {
                model.N_QCPDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDC"].ToString() != "")
            {
                model.N_2XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDC"].ToString() != "")
            {
                model.N_3XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDC"].ToString() != "")
            {
                model.N_4XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDC"].ToString() != "")
            {
                model.N_GDDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDC"].ToString() != "")
            {
                model.N_GDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPJC539 GetModelJC539(string N_HYDH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYDH,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_QCPDC,N_2XDC,N_3XDC,N_4XDC from KFB_SETUPJC539 ");
        strSql.Append(" where N_HYDH=:N_HYDH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYDH;

        KFB_SETUPJC539 model = new KFB_SETUPJC539();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_QCPTY"].ToString() != "")
            {
                model.N_QCPTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XTY"].ToString() != "")
            {
                model.N_2XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_2XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XTY"].ToString() != "")
            {
                model.N_3XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_3XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XTY"].ToString() != "")
            {
                model.N_4XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_4XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDZ"].ToString() != "")
            {
                model.N_QCPDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDZ"].ToString() != "")
            {
                model.N_2XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDZ"].ToString() != "")
            {
                model.N_3XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDZ"].ToString() != "")
            {
                model.N_4XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDC"].ToString() != "")
            {
                model.N_QCPDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDC"].ToString() != "")
            {
                model.N_2XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDC"].ToString() != "")
            {
                model.N_3XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDC"].ToString() != "")
            {
                model.N_4XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPCP GetModelCP(string N_HYDH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYDH,N_BQTY,N_LQTY,N_ZQTY,N_GSTY,N_QZTY,N_BQDZ,N_LQDZ,N_ZQDZ,N_GSDZ,N_QZDZ,N_BQDC,N_LQDC,N_ZQDC,N_GSDC,N_QZDC from KFB_SETUPCP ");
        strSql.Append(" where N_HYDH=:N_HYDH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYDH;

        KFB_SETUPCP model = new KFB_SETUPCP();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_BQTY"].ToString() != "")
            {
                model.N_BQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQTY"].ToString() != "")
            {
                model.N_LQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_LQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQTY"].ToString() != "")
            {
                model.N_ZQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GSTY"].ToString() != "")
            {
                model.N_GSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QZTY"].ToString() != "")
            {
                model.N_QZTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QZTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDZ"].ToString() != "")
            {
                model.N_BQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDZ"].ToString() != "")
            {
                model.N_LQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_LQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDZ"].ToString() != "")
            {
                model.N_ZQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GSDZ"].ToString() != "")
            {
                model.N_GSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QZDZ"].ToString() != "")
            {
                model.N_QZDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QZDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDC"].ToString() != "")
            {
                model.N_BQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BQDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDC"].ToString() != "")
            {
                model.N_LQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_LQDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDC"].ToString() != "")
            {
                model.N_ZQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GSDC"].ToString() != "")
            {
                model.N_GSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QZDC"].ToString() != "")
            {
                model.N_QZDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QZDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPSS GetModelSS(string N_HYDH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_HYDH,N_DYTY,N_DYDZ,N_DYDC from KFB_SETUPSS ");
        strSql.Append(" where N_HYDH=:N_HYDH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,50)};
        parameters[0].Value = N_HYDH;

        KFB_SETUPSS model = new KFB_SETUPSS();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    public void SetData(KFB_ZHGL mo_zhgl, KFB_SETUPLQ mo_lq, KFB_SETUPMB mo_mb, KFB_SETUPRB mo_rb, KFB_SETUPTB mo_tb, KFB_SETUPZQ mo_zq, KFB_SETUPMQ mo_mz, KFB_SETUPZS mo_zs, KFB_SETUPSM mo_sm, KFB_SETUPLHC mo_lhc, KFB_SETUPDLT mo_dlt, KFB_SETUPJC539 mo_jc539, KFB_SETUPCP mo_cp, KFB_SETUPSS mo_ss, KFB_SETUPBQ mo_bq, KFB_SETUPCQ mo_cq)
    {
        Hashtable o_hsta = new Hashtable();
        #region"帳號管理"
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" insert into kfb_zhgl(n_id,n_hyzh,n_hymm,n_hymc,n_hydj,n_yxdl,n_zjdh,n_dgddh,n_gddh,n_zdldh,");
        strSql.Append(" n_kyed,n_hydlip,n_xzsj,n_zqcz,n_lqcz,n_mzcz,n_mbcz,n_rbcz,n_dldh,n_tbcz,n_hyjrsj,n_xzyc,n_zscz,n_hyxg,n_smcz,");
        strSql.Append(" n_dltcz,n_cpcz,n_lhccz,n_jccz,n_2xcz,n_3xcz,n_4xcz,n_syed,n_dzjdh,n_ddsx,N_TOLLGATE,n_yxxz,n_sscz,n_dhhm,n_mail,n_qq,n_yjlx,n_sqzt,n_bqcz,n_cqcz )");
        strSql.Append("  values(EXAMPLE_SEQ.nextval,:n_hyzh,:n_hymm,:n_hymc,:n_hydj,:n_yxdl,:n_zjdh,:n_dgddh,:n_gddh,:n_zdldh,");
        strSql.Append("  :n_kyed,:n_hydlip,:n_xzsj,:n_zqcz,:n_lqcz,:n_mzcz,:n_mbcz,:n_rbcz,:n_dldh,:n_tbcz,:n_hyjrsj,:n_xzyc,:n_zscz,:n_hyxg,:n_smcz,");
        strSql.Append(" :n_dltcz,:n_cpcz,:n_lhccz,:n_jccz,:n_2xcz,:n_3xcz,:n_4xcz,:n_syed,:n_dzjdh,:n_ddsx,:N_TOLLGATE,:n_yxxz,:n_sscz,:n_dhhm,:n_mail,:n_qq,:n_yjlx,:n_sqzt,:n_bqcz,:n_cqcz)");
        OracleParameter[] parameters = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                    new OracleParameter(":n_hymm", OracleType.VarChar,100),
                    new OracleParameter(":n_hymc", OracleType.VarChar,100),
                    new OracleParameter(":n_hydj", OracleType.Number,4),
                    new OracleParameter(":n_yxdl", OracleType.Number,4),
                  //  new OracleParameter(":n_hydlcw", OracleType.Number,4),
                    new OracleParameter(":n_zjdh", OracleType.VarChar,100),
                    new OracleParameter(":n_dgddh", OracleType.VarChar,100),
                    new OracleParameter(":n_gddh", OracleType.VarChar,100),
                    new OracleParameter(":n_zdldh", OracleType.VarChar,100),
                    new OracleParameter(":n_kyed", OracleType.Float,20),
                   // new OracleParameter(":n_syed", OracleType.Float,8),
                    new OracleParameter(":n_hydlip", OracleType.VarChar,20),                
                    new OracleParameter(":n_xzsj", OracleType.DateTime),
                    new OracleParameter(":n_zqcz", OracleType.Number,4),
                    new OracleParameter(":n_lqcz", OracleType.Number,4),
                    new OracleParameter(":n_mzcz", OracleType.Number,4),
                    new OracleParameter(":n_mbcz", OracleType.Number,4),
                    new OracleParameter(":n_rbcz", OracleType.Number,4),
                            
                    new OracleParameter(":n_dldh", OracleType.VarChar,100),
                    new OracleParameter(":n_tbcz", OracleType.Number,4),
                    new OracleParameter(":n_hyjrsj", OracleType.DateTime),
                    new OracleParameter(":n_xzyc", OracleType.Number,4),
                    new OracleParameter(":n_zscz", OracleType.Number,4),
                    new OracleParameter(":n_hyxg", OracleType.DateTime),
                    new OracleParameter(":n_smcz", OracleType.Number,4),

                    new OracleParameter(":n_dltcz", OracleType.Number,4),
                    new OracleParameter(":n_cpcz", OracleType.Number,4),
                    new OracleParameter(":n_lhccz", OracleType.Number,4),
                    new OracleParameter(":n_jccz", OracleType.Number,4),
                    new OracleParameter(":n_2xcz", OracleType.Number,4),
                    new OracleParameter(":n_3xcz", OracleType.Number,4),
                    new OracleParameter(":n_4xcz", OracleType.Number,4),
                    new OracleParameter(":n_syed", OracleType.Float,8),
                    new OracleParameter(":n_dzjdh", OracleType.VarChar,100),
                    new OracleParameter(":n_ddsx", OracleType.Float,8),
                    new OracleParameter(":N_TOLLGATE",OracleType.Int32,4),
                    new OracleParameter(":n_yxxz", OracleType.Number,4),
                    new OracleParameter(":n_sscz", OracleType.Number,4),
                    new OracleParameter(":n_dhhm", OracleType.VarChar,50),
                    new OracleParameter(":n_mail", OracleType.VarChar,50),
                    new OracleParameter(":n_qq", OracleType.VarChar,50),
                    new OracleParameter(":n_yjlx", OracleType.Number,4),
                    new OracleParameter(":n_sqzt", OracleType.VarChar,1),
                 new OracleParameter(":n_bqcz", OracleType.Number,4),
                 new OracleParameter(":n_cqcz", OracleType.Number,4)
                    
				};
        parameters[0].Value = mo_zhgl.N_HYZH;
        parameters[1].Value = mo_zhgl.N_HYMM;
        parameters[2].Value = mo_zhgl.N_HYMC;
        parameters[3].Value = mo_zhgl.N_HYDJ;
        parameters[4].Value = mo_zhgl.N_YXDL;
        // parameters[5].Value = mo_zhgl.N_HYDLCW;
        parameters[5].Value = mo_zhgl.N_ZJDH;
        parameters[6].Value = mo_zhgl.N_DGDDH;
        parameters[7].Value = mo_zhgl.N_GDDH;
        parameters[8].Value = mo_zhgl.N_ZDLDH;
        parameters[9].Value = mo_zhgl.N_KYED;
        // parameters[11].Value = mo_zhgl.N_SYED;

        parameters[10].Value = mo_zhgl.N_HYDLIP;
        parameters[11].Value = mo_zhgl.N_XZSJ;

        parameters[12].Value = mo_zhgl.N_ZQCZ;
        parameters[13].Value = mo_zhgl.N_LQCZ;
        parameters[14].Value = mo_zhgl.N_MZCZ;
        parameters[15].Value = mo_zhgl.N_MBCZ;
        parameters[16].Value = mo_zhgl.N_RBCZ;

        parameters[17].Value = mo_zhgl.N_DLDH;
        parameters[18].Value = mo_zhgl.N_TBCZ;
        parameters[19].Value = mo_zhgl.N_HYJRSJ;
        parameters[20].Value = mo_zhgl.N_XZYC;
        parameters[21].Value = mo_zhgl.N_ZSCZ;
        parameters[22].Value = mo_zhgl.N_HYXG;

        parameters[23].Value = mo_zhgl.N_SMCZ;
        parameters[24].Value = mo_zhgl.N_DLTCZ;
        parameters[25].Value = mo_zhgl.N_CPCZ;
        parameters[26].Value = mo_zhgl.N_LHCCZ;
        parameters[27].Value = mo_zhgl.N_JCCZ;
        parameters[28].Value = mo_zhgl.N_2XCZ;
        parameters[29].Value = mo_zhgl.N_3XCZ;
        parameters[30].Value = mo_zhgl.N_4XCZ;
        parameters[31].Value = mo_zhgl.N_SYED;
        parameters[32].Value = mo_zhgl.N_DZJDH;
        parameters[33].Value = mo_zhgl.N_DDSX;
        parameters[34].Value = mo_zhgl.N_TOLLGATE;
        parameters[35].Value = mo_zhgl.N_YXXZ;
        parameters[36].Value = mo_zhgl.N_SSCZ;
        parameters[37].Value = mo_zhgl.N_DHHM;
        parameters[38].Value = mo_zhgl.N_MAIL;
        parameters[39].Value = mo_zhgl.N_QQ;
        parameters[40].Value = mo_zhgl.N_YJLX;
        parameters[41].Value = mo_zhgl.N_SQZT;
        parameters[42].Value = mo_zhgl.N_BQCZ;
        parameters[43].Value = mo_zhgl.N_CQCZ;
        o_hsta.Add(strSql.ToString(), parameters);
        #endregion
        #region"修改上级剩余额度"
        if (mo_zhgl.N_HYDJ > 4)
        {
            string strn_hyzh = "";
            switch (mo_zhgl.N_HYDJ.ToString())
            {
                case "5": strn_hyzh = mo_zhgl.N_DZJDH; break;
                case "6": strn_hyzh = mo_zhgl.N_ZJDH; break;
                case "7": strn_hyzh = mo_zhgl.N_DGDDH; break;
                case "8": strn_hyzh = mo_zhgl.N_GDDH; break;
                case "9": strn_hyzh = mo_zhgl.N_ZDLDH; break;
            }
            StringBuilder strSqlup = new StringBuilder();
            strSqlup.Append(" update kfb_zhgl set n_syed=n_syed-:n_syed where n_hyzh=:n_hyzh ");

            OracleParameter[] parametersup = {
                        new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                        new OracleParameter(":n_syed", OracleType.Float,8)
				    };
            parametersup[0].Value = strn_hyzh;
            parametersup[1].Value = mo_zhgl.N_SYED;
            o_hsta.Add(strSqlup.ToString(), parametersup);
        }
        #endregion
        #region"籃球"
        strSql = new StringBuilder();
        strSql.Append(" insert into kfb_setuplq(n_hyzh,n_rfty,n_dxty,n_dyty,n_dsty,n_zdrfty,n_zddxty,n_bcrfty,n_bcdxty,n_bcdyty,n_bcdsty,n_ggty,n_gjty,");
        strSql.Append(" n_rfdz,n_dxdz,n_dydz,n_dsdz,n_zdrfdz,n_zddxdz,n_bcrfdz,n_bcdxdz,n_bcdydz,n_bcdsdz,n_ggdz,n_gjdz,");
        strSql.Append(" n_rfdc,n_dxdc,n_dydc,n_dsdc,n_zdrfdc,n_zddxdc,n_bcrfdc,n_bcdxdc,n_bcdydc,n_bcdsdc,n_ggdc,n_gjdc,");

        strSql.Append(" n_rfdd,n_dxdd,n_dydd,n_dsdd,n_zdrfdd,n_zddxdd,n_bcrfdd,n_bcdxdd,n_bcdydd,n_bcdsdd,n_ggdd,n_gjdd,");
        strSql.Append(" n_djrfty,n_djdxty,n_djdsty,n_djrfdz,n_djdxdz,n_djdsdz,n_djrfdc,n_djdxdc,n_djdsdc,n_djrfdd,n_djdxdd,n_djdsdd)");

        strSql.Append("  values(:n_hyzh,:n_rfty,:n_dxty,:n_dyty,:n_dsty,:n_zdrfty,:n_zddxty,:n_bcrfty,:n_bcdxty,:n_bcdyty,:n_bcdsty,:n_ggty,:n_gjty,");
        strSql.Append("  :n_rfdz,:n_dxdz,:n_dydz,:n_dsdz,:n_zdrfdz,:n_zddxdz,:n_bcrfdz,:n_bcdxdz,:n_bcdydz,:n_bcdsdz,:n_ggdz,:n_gjdz,");
        strSql.Append("  :n_rfdc,:n_dxdc,:n_dydc,:n_dsdc,:n_zdrfdc,:n_zddxdc,:n_bcrfdc,:n_bcdxdc,:n_bcdydc,:n_bcdsdc,:n_ggdc,:n_gjdc,");

        strSql.Append("  :n_rfdd,:n_dxdd,:n_dydd,:n_dsdd,:n_zdrfdd,:n_zddxdd,:n_bcrfdd,:n_bcdxdd,:n_bcdydd,:n_bcdsdd,:n_ggdd,:n_gjdd,");
        strSql.Append("  :n_djrfty,:n_djdxty,:n_djdsty,:n_djrfdz,:n_djdxdz,:n_djdsdz,:n_djrfdc,:n_djdxdc,:n_djdsdc,:n_djrfdd,:n_djdxdd,:n_djdsdd)");

        OracleParameter[] parameterslq = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                    new OracleParameter(":n_rfty", OracleType.Float,8),
                    new OracleParameter(":n_rfdz", OracleType.Float,8),
                    new OracleParameter(":n_rfdc", OracleType.Float,8),
                    new OracleParameter(":n_dxty", OracleType.Float,8),
                    new OracleParameter(":n_dxdz", OracleType.Float,8),
                    new OracleParameter(":n_dxdc", OracleType.Float,8),
                    new OracleParameter(":n_dyty", OracleType.Float,8),
                    new OracleParameter(":n_dydz", OracleType.Float,8),
                    new OracleParameter(":n_dydc", OracleType.Float,8),
                    new OracleParameter(":n_dsty", OracleType.Float,8),
                    new OracleParameter(":n_dsdz", OracleType.Float,8),
                    new OracleParameter(":n_dsdc", OracleType.Float,8),
                    new OracleParameter(":n_zdrfty", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdz", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdc", OracleType.Float,8),
                    new OracleParameter(":n_zddxty", OracleType.Float,8),
                    new OracleParameter(":n_zddxdz", OracleType.Float,8),
                    new OracleParameter(":n_zddxdc", OracleType.Float,8),
                    new OracleParameter(":n_bcrfty", OracleType.Float,8),
                    new OracleParameter(":n_bcrfdz", OracleType.Float,8),
                    new OracleParameter(":n_bcrfdc", OracleType.Float,8),
                    new OracleParameter(":n_bcdxty", OracleType.Float,8),
                    new OracleParameter(":n_bcdxdz", OracleType.Float,8),
                    new OracleParameter(":n_bcdxdc", OracleType.Float,8),
                    new OracleParameter(":n_bcdyty", OracleType.Float,8),
                    new OracleParameter(":n_bcdydz", OracleType.Float,8),
                    new OracleParameter(":n_bcdydc", OracleType.Float,8),
                    new OracleParameter(":n_bcdsty", OracleType.Float,8),
                    new OracleParameter(":n_bcdsdz", OracleType.Float,8),
                    new OracleParameter(":n_bcdsdc", OracleType.Float,8),
                    new OracleParameter(":n_ggty", OracleType.Float,8),
                    new OracleParameter(":n_ggdz", OracleType.Float,8),
                    new OracleParameter(":n_ggdc", OracleType.Float,8),
                    new OracleParameter(":n_gjty", OracleType.Float,8),
                    new OracleParameter(":n_gjdz", OracleType.Float,8),
                    new OracleParameter(":n_gjdc", OracleType.Float,8),

                    new OracleParameter(":n_rfdd", OracleType.Float,8),
                    new OracleParameter(":n_dxdd", OracleType.Float,8),
                    new OracleParameter(":n_dydd", OracleType.Float,8),
                    new OracleParameter(":n_dsdd", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdd", OracleType.Float,8),
                    new OracleParameter(":n_zddxdd", OracleType.Float,8),
                    new OracleParameter(":n_bcrfdd", OracleType.Float,8),
                    new OracleParameter(":n_bcdxdd", OracleType.Float,8),
                    new OracleParameter(":n_bcdydd", OracleType.Float,8),
                    new OracleParameter(":n_bcdsdd", OracleType.Float,8),
                    new OracleParameter(":n_ggdd", OracleType.Float,8),
                    new OracleParameter(":n_gjdd", OracleType.Float,8),

                    new OracleParameter(":n_djrfty", OracleType.Float,8),
                    new OracleParameter(":n_djdxty", OracleType.Float,8),
                    new OracleParameter(":n_djdsty", OracleType.Float,8),
                    new OracleParameter(":n_djrfdz", OracleType.Float,8),
                    new OracleParameter(":n_djdxdz", OracleType.Float,8),
                    new OracleParameter(":n_djdsdz", OracleType.Float,8),
                    new OracleParameter(":n_djrfdc", OracleType.Float,8),
                    new OracleParameter(":n_djdxdc", OracleType.Float,8),
                    new OracleParameter(":n_djdsdc", OracleType.Float,8),
                    new OracleParameter(":n_djrfdd", OracleType.Float,8),
                    new OracleParameter(":n_djdxdd", OracleType.Float,8),
                    new OracleParameter(":n_djdsdd", OracleType.Float,8)

				};
        parameterslq[0].Value = mo_lq.N_HYZH;
        parameterslq[1].Value = mo_lq.N_RFTY;
        parameterslq[2].Value = mo_lq.N_RFDZ;
        parameterslq[3].Value = mo_lq.N_RFDC;
        parameterslq[4].Value = mo_lq.N_DXTY;
        parameterslq[5].Value = mo_lq.N_DXDZ;
        parameterslq[6].Value = mo_lq.N_DXDC;
        parameterslq[7].Value = mo_lq.N_DYTY;
        parameterslq[8].Value = mo_lq.N_DYDZ;
        parameterslq[9].Value = mo_lq.N_DYDC;
        parameterslq[10].Value = mo_lq.N_DSTY;
        parameterslq[11].Value = mo_lq.N_DSDZ;
        parameterslq[12].Value = mo_lq.N_DSDC;
        parameterslq[13].Value = mo_lq.N_ZDRFTY;
        parameterslq[14].Value = mo_lq.N_ZDRFDZ;
        parameterslq[15].Value = mo_lq.N_ZDRFDC;
        parameterslq[16].Value = mo_lq.N_ZDDXTY;
        parameterslq[17].Value = mo_lq.N_ZDDXDZ;
        parameterslq[18].Value = mo_lq.N_ZDDXDC;
        parameterslq[19].Value = mo_lq.N_BCRFTY;
        parameterslq[20].Value = mo_lq.N_BCRFDZ;
        parameterslq[21].Value = mo_lq.N_BCRFDC;
        parameterslq[22].Value = mo_lq.N_BCDXTY;
        parameterslq[23].Value = mo_lq.N_BCDXDZ;
        parameterslq[24].Value = mo_lq.N_BCDXDC;
        parameterslq[25].Value = mo_lq.N_BCDYTY;
        parameterslq[26].Value = mo_lq.N_BCDYDZ;
        parameterslq[27].Value = mo_lq.N_BCDYDC;
        parameterslq[28].Value = mo_lq.N_BCDSTY;
        parameterslq[29].Value = mo_lq.N_BCDSDZ;
        parameterslq[30].Value = mo_lq.N_BCDSDC;
        parameterslq[31].Value = mo_lq.N_GGTY;
        parameterslq[32].Value = mo_lq.N_GGDZ;
        parameterslq[33].Value = mo_lq.N_GGDC;
        parameterslq[34].Value = mo_lq.N_GJTY;
        parameterslq[35].Value = mo_lq.N_GJDZ;
        parameterslq[36].Value = mo_lq.N_GJDC;

        parameterslq[37].Value = mo_lq.N_RFDD;
        parameterslq[38].Value = mo_lq.N_DXDD;
        parameterslq[39].Value = mo_lq.N_DYDD;
        parameterslq[40].Value = mo_lq.N_DSDD;
        parameterslq[41].Value = mo_lq.N_ZDRFDD;
        parameterslq[42].Value = mo_lq.N_ZDDXDD;
        parameterslq[43].Value = mo_lq.N_BCRFDD;
        parameterslq[44].Value = mo_lq.N_BCDXDD;
        parameterslq[45].Value = mo_lq.N_BCDYDD;
        parameterslq[46].Value = mo_lq.N_BCDSDD;
        parameterslq[47].Value = mo_lq.N_GGDD;
        parameterslq[48].Value = mo_lq.N_GJDD;
        parameterslq[49].Value = mo_lq.N_DJRFTY;
        parameterslq[50].Value = mo_lq.N_DJDXTY;
        parameterslq[51].Value = mo_lq.N_DJDSTY;
        parameterslq[52].Value = mo_lq.N_DJRFDZ;
        parameterslq[53].Value = mo_lq.N_DJDXDZ;
        parameterslq[54].Value = mo_lq.N_DJDSDZ;
        parameterslq[55].Value = mo_lq.N_DJRFDC;
        parameterslq[56].Value = mo_lq.N_DJDXDC;
        parameterslq[57].Value = mo_lq.N_DJDSDC;
        parameterslq[58].Value = mo_lq.N_DJRFDD;
        parameterslq[59].Value = mo_lq.N_DJDXDD;
        parameterslq[60].Value = mo_lq.N_DJDSDD;

        o_hsta.Add(strSql.ToString(), parameterslq);
        #endregion
        #region"棒球"
        strSql = new StringBuilder();
        strSql.Append(" insert into kfb_setupmb(n_hyzh,n_rfty,n_dxty,n_dyty,n_dsty,n_zdrfty,n_zddxty,n_syty,n_ggty,n_gjty,");
        strSql.Append(" n_rfdz,n_dxdz,n_dydz,n_dsdz,n_zdrfdz,n_zddxdz,n_sydz,n_ggdz,n_gjdz,");
        strSql.Append(" n_rfdc,n_dxdc,n_dydc,n_dsdc,n_zdrfdc,n_zddxdc,n_sydc,n_ggdc,n_gjdc)");
        strSql.Append("  values(:n_hyzh,:n_rfty,:n_dxty,:n_dyty,:n_dsty,:n_zdrfty,:n_zddxty,:n_syty,:n_ggty,:n_gjty,");
        strSql.Append("  :n_rfdz,:n_dxdz,:n_dydz,:n_dsdz,:n_zdrfdz,:n_zddxdz,:n_sydz,:n_ggdz,:n_gjdz,");
        strSql.Append(" :n_rfdc,:n_dxdc,:n_dydc,:n_dsdc,:n_zdrfdc,:n_zddxdc,:n_sydc,:n_ggdc,:n_gjdc)");
        OracleParameter[] parametersMB = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                    new OracleParameter(":n_rfty", OracleType.Float,8),
                    new OracleParameter(":n_rfdz", OracleType.Float,8),
                    new OracleParameter(":n_rfdc", OracleType.Float,8),
                    new OracleParameter(":n_dxty", OracleType.Float,8),
                    new OracleParameter(":n_dxdz", OracleType.Float,8),
                    new OracleParameter(":n_dxdc", OracleType.Float,8),
                    new OracleParameter(":n_dyty", OracleType.Float,8),
                    new OracleParameter(":n_dydz", OracleType.Float,8),
                    new OracleParameter(":n_dydc", OracleType.Float,8),
                    new OracleParameter(":n_dsty", OracleType.Float,8),
                    new OracleParameter(":n_dsdz", OracleType.Float,8),
                    new OracleParameter(":n_dsdc", OracleType.Float,8),
                    new OracleParameter(":n_zdrfty", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdz", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdc", OracleType.Float,8),
                    new OracleParameter(":n_zddxty", OracleType.Float,8),
                    new OracleParameter(":n_zddxdz", OracleType.Float,8),
                    new OracleParameter(":n_zddxdc", OracleType.Float,8),
                    new OracleParameter(":n_syty", OracleType.Float,8),
                    new OracleParameter(":n_sydz", OracleType.Float,8),
                    new OracleParameter(":n_sydc", OracleType.Float,8),
                    new OracleParameter(":n_ggty", OracleType.Float,8),
                    new OracleParameter(":n_ggdz", OracleType.Float,8),
                    new OracleParameter(":n_ggdc", OracleType.Float,8),
                    new OracleParameter(":n_gjty", OracleType.Float,8),
                    new OracleParameter(":n_gjdz", OracleType.Float,8),
                    new OracleParameter(":n_gjdc", OracleType.Float,8)
				};
        parametersMB[0].Value = mo_mb.N_HYZH;
        parametersMB[1].Value = mo_mb.N_RFTY;
        parametersMB[2].Value = mo_mb.N_RFDZ;
        parametersMB[3].Value = mo_mb.N_RFDC;
        parametersMB[4].Value = mo_mb.N_DXTY;
        parametersMB[5].Value = mo_mb.N_DXDZ;
        parametersMB[6].Value = mo_mb.N_DXDC;
        parametersMB[7].Value = mo_mb.N_DYTY;
        parametersMB[8].Value = mo_mb.N_DYDZ;
        parametersMB[9].Value = mo_mb.N_DYDC;
        parametersMB[10].Value = mo_mb.N_DSTY;
        parametersMB[11].Value = mo_mb.N_DSDZ;
        parametersMB[12].Value = mo_mb.N_DSDC;
        parametersMB[13].Value = mo_mb.N_ZDRFTY;
        parametersMB[14].Value = mo_mb.N_ZDRFDZ;
        parametersMB[15].Value = mo_mb.N_ZDRFDC;
        parametersMB[16].Value = mo_mb.N_ZDDXTY;
        parametersMB[17].Value = mo_mb.N_ZDDXDZ;
        parametersMB[18].Value = mo_mb.N_ZDDXDC;
        parametersMB[19].Value = mo_mb.N_SYTY;
        parametersMB[20].Value = mo_mb.N_SYDZ;
        parametersMB[21].Value = mo_mb.N_SYDC;
        parametersMB[22].Value = mo_mb.N_GGTY;
        parametersMB[23].Value = mo_mb.N_GGDZ;
        parametersMB[24].Value = mo_mb.N_GGDC;
        parametersMB[25].Value = mo_mb.N_GJTY;
        parametersMB[26].Value = mo_mb.N_GJDZ;
        parametersMB[27].Value = mo_mb.N_GJDC;
        o_hsta.Add(strSql.ToString(), parametersMB);
        #endregion
        #region"网球"
        strSql = new StringBuilder();
        strSql.Append(" insert into kfb_setuprb(n_hyzh,n_rfty,n_dxty,n_dyty,n_dsty,n_zdrfty,n_zddxty,n_syty,n_ggty,n_gjty,");
        strSql.Append(" n_rfdz,n_dxdz,n_dydz,n_dsdz,n_zdrfdz,n_zddxdz,n_sydz,n_ggdz,n_gjdz,");
        strSql.Append(" n_rfdc,n_dxdc,n_dydc,n_dsdc,n_zdrfdc,n_zddxdc,n_sydc,n_ggdc,n_gjdc)");
        strSql.Append("  values(:n_hyzh,:n_rfty,:n_dxty,:n_dyty,:n_dsty,:n_zdrfty,:n_zddxty,:n_syty,:n_ggty,:n_gjty,");
        strSql.Append("  :n_rfdz,:n_dxdz,:n_dydz,:n_dsdz,:n_zdrfdz,:n_zddxdz,:n_sydz,:n_ggdz,:n_gjdz,");
        strSql.Append(" :n_rfdc,:n_dxdc,:n_dydc,:n_dsdc,:n_zdrfdc,:n_zddxdc,:n_sydc,:n_ggdc,:n_gjdc)");
        OracleParameter[] parametersRB = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                    new OracleParameter(":n_rfty", OracleType.Float,8),
                    new OracleParameter(":n_rfdz", OracleType.Float,8),
                    new OracleParameter(":n_rfdc", OracleType.Float,8),
                    new OracleParameter(":n_dxty", OracleType.Float,8),
                    new OracleParameter(":n_dxdz", OracleType.Float,8),
                    new OracleParameter(":n_dxdc", OracleType.Float,8),
                    new OracleParameter(":n_dyty", OracleType.Float,8),
                    new OracleParameter(":n_dydz", OracleType.Float,8),
                    new OracleParameter(":n_dydc", OracleType.Float,8),
                    new OracleParameter(":n_dsty", OracleType.Float,8),
                    new OracleParameter(":n_dsdz", OracleType.Float,8),
                    new OracleParameter(":n_dsdc", OracleType.Float,8),
                    new OracleParameter(":n_zdrfty", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdz", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdc", OracleType.Float,8),
                    new OracleParameter(":n_zddxty", OracleType.Float,8),
                    new OracleParameter(":n_zddxdz", OracleType.Float,8),
                    new OracleParameter(":n_zddxdc", OracleType.Float,8),
                    new OracleParameter(":n_syty", OracleType.Float,8),
                    new OracleParameter(":n_sydz", OracleType.Float,8),
                    new OracleParameter(":n_sydc", OracleType.Float,8),
                    new OracleParameter(":n_ggty", OracleType.Float,8),
                    new OracleParameter(":n_ggdz", OracleType.Float,8),
                    new OracleParameter(":n_ggdc", OracleType.Float,8),
                    new OracleParameter(":n_gjty", OracleType.Float,8),
                    new OracleParameter(":n_gjdz", OracleType.Float,8),
                    new OracleParameter(":n_gjdc", OracleType.Float,8)
				};
        parametersRB[0].Value = mo_rb.N_HYZH;
        parametersRB[1].Value = mo_rb.N_RFTY;
        parametersRB[2].Value = mo_rb.N_RFDZ;
        parametersRB[3].Value = mo_rb.N_RFDC;
        parametersRB[4].Value = mo_rb.N_DXTY;
        parametersRB[5].Value = mo_rb.N_DXDZ;
        parametersRB[6].Value = mo_rb.N_DXDC;
        parametersRB[7].Value = mo_rb.N_DYTY;
        parametersRB[8].Value = mo_rb.N_DYDZ;
        parametersRB[9].Value = mo_rb.N_DYDC;
        parametersRB[10].Value = mo_rb.N_DSTY;
        parametersRB[11].Value = mo_rb.N_DSDZ;
        parametersRB[12].Value = mo_rb.N_DSDC;
        parametersRB[13].Value = mo_rb.N_ZDRFTY;
        parametersRB[14].Value = mo_rb.N_ZDRFDZ;
        parametersRB[15].Value = mo_rb.N_ZDRFDC;
        parametersRB[16].Value = mo_rb.N_ZDDXTY;
        parametersRB[17].Value = mo_rb.N_ZDDXDZ;
        parametersRB[18].Value = mo_rb.N_ZDDXDC;
        parametersRB[19].Value = mo_rb.N_SYTY;
        parametersRB[20].Value = mo_rb.N_SYDZ;
        parametersRB[21].Value = mo_rb.N_SYDC;
        parametersRB[22].Value = mo_rb.N_GGTY;
        parametersRB[23].Value = mo_rb.N_GGDZ;
        parametersRB[24].Value = mo_rb.N_GGDC;
        parametersRB[25].Value = mo_rb.N_GJTY;
        parametersRB[26].Value = mo_rb.N_GJDZ;
        parametersRB[27].Value = mo_rb.N_GJDC;
        o_hsta.Add(strSql.ToString(), parametersRB);
        #endregion
        #region"排球"
        strSql = new StringBuilder();
        strSql.Append(" insert into kfb_setuptb(n_hyzh,n_rfty,n_dxty,n_dyty,n_dsty,n_zdrfty,n_zddxty,n_syty,n_ggty,n_gjty,");
        strSql.Append(" n_rfdz,n_dxdz,n_dydz,n_dsdz,n_zdrfdz,n_zddxdz,n_sydz,n_ggdz,n_gjdz,");
        strSql.Append(" n_rfdc,n_dxdc,n_dydc,n_dsdc,n_zdrfdc,n_zddxdc,n_sydc,n_ggdc,n_gjdc)");
        strSql.Append("  values(:n_hyzh,:n_rfty,:n_dxty,:n_dyty,:n_dsty,:n_zdrfty,:n_zddxty,:n_syty,:n_ggty,:n_gjty,");
        strSql.Append("  :n_rfdz,:n_dxdz,:n_dydz,:n_dsdz,:n_zdrfdz,:n_zddxdz,:n_sydz,:n_ggdz,:n_gjdz,");
        strSql.Append(" :n_rfdc,:n_dxdc,:n_dydc,:n_dsdc,:n_zdrfdc,:n_zddxdc,:n_sydc,:n_ggdc,:n_gjdc)");
        OracleParameter[] parametersTB = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                    new OracleParameter(":n_rfty", OracleType.Float,8),
                    new OracleParameter(":n_rfdz", OracleType.Float,8),
                    new OracleParameter(":n_rfdc", OracleType.Float,8),
                    new OracleParameter(":n_dxty", OracleType.Float,8),
                    new OracleParameter(":n_dxdz", OracleType.Float,8),
                    new OracleParameter(":n_dxdc", OracleType.Float,8),
                    new OracleParameter(":n_dyty", OracleType.Float,8),
                    new OracleParameter(":n_dydz", OracleType.Float,8),
                    new OracleParameter(":n_dydc", OracleType.Float,8),
                    new OracleParameter(":n_dsty", OracleType.Float,8),
                    new OracleParameter(":n_dsdz", OracleType.Float,8),
                    new OracleParameter(":n_dsdc", OracleType.Float,8),
                    new OracleParameter(":n_zdrfty", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdz", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdc", OracleType.Float,8),
                    new OracleParameter(":n_zddxty", OracleType.Float,8),
                    new OracleParameter(":n_zddxdz", OracleType.Float,8),
                    new OracleParameter(":n_zddxdc", OracleType.Float,8),
                    new OracleParameter(":n_syty", OracleType.Float,8),
                    new OracleParameter(":n_sydz", OracleType.Float,8),
                    new OracleParameter(":n_sydc", OracleType.Float,8),
                    new OracleParameter(":n_ggty", OracleType.Float,8),
                    new OracleParameter(":n_ggdz", OracleType.Float,8),
                    new OracleParameter(":n_ggdc", OracleType.Float,8),
                    new OracleParameter(":n_gjty", OracleType.Float,8),
                    new OracleParameter(":n_gjdz", OracleType.Float,8),
                    new OracleParameter(":n_gjdc", OracleType.Float,8)
				};
        parametersTB[0].Value = mo_tb.N_HYZH;
        parametersTB[1].Value = mo_tb.N_RFTY;
        parametersTB[2].Value = mo_tb.N_RFDZ;
        parametersTB[3].Value = mo_tb.N_RFDC;
        parametersTB[4].Value = mo_tb.N_DXTY;
        parametersTB[5].Value = mo_tb.N_DXDZ;
        parametersTB[6].Value = mo_tb.N_DXDC;
        parametersTB[7].Value = mo_tb.N_DYTY;
        parametersTB[8].Value = mo_tb.N_DYDZ;
        parametersTB[9].Value = mo_tb.N_DYDC;
        parametersTB[10].Value = mo_tb.N_DSTY;
        parametersTB[11].Value = mo_tb.N_DSDZ;
        parametersTB[12].Value = mo_tb.N_DSDC;
        parametersTB[13].Value = mo_tb.N_ZDRFTY;
        parametersTB[14].Value = mo_tb.N_ZDRFDZ;
        parametersTB[15].Value = mo_tb.N_ZDRFDC;
        parametersTB[16].Value = mo_tb.N_ZDDXTY;
        parametersTB[17].Value = mo_tb.N_ZDDXDZ;
        parametersTB[18].Value = mo_tb.N_ZDDXDC;
        parametersTB[19].Value = mo_tb.N_SYTY;
        parametersTB[20].Value = mo_tb.N_SYDZ;
        parametersTB[21].Value = mo_tb.N_SYDC;
        parametersTB[22].Value = mo_tb.N_GGTY;
        parametersTB[23].Value = mo_tb.N_GGDZ;
        parametersTB[24].Value = mo_tb.N_GGDC;
        parametersTB[25].Value = mo_tb.N_GJTY;
        parametersTB[26].Value = mo_tb.N_GJDZ;
        parametersTB[27].Value = mo_tb.N_GJDC;
        o_hsta.Add(strSql.ToString(), parametersTB);
        #endregion
        #region"足球"
        strSql = new StringBuilder();
        strSql.Append(" insert into kfb_setupzq(n_hyzh,n_arfty,n_adxty,n_adyty,n_adsty,n_azdrfty,n_azddxty,n_abcrfty,n_abcdxty,n_abcdyty,n_arqsty,n_abdty,n_abqcty,n_aggty,n_agjty,");
        strSql.Append(" n_brfty,n_bdxty,n_bdyty,n_bdsty,n_bzdrfty,n_bzddxty,n_bbcrfty,n_bbcdxty,n_bbcdyty,n_brqsty,n_bbdty,n_bbqcty,n_bggty,n_bgjty,");
        strSql.Append(" n_crfty,n_cdxty,n_cdyty,n_cdsty,n_czdrfty,n_czddxty,n_cbcrfty,n_cbcdxty,n_cbcdyty,n_crqsty,n_cbdty,n_cbqcty,n_cggty,n_cgjty,");
        strSql.Append(" n_rfdz,n_dxdz,n_dydz,n_dsdz,n_zdrfdz,n_zddxdz,n_bcrfdz,n_bcdxdz,n_bcdydz,n_rqsdz,n_bddz,n_bqcdz,n_ggdz,n_gjdz,");
        strSql.Append(" n_rfdc,n_dxdc,n_dydc,n_dsdc,n_zdrfdc,n_zddxdc,n_bcrfdc,n_bcdxdc,n_bcdydc,n_rqsdc,n_bddc,n_bqcdc,n_ggdc,n_gjdc)");
        strSql.Append("  values(:n_hyzh,:n_arfty,:n_adxty,:n_adyty,:n_adsty,:n_azdrfty,:n_azddxty,:n_abcrfty,:n_abcdxty,:n_abcdyty,:n_arqsty,:n_abdty,:n_abqcty,:n_aggty,:n_agjty,");
        strSql.Append("  :n_brfty,:n_bdxty,:n_bdyty,:n_bdsty,:n_bzdrfty,:n_bzddxty,:n_bbcrfty,:n_bbcdxty,:n_bbcdyty,:n_brqsty,:n_bbdty,:n_bbqcty,:n_bggty,:n_bgjty,");
        strSql.Append("  :n_crfty,:n_cdxty,:n_cdyty,:n_cdsty,:n_czdrfty,:n_czddxty,:n_cbcrfty,:n_cbcdxty,:n_cbcdyty,:n_crqsty,:n_cbdty,:n_cbqcty,:n_cggty,:n_cgjty,");
        strSql.Append("  :n_rfdz,:n_dxdz,:n_dydz,:n_dsdz,:n_zdrfdz,:n_zddxdz,:n_bcrfdz,:n_bcdxdz,:n_bcdydz,:n_rqsdz,:n_bddz,:n_bqcdz,:n_ggdz,:n_gjdz,");
        strSql.Append(" :n_rfdc,:n_dxdc,:n_dydc,:n_dsdc,:n_zdrfdc,:n_zddxdc,:n_bcrfdc,:n_bcdxdc,:n_bcdydc,:n_rqsdc,:n_bddc,:n_bqcdc,:n_ggdc,:n_gjdc)");
        OracleParameter[] parameterszq = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                    new OracleParameter(":n_arfty", OracleType.Float,8),
                    new OracleParameter(":n_adxty", OracleType.Float,8),
                    new OracleParameter(":n_adyty", OracleType.Float,8),
                    new OracleParameter(":n_adsty", OracleType.Float,8),
                    new OracleParameter(":n_azdrfty", OracleType.Float,8),
                    new OracleParameter(":n_azddxty", OracleType.Float,8),
                    new OracleParameter(":n_abcrfty", OracleType.Float,8),
                    new OracleParameter(":n_abcdxty", OracleType.Float,8),
                    new OracleParameter(":n_abcdyty", OracleType.Float,8),
                    new OracleParameter(":n_arqsty", OracleType.Float,8),
                    new OracleParameter(":n_abdty", OracleType.Float,8),
                    new OracleParameter(":n_abqcty", OracleType.Float,8),
                    new OracleParameter(":n_aggty", OracleType.Float,8),
                    new OracleParameter(":n_agjty", OracleType.Float,8),
                    new OracleParameter(":n_brfty", OracleType.Float,8),
                    new OracleParameter(":n_bdxty", OracleType.Float,8),
                    new OracleParameter(":n_bdyty", OracleType.Float,8),
                    new OracleParameter(":n_bdsty", OracleType.Float,8),
                    new OracleParameter(":n_bzdrfty", OracleType.Float,8),
                    new OracleParameter(":n_bzddxty", OracleType.Float,8),
                    new OracleParameter(":n_bbcrfty", OracleType.Float,8),
                    new OracleParameter(":n_bbcdxty", OracleType.Float,8),
                    new OracleParameter(":n_bbcdyty", OracleType.Float,8),
                    new OracleParameter(":n_brqsty", OracleType.Float,8),
                    new OracleParameter(":n_bbdty", OracleType.Float,8),
                    new OracleParameter(":n_bbqcty", OracleType.Float,8),
                    new OracleParameter(":n_bggty", OracleType.Float,8),
                    new OracleParameter(":n_bgjty", OracleType.Float,8),
                    new OracleParameter(":n_crfty", OracleType.Float,8),
                    new OracleParameter(":n_cdxty", OracleType.Float,8),
                    new OracleParameter(":n_cdyty", OracleType.Float,8),
                    new OracleParameter(":n_cdsty", OracleType.Float,8),
                    new OracleParameter(":n_czdrfty", OracleType.Float,8),
                    new OracleParameter(":n_czddxty", OracleType.Float,8),
                    new OracleParameter(":n_cbcrfty", OracleType.Float,8),
                    new OracleParameter(":n_cbcdxty", OracleType.Float,8),
                    new OracleParameter(":n_cbcdyty", OracleType.Float,8),
                    new OracleParameter(":n_crqsty", OracleType.Float,8),
                    new OracleParameter(":n_cbdty", OracleType.Float,8),
                    new OracleParameter(":n_cbqcty", OracleType.Float,8),
                    new OracleParameter(":n_cggty", OracleType.Float,8),
                    new OracleParameter(":n_cgjty", OracleType.Float,8),
                    new OracleParameter(":n_rfdz", OracleType.Float,8),
                    new OracleParameter(":n_rfdc", OracleType.Float,8),
                    new OracleParameter(":n_dxdz", OracleType.Float,8),
                    new OracleParameter(":n_dxdc", OracleType.Float,8),
                    new OracleParameter(":n_dydz", OracleType.Float,8),
                    new OracleParameter(":n_dydc", OracleType.Float,8),
                    new OracleParameter(":n_dsdz", OracleType.Float,8),
                    new OracleParameter(":n_dsdc", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdz", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdc", OracleType.Float,8),
                    new OracleParameter(":n_zddxdz", OracleType.Float,8),
                    new OracleParameter(":n_zddxdc", OracleType.Float,8),
                    new OracleParameter(":n_bcrfdz", OracleType.Float,8),
                    new OracleParameter(":n_bcrfdc", OracleType.Float,8),
                    new OracleParameter(":n_bcdxdz", OracleType.Float,8),
                    new OracleParameter(":n_bcdxdc", OracleType.Float,8),
                    new OracleParameter(":n_bcdydz", OracleType.Float,8),
                    new OracleParameter(":n_bcdydc", OracleType.Float,8),
                    new OracleParameter(":n_rqsdz", OracleType.Float,8),
                    new OracleParameter(":n_rqsdc", OracleType.Float,8),
                    new OracleParameter(":n_bddz", OracleType.Float,8),
                    new OracleParameter(":n_bddc", OracleType.Float,8),
                    new OracleParameter(":n_bqcdz", OracleType.Float,8),
                    new OracleParameter(":n_bqcdc", OracleType.Float,8),
                    new OracleParameter(":n_ggdz", OracleType.Float,8),
                    new OracleParameter(":n_ggdc", OracleType.Float,8),
                    new OracleParameter(":n_gjdz", OracleType.Float,8),
                    new OracleParameter(":n_gjdc", OracleType.Float,8)
				};
        parameterszq[0].Value = mo_zq.N_HYZH;
        parameterszq[1].Value = mo_zq.N_ARFTY;
        parameterszq[2].Value = mo_zq.N_ADXTY;
        parameterszq[3].Value = mo_zq.N_ADYTY;
        parameterszq[4].Value = mo_zq.N_ADSTY;
        parameterszq[5].Value = mo_zq.N_AZDRFTY;
        parameterszq[6].Value = mo_zq.N_AZDDXTY;
        parameterszq[7].Value = mo_zq.N_ABCRFTY;
        parameterszq[8].Value = mo_zq.N_ABCDXTY;
        parameterszq[9].Value = mo_zq.N_ABCDYTY;
        parameterszq[10].Value = mo_zq.N_ARQSTY;
        parameterszq[11].Value = mo_zq.N_ABDTY;
        parameterszq[12].Value = mo_zq.N_ABQCTY;
        parameterszq[13].Value = mo_zq.N_AGGTY;
        parameterszq[14].Value = mo_zq.N_AGJTY;
        parameterszq[15].Value = mo_zq.N_BRFTY;
        parameterszq[16].Value = mo_zq.N_BDXTY;
        parameterszq[17].Value = mo_zq.N_BDYTY;
        parameterszq[18].Value = mo_zq.N_BDSTY;
        parameterszq[19].Value = mo_zq.N_BZDRFTY;
        parameterszq[20].Value = mo_zq.N_BZDDXTY;
        parameterszq[21].Value = mo_zq.N_BBCRFTY;
        parameterszq[22].Value = mo_zq.N_BBCDXTY;
        parameterszq[23].Value = mo_zq.N_BBCDYTY;
        parameterszq[24].Value = mo_zq.N_BRQSTY;
        parameterszq[25].Value = mo_zq.N_BBDTY;
        parameterszq[26].Value = mo_zq.N_BBQCTY;
        parameterszq[27].Value = mo_zq.N_BGGTY;
        parameterszq[28].Value = mo_zq.N_BGJTY;
        parameterszq[29].Value = mo_zq.N_CRFTY;
        parameterszq[30].Value = mo_zq.N_CDXTY;
        parameterszq[31].Value = mo_zq.N_CDYTY;
        parameterszq[32].Value = mo_zq.N_CDSTY;
        parameterszq[33].Value = mo_zq.N_CZDRFTY;
        parameterszq[34].Value = mo_zq.N_CZDDXTY;
        parameterszq[35].Value = mo_zq.N_CBCRFTY;
        parameterszq[36].Value = mo_zq.N_CBCDXTY;
        parameterszq[37].Value = mo_zq.N_CBCDYTY;
        parameterszq[38].Value = mo_zq.N_CRQSTY;
        parameterszq[39].Value = mo_zq.N_CBDTY;
        parameterszq[40].Value = mo_zq.N_CBQCTY;
        parameterszq[41].Value = mo_zq.N_CGGTY;
        parameterszq[42].Value = mo_zq.N_CGJTY;
        parameterszq[43].Value = mo_zq.N_RFDZ;
        parameterszq[44].Value = mo_zq.N_RFDC;
        parameterszq[45].Value = mo_zq.N_DXDZ;
        parameterszq[46].Value = mo_zq.N_DXDC;
        parameterszq[47].Value = mo_zq.N_DYDZ;
        parameterszq[48].Value = mo_zq.N_DYDC;
        parameterszq[49].Value = mo_zq.N_DSDZ;
        parameterszq[50].Value = mo_zq.N_DSDC;
        parameterszq[51].Value = mo_zq.N_ZDRFDZ;
        parameterszq[52].Value = mo_zq.N_ZDRFDC;
        parameterszq[53].Value = mo_zq.N_ZDDXDZ;
        parameterszq[54].Value = mo_zq.N_ZDDXDC;
        parameterszq[55].Value = mo_zq.N_BCRFDZ;
        parameterszq[56].Value = mo_zq.N_BCRFDC;
        parameterszq[57].Value = mo_zq.N_BCDXDZ;
        parameterszq[58].Value = mo_zq.N_BCDXDC;
        parameterszq[59].Value = mo_zq.N_BCDYDZ;
        parameterszq[60].Value = mo_zq.N_BCDYDC;
        parameterszq[61].Value = mo_zq.N_RQSDZ;
        parameterszq[62].Value = mo_zq.N_RQSDC;
        parameterszq[63].Value = mo_zq.N_BDDZ;
        parameterszq[64].Value = mo_zq.N_BDDC;
        parameterszq[65].Value = mo_zq.N_BQCDZ;
        parameterszq[66].Value = mo_zq.N_BQCDC;
        parameterszq[67].Value = mo_zq.N_GGDZ;
        parameterszq[68].Value = mo_zq.N_GGDC;
        parameterszq[69].Value = mo_zq.N_GJDZ;
        parameterszq[70].Value = mo_zq.N_GJDC;
        o_hsta.Add(strSql.ToString(), parameterszq);
        #endregion
        #region"美足"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPMQ(");
        strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_BCRFTY,:N_BCDXTY,:N_BCDYTY,:N_BCDSTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_BCRFDZ,:N_BCDXDZ,:N_BCDYDZ,:N_BCDSDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_BCRFDC,:N_BCDXDC,:N_BCDYDC,:N_BCDSDC,:N_GGDC,:N_GJDC)");
        OracleParameter[] parametersMZ = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCRFTY", OracleType.Float,22),
					new OracleParameter(":N_BCDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCDYTY", OracleType.Float,22),
					new OracleParameter(":N_BCDSTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCRFDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDYDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCRFDC", OracleType.Float,22),
					new OracleParameter(":N_BCDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCDYDC", OracleType.Float,22),
					new OracleParameter(":N_BCDSDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
        parametersMZ[0].Value = mo_mz.N_HYZH;
        parametersMZ[1].Value = mo_mz.N_RFTY;
        parametersMZ[2].Value = mo_mz.N_DXTY;
        parametersMZ[3].Value = mo_mz.N_DYTY;
        parametersMZ[4].Value = mo_mz.N_DSTY;
        parametersMZ[5].Value = mo_mz.N_ZDRFTY;
        parametersMZ[6].Value = mo_mz.N_ZDDXTY;
        parametersMZ[7].Value = mo_mz.N_BCRFTY;
        parametersMZ[8].Value = mo_mz.N_BCDXTY;
        parametersMZ[9].Value = mo_mz.N_BCDYTY;
        parametersMZ[10].Value = mo_mz.N_BCDSTY;
        parametersMZ[11].Value = mo_mz.N_GGTY;
        parametersMZ[12].Value = mo_mz.N_GJTY;
        parametersMZ[13].Value = mo_mz.N_RFDZ;
        parametersMZ[14].Value = mo_mz.N_DXDZ;
        parametersMZ[15].Value = mo_mz.N_DYDZ;
        parametersMZ[16].Value = mo_mz.N_DSDZ;
        parametersMZ[17].Value = mo_mz.N_ZDRFDZ;
        parametersMZ[18].Value = mo_mz.N_ZDDXDZ;
        parametersMZ[19].Value = mo_mz.N_BCRFDZ;
        parametersMZ[20].Value = mo_mz.N_BCDXDZ;
        parametersMZ[21].Value = mo_mz.N_BCDYDZ;
        parametersMZ[22].Value = mo_mz.N_BCDSDZ;
        parametersMZ[23].Value = mo_mz.N_GGDZ;
        parametersMZ[24].Value = mo_mz.N_GJDZ;
        parametersMZ[25].Value = mo_mz.N_RFDC;
        parametersMZ[26].Value = mo_mz.N_DXDC;
        parametersMZ[27].Value = mo_mz.N_DYDC;
        parametersMZ[28].Value = mo_mz.N_DSDC;
        parametersMZ[29].Value = mo_mz.N_ZDRFDC;
        parametersMZ[30].Value = mo_mz.N_ZDDXDC;
        parametersMZ[31].Value = mo_mz.N_BCRFDC;
        parametersMZ[32].Value = mo_mz.N_BCDXDC;
        parametersMZ[33].Value = mo_mz.N_BCDYDC;
        parametersMZ[34].Value = mo_mz.N_BCDSDC;
        parametersMZ[35].Value = mo_mz.N_GGDC;
        parametersMZ[36].Value = mo_mz.N_GJDC;
        o_hsta.Add(strSql.ToString(), parametersMZ);
        #endregion
        #region"冰球"
        strSql = new StringBuilder();
        strSql.Append(" insert into kfb_setupbq(n_hyzh,n_rfty,n_dxty,n_dyty,n_dsty,n_zdrfty,n_zddxty,n_syty,n_ggty,n_gjty,");
        strSql.Append(" n_rfdz,n_dxdz,n_dydz,n_dsdz,n_zdrfdz,n_zddxdz,n_sydz,n_ggdz,n_gjdz,");
        strSql.Append(" n_rfdc,n_dxdc,n_dydc,n_dsdc,n_zdrfdc,n_zddxdc,n_sydc,n_ggdc,n_gjdc)");
        strSql.Append("  values(:n_hyzh,:n_rfty,:n_dxty,:n_dyty,:n_dsty,:n_zdrfty,:n_zddxty,:n_syty,:n_ggty,:n_gjty,");
        strSql.Append("  :n_rfdz,:n_dxdz,:n_dydz,:n_dsdz,:n_zdrfdz,:n_zddxdz,:n_sydz,:n_ggdz,:n_gjdz,");
        strSql.Append(" :n_rfdc,:n_dxdc,:n_dydc,:n_dsdc,:n_zdrfdc,:n_zddxdc,:n_sydc,:n_ggdc,:n_gjdc)");
        OracleParameter[] parametersBQ = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100),
                    new OracleParameter(":n_rfty", OracleType.Float,8),
                    new OracleParameter(":n_rfdz", OracleType.Float,8),
                    new OracleParameter(":n_rfdc", OracleType.Float,8),
                    new OracleParameter(":n_dxty", OracleType.Float,8),
                    new OracleParameter(":n_dxdz", OracleType.Float,8),
                    new OracleParameter(":n_dxdc", OracleType.Float,8),
                    new OracleParameter(":n_dyty", OracleType.Float,8),
                    new OracleParameter(":n_dydz", OracleType.Float,8),
                    new OracleParameter(":n_dydc", OracleType.Float,8),
                    new OracleParameter(":n_dsty", OracleType.Float,8),
                    new OracleParameter(":n_dsdz", OracleType.Float,8),
                    new OracleParameter(":n_dsdc", OracleType.Float,8),
                    new OracleParameter(":n_zdrfty", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdz", OracleType.Float,8),
                    new OracleParameter(":n_zdrfdc", OracleType.Float,8),
                    new OracleParameter(":n_zddxty", OracleType.Float,8),
                    new OracleParameter(":n_zddxdz", OracleType.Float,8),
                    new OracleParameter(":n_zddxdc", OracleType.Float,8),
                    new OracleParameter(":n_syty", OracleType.Float,8),
                    new OracleParameter(":n_sydz", OracleType.Float,8),
                    new OracleParameter(":n_sydc", OracleType.Float,8),
                    new OracleParameter(":n_ggty", OracleType.Float,8),
                    new OracleParameter(":n_ggdz", OracleType.Float,8),
                    new OracleParameter(":n_ggdc", OracleType.Float,8),
                    new OracleParameter(":n_gjty", OracleType.Float,8),
                    new OracleParameter(":n_gjdz", OracleType.Float,8),
                    new OracleParameter(":n_gjdc", OracleType.Float,8)
				};
        parametersBQ[0].Value = mo_bq.N_HYZH;
        parametersBQ[1].Value = mo_bq.N_RFTY;
        parametersBQ[2].Value = mo_bq.N_RFDZ;
        parametersBQ[3].Value = mo_bq.N_RFDC;
        parametersBQ[4].Value = mo_bq.N_DXTY;
        parametersBQ[5].Value = mo_bq.N_DXDZ;
        parametersBQ[6].Value = mo_bq.N_DXDC;
        parametersBQ[7].Value = mo_bq.N_DYTY;
        parametersBQ[8].Value = mo_bq.N_DYDZ;
        parametersBQ[9].Value = mo_bq.N_DYDC;
        parametersBQ[10].Value = mo_bq.N_DSTY;
        parametersBQ[11].Value = mo_bq.N_DSDZ;
        parametersBQ[12].Value = mo_bq.N_DSDC;
        parametersBQ[13].Value = mo_bq.N_ZDRFTY;
        parametersBQ[14].Value = mo_bq.N_ZDRFDZ;
        parametersBQ[15].Value = mo_bq.N_ZDRFDC;
        parametersBQ[16].Value = mo_bq.N_ZDDXTY;
        parametersBQ[17].Value = mo_bq.N_ZDDXDZ;
        parametersBQ[18].Value = mo_bq.N_ZDDXDC;
        parametersBQ[19].Value = mo_bq.N_SYTY;
        parametersBQ[20].Value = mo_bq.N_SYDZ;
        parametersBQ[21].Value = mo_bq.N_SYDC;
        parametersBQ[22].Value = mo_bq.N_GGTY;
        parametersBQ[23].Value = mo_bq.N_GGDZ;
        parametersBQ[24].Value = mo_bq.N_GGDC;
        parametersBQ[25].Value = mo_bq.N_GJTY;
        parametersBQ[26].Value = mo_bq.N_GJDZ;
        parametersBQ[27].Value = mo_bq.N_GJDC;
        o_hsta.Add(strSql.ToString(), parametersBQ);
        #endregion
        #region"彩球"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPCQ(");
        strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_BCRFTY,:N_BCDXTY,:N_BCDYTY,:N_BCDSTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_BCRFDZ,:N_BCDXDZ,:N_BCDYDZ,:N_BCDSDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_BCRFDC,:N_BCDXDC,:N_BCDYDC,:N_BCDSDC,:N_GGDC,:N_GJDC)");
        OracleParameter[] parametersCQ = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCRFTY", OracleType.Float,22),
					new OracleParameter(":N_BCDXTY", OracleType.Float,22),
					new OracleParameter(":N_BCDYTY", OracleType.Float,22),
					new OracleParameter(":N_BCDSTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCRFDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDYDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCRFDC", OracleType.Float,22),
					new OracleParameter(":N_BCDXDC", OracleType.Float,22),
					new OracleParameter(":N_BCDYDC", OracleType.Float,22),
					new OracleParameter(":N_BCDSDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
        parametersCQ[0].Value = mo_cq.N_HYZH;
        parametersCQ[1].Value = mo_cq.N_RFTY;
        parametersCQ[2].Value = mo_cq.N_DXTY;
        parametersCQ[3].Value = mo_cq.N_DYTY;
        parametersCQ[4].Value = mo_cq.N_DSTY;
        parametersCQ[5].Value = mo_cq.N_ZDRFTY;
        parametersCQ[6].Value = mo_cq.N_ZDDXTY;
        parametersCQ[7].Value = mo_cq.N_BCRFTY;
        parametersCQ[8].Value = mo_cq.N_BCDXTY;
        parametersCQ[9].Value = mo_cq.N_BCDYTY;
        parametersCQ[10].Value = mo_cq.N_BCDSTY;
        parametersCQ[11].Value = mo_cq.N_GGTY;
        parametersCQ[12].Value = mo_cq.N_GJTY;
        parametersCQ[13].Value = mo_cq.N_RFDZ;
        parametersCQ[14].Value = mo_cq.N_DXDZ;
        parametersCQ[15].Value = mo_cq.N_DYDZ;
        parametersCQ[16].Value = mo_cq.N_DSDZ;
        parametersCQ[17].Value = mo_cq.N_ZDRFDZ;
        parametersCQ[18].Value = mo_cq.N_ZDDXDZ;
        parametersCQ[19].Value = mo_cq.N_BCRFDZ;
        parametersCQ[20].Value = mo_cq.N_BCDXDZ;
        parametersCQ[21].Value = mo_cq.N_BCDYDZ;
        parametersCQ[22].Value = mo_cq.N_BCDSDZ;
        parametersCQ[23].Value = mo_cq.N_GGDZ;
        parametersCQ[24].Value = mo_cq.N_GJDZ;
        parametersCQ[25].Value = mo_cq.N_RFDC;
        parametersCQ[26].Value = mo_cq.N_DXDC;
        parametersCQ[27].Value = mo_cq.N_DYDC;
        parametersCQ[28].Value = mo_cq.N_DSDC;
        parametersCQ[29].Value = mo_cq.N_ZDRFDC;
        parametersCQ[30].Value = mo_cq.N_ZDDXDC;
        parametersCQ[31].Value = mo_cq.N_BCRFDC;
        parametersCQ[32].Value = mo_cq.N_BCDXDC;
        parametersCQ[33].Value = mo_cq.N_BCDYDC;
        parametersCQ[34].Value = mo_cq.N_BCDSDC;
        parametersCQ[35].Value = mo_cq.N_GGDC;
        parametersCQ[36].Value = mo_cq.N_GJDC;
        o_hsta.Add(strSql.ToString(), parametersCQ);
        #endregion

        #region"指数"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPZS(");
        strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_BDTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_BDDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_BDDC,N_GGDC,N_GJDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_SYTY,:N_BDTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_SYDZ,:N_BDDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_SYDC,:N_BDDC,:N_GGDC,:N_GJDC)");
        OracleParameter[] parametersZS = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_BDTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_BDDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_BDDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
        parametersZS[0].Value = mo_zs.N_HYZH;
        parametersZS[1].Value = mo_zs.N_RFTY;
        parametersZS[2].Value = mo_zs.N_DXTY;
        parametersZS[3].Value = mo_zs.N_DYTY;
        parametersZS[4].Value = mo_zs.N_DSTY;
        parametersZS[5].Value = mo_zs.N_ZDRFTY;
        parametersZS[6].Value = mo_zs.N_ZDDXTY;
        parametersZS[7].Value = mo_zs.N_SYTY;
        parametersZS[8].Value = mo_zs.N_BDTY;
        parametersZS[9].Value = mo_zs.N_GGTY;
        parametersZS[10].Value = mo_zs.N_GJTY;
        parametersZS[11].Value = mo_zs.N_RFDZ;
        parametersZS[12].Value = mo_zs.N_DXDZ;
        parametersZS[13].Value = mo_zs.N_DYDZ;
        parametersZS[14].Value = mo_zs.N_DSDZ;
        parametersZS[15].Value = mo_zs.N_ZDRFDZ;
        parametersZS[16].Value = mo_zs.N_ZDDXDZ;
        parametersZS[17].Value = mo_zs.N_SYDZ;
        parametersZS[18].Value = mo_zs.N_BDDZ;
        parametersZS[19].Value = mo_zs.N_GGDZ;
        parametersZS[20].Value = mo_zs.N_GJDZ;
        parametersZS[21].Value = mo_zs.N_RFDC;
        parametersZS[22].Value = mo_zs.N_DXDC;
        parametersZS[23].Value = mo_zs.N_DYDC;
        parametersZS[24].Value = mo_zs.N_DSDC;
        parametersZS[25].Value = mo_zs.N_ZDRFDC;
        parametersZS[26].Value = mo_zs.N_ZDDXDC;
        parametersZS[27].Value = mo_zs.N_SYDC;
        parametersZS[28].Value = mo_zs.N_BDDC;
        parametersZS[29].Value = mo_zs.N_GGDC;
        parametersZS[30].Value = mo_zs.N_GJDC;
        o_hsta.Add(strSql.ToString(), parametersZS);
        #endregion
        #region"赛马"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPSM(");
        strSql.Append("N_HYDH,N_DYTY,N_WZTY,N_LYTY,N_WZQTY,N_DYDZ,N_WZDZ,N_LYDZ,N_WZQDZ,N_DYDC,N_WZDC,N_LYDC,N_WZQDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYDH,:N_DYTY,:N_WZTY,:N_LYTY,:N_WZQTY,:N_DYDZ,:N_WZDZ,:N_LYDZ,:N_WZQDZ,:N_DYDC,:N_WZDC,:N_LYDC,:N_WZQDC)");
        OracleParameter[] parametersSM = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_WZTY", OracleType.Float,22),
					new OracleParameter(":N_LYTY", OracleType.Float,22),
					new OracleParameter(":N_WZQTY", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_WZDZ", OracleType.Float,22),
					new OracleParameter(":N_LYDZ", OracleType.Float,22),
					new OracleParameter(":N_WZQDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_WZDC", OracleType.Float,22),
					new OracleParameter(":N_LYDC", OracleType.Float,22),
					new OracleParameter(":N_WZQDC", OracleType.Float,22)};
        parametersSM[0].Value = mo_sm.N_HYDH;
        parametersSM[1].Value = mo_sm.N_DYTY;
        parametersSM[2].Value = mo_sm.N_WZTY;
        parametersSM[3].Value = mo_sm.N_LYTY;
        parametersSM[4].Value = mo_sm.N_WZQTY;
        parametersSM[5].Value = mo_sm.N_DYDZ;
        parametersSM[6].Value = mo_sm.N_WZDZ;
        parametersSM[7].Value = mo_sm.N_LYDZ;
        parametersSM[8].Value = mo_sm.N_WZQDZ;
        parametersSM[9].Value = mo_sm.N_DYDC;
        parametersSM[10].Value = mo_sm.N_WZDC;
        parametersSM[11].Value = mo_sm.N_LYDC;
        parametersSM[12].Value = mo_sm.N_WZQDC;
        o_hsta.Add(strSql.ToString(), parametersSM);
        #endregion
        #region"六合彩"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPLHC(");
        strSql.Append("N_HYDH,N_TBHTY,N_TTTY,N_THTY,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_GDDSTY,N_GDDXTY,N_TBHDZ,N_TTDZ,N_THDZ,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_GDDSDZ,N_GDDXDZ,N_TBHDC,N_TTDC,N_THDC,N_QCPDC,N_2XDC,N_3XDC,N_4XDC,N_GDDSDC,N_GDDXDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYDH,:N_TBHTY,:N_TTTY,:N_THTY,:N_QCPTY,:N_2XTY,:N_3XTY,:N_4XTY,:N_GDDSTY,:N_GDDXTY,:N_TBHDZ,:N_TTDZ,:N_THDZ,:N_QCPDZ,:N_2XDZ,:N_3XDZ,:N_4XDZ,:N_GDDSDZ,:N_GDDXDZ,:N_TBHDC,:N_TTDC,:N_THDC,:N_QCPDC,:N_2XDC,:N_3XDC,:N_4XDC,:N_GDDSDC,:N_GDDXDC)");
        OracleParameter[] parametersLHC = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_TBHTY", OracleType.Float,22),
					new OracleParameter(":N_TTTY", OracleType.Float,22),
					new OracleParameter(":N_THTY", OracleType.Float,22),
					new OracleParameter(":N_QCPTY", OracleType.Float,22),
					new OracleParameter(":N_2XTY", OracleType.Float,22),
					new OracleParameter(":N_3XTY", OracleType.Float,22),
					new OracleParameter(":N_4XTY", OracleType.Float,22),
					new OracleParameter(":N_GDDSTY", OracleType.Float,22),
					new OracleParameter(":N_GDDXTY", OracleType.Float,22),
					new OracleParameter(":N_TBHDZ", OracleType.Float,22),
					new OracleParameter(":N_TTDZ", OracleType.Float,22),
					new OracleParameter(":N_THDZ", OracleType.Float,22),
					new OracleParameter(":N_QCPDZ", OracleType.Float,22),
					new OracleParameter(":N_2XDZ", OracleType.Float,22),
					new OracleParameter(":N_3XDZ", OracleType.Float,22),
					new OracleParameter(":N_4XDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_TBHDC", OracleType.Float,22),
					new OracleParameter(":N_TTDC", OracleType.Float,22),
					new OracleParameter(":N_THDC", OracleType.Float,22),
					new OracleParameter(":N_QCPDC", OracleType.Float,22),
					new OracleParameter(":N_2XDC", OracleType.Float,22),
					new OracleParameter(":N_3XDC", OracleType.Float,22),
					new OracleParameter(":N_4XDC", OracleType.Float,22),
					new OracleParameter(":N_GDDSDC", OracleType.Float,22),
					new OracleParameter(":N_GDDXDC", OracleType.Float,22)};
        parametersLHC[0].Value = mo_lhc.N_HYDH;
        parametersLHC[1].Value = mo_lhc.N_TBHTY;
        parametersLHC[2].Value = mo_lhc.N_TTTY;
        parametersLHC[3].Value = mo_lhc.N_THTY;
        parametersLHC[4].Value = mo_lhc.N_QCPTY;
        parametersLHC[5].Value = mo_lhc.N_2XTY;
        parametersLHC[6].Value = mo_lhc.N_3XTY;
        parametersLHC[7].Value = mo_lhc.N_4XTY;
        parametersLHC[8].Value = mo_lhc.N_GDDSTY;
        parametersLHC[9].Value = mo_lhc.N_GDDXTY;
        parametersLHC[10].Value = mo_lhc.N_TBHDZ;
        parametersLHC[11].Value = mo_lhc.N_TTDZ;
        parametersLHC[12].Value = mo_lhc.N_THDZ;
        parametersLHC[13].Value = mo_lhc.N_QCPDZ;
        parametersLHC[14].Value = mo_lhc.N_2XDZ;
        parametersLHC[15].Value = mo_lhc.N_3XDZ;
        parametersLHC[16].Value = mo_lhc.N_4XDZ;
        parametersLHC[17].Value = mo_lhc.N_GDDSDZ;
        parametersLHC[18].Value = mo_lhc.N_GDDXDZ;
        parametersLHC[19].Value = mo_lhc.N_TBHDC;
        parametersLHC[20].Value = mo_lhc.N_TTDC;
        parametersLHC[21].Value = mo_lhc.N_THDC;
        parametersLHC[22].Value = mo_lhc.N_QCPDC;
        parametersLHC[23].Value = mo_lhc.N_2XDC;
        parametersLHC[24].Value = mo_lhc.N_3XDC;
        parametersLHC[25].Value = mo_lhc.N_4XDC;
        parametersLHC[26].Value = mo_lhc.N_GDDSDC;
        parametersLHC[27].Value = mo_lhc.N_GDDXDC;
        o_hsta.Add(strSql.ToString(), parametersLHC);
        #endregion
        #region"大乐透"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPDLT(");
        strSql.Append("N_HYDH,N_TBHTY,N_TTTY,N_THTY,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_GDDSTY,N_GDDXTY,N_TBHDZ,N_TTDZ,N_THDZ,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_GDDSDZ,N_GDDXDZ,N_TBHDC,N_TTDC,N_THDC,N_QCPDC,N_2XDC,N_3XDC,N_4XDC,N_GDDSDC,N_GDDXDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYDH,:N_TBHTY,:N_TTTY,:N_THTY,:N_QCPTY,:N_2XTY,:N_3XTY,:N_4XTY,:N_GDDSTY,:N_GDDXTY,:N_TBHDZ,:N_TTDZ,:N_THDZ,:N_QCPDZ,:N_2XDZ,:N_3XDZ,:N_4XDZ,:N_GDDSDZ,:N_GDDXDZ,:N_TBHDC,:N_TTDC,:N_THDC,:N_QCPDC,:N_2XDC,:N_3XDC,:N_4XDC,:N_GDDSDC,:N_GDDXDC)");
        OracleParameter[] parametersDLT = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_TBHTY", OracleType.Float,22),
					new OracleParameter(":N_TTTY", OracleType.Float,22),
					new OracleParameter(":N_THTY", OracleType.Float,22),
					new OracleParameter(":N_QCPTY", OracleType.Float,22),
					new OracleParameter(":N_2XTY", OracleType.Float,22),
					new OracleParameter(":N_3XTY", OracleType.Float,22),
					new OracleParameter(":N_4XTY", OracleType.Float,22),
					new OracleParameter(":N_GDDSTY", OracleType.Float,22),
					new OracleParameter(":N_GDDXTY", OracleType.Float,22),
					new OracleParameter(":N_TBHDZ", OracleType.Float,22),
					new OracleParameter(":N_TTDZ", OracleType.Float,22),
					new OracleParameter(":N_THDZ", OracleType.Float,22),
					new OracleParameter(":N_QCPDZ", OracleType.Float,22),
					new OracleParameter(":N_2XDZ", OracleType.Float,22),
					new OracleParameter(":N_3XDZ", OracleType.Float,22),
					new OracleParameter(":N_4XDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDSDZ", OracleType.Float,22),
					new OracleParameter(":N_GDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_TBHDC", OracleType.Float,22),
					new OracleParameter(":N_TTDC", OracleType.Float,22),
					new OracleParameter(":N_THDC", OracleType.Float,22),
					new OracleParameter(":N_QCPDC", OracleType.Float,22),
					new OracleParameter(":N_2XDC", OracleType.Float,22),
					new OracleParameter(":N_3XDC", OracleType.Float,22),
					new OracleParameter(":N_4XDC", OracleType.Float,22),
					new OracleParameter(":N_GDDSDC", OracleType.Float,22),
					new OracleParameter(":N_GDDXDC", OracleType.Float,22)};
        parametersDLT[0].Value = mo_dlt.N_HYDH;
        parametersDLT[1].Value = mo_dlt.N_TBHTY;
        parametersDLT[2].Value = mo_dlt.N_TTTY;
        parametersDLT[3].Value = mo_dlt.N_THTY;
        parametersDLT[4].Value = mo_dlt.N_QCPTY;
        parametersDLT[5].Value = mo_dlt.N_2XTY;
        parametersDLT[6].Value = mo_dlt.N_3XTY;
        parametersDLT[7].Value = mo_dlt.N_4XTY;
        parametersDLT[8].Value = mo_dlt.N_GDDSTY;
        parametersDLT[9].Value = mo_dlt.N_GDDXTY;
        parametersDLT[10].Value = mo_dlt.N_TBHDZ;
        parametersDLT[11].Value = mo_dlt.N_TTDZ;
        parametersDLT[12].Value = mo_dlt.N_THDZ;
        parametersDLT[13].Value = mo_dlt.N_QCPDZ;
        parametersDLT[14].Value = mo_dlt.N_2XDZ;
        parametersDLT[15].Value = mo_dlt.N_3XDZ;
        parametersDLT[16].Value = mo_dlt.N_4XDZ;
        parametersDLT[17].Value = mo_dlt.N_GDDSDZ;
        parametersDLT[18].Value = mo_dlt.N_GDDXDZ;
        parametersDLT[19].Value = mo_dlt.N_TBHDC;
        parametersDLT[20].Value = mo_dlt.N_TTDC;
        parametersDLT[21].Value = mo_dlt.N_THDC;
        parametersDLT[22].Value = mo_dlt.N_QCPDC;
        parametersDLT[23].Value = mo_dlt.N_2XDC;
        parametersDLT[24].Value = mo_dlt.N_3XDC;
        parametersDLT[25].Value = mo_dlt.N_4XDC;
        parametersDLT[26].Value = mo_dlt.N_GDDSDC;
        parametersDLT[27].Value = mo_dlt.N_GDDXDC;
        o_hsta.Add(strSql.ToString(), parametersDLT);
        #endregion
        #region"今彩539"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPJC539(");
        strSql.Append("N_HYDH,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_QCPDC,N_2XDC,N_3XDC,N_4XDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYDH,:N_QCPTY,:N_2XTY,:N_3XTY,:N_4XTY,:N_QCPDZ,:N_2XDZ,:N_3XDZ,:N_4XDZ,:N_QCPDC,:N_2XDC,:N_3XDC,:N_4XDC)");
        OracleParameter[] parametersJC539 = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_QCPTY", OracleType.Float,22),
					new OracleParameter(":N_2XTY", OracleType.Float,22),
					new OracleParameter(":N_3XTY", OracleType.Float,22),
					new OracleParameter(":N_4XTY", OracleType.Float,22),
					new OracleParameter(":N_QCPDZ", OracleType.Float,22),
					new OracleParameter(":N_2XDZ", OracleType.Float,22),
					new OracleParameter(":N_3XDZ", OracleType.Float,22),
					new OracleParameter(":N_4XDZ", OracleType.Float,22),
					new OracleParameter(":N_QCPDC", OracleType.Float,22),
					new OracleParameter(":N_2XDC", OracleType.Float,22),
					new OracleParameter(":N_3XDC", OracleType.Float,22),
					new OracleParameter(":N_4XDC", OracleType.Float,22)};
        parametersJC539[0].Value = mo_jc539.N_HYDH;
        parametersJC539[1].Value = mo_jc539.N_QCPTY;
        parametersJC539[2].Value = mo_jc539.N_2XTY;
        parametersJC539[3].Value = mo_jc539.N_3XTY;
        parametersJC539[4].Value = mo_jc539.N_4XTY;
        parametersJC539[5].Value = mo_jc539.N_QCPDZ;
        parametersJC539[6].Value = mo_jc539.N_2XDZ;
        parametersJC539[7].Value = mo_jc539.N_3XDZ;
        parametersJC539[8].Value = mo_jc539.N_4XDZ;
        parametersJC539[9].Value = mo_jc539.N_QCPDC;
        parametersJC539[10].Value = mo_jc539.N_2XDC;
        parametersJC539[11].Value = mo_jc539.N_3XDC;
        parametersJC539[12].Value = mo_jc539.N_4XDC;
        o_hsta.Add(strSql.ToString(), parametersJC539);
        #endregion
        #region"运动彩票"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPCP(");
        strSql.Append("N_HYDH,N_BQTY,N_LQTY,N_ZQTY,N_GSTY,N_QZTY,N_BQDZ,N_LQDZ,N_ZQDZ,N_GSDZ,N_QZDZ,N_BQDC,N_LQDC,N_ZQDC,N_GSDC,N_QZDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYDH,:N_BQTY,:N_LQTY,:N_ZQTY,:N_GSTY,:N_QZTY,:N_BQDZ,:N_LQDZ,:N_ZQDZ,:N_GSDZ,:N_QZDZ,:N_BQDC,:N_LQDC,:N_ZQDC,:N_GSDC,:N_QZDC)");
        OracleParameter[] parametersCP = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_BQTY", OracleType.Float,22),
					new OracleParameter(":N_LQTY", OracleType.Float,22),
					new OracleParameter(":N_ZQTY", OracleType.Float,22),
					new OracleParameter(":N_GSTY", OracleType.Float,22),
					new OracleParameter(":N_QZTY", OracleType.Float,22),
					new OracleParameter(":N_BQDZ", OracleType.Float,22),
					new OracleParameter(":N_LQDZ", OracleType.Float,22),
					new OracleParameter(":N_ZQDZ", OracleType.Float,22),
					new OracleParameter(":N_GSDZ", OracleType.Float,22),
					new OracleParameter(":N_QZDZ", OracleType.Float,22),
					new OracleParameter(":N_BQDC", OracleType.Float,22),
					new OracleParameter(":N_LQDC", OracleType.Float,22),
					new OracleParameter(":N_ZQDC", OracleType.Float,22),
					new OracleParameter(":N_GSDC", OracleType.Float,22),
					new OracleParameter(":N_QZDC", OracleType.Float,22)};
        parametersCP[0].Value = mo_cp.N_HYDH;
        parametersCP[1].Value = mo_cp.N_BQTY;
        parametersCP[2].Value = mo_cp.N_LQTY;
        parametersCP[3].Value = mo_cp.N_ZQTY;
        parametersCP[4].Value = mo_cp.N_GSTY;
        parametersCP[5].Value = mo_cp.N_QZTY;
        parametersCP[6].Value = mo_cp.N_BQDZ;
        parametersCP[7].Value = mo_cp.N_LQDZ;
        parametersCP[8].Value = mo_cp.N_ZQDZ;
        parametersCP[9].Value = mo_cp.N_GSDZ;
        parametersCP[10].Value = mo_cp.N_QZDZ;
        parametersCP[11].Value = mo_cp.N_BQDC;
        parametersCP[12].Value = mo_cp.N_LQDC;
        parametersCP[13].Value = mo_cp.N_ZQDC;
        parametersCP[14].Value = mo_cp.N_GSDC;
        parametersCP[15].Value = mo_cp.N_QZDC;
        o_hsta.Add(strSql.ToString(), parametersCP);
        #endregion
        #region"政治時事"
        strSql = new StringBuilder();
        strSql.Append("insert into KFB_SETUPSS(");
        strSql.Append("N_HYDH,N_DYTY,N_DYDZ,N_DYDC)");
        strSql.Append(" values (");
        strSql.Append(":N_HYDH,:N_DYTY,:N_DYDZ,:N_DYDC)");
        OracleParameter[] parametersSS = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22)};
        parametersSS[0].Value = mo_ss.N_HYDH;
        parametersSS[1].Value = mo_ss.N_DYTY;
        parametersSS[2].Value = mo_ss.N_DYDZ;
        parametersSS[3].Value = mo_ss.N_DYDC;
        o_hsta.Add(strSql.ToString(), parametersSS);
        #endregion

        DbHelperOra.ExecuteSqlTran(o_hsta);

    }

    public string GetGJZH(string strcName, string struseid)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("SELECT " + strcName + "  FROM kfb_zhgl");
        strSql.Append(" WHERE n_hyzh=:n_hyzh");
        OracleParameter[] parameters = {
                    new OracleParameter(":n_hyzh", OracleType.VarChar,100)
				};
        parameters[0].Value = struseid;
        DataSet GetDS = KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
        return GetDS.Tables[0].Rows[0][0].ToString();
    }
    /// <summary>
    /// 得到下级 最大拆帐
    /// </summary>
    /// <param name="s_aDLS"></param>
    /// <returns></returns>
    public KFB_ZHGL GetXJZH(string strlv, string N_HYZH)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select nvl(max(n_lqcz),0) n_lqcz ,nvl(max(n_zqcz),0)  n_zqcz,nvl(max(n_mzcz),0)  n_mzcz,nvl(max(n_mbcz),0)  n_mbcz,nvl(max(n_rbcz),0)  n_rbcz,");
        strSql.Append(" nvl(max(n_tbcz),0)  n_tbcz,nvl(max(n_zscz),0)  n_zscz,nvl(max(n_smcz),0)  n_smcz,nvl(max(n_dltcz),0)  n_dltcz,nvl(max(n_cpcz),0)  n_cpcz,");
        strSql.Append(" nvl(max(n_lhccz),0)  n_lhccz,nvl(max(n_jccz),0)  n_jccz,nvl(max(n_2xcz),0)  n_2xcz,nvl(max(n_3xcz),0)  n_3xcz,nvl(max(n_4xcz),0)  n_4xcz,");
        strSql.Append(" nvl(max(n_sscz),0)  n_sscz,nvl(max(n_bqcz),0)  n_bqcz,nvl(max(n_cqcz),0)  n_cqcz  from KFB_ZHGL ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE   n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }
        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }

        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_ZHGL model = new KFB_ZHGL();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);

        if (ds.Tables[0].Rows[0]["N_ZQCZ"].ToString() != "")
        {
            model.N_ZQCZ = int.Parse(ds.Tables[0].Rows[0]["N_ZQCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_LQCZ"].ToString() != "")
        {
            model.N_LQCZ = int.Parse(ds.Tables[0].Rows[0]["N_LQCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_MZCZ"].ToString() != "")
        {
            model.N_MZCZ = int.Parse(ds.Tables[0].Rows[0]["N_MZCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_MBCZ"].ToString() != "")
        {
            model.N_MBCZ = int.Parse(ds.Tables[0].Rows[0]["N_MBCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_RBCZ"].ToString() != "")
        {
            model.N_RBCZ = int.Parse(ds.Tables[0].Rows[0]["N_RBCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_TBCZ"].ToString() != "")
        {
            model.N_TBCZ = int.Parse(ds.Tables[0].Rows[0]["N_TBCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_ZSCZ"].ToString() != "")
        {
            model.N_ZSCZ = int.Parse(ds.Tables[0].Rows[0]["N_ZSCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_SMCZ"].ToString() != "")
        {
            model.N_SMCZ = int.Parse(ds.Tables[0].Rows[0]["N_SMCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_DLTCZ"].ToString() != "")
        {
            model.N_DLTCZ = int.Parse(ds.Tables[0].Rows[0]["N_DLTCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_CPCZ"].ToString() != "")
        {
            model.N_CPCZ = int.Parse(ds.Tables[0].Rows[0]["N_CPCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_LHCCZ"].ToString() != "")
        {
            model.N_LHCCZ = int.Parse(ds.Tables[0].Rows[0]["N_LHCCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_JCCZ"].ToString() != "")
        {
            model.N_JCCZ = int.Parse(ds.Tables[0].Rows[0]["N_JCCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_2XCZ"].ToString() != "")
        {
            model.N_2XCZ = int.Parse(ds.Tables[0].Rows[0]["N_2XCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_3XCZ"].ToString() != "")
        {
            model.N_3XCZ = int.Parse(ds.Tables[0].Rows[0]["N_3XCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_4XCZ"].ToString() != "")
        {
            model.N_4XCZ = int.Parse(ds.Tables[0].Rows[0]["N_4XCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_SSCZ"].ToString() != "")
        {
            model.N_SSCZ = int.Parse(ds.Tables[0].Rows[0]["N_SSCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_BQCZ"].ToString() != "")
        {
            model.N_BQCZ = int.Parse(ds.Tables[0].Rows[0]["N_BQCZ"].ToString());
        }
        if (ds.Tables[0].Rows[0]["N_CQCZ"].ToString() != "")
        {
            model.N_CQCZ = int.Parse(ds.Tables[0].Rows[0]["N_CQCZ"].ToString());
        }
        return model;

    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPLQ GetModelLQ(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select ");
        strSql.Append(" max(N_RFTY) N_RFTY ,    max(N_DXTY) N_DXTY,     max(N_DYTY) N_DYTY,     max(N_DSTY) N_DSTY,     max(N_ZDRFTY) N_ZDRFTY, max(N_ZDDXTY) N_ZDDXTY,");
        strSql.Append(" max(N_BCRFTY) N_BCRFTY, max(N_BCDXTY) N_BCDXTY, max(N_BCDYTY) N_BCDYTY, max(N_BCDSTY) N_BCDSTY, max(N_GGTY) N_GGTY,     max(N_GJTY) N_GJTY,");

        strSql.Append(" max(N_RFDZ) N_RFDZ,     max(N_DXDZ) N_DXDZ,     max(N_DYDZ) N_DYDZ,     max(N_DSDZ) N_DSDZ,     max(N_ZDRFDZ) N_ZDRFDZ, max(N_ZDDXDZ) N_ZDDXDZ,");
        strSql.Append(" max(N_BCRFDZ) N_BCRFDZ, max(N_BCDXDZ) N_BCDXDZ, max(N_BCDYDZ) N_BCDYDZ, max(N_BCDSDZ) N_BCDSDZ, max(N_GGDZ) N_GGDZ,     max(N_GJDZ) N_GJDZ,");

        strSql.Append(" max(N_RFDC) N_RFDC,     max(N_DXDC) N_DXDC,     max(N_DYDC) N_DYDC ,    max(N_DSDC) N_DSDC,     max(N_ZDRFDC) N_ZDRFDC, max(N_ZDDXDC) N_ZDDXDC,");
        strSql.Append(" max(N_BCRFDC) N_BCRFDC, max(N_BCDXDC) N_BCDXDC, max(N_BCDYDC) N_BCDYDC, max(N_BCDSDC) N_BCDSDC, max(N_GGDC) N_GGDC,     max(N_GJDC) N_GJDC,");

        strSql.Append(" max(N_RFDD) N_RFDD ,    max(N_DXDD) N_DXDD,     max(N_DYDD) N_DYDD,     max(N_DSDD) N_DSDD,     max(N_ZDRFDD) N_ZDRFDD, max(N_ZDDXDD) N_ZDDXDD,");
        strSql.Append(" max(N_BCRFDD) N_BCRFDD, max(N_BCDXDD) N_BCDXDD, max(N_BCDYDD) N_BCDYDD, max(N_BCDSDD) N_BCDSDD, max(N_GGDD) N_GGDD,     max(N_GJDD) N_GJDD,");

        strSql.Append("max(N_DJRFTY) N_DJRFTY, max(N_DJDXTY) N_DJDXTY, max(N_DJDSTY) N_DJDSTY, max(N_DJRFDZ) N_DJRFDZ, max(N_DJDXDZ) N_DJDXDZ, max(N_DJDSDZ) N_DJDSDZ, max(N_DJRFDC) N_DJRFDC, max(N_DJDXDC) N_DJDXDC, max(N_DJDSDC) N_DJDSDC, max(N_DJRFDD) N_DJRFDD, max(N_DJDXDD) N_DJDXDD, max(N_DJDSDD) N_DJDSDD");

        strSql.Append(" from KFB_SETUPLQ ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE   n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }

        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPLQ model = new KFB_SETUPLQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFTY"].ToString() != "")
            {
                model.N_BCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXTY"].ToString() != "")
            {
                model.N_BCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYTY"].ToString() != "")
            {
                model.N_BCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSTY"].ToString() != "")
            {
                model.N_BCDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString() != "")
            {
                model.N_BCDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDC"].ToString() != "")
            {
                model.N_BCDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDD"].ToString() != "")
            {
                model.N_RFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDD"].ToString() != "")
            {
                model.N_DXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDD"].ToString() != "")
            {
                model.N_DYDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDD"].ToString() != "")
            {
                model.N_DSDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDD"].ToString() != "")
            {
                model.N_ZDRFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDD"].ToString() != "")
            {
                model.N_ZDDXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDD"].ToString() != "")
            {
                model.N_BCRFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDD"].ToString() != "")
            {
                model.N_BCDXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDD"].ToString() != "")
            {
                model.N_BCDYDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDD"].ToString() != "")
            {
                model.N_BCDSDD = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDD"].ToString() != "")
            {
                model.N_GGDD = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDD"].ToString() != "")
            {
                model.N_GJDD = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFTY"].ToString() != "")
            {
                model.N_DJRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXTY"].ToString() != "")
            {
                model.N_DJDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSTY"].ToString() != "")
            {
                model.N_DJDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFDZ"].ToString() != "")
            {
                model.N_DJRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXDZ"].ToString() != "")
            {
                model.N_DJDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSDZ"].ToString() != "")
            {
                model.N_DJDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFDC"].ToString() != "")
            {
                model.N_DJRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXDC"].ToString() != "")
            {
                model.N_DJDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSDC"].ToString() != "")
            {
                model.N_DJDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJRFDD"].ToString() != "")
            {
                model.N_DJRFDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DJRFDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDXDD"].ToString() != "")
            {
                model.N_DJDXDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDXDD"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DJDSDD"].ToString() != "")
            {
                model.N_DJDSDD = decimal.Parse(ds.Tables[0].Rows[0]["N_DJDSDD"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPMB GetModelMB(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(N_RFTY) N_RFTY ,max(N_DXTY) N_DXTY,max(N_DYTY) N_DYTY,max(N_DSTY) N_DSTY,max(N_ZDRFTY) N_ZDRFTY, ");
        strSql.Append(" max(N_ZDDXTY) N_ZDDXTY, max(N_GGTY) N_GGTY,max(N_GJTY) N_GJTY,max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ, ");
        strSql.Append("  max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ,max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC ");
        strSql.Append("  ,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,max(N_ZDDXDC) N_ZDDXDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC , ");
        strSql.Append("  max(n_syty) n_syty, max(n_sydz) n_sydz, max(n_sydc) n_sydc from kfb_setupmb ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPMB model = new KFB_SETUPMB();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPRB GetModelRB(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(N_RFTY) N_RFTY ,max(N_DXTY) N_DXTY,max(N_DYTY) N_DYTY,max(N_DSTY) N_DSTY,max(N_ZDRFTY) N_ZDRFTY, ");
        strSql.Append(" max(N_ZDDXTY) N_ZDDXTY, max(N_GGTY) N_GGTY,max(N_GJTY) N_GJTY,max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ, ");
        strSql.Append("  max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ,max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC ");
        strSql.Append("  ,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,max(N_ZDDXDC) N_ZDDXDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC , ");
        strSql.Append("  max(n_syty) n_syty, max(n_sydz) n_sydz, max(n_sydc) n_sydc from kfb_setuprb ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPRB model = new KFB_SETUPRB();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPTB GetModelTB(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(N_RFTY) N_RFTY ,max(N_DXTY) N_DXTY,max(N_DYTY) N_DYTY,max(N_DSTY) N_DSTY,max(N_ZDRFTY) N_ZDRFTY, ");
        strSql.Append(" max(N_ZDDXTY) N_ZDDXTY, max(N_GGTY) N_GGTY,max(N_GJTY) N_GJTY,max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ, ");
        strSql.Append("  max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ,max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC ");
        strSql.Append("  ,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,max(N_ZDDXDC) N_ZDDXDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC , ");
        strSql.Append("  max(n_syty) n_syty, max(n_sydz) n_sydz, max(n_sydc) n_sydc from kfb_setuptb ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPTB model = new KFB_SETUPTB();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //    model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPZQ GetModelZQ(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select max(N_HYZH) N_HYZH,max(N_ARFTY) N_ARFTY,max(N_ADXTY) N_ADXTY,max(N_ADYTY) N_ADYTY,");
        strSql.Append(" max(N_ADSTY) N_ADSTY,max(N_AZDRFTY) N_AZDRFTY,max(N_AZDDXTY) N_AZDDXTY,max(N_ABCRFTY) N_ABCRFTY,");
        strSql.Append(" max(N_ABCDXTY) N_ABCDXTY,max(N_ABCDYTY) N_ABCDYTY,max(N_ARQSTY) N_ARQSTY,max(N_ABDTY) N_ABDTY,");
        strSql.Append(" max(N_ABQCTY) N_ABQCTY,max(N_AGGTY) N_AGGTY,max(N_AGJTY) N_AGJTY,max(N_BRFTY) N_BRFTY,max(N_BDXTY) N_BDXTY,");
        strSql.Append(" max(N_BDYTY) N_BDYTY,max(N_BDSTY) N_BDSTY,max(N_BZDRFTY) N_BZDRFTY,max(N_BZDDXTY) N_BZDDXTY,max(N_BBCRFTY) N_BBCRFTY,");
        strSql.Append(" max(N_BBCDXTY) N_BBCDXTY,max(N_BBCDYTY) N_BBCDYTY,max(N_BRQSTY) N_BRQSTY,max(N_BBDTY) N_BBDTY,max(N_BBQCTY) N_BBQCTY,");
        strSql.Append(" max(N_BGGTY) N_BGGTY,max(N_BGJTY) N_BGJTY,max(N_CRFTY) N_CRFTY,max(N_CDXTY) N_CDXTY,max(N_CDYTY) N_CDYTY,max(N_CDSTY) N_CDSTY,");
        strSql.Append(" max(N_CZDRFTY) N_CZDRFTY,max(N_CZDDXTY) N_CZDDXTY,max(N_CBCRFTY) N_CBCRFTY,max(N_CBCDXTY) N_CBCDXTY,");
        strSql.Append(" max(N_CBCDYTY) N_CBCDYTY,max(N_CRQSTY) N_CRQSTY,max(N_CBDTY) N_CBDTY,max(N_CBQCTY) N_CBQCTY,max(N_CGGTY) N_CGGTY,");
        strSql.Append(" max(N_CGJTY) N_CGJTY,max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ,");
        strSql.Append(" max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_BCRFDZ) N_BCRFDZ,max(N_BCDXDZ) N_BCDXDZ,max(N_BCDYDZ) N_BCDYDZ,");
        strSql.Append(" max(N_RQSDZ) N_RQSDZ,max(N_BDDZ) N_BDDZ,max(N_BQCDZ) N_BQCDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ,");
        strSql.Append(" max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,");
        strSql.Append(" max(N_ZDDXDC) N_ZDDXDC,max(N_BCRFDC) N_BCRFDC,max(N_BCDXDC) N_BCDXDC,max(N_BCDYDC) N_BCDYDC,max(N_RQSDC) N_RQSDC,");
        strSql.Append(" max(N_BDDC) N_BDDC,max(N_BQCDC) N_BQCDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC from KFB_SETUPZQ ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPZQ model = new KFB_SETUPZQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_ARFTY"].ToString() != "")
            {
                model.N_ARFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ARFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ADXTY"].ToString() != "")
            {
                model.N_ADXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ADXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ADYTY"].ToString() != "")
            {
                model.N_ADYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ADYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ADSTY"].ToString() != "")
            {
                model.N_ADSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ADSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AZDRFTY"].ToString() != "")
            {
                model.N_AZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AZDDXTY"].ToString() != "")
            {
                model.N_AZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABCRFTY"].ToString() != "")
            {
                model.N_ABCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABCDXTY"].ToString() != "")
            {
                model.N_ABCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABCDYTY"].ToString() != "")
            {
                model.N_ABCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ARQSTY"].ToString() != "")
            {
                model.N_ARQSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ARQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABDTY"].ToString() != "")
            {
                model.N_ABDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ABQCTY"].ToString() != "")
            {
                model.N_ABQCTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ABQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AGGTY"].ToString() != "")
            {
                model.N_AGGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_AGJTY"].ToString() != "")
            {
                model.N_AGJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_AGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BRFTY"].ToString() != "")
            {
                model.N_BRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDXTY"].ToString() != "")
            {
                model.N_BDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDYTY"].ToString() != "")
            {
                model.N_BDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDSTY"].ToString() != "")
            {
                model.N_BDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BZDRFTY"].ToString() != "")
            {
                model.N_BZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BZDDXTY"].ToString() != "")
            {
                model.N_BZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBCRFTY"].ToString() != "")
            {
                model.N_BBCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBCDXTY"].ToString() != "")
            {
                model.N_BBCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBCDYTY"].ToString() != "")
            {
                model.N_BBCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BRQSTY"].ToString() != "")
            {
                model.N_BRQSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BRQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBDTY"].ToString() != "")
            {
                model.N_BBDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BBQCTY"].ToString() != "")
            {
                model.N_BBQCTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BBQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BGGTY"].ToString() != "")
            {
                model.N_BGGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BGJTY"].ToString() != "")
            {
                model.N_BGJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CRFTY"].ToString() != "")
            {
                model.N_CRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CDXTY"].ToString() != "")
            {
                model.N_CDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CDYTY"].ToString() != "")
            {
                model.N_CDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CDSTY"].ToString() != "")
            {
                model.N_CDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CZDRFTY"].ToString() != "")
            {
                model.N_CZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CZDDXTY"].ToString() != "")
            {
                model.N_CZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBCRFTY"].ToString() != "")
            {
                model.N_CBCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBCDXTY"].ToString() != "")
            {
                model.N_CBCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBCDYTY"].ToString() != "")
            {
                model.N_CBCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CRQSTY"].ToString() != "")
            {
                model.N_CRQSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CRQSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBDTY"].ToString() != "")
            {
                model.N_CBDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBQCTY"].ToString() != "")
            {
                model.N_CBQCTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CBQCTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CGGTY"].ToString() != "")
            {
                model.N_CGGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CGGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CGJTY"].ToString() != "")
            {
                model.N_CGJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_CGJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSDZ"].ToString() != "")
            {
                model.N_RQSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDZ"].ToString() != "")
            {
                model.N_BDDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCDZ"].ToString() != "")
            {
                model.N_BQCDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RQSDC"].ToString() != "")
            {
                model.N_RQSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RQSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDC"].ToString() != "")
            {
                model.N_BDDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQCDC"].ToString() != "")
            {
                model.N_BQCDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BQCDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPMQ GetModelMQ(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select max(N_RFTY) N_RFTY ,max(N_DXTY) N_DXTY,max(N_DYTY) N_DYTY,max(N_DSTY) N_DSTY,max(N_ZDRFTY) N_ZDRFTY,");
        strSql.Append(" max(N_ZDDXTY) N_ZDDXTY,max(N_BCRFTY) N_BCRFTY,max(N_BCDXTY) N_BCDXTY,max(N_BCDYTY) N_BCDYTY,max(N_BCDSTY) N_BCDSTY,");
        strSql.Append(" max(N_GGTY) N_GGTY,max(N_GJTY) N_GJTY,max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ,");
        strSql.Append(" max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_BCRFDZ) N_BCRFDZ,max(N_BCDXDZ) N_BCDXDZ,max(N_BCDYDZ) N_BCDYDZ,");
        strSql.Append(" max(N_BCDSDZ) N_BCDSDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ,max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC");
        strSql.Append(" ,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,max(N_ZDDXDC) N_ZDDXDC,max(N_BCRFDC) N_BCRFDC,max(N_BCDXDC) N_BCDXDC,");
        strSql.Append("  max(N_BCDYDC) N_BCDYDC,max(N_BCDSDC) N_BCDSDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC from kfb_setupmq ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }

        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;
        KFB_SETUPMQ model = new KFB_SETUPMQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFTY"].ToString() != "")
            {
                model.N_BCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXTY"].ToString() != "")
            {
                model.N_BCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYTY"].ToString() != "")
            {
                model.N_BCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSTY"].ToString() != "")
            {
                model.N_BCDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString() != "")
            {
                model.N_BCDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDC"].ToString() != "")
            {
                model.N_BCDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPCQ GetModelCQ(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select max(N_RFTY) N_RFTY ,max(N_DXTY) N_DXTY,max(N_DYTY) N_DYTY,max(N_DSTY) N_DSTY,max(N_ZDRFTY) N_ZDRFTY,");
        strSql.Append(" max(N_ZDDXTY) N_ZDDXTY,max(N_BCRFTY) N_BCRFTY,max(N_BCDXTY) N_BCDXTY,max(N_BCDYTY) N_BCDYTY,max(N_BCDSTY) N_BCDSTY,");
        strSql.Append(" max(N_GGTY) N_GGTY,max(N_GJTY) N_GJTY,max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ,");
        strSql.Append(" max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_BCRFDZ) N_BCRFDZ,max(N_BCDXDZ) N_BCDXDZ,max(N_BCDYDZ) N_BCDYDZ,");
        strSql.Append(" max(N_BCDSDZ) N_BCDSDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ,max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC");
        strSql.Append(" ,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,max(N_ZDDXDC) N_ZDDXDC,max(N_BCRFDC) N_BCRFDC,max(N_BCDXDC) N_BCDXDC,");
        strSql.Append("  max(N_BCDYDC) N_BCDYDC,max(N_BCDSDC) N_BCDSDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC from kfb_setupCQ ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }

        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;
        KFB_SETUPCQ model = new KFB_SETUPCQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFTY"].ToString() != "")
            {
                model.N_BCRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXTY"].ToString() != "")
            {
                model.N_BCDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYTY"].ToString() != "")
            {
                model.N_BCDYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSTY"].ToString() != "")
            {
                model.N_BCDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString() != "")
            {
                model.N_BCRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString() != "")
            {
                model.N_BCDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString() != "")
            {
                model.N_BCDYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString() != "")
            {
                model.N_BCDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCRFDC"].ToString() != "")
            {
                model.N_BCRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDXDC"].ToString() != "")
            {
                model.N_BCDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDYDC"].ToString() != "")
            {
                model.N_BCDYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BCDSDC"].ToString() != "")
            {
                model.N_BCDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BCDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPZS GetModelZS(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(N_RFTY) N_RFTY ,max(N_DXTY) N_DXTY,max(N_DYTY) N_DYTY,max(N_DSTY) N_DSTY,max(N_ZDRFTY) N_ZDRFTY, ");
        strSql.Append(" max(N_ZDDXTY) N_ZDDXTY, max(N_GGTY) N_GGTY,max(N_GJTY) N_GJTY,max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ, ");
        strSql.Append("  max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ,max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC ");
        strSql.Append("  ,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,max(N_ZDDXDC) N_ZDDXDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC , ");
        strSql.Append("  max(n_syty) n_syty, max(n_sydz) n_sydz, max(n_sydc) n_sydc ,max(n_bddc) n_bddc, max(n_bddz) n_bddz,max(n_bdty) n_bdty from kfb_setupzs ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

       KFB_SETUPZS model = new KFB_SETUPZS();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //  model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDTY"].ToString() != "")
            {
                model.N_BDTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BDTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDZ"].ToString() != "")
            {
                model.N_BDDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BDDC"].ToString() != "")
            {
                model.N_BDDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BDDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPSM GetModelSM(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(n_dyty) n_dyty,max(n_wzty) n_wzty,");
        strSql.Append(" max(n_lyty) n_lyty,max(n_wzqty) n_wzqty,max(n_dydz) n_dydz,max(n_wzdz) n_wzdz,");
        strSql.Append(" max(n_lydz) n_lydz,max(n_wzqdz) n_wzqdz,max(n_dydc) n_dydc,max(n_wzdc) n_wzdc,");
        strSql.Append(" max(n_lydc) n_lydc,max(n_wzqdc) n_wzqdc  from  kfb_setupsm");
        strSql.Append(" where 1=1 and  n_hydh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;


        KFB_SETUPSM model = new KFB_SETUPSM();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZTY"].ToString() != "")
            {
                model.N_WZTY = decimal.Parse(ds.Tables[0].Rows[0]["N_WZTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LYTY"].ToString() != "")
            {
                model.N_LYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_LYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZQTY"].ToString() != "")
            {
                model.N_WZQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_WZQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZDZ"].ToString() != "")
            {
                model.N_WZDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_WZDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LYDZ"].ToString() != "")
            {
                model.N_LYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_LYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZQDZ"].ToString() != "")
            {
                model.N_WZQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_WZQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZDC"].ToString() != "")
            {
                model.N_WZDC = decimal.Parse(ds.Tables[0].Rows[0]["N_WZDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LYDC"].ToString() != "")
            {
                model.N_LYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_LYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_WZQDC"].ToString() != "")
            {
                model.N_WZQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_WZQDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }

    public KFB_SETUPBQ GetModelBQ(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(N_RFTY) N_RFTY,max(N_DXTY) N_DXTY,max(N_DYTY) N_DYTY,max(N_DSTY) N_DSTY,max(N_ZDRFTY) N_ZDRFTY,max(N_ZDDXTY) N_ZDDXTY,max(N_SYTY) N_SYTY,max(N_GGTY) N_GGTY,max(N_GJTY) N_GJTY, ");
        strSql.Append("        max(N_RFDZ) N_RFDZ,max(N_DXDZ) N_DXDZ,max(N_DYDZ) N_DYDZ,max(N_DSDZ) N_DSDZ,max(N_ZDRFDZ) N_ZDRFDZ,max(N_ZDDXDZ) N_ZDDXDZ,max(N_SYDZ) N_SYDZ,max(N_GGDZ) N_GGDZ,max(N_GJDZ) N_GJDZ, ");
        strSql.Append("        max(N_RFDC) N_RFDC,max(N_DXDC) N_DXDC,max(N_DYDC) N_DYDC,max(N_DSDC) N_DSDC,max(N_ZDRFDC) N_ZDRFDC,max(N_ZDDXDC) N_ZDDXDC,max(N_SYDC) N_SYDC,max(N_GGDC) N_GGDC,max(N_GJDC) N_GJDC ");
        //strSql.Append("        max(N_RFDD) N_RFDD,max(N_DXDD) N_DXDD,max(N_DYDD) N_DYDD,max(N_DSDD) N_DSDD,max(N_ZDRFDD) N_ZDRFDD,max(N_ZDDXDD) N_ZDDXDD,max(N_SYDD) N_SYDD,max(N_GGDD) N_GGDD,max(N_GJDD) N_GJDD  ");
        strSql.Append(" from kfb_setupbq ");
        strSql.Append(" where 1=1 and  n_hyzh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPBQ model = new KFB_SETUPBQ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
            if (ds.Tables[0].Rows[0]["N_RFTY"].ToString() != "")
            {
                model.N_RFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_RFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXTY"].ToString() != "")
            {
                model.N_DXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSTY"].ToString() != "")
            {
                model.N_DSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString() != "")
            {
                model.N_ZDRFTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString() != "")
            {
                model.N_ZDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYTY"].ToString() != "")
            {
                model.N_SYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_SYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGTY"].ToString() != "")
            {
                model.N_GGTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GGTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJTY"].ToString() != "")
            {
                model.N_GJTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GJTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDZ"].ToString() != "")
            {
                model.N_RFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDZ"].ToString() != "")
            {
                model.N_DXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDZ"].ToString() != "")
            {
                model.N_DSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString() != "")
            {
                model.N_ZDRFDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString() != "")
            {
                model.N_ZDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDZ"].ToString() != "")
            {
                model.N_SYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDZ"].ToString() != "")
            {
                model.N_GGDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDZ"].ToString() != "")
            {
                model.N_GJDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_RFDC"].ToString() != "")
            {
                model.N_RFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_RFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DXDC"].ToString() != "")
            {
                model.N_DXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DSDC"].ToString() != "")
            {
                model.N_DSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString() != "")
            {
                model.N_ZDRFDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDRFDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString() != "")
            {
                model.N_ZDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZDDXDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_SYDC"].ToString() != "")
            {
                model.N_SYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_SYDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GGDC"].ToString() != "")
            {
                model.N_GGDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GGDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GJDC"].ToString() != "")
            {
                model.N_GJDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GJDC"].ToString());
            }

            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPLHC GetModelLHC(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select  max(N_TBHTY) N_TBHTY,max(N_TTTY) N_TTTY,max(N_THTY) N_THTY,max(N_QCPTY) N_QCPTY ,");
        strSql.Append(" max(N_2XTY) N_2XTY,max(N_3XTY) N_3XTY,max(N_4XTY) N_4XTY,max(N_GDDSTY) N_GDDSTY,max(N_GDDXTY) N_GDDXTY,");
        strSql.Append(" max(N_TBHDZ) N_TBHDZ,max(N_TTDZ) N_TTDZ,max(N_THDZ) N_THDZ,max(N_QCPDZ) N_QCPDZ,max(N_2XDZ) N_2XDZ,");
        strSql.Append(" max(N_3XDZ) N_3XDZ,max(N_4XDZ) N_4XDZ,max(N_GDDSDZ) N_GDDSDZ,max(N_GDDXDZ) N_GDDXDZ,max(N_TBHDC) N_TBHDC,");
        strSql.Append(" max(N_TTDC) N_TTDC,max(N_THDC) N_THDC,max(N_QCPDC) N_QCPDC,max(N_2XDC) N_2XDC,max(N_3XDC) N_3XDC,");
        strSql.Append(" max(N_4XDC) N_4XDC,max(N_GDDSDC) N_GDDSDC,max(N_GDDXDC) N_GDDXDC from KFB_SETUPLHC ");
        strSql.Append(" where 1=1 and  n_hydh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;
        KFB_SETUPLHC model = new KFB_SETUPLHC();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //    model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_TBHTY"].ToString() != "")
            {
                model.N_TBHTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTTY"].ToString() != "")
            {
                model.N_TTTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TTTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THTY"].ToString() != "")
            {
                model.N_THTY = decimal.Parse(ds.Tables[0].Rows[0]["N_THTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPTY"].ToString() != "")
            {
                model.N_QCPTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XTY"].ToString() != "")
            {
                model.N_2XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_2XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XTY"].ToString() != "")
            {
                model.N_3XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_3XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XTY"].ToString() != "")
            {
                model.N_4XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_4XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSTY"].ToString() != "")
            {
                model.N_GDDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXTY"].ToString() != "")
            {
                model.N_GDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDZ"].ToString() != "")
            {
                model.N_TBHDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDZ"].ToString() != "")
            {
                model.N_TTDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDZ"].ToString() != "")
            {
                model.N_THDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_THDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDZ"].ToString() != "")
            {
                model.N_QCPDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDZ"].ToString() != "")
            {
                model.N_2XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDZ"].ToString() != "")
            {
                model.N_3XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDZ"].ToString() != "")
            {
                model.N_4XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString() != "")
            {
                model.N_GDDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString() != "")
            {
                model.N_GDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDC"].ToString() != "")
            {
                model.N_TBHDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDC"].ToString() != "")
            {
                model.N_TTDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDC"].ToString() != "")
            {
                model.N_THDC = decimal.Parse(ds.Tables[0].Rows[0]["N_THDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDC"].ToString() != "")
            {
                model.N_QCPDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDC"].ToString() != "")
            {
                model.N_2XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDC"].ToString() != "")
            {
                model.N_3XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDC"].ToString() != "")
            {
                model.N_4XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDC"].ToString() != "")
            {
                model.N_GDDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDC"].ToString() != "")
            {
                model.N_GDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPDLT GetModelDLT(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select  max(N_TBHTY) N_TBHTY,max(N_TTTY) N_TTTY,max(N_THTY) N_THTY,max(N_QCPTY) N_QCPTY ,");
        strSql.Append(" max(N_2XTY) N_2XTY,max(N_3XTY) N_3XTY,max(N_4XTY) N_4XTY,max(N_GDDSTY) N_GDDSTY,max(N_GDDXTY) N_GDDXTY,");
        strSql.Append(" max(N_TBHDZ) N_TBHDZ,max(N_TTDZ) N_TTDZ,max(N_THDZ) N_THDZ,max(N_QCPDZ) N_QCPDZ,max(N_2XDZ) N_2XDZ,");
        strSql.Append(" max(N_3XDZ) N_3XDZ,max(N_4XDZ) N_4XDZ,max(N_GDDSDZ) N_GDDSDZ,max(N_GDDXDZ) N_GDDXDZ,max(N_TBHDC) N_TBHDC,");
        strSql.Append(" max(N_TTDC) N_TTDC,max(N_THDC) N_THDC,max(N_QCPDC) N_QCPDC,max(N_2XDC) N_2XDC,max(N_3XDC) N_3XDC,");
        strSql.Append(" max(N_4XDC) N_4XDC,max(N_GDDSDC) N_GDDSDC,max(N_GDDXDC) N_GDDXDC from kfb_setupdlt ");
        strSql.Append(" where 1=1 and  n_hydh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;
        KFB_SETUPDLT model = new KFB_SETUPDLT();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //  model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_TBHTY"].ToString() != "")
            {
                model.N_TBHTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTTY"].ToString() != "")
            {
                model.N_TTTY = decimal.Parse(ds.Tables[0].Rows[0]["N_TTTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THTY"].ToString() != "")
            {
                model.N_THTY = decimal.Parse(ds.Tables[0].Rows[0]["N_THTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPTY"].ToString() != "")
            {
                model.N_QCPTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XTY"].ToString() != "")
            {
                model.N_2XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_2XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XTY"].ToString() != "")
            {
                model.N_3XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_3XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XTY"].ToString() != "")
            {
                model.N_4XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_4XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSTY"].ToString() != "")
            {
                model.N_GDDSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXTY"].ToString() != "")
            {
                model.N_GDDXTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDZ"].ToString() != "")
            {
                model.N_TBHDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDZ"].ToString() != "")
            {
                model.N_TTDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDZ"].ToString() != "")
            {
                model.N_THDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_THDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDZ"].ToString() != "")
            {
                model.N_QCPDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDZ"].ToString() != "")
            {
                model.N_2XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDZ"].ToString() != "")
            {
                model.N_3XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDZ"].ToString() != "")
            {
                model.N_4XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString() != "")
            {
                model.N_GDDSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString() != "")
            {
                model.N_GDDXDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TBHDC"].ToString() != "")
            {
                model.N_TBHDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TBHDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_TTDC"].ToString() != "")
            {
                model.N_TTDC = decimal.Parse(ds.Tables[0].Rows[0]["N_TTDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_THDC"].ToString() != "")
            {
                model.N_THDC = decimal.Parse(ds.Tables[0].Rows[0]["N_THDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDC"].ToString() != "")
            {
                model.N_QCPDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDC"].ToString() != "")
            {
                model.N_2XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDC"].ToString() != "")
            {
                model.N_3XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDC"].ToString() != "")
            {
                model.N_4XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDSDC"].ToString() != "")
            {
                model.N_GDDSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GDDXDC"].ToString() != "")
            {
                model.N_GDDXDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GDDXDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPJC539 GetModelJC539(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(N_QCPTY) N_QCPTY , max(N_2XTY) N_2XTY,max(N_3XTY) N_3XTY,max(N_4XTY) N_4XTY,");
        strSql.Append(" max(N_QCPDZ) N_QCPDZ,max(N_2XDZ) N_2XDZ,max(N_3XDZ) N_3XDZ,max(N_4XDZ) N_4XDZ,");
        strSql.Append(" max(N_QCPDC) N_QCPDC,max(N_2XDC) N_2XDC,max(N_3XDC) N_3XDC,max(N_4XDC) N_4XDC from kfb_setupjc539");
        strSql.Append(" where 1=1 and  n_hydh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPJC539 model = new KFB_SETUPJC539();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_QCPTY"].ToString() != "")
            {
                model.N_QCPTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XTY"].ToString() != "")
            {
                model.N_2XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_2XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XTY"].ToString() != "")
            {
                model.N_3XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_3XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XTY"].ToString() != "")
            {
                model.N_4XTY = decimal.Parse(ds.Tables[0].Rows[0]["N_4XTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDZ"].ToString() != "")
            {
                model.N_QCPDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDZ"].ToString() != "")
            {
                model.N_2XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDZ"].ToString() != "")
            {
                model.N_3XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDZ"].ToString() != "")
            {
                model.N_4XDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QCPDC"].ToString() != "")
            {
                model.N_QCPDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QCPDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_2XDC"].ToString() != "")
            {
                model.N_2XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_2XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_3XDC"].ToString() != "")
            {
                model.N_3XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_3XDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_4XDC"].ToString() != "")
            {
                model.N_4XDC = decimal.Parse(ds.Tables[0].Rows[0]["N_4XDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPCP GetModelCP(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(N_BQTY) N_BQTY,max(N_LQTY) N_LQTY,max(N_ZQTY) N_ZQTY,max(N_GSTY) N_GSTY,max(N_QZTY) N_QZTY,");
        strSql.Append(" max(N_BQDZ) N_BQDZ,max(N_LQDZ) N_LQDZ,max(N_ZQDZ) N_ZQDZ,max(N_GSDZ) N_GSDZ,max(N_QZDZ) N_QZDZ,");
        strSql.Append(" max(N_BQDC) N_BQDC,max(N_LQDC) N_LQDC,max(N_ZQDC) N_ZQDC,max(N_GSDC) N_GSDC,max(N_QZDC) N_QZDC  from KFB_SETUPCP ");
        strSql.Append(" where 1=1 and  n_hydh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }

        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;

        KFB_SETUPCP model = new KFB_SETUPCP();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //  model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_BQTY"].ToString() != "")
            {
                model.N_BQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_BQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQTY"].ToString() != "")
            {
                model.N_LQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_LQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQTY"].ToString() != "")
            {
                model.N_ZQTY = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GSTY"].ToString() != "")
            {
                model.N_GSTY = decimal.Parse(ds.Tables[0].Rows[0]["N_GSTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QZTY"].ToString() != "")
            {
                model.N_QZTY = decimal.Parse(ds.Tables[0].Rows[0]["N_QZTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDZ"].ToString() != "")
            {
                model.N_BQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_BQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDZ"].ToString() != "")
            {
                model.N_LQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_LQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDZ"].ToString() != "")
            {
                model.N_ZQDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GSDZ"].ToString() != "")
            {
                model.N_GSDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_GSDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QZDZ"].ToString() != "")
            {
                model.N_QZDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_QZDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BQDC"].ToString() != "")
            {
                model.N_BQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_BQDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LQDC"].ToString() != "")
            {
                model.N_LQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_LQDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_ZQDC"].ToString() != "")
            {
                model.N_ZQDC = decimal.Parse(ds.Tables[0].Rows[0]["N_ZQDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_GSDC"].ToString() != "")
            {
                model.N_GSDC = decimal.Parse(ds.Tables[0].Rows[0]["N_GSDC"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_QZDC"].ToString() != "")
            {
                model.N_QZDC = decimal.Parse(ds.Tables[0].Rows[0]["N_QZDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_SETUPSS GetModelSS(string strlv, string N_HYZH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append(" select max(n_dyty) n_dyty,");
        strSql.Append(" max(n_dydz) n_dydz,");
        strSql.Append(" max(n_dydc) n_dydc ");
        strSql.Append(" from  kfb_setupss");
        strSql.Append(" where 1=1 and  n_hydh IN (");
        if (!strlv.Equals("9"))
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_zhgl WHERE  n_hyzh!=:N_HYZH AND  ");
        }
        else
        {
            strSql.Append(" SELECT n_hyzh FROM kfb_hygl WHERE  ");
        }

        if (strlv.Equals("4"))
        {
            strSql.Append(" n_dzjdh=:N_HYZH )");
        }
        else if (strlv.Equals("5"))
        {
            strSql.Append(" n_zjdh=:N_HYZH )");
        }
        else if (strlv.Equals("6"))
        {
            strSql.Append(" n_dgddh=:N_HYZH )");
        }
        else if (strlv.Equals("7"))
        {
            strSql.Append(" n_gddh=:N_HYZH )");
        }
        else if (strlv.Equals("8"))
        {
            strSql.Append(" n_zdldh=:N_HYZH )");
        }
        else if (strlv.Equals("9"))
        {
            strSql.Append(" n_dldh=:N_HYZH )");
        }


        OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)                            
            };
        parameters[0].Value = N_HYZH;


        KFB_SETUPSS model = new KFB_SETUPSS();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // model.N_HYDH = ds.Tables[0].Rows[0]["N_HYDH"].ToString();
            if (ds.Tables[0].Rows[0]["N_DYTY"].ToString() != "")
            {
                model.N_DYTY = decimal.Parse(ds.Tables[0].Rows[0]["N_DYTY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDZ"].ToString() != "")
            {
                model.N_DYDZ = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDZ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_DYDC"].ToString() != "")
            {
                model.N_DYDC = decimal.Parse(ds.Tables[0].Rows[0]["N_DYDC"].ToString());
            }
            return model;
        }
        else
        {
            return null;
        }
    }
    public string GetLeast(string s_Table, string s_LeastType, string s_Col, string s_Where)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select " + s_LeastType + "(" + s_Col + ") from " + s_Table + s_Where);
        return Convert.ToString(KingOfBall.DbHelperOra.GetSingle(strSql.ToString()));
    }

}
