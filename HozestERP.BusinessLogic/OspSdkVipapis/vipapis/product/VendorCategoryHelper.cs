using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class VendorCategoryHelper : TBeanSerializer<VendorCategory>
	{
		
		public static VendorCategoryHelper OBJ = new VendorCategoryHelper();
		
		public static VendorCategoryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorCategory structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("vendor_category_path".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_category_path(value);
					}
					
					
					
					
					
					if ("vendor_properties_map".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, List<string>> value;
						
						value = new Dictionary<string, List<string>>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								List<string> _val1;
								_key1 = iprot.ReadString();
								
								
								_val1 = new List<string>();
								iprot.ReadListBegin();
								while(true){
									
									try{
										
										string elem2;
										elem2 = iprot.ReadString();
										
										_val1.Add(elem2);
									}
									catch(Exception e){
										
										
										break;
									}
								}
								
								iprot.ReadListEnd();
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetVendor_properties_map(value);
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
		
		
		public void Write(VendorCategory structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_category_name() != null) {
				
				oprot.WriteFieldBegin("vendor_category_name");
				oprot.WriteString(structs.GetVendor_category_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_category_name can not be null!");
			}
			
			
			if(structs.GetVendor_category_id() != null) {
				
				oprot.WriteFieldBegin("vendor_category_id");
				oprot.WriteString(structs.GetVendor_category_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_category_id can not be null!");
			}
			
			
			if(structs.GetVendor_category_path() != null) {
				
				oprot.WriteFieldBegin("vendor_category_path");
				oprot.WriteString(structs.GetVendor_category_path());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_category_path can not be null!");
			}
			
			
			if(structs.GetVendor_properties_map() != null) {
				
				oprot.WriteFieldBegin("vendor_properties_map");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, List<string> > _ir0 in structs.GetVendor_properties_map()){
					
					string _key0 = _ir0.Key;
					List<string> _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					
					oprot.WriteListBegin();
					foreach(string _item1 in _value0){
						
						oprot.WriteString(_item1);
						
					}
					
					oprot.WriteListEnd();
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_properties_map can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorCategory bean){
			
			
		}
		
	}
	
}