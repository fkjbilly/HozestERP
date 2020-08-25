using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class GetTemplateTypeResponseHelper : TBeanSerializer<GetTemplateTypeResponse>
	{
		
		public static GetTemplateTypeResponseHelper OBJ = new GetTemplateTypeResponseHelper();
		
		public static GetTemplateTypeResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetTemplateTypeResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("template_types".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.sizetable.TemplateType> value;
						
						value = new List<vipapis.marketplace.sizetable.TemplateType>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.sizetable.TemplateType elem0;
								
								elem0 = new vipapis.marketplace.sizetable.TemplateType();
								vipapis.marketplace.sizetable.TemplateTypeHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTemplate_types(value);
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
		
		
		public void Write(GetTemplateTypeResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTemplate_types() != null) {
				
				oprot.WriteFieldBegin("template_types");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.sizetable.TemplateType _item0 in structs.GetTemplate_types()){
					
					
					vipapis.marketplace.sizetable.TemplateTypeHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetTemplateTypeResponse bean){
			
			
		}
		
	}
	
}