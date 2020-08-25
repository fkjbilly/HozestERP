<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="XMAfterSalesSalary.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMAfterSalesSalary" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/GridNevigator.ascx" TagName="GridNevigator" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/UpdaeProcess.ascx" TagName="UpdateProcess" TagPrefix="SHIBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
<script src="../Script/CommonManager.js" type="text/javascript"></script>
   <style type="text/css">
  
       .headbackground
        { 
            border-top-color:transparent;
            border-bottom-color:transparent;
            border-left-color:transparent;
            border-right-color:transparent; 
        }
        
        .gridlist {
            background: none repeat 0% 0% #FFF;
            color:#444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border:0px;
        }
          
</style> 
<script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript">
        function ShowHidde(sid, evt) {
            var b = "";
            var openType = "";
            var customerID = sid;
            //还原其他所有行
            $("tr[id^=div]").each(function () {
                if (evt == null) { 
                    return;
                }
                var a = $(this).attr("id").replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = a; //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            });
            //如果点击同一个
            if (sid == b) {
                openType = "0";
                var a = b.replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = $(this).attr("id"); //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            } else {
                openType = "1";
                var objDiv = document.getElementById("div" + sid);
                if (window.ActiveXObject) {
                    objDiv.style.display = objDiv.style.display == "none" ? "block" : "none";
                }
                else {
                    objDiv.style.display = objDiv.style.display == "none" ? "table-row" : "none";
                }
                var imgid = 'img' + sid;
                document.getElementById(imgid).src = objDiv.style.display == "none" ? "../images/folder.gif" : "../images/folderopen.gif";
            }
        }

    function ShowSelectCustomerDetail(URL) {
        var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:800px;dialogHeight:450px;center:yes;");
        return true;
    }
    var GridCommand = function (commandName, record) {
        if (commandName == "Edit") {
        }
        else {
            Ext.MessageBox.confirm('提示信息', '确定删除您选中的记录吗？', function (btn) {
                if (btn == "yes") {
                    CompanyX.DeleteCustomer(record.CustomerID);
                }
            });
        }
    }
    var rowclickFn = function (grid, rowindex, e) {
        GridCommand("Delete", grid.getSelectionModel().getSelected().data);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
      <tr>
        <%--<td style="width: 70px" align="right">
               开始日期:
            </td>
        <td style="width: 120px;">
               <input id="ddlBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server" style=" width:100%;"/>
            </td>--%>

        <%--<td style="width: 70px" align="right">
               结束日期:
            </td>
        <td style="width: 120px;">
               <input id="ddlEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server" style=" width:100%;"/>
            </td>--%>
        <td style="width: 70px" align="right">
               月份:
            </td>
        <td style="width: 120px;">
               <input id="ddlMonth" onfocus="WdatePicker({dateFmt:'yyyy-MM'})" class="Wdate" runat="server" style=" width:100%;"/>
            </td>

        <td style="width: 70px" align="right">
               组别: 
            </td>
        <td style="width: 120px;">
               <asp:DropDownList ID="ddlGroupID" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        <td style="width: 70px" align="right">
               姓名:
            </td>
        <td style="width: 120px;">
               <asp:TextBox runat="server" ID="ddlName" Width="100%"></asp:TextBox>
            </td>
        <td style="width: 70px" align="right">
               级别:
            </td>
        <td style="width: 120px;">
               <asp:DropDownList ID="ddlRank" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        <td style="text-align: right">
           <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMAfterSalesSalary.Search %>" />
           <asp:Button ID="btnExport" runat="server" Text="导出" OnClick="btnExport_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMAfterSalesSalary.Export %>" />
           <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"   OnClick="btnRefresh_Click" />
        </td> 
      </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
        OnRowDataBound="grdvClients_RowDataBound" OnRowEditing="grdvClients_RowEditing" OnRowUpdating="grdvClients_RowUpdating" OnRowCancelingEdit="grdvClients_RowCancelingEdit"> 
        <Columns>
    
         <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <a href="javascript:void(0);"><img id='img<%# Eval("ID")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("ID")%>',event)" /></a>
                <%# Container.DataItemIndex + 1 %>
                <asp:HiddenField ID="hdDId" Value='<%# Eval("ID")%>' runat="server" />
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="30px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> 
         <asp:TemplateField HeaderText="组别" SortExpression="Group">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
               <asp:Label ID="lblGroup" runat="server" Text='<%# Eval("Group")==null?"":Eval("Group").ToString().Length>15?Eval("Group").ToString().Substring(0,15)+"..":Eval("Group").ToString()%>' ToolTip='<%# Eval("Group") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
          
         <asp:TemplateField HeaderText="客服"  SortExpression="Name">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")==null?"":Eval("Name").ToString().Length>15?Eval("Name").ToString().Substring(0,15)+"..":Eval("Name").ToString()%>' ToolTip='<%# Eval("Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="级别"  SortExpression="RankName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblRank" runat="server" Text='<%# Eval("RankName")==null?"":Eval("RankName").ToString().Length>15?Eval("RankName").ToString().Substring(0,15)+"..":Eval("RankName").ToString()%>' ToolTip='<%# Eval("RankName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="底薪"  SortExpression="BasicSalary">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblBasicSalary" runat="server" Text='<%# Eval("BasicSalary")==null?"":Eval("BasicSalary").ToString().Length>15?Eval("BasicSalary").ToString().Substring(0,15)+"..":Eval("BasicSalary").ToString()%>' ToolTip='<%# Eval("BasicSalary") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="奖金基数"  SortExpression="BonusBase">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblBonusBase" runat="server" Text='<%# Eval("BonusBase")==null?"":Eval("BonusBase").ToString().Length>15?Eval("BonusBase").ToString().Substring(0,15)+"..":Eval("BonusBase").ToString()%>' ToolTip='<%# Eval("BonusBase") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="KPI得分"  SortExpression="KPIScore">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblKPIScore" runat="server" Text='<%# Eval("KPIScore")==null?"":Eval("KPIScore").ToString().Length>25?Eval("KPIScore").ToString().Substring(0,25)+"..":Eval("KPIScore").ToString()%>' ToolTip='<%# Eval("KPIScore") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="实际奖金"  SortExpression="RealBonus">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblRealBonus" runat="server" Text='<%# Eval("RealBonus")==null?"":Eval("RealBonus").ToString().Length>15?Eval("RealBonus").ToString().Substring(0,15)+"..":Eval("RealBonus").ToString()%>' ToolTip='<%# Eval("RealBonus") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="合计"  SortExpression="Total">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total")==null?"":Eval("Total").ToString().Length>15?Eval("Total").ToString().Substring(0,15)+"..":Eval("Total").ToString()%>' ToolTip='<%# Eval("Total") %>'></asp:Label>

                    <!--下拉tr-->
                    <tr id='div<%#Eval("ID")%>' style=" background-color:White; display:none; border:0px;" class="gridlist"> 
                        <td colspan="100%" style=" width:100%; height:100%;">
                            <div style="background-color:White;">
                                <div style=" position: relative; left: 0px; overflow: auto;
                                    width: 100%;">

                                    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
                                        <tbody>  
                                            <tr>
                                                <th style='width: 9%;text-align:center;'>退货挽回率</th>
                                                <th style='width: 9%;text-align:center;'>挽回率得分</th>
                                                <th style='width: 9%;text-align:center;'>组内平均值</th>
                                                <th style='width: 9%;text-align:center;'>个人百分比</th>
                                                <th style='width: 6%;text-align:center;'>得分</th>
                                                <th style='width: 8%;text-align:center;'>响应时间</th>
                                                <th style='width: 6%;text-align:center;'>DSR</th>
                                                <th style='width: 8%;text-align:center;'>京东售后</th>
                                                <th style='width: 8%;text-align:center;'>售后出错</th>
                                                <th style='width: 12%;text-align:center;'>天猫综合指数</th>
                                                <th style='width: 8%;text-align:center;'>客户投诉</th>
                                                <th style='width: 8%;text-align:center;'>评价加分</th>                                    
                                            </tr>
                                            <%# Eval("tabKPI")%>
                                            <tr>
                                             <div style="background-color:White; width:100%; border:0px;" > 
                                            <td  colspan="100%"> 
                                                    
                                            
                                            </td> 
                                            </div>
                                            </tr>
                                            
                                               
                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
