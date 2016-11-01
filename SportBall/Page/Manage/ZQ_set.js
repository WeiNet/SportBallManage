var highlightcolor = '#eafcd5';
//此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
var clickcolor = '#51b2f6';
function changeto() {
    source = event.srcElement;
    if (source.tagName == "TR" || source.tagName == "TABLE")
        return;
    while (source.tagName != "TD")
        source = source.parentElement;
    source = source.parentElement;
    cs = source.children;
    //alert(cs.length);
    if (cs[1].style.backgroundColor != highlightcolor && source.id != "nc" && cs[1].style.backgroundColor != clickcolor)
        for (i = 0; i < cs.length; i++) {
            cs[i].style.backgroundColor = highlightcolor;
        }
}

function changeback() {
    if (event.fromElement.contains(event.toElement) || source.contains(event.toElement) || source.id == "nc")
        return
    if (event.toElement != source && cs[1].style.backgroundColor != clickcolor)
        //source.style.backgroundColor=originalcolor
        for (i = 0; i < cs.length; i++) {
            cs[i].style.backgroundColor = "";
        }
}

function clickto() {
    source = event.srcElement;
    if (source.tagName == "TR" || source.tagName == "TABLE")
        return;
    while (source.tagName != "TD")
        source = source.parentElement;
    source = source.parentElement;
    cs = source.children;
    //alert(cs.length);
    if (cs[1].style.backgroundColor != clickcolor && source.id != "nc")
        for (i = 0; i < cs.length; i++) {
            cs[i].style.backgroundColor = clickcolor;
        }
    else
        for (i = 0; i < cs.length; i++) {
            cs[i].style.backgroundColor = "";
        }
}
function SetSX(obj) {
    if (obj.value.trim() == "") return;
    var obj1 = document.getElementsByTagName("INPUT");
    var sPer = obj.id.substring(0, 5);
    for (var kk = 0; kk < obj1.length ; kk++) {
        if (obj1[kk].id.indexOf(sPer) > -1) {
            obj1[kk].value = obj.value;
        }
    }
}
function SetTY(obj) {
    var obj1 = document.getElementsByTagName("select");
    var sPer = obj.id.substring(0, 6);
    for (var kk = 0; kk < obj1.length ; kk++) {
        if (obj1[kk].id.indexOf(sPer) > -1) {
            obj1[kk].value = obj.value;
        }
    }
}
function checkBallInput() {
    var obj1 = document.getElementsByTagName("INPUT");

    for (var kk = 0; kk < obj1.length ; kk++) {
        if (obj1[kk].value == "" && obj1[kk].id.indexOf("all") == -1 && obj1[kk].type != 'hidden') {
            alert(obj1[kk].id)
            alert("請完整的填寫新增信息");
            return false;
        }
    }
    return true;
}

function SetBallAble() {
    var txtobj = document.getElementsByTagName("INPUT");
    var txtobj1 = document.getElementsByTagName("select");
    var checkbool = true;
    var hidvalue = "";
    for (var i = 0; i < txtobj.length; i++) {
        if (txtobj[i].id.indexOf("txt") > -1)//判断是不是文本框
        {
            var txtid = txtobj[i].id;
            var lbid = document.getElementById(txtid.replace("txt", "lb"));//上级帐号的设定
            if (lbid != null) {
                if (isNaN(txtobj[i].value) == true)//判断文本框输入是不是数字
                {
                    alert("請輸入數字");
                    txtobj[i].style.color = "#FF0000";
                    return false;
                }
                if (parseFloat(txtobj[i].value) > parseFloat(lbid.innerText))//判断输入的设定值是不是大于上级用户的设定值
                {
                    alert("輸入的數值不能大於上級");
                    txtobj[i].style.color = "#FF0000";
                    lbid.style.color = "#FF0000";
                    return false;
                }
                var lbtid = document.getElementById(lbid.id + "t");//下级帐号的设定
                if (lbtid != null && lbtid.innerText.trim() != "") {
                    var indexs = lbtid.innerText.indexOf(")");
                    var lbtvalue = lbtid.innerText.substring(indexs + 1);
                    if (parseFloat(txtobj[i].value) < parseFloat(lbtvalue))//判断输入的设定值是不是小于下级用户的设定值
                    {
                        txtid = txtid.replace("txt", "");
                        var index = getIndex(txtid);
                        hidvalue = hidvalue + txtid.substring(0, index) + ":" + txtid.substring(index + 2) + "" + txtid.substring(index, index + 2) + "," + txtobj[i].value + ";";
                        checkbool = false;
                        txtobj[i].style.color = "#FF0000";
                        lbtid.style.color = "#FF0000";
                    }
                }
            }

        }
    }
    for (var i = 0; i < txtobj1.length; i++) {
        if (txtobj1[i].id.indexOf("drp") > -1)//判断是不是文本框
        {
            var txtid = txtobj1[i].id;
            var lbid = document.getElementById(txtid.replace("drp", "lb") + "t");//下级帐号的设定
            if (lbid != null && lbid.innerText.trim()) {
                if (isNaN(txtobj1[i].value) == true)//判断文本框输入是不是数字
                {
                    alert("輸入的數值不能大於上級");
                    txtobj1[i].style.color = "#FF0000";
                    return false;
                }
                var indexs = lbid.innerText.indexOf(")");
                var lbtvalue = lbid.innerText.substring(indexs + 1);
                if (parseFloat(txtobj1[i].value) < parseFloat(lbtvalue))//判断输入的设定值是不是小于下级用户的设定值
                {
                    txtid = txtid.replace("drp", "");
                    var index = getIndex(txtid);
                    hidvalue = hidvalue + txtid.substring(0, index) + ":" + txtid.substring(index + 2) + "" + txtid.substring(index, index + 2) + "," + txtobj1[i].value + ";";
                    checkbool = false;
                    txtobj1[i].style.color = "#FF0000";
                    // lbid.style.color="#FF0000";
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
        var hidobj = document.getElementById("hidvalue");
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