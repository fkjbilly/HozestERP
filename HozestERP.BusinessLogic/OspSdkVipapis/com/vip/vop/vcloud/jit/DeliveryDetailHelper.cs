using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class DeliveryDetailHelper : TBeanSerializer<DeliveryDetail>
	{
		
		public static DeliveryDetailHelper OBJ = new DeliveryDetailHelper();
		
		public static DeliveryDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorType(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("boxNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBoxNo(value);
					}
					
					
					
					
					
					if ("pickNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPickNo(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("productName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProductName(value);
					}
					
					
					
					
					
					if ("subPickNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSubPickNo(value);
					}
					
					
					
					
					
					if ("imageUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImageUrl(value);
					}
					
					
					
					
					
					if ("color".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetColor(value);
					}
					
					
					
					
					
					if ("colorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetColorName(value);
					}
					
					
					
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
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
		
		
		public void Write(DeliveryDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorType() != null) {
				
				oprot.WriteFieldBegin("vendorType");
				oprot.WriteString(structs.GetVendorType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBoxNo() != null) {
				
				oprot.WriteFieldBegin("boxNo");
				oprot.WriteString(structs.GetBoxNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPickNo() != null) {
				
				oprot.WriteFieldBegin("pickNo");
				oprot.WriteString(structs.GetPickNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProductName() != null) {
				
				oprot.WriteFieldBegin("productName");
				oprot.WriteString(structs.GetProductName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubPickNo() != null) {
				
				oprot.WriteFieldBegin("subPickNo");
				oprot.WriteString(structs.GetSubPickNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImageUrl() != null) {
				
				oprot.WriteFieldBegin("imageUrl");
				oprot.WriteString(structs.GetImageUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetColor() != null) {
				
				oprot.WriteFieldBegin("color");
				oprot.WriteString(structs.GetColor());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetColorName() != null) {
				
				oprot.WriteFieldBegin("colorName");
				oprot.WriteString(structs.GetColorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryDetail bean){
			
			
		}
		
	}
	
}