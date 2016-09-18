<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" Inherits="Gamelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 58px;
        }
    </style>
     <link href="../../Styles/football.css" rel="stylesheet" />
    <script src="jquery-1.8.3.min.js" type="text/javascript"></script>

    <script src="jquery.tmpl.min.js" type="text/javascript"></script>

    <script src="jquery.json.js" type="text/javascript"></script>

    <script src="unlimitdigital.webcontrols.pager.js" type="text/javascript"></script>

    <script src="game.js" type="text/javascript"></script>
   
    <script id="leagueTemplate" type="text/x-jquery-tmpl">
            <li><input type="checkbox" name="chkLeague" value="${N_NO}">${N_LMMC}</li>
    </script>

    <script id="footTemplate" type="text/x-jquery-tmpl">
            <span id="pageIndex">${pageIndex}</span>/<span id="pageCount">${pageCount}</span> 页
            <select id="drpPage">         
            </select>
    </script>
     <script id="gameTemplate" type="text/x-jquery-tmpl">
          <tr {{if $data[13] == 0}} class="graybg"{{/if}}>
            <td class="mgmiddle">
                {{html getAccDate(this)}}
            </td>
            <td class="mgmiddle">
                {{html getBeganTime(this)}}
            </td>
            <td class="txtleft">
                {{html getTeam(this)}}
            </td>            
            <td>
            	{{html GetSpecialWave(this,37,53,26,64,"10")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,38,54,27,65,"20")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,39,55,28,66,"21")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,40,56,29,67,"30")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,41,57,30,68,"31")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,42,58,31,69,"32")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,43,59,32,70,"40")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,44,60,33,71,"41")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,45,61,34,72,"42")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,46,62,35,73,"43")}}
            </td>
            <td>
                {{html GetSpecialOther(this,21,48,"00")}}
            </td>
            <td>
                {{html GetSpecialOther(this,22,49,"11")}}
            </td>
            <td>
                {{html GetSpecialOther(this,23,50,"22")}}
            </td>
            <td>
                {{html GetSpecialOther(this,24,51,"33")}}
            </td>
            <td>
                {{html GetSpecialOther(this,25,52,"44")}}
            </td>
            <td>
            	{{html GetSpecialWave(this,47,63,36,74,"5")}}
            </td>
            <td class="mgmiddle">
                {{html GetSetting(this)}}
            </td>
            
        </tr>
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server"> 



    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">足球操盘</a> / <span id="lblball"></span>波胆
    </ul>
    <div class="title_right">
        <strong>波胆</strong>
    </div>
    <input id="hidPlayType" name="hidPlayType" type="hidden" value="4" />
    <div style="width: 90%; margin: auto">
       <table class="rightbartable" cellspacing="0" cellpadding="0" border="0">
        
        <tr>
            <td class="ct-lf">
            </td>
            <td class="ctmain">
                    <div class="tabtop">
                        <select name="drpCourtType" id="drpCourtType" style="display:none">
                            <option value="0">全部</option>
                            <option value="1" selected="selected">全場</option>
                            <option value="2">上半場</option>
                            <option value="4">下半場</option>
                        </select>
                        <select name="drpStatus" id="drpStatus">
                            <option value="-1">開放中+關閉中</option>
                            <option value="2">開放中</option>
                            <option value="0">關閉中</option>
                        </select>
                        <select name="drpUpdateTime" id="drpUpdateTime" onchange="FnAutoupdate(this.value)">
                            <option value="">不更新</option>
                            <option value="5">每5秒更新</option>
                            <option value="10">每10秒更新</option>
                            <option value="20">每20秒更新</option>
                            <option value="30">每30秒更新</option>
                            <option value="60">每60秒更新</option>
                        </select>
                        <span id="lblMintus"></span>
                        <input type="button" name="btnUpdate" value="更新" id="btnUpdate" class="STYLE1" />
                        <select name="drpPageSize" onchange="" id="drpPageSize">
                            <option value="15">每頁顯示15筆</option>
                            <option value="30">每頁顯示30筆</option>
                            <option value="45">每頁顯示45筆</option>
                            <option selected="selected" value="50">每頁顯示50筆</option>
                        </select>
                        排序
                        <select name="drpSort" id="drpSort" style="display:none">
                            <option selected="selected" value="0">按比赛时间</option>
                            <option value="1">按球赛場次</option>
                        </select>
                        <select name="drpAccDate" id="drpAccDate" style="display:none">
                        </select>
                        <select name="drpSetting" id="drpSetting" style="display:none">
                        </select>
                        <span id="footContainerId">
                        </span>
                        <input type="button" onclick="openLeague()" value="选择联盟" class="btnlm" />
                    </div>
                    <div class="footballs" style="position:relative;">
                        <table cellspacing="0" cellpadding="0" border="0" class="correct">
                            <tr class="headpink">
		                        <td>账务日期</td>
                                <td>比赛时间</td>
                                <td>球队</td>
                                <td>1:0</td>
                                <td>2:0</td>
                                <td>2:1</td>
                                <td>3:0</td>
                                <td>3:1</td>
                                <td>3:2</td>
                                <td>4:0</td>
                                <td>4:1</td>
                                <td>4:2</td>
                                <td>4:3</td>
                                <td>0:0</td>
                                <td>1:1</td>
                                <td>2:2</td>
                                <td>3:3</td>
                                <td>4:4</td>
                                <td>&gt;=5</td>
                                <td>明细</td>
                               
                             </tr>
                            <tbody id="gameContainerId">
                            </tbody>
                        </table>
                        <div id="showdiv" style="width: 140px; height: 0; position: absolute;"></div>
                    </div>
                    <!--footballs end-->
                    <!--选择联盟-->
                    <div class="allianceFlow" style="display: none" id="divLeague">
                        <input type="button" onclick="selectLeague()" value="確定" id="btnConfirm" />
                        <input type="button" onclick="cancelLeague()" value="取消" id="btnCancel1" />
                        <p class="topbox">
                            <input type="checkbox" onclick="checkAllLeague(this)" id="chkAll" value="" />所有聯盟
                        </p>
                        <ul id="leagueContainerId">
                        </ul>
                        <div class="bottonbtn">
                            <input type="button" onclick="selectLeague()" value="確定" id="btnSure" />
                            <input type="button" onclick="cancelLeague()" value="取消" id="btnCancel" />
                        </div>
                    </div>
                    <!--选择联盟 end-->
                </td>
            <td class="ct-rg">
            </td>
        </tr>
        <tr>
            <td class="bt-lf">
            </td>
            <td class="bt-ct">
            </td>
            <td class="bt-rg">
            </td>
        </tr>
    </table>
</div>


<script type="text/javascript">
    $(function () { pageLoad(); });
</script>
</asp:Content>

