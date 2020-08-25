<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="NickMonthlyTargetAdd.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.NickMonthlyTargetAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px; font-weight: bold; font-size: large">
                店铺月度总目标
            </td>
            <td style="width: 200px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td style="width: 200px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                日期<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <%-- <asp:Label ID="lblLogDate" Visible="false" runat="server"></asp:Label>--%>
                <input id="dpLogDate" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" class="Wdate" runat="server"
                    style="width: 80%;" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                &nbsp;
            </td>
            <td style="width: 260px">
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
            <td style="width: 120px">
                成交金额<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <HozestERP:SimpleTextBox ID="txtBargainAmount" runat="server" Width="80%" Text="0.0"
                    ErrorMessage="成交金额不能为空." ValidationGroup="ClientValidationGroup" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                成交件数<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <HozestERP:SimpleTextBox ID="txtBargainNum" runat="server" Text="0" ErrorMessage="成交件数不能为空."
                    Width="80%" ValidationGroup="ClientValidationGroup" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                新客户订单数<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <HozestERP:SimpleTextBox ID="txtNewCustomerOrderNum" runat="server" Text="0" Width="80%"
                    ErrorMessage="新客户订单数不能为空." ValidationGroup="ClientValidationGroup" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                老客户订单数<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <HozestERP:SimpleTextBox ID="txtOldCustomerOrderNum" runat="server" Text="0" ErrorMessage="老客户订单数不能为空."
                    Width="80%" ValidationGroup="ClientValidationGroup" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                成交人数<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <HozestERP:SimpleTextBox ID="txtBargainPeopleNum" runat="server" Text="0" Width="80%"
                    ErrorMessage="成交人数不能为空." ValidationGroup="ClientValidationGroup" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                客单价<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <HozestERP:SimpleTextBox ID="txtNickPerTicketSales" runat="server" Text="0.0" ErrorMessage="客单价不能为空."
                    Width="80%" ValidationGroup="ClientValidationGroup" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
      
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                店铺
            </td>
            <td style="width: 260px">
                <asp:Label ID="lbNickName" runat="server"></asp:Label>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                所属平台
            </td>
            <td style="width: 260px">
                 <asp:Label ID="lbPlatFormName"  runat="server" ></asp:Label>
            </td>

        </tr>
          <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>

          <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            <%--    创建人--%>
            </td>
            <td style="width: 260px">
              <%--  <asp:Label ID="lbCreateName" runat="server"></asp:Label>--%>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>

             <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                Visible="<% $CRMIsActionAllowed:ManageBusiness.NickMonthlyTargetAdd.Save %>" onclick="btnSave_Click" 
                 />
        </td>

          <td style="width: 10px">
            </td>
            <td>
                &nbsp;</td>
    </tr>
 </table>
</asp:Content>
