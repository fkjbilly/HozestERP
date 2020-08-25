using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class VopOrderVoHelper : TBeanSerializer<VopOrderVo>
	{
		
		public static VopOrderVoHelper OBJ = new VopOrderVoHelper();
		
		public static VopOrderVoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VopOrderVo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("connectTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConnectTime(value);
					}
					
					
					
					
					
					if ("message".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMessage(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWeight(value);
					}
					
					
					
					
					
					if ("volume".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVolume(value);
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
		
		
		public void Write(VopOrderVo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			if(structs.GetConnectTime() != null) {
				
				oprot.WriteFieldBegin("connectTime");
				oprot.WriteString(structs.GetConnectTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("connectTime can not be null!");
			}
			
			
			if(structs.GetMessage() != null) {
				
				oprot.WriteFieldBegin("message");
				oprot.WriteString(structs.GetMessage());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("message can not be null!");
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteDouble((double)structs.GetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVolume() != null) {
				
				oprot.WriteFieldBegin("volume");
				oprot.WriteDouble((double)structs.GetVolume());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VopOrderVo bean){
			
			
		}
		
	}
	
}