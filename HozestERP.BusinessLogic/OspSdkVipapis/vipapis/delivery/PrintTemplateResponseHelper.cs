using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PrintTemplateResponseHelper : TBeanSerializer<PrintTemplateResponse>
	{
		
		public static PrintTemplateResponseHelper OBJ = new PrintTemplateResponseHelper();
		
		public static PrintTemplateResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PrintTemplateResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("partOrderLists".Equals(schemeField.Trim())){
						
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
						
						structs.SetPartOrderLists(value);
					}
					
					
					
					
					
					if ("allPrintHtml".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAllPrintHtml(value);
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
		
		
		public void Write(PrintTemplateResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPartOrderLists() != null) {
				
				oprot.WriteFieldBegin("partOrderLists");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetPartOrderLists()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("partOrderLists can not be null!");
			}
			
			
			if(structs.GetAllPrintHtml() != null) {
				
				oprot.WriteFieldBegin("allPrintHtml");
				oprot.WriteString(structs.GetAllPrintHtml());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("allPrintHtml can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PrintTemplateResponse bean){
			
			
		}
		
	}
	
}