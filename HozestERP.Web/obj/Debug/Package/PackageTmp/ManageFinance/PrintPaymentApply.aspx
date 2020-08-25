<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPaymentApply.aspx.cs" Inherits="HozestERP.Web.ManageFinance.PrintPaymentApply" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
            alert("操作成功！")
        }

        function CreateOneFormPage() {
            //LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP = getLodop();
            LODOP.ADD_PRINT_HTM(50, 80, 500, 700, document.getElementById("print_body").innerHTML);
            
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
                        <td class="TableHeader" align="center" colspan="4" height="90px">
                            &nbsp;<font size="5">宁波市和众互联科技股份有限公司付款申请单</font>
                        </td>
                        </tr>
                        <tr>
                            <td  class="TableContent" width="15%" align="center">
                                申请部门：
                            </td>
                            <td align="left" class="TableData" width="50%">
                                <asp:Label ID="txtDepartment" runat="server" Text=""></asp:Label>
                            </td> 
                            <td  class="TableContent" width="15%" align="center">
                                申请日期：
                            </td>
                            <td align="left" class="TableData" width="20%">
                                <asp:Label ID="txtYear" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;年"></asp:Label>
                                <asp:Label ID="txtMonth" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;月"></asp:Label>
                                <asp:Label ID="txtDay" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;日"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td  class="TableContent" width="15%" align="center" style="height:80px">
                                请款原因：
                            </td>
                            <td align="left" class="TableData" width="50%">
                                <asp:Label ID="txtReason" runat="server" Text=""></asp:Label>
                            </td> 
                            <td  class="TableContent" width="15%" align="center">
                                合同编号：
                            </td>
                            <td align="left" class="TableData" width="20%">
                                <asp:Label ID="txtNum" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td  class="TableContent" width="15%" align="center">
                                付款金额：
                            </td>
                            <td align="left" class="TableData" colspan="3">
                                <asp:Label ID="txtRMB"  runat="server" Text="人民币（大写）" Width="70%"></asp:Label>
                                <asp:Label ID="RMB"  runat="server" Text="¥："></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td  class="TableContent" width="15%" align="center">
                                付款方式：
                            </td>
                            <td align="left" class="TableData" width="50%">
                                <asp:CheckBox ID="chk1" runat="server" Text="&nbsp;&nbsp;支付宝" Width="28%"/>
                                <asp:CheckBox ID="chk2"  runat="server" Text="&nbsp;&nbsp;现金" Width="22%"/>
                                <asp:CheckBox ID="chk3"  runat="server" Text="&nbsp;&nbsp;支票" Width="22%"/>
                                <asp:CheckBox ID="chk4"  runat="server" Text="&nbsp;&nbsp;汇款" Width="22%"/>
                            </td>
                            <td  class="TableContent" width="15%" align="center">
                                用款日期：
                            </td>
                            <td align="left" class="TableData" width="20%">
                                <asp:Label ID="txtDate" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td  class="TableContent" width="15%" align="center">
                                开户银行</td>
                            <td align="left" class="TableData" width="50%">
                                <asp:Label ID="txtBankCreate" runat="server" Text=""></asp:Label>
                            </td>
                            <td  class="TableContent" width="15%" align="center">
                                &nbsp;</td>
                            <td align="left" class="TableData" width="50%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td  class="TableContent" width="15%" align="center">
                                银行账户：
                            </td>
                            <td align="left" class="TableData" width="50%">
                                <asp:Label ID="txtBankNo" runat="server" Text=""></asp:Label>
                            </td>
                            <td  class="TableContent" width="15%" align="center">
                                实付金额：
                            </td>
                            <td align="left" class="TableData" width="50%">
                                <asp:Label ID="txtPrice" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td  class="TableContent" width="15%" align="center">
                                收款单位：
                            </td>
                            <td align="left" class="TableData" width="50%">
                                <asp:Label ID="txtCompany" runat="server" Text=""></asp:Label>
                            </td>
                            <td  class="TableContent" width="15%" align="center">
                                领款人：
                            </td>
                            <td align="left" class="TableData" width="50%">
                                <asp:Label ID="txtPerson" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            <div class="TableBlock" style="margin: 5px;border:hidden;width:650px" align="left">
                <asp:Label  runat="server" Text="总经理：" Width="9%"></asp:Label>
                <asp:Label ID="Label1" runat="server" Width="18%"></asp:Label>
                <asp:Label  runat="server" Text="财务主管：" Width="15%" style="text-align: right"></asp:Label>
                <asp:Label ID="txtFin" runat="server" Width="22%"></asp:Label>
                <asp:Label  runat="server" Text="经办人：" Width="15%" style="text-align: right"></asp:Label>
                                <asp:Label ID="txtPerson0" runat="server" Text="" Width="10%"></asp:Label>
            </div>
            </div>
            <ext:ResourceManager ID="ResourceManager1" runat="server"/>
            <div class="TableBlock" style="margin: 5px;border:hidden;width:650px" align="center">
                <ext:Button runat="server" Text="打印">
                    <Listeners>
                        <Click Handler="print_print();"/>
                    </Listeners>
                </ext:Button>
            </div>
        </center>
    </form>
</body>
</html>
