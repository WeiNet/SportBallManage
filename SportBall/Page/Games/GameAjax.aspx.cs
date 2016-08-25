using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class GameAjax : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //查询联盟
            int leagueId = 0;
            GameSBall game = new GameSBall();
            if (Request["lm"] != null && int.TryParse(Request["lm"], out leagueId))
            {
                string strLeague = game.GetTeamList(leagueId);
                Response.Clear();
                Response.Write(strLeague);
                Response.End();
            }

            //赛事批量操作
            int actionId = 0;
            if (Request["ai"] != null && int.TryParse(Request["ai"], out actionId) && !string.IsNullOrEmpty(Request["il"]))
            {
                string[] idList = Request["il"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                int HasBets = 0;
                if (actionId == 9)
                    HasBets = game.GetBetCount(idList);
                if (HasBets > 0)//垃圾桶中要删除资料有注单
                {
                    Response.Clear();
                    Response.Write("0011");
                    Response.End();
                }
                else
                {
                    string result = game.SetGameStatus(this.Request["pt"], actionId, idList);
                    Response.Clear();
                    Response.Write(result);
                    Response.End();
                }
            }



            //修改赔率
            int nid = 0;
            decimal nValue = 0;
            if (int.TryParse(this.Request["tid"], out nid) && !String.IsNullOrEmpty(Request["tFiled"]) && decimal.TryParse(Request["tValue"], out nValue))
            {
                string result = game.SetRate(nid, this.Request["tFiled"], nValue);
                Response.Clear();
                Response.Write(result);
                Response.End();
            }
        }
    }
