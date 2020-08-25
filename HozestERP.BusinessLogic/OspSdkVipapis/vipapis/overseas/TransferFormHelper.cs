using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class TransferFormHelper : TBeanSerializer<TransferForm>
	{
		
		public static TransferFormHelper OBJ = new TransferFormHelper();
		
		public static TransferFormHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TransferForm structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transfer_source".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransfer_source(value);
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
					
					
					
					
					
					if ("erp_transfer_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_transfer_sn(value);
					}
					
					
					
					
					
					if ("transfer_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransfer_sn(value);
					}
					
					
					
					
					
					if ("transfer_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransfer_type(value);
					}
					
					
					
					
					
					if ("pay_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPay_type(value);
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
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetLine_count(value);
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
					
					
					
					
					
					if ("area_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_id(value);
					}
					
					
					
					
					
					if ("product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.ProductItem> value;
						
						value = new List<vipapis.overseas.ProductItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.ProductItem elem0;
								
								elem0 = new vipapis.overseas.ProductItem();
								vipapis.overseas.ProductItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProduct_list(value);
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
		
		
		public void Write(TransferForm structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransfer_source() != null) {
				
				oprot.WriteFieldBegin("transfer_source");
				oprot.WriteString(structs.GetTransfer_source());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transfer_source can not be null!");
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
			
			
			if(structs.GetErp_transfer_sn() != null) {
				
				oprot.WriteFieldBegin("erp_transfer_sn");
				oprot.WriteString(structs.GetErp_transfer_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_transfer_sn can not be null!");
			}
			
			
			if(structs.GetTransfer_sn() != null) {
				
				oprot.WriteFieldBegin("transfer_sn");
				oprot.WriteString(structs.GetTransfer_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transfer_sn can not be null!");
			}
			
			
			if(structs.GetTransfer_type() != null) {
				
				oprot.WriteFieldBegin("transfer_type");
				oprot.WriteString(structs.GetTransfer_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transfer_type can not be null!");
			}
			
			
			if(structs.GetPay_type() != null) {
				
				oprot.WriteFieldBegin("pay_type");
				oprot.WriteString(structs.GetPay_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("pay_type can not be null!");
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
			
			else{
				throw new ArgumentException("to_warehouse can not be null!");
			}
			
			
			if(structs.GetLine_count() != null) {
				
				oprot.WriteFieldBegin("line_count");
				oprot.WriteI64((long)structs.GetLine_count()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("line_count can not be null!");
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
			
			
			if(structs.GetArea_id() != null) {
				
				oprot.WriteFieldBegin("area_id");
				oprot.WriteString(structs.GetArea_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_list() != null) {
				
				oprot.WriteFieldBegin("product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.ProductItem _item0 in structs.GetProduct_list()){
					
					
					vipapis.overseas.ProductItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TransferForm bean){
			
			
		}
		
	}
	
}