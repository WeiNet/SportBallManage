//目的：判斷欄位一定要輸入英文或數字
//參數：objFld--傳入欄位ID
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2005/04/22   1.00    Abel        New Create
function chkEAN(objFld)
{
    if(window.event.keyCode==37 || window.event.keyCode==38 || window.event.keyCode==39 || window.event.keyCode==40)
    {return;}
	var temp =objFld.value;		
	if (objFld.value!="")
	{			
		if (!((window.event.keyCode>=48 && window.event.keyCode<=57) || (window.event.keyCode>=65 && window.event.keyCode<=90) || window.event.keyCode==13 || window.event.keyCode==8 || window.event.keyCode==46 || window.event.keyCode==9))
		{
			//alert("A~Z,a~z or 0~9 only ");
			objFld.focus();
			window.event.returnValue=false;					
		}	
	}		
}

function KeyCodeOnlyChar()
{
    if(window.event.keyCode==37 || window.event.keyCode==38 || window.event.keyCode==39 || window.event.keyCode==40)
    {return;}
    if (!((window.event.keyCode>=65 && window.event.keyCode<=90) || window.event.keyCode==13 || window.event.keyCode==8 || window.event.keyCode==46 || window.event.keyCode==9))
	{
		window.event.returnValue=false;					
	}	
}

//只能輸入字母和數字
function KeyCodeOnlyCharNum()
{
    if(window.event.keyCode==37 || window.event.keyCode==38 || window.event.keyCode==39 || window.event.keyCode==40)
    {return;}
    if (!((window.event.keyCode>=65 && window.event.keyCode<=90) || (window.event.keyCode>=48 && window.event.keyCode<=57)|| (window.event.keyCode>=96 && window.event.keyCode<=105) || window.event.keyCode==13 || window.event.keyCode==8 || window.event.keyCode==46 || window.event.keyCode==9))
	{
		window.event.returnValue=false;					
	}	
}

function KeyCodeOnlyNumber()
{
    if(window.event.keyCode==37 || window.event.keyCode==38 || window.event.keyCode==39 || window.event.keyCode==40)
    {return;}
    if (!((window.event.keyCode>=48 && window.event.keyCode<=57)|| (window.event.keyCode>=96 && window.event.keyCode<=105) || window.event.keyCode==13 || window.event.keyCode==8 || window.event.keyCode==46 || window.event.keyCode==9))
	{
		window.event.returnValue=false;					
	}	
}
//可以輸入數字和.
//add by saga
function KeyCodeOnlyNumberAndDot()
{
    if(window.event.keyCode==37 || window.event.keyCode==38 || window.event.keyCode==39 || window.event.keyCode==40)
    {return;}
    if (!((window.event.keyCode>=48 && window.event.keyCode<=57)|| (window.event.keyCode>=96 && window.event.keyCode<=105) || window.event.keyCode==13 || window.event.keyCode==8 || window.event.keyCode==46 || window.event.keyCode==9 || window.event.keyCode==190 || window.event.keyCode==110))
	{
		window.event.returnValue=false;					
	}	
}
//用於onBlur:輸入數字的位數LenTh，小數的位數DotLen,欄位obj
//整數位數超過則清空，小數部分超過則截取
//若欄位為空，則預設0.00
//add by saga
function funChkNum(obj,LenTh,DotLen)
{ 
    var ZLen = LenTh*1-DotLen*1;
    var DLen = DotLen*1;
    if (obj.value != "" && !isNaN(obj.value))
    {
        var arryValue = obj.value.split(".");
        if (arryValue.length == 1)//無小數點
        { 
            if (arryValue[0].length > ZLen)
            {
                obj.value = "0.00";
                obj.focus();  
                obj.select();
            }
            else
            {
                obj.value = obj.value * 1 + ".00";
            }
        }
        else if (arryValue.length == 2)//一個小數點
        {
            var leftNo;//小數點左邊數字
            var rightNo;//小數點右邊數字
            leftNo = arryValue[0];
            rightNo = arryValue[1];
            if(leftNo.length > ZLen)
            {
                obj.value = "0.00";
                obj.focus();  
                obj.select();
            }
            obj.value = leftNo * 1 + ".";
            if (rightNo.length > DLen)
            {
                rightNo = rightNo.substring(0,DLen);
            }
            else
            {
                var i_ZeroNum = DLen-rightNo.length
                for(var i=0;i<i_ZeroNum;i++)
                {
                    rightNo += "0";
                }
            }
            obj.value = obj.value + rightNo;
        }
    }
    else
    {
          obj.value = "0.00";
          obj.focus();  
          obj.select();
          return false;
    }
}

