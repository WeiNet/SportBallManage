// JScript 文件

var queryObj = new Object();
queryObj.pageIndex = 1;
queryObj.pageSize = 50;  //分页笔数

var pagerObj, jsonObj;

function pageLoad() {
    $("#drpCourtType").bind("change", function () {//绑定场别事件
        $("#drpPage").val(1);//分页设置为第一页
        queryObj.pageIndex = 1;
        Query();
    });
    $("#drpStatus").bind("change", function () {//绑定状态事件
        $("#drpPage").val(1);
        queryObj.pageIndex = 1;
        Query();
    });
    $("#btnUpdate").bind("click", function () {//绑定更新按钮
        $(this).attr("disabled", true);
        Query();
    });
    $("#drpSort").bind("change", function () { //绑定排序事件
        $("#drpPage").val(1);
        queryObj.pageIndex = 1;
        Query();
    });
    $("#drpAccDate").bind("change", function () {//绑定帐期事件
        $("#drpPage").val(1);
        queryObj.pageIndex = 1;
        Query();
    });
    $("#drpPageSize").bind("change", function () {//绑定分页笔数
        $("#drpPage").val(1);
        queryObj.pageIndex = 1;
        queryObj.pageSize = this.value;  //分页笔数
        Query();
    });
    $("#drpSetting").bind("change", function () {//绑定操作下拉事件

        if (confirm("确定批量执行" + this.options[this.selectedIndex].text + "吗？")) {
            $("#drpPage").val(1);
            queryObj.pageIndex = 1;
            var idList = [];
            $("#gameContainerId").find("input[type='checkbox']:checked").each(function () {
                idList.push(this.value);
            });
            if (idList.length == 0) {
                alert("请选择赛事后再执行操作");
                return false;
            }
            changeStatus(this.value, idList.join(','), $("#hidPlayType").val());
            Query();
        }
        this.value = "-1";
    });
    Query();
}
function GetBallType(strballtype) {
    switch (strballtype) {
        case "b_zq":
            $("#lblball").html("足球");
            break;
        case "b_bk":
            $("#lblball").html("篮球");
            break;
        case "b_bj":
            $("#lblball").html("棒球");
            break;
        case "b_by":
            $("#lblball").html("网球");
            break;
        case "b_bb":
            $("#lblball").html("排球");
            break;
        default:
            $("#lblball").html("其他");
            break;
    }
}

function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}
function selectLeague() {//选择联盟
    var leagues = [];
    $("#leagueContainerId").find("input[type='checkbox']:checked").each(function () {
        leagues.push(this.value);
    });
    $("#chkAll").val(leagues.join(","));
    queryObj.pageIndex = 1;
    Query();
    $("#divLeague").hide();
}
function openLeague() {//展开联盟选择框
    $("#divLeague").toggle("fast");
}
function cancelLeague() {//隐藏联盟选择框
    $("#divLeague").hide();
}
function Query() {
    //debugger;
    queryObj.url = document.forms[0].action;
    queryObj.alliance = $("#chkAll").val();//联盟
    queryObj.isbet = $("#drpStatus").val();//是否开放
    queryObj.Sort = $("#drpSort").val();//排序
    queryObj.accDate = $("#drpAccDate").val();//账务日期
    queryObj.courtType = $("#drpCourtType").val();//场别
    queryObj.playType = $("#hidPlayType").val();
    queryObj.colspan = $(".headpink>td").length;
    GetBallType(getUrlParam("bt"));
    $.ajax({
        type: "post",
        dataType: "json",//返回json格式的数据
        url: queryObj.url,
        cache: false,
        async: true,
        data: {
            pi: queryObj.pageIndex,
            ps: queryObj.pageSize,
            sa: queryObj.alliance,
            si: queryObj.Sort,
            ib: queryObj.isbet,
            //            bt:queryObj.ballType,
            pt: queryObj.playType,
            ct: queryObj.courtType,
            ad: queryObj.accDate,
            rad: Math.random()
        },
        complete: function () {
            //alert(1);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error!!");
            //window.top.location.href = "/Company/Login.aspx";
        },
        success: function (retrunJson) {
            //retrunJson为返回的数据，在这里做数据绑定
            showGameList(retrunJson);
        }
    });
}

