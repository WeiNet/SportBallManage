// JScript 文件

var Mintus="";
function Reload()
{
    Mintus--;
    if(document.all.lblMintus!=null)
    {
        document.all.lblMintus.innerText=Mintus;
        if(Mintus==0)
        {
            document.all.btnUpdate.click();
        }
        else if(Mintus<0)
        {
            document.all.lblMintus.innerText="";
        }
    }
}
setInterval("Reload();",1000);

function deletetishireason(obj)
{
    var a =document.getElementById(obj);
    if(a!=null)
        a.childNodes[0].attachEvent('onclick',confirmsreason);
    
}
function confirmsreason()
{
    if(ShowConfirm("00042","")==true){
        var delreason= window.prompt(ShowMessage("00049",""),'');
        if(delreason==null) delreason="";
        document.getElementById("delyy").value=delreason;
        return true;
    }
    return false;
}
function deletetishi(obj)
{
    var a =document.getElementById(obj);
    if(a!=null)
        a.childNodes[0].attachEvent('onclick',confirms);
}
function querentishi(obj)
{
    var a =document.getElementById(obj);
    if(a!=null)
        a.childNodes[0].attachEvent('onclick',querenconfirms);
}
function huifutishi(obj)
{
    var a =document.getElementById(obj);
    if(a!=null)
        a.childNodes[0].attachEvent('onclick',huifuconfirms);
}
function confirms()
{
    return ShowConfirm("00042","");
}
function querenconfirms()
{
    return ShowConfirm("00043","");
}
function huifuconfirms()
{
    return ShowConfirm("00044","");
}

