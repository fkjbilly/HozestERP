using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class VipCardInfoHelper : TBeanSerializer<VipCardInfo>
	{
		
		public static VipCardInfoHelper OBJ = new VipCardInfoHelper();
		
		public static VipCardInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VipCardInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("card_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCard_code(value);
					}
					
					
					
					
					
					if ("face_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetFace_money(value);
					}
					
					
					
					
					
					if ("valid_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetValid_money(value);
					}
					
					
					
					
					
					if ("used_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetUsed_money(value);
					}
					
					
					
					
					
					if ("frozen_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetFrozen_money(value);
					}
					
					
					
					
					
					if ("expired_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetExpired_money(value);
					}
					
					
					
					
					
					if ("start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStart_time(value);
					}
					
					
					
					
					
					if ("stop_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStop_time(value);
					}
					
					
					
					
					
					if ("is_used".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_used(value);
					}
					
					
					
					
					
					if ("is_frozen".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_frozen(value);
					}
					
					
					
					
					
					if ("is_expired".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_expired(value);
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
		
		
		public void Write(VipCardInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCard_code() != null) {
				
				oprot.WriteFieldBegin("card_code");
				oprot.WriteString(structs.GetCard_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("card_code can not be null!");
			}
			
			
			if(structs.GetFace_money() != null) {
				
				oprot.WriteFieldBegin("face_money");
				oprot.WriteDouble((double)structs.GetFace_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("face_money can not be null!");
			}
			
			
			if(structs.GetValid_money() != null) {
				
				oprot.WriteFieldBegin("valid_money");
				oprot.WriteDouble((double)structs.GetValid_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("valid_money can not be null!");
			}
			
			
			if(structs.GetUsed_money() != null) {
				
				oprot.WriteFieldBegin("used_money");
				oprot.WriteDouble((double)structs.GetUsed_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("used_money can not be null!");
			}
			
			
			if(structs.GetFrozen_money() != null) {
				
				oprot.WriteFieldBegin("frozen_money");
				oprot.WriteDouble((double)structs.GetFrozen_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("frozen_money can not be null!");
			}
			
			
			if(structs.GetExpired_money() != null) {
				
				oprot.WriteFieldBegin("expired_money");
				oprot.WriteDouble((double)structs.GetExpired_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("expired_money can not be null!");
			}
			
			
			if(structs.GetStart_time() != null) {
				
				oprot.WriteFieldBegin("start_time");
				oprot.WriteString(structs.GetStart_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("start_time can not be null!");
			}
			
			
			if(structs.GetStop_time() != null) {
				
				oprot.WriteFieldBegin("stop_time");
				oprot.WriteString(structs.GetStop_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("stop_time can not be null!");
			}
			
			
			if(structs.GetIs_used() != null) {
				
				oprot.WriteFieldBegin("is_used");
				oprot.WriteI32((int)structs.GetIs_used()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_used can not be null!");
			}
			
			
			if(structs.GetIs_frozen() != null) {
				
				oprot.WriteFieldBegin("is_frozen");
				oprot.WriteI32((int)structs.GetIs_frozen()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_frozen can not be null!");
			}
			
			
			if(structs.GetIs_expired() != null) {
				
				oprot.WriteFieldBegin("is_expired");
				oprot.WriteI32((int)structs.GetIs_expired()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_expired can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VipCardInfo bean){
			
			
		}
		
	}
	
}