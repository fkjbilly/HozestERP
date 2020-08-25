<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerAvatarControl.ascx.cs"
    Inherits="HozestERP.Web.Modules.CustomerAvatarControl" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td>
            <fieldset class="fieldset">
                <legend>用户头像</legend>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td align="right" style="width: 20%">
                        </td>
                        <td>
                            <asp:Image ID="imgAvatar" runat="server" AlternateText="Avatar" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%; ">
                        </td>
                        <td>
                            <asp:FileUpload ID="uplAvatar" runat="server" ToolTip="Choose a new avatar image to upload." />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnUploadAvatar" runat="server" OnClick="btnUploadAvatar_Click" Text="上传" />
                            <asp:Button ID="btnRemoveAvatar" runat="server" OnClick="btnRemoveAvatar_Click" Text="删除"
                                CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
</table>
