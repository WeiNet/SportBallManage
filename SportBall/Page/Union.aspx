<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="Union.aspx.cs" Inherits="Union" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <script src="Union.js" type="text/javascript"></script>
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">系统设置</a>  <span
            class="divider">/</span>联盟管理
    </ul>
    <div class="title_right">
        <strong>
            <asp:Label ID="lblball" runat="server" Text=""></asp:Label>聯盟管理</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="新增聯盟" CssClass="button" OnClick="btnAdd_Click" OnClientClick="return checkLM();" />

                </td>
            </tr>
        </table>
        <table class="table">
            <tr>
                <td class="trr" style="width: 25%">聯盟名稱</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                <td class="trr" style="width: 25%">聯盟名稱(英文)</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtName_EN" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="trr" style="width: 25%">聯盟名稱(簡體)</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtName_CN" runat="server"></asp:TextBox></td>
                <td class="trr" style="width: 25%">聯盟名稱(繁體)</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtName_TW" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="trr" style="width: 25%">聯盟名稱(泰文)</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtName_TH" runat="server"></asp:TextBox></td>
                <td class="trr" style="width: 25%">序號</td>
                <td class="trl" style="width: 25%">
                    <asp:TextBox ID="txtNo" runat="server" onblur="onlyInt(this);"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="trr" style="width: 25%">等级</td>
                <td class="trl" style="width: 25%" colspan="3">
                    <asp:DropDownList ID="drpLevel" runat="server">
                        <asp:ListItem Value="1" Selected="True">1级</asp:ListItem>
                        <asp:ListItem Value="2">2级</asp:ListItem>
                        <asp:ListItem Value="3">3级</asp:ListItem>
                        <asp:ListItem Value="4">4级</asp:ListItem>
                        <asp:ListItem Value="5">5级</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>
        </table>
        <cc1:JXGrid ID="grvUnion" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="true" Width="100%"
            GridViewSortDirection="Ascending" OnRowCancelingEdit="grvUnion_RowCancelingEdit" OnRowDataBound="grvUnion_RowDataBound" OnRowEditing="grvUnion_RowEditing" OnRowUpdating="grvUnion_RowUpdating" OnRowDeleting="grvUnion_RowDeleting">
            <Columns>
                <asp:BoundField DataField="n_lx" HeaderText="類型" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="聯盟名稱" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblName" runat="server" Text='<%# Eval("n_lmmc") %>'></asp:Label>
                        <asp:HiddenField ID="grvhidN_NO" runat="server" Value='<%# Eval("N_NO") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="grvhidNO" runat="server" />
                        <asp:TextBox ID="grvtxtName" runat="server" Width="100%" MaxLength="200"></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="聯盟名稱(英文)" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblName_EN" runat="server" Text='<%# Eval("n_lmmc_en") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvtxtName_EN" runat="server" Width="100%" MaxLength="200"></asp:TextBox>

                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="聯盟名稱(簡體)" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblName_CN" runat="server" Text='<%# Eval("n_lmmc_cn") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvltxtName_CN" runat="server" Width="100%" MaxLength="200"></asp:TextBox>

                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="聯盟名稱(繁體)" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvllblName_TW" runat="server" Text='<%# Eval("n_lmmc_tw") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvltxtName_TW" runat="server" Width="100%" MaxLength="200"></asp:TextBox>

                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="聯盟名稱(泰文)" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvllblName_TH" runat="server" Text='<%# Eval("n_lmmc_th") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvltxtName_TH" runat="server" Width="100%" MaxLength="200"></asp:TextBox>

                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="序號" ItemStyle-Width="5%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvllblNO" runat="server" Text='<%# Eval("n_xh") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvltxtNO" runat="server" Width="100%" MaxLength="200"></asp:TextBox>

                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="等级" ItemStyle-Width="10%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvllblLevel" runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="grvdrpLevel" runat="server">
                            <asp:ListItem Value="1" Selected="True">1级</asp:ListItem>
                            <asp:ListItem Value="2">2级</asp:ListItem>
                            <asp:ListItem Value="3">3级</asp:ListItem>
                            <asp:ListItem Value="4">4级</asp:ListItem>
                            <asp:ListItem Value="5">5级</asp:ListItem>
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
