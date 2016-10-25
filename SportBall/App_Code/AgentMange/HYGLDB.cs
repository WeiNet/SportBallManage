using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections;
using KingOfBall;


    /// <summary>
    /// 数据访问类KFB_HYGL。
    /// </summary>
    public class KFB_HYGLDB
    {
        public KFB_HYGLDB()
        { }
        public KFB_HYGLDB(string s_UserID)
        {
            DbHelperOra.strUserID = s_UserID;
        }

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="s_aUser">帐号</param>
        /// <param name="s_aPassWord">新密码</param>
        public void UpdateMM(string s_aUser, string s_aPassWord)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE KFB_HYGL SET N_HYMM=:N_HYMM");

            strSql.Append(" WHERE N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                    new OracleParameter(":N_HYMM", OracleType.VarChar,100)
                };
            parameters[0].Value = s_aUser;
            parameters[1].Value = s_aPassWord;
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        public int UpdateMn(string s_aUser, string strmn, string strtype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE KFB_HYGL ");

            if (strtype.Equals("+"))
            {
                strSql.Append("  SET N_SYED=N_SYED+" + strmn + "");
                strSql.Append(" WHERE N_HYZH=:N_HYZH AND N_SYED+" + strmn + ">=0");
            }
            else if (strtype.Equals("-"))
            {
                strSql.Append(" SET N_SYED=N_SYED-" + strmn + "");
                strSql.Append(" WHERE N_HYZH=:N_HYZH AND N_SYED-" + strmn + ">=0");
            }

            OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100)
                };
            parameters[0].Value = s_aUser;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 转账额度变化记录
        /// </summary>
        /// <param name="n_id"></param>
        /// <param name="n_date"></param>
        /// <param name="n_type"></param>
        /// <param name="n_uid"></param>
        /// <param name="n_creditbefer"></param>
        /// <param name="n_creitafter"></param>
        public void InsertCreditLog(string n_type, string n_uid, decimal n_creditbefer, decimal n_creitafter)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into kfb_hycreditlog(n_id, n_date, n_type, n_uid, n_creditbefer, n_creitafter) ");
            strSql.Append("values(example_seq.nextval, sysdate, :n_type, :n_uid, :n_creditbefer, :n_creitafter)");
            OracleParameter[] parameters = {
					new OracleParameter(":n_type", OracleType.Char,1),
					new OracleParameter(":n_uid", OracleType.VarChar,50),
					new OracleParameter(":n_creditbefer", OracleType.Number),
					new OracleParameter(":n_creitafter", OracleType.Number)
            };
            parameters[0].Value = n_type;
            parameters[1].Value = n_uid;
            parameters[2].Value = n_creditbefer;
            parameters[3].Value = n_creitafter;
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        //會員
        public bool IsLoginhy(string strUserID, string strPassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM kfb_hygl");
            strSql.Append(" WHERE n_hyzh=:USERID");
            strSql.Append(" and  n_hymm=:USER_PASSWORD");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.VarChar,100),
                    new OracleParameter(":USER_PASSWORD", OracleType.VarChar,100)
				};
            parameters[0].Value = strUserID;
            parameters[1].Value = strPassWord;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改危险等级
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dangerous"></param>
        public void ModifyMember(string userId, KFB_HYGL memberInfo)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE KFB_HYGL SET N_WXDJ=:N_WXDJ,");
            strSql.Append(" N_ZQTZ=:N_ZQTZ ");
            strSql.Append(" WHERE N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
                    new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                    new OracleParameter(":N_WXDJ", OracleType.Int32),
                    new OracleParameter(":N_ZQTZ", OracleType.Int32)
                };
            parameters[0].Value = userId;
            parameters[1].Value = memberInfo.N_WXDJ;
            parameters[2].Value = memberInfo.N_ZQTZ;
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KFB_HYGL");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100)};
            parameters[0].Value = N_HYZH;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KFB_HYGL model, Hashtable o_aHt)
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
        /// 更新一条数据
        /// </summary>
        public int Update(KFB_HYGL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_HYGL set ");
            strSql.Append("N_HYMC=:N_HYMC,");
            strSql.Append("N_HBDM=:N_HBDM,");
            strSql.Append("N_DHHM=:N_DHHM,");
            strSql.Append("N_MAIL=:N_MAIL,");
            strSql.Append("N_QQ=:N_QQ, ");
            strSql.Append("N_SQZT=:N_SQZT ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                    new OracleParameter(":N_HYMC", OracleType.VarChar,100),
					new OracleParameter(":N_HBDM", OracleType.VarChar,6),
					new OracleParameter(":N_DHHM", OracleType.VarChar,50),
					new OracleParameter(":N_MAIL", OracleType.VarChar,50),
					new OracleParameter(":N_QQ", OracleType.VarChar,50),
                    new OracleParameter(":N_SQZT", OracleType.VarChar,1)
            };
            parameters[0].Value = model.N_HYZH;
            parameters[1].Value = model.N_HYMC;
            parameters[2].Value = model.N_HBDM;
            parameters[3].Value = model.N_DHHM;
            parameters[4].Value = model.N_MAIL;
            parameters[5].Value = model.N_QQ;
            parameters[6].Value = model.N_SQZT;

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string N_HYZH, Hashtable o_aHt)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete KFB_HYGL ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100)};
            parameters[0].Value = N_HYZH;

            o_aHt.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体试试
        /// </summary>
        public KFB_HYGL GetModel(string N_HYZH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from KFB_HYGL ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100)};
            parameters[0].Value = N_HYZH;

            KFB_HYGL model = new KFB_HYGL();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["N_ID"].ToString() != "")
                {
                    model.N_ID = int.Parse(ds.Tables[0].Rows[0]["N_ID"].ToString());
                }
                model.N_HYZH = ds.Tables[0].Rows[0]["N_HYZH"].ToString();
                model.N_HYMM = ds.Tables[0].Rows[0]["N_HYMM"].ToString();
                model.N_HYMC = ds.Tables[0].Rows[0]["N_HYMC"].ToString();
                if (ds.Tables[0].Rows[0]["N_KYED"].ToString() != "")
                {
                    model.N_KYED = decimal.Parse(ds.Tables[0].Rows[0]["N_KYED"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SYED"].ToString() != "")
                {
                    model.N_SYED = decimal.Parse(ds.Tables[0].Rows[0]["N_SYED"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_WXDJ"].ToString() != "")
                {
                    model.N_WXDJ = int.Parse(ds.Tables[0].Rows[0]["N_WXDJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YXDL"].ToString() != "")
                {
                    model.N_YXDL = int.Parse(ds.Tables[0].Rows[0]["N_YXDL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YXXZ"].ToString() != "")
                {
                    model.N_YXXZ = int.Parse(ds.Tables[0].Rows[0]["N_YXXZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DLSJ"].ToString() != "")
                {
                    model.N_DLSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_DLSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_YCXZ"].ToString() != "")
                {
                    model.N_YCXZ = int.Parse(ds.Tables[0].Rows[0]["N_YCXZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DZXX"].ToString() != "")
                {
                    model.N_DZXX = decimal.Parse(ds.Tables[0].Rows[0]["N_DZXX"].ToString());
                }
                model.N_DZJDH = ds.Tables[0].Rows[0]["N_DZJDH"].ToString();
                model.N_ZJDH = ds.Tables[0].Rows[0]["N_ZJDH"].ToString();
                model.N_DGDDH = ds.Tables[0].Rows[0]["N_DGDDH"].ToString();
                model.N_GDDH = ds.Tables[0].Rows[0]["N_GDDH"].ToString();
                model.N_ZDLDH = ds.Tables[0].Rows[0]["N_ZDLDH"].ToString();
                model.N_DLDH = ds.Tables[0].Rows[0]["N_DLDH"].ToString();
                if (ds.Tables[0].Rows[0]["N_LQTZ"].ToString() != "")
                {
                    model.N_LQTZ = int.Parse(ds.Tables[0].Rows[0]["N_LQTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_MBTZ"].ToString() != "")
                {
                    model.N_MBTZ = int.Parse(ds.Tables[0].Rows[0]["N_MBTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_RBTZ"].ToString() != "")
                {
                    model.N_RBTZ = int.Parse(ds.Tables[0].Rows[0]["N_RBTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZQTZ"].ToString() != "")
                {
                    model.N_ZQTZ = int.Parse(ds.Tables[0].Rows[0]["N_ZQTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_MZTZ"].ToString() != "")
                {
                    model.N_MZTZ = int.Parse(ds.Tables[0].Rows[0]["N_MZTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_CWCS"].ToString() != "")
                {
                    model.N_CWCS = int.Parse(ds.Tables[0].Rows[0]["N_CWCS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_XZSJ"].ToString() != "")
                {
                    model.N_XZSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_XZSJ"].ToString());
                }
                model.N_HYIP = ds.Tables[0].Rows[0]["N_HYIP"].ToString();
                if (ds.Tables[0].Rows[0]["N_TBTZ"].ToString() != "")
                {
                    model.N_TBTZ = int.Parse(ds.Tables[0].Rows[0]["N_TBTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_HYJR"].ToString() != "")
                {
                    model.N_HYJR = DateTime.Parse(ds.Tables[0].Rows[0]["N_HYJR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZSTZ"].ToString() != "")
                {
                    model.N_ZSTZ = int.Parse(ds.Tables[0].Rows[0]["N_ZSTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_XGSJ"].ToString() != "")
                {
                    model.N_XGSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_XGSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SMTZ"].ToString() != "")
                {
                    model.N_SMTZ = int.Parse(ds.Tables[0].Rows[0]["N_SMTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_CPTZ"].ToString() != "")
                {
                    model.N_CPTZ = int.Parse(ds.Tables[0].Rows[0]["N_CPTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_DLTTZ"].ToString() != "")
                {
                    model.N_DLTTZ = int.Parse(ds.Tables[0].Rows[0]["N_DLTTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_LHCTZ"].ToString() != "")
                {
                    model.N_LHCTZ = int.Parse(ds.Tables[0].Rows[0]["N_LHCTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_JCTZ"].ToString() != "")
                {
                    model.N_JCTZ = int.Parse(ds.Tables[0].Rows[0]["N_JCTZ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_TOLLGATE"].ToString() != "")
                {
                    model.N_TOLLGATE = int.Parse(ds.Tables[0].Rows[0]["N_TOLLGATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_ZJXZSJ"].ToString() != "")
                {
                    model.N_ZJXZSJ = DateTime.Parse(ds.Tables[0].Rows[0]["N_ZJXZSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_SSTZ"].ToString() != "")
                {
                    model.N_SSTZ = int.Parse(ds.Tables[0].Rows[0]["N_SSTZ"].ToString());
                }

                if (ds.Tables[0].Rows[0]["N_BQTZ"].ToString() != "")
                {
                    model.N_BQTZ = int.Parse(ds.Tables[0].Rows[0]["N_BQTZ"].ToString());
                }

                if (ds.Tables[0].Rows[0]["N_CQTZ"].ToString() != "")
                {
                    model.N_CQTZ = int.Parse(ds.Tables[0].Rows[0]["N_CQTZ"].ToString());
                }

                model.N_TKYZM = ds.Tables[0].Rows[0]["N_TKYZM"].ToString();
                model.N_HBDM = ds.Tables[0].Rows[0]["N_HBDM"].ToString();
                model.N_DHHM = ds.Tables[0].Rows[0]["N_DHHM"].ToString();
                model.N_MAIL = ds.Tables[0].Rows[0]["N_MAIL"].ToString();
                model.N_QQ = ds.Tables[0].Rows[0]["N_QQ"].ToString();
                model.N_DLDH = ds.Tables[0].Rows[0]["N_DLDH"].ToString();
                model.N_SFSW = ds.Tables[0].Rows[0]["N_SFSW"].ToString();
                model.N_SQZT = ds.Tables[0].Rows[0]["N_SQZT"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到會員列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMM,N_HYMC,N_KYED,N_SYED,N_WXDJ,N_YXDL,N_YXXZ,N_DLSJ,N_YCXZ,N_DZXX,N_DZJDH,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_DLDH,N_LQTZ,N_MBTZ,N_RBTZ,N_ZQTZ,N_MZTZ,N_CWCS,N_XZSJ,N_HYIP,N_TBTZ,N_HYJR,N_ZSTZ,N_XGSJ,N_SMTZ,N_CPTZ,N_DLTTZ,N_LHCTZ,N_JCTZ,N_TOLLGATE,N_SSTZ,N_DLDH,N_SFSW ");
            strSql.Append(" FROM KFB_HYGL ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,50)};
            parameters[0].Value = N_HYZH;
            return DbHelperOra.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到延時會員列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMM,N_HYMC,ROUND(N_KYED,0) AS N_KYED,ROUND(N_SYED,0) AS N_SYED,N_WXDJ,N_YXDL,N_YXXZ,N_DLSJ,N_YCXZ,N_DZXX,N_DZJDH,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_DLDH,N_LQTZ,N_MBTZ,N_RBTZ,N_ZQTZ,N_MZTZ,N_CWCS,N_XZSJ,N_HYIP,N_TBTZ,N_HYJR,N_ZSTZ,N_XGSJ,N_SMTZ,N_CPTZ,N_DLTTZ,N_LHCTZ,N_JCTZ,N_TOLLGATE,N_SSTZ,N_DLDH,N_SFSW ");
            strSql.Append(" FROM KFB_HYGL ");
            strSql.Append(" where n_ycxz>0 ORDER BY N_HYZH");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得会员账号
        /// </summary>
        public DataSet GetHYZH(string s_aDLS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID,N_HYZH,N_HYMM,N_HYMC,round(N_KYED) as N_KYED,round(N_SYED) as N_SYED,N_WXDJ,N_YXDL,N_YXXZ,N_DLSJ,N_YCXZ,N_DZXX,N_DZJDH,N_ZJDH,N_DGDDH,N_GDDH,N_ZDLDH,N_DLDH,N_LQTZ,N_MBTZ,N_RBTZ,N_ZQTZ,N_MZTZ,N_CWCS,N_XZSJ,N_HYIP,N_TBTZ,N_HYJR,N_ZSTZ,N_XGSJ,N_SMTZ,N_CPTZ,N_DLTTZ,N_LHCTZ,N_JCTZ,n_tollgate,N_SSTZ,N_DLDH,N_SFSW,N_SQZT ");
            strSql.Append(" FROM KFB_HYGL ");
            strSql.Append(" where n_dldh ='" + s_aDLS + "'");
            //strSql.Append(" ORDER BY N_ID");
            strSql.Append(" ORDER BY length(N_HYZH),N_HYZH");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得可用的会员账号
        /// </summary>
        public DataSet GetKYHYZH(string s_aDLS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_HYZH");
            strSql.Append(" FROM KFB_HYGL ");
            strSql.Append(" where n_dldh like '" + s_aDLS + "%'");
            strSql.Append(" ORDER BY N_ID");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得会员账号
        /// </summary>
        public DataSet GetHYDS(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append(" FROM KFB_HYGL ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100)
            };
            parameters[0].Value = N_HYZH;
            return DbHelperOra.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到大总监
        /// </summary>
        /// <returns></returns>
        public DataSet GetZJ()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT n_hyzh,n_hyzh||'['||n_hymc||']' as n_hymc ");
            strSql.Append(" FROM kfb_zhgl WHERE n_hydj=4 order by n_hyzh desc");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根據大总监得到代理商
        /// </summary>
        /// <returns></returns>
        public DataSet GetDZJ_DLS(string s_aZJZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT");
            strSql.Append(" (n_dzjdh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_dzjdh)||']-'||");
            strSql.Append(" n_zjdh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zjdh)||']-'||");
            strSql.Append(" n_dgddh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_dgddh)||']-'||");
            strSql.Append(" n_gddh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_gddh)||']-'||");
            strSql.Append(" n_zdldh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zdldh)||']-'||");
            strSql.Append(" n_hyzh||'['||n_hymc||']') as DLSName,");
            strSql.Append(" n_dzjdh||'-'||n_zjdh||'-'||n_dgddh||'-'||n_gddh||'-'||n_zdldh||'-'||n_hyzh as DLSID");
            strSql.Append(" from kfb_zhgl A where n_hydj = 9 and n_dzjdh = '" + s_aZJZH + "' order by DLSID desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根據总监得到代理商
        /// </summary>
        /// <returns></returns>
        public DataSet GetZJ_DLS(string s_aZJZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT");
            strSql.Append(" (n_zjdh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zjdh)||']-'||");
            strSql.Append(" n_dgddh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_dgddh)||']-'||");
            strSql.Append(" n_gddh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_gddh)||']-'||");
            strSql.Append(" n_zdldh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zdldh)||']-'||");
            strSql.Append(" n_hyzh||'['||n_hymc||']') as DLSName,");
            strSql.Append(" n_dzjdh||'-'||n_zjdh||'-'||n_dgddh||'-'||n_gddh||'-'||n_zdldh||'-'||n_hyzh as DLSID");
            strSql.Append(" from kfb_zhgl A where n_hydj = 9 and n_zjdh = '" + s_aZJZH + "' order by DLSID desc ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根據大股東得到代理商
        /// </summary>
        /// <param name="s_aZJZH"></param>
        /// <returns></returns>
        public DataSet GetDGD_DLS(string s_aZJZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT");
            strSql.Append(" (n_gddh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_gddh)||']-'||");
            strSql.Append(" n_zdldh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zdldh)||']-'||");
            strSql.Append(" n_hyzh||'['||n_hymc||']') as DLSName,");
            strSql.Append(" n_dzjdh||'-'||n_zjdh||'-'||n_dgddh||'-'||n_gddh||'-'||n_zdldh||'-'||n_hyzh as DLSID");
            strSql.Append(" from kfb_zhgl A where n_hydj = 9 and n_dgddh = '" + s_aZJZH + "' order by DLSID desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根據股東得到代理商
        /// </summary>
        /// <param name="s_aZJZH"></param>
        /// <returns></returns>
        public DataSet GetGD_DLS(string s_aZJZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT");
            strSql.Append(" (n_zdldh||'['||(select n_hymc from kfb_zhgl where n_hyzh =A.n_zdldh)||']-'||");
            strSql.Append(" n_hyzh||'['||n_hymc||']') as DLSName,");
            strSql.Append(" n_dzjdh||'-'||n_zjdh||'-'||n_dgddh||'-'||n_gddh||'-'||n_zdldh||'-'||n_hyzh as DLSID");
            strSql.Append(" from kfb_zhgl A where n_hydj = 9 and n_gddh = '" + s_aZJZH + "' order by DLSID desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根據代理得到代理商
        /// </summary>
        /// <param name="s_aZJZH"></param>
        /// <returns></returns>
        public DataSet GetZDL_DLS(string s_aZJZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT");
            strSql.Append(" (n_hyzh||'['||n_hymc||']') as DLSName,");
            strSql.Append(" n_dzjdh||'-'||n_zjdh||'-'||n_dgddh||'-'||n_gddh||'-'||n_zdldh||'-'||n_hyzh as DLSID");
            strSql.Append(" from kfb_zhgl A where n_hydj = 9 and n_zdldh = '" + s_aZJZH + "' order by DLSID desc ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根據代理得到代理商
        /// </summary>
        /// <param name="s_aZJZH"></param>
        /// <returns></returns>
        public DataSet GetDL_DLS(string s_aZJZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT (n_hyzh||'['||n_hymc||']') as DLSName,");
            strSql.Append(" n_dzjdh||'-'||n_zjdh||'-'||n_dgddh||'-'||n_gddh||'-'||n_zdldh||'-'||n_hyzh as DLSID");
            strSql.Append(" from kfb_zhgl A where n_hydj = 9 and n_dldh = '" + s_aZJZH + "' order by DLSID desc ");
            return DbHelperOra.Query(strSql.ToString());
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
        /// 得到會員所屬代理商的信用額度
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public float GetDLSED(string s_aDLS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_syed ");
            strSql.Append(" FROM kfb_zhgl ");
            strSql.Append(" where n_hyzh ='" + s_aDLS + "'");
            return Convert.ToSingle(DbHelperOra.GetSingle(strSql.ToString()));
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
        /// 判斷會員是否有注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetZD(string s_aHYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_ptzd ");
            strSql.Append(" where n_hydh ='" + s_aHYZH + "'");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 判斷會員是否有已過帳注單
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetOZD(string s_aHYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) ");
            strSql.Append(" FROM kfb_optzd ");
            strSql.Append(" where n_hydh ='" + s_aHYZH + "'");
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 取得会员的所有上级
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public DataSet GetSJ(string s_aHYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( select :n_hyzh AS NAME,'n_hydh' as id  FROM kfb_hygl where n_hyzh=:n_hyzh  ");
            strSql.Append(" union select n_dzjdh AS NAME,'n_dzjdh' as id  FROM kfb_hygl where n_hyzh=:n_hyzh  ");
            strSql.Append(" union select n_zjdh AS NAME,'n_zjdh' as id  FROM kfb_hygl where n_hyzh=:n_hyzh  ");
            strSql.Append(" union select n_dgddh AS NAME,'n_dgddh' as id  FROM kfb_hygl where n_hyzh=:n_hyzh  ");
            strSql.Append(" union select n_gddh AS NAME,'n_gddh' as id  FROM kfb_hygl where n_hyzh=:n_hyzh  ");
            strSql.Append(" union select n_zdldh AS NAME, 'n_zdldh' as id  FROM kfb_hygl where n_hyzh=:n_hyzh  ");
            strSql.Append(" union select n_dldh AS NAME,'n_dldh' as id  FROM kfb_hygl where n_hyzh=:n_hyzh  ");
            strSql.Append(" )  A ORDER BY A.NAME DESC");
            OracleParameter[] parameters = {
					new OracleParameter(":n_hyzh", OracleType.VarChar,100)};
            parameters[0].Value = s_aHYZH;
            return DbHelperOra.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 取得该会员的单场上限
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public int GetSX(string strhy, string strtb, string strcol)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select nvl(" + strcol + ",0)  from " + strtb + " where n_hydh='" + strhy + "'");
            return Convert.ToInt32(DbHelperOra.Query(strSql.ToString()).Tables[0].Rows[0][0]);
        }
        /// <summary>
        /// 取得该会员的单场上限单注上限
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public DataSet getSX(string strhy, string strtb, string strFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select nvl(n_" + strFlag + "dz,0) dz,nvl(n_" + strFlag + "dc,0) dc   from " + strtb + " where n_hydh='" + strhy + "'");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        ///  会员下注后扣掉對應的金額
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public void Delje(string strhy, string strje, Hashtable htab)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_syed=n_syed-(:strje/10000) ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                    new OracleParameter(":strje", OracleType.Number,8)
            };
            parameters[0].Value = strhy;
            parameters[1].Value = strje;
            htab.Add(parameters, strSql.ToString());
        }
        /// <summary>
        ///  会员下注后扣掉對應的金額及修改下注時間
        /// </summary>
        /// <param name="s_aDLS"></param>
        /// <returns></returns>
        public void Updje(string strhy, string strje, Hashtable htab)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_syed=n_syed-(:strje/10000),n_zjxzsj=sysdate ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                    new OracleParameter(":strje", OracleType.Number,8)
            };
            parameters[0].Value = strhy;
            parameters[1].Value = strje;
            htab.Add(parameters, strSql.ToString());
        }
        /// <summary>
        /// 重設剩餘額度
        /// </summary>
        public void ResetED()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_syed=n_kyed");
            DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 回收會員餘額
        /// </summary>
        /// <param name="N_HYZH"></param>
        public void HuiShouHYYE(string N_HYZH, Hashtable htab)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_syed=0,n_kyed=0");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100)
            };
            parameters[0].Value = N_HYZH;
            htab.Add(strSql, parameters);
        }
        /// <summary>
        /// 返回代理餘額
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="htab"></param>
        public void FanHuiDLYE(string N_HYZH, decimal N_KYED, Hashtable htab)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_zhgl set n_syed=n_syed+:N_SYED ");
            strSql.Append(" where N_HYZH=(select n_dldh from kfb_hygl where N_HYZH=:N_HYZH) ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_SYED", OracleType.Number,4),
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_KYED;
            htab.Add(strSql, parameters);
        }
        /// <summary>
        /// 修改会员登陆状态
        /// </summary>
        /// <param name="N_HYZH"></param>
        public void UPDYDL(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set N_XZSJ=:XZSJ,N_YXDL=:HYDL ");
            strSql.Append(" where N_HYZH=:N_HYZH ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":XZSJ", OracleType.DateTime),
                new OracleParameter(":HYDL", OracleType.Int32)
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = 0;
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 恢復會員餘額
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="htab"></param>
        public void HuiFuHYYE(string N_HYZH, decimal N_KYED)
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
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        public int UpdateYDED_CB(string N_HYZH, decimal N_ED)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set N_SYED=N_SYED-:N_ED ");
            strSql.Append(" where N_HYZH=:N_HYZH and (N_SYED-:N_ED>=0 or :N_ED<=0) ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_ED", OracleType.Number,4)
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_ED;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        public int UpdateED_CB(string N_HYZH, decimal N_ED)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_kyed=n_kyed-:N_ED ");
            strSql.Append(" where N_HYZH=:N_HYZH and (n_kyed-:N_ED>=0 or :N_ED<=0) ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_ED", OracleType.Number,4)
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_ED;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改我的錢包與真人遊戲錢包
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="N_ED"></param>
        public int UpdateEDAB(string N_HYZH, decimal N_ED)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_kyed=n_kyed-:N_ED,n_zrqb=n_zrqb+:N_ED ");
            strSql.Append(" where N_HYZH=:N_HYZH and (n_kyed-:N_ED>=0 or :N_ED<=0) ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_ED", OracleType.Number,4)
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_ED;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改我的錢包與運動遊戲錢包
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="N_ED"></param>
        public int UpdateEDAC(string N_HYZH, decimal N_ED)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(" update kfb_hygl set n_kyed=n_kyed-:N_ED,n_syed=n_syed+:N_ED,n_ydqb=n_ydqb+:N_ED ");
            strSql.Append(" update kfb_hygl set n_kyed=n_kyed-:N_ED,n_ydqb=n_ydqb+:N_ED ");
            strSql.Append(" where N_HYZH=:N_HYZH and (n_kyed-:N_ED>=0 or :N_ED<=0) and (n_syed+:N_ED>=0 or :N_ED>=0) ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_ED", OracleType.Number,4)
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_ED;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改真人遊戲錢包與運動遊戲錢包
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="N_ED"></param>
        public int UpdateEDBC(string N_HYZH, decimal N_ED)
        {
            StringBuilder strSql = new StringBuilder();
            // strSql.Append(" update kfb_hygl set n_zrqb=n_zrqb-:N_ED,n_syed=n_syed+:N_ED,n_ydqb=n_ydqb+:N_ED ");
            strSql.Append(" update kfb_hygl set n_zrqb=n_zrqb-:N_ED,n_ydqb=n_ydqb+:N_ED ");
            strSql.Append(" where N_HYZH=:N_HYZH and (n_syed+:N_ED>=0 or :N_ED>=0) ");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100),
                new OracleParameter(":N_ED", OracleType.Number,4)
            };
            parameters[0].Value = N_HYZH;
            parameters[1].Value = N_ED;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到會員額度
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <returns></returns>
        public DataSet getED(string N_HYZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_HYMC, N_KYED*10000 as N_KYED, N_SYED*10000 as N_SYED, N_ZRQB*10000 as N_ZRQB, N_YDQB*10000 as N_YDQB, N_SFSW ");
            strSql.Append(" FROM KFB_HYGL WHERE N_HYZH=:N_HYZH");
            OracleParameter[] parameters = {
		    	new OracleParameter(":N_HYZH", OracleType.VarChar,100)
            };
            parameters[0].Value = N_HYZH;
            return DbHelperOra.Query(strSql.ToString(), parameters);
        }
        //判斷?證碼
        public bool IsTKYZM(string strUserID, string strYZM)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM kfb_hygl");
            strSql.Append(" WHERE n_hyzh=:USERID");
            strSql.Append(" and  n_tkyzm=:USERTKZM");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.VarChar,100),
                    new OracleParameter(":USERTKZM", OracleType.VarChar,100)
				};
            parameters[0].Value = strUserID;
            parameters[1].Value = strYZM;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改會員?證碼
        /// </summary>
        /// <param name="s_aUser"></param>
        /// <param name="s_aPassWord"></param>
        public void UpdateTKYZM(string s_aUser, string s_aYZM)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_HYGL set n_tkyzm=:USERTKZM");
            strSql.Append(" WHERE n_hyzh=:USERID");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.VarChar,100),
                    new OracleParameter(":USERTKZM", OracleType.VarChar,100)
				};
            parameters[0].Value = s_aUser;
            parameters[1].Value = s_aYZM;
            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改我的錢包
        /// </summary>
        /// <param name="N_HYZH"></param>
        /// <param name="N_ED"></param>
        public void UpdateKYED(string N_HYZH, decimal N_ED, string strID, Hashtable o_hs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update kfb_hygl set n_kyed=n_kyed+:N_ED ");
            strSql.Append(" where N_HYZH='" + N_HYZH + "'");
            strSql.Append(" and '" + strID + "'='" + strID + "'");
            OracleParameter[] parameters = {
                new OracleParameter(":N_ED", OracleType.Number,4)
            };
            parameters[0].Value = N_ED;
            o_hs.Add(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 按日期和申??型查?获得代理资料
        /// </summary>
        public DataSet GetHYZH(string strdldh, string strrqs, string strrqe, string strlx, string strorder)
        {
            strrqs = strrqs.Equals("") ? "0000-00-00" : strrqs;
            strrqe = strrqe.Equals("") ? "9999-99-99" : strrqe;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" from KFB_HYGL ");
            strSql.Append(" where 1=1 ");
            strSql.Append(" and to_char(n_hyjr,'yyyy-MM-dd')>=:n_jrsjs ");
            strSql.Append(" and to_char(n_hyjr,'yyyy-MM-dd')<=:n_jrsje ");
            strSql.Append(" and n_sqzt in (" + strlx + ") ");
            strSql.Append(" and (n_dldh like :N_DLDH or :N_DLDH is null) ");
            if (strorder != "")
                strSql.Append(" order by " + strorder);
            OracleParameter[] parameters = {
                    new OracleParameter(":n_jrsjs", OracleType.VarChar,10),
                    new OracleParameter(":n_jrsje", OracleType.VarChar,10),
                    new OracleParameter(":N_DLDH", OracleType.VarChar,100)
				};
            parameters[0].Value = strrqs;
            parameters[1].Value = strrqe;
            parameters[2].Value = strdldh;
            return KingOfBall.DbHelperOra.Query(strSql.ToString(), parameters);
        }

        public string IsMail(string strMail)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(n_id) as num　from kfb_hygl where n_mail=:n_mail");
            OracleParameter[] parameters = {
                    new OracleParameter(":n_mail", OracleType.VarChar,50)
				};
            parameters[0].Value = strMail;
            return KingOfBall.DbHelperOra.GetSingle(strSql.ToString(), parameters).ToString();
        }
        /// <summary>
        /// 更改用户的下注状态
        /// </summary>
        /// <param name="strUserID">用户账号</param>
        /// <param name="iBetState">下注状态</param>
        /// <returns></returns>
        public bool SetUserBetState(string strUserID, int iBetState)
        {
            string strSql = "UPDATE KFB_HYGL SET N_YXXZ=:N_YXXZ WHERE N_HYZH=:N_HYZH";
            OracleParameter[] parameters = {
                    new OracleParameter(":N_YXXZ", OracleType.Int32,4),
                    new OracleParameter(":N_HYZH", OracleType.VarChar,50)
				};
            parameters[0].Value = iBetState;
            parameters[1].Value = strUserID;
            try
            {
                KingOfBall.DbHelperOra.ExecuteSql(strSql, parameters);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 取得某个代理下左右会员的真人额度
        /// </summary>
        /// <param name="strAgent">代理账号</param>
        /// <returns>decimal</returns>
        public decimal GetAllMemAmountByAgent(string strAgent)
        {
            string strSql = "SELECT SUM(N_SYED) AS N_TOTAL FROM KFB_HYGL WHERE N_DLDH=:N_DLDH GROUP BY N_DLDH";
            OracleParameter[] parameters = {                    
                    new OracleParameter(":N_DLDH", OracleType.VarChar,50)
				};
            parameters[0].Value = strAgent;
            try
            {
                object obj = DbHelperOra.GetSingle(strSql, parameters);
                return obj == null ? 0 : decimal.Parse(obj.ToString()) * 10000;

            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 取得某个代理下所有会员的额度信息
        /// </summary>
        /// <param name="strAgent"></param>
        /// <returns></returns>
        public DataSet GetAllMemAmountInfoByAgent(string strAgent)
        {
            string strSql = "SELECT N_HYZH AS N_USERID,N_SYED*10000 AS N_TOTAL FROM KFB_HYGL WHERE N_DLDH=:N_DLDH";
            OracleParameter[] parameters = {                    
                    new OracleParameter(":N_DLDH", OracleType.VarChar,50)
				};
            parameters[0].Value = strAgent;
            DataSet ds = DbHelperOra.Query(strSql, parameters);
            return ds;

        }
        #endregion  成员方法
    }


