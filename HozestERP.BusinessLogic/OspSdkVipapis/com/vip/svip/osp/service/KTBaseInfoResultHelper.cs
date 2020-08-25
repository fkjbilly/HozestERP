using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class KTBaseInfoResultHelper : TBeanSerializer<KTBaseInfoResult>
	{
		
		public static KTBaseInfoResultHelper OBJ = new KTBaseInfoResultHelper();
		
		public static KTBaseInfoResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(KTBaseInfoResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("code".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCode(value);
					}
					
					
					
					
					
					if ("msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsg(value);
					}
					
					
					
					
					
					if ("data".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.svip.osp.service.KTBaseInfo value;
						
						value = new com.vip.svip.osp.service.KTBaseInfo();
						com.vip.svip.osp.service.KTBaseInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetData(value);
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
		
		
		public void Write(KTBaseInfoResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCode() != null) {
				
				oprot.WriteFieldBegin("code");
				oprot.WriteI32((int)structs.GetCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("code can not be null!");
			}
			
			
			if(structs.GetMsg() != null) {
				
				oprot.WriteFieldBegin("msg");
				oprot.WriteString(structs.GetMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetData() != null) {
				
				oprot.WriteFieldBegin("data");
				
				com.vip.svip.osp.service.KTBaseInfoHelper.getInstance().Write(structs.GetData(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(KTBaseInfoResult bean){
			
			
		}
		
	}
	
}