<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master" 
AutoEventWireup="true" CodeBehind="MatchScalpingCode.aspx.cs" Inherits="HozestERP.Web.ManageProject.MatchScalpingCode" %>
 

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
  
<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />
<script type="text/javascript">
    function autoCompleteBindMatchScalpingCode() {

        //alert($("#<%= hfPlatformTypeIdSet.ClientID%>").val());
        //alert($("#<%= hfNickIdSet.ClientID%>").val());

        $("#<%= txtScalpingCode.ClientID%>").autocomplete({
            source: function (request, response) {
                jQuery.ajax({
                    url: "../ManageFinance/ScalpingCodeHandler.ashx?action=SelectByAdvanceState&PlatformTypeId=" + $('#<%= hfPlatformTypeIdSet.ClientID%>').val() + "&NickId=" + $('#<%= hfNickIdSet.ClientID%>').val(),
                    data: "q=" + encodeURI(request.term),
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.ScalpingCode + "平台：" + item.PlatformTypeName + " 店铺：" + item.NickName,
                                value: item.ScalpingCode,
                                scalping: item
                            }
                        }));
                    }
                });
            }
        }, {
            select: function (e, i, j) {
                $("#<%= hfScalpingId.ClientID%>").val(i.item.scalping.ScalpingId);
                $("#<%= hfPlatformTypeId.ClientID%>").val(i.item.scalping.PlatformTypeId);
                $("#<%= hfNickId.ClientID%>").val(i.item.scalping.NickId);
                $("#<%= txtPlatformType.ClientID%>").val(i.item.scalping.PlatformTypeName);
                $("#<%= txtNickName.ClientID%>").val(i.item.scalping.NickName);
            }
        });
    } 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table   border="0" cellspacing="0"  > 
             <tr>
          
            <td style="width: 140px; height:50px;" align="right">
                刷单单号<font color="red">*</font>:
             </td>  
             <td width="200px">  
              <input runat="server" id="txtScalpingCode" class="TextBox ScalpingCode" style="text-align: left;  width: 95%" type="text"/>
                    <input id="hfScalpingId" type="hidden" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtScalpingCode"  Font-Name="verdana" Font-Size="9pt"
                        runat="server" Display="None" ErrorMessage="刷单单号不能为空."  ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"  TargetControlID="RequiredFieldValidator1" 
                        HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopLeft"  />
             </td>
            <td style="width: 140px" align="right">
                 平台类型<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                 <input id="hfPlatformTypeId" type="hidden" runat="server" />
                    <asp:TextBox ID="txtPlatformType" runat="server" Width="95%" Enabled="false"></asp:TextBox> 
             </td>
            <td style="width: 140px" align="right">
                  店铺名称<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                 <input id="hfNickId" type="hidden" runat="server" /> 
                    <asp:TextBox ID="txtNickName" runat="server" Width="95%" Enabled="false"></asp:TextBox>  
                     
                 <input id="hfPlatformTypeIdSet" type="hidden" runat="server" />  
                 <input id="hfNickIdSet" type="hidden" runat="server" /> 
            </td>  
        </tr>  
    </table> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0"> 
   <%--   --%>
        <tr>
         <td style="text-align:right;">
          
         <asp:Button ID="Button1" SkinID="Button2" runat="server" Text="确定" OnClick="btnSave_Click"  ValidationGroup="ModuleValidationGroup" />
        </td>
        
        </tr>
    </table>  
    <script type="text/javascript">
        $(function () {

            autoCompleteBindMatchScalpingCode();
        });
    </script>
    
</asp:Content>
