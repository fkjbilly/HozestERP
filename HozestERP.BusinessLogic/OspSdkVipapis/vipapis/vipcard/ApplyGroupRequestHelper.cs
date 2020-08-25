using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class ApplyGroupRequestHelper : TBeanSerializer<ApplyGroupRequest>
	{
		
		public static ApplyGroupRequestHelper OBJ = new ApplyGroupRequestHelper();
		
		public static ApplyGroupRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ApplyGroupRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("merchant_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMerchant_code(value);
					}
					
					
					
					
					
					if ("activity_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActivity_flag(value);
					}
					
					
					
					
					
					if ("activity_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActivity_name(value);
					}
					
					
					
					
					
					if ("apply_key".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApply_key(value);
					}
					
					
					
					
					
					if ("card_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCard_flag(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("face_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetFace_money(value);
					}
					
					
					
					
					
					if ("use_stop_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUse_stop_time(value);
					}
					
					
					
					
					
					if ("use_effect_day".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetUse_effect_day(value);
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
		
		
		public void Write(ApplyGroupRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMerchant_code() != null) {
				
				oprot.WriteFieldBegin("merchant_code");
				oprot.WriteString(structs.GetMerchant_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("merchant_code can not be null!");
			}
			
			
			if(structs.GetActivity_flag() != null) {
				
				oprot.WriteFieldBegin("activity_flag");
				oprot.WriteString(structs.GetActivity_flag());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("activity_flag can not be null!");
			}
			
			
			if(structs.GetActivity_name() != null) {
				
				oprot.WriteFieldBegin("activity_name");
				oprot.WriteString(structs.GetActivity_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("activity_name can not be null!");
			}
			
			
			if(structs.GetApply_key() != null) {
				
				oprot.WriteFieldBegin("apply_key");
				oprot.WriteString(structs.GetApply_key());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("apply_key can not be null!");
			}
			
			
			if(structs.GetCard_flag() != null) {
				
				oprot.WriteFieldBegin("card_flag");
				oprot.WriteI32((int)structs.GetCard_flag()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("card_flag can not be null!");
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetFace_money() != null) {
				
				oprot.WriteFieldBegin("face_money");
				oprot.WriteI32((int)structs.GetFace_money()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("face_money can not be null!");
			}
			
			
			if(structs.GetUse_stop_time() != null) {
				
				oprot.WriteFieldBegin("use_stop_time");
				oprot.WriteString(structs.GetUse_stop_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("use_stop_time can not be null!");
			}
			
			
			if(structs.GetUse_effect_day() != null) {
				
				oprot.WriteFieldBegin("use_effect_day");
				oprot.WriteI32((int)structs.GetUse_effect_day()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("use_effect_day can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ApplyGroupRequest bean){
			
			
		}
		
	}
	
}