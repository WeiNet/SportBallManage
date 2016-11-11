<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_zdqr.aspx.cs" Inherits="re_zdqr" %>

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
            class="divider">/</span>走地注单
    </ul>
    <div class="title_right">
        <strong>走地注单</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">
            <tr>
                <td class="trr" style="width: 10%">比賽類型</td>
                <td class="trl">
                    <input id="chAll" type="checkbox" onclick="seleAll(this);" />全部
                    <input id="chbk" type="checkbox" />籃球
                    <input id="chbj" type="checkbox" />棒球
                    <input id="chby" type="checkbox" />网球
                    <input id="chbb" type="checkbox" />排球
                    <input id="chzq" type="checkbox" />足球
                    <input id="chbf" type="checkbox" style="display: none" />
                    <input id="chbq" type="checkbox" />冰球
                    <input id="chcq" type="checkbox" style="display: none" />
                    <input id="chzs" type="checkbox" style="display: none" />
                    <input id="chsm" type="checkbox" style="display: none" />
                    <input id="chlhc" type="checkbox" style="display: none" />
                    <input id="chdlt" type="checkbox" style="display: none" />
                    <input id="chjc" type="checkbox" style="display: none" />
                    <input id="chcp" type="checkbox" style="display: none" />
                    <input id="chss" type="checkbox" style="display: none" />
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <input type="button" id="btstart" onclick="SetTimeQuick('5'); return false;" value="開始" class="button" />
                    <input type="button" id="btstop" onclick="Btstop(); return false;" value="停止" class="button" />
                    <input type="button" id="btClear" onclick="TbClear(); return false;" value="清空" class="button" />
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="1" id="tabzd" cellspacing="1"
            class="table">
            <tr>
                <td colspan="6">注單明細
                    <asp:Label ID="lbtime" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="title">下注時間
                </td>
                <td align="center" class="title">單號
                </td>
                <td align="center" class="title">下注會員
                </td>
                <td align="center" class="title">投注內容
                </td>
                <td align="center" class="title">投注金額
                </td>
                <td align="center" class="title">操作
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
