using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class ReturnOrderHelper : TBeanSerializer<ReturnOrder>
	{
		
		public static ReturnOrderHelper OBJ = new ReturnOrderHelper();
		
		public static ReturnOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnOrder structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("return_source".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_source(value);
					}
					
					
					
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("erp_return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_return_sn(value);
					}
					
					
					
					
					
					if ("return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_sn(value);
					}
					
					
					
					
					
					if ("return_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_type(value);
					}
					
					
					
					
					
					if ("pay_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPay_type(value);
					}
					
					
					
					
					
					if ("self_reference".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSelf_reference(value);
					}
					
					
					
					
					
					if ("from_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFrom_warehouse(value);
					}
					
					
					
					
					
					if ("to_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTo_warehouse(value);
					}
					
					
					
					
					
					if ("line_count".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLine_count(value);
					}
					
					
					
					
					
					if ("consignee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConsignee(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("state".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetState(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("region".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRegion(value);
					}
					
					
					
					
					
					if ("town".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTown(value);
					}
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("postcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPostcode(value);
					}
					
					
					
					
					
					if ("area_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_id(value);
					}
					
					
					
					
					
					if ("telephone".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTelephone(value);
					}
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("to_email".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTo_email(value);
					}
					
					
					
					
					
					if ("cc_email".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCc_email(value);
					}
					
					
					
					
					
					if ("creater".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreater(value);
					}
					
					
					
					
					
					if ("creat_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreat_time(value);
					}
					
					
					
					
					
					if ("is_need_tidy_up".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_need_tidy_up(value);
					}
					
					
					
					
					
					if ("is_return_original_box".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_return_original_box(value);
					}
					
					
					
					
					
					if ("order_detail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.ReturnOrderDetail> value;
						
						value = new List<vipapis.overseas.ReturnOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.ReturnOrderDetail elem0;
								
								elem0 = new vipapis.overseas.ReturnOrderDetail();
								vipapis.overseas.ReturnOrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
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
		
		
		public void Write(ReturnOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturn_source() != null) {
				
				oprot.WriteFieldBegin("return_source");
				oprot.WriteString(structs.GetReturn_source());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_source can not be null!");
			}
			
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_code can not be null!");
			}
			
			
			if(structs.GetErp_return_sn() != null) {
				
				oprot.WriteFieldBegin("erp_return_sn");
				oprot.WriteString(structs.GetErp_return_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_return_sn can not be null!");
			}
			
			
			if(structs.GetReturn_sn() != null) {
				
				oprot.WriteFieldBegin("return_sn");
				oprot.WriteString(structs.GetReturn_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_sn can not be null!");
			}
			
			
			if(structs.GetReturn_type() != null) {
				
				oprot.WriteFieldBegin("return_type");
				oprot.WriteString(structs.GetReturn_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_type can not be null!");
			}
			
			
			if(structs.GetPay_type() != null) {
				
				oprot.WriteFieldBegin("pay_type");
				oprot.WriteString(structs.GetPay_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("pay_type can not be null!");
			}
			
			
			if(structs.GetSelf_reference() != null) {
				
				oprot.WriteFieldBegin("self_reference");
				oprot.WriteString(structs.GetSelf_reference());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFrom_warehouse() != null) {
				
				oprot.WriteFieldBegin("from_warehouse");
				oprot.WriteString(structs.GetFrom_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("from_warehouse can not be null!");
			}
			
			
			if(structs.GetTo_warehouse() != null) {
				
				oprot.WriteFieldBegin("to_warehouse");
				oprot.WriteString(structs.GetTo_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLine_count() != null) {
				
				oprot.WriteFieldBegin("line_count");
				oprot.WriteString(structs.GetLine_count());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("line_count can not be null!");
			}
			
			
			if(structs.GetConsignee() != null) {
				
				oprot.WriteFieldBegin("consignee");
				oprot.WriteString(structs.GetConsignee());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("consignee can not be null!");
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("country can not be null!");
			}
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteString(structs.GetState());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("state can not be null!");
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("city can not be null!");
			}
			
			
			if(structs.GetRegion() != null) {
				
				oprot.WriteFieldBegin("region");
				oprot.WriteString(structs.GetRegion());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTown() != null) {
				
				oprot.WriteFieldBegin("town");
				oprot.WriteString(structs.GetTown());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("address can not be null!");
			}
			
			
			if(structs.GetPostcode() != null) {
				
				oprot.WriteFieldBegin("postcode");
				oprot.WriteString(structs.GetPostcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_id() != null) {
				
				oprot.WriteFieldBegin("area_id");
				oprot.WriteString(structs.GetArea_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTelephone() != null) {
				
				oprot.WriteFieldBegin("telephone");
				oprot.WriteString(structs.GetTelephone());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTo_email() != null) {
				
				oprot.WriteFieldBegin("to_email");
				oprot.WriteString(structs.GetTo_email());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCc_email() != null) {
				
				oprot.WriteFieldBegin("cc_email");
				oprot.WriteString(structs.GetCc_email());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreater() != null) {
				
				oprot.WriteFieldBegin("creater");
				oprot.WriteString(structs.GetCreater());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("creater can not be null!");
			}
			
			
			if(structs.GetCreat_time() != null) {
				
				oprot.WriteFieldBegin("creat_time");
				oprot.WriteString(structs.GetCreat_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("creat_time can not be null!");
			}
			
			
			if(structs.GetIs_need_tidy_up() != null) {
				
				oprot.WriteFieldBegin("is_need_tidy_up");
				oprot.WriteString(structs.GetIs_need_tidy_up());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_return_original_box() != null) {
				
				oprot.WriteFieldBegin("is_return_original_box");
				oprot.WriteString(structs.GetIs_return_original_box());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_detail_list() != null) {
				
				oprot.WriteFieldBegin("order_detail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.ReturnOrderDetail _item0 in structs.GetOrder_detail_list()){
					
					
					vipapis.overseas.ReturnOrderDetailHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(ReturnOrder bean){
			
			
		}
		
	}
	
}