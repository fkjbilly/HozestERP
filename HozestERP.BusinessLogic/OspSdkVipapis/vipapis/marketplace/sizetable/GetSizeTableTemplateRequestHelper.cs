using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class GetSizeTableTemplateRequestHelper : TBeanSerializer<GetSizeTableTemplateRequest>
	{
		
		public static GetSizeTableTemplateRequestHelper OBJ = new GetSizeTableTemplateRequestHelper();
		
		public static GetSizeTableTemplateRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSizeTableTemplateRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("size_table_template_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSize_table_template_id(value);
					}
					
					
					
					
					
					if ("size_table_template_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_table_template_name(value);
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
		
		
		public void Write(GetSizeTableTemplateRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_template_id() != null) {
				
				oprot.WriteFieldBegin("size_table_template_id");
				oprot.WriteI32((int)structs.GetSize_table_template_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_template_name() != null) {
				
				oprot.WriteFieldBegin("size_table_template_name");
				oprot.WriteString(structs.GetSize_table_template_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSizeTableTemplateRequest bean){
			
			
		}
		
	}
	
}