<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="cxhy.aspx.cs" Inherits="cxhy" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">会员管理</a>  <span
            class="divider">/</span>
        搜尋會員
    </ul>
    <div class="title_right" runat="server" id="trbj">
        <strong>搜尋會員</strong>
    </div>
    <input id="hidHYZH" type="hidden" runat="server" />
    <div style="width: 90%; margin: auto">
        <table class="table" style="width: 100%">

            <tr>
                <td class="title">
                    <asp:Label ID="lbzw" runat="server" Text=" 會員帳號："></asp:Label>
                    <input name="txtHYZH" id="txtHYZH" type="text" size="20" runat="server" class="textbox" />
                    <asp:Button ID="btnQuery" runat="server" Text="查找" OnClick="btnQuery_Click" CssClass="button" />
                    
                </td>
            </tr>
        </table>
        <cc1:JXGrid ID="grvQuery" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnRowDataBound="grvQuery_RowDataBound" OnRowCommand="grvQuery_RowCommand" >
            <Columns>
                <asp:HyperLinkField HeaderText="大總監" DataNavigateUrlFields="n_dzjdh" DataNavigateUrlFormatString="AgentManageUpd.aspx?id={0}&amp;lv=4"
                    DataTextField="n_dzjdh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="總監" DataNavigateUrlFields="n_zjdh" DataNavigateUrlFormatString="AgentManageUpd.aspx?id={0}&amp;lv=5"
                    DataTextField="n_zjdh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="大股東" DataNavigateUrlFields="n_dgddh" DataNavigateUrlFormatString="AgentManageUpd.aspx?id={0}&amp;lv=6"
                    DataTextField="n_dgddh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="股東" DataNavigateUrlFields="n_gddh" DataNavigateUrlFormatString="AgentManageUpd.aspx?id={0}&amp;lv=7"
                    DataTextField="n_gddh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="總代理" DataNavigateUrlFields="n_zdldh" DataNavigateUrlFormatString="AgentManageUpd.aspx?id={0}&amp;lv=8"
                    DataTextField="n_zdldh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="代理商" DataNavigateUrlFields="n_dldh" DataNavigateUrlFormatString="AgentManageUpd.aspx?id={0}&amp;lv=9"
                    DataTextField="n_dldh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="會員" DataNavigateUrlFields="n_hyzh,n_dldh,n_zdldh,n_gddh,n_dgddh,n_zjdh"
                    DataNavigateUrlFormatString="xzhy.aspx?n_hyzh={0}&amp;n_dldh={1}&amp;n_zdldh={2}&amp;n_gddh={3}&amp;n_dgddh={4}&amp;n_zjdh={5}"
                    DataTextField="n_hyzh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="幣別">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="允許登入" DataField="n_yxdl">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="登入時間" DataField="n_dlsj">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="登入IP" DataField="n_hyip">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="回收額度">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Button ID="Button1" Enabled="false" runat="server" Text="額度回收" CommandName="HuiShou"
                            OnClientClick="return confirm('真的要收回額度嗎??');" CssClass="button"></asp:Button>
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