//用於onBlur:輸入數字的位數LenTh，小數的位數DotLen,欄位obj
//整數位數超過則清空，小數部分超過則截取
//若欄位為空，則預設空
//add by saga
function funChkNumNull(obj,LenTh,DotLen)
{ 
    var ZLen = LenTh*1-DotLen*1;
    var DLen = DotLen*1;
    if (obj.value != "" && !isNaN(obj.value))
    {
        var arryValue = obj.value.split(".");
        if (arryValue.length == 1)//無小數點
        { 
            if (arryValue[0].length > ZLen)
            {
                obj.value = arryValue[0].substring(0,ZLen);
                obj.focus();  
                obj.select();
            }
            else
            {
                obj.value = obj.value * 1;// + ".00";
            }
        }
        else if (arryValue.length == 2)//一個小數點
        {
            var leftNo;//小數點左邊數字
            var rightNo;//小數點右邊數字
            leftNo = arryValue[0];
            rightNo = arryValue[1];
            if(leftNo.length > ZLen)
            {
                obj.value = arryValue[0].substring(0, ZLen);
                obj.focus();
                obj.select();
                return;
            }
            obj.value = leftNo * 1 + ".";
            if (rightNo.length > DLen)
            {
                rightNo = rightNo.substring(0,DLen);
            }
            else
            {
                var i_ZeroNum = DLen-rightNo.length
                for(var i=0;i<i_ZeroNum;i++)
                {
                    rightNo += "0";
                }
            }
            obj.value = obj.value + rightNo;
        }
    }
    else
    {
          obj.value = "";
          return false;
    }
}

//用於onBlur:判斷百分比合法性,obj為欄位
//若欄位為空，則預設為0.00
//add by saga
function funChkPer(obj)
{ 
    if (obj.value != "" && !isNaN(obj.value))
    {
        var arryValue = obj.value.split(".");
        if (arryValue.length == 1)//無小數點
        { 
            if (arryValue[0].length > 3)
            {
                obj.value = "0.00";
            }
            else if(arryValue[0].length == 3)
            {
                if(arryValue[0] == "100")
                {
                    obj.value = "100.00";
                }
                else
                {
                    obj.value = "0.00";
                }
            }
            else
            {
                obj.value = obj.value * 1 + ".00";
            }
        }
        else if (arryValue.length == 2)//一個小數點
        {
            var leftNo;//小數點左邊數字
            var rightNo;//小數點右邊數字
            leftNo = arryValue[0];
            rightNo = arryValue[1];
            if(leftNo.length > 3)
            {
                obj.value = "0.00";
            }
            else if(leftNo.length == 3)
            {
                if(leftNo == "100")
                {
                    obj.value = "100.00";
                }
                else
                {
                    obj.value = "0.00";
                }
            }
            else
            {
                obj.value = leftNo * 1 + ".";
                if (rightNo.length > 2)
                {
                    rightNo = rightNo.substring(0,2);
                }
                else
                {
                    var i_ZeroNum = 2-rightNo.length
                    for(var i=0;i<i_ZeroNum;i++)
                    {
                        rightNo += "0";
                    }
                }
                obj.value = obj.value + rightNo;
            }
        }
    }
    else
    {
          obj.value = "0.00";
          obj.focus();  
          obj.select();
          return false;
    }
}

//用於onBlur:判斷百分比合法性,obj為欄位
//若欄位為空，則預設為0.00
//add by saga
function funChkPerNoDot(obj)
{ 
    if (obj.value != "" && !isNaN(obj.value))
    {
        var arryValue = obj.value.split(".");
        if (arryValue.length == 1)//無小數點
        { 
            if (arryValue[0].length > 3)
            {
                obj.value = "0";
            }
            else if(arryValue[0].length == 3)
            {
                if(arryValue[0] == "100")
                {
                    obj.value = "100";
                }
                else
                {
                    obj.value = "0";
                }
            }
            else
            {
                obj.value = obj.value * 1;
            }
        }
    }
    else
    {
          obj.value = "0";
          obj.focus();  
          obj.select();
          return false;
    }
}

