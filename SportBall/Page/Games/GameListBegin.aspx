﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" Inherits="Gamelist" %>

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
           <tr {{if $data[13] == 0}}class="graybg"{{/if}} id="tr${$data[0]}">
            <td class="mgmiddle">
                {{html getAccDate(this)}}
            </td>
            <td class="mgmiddle">
                {{html getBeganTime(this)}}
            </td>
            <td class="txtleft">
                {{html getTeam(this)}}
            </td>
            <td {{if $data[27] == 1}}class="graybg"{{/if}}>
                {{html GetDY(this)}}
            </td>
             <td {{if $data[35] == 1}}class="graybg"{{/if}}>
                {{html GetRF(this)}}
            </td>
             <td {{if $data[40] == 1}}class="graybg"{{/if}}>
                {{html GetDX(this)}}
            </td>
             <td {{if $data[45] == 1}}class="graybg"{{/if}}>
                {{html GetDS(this)}}
            </td>
            <td class="mgmiddle">
                {{html GetSetting(this)}}
            </td>
            <td class="mgmiddle">
                <input name="chkSelect" id="chkSelect" type="checkbox" value=${$data[0]}  />
            </td>
        </tr>
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server"> 



    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">足球操盘</a>  <span
            class="divider">/</span> 已开赛
    </ul>
    <div class="title_right">
        <strong>已开赛</strong>
    </div>
    <input id="hidPlayType" name="hidPlayType" type="hidden" value="7" />
    <div style="width: 90%; margin: auto">
        <table class="table">
            <tr>
                <td class="auto-style1">
                    <select name="drpCourtType" id="drpCourtType">
                        <option value="0">全部</option>
                        <option value="1">全場</option>
                        <option value="2">上半場</option>
                        <option value="4">下半場</option>
                    </select>
                    <select name="drpStatus" id="drpStatus" style="display: none">
                        <option value="-1">開放中+關閉中</option>
                        <option value="2">開放中</option>
                        <option value="0">關閉中</option>
                    </select>
                    <select name="drpUpdateTime" id="drpUpdateTime">
                        <option value="">不更新</option>
                        <option value="5">每5秒更新</option>
                        <option value="10">每10秒更新</option>
                        <option value="20">每20秒更新</option>
                        <option value="30">每30秒更新</option>
                        <option value="60">每60秒更新</option>
                    </select>
                    <span id="lblMintus"></span>
                    <input type="button" name="btnUpdate" value="更新" id="btnUpdate" class="button" />
                    <select name="drpPageSize" onchange="" id="drpPageSize">
                        <option value="15">每頁顯示15筆</option>
                        <option value="30">每頁顯示30筆</option>
                        <option value="45">每頁顯示45筆</option>
                        <option selected="selected" value="50">每頁顯示50筆</option>
                        <option value="100">每頁顯示100筆</option>
                    </select>
                    排序
                        <select name="drpSort" id="drpSort">
                            <option selected="selected" value="0">按比赛时间</option>
                            <option value="1">按球赛場次</option>
                        </select>
                    <select name="drpAccDate" id="drpAccDate" style="display: none">
                    </select>
                    <select name="drpSetting" id="drpSetting">
                        <option selected="selected" value="-1">赛事批量操作</option>
                        <%--<option value="0">删除</option>--%>
                        <option value="5">回单式</option>
                        <option value="6">回滚球</option>
                    </select>
                    <span id="footContainerId"></span>
                    <input type="button" onclick="openLeague()" value="选择联盟" class="button" />
                </td>
            </tr>
        </table>
        <table class="grid">
            <tr>
                <th>帳務日期</th>
                <th>比賽時間</th>
                <th>球隊</th>
                <th>獨贏</th>
                <th>讓分</th>
                <th>大小</th>
                <th>单双</th>
                <th>操作</th>
                <th>
                    <input id="chkAllGame" type="checkbox" onclick="checkAllGame(this);" />
                </th>
            </tr>
            <tbody id="gameContainerId">
            </tbody>
        </table>
        <!--footballs end-->
        <!--选择联盟-->
        <div class="allianceFlow" style="display: none" id="divLeague">
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
    </div>
    <script type="text/javascript">
        $(function () { pageLoad(); });
    </script>
</asp:Content>

