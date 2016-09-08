<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="IpManagement.aspx.cs" Inherits="IpManagement" %>
<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <script src="IpManagement.js"  type="text/javascript"></script>
     <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">超级用户</a>  <span
            class="divider">/</span>IP管理
    </ul>
    <div class="title_right">
        <strong>IP管理</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="button"   OnClientClick="return checkAdd();" OnClick="btnAdd_Click" />  
                </td>
            </tr>
        </table>
        <table class="table">
            <tr>
                <td class="trr" style="width: 25%">IP  <span style="color: #ff0000">*</span></td>
                <td class="trl" style="width: 75%">
                    <asp:TextBox ID="txtIP" runat="server"></asp:TextBox></td>
                
            </tr>  
        </table>
        <cc1:JXGrid ID="grvip" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnRowDeleting="grvip_RowDeleting" OnRowDataBound="grvip_RowDataBound">
            <Columns>
                  <asp:BoundField DataField="IP" HeaderText="IP">
                            <ItemStyle Width="95%" HorizontalAlign="Center" />
                        </asp:BoundField>

                <asp:TemplateField ItemStyle-Width="5%">

                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>操作</HeaderTemplate>
                    <ItemTemplate> 
                        <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" ToolTip="删除"
                            ImageUrl="~/Images/icon_del.gif" />

                    </ItemTemplate>  
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>
        　
    </div>
</asp:Content>
