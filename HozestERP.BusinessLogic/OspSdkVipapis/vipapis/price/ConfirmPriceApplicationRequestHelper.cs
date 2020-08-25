using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class ConfirmPriceApplicationRequestHelper : TBeanSerializer<ConfirmPriceApplicationRequest>
	{
		
		public static ConfirmPriceApplicationRequestHelper OBJ = new ConfirmPriceApplicationRequestHelper();
		
		public static ConfirmPriceApplicationRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ConfirmPriceApplicationRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("application_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApplication_id(value);
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
		
		
		public void Write(ConfirmPriceApplicationRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetApplication_id() != null) {
				
				oprot.WriteFieldBegin("application_id");
				oprot.WriteString(structs.GetApplication_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("application_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ConfirmPriceApplicationRequest bean){
			
			
		}
		
	}
	
}