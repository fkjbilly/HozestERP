using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsZcodeApplyInfoHelper : TBeanSerializer<OutWmsZcodeApplyInfo>
	{
		
		public static OutWmsZcodeApplyInfoHelper OBJ = new OutWmsZcodeApplyInfoHelper();
		
		public static OutWmsZcodeApplyInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsZcodeApplyInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("APP_NUM".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAPP_NUM(value);
					}
					
					
					
					
					
					if ("AMOUNT".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAMOUNT(value);
					}
					
					
					
					
					
					if ("APP_TIME".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAPP_TIME(value);
					}
					
					
					
					
					
					if ("CODE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCODE(value);
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
		
		
		public void Write(OutWmsZcodeApplyInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAPP_NUM() != null) {
				
				oprot.WriteFieldBegin("APP_NUM");
				oprot.WriteString(structs.GetAPP_NUM());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("APP_NUM can not be null!");
			}
			
			
			if(structs.GetAMOUNT() != null) {
				
				oprot.WriteFieldBegin("AMOUNT");
				oprot.WriteI32((int)structs.GetAMOUNT()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("AMOUNT can not be null!");
			}
			
			
			if(structs.GetAPP_TIME() != null) {
				
				oprot.WriteFieldBegin("APP_TIME");
				oprot.WriteString(structs.GetAPP_TIME());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("APP_TIME can not be null!");
			}
			
			
			if(structs.GetCODE() != null) {
				
				oprot.WriteFieldBegin("CODE");
				oprot.WriteString(structs.GetCODE());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("CODE can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsZcodeApplyInfo bean){
			
			
		}
		
	}
	
}