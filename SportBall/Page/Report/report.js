function seleAll(obj) {
    var chbool = obj.checked;
    if (document.all.ctl00$ContentPlaceHolder11$chbk != null) {
        document.all.ctl00$ContentPlaceHolder11$chbk.checked = chbool;
    }
    if (document.all.ctl00$ContentPlaceHolder11$chbj != null) {

        document.all.ctl00$ContentPlaceHolder11$chbj.checked = chbool;
    }
    if (document.all.ctl00$ContentPlaceHolder11$chby != null) {

        document.all.ctl00$ContentPlaceHolder11$chby.checked = chbool;

    }
    if (document.all.ctl00$ContentPlaceHolder11$chbb != null) {

        document.all.ctl00$ContentPlaceHolder11$chbb.checked = chbool;
    }
    if (document.all.ctl00$ContentPlaceHolder11$chzq != null) {

        document.all.ctl00$ContentPlaceHolder11$chzq.checked = chbool;

    }
    if (document.all.ctl00$ContentPlaceHolder11$chbf != null) {
        document.all.ctl00$ContentPlaceHolder11$chbf.checked = chbool;

    }
    if (document.all.ctl00$ContentPlaceHolder11$chzs != null) {

        document.all.ctl00$ContentPlaceHolder11$chzs.checked = chbool;

    }
    if (document.all.ctl00$ContentPlaceHolder11$chsm != null) {

        document.all.ctl00$ContentPlaceHolder11$chsm.checked = chbool;

    }
    if (document.all.ctl00$ContentPlaceHolder11$chlhc != null) {

        document.all.ctl00$ContentPlaceHolder11$chlhc.checked = chbool;


    }
    if (document.all.ctl00$ContentPlaceHolder11$chdlt != null) {

        document.all.ctl00$ContentPlaceHolder11$chdlt.checked = chbool;

    }
    if (document.all.ctl00$ContentPlaceHolder11$chjc != null) {

        document.all.ctl00$ContentPlaceHolder11$chjc.checked = chbool;


    }
    if (document.all.ctl00$ContentPlaceHolder11$chcp != null) {

        document.all.ctl00$ContentPlaceHolder11$chcp.checked = chbool;


    }
    if (document.all.ctl00$ContentPlaceHolder11$chbq != null) {

        document.all.ctl00$ContentPlaceHolder11$chbq.checked = chbool;


    }
    if (document.all.ctl00$ContentPlaceHolder11$chss != null) {

        document.all.ctl00$ContentPlaceHolder11$chss.checked = chbool;


    }
    if (document.all.ctl00$ContentPlaceHolder11$chcq != null) {

        document.all.ctl00$ContentPlaceHolder11$chcq.checked = chbool;

    }


}

function SethidValue(jb, id) {
    document.all.ctl00$ContentPlaceHolder11$hidjb.value = jb;
    if (jb != "11")
        document.all.ctl00$ContentPlaceHolder11$hidzh.value = id;
}

function SetValue(obj, value) {
    obj.innerText = value;
    document.all.ctl00$ContentPlaceHolder11$hidzwrq.value = value;
    return false;
}
function SetLsTime(obj, value1, value2) {
    document.all.ctl00$ContentPlaceHolder11$txtkjsj.value = value1;
    document.all.ctl00$ContentPlaceHolder11$txtjssj.value = value2;
    return false;
}

function GGUP(obj) {
    //var vaction=document.all.form1.action;
    document.all.form1.action = "re_zdcx.aspx?zdid=" + obj.id;
    //alert(document.all.form1.action);
    document.all.form1.submit();
}


function confirmsreason() {
    if (confirm("確定要刪除嗎？") == true) {
        var delreason = window.prompt(alert("請輸入刪除原因："), '');
        if (delreason == null) delreason = "";
        document.getElementById("ContentPlaceHolder11_delyy").value = delreason;
        return true;
    }
    return false;
}

function xiugaiconfirms() {
    return alert("確定要修改嗎？");
}
function GGUPXG(obj) {
    //var vaction=document.all.form1.action;
    document.all.form1.action = "re_zdxg.aspx?zdid=" + obj.id;
    //alert(document.all.form1.action);
    document.all.form1.submit();
}

