using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.wo{
	
	
	
	public class WorkOrderHelper : TBeanSerializer<WorkOrder>
	{
		
		public static WorkOrderHelper OBJ = new WorkOrderHelper();
		
		public static WorkOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(WorkOrder structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("syncType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSyncType(value);
					}
					
					
					
					
					
					if ("woNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWoNo(value);
					}
					
					
					
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("acceptTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAcceptTime(value);
					}
					
					
					
					
					
					if ("state".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetState(value);
					}
					
					
					
					
					
					if ("pc1Name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPc1Name(value);
					}
					
					
					
					
					
					if ("pc2Name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPc2Name(value);
					}
					
					
					
					
					
					if ("pc3Name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPc3Name(value);
					}
					
					
					
					
					
					if ("problemDesc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProblemDesc(value);
					}
					
					
					
					
					
					if ("currentStepState".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetCurrentStepState(value);
					}
					
					
					
					
					
					if ("sdNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSdNo(value);
					}
					
					
					
					
					
					if ("expectEndTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetExpectEndTime(value);
					}
					
					
					
					
					
					if ("messageType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMessageType(value);
					}
					
					
					
					
					
					if ("expEvaluation".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExpEvaluation(value);
					}
					
					
					
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
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
		
		
		public void Write(WorkOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSyncType() != null) {
				
				oprot.WriteFieldBegin("syncType");
				oprot.WriteI32((int)structs.GetSyncType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWoNo() != null) {
				
				oprot.WriteFieldBegin("woNo");
				oprot.WriteString(structs.GetWoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAcceptTime() != null) {
				
				oprot.WriteFieldBegin("acceptTime");
				oprot.WriteI64((long)structs.GetAcceptTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteByte((byte)structs.GetState()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPc1Name() != null) {
				
				oprot.WriteFieldBegin("pc1Name");
				oprot.WriteString(structs.GetPc1Name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPc2Name() != null) {
				
				oprot.WriteFieldBegin("pc2Name");
				oprot.WriteString(structs.GetPc2Name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPc3Name() != null) {
				
				oprot.WriteFieldBegin("pc3Name");
				oprot.WriteString(structs.GetPc3Name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProblemDesc() != null) {
				
				oprot.WriteFieldBegin("problemDesc");
				oprot.WriteString(structs.GetProblemDesc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrentStepState() != null) {
				
				oprot.WriteFieldBegin("currentStepState");
				oprot.WriteByte((byte)structs.GetCurrentStepState()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSdNo() != null) {
				
				oprot.WriteFieldBegin("sdNo");
				oprot.WriteString(structs.GetSdNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpectEndTime() != null) {
				
				oprot.WriteFieldBegin("expectEndTime");
				oprot.WriteI64((long)structs.GetExpectEndTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMessageType() != null) {
				
				oprot.WriteFieldBegin("messageType");
				oprot.WriteString(structs.GetMessageType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpEvaluation() != null) {
				
				oprot.WriteFieldBegin("expEvaluation");
				oprot.WriteString(structs.GetExpEvaluation());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(WorkOrder bean){
			
			
		}
		
	}
	
}