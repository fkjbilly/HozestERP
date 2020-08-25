using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class OrderListByCreateTimeHelper : BeanSerializer<OrderListByCreateTime>
	{
		
		public static OrderListByCreateTimeHelper OBJ = new OrderListByCreateTimeHelper();
		
		public static OrderListByCreateTimeHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderListByCreateTime structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
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
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
					}
					
					
					
					
					
					if ("postcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPostcode(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("country_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry_id(value);
					}
					
					
					
					
					
					if ("invoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriage(value);
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
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("ex_fav_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEx_fav_money(value);
					}
					
					
					
					
					
					if ("favourable_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFavourable_money(value);
					}
					
					
					
					
					
					if ("product_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_money(value);
					}
					
					
					
					
					
					if ("add_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAdd_time(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
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
		
		
		public void Write(OrderListByCreateTime structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteString(structs.GetOrder_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyer() != null) {
				
				oprot.WriteFieldBegin("buyer");
				oprot.WriteString(structs.GetBuyer());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPostcode() != null) {
				
				oprot.WriteFieldBegin("postcode");
				oprot.WriteString(structs.GetPostcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry_id() != null) {
				
				oprot.WriteFieldBegin("country_id");
				oprot.WriteString(structs.GetCountry_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice() != null) {
				
				oprot.WriteFieldBegin("invoice");
				oprot.WriteString(structs.GetInvoice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteString(structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_day() != null) {
				
				oprot.WriteFieldBegin("transport_day");
				oprot.WriteString(structs.GetTransport_day());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteString(structs.GetVendor_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEx_fav_money() != null) {
				
				oprot.WriteFieldBegin("ex_fav_money");
				oprot.WriteString(structs.GetEx_fav_money());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavourable_money() != null) {
				
				oprot.WriteFieldBegin("favourable_money");
				oprot.WriteString(structs.GetFavourable_money());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_money() != null) {
				
				oprot.WriteFieldBegin("product_money");
				oprot.WriteString(structs.GetProduct_money());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAdd_time() != null) {
				
				oprot.WriteFieldBegin("add_time");
				oprot.WriteString(structs.GetAdd_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderListByCreateTime bean){
			
			
		}
		
	}
	
}