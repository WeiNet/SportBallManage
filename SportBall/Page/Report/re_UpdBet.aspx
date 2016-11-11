<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_UpdBet.aspx.cs" Inherits="re_UpdBet" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="report.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
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
    <script type="text/javascript">

        var __mLanguage = 'zh-cn';

        //日曆控件
        $(function () {

            $("#ContentPlaceHolder11_txtkjsj,#ContentPlaceHolder11_txtjssj").datepicker({
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <asp:HiddenField ID="delyy" Value="" runat="server" />
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">报表管理</a>  <span
            class="divider">/</span>异动注单
    </ul>
    <div class="title_right">
        <strong>异动注单</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">

            <tr>
                <td class="trr">修改日期:</td>
                <td class="trl">
                    <asp:TextBox ID="txtkjsj" runat="server" size="10"></asp:TextBox>
                    <asp:TextBox ID="txtjssj" runat="server" size="10"></asp:TextBox>
                    <asp:Button ID="btcx" runat="server" Text="查詢" OnClick="btcx_Click" CssClass="button" />
                </td>
            </tr>
        </table>
        <br />

        <cc1:JXGrid ID="JXGrid1" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending">
            <Columns>
                <asp:BoundField HeaderText="下注单号" DataField="N_XZDH"></asp:BoundField>
                <asp:BoundField HeaderText="下注时间" DataField="N_XZRQ"></asp:BoundField>
                <asp:BoundField HeaderText="原内容" DataField="N_OLDNR" HtmlEncode="False"></asp:BoundField>
                <asp:BoundField HeaderText="现内容" DataField="N_XZNR" HtmlEncode="False"></asp:BoundField>
                <asp:BoundField HeaderText="原赔率" DataField="N_OLDPL"></asp:BoundField>
                <asp:BoundField HeaderText="现赔率" DataField="N_PL"></asp:BoundField>
                <asp:BoundField HeaderText="会员代号" DataField="N_HYDH"></asp:BoundField>
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>

    </div>
</asp:Content>
