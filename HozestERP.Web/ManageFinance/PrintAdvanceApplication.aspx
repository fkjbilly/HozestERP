<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintAdvanceApplication.aspx.cs" 
Inherits="HozestERP.Web.ManageFinance.PrintAdvanceApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
    <script src="../../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/print/LodopFuncs1.js" type="text/javascript"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
        <%--<embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="../Script/print/install_lodop32.exe">
        </embed>--%>
        <embed id="LODOP_EM" type="application/x-print-lodop" width=0 height=0></embed>
    </object> 
    <script language="javascript" type="text/javascript">
        var LODOP; //声明为全局变量 
        function win_preview() {
            CreateOneFormPage();
            LODOP.PREVIEW();
        }
        function win_print() {
            CreateOneFormPage();
            LODOP.PRINT();
        }
        function print_print() {
            CreateOneFormPage();
            LODOP.PRINT();
        }

        function CreateOneFormPage() {
            //LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP = getLodop();
            LODOP.ADD_PRINT_HTM(50, 80, 500, 700, document.getElementById("print_body").innerHTML);
            //document.getElementById('<%= hidBtnFinanceOk.ClientID %>').click();
        }; 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="print_body"> 
            <link href="../Portaltheme/13/style.css" rel="stylesheet" type="text/css" />
            <link href="../Portaltheme/13/person_info.css" rel="stylesheet" type="text/css" />
            <table width="650" class="TableBlock" cellspacing="0" cellpadding="0" style="margin: 5px;">
                <style>
                    .TableBlock .TableContent td, .TableBlock th.TableContent
                    {
                        background: none repeat scroll 0 0 #F2F2F2;
                        border-bottom: 1px solid #CCCCCC;
                        border-right: 1px solid #CCCCCC;
                        height: 30px;
                        padding: 3px;
                    }
                    .rbtnlExamType
                    {
                    }
                    .rbtnlGroupName input
                    {
                        margin-left: 10px;
                    }
                </style>
                <tbody>
                
                    <tr>
                        <td class="TableHeader" align="center" colspan="6" height="90px">
                            &nbsp;<font size="5">暂    支    单</font>
                        </td>
                    </tr>
                 <tr>
                        <td class="TableContent" >
                            部门:
                        </td>
                        <td align="left" class="TableData">
                            <asp:Label ID="lblApplicationDepartment" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="TableContent" >
                            店铺名称:
                        </td>
                        <td align="left" class="TableData">
                            <asp:Label ID="lblNickName" runat="server" Text=""></asp:Label>
                        </td>
                        <td  class="TableContent" width="10%">
                            付款日期:
                        </td>
                        <td align="left" class="TableData" >
                            <asp:Label ID="txtFinanceOkTime" runat="server" Text=""></asp:Label>
                        </td>
                         
                    </tr> 
                    <tr>
                        <td  class="TableContent" width="20%">
                            受款人和账号:
                        </td>
                        <td align="left" class="TableData" style="word-break: break-all" colspan="5" width="80%">
                            <asp:Label ID="txtApplicationPayee" runat="server" Text=""></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td  class="TableContent" width="20%">
                            暂支事由:
                        </td>
                        <td align="left" class="TableData" style="word-break: break-all" colspan="5" width="80%">
                            <asp:Label ID="txtTheAdvanceSubject" runat="server" Text=""></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td  class="TableContent" width="20%">
                            暂支金额:
                        </td>
                        <td align="left" class="TableData" colspan="3">
                            <asp:Label ID="txtTheAdvanceMoneyCapital" runat="server" Text=""></asp:Label>
                        </td> 
                        <td align="left" class="TableData" colspan="2">
                            <asp:Label ID="txtTheAdvanceMoneyLowerCase" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td  class="TableContent" width="20%">
                            预计归还日期:
                        </td>
                        <td align="left" class="TableData" colspan="3">
                            <asp:Label ID="txtForecastReturnTime" runat="server" Text=""></asp:Label>
                        </td> 
                        <td  class="TableContent" width="10%">
                            科目:
                        </td>
                        <td align="left" class="TableData" >
                            <asp:Label ID="txtSubject" runat="server" Text=""></asp:Label>
                        </td>
                    </tr> 
                    <tr>
                        <td class="TableContent">
                            部门主管:
                        </td>
                        <td align="left" class="TableData" width="20%" >
                            <asp:Label ID="txtManagerPeople" runat="server" Text=""></asp:Label>
                        </td>
                        <td  class="TableContent" width="10%">
                            申请人:
                        </td>
                        <td align="left" class="TableData" width="20%">
                            <asp:Label ID="txtApplicants" runat="server" Text=""></asp:Label>
                        </td>
                         <td  class="TableContent" width="10%">
                            受款人:
                        </td>
                        <td align="left" class="TableData" width="20%">
                            <asp:Label ID="txtRecipientsId" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table width="650" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="2" align="center">
                   
                   <%-- <asp:Button ID="btnPrinView"  SkinID="button4" runat="server" Text="打印预览"  OnClientClick="win_preview(); return false;"
                      Visible="<% $CRMIsActionAllowed:ManageFinance.PrintAdvanceApplication.PrinView %>"/>
         
         
                    <asp:Button ID="btnPrint"  SkinID="button4" runat="server" Text="打 印"  OnClientClick="print_print();"
                      Visible="<% $CRMIsActionAllowed:ManageFinance.PrintAdvanceApplication.Print %>"/>

                    <input type="button" id="btnPrinView" value="打印预览" class="SmallButtonB" 
                    onclick="win_preview(); return false;" />--%>
                     
                    <asp:Button ID="hidBtnFinanceOk" runat="server" Style="width: 0px; display: none;" ToolTip="财务确认"   OnClick="hidBtnFinanceOk_Click" />  
                    <input id="btnPrint" type="button" value="打 印" runat="server" class="SmallButtonA"
                     onclick="print_print();"  />
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
