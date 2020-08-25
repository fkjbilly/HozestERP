using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.wo{
	
	
	
	public class WorkOrderAttachHelper : TBeanSerializer<WorkOrderAttach>
	{
		
		public static WorkOrderAttachHelper OBJ = new WorkOrderAttachHelper();
		
		public static WorkOrderAttachHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(WorkOrderAttach structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("woNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWoNo(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("fileName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFileName(value);
					}
					
					
					
					
					
					if ("filePath".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFilePath(value);
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
		
		
		public void Write(WorkOrderAttach structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWoNo() != null) {
				
				oprot.WriteFieldBegin("woNo");
				oprot.WriteString(structs.GetWoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFileName() != null) {
				
				oprot.WriteFieldBegin("fileName");
				oprot.WriteString(structs.GetFileName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFilePath() != null) {
				
				oprot.WriteFieldBegin("filePath");
				oprot.WriteString(structs.GetFilePath());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(WorkOrderAttach bean){
			
			
		}
		
	}
	
}