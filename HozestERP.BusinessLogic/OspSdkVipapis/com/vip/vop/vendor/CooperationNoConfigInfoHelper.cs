using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vendor{
	
	
	
	public class CooperationNoConfigInfoHelper : TBeanSerializer<CooperationNoConfigInfo>
	{
		
		public static CooperationNoConfigInfoHelper OBJ = new CooperationNoConfigInfoHelper();
		
		public static CooperationNoConfigInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CooperationNoConfigInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("cooperationNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperationNo(value);
					}
					
					
					
					
					
					if ("forbidden".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetForbidden(value);
					}
					
					
					
					
					
					if ("stage".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStage(value);
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
		
		
		public void Write(CooperationNoConfigInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCooperationNo() != null) {
				
				oprot.WriteFieldBegin("cooperationNo");
				oprot.WriteI32((int)structs.GetCooperationNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForbidden() != null) {
				
				oprot.WriteFieldBegin("forbidden");
				oprot.WriteI32((int)structs.GetForbidden()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStage() != null) {
				
				oprot.WriteFieldBegin("stage");
				oprot.WriteI32((int)structs.GetStage()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CooperationNoConfigInfo bean){
			
			
		}
		
	}
	
}