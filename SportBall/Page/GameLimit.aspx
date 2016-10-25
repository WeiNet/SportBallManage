<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="GameLimit.aspx.cs" Inherits="GameLimit" EnableEventValidation="false" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <script src="GameLimit.js" type="text/javascript"></script>
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">系统设置</a>  <span
            class="divider">/</span> 单场单注限制
    </ul>
    <div class="title_right">
        <strong>单场单注限制</strong>
    </div>

    <div style="width: 90%; margin: auto">
        <table >
            <tr>
                <asp:HiddenField ID="hidFlag" runat="server" />
                <td >
                    <asp:Button ID="btnQuery" runat="server" CssClass="button" Text="查询" OnClick="btnQuery_Click" />
                    <%--查詢--%>
                    <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="新增分站限红" OnClick="btnAdd_Click" />
                    <%--添加--%>
                  
                </td>
            </tr>
        

        </table>
        <table class="table">
            <tr>
                <td class="trr">分站编号</td>
                <td class="trl">
                    <asp:TextBox runat="server" ID="txtFZBH" onblur="this.value=this.value.toUpperCase();" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="trr">联盟等级
                </th>
                <th class="trl">单场限额
                </th>
               
            </tr>
            <tr>
                <td class="trr">1
                </td>
                <td class="trl">
                    <asp:TextBox runat="server" ID="txt1" onkeypress="return inputNubmer()" Width="90%"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td class="trr">2
                </td>
                <td class="trl">
                    <asp:TextBox runat="server" ID="txt2" onkeypress="return inputNubmer()" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="trr">3
                </td>
                <td class="trl">
                    <asp:TextBox runat="server" ID="txt3" onkeypress="return inputNubmer()" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="trr">4
                </td>
                <td class="trl">
                    <asp:TextBox runat="server" ID="txt4" onkeypress="return inputNubmer()" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="trr">5
                </td>
                <td class="trl">
                    <asp:TextBox runat="server" ID="txt5" onkeypress="return inputNubmer()" Width="90%"></asp:TextBox>
                </td>
            </tr>

        </table>
        <table class="table">
            <tr>
                <td align="center">基准值</td>
            </tr>
        </table>
        <cc1:JXGrid ID="grvLimitBase" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="true" Width="100%"
            GridViewSortDirection="Ascending" OnRowCancelingEdit="grvLimitBase_RowCancelingEdit" OnRowDataBound="grvLimitBase_RowDataBound" OnRowEditing="grvLimitBase_RowEditing" OnRowUpdating="grvLimitBase_RowUpdating">
            <Columns>
                <asp:BoundField DataField="N_PLAYTYPE" HeaderText="玩法类型" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="基准值" ItemStyle-Width="55%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblPlayValue" runat="server" Text='<%# Eval("N_PLAYVALUE") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvtxtPlayValue" runat="server" Width="100%" MaxLength="200"></asp:TextBox>
                        <asp:HiddenField ID="hidPlayType" runat="server" />
                        <asp:HiddenField ID="hidCourtType" runat="server" />
                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>


                <asp:TemplateField ItemStyle-Width="15%">

                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>操作</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" ToolTip="操作"
                            ImageUrl="~/Images/icon_edit.gif" />

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
        <table class="table">
            <tr>
                <td align="center">单注 </td>
            </tr>
        </table>
         <cc1:JXGrid ID="grvLimitSingle" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnRowCancelingEdit="grvLimitSingle_RowCancelingEdit" OnRowDataBound="grvLimitSingle_RowDataBound" OnRowEditing="grvLimitSingle_RowEditing" OnRowUpdating="grvLimitSingle_RowUpdating">
            <Columns>
                <asp:BoundField DataField="N_LEVEL" HeaderText="联盟等级" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="单注" ItemStyle-Width="55%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblCREDIT" runat="server" Text='<%# Eval("N_CREDIT") %>'></asp:Label>

                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvtxtCREDIT" runat="server" Width="100%" MaxLength="200"></asp:TextBox>
                        <asp:HiddenField ID="hidLEVEL" runat="server" />
                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="15%">

                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>操作</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" ToolTip="操作"
                            ImageUrl="~/Images/icon_edit.gif" />


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
        <table class="table">
            <tr>
                <td align="center">单场<asp:DropDownList ID="drpSite" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSite_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            </tr>
        </table>
          <cc1:JXGrid ID="grvLimitCourt" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnRowCancelingEdit="grvLimitCourt_RowCancelingEdit" OnRowDataBound="grvLimitCourt_RowDataBound"  OnRowEditing="grvLimitCourt_RowEditing" OnRowUpdating="grvLimitCourt_RowUpdating" >
            <Columns>
                <asp:BoundField DataField="N_LEVEL" HeaderText="联盟等级" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="单场" ItemStyle-Width="55%">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="grvlblCREDIT" runat="server" Text='<%# Eval("N_CREDIT") %>'></asp:Label>

                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="grvtxtCREDIT" runat="server" Width="100%" MaxLength="200"></asp:TextBox>
                        <asp:HiddenField ID="hidLEVEL" runat="server" />
                    </EditItemTemplate>

                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="15%">

                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>操作</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" ToolTip="操作"
                            ImageUrl="~/Images/icon_edit.gif" />


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
