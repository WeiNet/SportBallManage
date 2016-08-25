// JScript 檔
///Class代號：      MessageBox
///Class名稱：      讀取MessageBox.xml文件信息
///程式說明:     　 從MessageBox.xml文件中循環讀取符合要求的信息
///xx.YYYY/MM/DD    VER     AUTHOR       COMMENTS(說明修改的內容)  
///01.2010/12/31    1.00    Ivy          CREATE 

//---------------------------------------------------------------------[在登陸換面使用] (函數)
//Author       ：Ivy
//Last Modifiy ：2008/2/20
//function FnLogin()
//{
//    document.getElementById('txtMail').value='';
//    document.getElementById('txtPw').value='';
//    document.getElementById('txtMail').focus();
//   return false;

//}
//---------------------------------------------------------------------[在頁面上彈出信息提示] (函數)

//Author      ：Ivy

//Last Modify ：2010/12/21
function Show(strCode) {

    var msg = ShowMessage(strCode, '');

    alert(msg);

}
//---------------------------------------------------------------------[在頁面上彈出信息提示] (函數)
//Author      ：Ivy
//Last Modify ：2010/12/21
function Show(strCode,StrPara)
{
   if(StrPara==undefined) StrPara='';
   var msg=ShowMessage(strCode,StrPara);
   alert(msg);
}
//---------------------------------------------------------------------[給指定的Web控件,彈出確認框信息提示] (函數)
//Author      ：Ivy
//Last Modify ：2010/12/21
function ShowConfirm(strCode,StrPara)
{
    if(StrPara==undefined) StrPara='';
   var msg=ShowMessage(strCode,StrPara);
   if(status=="XML Error!"){
        alert(msg);
        return false
   }
   else{
        return  confirm(msg);
    }
}
//---------------------------------------------------------------------[彈出信息提示,並轉向指的頁面] (函數)
//Author      ：Ivy
//Last Modify ：2010/12/21
function ShowAndRedirect(strCode,StrPara,url)
{
	 var msg=ShowMessage(strCode,StrPara);
	 alert(msg);
	 self.location.href=url;
}
//---------------------------------------------------------------------[彈出信息提示,並轉向指的頁面] (函數)
//Author      ：Ivy
//Last Modify ：2010/12/21
function ShowAndBaseRedirect(strCode,StrPara,url)
{
	 var msg=ShowMessage(strCode,StrPara);
	 alert(msg);
	 window.parent.location.href=url;
}
/*************************************************************************
程式代號：BasePage
程式名稱：app_code/BasePage.cs使用
**************************************************************************/
function ReplMsgDesc(vstrMsg,vstrPara){

		var vntArray=vstrPara.split('$');
		for(var i=0;i<vntArray.length;i++){
		    var strRepl ='{'+ i +'}' ;
			var intPos = vstrMsg.indexOf(strRepl);
			if(intPos!=-1){
				vstrMsg = vstrMsg.replace(strRepl, vntArray[i]);
			}
		}
		return vstrMsg
}

//ShowMessage(strCode,vstrPara)
//strCode 消息代號
//vstrPara 帶入消息中的字串參數
//ShowMessage('E0001','def$abc') 
//strCode為E0001時得" Save error！Table:{0}{1} ",vstrPara為"def$abc"
//會將{0}用def替換掉.{1}用abc替換掉
var v_Lang ="en";
function ShowMessage(strCode,vstrPara)
{
    if (__mLanguage != null && __mLanguage !="")
    {
        v_Lang = __mLanguage;
    }
  var strOut='XML fail!';

  var url = window.location.href;
  url = document.location.protocol + "//" + document.location.host + '/Data/Message.xml';   
  var objxmlDoc = LoadXml(url);
  if (objxmlDoc == null) 
  {
        if (document.location.pathname.indexOf('/') == 0) {
            url = document.location.protocol + "//" + document.location.host + "/" + document.location.pathname.split("/")[1] + '/Data/Message.xml';
        }
        else {
            url = document.location.protocol + "//" + document.location.host + "/" + document.location.pathname.split("/")[0] + '/Data/Message.xml';
        }    
        objxmlDoc = LoadXml(url); 
 }
  if(typeof(objxmlDoc)=='object')
   {
       try {
           if (document.documentMode == 10) {
                var objNode = objxmlDoc.selectSingleNode("MessageSettingConfig/MessageContent[MsgID='" + strCode + "']/" + v_Lang);
           }
           else
               var objNode = objxmlDoc.selectSingleNode("//MessageContent[MsgID='" + strCode + "']/" + v_Lang);
           strOut=ReplMsgDesc(objNode.text,vstrPara);
       }
    catch(e)
         { strOut = '沒找到對應消息ID{' + strCode + '}!\n請參見' + url; }
    }
 
 return strOut;
}
//讀取XML擋
function LoadXml(vstrReq){
    return xmlhttpTest(vstrReq)
}

