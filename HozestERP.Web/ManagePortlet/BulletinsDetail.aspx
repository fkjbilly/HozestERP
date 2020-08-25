<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinsDetail.aspx.cs"
    Inherits="HozestERP.Web.ManagePortlet.BulletinsDetail" %>

<%@ Register Src="~/Modules/UploadFileSeeControl.ascx" TagName="UploadFileSeeControl"
    TagPrefix="HozestERP" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;" border="0" cellspacing="2" cellpadding="2">
            <tbody>
                <tr align="center">
                    <td style="width: 100%; height: 50px; text-align: center; font-size: 14px;" colspan="5">
                        <b>
                            <asp:Literal ID="lblTitle" runat="server"></asp:Literal></b>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 22px; text-align: right; color: #444444; font-size: 12px;
                        margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; border-top-color: #b9b9b9;
                        border-top-width: 1px; border-top-style: solid; background-color: rgb(231, 231, 231);"
                        colspan="5">
                        类型:<asp:Literal ID="lblBulletinType" runat="server"></asp:Literal>
                        &nbsp;&nbsp;级别:<font color="red"><asp:Literal ID="lblPriorType" runat="server"></asp:Literal></font>&nbsp;&nbsp;发布人:<asp:Literal
                            ID="lblPromulgator" runat="server"></asp:Literal>&nbsp;&nbsp;发布时间：
                        <asp:Literal ID="lblDateTime" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left; color: #444444; padding-top: 5px; padding-right: 0px;
                        padding-bottom: 5px; padding-left: 0px; font-size: 18px; margin-top: 0px; margin-right: auto;
                        margin-bottom: 5px; margin-left: auto; border-bottom-color: #c1d5f0; border-bottom-width: 1px;
                        border-bottom-style: dashed; background-color: rgb(250, 250, 250); word-break: break-all;"
                        colspan="5">
                        <label id="TextArea1" style="width: 100%; height: 100%; text-indent: 20px; overflow: visible;
                            border-top-style: none; border-right-style: none; border-bottom-style: none;
                            border-left-style: none;">
                            <asp:Literal ID="lblDescription" runat="server"></asp:Literal>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left; color: #444444; padding-top: 5px; padding-right: 0px;
                        padding-bottom: 5px; padding-left: 0px; font-size: 14px; margin-top: 0px; margin-right: auto;
                        margin-bottom: 5px; margin-left: auto; border-bottom-color: #c1d5f0; border-bottom-width: 1px;
                        border-bottom-style: dashed; background-color: rgb(250, 250, 250);" colspan="5">
                        <HozestERP:UploadFileSeeControl ID="downloadfile" runat="server" TableName="OA_Bulletin" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
