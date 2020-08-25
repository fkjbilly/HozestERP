using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class GetHeaderHelper : TBeanSerializer<GetHeader>
	{
		
		public static GetHeaderHelper OBJ = new GetHeaderHelper();
		
		public static GetHeaderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetHeader structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnHeaderTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnHeaderTime(value);
					}
					
					
					
					
					
					if ("returnHeaderCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnHeaderCode(value);
					}
					
					
					
					
					
					if ("retrunHeaderMessage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRetrunHeaderMessage(value);
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
		
		
		public void Write(GetHeader structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnHeaderTime() != null) {
				
				oprot.WriteFieldBegin("returnHeaderTime");
				oprot.WriteString(structs.GetReturnHeaderTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("returnHeaderTime can not be null!");
			}
			
			
			if(structs.GetReturnHeaderCode() != null) {
				
				oprot.WriteFieldBegin("returnHeaderCode");
				oprot.WriteString(structs.GetReturnHeaderCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("returnHeaderCode can not be null!");
			}
			
			
			if(structs.GetRetrunHeaderMessage() != null) {
				
				oprot.WriteFieldBegin("retrunHeaderMessage");
				oprot.WriteString(structs.GetRetrunHeaderMessage());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("retrunHeaderMessage can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetHeader bean){
			
			
		}
		
	}
	
}