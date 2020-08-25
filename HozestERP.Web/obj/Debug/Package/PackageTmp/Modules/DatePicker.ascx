<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs" Inherits="HozestERP.Web.Modules.DatePicker" %>

<asp:TextBox runat="server" ID="txtDateTime" />
<asp:ImageButton runat="Server" ID="btnCalendar" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="显示日历" />
<br />
<ajaxToolkit:CalendarExtender runat="server" ID="ajaxCalendar" TargetControlID="txtDateTime" PopupButtonID="btnCalendar" /> 