function fn_CheckDate(obj) {
    var pat_hd = /^20\d{2}-((0[1-9]{1})|(1[0-2]{1}))-((0[1-9]{1})|([1-2]{1}[0-9]{1})|(3[0-1]{1}))$/;

    if (obj.value != "") {
        if (!pat_hd.test(obj.value)) {
            alert("日期格式不正确");
            obj.focus();
            return false;
        }
    }
    //else {
    //    alert("请输入日期");
    //    obj.focus();
    //    return false;
    //}
    return true;
}
function checkText() {
    var startText = document.getElementById("ContentPlaceHolder11_txtkjsj");
    if (startText.value == "") {
        alert("请输入起始日期");
        startText.focus();
        return false;
    }
    var EndText = document.getElementById("ContentPlaceHolder11_txtjssj");
    if (EndText.value == "") {
        alert("请输入结束日期");
        EndText.focus();
        return false;
    }
    return true;
}

function checkSubmit() {
    var startText = document.getElementById("txtNR");
    if (startText.value == "") {
        alert("请输入完整信息");
        startText.focus();
        return false;
    }
    var EndText = document.getElementById("txtFS");
    if (EndText.value == "") {
        alert("请输入完整信息");
        EndText.focus();
        return false;
    }
    var txtBL = document.getElementById("txtBL");
    if (txtBL.value == "") {
        alert("请输入完整信息");
        txtBL.focus();
        return false;
    }
    var txtXT = document.getElementById("txtXT");
    if (txtXT.value == "") {
        alert("请输入完整信息");
        txtXT.focus();
        return false;
    }
    return true;
}

function GGUPWQR(obj) {
    document.all.form1.action = "re_zdwqr.aspx?zdid=" + obj.id;
    document.all.form1.submit();
}


function Checkpage() {
    var txtBetNumber = document.getElementById("ContentPlaceHolder11_txtBetNumber");
    if (txtBetNumber.value == "") {
        alert("请输入单号");
        txtBetNumber.focus();
        return false;
    }
    if (document.getElementById("ContentPlaceHolder11_drptype").value == "3" && document.getElementById("ContentPlaceHolder11_txtContent").value == "") {
        alert("请填写备注");
        document.getElementById("ContentPlaceHolder11_txtContent").focus();
        return false;
    }
    return true;
}









var vtimeQuick = -1;
var timeGoQuick = null;
var objtime = 6;
function SetTimeQuick() {
    document.all.btstart.disabled = true;

    TranNew();

    vtimeQuick = objtime;
    if (vtimeQuick > 0) {
        window.clearTimeout(timeGoQuick);
        
        document.all.ContentPlaceHolder11_lbtime.innerText = vtimeQuick;
        if (objtime != 0) {
            timeGoQuick = setInterval(timeQuick, 1000);
        }
    }
    else {
        document.all.ContentPlaceHolder11_lbtime.innerText = "";
        window.clearTimeout(timeGoQuick);
    }
}
function timeQuick() {
    if (vtimeQuick < 0) {
        document.all.ContentPlaceHolder11_lbtime.innerText = "";
        window.clearTimeout(timeGoQuick);
    }
    else {
        vtimeQuick = vtimeQuick - 1;
        if (vtimeQuick == 0) {
            TranNew();
            vtimeQuick = objtime;
        }
        else {

            document.all.ContentPlaceHolder11_lbtime.innerText = vtimeQuick;
        }
    }
}
function GetNowTime() {
    var today = new Date();
    var todayy = today.getYear();
    if (todayy < 1000) {
        todayy += 1900;
    }
    var todaym = today.getMonth() + 1;
    var todayd = today.getDate();
    var todayh = today.getHours();
    var todaymin = today.getMinutes();
    var todaysec = today.getSeconds();
    return todayy + "/" + todaym + "/" + todayd + " " + todayh + ":" + todaymin + ":" + todaysec;
}
function TranNew() {
    xmlHttp = InitAjax();
    // var nowTime=GetNowTime();    
    var type = GetType();
    var Post_Url = document.forms[0].action + "";
    //  var GetT=document.all.hidtime.value;

    var nowTime = document.all.ctl00$ContentPlaceHolder11$hidtime.value;
   
    //    if(GetT=="")
    //    {
    //        nowTime=GetNowTime();    
    //        document.all.hidtime.value=nowTime;
    //    }
    //    else 
    //    {
    //        nowTime=document.all.hidtime.value;
    //        document.all.hidtime.value=GetNowTime();   
    //    }
    //alert(nowTime);
    if (Post_Url.indexOf('?') > -1) {
        Post_Url += "&time=" + nowTime + "&type=" + type;
    }
    else {
        Post_Url += "?time=" + nowTime + "&type=" + type;
    }
    xmlHttp.open("POST", Post_Url, true);
    xmlHttp.onreadystatechange = upPage;
    xmlHttp.send(null);
}


