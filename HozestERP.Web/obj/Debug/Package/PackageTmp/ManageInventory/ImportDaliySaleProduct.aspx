<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ImportDaliySaleProduct.aspx.cs" Inherits="HozestERP.Web.ManageInventory.ImportDaliySaleProduct" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
                &nbsp;
            </td>
            <td style="width: 80px;">
                项目
            </td>
            <td style="width: 450px;">
                <asp:DropDownList ID="ddXMProject" Width="40%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
                &nbsp;&nbsp;店铺 &nbsp;&nbsp;
                <asp:DropDownList ID="ddlNick" runat="server" OnSelectedIndexChanged="ddlNick_SelectedIndexChanged"
                    AutoPostBack="true">
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
            <td style="width: 80px;">
                选择源EXCEL
            </td>
            <td style="width: 450px;">
                <asp:FileUpload ID="DataFilePath" runat="server" Width="100%" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                时间
            </td>
            <td style="width: 450px;">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 30%;" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td>
                <asp:HyperLink ID="SaleDeliveryModel" runat="server" ForeColor="Red" Visible="false"
                    NavigateUrl="~/Template/日销售表格.xlsx">下载京东自营日销售模板</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                导入结果
            </td>
            <td>
                <asp:TextBox ID="txtResult" runat="server" Width="98%" Height="80px" TextMode="MultiLine"></asp:TextBox>
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
                        <asp:Button ID="btnImport" SkinID="Button2" runat="server" Text="导入" OnClick="btnImport_Click" />
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
