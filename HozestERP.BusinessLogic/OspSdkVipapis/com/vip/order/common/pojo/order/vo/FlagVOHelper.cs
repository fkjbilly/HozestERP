using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class FlagVOHelper : TBeanSerializer<FlagVO>
	{
		
		public static FlagVOHelper OBJ = new FlagVOHelper();
		
		public static FlagVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FlagVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("flagCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFlagCode(value);
					}
					
					
					
					
					
					if ("time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTime(value);
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
		
		
		public void Write(FlagVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetFlagCode() != null) {
				
				oprot.WriteFieldBegin("flagCode");
				oprot.WriteString(structs.GetFlagCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTime() != null) {
				
				oprot.WriteFieldBegin("time");
				oprot.WriteString(structs.GetTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FlagVO bean){
			
			
		}
		
	}
	
}