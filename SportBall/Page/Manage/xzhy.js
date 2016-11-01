function checkLower(a, c) {
    var isBig = 100;
    if (!isNaN(a)) {
        if (a < isBig) {
            //document.forms[0].addmember.disabled = true;
            alert("對不起，會員單注下限必須>=" + isBig);
            c.focus();
        }
        else {
            //document.forms[0].addmember.disabled = false;
        }
    }
    else {
        alert("對不起，請輸入一個數字");
        c.focus();
    }
}

function openUseeName(objHY, objDL) {
    var strPara = "dialogHeight:600px;dialogWidth:800px;status:no;scroll:yes;help:no";//showModalDialog
    //var strPara = "'dialogWidth: 300px;dialogHeight: 200px;dialogLeft: 80px;dialogTop: 50px;toolbar: no;menubar: no;resizable: yes;location: no;status: no;scrollbars: no;center:yes;'";
    var StrRtn = window.showModalDialog("CopyMember.aspx?random=" + Math.random() + "&n_hyzh=" + objHY.innerText + "&n_dls=" + objDL.innerText, "", strPara);
    if (StrRtn != null) {
        return true;
    }
    else {
        return false;
    }
}

function Check() {
    //    var mode= document.getElementById("hidMode");
    //    if(mode!=null&&mode.value=="Add") return false;
    var UserName = document.getElementById("ContentPlaceHolder11_txtUserName");
    if (UserName.value == "") {
       
        alert("請輸入會員名稱");
        UserName.select();
        return false;
    }
    var Pwd = document.getElementById("ContentPlaceHolder11_txtPwd");
    var PwdS = document.getElementById("ContentPlaceHolder11_txtPwdS");
    if (Pwd.value == "") {
      
        alert("請輸入密碼");
        Pwd.select();
        return false;
    }
    if (PwdS.value == "") {
       
        alert("請輸入確認密碼");
        PwdS.select();
        return false;
    }
    if (PwdS.value != Pwd.value) {
       
        alert("請輸入相同的新密碼和確認密碼");
        PwdS.select();
        return false;
    }
    var Pay = document.getElementById("ContentPlaceHolder11_txtPay");
    var DZXX = document.getElementById("ContentPlaceHolder11_txtDZXX");
    if (Pay.value.trim() == "") {
      
        alert("請輸入分配的信用額度");
        Pay.select();
        return false;
    }
    if (DZXX.value.trim() == "") {
      
        alert("請輸入單注下限");
        DZXX.select();
        return false;
    }
    return true;
}
function showinput(m, n) {
    var mode = document.getElementById("ContentPlaceHolder11_hidMode");
    if (mode != null && mode.value == "Add") return false;
    var obj = document.getElementsByTagName("div");
    var objInput = document.getElementById(m);

    selectedRow = objInput;
    selectedRow.style.color = '';

    var links = selectedRow.getElementsByTagName('a');
    var linksCount = links.length;

    for (var i = 0; i < linksCount; i++) {
        links[i].style.color = '';
    }

    var oTemp = "1"
    for (ii = 0; ii < obj.length ; ii++) {
        if (obj[ii].name == n) {
            if (obj[ii].style.display == "block") {
                oTemp = "2";
            }
        }
    }
    if (oTemp == "1") {
        for (k = 0; k < obj.length ; k++) {
            if (obj[k].style.display == "block") {
                obj[k].style.display = "none";
            }
        }
        var obj1 = document.getElementsByTagName("INPUT");
        for (kk = 0; kk < obj1.length ; kk++) {
            if (obj1[kk].className == "showinput") {
                obj1[kk].className = "hiddeninput";
                obj1[kk].readOnly = true;
                obj1[kk].parentElement.parentElement.style.background = "#FFFFFF";//EDEDED
            }
        }
    }
    else {
        selectedRow = null;
    }
    for (i = 0; i < obj.length ; i++) {
        if (obj[i].name == n) {
            if (obj[i].style.display == "block") {
                obj[i].style.display = "none";
            }
            else {
                obj[i].style.display = "block";
            }
        }
    }

    for (j = 0; j < objInput.all.length ; j++) {

        if (objInput.all(j).tagName == "INPUT") {
            if (objInput.all(j).className == "showinput") {
                objInput.all(j).className = "hiddeninput";
                objInput.style.background = "#FFFFFF";
            }
            else {
                objInput.all(j).className = "showinput";
                objInput.style.background = "#FFF79B";
            }
            if (objInput.all(j).readOnly) {
                objInput.all(j).readOnly = false;
            }
            else {
                objInput.all(j).readOnly = true;
            }
        }
    }
    return false;
}
function CheckNext(cid, cvalue, cobj) {
    _onlyNum(cobj);
    if (cobj.readOnly == true) {
        return false;
    }
    else {
        if (cobj.value.trim() == "") {
            alert("請輸入一個數字");
            cobj.select();
            return false;
        }
        else {
            if (isNaN(cobj.value.trim()) == true) {
                alert("請輸入一個數字");
                cobj.select();
                return false;
            }
            else {
                var cinput = document.getElementById(cid);
                for (n = 0; n < cinput.childNodes.length - 1; n++) {
                    if (cinput.childNodes[n].childNodes[0] == cobj) {
                        var temp = cinput.childNodes[n].childNodes[1].innerText;
                        var temp1 = temp.split(" ");
                        cinput.childNodes[0].style.color = "#000000";
                        cinput.childNodes[n].style.color = "#000000";
                        if (cobj.value > parseFloat(temp1["1"])) {
                            cinput.childNodes[0].style.color = "#FF0000";
                            cinput.childNodes[n].style.color = "#FF0000";
                            alert("您現在修改的數值大於您當前下線的最大數值");
                            cobj.select();
                            break;
                        }
                    }
                }
            }
        }
    }
}
function setVale(tid, tvalue, tobj) {
    if (tobj.value.trim() == "") {
        return false;
    }
    _onlyNum(tobj);
    if (tobj.readOnly == true) {
        return false;
    }
    else {
        if (isNaN(tvalue) == true) {
         
            alert("請輸入數字");
            return false;
        }
        var tInput = document.getElementById(tid);
        for (k = 0; k < tInput.all.length ; k++) {
            if (tInput.all(k).tagName == "INPUT" && tInput.all(k).parentElement.style.display != 'none') {
                if (tInput.all(k).name.substring(tInput.all(k).name.length - 4) != 'GGTY' && tInput.all(k).name.substring(tInput.all(k).name.length - 4) != 'GGDC' && tInput.all(k).name.substring(tInput.all(k).name.length - 4) != 'GGDZ' && tInput.all(k).name.substring(tInput.all(k).name.length - 4) != 'GGDD') {
                    tInput.all(k).value = parseFloat(tobj.value);
                }
            }
        }
        var b_Flag = false;
        for (n = 0; n < tInput.childNodes.length - 1; n++) {
            if (tInput.childNodes[n].childNodes[0].tagName == "DIV") {
                var temp2 = tInput.childNodes[n].childNodes[0].childNodes[0].value;
                var temp = tInput.childNodes[n].childNodes[0].childNodes[1].innerText;
                var temp1 = temp.split(" ");
                tInput.childNodes[0].style.color = "#000000";
                tInput.childNodes[n].childNodes[0].style.color = "#000000";
                if (parseFloat(temp2) > parseFloat(temp1["1"])) {
                    tInput.childNodes[0].style.color = "#FF0000";
                    tInput.childNodes[n].childNodes[0].style.color = "#FF0000";
                    b_Flag = true;
                }
            }
            else {
                var temp2 = tInput.childNodes[n].childNodes[0].value;
                var temp = tInput.childNodes[n].childNodes[1].innerText;
                var temp1 = temp.split(" ");
                tInput.childNodes[0].style.color = "#000000";
                tInput.childNodes[n].style.color = "#000000";
                if (parseFloat(temp2) > parseFloat(temp1["1"])) {
                    tInput.childNodes[0].style.color = "#FF0000";
                    tInput.childNodes[n].style.color = "#FF0000";
                    b_Flag = true;
                }
            }
        }
        if (b_Flag) {
            alert("您現在修改的數值大於您當前下線的最大數值");
            for (n = 0; n < tInput.childNodes.length - 1; n++) {
                //				var temp = tInput.childNodes[n].childNodes[1].innerText;
                //				var temp1 = temp.split(" ");
                //				tInput.childNodes[0].style.color="#000000";
                //				tInput.childNodes[n].style.color="#000000";
                //				tInput.childNodes[n].childNodes[0].value = parseFloat(temp1["1"]);
                if (tInput.childNodes[n].childNodes[0].tagName == "DIV") {
                    var temp = tInput.childNodes[n].childNodes[0].childNodes[1].innerText;
                    var temp1 = temp.split(" ");
                    tInput.childNodes[0].style.color = "#000000";
                    tInput.childNodes[n].childNodes[0].style.color = "#000000";
                    tInput.childNodes[n].childNodes[0].childNodes[0].value = parseFloat(temp1["1"]);
                }
                else {
                    var temp = tInput.childNodes[n].childNodes[1].innerText;
                    var temp1 = temp.split(" ");
                    tInput.childNodes[0].style.color = "#000000";
                    tInput.childNodes[n].style.color = "#000000";
                    tInput.childNodes[n].childNodes[0].value = parseFloat(temp1["1"]);
                }
            }
        }
    }
    //acd(tid,tvalue);
}

