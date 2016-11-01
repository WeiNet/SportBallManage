function CheckZS(obj) {
    if (obj.value != "") {
        _onlyNum(obj);
        if (obj.value.indexOf('.') > -1) {
            alert("不能有小數點");
            obj.value = Math.floor(obj.value);
            //        obj.focus();
        }
    }
}
function checkCZ(obj, name, chevalue) {
    _onlyNum(obj);
    if (obj.value.indexOf('.') > -1) {
        alert(name+"拆帳不能有小數點");
        obj.focus();
    }
    if (obj.value == "") {
        alert(name+"拆帳為空");
        obj.focus();
    }
    else {
        if (parseInt(obj.value) > parseInt(chevalue)) {
            alert(name + "拆帳不能大於" + chevalue); 
            obj.value = "";
            obj.focus();
        }
    }
}

function checkInput() {
    var obj1 = document.getElementsByTagName("INPUT");

    for (var kk = 0; kk < obj1.length ; kk++) {
        if (obj1[kk].value == "" && obj1[kk].id.indexOf("ALL") == -1 && obj1[kk].type != 'hidden') {
            alert("請完整的填寫新增信息")
            return false;
        }
    }
    return true;
}
function chMM() {
    var m1 = document.all.ContentPlaceHolder11_txtmm;
    var m2 = document.all.ContentPlaceHolder11_txtzrmm;
    if (m1.value != "" && m2.value != "") {
        if (m1.value != m2.value) {
            alert("請輸入相同的新密碼和確認密碼");
            return false;
        }
    }
    return true;
}

function chxyed(obj, name, values, min)//信用額度0 單隊上限1
{
    if (name == '1' && parseFloat(values) == 0) {
        return;
    }
    if (name == '1' && parseFloat(values) != 0 && parseFloat(obj.value) == 0) {
        alert("單隊上限必須大於0，小於" + values); 
        obj.value = "";
        obj.focus();
    }
    if (parseFloat(obj.value) > parseFloat(values)) {
        if (name == '1')
            alert("單隊上限不能大於" + values);
        else
            alert("信用額度不能大於" + values);
        obj.value = "";
        obj.focus();
    }
    else if (parseFloat(obj.value) < parseFloat(min)) {
        if (name == '1')
            alert("單隊上限不能小於" + min);

        else
            alert("信用額度不能小於" + min);
        obj.value = "";
        obj.focus();
    }
}
function AllDisable(obj) {
    if (obj == "ALL") {
        var txtobj = document.getElementsByTagName("INPUT");
        var divobj = document.getElementsByTagName("DIV");

        for (var i = 0; i < txtobj.length; i++) {
            if (txtobj[i].type == "text" && (txtobj[i].id != "ContentPlaceHolder11_txtzjmc" && txtobj[i].id != "ContentPlaceHolder11_txtzrmm" && txtobj[i].id != "ContentPlaceHolder11_txtmm" && txtobj[i].id != "ContentPlaceHolder11_txtxyed" && txtobj[i].id != "ContentPlaceHolder11_txtsyed" && txtobj[i].id != "ContentPlaceHolder11_txtddsx"))//txtsyed
            {
                txtobj[i].readOnly = true;
            }
        }
        for (var i = 0; i < divobj.length; i++) {
            divobj[i].style.display = "none";
        }
        return true;

    } else {
        var txtobj = document.getElementsByTagName("INPUT");
        var divobj = document.getElementsByTagName("DIV");

        for (var i = 0; i < txtobj.length; i++) {
            if (txtobj[i].type == "text" && (txtobj[i].id.indexOf("txt" + obj) > -1))//txtsyed
            {
                if (txtobj[i].readOnly == true) {
                    txtobj[i].readOnly = false;
                }
                else {
                    txtobj[i].readOnly = true;
                }
            }
        }
        for (var i = 0; i < divobj.length; i++) {
            if (divobj[i].id.indexOf("div" + obj) > -1)//txtsyed
            {
                if (divobj[i].style.display == "none") {
                    divobj[i].style.display = "";
                }
                else {
                    divobj[i].style.display = "none";
                }
            }
        }
        return false;
    }
}
function SetAllValue(obj) {
    var parent = obj.parentElement.parentElement;
    var GetElement = parent.children;
    for (var i = 0; i < GetElement.length; i++) {
        var txtobj = GetElement[i].children[0];
        //if(txtobj.type=="text")
        if (txtobj.type == "text" && GetElement[i].style.display != 'none') {
            if (obj.value != "") {
                if (txtobj.id.substring(txtobj.id.length - 5) != 'tycgg' && txtobj.id.substring(txtobj.id.length - 4) != 'tygg' && txtobj.id.substring(txtobj.id.length - 4) != 'dcgg' && txtobj.id.substring(txtobj.id.length - 4) != 'dzgg') {
                    txtobj.value = obj.value;
                }
            }
        }
    }
}
function CheckZS(obj) {
    if (obj.value != "") {
        _onlyNum(obj);
        if (obj.value.indexOf('.') > -1) {
            alert("不能有小數點");
            obj.value = Math.floor(obj.value);
            //        obj.focus();
        }
    }
}
function CheckDelXJ() {
    var hiddelxj = document.getElementById('ContentPlaceHolder11_hiddelxj').value;
    if (hiddelxj == "1")
        return confirm("存在下級會員，是否確定要刪除？");
    return true;
}

