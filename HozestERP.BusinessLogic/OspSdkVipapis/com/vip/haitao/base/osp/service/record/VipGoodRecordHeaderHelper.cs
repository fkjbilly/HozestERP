using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class VipGoodRecordHeaderHelper : TBeanSerializer<VipGoodRecordHeader>
	{
		
		public static VipGoodRecordHeaderHelper OBJ = new VipGoodRecordHeaderHelper();
		
		public static VipGoodRecordHeaderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VipGoodRecordHeader structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("recordType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordType(value);
					}
					
					
					
					
					
					if ("recordName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordName(value);
					}
					
					
					
					
					
					if ("recordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordNo(value);
					}
					
					
					
					
					
					if ("recordRule".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordRule(value);
					}
					
					
					
					
					
					if ("modifyFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetModifyFlag(value);
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
		
		
		public void Write(VipGoodRecordHeader structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRecordType() != null) {
				
				oprot.WriteFieldBegin("recordType");
				oprot.WriteString(structs.GetRecordType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordName() != null) {
				
				oprot.WriteFieldBegin("recordName");
				oprot.WriteString(structs.GetRecordName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordNo() != null) {
				
				oprot.WriteFieldBegin("recordNo");
				oprot.WriteString(structs.GetRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordRule() != null) {
				
				oprot.WriteFieldBegin("recordRule");
				oprot.WriteString(structs.GetRecordRule());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetModifyFlag() != null) {
				
				oprot.WriteFieldBegin("modifyFlag");
				oprot.WriteI32((int)structs.GetModifyFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VipGoodRecordHeader bean){
			
			
		}
		
	}
	
}