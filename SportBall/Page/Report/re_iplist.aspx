<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_iplist.aspx.cs" Inherits="re_iplist" %>

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

    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">报表管理</a>  <span
            class="divider">/</span>登入IP统计
    </ul>
    <div class="title_right">
        <strong>登入IP统计</strong>
    </div>
    <div style="width: 90%; margin: auto">


        <table class="table" style="width: 100%">
            <tr>
                <td class="trc">總公司
                </td>
            </tr>
        </table>
        <br />

        <cc1:JXGrid ID="Gridgs" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnDataBound="Gridgs_DataBound">
            <Columns>
                <asp:BoundField HeaderText="帳號" DataField="n_hyzh" />
                <asp:BoundField HeaderText="等級" DataField="n_hydj" />
                <asp:BoundField HeaderText="大總監" />
                <asp:BoundField HeaderText="總監" />
                <asp:BoundField HeaderText="大股東" />
                <asp:BoundField HeaderText="股東" />
                <asp:BoundField HeaderText="總代理" />
                <asp:BoundField HeaderText="代理商" />
                <asp:BoundField HeaderText="登入IP" DataField="n_hyip" />
                <asp:BoundField HeaderText="成功次數" DataField="n_cgcs" />
                <asp:BoundField HeaderText="失敗次數" DataField="n_spcs" />
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>

        <table style="width: 100%">
            <tr>
                <td class="trc">會員明細 
                    
                </td>
            </tr>
            <tr>
                <td>
                    <cc1:JXGrid ID="Gridhy" runat="server" AutoGenerateColumns="False" CssClass="grid"
                        ShowFooter="false" AllowPaging="false" Width="100%"
                        GridViewSortDirection="Ascending" OnDataBound="Gridhy_DataBound">
                        <Columns>
                             <asp:BoundField HeaderText="帳號" DataField="n_hyzh" />
                            <asp:BoundField HeaderText="等級" DataField="n_hydj" />
                            <asp:BoundField HeaderText="大總監" />
                            <asp:BoundField HeaderText="總監" />
                            <asp:BoundField HeaderText="大股東" />
                            <asp:BoundField HeaderText="股東" />
                            <asp:BoundField HeaderText="總代理" />
                            <asp:BoundField HeaderText="代理商" />
                            <asp:BoundField HeaderText="登入IP" DataField="n_hyip" />
                            <asp:BoundField HeaderText="成功次數" DataField="n_cgcs" />
                            <asp:BoundField HeaderText="失敗次數" DataField="n_spcs" />
                        </Columns>
                        <PagerStyle CssClass="Row1" />
                        <SelectedRowStyle CssClass="RowSel" />
                        <AlternatingRowStyle CssClass="Row2" />
                        <HeaderStyle CssClass="FixedTitleRow" />
                        <RowStyle Wrap="false" />
                    </cc1:JXGrid>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
