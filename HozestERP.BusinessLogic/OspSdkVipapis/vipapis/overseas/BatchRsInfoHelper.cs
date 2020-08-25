using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class BatchRsInfoHelper : TBeanSerializer<BatchRsInfo>
	{
		
		public static BatchRsInfoHelper OBJ = new BatchRsInfoHelper();
		
		public static BatchRsInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchRsInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("batch_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatch_no(value);
					}
					
					
					
					
					
					if ("rs_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetRs_type(value);
					}
					
					
					
					
					
					if ("rs_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRs_name(value);
					}
					
					
					
					
					
					if ("rs_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRs_no(value);
					}
					
					
					
					
					
					if ("rs_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRs_image(value);
					}
					
					
					
					
					
					if ("rs_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRs_id(value);
					}
					
					
					
					
					
					if ("file_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFile_name(value);
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
		
		
		public void Write(BatchRsInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteString(structs.GetVendor_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetBatch_no() != null) {
				
				oprot.WriteFieldBegin("batch_no");
				oprot.WriteString(structs.GetBatch_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batch_no can not be null!");
			}
			
			
			if(structs.GetRs_type() != null) {
				
				oprot.WriteFieldBegin("rs_type");
				oprot.WriteI32((int)structs.GetRs_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("rs_type can not be null!");
			}
			
			
			if(structs.GetRs_name() != null) {
				
				oprot.WriteFieldBegin("rs_name");
				oprot.WriteString(structs.GetRs_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("rs_name can not be null!");
			}
			
			
			if(structs.GetRs_no() != null) {
				
				oprot.WriteFieldBegin("rs_no");
				oprot.WriteString(structs.GetRs_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRs_image() != null) {
				
				oprot.WriteFieldBegin("rs_image");
				oprot.WriteString(structs.GetRs_image());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("rs_image can not be null!");
			}
			
			
			if(structs.GetRs_id() != null) {
				
				oprot.WriteFieldBegin("rs_id");
				oprot.WriteI32((int)structs.GetRs_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFile_name() != null) {
				
				oprot.WriteFieldBegin("file_name");
				oprot.WriteString(structs.GetFile_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("file_name can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchRsInfo bean){
			
			
		}
		
	}
	
}