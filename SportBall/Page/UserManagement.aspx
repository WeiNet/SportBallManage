<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="UserManagement" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <script src="UserManagement.js" type="text/javascript"></script>
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">超级用户</a>  <span
            class="divider">/</span>超级用户管理
    </ul>
    <div class="title_right">
        <strong>超级用户管理</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="button" OnClick="btnAdd_Click"  OnClientClick="return checkAdd();" />
                    <asp:Button ID="btnCancel" runat="server" Text="取 消" CssClass="button" OnClick="btnCancel_Click" OnClientClick="return clearTxt();"/>
                    
                </td>
            </tr>
        </table>
        <table class="table">
            <tr>
                <td class="trr" style="width: 25%">新用戶</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
                <td class="trr" style="width: 25%">新名稱</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="trr" style="width: 25%">新密碼</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="textPassWord" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox></td>
                <td class="trr" style="width: 25%">確認密碼</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="textPassWordRepeat" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="trr" style="width: 25%">用户类型</td>
                <td class="trl" style="width: 25%" colspan="3">
                    <asp:DropDownList ID="dropType" runat="server">
                        <asp:ListItem Value="0">超级用户</asp:ListItem>
                        <asp:ListItem Value="1">管理员</asp:ListItem>
                    </asp:DropDownList></td>

            </tr>

        </table>
        <cc1:JXGrid ID="grvUser" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="true" Width="100%"
            GridViewSortDirection="Ascending" OnRowCancelingEdit="grvUser_RowCancelingEdit" OnRowDataBound="grvUser_RowDataBound" OnRowDeleting="grvUser_RowDeleting" OnRowEditing="grvUser_RowEditing" OnRowUpdating="grvUser_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="用戶名" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblName" runat="server" Text='<%# Eval("n_hyzh") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="grvhidNO" runat="server" />
                        <asp:TextBox ID="grvtxtName" runat="server" Width="100%" MaxLength="200" ReadOnly="true"></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密碼" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblPassword" runat="server" Text='<%# Eval("n_hymm") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvtxtPassword" runat="server" Width="100%" MaxLength="200"></asp:TextBox>

                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="名稱" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblName_CN" runat="server" Text='<%# Eval("n_hymc") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvltxtName_CN" runat="server" Width="100%" MaxLength="200"></asp:TextBox>

                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="類別" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvllblType" runat="server" Text='<%# Eval("n_hydj") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="grvdrpType" runat="server">
                            <asp:ListItem Value="0" >超级用户</asp:ListItem>
                            <asp:ListItem Value="1">系统管理员</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="5%">

                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>操作</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" ToolTip="修改"
                            ImageUrl="~/Images/icon_edit.gif" />
                        <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" ToolTip="删除"
                            ImageUrl="~/Images/icon_del.gif" />

                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:ImageButton ID="grvibtnUpdate" runat="server" ToolTip="更新"
                            CommandName="Update" ImageUrl="~/Images/icon_save.gif"></asp:ImageButton>
                        <asp:ImageButton ID="grvibtnCancel" runat="server" ToolTip="取消"
                            CommandName="Cancel" ImageUrl="~/Images/icon_cal.gif"></asp:ImageButton>
                    </EditItemTemplate>
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
