<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdaeProcess.ascx.cs"
    Inherits="HozestERP.Web.Modules.UpdaeProcess"  %>
    
<div id="Controls_UpdateProcess_Div" runat="server" style="position: absolute; width: 100%;
    height: 100%; z-index: 100; left: 0px; top: 0px; text-align: center; vertical-align: bottom;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;
        vertical-align: middle; width: 100%">
        <tr style="height: 30%">
            <td style="width: 100%">
            </td>
        </tr>
        <tr style="height: 30%">
            <td style="width: 100%" align="center">
                <table border="0" cellpadding="0" cellspacing="0" style="vertical-align: middle;"
                    class="transbox">
                    <tr>
                        <td style="width: 100%" class="transbox" align="center">
                            <table border="0" cellpadding="0" cellspacing="0" class="WaitPanel">
                                <tr style="width: 100%">
                                    <td>
                                    </td>
                                    <td style="width: 100%; text-align: center;">
                                        <asp:Image ID="Image2" runat="server" SkinID="Loading" /><font color="white"> 更新中..</font>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 30%">
            <td style="width: 100%">
            </td>
        </tr>
    </table>
</div>

