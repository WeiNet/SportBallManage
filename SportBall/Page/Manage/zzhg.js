function Control() {
    document.getElementById("ContentPlaceHolder11_tabAdd").style.display = "";
    document.getElementById("ContentPlaceHolder11_btnAdd").value = "添 加";
    document.getElementById("ContentPlaceHolder11_tabInsert").style.display = "none";
    document.getElementById("ContentPlaceHolder11_txtUser").value = ""
    document.getElementById("ContentPlaceHolder11_txtPass1").value = ""
    document.getElementById("ContentPlaceHolder11_txtPass2").value = ""
    document.getElementById("ContentPlaceHolder11_txtTitle").value = ""
    document.getElementById("ContentPlaceHolder11_drpType").selectedIndex = 0;
}

function submmzzh() {
    var re = /^[1-8]{1}[\w]*$/;
    var UserName = document.getElementById("ContentPlaceHolder11_txtUser");
    if (UserName.value == "") {
        UserName.focus();
        alert("子帳號不能為空");
        return false;
    }
  
    else if (UserName.value.match(re) == null) {
        alert("子帳號第一位必須是1-8之間的數值");
        UserName.focus();
        return false;
    }
    var txtTitle = document.getElementById("ContentPlaceHolder11_txtTitle");
    if (txtTitle.value == "") {
        txtTitle.focus();
        alert("名稱不能為空");
        return false;
    }
    var txtPass1 = document.getElementById("ContentPlaceHolder11_txtPass1");
    if (txtPass1.value == "") {
        txtPass1.focus();
        alert("密碼不能為空");
        return false;
    }
    var txtPass2 = document.getElementById("ContentPlaceHolder11_txtPass2");
    if (txtPass1.value != txtPass2.value) {
        txtPass2.focus();
        alert("密碼填寫不一致");
        return false;
    }
   
}

function deletetishi(obj) {
    var a = document.getElementById(obj);
    a.childNodes[0].attachEvent('onclick', confirms);
}


function confirms() {
    return confirm("確定要刪除嗎？");
}