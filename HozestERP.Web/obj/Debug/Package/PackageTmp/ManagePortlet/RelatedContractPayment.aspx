<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelatedContractPayment.aspx.cs"
    Inherits="HozestERP.Web.ManagePortlet.RelatedContractPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Script/CommonManager.js" language="javascript" type="text/javascript"></script>
</head>
<body style="background-color:White;">
    <form id="form1" runat="server">
    <div class="portlet_content">
        <table style="width: 100%;">
            <%
                var realtedContractPayments = base.ContractService.GetRecentContractPayments(6);
                foreach (var item in realtedContractPayments)
                {
                    
                     
            %>
            <tr style="width: 100%; height: 5px;">
                <td style="width: 80%; color: red; border-bottom-color: #b9cadd; border-bottom-width: 1px;
                    border-bottom-style: dashed;padding-top:4px;">
                    <a onclick="javascript:ShowNewTabDetail('<%=CommonHelper.GetStoreLocation()%>ManageContract/BUContractPaymentSearch.aspx', '263', '收款记录')" href="#"><span style="float: left; cursor: hand;">
                        店铺:【<%=item.BContract.BClientInFo.StoreName%>】 </span><span style="float: right;
                            cursor: hand;">金额:【<%=item.PaymentAmount.ToString("F2") %>】元 </span></a>
                </td>
                <td style="width: 20%; text-align: right; color: red; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    <%=item.PaymentTime.ToString("yyyy-MM-dd")%>
                </td>
            </tr>
            <%
}
            %>
        </table>
    </div>
    </form>
</body>
</html>
