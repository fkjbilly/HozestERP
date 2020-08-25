using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class InterBatchNoVoHelper : TBeanSerializer<InterBatchNoVo>
	{
		
		public static InterBatchNoVoHelper OBJ = new InterBatchNoVoHelper();
		
		public static InterBatchNoVoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InterBatchNoVo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("bizResponseCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBizResponseCode(value);
					}
					
					
					
					
					
					if ("bizResponseMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBizResponseMsg(value);
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
		
		
		public void Write(InterBatchNoVo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBizResponseCode() != null) {
				
				oprot.WriteFieldBegin("bizResponseCode");
				oprot.WriteString(structs.GetBizResponseCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBizResponseMsg() != null) {
				
				oprot.WriteFieldBegin("bizResponseMsg");
				oprot.WriteString(structs.GetBizResponseMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InterBatchNoVo bean){
			
			
		}
		
	}
	
}