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
    var txtName = document.getElementById("ContentPlaceHolder11_txtUser");

    if (txtName.value.trim() == "") {
        alert("請輸入账号!!");
        txtName.select();
        return false;
    }
    var txtTitle = document.getElementById("ContentPlaceHolder11_txtTitle");

    if (txtTitle.value.trim() == "") {
        alert("請输入名称!!");
        txtTitle.select();
        return false;
    }
    var textPassWord = document.getElementById("ContentPlaceHolder11_textPassWord");
    if (textPassWord.value.trim() == "") {
        alert("请输入密码");
        textPassWord.select();
        return false;
    }
    var textPassWordRepeat = document.getElementById("ContentPlaceHolder11_textPassWordRepeat");
    if (textPassWordRepeat.value.trim() == "") {
        alert("请再次输入密码");
        textPassWordRepeat.select();
        return false;
    }
    if (textPassWordRepeat.value.trim() != textPassWord.value.trim()) {
        alert("两次输入的密码不一致，请重新输入");
        textPassWordRepeat.select();
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