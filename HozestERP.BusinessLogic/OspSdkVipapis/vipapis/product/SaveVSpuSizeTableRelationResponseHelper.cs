using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class SaveVSpuSizeTableRelationResponseHelper : TBeanSerializer<SaveVSpuSizeTableRelationResponse>
	{
		
		public static SaveVSpuSizeTableRelationResponseHelper OBJ = new SaveVSpuSizeTableRelationResponseHelper();
		
		public static SaveVSpuSizeTableRelationResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SaveVSpuSizeTableRelationResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
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
					
					
					
					
					
					if ("is_success".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetIs_success(value);
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
		
		
		public void Write(SaveVSpuSizeTableRelationResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteI32((int)structs.GetBrand_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brand_id can not be null!");
			}
			
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sn can not be null!");
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
			
			
			if(structs.GetIs_success() != null) {
				
				oprot.WriteFieldBegin("is_success");
				oprot.WriteBool((bool)structs.GetIs_success());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_success can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SaveVSpuSizeTableRelationResponse bean){
			
			
		}
		
	}
	
}