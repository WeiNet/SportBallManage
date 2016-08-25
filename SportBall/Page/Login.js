var __mLanguage = 'zh-cn';

//登陸判斷
function FnLogin() {
    if (document.getElementById("textUserName").value == "") {
        Show("A00009");
        document.getElementById("textUserName").focus();
        return false;
    }
    else {
        if (document.getElementById("textPassWord").value == "") {
            Show("A000010");
            document.getElementById("textPassWord").focus();
            return false;
        }
        else {
            return true;
        }
    }
}
