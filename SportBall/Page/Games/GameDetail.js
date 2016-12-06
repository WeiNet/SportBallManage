function deletetishireason(obj) {
    var a = document.getElementById(obj);
    if (a != null)
        a.childNodes[0].attachEvent('onclick', confirmsreason);

}

function confirmsreason() {
    if (confirm("確定要刪除嗎？") == true) {
        var delreason = window.prompt(alert("請輸入刪除原因"), '');
        if (delreason == null) delreason = "";
        document.getElementById("delyy").value = delreason;
        return true;
    }
    return false;
}


function huifutishi(obj) {
    var a = document.getElementById(obj);
    if (a != null)
        a.childNodes[0].attachEvent('onclick', huifuconfirms);
}

function huifuconfirms() {
    return confirm("確定要恢復嗎");
}