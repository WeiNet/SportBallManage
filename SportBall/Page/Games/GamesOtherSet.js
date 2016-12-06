﻿function changefenshu(obj) {
    if (obj.value == 0) {
        document.getElementById('drpRFCJPL').style.display = '';
        document.getElementById('drpRFCJPL1').style.display = 'none';
    }
    else {
        document.getElementById('drpRFCJPL1').style.display = '';
        document.getElementById('drpRFCJPL').style.display = 'none';
    }
}
function getTeamList12(obj, flag) {
    $.ajax({
        type: "post",
        dataType: "json",//返回json格式的数据
        url: "GameAjax.aspx",
        cache: false,
        async: true,
        data: {
            lm: obj.value,
            rad: Math.random()
        },
        complete: function () {
            //alert(1);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error!!");
        },
        success: function (retrunJson) {
            var option = "";
            $(retrunJson).each(function () {
                option += "<option value=\"" + this.N_ID + "\">" + this.N_DWMC + "</option>";
            });

            $("#drpVisit").html(option);
            $("#drpHome").html(option);
            $("#drpVisit").val($("#hidVisit").val());
            $("#drpHome").val($("#hidHome").val());
            $("#drpVisit").attr("disabled", flag);
            $("#drpHome").attr("disabled", flag);
        }
    });
}

function getOtherHomeNo(obj)
{   
    onlyInt(obj) ;
    var txtHomeNo = document.getElementById("txtHomeNo");
    txtHomeNo.value = parseInt(obj.value,10)+1;
}
function getOtherVisitNo(obj)
{   
    onlyInt(obj);
    var txtVisitNo = document.getElementById("txtVisitNo");
    txtVisitNo.value = parseInt(obj.value,10)-1;
}