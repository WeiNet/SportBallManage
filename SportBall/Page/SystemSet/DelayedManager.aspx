<%@ Page Title="" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="DelayedManager.aspx.cs" Inherits="DelayedManager" %>

<%@ Register Assembly="JXGridView" Namespace="JXGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <ul class="breadcrumb" style="margin-top: 5px">
        当前位置： <a href="#">通路管理</a>  <span
            class="divider">/</span> 下注延遲的會員清單
    </ul>
    <div class="title_right">
        <strong>下注延遲的會員清單</strong>
    </div>
    <div style="width: 90%; margin: auto">
        <cc1:JXGrid ID="grvHYZH" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnRowDataBound="grvHYZH_RowDataBound">
            <Columns>
                <asp:HyperLinkField HeaderText="總監" DataNavigateUrlFields="n_zjdh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=4"
                    DataTextField="n_zjdh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="大股東" DataNavigateUrlFields="n_dgddh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=5"
                    DataTextField="n_dgddh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="股東" DataNavigateUrlFields="n_gddh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=6"
                    DataTextField="n_gddh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="總代理" DataNavigateUrlFields="n_zdldh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=7"
                    DataTextField="n_zdldh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="代理商" DataNavigateUrlFields="n_dldh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=8"
                    DataTextField="n_dldh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="會員" DataNavigateUrlFields="n_hyzh,n_dldh,n_zdldh,n_gddh,n_dgddh,n_zjdh"
                    DataNavigateUrlFormatString="xzhy.aspx?n_hyzh={0}&amp;n_dldh={1}&amp;n_zdldh={2}&amp;n_gddh={3}&amp;n_dgddh={4}&amp;n_zjdh={5}"
                    DataTextField="n_hyzh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="會員名稱" DataField="n_hymc">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="信用額度" DataField="n_kyed">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="剩餘額度" DataField="n_syed">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="是否允許登入" DataField="n_yxdl">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="是否允許下注" DataField="n_yxxz">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="比賽類別">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="會員等級" DataField="n_wxdj">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>
        <cc1:JXGrid ID="grvWJZH" runat="server" AutoGenerateColumns="False" CssClass="grid"
            ShowFooter="false" AllowPaging="false" Width="100%"
            GridViewSortDirection="Ascending" OnRowDataBound="grvWJZH_RowDataBound">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="n_hyzh,n_hydj" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv={1}"
                    DataTextField="n_hyzh" DataTextFormatString="{0}" HeaderText="延時賬號">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="延時賬號" DataField="n_hyzh" Visible="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:HyperLinkField HeaderText="總監" DataNavigateUrlFields="n_zjdh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=4"
                    DataTextField="n_zjdh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="大股東" DataNavigateUrlFields="n_dgddh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=5"
                    DataTextField="n_dgddh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="股東" DataNavigateUrlFields="n_gddh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=6"
                    DataTextField="n_gddh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="總代理" DataNavigateUrlFields="n_zdldh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=7"
                    DataTextField="n_zdldh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="代理商" DataNavigateUrlFields="n_dldh" DataNavigateUrlFormatString="xgzh.aspx?id={0}&amp;lv=8"
                    DataTextField="n_dldh" DataTextFormatString="{0}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="信用額度" DataField="n_kyed">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="剩餘額度" DataField="n_syed">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="是否允許登入" DataField="n_yxdl">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <PagerStyle CssClass="Row1" />
            <SelectedRowStyle CssClass="RowSel" />
            <AlternatingRowStyle CssClass="Row2" />
            <HeaderStyle CssClass="FixedTitleRow" />
            <RowStyle Wrap="false" />
        </cc1:JXGrid>
         <table class="table">
            <tr>
                <td align="center"><asp:Button ID="btnBack" runat="server" Text="返回" CssClass="button" OnClick="btnBack_Click"  /></td>
            </tr>
        </table>
      

    </div>
</asp:Content>