//用於onBlur:判斷百分比合法性,obj為欄位
//若欄位為空，則預設為空
function funChkPerNull(obj)
{ 
    if (obj.value != "" && !isNaN(obj.value))
    {
        var arryValue = obj.value.split(".");
        if (arryValue.length == 1)//無小數點
        { 
            if (arryValue[0].length > 3)
            {
                obj.value = "0.00";
            }
            else if(arryValue[0].length == 3)
            {
                if(arryValue[0] == "100")
                {
                    obj.value = "100.00";
                }
                else
                {
                    obj.value = "0.00";
                }
            }
            else
            {
                obj.value = obj.value * 1 + ".00";
            }
        }
        else if (arryValue.length == 2)//一個小數點
        {
            var leftNo;//小數點左邊數字
            var rightNo;//小數點右邊數字
            leftNo = arryValue[0];
            rightNo = arryValue[1];
            if(leftNo.length > 3)
            {
                obj.value = "0.00";
            }
            else if(leftNo.length == 3)
            {
                if(leftNo == "100")
                {
                    obj.value = "100.00";
                }
                else
                {
                    obj.value = "0.00";
                }
            }
            else
            {
                obj.value = leftNo * 1 + ".";
                if (rightNo.length > 2)
                {
                    rightNo = rightNo.substring(0,2);
                }
                else
                {
                    var i_ZeroNum = 2-rightNo.length
                    for(var i=0;i<i_ZeroNum;i++)
                    {
                        rightNo += "0";
                    }
                }
                obj.value = obj.value + rightNo;
            }
        }
    }
    else
    {
          obj.value = "";
          return false;
    }
}
//目的：判斷欄位一定要輸入數字
//參數：objFld--傳入欄位ID
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2005/04/22   1.00    Abel        New Create
function IsNumeric(objFld)
{
	var temp =objFld.value;		
	if (objFld.value!="")
	{		
		if (isNaN(objFld.value))
		{
			alert("Number only");
			objFld.value="";
			objFld.focus();
			window.event.returnValue=false;					
		}	
		var ary=objFld.value.split(".");
		if(ary.length==1)
		    return true;
		var strV1=ary[0];
		var strV2=ary[1];
		if(strV1=="") strV1="0";
		if(strV2=="") 
		    objFld.value=strV1;
		else
		    objFld.value=strV1+"."+strV2;		
	}	
	return true;	
}
//目的：當拉動datagrid的捲軸時標頭隨著捲軸動
//參數：
////  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
////   1. 2005/05/07   1.00    Abel        New Create 
function head_scroll(objDivHead,objDivGrid)
{
	if (objDivHead!=null && objDivGrid!=null)
    { 
		objDivHead.scrollLeft=objDivGrid.scrollLeft; 
	}		
}  

//目的：設定有捲軸的datagrid的標題欄位，且隱藏原來grid的標題
//參數：
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2005/05/07   1.00    Abel        New Create
function SetTitle()
{	
	if(document.forms[0].all("ctl00_MainPlace_txtDGName")!=null)
	{
		var ObjTable=document.forms[0].all("ctl00_MainPlace_txtDGName").value;
		var objdiv=document.all.tags("div");
		for (i=0;i<objdiv.length;i++)
		{		
			if(objdiv[i].id.substring(0,23)=="ctl00_MainPlace_DG_Head")
			{								
				var Head=objdiv[i];
				if (document.all(ObjTable)!=null)
    			{    		
  					var Content=document.all(ObjTable);
  					var dgtable=Content.cloneNode(false);  			
   					var dgtable_head=Content.rows(0).cloneNode(true);
  					var NewRow=dgtable.insertRow(0);
  					NewRow.replaceNode(dgtable_head);  
  					Head.insertBefore(dgtable); 
					Content.rows(0).style.display = "none"; 					
  					dgtable.id="Header";  		      
    			}    			
			}			
		}  		
    }
}
function disableall_control(){
      for(i=0;i<document.forms[0].elements.length;i++){
            document.forms[0].elements[i].disabled=true;
      }
}
function enableall_control(){

      for(i=0;i<document.forms[0].elements.length;i++){
            document.forms[0].elements[i].disabled=false;
      }
}
//字符串去空格的正則式
String.prototype.trim=function()
{
	return this.replace(/(^\s*)|(\s*$)/g,'');
}

