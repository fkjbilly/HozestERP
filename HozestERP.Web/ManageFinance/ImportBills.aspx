<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ImportBills.aspx.cs" Inherits="HozestERP.Web.ManageFinance.ImportBills" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Script/select2-develop/dist/css/select2.css"  rel="stylesheet" type="text/css" />
    <link href="../Script/bootstrap-3.3.7/css/bootstrap.css"  rel="stylesheet" type="text/css" />
    <script src="../Script/select2-develop/dist/js/select2.full.js" type="text/javascript"></script>
    <script src="../Script/bootstrap-3.3.7/js/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px;" align="center">
                供应商
            </td>
           <td style="width: 400px;">
                <asp:TextBox ID="ddSuppliers" name="ddSuppliers" runat="server" Width="90%"></asp:TextBox>
                 <!--<input type="text"  id="ddSuppliers" name="ddSuppliers" />-->
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
            </td>
            <td style="width: 8px; height: 8px">
            </td>

        </tr>

        <tr>
            <td style="width: 8px; height: 8px">
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
     <script type="text/javascript">

         $.ajax({
             url: "XMBillsSelect2.ashx",
             type: "GET",
             dataType: "json",
             async: false,
             contentType: "application/json; charset=utf-8",
             success: function (json) {
                 select2data = [];
                 var allOption = new Object();
                 allOption.text = "---全部---";
                 allOption.id = -1;
                 select2data.push(allOption);
                 json.forEach(function (ele) {
                     select2data.push(ele);
                 });
                 $("#ctl00_ContentPlaceHolder1_ddSuppliers").select2({
                     data: select2data
                 });
             },
             error: function (x, e) {
             },
             complete: function (x) {
             }
         });
      
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnImport" SkinID="Button2" runat="server" Text="导入" OnClick="btnImport_Click"
                            Visible="<% $CRMIsActionAllowed:ManageFinance.XMBills.ImportBills %>" />
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
