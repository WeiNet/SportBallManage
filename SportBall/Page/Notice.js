var __mLanguage = 'zh-cn';

function deletetishi() {

    return confirm("你确定要删除吗？");
}

//Grid全選功能
function SelectAllGrid(objSelectAll, objGrid, objIndexCell) {
    var objGrid = document.getElementById(objGrid)
    for (var i = 1; i < objGrid.rows.length; i++) {
        if (objGrid.rows[i].cells[objIndexCell] != null) {
            if (objGrid.rows[i].cells[objIndexCell].childNodes[0] != null) {
                objGrid.rows[i].cells[objIndexCell].childNodes[0].checked = objSelectAll.checked
            }
        }
    }
}
function checkText() {

    if (document.getElementById("ContentPlaceHolder11_txtXXNR_CN").value == "") {
        alert("请输入信息内容！");
        document.getElementById("ContentPlaceHolder11_txtXXNR_CN").focus();
            return false;
        }
    return true;
 
}



//日曆控件
$(function () {

    $("#ContentPlaceHolder11_txtYXSJ,#ContentPlaceHolder11_txtkssj,#ContentPlaceHolder11_txtjssj").datepicker({
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

function fn_CheckDate(obj) {
    var pat_hd = /^20\d{2}-((0[1-9]{1})|(1[0-2]{1}))-((0[1-9]{1})|([1-2]{1}[0-9]{1})|(3[0-1]{1}))$/;

    if (obj.value != "") {
        if (!pat_hd.test(obj.value)) {
            alert("日期格式不正确");
            obj.focus();
            return false;
        }
    }
    //else {
    //    alert("请输入日期");
    //    obj.focus();
    //    return false;
    //}
    return true;
}
/*****************************************************
* 函數名稱: fnSelectAll()
* 目    的: 全選
* 參數說明: gridID:Grid之ID; chListID:CheckBox之ID; boolValue 全選欄位勾選狀態，選中為true，未選為false
*****************************************************/
function fnSelectAll(gridID, chListID, boolValue) {
    try {
        var ObjTable = document.getElementById(gridID);
        for (i = 0; i < ObjTable.rows.length; i++) {
            var objCheckBox = document.getElementById(gridID + "_" + chListID + "_" + i);
            objCheckBox.checked = boolValue;
        }
    } catch (e) {
    }
}