function SetAble() {
    var txtobj = document.getElementsByTagName("INPUT");
    var checkbool = true;
    var hidvalue = "";
    for (var i = 0; i < txtobj.length; i++) {
        if (txtobj[i].id.indexOf("txt") > -1) {
            var txtid = txtobj[i].id;
            var lbid = document.getElementById(txtid.replace("txt", "lb"));
            if (lbid != null) {
                if (isNaN(txtobj[i].value) == true) {
                    alert("請輸入數字");
                    txtobj[i].style.color = "#FF0000";
                    return false;
                }
                if (parseFloat(txtobj[i].value) > parseFloat(lbid.innerText)) {
                    alert("複製成功");
                    txtobj[i].style.color = "#FF0000";
                    // txtobj[i].focus();
                    lbid.style.color = "#FF0000";
                    return false;
                }
                var lbtid = document.getElementById(lbid.id + "t");
                if (lbtid != null) {
                    var indexs = lbtid.innerText.indexOf(")");
                    var lbtvalue = lbtid.innerText.substring(indexs + 1);
                    if (parseFloat(txtobj[i].value) < parseFloat(lbtvalue)) {
                        if (txtid.indexOf("txtcz") == -1) {
                            txtid = txtid.replace("txt", "");
                            var index = getIndex(txtid);
                            hidvalue = hidvalue + txtid.substring(0, index) + ":" + txtid.substring(index + 2) + "" + txtid.substring(index, index + 2) + "," + txtobj[i].value + ";";
                        }
                        else {
                            txtid = txtid.replace("txtcz", "");
                            hidvalue = hidvalue + "cz:" + txtid + "," + txtobj[i].value + ";";
                        }
                        checkbool = false;
                        txtobj[i].style.color = "#FF0000";
                        lbtid.style.color = "#FF0000";
                    }
                }
            }

        }

    }
    if (checkbool == false) {
        if (confirm("你所填寫的數據有部分低於你的下限，是否要更新？")) {
            if (confirm("你真的要批量修改您的下級嗎？")) {
                checkbool = true;
            }
        }
    }
    if (checkbool == true) {
        var hidobj = document.getElementById("ContentPlaceHolder11_hidvalue");
        hidobj.value = hidvalue;
        var txtnobj = document.getElementsByTagName("INPUT");
        for (var i = 0; i < txtnobj.length; i++) {

            if (txtnobj[i].type == "text") {
                txtnobj[i].disabled = false;
            }
        }
        return true;
    }
    else {
        return false;
    }

}

function getIndex(strID) {
    var Index = -1;
    if (strID.indexOf("ty") > -1) {
        Index = strID.indexOf("ty");
    }
    else if (strID.indexOf("lqdd") > -1) {
        Index = strID.indexOf("lqdd") + 2;
    }
    else if (strID.indexOf("dz") > -1) {
        Index = strID.indexOf("dz");
    }
    else if (strID.indexOf("dc") > -1) {
        Index = strID.indexOf("dc");
    }
    return Index;
}