function PostXML(vstrURL,vstrXML)
{    
    var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    xmlhttp.Open("POST", vstrURL, false);
    xmlhttp.setRequestHeader("Content-Type", "text/xml");
    xmlhttp.Send(vstrXML);
    if(xmlhttp.responseXML.xml!=""){
		var objDoc = new ActiveXObject("Microsoft.XMLDOM");
		objDoc.async = false;
		objDoc.loadXML(xmlhttp.responseXML.xml);
		return objDoc;
    }
}


function xmlhttpTest(url)
{      
  //判斷別是否支持標準XMLHttpRequest對象.  
  if (window.XMLHttpRequest)
     {
       var oXmlHttp = new XMLHttpRequest();
       }else{
                       //'Microsoft.XMLHTTP' 放在最前面以兼容ie6.
            var MSXML = ['Microsoft.XMLHTTP', 'MSXML2.XMLHTTP.5.0', 'MSXML2.XMLHTTP.4.0', 'MSXML2.XMLHTTP.3.0', 'MSXML2.XMLHTTP'];
            for(var n=0; n<MSXML.length; n++)
               {
                try{
                    var oXmlHttp = new ActiveXObject(MSXML[n]);
                    break;
                   }catch(e){}
               }    
     }
	try {
        oXmlHttp.open( "GET", url, false ) ;
        if (document.documentMode == 10) {
            try {
                xmlHttp.responseType("msxml-document");
            } catch (e) {
            }
        }
        else
            oXmlHttp.setRequestHeader("Content-Type", "text/xml");

        oXmlHttp.send(null) ;
        if(oXmlHttp.status==200)
        {oXmlHttp.responseXML ;
       }else{
         return null;
       }
        return oXmlHttp.responseXML ;
		} catch (e) {
  		return null;
		}
}


/**
 * 非IE浏览器兼容selectNodes
 */
//if(!isIE) {
	try{
		var ex;
		XMLDocument.prototype.__proto__.__defineGetter__("xml", function(){
			try {
				return new XMLSerializer().serializeToString(this);
			} catch (ex) {
				var d = document.createElement("div");
				d.appendChild(this.cloneNode(true));
				return d.innerHTML;
			}
		});
		Element.prototype.__proto__.__defineGetter__("xml", function(){
			try {
				return new XMLSerializer().serializeToString(this);
			} catch (ex) {
				var d = document.createElement("div");
				d.appendChild(this.cloneNode(true));
				return d.innerHTML;
			}
		});
		XMLDocument.prototype.__proto__.__defineGetter__("text", function(){
			return this.firstChild.textContent
		});
		Element.prototype.__proto__.__defineGetter__("text", function(){
			return this.textContent
		});
	
		if (document.implementation && document.implementation.createDocument) {
			XMLDocument.prototype.loadXML = function(xmlString){
				try {
					var childNodes = this.childNodes;
					for (var i = childNodes.length - 1; i >= 0; i--)
						this.removeChild(childNodes[i]);
	
					var dp = new DOMParser();
					var newDOM = dp.parseFromString(xmlString, "text/xml");
					var newElt = this.importNode(newDOM.documentElement, true);
					this.appendChild(newElt);
					return true;
				} catch (ex) {
					return false;
				}
			};
	
			// check for XPath implementation
			if (document.implementation.hasFeature("XPath", "3.0")) {
				// prototying the XMLDocument
				XMLDocument.prototype.selectNodes = function(cXPathString, xNode){
					if (!xNode) {
						xNode = this;
					}
					var oNSResolver = this.createNSResolver(this.documentElement)
					var aItems = this.evaluate(cXPathString, xNode, oNSResolver, XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null)
					var aResult = [];
					for (var i = 0; i < aItems.snapshotLength; i++) {
						aResult[i] = aItems.snapshotItem(i);
					}
					return aResult;
				}
	
				// prototying the Element
				Element.prototype.selectNodes = function(cXPathString){
					if (this.ownerDocument.selectNodes) {
						return this.ownerDocument.selectNodes(cXPathString, this);
					} else {
						throw "For XML Elements Only";
					}
				}
			}
	
			// check for XPath implementation
			if (document.implementation.hasFeature("XPath", "3.0")) {
				// prototying the XMLDocument
				XMLDocument.prototype.selectSingleNode = function(cXPathString, xNode){
					if (!xNode) {
						xNode = this;
					}
					var xItems = this.selectNodes(cXPathString, xNode);
					if (xItems.length > 0) {
						return xItems[0];
					} else {
						return null;
					}
				}
	
				// prototying the Element
				Element.prototype.selectSingleNode = function(cXPathString){
					if (this.ownerDocument.selectSingleNode) {
						return this.ownerDocument.selectSingleNode(cXPathString, this);
					} else {
						throw "For XML Elements Only";
					}
				}
			}
		}
	}catch(ex) {}
