using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vsizetable{
	
	
	
	public class SizeTableTemplateHelper : TBeanSerializer<SizeTableTemplate>
	{
		
		public static SizeTableTemplateHelper OBJ = new SizeTableTemplateHelper();
		
		public static SizeTableTemplateHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeTableTemplate structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("sizetable_template_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizetable_template_name(value);
					}
					
					
					
					
					
					if ("sizetable_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSizetable_id(value);
					}
					
					
					
					
					
					if ("sizetable_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetSizetable_type(value);
					}
					
					
					
					
					
					if ("del_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetDel_flag(value);
					}
					
					
					
					
					
					if ("sizetable_template_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSizetable_template_id(value);
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
		
		
		public void Write(SizeTableTemplate structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizetable_template_name() != null) {
				
				oprot.WriteFieldBegin("sizetable_template_name");
				oprot.WriteString(structs.GetSizetable_template_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizetable_id() != null) {
				
				oprot.WriteFieldBegin("sizetable_id");
				oprot.WriteI64((long)structs.GetSizetable_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizetable_type() != null) {
				
				oprot.WriteFieldBegin("sizetable_type");
				oprot.WriteI16((short)structs.GetSizetable_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDel_flag() != null) {
				
				oprot.WriteFieldBegin("del_flag");
				oprot.WriteI16((short)structs.GetDel_flag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizetable_template_id() != null) {
				
				oprot.WriteFieldBegin("sizetable_template_id");
				oprot.WriteI32((int)structs.GetSizetable_template_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeTableTemplate bean){
			
			
		}
		
	}
	
}