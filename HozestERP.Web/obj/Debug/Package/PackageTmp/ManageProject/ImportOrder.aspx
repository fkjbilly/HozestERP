<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ImportOrder.aspx.cs" Inherits="HozestERP.Web.ManageProject.ImportOrder" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px;" align="center">
                平台类型
            </td>
            <td style="width: 150px;" align="center">
                <asp:DropDownList ID="ddPlatformTypeId" runat="server" Width="100%" OnSelectedIndexChanged="ddPlatformTypeId_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px;" align="center">
                店铺名称
            </td>
            <td style="width: 150px" align="center">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 60px;" align="center">
                来源
            </td>
            <td style="width: 150px" align="center">
                <asp:DropDownList ID="ddlSourceType" Width="100%" runat="server">
                    <asp:ListItem Value="导入">导入</asp:ListItem>
                    <asp:ListItem Value="线下" Selected="True">线下</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px;" align="center">
                选择源EXCEL
            </td>
            <td style="width: 150px;">
                <asp:FileUpload ID="DataFilePath" runat="server" Width="100%" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px;">
                <div id="DIVDataFilePath2" runat="server">
                    <asp:FileUpload ID="DataFilePath2" runat="server" Width="100%" />
                </div>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:HyperLink ID="TMModel1" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/天猫1模版.xls">下载天猫1模版</asp:HyperLink>
                <asp:HyperLink ID="YMXMode" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/亚马逊模版.xls">亚马逊模版</asp:HyperLink>
                <asp:HyperLink ID="JDZYMode" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/京东自营模版 .xls">京东自营模版</asp:HyperLink>
                <asp:HyperLink ID="JDMode" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/京东模版.xls">京东模版</asp:HyperLink>
                <asp:HyperLink ID="SNZYMode" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/苏宁自营模版.xls">苏宁自营模版</asp:HyperLink>
                <asp:HyperLink ID="TYMode" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/通用模版.xls">通用模版</asp:HyperLink>
                <asp:HyperLink ID="XHSMode" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/小红书模版.xls">小红书模版</asp:HyperLink>
                <asp:HyperLink ID="PDDMode" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/拼多多.xls">拼多多模版</asp:HyperLink>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:HyperLink ID="TMModel2" runat="server" ForeColor="Red" Visible="false" NavigateUrl="~/Template/天猫2模版.xls">下载天猫2模版</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px;" align="center">
                导入结果
            </td>
            <td colspan="5">
                <asp:TextBox ID="txtResult" runat="server" Width="100%" Height="80px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnImport" SkinID="Button2" runat="server" Text="导入" OnClick="btnImport_Click"
                            Visible="<% $CRMIsActionAllowed:ImportOrder.Import %>" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnImport" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
