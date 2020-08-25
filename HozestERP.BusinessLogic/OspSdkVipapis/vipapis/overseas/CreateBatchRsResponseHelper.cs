using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class CreateBatchRsResponseHelper : TBeanSerializer<CreateBatchRsResponse>
	{
		
		public static CreateBatchRsResponseHelper OBJ = new CreateBatchRsResponseHelper();
		
		public static CreateBatchRsResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateBatchRsResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("rs_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetRs_id(value);
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
		
		
		public void Write(CreateBatchRsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRs_id() != null) {
				
				oprot.WriteFieldBegin("rs_id");
				oprot.WriteI32((int)structs.GetRs_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("rs_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateBatchRsResponse bean){
			
			
		}
		
	}
	
}