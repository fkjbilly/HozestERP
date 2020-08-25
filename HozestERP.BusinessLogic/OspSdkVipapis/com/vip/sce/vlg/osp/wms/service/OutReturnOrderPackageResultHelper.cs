using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutReturnOrderPackageResultHelper : TBeanSerializer<OutReturnOrderPackageResult>
	{
		
		public static OutReturnOrderPackageResultHelper OBJ = new OutReturnOrderPackageResultHelper();
		
		public static OutReturnOrderPackageResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutReturnOrderPackageResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vlgID".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVlgID(value);
					}
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("packageNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPackageNo(value);
					}
					
					
					
					
					
					if ("receivingTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceivingTime(value);
					}
					
					
					
					
					
					if ("handleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHandleType(value);
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
		
		
		public void Write(OutReturnOrderPackageResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVlgID() != null) {
				
				oprot.WriteFieldBegin("vlgID");
				oprot.WriteString(structs.GetVlgID());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vlgID can not be null!");
			}
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batchNo can not be null!");
			}
			
			
			if(structs.GetPackageNo() != null) {
				
				oprot.WriteFieldBegin("packageNo");
				oprot.WriteString(structs.GetPackageNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("packageNo can not be null!");
			}
			
			
			if(structs.GetReceivingTime() != null) {
				
				oprot.WriteFieldBegin("receivingTime");
				oprot.WriteString(structs.GetReceivingTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("receivingTime can not be null!");
			}
			
			
			if(structs.GetHandleType() != null) {
				
				oprot.WriteFieldBegin("handleType");
				oprot.WriteString(structs.GetHandleType());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("handleType can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutReturnOrderPackageResult bean){
			
			
		}
		
	}
	
}