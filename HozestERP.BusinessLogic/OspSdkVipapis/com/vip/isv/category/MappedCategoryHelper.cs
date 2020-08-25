using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.category{
	
	
	
	public class MappedCategoryHelper : TBeanSerializer<MappedCategory>
	{
		
		public static MappedCategoryHelper OBJ = new MappedCategoryHelper();
		
		public static MappedCategoryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MappedCategory structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("properties".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.category.MappedCategoryProperty> value;
						
						value = new List<com.vip.isv.category.MappedCategoryProperty>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.category.MappedCategoryProperty elem0;
								
								elem0 = new com.vip.isv.category.MappedCategoryProperty();
								com.vip.isv.category.MappedCategoryPropertyHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProperties(value);
					}
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("vendor_category_tree_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_category_tree_id(value);
					}
					
					
					
					
					
					if ("vendor_category_tree_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_category_tree_name(value);
					}
					
					
					
					
					
					if ("vendor_category_path".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_category_path(value);
					}
					
					
					
					
					
					if ("vendor_category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_category_name(value);
					}
					
					
					
					
					
					if ("vendor_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_category_id(value);
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
		
		
		public void Write(MappedCategory structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProperties() != null) {
				
				oprot.WriteFieldBegin("properties");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.category.MappedCategoryProperty _item0 in structs.GetProperties()){
					
					
					com.vip.isv.category.MappedCategoryPropertyHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_category_tree_id() != null) {
				
				oprot.WriteFieldBegin("vendor_category_tree_id");
				oprot.WriteI32((int)structs.GetVendor_category_tree_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_category_tree_name() != null) {
				
				oprot.WriteFieldBegin("vendor_category_tree_name");
				oprot.WriteString(structs.GetVendor_category_tree_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_category_path() != null) {
				
				oprot.WriteFieldBegin("vendor_category_path");
				oprot.WriteString(structs.GetVendor_category_path());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_category_name() != null) {
				
				oprot.WriteFieldBegin("vendor_category_name");
				oprot.WriteString(structs.GetVendor_category_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_category_id() != null) {
				
				oprot.WriteFieldBegin("vendor_category_id");
				oprot.WriteString(structs.GetVendor_category_id());
				
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MappedCategory bean){
			
			
		}
		
	}
	
}