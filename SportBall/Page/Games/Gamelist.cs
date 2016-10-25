
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
  public partial class Gamelist  :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ballType = this.Request["bt"];
            string sortId = this.Request["si"];
            string accInDate = this.Request["ad"];
            string selectAlliance = this.Request["sa"];
            int playType = -1;
            int pageSize = 10;
            int pageIndex = 1;
            int courtType = -1;
            int isBet = -1;
            if (string.IsNullOrEmpty(ballType))
            {
                return;
            }
            if (string.IsNullOrEmpty(sortId))
            {
                return;
            }
            if (accInDate == null)
            {
                return;
            }
            if (selectAlliance == null)
            {
                return;
            }
            if (!int.TryParse(this.Request["ct"], out courtType))
            {
                return;
            }
            if (!int.TryParse(this.Request["pt"], out playType))
            {
                return;
            }
            if (!int.TryParse(this.Request["ps"], out pageSize))
            {
                return;
            }
            if (!int.TryParse(this.Request["pi"], out pageIndex))
            {
                return;
            }
            if (!int.TryParse(this.Request["ib"], out isBet))
            {
                return;
            }
            List<int> selectAllianceList = new List<int>();
            foreach (string str in selectAlliance.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                selectAllianceList.Add(Convert.ToInt32(str));
            }
            List<KFB_LMGL> allAllianceList = new List<KFB_LMGL>();

            int recordCount = 0;  //比赛资料
            string accOutDate = "";
            List<List<object>> lm = new List<List<object>>();
            GameSBall objGame = new GameSBall();

            List<object[]> gameList = objGame.GetCompanyGameList(ballType, selectAllianceList, courtType, sortId, isBet, accInDate, playType, pageIndex, pageSize, out recordCount, out allAllianceList, out accOutDate);
            List<DateTime> zwrqlist = new List<DateTime>();


            if (playType == 0)//足球早盘
            {
                zwrqlist = objGame.GetBreakfaseZQ(Comm.GetZWRQ().ToString("yyyy/MM/dd"));
            }
            else if (playType == 10)
            {
                zwrqlist = objGame.GetRecycleRQ(ballType);
            }
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string output = "";
            //0早餐，1單式，2走地，3過關,4波胆，5半全场，6入球数，7已开赛，8过账前的历史比赛，9过账后的历史比赛,
            //n_gsty  0早餐  1单式  2滚球  3过关  4波胆  5单双/入球数  6半全场
            switch (playType)
            {
                case 0://足球早餐
                    output = "[" + ser.Serialize(gameList) + "," + ser.Serialize(allAllianceList) + "," + recordCount + ",\"" + accOutDate + "\"," + ser.Serialize(zwrqlist) + "]";
                    break;
                case 8://已计算
                    output = "[" + ser.Serialize(gameList) + "," + ser.Serialize(allAllianceList) + "," + recordCount + ",\"" + accOutDate + "\"," + ser.Serialize(Comm.getZWDate()) + "]";
                    break;
                case 9://历史比赛
                    output = "[" + ser.Serialize(gameList) + "," + ser.Serialize(allAllianceList) + "," + recordCount + ",\"" + accOutDate + "\"," + ser.Serialize(Comm.getZWDate()) + "]";
                    break;
                case 10://垃圾桶
                    output = "[" + ser.Serialize(gameList) + "," + ser.Serialize(allAllianceList) + "," + recordCount + ",\"" + accOutDate + "\"," + ser.Serialize(zwrqlist) + "]";
                    break;
                default:
                    output = "[" + ser.Serialize(gameList) + "," + ser.Serialize(allAllianceList) + "," + recordCount + ",\"" + accOutDate + "\"]";
                    break;
            }
            Response.Write(output);
            Response.End();

        }
    }
