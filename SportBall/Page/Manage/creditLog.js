var __mLanguage = 'zh-cn';

//日曆控件
$(function () {

    $("#ContentPlaceHolder11_txtkjsj,#ContentPlaceHolder11_txtjssj").datepicker({
        changeMonth: true,
        changeYear: true,
        showOn: 'both',
        firstDay: 7,
        changeFirstDay: false,
        showOtherMonths: true,
        selectOtherMonths: true,
        speed: 'immediate',
        buttonImage: '/Images/calendar_bd.gif',
        buttonText: '選擇日期',
        buttonImageOnly: true,
        dateFormat: 'yy-mm-dd',
        autoSize: true
    });
});


function Check() {
    //    var mode= document.getElementById("hidMode");
    //    if(mode!=null&&mode.value=="Add") return false;
    var UserName = document.getElementById("ContentPlaceHolder11_txtUserId");
    if (UserName.value == "") {
        alert("请输入会员帐号");
        UserName.select();
        return false;
    } 
    return true;
}