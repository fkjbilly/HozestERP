using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class GetSizeTableTemplateResponseHelper : TBeanSerializer<GetSizeTableTemplateResponse>
	{
		
		public static GetSizeTableTemplateResponseHelper OBJ = new GetSizeTableTemplateResponseHelper();
		
		public static GetSizeTableTemplateResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSizeTableTemplateResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_table_templates".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.sizetable.SizeTableTemplate> value;
						
						value = new List<vipapis.marketplace.sizetable.SizeTableTemplate>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.sizetable.SizeTableTemplate elem0;
								
								elem0 = new vipapis.marketplace.sizetable.SizeTableTemplate();
								vipapis.marketplace.sizetable.SizeTableTemplateHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSize_table_templates(value);
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
		
		
		public void Write(GetSizeTableTemplateResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_table_templates() != null) {
				
				oprot.WriteFieldBegin("size_table_templates");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.sizetable.SizeTableTemplate _item0 in structs.GetSize_table_templates()){
					
					
					vipapis.marketplace.sizetable.SizeTableTemplateHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSizeTableTemplateResponse bean){
			
			
		}
		
	}
	
}