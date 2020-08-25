using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class VendorSizeMappingDoHelper : TBeanSerializer<VendorSizeMappingDo>
	{
		
		public static VendorSizeMappingDoHelper OBJ = new VendorSizeMappingDoHelper();
		
		public static VendorSizeMappingDoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorSizeMappingDo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("vip_category_path".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVip_category_path(value);
					}
					
					
					
					
					
					if ("vip_category_path_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVip_category_path_id(value);
					}
					
					
					
					
					
					if ("vip_category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVip_category_name(value);
					}
					
					
					
					
					
					if ("vip_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVip_category_id(value);
					}
					
					
					
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("update_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetUpdate_time(value);
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
		
		
		public void Write(VendorSizeMappingDo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI32((int)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_category_path() != null) {
				
				oprot.WriteFieldBegin("vip_category_path");
				oprot.WriteString(structs.GetVip_category_path());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_category_path_id() != null) {
				
				oprot.WriteFieldBegin("vip_category_path_id");
				oprot.WriteString(structs.GetVip_category_path_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_category_name() != null) {
				
				oprot.WriteFieldBegin("vip_category_name");
				oprot.WriteString(structs.GetVip_category_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_category_id() != null) {
				
				oprot.WriteFieldBegin("vip_category_id");
				oprot.WriteI32((int)structs.GetVip_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteString(structs.GetSize_table_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreate_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdate_time() != null) {
				
				oprot.WriteFieldBegin("update_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetUpdate_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorSizeMappingDo bean){
			
			
		}
		
	}
	
}