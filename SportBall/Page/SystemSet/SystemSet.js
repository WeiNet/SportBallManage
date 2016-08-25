var __mLanguage = 'zh-cn';

//日曆控件
$(function () {
   
    $("#ContentPlaceHolder11_textDate,#ContentPlaceHolder11_textFinishDate").datepicker({
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


 
