using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class SizeTableHelper : BeanSerializer<SizeTable>
	{
		
		public static SizeTableHelper OBJ = new SizeTableHelper();
		
		public static SizeTableHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeTable structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("size_table_detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, Dictionary<string, string>> value;
						
						value = new Dictionary<string, Dictionary<string, string>>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key0;
								Dictionary<string, string> _val0;
								_key0 = iprot.ReadString();
								
								
								_val0 = new Dictionary<string, string>();
								iprot.ReadMapBegin();
								while(true){
									
									try{
										
										string _key1;
										string _val1;
										_key1 = iprot.ReadString();
										
										_val1 = iprot.ReadString();
										
										_val0.Add(_key1, _val1);
									}
									catch(Exception e){
										
										
										break;
									}
								}
								
								iprot.ReadMapEnd();
								
								value.Add(_key0, _val0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetSize_table_detail(value);
					}
					
					
					
					
					
					if ("size_table_html".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_table_html(value);
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
		
		
		public void Write(SizeTable structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
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
			
			
			if(structs.GetSize_table_detail() != null) {
				
				oprot.WriteFieldBegin("size_table_detail");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, Dictionary<string, string> > _ir0 in structs.GetSize_table_detail()){
					
					string _key0 = _ir0.Key;
					Dictionary<string, string> _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir1 in _value0){
						
						string _key1 = _ir1.Key;
						string _value1 = _ir1.Value;
						oprot.WriteString(_key1);
						
						oprot.WriteString(_value1);
						
					}
					
					oprot.WriteMapEnd();
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_html() != null) {
				
				oprot.WriteFieldBegin("size_table_html");
				oprot.WriteString(structs.GetSize_table_html());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeTable bean){
			
			
		}
		
	}
	
}