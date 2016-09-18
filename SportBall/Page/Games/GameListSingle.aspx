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
        <li>
            <input type="checkbox" name="chkLeague" value="${N_NO}"/>${N_LMMC}</li>
    </script>

    <script id="footTemplate" type="text/x-jquery-tmpl">
        <span id="pageIndex">${pageIndex}</span>/<span id="pageCount">${pageCount}</span> 页
            <select id="drpPage">
            </select>
    </script>
     <script id="gameTemplate" type="text/x-jquery-tmpl">
  <tr {{if $data[13] == 0}}class="graybg"{{/if}} {{if $data[14]==2}}style="background-color:#E6BD1A"{{/if}} id="tr${$data[0]}">
            <td class="mgmiddle">
                {{html getAccDate(this)}}<br/>{{if $data[16]==1}}開滾球{{/if}}
            </td>
            <td class="mgmiddle">
                {{html getBeganTime(this)}}
            </td>
            <td class="txtleft">
                {{html getTeam(this)}}
            </td>
            <td {{if $data[40] == 1}}class="graybg"{{/if}}>
                {{html GetDY(this)}}
            </td>
             <td {{if $data[27] == 1}}class="graybg"{{/if}}>
                {{html GetRF(this)}}
            </td>
             <td {{if $data[35] == 1}}class="graybg"{{/if}}>
                {{html GetDX(this)}}
            </td>
             <td {{if $data[45] == 1}}class="graybg"{{/if}}>
                {{html GetDS(this)}}
            </td>
            <td class="mgmiddle">
                {{html GetSetting(this)}}
            </td>
            <td class="mgmiddle">
                <input name="chkSelect" id="chkSelect" type="checkbox" value=${$data[0]} />
            </td>
        </tr>
             

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">



    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">足球操盘</a>  <span
            class="divider">/</span> 足球早餐
    </ul>
    <div class="title_right">
        <strong>足球早餐</strong>
    </div>
    <input id="hidPlayType" name="hidPlayType" type="hidden" value="1" />
    <div style="width: 90%; margin: auto">
        <table class="rightbartable" cellspacing="0" cellpadding="0" border="0">

            <tr>
                
                <td class="ctmain" >
                    <div class="tabtop" style="white-space: nowrap;">

                         <select name="drpCourtType" id="drpCourtType">
                            <option value="0">全部</option>
                            <option value="1">全場</option>
                            <option value="2">上半場</option>
                            <option value="4">下半場</option>
                        </select>
                        <select name="drpStatus" id="drpStatus">
                            <option value="-1">開放中+關閉中</option>
                            <option value="2">開放中</option>
                            <option value="0">關閉中</option>
                        </select>
                        <select name="drpUpdateTime" id="drpUpdateTime"  onchange="FnAutoupdate(this.value)">
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
                            <option value="100">每頁顯示100筆</option>
                        </select>
                        排序
                        <select name="drpSort" id="drpSort">
                            <option selected="selected" value="0">按比赛时间</option>
                            <option value="1">按球赛場次</option>
                        </select>
                        <select name="drpAccDate" id="drpAccDate" style="display:none">
                        </select>
                        <select name="drpSetting" id="drpSetting">
                            <option selected="selected" value="-1">赛事批量操作</option>
                            <option value="0">删除</option>
                            <option value="1">开盘</option>
                            <option value="2">关盘</option>
                            <option value="3">锁定</option>
                            <option value="8">解锁</option>
                           <%-- <option value="4">跟盘</option>--%>
                            <option value="6">去滚球</option>
                            <option value="7">去已开赛</option>
                        </select>
                        <span id="footContainerId">
                        </span>
                        <input type="button" onclick="openLeague()" value="选择联盟" class="btnlm" />
                    </div>
                    <div class="footballs">
                        <table cellspacing="0" cellpadding="0" border="0" class="correct2">
                            <tr class="headpink">
                                <td>帳務日期
                                </td>
                                <td>比賽時間
                                </td>
                                <td>球隊
                                </td>
                                <td>獨贏
                                </td>
                                <td>讓分
                                </td>
                                <td>大小
                                </td>
                                <td>单双
                                </td>
                                <td>操作
                                </td>
                                <td class="mgmiddle">
                                    <input id="chk" type="checkbox" onclick="checkAllGame(this);" />
                                </td>
                            </tr>
                            <tbody id="gameContainerId">
                            </tbody>
                        </table>
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
                <td class="ct-rg"></td>
            </tr>
            <tr>
                <td class="bt-lf"></td>
                <td class="bt-ct"></td>
                <td class="bt-rg"></td>
            </tr>
        </table>
    </div>


    <script type="text/javascript">
        $(function () { pageLoad(); });
    </script>
</asp:Content>

