var __mLanguage = 'zh-cn';

function funSave(objPlayValue) {
    var vPlayValue = document.getElementById(objPlayValue);
    if (vPlayValue.value == "") {
        alert("基准值不能为空！");
        vPlayValue.focus();
        return false;
    }
    
    return true;
}
//登陸判斷
function funQuery() {

    if (document.getElementById("ContentPlaceHolder11_txtFZBH").value == "") {
        alert("请输入分站编号");
        document.getElementById("ContentPlaceHolder11_txtFZBH").focus();
        return false;
    }
    return true;
}
function funAdd() {

    if (document.getElementById("ContentPlaceHolder11_txtFZBH").value == "") {
        alert("请输入分站编号");
        document.getElementById("ContentPlaceHolder11_txtFZBH").focus();
        return false;
    }
    if (document.getElementById("ContentPlaceHolder11_txt1").value == "") {
        alert("请填写完整信息");
        document.getElementById("ContentPlaceHolder11_txt1").focus();
        return false;
    }
    if (document.getElementById("ContentPlaceHolder11_txt2").value == "") {
        alert("请填写完整信息");
        document.getElementById("ContentPlaceHolder11_txt2").focus();
        return false;
    }
    if (document.getElementById("ContentPlaceHolder11_txt3").value == "") {
        alert("请填写完整信息");
        document.getElementById("ContentPlaceHolder11_txt3").focus();
        return false;
    }
    if (document.getElementById("ContentPlaceHolder11_txt4").value == "") {
        alert("请填写完整信息");
        document.getElementById("ContentPlaceHolder11_txt4").focus();
        return false;
    }
    if (document.getElementById("ContentPlaceHolder11_txt5").value == "") {
        alert("请填写完整信息");
        document.getElementById("ContentPlaceHolder11_txt5").focus();
        return false;
    }
    return true;
}