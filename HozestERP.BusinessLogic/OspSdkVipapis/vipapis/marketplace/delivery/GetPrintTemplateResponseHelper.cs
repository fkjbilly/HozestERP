using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class GetPrintTemplateResponseHelper : TBeanSerializer<GetPrintTemplateResponse>
	{
		
		public static GetPrintTemplateResponseHelper OBJ = new GetPrintTemplateResponseHelper();
		
		public static GetPrintTemplateResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPrintTemplateResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("part_order_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPart_order_list(value);
					}
					
					
					
					
					
					if ("all_print_html".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAll_print_html(value);
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
		
		
		public void Write(GetPrintTemplateResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPart_order_list() != null) {
				
				oprot.WriteFieldBegin("part_order_list");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetPart_order_list()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAll_print_html() != null) {
				
				oprot.WriteFieldBegin("all_print_html");
				oprot.WriteString(structs.GetAll_print_html());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPrintTemplateResponse bean){
			
			
		}
		
	}
	
}