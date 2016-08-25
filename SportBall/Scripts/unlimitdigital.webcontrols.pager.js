// JScript 檔
/*
備註：

頁面調用是需要引入：
jquery.js
jquery.tmpl.min.js

var pagerSoure = {'pageIndex':'0','pageSize':'30','recordCount':'180'};
var pager = new UnlimitDigital.Webcontrols.Pager(pagerSoure,'containerId','templateId');
pager.callBack(asnyloadc);
pager.dataBind();

數據源格式：pagerSoure:{'pageIndex':'0','pageSize':'30','recordCount':'180'};分別是pageIndex：當前頁從0開始 pageSize：每頁顯示筆數 recordCount總筆數

containerId：容器ID

templateId：模板ID
*/
/// <summary>
/// 实例化命名空间
/// </summary>
if(typeof(UnlimitDigital) == 'undefined') {
    UnlimitDigital = new Object();    
    if (typeof(UnlimitDigital.Webcontrols) == 'undefined') {
        UnlimitDigital.Webcontrols = new Object();
    }
}

/// <summary>
/// 實例化類
/// </summary>
UnlimitDigital.Webcontrols.Pager = function UnlimitDigital$Webcontrols$Pager(pagerSoure, containerId, templateId) {
    if (pagerSoure != null) {
        this.isExist = false; //是否對容器進行綁定
        this.pageSoure = pagerSoure;
        this.pageIndex = pagerSoure.pageIndex;
        this.pageSize = pagerSoure.pageSize; 
        this.recordCount = pagerSoure.recordCount;
        this.set_PageCount();
        this.containerId = containerId;
        this.templateId = templateId;
    }
}

/// <summary>
/// 頁腳控件屬性/方法
/// </summary>
UnlimitDigital.Webcontrols.Pager.prototype = {
    //數據獲取方法
    get_PageIndex : UnlimitDigital$Webcontrols$Pager$_getPageIndex,//當前頁
    get_PageSize : UnlimitDigital$Webcontrols$Pager$_getPageSize,//每頁顯示筆數
    get_RecordCount : UnlimitDigital$Webcontrols$Pager$_getRecordCount,//總筆數
    get_PageCount : UnlimitDigital$Webcontrols$Pager$_getPageCount,//總頁數
    get_PagerSoure : UnlimitDigital$Webcontrols$Pager$_getPagerSoure,//數據源
    get_ContainerId : UnlimitDigital$Webcontrols$Pager$_getContainerId,//容器Id
    get_TemplateId : UnlimitDigital$Webcontrols$Pager$_getTemplateId,//模板Id
    //數據設置方法
    set_PageIndex : UnlimitDigital$Webcontrols$Pager$_setPageIndex,
    set_PageSize : UnlimitDigital$Webcontrols$Pager$_setPageSize,
    set_RecordCount : UnlimitDigital$Webcontrols$Pager$_setRecordCount,
    set_PageCount : UnlimitDigital$Webcontrols$Pager$_setPageCount,
    set_PagerSoure : UnlimitDigital$Webcontrols$Pager$_setPagerSoure,
    set_ContainerId : UnlimitDigital$Webcontrols$Pager$_setContainerId,
    set_TemplateId : UnlimitDigital$Webcontrols$Pager$_setTemplateId,
    //公開事件
    dataBind:UnlimitDigital$Webcontrols$Pager$_DataBind,
    callBack:UnlimitDigital$Webcontrols$Pager$_CallBack,
    //私有事件
    _controlDis:UnlimitDigital$Webcontrols$Pager$_ControlDis,
    _pageIndexChange:UnlimitDigital$Webcontrols$Pager$_PageIndexChange,
    _validateInfo:UnlimitDigital$Webcontrols$Pager$_ValidateInfo

};

