using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.product{
	
	
	
	public class ProductSkuStatusHelper : TBeanSerializer<ProductSkuStatus>
	{
		
		public static ProductSkuStatusHelper OBJ = new ProductSkuStatusHelper();
		
		public static ProductSkuStatusHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductSkuStatus structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("partnerId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPartnerId(value);
					}
					
					
					
					
					
					if ("skuId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSkuId(value);
					}
					
					
					
					
					
					if ("sku".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSku(value);
					}
					
					
					
					
					
					if ("vdgValidateStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetVdgValidateStatus(value);
					}
					
					
					
					
					
					if ("pushVdgStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetPushVdgStatus(value);
					}
					
					
					
					
					
					if ("pdcValidateStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetPdcValidateStatus(value);
					}
					
					
					
					
					
					if ("pushPdcStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetPushPdcStatus(value);
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
		
		
		public void Write(ProductSkuStatus structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPartnerId() != null) {
				
				oprot.WriteFieldBegin("partnerId");
				oprot.WriteI64((long)structs.GetPartnerId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSkuId() != null) {
				
				oprot.WriteFieldBegin("skuId");
				oprot.WriteI64((long)structs.GetSkuId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSku() != null) {
				
				oprot.WriteFieldBegin("sku");
				oprot.WriteString(structs.GetSku());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVdgValidateStatus() != null) {
				
				oprot.WriteFieldBegin("vdgValidateStatus");
				oprot.WriteByte((byte)structs.GetVdgValidateStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPushVdgStatus() != null) {
				
				oprot.WriteFieldBegin("pushVdgStatus");
				oprot.WriteByte((byte)structs.GetPushVdgStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPdcValidateStatus() != null) {
				
				oprot.WriteFieldBegin("pdcValidateStatus");
				oprot.WriteByte((byte)structs.GetPdcValidateStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPushPdcStatus() != null) {
				
				oprot.WriteFieldBegin("pushPdcStatus");
				oprot.WriteByte((byte)structs.GetPushPdcStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductSkuStatus bean){
			
			
		}
		
	}
	
}