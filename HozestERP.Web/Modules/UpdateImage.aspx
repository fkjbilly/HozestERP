<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEditNoUpdatePanel.Master"
    AutoEventWireup="true" CodeBehind="UpdateImage.aspx.cs" Inherits="HozestERP.Web.Modules.UpdateImage" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEditNoUpdatePanel.Master" %>
<%@ Register Src="~/Modules/UpdaeProcess.ascx" TagName="UpdateProcess" TagPrefix="SHIBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="">
                <tr>
                    <td style="width: 8px; height: 8px">
                    </td>
                    <td colspan="2">
                        <asp:Image ID="imgShow" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 8px; height: 8px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 8px; height: 8px">
                    </td>
                    <td style="width: 200px;">
                        <asp:FileUpload ID="fileUpload" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 8px; height: 8px">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <shibr:updateprocess id="UpdateProcess1" runat="server"></shibr:updateprocess>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Button ID="btnSure" runat="server" Text="上传" OnClick="btnSure_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSure" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