///画面显示数据
function showGameList(objList) {
    var objData = objList[0];//比赛资料
    var objLM = objList[1];//联盟资料
    var count = objList[2];//比赛总比赛
    var objDate = objList[3];//系統賬務日期
    var objZwdate;
    switch (queryObj.playType) {
        case "0":
            var sdate = $("#drpAccDate").find("option:selected").text();
            objZwdate = objList[4];
            $("#drpAccDate").empty();
            $("#drpAccDate").append("<option value='' selected=\"selected\">--请选择--</option>");
            $.each(objZwdate, function (i) {
                if (sdate == formatDate(objZwdate[i], 'MM/dd'))
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\" selected=\"selected\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
                else
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
            });
            break;
        case "8":
            var sdate = $("#drpAccDate").find("option:selected").text();
            objZwdate = objList[4];
            $("#drpAccDate").empty();
            $("#drpAccDate").append("<option value='' selected=\"selected\">--请选择--</option>");
            $.each(objZwdate, function (i) {
                if (sdate == formatDate(objZwdate[i], 'MM/dd'))
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\" selected=\"selected\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
                else
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
            });
            break;
        case "9":
            var sdate = $("#drpAccDate").find("option:selected").text();
            objZwdate = objList[4];
            $("#drpAccDate").empty();
            $("#drpAccDate").append("<option value='' selected=\"selected\">--请选择--</option>");
            $.each(objZwdate, function (i) {
                if (sdate == formatDate(objZwdate[i], 'MM/dd'))
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\" selected=\"selected\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
                else
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
            });
            break;
        case "10":
            var sdate = $("#drpAccDate").find("option:selected").text();
            objZwdate = objList[4];
            $("#drpAccDate").empty();
            $("#drpAccDate").append("<option value='' selected=\"selected\">--请选择--</option>");
            $.each(objZwdate, function (i) {
                if (sdate == formatDate(objZwdate[i], 'MM/dd'))
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\" selected=\"selected\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
                else
                    $("#drpAccDate").append("<option value=\"" + formatDate(objZwdate[i], 'yyyy/MM/dd') + "\">" + formatDate(objZwdate[i], 'MM/dd') + "</option>");
            });
            break;
    }

    $("#gameContainerId").empty();
    $("#gameTemplate").tmpl(objData).appendTo("#gameContainerId");//向比赛资料模板塞资料

    $("#leagueContainerId").empty();
    $("#leagueTemplate").tmpl(objLM).appendTo("#leagueContainerId");//像联盟模板中塞联盟资料

    bindLeague(objData, objLM);//向比赛资料中插入联盟

    var datasource = { 'pageIndex': queryObj.pageIndex, 'pageSize': queryObj.pageSize, 'recordCount': count };
    if (pagerObj == null) {
        $("#footContainerId").html('');
        var pager = new UnlimitDigital.Webcontrols.Pager(datasource, 'footContainerId', 'footTemplate');
        pager.callBack(asnyloadFunc);
        pager.dataBind();
    } else {
        pagerObj.set_PagerSoure(datasource);
        pagerObj.dataBind();
    }
    $.each($("#chkAll").val().split(','), function (i) {//勾选选中的联盟
        $("#leagueContainerId").find("input[value='" + this + "']").attr("checked", "checked");
    });
    $("#btnUpdate").attr("disabled", false);
}
function asnyloadFunc(pager) {
    pagerObj = pager;
    queryObj.pageIndex = pager.pageIndex;
    queryObj.pageSize = pager.pageSize;
    Query();
}
function GetCourtName(strCourt) {
    var strReturn;
    switch (strCourt) {
        case 1:
            strReturn = "全場";
            break;
        case 2:
            strReturn = "上半場";
            break;
        case 4:
            strReturn = "下半場";
            break;
        default:
            strReturn = "";
            break;
    }
    return strReturn;
}
function bindLeague(data, leagueList) {
    var leagueName = "";
    var k = 0;
    $.each(data, function (i) {
        var leaglue = "";
        $.each(leagueList, function (j) {
            if (data[i][4] == this.N_NO) {
                leaglue = this.N_LMMC + " - " + GetCourtName(data[i][10]);
            }
        });

        if (leaglue != leagueName) {

            $("<tr><td colspan=\"" + queryObj.colspan + "\" class=\"ft-tit\">" + leaglue + "</td></tr>").insertBefore($("#gameContainerId tr:eq(" + k + ")"));
            leagueName = leaglue;
            k = k + 2;
        }
        else {
            k = k + 1;
        }
    });
}
String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}
function getCalcu(strUp, strDown) {
    strUp = strUp == "" ? "0/0" : strUp;
    strDown = strDown == "" ? "0/0" : strDown;
    return Math.abs(strUp.split('/')[1] - strDown.split('/')[1]);
}
function GetBallHead(lx, fs, bl) {
    var s_Result = "";
    switch (lx) {
        case 1://+
            if (bl < 100 && bl > 0)//+50
            {
                s_Result = ((fs - 1) + bl / 100.0) + "/" + fs;
            }
            else if (bl == 100)//+100
            {
                s_Result = fs - 0.5;
            }
            else if (bl == 0)//+0
            {
                s_Result = fs;
            }
            else {
                s_Result = fs + "+" + bl;
            }
            break;
        case 0:
            s_Result = fs;
            break;
        case -1:
            if (bl < 100 && bl > 0) {
                s_Result = fs + "/" + (fs + bl / 100.0);//-50
            }
            else {
                s_Result = fs + "-" + bl;
            }
            break;
        case -2:
            s_Result = fs + 0.5;
            break;
    }
    return s_Result;
}
//---------------------------------------------------   
// 日期格式化/Date(112132224)/被JSON序列化後的字符串
//---------------------------------------------------
function formatDate(input, formatStr) {
    if (input.indexOf('/Date(') != -1) {
        input = input.replace('/Date(', '').replace(')/', '');
    }

    var tmpDate = new Date(parseInt(input));
    return tmpDate.format(formatStr);
}
Date.prototype.format = function (format) {
    var weeks = ['周一', '周二', '周三', '周四', '周五', '周六', '周日'];
    var o = {
        "M+": this.getMonth() + 1, // month   
        "d+": this.getDate(), // day   
        "h+": this.getHours(), // hour   
        "m+": this.getMinutes(), // minute 
        "w+": weeks[this.getDay()], // week   
        "s+": this.getSeconds(), // second   
        "q+": Math.floor((this.getMonth() + 3) / 3), // quarter   
        "S": this.getMilliseconds()
    }
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "")
            .substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k]
                : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}
