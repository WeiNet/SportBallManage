var __mLanguage = 'zh-cn';

function funSave(objgrvtxtName,objgrvtxtName_EN,objgrvltxtName_CN,objgrvltxtName_TW,objgrvltxtName_TH,objgrvltxtNO) {
    var vobjgrvtxtName = document.getElementById(objgrvtxtName);
    var vobjgrvtxtName_EN = document.getElementById(objgrvtxtName_EN);
    var vobjgrvltxtName_CN = document.getElementById(objgrvltxtName_CN);
    var vobjgrvltxtName_TW = document.getElementById(objgrvltxtName_TW);
    var vobjgrvltxtName_TH = document.getElementById(objgrvltxtName_TH);
    var vobjgrvltxtNO = document.getElementById(objgrvltxtNO);
    if (vobjgrvtxtName.value == "") {
        alert("联盟名称不能为空！");
        vobjgrvtxtName.focus();
        return false;
    }
    if (vobjgrvtxtName_EN.value == "") {
        alert("联盟英文不能为空！");
        vobjgrvtxtName_EN.focus();
        return false;
    }
    if (vobjgrvltxtName_CN.value == "") {
        alert("联盟简体中文不能为空！");
        vobjgrvltxtName_CN.focus();
        return false;
    }
    if (vobjgrvltxtName_TW.value == "") {
        alert("联盟繁体中文不能为空！");
        vobjgrvltxtName_TW.focus();
        return false;
    }
    if (vobjgrvltxtName_TH.value == "") {
        alert("联盟泰文不能为空！");
        vobjgrvltxtName_TH.focus();
        return false;
    }
    if (vobjgrvltxtNO.value == "") {
        alert("序号不能为空！");
        vobjgrvltxtNO.focus();
        return false;
    }

    return true;
}
//刪除判斷
function funConfirm() {
    return ShowConfirm("A000013");
}
function checkLM() {
    var txtName = document.getElementById("ContentPlaceHolder11_txtName");
   
     if(txtName.value.trim()=="")
  {
     alert("請輸入聯盟名稱!!");
       txtName.select();
       return false;
      }
   
     var txtNo = document.getElementById("ContentPlaceHolder11_txtNo");
    if (txtNo.value.trim() == "") {
        alert("请输入序号");
        txtNo.select();
        return false;
    }
    return true;
}