//判斷日期是否合法
function FunIsDate(str) 
{ 
 	var objV=str;
	var sY;
	var sM;
	var sD;
	var strTimeAry1=objV.split("-");
	if(strTimeAry1.length != 3)
	    return false;
	sY=strTimeAry1[0];
	sM=strTimeAry1[1];
	sD=strTimeAry1[2];
	//alert(objV);
	try{
	    is=sY * 1;
	    is=sM * 1;
	    if(sD * 0 !=0)
	        return false;
	}catch(e)
	{return false;}
	if(sY.length !=4 || sM.length>2 || sD.length>2)
	    return false;
	if(sM>'12' || sM<'01' || sD<'01' || sD>'31')
		return false;
	else
		if(((sM=='04'||sM=='06'||sM=='09'||sM=='11')&& sD=='31')||(sM=='02' && sD>'29')||(sM=='02' && sD=='29' &&(sY%4!=0 ||(sY%100==0 && sY%400!=0))))
			return false;
	return true;				
}

//判斷欄位日期是否合法，不合法清空并提示
//add by saga
function chkDate(obj)
{
    var s_value = obj.value;
    if(s_value != "")
    {
        var bool_value = FunIsDate(s_value);
        if(bool_value == false)
        {
            alert("Please input right date, EX:yyyy-mm-dd");
            obj.value = "";
        }
    }
}
function gChangeDate(vobjName) {
    //	ClearError();
    var strDay, strMonth, strYear, strTimeAry, strWeekName
    var strDate, StandDate, strWeekName, datDate, intNum, strChangeDate
    var resStr = "";
    strDate = vobjName.value.trim();
    if (strDate == "") {
        return; //若為空值, 則不做
    }
    //轉換日期為標準模式 "1997-05-06"
    //XXXX/XX/XX
    if (strDate.indexOf("/") != 0) {
        resStr = "";
        for (var i = 0; i < strDate.length; i++)
            resStr = resStr + ((strDate.substring(i, i + 1)).replace('/', '-'));
        strDate = resStr;
    }
    //XXXX.XX.XX
    if (strDate.indexOf(".") != 0) {
        resStr = "";
        for (var i = 0; i < strDate.length; i++)
            resStr = resStr + ((strDate.substring(i, i + 1)).replace('.', '-'));
        strDate = resStr;
    }
    //XXXXXXXX	
    if (strDate.indexOf("-") <= 0)
        strDate = strDate.substring(0, strDate.length - 4) + "-" + strDate.substring(strDate.length - 4, strDate.length - 2) + "-" + strDate.substring(strDate.length - 2, strDate.length);

    //若輸入日期為12/23/23 應該是不合理的情況 ->先轉成西元年格式再做判斷
    var strTimeAry1 = strDate.split("-");
    if (strTimeAry1.length != 3) {
        //alert("日期格式不正確(正確格式:yyyy/MM/dd)"); //日期格式不正確(正確格式:yyyy/MM/dd)
        Show("A00026")
        vobjName.focus();
        vobjName.value = "";
        return;
    }
    //判斷日期是否合法
    var idDate = IsCDate(strDate);
    if (!idDate) {
        //alert("日期格式不正確(正確格式:yyyy-MM-dd)"); //日期格式不正確(正確格式:yyyy/MM/dd)
        Show("A00026")
        vobjName.focus();
        vobjName.value = "";
        return;
    }
    strYear = strTimeAry1[0];
    strMonth = strTimeAry1[1];
    strDay = strTimeAry1[2];

    if (strMonth.length == 1)
        strMonth = "0" + strMonth;
    if (strDay.length == 1)
        strDay = "0" + strDay;
    strDate = strYear + "-" + strMonth + "-" + strDay;
    vobjName.value = strDate;
}
/******************************************************************************************
' 函數名稱 : IsCDate
' 目    的 : 判斷日期是否正確
' 參數說明 : obj : 日期對象值
'            stype : 日期類型﹐0﹕非標准日期19970807﹐1﹕標准日期1997/8/7
'            CDate : 民國日期﹐0﹕公元日期﹐  1﹕民國日期
'******************************************************************************************/
//判斷日期
function IsCDate(objV) {
    var objV = objV.trim();
    var r = objV.match(/^(\d{1,4})(-|\-)(\d{1,2})\2(\d{1,2})$/);
    if (r == null) return false;
    var d = new Date(r[1], r[3] - 1, r[4]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);

}
//檢查時間欄位值的合法性
//objtime時間對象
//strH=0返回HH:MM，否則返回HH:MM:SS
function Check_Time_Field(objtime,strH)  
{
	var strTime
	var resStr="";
	var vH
	var vM
	var vS
	strTime=objtime.value.trim();
	if(strTime=="")	return true; //若時間為空值, 則不做	
	//設定時間為準模式 "12：00：00"	
	//XX.XX.XX
	resStr="";
	for(var i=0;i<strTime.length;i++)
		resStr=resStr +((strTime.substring(i,i+1)).replace('.',':'));
	strTime=resStr;
	//XX XX XX
	resStr="";
	for(var i=0;i<strTime.length;i++)
		resStr=resStr +((strTime.substring(i,i+1)).replace(' ',':'));
	strTime=resStr;
	//XX-XX-XX 
	resStr="";		
	for(var i=0;i<strTime.length;i++)
		resStr=resStr+((strTime.substring(i,i+1)).replace('-',':'));
	strTime=resStr;	
	//XXXXXXXX
	if(strTime.indexOf(":")<=0)
	{
		if(strTime.length==1)
			strTime="0"+""+strTime+":00:00";
		else{
			strTime=(strTime+'000000').substring(0,6)
		 	strTime=strTime.substring(0,2)+":"+strTime.substring(2,4)+ ":"+strTime.substring(4,6);
	 	}
	}
	//XX:XX
	if(strTime.lastIndexOf(":")>0 && strTime.lastIndexOf(":")<=2)
		strTime=strTime+':00';	
		
	var strTimeArry2=strTime.split(":");	
	vH=strTimeArry2[0];
	vM=strTimeArry2[1];
	vS=strTimeArry2[2];
	if(strTimeArry2.length==2)
		vS="00";
	if(!(isNaN(vH)||isNaN(vM)||isNaN(vS)))
	{
		if(vH>=24) vH=vH-24;
		if(vM>=60) vM=vM-60;
		if(vS>=60) vS=vS-60;	
		vH="00"+(vH*1).toString()
		vH=vH.substring(vH.length-2,vH.length)
		vM="00"+(vM*1).toString()
		vM=vM.substring(vM.length-2,vM.length)
		vS="00"+(vS*1).toString()
		vS=vS.substring(vS.length-2,vS.length)
	}	
	strTime=vH+":"+vM+":"+vS;
//對時間進行判斷
	if(!IsTime(strTime))
	{
		alert("Time error !") ;
		objtime.value="";
		objtime.focus();		
		return false;
	}	
	if(strH==0)
		strTime=strTime.substring(0,5);
	objtime.value=strTime;	
	return true;
}
//檢查時間合法性
function IsTime(strTime)
{
	var strHours;
	var strMinutes;
	var strSeconds;	
	var strTimeArry3=strTime.split(":");　//以":"為界分裝到數組中
	if(strTimeArry3.length!=3)//如果不是時分秒標准形式不判斷　　
		return false;
	strHours=strTimeArry3[0];
	strMinutes=strTimeArry3[1];
	strSeconds=strTimeArry3[2]
	if(isNaN(strHours)||isNaN(strMinutes)||isNaN(strSeconds))
		return false;
	if(strTimeArry3[0].length>2||strTimeArry3[1].length>2||strTimeArry3[2].length>2)
		return false;
	if(strHours>23||strHours<0||strMinutes>59||strMinutes<0||strSeconds>59||strSeconds<0)
		return false;
	return true;
}
//目的：欄位格式化，不足位時用0補足
//參數：obj對象,intBit欲補足的位數
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2005/06/09   1.00    XIONG       Create
function funFormat(obj,intBit)
{
	var val=obj.value.trim();
	var str="";
	var i=0;
	if(val!="")
	{
		for(i=0;i<intBit;i++)
			str=str+"0";
		val=str + val;
		val=val.substring(val.length-intBit,val.length);
		obj.value=val;
		return true;
	}
	return false;
}
//左右兩個TEXT物件範圍帶值
function text_range(obj1,obj2,cho,pos){
   //obj1=起始物件;
   //obj2=終止物件;
   //cho=D:日期的物件;U:需轉成大寫的物件;L:需轉成小寫的物件
   //pos=1:值來自起始物件;pos=2:值來自終止物件
   flg = true 
   if (pos==1){
      text1=obj1
      text2=obj2
   }else{
      text1=obj2
      text2=obj1
   }

   if (text1.value==''){
       return true;
   }
   if (cho=='D')
   {
      var bool=FunIsDate(text1.value);
      if(bool==false)
      {
		flg=false;
		text1.value="";
	  }
      if (flg==true){
         if (text1.value !='' && text2.value !='')
         {    
            ary1=obj1.value.split("/");
            ary2=obj2.value.split("/");        
//            if (obj2.value !=''&& obj1.value > obj2.value ){
            if (obj2.value !=''&& ary1[2]+"/"+ary1[0]+"/"+ary1[1] > ary2[2]+"/"+ary2[0]+"/"+ary2[1] )
            {
               alert("End less than Begin");
               //改成將兩個欄位都清空，並 Focus 於起日才對
               text1.value=text2.value;
               text1.select(); 
               text1.focus();  
               return false;            
            }
         }
      }
   }else if(cho=='U'){
      text1.value=text1.value.toUpperCase()
   }else if(cho=='L'){
      text1.value=text1.value.toLowerCase()
   }else if (cho=='T'){
		if(obj1.value.trim()!="" && obj2.value.trim()!="" && obj1.value.trim()*1>obj2.value.trim()*1)
		{
			alert("End less than Begin");
			 obj1.value=obj2.value;
              obj1.select(); 
              obj1.focus();  
               return false;           
			return false;
		}
   }
   
   if (flg==true && text2.value ==''){
      text2.value=text1.value;
      text2.select();
      text2.focus();
      return false;
   }
   return true;
}
/******************************
*作用：判斷一個物件中輸入的值是否超過設定大小,不區分中英文的，中文占１個長度
*名稱：isOver_EN（）
*參數：sText：對像名，len：允許長度
*用法示例：isOver_EN(this,20)
*/
function isOver_EN(sText,len)
{
	var intlen=sText.value.length;
	if (intlen > len) {	
        //alert("資料要求長度不得超過"+len+"個字符，目前資料長度是"+intlen+"個字符");
	    Show("A00087", len + "$" + intlen);
		sText.focus();	
		sText.select();
		return false;
	}
	return true;
}
/**********************************************************
作用textarea長度限定
用法checkLength(this,300)
this：對像名，len：允許長度
add by skyshi*/
function checkLength(objField,MaxLength) 
{
    
    if(objField.value!="") //不為空的情況下判斷
    {
        if(objField.value.length > MaxLength) 
        {
            //ShowError('A00009','不能輸入長度大于 '+MaxLength+' 的字符,系統將自動截取'+MaxLength+'');
            //alert('不能輸入長度大于 '+MaxLength+' 的字符,系統將自動截取'+MaxLength+'');
            objField.value =objField.value.substring(0,MaxLength);
            objField.focus();  
            return;
        }
    }
    
}
/******************************
*作用：判斷一個物件中輸入的值是否超過設定大小,一般用來判斷區分中英文的，中文占２個長度
*名稱：isOver_CN（）
*參數：sText：對像名，len：允許長度
*用法示例：isOver_CN(this,20)
*/
function isOver_CN(sText,len)
{
	var intlen=sText.value.length;
	if (intlen<=len && intlen>len/2)
   		intlen=bitLenght(sText);
	if (intlen>len) {
	    //alert("資料要求長度不得超過"+len+"個字符，目前資料長度是"+intlen+"個字符");
	    Show("A00087", len + "$" + intlen);
		sText.focus();	
		sText.select();
		return false;
	}
	return true;
}

