using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vendor{
	
	
	
	public class VisVendorInfoHelper : TBeanSerializer<VisVendorInfo>
	{
		
		public static VisVendorInfoHelper OBJ = new VisVendorInfoHelper();
		
		public static VisVendorInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VisVendorInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("vendorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorName(value);
					}
					
					
					
					
					
					if ("ebsId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetEbsId(value);
					}
					
					
					
					
					
					if ("vendorCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCode(value);
					}
					
					
					
					
					
					if ("taxReference".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTaxReference(value);
					}
					
					
					
					
					
					if ("vendorType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorType(value);
					}
					
					
					
					
					
					if ("vendorAddr".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorAddr(value);
					}
					
					
					
					
					
					if ("auditStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAuditStatus(value);
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
		
		
		public void Write(VisVendorInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorName() != null) {
				
				oprot.WriteFieldBegin("vendorName");
				oprot.WriteString(structs.GetVendorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEbsId() != null) {
				
				oprot.WriteFieldBegin("ebsId");
				oprot.WriteI32((int)structs.GetEbsId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCode() != null) {
				
				oprot.WriteFieldBegin("vendorCode");
				oprot.WriteString(structs.GetVendorCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTaxReference() != null) {
				
				oprot.WriteFieldBegin("taxReference");
				oprot.WriteString(structs.GetTaxReference());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorType() != null) {
				
				oprot.WriteFieldBegin("vendorType");
				oprot.WriteI32((int)structs.GetVendorType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorAddr() != null) {
				
				oprot.WriteFieldBegin("vendorAddr");
				oprot.WriteString(structs.GetVendorAddr());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAuditStatus() != null) {
				
				oprot.WriteFieldBegin("auditStatus");
				oprot.WriteI32((int)structs.GetAuditStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VisVendorInfo bean){
			
			
		}
		
	}
	
}