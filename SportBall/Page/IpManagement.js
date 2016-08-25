var __mLanguage = 'zh-cn';

function funSave(objgrvtxtName, objgrvtxtPassWord, objgrvltxt) {
    var vobjgrvtxtName = document.getElementById(objgrvtxtName);
    var vobjgrvtxtPassWord = document.getElementById(objgrvtxtPassWord);
    var vobjgrvltxt = document.getElementById(objgrvltxt);

    if (vobjgrvtxtName.value == "") {
        alert("请输入用户名！");
        vobjgrvtxtName.focus();
        return false;
    }
    if (vobjgrvtxtPassWord.value == "") {
        alert("请输入密码！");
        vobjgrvtxtPassWord.focus();
        return false;
    }
    if (vobjgrvltxt.value == "") {
        alert("请输入名称！");
        vobjgrvltxt.focus();
        return false;
    }


    return true;
}
//刪除判斷
function funConfirm() {
    return ShowConfirm("A000013");
}
function checkAdd() {
    var txtIP = document.getElementById("ContentPlaceHolder11_txtIP");

    if (txtIP.value.trim() == "") {
        alert("请输入IP地址!!");
        txtIP.select();
        return false;
    }
   
    return true;
}
function clearTxt() {
    var txtName = document.getElementById("ContentPlaceHolder11_txtUser");
    var txtTitle = document.getElementById("ContentPlaceHolder11_txtTitle");
    var textPassWord = document.getElementById("ContentPlaceHolder11_textPassWord");
    txtName.value = "";
    txtTitle.value = "";
    textPassWord.value = "";
    return true
}