/******************************
*作用：計算一個對象的值的長度，中文占２個長度
*名稱：bitLenght（）
*參數：sText：對像名
*用法示例：bitLenght(sText)
*/
function bitLenght(sText)
{
	var intlen;
	intlen=0;
	for(var i=0; i<sText.value.length; i++)
	{
		if(sText.value.charCodeAt(i)>255){
				intlen=intlen+2;}
			else{
				intlen++;}
	}
	return intlen;	
}

//判斷欄位值是否是正整數
function Check_Int_Field_Plus(objF)
{
	if(Check_Int_Field(objF))
	{
		var intV=objF.value*1;
		if(intV<0)
		{
			alert("欄位值不可小於0!")
			objF.value="";
			objF.focus();
			objF.select();
			return false;
		}
		objF.value=intV;
		return true;	
	}
}
//判斷欄位值是否是整數
function Check_Int_Field(ObjName)
{
	var LV_Value =ObjName.value.trim();
    if ((LV_Value != '') && (!isInteger(LV_Value)))
    {
        Show("A00098"); //請輸入數字！
	      ObjName.value="";
        ObjName.focus();
        return false;
    }
    strCheckNum = LV_Value * 1;
    ObjName.value = strCheckNum;
    return true;
}
//判斷是否為數字
function isNumeric(strNum) {  
	var strCheckNum = strNum + "";
	if(strCheckNum.length < 1) //空字符串
		return false;
	if(isNaN(strCheckNum)) //不是數值
		return false;
	return true;
}
//判斷是否是整數
function isInteger(strNum) {
    var arryValue = strNum.split(".");
    if (arryValue.length != 1)//無小數點
        return false;
    arryValue = strNum.split("-");
    if (arryValue.length != 1)//無小數點
        return false;
    arryValue = strNum.split("+");
    if (arryValue.length != 1)//無小數點
        return false;
	var strCheckNum = strNum*1 + "";
	if(strCheckNum.length < 1) //空字符串
		return false;
	if(isNaN(strCheckNum)) //不是數值
		return false;
	if(parseFloat(strCheckNum) > parseInt(strCheckNum)) //不是整數
		return false;
	return true;
}

