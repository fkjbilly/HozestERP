using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.product.publish.service{
	
	
	
	public class ShoeReportParameterHelper : TBeanSerializer<ShoeReportParameter>
	{
		
		public static ShoeReportParameterHelper OBJ = new ShoeReportParameterHelper();
		
		public static ShoeReportParameterHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ShoeReportParameter structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("sizeRelationshipJson".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeRelationshipJson(value);
					}
					
					
					
					
					
					if ("shoeTags".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShoeTags(value);
					}
					
					
					
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("reportJson".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReportJson(value);
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
		
		
		public void Write(ShoeReportParameter structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorId can not be null!");
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetSizeRelationshipJson() != null) {
				
				oprot.WriteFieldBegin("sizeRelationshipJson");
				oprot.WriteString(structs.GetSizeRelationshipJson());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sizeRelationshipJson can not be null!");
			}
			
			
			if(structs.GetShoeTags() != null) {
				
				oprot.WriteFieldBegin("shoeTags");
				oprot.WriteString(structs.GetShoeTags());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shoeTags can not be null!");
			}
			
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				oprot.WriteString(structs.GetResult());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("result can not be null!");
			}
			
			
			if(structs.GetReportJson() != null) {
				
				oprot.WriteFieldBegin("reportJson");
				oprot.WriteString(structs.GetReportJson());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("reportJson can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ShoeReportParameter bean){
			
			
		}
		
	}
	
}