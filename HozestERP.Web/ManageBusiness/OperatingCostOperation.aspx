<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperatingCostOperation.aspx.cs"
    Inherits="HozestERP.Web.ManageBusiness.OperatingCostOperation" %>

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
                    <ext:Panel Title="付款时间" ID="PagePay" runat="server" Visible="<% $CRMIsActionAllowed:ManageBusiness.OperatingCostOperation.PagePay %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="创单时间" ID="PageCreate" runat="server" Visible="<% $CRMIsActionAllowed:ManageBusiness.OperatingCostOperation.PageCreate %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="发货时间" ID="PageDeliver" runat="server" Visible="<% $CRMIsActionAllowed:ManageBusiness.OperatingCostOperation.PageDeliver %>">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="交易完成时间" ID="PageComplete" runat="server" Visible="<% $CRMIsActionAllowed:ManageBusiness.OperatingCostOperation.PageComplete %>">
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