//*******************************************
//目的：生成xml
//參數：
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS
//   1. 2006/05/04   1.00    Cindy       Create
function __ATLoadXml(vstrReq){
//var strReq;				variable to hold request string
	var root, source;		//A couple of XMLDOM objects (document and 
	var sT;

	//Show a searching message
	status = 'searching, please wait....';
	//Create an xml document object, and load the server's response
	source = new ActiveXObject('Microsoft.XMLDOM');
	source.async = false;

	//Send the request string and read the result into the XMLDOM object
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
function GetXmlHttpRequest()
{
    var xhr=null; 
    try 
    { 
        xhr=new ActiveXObject("Msxml2.XMLHTTP");//initialize a xmlhttp object 
    } 
    catch(e)
    { 
        try 
        { 
            xhr=new ActiveXObject("Microsoft.XMLHTTP"); 
        }
        catch(oc)
        { 
            xhr=null 
        } 
    } 

    if (!xhr && typeof XMLHttpRequest != "undefined" ) 
    { 
        xhr=new XMLHttpRequest() 
    } 
    return xhr 
} 


//功能: 當按Enter時就移到下一個欄位
//參數：
//  xx. YYYY/MM/DD   VER     AUTHOR      COMMENTS　　
//   1. 2005/04/22   1.00    Abel        New Create
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
//   1. 2005/04/21   1.00    Abel        New Create
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
/*****************************************************
* 函數名稱: fnSelAll()
* 目    的: 全選
* 參數說明: gridID:Grid之ID; chListID:CheckBox之ID; boolValue 全選欄溝選狀態，選中為true，未選為false
*****************************************************/
function fnSelAll(gridID,chListID,boolValue)
{	
    try
    {
	    var ObjTable = document.all(gridID);
	    for (var i = 0, iLen = ObjTable.rows.length; i < iLen; i++) {
	        var objCheckBox = document.getElementById(gridID + "_" + chListID + "_" + i);
	        objCheckBox.checked = boolValue;
	    }
     }catch(e){//alert(e);
     }
}

//設置只可以選一個CHECKBOX,實例onclick="return SingleChk(this,'grdList','chkList')"
//BY INSON
function SingleChk(obj,grdList,chkList)
{
if(obj.checked==false)
{
}
else
{
        var MainPage="ctl00_MainPlace_";
        var ObjTable = document.all(MainPage + grdList);
        var intCount=0;
            for(var i=2; i < ObjTable.rows.length+1; i++)
            {
                var intA=i*1+1;
                if((intA+"").length<2)
                    intA="0"+intA;
                var objCheckBox = document.all(MainPage + grdList + "_ctl"+intA+"_"+chkList);
                if(objCheckBox!=null&&objCheckBox.id!=obj.id)
                {
                objCheckBox.checked=false;
                }
            }
  } 
}
/*****************************************************
* 函數名稱: fnGetSelctCount()
* 目    的: 計算Grid勾選的筆數
* 參數說明: gridID:Grid之ID; chListID:CheckBox之ID;
*****************************************************/
function fnGetSelctCount(gridID,chListID)
{	
    var MainPage="";
    var intCount=0;
    try
    {
	    var ObjTable = document.all(MainPage+gridID); 
        for(i=2; i < ObjTable.rows.length; i++)
        {
            var intA=i*1+1;
            if((intA+"").length<2)
                intA="0"+intA;
            var objCheckBox = document.all(MainPage+gridID+"_ctl"+intA+"_"+chListID);
            if(objCheckBox.checked ==true)
                intCount +=1;
        }
     }catch(e){
     }
     return intCount;
}
//Grid選擇的顏色變化
function fnGridSelectRow(grdList,intRow)
{
    var MainPage="ctl00_MainPlace_";
//    var ObjTable = document.all(MainPage + grdList);
    var ObjTable = document.all(grdList);
    for(var i=1; i < ObjTable.rows.length; i++)
    {
        if(i % 2==0)
            ObjTable.rows[i].className="Row2";
        else
            ObjTable.rows[i].className="Row1";
    }
    ObjTable.rows[intRow].className="RowSel";
}

//将计算得到的结果四舍五入 ,Add By Dath
//* * ForDight(Dight,How):数值格式化函数，Dight要 * 格式化的 数字，How要保留的小数位数。 */ 
function ForDight(Dight,How)
{ 
	var Dight = Math.round (Dight*Math.pow(10,How))/Math.pow(10,How); 
	return Dight; 
}

//返回保留兩位小數 ,Add By Dath
function changeTwoDecimal_f(x) {
    var f_x = parseFloat(x);
    if (isNaN(f_x)) {
        alert('function:changeTwoDecimal->parameter error');
        return false;
    }
    var f_x = Math.round(x * 100) / 100;
    var s_x = f_x.toString();
    var pos_decimal = s_x.indexOf('.');
    if (pos_decimal < 0) {
        pos_decimal = s_x.length; s_x += '.';
    }
    while (s_x.length <= pos_decimal + 2) {
        s_x += '0';
    }
    return s_x;
}
//判斷起始和結束日期的大小
function CheckDateSE(objDateS, objDateE, ISstart) {
    try {
        var objStartDate = document.getElementById(objDateS);
        var objEndDate = document.getElementById(objDateE);
        var StartDate = objStartDate.value.trim();
        var EndDate = objEndDate.value.trim();
        if (StartDate != "" && EndDate != "") {
            var r = StartDate.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
            var dStart = new Date(r[1], r[3] - 1, r[4]);
            var r = EndDate.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
            var dEnd = new Date(r[1], r[3] - 1, r[4]);
            if (dStart > dEnd) {
                if (ISstart == true) {
                    objStartDate.value = "";
                    Show("A00128"); //開始日期不能大於結束日期
                }
                else {
                    objEndDate.value = "";
                    Show("A00129"); //結束日不能小於開始日
                }
                return false;
            }
            else {
                return true;
            }
        }
    } catch (e) {
    }
}

//開啟檔案
////Url: 檔案相對路徑和名稱
function funOpenFile(Url, Type, ID, FileName) {

    var strU = funStringToBase64(Url);
    var resStr = "";
    for (var i = 0; i < strU.length; i++) {
        resStr = resStr + (strU.substring(i, i + 1)).replace('=', '!').replace("/", "@").replace("+", "*");
    }
    var strUrl = "../OpenFile.aspx?Type=" + Type + "&ID=" + ID + "&FileName=" + escape(FileName) + "&U="
    strUrl += resStr;
    OpenWin(strUrl, 200, 100, "");
}
function funStringToBase64(input) {
    if (input == "")
        return "";
    var keyStr = "ABCDEFGHIJKLMNOP" +
                 "QRSTUVWXYZabcdef" +
                 "ghijklmnopqrstuv" +
                 "wxyz0123456789+/" +
                 "=";
    input = escape(input);
    var output = "";
    var chr1, chr2, chr3 = "";
    var enc1, enc2, enc3, enc4 = "";
    var i = 0;

    do {
        chr1 = input.charCodeAt(i++);
        chr2 = input.charCodeAt(i++);
        chr3 = input.charCodeAt(i++);

        enc1 = chr1 >> 2;
        enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
        enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
        enc4 = chr3 & 63;

        if (isNaN(chr2)) {
            enc3 = enc4 = 64;
        } else if (isNaN(chr3)) {
            enc4 = 64;
        }

        output = output + keyStr.charAt(enc1) + keyStr.charAt(enc2) + keyStr.charAt(enc3) + keyStr.charAt(enc4);
        chr1 = chr2 = chr3 = "";
        enc1 = enc2 = enc3 = enc4 = "";
    } while (i < input.length);

    return output;
}