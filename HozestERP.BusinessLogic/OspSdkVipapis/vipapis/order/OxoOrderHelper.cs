using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OxoOrderHelper : TBeanSerializer<OxoOrder>
	{
		
		public static OxoOrderHelper OBJ = new OxoOrderHelper();
		
		public static OxoOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OxoOrder structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("barcodes".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OxoOrderDetail> value;
						
						value = new List<vipapis.order.OxoOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OxoOrderDetail elem1;
								
								elem1 = new vipapis.order.OxoOrderDetail();
								vipapis.order.OxoOrderDetailHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBarcodes(value);
					}
					
					
					
					
					
					if ("business_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBusiness_type(value);
					}
					
					
					
					
					
					if ("order_source".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OxoOrderSource> value;
						
						value = new List<vipapis.order.OxoOrderSource>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OxoOrderSource elem3;
								
								elem3 = new vipapis.order.OxoOrderSource();
								vipapis.order.OxoOrderSourceHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_source(value);
					}
					
					
					
					
					
					if ("province_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince_code(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("city_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity_code(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("district_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict_code(value);
					}
					
					
					
					
					
					if ("district".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict(value);
					}
					
					
					
					
					
					if ("invoice_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoice_type(value);
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
		
		
		public void Write(OxoOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcodes() != null) {
				
				oprot.WriteFieldBegin("barcodes");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OxoOrderDetail _item0 in structs.GetBarcodes()){
					
					
					vipapis.order.OxoOrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBusiness_type() != null) {
				
				oprot.WriteFieldBegin("business_type");
				oprot.WriteI32((int)structs.GetBusiness_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_source() != null) {
				
				oprot.WriteFieldBegin("order_source");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OxoOrderSource _item0 in structs.GetOrder_source()){
					
					
					vipapis.order.OxoOrderSourceHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince_code() != null) {
				
				oprot.WriteFieldBegin("province_code");
				oprot.WriteString(structs.GetProvince_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity_code() != null) {
				
				oprot.WriteFieldBegin("city_code");
				oprot.WriteString(structs.GetCity_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDistrict_code() != null) {
				
				oprot.WriteFieldBegin("district_code");
				oprot.WriteString(structs.GetDistrict_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDistrict() != null) {
				
				oprot.WriteFieldBegin("district");
				oprot.WriteString(structs.GetDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_type() != null) {
				
				oprot.WriteFieldBegin("invoice_type");
				oprot.WriteI32((int)structs.GetInvoice_type()); 
				
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OxoOrder bean){
			
			
		}
		
	}
	
}