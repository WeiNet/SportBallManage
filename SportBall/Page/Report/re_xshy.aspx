<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="re_xshy.aspx.cs" Inherits="re_xshy" %>

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
            class="divider">/</span>線上會員
    </ul>
    <div class="title_right">
        <strong>線上會員</strong>
    </div>
    <div style="width: 90%; margin: auto">


        <table class="table" style="width: 100%">
            <tr>
                <td class="trr" width="10%">
                    <asp:Label ID="lbhy" runat="server" Text="會員帳號"></asp:Label>：</td>
                <td class="trl">
                    <asp:TextBox ID="txthyzh" runat="server"></asp:TextBox></td>


            </tr>
            <tr>
                <td class="trr" width="80">
                    <asp:Label ID="lbip" runat="server" Text="會員IP"></asp:Label>：</td>
                <td class="trl">
                    <asp:TextBox ID="txtip" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="trl" colspan="2">
                    <asp:Button ID="btcx" runat="server" Text="查詢" OnClick="btcx_Click" CssClass="button" /></td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <cc1:JXGrid ID="JXGrid2" runat="server" AutoGenerateColumns="False" CssClass="grid"
                ShowFooter="false" AllowPaging="false" Width="100%"
                GridViewSortDirection="Ascending">
                <Columns>
                    <asp:BoundField HeaderText="操盤手人数" DataField="cp">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="報表查詢員" DataField="cx">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="大總監人数" DataField="dzj">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="總監人数" DataField="zj">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="大股東人数" DataField="dgd">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="股東人数" DataField="gd">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="總代理人数" DataField="zdl">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="代理商人数" DataField="dl">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="會員人数" DataField="hy">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle CssClass="Row1" />
                <SelectedRowStyle CssClass="RowSel" />
                <AlternatingRowStyle CssClass="Row2" />
                <HeaderStyle CssClass="FixedTitleRow" />
                <RowStyle Wrap="false" />
            </cc1:JXGrid>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Width="100%">
            <table style="width: 100%">
                <tr>
                    <td class="trc">會員明細 
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <cc1:JXGrid ID="JXGrid1" runat="server" AutoGenerateColumns="False" CssClass="grid"
                            ShowFooter="false" AllowPaging="false" Width="100%"
                            GridViewSortDirection="Ascending" OnDataBound="JXGrid1_DataBound" >
                            <Columns>
                                <asp:BoundField HeaderText="會員帳號" DataField="n_hyzh" SortExpression="n_hyzh">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="會員等級" DataField="n_hydj">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="操盤手 ">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="大總監">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="總監">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="大股東">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="股東">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="總代理">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="代理商">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="登入IP" DataField="n_hyip" SortExpression="n_hyip">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="登入時間" DataField="n_dlsj" SortExpression="n_dlsj" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" HtmlEncode="False">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
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
        </asp:Panel>
    </div>
</asp:Content>
