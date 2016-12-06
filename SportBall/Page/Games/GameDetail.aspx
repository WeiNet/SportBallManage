<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameDetail.aspx.cs" Inherits="GameDetail" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注单详情</title>
    <script src="GameDetail.js" type="text/javascript"></script>
    <link href="../../Styles/master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div >
              <asp:HiddenField ID="delyy" Value="" runat="server" />
            <table class="table">
                <tr>
                    <td class="title" colspan="2">
                        <asp:Label ID="lblball" runat="server" Text=""></asp:Label>&gt;注單明細</td>
                </tr>
                <tr>
                    <td class="trc" style="width: 50%">
                        <asp:Label ID="lblDW" runat="server" Text=""></asp:Label>
                        <input id="hidType" type="hidden" runat="server" />
                    </td>
                    <td class="trc">
                        <asp:Button runat="server" ID="lbtnDetail" Text="注單明細" CssClass="button" OnClick="lbtnDetail_Click"  />
                        <asp:Button runat="server" ID="lbtnStat" Text="盤口統計" CssClass="button" OnClick="lbtnStat_Click"  />
                        <asp:Button runat="server" ID="lbtnCount" Text="盤口試算" CssClass="button" OnClick="lbtnCount_Click"  />

                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="trc">
                        <asp:Label ID="lblWF" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnUpdate" runat="server" Text="更新" CssClass="button" OnClick="btnUpdate_Click"  />
                        <asp:DropDownList ID="drpBill" runat="server"
                            TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="drpBill_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="顯示全部"></asp:ListItem>
                            <asp:ListItem Value="1" Text="只顯示有效注單"></asp:ListItem>
                            <asp:ListItem Value="2" Text="只顯示危險注單"></asp:ListItem>
                            <asp:ListItem Value="3" Text="只顯示已刪除注單"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpPage" runat="server" AutoPostBack="true" 
                            TabIndex="2" OnSelectedIndexChanged="drpPage_SelectedIndexChanged">
                            <asp:ListItem Value="15" Text="每頁顯示15筆"></asp:ListItem>
                            <asp:ListItem Value="30" Text="每頁顯示30筆"></asp:ListItem>
                            <asp:ListItem Value="45" Text="每頁顯示45筆"></asp:ListItem>
                            <asp:ListItem Value="50" Text="每頁顯示50筆"></asp:ListItem>
                            <asp:ListItem Selected="True" Value="100" Text="每頁顯示100筆"></asp:ListItem>
                        </asp:DropDownList>
                        <input type="button" id="btnClose" name="btnClose" onclick="window.close();" class="button"
                            value="關閉" />
                    </td>
                </tr>
            </table>
            <cc1:JXGrid ID="grvDetail" runat="server" AutoGenerateColumns="False" CssClass="grid"
                ShowFooter="false" AllowPaging="false" 
                GridViewSortDirection="Ascending" OnRowDataBound="grvDetail_RowDataBound" OnRowDeleting="grvDetail_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="n_xzrq" HeaderText="下注時間" />
                    <asp:TemplateField HeaderText="下注單號">
                        <ItemTemplate>
                            <asp:Label ID="lbln_xzwf" runat="server" Text='<% #Eval("n_xzwf")%>'></asp:Label><br />
                            <asp:Label ID="lblxzdh" runat="server" Text='<% #Eval("xzdh")%>'></asp:Label>
                            <asp:Label ID="lbln_xzdh" runat="server" Text='<% #Eval("n_xzdh")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="n_hydh" HeaderText="會員" />
                    <asp:TemplateField HeaderText="下注內容">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label ID="lblBetContent" runat="server" Text='<% #Eval("n_xznr")%>'></asp:Label>
                            <asp:Label ID="lbln_delyy" runat="server" Text='<% #Eval("n_delyy")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="n_xzje" HeaderText="下注金額" />
                    <asp:BoundField DataField="gsje" HeaderText="公司金額" />
                    <asp:BoundField DataField="n_syjg" HeaderText="輸贏結果" />
                    <asp:BoundField DataField="n_ty" HeaderText="退佣" />
                    <asp:BoundField DataField="n_hyjg" HeaderText="會員結果" />
                    <asp:BoundField DataField="n_gsjg" HeaderText="公司結果" />
                    <asp:CommandField HeaderText="刪除" ShowDeleteButton="True" />
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbln_del" runat="server" Text='<% #Eval("n_del")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbln_wxdj" runat="server" Text='<% #Eval("n_wxdj")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbln_dbzd" runat="server" Text='<% #Eval("n_dbzd")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="Row1" />
                <SelectedRowStyle CssClass="RowSel" />
                <AlternatingRowStyle CssClass="Row2" />
                <HeaderStyle CssClass="FixedTitleRow" />
                <RowStyle Wrap="false" />
            </cc1:JXGrid>
            <cc1:JXGrid ID="grvStat" runat="server" AutoGenerateColumns="False" CssClass="grid"
                ShowFooter="false" AllowPaging="false" 
                GridViewSortDirection="Ascending" OnRowDataBound="grvStat_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="下注方式" />
                    <asp:BoundField HeaderText="盤口" />
                    <asp:BoundField HeaderText="球隊" />
                    <asp:BoundField DataField="bs" HeaderText="注單筆數" />
                    <asp:BoundField DataField="n_xzje" HeaderText="下注金額" />
                    <asp:BoundField DataField="gsje" HeaderText="公司金額" />
                    <asp:BoundField DataField="n_syjg" HeaderText="輸贏結果" />
                    <asp:BoundField DataField="n_ty" HeaderText="退佣" />
                    <asp:BoundField DataField="n_hyjg" HeaderText="會員結果" />
                    <asp:BoundField DataField="n_gsjg" HeaderText="公司結果" />
                </Columns>
                <PagerStyle CssClass="Row1" />
                <SelectedRowStyle CssClass="RowSel" />
                <AlternatingRowStyle CssClass="Row2" />
                <HeaderStyle CssClass="FixedTitleRow" />
                <RowStyle Wrap="false" />
            </cc1:JXGrid>
            <cc1:JXGrid ID="grvCount" runat="server" AutoGenerateColumns="False" CssClass="grid"
                ShowFooter="false" AllowPaging="false" 
                GridViewSortDirection="Ascending" OnRowDataBound="grvCount_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="下注方式" />
                    <asp:BoundField HeaderText="盤口" />
                    <asp:BoundField HeaderText="球隊" />
                    <asp:BoundField DataField="bs" HeaderText="注單筆數" />
                    <asp:BoundField DataField="n_xzje" HeaderText="下注金額" />
                    <asp:BoundField DataField="n_syjg" HeaderText="輸贏結果" />
                    <asp:BoundField DataField="n_ty" HeaderText="退佣" />
                    <asp:BoundField DataField="n_hyjg" HeaderText="會員結果" />
                    <asp:BoundField HeaderText="贏 試算" />
                    <asp:BoundField HeaderText="輸 試算" />
                    <asp:BoundField HeaderText="贏 差距" />
                </Columns>
                <PagerStyle CssClass="Row1" />
                <SelectedRowStyle CssClass="RowSel" />
                <AlternatingRowStyle CssClass="Row2" />
                <HeaderStyle CssClass="FixedTitleRow" />
                <RowStyle Wrap="false" />
            </cc1:JXGrid>
        </div>
    </form>
</body>
</html>
