using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
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
					
					
					if ("size_table_template_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_table_template_name(value);
					}
					
					
					
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("size_table_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetSize_table_type(value);
					}
					
					
					
					
					
					if ("del_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetDel_flag(value);
					}
					
					
					
					
					
					if ("size_table_template_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSize_table_template_id(value);
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
			
			if(structs.GetSize_table_template_name() != null) {
				
				oprot.WriteFieldBegin("size_table_template_name");
				oprot.WriteString(structs.GetSize_table_template_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_type() != null) {
				
				oprot.WriteFieldBegin("size_table_type");
				oprot.WriteI16((short)structs.GetSize_table_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDel_flag() != null) {
				
				oprot.WriteFieldBegin("del_flag");
				oprot.WriteI16((short)structs.GetDel_flag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_template_id() != null) {
				
				oprot.WriteFieldBegin("size_table_template_id");
				oprot.WriteI32((int)structs.GetSize_table_template_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeTableTemplate bean){
			
			
		}
		
	}
	
}