<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_Quick.aspx.cs" Inherits="re_Quick" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="report.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            border: 1px solid #96d0e5;
            vertical-align: middle;
            width: 90%;
        }

        table td {
            word-break: keep-all;
            white-space: nowrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <asp:HiddenField ID="delyy" Value="" runat="server" />
    <asp:HiddenField ID="hidtime" runat="server" />
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">报表管理</a>  <span
            class="divider">/</span>即時注單
    </ul>
    <div class="title_right">
        <strong>即時注單</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">
            <tr>
                <td class="trr" style="width: 10%">比賽類型</td>
                <td class="trl">
                    <input id="chAll" name="chAll" type="checkbox" runat="server" onclick="selectCheckAll(this);" /><span id="lblAll" runat="server">全部</span>
                    <input id="chbk" name="chbk" type="checkbox" runat="server" /><span id="lblbk" runat="server">籃球</span>
                    <input id="chbj" name="chbj" type="checkbox" runat="server" /><span id="lblbj" runat="server">棒球</span>
                    <input id="chby" name="chby" type="checkbox" runat="server" /><span id="lblby" runat="server">网球</span>
                    <input id="chbb" name="chbb" type="checkbox" runat="server" /><span id="lblbb" runat="server">排球</span>
                    <input id="chzq" name="chzq" type="checkbox" runat="server" /><span id="lblzq" runat="server">足球</span>
                    <input id="chbq" name="chbq" type="checkbox" runat="server" /><span id="lblbq" runat="server">冰球</span>
                    <div style="display: none">
                        <input id="chbf" name="chbf" type="checkbox" runat="server" /><span id="lblbf" runat="server">美球</span>
                        <input id="chcq" name="chcq" type="checkbox" runat="server" /><span id="lblcq" runat="server">彩球</span>
                        <input id="chzs" name="chzs" type="checkbox" runat="server" /><span id="lblzs" runat="server">指數</span>
                        <input id="chsm" name="chsm" type="checkbox" runat="server" /><span id="lblsm" runat="server">賽馬</span>
                        <input id="chlhc" type="checkbox" runat="server" />六合彩
                    <input id="chdlt" type="checkbox" runat="server" />大樂透
                    <input id="chjc" type="checkbox" runat="server" />今彩539
                    <input id="chcp" name="chcp" type="checkbox" runat="server" /><span id="lblcp" runat="server">運動彩票</span>
                        <input id="chss" name="chss" type="checkbox" runat="server" /><span id="lblss" runat="server">時事</span>
                    </div>
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <input type="button" id="btstart" onclick="SetTimeQuick('6'); return false;" value="開始" class="button" />
                    <input type="button" id="btstop" onclick="Btstop(); return false;" value="停止" class="button" />
                    <input type="button" id="btClear" onclick="TbClear(); return false;" value="清空" class="button" />
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="1" id="tabzd" cellspacing="1"
            class="table">
            <tr>
                <td colspan="6">注單明細
                    <asp:Label ID="lbtime" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="title">下注時間</td>
                <td align="center" class="title">單號
                </td>
                <td align="center" class="title">下注會員
                </td>
                <td align="center" class="title">投注內容</td>
                <td width="20%" align="center" class="title">投注金額
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
