using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class ShapeSimilarityModelHelper : TBeanSerializer<ShapeSimilarityModel>
	{
		
		public static ShapeSimilarityModelHelper OBJ = new ShapeSimilarityModelHelper();
		
		public static ShapeSimilarityModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ShapeSimilarityModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("imgSrc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImgSrc(value);
					}
					
					
					
					
					
					if ("imgTarget".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImgTarget(value);
					}
					
					
					
					
					
					if ("imgTargetOut".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImgTargetOut(value);
					}
					
					
					
					
					
					if ("code".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCode(value);
					}
					
					
					
					
					
					if ("simScores".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetSimScores(value);
					}
					
					
					
					
					
					if ("message".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMessage(value);
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
		
		
		public void Write(ShapeSimilarityModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetImgSrc() != null) {
				
				oprot.WriteFieldBegin("imgSrc");
				oprot.WriteString(structs.GetImgSrc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImgTarget() != null) {
				
				oprot.WriteFieldBegin("imgTarget");
				oprot.WriteString(structs.GetImgTarget());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImgTargetOut() != null) {
				
				oprot.WriteFieldBegin("imgTargetOut");
				oprot.WriteString(structs.GetImgTargetOut());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCode() != null) {
				
				oprot.WriteFieldBegin("code");
				oprot.WriteI32((int)structs.GetCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSimScores() != null) {
				
				oprot.WriteFieldBegin("simScores");
				oprot.WriteDouble((double)structs.GetSimScores());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("simScores can not be null!");
			}
			
			
			if(structs.GetMessage() != null) {
				
				oprot.WriteFieldBegin("message");
				oprot.WriteString(structs.GetMessage());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ShapeSimilarityModel bean){
			
			
		}
		
	}
	
}