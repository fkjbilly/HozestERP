<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMPremiumsOperation.aspx.cs"
    Inherits="HozestERP.Web.ManageProject.XMPremiumsOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder1" runat="server" Mode="Script">
    </ext:ResourcePlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:TabPanel ID="TabPanel1" Region="Center" EnableTabScroll="true" LayoutOnTabChange="true"
                TabPosition="Top" TabAlign="Left" runat="server">
                <Items>
                    <ext:Panel Title="全部" ID="PageXMPremiumsOperationAll" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsOperation.All %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="已付款客服未核对" ID="PageManagerStatusPay" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsOperation.Pay %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="确认收货客服未核对" ID="PageManagerStatusNotEvaluation" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsOperation.ManagerStatusNoEvaluation %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="已核对未审核" ID="PageManagerStatusNotCheck" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsOperation.ManagerStatusNotCheck %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="已审核" ID="PageManagerStatusAlreadyCheck" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsOperation.ManagerStatusAlreadyCheck %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="无订单赠品" ID="PageManagerNoOrder" runat="server" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsOperation.ManagerNoOrder %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
