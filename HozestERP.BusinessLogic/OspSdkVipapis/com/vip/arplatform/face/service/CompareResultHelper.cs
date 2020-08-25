using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class CompareResultHelper : TBeanSerializer<CompareResult>
	{
		
		public static CompareResultHelper OBJ = new CompareResultHelper();
		
		public static CompareResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CompareResult structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("confidence".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetConfidence(value);
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
		
		
		public void Write(CompareResult structs, Protocol oprot){
			
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
			
			
			if(structs.GetConfidence() != null) {
				
				oprot.WriteFieldBegin("confidence");
				oprot.WriteDouble((double)structs.GetConfidence());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("confidence can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CompareResult bean){
			
			
		}
		
	}
	
}