/// <summary>
/// 獲取當前索引[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_getPageIndex() {
	return this.pageIndex;
}
/// <summary>
/// 獲取每頁可容數據筆數[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_getPageSize() {
    return this.pageSize;
}
/// <summary>
/// 獲取總數據筆數[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_getRecordCount() {
	return this.recordCount;
}
/// <summary>
/// 獲取總頁數[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_getPageCount() {
    return this.pageCount;
}
/// <summary>
/// 獲取數據源[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_getPagerSoure() {
	return this.pageSoure;
}
/// <summary>
/// 獲取容器ID[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_getContainerId() {
	return this.containerId;
}
/// <summary>
/// 獲取模块ID[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_getTemplateId() {
	return this.templateId;
}


/// <summary>
/// 設置當前索引[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_setPageIndex(pageIndex) {
    this.pageIndex = pageIndex;
}
/// <summary>
/// 設置獲取每頁可容數據筆數[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_setPageSize(pageSize) {
    this.pageSize = pageSize;
}
/// <summary>
/// 設置總數據筆數[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_setRecordCount(recordCount) {
    this.recordCount = recordCount;
}
/// <summary>
/// 設置總頁數[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_setPageCount() {
    this.pageCount = Math.ceil(this.recordCount / this.pageSize);
    if (this.recordCount == 0) {
        this.pageCount = 1;
    }
    if (this.pageIndex > this.pageCount) {
        this.pageIndex = this.pageCount;
    }
}
/// <summary>
/// 設置數據源[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_setPagerSoure(pagerSoure) {
	this.pageSoure = pagerSoure;
	if(pagerSoure != null){
	    this.set_PageIndex(pagerSoure.pageIndex);
        this.set_PageSize(pagerSoure.pageSize);
        this.set_RecordCount(pagerSoure.recordCount);
        this.set_PageCount();
    }
}
/// <summary>
/// 設置容器ID[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_setContainerId(containerId) {
    this.containerId = containerId;
}
/// <summary>
/// 設置模块ID[屬性]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_setTemplateId(templateId) {
    this.templateId = templateId;
}

