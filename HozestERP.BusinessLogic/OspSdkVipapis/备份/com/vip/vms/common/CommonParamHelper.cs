using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vms.common{
	
	
	
	public class CommonParamHelper : BeanSerializer<CommonParam>
	{
		
		public static CommonParamHelper OBJ = new CommonParamHelper();
		
		public static CommonParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CommonParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("appName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAppName(value);
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
		
		
		public void Write(CommonParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAppName() != null) {
				
				oprot.WriteFieldBegin("appName");
				oprot.WriteString(structs.GetAppName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("appName can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CommonParam bean){
			
			
		}
		
	}
	
}