function GetType() {
    var caiz = document.getElementsByTagName("INPUT");
    var vreturn = "";
    var vflag = "";
    for (var cz = 0; cz < caiz.length ; cz++) {
        if (caiz[cz].type == "checkbox") {
            if (caiz[cz].checked == true && caiz[cz].id != "chAll") {
                //			    if(caiz[cz].id!="chbq")
                //			    {
                vreturn = vreturn + vflag + "'" + caiz[cz].id + "'";
                //			    }
                //			    else
                //			    {
                //			        vreturn=vreturn+vflag+"'chbj'";
                //			    }
                vflag = ",";
            }
        }
    }
    return vreturn;
}

function seleAll(obj) {
    var chbool = obj.checked;
    document.all.chbk.checked = chbool;
    document.all.chbj.checked = chbool;
    document.all.chby.checked = chbool;
    document.all.chbb.checked = chbool;
    document.all.chzq.checked = chbool;
    document.all.chbf.checked = chbool;
    document.all.chzs.checked = chbool;
    document.all.chsm.checked = chbool;
    document.all.chlhc.checked = chbool;
    document.all.chdlt.checked = chbool;
    document.all.chjc.checked = chbool;
    document.all.chcp.checked = chbool;
    document.all.chbq.checked = chbool;
    document.all.chss.checked = chbool;
    document.all.chcq.checked = chbool;
}
function selectCheckAll(obj) {


         var chbool = obj.checked;
    document.all.ctl00$ContentPlaceHolder11$chbk.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chbj.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chby.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chbb.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chzq.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chbf.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chzs.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chsm.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chlhc.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chdlt.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chjc.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chcp.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chbq.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chss.checked = chbool;
    document.all.ctl00$ContentPlaceHolder11$chcq.checked = chbool;
}