function getAccDate(items) {
    //debugger;
    var item = items.data;
    return formatDate(item[2], "MM/dd");
}
function getBeganTime(items) {
    var item = items.data;
    return '<p>' + formatDate(item[3], "MM/dd") + '</p>\
            <span class="gray">'+ formatDate(item[3], "hh:mm") + '</span>';
}
function getTeam(items) {
    var item = items.data, html;

    var teamVisitName = '';
    var teamHomeName = '';
    if (item[6] == item[19]) {
        teamHomeName = item[7] + '<em class="red">[主]</em>';
        teamVisitName = item[9];
    }
    else {
        teamVisitName = item[7];
        teamHomeName = item[9] + '<em class="red">[主]</em>';
    }
    html = "<p>" + teamHomeName + "</p><p><span class=\"gray\">" + teamVisitName + "</span></p>";
    if (item[1] == "b_zq" && item[5] != 4 && item[5] != 5 && item[5] != 6) {
        html += '<span class="gray">和局</span>';
    }
    return html;
}
function getJZF(items) {
    var item = items.data, html;
    if (item[6] == item[19]) {
        html = item[50] + "<br/>" + item[51];
    }
    else {
        html = item[51] + "<br/>" + item[50];
    }
    return html;
}
var HTML_PK = '<ul class="tblist">\
                <li style="border:1px;solid red"><div style="width:50px"><a href="javascript:void(0);"  onclick="openFastSet({11},\'{10}\')">&nbsp;{0}</a></div>\
                    <div style="width:50px"><a href="javascript:void(0);"  onclick="openFastSet({11},\'{10}\')">&nbsp;{1}</a></div></li>\
                <li name="lipk"><p class="gray">{2}</p><p class="gray">{3}</p></li>\
                <li><div><a href="javascript:void(0);" onclick="setRate({12})" class="redlink">{4}</a></div>\
                    <div><a href="javascript:void(0);" onclick="setRate({13})" class="redlink">{5}</a></div>\</li>\
                <li class="txtleft"><div><a href="javascript:void(0);" onclick="openBillDetail({14})">{6}</a><em class="blank">{8}</em></div>\
                                    <div><a href="javascript:void(0);" onclick="openBillDetail({15})">{7}</a><em class="blank">{9}</em></div></li>\
               </ul>';
var HTML_PK_DRAW = '<ul class="tblist">\
                <li><div style="width:50px"><a href="javascript:void(0);" onclick="openFastSet({11},\'{10}\')">{0}</a></div>\
                    <div style="width:50px"><a href="javascript:void(0);" onclick="openFastSet({11},\'{10}\')">{1}</a></div></li>\
                <li name="lipk"><p class="gray">{2}</p><p class="gray">{3}</p></li>\
                <li><div><a href="javascript:void(0);" onclick="setRate({12})" class="redlink">{4}</a></div>\
                    <div><a href="javascript:void(0);" onclick="setRate({13})" class="redlink">{5}</a></div>\
                    <div><a href="javascript:void(0);" onclick="setRate({18})" class="redlink">{16}</a></div></li>\
                <li class="txtleft"><div><a href="javascript:void(0);" onclick="openBillDetail({14})">{6}</a><em class="blank">{8}</em></div>\
                                    <div><a href="javascript:void(0);" onclick="openBillDetail({15})">{7}</a><em class="blank">{9}</em></div>\
                                    <div><a href="javascript:void(0);" onclick="openBillDetail({19})">{17}</a></div></li>\
               </ul>';



var HTML_HISTORY_PK = '<ul class="tblist">\
                <li style="border:1px;solid red"><div style="width:50px"><a href="javascript:void(0);">&nbsp;{0}</a></div>\
                    <div style="width:50px"><a href="javascript:void(0);">&nbsp;{1}</a></div></li>\
                <li name="lipk"><p class="gray">{2}</p><p class="gray">{3}</p></li>\
                <li><div><a href="javascript:void(0);"  class="redlink">{4}</a></div>\
                    <div><a href="javascript:void(0);"  class="redlink">{5}</a></div>\</li>\
                <li class="txtleft"><div><a href="javascript:void(0);" >{6}</a><em class="blank">{8}</em></div>\
                                    <div><a href="javascript:void(0);">{7}</a><em class="blank">{9}</em></div></li>\
               </ul>';
var HTML_HISTORY_PK_DRAW = '<ul class="tblist">\
                <li><div style="width:50px"><a href="javascript:void(0);">{0}</a></div>\
                    <div style="width:50px"><a href="javascript:void(0);">{1}</a></div></li>\
                <li name="lipk"><p class="gray">{2}</p><p class="gray">{3}</p></li>\
                <li><div><a href="javascript:void(0);" class="redlink">{4}</a></div>\
                    <div><a href="javascript:void(0);" class="redlink">{5}</a></div>\
                    <div><a href="javascript:void(0);" class="redlink">{10}</a></div></li>\
                <li class="txtleft"><div><a href="javascript:void(0);" >{6}</a><em class="blank">{8}</em></div>\
                                    <div><a href="javascript:void(0);" >{7}</a><em class="blank">{9}</em></div>\
                                    <div><a href="javascript:void(0);" >{11}</a></div></li>\
               </ul>';
