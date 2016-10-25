
var xmlHttp = getXmlHttpRequest();
var highlightcolor = '#eafcd5';
//此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
var clickcolor = '#51b2f6';
//取得當前瀏覽器支持的XMLHTTP對象   
function getXmlHttpRequest() 
{  
    var request=null;   
    if(window.XMLHttpRequest)
    {
        request = new XMLHttpRequest();
    } 
    else if (window.ActiveXObject)
    {
        request=new ActiveXObject("Msxml2.XMLHTTP");
        if (! request)
        {
            request=new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
    return request;
}

//目的：提供開啟視窗的畫面
//參數：strUrl-->欲開啟畫面的網址，width-->畫面的寬度，height-->畫面的高度
//      WinName-->開啟的視窗名稱
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2006/05/18   1.00    Abel       Create
function OpenWin(strUrl,width,height,WinName)
{
   var top=0;
   var left=0;
   if (height =='' && width==''){
        width=screen.availWidth; 
        height=screen.availHeight;
    }else if (height >screen.availHeight && width>screen.availWidth){
        width=screen.availWidth; 
        height=screen.availHeight;
    }else{
        top=(screen.availHeight-height)/2;
        left=(screen.availWidth-width)/2;
    }
   
    window.open(strUrl,WinName,'width='+width+'px,height='+height+'px,dependent,left='+left+',top='+top+',status=no,toolbar=false,menubar=no,scrollbars=yes,resizable=yes',true);
}  

//目的：提供開啟showModalDialog的畫面
//參數：strUrl-->欲開啟畫面的網址，width-->畫面的寬度，height-->畫面的高度
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2006/05/18   1.00    Abel       Create
function OpenDialog(strUrl,width,height) {
    var Sys = new Object();
    var ua = navigator.userAgent.toLowerCase();
    var s;
    (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
    (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
    (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
    (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
    (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;
    
    var top=0;
    var left = 0;
    var strDiaUrl = "";
    if (height =='' && width==''){
        width=screen.availWidth; 
        height=screen.availHeight;
    }else if (height >screen.availHeight && width>screen.availWidth){
        width=screen.availWidth; 
        height=screen.availHeight;
    }else{
        top=(screen.availHeight-height)/2;
        left=(screen.availWidth-width)/2;
    }
    var returnValue=false;
    var dlgwin=null;
    try {
        if (strUrl.indexOf("?") >= 0)
            strUrl += "&";
        else
            strUrl += "?";       
        strDiaUrl = strUrl + "showModalDialog=showModalDialog";
        if (Sys.ie) {
            returnValue = window.showModalDialog(strDiaUrl, window, 'dialogLeft:' + left + ';dialogTop:' + top + ';dialogHeight:' + height + 'px;dialogWidth:' + width + 'px;status:no;help:no');
        } else {
            OpenWin(strUrl, width, height, '', 'no'); //不可以縮小和放大窗體
        }
    }catch(e){returnValue=false;}
    if (returnValue==null && returnValue==undefined){ 
        returnValue=false;
    }
    dlgwin=null;
   	return returnValue;
} 


//*******************************************
//目的：透過XMLDOM去取得另一個Page的資料，傳回取回的Data
//參數：
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2006/03/27   1.00    Abel       Create
function __ATLoadXml(vstrReq){
	var root, source;		
	var sT;
	
	status = 'searching, please wait....';
	source = new ActiveXObject('Microsoft.XMLDOM');
	source.async = false;
	source.load(vstrReq);
	//Check to see if there was an error parsing the response from the server
	if (source.parseError != 0){
		sT = 'XML Error...<br>reason:' + source.parseError.reason + '<br>';
		sT += 'errorCode:' + source.parseError.errorCode + '<br>';
		sT += 'filepos:' + source.parseError.filepos + '<br>';
		sT += 'line:' + source.parseError.line + '<br>';
		sT += 'linepos:' + source.parseError.linepos + '<br>';
		sT += 'reason:' + source.parseError.reason + '<br>';
		sT += 'srcText:' + source.parseError.srcText + '<br>';
		sT += '<pre>' + source.xml + '</pre><br>';
		alert(sT);
		status = 'XML Error!';}
	else {
		root = source.documentElement;		//Get a reference to root XML object
		status = 'Done';
		return root;}
}


//功能：設定二個控制項的絕對位置
//參數：obj1－傳入第一個控制項物件,objDiv--傳入對應位置的控制項
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2006/08/07   1.00    Abel        New Create
function SetDynamicPosition(obj1,objDiv){     
    var oBndRct =obj1.getBoundingClientRect();
    var xel, yel;
	xel = oBndRct.left;
	yel = oBndRct.bottom;
    objDiv.style.left=xel;
    objDiv.style.top=yel+document.body.scrollTop;
    objDiv.style.display="";
}

//功能：閱覽條件設定資訊
//參數：obj1－傳入欲顯示條件的控制項物件
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2006/08/07   1.00    Abel        New Create
function ShowQueryString(obj1,objQryStr){  
    var oBndRct =obj1.getBoundingClientRect();
    var xel, yel;
	   xel = oBndRct.left;
	   yel = oBndRct.bottom;
	   if (document.all(objQryStr)!=null){
	    var objDiv=document.all(objQryStr);
        objDiv.style.left=xel;
        objDiv.style.top=yel;
        objDiv.style.display="";
    }
}

//功能：關閉條件設定資訊
//參數：
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2006/08/07   1.00    Abel        New Create
function HideQueryString(objQryStr){  
	if (document.all(objQryStr)!=null){
        var objDiv=document.all(objQryStr);
        objDiv.style.display="none";
     }   
}



//功能：設定選取功能的按鈕
//參數：
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2006/05/25   1.00    Abel        New Create
function SetSelGrid(objChecked,obj1,obj2){   
     document.all(objChecked).checked=true;
     document.all(obj1).checked=false;
     document.all(obj2).checked=false;  
}


function __ATGetParentElementByTagName(vobj,vstrTagName) {
	while (vobj.tagName!=vstrTagName.toUpperCase()) {
		vobj=vobj.parentElement;
		if(vobj==null) return;
	}		
	return vobj
}

//功能：驗証Email的格式
//參數：field-->欲驗証的欄位 
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2007/04/11   1.00    Abel     New Create   
function validate_email(objField)
{
    with (objField)
    {
        
        apos=value.indexOf("@");
        dotpos=value.lastIndexOf(".");
        if(value==""){
            return true;
        }
        
        re = /^[^\s]+@[^\s]+\.[^\s]{2,3}$/;
        if(re.test(value)==true)
        {
            return true;
        }
        else //if (apos<1||dotpos-apos<2)
        {
            alert("Email error");
            objField.focus();
            return false;
        }
      
    }
}


/*
'''</summary>
'''提供Clinet呼叫Waiting畫面的Event，避免Client到按鈕
''' <remarks></remarks>
''' <history>
'''     1. 2007/04/19   1.00    [Abel]     Create
''' </history>
*/
function OnClientPageBlock(vblnDisplay) {
    try {
        var objDiv = document.getElementById("divFrmLoad");
        var objTable = document.getElementById("tdFrmLoad");
        if (vblnDisplay == false) {
            document.body.style.cursor = '';
            objDiv.style.display = "none";
            return true;
        }
        CreateProcessBar(objDiv, objTable, "");
    } catch (e) { ; }
    return true;
}
function OnFMainClientPageBlock(vblnDisplay) {
    try {
        var objDiv = window.FMain.document.getElementById("divFrmLoad");
        var objTable = window.FMain.document.getElementById("tdFrmLoad");
        if (vblnDisplay == false) {
            document.body.style.cursor = '';
            objDiv.style.display = "none";
            return true;
        }
        CreateProcessBar(objDiv, objTable, "FMain");
    } catch (e) { ; }
    return true;
}
function CreateProcessBar(objDiv, objTable, flg) {
    if (objTable == null || objDiv == null)
        return;
    document.body.style.cursor = 'wait';
    var strHtml = "<table id='tbBar' border='1' cellpadding='0' cellspacing='0' width='500px' rules='none' bordercolor='#COCOCO'>";
    strHtml += "<tr height='20px' bgcolor='#FAFFF0'>";
    for (var i = 0; i < 50; i++) {
        strHtml += "<td width='10px'>&nbsp;</td>";
    }
    strHtml += "</tr><tr><td style='background-color: #FAFFF0;font-family:Arial,sans-serif;' colspan='50' height='30px' align='center'>";
    strHtml += "Data Processing,  Please Wait....";
    strHtml += "</td></tr></table>";
    objTable.innerHTML = strHtml;
    var intWidth = document.body.clientWidth;
    var intLeft = (intWidth - 500) / 2;
    if (intLeft < 0) intLeft = 0;
    objDiv.style.left = intLeft;
    objDiv.style.top = 15;
    objDiv.style.display = "";
    setTimeout("showProcessBar('" + flg + "')", 100);
}
var indexBar = 0;
function showProcessBar(flg) {
    var objTbBar = document.getElementById("tbBar");
    if (flg == "FMain")
        objTbBar = window.FMain.document.getElementById("tbBar");
    if (objTbBar == null)
        return;
    var col = objTbBar.rows[0].cells;
    col(indexBar).bgColor = "navy";
    indexBar++;
    if (indexBar == 50) {
        indexBar = 0;
        for (var i = 0; i < col.length; i++) {
            col(i).bgColor = "#FOFFFF";
        }
    }
    setTimeout("showProcessBar('" + flg + "')", 100);
}

 /*
'''</summary>
'''提供Clinet偵測到有捲軸就切換視窗大小
''' <remarks></remarks>
''' <history>
'''     1. 2007/04/19   1.00    [Abel]     Create
''' </history>
*/
function fnSetWidowSize(){
    if (window.dialogHeight<parseInt(document.body.scrollHeight+50)){
        window.dialogHeight = document.body.scrollHeight+50+"px";
    }
}   


function getTop(e){
	var offset=e.offsetTop;
	if(e.offsetParent!=null) offset+=getTop(e.offsetParent);
	return offset;
}
function getLeft(e){
	var offset=e.offsetLeft;
	if(e.offsetParent!=null) offset+=getLeft(e.offsetParent);
	return offset;
}

function getDialogHeight(e){
	var offset=e.offsetHeight;
	if(e.offsetParent!=null) offset=getDialogHeight(e.offsetParent);
	return offset;
}

// 列印
//在列印的報表畫面加入：
//<OBJECT  id="WebBrowser"  classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"  height="0"  width="0" ></OBJECT>
function fnPrint() {
    try    {
        // 儲存原本頁首頁尾的設定，然後設定空白
        var ret = saveAndClearSetting();
        // 列印
        try{
            document.all.WebBrowser.ExecWB(6,1);
            return true;
        }catch(e)
        {
            window.print();
        }
        // 回存原本頁首頁尾的設定
        if ( ret ) restoreSetting();
    } catch (e) { alert("err="+e.description); }
    return false;
}
var hkey_path = "HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
var hkey_key_header = hkey_path+"header"; // 頁首
var hkey_key_footer = hkey_path+"footer"; // 頁尾
var hkey_key_margin_bottom = hkey_path+"margin_bottom"; // 邊界（下）
var hkey_key_margin_left = hkey_path+"margin_left"; // 邊界（左）
var hkey_key_margin_right = hkey_path+"margin_right"; // 邊界（右）
var hkey_key_margin_top = hkey_path+"margin_top"; // 邊界（上）
var old_header = "&w&b第 &p 頁，共 &P 頁";
var old_footer = "&u&b&d";
var old_left = "";
var old_right = "";
var old_bottom = "";
var old_top = "";
// 儲存原本頁首頁尾的設定，然後設定空白
function saveAndClearSetting() {
  try {
    var RegWsh = new ActiveXObject("WScript.Shell");
    old_header = RegWsh.RegRead(hkey_key_header);
    old_footer = RegWsh.RegRead(hkey_key_footer);
    old_left = RegWsh.RegRead(hkey_key_margin_left);
    old_right = RegWsh.RegRead(hkey_key_margin_right);
    old_bottom = RegWsh.RegRead(hkey_key_margin_bottom);
    old_top = RegWsh.RegRead(hkey_key_margin_top);
    RegWsh.RegWrite(hkey_key_header,"");
    RegWsh.RegWrite(hkey_key_footer,"");
//    RegWsh.RegWrite(hkey_key_margin_left,"0.05");
//    RegWsh.RegWrite(hkey_key_margin_right,"0.05");
//    RegWsh.RegWrite(hkey_key_margin_bottom,"0.2");
//    RegWsh.RegWrite(hkey_key_margin_top,"0.2");
    return true;
  } catch (e) { 
    if ( e.description.indexOf("伺服程式無法產生物件") != -1 ) {//alert("ERR="+e.description);
        ;//alert("請調整IE瀏覽器的安全性\n網際網路選項＼安全性＼自訂層級\n「起始不標示為安全的ActiveX控制項」設定為啟用或提示。"); 
    } // if
    else {
        alert("ERR="+e.description); 
    } // else
  } // catch
    return false;
}
// 回存原本頁首頁尾的設定
function restoreSetting() {
  try {
    var RegWsh = new ActiveXObject("WScript.Shell");
    RegWsh.RegWrite(hkey_key_header,old_header);
    RegWsh.RegWrite(hkey_key_footer,old_footer);
    RegWsh.RegWrite(hkey_key_margin_left,old_left);
    RegWsh.RegWrite(hkey_key_margin_right,old_right);
    RegWsh.RegWrite(hkey_key_margin_bottom,old_bottom);
    RegWsh.RegWrite(hkey_key_margin_top,old_top);
  } catch (e) {
    if ( e.description.indexOf("伺服程式無法產生物件") != -1 ) {
        ;//alert("請調整IE瀏覽器的安全性\n網際網路選項＼安全性＼自訂層級\n「起始不標示為安全的ActiveX控制項」設定為啟用或提示。"); 
    } // if
    else {
        ;//alert("ERR="+e.description); 
    } // else
  } // catch
}

//獲得文件大小    
function getFileSize (fileName)
{   
    if(document.all)   
    {   
        window.oldOnError = window.onerror;           
        window.onerror = function (err) {   
            if(err.indexOf('utomation') != -1)   
            {   
                alert('The command has been forbidden!');                   
                return   true;               
            }             
            else     
                return   false;           
        };   
        var fso = new ActiveXObject('Scripting.FileSystemObject');   
        var file = fso.GetFile(fileName);           
        window.onerror = window.oldOnError;   
        return file.Size; 
   }
}

//獲得文件類型
function getFileType(files)
{
	var ary=files.value.split(".");
	return ary[ary.length-1];
}   

//限制上傳文件的大小
function ShowSize(files,i_byte)       
{       
  try{
      var fso,f,s;    
      fso=new ActiveXObject("Scripting.FileSystemObject");       
      f=fso.GetFile(files.value);       
      if((f.size/(1024*1024))>i_byte*1){   
      //alert("Sorry,the file size should not exceed "+ i_byte +"M");   
      files.value="";
      return false;   
      }   
      else   
      { OnClientPageBlock(true);
        return true;   
      }
  }  
  catch(e)
  {
    OnClientPageBlock(true);
    return true;
  }
  
}

//功能: 當按Enter時就移到下一個欄位
//參數：
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2008/12/09   1.00    Abel     New Create
function EnterKey()
{		
    try{
 
    if (window.event.keyCode==13)
    {			
        var type=document.activeElement.type;       
        if (!(type=="button" || type=="submit" || type=="textarea"))
        {						
			        var SName=document.activeElement.name;		
			        var Idx=ElementIdx(SName);					
			        if (Idx==-1)
			        {
				        window.event.returnValue=false;
			        }
			        else
			        {						
				        //注意:連結按鈕不能算				
				        var maxItem=document.forms[0].length;
				        while  (Idx<=maxItem-2)
				        {							
                var typeNext=document.forms[0].elements[Idx+1].type;																						
                    if (!(typeNext=="button" || typeNext=="submit" || typeNext=="hidden" || typeNext=="option" || typeNext=="select-one" || typeNext=="checkbox" || typeNext=="radio" || document.forms[0].elements[Idx+1].style.display=="none" ))
                    {								
                    if(document.forms[0].elements[Idx+1].readOnly==true || document.forms[0].elements[Idx+1].disabled==true || document.forms[0].elements[Idx+1].parentNode.style.display=="none" )
                    {
                        Idx++;
                        continue;
                    }
                    else
                    {										
                        document.forms[0].elements[Idx+1].focus();		
                        window.event.returnValue=false;	//由上一行替代Focus動作								
                        break;										
                    }
                }
					        else
					        {
						        if(Idx==maxItem-1)
						        {
							        document.forms[0].elements[Idx].focus();	
							        window.event.returnValue=false;
							        break;
						        }else{
						        Idx++;					
						        continue;	}					
					        }
				        }
				        window.event.returnValue=false;	//由上一行替代Focus動作	
			        }
        }
    }
    }catch(e){}
}

//功能: 回傳 Control 索引值 in <Form> tag
//參數：sSName傳入要Focus的欄位名稱
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2008/12/09   1.00    Abel        New Create
function ElementIdx(SName){
	var IsFound=false;		
	if (SName!=""){					
		for (var i=0;i<=document.forms[0].length-1;i++){
			var Name=document.forms[0].elements[i].name;					
			if (SName==Name){
				IsFound=true;
				break;
			}
		}
	}			
	if (IsFound) return i;  else  return -1;		
}

//數字轉中文
function funIntToWordNo(strNum)
{
	var strNo="";
	var strFrom=strNum+"";
	for(i=0;i<strFrom.length; i++)
	{
		switch (strFrom.substring(i,i+1))
		{
			case "0": strNo+="&#12295;";
				break;			
			case "1": strNo+="一";
				break;			
			case "2": strNo+="二";
				break;			
			case "3": strNo+="三";
				break;			
			case "4": strNo+="四";
				break;			
			case "5": strNo+="五";
				break;			
			case "6": strNo+="六";
				break;			
			case "7": strNo+="七";
				break;			
			case "8": strNo+="八";
				break;			
			case "9": strNo+="九";
				break;
		}		
	}
	return strNo;
}	



//向按鈕添加鼠標事件（onmouseover,onmouseout）
function SetButtonAddStyle() {
    var j = 0;
    for (var i = 0; i <= document.forms[j].length - 1; i++) {
        try {
            var objId = document.forms[j].elements[i].id;
            var obj = document.getElementById(objId);
            var objType = obj.type;
            if (objType == "button" || objType == "submit") {
                //obj.attachEvent('onmouseover', "this.className='buttonHover';"); //在原先事件上添加 
                //obj.setAttribute('onfocus',add); //会替代原有事件方法
                //obj.onfocus=add; //等效obj.setAttribute('onfocus',add)
                obj.onmouseover = function () { this.className = "buttonHover"; this.style.cursor = "hand"; }
                obj.onmouseout = function () { this.className = "button"; this.style.cursor = ""; }
            }
            if (objType == "text" || objType == "password") {
                obj.onfocus = function () { this.select(); }
            }
        } catch (e) { ; }
    }
}

/*------------------------鼠標拖動效果---------------------*/
function funDivDrag(gObjDiv) {
    return; //Abel 暫停拖動功能
    if (gObjDiv == null) return;
    var dx, dy, mx, my, mouseD;
    var odrag;
    var isIE = document.all ? true : false;
    document.onmousedown = function (e) {
        var e = e ? e : event;
        if (e.button == (document.all ? 1 : 0)) {
            mouseD = true;
        }
    }
    document.onmouseup = function () {
        mouseD = false;
        odrag = "";
        if (isIE) {
            gObjDiv.releaseCapture();
            //gObjDiv.filters.alpha.opacity = 100;
        }
        else {
            window.releaseEvents(gObjDiv.MOUSEMOVE);
            gObjDiv.style.opacity = 1;
        }
        gObjDiv.style.cursor = "auto";
    }

    gObjDiv.onmousedown = function (e) {
        odrag = this;
        var e = e ? e : event;
        if (e.button == (document.all ? 1 : 0)) {
            mx = e.clientX;
            my = e.clientY;
            gObjDiv.style.left = gObjDiv.offsetLeft + "px";
            gObjDiv.style.top = gObjDiv.offsetTop + "px";
            if (isIE) {
                gObjDiv.setCapture();
                //gObjDiv.filters.alpha.opacity = 50;
            }
            else {
                window.captureEvents(Event.MOUSEMOVE);
                gObjDiv.style.opacity = 0.5;
            }
        }
        gObjDiv.style.cursor = "move";
    }
    document.onmousemove = function (e) {
        var e = e ? e : event;
        if (mouseD == true && odrag) {
            var mrX = e.clientX - mx;
            var mrY = e.clientY - my;
            gObjDiv.style.left = parseInt(gObjDiv.style.left) + mrX + "px";
            gObjDiv.style.top = parseInt(gObjDiv.style.top) + mrY + "px";
            mx = e.clientX;
            my = e.clientY;

        }
    }
}


//格式化病歷號ex:輸入5-->0000000005 Add by Nina 20120927
function SuppZero(objMrNo)
{ 
 var strMrNo = objMrNo.value.trim();
    if (strMrNo == "") return;
    strMrNo = "000000000" + strMrNo;
    strMrNo = strMrNo.substring(strMrNo.length - 10, strMrNo.length);
    objMrNo.value = strMrNo;
}

//提示是否删除，Add By Dath
function fun_ibtnDel() {
    return ShowConfirm("A00021"); //確認刪除嗎？
}

//關閉 Add by Dath 20121003，普通關閉按鈕使用，無後續動作
function fnClosed(strReturnValue) {
    window.opener = null;
    window.returnValue = strReturnValue;
    window.close();
}

function inputNubmer() {

    var key = window.event.keyCode;
    if (key >= 48 && key <= 57) {
        return true;
    }
    else {
        window.event.keyCode = 0;
        return true;
    }
}
function _onlyNum(obj) {
    obj.value = obj.value.trim().replace(/[^0-9.-]/g, '');
    if (obj.value == "") {
        obj.value = "0";
    }
    else if (isNaN(obj.value.trim())) {
        alert("请输入数字");
        obj.value = "0";
        obj.select();
    }
}
//限制只能輸入數字
function onlyInt(obj) {
    obj.value = obj.value.replace(/[^0-9]/g, '');
    if (obj.value.trim() == "") {
        obj.value = "0";
    }
    else if (isNaN(obj.value.trim())) {
        alert("请输入数字");
        obj.value = "0";
        obj.select();
    }
}

//限制只能輸入數字和小數點
function _onlyNum4(obj) {
    obj.value = obj.value.trim().replace(/[^0-9.-]/g, '');
    if (obj.value == "") {
        obj.value = "0";
    }
    else if (isNaN(obj.value.trim())) {
        alert("请输入数字");
        obj.value = "0";
        obj.select();
    }
}
function inputNubmerFloat() {
    var key = window.event.keyCode;
    if ((key >= 48 && key <= 57) || key == 46) {
        return true;
    }
    else {
        window.event.keyCode = 0;
        return true;
    }
}
function changeback() {
    if (event.fromElement.contains(event.toElement) || source.contains(event.toElement) || source.id == "nc")
        return
    if (event.toElement != source && cs[1].style.backgroundColor != clickcolor)
        //source.style.backgroundColor=originalcolor
        for (i = 0; i < cs.length; i++) {
            cs[i].style.backgroundColor = "";
        }
}

function changeto() {
    source = event.srcElement;
    if (source.tagName == "TR" || source.tagName == "TABLE")
        return;
    while (source.tagName != "TD")
        source = source.parentElement;
    source = source.parentElement;
    cs = source.children;
    //alert(cs.length);
    if (cs[1].style.backgroundColor != highlightcolor && source.id != "nc" && cs[1].style.backgroundColor != clickcolor)
        for (i = 0; i < cs.length; i++) {
            cs[i].style.backgroundColor = highlightcolor;
        }
}