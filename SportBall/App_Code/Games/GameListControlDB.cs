#region history

#endregion

#region using
using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;
#endregion

public class GameListControlDB
{
    #region  總的成员方法
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int N_TYPE)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from KFB_BBKG");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4)};
        parameters[0].Value = N_TYPE;

        return DbHelperOra.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_BD,N_X_DX,N_X_DS,N_X_BD,N_Z_DX,N_D_DX,N_D_DS,N_D_BD,N_J_DX,N_J_DS,N_Z_DS,N_S_DX,N_S_DS,N_S_BD,N_BJGPDXCJ,N_BJGPDSCJ)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_BD,:N_X_DX,:N_X_DS,:N_X_BD,:N_Z_DX,:N_D_DX,:N_D_DS,:N_D_BD,:N_J_DX,:N_J_DS,:N_Z_DS,:N_S_DX,:N_S_DS,:N_S_BD,:N_BJGPDXCJ,:N_BJGPDSCJ)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_BD", OracleType.Number,4),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_X_BD", OracleType.Float,22),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DS",  OracleType.Float,22),
					new OracleParameter(":N_D_BD", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
                    new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_S_BD", OracleType.Float,22),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_BD;
        parameters[2].Value = model.N_X_DX;
        parameters[3].Value = model.N_X_DS;
        parameters[4].Value = model.N_X_BD;
        parameters[5].Value = model.N_Z_DX;
        parameters[6].Value = model.N_D_DX;
        parameters[7].Value = model.N_D_DS;
        parameters[8].Value = model.N_D_BD;
        parameters[9].Value = model.N_J_DX;
        parameters[10].Value = model.N_J_DS;
        parameters[11].Value = model.N_Z_DS;
        parameters[12].Value = model.N_S_DX;
        parameters[13].Value = model.N_S_DS;
        parameters[14].Value = model.N_S_BD;
        parameters[15].Value = model.N_BJGPDXCJ;
        parameters[16].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_BD=:N_Z_BD,");
        strSql.Append("N_X_DX=:N_X_DX,");
        strSql.Append("N_X_DS=:N_X_DS,");
        strSql.Append("N_X_BD=:N_X_BD,");
        strSql.Append("N_Z_DX=:N_Z_DX,");
        strSql.Append("N_D_DX=:N_D_DX,");
        strSql.Append("N_D_DS=:N_D_DS,");
        strSql.Append("N_D_BD=:N_D_BD,");
        strSql.Append("N_J_DX=:N_J_DX,");
        strSql.Append("N_J_DS=:N_J_DS,");
        strSql.Append("N_Z_DS=:N_Z_DS,");
        strSql.Append("N_S_DX=:N_S_DX,");
        strSql.Append("N_S_DS=:N_S_DS,");
        strSql.Append("N_S_BD=:N_S_BD,");
        strSql.Append("N_BJGPDXCJ=:N_BJGPDXCJ,");
        strSql.Append("N_BJGPDSCJ=:N_BJGPDSCJ");
        strSql.Append(" where N_TYPE=:N_TYPE");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_BD", OracleType.Number,4),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_X_BD", OracleType.Float,22),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DS", OracleType.Float,22),
					new OracleParameter(":N_D_BD", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
                    new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_S_BD", OracleType.Float,22),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_BD;
        parameters[2].Value = model.N_X_DX;
        parameters[3].Value = model.N_X_DS;
        parameters[4].Value = model.N_X_BD;
        parameters[5].Value = model.N_Z_DX;
        parameters[6].Value = model.N_D_DX;
        parameters[7].Value = model.N_D_DS;
        parameters[8].Value = model.N_D_BD;
        parameters[9].Value = model.N_J_DX;
        parameters[10].Value = model.N_J_DS;
        parameters[11].Value = model.N_Z_DS;
        parameters[12].Value = model.N_S_DX;
        parameters[13].Value = model.N_S_DS;
        parameters[14].Value = model.N_S_BD;
        parameters[15].Value = model.N_BJGPDXCJ;
        parameters[16].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZQ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_RF,N_Z_DX,N_Z_DY,N_Z_DS,N_Z_ZDRF,N_Z_ZDDX,N_Z_RQS,N_Z_BD,N_Z_BQC,N_Z_GG,N_Z_GJ,N_Z_JZF,N_X_RF,N_X_DX,N_X_DY,N_X_DS,N_X_ZDRF,N_X_ZDDX,N_X_BCRF,N_X_BCDX,N_X_BCDY,N_X_RQS,N_X_BD,N_X_BQC,N_X_GG,N_X_GJ,N_D_RF,N_D_DX,N_D_DY,N_D_DS,N_D_ZDRF,N_D_ZDDX,N_D_BCRF,N_D_BCDX,N_D_BCDY,N_D_RQS,N_D_BD,N_D_BQC,N_D_GG,N_D_GJ,N_J_RF,N_J_DX,N_J_DY,N_J_DS,N_J_ZDRF,N_J_ZDDX,N_J_SBCRF,N_J_SBCDX,N_J_SBCDY,N_J_GG,N_J_GJ,N_S_RF,N_S_DX,N_S_DY,N_S_DS,N_S_ZDRF,N_S_ZDDX,N_S_BCRF,N_S_BCDX,N_S_BCDY,N_S_RQS,N_S_BD,N_S_BQC,N_S_GG,N_S_GJ,N_BJGPRFCJ,N_BJGPDXCJ,N_BJGPDSCJ)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_RF,:N_Z_DX,:N_Z_DY,:N_Z_DS,:N_Z_ZDRF,:N_Z_ZDDX,:N_Z_RQS,:N_Z_BD,:N_Z_BQC,:N_Z_GG,:N_Z_GJ,:N_Z_JZF,:N_X_RF,:N_X_DX,:N_X_DY,:N_X_DS,:N_X_ZDRF,:N_X_ZDDX,:N_X_BCRF,:N_X_BCDX,:N_X_BCDY,:N_X_RQS,:N_X_BD,:N_X_BQC,:N_X_GG,:N_X_GJ,:N_D_RF,:N_D_DX,:N_D_DY,:N_D_DS,:N_D_ZDRF,:N_D_ZDDX,:N_D_BCRF,:N_D_BCDX,:N_D_BCDY,:N_D_RQS,:N_D_BD,:N_D_BQC,:N_D_GG,:N_D_GJ,:N_J_RF,:N_J_DX,:N_J_DY,:N_J_DS,:N_J_ZDRF,:N_J_ZDDX,:N_J_SBCRF,:N_J_SBCDX,:N_J_SBCDY,:N_J_GG,:N_J_GJ,:N_S_RF,:N_S_DX,:N_S_DY,:N_S_DS,:N_S_ZDRF,:N_S_ZDDX,:N_S_BCRF,:N_S_BCDX,:N_S_BCDY,:N_S_RQS,:N_S_BD,:N_S_BQC,:N_S_GG,:N_S_GJ,:N_BJGPRFCJ,:N_BJGPDXCJ,:N_BJGPDSCJ)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_RF", OracleType.Number,4),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_Z_DY", OracleType.Number,4),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDRF", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDDX", OracleType.Number,4),
					new OracleParameter(":N_Z_RQS", OracleType.Number,4),
					new OracleParameter(":N_Z_BD", OracleType.Number,4),
					new OracleParameter(":N_Z_BQC", OracleType.Number,4),
					new OracleParameter(":N_Z_GG", OracleType.Number,4),
					new OracleParameter(":N_Z_GJ", OracleType.Number,4),
					new OracleParameter(":N_Z_JZF", OracleType.Number,4),
					new OracleParameter(":N_X_RF", OracleType.Float,22),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_X_DY", OracleType.Float,22),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_X_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_X_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_X_RQS", OracleType.Float,22),
					new OracleParameter(":N_X_BD", OracleType.Float,22),
					new OracleParameter(":N_X_BQC", OracleType.Float,22),
					new OracleParameter(":N_X_GG", OracleType.Float,22),
					new OracleParameter(":N_X_GJ", OracleType.Float,22),
					new OracleParameter(":N_D_RF", OracleType.Float,22),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DY", OracleType.Float,22),
					new OracleParameter(":N_D_DS", OracleType.Float,22),
					new OracleParameter(":N_D_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_D_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_RQS", OracleType.Float,22),
					new OracleParameter(":N_D_BD", OracleType.Float,22),
					new OracleParameter(":N_D_BQC", OracleType.Float,22),
					new OracleParameter(":N_D_GG", OracleType.Float,22),
					new OracleParameter(":N_D_GJ", OracleType.Float,22),
					new OracleParameter(":N_J_RF", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22),
					//new OracleParameter(":N_J_YSEY", OracleType.Float,22),
					new OracleParameter(":N_J_GG", OracleType.Float,22),
					new OracleParameter(":N_J_GJ", OracleType.Float,22),
                    new OracleParameter(":N_S_RF", OracleType.Float,22),
					new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_S_DY", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_S_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_S_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_RQS", OracleType.Float,22),
					new OracleParameter(":N_S_BD", OracleType.Float,22),
					new OracleParameter(":N_S_BQC", OracleType.Float,22),
					new OracleParameter(":N_S_GG", OracleType.Float,22),
					new OracleParameter(":N_S_GJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPRFCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_RF;
        parameters[2].Value = model.N_Z_DX;
        parameters[3].Value = model.N_Z_DY;
        parameters[4].Value = model.N_Z_DS;
        parameters[5].Value = model.N_Z_ZDRF;
        parameters[6].Value = model.N_Z_ZDDX;
        parameters[7].Value = model.N_Z_RQS;
        parameters[8].Value = model.N_Z_BD;
        parameters[9].Value = model.N_Z_BQC;
        parameters[10].Value = model.N_Z_GG;
        parameters[11].Value = model.N_Z_GJ;
        parameters[12].Value = model.N_Z_JZF;
        parameters[13].Value = model.N_X_RF;
        parameters[14].Value = model.N_X_DX;
        parameters[15].Value = model.N_X_DY;
        parameters[16].Value = model.N_X_DS;
        parameters[17].Value = model.N_X_ZDRF;
        parameters[18].Value = model.N_X_ZDDX;
        parameters[19].Value = model.N_X_BCRF;
        parameters[20].Value = model.N_X_BCDX;
        parameters[21].Value = model.N_X_BCDY;
        parameters[22].Value = model.N_X_RQS;
        parameters[23].Value = model.N_X_BD;
        parameters[24].Value = model.N_X_BQC;
        parameters[25].Value = model.N_X_GG;
        parameters[26].Value = model.N_X_GJ;
        parameters[27].Value = model.N_D_RF;
        parameters[28].Value = model.N_D_DX;
        parameters[29].Value = model.N_D_DY;
        parameters[30].Value = model.N_D_DS;
        parameters[31].Value = model.N_D_ZDRF;
        parameters[32].Value = model.N_D_ZDDX;
        parameters[33].Value = model.N_D_BCRF;
        parameters[34].Value = model.N_D_BCDX;
        parameters[35].Value = model.N_D_BCDY;
        parameters[36].Value = model.N_D_RQS;
        parameters[37].Value = model.N_D_BD;
        parameters[38].Value = model.N_D_BQC;
        parameters[39].Value = model.N_D_GG;
        parameters[40].Value = model.N_D_GJ;
        parameters[41].Value = model.N_J_RF;
        parameters[42].Value = model.N_J_DX;
        parameters[43].Value = model.N_J_DY;
        parameters[44].Value = model.N_J_DS;
        parameters[45].Value = model.N_J_ZDRF;
        parameters[46].Value = model.N_J_ZDDX;
        parameters[47].Value = model.N_J_SBCRF;
        parameters[48].Value = model.N_J_SBCDX;
        parameters[49].Value = model.N_J_SBCDY;
        //parameters[53].Value = model.N_J_YSEY;
        parameters[50].Value = model.N_J_GG;
        parameters[51].Value = model.N_J_GJ;
        parameters[52].Value = model.N_S_RF;
        parameters[53].Value = model.N_S_DX;
        parameters[54].Value = model.N_S_DY;
        parameters[55].Value = model.N_S_DS;
        parameters[56].Value = model.N_S_ZDRF;
        parameters[57].Value = model.N_S_ZDDX;
        parameters[58].Value = model.N_S_BCRF;
        parameters[59].Value = model.N_S_BCDX;
        parameters[60].Value = model.N_S_BCDY;
        parameters[61].Value = model.N_S_RQS;
        parameters[62].Value = model.N_S_BD;
        parameters[63].Value = model.N_S_BQC;
        parameters[64].Value = model.N_S_GG;
        parameters[65].Value = model.N_S_GJ;
        parameters[66].Value = model.N_BJGPRFCJ;
        parameters[67].Value = model.N_BJGPDXCJ;
        parameters[68].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZQ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_RF=:N_Z_RF,");
        strSql.Append("N_Z_DX=:N_Z_DX,");
        strSql.Append("N_Z_DY=:N_Z_DY,");
        strSql.Append("N_Z_DS=:N_Z_DS,");
        strSql.Append("N_Z_ZDRF=:N_Z_ZDRF,");
        strSql.Append("N_Z_ZDDX=:N_Z_ZDDX,");
        strSql.Append("N_Z_RQS=:N_Z_RQS,");
        strSql.Append("N_Z_BD=:N_Z_BD,");
        strSql.Append("N_Z_BQC=:N_Z_BQC,");
        strSql.Append("N_Z_GG=:N_Z_GG,");
        strSql.Append("N_Z_GJ=:N_Z_GJ,");
        strSql.Append("N_Z_JZF=:N_Z_JZF,");
        strSql.Append("N_X_RF=:N_X_RF,");
        strSql.Append("N_X_DX=:N_X_DX,");
        strSql.Append("N_X_DY=:N_X_DY,");
        strSql.Append("N_X_DS=:N_X_DS,");
        strSql.Append("N_X_ZDRF=:N_X_ZDRF,");
        strSql.Append("N_X_ZDDX=:N_X_ZDDX,");
        strSql.Append("N_X_BCRF=:N_X_BCRF,");
        strSql.Append("N_X_BCDX=:N_X_BCDX,");
        strSql.Append("N_X_BCDY=:N_X_BCDY,");
        strSql.Append("N_X_RQS=:N_X_RQS,");
        strSql.Append("N_X_BD=:N_X_BD,");
        strSql.Append("N_X_BQC=:N_X_BQC,");
        strSql.Append("N_X_GG=:N_X_GG,");
        strSql.Append("N_X_GJ=:N_X_GJ,");
        strSql.Append("N_D_RF=:N_D_RF,");
        strSql.Append("N_D_DX=:N_D_DX,");
        strSql.Append("N_D_DY=:N_D_DY,");
        strSql.Append("N_D_DS=:N_D_DS,");
        strSql.Append("N_D_ZDRF=:N_D_ZDRF,");
        strSql.Append("N_D_ZDDX=:N_D_ZDDX,");
        strSql.Append("N_D_BCRF=:N_D_BCRF,");
        strSql.Append("N_D_BCDX=:N_D_BCDX,");
        strSql.Append("N_D_BCDY=:N_D_BCDY,");
        strSql.Append("N_D_RQS=:N_D_RQS,");
        strSql.Append("N_D_BD=:N_D_BD,");
        strSql.Append("N_D_BQC=:N_D_BQC,");
        strSql.Append("N_D_GG=:N_D_GG,");
        strSql.Append("N_D_GJ=:N_D_GJ,");
        strSql.Append("N_J_RF=:N_J_RF,");
        strSql.Append("N_J_DX=:N_J_DX,");
        strSql.Append("N_J_DY=:N_J_DY,");
        strSql.Append("N_J_DS=:N_J_DS,");
        strSql.Append("N_J_ZDRF=:N_J_ZDRF,");
        strSql.Append("N_J_ZDDX=:N_J_ZDDX,");
        strSql.Append("N_J_SBCRF=:N_J_SBCRF,");
        strSql.Append("N_J_SBCDX=:N_J_SBCDX,");
        strSql.Append("N_J_SBCDY=:N_J_SBCDY,");
        //strSql.Append("N_J_YSEY=:N_J_YSEY,");
        strSql.Append("N_J_GG=:N_J_GG,");
        strSql.Append("N_J_GJ=:N_J_GJ,");
        strSql.Append("N_S_RF=:N_S_RF,");
        strSql.Append("N_S_DX=:N_S_DX,");
        strSql.Append("N_S_DY=:N_S_DY,");
        strSql.Append("N_S_DS=:N_S_DS,");
        strSql.Append("N_S_ZDRF=:N_S_ZDRF,");
        strSql.Append("N_S_ZDDX=:N_S_ZDDX,");
        strSql.Append("N_S_BCRF=:N_S_BCRF,");
        strSql.Append("N_S_BCDX=:N_S_BCDX,");
        strSql.Append("N_S_BCDY=:N_S_BCDY,");
        strSql.Append("N_S_RQS=:N_S_RQS,");
        strSql.Append("N_S_BD=:N_S_BD,");
        strSql.Append("N_S_BQC=:N_S_BQC,");
        strSql.Append("N_S_GG=:N_S_GG,");
        strSql.Append("N_S_GJ=:N_S_GJ,");
        strSql.Append("N_BJGPRFCJ=:N_BJGPRFCJ,");
        strSql.Append("N_BJGPDXCJ=:N_BJGPDXCJ,");
        strSql.Append("N_BJGPDSCJ=:N_BJGPDSCJ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_RF", OracleType.Number,4),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_Z_DY", OracleType.Number,4),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDRF", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDDX", OracleType.Number,4),
					new OracleParameter(":N_Z_RQS", OracleType.Number,4),
					new OracleParameter(":N_Z_BD", OracleType.Number,4),
					new OracleParameter(":N_Z_BQC", OracleType.Number,4),
					new OracleParameter(":N_Z_GG", OracleType.Number,4),
					new OracleParameter(":N_Z_GJ", OracleType.Number,4),
					new OracleParameter(":N_Z_JZF", OracleType.Number,4),
					new OracleParameter(":N_X_RF", OracleType.Float,22),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_X_DY", OracleType.Float,22),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_X_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_X_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_X_RQS", OracleType.Float,22),
					new OracleParameter(":N_X_BD", OracleType.Float,22),
					new OracleParameter(":N_X_BQC", OracleType.Float,22),
					new OracleParameter(":N_X_GG", OracleType.Float,22),
					new OracleParameter(":N_X_GJ", OracleType.Float,22),
					new OracleParameter(":N_D_RF", OracleType.Float,22),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DY", OracleType.Float,22),
					new OracleParameter(":N_D_DS", OracleType.Float,22),
					new OracleParameter(":N_D_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_D_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_RQS", OracleType.Float,22),
					new OracleParameter(":N_D_BD", OracleType.Float,22),
					new OracleParameter(":N_D_BQC", OracleType.Float,22),
					new OracleParameter(":N_D_GG", OracleType.Float,22),
					new OracleParameter(":N_D_GJ", OracleType.Float,22),
					new OracleParameter(":N_J_RF", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22),
					//new OracleParameter(":N_J_YSEY", OracleType.Float,22),
					new OracleParameter(":N_J_GG", OracleType.Float,22),
					new OracleParameter(":N_J_GJ", OracleType.Float,22),
                    new OracleParameter(":N_S_RF", OracleType.Float,22),
					new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_S_DY", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_S_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_S_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_RQS", OracleType.Float,22),
					new OracleParameter(":N_S_BD", OracleType.Float,22),
					new OracleParameter(":N_S_BQC", OracleType.Float,22),
					new OracleParameter(":N_S_GG", OracleType.Float,22),
					new OracleParameter(":N_S_GJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPRFCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_RF;
        parameters[2].Value = model.N_Z_DX;
        parameters[3].Value = model.N_Z_DY;
        parameters[4].Value = model.N_Z_DS;
        parameters[5].Value = model.N_Z_ZDRF;
        parameters[6].Value = model.N_Z_ZDDX;
        parameters[7].Value = model.N_Z_RQS;
        parameters[8].Value = model.N_Z_BD;
        parameters[9].Value = model.N_Z_BQC;
        parameters[10].Value = model.N_Z_GG;
        parameters[11].Value = model.N_Z_GJ;
        parameters[12].Value = model.N_Z_JZF;
        parameters[13].Value = model.N_X_RF;
        parameters[14].Value = model.N_X_DX;
        parameters[15].Value = model.N_X_DY;
        parameters[16].Value = model.N_X_DS;
        parameters[17].Value = model.N_X_ZDRF;
        parameters[18].Value = model.N_X_ZDDX;
        parameters[19].Value = model.N_X_BCRF;
        parameters[20].Value = model.N_X_BCDX;
        parameters[21].Value = model.N_X_BCDY;
        parameters[22].Value = model.N_X_RQS;
        parameters[23].Value = model.N_X_BD;
        parameters[24].Value = model.N_X_BQC;
        parameters[25].Value = model.N_X_GG;
        parameters[26].Value = model.N_X_GJ;
        parameters[27].Value = model.N_D_RF;
        parameters[28].Value = model.N_D_DX;
        parameters[29].Value = model.N_D_DY;
        parameters[30].Value = model.N_D_DS;
        parameters[31].Value = model.N_D_ZDRF;
        parameters[32].Value = model.N_D_ZDDX;
        parameters[33].Value = model.N_D_BCRF;
        parameters[34].Value = model.N_D_BCDX;
        parameters[35].Value = model.N_D_BCDY;
        parameters[36].Value = model.N_D_RQS;
        parameters[37].Value = model.N_D_BD;
        parameters[38].Value = model.N_D_BQC;
        parameters[39].Value = model.N_D_GG;
        parameters[40].Value = model.N_D_GJ;
        parameters[41].Value = model.N_J_RF;
        parameters[42].Value = model.N_J_DX;
        parameters[43].Value = model.N_J_DY;
        parameters[44].Value = model.N_J_DS;
        parameters[45].Value = model.N_J_ZDRF;
        parameters[46].Value = model.N_J_ZDDX;
        parameters[47].Value = model.N_J_SBCRF;
        parameters[48].Value = model.N_J_SBCDX;
        parameters[49].Value = model.N_J_SBCDY;
        //parameters[53].Value = model.N_J_YSEY;
        parameters[50].Value = model.N_J_GG;
        parameters[51].Value = model.N_J_GJ;
        parameters[52].Value = model.N_S_RF;
        parameters[53].Value = model.N_S_DX;
        parameters[54].Value = model.N_S_DY;
        parameters[55].Value = model.N_S_DS;
        parameters[56].Value = model.N_S_ZDRF;
        parameters[57].Value = model.N_S_ZDDX;
        parameters[58].Value = model.N_S_BCRF;
        parameters[59].Value = model.N_S_BCDX;
        parameters[60].Value = model.N_S_BCDY;
        parameters[61].Value = model.N_S_RQS;
        parameters[62].Value = model.N_S_BD;
        parameters[63].Value = model.N_S_BQC;
        parameters[64].Value = model.N_S_GG;
        parameters[65].Value = model.N_S_GJ;
        parameters[66].Value = model.N_BJGPRFCJ;
        parameters[67].Value = model.N_BJGPDXCJ;
        parameters[68].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void Add(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_RF,N_Z_DX,N_Z_DY,N_Z_DS,N_Z_ZDRF,N_Z_ZDDX,N_Z_YSEY,N_Z_GG,N_Z_GJ,N_X_RF,N_X_DX,N_X_DY,N_X_DS,N_X_ZDRF,N_X_ZDDX,N_X_YSEY,N_X_BCRF,N_X_BCDX,N_X_BCDY,N_X_BCDS,N_X_GG,N_X_GJ,N_D_RF,N_D_DX,N_D_DY,N_D_DS,N_D_ZDRF,N_D_ZDDX,N_D_YSEY,N_D_BCRF,N_D_BCDX,N_D_BCDY,N_D_BCDS,N_D_GG,N_D_GJ,N_J_RF,N_J_DX,N_J_DY,N_J_DS,N_J_ZDRF,N_J_ZDDX,N_J_YSEY,N_J_SBCRF,N_J_XBCRF,N_J_SBCDX,N_J_XBCDX,N_J_SBCDY,N_J_XBCDY,N_J_SBCDS,N_J_XBCDS,N_J_GG,N_J_GJ,N_Z_JZF,N_S_RF,N_S_DX,N_S_DY,N_S_DS,N_S_ZDRF,N_S_ZDDX,N_S_YSEY,N_S_BCRF,N_S_BCDX,N_S_BCDY,N_S_BCDS,N_S_GG,N_S_GJ,N_BJGPRFCJ,N_BJGPDXCJ,N_BJGPDSCJ)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_RF,:N_Z_DX,:N_Z_DY,:N_Z_DS,:N_Z_ZDRF,:N_Z_ZDDX,:N_Z_YSEY,:N_Z_GG,:N_Z_GJ,:N_X_RF,:N_X_DX,:N_X_DY,:N_X_DS,:N_X_ZDRF,:N_X_ZDDX,:N_X_YSEY,:N_X_BCRF,:N_X_BCDX,:N_X_BCDY,:N_X_BCDS,:N_X_GG,:N_X_GJ,:N_D_RF,:N_D_DX,:N_D_DY,:N_D_DS,:N_D_ZDRF,:N_D_ZDDX,:N_D_YSEY,:N_D_BCRF,:N_D_BCDX,:N_D_BCDY,:N_D_BCDS,:N_D_GG,:N_D_GJ,:N_J_RF,:N_J_DX,:N_J_DY,:N_J_DS,:N_J_ZDRF,:N_J_ZDDX,:N_J_YSEY,:N_J_SBCRF,:N_J_XBCRF,:N_J_SBCDX,:N_J_XBCDX,:N_J_SBCDY,:N_J_XBCDY,:N_J_SBCDS,:N_J_XBCDS,:N_J_GG,:N_J_GJ,:N_Z_JZF,:N_S_RF,:N_S_DX,:N_S_DY,:N_S_DS,:N_S_ZDRF,:N_S_ZDDX,:N_S_YSEY,:N_S_BCRF,:N_S_BCDX,:N_S_BCDY,:N_S_BCDS,:N_S_GG,:N_S_GJ,:N_BJGPRFCJ,:N_BJGPDXCJ,:N_BJGPDSCJ)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_RF", OracleType.Number,4),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_Z_DY", OracleType.Number,4),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDRF", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDDX", OracleType.Number,4),
					new OracleParameter(":N_Z_YSEY", OracleType.Number,4),
					new OracleParameter(":N_Z_GG", OracleType.Number,4),
					new OracleParameter(":N_Z_GJ", OracleType.Number,4),
					new OracleParameter(":N_X_RF", OracleType.Float,22),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_X_DY", OracleType.Float,22),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_X_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_X_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_X_YSEY", OracleType.Float,22),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_X_BCDS", OracleType.Float,22),
					new OracleParameter(":N_X_GG", OracleType.Float,22),
					new OracleParameter(":N_X_GJ", OracleType.Float,22),
					new OracleParameter(":N_D_RF", OracleType.Float,22),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DY", OracleType.Float,22),
					new OracleParameter(":N_D_DS", OracleType.Float,22),
					new OracleParameter(":N_D_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_D_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_D_YSEY", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_BCDS", OracleType.Float,22),
					new OracleParameter(":N_D_GG", OracleType.Float,22),
					new OracleParameter(":N_D_GJ", OracleType.Float,22),
					new OracleParameter(":N_J_RF", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_YSEY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_XBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDS", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDS", OracleType.Float,22),
					new OracleParameter(":N_J_GG", OracleType.Float,22),
					new OracleParameter(":N_J_GJ", OracleType.Float,22),
					new OracleParameter(":N_Z_JZF", OracleType.Number,4),
                    new OracleParameter(":N_S_RF", OracleType.Float,22),
					new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_S_DY", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_S_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_S_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_S_YSEY", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_BCDS", OracleType.Float,22),
					new OracleParameter(":N_S_GG", OracleType.Float,22),
					new OracleParameter(":N_S_GJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPRFCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_RF;
        parameters[2].Value = model.N_Z_DX;
        parameters[3].Value = model.N_Z_DY;
        parameters[4].Value = model.N_Z_DS;
        parameters[5].Value = model.N_Z_ZDRF;
        parameters[6].Value = model.N_Z_ZDDX;
        parameters[7].Value = model.N_Z_YSEY;
        parameters[8].Value = model.N_Z_GG;
        parameters[9].Value = model.N_Z_GJ;
        parameters[10].Value = model.N_X_RF;
        parameters[11].Value = model.N_X_DX;
        parameters[12].Value = model.N_X_DY;
        parameters[13].Value = model.N_X_DS;
        parameters[14].Value = model.N_X_ZDRF;
        parameters[15].Value = model.N_X_ZDDX;
        parameters[16].Value = model.N_X_YSEY;
        parameters[17].Value = model.N_X_BCRF;
        parameters[18].Value = model.N_X_BCDX;
        parameters[19].Value = model.N_X_BCDY;
        parameters[20].Value = model.N_X_BCDS;
        parameters[21].Value = model.N_X_GG;
        parameters[22].Value = model.N_X_GJ;
        parameters[23].Value = model.N_D_RF;
        parameters[24].Value = model.N_D_DX;
        parameters[25].Value = model.N_D_DY;
        parameters[26].Value = model.N_D_DS;
        parameters[27].Value = model.N_D_ZDRF;
        parameters[28].Value = model.N_D_ZDDX;
        parameters[29].Value = model.N_D_YSEY;
        parameters[30].Value = model.N_D_BCRF;
        parameters[31].Value = model.N_D_BCDX;
        parameters[32].Value = model.N_D_BCDY;
        parameters[33].Value = model.N_D_BCDS;
        parameters[34].Value = model.N_D_GG;
        parameters[35].Value = model.N_D_GJ;
        parameters[36].Value = model.N_J_RF;
        parameters[37].Value = model.N_J_DX;
        parameters[38].Value = model.N_J_DY;
        parameters[39].Value = model.N_J_DS;
        parameters[40].Value = model.N_J_ZDRF;
        parameters[41].Value = model.N_J_ZDDX;
        parameters[42].Value = model.N_J_YSEY;
        parameters[43].Value = model.N_J_SBCRF;
        parameters[44].Value = model.N_J_XBCRF;
        parameters[45].Value = model.N_J_SBCDX;
        parameters[46].Value = model.N_J_XBCDX;
        parameters[47].Value = model.N_J_SBCDY;
        parameters[48].Value = model.N_J_XBCDY;
        parameters[49].Value = model.N_J_SBCDS;
        parameters[50].Value = model.N_J_XBCDS;
        parameters[51].Value = model.N_J_GG;
        parameters[52].Value = model.N_J_GJ;
        parameters[53].Value = model.N_Z_JZF;
        parameters[54].Value = model.N_S_RF;
        parameters[55].Value = model.N_S_DX;
        parameters[56].Value = model.N_S_DY;
        parameters[57].Value = model.N_S_DS;
        parameters[58].Value = model.N_S_ZDRF;
        parameters[59].Value = model.N_S_ZDDX;
        parameters[60].Value = model.N_S_YSEY;
        parameters[61].Value = model.N_S_BCRF;
        parameters[62].Value = model.N_S_BCDX;
        parameters[63].Value = model.N_S_BCDY;
        parameters[64].Value = model.N_S_BCDS;
        parameters[65].Value = model.N_S_GG;
        parameters[66].Value = model.N_S_GJ;
        parameters[67].Value = model.N_BJGPRFCJ;
        parameters[68].Value = model.N_BJGPDXCJ;
        parameters[69].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void Update(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_RF=:N_Z_RF,");
        strSql.Append("N_Z_DX=:N_Z_DX,");
        strSql.Append("N_Z_DY=:N_Z_DY,");
        strSql.Append("N_Z_DS=:N_Z_DS,");
        strSql.Append("N_Z_ZDRF=:N_Z_ZDRF,");
        strSql.Append("N_Z_ZDDX=:N_Z_ZDDX,");
        strSql.Append("N_Z_YSEY=:N_Z_YSEY,");
        strSql.Append("N_Z_GG=:N_Z_GG,");
        strSql.Append("N_Z_GJ=:N_Z_GJ,");
        strSql.Append("N_X_RF=:N_X_RF,");
        strSql.Append("N_X_DX=:N_X_DX,");
        strSql.Append("N_X_DY=:N_X_DY,");
        strSql.Append("N_X_DS=:N_X_DS,");
        strSql.Append("N_X_ZDRF=:N_X_ZDRF,");
        strSql.Append("N_X_ZDDX=:N_X_ZDDX,");
        strSql.Append("N_X_YSEY=:N_X_YSEY,");
        strSql.Append("N_X_BCRF=:N_X_BCRF,");
        strSql.Append("N_X_BCDX=:N_X_BCDX,");
        strSql.Append("N_X_BCDY=:N_X_BCDY,");
        strSql.Append("N_X_BCDS=:N_X_BCDS,");
        strSql.Append("N_X_GG=:N_X_GG,");
        strSql.Append("N_X_GJ=:N_X_GJ,");
        strSql.Append("N_D_RF=:N_D_RF,");
        strSql.Append("N_D_DX=:N_D_DX,");
        strSql.Append("N_D_DY=:N_D_DY,");
        strSql.Append("N_D_DS=:N_D_DS,");
        strSql.Append("N_D_ZDRF=:N_D_ZDRF,");
        strSql.Append("N_D_ZDDX=:N_D_ZDDX,");
        strSql.Append("N_D_YSEY=:N_D_YSEY,");
        strSql.Append("N_D_BCRF=:N_D_BCRF,");
        strSql.Append("N_D_BCDX=:N_D_BCDX,");
        strSql.Append("N_D_BCDY=:N_D_BCDY,");
        strSql.Append("N_D_BCDS=:N_D_BCDS,");
        strSql.Append("N_D_GG=:N_D_GG,");
        strSql.Append("N_D_GJ=:N_D_GJ,");
        strSql.Append("N_J_RF=:N_J_RF,");
        strSql.Append("N_J_DX=:N_J_DX,");
        strSql.Append("N_J_DY=:N_J_DY,");
        strSql.Append("N_J_DS=:N_J_DS,");
        strSql.Append("N_J_ZDRF=:N_J_ZDRF,");
        strSql.Append("N_J_ZDDX=:N_J_ZDDX,");
        strSql.Append("N_J_YSEY=:N_J_YSEY,");
        strSql.Append("N_J_SBCRF=:N_J_SBCRF,");
        strSql.Append("N_J_XBCRF=:N_J_XBCRF,");
        strSql.Append("N_J_SBCDX=:N_J_SBCDX,");
        strSql.Append("N_J_XBCDX=:N_J_XBCDX,");
        strSql.Append("N_J_SBCDY=:N_J_SBCDY,");
        strSql.Append("N_J_XBCDY=:N_J_XBCDY,");
        strSql.Append("N_J_SBCDS=:N_J_SBCDS,");
        strSql.Append("N_J_XBCDS=:N_J_XBCDS,");
        strSql.Append("N_J_GG=:N_J_GG,");
        strSql.Append("N_J_GJ=:N_J_GJ,");
        strSql.Append("N_Z_JZF=:N_Z_JZF,");
        strSql.Append("N_S_RF=:N_S_RF,");
        strSql.Append("N_S_DX=:N_S_DX,");
        strSql.Append("N_S_DY=:N_S_DY,");
        strSql.Append("N_S_DS=:N_S_DS,");
        strSql.Append("N_S_ZDRF=:N_S_ZDRF,");
        strSql.Append("N_S_ZDDX=:N_S_ZDDX,");
        strSql.Append("N_S_YSEY=:N_S_YSEY,");
        strSql.Append("N_S_BCRF=:N_S_BCRF,");
        strSql.Append("N_S_BCDX=:N_S_BCDX,");
        strSql.Append("N_S_BCDY=:N_S_BCDY,");
        strSql.Append("N_S_BCDS=:N_S_BCDS,");
        strSql.Append("N_S_GG=:N_S_GG,");
        strSql.Append("N_S_GJ=:N_S_GJ,");
        strSql.Append("N_BJGPRFCJ=:N_BJGPRFCJ,");
        strSql.Append("N_BJGPDXCJ=:N_BJGPDXCJ,");
        strSql.Append("N_BJGPDSCJ=:N_BJGPDSCJ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_RF", OracleType.Number,4),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_Z_DY", OracleType.Number,4),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDRF", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDDX", OracleType.Number,4),
					new OracleParameter(":N_Z_YSEY", OracleType.Number,4),
					new OracleParameter(":N_Z_GG", OracleType.Number,4),
					new OracleParameter(":N_Z_GJ", OracleType.Number,4),
					new OracleParameter(":N_X_RF", OracleType.Float,22),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_X_DY", OracleType.Float,22),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_X_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_X_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_X_YSEY", OracleType.Float,22),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_X_BCDS", OracleType.Float,22),
					new OracleParameter(":N_X_GG", OracleType.Float,22),
					new OracleParameter(":N_X_GJ", OracleType.Float,22),
					new OracleParameter(":N_D_RF", OracleType.Float,22),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DY", OracleType.Float,22),
					new OracleParameter(":N_D_DS", OracleType.Float,22),
					new OracleParameter(":N_D_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_D_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_D_YSEY", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_BCDS", OracleType.Float,22),
					new OracleParameter(":N_D_GG", OracleType.Float,22),
					new OracleParameter(":N_D_GJ", OracleType.Float,22),
					new OracleParameter(":N_J_RF", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_YSEY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_XBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDS", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDS", OracleType.Float,22),
					new OracleParameter(":N_J_GG", OracleType.Float,22),
					new OracleParameter(":N_J_GJ", OracleType.Float,22),
					new OracleParameter(":N_Z_JZF", OracleType.Number,4),
                    new OracleParameter(":N_S_RF", OracleType.Float,22),
					new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_S_DY", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_S_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_S_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_S_YSEY", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_BCDS", OracleType.Float,22),
					new OracleParameter(":N_S_GG", OracleType.Float,22),
					new OracleParameter(":N_S_GJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPRFCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Float,22),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_RF;
        parameters[2].Value = model.N_Z_DX;
        parameters[3].Value = model.N_Z_DY;
        parameters[4].Value = model.N_Z_DS;
        parameters[5].Value = model.N_Z_ZDRF;
        parameters[6].Value = model.N_Z_ZDDX;
        parameters[7].Value = model.N_Z_YSEY;
        parameters[8].Value = model.N_Z_GG;
        parameters[9].Value = model.N_Z_GJ;
        parameters[10].Value = model.N_X_RF;
        parameters[11].Value = model.N_X_DX;
        parameters[12].Value = model.N_X_DY;
        parameters[13].Value = model.N_X_DS;
        parameters[14].Value = model.N_X_ZDRF;
        parameters[15].Value = model.N_X_ZDDX;
        parameters[16].Value = model.N_X_YSEY;
        parameters[17].Value = model.N_X_BCRF;
        parameters[18].Value = model.N_X_BCDX;
        parameters[19].Value = model.N_X_BCDY;
        parameters[20].Value = model.N_X_BCDS;
        parameters[21].Value = model.N_X_GG;
        parameters[22].Value = model.N_X_GJ;
        parameters[23].Value = model.N_D_RF;
        parameters[24].Value = model.N_D_DX;
        parameters[25].Value = model.N_D_DY;
        parameters[26].Value = model.N_D_DS;
        parameters[27].Value = model.N_D_ZDRF;
        parameters[28].Value = model.N_D_ZDDX;
        parameters[29].Value = model.N_D_YSEY;
        parameters[30].Value = model.N_D_BCRF;
        parameters[31].Value = model.N_D_BCDX;
        parameters[32].Value = model.N_D_BCDY;
        parameters[33].Value = model.N_D_BCDS;
        parameters[34].Value = model.N_D_GG;
        parameters[35].Value = model.N_D_GJ;
        parameters[36].Value = model.N_J_RF;
        parameters[37].Value = model.N_J_DX;
        parameters[38].Value = model.N_J_DY;
        parameters[39].Value = model.N_J_DS;
        parameters[40].Value = model.N_J_ZDRF;
        parameters[41].Value = model.N_J_ZDDX;
        parameters[42].Value = model.N_J_YSEY;
        parameters[43].Value = model.N_J_SBCRF;
        parameters[44].Value = model.N_J_XBCRF;
        parameters[45].Value = model.N_J_SBCDX;
        parameters[46].Value = model.N_J_XBCDX;
        parameters[47].Value = model.N_J_SBCDY;
        parameters[48].Value = model.N_J_XBCDY;
        parameters[49].Value = model.N_J_SBCDS;
        parameters[50].Value = model.N_J_XBCDS;
        parameters[51].Value = model.N_J_GG;
        parameters[52].Value = model.N_J_GJ;
        parameters[53].Value = model.N_Z_JZF;
        parameters[54].Value = model.N_S_RF;
        parameters[55].Value = model.N_S_DX;
        parameters[56].Value = model.N_S_DY;
        parameters[57].Value = model.N_S_DS;
        parameters[58].Value = model.N_S_ZDRF;
        parameters[59].Value = model.N_S_ZDDX;
        parameters[60].Value = model.N_S_YSEY;
        parameters[61].Value = model.N_S_BCRF;
        parameters[62].Value = model.N_S_BCDX;
        parameters[63].Value = model.N_S_BCDY;
        parameters[64].Value = model.N_S_BCDS;
        parameters[65].Value = model.N_S_GG;
        parameters[66].Value = model.N_S_GJ;
        parameters[67].Value = model.N_BJGPRFCJ;
        parameters[68].Value = model.N_BJGPDXCJ;
        parameters[69].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public void Delete(int N_TYPE)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete KFB_BBKG ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4)};
        parameters[0].Value = N_TYPE;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public KFB_BBKG GetModel(int N_TYPE)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from KFB_BBKG ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4)};
        parameters[0].Value = N_TYPE;

        KFB_BBKG model = new KFB_BBKG();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["N_TYPE"].ToString() != "")
            {
                model.N_TYPE = int.Parse(ds.Tables[0].Rows[0]["N_TYPE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_RF"].ToString() != "")
            {
                model.N_Z_RF = int.Parse(ds.Tables[0].Rows[0]["N_Z_RF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_DX"].ToString() != "")
            {
                model.N_Z_DX = int.Parse(ds.Tables[0].Rows[0]["N_Z_DX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_DY"].ToString() != "")
            {
                model.N_Z_DY = int.Parse(ds.Tables[0].Rows[0]["N_Z_DY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_DS"].ToString() != "")
            {
                model.N_Z_DS = int.Parse(ds.Tables[0].Rows[0]["N_Z_DS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_ZDRF"].ToString() != "")
            {
                model.N_Z_ZDRF = int.Parse(ds.Tables[0].Rows[0]["N_Z_ZDRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_ZDDX"].ToString() != "")
            {
                model.N_Z_ZDDX = int.Parse(ds.Tables[0].Rows[0]["N_Z_ZDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_YSEY"].ToString() != "")
            {
                model.N_Z_YSEY = int.Parse(ds.Tables[0].Rows[0]["N_Z_YSEY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_GG"].ToString() != "")
            {
                model.N_Z_GG = int.Parse(ds.Tables[0].Rows[0]["N_Z_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_GJ"].ToString() != "")
            {
                model.N_Z_GJ = int.Parse(ds.Tables[0].Rows[0]["N_Z_GJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_RF"].ToString() != "")
            {
                model.N_X_RF = float.Parse(ds.Tables[0].Rows[0]["N_X_RF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_DX"].ToString() != "")
            {
                model.N_X_DX = float.Parse(ds.Tables[0].Rows[0]["N_X_DX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_DY"].ToString() != "")
            {
                model.N_X_DY = float.Parse(ds.Tables[0].Rows[0]["N_X_DY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_DS"].ToString() != "")
            {
                model.N_X_DS = float.Parse(ds.Tables[0].Rows[0]["N_X_DS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_ZDRF"].ToString() != "")
            {
                model.N_X_ZDRF = float.Parse(ds.Tables[0].Rows[0]["N_X_ZDRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_ZDDX"].ToString() != "")
            {
                model.N_X_ZDDX = float.Parse(ds.Tables[0].Rows[0]["N_X_ZDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_YSEY"].ToString() != "")
            {
                model.N_X_YSEY = float.Parse(ds.Tables[0].Rows[0]["N_X_YSEY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_BCRF"].ToString() != "")
            {
                model.N_X_BCRF = float.Parse(ds.Tables[0].Rows[0]["N_X_BCRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_BCDX"].ToString() != "")
            {
                model.N_X_BCDX = float.Parse(ds.Tables[0].Rows[0]["N_X_BCDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_BCDY"].ToString() != "")
            {
                model.N_X_BCDY = float.Parse(ds.Tables[0].Rows[0]["N_X_BCDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_BCDS"].ToString() != "")
            {
                model.N_X_BCDS = float.Parse(ds.Tables[0].Rows[0]["N_X_BCDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_GG"].ToString() != "")
            {
                model.N_X_GG = float.Parse(ds.Tables[0].Rows[0]["N_X_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_X_GJ"].ToString() != "")
            {
                model.N_X_GJ = float.Parse(ds.Tables[0].Rows[0]["N_X_GJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_RF"].ToString() != "")
            {
                model.N_D_RF = float.Parse(ds.Tables[0].Rows[0]["N_D_RF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_DX"].ToString() != "")
            {
                model.N_D_DX = float.Parse(ds.Tables[0].Rows[0]["N_D_DX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_DY"].ToString() != "")
            {
                model.N_D_DY = float.Parse(ds.Tables[0].Rows[0]["N_D_DY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_DS"].ToString() != "")
            {
                model.N_D_DS = float.Parse(ds.Tables[0].Rows[0]["N_D_DS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_ZDRF"].ToString() != "")
            {
                model.N_D_ZDRF = float.Parse(ds.Tables[0].Rows[0]["N_D_ZDRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_ZDDX"].ToString() != "")
            {
                model.N_D_ZDDX = float.Parse(ds.Tables[0].Rows[0]["N_D_ZDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_YSEY"].ToString() != "")
            {
                model.N_D_YSEY = float.Parse(ds.Tables[0].Rows[0]["N_D_YSEY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_BCRF"].ToString() != "")
            {
                model.N_D_BCRF = float.Parse(ds.Tables[0].Rows[0]["N_D_BCRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_BCDX"].ToString() != "")
            {
                model.N_D_BCDX = float.Parse(ds.Tables[0].Rows[0]["N_D_BCDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_BCDY"].ToString() != "")
            {
                model.N_D_BCDY = float.Parse(ds.Tables[0].Rows[0]["N_D_BCDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_BCDS"].ToString() != "")
            {
                model.N_D_BCDS = float.Parse(ds.Tables[0].Rows[0]["N_D_BCDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_GG"].ToString() != "")
            {
                model.N_D_GG = float.Parse(ds.Tables[0].Rows[0]["N_D_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_D_GJ"].ToString() != "")
            {
                model.N_D_GJ = float.Parse(ds.Tables[0].Rows[0]["N_D_GJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_RF"].ToString() != "")
            {
                model.N_J_RF = float.Parse(ds.Tables[0].Rows[0]["N_J_RF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_DX"].ToString() != "")
            {
                model.N_J_DX = float.Parse(ds.Tables[0].Rows[0]["N_J_DX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_DY"].ToString() != "")
            {
                model.N_J_DY = float.Parse(ds.Tables[0].Rows[0]["N_J_DY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_DS"].ToString() != "")
            {
                model.N_J_DS = float.Parse(ds.Tables[0].Rows[0]["N_J_DS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_ZDRF"].ToString() != "")
            {
                model.N_J_ZDRF = float.Parse(ds.Tables[0].Rows[0]["N_J_ZDRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_ZDDX"].ToString() != "")
            {
                model.N_J_ZDDX = float.Parse(ds.Tables[0].Rows[0]["N_J_ZDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_YSEY"].ToString() != "")
            {
                model.N_J_YSEY = float.Parse(ds.Tables[0].Rows[0]["N_J_YSEY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_SBCRF"].ToString() != "")
            {
                model.N_J_SBCRF = float.Parse(ds.Tables[0].Rows[0]["N_J_SBCRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_XBCRF"].ToString() != "")
            {
                model.N_J_XBCRF = float.Parse(ds.Tables[0].Rows[0]["N_J_XBCRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_SBCDX"].ToString() != "")
            {
                model.N_J_SBCDX = float.Parse(ds.Tables[0].Rows[0]["N_J_SBCDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_XBCDX"].ToString() != "")
            {
                model.N_J_XBCDX = float.Parse(ds.Tables[0].Rows[0]["N_J_XBCDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_SBCDY"].ToString() != "")
            {
                model.N_J_SBCDY = float.Parse(ds.Tables[0].Rows[0]["N_J_SBCDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_XBCDY"].ToString() != "")
            {
                model.N_J_XBCDY = float.Parse(ds.Tables[0].Rows[0]["N_J_XBCDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_SBCDS"].ToString() != "")
            {
                model.N_J_SBCDS = float.Parse(ds.Tables[0].Rows[0]["N_J_SBCDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_XBCDS"].ToString() != "")
            {
                model.N_J_XBCDS = float.Parse(ds.Tables[0].Rows[0]["N_J_XBCDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_GG"].ToString() != "")
            {
                model.N_J_GG = float.Parse(ds.Tables[0].Rows[0]["N_J_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_GJ"].ToString() != "")
            {
                model.N_J_GJ = float.Parse(ds.Tables[0].Rows[0]["N_J_GJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_Z_JZF"].ToString() != "")
            {
                model.N_Z_JZF = int.Parse(ds.Tables[0].Rows[0]["N_Z_JZF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_RF"].ToString() != "")
            {
                model.N_S_RF = float.Parse(ds.Tables[0].Rows[0]["N_S_RF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_DX"].ToString() != "")
            {
                model.N_S_DX = float.Parse(ds.Tables[0].Rows[0]["N_S_DX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_DY"].ToString() != "")
            {
                model.N_S_DY = float.Parse(ds.Tables[0].Rows[0]["N_S_DY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_DS"].ToString() != "")
            {
                model.N_S_DS = float.Parse(ds.Tables[0].Rows[0]["N_S_DS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_ZDRF"].ToString() != "")
            {
                model.N_S_ZDRF = float.Parse(ds.Tables[0].Rows[0]["N_S_ZDRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_ZDDX"].ToString() != "")
            {
                model.N_S_ZDDX = float.Parse(ds.Tables[0].Rows[0]["N_S_ZDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_YSEY"].ToString() != "")
            {
                model.N_S_YSEY = float.Parse(ds.Tables[0].Rows[0]["N_S_YSEY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_BCRF"].ToString() != "")
            {
                model.N_S_BCRF = float.Parse(ds.Tables[0].Rows[0]["N_S_BCRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_BCDX"].ToString() != "")
            {
                model.N_S_BCDX = float.Parse(ds.Tables[0].Rows[0]["N_S_BCDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_BCDY"].ToString() != "")
            {
                model.N_S_BCDY = float.Parse(ds.Tables[0].Rows[0]["N_S_BCDY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_BCDS"].ToString() != "")
            {
                model.N_S_BCDS = float.Parse(ds.Tables[0].Rows[0]["N_S_BCDS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_GG"].ToString() != "")
            {
                model.N_S_GG = float.Parse(ds.Tables[0].Rows[0]["N_S_GG"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_S_GJ"].ToString() != "")
            {
                model.N_S_GJ = float.Parse(ds.Tables[0].Rows[0]["N_S_GJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BJGPRFCJ"].ToString() != "")
            {
                model.N_BJGPRFCJ = float.Parse(ds.Tables[0].Rows[0]["N_BJGPRFCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BJGPDXCJ"].ToString() != "")
            {
                model.N_BJGPDXCJ = float.Parse(ds.Tables[0].Rows[0]["N_BJGPDXCJ"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_BJGPDSCJ"].ToString() != "")
            {
                model.N_BJGPDSCJ = float.Parse(ds.Tables[0].Rows[0]["N_BJGPDSCJ"].ToString());
            }


            if (ds.Tables[0].Rows[0]["n_z_rqs"].ToString() != "")
            {
                model.N_Z_RQS = int.Parse(ds.Tables[0].Rows[0]["n_z_rqs"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_z_bd"].ToString() != "")
            {
                model.N_Z_BD = int.Parse(ds.Tables[0].Rows[0]["n_z_bd"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_z_bqc"].ToString() != "")
            {
                model.N_Z_BQC = int.Parse(ds.Tables[0].Rows[0]["n_z_bqc"].ToString());
            }

            if (ds.Tables[0].Rows[0]["n_x_rqs"].ToString() != "")
            {
                model.N_X_RQS = float.Parse(ds.Tables[0].Rows[0]["n_X_rqs"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_X_bd"].ToString() != "")
            {
                model.N_X_BD = float.Parse(ds.Tables[0].Rows[0]["n_X_bd"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_X_bqc"].ToString() != "")
            {
                model.N_X_BQC = float.Parse(ds.Tables[0].Rows[0]["n_X_bqc"].ToString());
            }

            if (ds.Tables[0].Rows[0]["n_D_rqs"].ToString() != "")
            {
                model.N_D_RQS = float.Parse(ds.Tables[0].Rows[0]["n_D_rqs"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_D_bd"].ToString() != "")
            {
                model.N_D_BD = float.Parse(ds.Tables[0].Rows[0]["n_D_bd"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_D_bqc"].ToString() != "")
            {
                model.N_D_BQC = float.Parse(ds.Tables[0].Rows[0]["n_D_bqc"].ToString());
            }

            if (ds.Tables[0].Rows[0]["n_s_rqs"].ToString() != "")
            {
                model.N_S_RQS = float.Parse(ds.Tables[0].Rows[0]["n_S_rqs"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_S_bd"].ToString() != "")
            {
                model.N_S_BD = float.Parse(ds.Tables[0].Rows[0]["n_S_bd"].ToString());
            }
            if (ds.Tables[0].Rows[0]["n_S_bqc"].ToString() != "")
            {
                model.N_S_BQC = float.Parse(ds.Tables[0].Rows[0]["n_S_bqc"].ToString());
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
        strSql.Append("select N_TYPE,N_Z_RF,N_Z_DX,N_Z_DY,N_Z_DS,N_Z_ZDRF,N_Z_ZDDX,N_Z_YSEY,N_Z_GG,N_Z_GJ,N_X_RF,N_X_DX,N_X_DY,N_X_DS,N_X_ZDRF,N_X_ZDDX,N_X_YSEY,N_X_GG,N_X_GJ,N_D_RF,N_D_DX,N_D_DY,N_D_DS,N_D_ZDRF,N_D_ZDDX,N_D_YSEY,N_D_GG,N_D_GJ,N_J_RF,N_J_DX,N_J_DY,N_J_DS,N_J_ZDRF,N_J_ZDDX,N_J_YSEY,N_J_GG,N_J_GJ,N_Z_JZF,N_S_RF,N_S_DX,N_S_DY,N_S_DS,N_S_ZDRF,N_S_ZDDX,N_S_YSEY,N_S_GG,N_S_GJ,N_BJGPRFCJ,N_BJGPDXCJ,N_BJGPDSCJ ");
        strSql.Append(" FROM KFB_BBKG ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperOra.Query(strSql.ToString());
    }

    #endregion  成员方法

    #region  讓分成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddRF(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_RF,N_X_RF,N_D_RF,N_J_RF,N_S_RF)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_RF,:N_X_RF,:N_D_RF,:N_J_RF,:N_S_RF)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_RF", OracleType.Number,4),
					new OracleParameter(":N_X_RF", OracleType.Float,22),
					new OracleParameter(":N_D_RF", OracleType.Float,22),
					new OracleParameter(":N_J_RF", OracleType.Float,22),
					new OracleParameter(":N_S_RF", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_RF;
        parameters[2].Value = model.N_X_RF;
        parameters[3].Value = model.N_D_RF;
        parameters[4].Value = model.N_J_RF;
        parameters[5].Value = model.N_S_RF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateRF(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_RF=:N_Z_RF,");
        strSql.Append("N_X_RF=:N_X_RF,");
        strSql.Append("N_D_RF=:N_D_RF,");
        strSql.Append("N_S_RF=:N_S_RF,");
        strSql.Append("N_J_RF=:N_J_RF");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_RF", OracleType.Number,4),
					new OracleParameter(":N_X_RF", OracleType.Float,22),
					new OracleParameter(":N_D_RF", OracleType.Float,22),
                    new OracleParameter(":N_S_RF", OracleType.Float,22),
					new OracleParameter(":N_J_RF", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_RF;
        parameters[2].Value = model.N_X_RF;
        parameters[3].Value = model.N_D_RF;
        parameters[4].Value = model.N_S_RF;
        parameters[5].Value = model.N_J_RF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  大小成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddDX(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_DX,N_X_DX,N_D_DX,N_S_DX,N_J_DX)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_DX,:N_X_DX,:N_D_DX,:N_S_DX,:N_J_DX)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
                    new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_DX;
        parameters[2].Value = model.N_X_DX;
        parameters[3].Value = model.N_D_DX;
        parameters[4].Value = model.N_S_DX;
        parameters[5].Value = model.N_J_DX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateDX(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_DX=:N_Z_DX,");
        strSql.Append("N_X_DX=:N_X_DX,");
        strSql.Append("N_D_DX=:N_D_DX,");
        strSql.Append("N_S_DX=:N_S_DX,");
        strSql.Append("N_J_DX=:N_J_DX");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_DX", OracleType.Number,4),
					new OracleParameter(":N_X_DX", OracleType.Float,22),
					new OracleParameter(":N_D_DX", OracleType.Float,22),
                    new OracleParameter(":N_S_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_DX;
        parameters[2].Value = model.N_X_DX;
        parameters[3].Value = model.N_D_DX;
        parameters[4].Value = model.N_S_DX;
        parameters[5].Value = model.N_J_DX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  獨贏成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddDY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_DY,N_X_DY,N_S_DY,N_D_DY,N_J_DY)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_DY,:N_X_DY,:N_S_DY,:N_D_DY,:N_J_DY)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_DY", OracleType.Number,4),
					new OracleParameter(":N_X_DY", OracleType.Float,22),
					new OracleParameter(":N_S_DY", OracleType.Float,22),
					new OracleParameter(":N_D_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_DY;
        parameters[2].Value = model.N_X_DY;
        parameters[3].Value = model.N_S_DY;
        parameters[4].Value = model.N_D_DY;
        parameters[5].Value = model.N_J_DY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateDY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_DY=:N_Z_DY,");
        strSql.Append("N_X_DY=:N_X_DY,");
        strSql.Append("N_S_DY=:N_S_DY,");
        strSql.Append("N_D_DY=:N_D_DY,");
        strSql.Append("N_J_DY=:N_J_DY");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_DY", OracleType.Number,4),
					new OracleParameter(":N_X_DY", OracleType.Float,22),
					new OracleParameter(":N_S_DY", OracleType.Float,22),
					new OracleParameter(":N_D_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_DY;
        parameters[2].Value = model.N_X_DY;
        parameters[3].Value = model.N_S_DY;
        parameters[4].Value = model.N_D_DY;
        parameters[5].Value = model.N_J_DY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  單雙成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddDS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_DS,N_X_DS,N_S_DS,N_D_DS,N_J_DS)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_DS,:N_X_DS,:N_S_DS,:N_D_DS,:N_J_DS)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_D_DS", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_DS;
        parameters[2].Value = model.N_X_DS;
        parameters[3].Value = model.N_S_DS;
        parameters[4].Value = model.N_D_DS;
        parameters[5].Value = model.N_J_DS;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateDS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_DS=:N_Z_DS,");
        strSql.Append("N_X_DS=:N_X_DS,");
        strSql.Append("N_S_DS=:N_S_DS,");
        strSql.Append("N_D_DS=:N_D_DS,");
        strSql.Append("N_J_DS=:N_J_DS");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_DS", OracleType.Number,4),
					new OracleParameter(":N_X_DS", OracleType.Float,22),
					new OracleParameter(":N_S_DS", OracleType.Float,22),
					new OracleParameter(":N_D_DS", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_DS;
        parameters[2].Value = model.N_X_DS;
        parameters[3].Value = model.N_S_DS;
        parameters[4].Value = model.N_D_DS;
        parameters[5].Value = model.N_J_DS;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  走地讓分成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZR(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_ZDRF,N_X_ZDRF,N_S_ZDRF,N_D_ZDRF,N_J_ZDRF)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_ZDRF,:N_X_ZDRF,:N_S_ZDRF,:N_D_ZDRF,:N_J_ZDRF)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDRF", OracleType.Number,4),
					new OracleParameter(":N_X_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_S_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_D_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_ZDRF;
        parameters[2].Value = model.N_X_ZDRF;
        parameters[3].Value = model.N_S_ZDRF;
        parameters[4].Value = model.N_D_ZDRF;
        parameters[5].Value = model.N_J_ZDRF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZR(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_ZDRF=:N_Z_ZDRF,");
        strSql.Append("N_X_ZDRF=:N_X_ZDRF,");
        strSql.Append("N_S_ZDRF=:N_S_ZDRF,");
        strSql.Append("N_D_ZDRF=:N_D_ZDRF,");
        strSql.Append("N_J_ZDRF=:N_J_ZDRF");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDRF", OracleType.Number,4),
					new OracleParameter(":N_X_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_S_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_D_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_ZDRF;
        parameters[2].Value = model.N_X_ZDRF;
        parameters[3].Value = model.N_S_ZDRF;
        parameters[4].Value = model.N_D_ZDRF;
        parameters[5].Value = model.N_J_ZDRF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  走地大小成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZD(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_ZDDX,N_X_ZDDX,N_S_ZDDX,N_D_ZDDX,N_J_ZDDX)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_ZDDX,:N_X_ZDDX,:N_S_ZDDX,:N_D_ZDDX,:N_J_ZDDX)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDDX", OracleType.Number,4),
					new OracleParameter(":N_X_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_S_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_D_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_ZDDX;
        parameters[2].Value = model.N_X_ZDDX;
        parameters[3].Value = model.N_S_ZDDX;
        parameters[4].Value = model.N_D_ZDDX;
        parameters[5].Value = model.N_J_ZDDX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZD(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_ZDDX=:N_Z_ZDDX,");
        strSql.Append("N_X_ZDDX=:N_X_ZDDX,");
        strSql.Append("N_S_ZDDX=:N_S_ZDDX,");
        strSql.Append("N_D_ZDDX=:N_D_ZDDX,");
        strSql.Append("N_J_ZDDX=:N_J_ZDDX");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_ZDDX", OracleType.Number,4),
					new OracleParameter(":N_X_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_S_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_D_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_ZDDX;
        parameters[2].Value = model.N_X_ZDDX;
        parameters[3].Value = model.N_S_ZDDX;
        parameters[4].Value = model.N_D_ZDDX;
        parameters[5].Value = model.N_J_ZDDX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  一輸二贏成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddSY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_YSEY,N_X_YSEY,N_S_YSEY,N_D_YSEY,N_J_YSEY)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_YSEY,:N_X_YSEY,:N_S_YSEY,:N_D_YSEY,:N_J_YSEY)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_YSEY", OracleType.Number,4),
					new OracleParameter(":N_X_YSEY", OracleType.Float,22),
					new OracleParameter(":N_S_YSEY", OracleType.Float,22),
					new OracleParameter(":N_D_YSEY", OracleType.Float,22),
					new OracleParameter(":N_J_YSEY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_YSEY;
        parameters[2].Value = model.N_X_YSEY;
        parameters[3].Value = model.N_S_YSEY;
        parameters[4].Value = model.N_D_YSEY;
        parameters[5].Value = model.N_J_YSEY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateSY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_YSEY=:N_Z_YSEY,");
        strSql.Append("N_X_YSEY=:N_X_YSEY,");
        strSql.Append("N_S_YSEY=:N_S_YSEY,");
        strSql.Append("N_D_YSEY=:N_D_YSEY,");
        strSql.Append("N_J_YSEY=:N_J_YSEY");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_YSEY", OracleType.Number,4),
					new OracleParameter(":N_X_YSEY", OracleType.Float,22),
					new OracleParameter(":N_S_YSEY", OracleType.Float,22),
					new OracleParameter(":N_D_YSEY", OracleType.Float,22),
					new OracleParameter(":N_J_YSEY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_YSEY;
        parameters[2].Value = model.N_X_YSEY;
        parameters[3].Value = model.N_S_YSEY;
        parameters[4].Value = model.N_D_YSEY;
        parameters[5].Value = model.N_J_YSEY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  半場讓分成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddBCRF(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_BCRF,N_S_BCRF,N_D_BCRF,N_J_SBCRF,N_J_XBCRF)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_BCRF,:N_S_BCRF,:N_D_BCRF,:N_J_SBCRF,:N_J_XBCRF)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_XBCRF", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCRF;
        parameters[2].Value = model.N_S_BCRF;
        parameters[3].Value = model.N_D_BCRF;
        parameters[4].Value = model.N_J_SBCRF;
        parameters[5].Value = model.N_J_XBCRF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateBCRF(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BCRF=:N_X_BCRF,");
        strSql.Append("N_S_BCRF=:N_S_BCRF,");
        strSql.Append("N_D_BCRF=:N_D_BCRF,");
        strSql.Append("N_J_SBCRF=:N_J_SBCRF,");
        strSql.Append("N_J_XBCRF=:N_J_XBCRF");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22),
					new OracleParameter(":N_J_XBCRF", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCRF;
        parameters[2].Value = model.N_S_BCRF;
        parameters[3].Value = model.N_D_BCRF;
        parameters[4].Value = model.N_J_SBCRF;
        parameters[5].Value = model.N_J_XBCRF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  半場大小成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddBCDX(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_BCDX,N_S_BCDX,N_D_BCDX,N_J_SBCDX,N_J_XBCDX)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_BCDX,:N_S_BCDX,:N_D_BCDX,:N_J_SBCDX,:N_J_XBCDX)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDX", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDX;
        parameters[2].Value = model.N_S_BCDX;
        parameters[3].Value = model.N_D_BCDX;
        parameters[4].Value = model.N_J_SBCDX;
        parameters[5].Value = model.N_J_XBCDX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateBCDX(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BCDX=:N_X_BCDX,");
        strSql.Append("N_S_BCDX=:N_S_BCDX,");
        strSql.Append("N_D_BCDX=:N_D_BCDX,");
        strSql.Append("N_J_SBCDX=:N_J_SBCDX,");
        strSql.Append("N_J_XBCDX=:N_J_XBCDX");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDX", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDX;
        parameters[2].Value = model.N_S_BCDX;
        parameters[3].Value = model.N_D_BCDX;
        parameters[4].Value = model.N_J_SBCDX;
        parameters[5].Value = model.N_J_XBCDX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  半場獨贏成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddBCDY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_BCDY,N_S_BCDY,N_D_BCDY,N_J_SBCDY,N_J_XBCDY)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_BCDY,:N_S_BCDY,:N_D_BCDY,:N_J_SBCDY,:N_J_XBCDY)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDY;
        parameters[2].Value = model.N_S_BCDY;
        parameters[3].Value = model.N_D_BCDY;
        parameters[4].Value = model.N_J_SBCDY;
        parameters[5].Value = model.N_J_XBCDY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateBCDY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BCDY=:N_X_BCDY,");
        strSql.Append("N_S_BCDY=:N_S_BCDY,");
        strSql.Append("N_D_BCDY=:N_D_BCDY,");
        strSql.Append("N_J_SBCDY=:N_J_SBCDY,");
        strSql.Append("N_J_XBCDY=:N_J_XBCDY");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDY;
        parameters[2].Value = model.N_S_BCDY;
        parameters[3].Value = model.N_D_BCDY;
        parameters[4].Value = model.N_J_SBCDY;
        parameters[5].Value = model.N_J_XBCDY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  足球半場讓分成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZQBCRF(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_BCRF,N_S_BCRF,N_D_BCRF,N_J_SBCRF)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_BCRF,:N_S_BCRF,:N_D_BCRF,:N_J_SBCRF)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCRF;
        parameters[2].Value = model.N_S_BCRF;
        parameters[3].Value = model.N_D_BCRF;
        parameters[4].Value = model.N_J_SBCRF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZQBCRF(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BCRF=:N_X_BCRF,");
        strSql.Append("N_S_BCRF=:N_S_BCRF,");
        strSql.Append("N_D_BCRF=:N_D_BCRF,");
        strSql.Append("N_J_SBCRF=:N_J_SBCRF ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCRF", OracleType.Float,22),
					new OracleParameter(":N_S_BCRF", OracleType.Float,22),
					new OracleParameter(":N_D_BCRF", OracleType.Float,22),
					new OracleParameter(":N_J_SBCRF", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCRF;
        parameters[2].Value = model.N_S_BCRF;
        parameters[3].Value = model.N_D_BCRF;
        parameters[4].Value = model.N_J_SBCRF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  足球半場大小成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZQBCDX(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_BCDX,N_S_BCDX,N_D_BCDX,N_J_SBCDX)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_BCDX,:N_S_BCDX,:N_D_BCDX,:N_J_SBCDX)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDX;
        parameters[2].Value = model.N_S_BCDX;
        parameters[3].Value = model.N_D_BCDX;
        parameters[4].Value = model.N_J_SBCDX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZQBCDX(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BCDX=:N_X_BCDX,");
        strSql.Append("N_S_BCDX=:N_S_BCDX,");
        strSql.Append("N_D_BCDX=:N_D_BCDX,");
        strSql.Append("N_J_SBCDX=:N_J_SBCDX");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDX", OracleType.Float,22),
					new OracleParameter(":N_S_BCDX", OracleType.Float,22),
					new OracleParameter(":N_D_BCDX", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDX", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDX;
        parameters[2].Value = model.N_S_BCDX;
        parameters[3].Value = model.N_D_BCDX;
        parameters[4].Value = model.N_J_SBCDX;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  足球半場獨贏成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddZQBCDY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_BCDY,N_S_BCDY,N_D_BCDY,N_J_SBCDY)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_BCDY,:N_S_BCDY,:N_D_BCDY,:N_J_SBCDY)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDY;
        parameters[2].Value = model.N_S_BCDY;
        parameters[3].Value = model.N_D_BCDY;
        parameters[4].Value = model.N_J_SBCDY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateZQBCDY(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BCDY=:N_X_BCDY,");
        strSql.Append("N_S_BCDY=:N_S_BCDY,");
        strSql.Append("N_D_BCDY=:N_D_BCDY,");
        strSql.Append("N_J_SBCDY=:N_J_SBCDY ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDY", OracleType.Float,22),
					new OracleParameter(":N_S_BCDY", OracleType.Float,22),
					new OracleParameter(":N_D_BCDY", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDY", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDY;
        parameters[2].Value = model.N_S_BCDY;
        parameters[3].Value = model.N_D_BCDY;
        parameters[4].Value = model.N_J_SBCDY;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  半場單雙成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddBCDS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_YSEY,N_S_YSEY,N_D_YSEY,N_J_SBCDS,N_J_XBCDS)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_YSEY,:N_S_YSEY,:N_D_YSEY,:N_J_SBCDS,:N_J_XBCDS)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDS", OracleType.Float,22),
					new OracleParameter(":N_S_BCDS", OracleType.Float,22),
					new OracleParameter(":N_D_BCDS", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDS", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDS", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDS;
        parameters[2].Value = model.N_S_BCDS;
        parameters[3].Value = model.N_D_BCDS;
        parameters[4].Value = model.N_J_SBCDS;
        parameters[5].Value = model.N_J_XBCDS;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateBCDS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BCDS=:N_X_BCDS,");
        strSql.Append("N_S_BCDS=:N_S_BCDS,");
        strSql.Append("N_D_BCDS=:N_D_BCDS,");
        strSql.Append("N_J_SBCDS=:N_J_SBCDS,");
        strSql.Append("N_J_XBCDS=:N_J_XBCDS");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BCDS", OracleType.Float,22),
					new OracleParameter(":N_S_BCDS", OracleType.Float,22),
					new OracleParameter(":N_D_BCDS", OracleType.Float,22),
					new OracleParameter(":N_J_SBCDS", OracleType.Float,22),
					new OracleParameter(":N_J_XBCDS", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BCDS;
        parameters[2].Value = model.N_S_BCDS;
        parameters[3].Value = model.N_D_BCDS;
        parameters[4].Value = model.N_J_SBCDS;
        parameters[5].Value = model.N_J_XBCDS;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  過關成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddGG(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_GG,N_S_GG)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_GG,:N_S_GG)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_GG", OracleType.Number,4),
					new OracleParameter(":N_S_GG", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_GG;
        parameters[2].Value = model.N_S_GG;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateGG(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_GG=:N_X_GG,");
        strSql.Append("N_S_GG=:N_S_GG");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_GG", OracleType.Number,4),
					new OracleParameter(":N_S_GG", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_GG;
        parameters[2].Value = model.N_S_GG;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  半場讓分大小成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddRD(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_X_GJ,N_S_GJ)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_X_GJ,:N_S_GJ)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_GJ", OracleType.Number,4),
					new OracleParameter(":N_S_GJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_GJ;
        parameters[2].Value = model.N_S_GJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateRD(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_GJ=:N_X_GJ,");
        strSql.Append("N_S_GJ=:N_S_GJ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_GJ", OracleType.Number,4),
					new OracleParameter(":N_S_GJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_GJ;
        parameters[2].Value = model.N_S_GJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  基準分成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddJZ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_JZF)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_JZF)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_JZF", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_JZF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateJZ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_Z_JZF=:N_Z_JZF");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_Z_JZF", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_Z_JZF;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  讓分差距成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddRFCJ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_BJGPRFCJ)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_BJGPRFCJ)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_BJGPRFCJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_BJGPRFCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateRFCJ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_BJGPRFCJ=:N_BJGPRFCJ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_BJGPRFCJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_BJGPRFCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  大小差距成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddDXCJ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_BJGPDXCJ)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_BJGPDXCJ)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_BJGPDXCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateDXCJ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_BJGPDXCJ=:N_BJGPDXCJ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_BJGPDXCJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_BJGPDXCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region  單雙差距成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddDSCJ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_BJGPDSCJ)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_BJGPDSCJ)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateDSCJ(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_BJGPDSCJ=:N_BJGPDSCJ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_BJGPDSCJ", OracleType.Number,4)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_BJGPDSCJ;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region 波胆成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddBD(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_BD,N_X_BD,N_S_BD,N_D_BD)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_BD,:N_X_BD,:N_S_BD,:N_D_BD)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BD", OracleType.Float,22),
					new OracleParameter(":N_S_BD", OracleType.Float,22),
					new OracleParameter(":N_D_BD", OracleType.Float,22),
                new OracleParameter(":N_Z_BD", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BD;
        parameters[2].Value = model.N_S_BD;
        parameters[3].Value = model.N_D_BD;
        parameters[4].Value = model.N_Z_BD;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateBD(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BD=:N_X_BD,");
        strSql.Append("N_S_BD=:N_S_BD,");
        strSql.Append("N_D_BD=:N_D_BD,");
        strSql.Append("N_Z_BD=:N_Z_BD");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BD", OracleType.Float,22),
					new OracleParameter(":N_S_BD", OracleType.Float,22),
					new OracleParameter(":N_D_BD", OracleType.Float,22),
                new OracleParameter(":N_Z_BD", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BD;
        parameters[2].Value = model.N_S_BD;
        parameters[3].Value = model.N_D_BD;
        parameters[4].Value = model.N_Z_BD;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region 入球数成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddRQS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_RQS,N_X_RQS,N_S_RQS,N_D_RQS)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_RQS,:N_X_RQS,:N_S_RQS,:N_D_RQS)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_RQS", OracleType.Float,22),
					new OracleParameter(":N_S_RQS", OracleType.Float,22),
					new OracleParameter(":N_D_RQS", OracleType.Float,22),
                new OracleParameter(":N_Z_RQS", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_RQS;
        parameters[2].Value = model.N_S_RQS;
        parameters[3].Value = model.N_D_RQS;
        parameters[4].Value = model.N_Z_RQS;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateRQS(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_RQS=:N_X_RQS,");
        strSql.Append("N_S_RQS=:N_S_RQS,");
        strSql.Append("N_D_RQS=:N_D_RQS,");
        strSql.Append("N_Z_RQS=:N_Z_RQS");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_RQS", OracleType.Float,22),
					new OracleParameter(":N_S_RQS", OracleType.Float,22),
					new OracleParameter(":N_D_RQS", OracleType.Float,22),
                new OracleParameter(":N_Z_RQS", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_RQS;
        parameters[2].Value = model.N_S_RQS;
        parameters[3].Value = model.N_D_RQS;
        parameters[4].Value = model.N_Z_RQS;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    #region 半全场成员方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddBQC(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKG(");
        strSql.Append("N_TYPE,N_Z_BQC,N_X_BQC,N_S_BQC,N_D_BQC)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_Z_BQC,:N_X_BQC,:N_S_BQC,:N_D_BQC)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BQC", OracleType.Float,22),
					new OracleParameter(":N_S_BQC", OracleType.Float,22),
					new OracleParameter(":N_D_BQC", OracleType.Float,22),
                new OracleParameter(":N_Z_BQC", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BQC;
        parameters[2].Value = model.N_S_BQC;
        parameters[3].Value = model.N_D_BQC;
        parameters[4].Value = model.N_Z_BQC;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateBQC(KFB_BBKG model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKG set ");
        strSql.Append("N_TYPE=:N_TYPE,");
        strSql.Append("N_X_BQC=:N_X_BQC,");
        strSql.Append("N_S_BQC=:N_S_BQC,");
        strSql.Append("N_D_BQC=:N_D_BQC,");
        strSql.Append("N_Z_BQC=:N_Z_BQC");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_X_BQC", OracleType.Float,22),
					new OracleParameter(":N_S_BQC", OracleType.Float,22),
					new OracleParameter(":N_D_BQC", OracleType.Float,22),
                new OracleParameter(":N_Z_BQC", OracleType.Float,22)
            };
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_X_BQC;
        parameters[2].Value = model.N_S_BQC;
        parameters[3].Value = model.N_D_BQC;
        parameters[4].Value = model.N_Z_BQC;

        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    #endregion  成员方法

    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int N_TYPE, int N_LMNO, int N_CBXH)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from KFB_BBKGJZ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        strSql.Append(" and N_LMNO=:N_LMNO ");
        strSql.Append(" and N_CBXH=:N_CBXH ");
        OracleParameter[] parameters = {
				new OracleParameter(":N_TYPE", OracleType.Number,4),
                new OracleParameter(":N_LMNO", OracleType.Number,38),
                new OracleParameter(":N_CBXH", OracleType.Number,38),
            };
        parameters[0].Value = N_TYPE;
        parameters[1].Value = N_LMNO;
        parameters[2].Value = N_CBXH;
        return DbHelperOra.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void Add(KFB_BBKGJZ model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKGJZ(");
        strSql.Append("N_TYPE,N_LMNO,N_CBXH,N_J_RF,N_J_DX,N_J_DY,N_J_DS,N_J_ZDRF,N_J_ZDDX,N_J_YSEY)");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_LMNO,:N_CBXH,:N_J_RF,:N_J_DX,:N_J_DY,:N_J_DS,:N_J_ZDRF,:N_J_ZDDX,:N_J_YSEY)");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_LMNO", OracleType.Number,38),
					new OracleParameter(":N_CBXH", OracleType.Number,38),
					new OracleParameter(":N_J_RF", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_YSEY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_LMNO;
        parameters[2].Value = model.N_CBXH;
        parameters[3].Value = model.N_J_RF;
        parameters[4].Value = model.N_J_DX;
        parameters[5].Value = model.N_J_DY;
        parameters[6].Value = model.N_J_DS;
        parameters[7].Value = model.N_J_ZDRF;
        parameters[8].Value = model.N_J_ZDDX;
        parameters[9].Value = model.N_J_YSEY;
        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void Update(KFB_BBKGJZ model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKGJZ set ");
        strSql.Append("N_J_RF=:N_J_RF,");
        strSql.Append("N_J_DX=:N_J_DX,");
        strSql.Append("N_J_DY=:N_J_DY,");
        strSql.Append("N_J_DS=:N_J_DS,");
        strSql.Append("N_J_ZDRF=:N_J_ZDRF,");
        strSql.Append("N_J_ZDDX=:N_J_ZDDX,");
        strSql.Append("N_J_YSEY=:N_J_YSEY ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        strSql.Append(" and N_LMNO=:N_LMNO ");
        strSql.Append(" and N_CBXH=:N_CBXH ");
        OracleParameter[] parameters = {
					new OracleParameter(":N_TYPE", OracleType.Number,4),
					new OracleParameter(":N_LMNO", OracleType.Number,38),
					new OracleParameter(":N_CBXH", OracleType.Number,38),
					new OracleParameter(":N_J_RF", OracleType.Float,22),
					new OracleParameter(":N_J_DX", OracleType.Float,22),
					new OracleParameter(":N_J_DY", OracleType.Float,22),
					new OracleParameter(":N_J_DS", OracleType.Float,22),
					new OracleParameter(":N_J_ZDRF", OracleType.Float,22),
					new OracleParameter(":N_J_ZDDX", OracleType.Float,22),
					new OracleParameter(":N_J_YSEY", OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_LMNO;
        parameters[2].Value = model.N_CBXH;
        parameters[3].Value = model.N_J_RF;
        parameters[4].Value = model.N_J_DX;
        parameters[5].Value = model.N_J_DY;
        parameters[6].Value = model.N_J_DS;
        parameters[7].Value = model.N_J_ZDRF;
        parameters[8].Value = model.N_J_ZDDX;
        parameters[9].Value = model.N_J_YSEY;
        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void AddWF(KFB_BBKGJZ model, string strWF)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into KFB_BBKGJZ(");
        strSql.Append("N_TYPE,N_LMNO,N_CBXH,N_J_" + strWF + ")");
        strSql.Append(" values (");
        strSql.Append(":N_TYPE,:N_LMNO,:N_CBXH,:N_J_" + strWF + ")");
        OracleParameter[] parameters = {
                    new OracleParameter(":N_TYPE", OracleType.Number,4),
                    new OracleParameter(":N_LMNO", OracleType.Number,38),
                    new OracleParameter(":N_CBXH", OracleType.Number,38),
                    new OracleParameter(":N_J_" + strWF, OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_LMNO;
        parameters[2].Value = model.N_CBXH;
        parameters[3].Value = getWF(model, strWF);
        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public void UpdateWF(KFB_BBKGJZ model, string strWF)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update KFB_BBKGJZ set ");
        strSql.Append("N_J_" + strWF + "=:N_J_" + strWF);
        strSql.Append(" where N_TYPE=:N_TYPE ");
        strSql.Append(" and N_LMNO=:N_LMNO ");
        strSql.Append(" and N_CBXH=:N_CBXH ");
        OracleParameter[] parameters = {
                    new OracleParameter(":N_TYPE", OracleType.Number,4),
                    new OracleParameter(":N_LMNO", OracleType.Number,38),
                    new OracleParameter(":N_CBXH", OracleType.Number,38),
                    new OracleParameter(":N_J_" + strWF , OracleType.Float,22)};
        parameters[0].Value = model.N_TYPE;
        parameters[1].Value = model.N_LMNO;
        parameters[2].Value = model.N_CBXH;
        parameters[3].Value = getWF(model, strWF);
        DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
    }
    private float? getWF(KFB_BBKGJZ model, string strWF)
    {
        switch (strWF)
        {
            case "RF":
                return model.N_J_RF;
            case "DX":
                return model.N_J_DX;
            case "DS":
                return model.N_J_DS;
            case "DY":
                return model.N_J_DY;
            case "ZDRF":
                return model.N_J_ZDRF;
            case "ZDDX":
                return model.N_J_ZDDX;
            case "YSEY":
                return model.N_J_YSEY;
        }
        return 0;
    }
    public KFB_BBKGJZ GetModel(int N_TYPE, int N_LMNO, int N_CBXH)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from KFB_BBKGJZ ");
        strSql.Append(" where N_TYPE=:N_TYPE ");
        strSql.Append(" and N_LMNO=:N_LMNO ");
        strSql.Append(" and N_CBXH=:N_CBXH ");
        OracleParameter[] parameters = {
				new OracleParameter(":N_TYPE", OracleType.Number,4),
                new OracleParameter(":N_LMNO", OracleType.Number,38),
                new OracleParameter(":N_CBXH", OracleType.Number,38),
            };
        parameters[0].Value = N_TYPE;
        parameters[1].Value = N_LMNO;
        parameters[2].Value = N_CBXH;
        KFB_BBKGJZ model = new KFB_BBKGJZ();
        DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["N_TYPE"].ToString() != "")
            {
                model.N_TYPE = int.Parse(ds.Tables[0].Rows[0]["N_TYPE"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_LMNO"].ToString() != "")
            {
                model.N_LMNO = int.Parse(ds.Tables[0].Rows[0]["N_LMNO"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_CBXH"].ToString() != "")
            {
                model.N_CBXH = int.Parse(ds.Tables[0].Rows[0]["N_CBXH"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_RF"].ToString() != "")
            {
                model.N_J_RF = float.Parse(ds.Tables[0].Rows[0]["N_J_RF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_DX"].ToString() != "")
            {
                model.N_J_DX = float.Parse(ds.Tables[0].Rows[0]["N_J_DX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_DY"].ToString() != "")
            {
                model.N_J_DY = float.Parse(ds.Tables[0].Rows[0]["N_J_DY"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_DS"].ToString() != "")
            {
                model.N_J_DS = float.Parse(ds.Tables[0].Rows[0]["N_J_DS"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_ZDRF"].ToString() != "")
            {
                model.N_J_ZDRF = float.Parse(ds.Tables[0].Rows[0]["N_J_ZDRF"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_ZDDX"].ToString() != "")
            {
                model.N_J_ZDDX = float.Parse(ds.Tables[0].Rows[0]["N_J_ZDDX"].ToString());
            }
            if (ds.Tables[0].Rows[0]["N_J_YSEY"].ToString() != "")
            {
                model.N_J_YSEY = float.Parse(ds.Tables[0].Rows[0]["N_J_YSEY"].ToString());
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
    public DataSet GetLM(string strlx)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select N_NO,N_LMMC,N_LX,N_XH,N_LEVEL,N_LMMC_EN,N_LMMC_CN,N_LMMC_TW,N_LMMC_TH ");
        strSql.Append(" FROM KFB_LMGL ");
        strSql.Append(" where N_LX=:N_LX");
        strSql.Append(" ORDER BY N_LEVEL,N_XH");
        OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.Number,4)
            };
        parameters[0].Value = Convert.ToInt32(strlx);
        return DbHelperOra.Query(strSql.ToString(), parameters);
    }
}
