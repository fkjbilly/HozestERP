using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsReturnOrderHeaderHelper : TBeanSerializer<OutWmsReturnOrderHeader>
	{
		
		public static OutWmsReturnOrderHeaderHelper OBJ = new OutWmsReturnOrderHeaderHelper();
		
		public static OutWmsReturnOrderHeaderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsReturnOrderHeader structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("return_source".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_source(value);
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
					
					
					
					
					
					if ("po".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo(value);
					}
					
					
					
					
					
					if ("line_count".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
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
					
					
					
					
					
					if ("erp_creater".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_creater(value);
					}
					
					
					
					
					
					if ("erp_create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_create_time(value);
					}
					
					
					
					
					
					if ("ship_to".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShip_to(value);
					}
					
					
					
					
					
					if ("self_reference".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSelf_reference(value);
					}
					
					
					
					
					
					if ("is_return_original_box".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_return_original_box(value);
					}
					
					
					
					
					
					if ("is_need_tidy_up".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_need_tidy_up(value);
					}
					
					
					
					
					
					if ("detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail();
								com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDetail(value);
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
		
		
		public void Write(OutWmsReturnOrderHeader structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetReturn_source() != null) {
				
				oprot.WriteFieldBegin("return_source");
				oprot.WriteString(structs.GetReturn_source());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_source can not be null!");
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
			
			
			if(structs.GetPo() != null) {
				
				oprot.WriteFieldBegin("po");
				oprot.WriteString(structs.GetPo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po can not be null!");
			}
			
			
			if(structs.GetLine_count() != null) {
				
				oprot.WriteFieldBegin("line_count");
				oprot.WriteI64((long)structs.GetLine_count()); 
				
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
			
			else{
				throw new ArgumentException("region can not be null!");
			}
			
			
			if(structs.GetTown() != null) {
				
				oprot.WriteFieldBegin("town");
				oprot.WriteString(structs.GetTown());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("town can not be null!");
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
			
			else{
				throw new ArgumentException("postcode can not be null!");
			}
			
			
			if(structs.GetArea_id() != null) {
				
				oprot.WriteFieldBegin("area_id");
				oprot.WriteString(structs.GetArea_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("area_id can not be null!");
			}
			
			
			if(structs.GetTelephone() != null) {
				
				oprot.WriteFieldBegin("telephone");
				oprot.WriteString(structs.GetTelephone());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("telephone can not be null!");
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("mobile can not be null!");
			}
			
			
			if(structs.GetTo_email() != null) {
				
				oprot.WriteFieldBegin("to_email");
				oprot.WriteString(structs.GetTo_email());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("to_email can not be null!");
			}
			
			
			if(structs.GetCc_email() != null) {
				
				oprot.WriteFieldBegin("cc_email");
				oprot.WriteString(structs.GetCc_email());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cc_email can not be null!");
			}
			
			
			if(structs.GetErp_creater() != null) {
				
				oprot.WriteFieldBegin("erp_creater");
				oprot.WriteString(structs.GetErp_creater());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_creater can not be null!");
			}
			
			
			if(structs.GetErp_create_time() != null) {
				
				oprot.WriteFieldBegin("erp_create_time");
				oprot.WriteString(structs.GetErp_create_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_create_time can not be null!");
			}
			
			
			if(structs.GetShip_to() != null) {
				
				oprot.WriteFieldBegin("ship_to");
				oprot.WriteString(structs.GetShip_to());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ship_to can not be null!");
			}
			
			
			if(structs.GetSelf_reference() != null) {
				
				oprot.WriteFieldBegin("self_reference");
				oprot.WriteI32((int)structs.GetSelf_reference()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("self_reference can not be null!");
			}
			
			
			if(structs.GetIs_return_original_box() != null) {
				
				oprot.WriteFieldBegin("is_return_original_box");
				oprot.WriteI32((int)structs.GetIs_return_original_box()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_return_original_box can not be null!");
			}
			
			
			if(structs.GetIs_need_tidy_up() != null) {
				
				oprot.WriteFieldBegin("is_need_tidy_up");
				oprot.WriteI32((int)structs.GetIs_need_tidy_up()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_need_tidy_up can not be null!");
			}
			
			
			if(structs.GetDetail() != null) {
				
				oprot.WriteFieldBegin("detail");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail _item0 in structs.GetDetail()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsReturnOrderHeader bean){
			
			
		}
		
	}
	
}