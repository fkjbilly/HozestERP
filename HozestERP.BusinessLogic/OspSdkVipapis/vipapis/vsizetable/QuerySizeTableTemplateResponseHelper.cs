using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vsizetable{
	
	
	
	public class QuerySizeTableTemplateResponseHelper : TBeanSerializer<QuerySizeTableTemplateResponse>
	{
		
		public static QuerySizeTableTemplateResponseHelper OBJ = new QuerySizeTableTemplateResponseHelper();
		
		public static QuerySizeTableTemplateResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(QuerySizeTableTemplateResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sizetable_template_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vsizetable.SizeTableTemplate> value;
						
						value = new List<vipapis.vsizetable.SizeTableTemplate>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vsizetable.SizeTableTemplate elem0;
								
								elem0 = new vipapis.vsizetable.SizeTableTemplate();
								vipapis.vsizetable.SizeTableTemplateHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSizetable_template_list(value);
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
		
		
		public void Write(QuerySizeTableTemplateResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSizetable_template_list() != null) {
				
				oprot.WriteFieldBegin("sizetable_template_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.vsizetable.SizeTableTemplate _item0 in structs.GetSizetable_template_list()){
					
					
					vipapis.vsizetable.SizeTableTemplateHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(QuerySizeTableTemplateResponse bean){
			
			
		}
		
	}
	
}