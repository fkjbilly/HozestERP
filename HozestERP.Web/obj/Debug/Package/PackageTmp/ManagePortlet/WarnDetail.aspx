<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarnDetail.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.WarnDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../Script/CommonManager.js" language="javascript" type="text/javascript"></script>
</head>
<body style="background-color:White;">
    <form id="form1" runat="server">
    <div class="portlet_content">

        <asp:Literal ID="litContent" runat="server"></asp:Literal>

        <%--<table style="width: 100%;">
            <%
               // var departMent = base.CustomerService.GetDepartmentByCustomerID(HozestERPContext.Current.User.CustomerID);
               // var dep = departMent.DepartmentID;
               //  var LinkDepartMent = "AMClients.aspx";
               //if (dep==48)
               //    LinkDepartMent="AMClients.aspx";
               //else if(dep==46)   LinkDepartMent = "AMClients.aspx";
               // var contractExpands = base.AEContractService.GetWarningTop(HozestERPContext.Current.User.CustomerID);
               //foreach (var item in contractExpands)
               // {
              %>
            <tr style="width: 100%; height: 5px;">
                <td style="width: 80%; color: Red">
                     <a id="ctlClient" onclick="javascript:ShowNewTabDetail('<%=CommonHelper.GetStoreLocation()%>ManageAM/AMClients.aspx', '263', '收款记录')" href="#" runat="server">
                        <%=item.BContract.BClientInFo.StoreName%></a>
                </td>
                <td style="text-align: right">
                    <a target="_blank" href=" http://amos.im.alisoft.com/msg.aw?v=2&uid=<%=item.BContract.BClientInFo.LinkWant%>&site=cntaobao&s=1&charset=utf-8">
                        <img border="0" src=" http://amos.im.alisoft.com/online.aw?v=2&uid=<%=item.BContract.BClientInFo.LinkWant%>&site=cntaobao&s=1&charset=utf-8"
                            alt="点击这里打开链接" /></a>
                </td>
            </tr>
            <tr style="width: 100%; height: 1px;">
                <td style="border-bottom: dashed 1px #B9CADD;" colspan="3">
                </td>
            </tr>
            <%
}
            %>
        </table>--%>


    </div>
    </form>
</body>
</html>
