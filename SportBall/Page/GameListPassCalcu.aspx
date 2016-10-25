<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="GameListPassCalcu.aspx.cs" Inherits="GameListPassCalcu" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Games/baseball.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">足球操盘</a> /<asp:Label ID="lbtt" runat="server" Text=""></asp:Label>計算過關結果
    </ul>
    <div class="title_right">
        <strong>計算過關結果</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">

            <tr>
                <td class="title">
                    <asp:Label ID="lbzw" runat="server" Text=" 帳務日期："></asp:Label>
                    <asp:DropDownList ID="drpDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpDate_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="btcx" runat="server" Text="查詢" OnClick="btcx_Click" CssClass="button" />
                    <asp:Button ID="btjs" runat="server" Text="計算結果" OnClick="btjs_Click" CssClass="button" />
                </td>
            </tr>
        </table>
        <cc1:JXGrid ID="JXGrid1" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="true" Width="100%"
            GridViewSortDirection="Ascending" OnRowDataBound="JXGrid1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="下注時間" FooterText="合計">
                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                    <ItemTemplate>
                        <asp:Label ID="lbn_xzrq" runat="server" Text='<%#String.Format("{0}",Eval("n_xzrq")).Replace(" ","<br>").Replace("-","/")%>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" BackColor="Red" ForeColor="White" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單號">
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                    <ItemTemplate>
                        <asp:Label ID="lbn_xzdh" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="投注內容">
                    <ItemTemplate>
                        <asp:Label ID="lbn_xznr" runat="server" Text='<%#Bind("xznr")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="投注金額" DataField="n_xzje">
                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                    <FooterStyle HorizontalAlign="Center" BackColor="Red" ForeColor="White" />
                </asp:BoundField>
                <asp:BoundField HeaderText="可贏金額" DataField="n_kyje" DataFormatString="{0:0.0}" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                    <FooterStyle HorizontalAlign="Center" BackColor="Red" ForeColor="White" />
                </asp:BoundField>
                <asp:BoundField HeaderText="結果" DataField="n_syjg" DataFormatString="{0:0.0}" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                    <FooterStyle HorizontalAlign="Center" BackColor="Red" ForeColor="White" />
                </asp:BoundField>
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>
          <table width="100%" cellpadding="0" cellspacing="0" class="table" >
                    <tr  runat="server" id="trhj">
                        <td style=" height:19px" colspan="3" class="trr" >
                            合計
                        </td>
                        <td align="center" style="width:12%" class="trc" >
                            <asp:Label ID="lbxzje" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="trc"  style="width:12%">
                            <asp:Label ID="lbkyje" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="trc" style="width:12%">
                            <asp:Label ID="lbsyjg" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr  runat="server" id="trno">
                        <td style="width:12%" colspan="6" class="trc">
                            沒有注單.
                        </td>
                    </tr>
                </table>
    </div>

</asp:Content>
