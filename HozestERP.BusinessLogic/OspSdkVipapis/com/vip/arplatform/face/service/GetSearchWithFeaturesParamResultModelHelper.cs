using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class GetSearchWithFeaturesParamResultModelHelper : TBeanSerializer<GetSearchWithFeaturesParamResultModel>
	{
		
		public static GetSearchWithFeaturesParamResultModelHelper OBJ = new GetSearchWithFeaturesParamResultModelHelper();
		
		public static GetSearchWithFeaturesParamResultModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSearchWithFeaturesParamResultModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("token".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetToken(value);
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
		
		
		public void Write(GetSearchWithFeaturesParamResultModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetToken() != null) {
				
				oprot.WriteFieldBegin("token");
				oprot.WriteString(structs.GetToken());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("token can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSearchWithFeaturesParamResultModel bean){
			
			
		}
		
	}
	
}