using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class GameOtherDefaultDB
    {

     

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string N_LX)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KFB_BSYS");
            strSql.Append(" where N_LX=:N_LX ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.VarChar,50)
            };
            parameters[0].Value = N_LX;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateBQ(KFB_BSYS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_BSYS set ");
            strSql.Append("N_LX=:N_LX,");
            strSql.Append("N_HYDZSX=:N_HYDZSX,");
            strSql.Append("N_HYDCSX=:N_HYDCSX,");
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
            strSql.Append("N_LDXSX=:N_LDXSX,");
            strSql.Append("N_RDXSX=:N_RDXSX,");
            strSql.Append("N_LDSSX=:N_LDSSX,");
            strSql.Append("N_RDSSX=:N_RDSSX");
            strSql.Append(" where N_LX=:N_LX ");
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
    }