var xmlHttp = false;
/**
* 初始化一个xmlhttp对象
*/
function InitAjax() {
    var ajax = false;
    try {
        ajax = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch (e) {
        try {
            ajax = new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (E) {
            ajax = false;
        }
    }
    if (!ajax && typeof XMLHttpRequest != 'undefined') {
        ajax = new XMLHttpRequest();
    }
    return ajax;
}
function upPage() {
    if (xmlHttp.readyState == 4)   // &&   xmlHttp.status == '200') 
    {
        var response = xmlHttp.responseText;
        var oDoc = new ActiveXObject("MSXML2.DOMDocument");
        oDoc.loadXML(response);
        var root = oDoc.documentElement;

        if (root == null) {
            return false;
        }
        if (root.nodeName == "Table") {
            var tabObj = document.getElementById("tabzd");


            //目前table有多少行
            var rowCount = tabObj.rows.length;
            //每行有多少列
            var cellCount = tabObj.rows(0).cells.length;

            var varChildNode = root.childNodes;

            //时间
            var time = varChildNode[0].selectNodes("Time");
            document.all.ctl00$ContentPlaceHolder11$hidtime.value = time[0].text;

            var vN_XZDH = varChildNode[0].selectNodes("N_XZDH");

            if (varChildNode.length > 1 || vN_XZDH.length > 0) {
                for (var i = 0; i < varChildNode.length; i++) {
                    var newRow = tabObj.insertRow(2);
                    var varchildN = varChildNode[i].childNodes;
                    //颜色
                    var varcolor = varchildN[7].text;

                    //下注時間
                    var cell0 = newRow.insertCell();
                    cell0.style.backgroundColor = varcolor;
                    cell0.innerHTML = varchildN[1].text;
                    //單號
                    var cell1 = newRow.insertCell();
                    cell1.style.backgroundColor = varcolor;
                    cell1.innerHTML = varchildN[4].text + "<br/>" + varchildN[0].text;;
                    //下注會員
                    var cell2 = newRow.insertCell();
                    cell2.style.backgroundColor = varcolor;
                    cell2.innerHTML = varchildN[2].text;
                    //投注內容
                    var cell3 = newRow.insertCell();
                    cell3.style.backgroundColor = varcolor;
                    cell3.innerHTML = varchildN[5].text;
                    //投注金額
                    var cell4 = newRow.insertCell();
                    cell4.style.backgroundColor = varcolor;
                    cell4.innerHTML = varchildN[3].text;
                }
            }
        }
        else if (root.nodeName == "ZDTB") {
            //清掉TABLE
            TbClear();
            var tabObj = document.getElementById("tabzd");
            //目前table有多少行
            var rowCount = tabObj.rows.length;
            //每行有多少列
            var cellCount = tabObj.rows(0).cells.length;

            var varChildNode = root.childNodes;
            document.all.ctl00$ContentPlaceHolder11$hidtime.value = varChildNode[0].text;
            for (var i = 1; i < varChildNode.length; i++) {
                var newRow = tabObj.insertRow(2);
                var varchildN = varChildNode[i].childNodes;
                //下注時間
                var cell0 = newRow.insertCell();
                // cell0.style.backgroundColor="#FFFFFF";
                cell0.innerHTML = varchildN[1].text;
                //單號
                var cell1 = newRow.insertCell();
                // cell1.style.backgroundColor="#FFFFFF";
                cell1.innerHTML = varchildN[4].text + "<br/>" + varchildN[0].text;
                var nid = varchildN[0].text;
                //下注會員
                var cell2 = newRow.insertCell();
                // cell2.style.backgroundColor="#FFFFFF";
                cell2.innerHTML = varchildN[2].text;
                //投注內容
                var cell3 = newRow.insertCell();
                // cell3.style.backgroundColor="#FFFFFF";
                cell3.innerHTML = varchildN[5].text;
                //投注金額
                var cell4 = newRow.insertCell();
                // cell4.style.backgroundColor="#FFFFFF";
                cell4.innerHTML = varchildN[3].text;
                //操作
                var cell5 = newRow.insertCell();
                //  cell5.style.backgroundColor="#FFFFFF";

                if (varchildN[7].text == "") {
                    cell5.innerHTML = "<input id='bt" + i + "' type='button' value='" + ShowMessage("G0003", "") + "' onclick=\"Tranzd(this,'" + varchildN[6].text + "',0)\" /> ";
                    cell5.innerHTML += "<input id='btc" + i + "' type='button' value='收单' onclick=\"Tranzd(this,'" + varchildN[6].text + "',1)\" /> ";
                }
                //危險等級
                var vwxdj = varchildN[7].text;
                var vdbzd = varchildN[8].text;
                //                if(vwxdj==2)
                //                {                    
                //                    newRow.style.backgroundColor="#0000FF";
                //                }
                //                else 
                if (vwxdj == 3 || vdbzd == 1) {
                    newRow.style.backgroundColor = "#FFC0CB";
                }
                else if (vwxdj == 4) {
                    newRow.style.backgroundColor = "#FFC0CB";
                }
                else {
                    newRow.style.backgroundColor = "#FFD700";
                }
                // alert(newRow.innerHTML);   
            }

        }
        objtime = 6;
    }
    function Tranzd(obj, nid, status) {
        //    obj.disabled=true;
        //    obj.style.display='none';
        xmlHttp = InitAjax();
        // var nowTime=GetNowTime();  
        var nowTime = document.getElementById("ContentPlaceHolder11_hidtime").value;
        var type = GetType();
        var Post_Url = document.forms[0].action + "";

        if (Post_Url.indexOf('?') > -1) {
            Post_Url += "&nid=" + nid + "&status=" + status;
        }
        else {
            Post_Url += "?nid=" + nid + "&status=" + status;
        }
        xmlHttp.open("POST", Post_Url, true);
        xmlHttp.onreadystatechange = upzd;
        xmlHttp.send(null);
        obj.parentNode.innerHTML = "";
    }
}
function TbClear() {
    var tabObj = document.getElementById("tabzd");
    //目前table有多少行
    var rowCount = tabObj.rows.length;
    for (var i = 2; i < rowCount; i++) {
        //tabObj.removeChild(i);
        tabObj.rows[2].removeNode(true);
    }
    document.all.ctl00$ContentPlaceHolder11$hidtime.value = "";
}

function Btstop() {
    document.all.btstart.disabled = false;
    window.clearTimeout(timeGoQuick);
}