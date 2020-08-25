<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateTimePicker.ascx.cs"
    Inherits="HozestERP.Web.Modules.DateTimePicker" %>
<script type="text/javascript" language="javascript" src="<%=CommonHelper.GetStoreLocation()%>Modules/My97DatePicker/WdatePicker.js"></script>
<input type="text" class="Wdate" id="txtDateTime" style="width: 125px" name="txtDateTime"
    runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" />