function GetDY(items) {
    var item = items.data, html;
    var headup = "PK", headdown = "";
    var csup = "", csdown = "";
    var calcuup = "", calcudown = "";
    var rateup = "0.000", ratedown = "0.000";
    var ratedraw = "0.000", csdraw = "0/0";
    var calcu = 0;
    var playType = "";

    if (item[1] == "b_zq") {
        if (item[5] == 2) {//走地
            playType = "zd";
            csup = item[47];
            csdown = item[48];
            rateup = item[38];
            ratedown = item[39];
            ratedraw = item[21];
            csdraw = item[49];
        }
        else if (item[5] == 3) {//过关
            csup = item[65];
            csdown = item[66];
            rateup = item[44];
            ratedown = item[45];
            ratedraw = item[16];
            csdraw = item[67];
        }
        else {
            csup = item[52];
            csdown = item[53];
            rateup = item[38];
            ratedown = item[39];
            ratedraw = item[21];
            csdraw = item[54];
        }
        ratedraw = ratedraw.toFixed(3);
    }
    else {
        csup = item[57];
        csdown = item[58];
        rateup = item[38];
        ratedown = item[39];
    }
    calcu = getCalcu(csup, csdown);
    if (item[1] == "b_zq") {
        if (calcu >= 0) {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
        else {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
    }
    else {
        if (calcu >= 0) {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
        else {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
    }
    rateup = rateup.toFixed(3);
    ratedown = ratedown.toFixed(3);

    var clickcsup = item[0] + "," + item[6] + ",\'l_" + playType + "dy\'," + item[5];
    var clickcsdown = item[0] + "," + item[8] + ",\'l_" + playType + "dy\'," + item[5];
    var clickcsdraw = item[0] + ",0,\'l_" + playType + "hj\'," + item[5];
    var clickrateup = item[0] + ",'\L\',\'DY\',$(this)";
    var clickratedown = item[0] + ",'\R\',\'DY\',$(this)";
    var clickratedraw = "";
    if (item[1] == "b_zq") {
        if (item[5] == 8 || item[5] == 9)
            html = String.format(HTML_HISTORY_PK_DRAW, headup, headdown, "", "",
                                        rateup, ratedown, csup, csdown, calcuup, calcudown,
                                        ratedraw, csdraw);
        else
            html = String.format(HTML_PK_DRAW, headup, headdown, "", "",
                                        rateup, ratedown, csup, csdown, calcuup, calcudown,
                                        "dy", item[0], clickrateup, clickratedown, clickcsup, clickcsdown,
                                        ratedraw, csdraw, clickratedraw, clickcsdraw);
    }
    else {
        if (item[5] == 8 || item[5] == 9)
            html = String.format(HTML_HISTORY_PK, headup, headdown, "", "",
                                    rateup, ratedown, csup, csdown, calcuup, calcudown);
        else
            html = String.format(HTML_PK, headup, headdown, "", "",
                                    rateup, ratedown, csup, csdown, calcuup, calcudown,
                                    "dy", item[0], clickrateup, clickratedown, clickcsup, clickcsdown);
    }
    return html;
}
function GetRF(items) {
    var item = items.data, html;
    var headup = "", headdown = "";
    var csup = "", csdown = "";
    var calcuup = "", calcudown = "";
    var rateup = "0.000", ratedown = "0.000";
    var calcu = 0;

    if (item[12] == 0) {
        headup = GetBallHead(item[22], item[23], item[24]);
        headdown = "";
    }
    else {
        headup = "";
        headdown = GetBallHead(item[22], item[23], item[24]);
    }
    var playType = "";
    if (item[1] == "b_zq") {
        if (item[5] == 2) {//走地
            playType = "zd";
            csup = item[43];
            csdown = item[44];
        }
        else if (item[5] == 3) {//过关
            csup = item[61];
            csdown = item[62];
        }
        else {
            csup = item[48];
            csdown = item[49];
        }
        calcu = getCalcu(csup, csdown);
        if (calcu >= 0) {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
        else {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
    }
    else {
        if (item[5] == 2) {//走地
            playType = "zd";
            csup = item[41];
            csdown = item[42];
        }
        else if (item[5] == 3) {//过关
            csup = item[61];
            csdown = item[62];
        }
        else {
            csup = item[53];
            csdown = item[54];
        }
        calcu = getCalcu(csup, csdown);
        if (calcu >= 0) {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
        else {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
    }
    rateup = item[25].toFixed(3);
    ratedown = item[26].toFixed(3);
    var clickcsup = item[0] + "," + item[6] + ",\'l_" + playType + "rf\'," + item[5];
    var clickcsdown = item[0] + "," + item[8] + ",\'l_" + playType + "rf\'," + item[5];

    var clickrateup = item[0] + ",'\L\',\'RF\',$(this)";
    var clickratedown = item[0] + ",'\R\',\'RF\',$(this)";
    if (item[5] == 8 || item[5] == 9)
        html = String.format(HTML_HISTORY_PK, headup, headdown, "", "",
                                rateup, ratedown, csup, csdown, calcuup, calcudown);
    else
        html = String.format(HTML_PK, headup, headdown, "", "",
                                rateup, ratedown, csup, csdown, calcuup, calcudown,
                                "rf", item[0], clickrateup, clickratedown, clickcsup, clickcsdown);
    return html;
}
function GetDX(items) {
    var item = items.data, html;
    var headup = "", headdown = "";
    var csup = "", csdown = "";
    var calcuup = "", calcudown = "";
    var rateup = "0.000", ratedown = "0.000";
    var calcu = 0;
    var playType = "";
    if (item[1] == "b_zq") {
        rateup = item[36].toFixed(3);
        ratedown = item[37].toFixed(3);
        headup = GetBallHead(item[30], item[31], item[32]);
        if (item[5] == 2) {//走地
            playType = "zd";
            csup = item[43];
            csdown = item[44];
            rateup = item[33].toFixed(3);
            ratedown = item[34].toFixed(3);
        }
        else if (item[5] == 3) {//过关
            csup = item[61];
            csdown = item[62];
            headup = GetBallHead(item[33], item[34], item[35]);
        }
        else {
            csup = item[50];
            csdown = item[51];
            rateup = item[33].toFixed(3);
            ratedown = item[34].toFixed(3);
        }
        calcu = getCalcu(csup, csdown);
        if (calcu >= 0) {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
        else {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
    }
    else {
        if (item[5] == 2) {//走地
            playType = "zd";
            csup = item[43];
            csdown = item[44];
            rateup = item[33].toFixed(3);
            ratedown = item[34].toFixed(3);
        }
        else if (item[5] == 3) {//过关
            csup = item[63];
            csdown = item[64];
            headup = GetBallHead(item[33], item[34], item[35]);
            rateup = item[36].toFixed(3);
            ratedown = item[37].toFixed(3);
        }
        else {
            csup = item[55];
            csdown = item[56];
            headup = GetBallHead(item[30], item[31], item[32]);
            rateup = item[33].toFixed(3);
            ratedown = item[34].toFixed(3);
        }
        calcu = getCalcu(csup, csdown);
        if (calcu >= 0) {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
        else {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
    }
    var clickcsup = item[0] + "," + item[6] + ",\'l_" + playType + "dx\'," + item[5];
    var clickcsdown = item[0] + "," + item[8] + ",\'l_" + playType + "dx\'," + item[5];
    var clickrateup = item[0] + ",'\L\',\'DX\',$(this)";
    var clickratedown = item[0] + ",'\R\',\'DX\',$(this)";
    if (item[5] == 8 || item[5] == 9)
        html = String.format(HTML_HISTORY_PK, headup, headdown, "大", "小",
                            rateup, ratedown, csup, csdown, calcuup, calcudown);
    else
        html = String.format(HTML_PK, headup, headdown, "大", "小",
                            rateup, ratedown, csup, csdown, calcuup, calcudown,
                            "dx", item[0], clickrateup, clickratedown, clickcsup, clickcsdown);
    return html;
}
function GetDS(items) {
    var item = items.data, html;
    var headup = "改", headdown = "";
    var csup = "", csdown = "";
    var calcuup = "", calcudown = "";
    var rateup = "0.000", ratedown = "0.000";
    var calcu = 0;
    if (item[1] == "b_zq") {
        if (item[5] == 3) {//过关
            rateup = item[52];
            ratedown = item[53];
            csup = item[68];
            csdown = item[69];
        }
        else {
            rateup = item[43];
            ratedown = item[44];
            csup = item[55];
            csdown = item[56];
        }
        calcu = getCalcu(csup, csdown);
        if (calcu >= 0) {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
        else {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
    }
    else {
        if (item[5] == 3) {//过关
            rateup = item[52];
            ratedown = item[53];
            csup = item[67];
            csdown = item[68];
        }
        else {
            rateup = item[43];
            ratedown = item[44];
            csup = item[59];
            csdown = item[60];
        }
        calcu = getCalcu(csup, csdown);
        if (calcu >= 0) {
            calcuup = "";
            calcudown = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
        }
        else {
            calcuup = "&nbsp;&nbsp;&nbsp;&nbsp;" + calcu;
            calcudown = "";
        }
    }
    rateup = rateup.toFixed(3);
    ratedown = ratedown.toFixed(3);
    var clickcsup = item[0] + "," + item[6] + ",\'l_ds\'," + item[5];
    var clickcsdown = item[0] + "," + item[8] + ",\'l_ds\'," + item[5];
    var clickrateup = item[0] + ",'\L\',\'DS\',$(this)";
    var clickratedown = item[0] + ",'\R\',\'DS\',$(this)";
    if (item[5] == 8 || item[5] == 9)
        html = String.format(HTML_HISTORY_PK, headup, headdown, "單", "雙",
                                rateup, ratedown, csup, csdown, calcuup, calcudown);
    else
        html = String.format(HTML_PK, headup, headdown, "單", "雙",
                                    rateup, ratedown, csup, csdown, calcuup, calcudown,
                                    "ds", item[0], clickrateup, clickratedown, clickcsup, clickcsdown);
    return html;
}
function setRate(id, team, playtype, obj) {
    if (team == "L") {
        var _tempR = $(obj.parent().parent().find('div')[1]).find('a');
        _tempR.html((parseFloat(_tempR.html()) - 0.01).toFixed(3));

        obj.html((parseFloat(obj.html()) + 0.01).toFixed(3));
    }

    if (team == "R") {
        var _tempL = $(obj.parent().parent().find('div')[0]).find('a');
        _tempL.html((parseFloat(_tempL.html()) - 0.01).toFixed(3));

        obj.html((parseFloat(obj.html()) + 0.01).toFixed(3));
    }
    var http = GetXMLHTTP();

    var url = "../../Pages/ball_game.aspx?WF=" + playtype + "&PL=" + team + "&N_ID=" + id + "&random=" + Math.random();
    http.open("get", url, false);
    http.send();
}


function setGoalRate(id, team, playtype, obj) {
    if (team == "L") {
        var _tempR = $(obj.parent().next("td")).find('.redlink');
        _tempR.html((parseFloat(_tempR.html()) - 0.01).toFixed(2));

        obj.html((parseFloat(obj.html()) + 0.01).toFixed(2));
    }

    if (team == "R") {
        var _tempL = $(obj.parent().prev("td")).find('.redlink');
        _tempL.html((parseFloat(_tempL.html()) - 0.01).toFixed(2));

        obj.html((parseFloat(obj.html()) + 0.01).toFixed(2));
    }
    var http = GetXMLHTTP();

    var url = "../../Pages/ball_game.aspx?WF=" + playtype + "&PL=" + team + "&N_ID=" + id + "&random=" + Math.random();
    http.open("get", url, false);
    http.send();
}
function GetXMLHTTP() {
    var A = null;
    try {
        A = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch (e) {
        try {
            A = new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (e) {
            A = null;
        }
    }
    if (!A && XMLHttpRequest != null) {
        A = new XMLHttpRequest();
    }
    return A;
}
function openFastSet(objValue, objPK) {
    var strPara = "height=200px, width=600px, top=300px, left=200px, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no";
    var StrRtn = window.open("GameFastSet.aspx?random=" + Math.random() + "&N_ID=" + objValue + "&PK=" + objPK, objPK, strPara);
}
function openBillDetail(id, teamId, playType, playId) {
   
    var strPara = "height=700px, width=800px, top=200px, left=450px, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no";
    var strRtn = window.open("GameDetail.aspx?random=" + Math.random() + "&id=" + id + "&ti=" + teamId + "&pt=" + playType + "&pi=" + playId + "&bt=" + getUrlParam("bt"), "openBillDetail", strPara);
    return false;
}
var HTML_SET1 = '<p class="setbtn"><a href="javascript:void(0);" onclick="{4}" status="{8}">{0}</a><a href="javascript:void(0);" onclick="{5}">{1}</a></p>\
                <p class="setbtn"><a href="javascript:void(0);" onclick="{6}">{2}</a><a href="javascript:void(0);" onclick="{7}">{3}</a></p>';
var HTML_SET2 = '<p class="setbtn"><a href="javascript:void(0);" onclick="{3}">{0}</a><a href="javascript:void(0);" onclick="{4}">{1}</a></p>\
                <p class="setbtn"><a href="javascript:void(0);" onclick="{5}">{2}</a></p>';
var HTML_SET3 = '<p class="setbtn"><a href="javascript:void(0);" onclick="{1}">{0}</a>';
function GetSetting(items) {
    var item = items.data, html;
    var type = $("#hidPlayType").val();
    var id = item[0];
    var teamId = -1;
    var playType = "all";
    var playId = item[5];
    var fnBillDetailName = "openBillDetail(" + id + "," + teamId + ",'" + playType + "'," + playId + ")";
    if (type == 9) {
        return String.format(HTML_SET2, "", "明细", "重新计算", "", fnBillDetailName, "setCalcu('" + item[1] + "'," + id + "," + playId + ")");
    }
    else if (type == 8) {
        return String.format(HTML_SET2, "回已开赛", "明细", "重新计算", "gotoBeganList(" + id + ")", fnBillDetailName, "setCalcu('" + item[1] + "'," + id + "," + playId + ")");
    }
    else if (type == 7) {
        var status = (item[16] == 2 ? "回滚球" : "回单式");
        return String.format(HTML_SET1, status, "计算", "明细", "设置", "backSingleOrRun(" + id + ")", "setCalcu('" + item[1] + "'," + id + "," + playId + ")", fnBillDetailName, "setSetting('" + item[1] + "'," + id + ")", item[16]);
    }
    else if (type == 4 || type == 5 || type == 6) {
        return String.format(HTML_SET3, "明细", fnBillDetailName);
    }
    else {
        var statusId = item[13];
        var statusName = statusId == 0 ? "开放" : "关闭"
        return String.format(HTML_SET1, statusName, "开赛", "明细", "设置", "setGameStatus(" + id + ")", "gotoBeganList(" + id + ")", fnBillDetailName, "setSetting('" + item[1] + "'," + id + ")", statusId);
    }
}
//计算
function setCalcu(ballType, id, playType) {
    var strPara = "height=300px, width=600px, top=300px, left=300px, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no";
    var StrRtn = window.open("GameCalculation.aspx?random=" + Math.random() + "&bt=" + ballType + "&id=" + id + "&pt=" + playType, playType, strPara);
}
//返回到单式或滚球
function backSingleOrRun(id) {
    var status = $("#tr" + id).find("[status]").attr("status") == "2" ? 6 : 5;
    changeStatus(status, id, $("#hidPlayType").val());
}
//进入设置
function setSetting(ballType, id) {
    var strPara = "height=800px, width=1000px, top=150px, left=200px, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no";
    var StrRtn = "";
    if (ballType == "b_zq")
        StrRtn = window.open("GamesSet.aspx?random=" + Math.random() + "&bt=" + ballType + "&id=" + id, id, strPara);
    else
        StrRtn = window.open("game_otheredit.aspx?random=" + Math.random() + "&bt=" + ballType + "&id=" + id, id, strPara);
}

//开放或关闭
function setGameStatus(id, obj) {
    var status = $("#tr" + id).find("[status]").attr("status") == "0" ? 1 : 2;
    changeStatus(status, id, $("#hidPlayType").val());
}
//到已开赛
function gotoBeganList(id) {
    changeStatus(7, id, $("#hidPlayType").val());
}
function changeStatus(actionId, idList, playType) {//改变状态
    //debugger;
    $.ajax({
        type: "post",
        dataType: "json",//返回json格式的数据
        url: "GameAjax.aspx",
        cache: false,
        async: true,
        data: {
            ai: actionId,
            il: idList,
            pt: playType,
            rad: Math.random()
        },
        complete: function () {
            //alert(1);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error!!");
        },
        success: function (retrunJson) {
            if (retrunJson == "0011") {
                alert("部分賽事已有注單，無法刪除!");
                return;
            }
            if (retrunJson != "1") {
                alert("Error...");
                return;
            }
            actionId = parseInt(actionId, 10);
            switch (actionId) {
                case 1:
                    $.each(idList.toString().split(','), function () {
                        $("#tr" + this).removeClass("graybg");
                        $("#tr" + this).find("[status]").text("关闭").attr("status", 1);
                    });
                    break;
                case 2:
                    $.each(idList.toString().split(','), function () {
                        $("#tr" + this).addClass("graybg");
                        $("#tr" + this).find("[status]").text("开放").attr("status", 0);
                    });
                    break;
                case 5:
                case 6:
                    $.each(idList.toString().split(','), function () {
                        $("#tr" + this).hide();
                    });
                    break;
                case 7:
                    $.each(idList.toString().split(','), function () {
                        $("#tr" + this).hide();
                    });
                    break;
            }
        }
    });
}
function getTeamList(obj, flag) {
    $.ajax({
        type: "post",
        dataType: "json",//返回json格式的数据
        url: "GameAjax.aspx",
        cache: false,
        async: true,
        data: {
            lm: obj.value,
            rad: Math.random()
        },
        complete: function () {
            //alert(1);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error!!");
        },
        success: function (retrunJson) {
            var option = "";
            $(retrunJson).each(function () {
                option += "<option value=\"" + this.N_ID + "\">" + this.N_DWMC + "</option>";
            });
            $("#drpVisit").html(option);
            $("#drpHome").html(option);
            $("#drpVisit").val($("#hidVisit").val());
            $("#drpHome").val($("#hidHome").val());
            $("#drpVisit").attr("disabled", flag);
            $("#drpHome").attr("disabled", flag);
        }
    });
}

function changefenshu(obj) {
    if (obj.value == 0) {
        document.getElementById('drpRFCJPL').style.display = '';
        document.getElementById('drpRFCJPL1').style.display = 'none';
    }
    else {
        document.getElementById('drpRFCJPL1').style.display = '';
        document.getElementById('drpRFCJPL').style.display = 'none';
    }
}

function CountTotal(obj1, obj2, obj3) {
    var obj1 = document.getElementById(obj1);
    var obj2 = document.getElementById(obj2);
    var obj3 = document.getElementById(obj3);
    obj3.value = (parseFloat(obj1.value) + parseFloat(obj2.value)).toFixed(3);
}
function ConRate(obj1, obj2) {
    switch (obj1.value) {
        case "1":
            obj2.value = 50;
            obj2.readOnly = false;
            break;
        case "0":
            obj2.value = 0;
            obj2.readOnly = true;
            break;
        case "-1":
            obj2.value = 50;
            obj2.readOnly = false;
            break;
        case "-2":
            obj2.value = 100;
            obj2.readOnly = true;
            break;
    }
}
function refresh(flag) {
    window.opener.$("#btnUpdate").click();
    if (flag) {
        window.close();
    }
    return false;
}
function checkAllGame(obj) {
    $("#gameContainerId").find("input[type='checkbox']").attr("checked", obj.checked);
}
function checkAllLeague(obj) {
    $("#leagueContainerId").find("input[type='checkbox']").attr("checked", obj.checked);
}
var SPECIAL_WAVE = '<p class="bd-bottom">\
                        <a href="#" class="bdredlink" onclick="ShowRateDiv({6})">{0}</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="openBillDetail({4})">{2}</a>\
                    </p>\
                    <p>\
                        <a href="#" class="bdredlink" onclick="ShowRateDiv({7})">{1}</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="openBillDetail({5})">{3}</a>\
                    </p>';
var SPECIAL_OTHER = '<a href="#" class="redlink" onclick="{4}({3})">{0}</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="openBillDetail({2})">{1}</a>';
function GetSpecialWave(items, indexRateUp, indexCSUp, indexRateDown, indexCSDown, bdtype) {
    var item = items.data;
    var clickupcs = item[0] + "," + item[6] + ",\'l_bd" + bdtype + "\'," + item[5];
    var clickdowncs = item[0] + "," + item[8] + ",\'l_bd" + getReverseStr(bdtype) + "\'," + item[5];
    var clickkuprate = item[0] + ",\'N_BDZPL" + bdtype + "\'," + item[5] + ",$(this)";
    var clickdownrate = item[0] + ",\'N_BDKPL" + bdtype + "\'," + item[5] + ",$(this)";
    return String.format(SPECIAL_WAVE, item[indexRateUp], item[indexRateDown], item[indexCSUp], item[indexCSDown], clickupcs, clickdowncs, clickkuprate, clickdownrate);
}
//字符串反序输出
function getReverseStr(s) {
    var b = s.split('');
    b.reverse()
    return b.join('');
}

//入球足球数，半全场
function GetSpecialOther(items, indexRate, indexCS, otherType) {
    var item = items.data, html;
    var clickcs, clickkrate;
    var fn = "ShowRateDiv";
    switch (item[5]) {
        case 4:
            clickcs = item[0] + "," + item[19] + ",\'l_bd" + otherType + "\'," + item[5];
            clickkrate = item[0] + ",\'N_BDGPL" + otherType + "\'," + item[5] + ",$(this)";
            break;
        case 5:
            clickcs = item[0] + ",\'0\',\'l_rqs" + otherType + "\'," + item[5];
            if (otherType == "d" || otherType == "s") {
                var LR = otherType == "d" ? "L" : "R";
                var clickkrate = item[0] + ",\'" + LR + "\',\'DS\',$(this)";
                fn = "setGoalRate";
            }
            else {
                clickkrate = item[0] + ",\'N_RQSPL" + otherType + "\'," + item[5] + ",$(this)";
            }
            break;
        case 6:
            clickcs = item[0] + ",\'0\',\'l_bqc" + otherType + "\'," + item[5];
            clickkrate = item[0] + ",\'N_BQC" + otherType + "\'," + item[5] + ",$(this)";
            break;
    }
    return String.format(SPECIAL_OTHER, item[indexRate], item[indexCS], clickcs, clickkrate, fn);
}
function GetZWRQ(dtzwrq) {
    var myzwrq = [];
    for (i = 0; i < 10; i++) {
        myzwrq.push((new Date(dtzwrq).setDate(-i)).toString());
    }
    return myzwrq;
}
var Mintus = 0;
var objInterval = null;
//自动更新
function FnAutoupdate(sMintus) {
    if (sMintus == "") {
        Mintus = 0;
        $("#lblMintus").text("");
        window.clearInterval(objInterval);
        return;
    }
    window.clearInterval(objInterval);
    $("#lblMintus").text(sMintus);
    window.Times = sMintus;
    Mintus = window.Times;
    objInterval = window.setInterval(function () {
        ReloadBall();
    }, 1000);
}

//定时刷新
function ReloadBall() {
    Mintus--;
    if ($("#lblMintus").length > 0) {
        $("#lblMintus").text(Mintus);
        if (Mintus <= 0) {
            pageLoad();
            Mintus = window.Times;
        }
    }
}

function ShowRateDiv(id, pType, playType, objBD) {
    var strhtml = '<table style="background-color:White;border:1px solid #ccc"><tr><td>\
                    <span id="bot1" style="width: 40;">賠率 </span>\
                 </td>\
                 <td>\
                    <input type="text" id="txtshow" value="">\
                 </td>\
            </tr>\
            <tr>\
                <td colspan="2">\
                    <input type="button" id="btnshow" value="確定">\
                    <input type="button" id="btnclose" value="關閉">\
                </td>\
            </tr></table>'

    $("#showdiv").html(strhtml);

    var xy = objBD.position();
    $("#showdiv").css("top", xy.top + 20);
    $("#showdiv").css("left", xy.left);

    $("#btnshow").die().live('click', function () {
        var obj = $("#txtshow")[0];
        if (obj.value == "") {
            alert("请输入数字");
            return false;
        }
        else {
            changeRate(id, pType, obj.value);
            objBD.html(obj.value);
        }
    });
    $("#btnclose").die().live('click', function () {
        $("#showdiv").hide();
    });
    $("#txtshow").die().live('blur', function () {

        if (this.value != "") {
            if (isNaN(this.value)) {
                alert("输入有误，请输入数字")
                this.focus();
            }
        }
        //	    else
        //	    {
        //		    alert("请输入数字")
        //		    this.focus();
        //	    }
    });
    $("#showdiv").show();
}

function changeRate(nid, sFiled, nValue) {//改变rate
    $.ajax({
        type: "post",
        dataType: "json",//返回json格式的数据
        url: "GameAjax.aspx",
        cache: false,
        async: true,
        data: {
            tid: nid,
            tFiled: sFiled,
            tValue: nValue,
            rad: Math.random()
        },
        complete: function () {
            //alert(1);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error!!");
        },
        success: function (retrunJson) {
            if (retrunJson != "1") {
                alert("Error...");
                return;
            }
        }
    });
}

function CountTotal(obj1, obj2, obj3) {
    var obj1 = document.getElementById(obj1);
    var obj2 = document.getElementById(obj2);
    var obj3 = document.getElementById(obj3);
    obj3.value = (parseFloat(obj1.value) + parseFloat(obj2.value)).toFixed(3);
}

function CountRate(obj1, obj2, obj3, obj, type) {
    if (type != null)
        type = 10.000;
    else
        type = 2.000;
    if (obj == 3) {
        if (parseFloat(obj3.value) > type) {
            obj3.value = type;
        }
        obj1.value = (parseFloat(obj3.value) / 2).toFixed(3);
        obj2.value = (parseFloat(obj3.value) / 2).toFixed(3);
        obj3.value = parseFloat(obj3.value).toFixed(3);
    }
    else if (obj == 2) {
        if (parseFloat(obj2.value) > type) {
            obj2.value = type;
        }
        obj1.value = (parseFloat(obj3.value) - parseFloat(obj2.value)).toFixed(3);
        obj2.value = parseFloat(obj2.value).toFixed(3);
    }
    else {
        if (parseFloat(obj1.value) > type) {
            obj1.value = type;
        }
        obj2.value = (parseFloat(obj3.value) - parseFloat(obj1.value)).toFixed(3);
        obj1.value = parseFloat(obj1.value).toFixed(3);
    }
}