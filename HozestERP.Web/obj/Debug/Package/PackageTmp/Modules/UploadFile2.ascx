<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFile2.ascx.cs"
    Inherits="HozestERP.Web.Modules.UploadFile2" %>
<asp:UpdatePanel ID="updatePanel2" runat="server">
    <ContentTemplate>
        <link href="<%=CommonHelper.GetStoreLocation() %>Modules/Uploadify/uploadify.css"
            rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="<%=CommonHelper.GetStoreLocation() %>Modules/Uploadify/jquery-1.4.2.min.js"></script>
        <script type="text/javascript" src="<%=CommonHelper.GetStoreLocation() %>Modules/Uploadify/swfobject.js"></script>
        <script type="text/javascript" src="<%=CommonHelper.GetStoreLocation() %>Modules/Uploadify/jquery.uploadify.v2.1.4.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#uploadify").uploadify({
                    'uploader': '<%=CommonHelper.GetStoreLocation() %>Modules/Uploadify/uploadify.swf'
               , 'script': '<%=CommonHelper.GetStoreLocation() %>Modules/UploadHandler.ashx'
               , 'scriptData': { 'TaggantID': '<%=this.TaggantID.ToString() %>', 'ObjectID': '<%=this.ObjectID %>', 'TableName': '<%=this.TableName %>' }
               , 'cancelImg': '<%=CommonHelper.GetStoreLocation() %>Modules/Uploadify/cancel.png'
               , 'folder': 'UploadFile'
               , 'fileExt': '*.jpg;*.png;*.gif'
               , 'fileDesc': '图片文件(*.jpg;*.png;*.gif)'
               , 'auto': true
               , 'multi': true
               , 'buttonImg': '<%=CommonHelper.GetStoreLocation() %>images/browse.jpg'
               , 'onSelect': function (e, queueId, fileObj) {
               }
               , 'onProgress': function (event, queueID, fileObj, date, percentage, bytesLoaded, allBytesLoaded, speed) {
               }
               , 'onComplete': function (e, queueId, fileObj, response, data) {
                   document.getElementById("<%=this.btnRefresh.ClientID %>").click();
               }
               , 'onError': function (event, queueID, fileObj) {
                   alert("文件:" + fileObj.name + " 上传失败");
               }
                });
            });

        </script>
        <style type="text/css">
            #fileQueue
            {
                margin-top: 15px;
            }
        </style>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
      
            <tr>
                <td style="vertical-align: top;">
                    <input type="file" name="uploadify" id="uploadify" />
                </td>
            </tr>
            <tr>
                <td style="width: 8px; height: 8px">
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <div>
                        <asp:Repeater ID="rpFiles" runat="server" OnItemCommand="rpFiles_ItemCommand">
                            <ItemTemplate>
                                <div style="float: left; padding-right: 10px;">
                                    <a href="#" onclick="window.open('<%# CommonHelper.GetStoreLocation()%>ManageFile/GetDownload.ashx?FilePath=../Upload/<%# Eval("Url")%>&Filename=<%# Eval("FullName") %>');return false;"
                                        target="_blank">
                                        <img src="geticon.axd?file=<%# Eval("Url").ToString().Substring(Eval("Url").ToString().LastIndexOf('.'))%>&size=small"
                                            alt="<%# Eval("Url").ToString().Substring(Eval("Url").ToString().LastIndexOf('.'))%>" />
                                        <%# Eval("FullName") %></a>
                                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("UploadFileID") %>'
                                        SkinID="btnDetailDelete" CommandName="DetailDelete" OnClientClick="return confirm('您确认要删除吗？');"></asp:ImageButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnRefresh" runat="server" Text="刷新附件" OnClick="btnRefresh_Click"
            Style="display: none; width: 0px; height: 0px;" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnRefresh" />
        <asp:PostBackTrigger ControlID="rpFiles" />
    </Triggers>
</asp:UpdatePanel>
