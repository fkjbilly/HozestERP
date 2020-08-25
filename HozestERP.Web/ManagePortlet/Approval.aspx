<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.Approval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="../Script/CommonManager.js" language="javascript" type="text/javascript"></script>
</head>
<body style="background-color:White;">
    <form id="form1" runat="server">
    <div class="portlet_content">
        <table style="width: 100%;">
        <%
            
            var approvals = base.ContractService.GetContractApprovalList(HozestERPContext.Current.User.CustomerID,5);
            foreach (var item in approvals)
            {
                
        %>
        <tr style="width: 100%; height: 5px;">
           <td style="width: 80%; color: red; border-bottom-color: #b9cadd; border-bottom-width: 1px;border-bottom-style: dashed;padding-top:4px;">
            <a onclick="javascript:ShowNewTabDetail('<%=CommonHelper.GetStoreLocation()%>ManageContract/ContractDetail.aspx?ContractID=<%=item.ContractID %>', 'ContractDetail<%=item.ContractID %>', '<%=item.ContractCode %>合同信息');return false;"
                style="cursor: pointer;" ><span style="float: left; cursor: hand;">店铺:【<%=item.BClientInFo.StoreName%>】</span><span style="float: right;
                            cursor: hand;">业务员:【<%=item.BClientInFo.SCustomer.SCustomerInfo.FullName%>】 </span></a></td>
                            <td style="width: 20%; text-align: right; color: red; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                <%=item.Created.ToString("yyyy-MM-dd")%>
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
