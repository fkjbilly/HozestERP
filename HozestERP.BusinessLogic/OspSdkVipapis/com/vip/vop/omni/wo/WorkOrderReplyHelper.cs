using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.wo{
	
	
	
	public class WorkOrderReplyHelper : TBeanSerializer<WorkOrderReply>
	{
		
		public static WorkOrderReplyHelper OBJ = new WorkOrderReplyHelper();
		
		public static WorkOrderReplyHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(WorkOrderReply structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("wo_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWo_no(value);
					}
					
					
					
					
					
					if ("content".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetContent(value);
					}
					
					
					
					
					
					if ("carrier_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_id(value);
					}
					
					
					
					
					
					if ("fix_user".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFix_user(value);
					}
					
					
					
					
					
					if ("fix_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetFix_time(value);
					}
					
					
					
					
					
					if ("attachments".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.omni.wo.Attachment> value;
						
						value = new List<com.vip.vop.omni.wo.Attachment>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.omni.wo.Attachment elem0;
								
								elem0 = new com.vip.vop.omni.wo.Attachment();
								com.vip.vop.omni.wo.AttachmentHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetAttachments(value);
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
		
		
		public void Write(WorkOrderReply structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWo_no() != null) {
				
				oprot.WriteFieldBegin("wo_no");
				oprot.WriteString(structs.GetWo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("wo_no can not be null!");
			}
			
			
			if(structs.GetContent() != null) {
				
				oprot.WriteFieldBegin("content");
				oprot.WriteString(structs.GetContent());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("content can not be null!");
			}
			
			
			if(structs.GetCarrier_id() != null) {
				
				oprot.WriteFieldBegin("carrier_id");
				oprot.WriteString(structs.GetCarrier_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFix_user() != null) {
				
				oprot.WriteFieldBegin("fix_user");
				oprot.WriteString(structs.GetFix_user());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFix_time() != null) {
				
				oprot.WriteFieldBegin("fix_time");
				oprot.WriteI64((long)structs.GetFix_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAttachments() != null) {
				
				oprot.WriteFieldBegin("attachments");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.omni.wo.Attachment _item0 in structs.GetAttachments()){
					
					
					com.vip.vop.omni.wo.AttachmentHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(WorkOrderReply bean){
			
			
		}
		
	}
	
}