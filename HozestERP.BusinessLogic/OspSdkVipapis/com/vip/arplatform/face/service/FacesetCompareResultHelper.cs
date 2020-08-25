using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class FacesetCompareResultHelper : TBeanSerializer<FacesetCompareResult>
	{
		
		public static FacesetCompareResultHelper OBJ = new FacesetCompareResultHelper();
		
		public static FacesetCompareResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FacesetCompareResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("time_used".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetTime_used(value);
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
		
		
		public void Write(FacesetCompareResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTime_used() != null) {
				
				oprot.WriteFieldBegin("time_used");
				oprot.WriteI64((long)structs.GetTime_used()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("time_used can not be null!");
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
		
		
		public void Validate(FacesetCompareResult bean){
			
			
		}
		
	}
	
}