using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class SaleOrderResultHelper : TBeanSerializer<SaleOrderResult>
	{
		
		public static SaleOrderResultHelper OBJ = new SaleOrderResultHelper();
		
		public static SaleOrderResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SaleOrderResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sales_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_id(value);
					}
					
					
					
					
					
					if ("order_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_no(value);
					}
					
					
					
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("order_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_type(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("transport_day".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_day(value);
					}
					
					
					
					
					
					if ("order_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_status(value);
					}
					
					
					
					
					
					if ("buyer".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyer(value);
					}
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
					}
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("user_type_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUser_type_name(value);
					}
					
					
					
					
					
					if ("user_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUser_name(value);
					}
					
					
					
					
					
					if ("goHTS_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoHTS_money(value);
					}
					
					
					
					
					
					if ("chinaFreightForwarding".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetChinaFreightForwarding(value);
					}
					
					
					
					
					
					if ("globalFreightForwarding".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGlobalFreightForwarding(value);
					}
					
					
					
					
					
					if ("order_detail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.OrderDetail> value;
						
						value = new List<vipapis.overseas.OrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.OrderDetail elem1;
								
								elem1 = new vipapis.overseas.OrderDetail();
								vipapis.overseas.OrderDetailHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_detail_list(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(SaleOrderResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSales_id() != null) {
				
				oprot.WriteFieldBegin("sales_id");
				oprot.WriteString(structs.GetSales_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sales_id can not be null!");
			}
			
			
			if(structs.GetOrder_no() != null) {
				
				oprot.WriteFieldBegin("order_no");
				oprot.WriteString(structs.GetOrder_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_no can not be null!");
			}
			
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetOrder_type() != null) {
				
				oprot.WriteFieldBegin("order_type");
				oprot.WriteString(structs.GetOrder_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_type can not be null!");
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("create_time can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("remark can not be null!");
			}
			
			
			if(structs.GetTransport_day() != null) {
				
				oprot.WriteFieldBegin("transport_day");
				oprot.WriteString(structs.GetTransport_day());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transport_day can not be null!");
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteString(structs.GetOrder_status());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_status can not be null!");
			}
			
			
			if(structs.GetBuyer() != null) {
				
				oprot.WriteFieldBegin("buyer");
				oprot.WriteString(structs.GetBuyer());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("buyer can not be null!");
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("address can not be null!");
			}
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("tel can not be null!");
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("mobile can not be null!");
			}
			
			
			if(structs.GetUser_type_name() != null) {
				
				oprot.WriteFieldBegin("user_type_name");
				oprot.WriteString(structs.GetUser_type_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("user_type_name can not be null!");
			}
			
			
			if(structs.GetUser_name() != null) {
				
				oprot.WriteFieldBegin("user_name");
				oprot.WriteString(structs.GetUser_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("user_name can not be null!");
			}
			
			
			if(structs.GetGoHTS_money() != null) {
				
				oprot.WriteFieldBegin("goHTS_money");
				oprot.WriteString(structs.GetGoHTS_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goHTS_money can not be null!");
			}
			
			
			if(structs.GetChinaFreightForwarding() != null) {
				
				oprot.WriteFieldBegin("chinaFreightForwarding");
				oprot.WriteString(structs.GetChinaFreightForwarding());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("chinaFreightForwarding can not be null!");
			}
			
			
			if(structs.GetGlobalFreightForwarding() != null) {
				
				oprot.WriteFieldBegin("globalFreightForwarding");
				oprot.WriteString(structs.GetGlobalFreightForwarding());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("globalFreightForwarding can not be null!");
			}
			
			
			if(structs.GetOrder_detail_list() != null) {
				
				oprot.WriteFieldBegin("order_detail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.OrderDetail _item0 in structs.GetOrder_detail_list()){
					
					
					vipapis.overseas.OrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_detail_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SaleOrderResult bean){
			
			
		}
		
	}
	
}