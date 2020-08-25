<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RefundmentContract.aspx.cs"
    Inherits="HozestERP.Web.ManagePortlet.RefundmentContract" %>

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
                var contracts = base.ContractService.GetClientRefundmentContractDesktopList(HozestERPContext.Current.User.CustomerID, emptyLikeStr, emptyLikeStr, -1, -1, -1,
                    emptyLikeStr, emptyLikeStr, emptyLikeStr, emptyLikeStr, null, null, -1);
                foreach (var contract in contracts)
                {
            %>
            <tr style="width: 100%; height: 5px;">
                <td style="width: 40%; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    <%--<a onclick="javascript:ShowNewTabDetail('<%=CommonHelper.GetStoreLocation()%>ManageContract/BUContractPaymentSearch.aspx', '263', '收款记录')" href="#">
                    </a>--%>
                    <span style="float: left; cursor: hand;">店铺:【
                    <% if (!string.IsNullOrEmpty(contract.StoreName.Trim()))
                       {
                           if (contract.StoreName.Trim().Length >= 25)
                           {
                           %>          
                      <%= contract.StoreName.Trim().Substring(0, 25) + "..."%>                                    
                       <%} else{ %> 
                            <%= contract.StoreName.Trim().Substring(0, contract.StoreName.Trim().Length)%>   
                          <% }
                       }%>

                     】</span>
                </td>
                <td style="width: 30%; text-align: right; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    合同编号:&nbsp;<%= contract.ContractCode.Trim() %>
                </td>
               <%-- <td style="width: 20%; text-align: right; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    合同金额(元):&nbsp;￥<span style="color:Red;font-weight:bold;"><%= Math.Round(contract.Amount,2).ToString() %></span>&nbsp;
                </td>--%>
                <td style="width: 20%; text-align: right; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    合同状态:&nbsp;<span>退款</span>&nbsp;
                </td>
            </tr>
            <%}%>
        </table>
    </div>
    </form>
</body>
</html>
