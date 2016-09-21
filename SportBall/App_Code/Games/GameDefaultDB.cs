using KingOfBall;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;


    public class GameDefaultDB
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
        public void UpdateZQ(KFB_BSYS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KFB_BSYS set ");
            strSql.Append("N_LX=:N_LX,");
            strSql.Append("N_HYDZSX=:N_HYDZSX,");
            strSql.Append("N_HYDCSX=:N_HYDCSX,");
            strSql.Append("N_DYSX=:N_DYSX,");
            strSql.Append("N_WZSX=:N_WZSX,");
            strSql.Append("N_LYSX=:N_LYSX,");
            strSql.Append("N_WZQSX=:N_WZQSX,");
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
            strSql.Append(" where N_LX=:N_LX  ");
            OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_HYDZSX", OracleType.Float,22),
					new OracleParameter(":N_HYDCSX", OracleType.Float,22),
					new OracleParameter(":N_DYSX", OracleType.Number,4),
					new OracleParameter(":N_WZSX", OracleType.Number,4),
					new OracleParameter(":N_LYSX", OracleType.Number,4),
					new OracleParameter(":N_WZQSX", OracleType.Number,4),
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
					new OracleParameter(":N_RQSPL01", OracleType.Float,22),
					new OracleParameter(":N_RQSPL23", OracleType.Float,22),
					new OracleParameter(":N_RQSPL46", OracleType.Float,22),
					new OracleParameter(":N_RQSPL7", OracleType.Float,22),
					new OracleParameter(":N_RQSSX", OracleType.Float,22),
					new OracleParameter(":N_BDGPL00", OracleType.Float,22),
					new OracleParameter(":N_BDZPL10", OracleType.Float,22),
					new OracleParameter(":N_BDGPL11", OracleType.Float,22),
					new OracleParameter(":N_BDZPL20", OracleType.Float,22),
					new OracleParameter(":N_BDZPL21", OracleType.Float,22),
					new OracleParameter(":N_BDGPL22", OracleType.Float,22),
					new OracleParameter(":N_BDZPL30", OracleType.Float,22),
					new OracleParameter(":N_BDZPL31", OracleType.Float,22),
					new OracleParameter(":N_BDZPL32", OracleType.Float,22),
					new OracleParameter(":N_BDGPL33", OracleType.Float,22),
					new OracleParameter(":N_BDZPL41", OracleType.Float,22),
					new OracleParameter(":N_BDZPL40", OracleType.Float,22),
					new OracleParameter(":N_BDZPL42", OracleType.Float,22),
					new OracleParameter(":N_BDZPL43", OracleType.Float,22),
					new OracleParameter(":N_BDKPL10", OracleType.Float,22),
					new OracleParameter(":N_BDKPL20", OracleType.Float,22),
					new OracleParameter(":N_BDKPL21", OracleType.Float,22),
					new OracleParameter(":N_BDKPL30", OracleType.Float,22),
					new OracleParameter(":N_BDKPL31", OracleType.Float,22),
					new OracleParameter(":N_BDKPL32", OracleType.Float,22),
					new OracleParameter(":N_BDKPL40", OracleType.Float,22),
					new OracleParameter(":N_BDKPL41", OracleType.Float,22),
					new OracleParameter(":N_BDKPL42", OracleType.Float,22),
					new OracleParameter(":N_BDKPL43", OracleType.Float,22),
					new OracleParameter(":N_BDGPL44", OracleType.Float,22),
					new OracleParameter(":N_BDZPL5", OracleType.Float,22),
					new OracleParameter(":N_BDKPL5", OracleType.Float,22),
					new OracleParameter(":N_BDSX", OracleType.Float,22),
					new OracleParameter(":N_BQCZZ", OracleType.Float,22),
					new OracleParameter(":N_BQCZH", OracleType.Float,22),
					new OracleParameter(":N_BQCZK", OracleType.Float,22),
					new OracleParameter(":N_BQCHH", OracleType.Float,22),
					new OracleParameter(":N_BQCHZ", OracleType.Float,22),
					new OracleParameter(":N_BQCHK", OracleType.Float,22),
					new OracleParameter(":N_BQCKK", OracleType.Float,22),
					new OracleParameter(":N_BQCKZ", OracleType.Float,22),
					new OracleParameter(":N_BQCKH", OracleType.Float,22),
					new OracleParameter(":N_BQCSX", OracleType.Float,22),
					new OracleParameter(":N_HJPL", OracleType.Float,22),
					new OracleParameter(":N_HJGGCJ", OracleType.Float,22),
					new OracleParameter(":N_HJSX", OracleType.Float,22),
					new OracleParameter(":N_LDXSX", OracleType.Number,4),
					new OracleParameter(":N_RDXSX", OracleType.Number,4),
					new OracleParameter(":N_LDSSX", OracleType.Number,4),
					new OracleParameter(":N_RDSSX", OracleType.Number,4)};
            parameters[0].Value = model.N_LX;
            parameters[1].Value = model.N_HYDZSX;
            parameters[2].Value = model.N_HYDCSX;
            parameters[3].Value = model.N_DYSX;
            parameters[4].Value = model.N_WZSX;
            parameters[5].Value = model.N_LYSX;
            parameters[6].Value = model.N_WZQSX;
            parameters[7].Value = model.N_CBXH;
            parameters[8].Value = model.N_RFFS;
            parameters[9].Value = model.N_RFLX;
            parameters[10].Value = model.N_RFBL;
            parameters[11].Value = model.N_LRFPL;
            parameters[12].Value = model.N_RRFPL;
            parameters[13].Value = model.N_LRFCJ;
            parameters[14].Value = model.N_RRFCJ;
            parameters[15].Value = model.N_LRFSX;
            parameters[16].Value = model.N_RRFSX;
            parameters[17].Value = model.N_RFCJJE;
            parameters[18].Value = model.N_RFCJFS;
            parameters[19].Value = model.N_RFCJPL;
            parameters[20].Value = model.N_DXFS;
            parameters[21].Value = model.N_DXLX;
            parameters[22].Value = model.N_DXBL;
            parameters[23].Value = model.N_DXDPL;
            parameters[24].Value = model.N_DXXPL;
            parameters[25].Value = model.N_DXDCJ;
            parameters[26].Value = model.N_DXXCJ;
            parameters[27].Value = model.N_DXDCSX;
            parameters[28].Value = model.N_DXCJ;
            parameters[29].Value = model.N_DXCJPL;
            parameters[30].Value = model.N_LDYPL;
            parameters[31].Value = model.N_RDYPL;
            parameters[32].Value = model.N_LDYCJ;
            parameters[33].Value = model.N_RDYCJ;
            parameters[34].Value = model.N_LDYSX;
            parameters[35].Value = model.N_RDYSX;
            parameters[36].Value = model.N_DYCJ;
            parameters[37].Value = model.N_DYCJPL;
            parameters[38].Value = model.N_LSYPL;
            parameters[39].Value = model.N_RSYPL;
            parameters[40].Value = model.N_LSYCJ;
            parameters[41].Value = model.N_RSYCJ;
            parameters[42].Value = model.N_LSYSX;
            parameters[43].Value = model.N_RSYSX;
            parameters[44].Value = model.N_SYCJ;
            parameters[45].Value = model.N_SYCJPL;
            parameters[46].Value = model.N_DSDPL;
            parameters[47].Value = model.N_DSSPL;
            parameters[48].Value = model.N_DSDCJ;
            parameters[49].Value = model.N_DSSCJ;
            parameters[50].Value = model.N_DSDCSX;
            parameters[51].Value = model.N_DSCJ;
            parameters[52].Value = model.N_DSCJPL;
            parameters[53].Value = model.N_RQSPL01;
            parameters[54].Value = model.N_RQSPL23;
            parameters[55].Value = model.N_RQSPL46;
            parameters[56].Value = model.N_RQSPL7;
            parameters[57].Value = model.N_RQSSX;
            parameters[58].Value = model.N_BDGPL00;
            parameters[59].Value = model.N_BDZPL10;
            parameters[60].Value = model.N_BDGPL11;
            parameters[61].Value = model.N_BDZPL20;
            parameters[62].Value = model.N_BDZPL21;
            parameters[63].Value = model.N_BDGPL22;
            parameters[64].Value = model.N_BDZPL30;
            parameters[65].Value = model.N_BDZPL31;
            parameters[66].Value = model.N_BDZPL32;
            parameters[67].Value = model.N_BDGPL33;
            parameters[68].Value = model.N_BDZPL41;
            parameters[69].Value = model.N_BDZPL40;
            parameters[70].Value = model.N_BDZPL42;
            parameters[71].Value = model.N_BDZPL43;
            parameters[72].Value = model.N_BDKPL10;
            parameters[73].Value = model.N_BDKPL20;
            parameters[74].Value = model.N_BDKPL21;
            parameters[75].Value = model.N_BDKPL30;
            parameters[76].Value = model.N_BDKPL31;
            parameters[77].Value = model.N_BDKPL32;
            parameters[78].Value = model.N_BDKPL40;
            parameters[79].Value = model.N_BDKPL41;
            parameters[80].Value = model.N_BDKPL42;
            parameters[81].Value = model.N_BDKPL43;
            parameters[82].Value = model.N_BDGPL44;
            parameters[83].Value = model.N_BDZPL5;
            parameters[84].Value = model.N_BDKPL5;
            parameters[85].Value = model.N_BDSX;
            parameters[86].Value = model.N_BQCZZ;
            parameters[87].Value = model.N_BQCZH;
            parameters[88].Value = model.N_BQCZK;
            parameters[89].Value = model.N_BQCHH;
            parameters[90].Value = model.N_BQCHZ;
            parameters[91].Value = model.N_BQCHK;
            parameters[92].Value = model.N_BQCKK;
            parameters[93].Value = model.N_BQCKZ;
            parameters[94].Value = model.N_BQCKH;
            parameters[95].Value = model.N_BQCSX;
            parameters[96].Value = model.N_HJPL;
            parameters[97].Value = model.N_HJGGCJ;
            parameters[98].Value = model.N_HJSX;
            parameters[99].Value = model.N_LDXSX;
            parameters[100].Value = model.N_RDXSX;
            parameters[101].Value = model.N_LDSSX;
            parameters[102].Value = model.N_RDSSX;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddZQ(KFB_BSYS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KFB_BSYS(");
            strSql.Append("N_LX,N_HYDZSX,N_HYDCSX,N_DYSX,N_WZSX,N_LYSX,N_WZQSX,N_CBXH,N_RFFS,N_RFLX,N_RFBL,N_LRFPL,N_RRFPL,N_LRFCJ,N_RRFCJ,N_LRFSX,N_RRFSX,N_RFCJJE,N_RFCJFS,N_RFCJPL,N_DXFS,N_DXLX,N_DXBL,N_DXDPL,N_DXXPL,N_DXDCJ,N_DXXCJ,N_DXDCSX,N_DXCJ,N_DXCJPL,N_LDYPL,N_RDYPL,N_LDYCJ,N_RDYCJ,N_LDYSX,N_RDYSX,N_DYCJ,N_DYCJPL,N_LSYPL,N_RSYPL,N_LSYCJ,N_RSYCJ,N_LSYSX,N_RSYSX,N_SYCJ,N_SYCJPL,N_DSDPL,N_DSSPL,N_DSDCJ,N_DSSCJ,N_DSDCSX,N_DSCJ,N_DSCJPL,N_RQSPL01,N_RQSPL23,N_RQSPL46,N_RQSPL7,N_RQSSX,N_BDGPL00,N_BDZPL10,N_BDGPL11,N_BDZPL20,N_BDZPL21,N_BDGPL22,N_BDZPL30,N_BDZPL31,N_BDZPL32,N_BDGPL33,N_BDZPL41,N_BDZPL40,N_BDZPL42,N_BDZPL43,N_BDKPL10,N_BDKPL20,N_BDKPL21,N_BDKPL30,N_BDKPL31,N_BDKPL32,N_BDKPL40,N_BDKPL41,N_BDKPL42,N_BDKPL43,N_BDGPL44,N_BDZPL5,N_BDKPL5,N_BDSX,N_BQCZZ,N_BQCZH,N_BQCZK,N_BQCHH,N_BQCHZ,N_BQCHK,N_BQCKK,N_BQCKZ,N_BQCKH,N_BQCSX,N_HJPL,N_HJGGCJ,N_HJSX,N_LDXSX,N_RDXSX,N_LDSSX,N_RDSSX)");
            strSql.Append(" values (");
            strSql.Append(":N_LX,:N_HYDZSX,:N_HYDCSX,:N_DYSX,:N_WZSX,:N_LYSX,:N_WZQSX,:N_CBXH,:N_RFFS,:N_RFLX,:N_RFBL,:N_LRFPL,:N_RRFPL,:N_LRFCJ,:N_RRFCJ,:N_LRFSX,:N_RRFSX,:N_RFCJJE,:N_RFCJFS,:N_RFCJPL,:N_DXFS,:N_DXLX,:N_DXBL,:N_DXDPL,:N_DXXPL,:N_DXDCJ,:N_DXXCJ,:N_DXDCSX,:N_DXCJ,:N_DXCJPL,:N_LDYPL,:N_RDYPL,:N_LDYCJ,:N_RDYCJ,:N_LDYSX,:N_RDYSX,:N_DYCJ,:N_DYCJPL,:N_LSYPL,:N_RSYPL,:N_LSYCJ,:N_RSYCJ,:N_LSYSX,:N_RSYSX,:N_SYCJ,:N_SYCJPL,:N_DSDPL,:N_DSSPL,:N_DSDCJ,:N_DSSCJ,:N_DSDCSX,:N_DSCJ,:N_DSCJPL,:N_RQSPL01,:N_RQSPL23,:N_RQSPL46,:N_RQSPL7,:N_RQSSX,:N_BDGPL00,:N_BDZPL10,:N_BDGPL11,:N_BDZPL20,:N_BDZPL21,:N_BDGPL22,:N_BDZPL30,:N_BDZPL31,:N_BDZPL32,:N_BDGPL33,:N_BDZPL41,:N_BDZPL40,:N_BDZPL42,:N_BDZPL43,:N_BDKPL10,:N_BDKPL20,:N_BDKPL21,:N_BDKPL30,:N_BDKPL31,:N_BDKPL32,:N_BDKPL40,:N_BDKPL41,:N_BDKPL42,:N_BDKPL43,:N_BDGPL44,:N_BDZPL5,:N_BDKPL5,:N_BDSX,:N_BQCZZ,:N_BQCZH,:N_BQCZK,:N_BQCHH,:N_BQCHZ,:N_BQCHK,:N_BQCKK,:N_BQCKZ,:N_BQCKH,:N_BQCSX,:N_HJPL,:N_HJGGCJ,:N_HJSX,:N_LDXSX,:N_RDXSX,:N_LDSSX,:N_RDSSX)");
            OracleParameter[] parameters = {
					new OracleParameter(":N_LX", OracleType.VarChar,50),
					new OracleParameter(":N_HYDZSX", OracleType.Float,22),
					new OracleParameter(":N_HYDCSX", OracleType.Float,22),
					new OracleParameter(":N_DYSX", OracleType.Number,4),
					new OracleParameter(":N_WZSX", OracleType.Number,4),
					new OracleParameter(":N_LYSX", OracleType.Number,4),
					new OracleParameter(":N_WZQSX", OracleType.Number,4),
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
					new OracleParameter(":N_RQSPL01", OracleType.Float,22),
					new OracleParameter(":N_RQSPL23", OracleType.Float,22),
					new OracleParameter(":N_RQSPL46", OracleType.Float,22),
					new OracleParameter(":N_RQSPL7", OracleType.Float,22),
					new OracleParameter(":N_RQSSX", OracleType.Float,22),
					new OracleParameter(":N_BDGPL00", OracleType.Float,22),
					new OracleParameter(":N_BDZPL10", OracleType.Float,22),
					new OracleParameter(":N_BDGPL11", OracleType.Float,22),
					new OracleParameter(":N_BDZPL20", OracleType.Float,22),
					new OracleParameter(":N_BDZPL21", OracleType.Float,22),
					new OracleParameter(":N_BDGPL22", OracleType.Float,22),
					new OracleParameter(":N_BDZPL30", OracleType.Float,22),
					new OracleParameter(":N_BDZPL31", OracleType.Float,22),
					new OracleParameter(":N_BDZPL32", OracleType.Float,22),
					new OracleParameter(":N_BDGPL33", OracleType.Float,22),
					new OracleParameter(":N_BDZPL41", OracleType.Float,22),
					new OracleParameter(":N_BDZPL40", OracleType.Float,22),
					new OracleParameter(":N_BDZPL42", OracleType.Float,22),
					new OracleParameter(":N_BDZPL43", OracleType.Float,22),
					new OracleParameter(":N_BDKPL10", OracleType.Float,22),
					new OracleParameter(":N_BDKPL20", OracleType.Float,22),
					new OracleParameter(":N_BDKPL21", OracleType.Float,22),
					new OracleParameter(":N_BDKPL30", OracleType.Float,22),
					new OracleParameter(":N_BDKPL31", OracleType.Float,22),
					new OracleParameter(":N_BDKPL32", OracleType.Float,22),
					new OracleParameter(":N_BDKPL40", OracleType.Float,22),
					new OracleParameter(":N_BDKPL41", OracleType.Float,22),
					new OracleParameter(":N_BDKPL42", OracleType.Float,22),
					new OracleParameter(":N_BDKPL43", OracleType.Float,22),
					new OracleParameter(":N_BDGPL44", OracleType.Float,22),
					new OracleParameter(":N_BDZPL5", OracleType.Float,22),
					new OracleParameter(":N_BDKPL5", OracleType.Float,22),
					new OracleParameter(":N_BDSX", OracleType.Float,22),
					new OracleParameter(":N_BQCZZ", OracleType.Float,22),
					new OracleParameter(":N_BQCZH", OracleType.Float,22),
					new OracleParameter(":N_BQCZK", OracleType.Float,22),
					new OracleParameter(":N_BQCHH", OracleType.Float,22),
					new OracleParameter(":N_BQCHZ", OracleType.Float,22),
					new OracleParameter(":N_BQCHK", OracleType.Float,22),
					new OracleParameter(":N_BQCKK", OracleType.Float,22),
					new OracleParameter(":N_BQCKZ", OracleType.Float,22),
					new OracleParameter(":N_BQCKH", OracleType.Float,22),
					new OracleParameter(":N_BQCSX", OracleType.Float,22),
					new OracleParameter(":N_HJPL", OracleType.Float,22),
					new OracleParameter(":N_HJGGCJ", OracleType.Float,22),
					new OracleParameter(":N_HJSX", OracleType.Float,22),
					new OracleParameter(":N_LDXSX", OracleType.Number,4),
					new OracleParameter(":N_RDXSX", OracleType.Number,4),
					new OracleParameter(":N_LDSSX", OracleType.Number,4),
					new OracleParameter(":N_RDSSX", OracleType.Number,4)};
            parameters[0].Value = model.N_LX;
            parameters[1].Value = model.N_HYDZSX;
            parameters[2].Value = model.N_HYDCSX;
            parameters[3].Value = model.N_DYSX;
            parameters[4].Value = model.N_WZSX;
            parameters[5].Value = model.N_LYSX;
            parameters[6].Value = model.N_WZQSX;
            parameters[7].Value = model.N_CBXH;
            parameters[8].Value = model.N_RFFS;
            parameters[9].Value = model.N_RFLX;
            parameters[10].Value = model.N_RFBL;
            parameters[11].Value = model.N_LRFPL;
            parameters[12].Value = model.N_RRFPL;
            parameters[13].Value = model.N_LRFCJ;
            parameters[14].Value = model.N_RRFCJ;
            parameters[15].Value = model.N_LRFSX;
            parameters[16].Value = model.N_RRFSX;
            parameters[17].Value = model.N_RFCJJE;
            parameters[18].Value = model.N_RFCJFS;
            parameters[19].Value = model.N_RFCJPL;
            parameters[20].Value = model.N_DXFS;
            parameters[21].Value = model.N_DXLX;
            parameters[22].Value = model.N_DXBL;
            parameters[23].Value = model.N_DXDPL;
            parameters[24].Value = model.N_DXXPL;
            parameters[25].Value = model.N_DXDCJ;
            parameters[26].Value = model.N_DXXCJ;
            parameters[27].Value = model.N_DXDCSX;
            parameters[28].Value = model.N_DXCJ;
            parameters[29].Value = model.N_DXCJPL;
            parameters[30].Value = model.N_LDYPL;
            parameters[31].Value = model.N_RDYPL;
            parameters[32].Value = model.N_LDYCJ;
            parameters[33].Value = model.N_RDYCJ;
            parameters[34].Value = model.N_LDYSX;
            parameters[35].Value = model.N_RDYSX;
            parameters[36].Value = model.N_DYCJ;
            parameters[37].Value = model.N_DYCJPL;
            parameters[38].Value = model.N_LSYPL;
            parameters[39].Value = model.N_RSYPL;
            parameters[40].Value = model.N_LSYCJ;
            parameters[41].Value = model.N_RSYCJ;
            parameters[42].Value = model.N_LSYSX;
            parameters[43].Value = model.N_RSYSX;
            parameters[44].Value = model.N_SYCJ;
            parameters[45].Value = model.N_SYCJPL;
            parameters[46].Value = model.N_DSDPL;
            parameters[47].Value = model.N_DSSPL;
            parameters[48].Value = model.N_DSDCJ;
            parameters[49].Value = model.N_DSSCJ;
            parameters[50].Value = model.N_DSDCSX;
            parameters[51].Value = model.N_DSCJ;
            parameters[52].Value = model.N_DSCJPL;
            parameters[53].Value = model.N_RQSPL01;
            parameters[54].Value = model.N_RQSPL23;
            parameters[55].Value = model.N_RQSPL46;
            parameters[56].Value = model.N_RQSPL7;
            parameters[57].Value = model.N_RQSSX;
            parameters[58].Value = model.N_BDGPL00;
            parameters[59].Value = model.N_BDZPL10;
            parameters[60].Value = model.N_BDGPL11;
            parameters[61].Value = model.N_BDZPL20;
            parameters[62].Value = model.N_BDZPL21;
            parameters[63].Value = model.N_BDGPL22;
            parameters[64].Value = model.N_BDZPL30;
            parameters[65].Value = model.N_BDZPL31;
            parameters[66].Value = model.N_BDZPL32;
            parameters[67].Value = model.N_BDGPL33;
            parameters[68].Value = model.N_BDZPL41;
            parameters[69].Value = model.N_BDZPL40;
            parameters[70].Value = model.N_BDZPL42;
            parameters[71].Value = model.N_BDZPL43;
            parameters[72].Value = model.N_BDKPL10;
            parameters[73].Value = model.N_BDKPL20;
            parameters[74].Value = model.N_BDKPL21;
            parameters[75].Value = model.N_BDKPL30;
            parameters[76].Value = model.N_BDKPL31;
            parameters[77].Value = model.N_BDKPL32;
            parameters[78].Value = model.N_BDKPL40;
            parameters[79].Value = model.N_BDKPL41;
            parameters[80].Value = model.N_BDKPL42;
            parameters[81].Value = model.N_BDKPL43;
            parameters[82].Value = model.N_BDGPL44;
            parameters[83].Value = model.N_BDZPL5;
            parameters[84].Value = model.N_BDKPL5;
            parameters[85].Value = model.N_BDSX;
            parameters[86].Value = model.N_BQCZZ;
            parameters[87].Value = model.N_BQCZH;
            parameters[88].Value = model.N_BQCZK;
            parameters[89].Value = model.N_BQCHH;
            parameters[90].Value = model.N_BQCHZ;
            parameters[91].Value = model.N_BQCHK;
            parameters[92].Value = model.N_BQCKK;
            parameters[93].Value = model.N_BQCKZ;
            parameters[94].Value = model.N_BQCKH;
            parameters[95].Value = model.N_BQCSX;
            parameters[96].Value = model.N_HJPL;
            parameters[97].Value = model.N_HJGGCJ;
            parameters[98].Value = model.N_HJSX;
            parameters[99].Value = model.N_LDXSX;
            parameters[100].Value = model.N_RDXSX;
            parameters[101].Value = model.N_LDSSX;
            parameters[102].Value = model.N_RDSSX;

            DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }


    }
