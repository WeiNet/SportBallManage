<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="Welcome" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">

    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">系统设置</a>  <span
            class="divider">/</span> 每日过账
    </ul>
    <div class="title_right">
        <strong>每日过账</strong>
    </div>
    <div style="width:90%; margin: auto">
        <cc1:JXGrid ID="gridGZ" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="true" Width="100%" OnDataBound="gridGZ_DataBound"
            GridViewSortDirection="Ascending" >
            <Columns>
                <asp:BoundField HeaderText="账务日期" DataField="zwrq" />
                <asp:BoundField HeaderText="注单信息" />
                <asp:BoundField HeaderText="过关" />
                <asp:BoundField HeaderText="尚未计算的注单" />
                <asp:BoundField HeaderText="操作" />
                <asp:TemplateField HeaderText="lbcounts" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbcounts" runat="server" Text='<%#Bind("counts")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="type" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbTYPE" runat="server" Text='<%#Bind("TYPE")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="zwrq" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbzwrq" runat="server" Text='<%#Bind("zwrq")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>
        <table class="table">
            <tr>
                <td align="center">历史过账记录</td>
            </tr>
        </table>
        <cc1:JXGrid ID="gridHisData" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="true" Width="100%">
            <Columns>
                <asp:BoundField HeaderText="账务日期" DataField="n_zwrq" />
                <asp:BoundField HeaderText="过账时间" DataField="n_gzsj" />
                <asp:BoundField HeaderText="过账人员" DataField="N_XGZH" />
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>

    </div>

</asp:Content>
