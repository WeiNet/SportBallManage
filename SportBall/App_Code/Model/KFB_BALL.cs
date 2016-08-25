using System;

    /// <summary>
    /// 实体类KFB_BASEBALL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class KFB_BALL
    {
        public KFB_BALL()
        { }
        #region Model
        private int _n_id;
        private int _n_matchid;
        private string _n_lx;
        private DateTime? _n_zwdate;
        private DateTime? _n_gamedate;
        private int? _n_lmno;
        private int? _n_visit;
        private int? _n_home;
        private string _n_visit_name;
        private string _n_home_name;
        private decimal? _n_visit_result;
        private decimal? _n_home_result;
        private string _n_tsa;
        private string _n_tsb;
        private int? _n_visit_no;
        private int? _n_home_no;
        private int? _n_sfzd;
        private int? _n_sfxz;
        private int? _n_xzzt;
        private int? _n_let;
        private int? _n_lock;
        private int? _n_vh;
        private int? _n_sf9j;
        private int? _n_sfds;
        private int? _n_sfgp;
        private decimal? _n_hydzsx;
        private decimal? _n_hydcsx;
        private int? _n_sfjzf;
        private int? _n_zbxh;

        private int? _n_cbxh;
        private decimal? _n_rffs;
        private int? _n_rflx;
        private int? _n_rfbl;
        private decimal? _n_lrfpl;
        private decimal? _n_rrfpl;
        private decimal? _n_lrfcj;
        private decimal? _n_rrfcj;
        private decimal? _n_lrfsx;
        private decimal? _n_rrfsx;
        private decimal? _n_rfcjje;
        private int? _n_rfcjfs;
        private decimal? _n_rfcjpl;
        private decimal? _n_dxfs;
        private int? _n_dxlx;
        private int? _n_dxbl;
        private decimal? _n_dxdpl;
        private decimal? _n_dxxpl;
        private decimal? _n_dxdcj;
        private decimal? _n_dxxcj;
        private decimal? _n_dxdcsx;
        private decimal? _n_ldxsx;
        private decimal? _n_rdxsx;
        private decimal? _n_dxcj;
        private decimal? _n_dxcjpl;
        private decimal? _n_ldypl;
        private decimal? _n_rdypl;
        private decimal? _n_ldycj;
        private decimal? _n_rdycj;
        private decimal? _n_ldysx;
        private decimal? _n_rdysx;
        private decimal? _n_dycj;
        private decimal? _n_dycjpl;
        private decimal? _n_lsypl;
        private decimal? _n_rsypl;
        private decimal? _n_lsycj;
        private decimal? _n_rsycj;
        private decimal? _n_lsysx;
        private decimal? _n_rsysx;
        private decimal? _n_sycj;
        private decimal? _n_sycjpl;
        private decimal? _n_dsdpl;
        private decimal? _n_dsspl;
        private decimal? _n_dsdcj;
        private decimal? _n_dsscj;
        private decimal? _n_dsdcsx;
        private decimal? _n_ldssx;
        private decimal? _n_rdssx;
        private decimal? _n_dscj;
        private decimal? _n_dscjpl;
        private decimal? _n_up_visit_result;
        private decimal? _n_up_home_result;
        private decimal? _n_visit_jzf;
        private decimal? _n_home_jzf;
        private string _n_zdtime;
        private string _n_zdflag;
        private DateTime? _n_zduptime;
        private int? _n_rf_open;
        private int? _n_dx_open;
        private int? _n_dy_open;
        private int? _n_sy_open;
        private int? _n_ds_open;
        private int? _n_rq_open;
        private int? _n_bd_open;
        private int? _n_bqc_open;
        private int? _n_rf_gg;
        private int? _n_dx_gg;
        private int? _n_dy_gg;
        private int? _n_sy_gg;
        private int? _n_ds_gg;
        private int? _n_rf_lock_v;
        private int? _n_rf_lock_h;
        private int? _n_dx_lock_v;
        private int? _n_dx_lock_h;
        private int? _n_dy_lock_v;
        private int? _n_dy_lock_h;
        private int? _n_sy_lock_v;
        private int? _n_sy_lock_h;
        private int? _n_ds_lock_v;
        private int? _n_ds_lock_h;

        private int _n_id2;
        private int? _n_let2;
        private int? _n_cbxh2;

        private int? _n_lmno2;
        private int? _n_visit2;
        private int? _n_home2;

        private decimal? _n_rffs2;
        private int? _n_rflx2;
        private int? _n_rfbl2;
        private decimal? _n_lrfpl2;
        private decimal? _n_rrfpl2;

        private decimal? _n_dxfs2;
        private int? _n_dxlx2;
        private int? _n_dxbl2;
        private decimal? _n_dxdpl2;
        private decimal? _n_dxxpl2;

        private decimal? _n_ldypl2;
        private decimal? _n_rdypl2;

        private decimal? _n_lsypl2;
        private decimal? _n_rsypl2;

        private decimal? _n_dsdpl2;
        private decimal? _n_dsspl2;

        private int? _n_rf_open2;
        private int? _n_dx_open2;
        private int? _n_dy_open2;
        private int? _n_sy_open2;
        private int? _n_ds_open2;

        private int? _n_rf_lock_v2;
        private int? _n_rf_lock_h2;
        private int? _n_dx_lock_v2;
        private int? _n_dx_lock_h2;
        private int? _n_dy_lock_v2;
        private int? _n_dy_lock_h2;
        private int? _n_sy_lock_v2;
        private int? _n_sy_lock_h2;
        private int? _n_ds_lock_v2;
        private int? _n_ds_lock_h2;

        private string _n_remark;
        private DateTime? _n_counttime;
        private string _n_sameteam;
        private int? _n_gzflag;
        private decimal? _n_rqspl01;
        private decimal? _n_rqspl23;
        private decimal? _n_rqspl46;
        private decimal? _n_rqspl7;
        private decimal? _n_rqssx;
        private decimal? _n_bdgpl00;
        private decimal? _n_bdzpl10;
        private decimal? _n_bdgpl11;
        private decimal? _n_bdzpl20;
        private decimal? _n_bdzpl21;
        private decimal? _n_bdgpl22;
        private decimal? _n_bdzpl30;
        private decimal? _n_bdzpl31;
        private decimal? _n_bdzpl32;
        private decimal? _n_bdgpl33;
        private decimal? _n_bdzpl41;
        private decimal? _n_bdzpl40;
        private decimal? _n_bdzpl42;
        private decimal? _n_bdzpl43;
        private decimal? _n_bdkpl10;
        private decimal? _n_bdkpl20;
        private decimal? _n_bdkpl21;
        private decimal? _n_bdkpl30;
        private decimal? _n_bdkpl31;
        private decimal? _n_bdkpl32;
        private decimal? _n_bdkpl40;
        private decimal? _n_bdkpl41;
        private decimal? _n_bdkpl42;
        private decimal? _n_bdkpl43;
        private decimal? _n_bdgpl44;
        private decimal? _n_bdzpl5;
        private decimal? _n_bdkpl5;
        private decimal? _n_bdsx;
        private decimal? _n_bqczz;
        private decimal? _n_bqczh;
        private decimal? _n_bqczk;
        private decimal? _n_bqchh;
        private decimal? _n_bqchz;
        private decimal? _n_bqchk;
        private decimal? _n_bqckk;
        private decimal? _n_bqckz;
        private decimal? _n_bqckh;
        private decimal? _n_bqcsx;
        private decimal? _n_hjpl;
        private decimal? _n_hjpl2;
        private decimal? _n_hjggcj;
        private decimal? _n_hjsx;
        private int? _n_samegame;
        private int? _n_visit_redcard;
        private int? _n_home_redcard;
        /// <summary>
        /// 
        /// </summary>
        public int N_ID
        {
            set { _n_id = value; }
            get { return _n_id; }
        }
        public int N_MATCHID
        {
            set { _n_matchid = value; }
            get { return _n_matchid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_LX
        {
            set { _n_lx = value; }
            get { return _n_lx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? N_ZWDATE
        {
            set { _n_zwdate = value; }
            get { return _n_zwdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? N_GAMEDATE
        {
            set { _n_gamedate = value; }
            get { return _n_gamedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_LMNO
        {
            set { _n_lmno = value; }
            get { return _n_lmno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_VISIT
        {
            set { _n_visit = value; }
            get { return _n_visit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_HOME
        {
            set { _n_home = value; }
            get { return _n_home; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_VISIT_NAME
        {
            set { _n_visit_name = value; }
            get { return _n_visit_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_HOME_NAME
        {
            set { _n_home_name = value; }
            get { return _n_home_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_VISIT_RESULT
        {
            set { _n_visit_result = value; }
            get { return _n_visit_result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HOME_RESULT
        {
            set { _n_home_result = value; }
            get { return _n_home_result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_TSA
        {
            set { _n_tsa = value; }
            get { return _n_tsa; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_TSB
        {
            set { _n_tsb = value; }
            get { return _n_tsb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_VISIT_NO
        {
            set { _n_visit_no = value; }
            get { return _n_visit_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_HOME_NO
        {
            set { _n_home_no = value; }
            get { return _n_home_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SFZD
        {
            set { _n_sfzd = value; }
            get { return _n_sfzd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SFXZ
        {
            set { _n_sfxz = value; }
            get { return _n_sfxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_XZZT
        {
            set { _n_xzzt = value; }
            get { return _n_xzzt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_LET
        {
            set { _n_let = value; }
            get { return _n_let; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_LOCK
        {
            set { _n_lock = value; }
            get { return _n_lock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_VH
        {
            set { _n_vh = value; }
            get { return _n_vh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SF9J
        {
            set { _n_sf9j = value; }
            get { return _n_sf9j; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SFDS
        {
            set { _n_sfds = value; }
            get { return _n_sfds; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SFGP
        {
            set { _n_sfgp = value; }
            get { return _n_sfgp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HYDZSX
        {
            set { _n_hydzsx = value; }
            get { return _n_hydzsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HYDCSX
        {
            set { _n_hydcsx = value; }
            get { return _n_hydcsx; }
        }
        /// <summary>
        /// 是否開放基準分
        /// </summary>
        public int? N_SFJZF
        {
            set { _n_sfjzf = value; }
            get { return _n_sfjzf; }
        }
        /// <summary>
        /// 直播名稱
        /// </summary>
        public int? N_ZBXH
        {
            set { _n_zbxh = value; }
            get { return _n_zbxh; }
        }

        /// <summary>
        /// 場別
        /// </summary>
        public int? N_CBXH
        {
            set { _n_cbxh = value; }
            get { return _n_cbxh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RFFS
        {
            set { _n_rffs = value; }
            get { return _n_rffs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RFLX
        {
            set { _n_rflx = value; }
            get { return _n_rflx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RFBL
        {
            set { _n_rfbl = value; }
            get { return _n_rfbl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LRFPL
        {
            set { _n_lrfpl = value; }
            get { return _n_lrfpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RRFPL
        {
            set { _n_rrfpl = value; }
            get { return _n_rrfpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LRFCJ
        {
            set { _n_lrfcj = value; }
            get { return _n_lrfcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RRFCJ
        {
            set { _n_rrfcj = value; }
            get { return _n_rrfcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LRFSX
        {
            set { _n_lrfsx = value; }
            get { return _n_lrfsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RRFSX
        {
            set { _n_rrfsx = value; }
            get { return _n_rrfsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RFCJJE
        {
            set { _n_rfcjje = value; }
            get { return _n_rfcjje; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RFCJFS
        {
            set { _n_rfcjfs = value; }
            get { return _n_rfcjfs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RFCJPL
        {
            set { _n_rfcjpl = value; }
            get { return _n_rfcjpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXFS
        {
            set { _n_dxfs = value; }
            get { return _n_dxfs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DXLX
        {
            set { _n_dxlx = value; }
            get { return _n_dxlx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DXBL
        {
            set { _n_dxbl = value; }
            get { return _n_dxbl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXDPL
        {
            set { _n_dxdpl = value; }
            get { return _n_dxdpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXXPL
        {
            set { _n_dxxpl = value; }
            get { return _n_dxxpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXDCJ
        {
            set { _n_dxdcj = value; }
            get { return _n_dxdcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXXCJ
        {
            set { _n_dxxcj = value; }
            get { return _n_dxxcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXDCSX
        {
            set { _n_dxdcsx = value; }
            get { return _n_dxdcsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LDXSX
        {
            set { _n_ldxsx = value; }
            get { return _n_ldxsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RDXSX
        {
            set { _n_rdxsx = value; }
            get { return _n_rdxsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXCJ
        {
            set { _n_dxcj = value; }
            get { return _n_dxcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXCJPL
        {
            set { _n_dxcjpl = value; }
            get { return _n_dxcjpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LDYPL
        {
            set { _n_ldypl = value; }
            get { return _n_ldypl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RDYPL
        {
            set { _n_rdypl = value; }
            get { return _n_rdypl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LDYCJ
        {
            set { _n_ldycj = value; }
            get { return _n_ldycj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RDYCJ
        {
            set { _n_rdycj = value; }
            get { return _n_rdycj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LDYSX
        {
            set { _n_ldysx = value; }
            get { return _n_ldysx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RDYSX
        {
            set { _n_rdysx = value; }
            get { return _n_rdysx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DYCJ
        {
            set { _n_dycj = value; }
            get { return _n_dycj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DYCJPL
        {
            set { _n_dycjpl = value; }
            get { return _n_dycjpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LSYPL
        {
            set { _n_lsypl = value; }
            get { return _n_lsypl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RSYPL
        {
            set { _n_rsypl = value; }
            get { return _n_rsypl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LSYCJ
        {
            set { _n_lsycj = value; }
            get { return _n_lsycj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RSYCJ
        {
            set { _n_rsycj = value; }
            get { return _n_rsycj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LSYSX
        {
            set { _n_lsysx = value; }
            get { return _n_lsysx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RSYSX
        {
            set { _n_rsysx = value; }
            get { return _n_rsysx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_SYCJ
        {
            set { _n_sycj = value; }
            get { return _n_sycj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_SYCJPL
        {
            set { _n_sycjpl = value; }
            get { return _n_sycjpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSDPL
        {
            set { _n_dsdpl = value; }
            get { return _n_dsdpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSSPL
        {
            set { _n_dsspl = value; }
            get { return _n_dsspl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSDCJ
        {
            set { _n_dsdcj = value; }
            get { return _n_dsdcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSSCJ
        {
            set { _n_dsscj = value; }
            get { return _n_dsscj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSDCSX
        {
            set { _n_dsdcsx = value; }
            get { return _n_dsdcsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LDSSX
        {
            set { _n_ldssx = value; }
            get { return _n_ldssx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RDSSX
        {
            set { _n_rdssx = value; }
            get { return _n_rdssx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSCJ
        {
            set { _n_dscj = value; }
            get { return _n_dscj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSCJPL
        {
            set { _n_dscjpl = value; }
            get { return _n_dscjpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_UP_VISIT_RESULT
        {
            set { _n_up_visit_result = value; }
            get { return _n_up_visit_result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_UP_HOME_RESULT
        {
            set { _n_up_home_result = value; }
            get { return _n_up_home_result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_VISIT_JZF
        {
            set { _n_visit_jzf = value; }
            get { return _n_visit_jzf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HOME_JZF
        {
            set { _n_home_jzf = value; }
            get { return _n_home_jzf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_ZDTIME
        {
            set { _n_zdtime = value; }
            get { return _n_zdtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_ZDFLAG
        {
            set { _n_zdflag = value; }
            get { return _n_zdflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? N_ZDUPTIME
        {
            set { _n_zduptime = value; }
            get { return _n_zduptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RF_OPEN
        {
            set { _n_rf_open = value; }
            get { return _n_rf_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DX_OPEN
        {
            set { _n_dx_open = value; }
            get { return _n_dx_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DY_OPEN
        {
            set { _n_dy_open = value; }
            get { return _n_dy_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SY_OPEN
        {
            set { _n_sy_open = value; }
            get { return _n_sy_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DS_OPEN
        {
            set { _n_ds_open = value; }
            get { return _n_ds_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RQ_OPEN
        {
            set { _n_rq_open = value; }
            get { return _n_rq_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_BD_OPEN
        {
            set { _n_bd_open = value; }
            get { return _n_bd_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_BQC_OPEN
        {
            set { _n_bqc_open = value; }
            get { return _n_bqc_open; }
        }
        /// <summary>
        /// 讓分過關是否開放
        /// </summary>
        public int? N_RF_GG
        {
            set { _n_rf_gg = value; }
            get { return _n_rf_gg; }
        }
        /// <summary>
        /// 大小過關是否開放
        /// </summary>
        public int? N_DX_GG
        {
            set { _n_dx_gg = value; }
            get { return _n_dx_gg; }
        }
        /// <summary>
        /// 獨贏過關是否開放
        /// </summary>
        public int? N_DY_GG
        {
            set { _n_dy_gg = value; }
            get { return _n_dy_gg; }
        }
        /// <summary>
        /// 輸贏過關是否開放
        /// </summary>
        public int? N_SY_GG
        {
            set { _n_sy_gg = value; }
            get { return _n_sy_gg; }
        }
        /// <summary>
        /// 單雙過關是否開放
        /// </summary>
        public int? N_DS_GG
        {
            set { _n_ds_gg = value; }
            get { return _n_ds_gg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RF_LOCK_V
        {
            set { _n_rf_lock_v = value; }
            get { return _n_rf_lock_v; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RF_LOCK_H
        {
            set { _n_rf_lock_h = value; }
            get { return _n_rf_lock_h; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DX_LOCK_V
        {
            set { _n_dx_lock_v = value; }
            get { return _n_dx_lock_v; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DX_LOCK_H
        {
            set { _n_dx_lock_h = value; }
            get { return _n_dx_lock_h; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DY_LOCK_V
        {
            set { _n_dy_lock_v = value; }
            get { return _n_dy_lock_v; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DY_LOCK_H
        {
            set { _n_dy_lock_h = value; }
            get { return _n_dy_lock_h; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SY_LOCK_V
        {
            set { _n_sy_lock_v = value; }
            get { return _n_sy_lock_v; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SY_LOCK_H
        {
            set { _n_sy_lock_h = value; }
            get { return _n_sy_lock_h; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DS_LOCK_V
        {
            set { _n_ds_lock_v = value; }
            get { return _n_ds_lock_v; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DS_LOCK_H
        {
            set { _n_ds_lock_h = value; }
            get { return _n_ds_lock_h; }
        }


        /// <summary>
        /// 場別
        /// </summary>
        public int N_ID2
        {
            set { _n_id2 = value; }
            get { return _n_id2; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? N_LET2
        {
            set { _n_let2 = value; }
            get { return _n_let2; }
        }

        /// <summary>
        /// 場別
        /// </summary>
        public int? N_CBXH2
        {
            set { _n_cbxh2 = value; }
            get { return _n_cbxh2; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? N_LMNO2
        {
            set { _n_lmno2 = value; }
            get { return _n_lmno2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_VISIT2
        {
            set { _n_visit2 = value; }
            get { return _n_visit2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_HOME2
        {
            set { _n_home2 = value; }
            get { return _n_home2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RFFS2
        {
            set { _n_rffs2 = value; }
            get { return _n_rffs2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RFLX2
        {
            set { _n_rflx2 = value; }
            get { return _n_rflx2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RFBL2
        {
            set { _n_rfbl2 = value; }
            get { return _n_rfbl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LRFPL2
        {
            set { _n_lrfpl2 = value; }
            get { return _n_lrfpl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RRFPL2
        {
            set { _n_rrfpl2 = value; }
            get { return _n_rrfpl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXFS2
        {
            set { _n_dxfs2 = value; }
            get { return _n_dxfs2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DXLX2
        {
            set { _n_dxlx2 = value; }
            get { return _n_dxlx2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DXBL2
        {
            set { _n_dxbl2 = value; }
            get { return _n_dxbl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXDPL2
        {
            set { _n_dxdpl2 = value; }
            get { return _n_dxdpl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DXXPL2
        {
            set { _n_dxxpl2 = value; }
            get { return _n_dxxpl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LDYPL2
        {
            set { _n_ldypl2 = value; }
            get { return _n_ldypl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RDYPL2
        {
            set { _n_rdypl2 = value; }
            get { return _n_rdypl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_LSYPL2
        {
            set { _n_lsypl2 = value; }
            get { return _n_lsypl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RSYPL2
        {
            set { _n_rsypl2 = value; }
            get { return _n_rsypl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSDPL2
        {
            set { _n_dsdpl2 = value; }
            get { return _n_dsdpl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DSSPL2
        {
            set { _n_dsspl2 = value; }
            get { return _n_dsspl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RF_OPEN2
        {
            set { _n_rf_open2 = value; }
            get { return _n_rf_open2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DX_OPEN2
        {
            set { _n_dx_open2 = value; }
            get { return _n_dx_open2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DY_OPEN2
        {
            set { _n_dy_open2 = value; }
            get { return _n_dy_open2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SY_OPEN2
        {
            set { _n_sy_open2 = value; }
            get { return _n_sy_open2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DS_OPEN2
        {
            set { _n_ds_open2 = value; }
            get { return _n_ds_open2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RF_LOCK_V2
        {
            set { _n_rf_lock_v2 = value; }
            get { return _n_rf_lock_v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_RF_LOCK_H2
        {
            set { _n_rf_lock_h2 = value; }
            get { return _n_rf_lock_h2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DX_LOCK_V2
        {
            set { _n_dx_lock_v2 = value; }
            get { return _n_dx_lock_v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DX_LOCK_H2
        {
            set { _n_dx_lock_h2 = value; }
            get { return _n_dx_lock_h2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DY_LOCK_V2
        {
            set { _n_dy_lock_v2 = value; }
            get { return _n_dy_lock_v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DY_LOCK_H2
        {
            set { _n_dy_lock_h2 = value; }
            get { return _n_dy_lock_h2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SY_LOCK_V2
        {
            set { _n_sy_lock_v2 = value; }
            get { return _n_sy_lock_v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_SY_LOCK_H2
        {
            set { _n_sy_lock_h2 = value; }
            get { return _n_sy_lock_h2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DS_LOCK_V2
        {
            set { _n_ds_lock_v2 = value; }
            get { return _n_ds_lock_v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_DS_LOCK_H2
        {
            set { _n_ds_lock_h2 = value; }
            get { return _n_ds_lock_h2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N_REMARK
        {
            set { _n_remark = value; }
            get { return _n_remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? N_COUNTTIME
        {
            set { _n_counttime = value; }
            get { return _n_counttime; }
        }
        /// <summary>
        /// 过关相同赛事
        /// </summary>
        public string N_SAMETEAM
        {
            set { _n_sameteam = value; }
            get { return _n_sameteam; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? N_GZFLAG
        {
            set { _n_gzflag = value; }
            get { return _n_gzflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RQSPL01
        {
            set { _n_rqspl01 = value; }
            get { return _n_rqspl01; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RQSPL23
        {
            set { _n_rqspl23 = value; }
            get { return _n_rqspl23; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RQSPL46
        {
            set { _n_rqspl46 = value; }
            get { return _n_rqspl46; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RQSPL7
        {
            set { _n_rqspl7 = value; }
            get { return _n_rqspl7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_RQSSX
        {
            set { _n_rqssx = value; }
            get { return _n_rqssx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDGPL00
        {
            set { _n_bdgpl00 = value; }
            get { return _n_bdgpl00; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL10
        {
            set { _n_bdzpl10 = value; }
            get { return _n_bdzpl10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDGPL11
        {
            set { _n_bdgpl11 = value; }
            get { return _n_bdgpl11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL20
        {
            set { _n_bdzpl20 = value; }
            get { return _n_bdzpl20; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL21
        {
            set { _n_bdzpl21 = value; }
            get { return _n_bdzpl21; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDGPL22
        {
            set { _n_bdgpl22 = value; }
            get { return _n_bdgpl22; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL30
        {
            set { _n_bdzpl30 = value; }
            get { return _n_bdzpl30; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL31
        {
            set { _n_bdzpl31 = value; }
            get { return _n_bdzpl31; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL32
        {
            set { _n_bdzpl32 = value; }
            get { return _n_bdzpl32; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDGPL33
        {
            set { _n_bdgpl33 = value; }
            get { return _n_bdgpl33; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL41
        {
            set { _n_bdzpl41 = value; }
            get { return _n_bdzpl41; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL40
        {
            set { _n_bdzpl40 = value; }
            get { return _n_bdzpl40; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL42
        {
            set { _n_bdzpl42 = value; }
            get { return _n_bdzpl42; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL43
        {
            set { _n_bdzpl43 = value; }
            get { return _n_bdzpl43; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL10
        {
            set { _n_bdkpl10 = value; }
            get { return _n_bdkpl10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL20
        {
            set { _n_bdkpl20 = value; }
            get { return _n_bdkpl20; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL21
        {
            set { _n_bdkpl21 = value; }
            get { return _n_bdkpl21; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL30
        {
            set { _n_bdkpl30 = value; }
            get { return _n_bdkpl30; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL31
        {
            set { _n_bdkpl31 = value; }
            get { return _n_bdkpl31; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL32
        {
            set { _n_bdkpl32 = value; }
            get { return _n_bdkpl32; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL40
        {
            set { _n_bdkpl40 = value; }
            get { return _n_bdkpl40; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL41
        {
            set { _n_bdkpl41 = value; }
            get { return _n_bdkpl41; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL42
        {
            set { _n_bdkpl42 = value; }
            get { return _n_bdkpl42; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL43
        {
            set { _n_bdkpl43 = value; }
            get { return _n_bdkpl43; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDGPL44
        {
            set { _n_bdgpl44 = value; }
            get { return _n_bdgpl44; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDZPL5
        {
            set { _n_bdzpl5 = value; }
            get { return _n_bdzpl5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDKPL5
        {
            set { _n_bdkpl5 = value; }
            get { return _n_bdkpl5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BDSX
        {
            set { _n_bdsx = value; }
            get { return _n_bdsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCZZ
        {
            set { _n_bqczz = value; }
            get { return _n_bqczz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCZH
        {
            set { _n_bqczh = value; }
            get { return _n_bqczh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCZK
        {
            set { _n_bqczk = value; }
            get { return _n_bqczk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCHH
        {
            set { _n_bqchh = value; }
            get { return _n_bqchh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCHZ
        {
            set { _n_bqchz = value; }
            get { return _n_bqchz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCHK
        {
            set { _n_bqchk = value; }
            get { return _n_bqchk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCKK
        {
            set { _n_bqckk = value; }
            get { return _n_bqckk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCKZ
        {
            set { _n_bqckz = value; }
            get { return _n_bqckz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCKH
        {
            set { _n_bqckh = value; }
            get { return _n_bqckh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_BQCSX
        {
            set { _n_bqcsx = value; }
            get { return _n_bqcsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HJPL
        {
            set { _n_hjpl = value; }
            get { return _n_hjpl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HJPL2
        {
            set { _n_hjpl2 = value; }
            get { return _n_hjpl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HJGGCJ
        {
            set { _n_hjggcj = value; }
            get { return _n_hjggcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_HJSX
        {
            set { _n_hjsx = value; }
            get { return _n_hjsx; }
        }
        /// <summary>
        /// 相同赛事的上下半场和全场
        /// </summary>
        public int? N_SAMEGAME
        {
            set { _n_samegame = value; }
            get { return _n_samegame; }
        }
        public int? N_VISIT_REDCARD
        {
            set { _n_visit_redcard = value; }
            get { return _n_visit_redcard; }
        }
        public int? N_HOME_REDCARD
        {
            set { _n_home_redcard = value; }
            get { return _n_home_redcard; }
        }
        #endregion Model
    }


