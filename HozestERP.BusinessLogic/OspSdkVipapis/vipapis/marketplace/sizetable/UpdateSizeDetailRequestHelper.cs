using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class UpdateSizeDetailRequestHelper : TBeanSerializer<UpdateSizeDetailRequest>
	{
		
		public static UpdateSizeDetailRequestHelper OBJ = new UpdateSizeDetailRequestHelper();
		
		public static UpdateSizeDetailRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdateSizeDetailRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("size_detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_detail_id(value);
					}
					
					
					
					
					
					if ("size_detail_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_detail_name(value);
					}
					
					
					
					
					
					if ("size_detail_properties".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								string _val1;
								_key1 = iprot.ReadString();
								
								_val1 = iprot.ReadString();
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetSize_detail_properties(value);
					}
					
					
					
					
					
					if ("size_detail_order".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSize_detail_order(value);
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
		
		
		public void Write(UpdateSizeDetailRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_table_id can not be null!");
			}
			
			
			if(structs.GetSize_detail_id() != null) {
				
				oprot.WriteFieldBegin("size_detail_id");
				oprot.WriteI64((long)structs.GetSize_detail_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_detail_id can not be null!");
			}
			
			
			if(structs.GetSize_detail_name() != null) {
				
				oprot.WriteFieldBegin("size_detail_name");
				oprot.WriteString(structs.GetSize_detail_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_detail_name can not be null!");
			}
			
			
			if(structs.GetSize_detail_properties() != null) {
				
				oprot.WriteFieldBegin("size_detail_properties");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetSize_detail_properties()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_detail_order() != null) {
				
				oprot.WriteFieldBegin("size_detail_order");
				oprot.WriteI32((int)structs.GetSize_detail_order()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdateSizeDetailRequest bean){
			
			
		}
		
	}
	
}