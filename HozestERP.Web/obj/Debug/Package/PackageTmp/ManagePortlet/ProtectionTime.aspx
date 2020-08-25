<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProtectionTime.aspx.cs"
    Inherits="HozestERP.Web.ManagePortlet.ProtectionTime" %>

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
                var mClientInfos = base.ClientService.GetClientProtectionTimeDesktopList(HozestERPContext.Current.User.CustomerID);
                var ClientInfos = mClientInfos.Where(q => (DateTime.Now.Date - q.ProtectionDateTime.Value.Date).TotalDays <= 100).ToList(); //过滤因数据混乱而逾期没有从系统剔除的数据
                foreach (var client in ClientInfos)
                {
            %>
            <tr style="width: 100%; height: 5px;">
                <td style="width: 50%; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    <%--<a onclick="javascript:ShowNewTabDetail('<%=CommonHelper.GetStoreLocation()%>ManageContract/BUContractPaymentSearch.aspx', '263', '收款记录')" href="#">
                    </a>--%>
                    <span style="float: left; cursor: hand;">店铺:【
                    <% if (!string.IsNullOrEmpty(client.StoreName.Trim()))
                       {
                           if (client.StoreName.Trim().Length >= 25)
                           {
                           %>          
                      <%= client.StoreName.Trim().Substring(0, 25) + "..."%>                                    
                       <%} else{ %> 
                            <%= client.StoreName.Trim().Substring(0, client.StoreName.Trim().Length)%>   
                          <% }
                       }%>

                     】</span>
                </td>
                <td style="width: 20%; text-align: right; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                    保护时间:&nbsp;<%= client.ProtectionDateTime.Value.ToString("yyyy/MM/dd")%>
                </td>
                <td style="width: 20%; text-align: right; border-bottom-color: #b9cadd; border-bottom-width: 1px; border-bottom-style: dashed;padding-top:4px;">
                   剩余保护天数:&nbsp;<span style="color:Red; font-weight:bold;"><%= client.ProtectionDays.ToString() %></span>&nbsp;
                </td>
            </tr>
            <%}%>
        </table>
    </div>
    </form>
</body>
</html>
