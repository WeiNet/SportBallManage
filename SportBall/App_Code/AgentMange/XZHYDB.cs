using KingOfBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class XZHYDB
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KFB_HYGL model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_HYGL set ");
            strSql.Append("N_HYZH=:N_HYZH,");
            strSql.Append("N_HYMM=:N_HYMM,");
            strSql.Append("N_HYMC=:N_HYMC,");
            strSql.Append("N_KYED=:N_KYED,");
            strSql.Append("N_SYED=:N_SYED,");
            strSql.Append("N_WXDJ=:N_WXDJ,");
            strSql.Append("N_YXDL=:N_YXDL,");
            strSql.Append("N_YXXZ=:N_YXXZ,");
            strSql.Append("N_DLSJ=:N_DLSJ,");
            strSql.Append("N_YCXZ=:N_YCXZ,");
            strSql.Append("N_DZXX=:N_DZXX,");
            strSql.Append("N_ZJDH=:N_ZJDH,");
            strSql.Append("N_DGDDH=:N_DGDDH,");
            strSql.Append("N_GDDH=:N_GDDH,");
            strSql.Append("N_ZDLDH=:N_ZDLDH,");
            strSql.Append("N_DLDH=:N_DLDH,");
            strSql.Append("N_LQTZ=:N_LQTZ,");
            strSql.Append("N_MBTZ=:N_MBTZ,");
            strSql.Append("N_RBTZ=:N_RBTZ,");
            strSql.Append("N_ZQTZ=:N_ZQTZ,");
            strSql.Append("N_MZTZ=:N_MZTZ,");
            strSql.Append("N_CWCS=:N_CWCS,");
            strSql.Append("N_XZSJ=:N_XZSJ,");
            strSql.Append("N_HYIP=:N_HYIP,");
            strSql.Append("N_TBTZ=:N_TBTZ,");
            strSql.Append("N_HYJR=:N_HYJR,");
            strSql.Append("N_ZSTZ=:N_ZSTZ,");
            strSql.Append("N_XGSJ=:N_XGSJ,");
            strSql.Append("N_SMTZ=:N_SMTZ,");
            strSql.Append("N_CPTZ=:N_CPTZ,");
            strSql.Append("N_DLTTZ=:N_DLTTZ,");
            strSql.Append("N_LHCTZ=:N_LHCTZ,");
            strSql.Append("N_JCTZ=:N_JCTZ,");
            strSql.Append("N_TOLLGATE=:N_TOLLGATE,");
            strSql.Append("N_DZJDH=:N_DZJDH,");
            strSql.Append("N_SSTZ=:N_SSTZ,");
            strSql.Append("N_TKYZM=:N_TKYZM,");
            strSql.Append("N_HBDM=:N_HBDM,");
            strSql.Append("N_DHHM=:N_DHHM,");
            strSql.Append("N_MAIL=:N_MAIL,");
            strSql.Append("N_QQ=:N_QQ,");
            strSql.Append("N_DLZH=:N_DLZH,");
            strSql.Append("N_SFSW=:N_SFSW, ");
            strSql.Append("N_BQTZ=:N_BQTZ,");
            strSql.Append("N_CQTZ=:N_CQTZ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYMM", OracleType.VarChar,100),
					new OracleParameter(":N_HYMC", OracleType.VarChar,100),
					new OracleParameter(":N_KYED", OracleType.Float,22),
					new OracleParameter(":N_SYED", OracleType.Float,22),
					new OracleParameter(":N_WXDJ", OracleType.Number,4),
					new OracleParameter(":N_YXDL", OracleType.Number,4),
					new OracleParameter(":N_YXXZ", OracleType.Number,4),
					new OracleParameter(":N_DLSJ", OracleType.DateTime),
					new OracleParameter(":N_YCXZ", OracleType.Number,4),
					new OracleParameter(":N_DZXX", OracleType.Float,22),
					new OracleParameter(":N_ZJDH", OracleType.VarChar,100),
					new OracleParameter(":N_DGDDH", OracleType.VarChar,100),
					new OracleParameter(":N_GDDH", OracleType.VarChar,100),
					new OracleParameter(":N_ZDLDH", OracleType.VarChar,100),
					new OracleParameter(":N_DLDH", OracleType.VarChar,100),
					new OracleParameter(":N_LQTZ", OracleType.Number,4),
					new OracleParameter(":N_MBTZ", OracleType.Number,4),
					new OracleParameter(":N_RBTZ", OracleType.Number,4),
					new OracleParameter(":N_ZQTZ", OracleType.Number,4),
					new OracleParameter(":N_MZTZ", OracleType.Number,4),
					new OracleParameter(":N_CWCS", OracleType.Number,4),
					new OracleParameter(":N_XZSJ", OracleType.DateTime),
					new OracleParameter(":N_HYIP", OracleType.VarChar,100),
					new OracleParameter(":N_TBTZ", OracleType.Number,4),
					new OracleParameter(":N_HYJR", OracleType.DateTime),
					new OracleParameter(":N_ZSTZ", OracleType.Number,4),
					new OracleParameter(":N_XGSJ", OracleType.DateTime),
					new OracleParameter(":N_SMTZ", OracleType.Number,4),
					new OracleParameter(":N_CPTZ", OracleType.Number,4),
					new OracleParameter(":N_DLTTZ", OracleType.Number,4),
					new OracleParameter(":N_LHCTZ", OracleType.Number,4),
					new OracleParameter(":N_JCTZ", OracleType.Number,4),
					new OracleParameter(":n_tollgate", OracleType.Number,4),
					new OracleParameter(":N_DZJDH", OracleType.VarChar,100),
                    new OracleParameter(":N_SSTZ", OracleType.Number,4),
                    new OracleParameter(":N_TKYZM", OracleType.VarChar,100),
					new OracleParameter(":N_HBDM", OracleType.VarChar,6),
					new OracleParameter(":N_DHHM", OracleType.VarChar,50),
					new OracleParameter(":N_MAIL", OracleType.VarChar,50),
					new OracleParameter(":N_QQ", OracleType.VarChar,50),
                    new OracleParameter(":N_DLZH", OracleType.VarChar,100),
                    new OracleParameter(":N_SFSW", OracleType.VarChar,1),
                				new OracleParameter(":N_BQTZ", OracleType.Number,4),
                				new OracleParameter(":N_CQTZ", OracleType.Number,4)
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_HYMM;
            parameters[2].Value = model.N_HYMC;
            parameters[3].Value = model.N_KYED;
            parameters[4].Value = model.N_SYED;
            parameters[5].Value = model.N_WXDJ;
            parameters[6].Value = model.N_YXDL;
            parameters[7].Value = model.N_YXXZ;
            parameters[8].Value = model.N_DLSJ;
            parameters[9].Value = model.N_YCXZ;
            parameters[10].Value = model.N_DZXX;
            parameters[11].Value = model.N_ZJDH;
            parameters[12].Value = model.N_DGDDH;
            parameters[13].Value = model.N_GDDH;
            parameters[14].Value = model.N_ZDLDH;
            parameters[15].Value = model.N_DLDH;
            parameters[16].Value = model.N_LQTZ;
            parameters[17].Value = model.N_MBTZ;
            parameters[18].Value = model.N_RBTZ;
            parameters[19].Value = model.N_ZQTZ;
            parameters[20].Value = model.N_MZTZ;
            parameters[21].Value = model.N_CWCS;
            parameters[22].Value = model.N_XZSJ;
            parameters[23].Value = model.N_HYIP;
            parameters[24].Value = model.N_TBTZ;
            parameters[25].Value = model.N_HYJR;
            parameters[26].Value = model.N_ZSTZ;
            parameters[27].Value = model.N_XGSJ;
            parameters[28].Value = model.N_SMTZ;
            parameters[29].Value = model.N_CPTZ;
            parameters[30].Value = model.N_DLTTZ;
            parameters[31].Value = model.N_LHCTZ;
            parameters[32].Value = model.N_JCTZ;
            parameters[33].Value = model.N_TOLLGATE;
            parameters[34].Value = model.N_DZJDH;
            parameters[35].Value = model.N_SSTZ;
            parameters[36].Value = model.N_TKYZM;
            parameters[37].Value = model.N_HBDM;
            parameters[38].Value = model.N_DHHM;
            parameters[39].Value = model.N_MAIL;
            parameters[40].Value = model.N_QQ;
            parameters[41].Value = model.N_DLZH;
            parameters[42].Value = model.N_SFSW;

            parameters[43].Value = model.N_BQTZ;
            parameters[44].Value = model.N_CQTZ;

            o_aHt.Add(parameters, strSql.ToString());
        }
        /// <summary>
        /// 消耗會員所屬代理商的信用額度
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public void SetDLSED(string s_aDLS, decimal d_aHYED, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update kfb_zhgl set n_syed = n_syed - :n_syed");
            strSql.Append(" where n_hyzh =:n_hyzh");
            OracleParameter[] parameters = {
					new OracleParameter(":n_hyzh", OracleType.VarChar,100),
					new OracleParameter(":n_syed", OracleType.Number,4)};
            parameters[0].Value = s_aDLS;
            parameters[1].Value = d_aHYED;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddCP(KFB_SETUPCP model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPCP(");
            strSql.Append("N_HYDH,N_BQTY,N_LQTY,N_ZQTY,N_GSTY,N_QZTY,N_BQDZ,N_LQDZ,N_ZQDZ,N_GSDZ,N_QZDZ,N_BQDC,N_LQDC,N_ZQDC,N_GSDC,N_QZDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYDH,:N_BQTY,:N_LQTY,:N_ZQTY,:N_GSTY,:N_QZTY,:N_BQDZ,:N_LQDZ,:N_ZQDZ,:N_GSDZ,:N_QZDZ,:N_BQDC,:N_LQDC,:N_ZQDC,:N_GSDC,:N_QZDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_BQTY;
            parameters[2].Value = model.N_LQTY;
            parameters[3].Value = model.N_ZQTY;
            parameters[4].Value = model.N_GSTY;
            parameters[5].Value = model.N_QZTY;
            parameters[6].Value = model.N_BQDZ;
            parameters[7].Value = model.N_LQDZ;
            parameters[8].Value = model.N_ZQDZ;
            parameters[9].Value = model.N_GSDZ;
            parameters[10].Value = model.N_QZDZ;
            parameters[11].Value = model.N_BQDC;
            parameters[12].Value = model.N_LQDC;
            parameters[13].Value = model.N_ZQDC;
            parameters[14].Value = model.N_GSDC;
            parameters[15].Value = model.N_QZDC;
            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddDLT(KFB_SETUPDLT model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPDLT(");
            strSql.Append("N_HYDH,N_TBHTY,N_TTTY,N_THTY,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_GDDSTY,N_GDDXTY,N_TBHDZ,N_TTDZ,N_THDZ,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_GDDSDZ,N_GDDXDZ,N_TBHDC,N_TTDC,N_THDC,N_QCPDC,N_2XDC,N_3XDC,N_4XDC,N_GDDSDC,N_GDDXDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYDH,:N_TBHTY,:N_TTTY,:N_THTY,:N_QCPTY,:N_2XTY,:N_3XTY,:N_4XTY,:N_GDDSTY,:N_GDDXTY,:N_TBHDZ,:N_TTDZ,:N_THDZ,:N_QCPDZ,:N_2XDZ,:N_3XDZ,:N_4XDZ,:N_GDDSDZ,:N_GDDXDZ,:N_TBHDC,:N_TTDC,:N_THDC,:N_QCPDC,:N_2XDC,:N_3XDC,:N_4XDC,:N_GDDSDC,:N_GDDXDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_TBHTY;
            parameters[2].Value = model.N_TTTY;
            parameters[3].Value = model.N_THTY;
            parameters[4].Value = model.N_QCPTY;
            parameters[5].Value = model.N_2XTY;
            parameters[6].Value = model.N_3XTY;
            parameters[7].Value = model.N_4XTY;
            parameters[8].Value = model.N_GDDSTY;
            parameters[9].Value = model.N_GDDXTY;
            parameters[10].Value = model.N_TBHDZ;
            parameters[11].Value = model.N_TTDZ;
            parameters[12].Value = model.N_THDZ;
            parameters[13].Value = model.N_QCPDZ;
            parameters[14].Value = model.N_2XDZ;
            parameters[15].Value = model.N_3XDZ;
            parameters[16].Value = model.N_4XDZ;
            parameters[17].Value = model.N_GDDSDZ;
            parameters[18].Value = model.N_GDDXDZ;
            parameters[19].Value = model.N_TBHDC;
            parameters[20].Value = model.N_TTDC;
            parameters[21].Value = model.N_THDC;
            parameters[22].Value = model.N_QCPDC;
            parameters[23].Value = model.N_2XDC;
            parameters[24].Value = model.N_3XDC;
            parameters[25].Value = model.N_4XDC;
            parameters[26].Value = model.N_GDDSDC;
            parameters[27].Value = model.N_GDDXDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddJC539(KFB_SETUPJC539 model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPJC539(");
            strSql.Append("N_HYDH,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_QCPDC,N_2XDC,N_3XDC,N_4XDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYDH,:N_QCPTY,:N_2XTY,:N_3XTY,:N_4XTY,:N_QCPDZ,:N_2XDZ,:N_3XDZ,:N_4XDZ,:N_QCPDC,:N_2XDC,:N_3XDC,:N_4XDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_QCPTY;
            parameters[2].Value = model.N_2XTY;
            parameters[3].Value = model.N_3XTY;
            parameters[4].Value = model.N_4XTY;
            parameters[5].Value = model.N_QCPDZ;
            parameters[6].Value = model.N_2XDZ;
            parameters[7].Value = model.N_3XDZ;
            parameters[8].Value = model.N_4XDZ;
            parameters[9].Value = model.N_QCPDC;
            parameters[10].Value = model.N_2XDC;
            parameters[11].Value = model.N_3XDC;
            parameters[12].Value = model.N_4XDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddLHC(KFB_SETUPLHC model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPLHC(");
            strSql.Append("N_HYDH,N_TBHTY,N_TTTY,N_THTY,N_QCPTY,N_2XTY,N_3XTY,N_4XTY,N_GDDSTY,N_GDDXTY,N_TBHDZ,N_TTDZ,N_THDZ,N_QCPDZ,N_2XDZ,N_3XDZ,N_4XDZ,N_GDDSDZ,N_GDDXDZ,N_TBHDC,N_TTDC,N_THDC,N_QCPDC,N_2XDC,N_3XDC,N_4XDC,N_GDDSDC,N_GDDXDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYDH,:N_TBHTY,:N_TTTY,:N_THTY,:N_QCPTY,:N_2XTY,:N_3XTY,:N_4XTY,:N_GDDSTY,:N_GDDXTY,:N_TBHDZ,:N_TTDZ,:N_THDZ,:N_QCPDZ,:N_2XDZ,:N_3XDZ,:N_4XDZ,:N_GDDSDZ,:N_GDDXDZ,:N_TBHDC,:N_TTDC,:N_THDC,:N_QCPDC,:N_2XDC,:N_3XDC,:N_4XDC,:N_GDDSDC,:N_GDDXDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_TBHTY;
            parameters[2].Value = model.N_TTTY;
            parameters[3].Value = model.N_THTY;
            parameters[4].Value = model.N_QCPTY;
            parameters[5].Value = model.N_2XTY;
            parameters[6].Value = model.N_3XTY;
            parameters[7].Value = model.N_4XTY;
            parameters[8].Value = model.N_GDDSTY;
            parameters[9].Value = model.N_GDDXTY;
            parameters[10].Value = model.N_TBHDZ;
            parameters[11].Value = model.N_TTDZ;
            parameters[12].Value = model.N_THDZ;
            parameters[13].Value = model.N_QCPDZ;
            parameters[14].Value = model.N_2XDZ;
            parameters[15].Value = model.N_3XDZ;
            parameters[16].Value = model.N_4XDZ;
            parameters[17].Value = model.N_GDDSDZ;
            parameters[18].Value = model.N_GDDXDZ;
            parameters[19].Value = model.N_TBHDC;
            parameters[20].Value = model.N_TTDC;
            parameters[21].Value = model.N_THDC;
            parameters[22].Value = model.N_QCPDC;
            parameters[23].Value = model.N_2XDC;
            parameters[24].Value = model.N_3XDC;
            parameters[25].Value = model.N_4XDC;
            parameters[26].Value = model.N_GDDSDC;
            parameters[27].Value = model.N_GDDXDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddLQ(KFB_SETUPLQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPLQ(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC,");
            strSql.Append("N_RFDD,N_DXDD,N_DYDD,N_DSDD,N_ZDRFDD,N_ZDDXDD,N_BCRFDD,N_BCDXDD,N_BCDYDD,N_BCDSDD,N_GGDD,N_GJDD,N_DJRFTY,N_DJDXTY,N_DJDSTY,N_DJRFDZ,N_DJDXDZ,N_DJDSDZ,N_DJRFDC,N_DJDXDC,N_DJDSDC,N_DJRFDD,N_DJDXDD,N_DJDSDD)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_BCRFTY,:N_BCDXTY,:N_BCDYTY,:N_BCDSTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_BCRFDZ,:N_BCDXDZ,:N_BCDYDZ,:N_BCDSDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_BCRFDC,:N_BCDXDC,:N_BCDYDC,:N_BCDSDC,:N_GGDC,:N_GJDC,");
            strSql.Append(":N_RFDD,:N_DXDD,:N_DYDD,:N_DSDD,:N_ZDRFDD,:N_ZDDXDD,:N_BCRFDD,:N_BCDXDD,:N_BCDYDD,:N_BCDSDD,:N_GGDD,:N_GJDD,:N_DJRFTY,:N_DJDXTY,:N_DJDSTY,:N_DJRFDZ,:N_DJDXDZ,:N_DJDSDZ,:N_DJRFDC,:N_DJDXDC,:N_DJDSDC,:N_DJRFDD,:N_DJDXDD,:N_DJDSDD)");
            OracleParameter[] parameters = {
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
					new OracleParameter(":N_GJDC", OracleType.Float,22),
					new OracleParameter(":N_RFDD", OracleType.Float,22),
					new OracleParameter(":N_DXDD", OracleType.Float,22),
					new OracleParameter(":N_DYDD", OracleType.Float,22),
					new OracleParameter(":N_DSDD", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDD", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDD", OracleType.Float,22),
					new OracleParameter(":N_BCRFDD", OracleType.Float,22),
					new OracleParameter(":N_BCDXDD", OracleType.Float,22),
					new OracleParameter(":N_BCDYDD", OracleType.Float,22),
					new OracleParameter(":N_BCDSDD", OracleType.Float,22),
					new OracleParameter(":N_GGDD", OracleType.Float,22),
					new OracleParameter(":N_GJDD", OracleType.Float,22),
                    new OracleParameter(":N_DJRFTY", OracleType.Float,22),
					new OracleParameter(":N_DJDXTY", OracleType.Float,22),
                    new OracleParameter(":N_DJDSTY", OracleType.Float,22),
                    new OracleParameter(":N_DJRFDZ", OracleType.Float,22),
					new OracleParameter(":N_DJDXDZ", OracleType.Float,22),
                    new OracleParameter(":N_DJDSDZ", OracleType.Float,22),
                    new OracleParameter(":N_DJRFDC", OracleType.Float,22),
					new OracleParameter(":N_DJDXDC", OracleType.Float,22),
                    new OracleParameter(":N_DJDSDC", OracleType.Float,22),
                    new OracleParameter(":N_DJRFDD", OracleType.Float,22),
					new OracleParameter(":N_DJDXDD", OracleType.Float,22),
                    new OracleParameter(":N_DJDSDD", OracleType.Float,22)
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_BCRFTY;
            parameters[8].Value = model.N_BCDXTY;
            parameters[9].Value = model.N_BCDYTY;
            parameters[10].Value = model.N_BCDSTY;
            parameters[11].Value = model.N_GGTY;
            parameters[12].Value = model.N_GJTY;
            parameters[13].Value = model.N_RFDZ;
            parameters[14].Value = model.N_DXDZ;
            parameters[15].Value = model.N_DYDZ;
            parameters[16].Value = model.N_DSDZ;
            parameters[17].Value = model.N_ZDRFDZ;
            parameters[18].Value = model.N_ZDDXDZ;
            parameters[19].Value = model.N_BCRFDZ;
            parameters[20].Value = model.N_BCDXDZ;
            parameters[21].Value = model.N_BCDYDZ;
            parameters[22].Value = model.N_BCDSDZ;
            parameters[23].Value = model.N_GGDZ;
            parameters[24].Value = model.N_GJDZ;
            parameters[25].Value = model.N_RFDC;
            parameters[26].Value = model.N_DXDC;
            parameters[27].Value = model.N_DYDC;
            parameters[28].Value = model.N_DSDC;
            parameters[29].Value = model.N_ZDRFDC;
            parameters[30].Value = model.N_ZDDXDC;
            parameters[31].Value = model.N_BCRFDC;
            parameters[32].Value = model.N_BCDXDC;
            parameters[33].Value = model.N_BCDYDC;
            parameters[34].Value = model.N_BCDSDC;
            parameters[35].Value = model.N_GGDC;
            parameters[36].Value = model.N_GJDC;
            parameters[37].Value = model.N_RFDD;
            parameters[38].Value = model.N_DXDD;
            parameters[39].Value = model.N_DYDD;
            parameters[40].Value = model.N_DSDD;
            parameters[41].Value = model.N_ZDRFDD;
            parameters[42].Value = model.N_ZDDXDD;
            parameters[43].Value = model.N_BCRFDD;
            parameters[44].Value = model.N_BCDXDD;
            parameters[45].Value = model.N_BCDYDD;
            parameters[46].Value = model.N_BCDSDD;
            parameters[47].Value = model.N_GGDD;
            parameters[48].Value = model.N_GJDD;
            parameters[49].Value = model.N_DJRFTY;
            parameters[50].Value = model.N_DJDXTY;
            parameters[51].Value = model.N_DJDSTY;
            parameters[52].Value = model.N_DJRFDZ;
            parameters[53].Value = model.N_DJDXDZ;
            parameters[54].Value = model.N_DJDSDZ;
            parameters[55].Value = model.N_DJRFDC;
            parameters[56].Value = model.N_DJDXDC;
            parameters[57].Value = model.N_DJDSDC;
            parameters[58].Value = model.N_DJRFDD;
            parameters[59].Value = model.N_DJDXDD;
            parameters[60].Value = model.N_DJDSDD;
            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddMB(KFB_SETUPMB model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPMB(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_SYTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_SYDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_SYDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddMQ(KFB_SETUPMQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPMQ(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_BCRFTY,:N_BCDXTY,:N_BCDYTY,:N_BCDSTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_BCRFDZ,:N_BCDXDZ,:N_BCDYDZ,:N_BCDSDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_BCRFDC,:N_BCDXDC,:N_BCDYDC,:N_BCDSDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_BCRFTY;
            parameters[8].Value = model.N_BCDXTY;
            parameters[9].Value = model.N_BCDYTY;
            parameters[10].Value = model.N_BCDSTY;
            parameters[11].Value = model.N_GGTY;
            parameters[12].Value = model.N_GJTY;
            parameters[13].Value = model.N_RFDZ;
            parameters[14].Value = model.N_DXDZ;
            parameters[15].Value = model.N_DYDZ;
            parameters[16].Value = model.N_DSDZ;
            parameters[17].Value = model.N_ZDRFDZ;
            parameters[18].Value = model.N_ZDDXDZ;
            parameters[19].Value = model.N_BCRFDZ;
            parameters[20].Value = model.N_BCDXDZ;
            parameters[21].Value = model.N_BCDYDZ;
            parameters[22].Value = model.N_BCDSDZ;
            parameters[23].Value = model.N_GGDZ;
            parameters[24].Value = model.N_GJDZ;
            parameters[25].Value = model.N_RFDC;
            parameters[26].Value = model.N_DXDC;
            parameters[27].Value = model.N_DYDC;
            parameters[28].Value = model.N_DSDC;
            parameters[29].Value = model.N_ZDRFDC;
            parameters[30].Value = model.N_ZDDXDC;
            parameters[31].Value = model.N_BCRFDC;
            parameters[32].Value = model.N_BCDXDC;
            parameters[33].Value = model.N_BCDYDC;
            parameters[34].Value = model.N_BCDSDC;
            parameters[35].Value = model.N_GGDC;
            parameters[36].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddRB(KFB_SETUPRB model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPRB(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_SYTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_SYDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_SYDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddSM(KFB_SETUPSM model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPSM(");
            strSql.Append("N_HYDH,N_DYTY,N_WZTY,N_LYTY,N_WZQTY,N_DYDZ,N_WZDZ,N_LYDZ,N_WZQDZ,N_DYDC,N_WZDC,N_LYDC,N_WZQDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYDH,:N_DYTY,:N_WZTY,:N_LYTY,:N_WZQTY,:N_DYDZ,:N_WZDZ,:N_LYDZ,:N_WZQDZ,:N_DYDC,:N_WZDC,:N_LYDC,:N_WZQDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_DYTY;
            parameters[2].Value = model.N_WZTY;
            parameters[3].Value = model.N_LYTY;
            parameters[4].Value = model.N_WZQTY;
            parameters[5].Value = model.N_DYDZ;
            parameters[6].Value = model.N_WZDZ;
            parameters[7].Value = model.N_LYDZ;
            parameters[8].Value = model.N_WZQDZ;
            parameters[9].Value = model.N_DYDC;
            parameters[10].Value = model.N_WZDC;
            parameters[11].Value = model.N_LYDC;
            parameters[12].Value = model.N_WZQDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddTB(KFB_SETUPTB model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPTB(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_SYTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_SYDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_SYDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddZQ(KFB_SETUPZQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPZQ(");
            strSql.Append("N_HYZH,N_ARFTY,N_ADXTY,N_ADYTY,N_ADSTY,N_AZDRFTY,N_AZDDXTY,N_ABCRFTY,N_ABCDXTY,N_ABCDYTY,N_ARQSTY,N_ABDTY,N_ABQCTY,N_AGGTY,N_AGJTY,N_BRFTY,N_BDXTY,N_BDYTY,N_BDSTY,N_BZDRFTY,N_BZDDXTY,N_BBCRFTY,N_BBCDXTY,N_BBCDYTY,N_BRQSTY,N_BBDTY,N_BBQCTY,N_BGGTY,N_BGJTY,N_CRFTY,N_CDXTY,N_CDYTY,N_CDSTY,N_CZDRFTY,N_CZDDXTY,N_CBCRFTY,N_CBCDXTY,N_CBCDYTY,N_CRQSTY,N_CBDTY,N_CBQCTY,N_CGGTY,N_CGJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_RQSDZ,N_BDDZ,N_BQCDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_RQSDC,N_BDDC,N_BQCDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_ARFTY,:N_ADXTY,:N_ADYTY,:N_ADSTY,:N_AZDRFTY,:N_AZDDXTY,:N_ABCRFTY,:N_ABCDXTY,:N_ABCDYTY,:N_ARQSTY,:N_ABDTY,:N_ABQCTY,:N_AGGTY,:N_AGJTY,:N_BRFTY,:N_BDXTY,:N_BDYTY,:N_BDSTY,:N_BZDRFTY,:N_BZDDXTY,:N_BBCRFTY,:N_BBCDXTY,:N_BBCDYTY,:N_BRQSTY,:N_BBDTY,:N_BBQCTY,:N_BGGTY,:N_BGJTY,:N_CRFTY,:N_CDXTY,:N_CDYTY,:N_CDSTY,:N_CZDRFTY,:N_CZDDXTY,:N_CBCRFTY,:N_CBCDXTY,:N_CBCDYTY,:N_CRQSTY,:N_CBDTY,:N_CBQCTY,:N_CGGTY,:N_CGJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_BCRFDZ,:N_BCDXDZ,:N_BCDYDZ,:N_RQSDZ,:N_BDDZ,:N_BQCDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_BCRFDC,:N_BCDXDC,:N_BCDYDC,:N_RQSDC,:N_BDDC,:N_BQCDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_ARFTY", OracleType.Float,22),
					new OracleParameter(":N_ADXTY", OracleType.Float,22),
					new OracleParameter(":N_ADYTY", OracleType.Float,22),
					new OracleParameter(":N_ADSTY", OracleType.Float,22),
					new OracleParameter(":N_AZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_AZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_ABCRFTY", OracleType.Float,22),
					new OracleParameter(":N_ABCDXTY", OracleType.Float,22),
					new OracleParameter(":N_ABCDYTY", OracleType.Float,22),
					new OracleParameter(":N_ARQSTY", OracleType.Float,22),
					new OracleParameter(":N_ABDTY", OracleType.Float,22),
					new OracleParameter(":N_ABQCTY", OracleType.Float,22),
					new OracleParameter(":N_AGGTY", OracleType.Float,22),
					new OracleParameter(":N_AGJTY", OracleType.Float,22),
					new OracleParameter(":N_BRFTY", OracleType.Float,22),
					new OracleParameter(":N_BDXTY", OracleType.Float,22),
					new OracleParameter(":N_BDYTY", OracleType.Float,22),
					new OracleParameter(":N_BDSTY", OracleType.Float,22),
					new OracleParameter(":N_BZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_BZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_BBCRFTY", OracleType.Float,22),
					new OracleParameter(":N_BBCDXTY", OracleType.Float,22),
					new OracleParameter(":N_BBCDYTY", OracleType.Float,22),
					new OracleParameter(":N_BRQSTY", OracleType.Float,22),
					new OracleParameter(":N_BBDTY", OracleType.Float,22),
					new OracleParameter(":N_BBQCTY", OracleType.Float,22),
					new OracleParameter(":N_BGGTY", OracleType.Float,22),
					new OracleParameter(":N_BGJTY", OracleType.Float,22),
					new OracleParameter(":N_CRFTY", OracleType.Float,22),
					new OracleParameter(":N_CDXTY", OracleType.Float,22),
					new OracleParameter(":N_CDYTY", OracleType.Float,22),
					new OracleParameter(":N_CDSTY", OracleType.Float,22),
					new OracleParameter(":N_CZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_CZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_CBCRFTY", OracleType.Float,22),
					new OracleParameter(":N_CBCDXTY", OracleType.Float,22),
					new OracleParameter(":N_CBCDYTY", OracleType.Float,22),
					new OracleParameter(":N_CRQSTY", OracleType.Float,22),
					new OracleParameter(":N_CBDTY", OracleType.Float,22),
					new OracleParameter(":N_CBQCTY", OracleType.Float,22),
					new OracleParameter(":N_CGGTY", OracleType.Float,22),
					new OracleParameter(":N_CGJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCRFDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDXDZ", OracleType.Float,22),
					new OracleParameter(":N_BCDYDZ", OracleType.Float,22),
					new OracleParameter(":N_RQSDZ", OracleType.Float,22),
					new OracleParameter(":N_BDDZ", OracleType.Float,22),
					new OracleParameter(":N_BQCDZ", OracleType.Float,22),
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
					new OracleParameter(":N_RQSDC", OracleType.Float,22),
					new OracleParameter(":N_BDDC", OracleType.Float,22),
					new OracleParameter(":N_BQCDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_ARFTY;
            parameters[2].Value = model.N_ADXTY;
            parameters[3].Value = model.N_ADYTY;
            parameters[4].Value = model.N_ADSTY;
            parameters[5].Value = model.N_AZDRFTY;
            parameters[6].Value = model.N_AZDDXTY;
            parameters[7].Value = model.N_ABCRFTY;
            parameters[8].Value = model.N_ABCDXTY;
            parameters[9].Value = model.N_ABCDYTY;
            parameters[10].Value = model.N_ARQSTY;
            parameters[11].Value = model.N_ABDTY;
            parameters[12].Value = model.N_ABQCTY;
            parameters[13].Value = model.N_AGGTY;
            parameters[14].Value = model.N_AGJTY;
            parameters[15].Value = model.N_BRFTY;
            parameters[16].Value = model.N_BDXTY;
            parameters[17].Value = model.N_BDYTY;
            parameters[18].Value = model.N_BDSTY;
            parameters[19].Value = model.N_BZDRFTY;
            parameters[20].Value = model.N_BZDDXTY;
            parameters[21].Value = model.N_BBCRFTY;
            parameters[22].Value = model.N_BBCDXTY;
            parameters[23].Value = model.N_BBCDYTY;
            parameters[24].Value = model.N_BRQSTY;
            parameters[25].Value = model.N_BBDTY;
            parameters[26].Value = model.N_BBQCTY;
            parameters[27].Value = model.N_BGGTY;
            parameters[28].Value = model.N_BGJTY;
            parameters[29].Value = model.N_CRFTY;
            parameters[30].Value = model.N_CDXTY;
            parameters[31].Value = model.N_CDYTY;
            parameters[32].Value = model.N_CDSTY;
            parameters[33].Value = model.N_CZDRFTY;
            parameters[34].Value = model.N_CZDDXTY;
            parameters[35].Value = model.N_CBCRFTY;
            parameters[36].Value = model.N_CBCDXTY;
            parameters[37].Value = model.N_CBCDYTY;
            parameters[38].Value = model.N_CRQSTY;
            parameters[39].Value = model.N_CBDTY;
            parameters[40].Value = model.N_CBQCTY;
            parameters[41].Value = model.N_CGGTY;
            parameters[42].Value = model.N_CGJTY;
            parameters[43].Value = model.N_RFDZ;
            parameters[44].Value = model.N_DXDZ;
            parameters[45].Value = model.N_DYDZ;
            parameters[46].Value = model.N_DSDZ;
            parameters[47].Value = model.N_ZDRFDZ;
            parameters[48].Value = model.N_ZDDXDZ;
            parameters[49].Value = model.N_BCRFDZ;
            parameters[50].Value = model.N_BCDXDZ;
            parameters[51].Value = model.N_BCDYDZ;
            parameters[52].Value = model.N_RQSDZ;
            parameters[53].Value = model.N_BDDZ;
            parameters[54].Value = model.N_BQCDZ;
            parameters[55].Value = model.N_GGDZ;
            parameters[56].Value = model.N_GJDZ;
            parameters[57].Value = model.N_RFDC;
            parameters[58].Value = model.N_DXDC;
            parameters[59].Value = model.N_DYDC;
            parameters[60].Value = model.N_DSDC;
            parameters[61].Value = model.N_ZDRFDC;
            parameters[62].Value = model.N_ZDDXDC;
            parameters[63].Value = model.N_BCRFDC;
            parameters[64].Value = model.N_BCDXDC;
            parameters[65].Value = model.N_BCDYDC;
            parameters[66].Value = model.N_RQSDC;
            parameters[67].Value = model.N_BDDC;
            parameters[68].Value = model.N_BQCDC;
            parameters[69].Value = model.N_GGDC;
            parameters[70].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddZS(KFB_SETUPZS model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPZS(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_BDTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_BDDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_BDDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_SYTY,:N_BDTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_SYDZ,:N_BDDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_SYDC,:N_BDDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_BDTY;
            parameters[9].Value = model.N_GGTY;
            parameters[10].Value = model.N_GJTY;
            parameters[11].Value = model.N_RFDZ;
            parameters[12].Value = model.N_DXDZ;
            parameters[13].Value = model.N_DYDZ;
            parameters[14].Value = model.N_DSDZ;
            parameters[15].Value = model.N_ZDRFDZ;
            parameters[16].Value = model.N_ZDDXDZ;
            parameters[17].Value = model.N_SYDZ;
            parameters[18].Value = model.N_BDDZ;
            parameters[19].Value = model.N_GGDZ;
            parameters[20].Value = model.N_GJDZ;
            parameters[21].Value = model.N_RFDC;
            parameters[22].Value = model.N_DXDC;
            parameters[23].Value = model.N_DYDC;
            parameters[24].Value = model.N_DSDC;
            parameters[25].Value = model.N_ZDRFDC;
            parameters[26].Value = model.N_ZDDXDC;
            parameters[27].Value = model.N_SYDC;
            parameters[28].Value = model.N_BDDC;
            parameters[29].Value = model.N_GGDC;
            parameters[30].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddSS(KFB_SETUPSS model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPSS(");
            strSql.Append("N_HYDH,N_DYTY,N_DYDZ,N_DYDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYDH,:N_DYTY,:N_DYDZ,:N_DYDC)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYDH", OracleType.VarChar,100),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22)};
            parameters[0].Value = model.N_HYDH;
            parameters[1].Value = model.N_DYTY;
            parameters[2].Value = model.N_DYDZ;
            parameters[3].Value = model.N_DYDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddBQ(KFB_SETUPBQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPBQ(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_SYTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_SYDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_SYDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_SYTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_SYDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_SYDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_RFTY", OracleType.Float,22),
					new OracleParameter(":N_DXTY", OracleType.Float,22),
					new OracleParameter(":N_DYTY", OracleType.Float,22),
					new OracleParameter(":N_DSTY", OracleType.Float,22),
					new OracleParameter(":N_ZDRFTY", OracleType.Float,22),
					new OracleParameter(":N_ZDDXTY", OracleType.Float,22),
					new OracleParameter(":N_SYTY", OracleType.Float,22),
					new OracleParameter(":N_GGTY", OracleType.Float,22),
					new OracleParameter(":N_GJTY", OracleType.Float,22),
					new OracleParameter(":N_RFDZ", OracleType.Float,22),
					new OracleParameter(":N_DXDZ", OracleType.Float,22),
					new OracleParameter(":N_DYDZ", OracleType.Float,22),
					new OracleParameter(":N_DSDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDZ", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDZ", OracleType.Float,22),
					new OracleParameter(":N_SYDZ", OracleType.Float,22),
					new OracleParameter(":N_GGDZ", OracleType.Float,22),
					new OracleParameter(":N_GJDZ", OracleType.Float,22),
					new OracleParameter(":N_RFDC", OracleType.Float,22),
					new OracleParameter(":N_DXDC", OracleType.Float,22),
					new OracleParameter(":N_DYDC", OracleType.Float,22),
					new OracleParameter(":N_DSDC", OracleType.Float,22),
					new OracleParameter(":N_ZDRFDC", OracleType.Float,22),
					new OracleParameter(":N_ZDDXDC", OracleType.Float,22),
					new OracleParameter(":N_SYDC", OracleType.Float,22),
					new OracleParameter(":N_GGDC", OracleType.Float,22),
					new OracleParameter(":N_GJDC", OracleType.Float,22)
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_SYTY;
            parameters[8].Value = model.N_GGTY;
            parameters[9].Value = model.N_GJTY;
            parameters[10].Value = model.N_RFDZ;
            parameters[11].Value = model.N_DXDZ;
            parameters[12].Value = model.N_DYDZ;
            parameters[13].Value = model.N_DSDZ;
            parameters[14].Value = model.N_ZDRFDZ;
            parameters[15].Value = model.N_ZDDXDZ;
            parameters[16].Value = model.N_SYDZ;
            parameters[17].Value = model.N_GGDZ;
            parameters[18].Value = model.N_GJDZ;
            parameters[19].Value = model.N_RFDC;
            parameters[20].Value = model.N_DXDC;
            parameters[21].Value = model.N_DYDC;
            parameters[22].Value = model.N_DSDC;
            parameters[23].Value = model.N_ZDRFDC;
            parameters[24].Value = model.N_ZDDXDC;
            parameters[25].Value = model.N_SYDC;
            parameters[26].Value = model.N_GGDC;
            parameters[27].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddCQ(KFB_SETUPCQ model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_SETUPCQ(");
            strSql.Append("N_HYZH,N_RFTY,N_DXTY,N_DYTY,N_DSTY,N_ZDRFTY,N_ZDDXTY,N_BCRFTY,N_BCDXTY,N_BCDYTY,N_BCDSTY,N_GGTY,N_GJTY,N_RFDZ,N_DXDZ,N_DYDZ,N_DSDZ,N_ZDRFDZ,N_ZDDXDZ,N_BCRFDZ,N_BCDXDZ,N_BCDYDZ,N_BCDSDZ,N_GGDZ,N_GJDZ,N_RFDC,N_DXDC,N_DYDC,N_DSDC,N_ZDRFDC,N_ZDDXDC,N_BCRFDC,N_BCDXDC,N_BCDYDC,N_BCDSDC,N_GGDC,N_GJDC)");
            strSql.Append(" values (");
            strSql.Append(":N_HYZH,:N_RFTY,:N_DXTY,:N_DYTY,:N_DSTY,:N_ZDRFTY,:N_ZDDXTY,:N_BCRFTY,:N_BCDXTY,:N_BCDYTY,:N_BCDSTY,:N_GGTY,:N_GJTY,:N_RFDZ,:N_DXDZ,:N_DYDZ,:N_DSDZ,:N_ZDRFDZ,:N_ZDDXDZ,:N_BCRFDZ,:N_BCDXDZ,:N_BCDYDZ,:N_BCDSDZ,:N_GGDZ,:N_GJDZ,:N_RFDC,:N_DXDC,:N_DYDC,:N_DSDC,:N_ZDRFDC,:N_ZDDXDC,:N_BCRFDC,:N_BCDXDC,:N_BCDYDC,:N_BCDSDC,:N_GGDC,:N_GJDC)");
            OracleParameter[] parameters = {
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
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_RFTY;
            parameters[2].Value = model.N_DXTY;
            parameters[3].Value = model.N_DYTY;
            parameters[4].Value = model.N_DSTY;
            parameters[5].Value = model.N_ZDRFTY;
            parameters[6].Value = model.N_ZDDXTY;
            parameters[7].Value = model.N_BCRFTY;
            parameters[8].Value = model.N_BCDXTY;
            parameters[9].Value = model.N_BCDYTY;
            parameters[10].Value = model.N_BCDSTY;
            parameters[11].Value = model.N_GGTY;
            parameters[12].Value = model.N_GJTY;
            parameters[13].Value = model.N_RFDZ;
            parameters[14].Value = model.N_DXDZ;
            parameters[15].Value = model.N_DYDZ;
            parameters[16].Value = model.N_DSDZ;
            parameters[17].Value = model.N_ZDRFDZ;
            parameters[18].Value = model.N_ZDDXDZ;
            parameters[19].Value = model.N_BCRFDZ;
            parameters[20].Value = model.N_BCDXDZ;
            parameters[21].Value = model.N_BCDYDZ;
            parameters[22].Value = model.N_BCDSDZ;
            parameters[23].Value = model.N_GGDZ;
            parameters[24].Value = model.N_GJDZ;
            parameters[25].Value = model.N_RFDC;
            parameters[26].Value = model.N_DXDC;
            parameters[27].Value = model.N_DYDC;
            parameters[28].Value = model.N_DSDC;
            parameters[29].Value = model.N_ZDRFDC;
            parameters[30].Value = model.N_ZDDXDC;
            parameters[31].Value = model.N_BCRFDC;
            parameters[32].Value = model.N_BCDXDC;
            parameters[33].Value = model.N_BCDYDC;
            parameters[34].Value = model.N_BCDSDC;
            parameters[35].Value = model.N_GGDC;
            parameters[36].Value = model.N_GJDC;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddHYGL(KFB_HYGL model, Hashtable o_aHt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_HYGL(");
            strSql.Append("N_ID,N_HYZH,N_HYMM,N_HYMC,N_KYED,N_SYED,N_WXDJ,N_YXDL,N_YXXZ,N_DLSJ,N_YCXZ,N_DZXX,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_DLDH,N_LQTZ,N_MBTZ,N_RBTZ,N_ZQTZ,N_MZTZ,N_CWCS,N_XZSJ,N_HYIP,N_TBTZ,N_HYJR,N_ZSTZ,N_XGSJ,N_SMTZ,N_CPTZ,N_DLTTZ,N_LHCTZ,N_JCTZ,N_TOLLGATE,N_DZJDH,N_SSTZ,N_TKYZM,N_HBDM,N_DHHM,N_MAIL,N_QQ,N_DLZH,N_SFSW,N_BQTZ,N_CQTZ,N_SEX,N_BIRTHDAY,N_COUNTRY,N_ASK,N_ANSWER)");
            strSql.Append(" values (");
            strSql.Append("EXAMPLE_SEQ.nextval,:N_HYZH,:N_HYMM,:N_HYMC,:N_KYED,:N_SYED,:N_WXDJ,:N_YXDL,:N_YXXZ,:N_DLSJ,:N_YCXZ,:N_DZXX,:N_ZJDH,:N_DGDDH,:N_GDDH,:N_ZDLDH,:N_DLDH,:N_LQTZ,:N_MBTZ,:N_RBTZ,:N_ZQTZ,:N_MZTZ,:N_CWCS,:N_XZSJ,:N_HYIP,:N_TBTZ,:N_HYJR,:N_ZSTZ,:N_XGSJ,:N_SMTZ,:N_CPTZ,:N_DLTTZ,:N_LHCTZ,:N_JCTZ,:N_TOLLGATE,:N_DZJDH,:N_SSTZ,:N_TKYZM,:N_HBDM,:N_DHHM,:N_MAIL,:N_QQ,:N_DLZH,:N_SFSW,:N_BQTZ,:N_CQTZ,:N_SEX,:N_BIRTHDAY,:N_COUNTRY,:N_ASK,:N_ANSWER)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
					new OracleParameter(":N_HYMM", OracleType.VarChar,100),
					new OracleParameter(":N_HYMC", OracleType.VarChar,100),
					new OracleParameter(":N_KYED", OracleType.Float,22),
					new OracleParameter(":N_SYED", OracleType.Float,22),
					new OracleParameter(":N_WXDJ", OracleType.Number,4),
					new OracleParameter(":N_YXDL", OracleType.Number,4),
					new OracleParameter(":N_YXXZ", OracleType.Number,4),
					new OracleParameter(":N_DLSJ", OracleType.DateTime),
					new OracleParameter(":N_YCXZ", OracleType.Number,4),
					new OracleParameter(":N_DZXX", OracleType.Float,22),
					new OracleParameter(":N_ZJDH", OracleType.VarChar,100),
					new OracleParameter(":N_DGDDH", OracleType.VarChar,100),
					new OracleParameter(":N_GDDH", OracleType.VarChar,100),
					new OracleParameter(":N_ZDLDH", OracleType.VarChar,100),
					new OracleParameter(":N_DLDH", OracleType.VarChar,100),
					new OracleParameter(":N_LQTZ", OracleType.Number,4),
					new OracleParameter(":N_MBTZ", OracleType.Number,4),
					new OracleParameter(":N_RBTZ", OracleType.Number,4),
					new OracleParameter(":N_ZQTZ", OracleType.Number,4),
					new OracleParameter(":N_MZTZ", OracleType.Number,4),
					new OracleParameter(":N_CWCS", OracleType.Number,4),
					new OracleParameter(":N_XZSJ", OracleType.DateTime),
					new OracleParameter(":N_HYIP", OracleType.VarChar,100),
					new OracleParameter(":N_TBTZ", OracleType.Number,4),
					new OracleParameter(":N_HYJR", OracleType.DateTime),
					new OracleParameter(":N_ZSTZ", OracleType.Number,4),
					new OracleParameter(":N_XGSJ", OracleType.DateTime),
					new OracleParameter(":N_SMTZ", OracleType.Number,4),
					new OracleParameter(":N_CPTZ", OracleType.Number,4),
					new OracleParameter(":N_DLTTZ", OracleType.Number,4),
					new OracleParameter(":N_LHCTZ", OracleType.Number,4),
					new OracleParameter(":N_JCTZ", OracleType.Number,4),
					new OracleParameter(":n_tollgate", OracleType.Number,4),
					new OracleParameter(":N_DZJDH", OracleType.VarChar,100),
                    new OracleParameter(":N_SSTZ", OracleType.Number,4),
                    new OracleParameter(":N_TKYZM", OracleType.VarChar,100),
					new OracleParameter(":N_HBDM", OracleType.VarChar,6),
					new OracleParameter(":N_DHHM", OracleType.VarChar,50),
					new OracleParameter(":N_MAIL", OracleType.VarChar,50),
					new OracleParameter(":N_QQ", OracleType.VarChar,50),
                    new OracleParameter(":N_DLZH", OracleType.VarChar,100),
                    new OracleParameter(":N_SFSW", OracleType.VarChar,1),
                 new OracleParameter(":N_BQTZ", OracleType.Number,4),
                 new OracleParameter(":N_CQTZ", OracleType.Number,4),
                 new OracleParameter(":N_SEX", OracleType.Char,1),
                 new OracleParameter(":N_BIRTHDAY", OracleType.DateTime),
                 new OracleParameter(":N_COUNTRY", OracleType.VarChar,50),
                 new OracleParameter(":N_ASK", OracleType.VarChar,100),
                 new OracleParameter(":N_ANSWER", OracleType.VarChar,100)
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_HYMM;
            parameters[2].Value = model.N_HYMC;
            parameters[3].Value = model.N_KYED;
            parameters[4].Value = model.N_SYED;
            parameters[5].Value = model.N_WXDJ;
            parameters[6].Value = model.N_YXDL;
            parameters[7].Value = model.N_YXXZ;
            parameters[8].Value = model.N_DLSJ;
            parameters[9].Value = model.N_YCXZ;
            parameters[10].Value = model.N_DZXX;
            parameters[11].Value = model.N_ZJDH;
            parameters[12].Value = model.N_DGDDH;
            parameters[13].Value = model.N_GDDH;
            parameters[14].Value = model.N_ZDLDH;
            parameters[15].Value = model.N_DLDH;
            parameters[16].Value = model.N_LQTZ;
            parameters[17].Value = model.N_MBTZ;
            parameters[18].Value = model.N_RBTZ;
            parameters[19].Value = model.N_ZQTZ;
            parameters[20].Value = model.N_MZTZ;
            parameters[21].Value = model.N_CWCS;
            parameters[22].Value = model.N_XZSJ;
            parameters[23].Value = model.N_HYIP;
            parameters[24].Value = model.N_TBTZ;
            parameters[25].Value = model.N_HYJR;
            parameters[26].Value = model.N_ZSTZ;
            parameters[27].Value = model.N_XGSJ;
            parameters[28].Value = model.N_SMTZ;
            parameters[29].Value = model.N_CPTZ;
            parameters[30].Value = model.N_DLTTZ;
            parameters[31].Value = model.N_LHCTZ;
            parameters[32].Value = model.N_JCTZ;
            parameters[33].Value = model.N_TOLLGATE;
            parameters[34].Value = model.N_DZJDH;
            parameters[35].Value = model.N_SSTZ;
            parameters[36].Value = model.N_TKYZM;
            parameters[37].Value = model.N_HBDM;
            parameters[38].Value = model.N_DHHM;
            parameters[39].Value = model.N_MAIL;
            parameters[40].Value = model.N_QQ;
            parameters[41].Value = model.N_DLZH;
            parameters[42].Value = model.N_SFSW;
            parameters[43].Value = model.N_BQTZ;
            parameters[44].Value = model.N_CQTZ;
            parameters[45].Value = model.N_SEX;
            parameters[46].Value = model.N_BIRTHDAY;
            parameters[47].Value = model.N_COUNTRY;
            parameters[48].Value = model.N_ASK;
            parameters[49].Value = model.N_ANSWER;


            o_aHt.Add(strSql.ToString(), parameters);
        }
       
        /// <summary>
        /// 執行事物
        /// </summary>
        /// <param name="o_aHt"></param>
        public void SetTran(Hashtable o_aHt)
        {
            DbHelperOra.ExecuteSqlTran(o_aHt);
        }
    }