/// <summary>
/// 計算並呈現相關效果[方法]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_DataBind(){
	//綁定頁腳
	if(!this.isExist) {
	    if (this.get_PagerSoure() != null) {
	        this.get_PagerSoure().pageCount = this.get_PageCount();
	        this.get_PagerSoure().pageIndex = this.get_PagerSoure().pageIndex;
	        $("#" + this.get_TemplateId()).tmpl(this.get_PagerSoure()).appendTo("#" + this.get_ContainerId());
	        this.isExist = true;
	        //處理頁腳邏輯[判斷是否綁定成功]
	        if (typeof (this.pageSoure) != "undefined") {
	            var pager = this;
	            this._controlDis();
	            var option = "";
                for(i=1;i<=this.get_PageCount();i++)
                {
                    option += "<option value=" + i + ">" + i + "</option>";
                }
                $("#drpPage").append(option); 
	            //分页下拉框事件綁定
	            $("#" + this.get_ContainerId()).find("#drpPage").bind("change", function () {
	                //索引輸入錯誤,提示出錯
	                if (!pager._validateInfo($("#drpPage").val())) {
	                    alert(GlobalResx.formatmessage);
	                    //this.focus();
	                }
	                else if ($("#drpPage").val() > parseInt(pager.get_PageCount())) {
	                    alert(GlobalResx.indexmessage);
	                    //this.focus();
	                }
	                else {
	                    if (parseInt($("#drpPage").val()) == pager.get_PageIndex()) { return false; }
	                    pager.set_PageIndex($("#drpPage").val());
	                    pager._pageIndexChange(pager);
	                } return false;
	            });
	            
	            //按鈕事件綁定
	            $("#" + this.get_ContainerId()).find("#go").bind("click", function () {
	                //用戶輸入數字
	                var txtPageNum = $("#" + pager.get_ContainerId()).find("input[type='text']").eq(0);
	                //索引輸入錯誤,提示出錯
	                if (!pager._validateInfo(txtPageNum.val())) {
	                    alert(GlobalResx.formatmessage);
	                    txtPageNum.focus();
	                }
	                else if (txtPageNum.val() > parseInt(pager.get_PageCount())) {
	                    alert(GlobalResx.indexmessage);
	                    txtPageNum.focus();
	                }
	                else {
	                    if (parseInt(txtPageNum.val()) == pager.get_PageIndex()) { return false; }
	                    pager.set_PageIndex(txtPageNum.val());
	                    pager._pageIndexChange(pager);
	                } return false;
	            });
	            $("#" + this.get_ContainerId()).find("#prev").bind("click", function () {
	                if (!$(this).attr('disabled')) {
	                    pager.set_PageIndex((parseInt(pager.pageIndex) - 1));
	                    pager._pageIndexChange(pager);
	                } return false;
	            });
	            $("#" + this.get_ContainerId()).find("#next").bind("click", function () {
	                if (!$(this).attr('disabled')) {
	                    pager.set_PageIndex((parseInt(pager.pageIndex) + 1));
	                    pager._pageIndexChange(pager);
	                } return false;
	            });
	            $(document).keydown(function (e) {
	                if (e.keyCode == 13) {
	                    $("#" + pager.get_ContainerId()).find("#go").click();
	                }
	                if (e.keyCode == 37) {
	                    $("#" + pager.get_ContainerId()).find("#prev").click();
	                }
	                if (e.keyCode == 39) {
	                    $("#" + pager.get_ContainerId()).find("#next").click();
	                }
	            });
	        }
	    }
	}else{
	    this._controlDis();
	    $("#"+this.get_ContainerId()).find("span[id='pageIndex']").eq(0).html(this.get_PageIndex());
	    $("#" + this.get_ContainerId()).find("input[type='text']").eq(0).val(this.get_PageIndex());
	    $("#"+this.get_ContainerId()).find("span[id='pageCount']").eq(0).html(this.get_PageCount());
        var option = "";
        var pageValue = $("#drpPage").val();
        for(i=1;i<=this.get_PageCount();i++)
        {
            option += "<option value=" + i + ">" + i + "</option>";
        }
        $("#drpPage").html('');
        $("#drpPage").html(option);
        $("#drpPage").val(pageValue);
	}
}
/// <summary>
/// 控制分頁按鈕[私有方法]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_ControlDis(){
    //當前索引為第一頁則不可以上一頁,禁用上一頁
    if(parseInt(this.get_PageIndex()) == 1){
        $("#" + this.get_ContainerId()).find("#prev").attr('disabled', 'disabled');
    }else{
        $("#"+this.get_ContainerId()).find("#prev").attr('disabled','');
    }
    //當前索引為最後一頁則不可以繼續下一頁,禁用下一頁
    if(parseInt(this.get_PageIndex()) == parseInt(this.get_PageCount())){
       $("#"+this.get_ContainerId()).find("#next").attr('disabled','disabled');
    }else{
        $("#"+this.get_ContainerId()).find("#next").attr('disabled','');
    }
}
/// <summary>
/// 翻頁事件，提供翻頁新的頁面索引[私有方法]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_PageIndexChange(pager){
    this.callbackFunc(pager,this.pageIndex);
}
/// <summary>
/// 验证頁面索引合法性[私有方法]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_ValidateInfo(str){
    //如果为空，返回false
    if(str == ""||typeof(str) == "undefined")
    {
        return false;
    }    
    var r = /^\+?[1-9][0-9]*$/;//正整数 
    if(!r.test(str)) 
    {
        return false;
    }
    else
    {
        return true;
    }
}
/// <summary>
/// 設定用戶自定義回調方法[公開方法]
/// </summary>
function UnlimitDigital$Webcontrols$Pager$_CallBack(func) {
    this.callbackFunc = func;
}