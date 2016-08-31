function CheckNum() {
    var re = /^-?[0-9.]+$/;
    var txtVisit = document.getElementById("txtVisit");
    var txtHome = document.getElementById("txtHome");
    var txtVisit_Up = document.getElementById("txtVisit_Up");
    var txtHome_Up = document.getElementById("txtHome_Up");
    if (txtVisit != null && txtVisit.value.match(re) == null) {
        alert("请输入数字");
        txtVisit.focus();
        return false;
    }
    if (txtHome != null && txtHome.value.match(re) == null) {
        txtHome .focus();
        alert("请输入数字");
        return false;
    }
    if (txtVisit_Up != null && txtVisit_Up.value.match(re) == null) {
        txtVisit_Up.focus();
        alert("请输入数字");
        return false;
    }
    if (txtHome_Up != null && txtHome_Up.value.match(re) == null) {
        txtHome_Up.focus();
        alert("请输入数字");
        return false;
    }
    return true;
}
function refresh(flag) {
    window.opener.$("#btnUpdate").click();
    if (flag) {
        window.close();
    }
    return false;
}