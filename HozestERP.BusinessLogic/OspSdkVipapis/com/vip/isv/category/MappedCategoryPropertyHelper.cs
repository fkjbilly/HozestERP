using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.category{
	
	
	
	public class MappedCategoryPropertyHelper : TBeanSerializer<MappedCategoryProperty>
	{
		
		public static MappedCategoryPropertyHelper OBJ = new MappedCategoryPropertyHelper();
		
		public static MappedCategoryPropertyHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MappedCategoryProperty structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_prop_Name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_prop_Name(value);
					}
					
					
					
					
					
					if ("vip_prop_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVip_prop_name(value);
					}
					
					
					
					
					
					if ("vip_prop_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVip_prop_id(value);
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
		
		
		public void Write(MappedCategoryProperty structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_prop_Name() != null) {
				
				oprot.WriteFieldBegin("vendor_prop_Name");
				oprot.WriteString(structs.GetVendor_prop_Name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_prop_name() != null) {
				
				oprot.WriteFieldBegin("vip_prop_name");
				oprot.WriteString(structs.GetVip_prop_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_prop_id() != null) {
				
				oprot.WriteFieldBegin("vip_prop_id");
				oprot.WriteI32((int)structs.GetVip_prop_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MappedCategoryProperty bean){
			
			
		}
		
	}
	
}