function ConRate(obj1,obj2)
{
    switch(obj1.value)
    {
        case "1":
            obj2.value = 50;
            obj2.readOnly = false;
            break;
        case "0":
            obj2.value = 0;
            obj2.readOnly = true;
            break;
        case "-1":
            obj2.value = 50;
            obj2.readOnly = false;
            break;
        case "-2":
            obj2.value = 100;
            obj2.readOnly = true;
            break;
    }
}
function checkSave()
{
    var drpLM = document.getElementById("drpLM");
    var drpVisit = document.getElementById("drpVisit");
    var drpHome = document.getElementById("drpHome");
    if(drpLM.value.trim()=="-1")
    {
        alert("請選擇聯盟");
        drpLM.focus();
        return false;
    }
    if(drpVisit!=null&&drpVisit.value.trim() =="-1")
    {
        alert("請選擇球隊");
        drpVisit.focus();
        return false;
    }
    if(drpHome!=null&&drpHome.value.trim() =="-1")
    {
        alert("請選擇球隊");
        drpHome.focus();
        return false;
    }
    if(drpHome!=null&&drpVisit!=null&&drpHome.value.trim() == drpVisit.value.trim())
    {
        alert("兩個球隊不能相同;"); 
        drpHome.focus();
        return false;
    }
    var txtVisitNo = document.getElementById("txtVisitNo");
    var txtHomeNo = document.getElementById("txtHomeNo");
    if(txtVisitNo!=null&&txtVisitNo.value.trim()=="")
    {
        
        alert("請輸入場次編號");
        return false;
    }    
    if(txtHomeNo!=null&&txtHomeNo.value.trim()=="")
    {
        alert("請輸入場次編號");
        return false;
    }
    return true;
}
function checkOtherSave()
{
    var drpLM = document.getElementById("ContentPlaceHolder11_drpLM");
    var drpVisit = document.getElementById("ContentPlaceHolder11_drpVisit");
    var drpHome = document.getElementById("ContentPlaceHolder11_drpHome");
    if(drpLM.value.trim()=="-1")
    {
        alert("請選擇聯盟");
        drpLM.focus();
        return false;
    }
    if(drpVisit!=null&&drpVisit.value.trim() =="-1")
    {
        alert("請選擇球隊");
        drpVisit.focus();
        return false;
    }
    if(drpHome!=null&&drpHome.value.trim() =="-1")
    {
        alert("請選擇球隊");
        drpHome.focus();
        return false;
    }
    if(drpHome!=null&&drpVisit!=null&&drpHome.value.trim() == drpVisit.value.trim())
    {
        alert("兩個球隊不能相同");
        drpHome.focus();
        return false;
    }
    var txtVisitNo = document.getElementById("ContentPlaceHolder11_txtVisitNo");
    var txtHomeNo = document.getElementById("ContentPlaceHolder11_txtHomeNo");
    if(txtVisitNo!=null&&txtVisitNo.value.trim()=="")
    {
        alert("請輸入場次編號");
        return false;
    }    
    if(txtHomeNo!=null&&txtHomeNo.value.trim()=="")
    {
        alert("請輸入場次編號");
        return false;
    }
    return true;

}
    function getHomeNo(obj)
    {   
        onlyInt(obj) ;
        var txtHomeNo = document.getElementById("ContentPlaceHolder11_txtHomeNo");
        txtHomeNo.value = parseInt(obj.value,10)+1;
    }
    function getVisitNo(obj)
    {   
        onlyInt(obj);
        var txtVisitNo = document.getElementById("ContentPlaceHolder11_txtVisitNo");
        txtVisitNo.value = parseInt(obj.value,10)-1;
    }
    function getGS(obj)
    {
        var http = GetXMLHTTP();
        var oDoc = new ActiveXObject("MSXML2.DOMDocument");
        var url = "index_addgame.aspx?LM="+obj.value+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
        var result = http.responseText;
    
        if(result != 'null'){
            oDoc.loadXML(result);
            var root=oDoc.documentElement;
            if (root==null)
                return true;
     
            //判斷並返回錯誤信息
            var drpVisit=document.getElementById("drpVisit") ;
          
            drpVisit.length=0;
            drpVisit.options.add(new Option(ShowMessage("G0044",""),"-1"));
            for(i=0;i<root.childNodes.length;i++)
            {
                var nodeSub=root.childNodes[i];
                var text="";
                var value="";
                if(nodeSub.selectSingleNode("N_DWMC")!=null){
                    text=nodeSub.selectSingleNode("N_DWMC").text.trim();
                }
                if(nodeSub.selectSingleNode("N_ID")!=null) {
                    value=nodeSub.selectSingleNode("N_ID").text.trim();
                }
                drpVisit.options.add(new Option(text,value));
            }
            drpVisit.selectedIndex = 0;
        }
    }
    function getDW(obj,objStatus)
    {
        var http = GetXMLHTTP();
        var oDoc = new ActiveXObject("MSXML2.DOMDocument");
        var url ;
        if(objStatus=="baseball")
            url = "baseball_addgame.aspx?LM="+obj.value+"&random="+Math.random();
        else if(objStatus=="football")
            url = "football_addgame.aspx?LM="+obj.value+"&random="+Math.random();
        else if(objStatus=="index")
            url = "index_addgame.aspx?LM="+obj.value+"&random="+Math.random();
        else  
            url = "basketball_addgame.aspx?LM="+obj.value+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
        var result = http.responseText;
    
        if(result != 'null'){
            oDoc.loadXML(result);
            var root=oDoc.documentElement;
            if (root==null)
                return true;
     
            //判斷並返回錯誤信息
            var drpVisit=document.getElementById("drpVisit") ;
            var drpHome=document.getElementById("drpHome") ;
          
            drpVisit.length=0;
            drpHome.length=0;
            drpVisit.options.add(new Option(ShowMessage("G0042",""),"-1"));
            drpHome.options.add(new Option(ShowMessage("G0042",""),"-1"));
            for(i=0;i<root.childNodes.length;i++)
            {
                var nodeSub=root.childNodes[i];
                var text="";
                var value="";
                if(nodeSub.selectSingleNode("N_DWMC")!=null){
                    text=nodeSub.selectSingleNode("N_DWMC").text.trim();
                }
                if(nodeSub.selectSingleNode("N_ID")!=null) {
                    value=nodeSub.selectSingleNode("N_ID").text.trim();
                }
                drpVisit.options.add(new Option(text,value));
                drpHome.options.add(new Option(text,value));
            }
            drpVisit.selectedIndex = 0;
            drpHome.selectedIndex = 0;
        }
    }
    function GetXMLHTTP()
    {
        var A = null;
        try
        {
            A = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch(e)
        {
            try
            {
                A = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch(e)
            {
                A=null;
            }
        }
        if(!A&&XMLHttpRequest!=null)
        {
            A = new XMLHttpRequest();
        }
        return A;
    }
    function CountRate(obj1,obj2,obj3,obj,type)
    {
        if(type !=null) 
            type = 10.000;
        else 
            type = 2.000;
        if(obj==3){
            if(parseFloat(obj3.value)>type){
                obj3.value = type;
            }
            obj1.value =(parseFloat(obj3.value)/2).toFixed(3);
            obj2.value =(parseFloat(obj3.value)/2).toFixed(3);
            obj3.value = parseFloat(obj3.value).toFixed(3);
        }
        else if(obj==2)
        {
            if(parseFloat(obj2.value)>type)
            {
                obj2.value=type;
            }
            //        else if(parseFloat(obj2.value)<0)
            //        {
            //            obj2.value="0.000";
            //        }
            obj1.value  = (parseFloat(obj3.value)-parseFloat(obj2.value)).toFixed(3);
            obj2.value = parseFloat(obj2.value).toFixed(3);
        }
        else
        {
            if(parseFloat(obj1.value)>type)
            {
                obj1.value=type;
            }
            //        else if(parseFloat(obj1.value)<0)
            //        {
            //            obj1.value="0";
            //        }
            obj2.value  = (parseFloat(obj3.value)-parseFloat(obj1.value)).toFixed(3);
            obj1.value = parseFloat(obj1.value).toFixed(3);
        }
    }
    ///四舍五入
    function round(v,e) 
    { 
        var t=1; 
        for(;e>0;t*=10,e--); 
        for(;e<0;t/=10,e++); 
        return Math.round(v*t)/t; 
    } 
    function CountTotal(obj1,obj2,obj3)
    {
        var obj1 = document.getElementById(obj1);
        var obj2 = document.getElementById(obj2);
        var obj3 = document.getElementById(obj3);
        obj3.value=(parseFloat(obj1.value)+parseFloat(obj2.value)).toFixed(3);
    }
    function OpenBallSet(objValue,objPK)
    {
        //var strPara ="dialogHeight:300px;dialogWidth:800px;status:no;scroll:no;help:no;title:yes;";//showModalDialog
        var strPara = "height=600px, width=1000px, top=100px, left=200px, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no";
        var StrRtn = window.open(objValue,objPK,strPara);
    }
    function OpenFastSet(objValue,objPK)
    {
        //var strPara ="dialogHeight:300px;dialogWidth:800px;status:no;scroll:no;help:no;title:yes;";//showModalDialog
        var strPara = "height=200px, width=600px, top=300px, left=200px, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no";
        var StrRtn = window.open("../ball_fastset.aspx?random=" + Math.random()+"&N_ID="+objValue+"&PK="+objPK,objPK,strPara);
        if(StrRtn!=null)
        {
            //document.all.btnUpdate.click();
            //return true;
        }
        else
        {
            //return false;
        }
    }

    function OpenFastZDSet(objValue)
    {
        var strPara = "height=200px, width=600px, top=300px, left=200px, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no";
        var StrRtn = window.open("ball_RunSet.aspx?random=" + Math.random()+"&N_ID="+objValue,"",strPara);
    }
    /*
    function OpenSet(objValue,objPK)
    {
        var strPara ="dialogHeight:300px;dialogWidth:800px;status:no;scroll:no;help:no";//showModalDialog
        //var strPara = "'dialogWidth: 300px;dialogHeight: 200px;dialogLeft: 80px;dialogTop: 50px;toolbar: no;menubar: no;resizable: yes;location: no;status: no;scrollbars: no;center:yes;'";
        var StrRtn = window.showModalDialog("../ball_fastset.aspx?random=" + Math.random()+"&N_ID="+objValue+"&PK="+objPK,"",strPara);
        if(StrRtn!=null)
        {
            document.all.btnUpdate.click();
            return true;
        }
        else
        {
            return false;
        }
    }
    function OpenBKSet(objValue,objPK)
    {
        var strPara ="dialogHeight:300px;dialogWidth:800px;status:no;scroll:no;help:no";//showModalDialog
        //var strPara = "'dialogWidth: 300px;dialogHeight: 200px;dialogLeft: 80px;dialogTop: 50px;toolbar: no;menubar: no;resizable: yes;location: no;status: no;scrollbars: no;center:yes;'";
        var StrRtn = window.showModalDialog("../ball_fastset.aspx?random=" + Math.random()+"&N_ID="+objValue+"&PK="+objPK,"",strPara);
        if(StrRtn!=null)
        {
            document.all.btnUpdate.click();
            return true;
        }
        else
        {
            return false;
        }
    }
    */
    function BillClick(objVH,objWF,objPK,objValue,objBall,objType,objStatus)
    {
        var strPara ="dialogHeight:700px;dialogWidth:1000px;status:no;scroll:yes;help:no";//showModalDialog
        objWF=objWF.replace("(","").replace(")","");
        objType=objType.replace("(","").replace(")","");
        //var strPara = "'dialogWidth: 300px;dialogHeight: 200px;dialogLeft: 80px;dialogTop: 50px;toolbar: no;menubar: no;resizable: yes;location: no;status: no;scrollbars: no;center:yes;'";
        var StrRtn = window.showModalDialog("../ball_billdetail.aspx?random=" + Math.random()+"&N_ID="+objValue+"&VH="+objVH+"&WF="+escape(objWF)+"&PK="+objPK+"&Ball="+objBall+"&Type="+escape(objType)+"&Status="+objStatus,"",strPara);
        return false;
    }
    function BillDetail(objValue,objBall,objType,objStatus)
    {    
        var strPara ="dialogHeight:700px;dialogWidth:1000px;status:no;scroll:yes;help:no";//showModalDialog
        objType=objType.replace("(","").replace(")","");
        //var strPara = "'dialogWidth: 300px;dialogHeight: 200px;dialogLeft: 80px;dialogTop: 50px;toolbar: no;menubar: no;resizable: yes;location: no;status: no;scrollbars: no;center:yes;'";
        var StrRtn = window.showModalDialog("../ball_billdetail.aspx?random=" + Math.random()+"&N_ID="+objValue+"&Ball="+objBall+"&Type="+objType+"&Status="+objStatus,"",strPara);
        return false;
    }
    /*
    function BillBKClick(objVH,objWF,objPK,objValue,objBall,objType)
    {
        var strPara ="dialogHeight:700px;dialogWidth:1000px;status:no;scroll:no;help:no";//showModalDialog
        //var strPara = "'dialogWidth: 300px;dialogHeight: 200px;dialogLeft: 80px;dialogTop: 50px;toolbar: no;menubar: no;resizable: yes;location: no;status: no;scrollbars: no;center:yes;'";
        var StrRtn = window.showModalDialog("../ball_billdetail.aspx?random=" + Math.random()+"&N_ID="+objValue+"&VH="+objVH+"&WF="+escape(objWF)+"&PK="+objPK+"&Ball="+objBall+"&Type="+escape(objType),"",strPara);
        return false;
    }
    function BillBKDetail(objValue,objBall,objType)
    {    
        var strPara ="dialogHeight:700px;dialogWidth:1000px;status:no;scroll:no;help:no";//showModalDialog
        //var strPara = "'dialogWidth: 300px;dialogHeight: 200px;dialogLeft: 80px;dialogTop: 50px;toolbar: no;menubar: no;resizable: yes;location: no;status: no;scrollbars: no;center:yes;'";
        var StrRtn = window.showModalDialog("../ball_billdetail.aspx?random=" + Math.random()+"&N_ID="+objValue+"&Ball="+objBall+"&Type="+objType,"",strPara);
        return false;
    }
    */
    function OpenAll(obj1,obj2)
    {
        //    if(obj1.value=="開放中")
        if(obj2.value=="0")
        {
            obj1.value="關閉中";
            obj2.value = "1";
        }
        else
        {
            obj1.value="開放中";
            obj2.value = "0";
        }
    }
    function OpenPL(obj1,obj2)
    {
        //    if(obj1.value=="開")
        if(obj2.value=="0")
        {
            obj1.value="關";
            obj2.value = "1";
        }
        else
        {
            obj1.value="開";
            obj2.value = "0";
        }
    }
    function CountPLAdd(objL,objR)
    {   
        objL.value = (parseFloat(objL.value)+0.01).toFixed(3);
        objR.value = (parseFloat(objR.value)-0.01).toFixed(3);
    }
    function CountPLSub(objL,objR)
    {   
        objL.value = (parseFloat(objL.value)-0.01).toFixed(3);
        objR.value = (parseFloat(objR.value)+0.01).toFixed(3);
    }
    /*
    function CountClickL(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)+0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)-0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "baseball_dsgame.aspx?WF="+objWF+"&PL=L&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    function CountClickR(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)-0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)+0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "baseball_dsgame.aspx?WF="+objWF+"&PL=R&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    */
    function ChangeLPL(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)+0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)-0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "../ball_game.aspx?WF="+objWF+"&PL=L&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    function ChangeRPL(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)-0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)+0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "../ball_game.aspx?WF="+objWF+"&PL=R&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    /*
    function CountClickBKL(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)+0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)-0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "basketball_dsgame.aspx?WF="+objWF+"&PL=L&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    function CountClickBKR(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)-0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)+0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "basketball_dsgame.aspx?WF="+objWF+"&PL=R&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    function CountClickZQL(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)+0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)-0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "football_dsgame.aspx?WF="+objWF+"&PL=L&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    function CountClickZQR(objL,objR,objWF,objID)
    {   
        objL.innerText = (parseFloat(objL.innerText)-0.01).toFixed(3);
        objR.innerText = (parseFloat(objR.innerText)+0.01).toFixed(3);
        var http = GetXMLHTTP();
        var url = "football_dsgame.aspx?WF="+objWF+"&PL=R&N_ID="+objID+"&random="+Math.random();
        http.open("get",url,false);
        http.send();
    }
    */
    function CheckNum()
    {
        var re = /^-?[0-9.]+$/;
        var txtVisit = document.getElementById("txtVisit");
        var txtHome = document.getElementById("txtHome");
        var txtVisit_Up = document.getElementById("txtVisit_Up");
        var txtHome_Up = document.getElementById("txtHome_Up");
        if(txtVisit!=null&&txtVisit.value.match(re)==null)
        {
            Show("00086","");
            return false;
        }
        if(txtHome!=null&&txtHome.value.match(re)==null)
        {
            Show("00086","");
            return false;
        }
        if(txtVisit_Up!=null&&txtVisit_Up.value.match(re)==null)
        {
            Show("00086","");
            return false;
        }
        if(txtHome_Up!=null&&txtHome_Up.value.match(re)==null)
        {
            Show("00086","");
            return false;
        }
        return true;
    }
    function changefenshu(obj)
    {
        if(obj.value==0) {
            document.getElementById('ContentPlaceHolder11_drpRFCJPL').style.display = '';
            document.getElementById('ContentPlaceHolder11_drpRFCJPL1').style.display = 'none';
        }
        else{
            document.getElementById('ContentPlaceHolder11_drpRFCJPL1').style.display = '';
            document.getElementById('ContentPlaceHolder11_drpRFCJPL').style.display = 'none';
        }
    }
    var xmlHttp = false;
    /**
    * 初始化一个xmlhttp对象
    */
    function InitAjax()
    {
        var ajax=false; 
        try
        { 
            ajax = new ActiveXObject("Msxml2.XMLHTTP"); 
        } 
        catch (e) 
        { 
            try 
            { 
                ajax = new ActiveXObject("Microsoft.XMLHTTP"); 
            } 
            catch (E) 
            { 
                ajax = false; 
            } 
        }
        if (!ajax && typeof XMLHttpRequest!='undefined') 
        { 
            ajax = new XMLHttpRequest(); 
        } 
        return ajax;
    }
    function updatePage() 
    {
        if (xmlHttp.readyState == 4  )   // &&   xmlHttp.status == '200') 
        {
            var response = xmlHttp.responseText;
            if(response!="no")
            {
                alert(response);
            }
        }
    }
    function ShowZQDiv(nid,nvalue,ntype,nfield,lblid)
    {
        var x=window.event.x;
        var y= window.event.y;
        var obj=document.all.showdiv;	
        var txt=document.all.txtshow;	
        obj.style.left=x+5+window.document.body.scrollLeft;
        obj.style.top=y+5+window.document.body.scrollTop;
        obj.style.visibility="";
        txt.value=nvalue;
        if(ntype=="1")
            ntype="n_visit";
        else if(ntype=="2")
            ntype="n_home";
        else
            ntype="";
        document.all.hidnid.value=nid;
        document.all.hidntype.value=ntype;
        document.all.hidnfield.value=nfield;
        document.all.hidlblid.value=lblid;
    }
    function UpdZQ()
    {
        var nid=document.all.hidnid.value;
        var ntype=document.all.hidntype.value;	
        var nfield=document.all.hidnfield.value;
        var varvalue=document.all.txtshow.value;

        var lblpl=eval("document.all."+document.all.hidlblid.value);
        lblpl.innerHTML=varvalue;
        var obj=document.all.showdiv;	
        obj.style.visibility="hidden";
        TransZQ(nid,ntype,nfield,'up',varvalue);	
    }
    function divZQclose()
    {
        var obj=document.all.showdiv;	
        obj.style.visibility="hidden";
    }
    function checkZQNum(obj)
    {
        if(obj.value!="")
        {
            if(isNaN(obj.value))
            {
                Show("00087","");
                obj.focus();
            }
        }
        else
        {
            Show("00086","");
            obj.focus();
        }
    }
    function TransZQ(nid,ntype,nfield,flag,value)
    {
        xmlHttp=InitAjax();
        if(nid==null)
        {
            return ;
        }
        var Post_Url=document.forms[0].action+"";
        if(Post_Url.indexOf('?')>-1)
        {
            Post_Url+="&nid=" + nid + "&ntype=" + ntype + "&nfield=" + nfield + "&flag=" + flag + "&value=" + value;
        }
        else 
        {
            Post_Url+="?nid=" + nid + "&ntype=" + ntype + "&nfield=" + nfield + "&flag=" + flag + "&value=" + value;
        }
        xmlHttp.open("POST", Post_Url, true);
        xmlHttp.onreadystatechange = updatePage;
        xmlHttp.send(null);
    }



    function Showdiv()
    {
        var obj=document.getElementById("showdiv");
        if(obj.style.display=="")
            obj.style.display="none";
        else
        {
            obj.style.display="";
            //	    var x=window.event.x;
            //	    var y= window.event.y;
            //	    var obj=document.all.showdiv;	
            //	    //obj.style.left=x+5+window.document.body.scrollLeft;
            //        obj.style.top=y+10+window.document.body.scrollTop;
        }
    }
    function checkAll()
    {
        var obj=document.getElementById('showdiv');
        var el = obj.getElementsByTagName('input');
        var len = el.length;
        var boolChecked=false;
        if(document.getElementById("chk_all").checked==true)
            boolChecked=true;
        for(var i=0; i<len; i++)
        {
            if(el[i].type=="checkbox" && el[i].id!="chk_all" )
            {
                el[i].checked = boolChecked;
                fnCheck(el[i]);
            }
        }
        if(!boolChecked)
            document.getElementById("hidLeague").value="";
    }
    function fnCancel()
    {
        document.getElementById("showdiv").style.display="none";
    }

    function fnCheck(obj)
    {
        var strLeague=document.getElementById("hidLeague").value.trim();
        var strTemp=obj.value.trim()
        if(obj.checked==true)
        {
            if(strLeague.indexOf(strTemp)==-1)
                document.getElementById("hidLeague").value +=strTemp+"','";
        }
        else
        {
            if(strLeague.indexOf(strTemp+"','")>-1)
                document.getElementById("hidLeague").value=document.getElementById("hidLeague").value.replace(strTemp+"','",'');
            else if(strLeague.indexOf("','"+strTemp)>-1)
                document.getElementById("hidLeague").value=document.getElementById("hidLeague").value.replace("','"+strTemp,'');
            else if(strLeague.indexOf(strTemp)>-1)
                document.getElementById("hidLeague").value=document.getElementById("hidLeague").value.replace(strTemp,'');
        }
    }

    function fnSure()
    {
        document.getElementById("btnUpdate").click();
        document.getElementById("showdiv").style.display="none";
    }

    function ReBind(s_LM) {
        var arr = s_LM.split("','");
        var strLeague = document.getElementById("hidLeague").value.trim();
        for (i = 0; i < arr.length; i++) {
            if (document.getElementById("chk_" + arr[i]) != null)
                document.getElementById("chk_" + arr[i]).checked = true;
            else {
                if (strLeague.indexOf(arr[i] + "','") > -1)
                    document.getElementById("hidLeague").value = document.getElementById("hidLeague").value.replace(arr[i] + "','", '');
                else if (strLeague.indexOf("','" + arr[i]) > -1)
                    document.getElementById("hidLeague").value = document.getElementById("hidLeague").value.replace("','" + arr[i], '');
                else if (strLeague.indexOf(arr[i]) > -1)
                    document.getElementById("hidLeague").value = document.getElementById("hidLeague").value.replace(arr[i], '');
            }
        }
    }