using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class TemplateTypeHelper : TBeanSerializer<TemplateType>
	{
		
		public static TemplateTypeHelper OBJ = new TemplateTypeHelper();
		
		public static TemplateTypeHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TemplateType structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("template_type_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTemplate_type_id(value);
					}
					
					
					
					
					
					if ("template_type_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTemplate_type_name(value);
					}
					
					
					
					
					
					if ("template_properties".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTemplate_properties(value);
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
		
		
		public void Write(TemplateType structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTemplate_type_id() != null) {
				
				oprot.WriteFieldBegin("template_type_id");
				oprot.WriteI32((int)structs.GetTemplate_type_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTemplate_type_name() != null) {
				
				oprot.WriteFieldBegin("template_type_name");
				oprot.WriteString(structs.GetTemplate_type_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTemplate_properties() != null) {
				
				oprot.WriteFieldBegin("template_properties");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetTemplate_properties()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TemplateType bean){
			
			
		}
		
	}
	
}