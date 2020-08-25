<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractAmountRank.aspx.cs"
    Inherits="HozestERP.Web.ManagePortlet.ContractAmountRank" %>

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
                var emptyLikeStr = "%%";
                var contracts = base.ContractService.GetClientContractAmountRankDesktopList(HozestERPContext.Current.User.CustomerID, emptyLikeStr, emptyLikeStr, -1, -1, -1,
                    emptyLikeStr, emptyLikeStr, emptyLikeStr, emptyLikeStr, null, null, -1);
                foreach (var contract in contracts)
                {
            %>
            <tr style="width: 100%; height: 5px;">
                <td style="width: 70%; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    <%--<a onclick="javascript:ShowNewTabDetail('<%=CommonHelper.GetStoreLocation()%>ManageContract/BUContractPaymentSearch.aspx', '263', '收款记录')" href="#">
                    </a>--%>
                    <span style="float: left; cursor: hand;">业务员:【<%= contract.CustomerName.Trim() %>】</span>
                </td>
                <%--<td style="width: 20%; text-align: right; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    合同编号:&nbsp;<%= contract.ContractCode.Trim() %>
                </td>--%>
                <%--<td style="width: 20%; text-align: right; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    合同金额:&nbsp;￥<span ><%= Math.Round(contract.Amount,2).ToString() %></span>&nbsp;
                </td>--%>
                <td style="width: 20%; text-align: left; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    金额:&nbsp;￥<span style="color:Red;font-weight:bold;"><%= Math.Round(contract.PaymentAmount,2).ToString() %></span>&nbsp;
                </td>
            </tr>
            <%}%>
        </table>
    </div>
    </form>
</body>
</html>
