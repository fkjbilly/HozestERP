using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class AddSizeTableTemplateResponseHelper : TBeanSerializer<AddSizeTableTemplateResponse>
	{
		
		public static AddSizeTableTemplateResponseHelper OBJ = new AddSizeTableTemplateResponseHelper();
		
		public static AddSizeTableTemplateResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AddSizeTableTemplateResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
		
		
		public void Write(AddSizeTableTemplateResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_table_template_id() != null) {
				
				oprot.WriteFieldBegin("size_table_template_id");
				oprot.WriteI32((int)structs.GetSize_table_template_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AddSizeTableTemplateResponse bean){
			
			
		}
		
	}
	
}