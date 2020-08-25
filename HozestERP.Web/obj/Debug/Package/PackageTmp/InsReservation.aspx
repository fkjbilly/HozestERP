<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsReservation.aspx.cs" Inherits="HozestERP.Web.InsReservation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<link type="text/css" rel="stylesheet" href="GridViewMakeover/css/style.css" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"/>
<style type="text/css">
#customers
  {
  background: #FFFFFF;
  width:100%;
  border-collapse:collapse;
  }

#customers td, #customers th 
  {
  font-size:1em;
  border-right: #717171 0px solid; border-top: #717171 0px solid; border-left: #717171 0px solid; border-bottom: #EDEDED 1px solid;

  padding:7px 7px 2px 7px;
  }
#customers th 
  {
  font-size:1em;


  color:#000000;
  }
#customers tr.alt td 
  {
  color:#000000;
  background-color:#EAF2D3;
  }
</style>
</head>
<body>
<form id="form1" runat="server"> 
 
    <center><asp:Image ID="log" runat="server" ImageUrl="GridViewMakeover/css/logo.png" Width="70%"/>
        <div class="box">
        <div class="search_box" >
            <br/> <asp:Label ID="Label1" text="订单编号&nbsp;&nbsp;&nbsp;&nbsp;" runat="server" CssClass="lblStyle"></asp:Label>
            <asp:TextBox ID="txtNumber" runat="server" CssClass="tetStyle" value="请输入订单编号" onFocus="this.value = '';" onBlur="if (this.value == '') {this.value = '请输入订单编号';}" ForeColor="Gray"></asp:TextBox><br/><hr width="90%" color="#EDEDED" size=1 />
        </div>
        <div class="search_box2" >
            <asp:Label ID="Label6" text="买&nbsp;&nbsp;家&nbsp;&nbsp;ID&nbsp;&nbsp;&nbsp;&nbsp;" runat="server" CssClass="lblStyle"></asp:Label>
            <asp:TextBox ID="txtWantID" runat="server"  CssClass="tetStyle" value="请输入买家ID" onFocus="this.value = '';" onBlur="if (this.value == '') {this.value = '请输入买家ID';}" ForeColor="Gray"></asp:TextBox><br/><hr width="90%" color="#EDEDED" size=1 />
        </div>
        <div class="search_box3" >
            <asp:Label ID="Label2" text="姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;" runat="server" CssClass="lblStyle"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"  CssClass="tetStyle" value="请输入姓名" onFocus="this.value = '';" onBlur="if (this.value == '') {this.value = '请输入姓名';}" ForeColor="Gray"></asp:TextBox><br/><hr width="90%" color="#EDEDED" size=1 />
        </div>
        <div class="search_box4" >
           <asp:Label ID="Label3" text="电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话&nbsp;&nbsp;&nbsp;&nbsp;" runat="server" CssClass="lblStyle"></asp:Label>
            <asp:TextBox ID="txtTel" runat="server"  CssClass="tetStyle" value="请输入电话" onFocus="this.value = '';" onBlur="if (this.value == '') {this.value = '请输入电话';}" ForeColor="Gray"></asp:TextBox><br/><hr width="90%" color="#EDEDED" size=1 />
        </div>
        <div class="search_box5" >
            <asp:Label ID="Label4" text="&nbsp;安装地址&nbsp;&nbsp;&nbsp;&nbsp;" runat="server" CssClass="lblStyle"></asp:Label>
 
            <asp:TextBox ID="txtAddress" runat="server"  CssClass="tetStyle" Text="请输入安装地址" OnFocus="javascript:if(this.value=='请输入安装地址') {this.value='';}" OnBlur="javascript:if(this.value==''){this.value='请输入安装地址';}" ForeColor="Gray"></asp:TextBox> <br/><hr width="90%" color="#EDEDED" size=1 />   <br/>          
        </div>
        </div><br /><asp:Label ID="Label7" text="标准阳台提供免费安装, 特殊阳台*需要额外" runat="server" CssClass="lblStyle2"></asp:Label><br />
        <asp:Label ID="Label8" text="收费（安装现场收取）, 收费标准说明如下:" runat="server" CssClass="lblStyle2"></asp:Label><br /><br />
        </center>

        <center>
        <div class="box">
        <asp:GridView ID="gvXMProduct" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            SkinID="GridViewThemen" OnRowDataBound="gvXMProduct_RowDataBound"
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt">

            <Columns>
                <asp:TemplateField  >
                    <HeaderStyle CssClass="gvHideHeader" />
                    <ItemStyle HorizontalAlign="Center" Height="40px" /> 
                    <ItemTemplate>
                            <%# Eval("type")%>
                    <asp:Label ID="lblType" runat="server"></asp:Label> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  >
                    <HeaderStyle CssClass="gvHideHeader" />
                    <ItemStyle  HorizontalAlign="Center" /> 
                    <ItemTemplate>
                        <%--<asp:DropDownList ID="ddlDemand" runat="server" Width="100%">
                        </asp:DropDownList>--%> 
                        
                            <asp:RadioButtonList ID="ddlDemand" runat="server" AutoPostBack="true" 
                                OnSelectedIndexChanged="ddlDemand_SelectedIndexChanged" RepeatColumns="2" 
                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="gvHideHeader" />
                    <ItemStyle HorizontalAlign="Center" /> 
                    <ItemTemplate>
                    <asp:Label ID="Label4" text="金额(元):" runat="server" CssClass="lblStyle"></asp:Label>
                    <asp:Label ID="lblPrice" runat="server" align="center"></asp:Label>    
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
        </div></center>
        <br/>
        <center>
            <asp:Button ID="Save" runat="server" Text="确认提交"  OnClick="btnSave_Click" class="button gray"/>     
        </center>
        
        <center>
            <div class="box">

                <table id="customers">
                <tr>
                <td colspan="3" align="center"><strong><asp:Label ID="Label9" text="*特殊阳台收费说明" runat="server" CssClass="lblStyle3"></asp:Label></strong><br />
                <asp:Label ID="Label10" text="注:由于各家阳台安装条件各异," runat="server" CssClass="lblStyle4"></asp:Label><br />
                <asp:Label ID="Label11" text="以下收费仅供参考,具体收费以实际安装" runat="server" CssClass="lblStyle4"></asp:Label><br />
                <asp:Label ID="Label12" text="情况为准,如有不合理收费请联系本店客服。" runat="server" CssClass="lblStyle4"></asp:Label><br /><br />
                </td>

                </tr>

                <tr >
                <th align="left">阳台情况</th><th>收费标准(元)</th><th>备注</th>
                </tr>

                <tr>
                <td align="left">侧墙面保温层</td><td align="center">30</td><td align="center">不含特殊螺丝费</td>
                </tr>

                <tr >
                <td>瓷砖</td><td align="center">20</td><td align="center">不含特殊螺丝费</td>
                </tr>

                <tr >
                <td>电动晾衣架阳台吊顶</td><td align="center">40-50</td><td align="center">不含特殊螺丝费</td>
                </tr>

                <tr >
                <td>手摇晾衣架阳台吊顶</td><td align="center">30-40</td><td align="center">不含特殊螺丝费</td>
                </tr>

                <tr >
                <td>其他特殊阳台<br />(阳光房\斜顶等)</td><td align="center">30-80</td><td align="center">不含特殊螺丝费</td>
                </tr>
                <tr >
                <td>超高阳台<br />3.2米-4.5米以上</td><td align="center">3.2米-4.5米50-80<br />4.5米以上90-150</td><td align="center">不含特殊螺丝费<br />不含钢丝绳费用</td>
                </tr>
                <tr >
                <td>手动晾衣架拆旧</td><td align="center">20-30</td><td align="center"></td>
                </tr>
                <tr >
                <td>杆子剪裁</td><td align="center">10-20</td><td align="center"></td>
                </tr>
                <tr >
                <td>超高吊顶<br />(35厘米以上)</td><td align="center">50</td><td align="center"></td>
                </tr>
                <tr >
                <td>部分偏远区域<br />安装师傅不能满足</td><td align="center">远程30-50</td><td align="center">部分区域师傅不会安装<br />订单购买前需要确认</td>
                </tr>
                <tr >
                <td>空跑费60元起<br />&nbsp;</td><td align="center">远程30-50<br />&nbsp;</td><br />&nbsp;<td align="center"></td>
                </tr>
                </table>
                <br />&nbsp;
            </div> 
            </center> 
    </form> 
</body>
</html>