function checkED(obj, mode) {
    _onlyNum(obj);
    var lbLeftED = document.getElementById("ContentPlaceHolder11_lbLeftED");
    var txtLeftED = document.getElementById("ContentPlaceHolder11_txtLeftED");
    var lblPay = document.getElementById("ContentPlaceHolder11_lblPay");
    var txtDLSED = document.getElementById("ContentPlaceHolder11_txtDLSED");
    if (mode != null) {
        if (parseFloat(obj.value) > (parseFloat(txtDLSED.innerText) + parseFloat(lblPay.innerText))) {
            Show("A0042", (parseFloat(txtDLSED.innerText) + parseFloat(lblPay.innerText)).toFixed(3));
            obj.focus();
            return false;
        }
        else if (parseFloat(obj.value) < (parseFloat(lblPay.innerText) - parseFloat(lbLeftED.innerText))) {
            Show("A0040", (parseFloat(lblPay.innerText) - parseFloat(lbLeftED.innerText)).toFixed(3));
            obj.focus();
            return false;
        }
    }
    else {
        if (parseFloat(obj.value) > parseFloat(txtDLSED.innerText)) {
            Show("A0042", parseFloat(txtDLSED.innerText).toFixed(3));
            obj.focus();
            return false;
        }
    }
    txtLeftED.value = (parseFloat(obj.value) - parseFloat(lblPay.innerText) + parseFloat(lbLeftED.innerText)).toFixed(3);;
    return true;
}