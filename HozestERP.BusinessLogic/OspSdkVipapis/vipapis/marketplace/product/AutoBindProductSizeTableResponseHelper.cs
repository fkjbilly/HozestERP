using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class AutoBindProductSizeTableResponseHelper : TBeanSerializer<AutoBindProductSizeTableResponse>
	{
		
		public static AutoBindProductSizeTableResponseHelper OBJ = new AutoBindProductSizeTableResponseHelper();
		
		public static AutoBindProductSizeTableResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AutoBindProductSizeTableResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpu_id(value);
					}
					
					
					
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("sku_size_detail_id_mappings".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, long?> value;
						
						value = new Dictionary<string, long?>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key0;
								long _val0;
								_key0 = iprot.ReadString();
								
								_val0 = iprot.ReadI64(); 
								
								value.Add(_key0, _val0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetSku_size_detail_id_mappings(value);
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
		
		
		public void Write(AutoBindProductSizeTableResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu_id can not be null!");
			}
			
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_table_id can not be null!");
			}
			
			
			if(structs.GetSku_size_detail_id_mappings() != null) {
				
				oprot.WriteFieldBegin("sku_size_detail_id_mappings");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, long? > _ir0 in structs.GetSku_size_detail_id_mappings()){
					
					string _key0 = _ir0.Key;
					long? _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteI64((long)_value0); 
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AutoBindProductSizeTableResponse bean){
			
			
		}
		
	}
	
}