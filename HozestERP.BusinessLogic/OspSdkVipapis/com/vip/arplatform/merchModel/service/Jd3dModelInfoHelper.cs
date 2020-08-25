using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.merchModel.service{
	
	
	
	public class Jd3dModelInfoHelper : TBeanSerializer<Jd3dModelInfo>
	{
		
		public static Jd3dModelInfoHelper OBJ = new Jd3dModelInfoHelper();
		
		public static Jd3dModelInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Jd3dModelInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUrl(value);
					}
					
					
					
					
					
					if ("cost".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetCost(value);
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
		
		
		public void Write(Jd3dModelInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUrl() != null) {
				
				oprot.WriteFieldBegin("url");
				oprot.WriteString(structs.GetUrl());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("url can not be null!");
			}
			
			
			if(structs.GetCost() != null) {
				
				oprot.WriteFieldBegin("cost");
				oprot.WriteDouble((double)structs.GetCost());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cost can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Jd3dModelInfo bean){
			
			
		}
		
	}
	
}