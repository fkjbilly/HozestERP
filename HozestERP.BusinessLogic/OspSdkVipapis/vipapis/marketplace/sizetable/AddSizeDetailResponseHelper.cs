using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class AddSizeDetailResponseHelper : TBeanSerializer<AddSizeDetailResponse>
	{
		
		public static AddSizeDetailResponseHelper OBJ = new AddSizeDetailResponseHelper();
		
		public static AddSizeDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AddSizeDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_detail_id(value);
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
		
		
		public void Write(AddSizeDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_detail_id() != null) {
				
				oprot.WriteFieldBegin("size_detail_id");
				oprot.WriteI64((long)structs.GetSize_detail_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_detail_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AddSizeDetailResponse bean){
			
			
		}
		
	}
	
}