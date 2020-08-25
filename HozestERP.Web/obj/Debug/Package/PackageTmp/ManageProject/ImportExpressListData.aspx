<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ImportExpressListData.aspx.cs" Inherits="HozestERP.Web.ManageProject.ImportExpressListData" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                快递公司
            </td>
            <td style="width: 200px;">
                <asp:DropDownList ID="ddlExpress" runat="server" Width="50%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                对账时间
            </td>
            <td style="width: 450px;">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" class="Wdate"
                    runat="server" style="width: 30%;" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                选择源EXCEL
            </td>
            <td style="width: 400px;">
                <asp:FileUpload ID="DataFilePath" runat="server" Width="100%" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
                &nbsp;
            </td>
            <td style="width: 80px;">
                &nbsp;
            </td>
            <td style="width: 400px;">
                <asp:HyperLink ID="DownTemp" runat="server" ForeColor="Red" NavigateUrl="~/Template/快递账单模板.xls">下载快递账单模板</asp:HyperLink>
            </td>
            <td>
                &nbsp;
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
                导入结果
            </td>
            <td>
                <asp:TextBox ID="txtResult" runat="server" Width="100%" Height="80px" TextMode="MultiLine"></asp:TextBox>
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
